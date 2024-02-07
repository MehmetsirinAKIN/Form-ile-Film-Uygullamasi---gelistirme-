using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_uyg
{
    public class standart : kullaniciTurleri
    {
        public standart()
        {
            //todo
        }
        public override void Fiyat()
        {
             base.Fiyat();
            fiyatver = fiyatver;
        }

        public override void KullanıcıEkle(string Adsoyad, string tc, DateTime dogumtarihi, string cinsiyet, string KullaniciTipi, string KullaniciAdi, string sifre)
        {
          //  base.KullanıcıEkle();
        }
        public override void KullanıcıSil(int kullaniciId)
        {
           
        }
        public override void KullanıcıGuncelle(int kullaniciId, string Adsoyad, string tc, DateTime dogumtarihi, string cinsiyet, string KullaniciTipi)
        {
           // todo
        }

    }
}
