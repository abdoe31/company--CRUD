using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics.Contracts;

namespace Company.datalayer
{
    public   class DBmanger
    {
          public   static  DataTable GetData(string query)
        {
            SqlConnection con = new SqlConnection("server = DESKTOP-34KGDF7\\MSSQLSERVER01;database = company ; trusted_connection=true;trustServerCertificate=true");

            SqlCommand command = new SqlCommand(query, con);

            SqlDataAdapter sql = new SqlDataAdapter(command);

            DataTable tb = new DataTable();
            sql.Fill(tb);

            return tb;

        }


        public static int modify(string query)
        {
            SqlConnection con = new SqlConnection("server = DESKTOP-34KGDF7\\MSSQLSERVER01;database = company ; trusted_connection=true;trustServerCertificate=true");

            SqlCommand command = new SqlCommand(query, con);
            con.Open();

         int x =  command.ExecuteNonQuery();

            con.Close();
            return x;
        }

    }
}