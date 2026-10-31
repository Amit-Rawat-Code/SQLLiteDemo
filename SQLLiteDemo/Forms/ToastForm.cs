using System;
using System.Drawing;
using System.Windows.Forms;

namespace SQLLiteDemo.Forms
{
    public enum ToastType
    {
        Success,
        Error,
        Warning,
        Info
    }

    public partial class ToastForm : Form
    {
        private Label lblMessage;
        private PictureBox picIcon;
        private Button btnOk;
        private System.Windows.Forms.Timer autoCloseTimer;

        public ToastForm(Form parent, string message, ToastType type, int autoCloseSeconds = 10)
        {
            Owner = parent;
            StartPosition = FormStartPosition.Manual;

            InitializeUI();
            SetMessage(message, type);
            StartAutoClose(autoCloseSeconds);
        }

        private void InitializeUI()
        {
            // FORM
            FormBorderStyle = FormBorderStyle.None;
            ShowInTaskbar = false;
            BackColor = Color.White;
            ClientSize = new Size(320, 190);
            TopMost = true;

            // SHADOW / BORDER
            Padding = new Padding(1);
            BackColor = Color.Gainsboro;

            var container = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };
            Controls.Add(container);

            // ICON
            picIcon = new PictureBox
            {
                Size = new Size(48, 48),
                Location = new Point((Width - 48) / 2, 20),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            // MESSAGE
            lblMessage = new Label
            {
                AutoSize = false,
                Width = Width - 40,
                Height = 50,
                Location = new Point(20, 80),
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Segoe UI", 10.5f, FontStyle.Bold)
            };

            // OK BUTTON
            btnOk = new Button
            {
                Text = "OK",
                Size = new Size(90, 32),
                Location = new Point((Width - 90) / 2, 140)
            };
            btnOk.Click += (s, e) => Close();

            container.Controls.Add(picIcon);
            container.Controls.Add(lblMessage);
            container.Controls.Add(btnOk);
        }

        private void SetMessage(string message, ToastType type)
        {
            lblMessage.Text = message;

            switch (type)
            {
                case ToastType.Success:
                    picIcon.Image = Properties.Resources.tick;
                    break;

                case ToastType.Error:
                    picIcon.Image = Properties.Resources.error;
                    break;
                case ToastType.Warning:
                    picIcon.Image = Properties.Resources.warning;
                    break;
                case ToastType.Info:
                    picIcon.Image = Properties.Resources.info;
                    break;
            }
        }

        private void StartAutoClose(int seconds)
        {
            autoCloseTimer = new System.Windows.Forms.Timer
            {
                Interval = seconds * 1000
            };

            autoCloseTimer.Tick += (s, e) =>
            {
                autoCloseTimer.Stop();
                Close();
            };

            autoCloseTimer.Start();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (Owner != null)
            {
                Left = Owner.Left + (Owner.Width - Width) / 2;
                Top=Owner.Top + (Owner.Height - Height) / 2;
            }
            else
            {
                CenterToParent();
            }
        }
    }
}
