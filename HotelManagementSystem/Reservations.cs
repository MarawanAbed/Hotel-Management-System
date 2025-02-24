using BL.Services.Abstraction;
using BL.Services.Implementation;
using Dal.Entities;
using Dal.Repo.Implementation;
using HotelManagementSystem.database;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

using System.Data;
using System.Windows.Forms;


namespace HotelManagementSystem
{
    public partial class Reservations : Form
    {
        private readonly IReservationServices _reservationService;

        public Reservations()
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            var reservationRepository = new ReservationRepo(context);
            _reservationService = new ReservationServices(reservationRepository);
            LoadReservations();
            LoadRooms();
            comboBox2.DataSource = Enum.GetValues(typeof(ReservationStatus));

        }
        private void LoadReservations()
        {
            dataGridView1.DataSource = _reservationService.GetAllReservations();
        }
        //load rooms
        private void LoadRooms()
        {
            comboBox1.DataSource = _reservationService.GetAvailableRooms();
            comboBox1.DisplayMember = "RoomNumber";
            comboBox1.ValueMember = "RoomID";
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Please select a valid room.");
                return;
            }

            Reservation newReservation = new Reservation
            {
                CustomerName = textBox1.Text,
                RoomID = Convert.ToInt32(comboBox1.SelectedValue),
                CheckInDate = dateTimePicker1.Value,
                CheckOutDate = dateTimePicker2.Value,
                Status = ReservationStatus.Upcoming
            };
            _reservationService.AddReservation(newReservation);

            MessageBox.Show("Reservation added successfully!");

            LoadRooms();
            LoadReservations();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                List<Reservation> reservation = readExcel<Reservation>(filePath);
                dataGridView1.DataSource = reservation;
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[2].Width = 300;
                SaveReservationsToDatabase(reservation);
                LoadDataFromDatabase();
            }



        }
        private void SaveReservationsToDatabase(List<Reservation> reservation)
        {
            try
            {
                foreach (var item in reservation)
                {
                    var existingReservation = _reservationService.GetReservationById(item.ReservationID);
                    if (existingReservation == null)
                    {
                        // Insert new record
                        _reservationService.AddReservation(new Reservation
                        {
                            CustomerName = item.CustomerName,
                            RoomID = item.RoomID,
                            CheckInDate = item.CheckInDate,
                            CheckOutDate = item.CheckOutDate,
                            Status = item.Status
                        });
                        
                    }
                    else
                    {
                        existingReservation.CustomerName = item.CustomerName;
                        existingReservation.RoomID = item.RoomID;
                        existingReservation.CheckInDate = item.CheckInDate;
                        existingReservation.CheckOutDate = item.CheckOutDate;
                        existingReservation.Status = item.Status;
                        
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

            try
            {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Report");
                    var properties = typeof(T).GetProperties();

                    for (int i = 0; i < properties.Length; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = properties[i].Name;
                        worksheet.Cells[1, i + 1].Style.Font.Bold = true; 
                    }

                    for (int row = 0; row < data.Count; row++)
                    {
                        for (int col = 0; col < properties.Length; col++)
                        {
                            worksheet.Cells[row + 2, col + 1].Value = properties[col].GetValue(data[row]);
                        }
                    }

                    worksheet.Cells.AutoFitColumns(); 

                    package.SaveAs(new FileInfo(path));
                    MessageBox.Show("Export successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error exporting to Excel: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<T> readExcel<T>(string path) where T : new()
        {
            List<T> dataList = new List<T>();

            using (var package = new ExcelPackage(new FileInfo(path)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                var properties = typeof(T).GetProperties();

                for (int row = 2; row <= worksheet.Dimension.Rows; row++) 
                {
                    T item = new T();
                    for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                    {
                        string columnName = worksheet.Cells[1, col].Text;
                        var property = properties.FirstOrDefault(p => p.Name.Equals(columnName, StringComparison.OrdinalIgnoreCase));

                        if (property != null)
                        {
                            var cell = worksheet.Cells[row, col];

                            if (property.PropertyType == typeof(DateTime) || property.PropertyType == typeof(DateTime?))
                            {
                                if (cell.Value != null && double.TryParse(cell.Value.ToString(), out double dateSerial))
                                {
                                    property.SetValue(item, DateTime.FromOADate(dateSerial));
                                }
                                else if (DateTime.TryParse(cell.Text, out DateTime parsedDate))
                                {
                                    property.SetValue(item, parsedDate);
                                }
                            }
                            else if (property.PropertyType.IsEnum) 
                            {
                                try
                                {
                                    object enumValue = Enum.Parse(property.PropertyType, cell.Text, true);
                                    property.SetValue(item, enumValue);
                                }
                                catch
                                {
                                    MessageBox.Show($"Invalid enum value: {cell.Text} for {property.Name}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else if (property.PropertyType == typeof(Room)) 
                            {
                                int roomId;
                                if (int.TryParse(cell.Text, out roomId))
                                {
                                   
                                    var room = _reservationService.GetRoomById(roomId);
                                    if (room != null)
                                    {
                                        property.SetValue(item, room);
                                    }
                                    else
                                    {
                                        MessageBox.Show($"Room with ID {roomId} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                            else
                            {
                                object convertedValue = Convert.ChangeType(cell.Text, Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType);
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
            var reservations = _reservationService.GetAllReservations();
            dataGridView1.DataSource = reservations; 
        }

      
        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                var data = _reservationService.GetAll();
                writeExcel(data, filePath);
            }
         
         

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ReservationID"].Value);
                var resrevations=new Reservation
                {
                    ReservationID = id,
                    CustomerName = textBox1.Text,
                    RoomID = Convert.ToInt32(comboBox1.SelectedValue),
                    CheckInDate = dateTimePicker1.Value,
                    CheckOutDate = dateTimePicker2.Value,
                    Status = (ReservationStatus)comboBox2.SelectedItem
                };

                _reservationService.UpdateReservation(resrevations);
                LoadReservations();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ReservationID"].Value);
                _reservationService.DeleteReservation(id);
                LoadReservations();
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Reservations_Load(object sender, EventArgs e)
        {
            LoadRooms();
        }
    }
}
