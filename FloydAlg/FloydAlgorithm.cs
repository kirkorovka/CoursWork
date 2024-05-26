using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FloydAlg
{
    public class FloydAlgorithm
    {
        private Dictionary<string, int> vertexIndexMap;
        private int[,] dist;
        private int[,] next;
        public int[,] currentFill;
        public int elms = 0;

        public FloydAlgorithm(Graph graph)
        {
            Implement(graph);
        }

        private void Implement(Graph graph)
        {
            // Словарь связывающий имена вершин с индексом в матрице расстояний
            vertexIndexMap = new Dictionary<string, int>();
            int index = 0;
            foreach (var vertexName in graph.Vertices.Keys)
            {
                vertexIndexMap[vertexName] = index;
                index++;
            }

            int n = graph.Vertices.Count;
            dist = new int[n, n];
            next = new int[n, n];
            elms = n;

            // Инициализировать расстояние 
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    dist[i, j] = (i == j) ? 0 : 101;
                    // 1–100 (макс.)
                    next[i, j] = -1;
                }
            }

            // Заполнить массив расстояний 
            foreach (var startVertexName in graph.Vertices.Keys)
            {
                var startVertex = graph.Vertices[startVertexName];
                int startIndex = vertexIndexMap[startVertexName];

                foreach (var endVertex in startVertex.Connections.Keys)
                {
                    int endIndex = vertexIndexMap[endVertex.Name];
                    int weight = startVertex.Connections[endVertex];
                    dist[startIndex, endIndex] = weight;
                    next[startIndex, endIndex] = endIndex;
                }
            }

            currentFill = dist;
        }

       //Метод реализации алгоритма
        public int[,] SearchPath()
        {
            int n = dist.GetLength(0);

            // Алгоритм Флойда

            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (dist[i, k] != 101 && dist[k, j] != 101 &&
                            dist[i, j] > dist[i, k] + dist[k, j]) {

                            dist[i, j] = dist[i, k] + dist[k, j];
                            next[i, j] = next[i, k];
                        }
                    }
                }
            }

            return currentFill = dist;
        }

       
    }
}
