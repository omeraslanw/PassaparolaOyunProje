using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PassaparolaOyunProje
{
    internal class sqlbaglantisi
    {
        public SqlConnection baglanti()
        {
                SqlConnection baglan = new SqlConnection(@"Data Source=DESKTOP-BOV3B8B\SQLEXPRESS;Initial Catalog=PassaparolaOyunu;Integrated Security=True");
                baglan.Open();
                return baglan;
        }
    }
}
