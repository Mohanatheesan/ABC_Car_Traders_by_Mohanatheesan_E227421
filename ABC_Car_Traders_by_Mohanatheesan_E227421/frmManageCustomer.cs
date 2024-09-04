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
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using ClosedXML.Excel;

namespace ABC_Car_Traders_by_Mohanatheesan_E227421
{
    public partial class frmManageCustomer : Form
    {

        DataTable dtCustomer = new DataTable();

        public frmManageCustomer()
        {
            InitializeComponent();
        }

        private void frmManageCustomer_Load(object sender, EventArgs e)
        {
            LoadCustomers();
        }

        public void LoadCustomers()
        {
            Users customers = new Users();
            dtCustomer = customers.LoadCustomers();

            dataCustomers.DataSource = dtCustomer;
            dataCustomers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            SearchCustomer(txtSearch.Text);
        }

        public void SearchCustomer(string txt)
        {
            if (string.IsNullOrEmpty(txt))
            {
                LoadCustomers();
            }
            else
            {
                BindingSource bs = new BindingSource();
                bs.DataSource = dtCustomer;
                dataCustomers.DataSource = bs;
                bs.Filter = $"Name LIKE '%{txt}%' OR " +
                    $"Name like '%{txt}%' OR " +
                    $"Username like '%{txt}%' OR " +
                    $"Phone like '%{txt}%' OR " +
                    $"CONVERT(Registered, System.String) LIKE '%{txt}%'";
            }
        }


        public void ExportToExcel(DataTable dt)
        {
            try
            {
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                    saveFileDialog.Title = "Save Excel File";
                    saveFileDialog.DefaultExt = "xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        using (var workbook = new XLWorkbook())
                        {
                            workbook.Worksheets.Add(dt, "Sheet1");
                            workbook.SaveAs(saveFileDialog.FileName);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred while exporting to Excel: " + ex.Message, "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            if (dtCustomer.Rows.Count == 0)
            {
                MessageBox.Show("No data available to export.", "Export Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ExportToExcel(dtCustomer);
        }
    }
}
