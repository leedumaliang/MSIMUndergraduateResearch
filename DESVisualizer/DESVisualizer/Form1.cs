using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
            eventList = new List<Event>();
            arcList = new List<Arc>();
        }

        private System.Drawing.Graphics graphics;
        private StreamReader sr = new StreamReader("event_net_list.txt");
        private List<Event> eventList;
        private List<Arc> arcList;
        
        //private void drawArc(int current, int next)
        //{
        //    Rectangle rect = new Rectangle(25 + (current * 100), 35 - (next * 10), 100 + (next * 100), 35 + (next * 10));
        //    Pen blackPen = new Pen(Color.Black, 3);

        //    // Create start and sweep angles on ellipse.
        //    float startAngle = 0.0F;
        //    float sweepAngle = -180.0F;

        //    // Draw arc to screen.
        //    graphics.DrawArc(blackPen, rect, startAngle, sweepAngle);

        //}

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            //drawArc(0);
            //drawArc(1, 0);
            //drawArc(0, 1);
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Form Load");

        }

        private void DrawEvents_Click(object sender, EventArgs e)
        {
            foreach (Event ev in eventList)
            {
                ev.DrawEvent(graphics); 
            }
        }

        private void DrawArcs_Click(object sender, EventArgs e)
        {
            foreach (Arc arc in arcList)
            {
                arc.DrawArc(graphics);
            }
        }

        private void ImportButton_Click(object sender, EventArgs e)
        {
            int edgeCount = 0; 
            while (sr.Peek() >= 0)
            {
                string ev = sr.ReadLine();
                int eventName = ev[0] - '0';
                List<int> eventEdges = new List<int>(); 
                //Console.Write((char)eventName);
                for (int i = 0; i < ev.Length / 2; i++)
                {
                    eventEdges.Add(edgeCount++);
                    int edge = (int)char.GetNumericValue(ev[i * 2 + 2]);
                    arcList.Add(new Arc(eventName, edge)); 
                    //eventEdges.Add((int)Char.GetNumericValue(ev[i * 2 + 2]));
                }
                //foreach(int _edge in eventEdges)
                //{
                //    Console.WriteLine((int)_edge);
                //}
                //Console.WriteLine();
                eventList.Add(new Event(eventName, eventEdges));
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            eventList.ElementAt(int.Parse(textBox1.Text)).HighlightEvent(graphics);
        }

    }
}

public class Event
{
    public Event(int _id, List<int> _edges) 
    {
        Console.WriteLine();
        Console.Write(_id);
        id = _id;
        edges = new List<int>();
        edges = _edges;
        location = id * 200;
        size = 100;
    }
    public void DrawEvent(Graphics graphics)
    {
        Console.Write((string)"Drawing Event");
        System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(
            (location), 100, size, size);
        graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);
        //graphics.DrawRectangle(System.Drawing.Pens.Black, rectangle);
        graphics.DrawString(id.ToString(), drawFont, drawBrush, location + 40, 137, drawFormat);
    }
    //public void DrawEdges(Graphics graphics)
    //{
    //    Console.Write((string)"Drawing Edges");
    //    foreach ( edge in edges)
    //    {
    //        edge.
    //    }
    //}
    public void HighlightEvent(System.Drawing.Graphics graphics)
    {
        System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(
            (location), 100, size, size);
        graphics.DrawEllipse(System.Drawing.Pens.Yellow, rectangle);
    }
    public int id { get; }
    private List<int> edges;
    private int location;
    private int size;
    private System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 16);
    private System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
    private System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();


}

public class Arc
{
    public static int nextID = 1;
    public Arc(int _current, int _next)
    {
        id = nextID++;
        //current = _current;
        //next = _next;
        current = _current;
        next = _next;
        difference = next - current;
    }
    public void DrawArc(System.Drawing.Graphics graphics)
    {
        //int height = 35 + (int)(Math.Pow(10, difference));
        int height = difference * 50;
        Pen blackPen = new Pen(Color.Black, 1);
        Rectangle rect;
        if (height > 0)
        {
            rect = new Rectangle(50 + (current * 200), 100 - height / 2, difference * 200, height);
            float startAngle = 0.0F;
            float sweepAngle = -180.0F;
            graphics.DrawArc(blackPen, rect, startAngle, sweepAngle);
            //graphics.DrawRectangle(blackPen, rect);
        }
        else
        {
            rect = new Rectangle(50 + (next * 200), 200 + height / 2, difference * -200, height * -1);
            float startAngle = 0.0F;
            float sweepAngle = 180.0F;
            graphics.DrawArc(blackPen, rect, startAngle, sweepAngle);
            //graphics.DrawRectangle(blackPen, rect);
        }
    }
    public int id { get; set; }
    private int current;
    private int next;
    private int difference;
}