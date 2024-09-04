using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Car_Traders_by_Mohanatheesan_E227421
{
    internal class Session
    {
        public static int userID {  get; set; }
        public static string userName { get; set; }
        public static string password { get; set; }
        public static string accType { get; set; }


        // For Cart
        public static DataTable cart;
        public static decimal OrderTotal;
        // Cart = ID, ItemType, ItemID, ItemName, ItemQty, ItemPrice, Amount
        // OrderTotal


    }
}
