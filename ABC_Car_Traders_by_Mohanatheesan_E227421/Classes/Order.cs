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
    internal class Order : DBClass
    {
        public int orderID { get; set; }
        public int orderBy { get; set; }
        public DateTime orderDateTime { get; set; }
        public decimal orderValue { get; set; }
        public string orderStaus { get; set; }
        // Pending | Confirmed | Delivered | Cancelled

        public bool PlaceOrder()
        {
            string sql = "INSERT INTO tblOrders (orderBy, orderDateTime, orderValue, orderStatus, active) VALUES ('"+orderBy+"', '"+orderDateTime+"', '"+orderValue+"','"+orderStaus+"', '1')";

            if (ExecuteQuery(sql))
            {
                sql = "SELECT * FROM tblOrders WHERE orderBy = '" + orderBy + "' and orderDateTime = '" + orderDateTime + "' and orderValue = '" + orderValue + "' and orderStatus = 'Pending' ";
                DataRow rowInserted = GetRow(sql);
                orderID = Convert.ToInt32(rowInserted[0].ToString());

                if (AddOrderItems(orderID))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }   
        }

        public bool AddOrderItems(int ID)
        {
            bool status = false;
            foreach(DataRow row in Session.cart.Rows)
            {
                // Cart = ID, ItemType, ItemID, ItemName, ItemQty, ItemPrice, Amount
                int orderID = ID;
                string itemType = row[1].ToString();
                int itemID = Convert.ToInt32(row[2].ToString());
                string itemName = row[3].ToString();
                int itemQty = Convert.ToInt32(row[4].ToString());
                decimal itemPrice = Convert.ToDecimal(row[5].ToString());
                decimal amount = Convert.ToDecimal(row[6].ToString());

                string sql = "INSERT INTO tblOrderItems (orderID, itemType, itemID, itemName, itemQty, itemPrice, amount, active) VALUES ('"+orderID+"', '"+itemType+"', '"+itemID+"', '"+itemName+"', '"+itemQty+"', '"+itemPrice+"', '"+amount+"', '1')";
                if (ExecuteQuery(sql))
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
            }
            return status;
        }


        public DataTable ViewAllOrders()
        {
            string sql = "";
            if(Session.accType == "Customer")
            {
                sql = "SELECT * FROM tblOrders " +
                "WHERE orderBy = '" + Session.userID + "'";
            }
            else
            {
                sql = "SELECT * FROM tblOrders " +
                "JOIN (select userID, fullname, phone, accType from tblUsers) users " +
                "ON tblOrders.orderBy = users.userID";
            }
            

            DataTable dataTable = new DataTable();
            dataTable = LoadData(sql);
            return dataTable;
        }

        public DataRow GetOrder(int ID)
        {
            string sql = "SELECT * FROM tblOrders " +
                "JOIN (select userID, fullname, phone from tblUsers) users " +
                "ON tblOrders.orderBy = users.userID " +
                "Where tblOrders.orderID = '" + ID + "'";
            DataRow row = GetRow(sql);
            return row;
        }

        public DataTable GetOrderList(int ID)
        {
            string sql = "SELECT * from tblOrderItems where orderID = '" + ID + "' and active = '1'";
            DataTable dataTable = LoadData(sql);
            return dataTable;
        }

        public bool UpdateStatus()
        {
            string sql = "UPDATE tblOrders SET orderStatus = '" + orderStaus + "' WHERE orderID = '" + orderID + "'";
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
}
