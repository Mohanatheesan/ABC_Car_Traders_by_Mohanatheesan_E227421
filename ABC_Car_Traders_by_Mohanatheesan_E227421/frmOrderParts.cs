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
    public partial class frmOrderParts : Form
    {
        DataTable partsDataTable = new DataTable();

        public frmOrderParts()
        {
            InitializeComponent();
        }

        public void LoadPartData()
        {
            Parts parts = new Parts();
            partsDataTable = parts.GetPartList();
            dataParts.DataSource = partsDataTable;
            dataParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        public void SearchDataPart(string txt)
        {
            if (string.IsNullOrEmpty(txt))
            {
                LoadPartData();
            }
            else
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = partsDataTable;
                dataParts.DataSource = bs;
                bs.Filter = $"Name LIKE '%{txt}%' OR " +
                    $"CONVERT(Price, System.String) LIKE '%{txt}%' OR " +
                    $"CONVERT(Stock, System.String) LIKE '%{txt}%'";
            }
        }

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (txtItemID.Text == "")
            {
                MessageBox.Show("Please Select Again", "Cart Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (Convert.ToInt32(txtQty.Text) < 1)
            {
                MessageBox.Show("Please Type Quantity", "Cart Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {

                // Cart = ID, ItemType, ItemID, ItemName, ItemQty, ItemPrice, Amount

                int ItemID = Convert.ToInt32(txtItemID.Text);
                string ItemName = txtName.Text;
                int ItemQty = Convert.ToInt32(txtQty.Text);
                decimal ItemPrice = Convert.ToDecimal(txtPrice.Text);
                decimal amount = ItemQty * ItemPrice;

                DataRow[] foundRow = Session.cart.Select("ItemType = 'Part' AND ItemID = '" + ItemID + "'");

                if (foundRow.Length > 0)
                {
                    MessageBox.Show("The Item is Already in the Cart", "Cart Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DataRow row = Session.cart.NewRow();
                    row[1] = "Part";
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

        private void frmOrderParts_Load(object sender, EventArgs e)
        {
            LoadPartData();
            LoadCart();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchDataPart(txtSearch.Text);
        }

        private void txtQty_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataParts_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataPartSelect(e);
        }
        public void DataPartSelect(DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataParts.Rows[e.RowIndex];
                int partID = Convert.ToInt32(row.Cells[0].Value);

                Parts parts = new Parts();
                DataRow arow = parts.GetPart(partID);

                txtItemID.Text = arow[0].ToString();
                txtName.Text = arow[1].ToString();
                txtPrice.Text = arow[3].ToString();
                txtStock.Text = arow[4].ToString();
                txtDescription.Text = arow[2].ToString();
            }

            // Button Option
            btnAddToCart.Visible = true;
        }
    }
}
