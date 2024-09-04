using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ABC_Car_Traders_by_Mohanatheesan_E227421.Classes;
namespace ABC_Car_Traders_by_Mohanatheesan_E227421
{
    public partial class frmManageOrders : Form
    {
        DataTable dtOrders = new DataTable();
        DataTable dtOrderItems = new DataTable();

        public frmManageOrders()
        {
            InitializeComponent();
        }

        private void frmManageOrders_Load(object sender, EventArgs e)
        {
            LoadOrders();
        }

        public void LoadOrders()
        {
            dtOrders.Clear();
            Order order = new Order();
            dtOrders = order.ViewAllOrders();
            dataOrders.DataSource = dtOrders;
            dataOrders.Columns[1].Visible = false;
            dataOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchOrders(txtSearch.Text);
        }

        public void SearchOrders(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                LoadOrders();
            }
            else
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dtOrders;
                dataOrders.DataSource = bs;
                bs.Filter = $"CONVERT(orderID, System.String) LIKE '%{search}%' OR " +
                    $"CONVERT(orderDateTime, System.String) LIKE '%{search}%' OR " +
                    $"CONVERT(orderValue, System.String) LIKE '%{search}%' OR " +
                    $"orderStatus LIKE '%{search}%' OR " +
                    $"phone LIKE '%{search}%' OR " +
                    $"fullname LIKE '%{search}%'";
            }
        }

        private void dataOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            ViewOrderDetails(e);
        }

        public void ViewOrderDetails(DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                DataGridViewRow row = dataOrders.Rows[e.RowIndex];
                int orderID = Convert.ToInt32(row.Cells[0].Value);

                Order order = new Order();
                DataRow rowOrder = order.GetOrder(orderID);
                DataTable orderlist = order.GetOrderList(orderID);

                txtOrderID.Text = rowOrder[0].ToString();
                txtOrderDateTime.Text = rowOrder[2].ToString();
                txtOrderValue.Text = "LKR " + rowOrder[3].ToString();
                txtOrderBy.Text = rowOrder[7].ToString();
                txtPhone.Text = rowOrder[8].ToString();
                
                string orderStatus = rowOrder[4].ToString();
                txtOrderStatus.Text = orderStatus;

                if(orderStatus == "Pending")
                {
                    radioPending.Checked = true;
                }
                else if(orderStatus == "Confirmed")
                {
                    radioConfirmed.Checked = true;
                }
                else if(orderStatus == "Delivered")
                {
                    radioDelivered.Checked = true;
                }
                else if(orderStatus == "Cancelled")
                {
                    radioCancelled.Checked = true;
                }
                

                dataOrderItems.DataSource = null;
                dataOrderItems.DataSource = orderlist;
                dataOrderItems.Columns[0].Visible = false;
                dataOrderItems.Columns[1].Visible = false;
                dataOrderItems.Columns[8].Visible = false;
                dataOrderItems.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.orderID = Convert.ToInt32(txtOrderID.Text);

            string orderStaus = null;
            if (radioPending.Checked)
            {
                orderStaus = "Pending";
            }
            else if(radioConfirmed.Checked)
            {
                orderStaus = "Confirmed";
            }
            else if(radioDelivered.Checked)
            {
                orderStaus = "Delivered";
            }
            else if(radioCancelled.Checked)
            {
                orderStaus = "Cancelled";
            }
            order.orderStaus = orderStaus;
            if (order.UpdateStatus())
            {
                MessageBox.Show("Order Status was Updated Successfully", "Order Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOrderStatus.Text = orderStaus;
                LoadOrders();
            }
        }
    }
}
