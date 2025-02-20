﻿

using HotelManagementSystem.database;
using OfficeOpenXml;
using System.Reflection;

namespace HotelManagementSystem
{
    public partial class RoomManagement : Form
    {
        private readonly ApplicationDbContext _context;

        public RoomManagement()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            LoadRooms();
        }
        private void LoadRooms()
        {
            var rooms = _context.Rooms
                .Select(r => new
                {
                    r.RoomID,
                    r.RoomNumber,
                    r.Type,
                    r.Price,
                    Availability = r.Availability ? "Available" : "Occupied" // Display status clearly
                })
                .ToList();

            dataGridView1.DataSource = rooms;
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Room room = new Room
            {
                RoomNumber = textBox1.Text,
                Type = textBox3.Text,
                Price = decimal.Parse(textBox2.Text),
                Availability = true // Always start as available
            };

            _context.Rooms.Add(room);
            _context.SaveChanges();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            LoadRooms(); // Refresh the room list
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["RoomID"].Value);
                var room = _context.Rooms.Find(id);

                if (room != null)
                {
                    room.RoomNumber = textBox1.Text;
                    room.Type = textBox3.Text;
                    room.Price = decimal.Parse(textBox2.Text);
                    _context.SaveChanges();
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    LoadRooms(); // Refresh the room list
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["RoomID"].Value);
                var room = _context.Rooms.Find(id);

                if (room != null)
                {
                    // Check for active reservations
                    bool hasActiveReservations = _context.Reservations.Any(r =>
                        r.RoomID == id && (r.Status == ReservationStatus.Upcoming || r.Status == ReservationStatus.Ongoing));

                    if (hasActiveReservations)
                    {
                        MessageBox.Show("Cannot delete this room as it has an active reservation.");
                        return;
                    }

                    _context.Rooms.Remove(room);
                    _context.SaveChanges();
                    LoadRooms(); // Refresh the room list
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
                    var worksheet = package.Workbook.Worksheets.FirstOrDefault();
                    if (worksheet == null)
                    {
                        MessageBox.Show("No sheet found in the Excel file.");
                        return;
                    }

                    List<Room> rooms = ReadRoomSheet(worksheet);

                    if (rooms.Count > 0)
                    {
                        _context.Rooms.AddRange(rooms);
                        _context.SaveChanges();
                        LoadRooms();
                        MessageBox.Show("Import successful! Rooms saved to the database.");
                    }
                }
            }
        }
        private void ExportRoomsToExcel()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = "Excel Files|*.xlsx",
                FileName = "Rooms.xlsx"
            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Rooms");

                    // Headers
                    worksheet.Cells[1, 1].Value = "RoomID";
                    worksheet.Cells[1, 2].Value = "RoomNumber";
                    worksheet.Cells[1, 3].Value = "Type";
                    worksheet.Cells[1, 4].Value = "Price";
                    worksheet.Cells[1, 5].Value = "Availability";

                    var rooms = _context.Rooms.ToList();
                    int row = 2;
                    foreach (var room in rooms)
                    {
                        worksheet.Cells[row, 1].Value = room.RoomID;
                        worksheet.Cells[row, 2].Value = room.RoomNumber;
                        worksheet.Cells[row, 3].Value = room.Type;
                        worksheet.Cells[row, 4].Value = room.Price;
                        worksheet.Cells[row, 5].Value = room.Availability ? "Available" : "Occupied"; // Convert boolean to text
                        row++;
                    }

                    FileInfo excelFile = new FileInfo(saveFileDialog.FileName);
                    package.SaveAs(excelFile);
                    MessageBox.Show("Rooms exported successfully.");
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            ExportRoomsToExcel();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowDividerDoubleClick(object sender, DataGridViewRowDividerDoubleClickEventArgs e)
        {


        }

        private List<Room> ReadRoomSheet(ExcelWorksheet worksheet)
        {
            List<Room> rooms = new List<Room>();

            int rowCount = worksheet.Dimension.Rows;
            int colCount = worksheet.Dimension.Columns;
            PropertyInfo[] properties = typeof(Room).GetProperties();

            Dictionary<int, PropertyInfo> columnMappings = new Dictionary<int, PropertyInfo>();

            for (int col = 1; col <= colCount; col++)
            {
                string headerValue = worksheet.Cells[1, col].Value?.ToString()?.Trim();
                if (!string.IsNullOrEmpty(headerValue))
                {
                    PropertyInfo property = properties.FirstOrDefault(p => p.Name.Equals(headerValue, StringComparison.OrdinalIgnoreCase));
                    if (property != null && property.Name != "RoomID") // Ignore RoomID during import
                    {
                        columnMappings[col] = property;
                    }
                }
            }

            for (int row = 2; row <= rowCount; row++)
            {
                Room room = new Room(); // Do NOT set RoomID
                foreach (var columnMapping in columnMappings)
                {
                    int colIndex = columnMapping.Key;
                    PropertyInfo prop = columnMapping.Value;
                    object cellValue = worksheet.Cells[row, colIndex].Value;

                    if (cellValue != null)
                    {
                        try
                        {
                            if (prop.Name == "Availability") // Handle Availability conversion
                            {
                                string availabilityText = cellValue.ToString().Trim().ToLower();
                                room.Availability = availabilityText == "available"; // Convert "Available" to true, "Occupied" to false
                            }
                            else
                            {
                                object convertedValue = Convert.ChangeType(cellValue, prop.PropertyType);
                                prop.SetValue(room, convertedValue);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error converting value '{cellValue}' for column '{prop.Name}': {ex.Message}");
                        }
                    }
                }
                rooms.Add(room);
            }

            return rooms;
        }
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            textBox1.Text = dataGridView1.SelectedRows[0].Cells["RoomNumber"].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells["Price"].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells["Type"].Value.ToString();
        }

        private void RoomManagement_Load(object sender, EventArgs e)
        {
        }
    }
}
