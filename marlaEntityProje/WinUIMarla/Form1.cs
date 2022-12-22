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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MenuKategoriRepository crp = new MenuKategoriRepository();
        UrunRepository Urp = new UrunRepository();
        SiparisRepository spr = new SiparisRepository();
        CalisanRepository calisanrp = new CalisanRepository();
        UrunSiparisDetayRepository Usd = new UrunSiparisDetayRepository();
        RestaurantRepository rep = new RestaurantRepository();
        MusteriRepository mr = new MusteriRepository();
        MalzemeRepository mar = new MalzemeRepository();
        TedarikciRepository ted = new TedarikciRepository();
        malzemeKategoriRepository mak = new malzemeKategoriRepository();

        private void Form1_Load(object sender, EventArgs e)
        {
            comboMenukat.DataSource = crp.GetAll();
            comboMenukat.DisplayMember = "MenuKategoriAdi";
            comboMenukat.ValueMember = "MenuKategoriID";

            comboSiparisCalisan.DataSource = calisanrp.GetAll();
            comboSiparisCalisan.DisplayMember = "CalisanAdi";
            comboSiparisCalisan.ValueMember = "CalisanID";

            comboUrnSiparisUrn.DataSource = Usd.GetAll();
            comboUrnSiparisUrn.DisplayMember = "UrunID";
            comboUrnSiparisUrn.ValueMember = "Fiyat";

            comboCalisanRest.DataSource = rep.GetAll();
            comboCalisanRest.DisplayMember = "Adres";
            comboCalisanRest.ValueMember = "RestaurantID";

            List<Malzeme> a = new List<Malzeme>();
            List<Tedarikci> b = new List<Tedarikci>();
            List<MalzemeKategori> c = new List<MalzemeKategori>();
            a = mar.GetAll();
            b = ted.GetAll();
            c = mak.GetAll();

            var result = from mq in a
                         join maq in c on mq.MalzemeKategoriID equals maq.MalzemeKategoriID
                         join tq in b on mq.TedarikciID equals tq.TedarikciID
                         //
                         select new
                         {
                             TedarikciID=tq.TedarikciID,
                             Malzeme = maq.MalzemeKategoriAdi + '-' + maq.MalzemeKategoriID
                         };
            comboBox1.DataSource = result.Distinct().ToList();
            comboBox1.DisplayMember = "Malzeme";
            comboBox1.ValueMember ="TedarikciID";
        }

        private void btnMenukategoriGoster_Click(object sender, EventArgs e)
        {
            GetirMenuKategori();

        }

        private void GetirMenuKategori()
        {
            dataGridViewMenuKategori.DataSource = crp.GetAll().Select(c => new { c.MenuKategoriID, c.MenuKategoriAdi, c.MenuID }).ToList();
        }

        private void btnMenuKategoriEkle_Click(object sender, EventArgs e)
        {
            crp.Insert(new MenuKategori {MenuKategoriAdi=textBox1.Text,MenuID=Convert.ToInt32( textBox2.Text) });
            GetirMenuKategori();
            TemizlemenKat();
        }

        MenuKategori secili;
        private void dataGridViewMenuKategori_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int id = (int)dataGridViewMenuKategori.Rows[e.RowIndex].Cells[0].Value;
            secili = crp.GetById(id);
            textBox1.Text = secili.MenuKategoriAdi;
            textBox2.Text = secili.MenuID.ToString();

        }

        private void btnMenuKategoriGuncelle_Click(object sender, EventArgs e)
        {


            secili.MenuKategoriAdi = textBox1.Text;
            secili.MenuID = Convert.ToInt32(textBox2.Text);
            crp.Update(secili);
            GetirMenuKategori();
            TemizlemenKat();

        }

        private void TemizlemenKat()
        {
            textBox1.Text = textBox2.Text = string.Empty;
        }

        private void btnMenuKategoriSil_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewMenuKategori.SelectedCells[0].Value;
            crp.Delete(id);
            GetirMenuKategori();
            TemizlemenKat();
        }

        private void btnMenugoster_Click(object sender, EventArgs e)
        {
            GetirUrun();
        }

        private void GetirUrun()
        {
            dataGridViewUrun.DataSource = Urp.GetAll().Select(c => new { c.UrunID, c.KategoriID, c.UrunAdi, c.UrunAciklamasi, c.Fiyat, c.Durum, }).ToList();
        }

        private void btnUrunEkle_Click(object sender, EventArgs e)
        {
            Urp.Insert(new Urun { KategoriID = (int)comboMenukat.SelectedValue, UrunAdi = txtUrunAdi.Text, UrunAciklamasi = txtUrunAciklama.Text, Fiyat = Convert.ToDecimal(txturunFiyat.Text), Durum = checkUrun.Checked });
            GetirUrun();
            TemizleUrun();

        }

        private void TemizleUrun()
        {
            txtUrunAdi.Text = txtUrunAciklama.Text = txturunFiyat.Text = string.Empty;
            checkUrun.Checked = false;
        }

        Urun SeciliUrun;
        private void dataGridViewUrun_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridViewUrun.Rows[e.RowIndex].Cells[0].Value;
            SeciliUrun = Urp.GetById(id);
            comboMenukat.SelectedValue = SeciliUrun.KategoriID;
            txtUrunAdi.Text = SeciliUrun.UrunAdi;
            txtUrunAciklama.Text = SeciliUrun.UrunAciklamasi;
            txturunFiyat.Text = SeciliUrun.Fiyat.ToString();
            checkUrun.Checked = (bool)SeciliUrun.Durum;

        
        }

        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            SeciliUrun.KategoriID = (int)comboMenukat.SelectedValue;
            SeciliUrun.UrunAdi = txtUrunAdi.Text;
            SeciliUrun.UrunAciklamasi = txtUrunAciklama.Text;
            SeciliUrun.Fiyat = Convert.ToDecimal( txturunFiyat.Text);
            SeciliUrun.Durum = checkUrun.Checked;
            Urp.Update(SeciliUrun);
            TemizlemenKat();

            TemizleUrun();
            GetirUrun();
        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewUrun.SelectedCells[0].Value;
            Urp.Delete(id);
            GetirUrun();
            TemizleUrun();
        }

        private void btnSiparisGoster_Click(object sender, EventArgs e)
        {
            GetirSiparis();
        }

        private void GetirSiparis()
        {
            dataGridViewSiparis.DataSource = spr.GetAll().Select(c => new { c.SiparisID, c.SiparisTarihi, c.TeslimTarihi, c.SiparisTuru, c.MasaNumarası, c.MusteriID, c.CalisanId }).ToList();
        }

        private void btnSiparisEkle_Click(object sender, EventArgs e)
        {
            if (checkSiparisTuru.Checked == true)
            {
                spr.Insert(new Sipari { SiparisTarihi = DateTime.Now, TeslimTarihi = DateTime.Now.AddMinutes(Convert.ToDouble(txtSiparisSuresi.Text)), SiparisTuru = checkSiparisTuru.Checked, MusteriID = Convert.ToInt32(txtSiparisMusteriID.Text) });

            }
            else if (checkSiparisTuru.Checked == false)
            {
                spr.Insert(new Sipari { SiparisTarihi = DateTime.Now, TeslimTarihi = DateTime.Now.AddMinutes(Convert.ToDouble(txtSiparisSuresi.Text)), SiparisTuru = checkSiparisTuru.Checked, MusteriID = Convert.ToInt32(txtSiparisMusteriID.Text), MasaNumarası = Convert.ToInt32(txtSiparisMasaNumarasi.Text), CalisanId = (int)comboSiparisCalisan.SelectedValue });

                GetirSiparis();

            }
            TemizleSiparis();
        }

        private void TemizleSiparis()
        {
            txtSiparisSuresi.Text = txtSiparisMusteriID.Text = txtSiparisMasaNumarasi.Text = string.Empty;
            checkSiparisTuru.Checked = false;
        }

        Sipari SeciliSiparis;
        private void dataGridViewSiparis_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (checkSiparisTuru.Checked==false)
            {
                int id = (int)dataGridViewSiparis.Rows[e.RowIndex].Cells[0].Value;
                SeciliSiparis = spr.GetById(id);     
                checkSiparisTuru.Checked = (bool)SeciliSiparis.SiparisTuru;
                txtSiparisMusteriID.Text = SeciliSiparis.MusteriID.ToString();
            }
            else if (checkSiparisTuru.Checked == true)
            {
                int id = (int)dataGridViewSiparis.Rows[e.RowIndex].Cells[0].Value;
                SeciliSiparis = spr.GetById(id);
                txtSiparisMasaNumarasi.Text = SeciliSiparis.MasaNumarası.ToString();
                checkSiparisTuru.Checked = (bool)SeciliSiparis.SiparisTuru;
                txtSiparisMusteriID.Text = SeciliSiparis.MusteriID.ToString();
                comboSiparisCalisan.SelectedValue = SeciliSiparis.CalisanId;
            }
        }

        private void btnSiparisGuncelle_Click(object sender, EventArgs e)
        {
            SeciliSiparis.MasaNumarası = Convert.ToInt32( txtSiparisMasaNumarasi.Text);
            SeciliSiparis.SiparisTuru = checkSiparisTuru.Checked;
            SeciliSiparis.MusteriID = Convert.ToInt32( txtSiparisMusteriID.Text);
            SeciliSiparis.CalisanId = (int)comboSiparisCalisan.SelectedValue;
            GetirSiparis();
            TemizleSiparis();
    
        }

        private void btnSiparisSil_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewSiparis.SelectedCells[0].Value;
            spr.Delete(id);
            GetirSiparis();
            TemizleSiparis();
        }

        private void btnUrnSiparisGoster_Click(object sender, EventArgs e)
        {
            GetirUrnSİparis();
        }

        private void GetirUrnSİparis()
        {
            dataGridViewUrunSiparis.DataSource = Usd.GetAll().Select(c => new { c.UrunSiparisDetay1, c.UrunID, c.SiparisID, c.SiparisMiktari, c.Fiyat }).ToList();
        }

        private void btnUrnSiparisEkle_Click(object sender, EventArgs e)
        {
            Usd.Insert(new UrunSiparisDetay { UrunID = Convert.ToInt32( txtUrnSprsUrunID.Text), SiparisID =Convert.ToInt32( txtUrnSprs2ID.Text), SiparisMiktari = Convert.ToInt32( txtUrnSparisMktari.Text), Fiyat = Convert.ToDecimal( comboUrnSiparisUrn.SelectedValue )});
            GetirUrnSİparis();
        }

        UrunSiparisDetay SeciliUrnsiparis;
        private void dataGridViewUrunSiparis_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridViewUrunSiparis.Rows[e.RowIndex].Cells[0].Value;
            SeciliUrnsiparis = Usd.GetById(id);

            txtUrnSprsUrunID.Text = SeciliUrnsiparis.UrunID.ToString();
            txtUrnSprs2ID.Text = SeciliUrnsiparis.SiparisID.ToString();
            txtUrnSparisMktari.Text = SeciliUrnsiparis.SiparisMiktari.ToString();
            comboUrnSiparisUrn.SelectedValue = SeciliUrnsiparis.Fiyat;
            
        }

        private void btnUrnSiparisGuncelle_Click(object sender, EventArgs e)
        {
            SeciliUrnsiparis.UrunID = Convert.ToInt32(txtUrnSprsUrunID.Text);
            SeciliUrnsiparis.SiparisID = Convert.ToInt32(txtUrnSprs2ID.Text);
            SeciliUrnsiparis.SiparisMiktari = Convert.ToInt32(txtUrnSparisMktari.Text);
            SeciliUrnsiparis.Fiyat = Convert.ToDecimal(comboUrnSiparisUrn.SelectedValue);

            GetirUrnSİparis();

            TemizleUrnSiparis();
        }

        private void TemizleUrnSiparis()
        {
            txtUrnSprsUrunID.Text = txtUrnSprs2ID.Text = txtUrnSparisMktari.Text = string.Empty;
        }

        private void btnUrnSiparisSil_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewUrunSiparis.SelectedCells[0].Value;
            Usd.Delete(id);
            GetirUrnSİparis();
            TemizleUrnSiparis();
        }

        private void btnCalisanGoster_Click(object sender, EventArgs e)
        {
            GetirCalisan();
        }
        private void GetirCalisan()
        {
            dataGridViewCalisan.DataSource = calisanrp.GetAll().Select(c => new { c.CalisanID, c.CalisanAdi, c.CalisanSoyadi, c.Unvan, c.RestaurantID }).ToList();
        }

        private void btnCalisanEkle_Click(object sender, EventArgs e)
        {
            calisanrp.Insert(new Calisan { CalisanAdi = txtCalisanAdi.Text, CalisanSoyadi = txtCalisanSoyadi.Text, Unvan = txtCalisanUnvan.Text, RestaurantID = Convert.ToInt32(comboCalisanRest.SelectedValue) });

           
            GetirCalisan();
            TemizleCalisan();
        }
        Calisan seciliCalisan;
        private void dataGridViewCalisan_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridViewCalisan.Rows[e.RowIndex].Cells[0].Value;
            seciliCalisan = calisanrp.GetById(id);
            txtCalisanAdi.Text = seciliCalisan.CalisanAdi;
            txtCalisanSoyadi.Text = seciliCalisan.CalisanSoyadi;
            txtCalisanUnvan.Text = seciliCalisan.Unvan;
            comboCalisanRest.SelectedValue = seciliCalisan.RestaurantID;
        }
        private void btnCalisanGuncelle_Click(object sender, EventArgs e)
        {
            seciliCalisan.CalisanAdi = txtCalisanAdi.Text;
            seciliCalisan.CalisanSoyadi = txtCalisanSoyadi.Text;
            seciliCalisan.Unvan = txtCalisanUnvan.Text;
            seciliCalisan.RestaurantID = Convert.ToInt32(comboCalisanRest.SelectedValue);
            GetirCalisan();
            TemizleCalisan();
        }
        private void TemizleCalisan()
        {
            txtCalisanAdi.Text = txtCalisanSoyadi.Text = txtCalisanUnvan.Text = string.Empty;
        }
        private void btnCalisanSil_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewCalisan.SelectedCells[0].Value;
            calisanrp.Delete(id);
            GetirCalisan();
            TemizleCalisan();
        }

        private void btnMusteriGoster_Click(object sender, EventArgs e)
        {
            GetirMusteri();
        }

        private void GetirMusteri()
        {
            dataGridViewMusteri.DataSource = mr.GetAll().Select(c => new {c.MusteriID, c.Adi, c.Soyadi, c.Adres, c.Telefon }).ToList();
        }

        private void btnMusteriEkle_Click(object sender, EventArgs e)
        {
            mr.Insert(new Musteri { Adi = txtMusteriAdi.Text, Soyadi = txtMusteriSoyadi.Text, Adres = txtMusteriAdres.Text, Telefon = txtMusteriTel.Text });
            TemizleMusteri();
            GetirMusteri();
        }
        Musteri SeciliMusteri;
        private void dataGridViewMusteri_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridViewMusteri.Rows[e.RowIndex].Cells[0].Value;
            SeciliMusteri = mr.GetById(id);
            txtMusteriAdi.Text = SeciliMusteri.Adi;
            txtMusteriSoyadi.Text = SeciliMusteri.Soyadi;
            txtMusteriAdres.Text = SeciliMusteri.Adres;
            txtMusteriTel.Text= SeciliMusteri.Telefon;
            GetirMusteri();
        }

        private void btnMusteriGuncelle_Click(object sender, EventArgs e)
        {
            SeciliMusteri.Adi = txtMusteriAdi.Text;
            SeciliMusteri.Soyadi = txtMusteriSoyadi.Text;
            SeciliMusteri.Adres = txtMusteriAdres.Text;
            SeciliMusteri.Telefon = txtMusteriTel.Text;
            GetirMusteri();
            TemizleMusteri();

        }

        private void TemizleMusteri()
        {
            txtMusteriAdi.Text = txtMusteriSoyadi.Text = txtMusteriAdres.Text = txtMusteriTel.Text = string.Empty;
        }

        private void btnMusteriSil_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewMusteri.SelectedCells[0].Value;
            mr.Delete(id);
            GetirMusteri();
            TemizleMusteri();
        }

        private void btnMalzemeGoster_Click(object sender, EventArgs e)
        {
            GetirMalzeme();
        }

        private void GetirMalzeme()
        {
            dataGridViewMalzeme.DataSource = mar.GetAll().Select(c => new { c.MalzemeID, c.MalzemeAdi, c.Durum, c.MalzemeKategoriID, c.TedarikciID }).ToList();
        }

        private void btnMalzemeEkle_Click(object sender, EventArgs e)
        {
            mar.Insert(new Malzeme { MalzemeAdi = txtmalzemeAdi.Text, MalzemeKategoriID = Convert.ToInt32(txtMlzMalzemeKategoriID.Text), Durum = checkMalzemeDurum.Checked, TedarikciID = Convert.ToInt32(comboBox1.SelectedValue) });
            TemizleMalzeme();
            GetirMalzeme();
        }

        private void TemizleMalzeme()
        {
            txtmalzemeAdi.Text = txtMlzMalzemeKategoriID.Text = string.Empty;
            checkMalzemeDurum.Checked = false;
        }

        Malzeme SeciliMalzeme;
        private void dataGridViewMalzeme_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridViewMalzeme.Rows[e.RowIndex].Cells[0].Value;
            SeciliMalzeme = mar.GetById(id);
            txtmalzemeAdi.Text = SeciliMalzeme.MalzemeAdi;
            txtMlzMalzemeKategoriID.Text = SeciliMalzeme.MalzemeKategoriID.ToString();
            checkMalzemeDurum.Checked = (bool)SeciliMalzeme.Durum;
            comboBox1.SelectedValue = SeciliMalzeme.TedarikciID; // COMBOBOX TANIMLANACAK YUKARIDA
            
            
        }

        private void btnMalzemeGuncelle_Click(object sender, EventArgs e)
        {
            SeciliMalzeme.MalzemeAdi = txtMusteriAdi.Text;
            SeciliMalzeme.MalzemeKategoriID = Convert.ToInt32( txtMlzMalzemeKategoriID.Text);
            SeciliMalzeme.Durum = checkMalzemeDurum.Checked;
            SeciliMalzeme.TedarikciID = (int)comboBox1.SelectedValue;
            GetirMalzeme();
            TemizleMalzeme();
        }

        private void btnMalzemeSil_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewMalzeme.SelectedCells[0].Value;
            mar.Delete(id);
            GetirMalzeme();
            TemizleMalzeme();
        }

        private void btnTedarikciGoster_Click(object sender, EventArgs e)
        {
            GetirTedarikci();

        }

        private void GetirTedarikci()
        {
            dataGridViewTedarikci.DataSource = ted.GetAll().Select(c => new { c.TedarikciID, c.TedarikciAdi }).ToList();
        }

        private void btnTedarikciEkle_Click(object sender, EventArgs e)
        {
            ted.Insert(new Tedarikci { TedarikciAdi = txtTedarikciAdi.Text });
            TemizleTedarikci();
            GetirTedarikci();
        }

        private void TemizleTedarikci()
        {
            txtTedarikciAdi.Text = string.Empty;
        }

        Tedarikci SeciliTedarikci;
        private void dataGridViewTedarikci_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = (int)dataGridViewTedarikci.Rows[e.RowIndex].Cells[0].Value;
            SeciliTedarikci = ted.GetById(id);
            txtTedarikciAdi.Text = SeciliTedarikci.TedarikciAdi;
        }

        private void btnTedarikciGuncelle_Click(object sender, EventArgs e)
        {
            SeciliTedarikci.TedarikciAdi = txtTedarikciAdi.Text;
            GetirTedarikci();
            TemizleTedarikci();
        }

        private void btnTedarikciSil_Click(object sender, EventArgs e)
        {
            int id = (int)dataGridViewTedarikci.SelectedCells[0].Value;
            ted.Delete(id);
            GetirTedarikci();
            TemizleTedarikci();
        }

        private void tabControl1_Enter(object sender, EventArgs e)
        {
           
        }
    }
}
