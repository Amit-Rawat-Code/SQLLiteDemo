using SQLLiteDemo.Common;
using SQLLiteDemo.DAL;
using SQLLiteDemo.Models;
using SQLLiteDemo.Security;

namespace SQLLiteDemo.Forms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            UserDAL dal = new UserDAL();
            User user = dal.Login(txtUsername.Text, txtPassword.Text);
            if (user != null)
            {
                //string lastPage = Properties.Settings.Default.LastPage;

                //if (string.IsNullOrEmpty(lastPage))
                //{
                //    Properties.Settings.Default.LastPage = "Dashboard";
                //    Properties.Settings.Default.Save();
                //}
                SessionManager.Start(user.Id, user.Username, "User");
                this.Hide();
                new DesktopForm().Show();
            }
            else
            {
                ToastHelper.ShowError(this, "Invalid username or password");
            }
        }
        private void lnkSignup_LinkClicked(object sender, EventArgs e)
        {
            Hide();
            new SignupForm(this).Show();
        }
    }
}
