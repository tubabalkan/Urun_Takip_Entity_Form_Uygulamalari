using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip_Entity
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DbUrunEntities db = new DbUrunEntities();
        private void BtnListele_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.TblMusteri.ToList();

            var degerler = from x in db.TblMusteri
                           select new
                           {
                               x.MusteriID,
                               x.Ad,
                               x.Soyad,
                               x.Bakiye
                           };

            dataGridView1.DataSource = degerler.ToList();
                          // var tüm degişken türlerini kapsar 

        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            TblMusteri t = new TblMusteri();
            t.Ad = TxtAd.Text;
            t.Bakiye = decimal.Parse(TxtBakiye.Text);
            t.Sehir = TxtSehir.Text;
            t.Soyad = TxtSoyad.Text;
            db.TblMusteri.Add(t);
            db.SaveChanges();
            MessageBox.Show("Yeni Musteri Kaydı Yapıldı!!");

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var x = db.TblMusteri.Find(id);
            db.TblMusteri.Remove(x);// x ten gelen değeri sil
            db.SaveChanges();//değişiklikleri kaydet
            MessageBox.Show("Musteri Kaydi Silinmiştir");

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var x = db.TblMusteri.Find(id);
            x.Ad = TxtAd.Text;
            x.Soyad = TxtSoyad.Text;
            x.Sehir = TxtSehir.Text;
            x.Bakiye = decimal.Parse(TxtBakiye.Text);
            db.SaveChanges();
            MessageBox.Show("Musteri Bilgileri Guncellendi");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
