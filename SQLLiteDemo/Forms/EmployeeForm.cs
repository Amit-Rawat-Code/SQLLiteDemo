using SQLLiteDemo.Common;
using SQLLiteDemo.DAL;
using SQLLiteDemo.Models;

namespace SQLLiteDemo
{
    public partial class EmployeeForm : Form
    {
        EmployeeDAL emp = new EmployeeDAL();
        public EmployeeForm()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.EmpCode = txtEmpCode.Text;
            employee.Name = txtName.Text;
            employee.Salary = Convert.ToDecimal(txtSalary.Text);
            employee.DOJ = Convert.ToDateTime(dtDoj.Text);
            bool isSuccess= emp.InsertEmployee(employee);
            if (isSuccess)
            {
                //MessageBox.Show("Data saved successfully..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ToastHelper.ShowSuccess(this, "Data saved successfully..");
            }
            else
            {
                //MessageBox.Show("Failed to save...","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                ToastHelper.ShowError(this, "Failed to save...");
            }
            LoadGrid();
        }
        private void LoadGrid()
        {
            ClearForm();
            dgvEmployee.DataSource = emp.GetEmployees();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupGrid();
            LoadGrid();
        }
        private void ClearForm()
        {
            txtEmpCode.Clear();
            txtName.Clear();
            txtSalary.Clear();

            dtDoj.Value = DateTime.Today;
            txtEmpCode.Text = "0";

            txtEmpCode.Focus();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string EmpCode = txtSearch.Text;
            SearhEmployee(EmpCode);
        }
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Id=_selectedEmployeeId;
            employee.Name = txtName.Text;
            employee.Salary = Convert.ToDecimal(txtSalary.Text);
            employee.EmpCode=txtEmpCode.Text;
            employee.DOJ=Convert.ToDateTime(dtDoj.Value);
            bool isSuccess = emp.UpdateEmployee(employee);
            if (isSuccess)
            {
                //MessageBox.Show("Updated successfully..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ToastHelper.ShowSuccess(this, "Updated successfully..");
            }
            else
            {
                //MessageBox.Show("Failed to update...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ToastHelper.ShowError(this, "Failed to update...");
            }
            LoadGrid();
            ClearForm();
        }
        private void SetupGrid()
        {
            dgvEmployee.AutoGenerateColumns = false;
            dgvEmployee.Columns.Clear();

            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Id",
                DataPropertyName = "Id",
                Visible = false
            });

            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EmpCode",
                HeaderText = "Emp Code",
                DataPropertyName = "EmpCode"
            });

            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Name",
                HeaderText = "Name",
                DataPropertyName = "Name"
            });

            dgvEmployee.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Salary",
                HeaderText = "Salary",
                DataPropertyName = "Salary"
            });

            // EDIT BUTTON
            var editBtn = new DataGridViewButtonColumn
            {
                Name = "Edit",
                HeaderText = "Edit",
                Text = "Edit",
                UseColumnTextForButtonValue = true
            };
            dgvEmployee.Columns.Add(editBtn);

            // DELETE BUTTON
            var deleteBtn = new DataGridViewButtonColumn
            {
                Name = "Delete",
                HeaderText = "Delete",
                Text = "Delete",
                UseColumnTextForButtonValue = true
            };
            dgvEmployee.Columns.Add(deleteBtn);
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var grid = dgvEmployee;
            if (grid.Columns[e.ColumnIndex].Name != "Edit" && grid.Columns[e.ColumnIndex].Name != "Delete")
                return;
            int id = Convert.ToInt32(grid.Rows[e.RowIndex].Cells["Id"].Value);

            if (grid.Columns[e.ColumnIndex].Name == "Edit")
            {
                LoadEmployeeForEdit(id);
            }
            else if (grid.Columns[e.ColumnIndex].Name == "Delete")
            {
                DeleteEmployee(id);
            }
        }
        private int _selectedEmployeeId = 0;

        private void LoadEmployeeForEdit(int id)
        {
            var employee = emp.GetEmployeeById(id);
            if (employee is not null)
            {
                _selectedEmployeeId = employee.Id;

                txtEmpCode.Text = employee.EmpCode;
                txtName.Text = employee.Name;
                txtSalary.Text = employee.Salary.ToString();
                dtDoj.Value = DateTime.Parse(employee.DOJ.ToString());
            }
            else
            {
                //MessageBox.Show("Employee not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ToastHelper.ShowWarning(this, "Employee not found");
            }            
        }
        private void SearhEmployee(string EmpCode)
        {
            var employee = emp.GetEmployeeByEmpCode(EmpCode);
            if (employee is not null)
            {
                _selectedEmployeeId = employee.Id;

                txtEmpCode.Text = employee.EmpCode;
                txtName.Text = employee.Name;
                txtSalary.Text = employee.Salary.ToString();
                dtDoj.Value = DateTime.Parse(employee.DOJ.ToString());
            }
            else
            {
                //MessageBox.Show("Employee not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ToastHelper.ShowWarning(this, "Employee not found");
            }
        }
        private void DeleteEmployee(int id)
        {
            if (MessageBox.Show(
                "Are you sure you want to delete this employee?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                bool isSuccess =emp.DeleteEmployee(id);
                if (isSuccess)
                {
                    //MessageBox.Show("Deleted successfully..", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ToastHelper.ShowSuccess(this, "Deleted successfully..");
                }
                else
                {
                    //MessageBox.Show("Failed to delete...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ToastHelper.ShowError(this, "Failed to delete...");
                }

                LoadGrid();
                ClearForm();
            }
        }
    }
}
