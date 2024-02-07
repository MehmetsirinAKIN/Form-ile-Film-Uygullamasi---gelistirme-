using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace Film_uyg
{
    public   class Kullanici 
    {
        public int KullaniciID { get; set; }
        public string AdSoyad { get; set; }
        public string TC { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string Cinsiyet { get; set; }
        public string UyelikTipi { get; set; }

        protected int fiyatver;
        public int Filmfiyat
        {
            get
            {
                return fiyatver;
            }
        }

        public Kullanici()
        {
            
        }

        public virtual void Fiyat()
        {
            fiyatver = 300;
        }
        public virtual void  KullanıcıEkle( string Adsoyad, string tc, DateTime dogumtarihi, string cinsiyet, string KullaniciTipi, string KullaniciAdi, string sifre)
        {
            //Todo
        }

       

        public virtual void KullanıcıGuncelle(int kullaniciId, string Adsoyad, string tc, DateTime dogumtarihi, string cinsiyet, string KullaniciTipi)
        {
            // todo
        }


        public virtual void KullanıcıSil(int kullaniciId)
        {
            // todo 
        }

        public virtual void yorumyaz(int kullaniciId,int filmId,string yorummetni)
        {

        }

        public virtual void PuanVER(int kullaniciId, int filmId, string Puan)
        {
           
        }
        public virtual void İzlemeListesineEkle( int kullaniciId, int filmId)
        {
            // todo 
        }

        public virtual void İzlemeListesineCıkar(int kullaniciId, int filmId)
        {
            // todo 
        }

        public virtual void BegenmeListesineEkle(int kullaniciId, int filmId)
        {
            // todo 
        }

        public virtual void BegenmeListesiCıkar(int kullaniciId, int filmId)
        {
            // todo 
        }


    }
}
    