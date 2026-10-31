using System.Drawing;
using System.Windows.Forms;

namespace SQLLiteDemo.Forms
{
    public partial class PayrollForm : Form
    {
        public PayrollForm()
        {
            Controls.Add(new Label
            {
                Text = "Payroll Module",
                Font = new Font("Segoe UI", 18),
                Dock = DockStyle.Top,
                Height = 50,
                TextAlign = ContentAlignment.MiddleCenter
            });
        }
    }
}
