namespace DESVisualizer
{
    partial class Form1
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
            this.DrawEvents = new System.Windows.Forms.Button();
            this.ImportButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.DrawArcs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DrawEvents
            // 
            this.DrawEvents.Location = new System.Drawing.Point(244, 0);
            this.DrawEvents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.DrawEvents.Name = "DrawEvents";
            this.DrawEvents.Size = new System.Drawing.Size(112, 35);
            this.DrawEvents.TabIndex = 2;
            this.DrawEvents.Text = "Draw Events";
            this.DrawEvents.UseVisualStyleBackColor = true;
            this.DrawEvents.Click += new System.EventHandler(this.DrawEvents_Click);
            // 
            // ImportButton
            // 
            this.ImportButton.Location = new System.Drawing.Point(368, 0);
            this.ImportButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(112, 35);
            this.ImportButton.TabIndex = 3;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.ImportButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(490, 0);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(148, 26);
            this.textBox1.TabIndex = 4;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // DrawArcs
            // 
            this.DrawArcs.Location = new System.Drawing.Point(13, 2);
            this.DrawArcs.Name = "DrawArcs";
            this.DrawArcs.Size = new System.Drawing.Size(143, 33);
            this.DrawArcs.TabIndex = 5;
            this.DrawArcs.Text = "Draw Arcs";
            this.DrawArcs.UseVisualStyleBackColor = true;
            this.DrawArcs.Click += new System.EventHandler(this.DrawArcs_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2552, 1000);
            this.Controls.Add(this.DrawArcs);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.DrawEvents);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button DrawEvents;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button DrawArcs;
    }
}

