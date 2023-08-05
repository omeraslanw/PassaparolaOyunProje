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
using System.Drawing.Text;
using System.Diagnostics.Eventing.Reader;

namespace PassaparolaOyunProje
{
    public partial class FrmYarisma : Form
    {
        public FrmYarisma()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();
        int soruno = 0, dogru = 0, yanlis = 0, bos = 0, sayac = 15;
        public string yarismaci;

        public void sorunoArtir()
        {
            soruno++;
            lblSoruNo.Text = soruno.ToString();
        }
        public void bosArtir()
        {
            bos++;
            lblBoss.Text = bos.ToString();
        }
        public void yanlisArtir()
        {
            yanlis++;
            lblYanliss.Text = yanlis.ToString();
        }
        public void dogruArtir()
        {
            dogru++;
            lblDogruu.Text = dogru.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac--;
            lblZamanlayici.Text = sayac.ToString();

            if (sayac == 0)
            {
                timer1.Stop();
                txtCevap.Enabled = false;
                MessageBox.Show("Süre bitti, lütfen sıradaki soruya geçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnBasla.Enabled = true;
            }
        }

        private void FrmYarisma_Load(object sender, EventArgs e)
        {
            lblYarismaci.Text = yarismaci.ToString();
            SqlCommand komut = new SqlCommand("select id from TblYarismaci where ad=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", yarismaci);
            SqlDataReader dataReader = komut.ExecuteReader();
            while (dataReader.Read())
            {
                lblId.Text = dataReader[0].ToString();
            }
            bgl.baglanti().Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmSiralama frm = new FrmSiralama();
            frm.Show();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmGiris frm = new FrmGiris();
            frm.Show();
        }

        private void btnDerece_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TblDereceler (dogru,yanlis,bos,yarismaciId) values (@p1,@p2,@p3,p4)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", dogru);
            komut.Parameters.AddWithValue("@p2", yanlis);
            komut.Parameters.AddWithValue("@p3", bos);
            komut.Parameters.AddWithValue("@p4", lblId.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Skorunuz sıralama tablosuna eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            panelYeniden.Visible = false;
        }

        private void btnYeniden_Click(object sender, EventArgs e)
        {
            bos = 0;
            dogru = 0;
            yanlis = 0;
            soruno = 0;
            sayac = 15;
            lblBos.Text = bos.ToString();
            lblDogru.Text = dogru.ToString();
            lblYanlis.Text = yanlis.ToString();
            lblSoruNo.Text = soruno.ToString();
            btnBasla.Enabled = true;
            txtCevap.Enabled = false;
            txtCevap.Text = "";
            panelYeniden.Visible = false;

            btnA.BackColor = Color.LightCoral;
            btnB.BackColor = Color.LightCoral;
            btnC.BackColor = Color.LightCoral;
            btnD.BackColor = Color.LightCoral;
            btnE.BackColor = Color.LightCoral;
            btnF.BackColor = Color.LightCoral;
            btnG.BackColor = Color.LightCoral;
            btnH.BackColor = Color.LightCoral;
            btnI.BackColor = Color.LightCoral;
            btnİ.BackColor = Color.LightCoral;
            btnJ.BackColor = Color.LightCoral;
            btnK.BackColor = Color.LightCoral;
            btnL.BackColor = Color.LightCoral;
            btnM.BackColor = Color.LightCoral;
            btnN.BackColor = Color.LightCoral;
            btnO.BackColor = Color.LightCoral;
            btnP.BackColor = Color.LightCoral;
            btnR.BackColor = Color.LightCoral;
            btnS.BackColor = Color.LightCoral;
            btnT.BackColor = Color.LightCoral;
            btnU.BackColor = Color.LightCoral;
            btnV.BackColor = Color.LightCoral;
            btnY.BackColor = Color.LightCoral;
            btnZ.BackColor = Color.LightCoral;
        }

        private void txtCevap_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnBasla.Enabled = true;
                txtCevap.Enabled = false;
                sayac = 15;
                lblZamanlayici.Text = sayac.ToString();
                timer1.Start();
                switch (soruno)
                {
                    case 1:
                        SqlCommand komut1 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut1.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr1 = komut1.ExecuteReader();
                        if (dr1.Read())
                        {
                            btnA.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnA.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 2:
                        SqlCommand komut2 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut2.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr2 = komut2.ExecuteReader();
                        if (dr2.Read())
                        {
                            btnB.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnB.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 3:
                        SqlCommand komut3 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut3.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr3 = komut3.ExecuteReader();
                        if (dr3.Read())
                        {
                            btnC.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnC.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 4:
                        SqlCommand komut4 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut4.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr4 = komut4.ExecuteReader();
                        if (dr4.Read())
                        {
                            btnD.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnD.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 5:
                        SqlCommand komut5 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut5.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr5 = komut5.ExecuteReader();
                        if (dr5.Read())
                        {
                            btnE.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnE.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 6:
                        SqlCommand komut6 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut6.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr6 = komut6.ExecuteReader();
                        if (dr6.Read())
                        {
                            btnF.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnF.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 7:
                        SqlCommand komut7 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut7.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr7 = komut7.ExecuteReader();
                        if (dr7.Read())
                        {
                            btnG.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnG.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 8:
                        SqlCommand komut8 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut8.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr8 = komut8.ExecuteReader();
                        if (dr8.Read())
                        {
                            btnH.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnH.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 9:
                        SqlCommand komut9 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut9.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr9 = komut9.ExecuteReader();
                        if (dr9.Read())
                        {
                            btnI.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnI.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 10:
                        SqlCommand komut10 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut10.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr10 = komut10.ExecuteReader();
                        if (dr10.Read())
                        {
                            btnİ.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnİ.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 11:
                        SqlCommand komut11 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut11.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr11 = komut11.ExecuteReader();
                        if (dr11.Read())
                        {
                            btnJ.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnJ.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 12:
                        SqlCommand komut12 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut12.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr12 = komut12.ExecuteReader();
                        if (dr12.Read())
                        {
                            btnK.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnK.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 13:
                        SqlCommand komut13 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut13.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr13 = komut13.ExecuteReader();
                        if (dr13.Read())
                        {
                            btnL.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnL.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 14:
                        SqlCommand komut14 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut14.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr14 = komut14.ExecuteReader();
                        if (dr14.Read())
                        {
                            btnM.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnM.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 15:
                        SqlCommand komut15 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut15.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr15 = komut15.ExecuteReader();
                        if (dr15.Read())
                        {
                            btnN.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnN.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 16:
                        SqlCommand komut16 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut16.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr16 = komut16.ExecuteReader();
                        if (dr16.Read())
                        {
                            btnO.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnO.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 17:
                        SqlCommand komut17 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut17.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr17 = komut17.ExecuteReader();
                        if (dr17.Read())
                        {
                            btnP.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnP.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 18:
                        SqlCommand komut18 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut18.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr18 = komut18.ExecuteReader();
                        if (dr18.Read())
                        {
                            btnR.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnR.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 19:
                        SqlCommand komut19 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut19.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr19 = komut19.ExecuteReader();
                        if (dr19.Read())
                        {
                            btnS.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnS.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 20:
                        SqlCommand komut20 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut20.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr20 = komut20.ExecuteReader();
                        if (dr20.Read())
                        {
                            btnT.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnT.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 21:
                        SqlCommand komut21 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut21.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr21 = komut21.ExecuteReader();
                        if (dr21.Read())
                        {
                            btnU.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnU.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 22:
                        SqlCommand komut22 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut22.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr22 = komut22.ExecuteReader();
                        if (dr22.Read())
                        {
                            btnV.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnV.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 23:
                        SqlCommand komut23 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut23.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr23 = komut23.ExecuteReader();
                        if (dr23.Read())
                        {
                            btnY.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnY.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                    case 24:
                        SqlCommand komut24 = new SqlCommand("select soru from TblSoru where cevap=@p1", bgl.baglanti());
                        komut24.Parameters.AddWithValue("@p1", txtCevap.Text);
                        SqlDataReader dr24 = komut24.ExecuteReader();
                        if (dr24.Read())
                        {
                            btnZ.BackColor = Color.Green;
                            dogruArtir();
                        }
                        else if (txtCevap.Text == "")
                        {
                            bosArtir();
                        }
                        else
                        {
                            btnZ.BackColor = Color.Red;
                            yanlisArtir();
                        }
                        break;
                }
            }

        }

        private void btnBasla_Click(object sender, EventArgs e)
        {
            txtCevap.Enabled = true;
            txtCevap.Focus();
            btnBasla.Text = "Sonraki";
            sorunoArtir();
            btnBasla.Enabled = false;
            sayac = 15;
            lblZamanlayici.Text = sayac.ToString();
            timer1.Start();

            switch (soruno)
            {
                case 1:
                    btnA.BackColor = Color.Yellow;
                    SqlCommand komut1 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut1.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr = komut1.ExecuteReader();
                    while (dr.Read())
                    {
                        btnSoru.Text = dr[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 2:
                    btnB.BackColor = Color.Yellow;
                    btnB.BackColor = Color.Yellow;
                    SqlCommand komut2 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut2.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr2 = komut2.ExecuteReader();
                    while (dr2.Read())
                    {
                        btnSoru.Text = dr2[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 3:
                    btnC.BackColor = Color.Yellow;
                    SqlCommand komut3 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut3.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr3 = komut3.ExecuteReader();
                    while (dr3.Read())
                    {
                        btnSoru.Text = dr3[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 4:
                    btnD.BackColor = Color.Yellow;
                    SqlCommand komut4 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut4.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr4 = komut4.ExecuteReader();
                    while (dr4.Read())
                    {
                        btnSoru.Text = dr4[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 5:
                    btnE.BackColor = Color.Yellow;
                    SqlCommand komut5 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut5.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr5 = komut5.ExecuteReader();
                    while (dr5.Read())
                    {
                        btnSoru.Text = dr5[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 6:
                    btnF.BackColor = Color.Yellow;
                    SqlCommand komut6 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut6.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr6 = komut6.ExecuteReader();
                    while (dr6.Read())
                    {
                        btnSoru.Text = dr6[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 7:
                    btnG.BackColor = Color.Yellow;
                    SqlCommand komut7 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut7.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr7 = komut7.ExecuteReader();
                    while (dr7.Read())
                    {
                        btnSoru.Text = dr7[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 8:
                    btnH.BackColor = Color.Yellow;
                    SqlCommand komut8 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut8.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr8 = komut8.ExecuteReader();
                    while (dr8.Read())
                    {
                        btnSoru.Text = dr8[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 9:
                    btnI.BackColor = Color.Yellow;
                    SqlCommand komut9 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut9.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr9 = komut9.ExecuteReader();
                    while (dr9.Read())
                    {
                        btnSoru.Text = dr9[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 10:
                    btnİ.BackColor = Color.Yellow;
                    SqlCommand komut10 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut10.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr10 = komut10.ExecuteReader();
                    while (dr10.Read())
                    {
                        btnSoru.Text = dr10[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 11:
                    btnJ.BackColor = Color.Yellow;
                    SqlCommand komut11 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut11.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr11 = komut11.ExecuteReader();
                    while (dr11.Read())
                    {
                        btnSoru.Text = dr11[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 12:
                    btnK.BackColor = Color.Yellow;
                    SqlCommand komut12 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut12.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr12 = komut12.ExecuteReader();
                    while (dr12.Read())
                    {
                        btnSoru.Text = dr12[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 13:
                    btnL.BackColor = Color.Yellow;
                    SqlCommand komut13 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut13.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr13 = komut13.ExecuteReader();
                    while (dr13.Read())
                    {
                        btnSoru.Text = dr13[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 14:
                    btnM.BackColor = Color.Yellow;
                    SqlCommand komut14 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut14.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr14 = komut14.ExecuteReader();
                    while (dr14.Read())
                    {
                        btnSoru.Text = dr14[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 15:
                    btnN.BackColor = Color.Yellow;
                    SqlCommand komut15 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut15.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr15 = komut15.ExecuteReader();
                    while (dr15.Read())
                    {
                        btnSoru.Text = dr15[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 16:
                    btnO.BackColor = Color.Yellow;
                    SqlCommand komut16 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut16.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr16 = komut16.ExecuteReader();
                    while (dr16.Read())
                    {
                        btnSoru.Text = dr16[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 17:
                    btnP.BackColor = Color.Yellow;
                    SqlCommand komut17 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut17.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr17 = komut17.ExecuteReader();
                    while (dr17.Read())
                    {
                        btnSoru.Text = dr17[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 18:
                    btnR.BackColor = Color.Yellow;
                    SqlCommand komut18 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut18.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr18 = komut18.ExecuteReader();
                    while (dr18.Read())
                    {
                        btnSoru.Text = dr18[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 19:
                    btnS.BackColor = Color.Yellow;
                    SqlCommand komut19 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut19.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr19 = komut19.ExecuteReader();
                    while (dr19.Read())
                    {
                        btnSoru.Text = dr19[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 20:
                    btnT.BackColor = Color.Yellow;
                    SqlCommand komut20 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut20.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr20 = komut20.ExecuteReader();
                    while (dr20.Read())
                    {
                        btnSoru.Text = dr20[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 21:
                    btnU.BackColor = Color.Yellow;
                    SqlCommand komut21 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut21.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr21 = komut21.ExecuteReader();
                    while (dr21.Read())
                    {
                        btnSoru.Text = dr21[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 22:
                    btnV.BackColor = Color.Yellow;
                    SqlCommand komut22 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut22.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr22 = komut22.ExecuteReader();
                    while (dr22.Read())
                    {
                        btnSoru.Text = dr22[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 23:
                    btnY.BackColor = Color.Yellow;
                    SqlCommand komut23 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut23.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr23 = komut23.ExecuteReader();
                    while (dr23.Read())
                    {
                        btnSoru.Text = dr23[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;
                case 24:
                    btnZ.BackColor = Color.Yellow;
                    SqlCommand komut24 = new SqlCommand("select soru from TblSoru where id=@p1", bgl.baglanti());
                    komut24.Parameters.AddWithValue("@p1", soruno);
                    SqlDataReader dr24 = komut24.ExecuteReader();
                    while (dr24.Read())
                    {
                        btnSoru.Text = dr24[0].ToString();
                    }
                    bgl.baglanti().Close();
                    break;

                case 25:
                    panelYeniden.Visible = true;
                    lblDogru2.Text = dogru.ToString();
                    lblYanlis2.Text = yanlis.ToString();
                    lblBos2.Text = bos.ToString();
                    break;
            }
        }
    }
}
