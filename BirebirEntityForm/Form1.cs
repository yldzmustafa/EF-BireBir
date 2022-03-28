using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace BirebirEntityForm
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
            int nLeftRect,     // x-coordinate of upper-left corner
            int nTopRect,      // y-coordinate of upper-left corner
            int nRightRect,    // x-coordinate of lower-right corner
            int nBottomRect,   // y-coordinate of lower-right corner
            int nWidthEllipse, // width of ellipse
            int nHeightEllipse // height of ellipse
        );
        public System.Windows.Forms.BorderStyle BorderStyle { get; set; }
        public void CreateMyPanel()
        {
            Panel panel1 = new Panel();

            // Initialize the Panel control.
            panel2.Location = new Point(56, 140);
            panel2.Size = new Size(500, 100);
            // Set the Borderstyle for the Panel to three-dimensional.
            panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        }


        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
            CreateMyPanel();

        }

        private void yuvarlakButon1_Click(object sender, EventArgs e)
        {
            Ogrenci frm = new Ogrenci();
            this.Hide();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void yuvarlakButon2_Click(object sender, EventArgs e)
        {
            Adres frm = new Adres();
            this.Hide();
            frm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
