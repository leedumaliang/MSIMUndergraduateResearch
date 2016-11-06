using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Boss
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnGetWindows;
		private const int WM_CLOSE = 16;
		private const int BN_CLICKED = 245;
        const int WM_COMMAND = 0x0111;
        //string hex = "00040778";
        int ImportButtonId = Convert.ToInt32("00040778", 16);
        //const int ImportButtonId = 264056;
        int DrawEventsButtonId = Convert.ToInt32("0006071c", 16);
        //const int DrawEventsButtonId = 395036;
        int DrawArcsButtonId = Convert.ToInt32("0011079A", 16);
        //const int DrawArcsButtonId = 1116058;
        private System.Windows.Forms.Button btnCloseDESVisualizer;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		/// <summary>
		/// The FindWindow API
		/// </summary>
		/// <param name="lpClassName">the class name for the window to search for</param>
		/// <param name="lpWindowName">the name of the window to search for</param>
		/// <returns></returns>
		[DllImport("User32.dll")]
		public static extern Int32 FindWindow(String lpClassName,String lpWindowName);

		/// <summary>
		/// The SendMessage API
		/// </summary>
		/// <param name="hWnd">handle to the required window</param>
		/// <param name="msg">the system/Custom message to send</param>
		/// <param name="wParam">first message parameter</param>
		/// <param name="lParam">second message parameter</param>
		/// <returns></returns>
		[DllImport("user32.dll", CharSet=CharSet.Auto)]
		public static extern int SendMessage(int hWnd, int msg, int wParam, IntPtr lParam);
		
		/// <summary>
		/// The FindWindowEx API
		/// </summary>
		/// <param name="parentHandle">a handle to the parent window </param>
		/// <param name="childAfter">a handle to the child window to start search after</param>
		/// <param name="className">the class name for the window to search for</param>
		/// <param name="windowTitle">the name of the window to search for</param>
		/// <returns></returns>
		[DllImport("user32.dll", SetLastError = true)]
		public static extern IntPtr FindWindowEx(IntPtr parentHandle, string className,  string  windowTitle);

        [DllImport("user32.dll")]
        static extern IntPtr GetDlgItem(IntPtr hWnd, int nIDDlgItem);

        public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnGetWindows = new System.Windows.Forms.Button();
			this.btnCloseDESVisualizer = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnGetWindows
			// 
			this.btnGetWindows.Location = new System.Drawing.Point(16, 24);
			this.btnGetWindows.Name = "btnGetWindows";
			this.btnGetWindows.Size = new System.Drawing.Size(140, 23);
			this.btnGetWindows.TabIndex = 0;
			this.btnGetWindows.Text = "Use DESVisualizer";
			this.btnGetWindows.Click += new System.EventHandler(this.btnGetWindows_Click);
			// 
			// btnCloseDESVisualizer
			// 
			this.btnCloseDESVisualizer.Location = new System.Drawing.Point(16, 72);
			this.btnCloseDESVisualizer.Name = "btnCloseDESVisualizer";
			this.btnCloseDESVisualizer.Size = new System.Drawing.Size(140, 23);
			this.btnCloseDESVisualizer.TabIndex = 2;
			this.btnCloseDESVisualizer.Text = "Close the DESVisualizer";
			this.btnCloseDESVisualizer.Click += new System.EventHandler(this.btnCloseDESVisualizer_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            //this.ClientSize = new System.Drawing.Size(234, 119);
            this.ClientSize = new System.Drawing.Size(702, 357);
            this.Controls.Add(this.btnCloseDESVisualizer);
			this.Controls.Add(this.btnGetWindows);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Test Windows API";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void btnGetWindows_Click(object sender, System.EventArgs e)
		{
			int hwnd=0;
			IntPtr hwndChild=IntPtr.Zero;
           

            //Get a handle for the DESVisualizer Application main window
            hwnd = FindWindow(null, "Form1");
			if(hwnd == 0)
			{
				if(MessageBox.Show("Couldn't find the DESVisualizer. Do you want to start it?","Boss",MessageBoxButtons.YesNo)== DialogResult.Yes)
				{
					System.Diagnostics.Process.Start("DESVisualizer");
				}
			}
			else
			{

                //Get a handle for the "Import" button
                //hwndChild = FindWindowEx((IntPtr)hwnd,IntPtr.Zero,"Button","Import");
                hwndChild = FindWindowEx((IntPtr)hwnd, "Button", "Import");
                //hwndChild = GetDlgItem((IntPtr)hwnd, ImportButtonId);
                //int wParam = (BN_CLICKED << 16) | (ImportButtonId & 65535);
                SendMessage((int)hwndChild,BN_CLICKED,0,IntPtr.Zero);
                //SendMessage((int)hwnd, BN_CLICKED, wParam, hwndChild);
                // SendMessage((int)hwndChild, BN_CLICKED, 0, IntPtr.Zero);

                //Get a handle for the "Draw Events" button
                hwndChild = FindWindowEx((IntPtr)hwnd, "Button","Draw Events");
                //hwndChild = GetDlgItem((IntPtr)hwnd, DrawEventsButtonId);
				
				//send BN_CLICKED message
				SendMessage((int)hwndChild,BN_CLICKED,0,IntPtr.Zero);

				//Get a handle for the "Draw Arcs" button
				//hwndChild = FindWindowEx((IntPtr)hwnd,IntPtr.Zero,"Button","Draw Arcs");
				
				//send BN_CLICKED message
				//SendMessage((int)hwndChild,BN_CLICKED,0,IntPtr.Zero);



			}

		}

		private void btnCloseDESVisualizer_Click(object sender, System.EventArgs e)
		{
			int hwnd=0;

			//Get a handle for the DESVisualizer Application main window
			hwnd=FindWindow(null,"Form1");

			//send WM_CLOSE system message
			if(hwnd!=0)
				SendMessage(hwnd,WM_CLOSE,0,IntPtr.Zero);
		}
	}
}
