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
    public partial class Form1 : Form
    {
        SqlConnection baglan = new SqlConnection("Data Source=ƧıМЧΑCı;Initial Catalog=Personel;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();

        }
        
        
        private void Form1_Load(object sender, EventArgs e)
        {

            goster();
             
        }

        private void btnekle_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand kmt = new SqlCommand("insert into personelbilgi (resonelad,personelsoyad,personeltc,personelsifre,personelcinsiyet) values (@d1,@d2,@d3,@d4,@d5)", baglan);
            kmt.Parameters.AddWithValue("@d1", txtad.Text);
            kmt.Parameters.AddWithValue("@d2", txtsoyad.Text);
            kmt.Parameters.AddWithValue("@d3", msktc.Text);            
            kmt.Parameters.AddWithValue("@d4", txtsifre.Text);
            kmt.Parameters.AddWithValue("@d5", cmbcinsiyet.Text);
            kmt.ExecuteNonQuery();
            kmt.Dispose();
            baglan.Close();
            temizle();
            goster();
            
            MessageBox.Show("Kaydınız tamamlanmıştır. Hoşgeldiniz" + txtad.Text, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
        }
        void goster()
        {
            baglan.Open();
            SqlCommand kmt2 = new SqlCommand("Select * From personelbilgi",baglan);
            
            SqlDataAdapter sda = new SqlDataAdapter(kmt2);
            DataSet tb=new DataSet();
            sda.Fill(tb, "personelbilgi");
            dataGridView1.DataSource = tb.Tables["personelbilgi"];
            dataGridView1.Columns[0].Visible=false;
            baglan.Close();

        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand kmt3 = new SqlCommand("delete from personelbilgi where personelid=@d1",baglan);          
            kmt3.Parameters.AddWithValue("@d1", dataGridView1.CurrentRow.Cells[0].Value.ToString());
            kmt3.ExecuteNonQuery();
            kmt3.Dispose();
            baglan.Close();
            goster();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            Form2 fr2 = new Form2();
            fr2.Show();
            this.Hide();
           /* baglan.Open();
            SqlCommand kmt4 = new SqlCommand("update personelbilgi set resonelad=@d1,personelsoyad=@d2,personeltc=@d3,personelsifre=@d4 where personelid=@i", baglan);
            
            kmt4.Parameters.AddWithValue("@d1", txtad.Text);
            kmt4.Parameters.AddWithValue("@d2", txtsoyad.Text);
            kmt4.Parameters.AddWithValue("@d3", msktc.Text);
            kmt4.Parameters.AddWithValue("@d4", txtsifre.Text);
            kmt4.Parameters.AddWithValue("@i", dataGridView1.CurrentRow.Cells[0].Value.ToString());

            //("insert into personelbilgi (resonelad,personelsoyad,personeltc,personelsifre) values (@d1,@d2,@d3,@d4)", baglan);
            kmt4.ExecuteNonQuery();
            kmt4.Dispose();
            baglan.Close();
            goster();
            temizle();*/
            
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {

        }
        void temizle()
        {
            txtad.Clear();
            txtsoyad.Clear();
            msktc.Clear();
            txtsifre.Clear();
        }

        private void form3_Click(object sender, EventArgs e)
        {
            Form3 fr3 = new Form3();
            fr3.Show();
            this.Hide();
        }
    }
}
