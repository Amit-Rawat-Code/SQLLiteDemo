using System.Drawing;
using System.Windows.Forms;

namespace SQLLiteDemo.Forms
{
    public partial class DashboardForm : Form
    {
        public DashboardForm()
        {
            BackColor = Color.White;
            Controls.Add(new Label
            {
                Text = "Dashboard",
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 60,
                TextAlign = ContentAlignment.MiddleCenter
            });
        }
    }
}
