using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Film_uyg
{
    public class Yorum
    {
        public int YorumID { get; set; }
        public int KullaniciID { get; set; }
        public int FilmID { get; set; }
        public string Icerik { get; set; }
    }
}
