namespace SQLLiteDemo.Forms
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private System.ComponentModel.IContainer component=null;
        private TextBox txtUsername;
        private TextBox txtPassword;
        private Button btnLogin;
        private LinkLabel lnkSignup;
        private Label lblTitle;
        private void InitializeComponent()
        {
            txtUsername = new TextBox();
            txtPassword = new TextBox();
            btnLogin = new Button();
            lnkSignup = new LinkLabel();
            lblTitle = new Label();
            SuspendLayout();

            // Title
            lblTitle.Text = "Login";
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(120, 20);
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

            // Login Button
            btnLogin.Text = "Login";
            btnLogin.Location = new Point(50, 155);
            btnLogin.Size = new Size(220, 35);
            btnLogin.Click += btnLogin_Click;

            // Signup Link
            lnkSignup.Text = "Create new account";
            lnkSignup.Location = new Point(95, 200);
            lnkSignup.AutoSize = true;
            lnkSignup.LinkClicked += lnkSignup_LinkClicked;

            // Form
            ClientSize = new Size(320, 260);
            Controls.AddRange(new Control[] {
                lblTitle, txtUsername, txtPassword, btnLogin, lnkSignup
            });

            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Text = "Login";

            ResumeLayout(false);
        }

        #endregion
    }
}