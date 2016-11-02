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
        }

        private System.Drawing.Graphics graphics;
        StreamReader sr = new StreamReader("event_net_list.txt");

        
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

        private void button1_Click(object sender, EventArgs e)
        {
            Event event1 = new Event(1, null);
            event1.DrawEvent(graphics);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Arc arc1 = new Arc(0, 1);
            arc1.DrawArc(graphics);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach(Event ev in eventList)
            {
                ev.DrawEvent(graphics);
            }
            //event1.HighlightEvent(graphics);
        }

        private List<Event> eventList;

        private void button4_Click(object sender, EventArgs e)
        {
            string ev = sr.ReadLine();
            char eventName = ev[0];
            List<int> eventEdges = new List<int>(); 
            Console.Write((char)eventName);
            for (int i = 0; i < ev.Length / 2; i++)
            {
                eventEdges.Add((int)Char.GetNumericValue(ev[i * 2 + 2]));
            }
            foreach(int _edge in eventEdges)
            {
                Console.WriteLine((int)_edge);
            }
            Console.WriteLine();
            eventList.Add(new Event(eventName, eventEdges));

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

public class Event
{
    public Event(int _id, List<int> _edges) 
    {
        id = _id;
        edges = new List<int>();
        edges = _edges;
        location = id * 100;
        size = 50;
    }
    public void DrawEvent(System.Drawing.Graphics graphics)
    {
        Console.Write((string)"Drawing Event");
        System.Drawing.Rectangle rectangle = new System.Drawing.Rectangle(
            (location), 100, size, size);
        graphics.DrawEllipse(System.Drawing.Pens.Black, rectangle);

    }
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

}

public class Arc
{
    public static int nextID = 1;
    public Arc(int _current, int _next)
    {
        id = nextID++;
        //current = _current;
        //next = _next;
        current = id;
        Random random = new Random();
        next = id + random.Next(1,3);
        difference = next - current;
    }
    public void DrawArc(System.Drawing.Graphics graphics)
    {
        int height = 35 + (int)(Math.Pow(10, difference));
        Pen blackPen = new Pen(Color.Black, 1);
        Rectangle rect = new Rectangle(25 + (current * 100), 85 - height, 100 + (difference * 100), height);

        // Create start and sweep angles on ellipse.
        float startAngle = 0.0F;
        float sweepAngle = -180.0F;

        // Draw arc to screen.
        graphics.DrawArc(blackPen, rect, startAngle, sweepAngle);

    }
    public int id { get; set; }
    private int current;
    private int next;
    private int difference;
}