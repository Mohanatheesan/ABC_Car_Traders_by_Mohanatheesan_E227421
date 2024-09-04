using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Data;



namespace ABC_Car_Traders_by_Mohanatheesan_E227421.Classes
{
    internal class Users : DBClass
    {
        public int userID { get; set; }
        public string fullname {  get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string hashPassword { get; set; }
        public string phone { get; set; }
        public string accType { get; set; }
        

        public bool Login()
        {
            hashPassword = HashPassword(password);
            string sqlChk = "SELECT * from tblUsers where username = '" + username + "' and password = '" + hashPassword + "'";
            if (CheckRow(sqlChk))
            {
                DataRow row = GetRow(sqlChk);

                if (row != null)
                {
                    Session.userID = Convert.ToInt32(row[0].ToString());
                    Session.userName = row[2].ToString().Trim();
                    Session.password = row[3].ToString().Trim();
                    Session.accType = row[5].ToString().Trim();

                    if(Session.accType == "Customer")
                    {
                        DataTable cart = new DataTable();
                        cart.Columns.Add("ID",  typeof(int));
                        cart.Columns[0].AutoIncrement = true;
                        cart.Columns[0].AutoIncrementSeed = 1;
                        cart.Columns[0].AutoIncrementStep = 1;
                        cart.Columns[0].ReadOnly = true;

                        cart.Columns.Add("ItemType", typeof(string)); // 1
                        cart.Columns.Add("ItemID", typeof(int)); // 2
                        cart.Columns.Add("ItemName", typeof(string)); // 3
                        cart.Columns.Add("ItemQty", typeof(int)); // 4
                        cart.Columns.Add("ItemPrice", typeof(decimal)); // 5
                        cart.Columns.Add("Amount", typeof(decimal)); // 6

                        Session.cart = cart;
                        // Cart = ID, ItemType, ItemID, ItemName, ItemQty, ItemPrice, Amount
                        // OrderTotal
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool InsertUser()
        {
            string sqlChk = "SELECT * from tblUsers where username ='" + username + "' and active='1'";
            if (CheckRow(sqlChk))
            {
                MessageBox.Show("Already have an account with the username", "Register Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                hashPassword = HashPassword(password);
                DateTime regDateTime = DateTime.Now;

                string sql = "INSERT INTO tblUsers (fullname, username, password, phone, accType, regDateTime, active) VALUES ('" + fullname + "', '" + username + "', '" + hashPassword + "', '" + phone + "', 'Customer', '" + regDateTime + "', '1')";

                if (ExecuteQuery(sql))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }

        
        public static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // Convert the input string to a byte array and compute the hash
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Convert the byte array to a string in hexadecimal format
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }


        public DataTable LoadCustomers()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT userID as ID, fullname as Name, username as Username, phone as Phone, regDateTime as Registered FROM tblUsers where accType = 'Customer' and active = '1'";
            dt = LoadData(sql);
            return dt;
        }
    }
}
