using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Film_uyg
{
    public partial class Yonetici_DegerlendirmeDuzenle : Form
    {
        public Yonetici_DegerlendirmeDuzenle()
        {
            InitializeComponent();
        }

        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost;port=5432; Database=FilmKütüphanesi; " +
"user Id=postgres ; password=1234 ");

       

      

        private void btn_Listele_yorum_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from yorumlartablosu";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void btn_listele_puan_Click(object sender, EventArgs e)
        {
            string sorgu = "select * from degerlendirmetablosu";
            NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            txt_Yorum_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_Kulanıcı_id_yorum.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_Film_id_yorum.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_Yapılan_yorum.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_degerlendirme_id.Text = dataGridView2.CurrentRow.Cells[0].Value.ToString();
            txt_Kulanıcı_id_puan.Text = dataGridView2.CurrentRow.Cells[1].Value.ToString();
            txt_Film_id_puan.Text = dataGridView2.CurrentRow.Cells[2].Value.ToString();
            txt_puan.Text = dataGridView2.CurrentRow.Cells[3].Value.ToString();

        }

        private void btn_Sil_yorum_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DialogResult karar1 = new DialogResult();
            karar1 = MessageBox.Show(" Yorum Silme Onaylıyormusunuz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (karar1 == DialogResult.Yes)
            {

                NpgsqlCommand komut2 = new NpgsqlCommand("delete from yorumlartablosu where yorumid=@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", int.Parse(txt_Yorum_id.Text));
                komut2.ExecuteNonQuery();
                MessageBox.Show("Yorum Silme İşlemi Başarılı", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            if (karar1 == DialogResult.No)
            {

                MessageBox.Show(" Yorum Silme iptal edildi", "bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            baglanti.Close();
        }

        private void btn_sil_puan_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            DialogResult karar1 = new DialogResult();
            karar1 = MessageBox.Show(" Değerlendirme Silme Onaylıyormusunuz ? ", "Çıkış", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (karar1 == DialogResult.Yes)
            {

                NpgsqlCommand komut2 = new NpgsqlCommand("delete from degerlendirmetablosu where degerlendirmeid=@p1", baglanti);
                komut2.Parameters.AddWithValue("@p1", int.Parse(txt_degerlendirme_id.Text));
                komut2.ExecuteNonQuery();
                MessageBox.Show("Değerlendirme Silme İşlemi Başarılı", "bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            if (karar1 == DialogResult.No)
            {

                MessageBox.Show(" Değerlendirme Silme iptal edildi", "bilgilendirme", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            baglanti.Close();
        }


        private string yoneticiAd;
        private void btn_geri_Click(object sender, EventArgs e)
        {
            Yonetici_Ekran Form8 = new Yonetici_Ekran(yoneticiAd);
            this.Hide();
            Form8.Show();
        }

        private void btn_Guncelle_yorum_Click(object sender, EventArgs e)
        {
            
        }
    }
}
