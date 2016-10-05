using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DESVisualizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //DrawIt(0);
            graphics = this.CreateGraphics();
            this.Paint += new PaintEventHandler(pictureBox1_Paint); 
        }

        private System.Drawing.Graphics graphics;

        private void DrawIt(int offset)
        {
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(
                (100 * offset), 50, 50, 50);
            graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawIt(0); 
            DrawIt(1); 
            DrawIt(2); 
            DrawIt(3); 
        }
        
        private void drawArc(int current, int next)
        {
            Rectangle rect = new Rectangle(25 + (current * 100), 35 - (next * 10), 100 + (next * 100), 35 + (next * 10));
            Pen blackPen = new Pen(Color.Black, 3);

            // Create start and sweep angles on ellipse.
            float startAngle = 0.0F;
            float sweepAngle = -180.0F;

            // Draw arc to screen.
            graphics.DrawArc(blackPen, rect, startAngle, sweepAngle);

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            DrawIt(0);
            DrawIt(1);
            DrawIt(2);
            DrawIt(3);
            //drawArc(0);
            drawArc(1, 0);
            drawArc(0, 1);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form Load");

        }
    }
}
