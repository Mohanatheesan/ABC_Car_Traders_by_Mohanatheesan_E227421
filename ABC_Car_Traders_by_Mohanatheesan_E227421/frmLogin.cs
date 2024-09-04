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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Users user = new Users();
            user.username = txtUsername.Text;
            user.password = txtPassword.Text;

            if (user.username == "")
            {
                MessageBox.Show("Please type Username", "Login Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsername.Focus();
            }
            else if(user.password==""){
                MessageBox.Show("Please type Password", "Login Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
            }
            else
            {
                if (user.Login())
                {
                    this.Hide();
                    frmDashboard frmDashboard = new frmDashboard();
                    frmDashboard.Show();
                }
                else
                {
                    MessageBox.Show("Invalid Login, Please try again", "Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsername.Focus();
                }
            }
               
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        private void btnNoAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmRegister frmRegister = new frmRegister();
            frmRegister.Show();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
