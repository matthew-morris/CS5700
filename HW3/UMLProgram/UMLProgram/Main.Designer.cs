﻿namespace UMLProgram
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
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ClassDiagram
            // 
            this.ClassDiagram.AccessibleName = "ClassDiagramButton";
            this.ClassDiagram.Location = new System.Drawing.Point(17, 16);
            this.ClassDiagram.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ClassDiagram.Name = "ClassDiagram";
            this.ClassDiagram.Size = new System.Drawing.Size(129, 28);
            this.ClassDiagram.TabIndex = 0;
            this.ClassDiagram.Text = "ClassDiagram";
            this.ClassDiagram.UseVisualStyleBackColor = true;
            this.ClassDiagram.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 52);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "Aggregation";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 639);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ClassDiagram);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Main";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ClassDiagram;
        private System.Windows.Forms.Button button1;
    }
}

