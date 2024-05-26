namespace FloydAlg
{
    partial class InformationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InformationForm));
            InfTextBox = new RichTextBox();
            SuspendLayout();
            // 
            // InfTextBox
            // 
            InfTextBox.BackColor = Color.Honeydew;
            InfTextBox.Dock = DockStyle.Fill;
            InfTextBox.Location = new Point(0, 0);
            InfTextBox.Margin = new Padding(2);
            InfTextBox.Name = "InfTextBox";
            InfTextBox.Size = new Size(606, 556);
            InfTextBox.TabIndex = 0;
            InfTextBox.Text = resources.GetString("InfTextBox.Text");
            // 
            // InformationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Honeydew;
            ClientSize = new Size(606, 556);
            Controls.Add(InfTextBox);
            Margin = new Padding(2);
            Name = "InformationForm";
            Text = "InformationForm";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox InfTextBox;
    }
}