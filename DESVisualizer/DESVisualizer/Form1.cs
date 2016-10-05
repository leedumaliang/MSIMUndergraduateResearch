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
        }

        private void DrawIt(int offset)
        {
            System.Drawing.Graphics graphics = this.CreateGraphics();
            System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(
                (50 * offset), 50, 50, 50);
            graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DrawIt(0); 
        }
    }
}
