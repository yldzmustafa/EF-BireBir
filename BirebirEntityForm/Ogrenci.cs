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
using System.Data.Entity;

namespace BirebirEntityForm
{
    public partial class Ogrenci : Form
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

        public Ogrenci()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 20, 20));
        }

        private void Ogrenci_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Ogrenci_Load(object sender, EventArgs e)
        {
            using(var db=new Baglanti())
            {
                dataGridView1.DataSource = db.ogrenciTs.ToList();
            }
        }

        //ekle butonu
        private void button3_Click(object sender, EventArgs e)
        {
            using (var db = new Baglanti())
            {
                var ogrenci = new OgrenciT { ad = textBox1.Text, Soyad = textBox2.Text };
                db.ogrenciTs.Add(ogrenci);
                db.SaveChanges();

            }
            Ogrenci_Load(this, null);
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Select();
        }

        //güncelle butonu
        private void button4_Click(object sender, EventArgs e)
        {
            using (var db=new Baglanti())
            {
                int a = int.Parse(textBox3.Text);
                var ogrenci = from b in db.ogrenciTs
                              where b.Id == a
                              select b;
                foreach (var item in ogrenci)
                {
                    item.ad = textBox1.Text;
                    item.Soyad = textBox2.Text;
                }
                db.SaveChanges();
            }
            Ogrenci_Load(this, null);
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Select();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
