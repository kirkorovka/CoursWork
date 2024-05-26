namespace FloydAlg
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnAddVertex = new Button();
            txtVertexName = new TextBox();
            startV = new TextBox();
            destinationV = new TextBox();
            numConnectionWeight = new NumericUpDown();
            noUseLabel = new Label();
            Connector = new GroupBox();
            graphPanel = new Panel();
            InfButton = new Button();
            btnClear = new Button();
            btnRemoveVertex = new Button();
            prevState = new Button();
            nextState = new Button();
            stateBox = new ListBox();
            btnRunAlgorithm = new Button();
            Matrixpanel = new Panel();
            buttonPrev = new Button();
            buttonNext = new Button();
            ((System.ComponentModel.ISupportInitialize)numConnectionWeight).BeginInit();
            Connector.SuspendLayout();
            SuspendLayout();
            // 
            // btnAddVertex
            // 
            btnAddVertex.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnAddVertex.Location = new Point(643, 46);
            btnAddVertex.Margin = new Padding(2);
            btnAddVertex.Name = "btnAddVertex";
            btnAddVertex.Size = new Size(94, 29);
            btnAddVertex.TabIndex = 0;
            btnAddVertex.Text = "Add";
            btnAddVertex.UseVisualStyleBackColor = true;
            btnAddVertex.Click += btnAddVertex_Click;
            // 
            // txtVertexName
            // 
            txtVertexName.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            txtVertexName.Location = new Point(553, 47);
            txtVertexName.Margin = new Padding(2);
            txtVertexName.Name = "txtVertexName";
            txtVertexName.Size = new Size(86, 27);
            txtVertexName.TabIndex = 1;
            // 
            // startV
            // 
            startV.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            startV.Location = new Point(21, 54);
            startV.Margin = new Padding(2);
            startV.Name = "startV";
            startV.Size = new Size(82, 27);
            startV.TabIndex = 2;
            startV.TextChanged += txtStartVertex_TextChanged;
            // 
            // destinationV
            // 
            destinationV.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            destinationV.Location = new Point(192, 54);
            destinationV.Margin = new Padding(2);
            destinationV.Name = "destinationV";
            destinationV.Size = new Size(73, 27);
            destinationV.TabIndex = 3;
            destinationV.TextChanged += txtDestinationVertex_TextChanged;
            // 
            // numConnectionWeight
            // 
            numConnectionWeight.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            numConnectionWeight.Location = new Point(113, 55);
            numConnectionWeight.Margin = new Padding(2);
            numConnectionWeight.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numConnectionWeight.Name = "numConnectionWeight";
            numConnectionWeight.Size = new Size(68, 27);
            numConnectionWeight.TabIndex = 4;
            numConnectionWeight.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // noUseLabel
            // 
            noUseLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            noUseLabel.AutoSize = true;
            noUseLabel.ForeColor = Color.Black;
            noUseLabel.Location = new Point(19, 21);
            noUseLabel.Margin = new Padding(2, 0, 2, 0);
            noUseLabel.Name = "noUseLabel";
            noUseLabel.Size = new Size(241, 20);
            noUseLabel.TabIndex = 5;
            noUseLabel.Text = "From     Weight of connection     To";
            // 
            // Connector
            // 
            Connector.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            Connector.Controls.Add(numConnectionWeight);
            Connector.Controls.Add(noUseLabel);
            Connector.Controls.Add(startV);
            Connector.Controls.Add(destinationV);
            Connector.ForeColor = SystemColors.ActiveCaptionText;
            Connector.Location = new Point(555, 79);
            Connector.Margin = new Padding(2);
            Connector.Name = "Connector";
            Connector.Padding = new Padding(2);
            Connector.Size = new Size(284, 89);
            Connector.TabIndex = 6;
            Connector.TabStop = false;
            Connector.Text = "Connection";
            // 
            // graphPanel
            // 
            graphPanel.Location = new Point(9, 8);
            graphPanel.Margin = new Padding(2);
            graphPanel.Name = "graphPanel";
            graphPanel.Size = new Size(534, 580);
            graphPanel.TabIndex = 7;
            // 
            // InfButton
            // 
            InfButton.ForeColor = SystemColors.ActiveCaptionText;
            InfButton.Location = new Point(9, 592);
            InfButton.Margin = new Padding(2);
            InfButton.Name = "InfButton";
            InfButton.Size = new Size(281, 31);
            InfButton.TabIndex = 15;
            InfButton.Text = "Information";
            InfButton.UseVisualStyleBackColor = true;
            InfButton.Click += InfButton_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClear.Location = new Point(553, 8);
            btnClear.Margin = new Padding(2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(284, 29);
            btnClear.TabIndex = 8;
            btnClear.Text = "Create new graph ";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
            // 
            // btnRemoveVertex
            // 
            btnRemoveVertex.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnRemoveVertex.Location = new Point(741, 46);
            btnRemoveVertex.Margin = new Padding(2);
            btnRemoveVertex.Name = "btnRemoveVertex";
            btnRemoveVertex.Size = new Size(92, 29);
            btnRemoveVertex.TabIndex = 9;
            btnRemoveVertex.Text = "Delete";
            btnRemoveVertex.UseVisualStyleBackColor = true;
            btnRemoveVertex.Click += btnRemoveVertex_Click;
            // 
            // prevState
            // 
            prevState.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            prevState.Location = new Point(551, 592);
            prevState.Margin = new Padding(2);
            prevState.Name = "prevState";
            prevState.Size = new Size(142, 29);
            prevState.TabIndex = 10;
            prevState.Text = "<-";
            prevState.UseVisualStyleBackColor = true;
            prevState.Click += prevState_Click;
            // 
            // nextState
            // 
            nextState.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            nextState.Location = new Point(699, 593);
            nextState.Margin = new Padding(2);
            nextState.Name = "nextState";
            nextState.Size = new Size(134, 29);
            nextState.TabIndex = 11;
            nextState.Text = "->";
            nextState.UseVisualStyleBackColor = true;
            nextState.Click += nextState_Click;
            // 
            // stateBox
            // 
            stateBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            stateBox.BackColor = Color.Honeydew;
            stateBox.ForeColor = Color.Black;
            stateBox.FormattingEnabled = true;
            stateBox.Location = new Point(551, 465);
            stateBox.Margin = new Padding(2);
            stateBox.Name = "stateBox";
            stateBox.Size = new Size(285, 124);
            stateBox.TabIndex = 12;
            // 
            // btnRunAlgorithm
            // 
            btnRunAlgorithm.Anchor = AnchorStyles.Right;
            btnRunAlgorithm.Location = new Point(551, 401);
            btnRunAlgorithm.Margin = new Padding(2);
            btnRunAlgorithm.Name = "btnRunAlgorithm";
            btnRunAlgorithm.Size = new Size(286, 26);
            btnRunAlgorithm.TabIndex = 13;
            btnRunAlgorithm.Text = "Floyd Algorithm";
            btnRunAlgorithm.UseVisualStyleBackColor = true;
            btnRunAlgorithm.Click += btnRunAlgorithm_Click;
            // 
            // Matrixpanel
            // 
            Matrixpanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            Matrixpanel.BackColor = Color.Honeydew;
            Matrixpanel.Location = new Point(555, 172);
            Matrixpanel.Margin = new Padding(2);
            Matrixpanel.Name = "Matrixpanel";
            Matrixpanel.Size = new Size(278, 225);
            Matrixpanel.TabIndex = 14;
            // 
            // buttonPrev
            // 
            buttonPrev.Location = new Point(551, 432);
            buttonPrev.Name = "buttonPrev";
            buttonPrev.Size = new Size(142, 29);
            buttonPrev.TabIndex = 16;
            buttonPrev.Text = "Back";
            buttonPrev.UseVisualStyleBackColor = true;
            buttonPrev.Click += buttonPrev_Click;
            // 
            // buttonNext
            // 
            buttonNext.Location = new Point(694, 432);
            buttonNext.Name = "buttonNext";
            buttonNext.Size = new Size(142, 29);
            buttonNext.TabIndex = 17;
            buttonNext.Text = "Next";
            buttonNext.UseVisualStyleBackColor = true;
            buttonNext.Click += buttonNext_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(844, 634);
            Controls.Add(buttonNext);
            Controls.Add(buttonPrev);
            Controls.Add(btnRunAlgorithm);
            Controls.Add(InfButton);
            Controls.Add(Matrixpanel);
            Controls.Add(prevState);
            Controls.Add(nextState);
            Controls.Add(stateBox);
            Controls.Add(btnRemoveVertex);
            Controls.Add(btnClear);
            Controls.Add(graphPanel);
            Controls.Add(Connector);
            Controls.Add(txtVertexName);
            Controls.Add(btnAddVertex);
            Margin = new Padding(2);
            Name = "MainForm";
            Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)numConnectionWeight).EndInit();
            Connector.ResumeLayout(false);
            Connector.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private void DestinationV_TextChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private Button btnAddVertex;
        private TextBox txtVertexName;
        private TextBox startV;
        private TextBox destinationV;
        private NumericUpDown numConnectionWeight;
        private Label noUseLabel;
        private GroupBox Connector;
        private Panel graphPanel;
        private Button btnClear;
        private Button btnRemoveVertex;
        private Button prevState;
        private Button nextState;
        private ListBox stateBox;
        private Button btnRunAlgorithm;
        private Panel Matrixpanel;
        private Button InfButton;
        private Button buttonPrev;
        private Button buttonNext;
    }
}