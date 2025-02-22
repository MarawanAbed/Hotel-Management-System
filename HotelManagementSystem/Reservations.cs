using BL.Services.Abstraction;
using BL.Services.Implementation;
using Dal.Entities;
using Dal.Repo.Implementation;
using HotelManagementSystem.database;
using OfficeOpenXml;

using System.Data;


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
            //OpenFileDialog openFileDialog = new OpenFileDialog { Filter = "Excel Files|*.xlsx;*.xls" };
            //if (openFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    string filePath = openFileDialog.FileName;
            //    using (var package = new ExcelPackage(new FileInfo(filePath)))
            //    {
            //        var worksheet = package.Workbook.Worksheets.FirstOrDefault();
            //        if (worksheet == null)
            //        {
            //            MessageBox.Show("No sheet found in the Excel file.");
            //            return;
            //        }
            //        List<Reservation> reservations = ReadReservationSheet(worksheet);
            //        _context.Reservations.AddRange(reservations);
            //        _context.SaveChanges();
            //        LoadReservations();
            //    }
            //}
        }
        //private List<Reservation> ReadReservationSheet(ExcelWorksheet worksheet)
        //{
        //    List<Reservation> reservations = new List<Reservation>();
        //    int rowCount = worksheet.Dimension.Rows;
        //    for (int row = 2; row <= rowCount; row++)
        //    {
        //        reservations.Add(new Reservation
        //        {
        //            CustomerName = worksheet.Cells[row, 1].Value.ToString(),
        //            RoomID = Convert.ToInt32(worksheet.Cells[row, 2].Value),
        //            CheckInDate = DateTime.Parse(worksheet.Cells[row, 3].Value.ToString()),
        //            CheckOutDate = DateTime.Parse(worksheet.Cells[row, 4].Value.ToString()),
        //            Status = (ReservationStatus)Enum.Parse(typeof(ReservationStatus), worksheet.Cells[row, 5].Value.ToString())
        //        });
        //    }
        //    return reservations;
        //}
        private void button6_Click(object sender, EventArgs e)
        {
            //SaveFileDialog saveFileDialog = new SaveFileDialog { Filter = "Excel Files|*.xlsx" };
            //if (saveFileDialog.ShowDialog() == DialogResult.OK)
            //{
            //    using (var package = new ExcelPackage())
            //    {
            //        var worksheet = package.Workbook.Worksheets.Add("Reservations");
            //        worksheet.Cells[1, 1].Value = "CustomerName";
            //        worksheet.Cells[1, 2].Value = "RoomID";
            //        worksheet.Cells[1, 3].Value = "CheckInDate";
            //        worksheet.Cells[1, 4].Value = "CheckOutDate";
            //        worksheet.Cells[1, 5].Value = "Status";

            //        var reservations = _context.Reservations.ToList();
            //        for (int i = 0; i < reservations.Count; i++)
            //        {
            //            worksheet.Cells[i + 2, 1].Value = reservations[i].CustomerName;
            //            worksheet.Cells[i + 2, 2].Value = reservations[i].RoomID;
            //            worksheet.Cells[i + 2, 3].Value = reservations[i].CheckInDate.ToShortDateString();
            //            worksheet.Cells[i + 2, 4].Value = reservations[i].CheckOutDate.ToShortDateString();
            //            worksheet.Cells[i + 2, 5].Value = reservations[i].Status.ToString();
            //        }
            //        package.SaveAs(new FileInfo(saveFileDialog.FileName));
            //    }
            //}
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
