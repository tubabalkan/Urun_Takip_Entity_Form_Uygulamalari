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
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }

        private void FrmUrunler_Load(object sender, EventArgs e)
        {
            urunlistesi();
            comboBox1.DataSource = db.TblKategori.ToList();//combobox ın veri kaynagı kategori tablosundan gelsin
            comboBox1.ValueMember = "ID";//arka kısımda çalışacak deger
            comboBox1.DisplayMember = "Ad";//on kısımda kullanıcıya görünecek kısım


        }
DbUrunEntities db = new DbUrunEntities();
        void urunlistesi()
        {
            var urunler = from x in db.TblUrun // sadece istenilen kısmı listeler
                          select new
                          {
                              x.UrunId,
                              x.UrunAd,
                              x.AlisFiyat,
                              x.SatisFiyat,
                              x.TblKategori.Ad//kategori tablosunda adı getirir.

                          };
            dataGridView1.DataSource = urunler.ToList();

        
        }
        void temizle()
        {
            TxtAlisFiyat.Text = "";
            TxtId.Text = "";
            TxtSatisFiyat.Text = "";
            TxtStok.Text = "";
            TxtUrunAd.Text = "";

        }
        private void BtnListele_Click(object sender, EventArgs e)
        {

            // dataGridView1.DataSource = db.TblUrun.ToList();//Ürünler tablosunu listele
            urunlistesi();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            // TxtStok.Text = comboBox1.SelectedValue.ToString();//string ifadeye çevirme
            TblUrun t = new TblUrun();
            t.UrunAd = TxtUrunAd.Text;
            t.Stok = short.Parse(TxtStok.Text);
            t.AlisFiyat = decimal.Parse(TxtAlisFiyat.Text);
            t.SatisFiyat = decimal.Parse(TxtSatisFiyat.Text);
            t.Kategori = int.Parse(comboBox1.SelectedValue.ToString());
            db.TblUrun.Add(t);
            db.SaveChanges();
            MessageBox.Show("Urun Basarili Bir Sekilde Sisteme Kaydedildi");
            urunlistesi();
            temizle();






        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            if(TxtId.Text != "")
            {
                int id = int.Parse(TxtId.Text);
                var x = db.TblUrun.Find(id);
                db.TblUrun.Remove(x);
                db.SaveChanges();
                MessageBox.Show("Üeün Başarılı Bir Şekilde Silindi", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Stop);


            }
            else
            {
                MessageBox.Show("Lütfen Verileri Listeledikten Sonra Bir Satıra Tıklayıp Silmek İstediğiniz Kaydı Seçiniz","Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            urunlistesi();





        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            TxtId.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            //datagridin satırları içerinide tıklamış oldugum satırın indexini al b
            TxtUrunAd.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            TxtStok.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            TxtAlisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            TxtSatisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            //comboBox1.SelectedValue= dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(TxtId.Text);
            var x = db.TblUrun.Find(id);
            x.UrunAd = TxtUrunAd.Text;
            x.Stok = short.Parse(TxtStok.Text);
            x.AlisFiyat = decimal.Parse(TxtAlisFiyat.Text);
            x.SatisFiyat = decimal.Parse(TxtSatisFiyat.Text);
            x.Kategori = int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Veriler Başarılı Bir Şekilde Güncellenmiştir.","Güncelleme Bilgisi",MessageBoxButtons.OK,MessageBoxIcon.Information);
               
                
            


         }
    }
}  
