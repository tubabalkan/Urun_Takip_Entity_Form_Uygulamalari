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
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        DbUrunEntities db = new DbUrunEntities();
        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            DateTime bugun = DateTime.Today;
            lblMusteriSayisi.Text = db.TblMusteri.Count().ToString();
            lblKategori.Text = db.TblKategori.Count().ToString();
            lblUrunSayisi.Text = db.TblUrun.Count().ToString();
            lblBeyazEsyaSay.Text = db.TblUrun.Count(x=>x.Kategori==1).ToString();
            // x öyle ki
            lblToplamStok.Text = db.TblUrun.Sum(x => x.Stok).ToString();
            lblBgnStsAded.Text = db.TblSatislar.Count(x=>x.Tarih==bugun).ToString();
            lblToplamKasaTutar.Text = db.TblSatislar.Sum(x => x.Toplam).ToString() + " $";
            lblBgnKasaTutar.Text = db.TblSatislar.Where(x => x.Tarih == bugun).Sum(y => y.Toplam).ToString() + " $";
            lblEnYukskUrun.Text=(from x in db.TblUrun
                                orderby x.SatisFiyat descending
                                select x.UrunAd).FirstOrDefault();
            lblEnDusukFiytUrun.Text= (from x in db.TblUrun
                                      orderby x.SatisFiyat ascending
                                      select x.UrunAd).FirstOrDefault();
            lblEnFzlStkUrn.Text = (from x in db.TblUrun
                                   orderby x.Stok descending
                                   select x.UrunAd).FirstOrDefault();
            lblEnAzStklUrun.Text = (from x in db.TblUrun
                                    orderby x.Stok ascending
                                   select x.UrunAd).FirstOrDefault();


        }
    }
}
