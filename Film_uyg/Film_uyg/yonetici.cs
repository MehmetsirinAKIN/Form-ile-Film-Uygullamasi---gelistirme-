using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Film_uyg
{
    public  class yonetici
    {
        protected string  Yonetici_ad  { get; set; }


        public yonetici()
        {
            
        }

        public virtual void FilmEkle(int filmid ,string filmAdi, string yonetmen, string oyuncular, string filmTuru, int yayinYili, float degerlendirmePuani, string resimDosyaYolu)
        {
           //Todo
        }

        public virtual void FilmSil(int filmid)
        {
            //todo
        }
          
        public virtual void FilmGuncelle(int filmid, string filmAdi, string yonetmen, string oyuncular, string filmTuru, int yayinYili, float degerlendirmePuani, string resimDosyaYolu)
        {
            //Todo
        }

        //internal void FilmEkle()
        //{
        //    throw new NotImplementedException();
        //}
    }
  
}
