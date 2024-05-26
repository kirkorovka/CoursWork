using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FloydAlg 
{
    public partial class MainForm : Form
    {

        private Dictionary<string, Point> vertexPositions;
        private string selectedStartVertex = null;

        private List<StateStep> steps;
        private Graph graph;

        int IndexOfCurrentAction = 0;
        private int currentStep = -1;
        private int[,] matrix;

        InformationForm form;

        public MainForm()
        {
            InitializeComponent();
            vertexPositions = new Dictionary<string, Point>();
            Connector.Enabled = false;

            graph = new Graph();
            steps = new List<StateStep>();

            steps.Add(new StateStep("> Obj of Graph created (start)", graph));
        }

        private void AddStateStep(string action)
        {
            Graph snapshot = graph.Clone();

            StateStep state = new StateStep(action, snapshot);
            steps.Add(state);

            stateBox.Items.Add(state);
            IndexOfCurrentAction++;
        }

        private bool moreThanOneVertex()
        {
            return graph.Vertices.Count > 1;
        }

        private void btnAddVertex_Click(object sender, EventArgs e)
        {
            string vertexName = txtVertexName.Text.Trim();

            // Проверка пусто ли имя вершины
            if (string.IsNullOrEmpty(vertexName))
            {

                string startVertexName = startV.Text.Trim();
                string destinationVertexName = destinationV.Text.Trim();

                if (string.IsNullOrEmpty(startVertexName) || string.IsNullOrEmpty(destinationVertexName))
                {
                    MessageBox.Show("Please select start and destination vertices.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Проверка содержат ли startV и DestinationV допустимые имена вершин
                if (graph.Vertices.ContainsKey(startVertexName) && graph.Vertices.ContainsKey(destinationVertexName))
                {
                    // Добавьте соединение между существующими вершинами
                    int weight = (int)numConnectionWeight.Value;
                    graph.AddEdge(startVertexName, destinationVertexName, weight);

                    AddStateStep("> Connection between '" + startVertexName + "' & '" + destinationVertexName + "' created");


                    // Перерисовать граф
                    RedrawGraph();
                }

                else MessageBox.Show("One or more selected vertices do not exist in the graph.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if (!string.IsNullOrEmpty(vertexName)) // Добавить новую вершину
            {
                if (graph.Vertices.ContainsKey(vertexName))
                {
                    MessageBox.Show("Vertex name already exists. Please choose a different name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                AddVertexToGraph(vertexName);

                AddStateStep("> New vertex '" + vertexName + "' added");

                // Разрешить доступ к groupBox, если 2 вершины уже существуют
                if (moreThanOneVertex()) Connector.Enabled = true;
            }
            else MessageBox.Show("Please enter a valid vertex name or select existing vertices.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            txtVertexName.Text = "";
        }

        private void AddVertexToGraph(string vertexName)
        {
            // Добавить вершину в граф
            graph.AddVertex(vertexName);

            // Создать случайное положение вершины
            Random rnd = new Random();
            int x = rnd.Next(graphPanel.Width - 40) + 20;
            int y = rnd.Next(graphPanel.Height - 40) + 20;
            Point position = new Point(x, y);

            // Сохранить положение вершины
            vertexPositions[vertexName] = position;


            RedrawGraph();
        }

        private void RedrawGraph()
        {
            using (Graphics g = graphPanel.CreateGraphics())
            {
                g.Clear(Color.Honeydew);

                // Отрисовка вершины
                foreach (var entry in vertexPositions)
                {
                    string vertexName = entry.Key;
                    Point center = entry.Value;
                    g.FillEllipse(Brushes.Red, center.X - 20, center.Y - 20, 40, 40); // Color of circules
                    g.DrawString(vertexName, Font, Brushes.White, center.X - 12, center.Y - 18);
                }

                // Отрисовка связи
                foreach (var vertex in graph.Vertices.Values)
                {
                    if (vertexPositions.ContainsKey(vertex.Name))
                    {
                        Point sourceCenter = vertexPositions[vertex.Name];

                        foreach (var neighbor in vertex.Connections)
                        {
                            if (vertexPositions.ContainsKey(neighbor.Key.Name))
                            {
                                Point destinationCenter = vertexPositions[neighbor.Key.Name];


                                if (sourceCenter.X > destinationCenter.X)
                                {
                                    destinationCenter.X += 5;
                                    sourceCenter.X -= 5;
                                }
                                else
                                {
                                    destinationCenter.X -= 6;
                                    sourceCenter.X += 6;
                                }

                                if (sourceCenter.Y > destinationCenter.Y)
                                {
                                    destinationCenter.Y += 8;
                                    sourceCenter.Y -= 8;
                                }
                                else
                                {
                                    destinationCenter.Y -= 10;
                                    sourceCenter.Y += 10;
                                }

                                DrawArrow(g, sourceCenter, destinationCenter);
                                g.DrawString(neighbor.Value.ToString(), Font, Brushes.Black,
                                    Math.Abs((sourceCenter.X + destinationCenter.X) / 2),
                                    Math.Abs((sourceCenter.Y + destinationCenter.Y) / 2));
                            }
                        }
                    }
                }
            }
        }

        private void DrawArrow(Graphics g, Point source, Point destination)
        {
            Pen line = new Pen(Color.Green, 3);
            g.DrawLine(line, source, destination);

            // Рассчитайте наконечники стрел
            double angle = Math.Atan2(destination.Y - source.Y, destination.X - source.X);

            Point arrowSide1 = new Point(
                (int)(destination.X - 25 * Math.Cos(angle - Math.PI / 9)),
                (int)(destination.Y - 25 * Math.Sin(angle - Math.PI / 9)));
            Point arrowSide2 = new Point(
                (int)(destination.X - 25 * Math.Cos(angle + Math.PI / 9)),
                (int)(destination.Y - 25 * Math.Sin(angle + Math.PI / 9)));

            // Отрисовка стрелки
            g.DrawLine(line, destination, arrowSide1);
            g.DrawLine(line, destination, arrowSide2);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            selectedStartVertex = null;
            vertexPositions.Clear();
            graph.Clear();


            matrix = new int[0, 0];
            DrawMatrix(0, 0, 0);

            stateBox.Items.Clear();
            AddStateStep("> Everything was removed ");

            graphPanel.Refresh();
        }

        private void btnRunAlgorithm_Click(object sender, EventArgs e)
        {
            FloydAlgorithm alg = new FloydAlgorithm(graph);
            matrix = alg.currentFill;
            int cnt = alg.elms;

            int lbW = 40;
            int lbH = 30;
            currentStep = -1;

            matrix = alg.SearchPath();
            DrawMatrix(cnt, lbW, lbH);
            
           

        }
        /*
        private void DrawMatrix(int[,] mtx, int n, int w, int h)
        {
            Graphics g = Matrixpanel.CreateGraphics();
            if (mtx.Length == 0  n == 0  w == 0 || h == 0)    {
                Matrixpanel.Controls.Clear(); g.Clear(Color.Teal);
                return;
            }
            // space between, tiles bounds
            Padding padding = new Padding(10);    // set names for vertexes
            int cw = 0; foreach (var corteg in vertexPositions)
            {
                g.DrawString(corteg.Key, Font, Brushes.White, cw += w + 5, 5);
            }
            int spaceForLetters = 40;
            for (int i = 0; i < n; i++)
            {
                g.DrawString(vertexPositions.ElementAt(i).Key, Font,
                    Brushes.White, padding.Left, i * (h + padding.Top) + spaceForLetters);
                for (int j = 0; j < n; j++)
                {
                    Label newLb = new Label();
                    if (mtx[i, j] > 100 || mtx[i, j] == -1) newLb.Text = "~"; else newLb.Text = mtx[i, j].ToString();
                    newLb.ForeColor = Color.White;
                    newLb.Size = new Size(w, h); newLb.Location = new Point(j * (w + padding.Left) + spaceForLetters,
                                               i * (h + padding.Top) + spaceForLetters);            // add to panel
                    Matrixpanel.Controls.Add(newLb);            // nums[i, j] = newLb;
                }
            }
        }*/

        private void DrawMatrix(int n, int w, int h) {
            Graphics g = Matrixpanel.CreateGraphics();

            /* if (matrix == null)
             {
                 Matrixpanel.Controls.Clear();
                 g.Clear(Color.Honeydew);
                 return;
             }*/

            Matrixpanel.Controls.Clear();
            g.Clear(Color.Honeydew);
            

            Padding padding = new Padding(10);
            int spaceForLetters = 40;
            int cw = 0;
            foreach (var corteg in vertexPositions)
            {
                g.DrawString(corteg.Key, Font, Brushes.Black, cw += w + 5, 5);
            }
            

            for (int i = 0; i < n; i++)
            {
                g.DrawString(vertexPositions.ElementAt(i).Key, Font, Brushes.Black, padding.Left, i * (h + padding.Top) + spaceForLetters);

                for (int j = 0; j < n; j++)
                {
                    if (i <= currentStep && j <= currentStep)
                    {
                        Label label = Matrixpanel.Controls.OfType<Label>().FirstOrDefault(x => x.Tag != null && (int)x.Tag == i * n + j);
                        if (label == null)
                        {
                            label = new Label();
                            if (matrix[i, j] > 100)
                            {
                                label.Text = "~";
                            }
                            else
                            {
                                label.Text = matrix[i, j].ToString();
                            }
                            label.ForeColor = Color.Black;
                            label.Size = new Size(w, h);
                            label.Location = new Point(j * (w + padding.Left) + spaceForLetters, i * (h + padding.Top) + spaceForLetters);
                            label.Tag = i * n + j;
                            Matrixpanel.Controls.Add(label);
                        }
                        else
                        {
                            if (matrix[i, j] > 100)
                            {
                                label.Text = "~";
                            }
                            else
                            {
                                label.Text = matrix[i, j].ToString();
                            }
                        }
                    }
                    else
                    {
                        Label label = Matrixpanel.Controls.OfType<Label>().FirstOrDefault(x => x.Tag != null && (int)x.Tag == i * n + j);
                        if (label != null)
                        {
                            Matrixpanel.Controls.Remove(label);
                        }
                    }
                }
            }
            
        }


        private void txtStartVertex_TextChanged(object sender, EventArgs e)
        {
            selectedStartVertex = startV.Text.Trim();
        }

        private void txtDestinationVertex_TextChanged(object sender, EventArgs e)
        {
            // Проверка что конечная вершина не совпадает с начальной вершиной.
            if (destinationV.Text.Trim() == selectedStartVertex)
            {
                destinationV.Text = "";
                MessageBox.Show("Destination vertex cannot be the same as start vertex.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRemoveVertex_Click(object sender, EventArgs e)
        {
            string vertexToDelete = txtVertexName.Text.Trim();

            if (graph.Vertices.ContainsKey(vertexToDelete))
            {
                // Удалить вершину из графа
                graph.Vertices.Remove(vertexToDelete);

                // Удалить позицию вершины из словаря
                if (vertexPositions.ContainsKey(vertexToDelete))
                {
                    vertexPositions.Remove(vertexToDelete);
                }

                AddStateStep("> Vertex '" + vertexToDelete + "' was removed ");


                RedrawGraph();


                if (moreThanOneVertex()) Connector.Enabled = true;
            }

            else
            {
                MessageBox.Show("Vertex not found in the graph.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void prevState_Click(object sender, EventArgs e)
        {
            if (IndexOfCurrentAction > 0) graph = steps[--IndexOfCurrentAction].GraphSnapshot;
            RedrawGraph();
        }

        private void nextState_Click(object sender, EventArgs e)
        {
            if (IndexOfCurrentAction < steps.Count - 1) graph = steps[++IndexOfCurrentAction].GraphSnapshot;
            RedrawGraph();
        }

        private void InfButton_Click(object sender, EventArgs e)
        {
            form = new InformationForm();
            form.Show();
        }

        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (currentStep > -1)
            {
                currentStep--;
                DrawMatrix(matrix.GetLength(0), 50, 50);
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (currentStep < matrix.Length - 1)
            {
                currentStep++;
                DrawMatrix(matrix.GetLength(0), 50, 50);
            }
        }
    }
}

