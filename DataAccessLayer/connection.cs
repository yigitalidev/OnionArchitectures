using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class connection
    {
        public static SqlConnection cnn = new SqlConnection(@"Data Source=DESKTOP-N4P9SDV\SQLEXPRESS;Initial Catalog=DbPersonal;Integrated Security=True");
    }
}
