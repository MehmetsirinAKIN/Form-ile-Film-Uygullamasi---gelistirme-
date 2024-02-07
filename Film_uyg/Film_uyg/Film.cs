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
    public  class Film : yonetici
    {
        public int FilmId { get; set; }
        public string Ad { get; set; }
        public string Yonetmen { get; set; }
        public string Oyuncular { get; set; }
        public string Tur { get; set; }
        public int YayinYili { get; set; }
        public float DegerlendirmePuani { get; set; }
        public string ResimDosyaYolu { get; set; }

       // public string YouTubeLink { get; set; }

        public List<string> Yorumlar { get; set; } = new List<string>();
        public List<string> filmler { get; set; } = new List<string>();





    public override void FilmEkle(int filmid, string filmAdi, string yonetmen, string oyuncular, string filmTuru, int yayinYili, float degerlendirmePuani, string resimDosyaYolu)
        {

            FilmId = filmid;
            Ad = filmAdi;
            Yonetmen = yonetmen;
            Oyuncular = oyuncular;
            Tur = filmTuru;
            yayinYili = yayinYili;
            DegerlendirmePuani= degerlendirmePuani;
            ResimDosyaYolu = resimDosyaYolu;



            NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; " +
            "user Id=postgres ; password=1234 ");

            baglanti.Open();

            DialogResult karar1 = new DialogResult();
            karar1 = MessageBox.Show(" Film Eklemeyi Onaylıyormusunuz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (karar1 == DialogResult.Yes)
            {
                MessageBox.Show("Film Ekleme Başarılı", "bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                NpgsqlCommand komut1 = new NpgsqlCommand("insert into filmlertablosu (filmid,ad,yonetmen,oyuncular,tur,yayinyili,degerlendirmepuani,resimdosyayolu) values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", baglanti);
                komut1.Parameters.AddWithValue("@p1", filmid); // txt_film_id.Text'e dikkat
                komut1.Parameters.AddWithValue("@p2", filmAdi);
                komut1.Parameters.AddWithValue("@p3", yonetmen);
                komut1.Parameters.AddWithValue("@p4", oyuncular);
                komut1.Parameters.AddWithValue("@p5", filmTuru);
                komut1.Parameters.AddWithValue("@p6", yayinYili);
                komut1.Parameters.AddWithValue("@p7", SqlDbType.Real).Value = degerlendirmePuani;
                komut1.Parameters.AddWithValue("@p8", resimDosyaYolu);

                komut1.ExecuteNonQuery();

                // Film listeye ekleniyor
                string filmBilgisi = $"{filmAdi} - {yonetmen} - {oyuncular} - {filmTuru} - {yayinYili} - {degerlendirmePuani} - {resimDosyaYolu}";
                filmler.Add(filmBilgisi);

            }

            baglanti.Close();
        }






        public override void FilmSil(int filmid)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; " +
"user Id=postgres ; password=1234 ");

            baglanti.Open();
            DialogResult karar1 = new DialogResult();
            karar1 = MessageBox.Show(" Film Silme Onaylıyormusunuz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (karar1 == DialogResult.Yes)
            {

                NpgsqlCommand komut2 = new NpgsqlCommand("delete from filmlertablosu where filmid=@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", filmid);
                komut2.ExecuteNonQuery();
                MessageBox.Show("Film Silme İşlemi Başarılı", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }

            if (karar1 == DialogResult.No)
            {

                MessageBox.Show(" Film Silme iptal edildi", "bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            baglanti.Close();
        }






        public override void FilmGuncelle(int filmid, string filmAdi, string yonetmen, string oyuncular, string filmTuru, int yayinYili, float degerlendirmePuani, string resimDosyaYolu)
        {
            NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; " +
 "user Id=postgres ; password=1234 ");

            baglanti.Open();

            DialogResult karar = new DialogResult();
            karar = MessageBox.Show(" Film Güncelemeyi Onaylıyormusunuz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (karar == DialogResult.Yes)
            {
                MessageBox.Show("Film Güncelleme Başarılı", "bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);


                NpgsqlCommand komut3 = new NpgsqlCommand("update filmlertablosu set filmid=@p1,ad=@p2,yonetmen=@p3,oyuncular=@p4,tur=@p5,yayinyili=@p6,resimdosyayolu=@p8 where filmid=@p1", baglanti);

                komut3.Parameters.AddWithValue("@p1", filmid); // txt_film_id.Text'e dikkat
                komut3.Parameters.AddWithValue("@p2", filmAdi);
                komut3.Parameters.AddWithValue("@p3", yonetmen);
                komut3.Parameters.AddWithValue("@p4", oyuncular);
                komut3.Parameters.AddWithValue("@p5", filmTuru);
                komut3.Parameters.AddWithValue("@p6", yayinYili);
                //komut3.Parameters.AddWithValue("@p7", SqlDbType.Real).Value = degerlendirmePuani;
                komut3.Parameters.AddWithValue("@p8", resimDosyaYolu);



                komut3.ExecuteNonQuery();

            }

            if (karar == DialogResult.No)
            {

                MessageBox.Show(" Film Günceleme iptal edildi", "bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // MessageBox.Show("Film Güncelleme Başarılı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            baglanti.Close();
        }




    }
}
