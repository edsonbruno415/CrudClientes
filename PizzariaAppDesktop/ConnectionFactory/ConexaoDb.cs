using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PizzariaAppDesktop.ConnectionFactory
{
    public class ConexaoDb
    {

        public static DbConnection GetConnection()
        {
            DbConnection conn = null;
            string provider = ConfigurationManager.AppSettings["provider"].ToString();
            string server = ConfigurationManager.AppSettings["server"].ToString();
            string database = ConfigurationManager.AppSettings["database"].ToString();
            string user = ConfigurationManager.AppSettings["user"].ToString();
            string password = ConfigurationManager.AppSettings["password"].ToString();

            if (provider.Equals("MSSQL"))
            {
                conn = new SqlConnection(@"Server = "+server+"; Database = "+database+"; User Id = "+user+"; Password = "+password+";");
            }
            conn.Open();
            return conn;
        }

        public static DbCommand GetCommand(DbConnection conn)
        {
            return conn.CreateCommand();
        }

        public static DbDataReader GetDataReader(DbCommand command)
        {
            return command.ExecuteReader();
        }
    }
}
