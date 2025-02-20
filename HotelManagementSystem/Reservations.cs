using HotelManagementSystem.database;
using OfficeOpenXml;

using System.Data;


namespace HotelManagementSystem
{
    public partial class Reservations : Form
    {
        private readonly ApplicationDbContext _context;

        public Reservations()
        {
            InitializeComponent();
            _context = new ApplicationDbContext();
            LoadReservations();
            LoadRooms();
            comboBox2.DataSource = Enum.GetValues(typeof(ReservationStatus));

        }
        private void LoadReservations()
        {
            var reservations = _context.Reservations
                .Select(r => new
                {
                    r.ReservationID,
                    r.CustomerName,
                    RoomNumber = r.Room.RoomNumber,
                    r.CheckInDate,
                    r.CheckOutDate,
                    Status = r.Status.ToString()
                }).ToList();

            dataGridView1.DataSource = reservations;
        }

        private void LoadRooms()
        {
            comboBox1.DataSource = _context.Rooms
                .Where(r => r.Availability)
                .Select(r => new { r.RoomID, r.RoomNumber })
                .ToList();

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
                Status = ReservationStatus.Upcoming // Default status
            };

            _context.Reservations.Add(newReservation);

            // Mark the room as occupied
            var room = _context.Rooms.Find(newReservation.RoomID);
            if (room != null)
            {
                room.Availability = false; // Room is now occupied
            }

            _context.SaveChanges();
            MessageBox.Show("Reservation added successfully!");

            // Refresh room list and reservations
            LoadAvailableRooms();
            LoadReservations();
        }
        private void LoadAvailableRooms()
        {
            var availableRooms = _context.Rooms
                .Where(r => r.Availability) // Only fetch available rooms
                .Select(r => new { r.RoomID, DisplayText = $"{r.RoomNumber} - {r.Type}" })
                .ToList();

            comboBox1.DataSource = availableRooms;
            comboBox1.DisplayMember = "DisplayText"; // Show Room Number and Type
            comboBox1.ValueMember = "RoomID"; // Store RoomID
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Excel Files|*.xlsx;*.xls" };
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
                    List<Reservation> reservations = ReadReservationSheet(worksheet);
                    _context.Reservations.AddRange(reservations);
                    _context.SaveChanges();
                    LoadReservations();
                }
            }
        }
        private List<Reservation> ReadReservationSheet(ExcelWorksheet worksheet)
        {
            List<Reservation> reservations = new List<Reservation>();
            int rowCount = worksheet.Dimension.Rows;
            for (int row = 2; row <= rowCount; row++)
            {
                reservations.Add(new Reservation
                {
                    CustomerName = worksheet.Cells[row, 1].Value.ToString(),
                    RoomID = Convert.ToInt32(worksheet.Cells[row, 2].Value),
                    CheckInDate = DateTime.Parse(worksheet.Cells[row, 3].Value.ToString()),
                    CheckOutDate = DateTime.Parse(worksheet.Cells[row, 4].Value.ToString()),
                    Status = (ReservationStatus)Enum.Parse(typeof(ReservationStatus), worksheet.Cells[row, 5].Value.ToString())
                });
            }
            return reservations;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Excel Files|*.xlsx" };
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Reservations");
                    worksheet.Cells[1, 1].Value = "CustomerName";
                    worksheet.Cells[1, 2].Value = "RoomID";
                    worksheet.Cells[1, 3].Value = "CheckInDate";
                    worksheet.Cells[1, 4].Value = "CheckOutDate";
                    worksheet.Cells[1, 5].Value = "Status";

                    var reservations = _context.Reservations.ToList();
                    for (int i = 0; i < reservations.Count; i++)
                    {
                        worksheet.Cells[i + 2, 1].Value = reservations[i].CustomerName;
                        worksheet.Cells[i + 2, 2].Value = reservations[i].RoomID;
                        worksheet.Cells[i + 2, 3].Value = reservations[i].CheckInDate.ToShortDateString();
                        worksheet.Cells[i + 2, 4].Value = reservations[i].CheckOutDate.ToShortDateString();
                        worksheet.Cells[i + 2, 5].Value = reservations[i].Status.ToString();
                    }
                    package.SaveAs(new FileInfo(saveFileDialog.FileName));
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ReservationID"].Value);
                var reservation = _context.Reservations.Find(id);

                if (reservation != null)
                {
                    // Mark the old room as available
                    var oldRoom = _context.Rooms.Find(reservation.RoomID);
                    if (oldRoom != null)
                    {
                        oldRoom.Availability = true;
                    }

                    // Update reservation details
                    reservation.CustomerName = textBox1.Text;
                    reservation.RoomID = (int)comboBox1.SelectedValue;
                    reservation.CheckInDate = dateTimePicker1.Value;
                    reservation.CheckOutDate = dateTimePicker2.Value;
                    reservation.Status = (ReservationStatus)comboBox2.SelectedItem;

                    // Mark the new room as unavailable
                    var newRoom = _context.Rooms.Find(reservation.RoomID);
                    if (newRoom != null)
                    {
                        newRoom.Availability = false;
                    }

                    _context.SaveChanges();
                    LoadReservations(); // Refresh the reservation list
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ReservationID"].Value);
                var reservation = _context.Reservations.Find(id);

                if (reservation != null && reservation.Status == ReservationStatus.Upcoming)
                {
                    // Mark the room as available
                    var room = _context.Rooms.Find(reservation.RoomID);
                    if (room != null)
                    {
                        room.Availability = true;
                    }

                    _context.Reservations.Remove(reservation);
                    _context.SaveChanges();
                    LoadReservations(); // Refresh the reservation list
                }
                else
                {
                    MessageBox.Show("Only upcoming reservations can be deleted.");
                }
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
            LoadAvailableRooms();

        }
    }
}
