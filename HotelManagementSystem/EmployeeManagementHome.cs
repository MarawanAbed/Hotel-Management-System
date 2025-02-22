using HotelManagementSystem.database;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class EmployeeManagementHome : Form
    {
        private readonly ApplicationDbContext _context;

        public EmployeeManagementHome()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            LoadEmployees();

        }
        private void LoadEmployees()
        {
            dataGridView1.DataSource = _context.Employees.ToList();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee
            {
                Name = textBox1.Text,
                Position = textBox2.Text,
                Salary = decimal.Parse(textBox3.Text)
            };

            _context.Employees.Add(employee);
            _context.SaveChanges();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            LoadEmployees();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value);
                var employee = _context.Employees.Find(id);
                if (employee != null)
                {
                    employee.Name = textBox1.Text;
                    employee.Position = textBox2.Text;
                    employee.Salary = decimal.Parse(textBox3.Text);

                    _context.SaveChanges();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    LoadEmployees();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value);
                var employee = _context.Employees.Find(id);
                if (employee != null)
                {
                    _context.Employees.Remove(employee);
                    _context.SaveChanges();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    LoadEmployees();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    ExcelWorksheet worksheet = FindEmployeeSheet(package);

                    if (worksheet == null)
                    {
                        MessageBox.Show("No valid Employee sheet found!");
                        return;
                    }

                    List<Employee> employees = ReadEmployeeSheet(worksheet);

                    if (employees.Count > 0)
                    {
                        _context.Employees.AddRange(employees);
                        _context.SaveChanges();
                        LoadEmployees();
                        MessageBox.Show("Import successful! Employees saved to the database.");
                    }
                }
            }
        }



        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = "Employees.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (ExcelPackage package = new ExcelPackage())
                    {
                        ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Employees");

                        worksheet.Cells[1, 1].Value = "EmployeeID";
                        worksheet.Cells[1, 2].Value = "Name";
                        worksheet.Cells[1, 3].Value = "Position";
                        worksheet.Cells[1, 4].Value = "Salary";

                        var employees = _context.Employees.ToList();

                        int row = 2;
                        foreach (var emp in employees)
                        {
                            worksheet.Cells[row, 1].Value = emp.EmployeeID;
                            worksheet.Cells[row, 2].Value = emp.Name;
                            worksheet.Cells[row, 3].Value = emp.Position;
                            worksheet.Cells[row, 4].Value = emp.Salary;
                            row++;
                        }

                        FileInfo file = new FileInfo(saveFileDialog.FileName);
                        package.SaveAs(file);

                        MessageBox.Show("Export successful! File saved.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error exporting data: {ex.Message}");
                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {



        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            textBox1.Text = dataGridView1.SelectedRows[0].Cells["Name"].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["Position"].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells["Salary"].Value.ToString();
        }

        private List<Employee> ReadEmployeeSheet(ExcelWorksheet worksheet)
        {
            List<Employee> employees = new List<Employee>();

            int rowCount = worksheet.Dimension.Rows;
            int colCount = worksheet.Dimension.Columns;
            PropertyInfo[] properties = typeof(Employee).GetProperties();

            Dictionary<int, PropertyInfo> columnMappings = new Dictionary<int, PropertyInfo>();

            for (int col = 1; col <= colCount; col++)
            {
                string headerValue = worksheet.Cells[1, col].Value?.ToString()?.Trim();
                if (!string.IsNullOrEmpty(headerValue))
                {
                    PropertyInfo property = properties.FirstOrDefault(p => p.Name.Equals(headerValue, StringComparison.OrdinalIgnoreCase));
                    if (property != null && property.Name != "EmployeeID")
                    {
                        columnMappings[col] = property;
                    }
                }
            }

            for (int row = 2; row <= rowCount; row++)
            {
                Employee emp = new Employee();
                foreach (var columnMapping in columnMappings)
                {
                    int colIndex = columnMapping.Key;
                    PropertyInfo prop = columnMapping.Value;
                    object cellValue = worksheet.Cells[row, colIndex].Value;

                    if (cellValue != null)
                    {
                        try
                        {
                            object convertedValue = Convert.ChangeType(cellValue, prop.PropertyType);
                            prop.SetValue(emp, convertedValue);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error converting value '{cellValue}' for column '{prop.Name}': {ex.Message}");
                        }
                    }
                }
                employees.Add(emp);
            }

            return employees;
        }
        private ExcelWorksheet FindEmployeeSheet(ExcelPackage package)
        {
            foreach (var worksheet in package.Workbook.Worksheets)
            {
                var headerCells = new List<string>();
                int colCount = worksheet.Dimension?.Columns ?? 0;

                for (int col = 1; col <= colCount; col++)
                {
                    string header = worksheet.Cells[1, col].Value?.ToString()?.Trim();
                    if (!string.IsNullOrEmpty(header))
                    {
                        headerCells.Add(header.ToLower());
                    }
                }

                if (headerCells.Contains("name") && headerCells.Contains("position") && headerCells.Contains("salary"))
                {
                    return worksheet; 
                }
            }
            return null;
        }

    }
}
