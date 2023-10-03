using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace BarbasBigodes.Core
{
    class ConexaoFactory
    {
       public  static SqlConnection Abrir()
        {
            var connection = new SqlConnection(@"Server=USUARIO; Database=Barbearia; User Id=sa; Password=1234");
            connection.Open();
            return connection;
        }
    }
}