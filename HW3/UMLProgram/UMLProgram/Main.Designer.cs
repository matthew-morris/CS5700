namespace UMLProgram
{
    partial class Main
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
            this.ClassDiagram = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ClassDiagram
            // 
            this.ClassDiagram.AccessibleName = "ClassDiagramButton";
            this.ClassDiagram.Location = new System.Drawing.Point(13, 13);
            this.ClassDiagram.Name = "ClassDiagram";
            this.ClassDiagram.Size = new System.Drawing.Size(97, 23);
            this.ClassDiagram.TabIndex = 0;
            this.ClassDiagram.Text = "ClassDiagram";
            this.ClassDiagram.UseVisualStyleBackColor = true;
            this.ClassDiagram.Click += new System.EventHandler(this.button1_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 519);
            this.Controls.Add(this.ClassDiagram);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ClassDiagram;
    }
}

