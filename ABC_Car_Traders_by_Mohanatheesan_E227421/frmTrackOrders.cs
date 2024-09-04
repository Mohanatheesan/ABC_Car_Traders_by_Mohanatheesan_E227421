using ABC_Car_Traders_by_Mohanatheesan_E227421.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ABC_Car_Traders_by_Mohanatheesan_E227421
{
    public partial class frmTrackOrders : Form
    {
        DataTable dtOrders = new DataTable();
        DataTable dtOrderItems = new DataTable();

        public frmTrackOrders()
        {
            InitializeComponent();
        }

        public void LoadOrders()
        {
            dtOrders.Clear();
            Order order = new Order();
            dtOrders = order.ViewAllOrders();
            dataMyOrders.DataSource = dtOrders;
            dataMyOrders.Columns[1].Visible = false;
            dataMyOrders.Columns[5].Visible = false;
            dataMyOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void frmTrackOrders_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void dataMyOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewOrderDetails(e);
        }

        public void ViewOrderDetails(DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataMyOrders.Rows[e.RowIndex];
                    int orderID = Convert.ToInt32(row.Cells[0].Value);

                    Order order = new Order();
                    DataRow rowOrder = order.GetOrder(orderID);
                    DataTable orderlist = order.GetOrderList(orderID);

                    txtOrderID.Text = rowOrder[0].ToString();
                    txtOrderDateTime.Text = rowOrder[2].ToString();
                    txtOrderValue.Text = "LKR " + rowOrder[3].ToString();

                    string orderStatus = rowOrder[4].ToString();
                    txtOrderStatus.Text = orderStatus;

                    dataOrderItems.DataSource = null;
                    dataOrderItems.DataSource = orderlist;
                    dataOrderItems.Columns[0].Visible = false;
                    dataOrderItems.Columns[1].Visible = false;
                    dataOrderItems.Columns[8].Visible = false;
                    dataOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while retrieving order details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
