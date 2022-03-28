using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BirebirEntityForm
{
    public partial class Adres : Form
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
        public Adres()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Adres_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void Adres_Load(object sender, EventArgs e)
        {
            using (var db=new Baglanti())
            {
                dataGridView1.DataSource = db.adresses.ToList();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (var db=new Baglanti())
            {
                var adres = new Adress { ID = int.Parse(textBox1.Text), Adres = textBox2.Text };
                db.adresses.Add(adres);
                db.SaveChanges();
            }
            Adres_Load(this, null);
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Select();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (var db=new Baglanti())
            {
                int a = int.Parse(textBox1.Text);
                var adres = from b in db.adresses
                            where b.ID == a
                            select b;
                foreach (var item in adres)
                {
                    item.ID = int.Parse(textBox1.Text);
                    item.Adres = textBox2.Text;
                }
                db.SaveChanges();

            }
            Adres_Load(this, null);
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Select();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
