using BLL.Repositories;
using DAL;
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
    public partial class CalisanSiparisForm : Form
    {
        public CalisanSiparisForm()
        {
            InitializeComponent();
        }
        MenuKategoriRepository crp = new MenuKategoriRepository();
        UrunRepository Urp = new UrunRepository();
        SiparisRepository spr = new SiparisRepository();
        CalisanRepository calisanrp = new CalisanRepository();
        UrunSiparisDetayRepository Usd = new UrunSiparisDetayRepository();

        private void CalisanSiparisForm_Load(object sender, EventArgs e)
        {
            DataGridViewCellStyle style = new DataGridViewCellStyle();
            style.BackColor = Color.Red;

            textBox1.Text = "Adet Giriniz...";

            comboBox1.DataSource = spr.GetAll().Select(srp => srp.SiparisID).ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Urp.GetAll().Where(urn => urn.KategoriID == 1).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Urp.GetAll().Select(urn => new { urn.UrunID, urn.KategoriID, urn.UrunAdi, urn.UrunAciklamasi, urn.Fiyat, urn.Durum }).Where(urn => urn.KategoriID == 2).ToList();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Urp.GetAll().Select(urn => new { urn.UrunID, urn.KategoriID, urn.UrunAdi, urn.UrunAciklamasi, urn.Fiyat, urn.Durum }).Where(urn => urn.KategoriID == 3).ToList();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Urp.GetAll().Select(urn => new { urn.UrunID, urn.KategoriID, urn.UrunAdi, urn.UrunAciklamasi, urn.Fiyat, urn.Durum }).Where(urn => urn.KategoriID == 4).ToList();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Urp.GetAll().Select(urn => new { urn.UrunID, urn.KategoriID, urn.UrunAdi, urn.UrunAciklamasi, urn.Fiyat, urn.Durum }).Where(urn => urn.KategoriID == 5).ToList();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Urp.GetAll().Select(urn => new { urn.UrunID, urn.KategoriID, urn.UrunAdi, urn.UrunAciklamasi, urn.Fiyat, urn.Durum }).Where(urn => urn.KategoriID == 6).ToList();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Urp.GetAll().Select(urn => new { urn.UrunID, urn.KategoriID, urn.UrunAdi, urn.UrunAciklamasi, urn.Fiyat, urn.Durum }).Where(urn => urn.KategoriID == 7).ToList();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Urp.GetAll().Select(urn => new { urn.UrunID, urn.KategoriID, urn.UrunAdi, urn.UrunAciklamasi, urn.Fiyat, urn.Durum }).Where(urn => urn.KategoriID == 8).ToList();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Urp.GetAll().Select(urn => new { urn.UrunID, urn.KategoriID, urn.UrunAdi, urn.UrunAciklamasi, urn.Fiyat, urn.Durum }).Where(urn => urn.KategoriID == 9).ToList();

        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Urp.GetAll().Select(urn => new { urn.UrunID, urn.KategoriID, urn.UrunAdi, urn.UrunAciklamasi, urn.Fiyat, urn.Durum }).Where(urn => urn.KategoriID == 10).ToList();

        }

        private void button11_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Urp.GetAll().Select(urn => new { urn.UrunID, urn.KategoriID, urn.UrunAdi, urn.UrunAciklamasi, urn.Fiyat, urn.Durum }).Where(urn => urn.KategoriID == 11).ToList();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Urp.GetAll().Select(urn => new { urn.UrunID, urn.KategoriID, urn.UrunAdi, urn.UrunAciklamasi, urn.Fiyat, urn.Durum }).Where(urn => urn.KategoriID == 11).ToList();

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = "1"; }
            else
            { textBox1.Text = textBox1.Text + "1"; }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = "2"; }
            else
            { textBox1.Text = textBox1.Text + "2"; }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = "3"; }
            else
            { textBox1.Text = textBox1.Text + "3"; }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = "4"; }
            else
            { textBox1.Text = textBox1.Text + "4"; }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = "5"; }
            else
            { textBox1.Text = textBox1.Text + "5"; }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = "6"; }
            else
            { textBox1.Text = textBox1.Text + "6"; }
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = "7"; }
            else
            { textBox1.Text = textBox1.Text + "7"; }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = "8"; }
            else
            { textBox1.Text = textBox1.Text + "8"; }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = "9"; }
            else
            { textBox1.Text = textBox1.Text + "9"; }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { textBox1.Text = ""; }
            else
            { textBox1.Text = textBox1.Text + "0"; }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Usd.Insert(new UrunSiparisDetay { UrunID = (int)dataGridView1.CurrentRow.Cells[0].Value, Fiyat = (decimal)dataGridView1.CurrentRow.Cells[4].Value, SiparisID = (int)comboBox1.SelectedValue, SiparisMiktari = Convert.ToInt32(textBox1.Text) });// DÜZELTİLECEK
            Getirrrrrrrr();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridView1.SelectedCells[0].Value;
            Usd.Delete(id);
            Getirrrrrrrr();
        }

        private void button25_Click(object sender, EventArgs e)
        {
            Getirrrrrrrr();
        }

        private void Getirrrrrrrr()
        {
            List<Sipari> a = new List<Sipari>();
            List<UrunSiparisDetay> b = new List<UrunSiparisDetay>();
            a = spr.GetAll();
            b = Usd.GetAll();

            var result = from s in a
                         join usd in b on s.SiparisID equals usd.SiparisID
                         select new
                         {
                             s.SiparisID,
                             usd.SiparisMiktari,
                             usd.UrunID,
                             s.SiparisTarihi,
                             usd.Fiyat
                         };
            dataGridView1.DataSource = result.ToList();
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Text = string.Empty;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
