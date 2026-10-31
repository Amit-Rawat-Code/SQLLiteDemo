namespace SQLLiteDemo.Forms
{
    partial class SignupForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnSignup;
        private Label lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnSignup = new Button();
            lblTitle = new Label();
            SuspendLayout();

            // Title
            lblTitle.Text = "Sign Up";
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(110, 20);
            lblTitle.AutoSize = true;

            // Username
            txtUsername.Location = new Point(50, 70);
            txtUsername.Size = new Size(220, 27);
            txtUsername.PlaceholderText = "Username";

            // Password
            txtPassword.Location = new Point(50, 110);
            txtPassword.Size = new Size(220, 27);
            txtPassword.PlaceholderText = "Password";
            txtPassword.PasswordChar = '*';

            // Signup Button
            btnSignup.Text = "Create Account";
            btnSignup.Location = new Point(50, 155);
            btnSignup.Size = new Size(220, 35);
            btnSignup.Click += btnSignup_Click;

            // Form
            ClientSize = new Size(320, 230);
            Controls.AddRange(new Control[] {
                lblTitle, txtUsername, txtPassword, btnSignup
            });

            StartPosition = FormStartPosition.CenterParent;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Text = "Sign Up";

            ResumeLayout(false);
        }
    }
}
