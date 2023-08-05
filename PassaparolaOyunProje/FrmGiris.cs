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

namespace PassaparolaOyunProje
{
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }


        sqlbaglantisi bgl = new sqlbaglantisi();

        private void btnGiris_Click_1(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select ad,sifre from TblYarismaci where ad=@p1 and sifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtAd.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                this.Hide();
                FrmYarisma frm = new FrmYarisma();
                frm.yarismaci = txtAd.Text;
                frm.Show();
            }
            else
            {
                MessageBox.Show("Hatalı kullanıcı adı veya şifre", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            bgl.baglanti().Close();
        }

        private void linkKaydol_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmKaydol frm = new FrmKaydol();
            frm.Show();
        }
    }
}
