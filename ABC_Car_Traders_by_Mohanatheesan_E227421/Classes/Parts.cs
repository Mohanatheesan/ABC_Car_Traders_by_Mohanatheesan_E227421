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
    internal class Parts : DBClass
    {
        public int partID { get; set; }
        public string partName { get; set; }
        public string description { get; set; }
        public decimal price { get; set; }
        public int stock { get; set; }


        public bool InsertPart()
        {
            string sqlChk = "SELECT * from tblParts where partName = '" + partName + "' and  price = '" + price + "' and active = '1'";
            if (CheckRow(sqlChk))
            {
                MessageBox.Show("One match is found in existing records.", "Part Add Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                string sql = "INSERT INTO tblParts (partName, description, price, stock, active) VALUES ('"+partName+"', '"+description+"', '"+price+"', '"+stock+"', '1')";
                if(ExecuteQuery(sql))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdatePart()
        {
            string sql = "UPDATE tblParts SET partName = '"+partName+"', description = '"+description+"', price = '"+price+"', stock = '"+stock+"' WHERE partID = '"+partID+"'";
            if (ExecuteQuery(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeletePart()
        {
            string sql = "UPDATE tblParts SET active = '0' WHERE partID = '" + partID + "'";
            if (ExecuteQuery(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataRow GetPart(int id)
        {
            string sql = "SELECT * from tblParts where partID = '"+id+"'";
            DataRow row = GetRow(sql);
            return row;
        }

        public DataTable GetPartList()
        {
            string sql = "SELECT partID as ID, partName as Name, price as Price, stock as Stock FROM tblParts where active = '1'";
            DataTable dt = new DataTable();
            dt=LoadData(sql);
            return dt;
        }
    }
}
