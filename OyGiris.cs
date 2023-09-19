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
    public partial class OyGiris : Form
    {
        public OyGiris()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("server=DILAN\\SQLEXPRESS; Initial Catalog=SecimProjeDb; Integrated Security = SSPI");


        private void btnOyGiris_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into TBLILCE (ILCEAD,APARTİ,BPARTİ,CPARTİ,DPARTİ,EPARTİ) values (@P1,@P2,@P3,@P4,@P5,@P6)", baglanti);
            komut.Parameters.AddWithValue("@P1",txtİlce.Text);
            komut.Parameters.AddWithValue("@P2",txtA.Text);
            komut.Parameters.AddWithValue("@P3",txtB.Text);
            komut.Parameters.AddWithValue("@P4",txtC.Text);
            komut.Parameters.AddWithValue("@P5",txtD.Text);
            komut.Parameters.AddWithValue("@P6",txtE.Text);
            komut.ExecuteNonQuery();
            MessageBox.Show("Oy girişi gerçekleşti");

        }

        private void btnGrafik_Click(object sender, EventArgs e)
        {
            Grafikler grafik = new Grafikler();
            grafik.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
