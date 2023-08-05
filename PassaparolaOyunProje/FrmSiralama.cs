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
    public partial class FrmSiralama : Form
    {
        public FrmSiralama()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        private void FrmSiralama_Load(object sender, EventArgs e)
        {
            SqlDataAdapter da=new SqlDataAdapter("select dogru,yanlis,bos,ad from TblDereceler inner join TblYarismaci on TblDereceler.YarismaciId=TblYarismaci.id", bgl.baglanti());
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
