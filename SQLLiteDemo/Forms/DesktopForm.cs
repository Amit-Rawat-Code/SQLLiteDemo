using SQLLiteDemo.Common;
using SQLLiteDemo.Security;

namespace SQLLiteDemo.Forms
{
    public enum AppPage
    {
        Dashboard,
        Employee,
        Payroll
    }

    public partial class DesktopForm : Form
    {
        private bool IsAutoLogout = false;
        private Label lblSessionTimer;
        private System.Windows.Forms.Timer countdownTimer;
        private TimeSpan remainingTime;

        private System.Windows.Forms.Timer sessionTimer;
        private const int SESSION_TIMEOUT_MINUTES = 5;

        private Panel panelNav;
        private Panel panelContent;
        private Panel panelHeader;
        private Label lblHeaderTitle;
        private Panel navIndicator;

        public DesktopForm()
        {
            InitializeUI();
            this.KeyPreview = true;
            AttachActivityHandlers(this);
            //LoadDefaultDashboard();
            LoadInitialPage();
            CreateSessionTimerLabel();
            StartCountdown();
            //StartSessionTimer();            
        }

        private void InitializeUI()
        {
            Text = "Payroll Management System";
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;

            // LEFT NAV PANEL
            panelNav = new Panel
            {
                Dock = DockStyle.Left,
                Width = 230,
                BackColor = Color.FromArgb(32, 32, 32),
                Padding=new Padding(0,10,10,10)
            };

            // HEADER PANEL
            panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 70,
                BackColor = Color.FromArgb(240, 243, 248)
            };
            lblHeaderTitle = new Label
            {
                Text = "Payroll Management System",
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };

            panelHeader.Controls.Add(lblHeaderTitle);


            // CONTENT PANEL
            panelContent = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            
            Controls.Add(panelContent);
            Controls.Add(panelHeader);
            Controls.Add(panelNav);
            navIndicator = new Panel
            {
                Width = 4,
                Height = 48,
                BackColor = Color.DeepSkyBlue,
                Visible = false
            };

            panelNav.Controls.Add(navIndicator);
            panelNav.Controls.SetChildIndex(navIndicator, 0);

            AddNavButtons();
        }

        private void AddNavButtons()
        {
            panelNav.Controls.Add(CreateNavButton("Logout", 3, Logout));
            if (SessionManager.Role == "Admin" || SessionManager.Role == "HR")
                panelNav.Controls.Add(CreateNavButton("Payroll", 2, () =>
                    OpenPayroll()));

            panelNav.Controls.Add(CreateNavButton("Employee",1, () =>
                OpenEmployee()));
            
            panelNav.Controls.Add(CreateNavButton("Dashboard",0, () =>
                OpenDashboard(false)));

            //panelNav.Controls.Add(CreateNavButton("Payroll", 2, () =>
            //    LoadForm(new PayrollForm())));

            //panelNav.Controls.Add(CreateNavButton("Employees", 1, () =>
            //    LoadForm(new EmployeeForm())));

            //panelNav.Controls.Add(CreateNavButton("Dashboard", 0, () =>
            //    LoadForm(new DashboardForm())));
        }

        private Button CreateNavButton(string text, int index, Action onClick)
        {
            var btn = new Button
            {
                Text = text,
                Dock = DockStyle.Top,
                Height = 48,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.White,
                BackColor = Color.FromArgb(32, 32, 32),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.Click += (s, e) =>
            {
                HighlightButton(btn);
                onClick();
            };

            return btn;
        }
        // ==========================
        // ACTIVE MENU HIGHLIGHT
        // ==========================
        private void HighlightButton(Button activeBtn)
        {
            navIndicator.Visible = false;
            navIndicator.Top = activeBtn.Top;
            navIndicator.Height = activeBtn.Height;
            foreach (Control ctrl in panelNav.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.FromArgb(32, 32, 32);
                    btn.ForeColor = Color.White;
                }
            }

            activeBtn.BackColor = Color.FromArgb(55, 120, 215);
            activeBtn.ForeColor = Color.White;
        }
        private void LoadForm(Form form, AppPage page, Button btn)
        {
            panelContent.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            panelContent.Controls.Add(form);
            AttachActivityHandlers(form);
            form.Show();            
            HighlightButton(btn);
            UpdateHeaderTitle(page);

            // ✅ Remember last page
            Properties.Settings.Default.LastPage = page.ToString();
            Properties.Settings.Default.Save();
        }

        private void LoadDefaultDashboard()
        {
            foreach (Control ctrl in panelNav.Controls)
            {
                if (ctrl is Button btn && btn.Text == "Dashboard")
                {
                    HighlightButton(btn);
                    //LoadForm(new DashboardForm());
                    break;
                }
            }
        }
        private void LoadInitialPage()
        {
            string lastPage = Properties.Settings.Default.LastPage;

            if (string.IsNullOrEmpty(lastPage))
            {
                OpenDashboard(showWelcome: true);
            }
            else
            {
                Enum.TryParse(lastPage, out AppPage page);

                switch (page)
                {
                    case AppPage.Employee:
                        OpenEmployee();
                        break;
                    case AppPage.Payroll:
                        OpenPayroll();
                        break;
                    default:
                        OpenDashboard(false);
                        break;
                }
            }
        }
        private void OpenDashboard(bool showWelcome)
        {
            var btn = GetNavButton("Dashboard");

            LoadForm(new DashboardForm(), AppPage.Dashboard, btn);

            if (showWelcome)
            {
                ToastHelper.ShowSuccess(this, "Welcome to Payroll Management System");
            }
        }
        private void UpdateHeaderTitle(AppPage page)
        {
            lblHeaderTitle.Text = page switch
            {
                AppPage.Dashboard => "Dashboard",
                AppPage.Employee => "Employee Management",
                AppPage.Payroll => "Payroll Processing",
                _ => "Payroll Management System"
            };
        }
        private void OpenEmployee()
        {
            LoadForm(new EmployeeForm(), AppPage.Employee, GetNavButton("Employee"));
        }

        private void OpenPayroll()
        {
            LoadForm(new PayrollForm(), AppPage.Payroll, GetNavButton("Payroll"));
        }
        private Button GetNavButton(string text)
        {
            return panelNav.Controls
                .OfType<Button>()
                .First(b => b.Text == text);
        }

        private void Logout()
        {
            if (IsAutoLogout)
            {
                countdownTimer.Stop();
                SessionManager.Clear();
                //sessionTimer.Stop();

                // Clear last page
                Properties.Settings.Default.LastPage = "";
                Properties.Settings.Default.Save();

                // Redirect to login
                new LoginForm().Show();
                this.Hide();
            }
            else
            {
                var result = MessageBox.Show(
                "Are you sure you want to logout?",
                "Confirm Logout",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    countdownTimer.Stop();
                    // Clear session
                    SessionManager.Clear();
                    //sessionTimer.Stop();

                    // Clear last page
                    Properties.Settings.Default.LastPage = "";
                    Properties.Settings.Default.Save();

                    // Redirect to login
                    new LoginForm().Show();
                    this.Hide();
                }
            }            
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show(
                    "Exit application?",
                    "Confirm Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                Application.Exit();
            }

            base.OnFormClosing(e);
        }
        private void StartSessionTimer()
        {
            sessionTimer = new System.Windows.Forms.Timer { Interval = 60000 }; // 1 minute
            sessionTimer.Tick += (s, e) =>
            {
                if ((DateTime.Now - SessionManager.LastActivity).TotalMinutes > SESSION_TIMEOUT_MINUTES)
                {
                    sessionTimer.Stop();
                    MessageBox.Show("Session expired. Please login again.",
                        "Session Timeout", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    Logout();
                }
            };
            sessionTimer.Start();
        }
        private void CreateSessionTimerLabel()
        {
            lblSessionTimer = new Label
            {
                Text = "",
                AutoSize = true,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.DarkRed,
                Anchor = AnchorStyles.Top | AnchorStyles.Right,
                Location = new Point(this.Width - 230, 10)
            };

            this.Controls.Add(lblSessionTimer);
            lblSessionTimer.BringToFront();
        }
        private void StartCountdown()
        {
            remainingTime = TimeSpan.FromMinutes(SESSION_TIMEOUT_MINUTES);

            countdownTimer = new System.Windows.Forms.Timer();
            countdownTimer.Interval = 1000; // 1 second
            countdownTimer.Tick += CountdownTimer_Tick;
            countdownTimer.Start();
        }

        private void CountdownTimer_Tick(object sender, EventArgs e)
        {
            remainingTime = remainingTime.Subtract(TimeSpan.FromSeconds(1));

            lblSessionTimer.Text = $"Session expires in: {remainingTime:mm\\:ss}";

            if (remainingTime.TotalSeconds <= 0)
            {
                countdownTimer.Stop();

                MessageBox.Show(
                    "Session expired. Please login again.",
                    "Session Timeout",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                IsAutoLogout = true;
                Logout();
            }
            if (remainingTime.TotalMinutes <= 2)
            {
                lblSessionTimer.ForeColor = Color.Red;
            }
            else
            {
                lblSessionTimer.ForeColor = Color.DarkBlue;
            }

        }
        protected override void OnKeyDown(KeyEventArgs e)
        {
            ResetSessionTimer();
            SessionManager.UpdateActivity();
            base.OnKeyDown(e);
        }
        private void ResetSessionTimer()
        {
            remainingTime = TimeSpan.FromMinutes(SESSION_TIMEOUT_MINUTES);
        }
        private void UserActivity(object sender, EventArgs e)
        {
            ResetSessionTimer();
        }
        private void AttachActivityHandlers(Control parent)
        {
            parent.MouseMove += UserActivity;
            parent.MouseClick += UserActivity;
            parent.KeyDown += UserActivity;

            foreach (Control ctrl in parent.Controls)
            {
                AttachActivityHandlers(ctrl);
            }
        }


    }
}
