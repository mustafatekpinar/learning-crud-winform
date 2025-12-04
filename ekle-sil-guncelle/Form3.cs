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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglan = new SqlConnection("Data Source=ƧıМЧΑCı;Initial Catalog=Personel;Integrated Security=True");
        private void Form3_Load(object sender, EventArgs e)
        {
            SqlCommand kmt = new SqlCommand("Select Count(personelcinsiyet) From personelbilgi",baglan);
            SqlDataReader dr1=kmt.ExecuteReader();
            while (dr1.Read())
            {
                label2.Text = dr1[0].ToString();
            }
        }
    }
}
