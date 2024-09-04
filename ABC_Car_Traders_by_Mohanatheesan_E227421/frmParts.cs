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
    public partial class frmParts : Form
    {
        DataTable partDataTable = new DataTable();

        public frmParts()
        {
            InitializeComponent();
        }

        public void LoadPartData()
        {
            Parts part = new Parts();
            partDataTable = part.GetPartList();
            dataParts.DataSource = partDataTable;
            dataParts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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
                bs.DataSource = partDataTable;  // yourDataTable is the DataTable containing your data
                dataParts.DataSource = bs;
                bs.Filter = $"CONVERT(ID, System.String) LIKE '%{txt}%' OR " +
                    $"Name like '%{txt}%' OR " +
                    $"CONVERT(Price, System.String) LIKE '%{txt}%' OR " +
                    $"CONVERT(Stock, System.String) LIKE '%{txt}%'";
            }
        }

        public void ClearFields()
        {
            foreach (Control control in frmBoxPart.Controls)
            {
                if (control is TextBox)
                {
                    ((TextBox)control).Clear(); // Clears the text in the TextBox
                }
                else if (control is ComboBox)
                {
                    ((ComboBox)control).SelectedIndex = -1; // Clears the selected item in the ComboBox
                }
                else if (control is RichTextBox)
                {
                    ((RichTextBox)control).Clear();
                }
                //else if (control is CheckBox)
                //{
                //    ((CheckBox)control).Checked = false; // Unchecks the CheckBox
                //}
                //else if (control is RadioButton)
                //{
                //    ((RadioButton)control).Checked = false; // Unchecks the RadioButton
                //}
                // Add more conditions if you have other types of controls
            }
        }


        private void frmParts_Load(object sender, EventArgs e)
        {
            //Load Table
            LoadPartData();

            // Buttion Option
            btnAddPart.Visible = true;
            btnClearPart.Visible = true;
            btnDeletePart.Visible = false;
            btnUpdatePart.Visible = false;
        }
        private void txtPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAddPart_Click(object sender, EventArgs e)
        {
            string alert = string.Empty;

            if(txtPartName.Text == "")
            {
                alert = "Please Type Part Name";
            }
            else if(txtPrice.Text == "")
            {
                alert = "Please Type Price";
            }else if(txtStock.Text == "")
            {
                alert = "Please Type Stock";
            }else if(txtDescription.Text == "")
            {
                alert = "Please Type Description";
            }
            else
            {
                Parts part = new Parts();
                part.partName = txtPartName.Text;
                part.description = txtDescription.Text;
                part.price = Convert.ToDecimal(txtPrice.Text);
                part.stock = Convert.ToInt32(txtStock.Text);

                if (part.InsertPart())
                {
                    MessageBox.Show("Part Added Successfully", "Part Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadPartData();
                    ClearFields();
                }
            }

            if(alert != "")
            {
                MessageBox.Show(alert, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClearPart_Click(object sender, EventArgs e)
        {
            ClearFields();

            // Buttion Option
            btnAddPart.Visible = true;
            btnClearPart.Visible = true;
            btnDeletePart.Visible = false;
            btnUpdatePart.Visible = false;
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
                int partID= Convert.ToInt32(row.Cells[0].Value);

                Parts parts = new Parts();
                DataRow arow = parts.GetPart(partID);

                txtPartID.Text = arow[0].ToString();
                txtPartName.Text = arow[1].ToString();
                txtDescription.Text = arow[2].ToString();
                txtPrice.Text = arow[3].ToString();
                txtStock.Text = arow[4].ToString();
            }

            // Button Option
            btnAddPart.Visible = false;
            btnClearPart.Visible = true;
            btnDeletePart.Visible = true;
            btnUpdatePart.Visible = true;
        }

        private void btnUpdatePart_Click(object sender, EventArgs e)
        {
            string alert = string.Empty;
            if (txtPartID.Text == "")
            {
                alert = "Please Select the Record Again";
            }
            else
            {
                if (txtPartName.Text == "")
                {
                    alert = "Please Type Part Name";
                }
                else if (txtPrice.Text == "")
                {
                    alert = "Please Type Price";
                }
                else if (txtStock.Text == "")
                {
                    alert = "Please Type Stock";
                }
                else if (txtDescription.Text == "")
                {
                    alert = "Please Type Description";
                }
                else
                {
                    Parts part = new Parts();
                    part.partID = Convert.ToInt32(txtPartID.Text);
                    part.partName = txtPartName.Text;
                    part.description = txtDescription.Text;
                    part.price = Convert.ToDecimal(txtPrice.Text);
                    part.stock = Convert.ToInt32(txtStock.Text);

                    if (part.UpdatePart())
                    {
                        MessageBox.Show("Part Updated Successfully", "Part Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPartData();
                    }
                    else
                    {
                        MessageBox.Show("Part NOT Updated", "Part Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            if (alert != "")
            {
                MessageBox.Show(alert);
            }
        }

        private void btnDeletePart_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to delete the Part", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Parts part = new Parts();
                part.partID = Convert.ToInt32(txtPartID.Text);
                if (part.DeletePart())
                {
                    MessageBox.Show("The Part was Deleted Successfully", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadPartData();
                    ClearFields();

                    // Button Option
                    btnAddPart.Visible = true;
                    btnClearPart.Visible = true;
                    btnDeletePart.Visible = false;
                    btnUpdatePart.Visible = false;
                }
                else
                {
                    MessageBox.Show("The Part was Not Deleted", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchDataPart(txtSearch.Text);
        }
    }
}
