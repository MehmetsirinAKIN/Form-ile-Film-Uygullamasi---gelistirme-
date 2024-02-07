using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Film_uyg
{
    public class prememiumKullanıcı :kullaniciTurleri
    {
        public prememiumKullanıcı()
        {
            
        }
        public override void Fiyat()
        {
             base.Fiyat();

            fiyatver = fiyatver + fiyatver / 4;

        }

        public override void KullanıcıEkle(string Adsoyad, string tc, DateTime dogumtarihi, string cinsiyet, string KullaniciTipi, string KullaniciAdi, string sifre)
        {
            //base.KullanıcıEkle();
        }
        public override void KullanıcıSil(int kullaniciId)
        {
          
        }
        public override void KullanıcıGuncelle(int kullaniciId,string Adsoyad, string tc, DateTime dogumtarihi, string cinsiyet, string KullaniciTipi)
        {
           
        }



        public override void PuanVER(int kullaniciId)
        {

            // Kullanıcı adını, soyadını ve üyelik tipini al
            string sqlSorgusu = "SELECT uyeliktipi FROM kullanicitablosu WHERE kullaniciid = @kullaniciId";

            using (NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; user Id=postgres ; password=1234 "))
            {
                using (NpgsqlCommand komut = new NpgsqlCommand(sqlSorgusu, baglanti))
                {
                    komut.Parameters.AddWithValue("@kullaniciId", kullaniciId);

                    try
                    {
                        baglanti.Open();
                        NpgsqlDataReader reader = komut.ExecuteReader();

                        if (reader.Read())
                        {

                            string uyelikTipi = reader["uyeliktipi"].ToString();




                            if (string.Equals(uyelikTipi.Trim(), "Premium", StringComparison.OrdinalIgnoreCase))
                            {



                            }
                            else
                            {

                                MessageBox.Show("Premium kullanıcı değilsiniz Puan veremesiniz \n Puanlamak İsterseniz Premium pakete Geçebilirsiniz \n\n \nStandart  Aylık Fiyat : 100 TL \n Premium  Aylık Fiyat : %25 İndirimli : 75 TL \n");


                            }

                            baglanti.Close();
                        }
                        else
                        {
                            MessageBox.Show("Kullanıcı bilgileri bulunamadı.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Bir hata oluştu: " + ex.Message);
                    }
                }
            }
        }



    }
}
