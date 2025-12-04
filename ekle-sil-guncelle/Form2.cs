using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ekle_sil_guncelle
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=ƧıМЧΑCı;Initial Catalog=Personel;Integrated Security=True");
        private void Form2_Load(object sender, EventArgs e)
        {
            goster();
        }
        void goster()
        {
            baglan.Open();
            SqlCommand kmt2 = new SqlCommand("Select * From personelbilgi", baglan);

            SqlDataAdapter sda = new SqlDataAdapter(kmt2);
            DataSet tb = new DataSet();
            sda.Fill(tb, "personelbilgi");
            dataGridView1.DataSource = tb.Tables["personelbilgi"];
            baglan.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand kmt4 = new SqlCommand("update personelbilgi set resonelad=@d1,personelsoyad=@d2,personeltc=@d3,personelsifre=@d4,personelcinsiyet=@d5 where personelid=@i", baglan);

            kmt4.Parameters.AddWithValue("@d1", txtad.Text);
            kmt4.Parameters.AddWithValue("@d2", txtsoyad.Text);
            kmt4.Parameters.AddWithValue("@d3", msktc.Text);
            kmt4.Parameters.AddWithValue("@d4", txtsifre.Text);
            kmt4.Parameters.AddWithValue("@d5", cmbcinsiyet.Text);
            kmt4.Parameters.AddWithValue("@i", dataGridView1.CurrentRow.Cells[0].Value.ToString());

            //("insert into personelbilgi (resonelad,personelsoyad,personeltc,personelsifre) values (@d1,@d2,@d3,@d4)", baglan);
            kmt4.ExecuteNonQuery();
            kmt4.Dispose();
            baglan.Close();
            goster();
        }
    }
}
