using BL.Services.Abstraction;
using BL.Services.Implementation;
using Dal.Entities;
using Dal.Repo.Abstraction;
using Dal.Repo.Implementation;
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

        private readonly IEmpolyeeServices _empolyeeServices;
        public EmployeeManagementHome()
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            var empolyeeRepo = new EmpolyeeRepo(context);
            _empolyeeServices = new EmpolyeeServices(empolyeeRepo);
            LoadEmployees();

        }
        private void LoadEmployees()
        {
            dataGridView1.DataSource = _empolyeeServices.GetAllEmpolyees();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
                return;
            }

            Employee employee = new Employee
            {
                Name = textBox1.Text,
                Position = textBox2.Text,
                Salary = decimal.Parse(textBox3.Text)
            };

            _empolyeeServices.AddEmployee(employee);
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
                Employee employee = new Employee
                {
                    EmployeeID = id,
                    Name = textBox1.Text,
                    Position = textBox2.Text,
                    Salary = decimal.Parse(textBox3.Text)
                };
                _empolyeeServices.UpdateEmployee(employee);

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    LoadEmployees();
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["EmployeeID"].Value);

                _empolyeeServices.DeleteEmployee(id);
                textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    LoadEmployees();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                List<Employee> employee = readExcel<Employee>(filePath);
                dataGridView1.DataSource = employee;
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[2].Width = 300;
                SaveRoomsToDatabase(employee);
                LoadDataFromDatabase();
            }



        }
        private void SaveRoomsToDatabase(List<Employee> employee)
        {
            try
            {
                foreach (var item in employee)
                {
                    var existingEmployee = _empolyeeServices.GetEmployeeById(item.EmployeeID);
                    if (existingEmployee == null)
                    {
                        // Insert new record
                        _empolyeeServices.AddEmployee(new Employee
                        {
                            Name = item.Name,
                            Position = item.Position,
                            Salary = item.Salary



                        });

                    }
                    else
                    {
                        existingEmployee.Name = item.Name;
                        existingEmployee.Position = item.Position;
                        existingEmployee.Salary = item.Salary;





                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void writeExcel<T>(List<T> data, string path)
        {
            if (data == null || data.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Report");
                var properties = typeof(T).GetProperties(); // Reflection: Get properties dynamically

                for (int i = 0; i < properties.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = properties[i].Name;
                }

                for (int row = 0; row < data.Count; row++)
                {
                    for (int col = 0; col < properties.Length; col++)
                    {
                        worksheet.Cells[row + 2, col + 1].Value = properties[col].GetValue(data[row]); // Reflection: Get property values dynamically
                    }
                }

                package.SaveAs(new FileInfo(path));
            }
        }
        private List<T> readExcel<T>(string path) where T : new()
        {
            List<T> dataList = new List<T>();

            using (var package = new ExcelPackage(new FileInfo(path)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var properties = typeof(T).GetProperties();

                for (int row = 2; row <= worksheet.Dimension.Rows; row++) // Skip header row
                {
                    T item = new T();
                    for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                    {
                        string columnName = worksheet.Cells[1, col].Text;
                        var property = properties.FirstOrDefault(p => p.Name.Equals(columnName, StringComparison.OrdinalIgnoreCase));

                        if (property != null)
                        {
                            var cellValue = worksheet.Cells[row, col].Text;
                            if (!string.IsNullOrEmpty(cellValue))
                            {
                                object convertedValue = Convert.ChangeType(cellValue, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
                                property.SetValue(item, convertedValue);
                            }
                        }
                    }
                    dataList.Add(item);
                }

            }
            return dataList;
        }
        private void LoadDataFromDatabase()
        {
            var employees = _empolyeeServices.GetAllEmpolyees();
            dataGridView1.DataSource = employees;
        }
            



        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                var data = _empolyeeServices.GetAllEmpolyees();
                writeExcel(data, filePath);
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

        

    }
}
