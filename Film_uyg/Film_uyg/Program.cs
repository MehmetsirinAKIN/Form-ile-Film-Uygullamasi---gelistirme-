using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Film_uyg
{
    public static class FilmKutuphanesi
    {
        public static List<Film> FilmVeritabani = new List<Film>();
        public static List<Kullanici> KullaniciListesi = new List<Kullanici>();
 
        /// <summary>
        /// Uygulamanın ana girdi noktası.
        /// </summary>
        [STAThread]
       public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
