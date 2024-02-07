using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_uyg
{
    public abstract class kullaniciTurleri :Kullanici
    {
        

         protected int fiyatver;
        public int Filmfiyat
        {
            get
            {
                return fiyatver;
            } 
        }



        public kullaniciTurleri()
        {
            
        }

        public virtual void Fiyat()
        {
            fiyatver = 600;
        }

        public abstract void KullanıcıEkle(string Adsoyad, string tc, DateTime dogumtarihi, string cinsiyet, string KullaniciTipi, string KullaniciAdi, string sifre);
        public abstract void KullanıcıSil(int kullaniciId);
        public abstract void KullanıcıGuncelle(int kullaniciId, string Adsoyad, string tc, DateTime dogumtarihi, string cinsiyet, string KullaniciTipi);

        public virtual void PuanVER(int kullaniciId)
        {

        }
    }
}
