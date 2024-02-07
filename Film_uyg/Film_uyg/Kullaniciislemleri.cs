using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

namespace Film_uyg
{
    public  class Kullaniciislemleri: Kullanici
    {
        Kullanici kullanici = new Kullanici();

        

        public Kullaniciislemleri()
        {
            
        }

        public override void KullanıcıEkle(string Adsoyad, string tc, DateTime dogumtarihi, string cinsiyet, string KullaniciTipi, string KullaniciAdi, string sifre)
        {

            NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; " + "user Id=postgres ; password=1234 ");

            Random random = new Random();
            int kullaniciId = random.Next(1, 1000); // İstediğiniz aralığı belirleyebilirsiniz.

            baglanti.Open();

            DialogResult karar1 = new DialogResult();
            karar1 = MessageBox.Show("Kaydedilsin mi  ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (karar1 == DialogResult.Yes)
            {
                MessageBox.Show("Kayıt Başarılı", "bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);

                NpgsqlCommand komut1 = new NpgsqlCommand("insert into kullanicitablosu (kullaniciid,adsoyad,tc,dogumtarihi,cinsiyet,uyeliktipi) values(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
                NpgsqlCommand komut2 = new NpgsqlCommand("insert into kullaniciadisifre (kullaniciid,kullanici_adi,sifre) values(@p7,@p8,@p9)", baglanti);
                komut1.Parameters.AddWithValue("@p1", kullaniciId);
                komut1.Parameters.AddWithValue("@p2", Adsoyad);
                komut1.Parameters.AddWithValue("@p3", tc);
                komut1.Parameters.AddWithValue("@p4", dogumtarihi);
                komut1.Parameters.AddWithValue("@p5", cinsiyet);
                komut1.Parameters.AddWithValue("@p6", KullaniciTipi);

                komut2.Parameters.AddWithValue("@p7", kullaniciId);
                komut2.Parameters.AddWithValue("@p8", KullaniciAdi);
                komut2.Parameters.AddWithValue("@p9", sifre);

                komut1.ExecuteNonQuery();
                komut2.ExecuteNonQuery();
            }

            baglanti.Close();


            Form Form1 = new Login();
            // Aktif olan Form'u kapat
            // this.Hide(); 
            Kulanici_kaydol kulanici_Kaydol = new Kulanici_kaydol();
            kulanici_Kaydol.Hide();
           
            Form1.Show();
        }


        prememiumKullanıcı PrememiumKullanıcı = new prememiumKullanıcı();

        standart Standart = new standart();

        public override void KullanıcıGuncelle(int kullaniciId, string Adsoyad, string tc, DateTime dogumtarihi, string cinsiyet, string KullaniciTipi)
        {
            PrememiumKullanıcı.Fiyat();
            Standart.Fiyat();

            NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; " + "user Id=postgres ; password=1234 ");
            baglanti.Open();

            DialogResult karar = new DialogResult();
            karar = MessageBox.Show(" Hesap Güncelemeyi Onaylıyormusunuz ?  \n\n" + " Standart  Aylık Fiyat :   " + Standart.Filmfiyat.ToString() + " TL " + "\n\n Premium  Aylık Fiyat :  " + PrememiumKullanıcı.Filmfiyat.ToString() + " TL ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (karar == DialogResult.Yes)
            {
                MessageBox.Show("Hesap Güncelleme Başarıl\n\n Çıkış yapıp tekrar giriş yapmanınızı tavsiye ederiz ", "bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);


                NpgsqlCommand komut3 = new NpgsqlCommand("update kullanicitablosu set adsoyad=@Adsoyad,tc=@Tc,dogumtarihi=@Dogumtarihi,cinsiyet=@Cinsiyet,uyeliktipi=@Uyeliktipi where  kullaniciid = @kullaniciId ", baglanti);

                komut3.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                komut3.Parameters.AddWithValue("@Adsoyad", Adsoyad);
                komut3.Parameters.AddWithValue("@Tc", tc);
                komut3.Parameters.AddWithValue("@Dogumtarihi", dogumtarihi);
                komut3.Parameters.AddWithValue("@Cinsiyet", cinsiyet);
                komut3.Parameters.AddWithValue("@Uyeliktipi", KullaniciTipi);






                komut3.ExecuteNonQuery();

            }

            if (karar == DialogResult.No)
            {

                MessageBox.Show(" Hesap Günceleme iptal edildi", "bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // MessageBox.Show("Film Güncelleme Başarılı","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            baglanti.Close();
        }






        public override void KullanıcıSil(int kullaniciId)
        {
            DialogResult karar1 = new DialogResult();
            karar1 = MessageBox.Show("Kullanıcıyı Silme Onaylıyor musunuz?", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);

            if (karar1 == DialogResult.Yes)
            {

                using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres; password=1234"))
                {
                    baglanti.Open();
                    using (NpgsqlTransaction transaction = baglanti.BeginTransaction())
                    {
                        try
                        {

                            NpgsqlCommand kullaniciAd_sifreSilKomutu = new NpgsqlCommand("DELETE FROM kullaniciadisifre WHERE kullaniciid = @p1", baglanti, transaction);
                            kullaniciAd_sifreSilKomutu.Parameters.AddWithValue("@p1", kullaniciId);
                            kullaniciAd_sifreSilKomutu.ExecuteNonQuery();

                            // Bağımlı tablodan kayıtları sil (örneğin: degerlendirmetablosu)
                            NpgsqlCommand degerlendirmeSilKomutu = new NpgsqlCommand("DELETE FROM degerlendirmetablosu WHERE kullaniciid = @p1", baglanti, transaction);
                            degerlendirmeSilKomutu.Parameters.AddWithValue("@p1", kullaniciId);
                            degerlendirmeSilKomutu.ExecuteNonQuery();

                            // Bağımlı tablodan kayıtları sil (örneğin: yorumlartablosu)
                            NpgsqlCommand yorumSilKomutu = new NpgsqlCommand("DELETE FROM yorumlartablosu WHERE kullaniciid = @p1", baglanti, transaction);
                            yorumSilKomutu.Parameters.AddWithValue("@p1", kullaniciId);
                            yorumSilKomutu.ExecuteNonQuery();

                            // Bağımlı tablodan kayıtları sil (örneğin: yorumlartablosu)
                            NpgsqlCommand begenSilKomutu = new NpgsqlCommand("DELETE FROM begenilenfilmlertablosu WHERE kullaniciid = @p1", baglanti, transaction);
                            begenSilKomutu.Parameters.AddWithValue("@p1", kullaniciId);
                            begenSilKomutu.ExecuteNonQuery();

                            // Ana tablodaki kaydı sil (örneğin: kullanicitablosu)
                            NpgsqlCommand kullaniciSilKomutu = new NpgsqlCommand("DELETE FROM kullanicitablosu WHERE kullaniciid = @p1", baglanti, transaction);
                            kullaniciSilKomutu.Parameters.AddWithValue("@p1", kullaniciId);
                            kullaniciSilKomutu.ExecuteNonQuery();




                            NpgsqlCommand izlemeFilmSilKomutu = new NpgsqlCommand("DELETE FROM izlemetablosu  WHERE kullaniciid = @p1", baglanti, transaction);
                            izlemeFilmSilKomutu.Parameters.AddWithValue("@p1", kullaniciId);
                            izlemeFilmSilKomutu.ExecuteNonQuery();


                            transaction.Commit();
                            MessageBox.Show("Kullanıcı Silme İşlemi Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    baglanti.Close();
                }
            }
            else
            {
                MessageBox.Show("Kullanıcı Silme İptal Edildi", "Bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        public override void yorumyaz(int kullaniciId, int filmId,string yorummetni)
        {

            // Yorum ID'yi rastgele oluştur
            Random random = new Random();
            int yorumId = random.Next(1, 1000); // İstediğiniz aralığı belirleyebilirsiniz.

            // Yorum metni
            string yorumMetni = yorummetni;

            // Yorum tablosuna kayıt ekle
            string sqlSorgusu = "INSERT INTO yorumlartablosu (yorumid, kullaniciid, filmid, yorum) VALUES (@yorumId, @kullaniciId, @filmId, @yorumMetni)";

            using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
            {
                using (NpgsqlCommand komut = new NpgsqlCommand(sqlSorgusu, baglanti))
                {
                    // Parametreleri ekleyerek SQL enjeksiyonunu önle 
                    komut.Parameters.AddWithValue("@yorumId", yorumId);
                    komut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                    komut.Parameters.AddWithValue("@filmId", filmId);
                    komut.Parameters.AddWithValue("@yorumMetni", yorumMetni);

                    try
                    {
                        baglanti.Open();
                        komut.ExecuteNonQuery();

                        MessageBox.Show("Yorum başarıyla kaydedildi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);

                    }
                }
            }

        }


        public override void PuanVER(int kullaniciId, int filmId, string Puan)
        {

            // degerlendirme ID'yi rastgele oluştur
            Random random = new Random();
            int degerlendirmeId = random.Next(1, 1000); // İstediğiniz aralığı belirleyebilirsiniz.

            // degerlendirme metni
            string degerlendirmePuanı = Puan;

            // degerlendirme tablosuna kayıt ekle
            string sqlSorgusu = "INSERT INTO degerlendirmetablosu (degerlendirmeid, kullaniciid, filmid, Puan) VALUES (@degerlendirmeId, @kullaniciId, @filmId, @degerlendirmePuanı::real)";



            using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
            {
                using (NpgsqlCommand komut = new NpgsqlCommand(sqlSorgusu, baglanti))
                {
                    // Parametreleri ekleyerek SQL enjeksiyonunu önle 
                    komut.Parameters.AddWithValue("@degerlendirmeId", degerlendirmeId);
                    komut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                    komut.Parameters.AddWithValue("@filmId", filmId);
                    komut.Parameters.AddWithValue("@degerlendirmePuanı", degerlendirmePuanı); // Parametre adı düzeltildi

                    try
                    {
                        baglanti.Open();
                        komut.ExecuteNonQuery();

                        MessageBox.Show("Degerlendirme puanı başarıyla kaydedildi.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }


            ///////////////

            string sqlSorgusu2 = "UPDATE filmlertablosu SET degerlendirmepuani = (   SELECT AVG(Puan)  FROM degerlendirmetablosu   WHERE degerlendirmetablosu.filmid = filmlertablosu.filmid);";

            using (NpgsqlConnection baglanti2 = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
            {
                using (NpgsqlCommand komut2 = new NpgsqlCommand(sqlSorgusu2, baglanti2))
                {
                    // Parametreleri ekleyerek SQL enjeksiyonunu önle 

                    try
                    {
                        baglanti2.Open();
                        komut2.ExecuteNonQuery();


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }

        }


        public override void İzlemeListesineEkle(int kullaniciId,int filmId)
        {

            // Beğenilen filmler tablosunda aynı kayıtın olup olmadığını kontrol et
            string kontrolSorgusu = "SELECT COUNT(*) FROM izlemetablosu WHERE kullaniciid = @kullaniciId AND filmid = @filmId";

            using (NpgsqlConnection kontrolBaglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
            {
                using (NpgsqlCommand kontrolKomut = new NpgsqlCommand(kontrolSorgusu, kontrolBaglanti))
                {
                    kontrolKomut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                    kontrolKomut.Parameters.AddWithValue("@filmId", filmId);

                    kontrolBaglanti.Open();

                    object result = kontrolKomut.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int kayitSayisi = Convert.ToInt32(result);

                        if (kayitSayisi == 0)
                        {
                            // Beğenilen filmler tablosuna yeni bir kayıt ekle
                            string eklemeSorgusu = "INSERT INTO izlemetablosu (kullaniciid, filmid) VALUES (@kullaniciId, @filmId)";


                            using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
                            {
                                using (NpgsqlCommand komut = new NpgsqlCommand(eklemeSorgusu, baglanti))
                                {
                                    komut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                                    komut.Parameters.AddWithValue("@filmId", filmId);

                                    try
                                    {
                                        baglanti.Open();
                                        komut.ExecuteNonQuery();
                                        MessageBox.Show("Film İzleme Listesine kaydedildi.");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bu film zaten  İzleme Listesine var.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kontrol sorgusundan beklenmeyen bir değer döndü.");
                    }
                }
            }

        }



        public override void İzlemeListesineCıkar(int kullaniciId, int filmId)
        {

            // Beğenilen filmler tablosundan belirli bir kaydı sil
            string silmeSorgusu = "DELETE FROM izlemetablosu WHERE kullaniciid = @kullaniciId AND filmid = @filmId";

            using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
            {
                using (NpgsqlCommand kontrolKomut = new NpgsqlCommand("SELECT COUNT(*) FROM izlemetablosu WHERE kullaniciid = @kullaniciId AND filmid = @filmId", baglanti))
                {
                    kontrolKomut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                    kontrolKomut.Parameters.AddWithValue("@filmId", filmId);

                    baglanti.Open();

                    object result = kontrolKomut.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int kayitSayisi = Convert.ToInt32(result);

                        if (kayitSayisi > 0)
                        {
                            // Film beğenilen filmler listesinden çıkarıldı
                            using (NpgsqlCommand komut = new NpgsqlCommand(silmeSorgusu, baglanti))
                            {
                                komut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                                komut.Parameters.AddWithValue("@filmId", filmId);

                                try
                                {
                                    komut.ExecuteNonQuery();
                                    MessageBox.Show("Film İzleme  Listesinden çıkarıldı.");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bu film zaten İzleme  Listesinde Yok.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kontrol sorgusundan beklenmeyen bir değer döndü.");
                    }
                }
            }

        }



        public override void BegenmeListesineEkle(int kullaniciId, int filmId)
        {

            // Beğenilen filmler tablosunda aynı kayıtın olup olmadığını kontrol et
            string kontrolSorgusu = "SELECT COUNT(*) FROM begenilenfilmlertablosu WHERE kullaniciid = @kullaniciId AND filmid = @filmId";

            using (NpgsqlConnection kontrolBaglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
            {
                using (NpgsqlCommand kontrolKomut = new NpgsqlCommand(kontrolSorgusu, kontrolBaglanti))
                {
                    kontrolKomut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                    kontrolKomut.Parameters.AddWithValue("@filmId", filmId);

                    kontrolBaglanti.Open();

                    object result = kontrolKomut.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int kayitSayisi = Convert.ToInt32(result);

                        if (kayitSayisi == 0)
                        {
                            // Beğenilen filmler tablosuna yeni bir kayıt ekle
                            string eklemeSorgusu = "INSERT INTO begenilenfilmlertablosu (kullaniciid, filmid) VALUES (@kullaniciId, @filmId)";


                            using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
                            {
                                using (NpgsqlCommand komut = new NpgsqlCommand(eklemeSorgusu, baglanti))
                                {
                                    komut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                                    komut.Parameters.AddWithValue("@filmId", filmId);

                                    try
                                    {
                                        baglanti.Open();
                                        komut.ExecuteNonQuery();
                                        MessageBox.Show("Film beğenisi kaydedildi.");
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bu film zaten beğenilmiş.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kontrol sorgusundan beklenmeyen bir değer döndü.");
                    }
                }
            }

        }

        public override void BegenmeListesiCıkar(int kullaniciId, int filmId)
        {

            // Beğenilen filmler tablosundan belirli bir kaydı sil
            string silmeSorgusu = "DELETE FROM begenilenfilmlertablosu WHERE kullaniciid = @kullaniciId AND filmid = @filmId";

            using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
            {
                using (NpgsqlCommand kontrolKomut = new NpgsqlCommand("SELECT COUNT(*) FROM begenilenfilmlertablosu WHERE kullaniciid = @kullaniciId AND filmid = @filmId", baglanti))
                {
                    kontrolKomut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                    kontrolKomut.Parameters.AddWithValue("@filmId", filmId);

                    baglanti.Open();

                    object result = kontrolKomut.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        int kayitSayisi = Convert.ToInt32(result);

                        if (kayitSayisi > 0)
                        {
                            // Film beğenilen filmler listesinden çıkarıldı
                            using (NpgsqlCommand komut = new NpgsqlCommand(silmeSorgusu, baglanti))
                            {
                                komut.Parameters.AddWithValue("@kullaniciId", kullaniciId);
                                komut.Parameters.AddWithValue("@filmId", filmId);

                                try
                                {
                                    komut.ExecuteNonQuery();
                                    MessageBox.Show("Film beğeni listesinden çıkarıldı.");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Bir hata oluştu: " + ex.Message);
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Bu film zaten beğenilmemiş.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Kontrol sorgusundan beklenmeyen bir değer döndü.");
                    }
                }
            }

        }







    }
}
