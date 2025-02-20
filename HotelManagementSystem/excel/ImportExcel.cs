using HotelManagementSystem.database;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HotelManagementSystem.excel
{
    public class Excel
    {
        public void ImportFromExcel<T>(DataGridView dataGridView) where T : class, new()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Excel Files|*.xlsx;*.xls"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                var filePath = openFileDialog.FileName;
                List<T> records = new List<T>();

                using (var package = new ExcelPackage(new FileInfo(filePath)))
                {
                    var worksheet = package.Workbook.Worksheets[0];
                    int rowCount = worksheet.Dimension.Rows;
                    int colCount = worksheet.Dimension.Columns;

                    // Get class properties dynamically
                    PropertyInfo[] properties = typeof(T).GetProperties();

                    // Dictionary to map Excel column index to class properties
                    Dictionary<int, PropertyInfo> columnMappings = new Dictionary<int, PropertyInfo>();

                    // Match column headers with properties
                    for (int col = 1; col <= colCount; col++)
                    {
                        var headerValue = worksheet.Cells[1, col].Value?.ToString()?.Trim(); // Null-safe
                        if (!string.IsNullOrEmpty(headerValue))
                        {
                            var property = properties.FirstOrDefault(p => p.Name.Equals(headerValue, StringComparison.OrdinalIgnoreCase));
                            if (property != null && property.Name != "EmployeeID") // Ignore auto-generated ID
                            {
                                columnMappings[col] = property;
                            }
                        }
                    }

                    // Process each row
                    for (int row = 2; row <= rowCount; row++) // Skip header row
                    {
                        T obj = new T();
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
                                    prop.SetValue(obj, convertedValue);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error converting value '{cellValue}' for column '{prop.Name}': {ex.Message}");
                                }
                            }
                        }
                        records.Add(obj);
                    }
                }

                // Save to Database
                using (var dbContext = new ApplicationDbContext())
                {
                    dbContext.Set<T>().AddRange(records);
                    dbContext.SaveChanges();
                }

                // Refresh DataGridView
                LoadDataToGrid<T>(dataGridView);

                MessageBox.Show("Import successful! Data saved to the database.");
            }
        }
        public void LoadDataToGrid<T>(DataGridView dataGridView) where T : class
        {
            using (var dbContext = new ApplicationDbContext())
            {
                dataGridView.DataSource = dbContext.Set<T>().ToList();
            }
        }


        public static void ExportToExcel<T>(List<T> data)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = typeof(T).Name + ".xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add(typeof(T).Name);
                    PropertyInfo[] properties = typeof(T).GetProperties();

                    // Write headers
                    for (int i = 0; i < properties.Length; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = properties[i].Name;
                    }

                    // Write data
                    for (int row = 0; row < data.Count; row++)
                    {
                        for (int col = 0; col < properties.Length; col++)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = properties[col].GetValue(data[row]);
                        }
                    }

                    File.WriteAllBytes(saveFileDialog.FileName, package.GetAsByteArray());
                    MessageBox.Show("Export successful!");
                }
            }
        }
    }
}
