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
    public partial class FrmKaydol : Form
    {
        public FrmKaydol()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void btnKaydol_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtAd.Text == "" || txtSifre.Text == "" || txtSifre2.Text == "")
                {
                    MessageBox.Show("Girdiğiniz değerler geçersiz, lütfen farklı değerler giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (txtSifre.Text == txtSifre2.Text)
                    {
                        SqlCommand cmd = new SqlCommand("insert into TblYarismaci (ad,sifre) values (@p1,@p2)", bgl.baglanti());
                        cmd.Parameters.AddWithValue("@p1", txtAd.Text);
                        cmd.Parameters.AddWithValue("@p2", txtSifre.Text);
                        cmd.ExecuteNonQuery();
                        bgl.baglanti().Close();
                        MessageBox.Show("Hesabınız oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Girdiğiniz şifre değerleri aynı değil, lütfen farklı bir değer giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Girdiğiniz değerler geçersiz, lütfen farklı değerler giriniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
