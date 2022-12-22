using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinUIMarla
{
    public partial class GirisForm : Form
    {
        public GirisForm()
        {
            InitializeComponent();
        }

        private void GirisForm_Load(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtKullanici.Text == "Admin" && txtSifre.Text == "thelastdance")
            {
                this.BackColor = Color.Linen;

                panel2.Controls.Clear();
                Form1 yntc = new Form1();
                yntc.TopLevel = false;
                yntc.Dock = DockStyle.Fill;
                panel2.Controls.Add(yntc);
                yntc.BringToFront();
                yntc.Show();
                label3.Text = "YÖNETİCİ";

                panel1.Controls.Clear();
                panel3.Controls.Add(button2);
                panel3.Controls.Add(label3);
                this.BackgroundImage = null;
                


            }
            else if (txtKullanici.Text == "Emekci" && txtSifre.Text == "1234")
            {
                panel2.Controls.Clear();
                CalisanSiparisForm clsn = new CalisanSiparisForm();
                clsn.TopLevel = false;
                clsn.Dock = DockStyle.Fill;
                panel2.Controls.Add(clsn);

                clsn.BringToFront();
                clsn.Show();
                label3.Text = "SİPARİS";
                panel1.Controls.Clear();
                panel3.Controls.Add(button2);
                panel3.Controls.Add(label3);
                this.BackColor = Color.SeaShell;
                this.BackgroundImage = null;
            }
            else
            {


                MessageBox.Show("Kullanıcı adı veya şifre hatalı girdiniz. Lütfen kontrol ediniz");
            }
            foreach (var item in panel1.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Clear();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Controls.Clear();
            panel3.Controls.Clear();
            panel1.Controls.Add(txtKullanici);
            panel1.Controls.Add(txtSifre);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(button1);
            this.BackgroundImage = Properties.Resources._123;
            foreach (var item in panel1.Controls)
            {
                if (item is TextBox)
                {
                    TextBox txt = (TextBox)item;
                    txt.Clear();
                }
            }
        }
    }
}
