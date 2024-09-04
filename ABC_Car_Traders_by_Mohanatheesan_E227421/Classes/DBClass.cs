using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ABC_Car_Traders_by_Mohanatheesan_E227421.Classes
{   
    internal class DBClass
    {
        // Connection
        private readonly SqlConnection con = new SqlConnection("Data Source=DESKTOP-D8JFN9N;Initial Catalog=abcCarTradersDB_Theesan;Integrated Security=True;Encrypt=True;TrustServerCertificate=True");

        // Execeute SQL Queries
        public bool ExecuteQuery(string sql)
        {
            bool functionStatus = false;
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            SqlCommand cmd = new SqlCommand(sql, con);
            int rowCount = cmd.ExecuteNonQuery();

            if (rowCount > 0)
            {
                functionStatus = true;
            }
            else
            {
                functionStatus = false;
            }

            con.Close();
            return functionStatus;
        }

        
        // Execute SQL query and check record
        public bool CheckRow(string sql)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataReader reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                reader.Close();
                return true;
            }
            else
            {
                reader.Close();
                return false;
            }
        }

        // Execute SQL query and Return a Record
        public DataRow GetRow(string sql)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            DataRow row = null;

            SqlCommand cmd = new SqlCommand(sql, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                row = dt.Rows[0];
            }
            con.Close();

            return row;
        }


        // Execute SQL query and return Table Data
        public DataTable LoadData (string sql)
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand (sql, con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            con.Close();
            return dt;
        }

        // Execute SQL query and retrive ID
        public int GetID (string sql)
        {
            if(con.State != ConnectionState.Open)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand(sql, con);
            object result = cmd.ExecuteScalar();
            if(result != null)
            {
                int ID = Convert.ToInt32(result);
                return ID;
            }
            else
            {
                return 0;
            }
        }
    }
}
