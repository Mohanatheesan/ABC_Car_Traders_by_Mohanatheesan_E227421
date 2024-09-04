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
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
        }

        private void btnHaveAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            frmLogin frmLogin = new frmLogin();
            frmLogin.Show();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string alert = "Please fill ";
            bool alertShow = false;

            if (txtFullname.Text == "")
            {
                //MessageBox.Show("Please type Fullname", "Login Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                alert += "Fullname ";
                alertShow = true;
                txtFullname.Focus();
            }
             if (txtUsername.Text == "")
            {
                //MessageBox.Show("Please type Username", "Login Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                alert += "Username ";
                alertShow = true;
                txtUsername.Focus();
            }
             if(txtPassword.Text == "")
            {
                //MessageBox.Show("Please type Password", "Login Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                alert += "Password ";
                alertShow=true;
                txtPassword.Focus();
            }
             if (txtPhone.Text == "")
            {
                //MessageBox.Show("Please type Phone", "Login Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                alert += "Phone ";
                alertShow = true;
                txtPhone.Focus();
            }

            if (alertShow)
            {
                MessageBox.Show(alert, "Register Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                alertShow = false;

                Users user = new Users();
                user.fullname = txtFullname.Text;
                user.username = txtUsername.Text;
                user.password = txtPassword.Text;
                user.phone = txtPhone.Text;
                if (user.InsertUser())
                {
                    MessageBox.Show("The Account was created Successfully", "Register", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    frmLogin frmLogin = new frmLogin();
                    frmLogin.Show();
                }
                else
                {
                    MessageBox.Show("The Account was NOT created", "Register Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
