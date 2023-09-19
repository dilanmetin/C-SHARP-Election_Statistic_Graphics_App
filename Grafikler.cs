using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Seçim_Uygulama
{
    public partial class Grafikler : Form
    {
        public Grafikler()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=DILAN\\SQLEXPRESS; Initial Catalog=SecimProjeDb; Integrated Security = SSPI");
        private void Grafikler_Load(object sender, EventArgs e)
        {
            //ilçe adlarını comboboxa çekme
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT ILCEAD FROM TBLILCE", baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            baglanti.Close();

            //grafiğe toplam sonuçları getirme
            baglanti.Open();

            SqlCommand komut2 = new SqlCommand("SELECT SUM(APARTİ),SUM(BPARTİ),SUM(CPARTİ),SUM(DPARTİ),SUM(EPARTİ) FROM TBLILCE",baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chart1.Series["Partiler"].Points.AddXY("A", dr2[0]);
                chart1.Series["Partiler"].Points.AddXY("B", dr2[1]);
                chart1.Series["Partiler"].Points.AddXY("C", dr2[2]);
                chart1.Series["Partiler"].Points.AddXY("D", dr2[3]);
                chart1.Series["Partiler"].Points.AddXY("E", dr2[4]);
            }
            baglanti.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TBLILCE WHERE ILCEAD=@P1", baglanti);
            komut.Parameters.AddWithValue("@P1", comboBox1.Text); 
            SqlDataReader dr =komut.ExecuteReader();
            while (dr.Read())
            {
                progressBar1.Value = int.Parse(dr[2].ToString());
                progressBar2.Value = int.Parse(dr[3].ToString());
                progressBar3.Value = int.Parse(dr[4].ToString());
                progressBar4.Value = int.Parse(dr[5].ToString());
                progressBar5.Value = int.Parse(dr[6].ToString());
                labelA.Text = dr[2].ToString();
                labelB.Text = dr[3].ToString();
                labelC.Text = dr[4].ToString();
                labelD.Text = dr[5].ToString();
                labelE.Text = dr[6].ToString();
            }
            baglanti.Close();

        }
    }
}
