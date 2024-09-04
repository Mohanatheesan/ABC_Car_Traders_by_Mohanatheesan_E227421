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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ABC_Car_Traders_by_Mohanatheesan_E227421
{
    public partial class frmCart : Form
    {
        public frmCart()
        {
            InitializeComponent();
        }

        public void LoadDataCart()
        {
            dataCart.DataSource = Session.cart;
            dataCart.Columns[0].ReadOnly = true;

            dataCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            txtOrderTotal.Text = Session.OrderTotal.ToString();
        }


        public void DataCartSelect(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataCart.Rows[e.RowIndex];
                DataRow arow = null;

                int cartID = Convert.ToInt32(row.Cells[0].Value);
                int ItemID = Convert.ToInt32(row.Cells[2].Value);
                string ItemType = row.Cells[1].Value.ToString();

                string ItemName = "";

                if(ItemType == "Car")
                {
                    Cars car = new Cars();
                    arow = car.GetCar(ItemID);

                    ItemName = arow[1].ToString() + " " + arow[2].ToString() + " " + arow[3].ToString();
                    txtID.Text = cartID.ToString();
                    txtItemID.Text = arow[0].ToString();
                    txtName.Text = ItemName;
                    txtPrice.Text = arow[4].ToString();
                    txtStock.Text = arow[5].ToString();
                    txtDescription.Text = arow[6].ToString();

                    txtQty.Text = row.Cells[4].Value.ToString();
                }
                else if(ItemType == "Part")
                {
                    Parts part = new Parts();
                    arow = part.GetPart(ItemID);

                    ItemName = arow[1].ToString();
                    txtID.Text = cartID.ToString();
                    txtItemID.Text = arow[0].ToString();
                    txtName.Text = ItemName;
                    txtPrice.Text = arow[3].ToString();
                    txtStock.Text = arow[4].ToString();
                    txtDescription.Text = arow[2].ToString();

                    txtQty.Text = row.Cells[4].Value.ToString();
                }


                btnUpdateQty.Visible = true;
                btnRemoveItem.Visible = true;
            }
        }

        private void frmCart_Load(object sender, EventArgs e)
        {
            LoadDataCart();
        }

        private void dataCart_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataCartSelect(e);
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnUpdateQty_Click(object sender, EventArgs e)
        {
            string select = "ID = "+txtID.Text;

            DataRow[] rowToUpdate = Session.cart.Select(select);

            if(rowToUpdate.Length > 0)
            {
                DataRow row = rowToUpdate[0];
                row[4] = Convert.ToInt32(txtQty.Text);

                Decimal oldAmount = Convert.ToDecimal(row[6]);

                Decimal amount = Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(txtQty.Text);
                row[6] = amount;

                Session.OrderTotal = Session.OrderTotal - oldAmount + amount;

                LoadDataCart();
            }
        }

        private void btnRemoveItem_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to remove item?", "Cart Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string select = "ID = " + txtID.Text;

                DataRow[] rowToDelete = Session.cart.Select(select);

                if (rowToDelete.Length > 0)
                {
                    DataRow row = rowToDelete[0];

                    Decimal amount = Convert.ToDecimal(row[6]);

                    Session.cart.Rows.Remove(row);
                    Session.OrderTotal -= amount;

                    txtID.Text = string.Empty;
                    txtItemID.Text = string.Empty;
                    txtName.Text = string.Empty;
                    txtPrice.Text = string.Empty;
                    txtStock.Text = string.Empty;
                    txtQty.Text = string.Empty;
                    txtDescription.Text = string.Empty;

                    btnUpdateQty.Visible = false;
                    btnRemoveItem.Visible = false;

                    LoadDataCart();
                }
            }
        }

        private void btnClearCart_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to Clear the Cart?", "Cart Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Session.cart.Clear();
                Session.OrderTotal = 0;

                txtID.Text = string.Empty;
                txtItemID.Text = string.Empty;
                txtName.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtStock.Text = string.Empty;
                txtQty.Text = string.Empty;
                txtDescription.Text = string.Empty;

                btnUpdateQty.Visible = false;
                btnRemoveItem.Visible = false;

                LoadDataCart();
            }
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            Order order = new Order();
            order.orderBy = Session.userID;
            order.orderDateTime = DateTime.Now;
            order.orderValue = Session.OrderTotal;
            order.orderStaus = "Pending";

            if (order.PlaceOrder())
            {
                MessageBox.Show("Order Placed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Session.cart.Clear();
                Session.OrderTotal = 0;

                txtID.Text = string.Empty;
                txtItemID.Text = string.Empty;
                txtName.Text = string.Empty;
                txtPrice.Text = string.Empty;
                txtStock.Text = string.Empty;
                txtQty.Text = string.Empty;
                txtDescription.Text = string.Empty;

                btnUpdateQty.Visible = false;
                btnRemoveItem.Visible = false;

                LoadDataCart();
            }
            else
            {
                MessageBox.Show("Please contact the Admin", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
