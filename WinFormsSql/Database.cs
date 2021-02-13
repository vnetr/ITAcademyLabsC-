using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSql
{
    class Database
    {
        SqlConnection con = new SqlConnection("Server=tcp:itacademy.database.windows.net,1433;Database=Netrebiak;User ID=Netrebiak;Password=Elxf93611;Trusted_Connection=False;Encrypt=True;");
        public void OpenConnection()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }
        public void CloseConnection()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
        public SqlConnection GetConnection()
        {
            return con;
        }
    }
}
