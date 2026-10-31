using SQLLiteDemo.Common;
using SQLLiteDemo.DAL;

namespace SQLLiteDemo.Forms
{
    public partial class SignupForm : Form
    {
        public SignupForm(Form parent)
        {
            InitializeComponent();
            Owner = parent;
        }

        private void btnSignup_Click(object sender, EventArgs e)
        {
            UserDAL dal = new UserDAL();

            try
            {
                dal.Register(txtUsername.Text, txtPassword.Text);
                ToastHelper.ShowSuccess(this, "Account created successfully");
                Close();
                Owner.Show();
            }
            catch
            {
                ToastHelper.ShowError(this, "Username already exists");
            }
        }
    }
}
