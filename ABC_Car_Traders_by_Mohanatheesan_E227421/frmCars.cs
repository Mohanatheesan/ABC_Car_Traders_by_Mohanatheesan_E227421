using ABC_Car_Traders_by_Mohanatheesan_E227421.Classes;
using System;
using System.Data;
using System.Windows.Forms;


namespace ABC_Car_Traders_by_Mohanatheesan_E227421
{
    public partial class frmCars : Form
    {
        public string[] brands;
        DataTable carDataTable = new DataTable();
        



        public frmCars()
        {
            InitializeComponent();
        }

        public void LoadCarData()
        {
            Cars car = new Cars();
            carDataTable = car.GetCarList();
            dataCars.DataSource = carDataTable;
            dataCars.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void SearchDataCar(string txt)
        {
            if (string.IsNullOrEmpty(txt))
            {
                LoadCarData();
            }
            else
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = carDataTable; 
                dataCars.DataSource = bs;
                bs.Filter = $"Brand LIKE '%{txt}%' OR " +
                    $"Model like '%{txt}%' OR " +
                    $"CONVERT(Year, System.String) LIKE '%{txt}%' OR " +
                    $"CONVERT(Price, System.String) LIKE '%{txt}%' OR " +
                    $"CONVERT(Stock, System.String) LIKE '%{txt}%'";
            }
        }

        public void ClearFields()
        {
            foreach (Control control in frmBoxCar.Controls)
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

        

        private void frmCars_Load(object sender, EventArgs e)
        {
            Cars cars = new Cars();
            DataTable brands = cars.LoadBrands();
            
            foreach (DataRow row in brands.Rows)
            {
                foreach(DataColumn col in brands.Columns)
                {
                    cmbBrands.Items.Add(row[col].ToString());
                }
            }

            //Load Table
            LoadCarData();

            // Buttion Option
            btnAddCar.Visible = true;
            btnClearCar.Visible = true;
            btnDeleteCar.Visible = false;
            btnUpdateCar.Visible = false;
        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }


        private void txtPrice_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        

        private void txtYear_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtStock_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            string alert = string.Empty;
            if(cmbBrands.SelectedIndex == 0)
            {
                alert = "Please select a brand";
            }else if (txtModel.Text == "")
            {
                alert = "Please Type Model";
            }else if (txtYear.Text == "")
            {
                alert = "Please Type Year";
            }else if (txtPrice.Text == "")
            {
                alert = "Please Type Price";
            }else if (txtStock.Text == "")
            {
                alert = "Please Type Stock";
            }else if (txtDescription.Text == "")
            {
                alert = "Please Type Description";
            }
            else
            {
                Cars car = new Cars();
                car.brand = cmbBrands.Text;
                car.model = txtModel.Text;
                car.year = Convert.ToInt32(txtYear.Text);
                car.price = Convert.ToDecimal(txtPrice.Text);
                car.stock = Convert.ToInt32(txtStock.Text);
                car.description = txtDescription.Text;

                if (car.InsertCar())
                {
                    MessageBox.Show("Car Added Successfully", "Car Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadCarData();
                    ClearFields();
                }
            }

            if (alert != "")
            {
                MessageBox.Show(alert, "Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClearCar_Click(object sender, EventArgs e)
        {
            ClearFields();

            // Buttion Option
            btnAddCar.Visible = true;
            btnClearCar.Visible = true;
            btnDeleteCar.Visible = false;
            btnUpdateCar.Visible = false;
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

                txtCarID.Text = arow[0].ToString();
                cmbBrands.SelectedItem = arow[1].ToString();
                txtModel.Text = arow[2].ToString();
                txtYear.Text = arow[3].ToString();
                txtPrice.Text = arow[4].ToString();
                txtStock.Text = arow[5].ToString();
                txtDescription.Text = arow[6].ToString();
            }

            // Button Option
            btnAddCar.Visible = false;
            btnClearCar.Visible = true;
            btnDeleteCar.Visible = true;
            btnUpdateCar.Visible = true;
        }

        private void btnUpdateCar_Click(object sender, EventArgs e)
        {
            string alert = string.Empty;
            if(txtCarID.Text == "")
            {
                alert = "Please Select the Record Again";
            }
            else
            {
                if (cmbBrands.SelectedIndex == 0)
                {
                    alert = "Please select a brand";
                }
                else if (txtModel.Text == "")
                {
                    alert = "Please Type Model";
                }
                else if (txtYear.Text == "")
                {
                    alert = "Please Type Year";
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
                    Cars car = new Cars();
                    car.carID = Convert.ToInt32(txtCarID.Text);
                    car.brand = cmbBrands.Text;
                    car.model = txtModel.Text;
                    car.year = Convert.ToInt32(txtYear.Text);
                    car.price = Convert.ToDecimal(txtPrice.Text);
                    car.stock = Convert.ToInt32(txtStock.Text);
                    car.description = txtDescription.Text;

                    if (car.UpdateCar())
                    {
                        MessageBox.Show("Car Updated Successfully", "Car Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadCarData();
                    }
                    else
                    {
                        MessageBox.Show("Car NOT Updated", "Car Alert", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }

            if(alert != "")
            {
                MessageBox.Show(alert);
            }
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to delete the Car", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cars car = new Cars();
                car.carID = Convert.ToInt32(txtCarID.Text);
                if (car.DeleteCar())
                {
                    MessageBox.Show("The Car was Deleted Successfully", "Delete Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    LoadCarData();
                    ClearFields();

                    // Button Option
                    btnAddCar.Visible = true;
                    btnClearCar.Visible = true;
                    btnDeleteCar.Visible = false;
                    btnUpdateCar.Visible = false;
                }
                else
                {
                    MessageBox.Show("The Car was Not Deleted", "Delete Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchDataCar(txtSearch.Text);
        }

        private void dataCars_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            //DataCarSelect(e);
        }
    }
}
