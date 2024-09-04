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
    internal class Cars : DBClass
    {
        public int carID { get; set; }
        public string brand { get; set; }
        public string model { get; set; }
        public int year { get; set; }
        public decimal price {  get; set; }
        public int stock { get; set; }
        public string description { get; set; }

        

        public bool InsertCar()
        {
            string sqlChk = "SELECT * from tblCars where brand ='"+brand+"' and model='"+model+"' and year='"+year+"' and active='1'";
            if (CheckRow(sqlChk))
            {
                MessageBox.Show("One match is found in existing records.", "Car Add Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            else
            {
                string sql = "INSERT INTO tblCars (brand, model, year, price, stock, description, active) VALUES ('" + brand + "', '"+model+"', '"+year+"', '"+price+"', '"+stock+"', '"+description+"', '1')";

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

        public bool UpdateCar()
        {
            string sql = "UPDATE tblCars SET brand = '"+brand+"', model = '"+model+"', year = '"+year+"', price = '"+price+"', stock = '"+stock+"', description = '"+description+"' WHERE carID = '"+carID+"'";
            if (ExecuteQuery(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCar()
        {
            string sql = "UPDATE tblCars set active ='0' where carID = '"+carID+"'";
            if (ExecuteQuery(sql))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public DataRow GetCar(int id)
        {
            string sql = "SELECT * FROM tblCars where carID = '"+id+"' ";
            DataRow row = GetRow(sql);
            return row;
        }

        public DataTable GetCarList()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT carID as ID, brand as Brand, model as Model, year as Year, price as Price, stock as Stock from tblCars where active='1'";
            dt=LoadData(sql);
            return dt;
        }
        
        public DataTable LoadBrands()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT brandName from tblBrands ORDER BY brandName";
            dt=LoadData(sql);
            return dt;
        }
    }
}
