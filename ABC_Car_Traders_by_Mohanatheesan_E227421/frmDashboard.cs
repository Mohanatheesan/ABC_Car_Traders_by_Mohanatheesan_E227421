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
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            lblUsername.Text = "Hello " + Session.userName;
            lblAccType.Text = "("+Session.accType+")";

            if( Session.accType == "Customer")
            {
                btnCars.Visible = false;
                btnParts.Visible = false;
                btnManageOrders.Visible = false;
                btnManageCustomers.Visible = false;
            }
            else
            {
                btnFindCar.Visible = false;
                btnFindPart.Visible = false;
                btnCart.Visible = false;
                btnTrackOrders.Visible = false;
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Do you want to close the application?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Do you want to Logout?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Session.userID = 0;
                Session.userName = null;
                Session.password = null;
                Session.accType = null;

                this.Hide();
                frmLogin frmLogin = new frmLogin();
                frmLogin.Show();
            }
        }


        private void btnCars_Click(object sender, EventArgs e)
        {
            this.panelBody.Controls.Clear();
            frmCars frmCars = new frmCars()
            {
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            this.panelBody.Controls.Add(frmCars);
            frmCars.Show();
        }

        private void btnParts_Click(object sender, EventArgs e)
        {
            this.panelBody.Controls.Clear();
            frmParts frmParts = new frmParts()
            {
                TopLevel = false,
                TopMost = true,
                FormBorderStyle= FormBorderStyle.None
            };
            this.panelBody.Controls.Add(frmParts);
            frmParts.Show();
        }

        private void panelHead_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnFindCar_Click(object sender, EventArgs e)
        {
            this.panelBody.Controls.Clear();
            frmOrderCars frmOrderCars = new frmOrderCars()
            {
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            this.panelBody.Controls.Add(frmOrderCars);
            frmOrderCars.Show();
        }

        private void btnCart_Click(object sender, EventArgs e)
        {
            this.panelBody.Controls.Clear();
            frmCart frmCart = new frmCart()
            {
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            this.panelBody.Controls.Add(frmCart);
            frmCart.Show();
        }

        private void btnFindPart_Click(object sender, EventArgs e)
        {
            this.panelBody.Controls.Clear();
            frmOrderParts frmOrderParts = new frmOrderParts()
            {
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            this.panelBody.Controls.Add(frmOrderParts);
            frmOrderParts.Show();
        }

        private void btnManageOrders_Click(object sender, EventArgs e)
        {
            this.panelBody.Controls.Clear();
            frmManageOrders frmManageOrders = new frmManageOrders() {
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            this.panelBody.Controls.Add(frmManageOrders);
            frmManageOrders.Show();
        }

        private void btnTrackOrders_Click(object sender, EventArgs e)
        {
            this.panelBody.Controls.Clear();
            frmTrackOrders frmTrackOrders = new frmTrackOrders()
            {
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            this.panelBody.Controls.Add(frmTrackOrders);
            frmTrackOrders.Show();
        }

        private void btnManageCustomers_Click(object sender, EventArgs e)
        {
            this.panelBody.Controls.Clear();
            frmManageCustomer frmManageCustomer = new frmManageCustomer()
            {
                TopLevel = false,
                TopMost = true,
                FormBorderStyle = FormBorderStyle.None
            };
            this.panelBody.Controls.Add(frmManageCustomer);
            frmManageCustomer.Show();
        }
    }
}
