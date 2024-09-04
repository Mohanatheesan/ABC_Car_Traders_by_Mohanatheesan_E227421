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
    public partial class frmOrderCars : Form
    {
        DataTable carsDataTable = new DataTable();

        public frmOrderCars()
        {
            InitializeComponent();
        }

        public void LoadCarData()
        {
            Cars cars = new Cars();
            carsDataTable = cars.GetCarList();
            dataCars.DataSource = carsDataTable;
            dataCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void frmOrderCars_Load(object sender, EventArgs e)
        {
            LoadCarData();

            LoadCart();
        }

        public void LoadCart()
        {
            dataCart.DataSource = Session.cart;
            dataCart.Columns[0].Visible = false;
            dataCart.Columns[1].Visible = false;
            dataCart.Columns[2].Visible = false;
            dataCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            txtOrderTotal.Text = Session.OrderTotal.ToString();
        }
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchDataCar(txtSearch.Text);
        }

        public void SearchDataCar (string txt)
        {
            if (string.IsNullOrEmpty(txt))
            {
                LoadCarData();
            }
            else
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = carsDataTable;
                dataCars.DataSource = bs;
                bs.Filter = $"Brand LIKE '%{txt}%' OR " +
                    $"Model like '%{txt}%' OR " +
                    $"CONVERT(Year, System.String) LIKE '%{txt}%' OR " +
                    $"CONVERT(Price, System.String) LIKE '%{txt}%' OR " +
                    $"CONVERT(Stock, System.String) LIKE '%{txt}%'";
            }
        }

        private void dataCars_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataCarSelect(e);
        }

        public void DataCarSelect(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataCars.Rows[e.RowIndex];
                int carID = Convert.ToInt32(row.Cells[0].Value);

                Cars cars = new Cars();
                DataRow arow = cars.GetCar(carID);

                txtItemID.Text = arow[0].ToString();
                txtName.Text = arow[1].ToString() + " " + arow[2].ToString() + " " + arow[3].ToString();
                txtPrice.Text = arow[4].ToString();
                txtStock.Text = arow[5].ToString();
                txtDescription.Text = arow[6].ToString();
            }

            // Button Option
            btnAddToCart.Visible = true;
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if(txtItemID.Text == "")
            {
                MessageBox.Show("Please Select Again", "Cart Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(Convert.ToInt32(txtQty.Text) < 1)
            {
                MessageBox.Show("Please Type Quantity", "Cart Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }else
            {

                // Cart = ID, ItemType, ItemID, ItemName, ItemQty, ItemPrice, Amount
                
                int ItemID = Convert.ToInt32(txtItemID.Text);
                string ItemName = txtName.Text;
                int ItemQty = Convert.ToInt32(txtQty.Text);
                decimal ItemPrice = Convert.ToDecimal(txtPrice.Text);
                decimal amount = ItemQty * ItemPrice;

                DataRow[] foundRow = Session.cart.Select("ItemType = 'Car' AND ItemID = '"+ItemID+"'");

                if(foundRow.Length > 0)
                {
                    MessageBox.Show("The Item is Already in the Cart", "Cart Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DataRow row = Session.cart.NewRow();
                    row[1] = "Car";
                    row[2] = ItemID;
                    row[3] = ItemName;
                    row[4] = ItemQty;
                    row[5] = ItemPrice;
                    row[6] = amount;
                    Session.cart.Rows.Add(row);

                    Session.OrderTotal += amount;

                    LoadCart();
                }

            }
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
