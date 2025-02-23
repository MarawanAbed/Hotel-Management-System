

using BL.Services.Abstraction;
using BL.Services.Implementation;
using Dal.Entities;
using Dal.Repo.Implementation;
using HotelManagementSystem.database;
using OfficeOpenXml;
using System.Reflection;

namespace HotelManagementSystem
{
    public partial class RoomManagement : Form
    {
        private readonly IRoomServices _services;


        public RoomManagement()
        {
            InitializeComponent();
            var context = new ApplicationDbContext();
            var userRepository = new RoomRepo(context);
            _services = new RoomServices(userRepository);

            LoadRooms();
        }
        private void LoadRooms()
        {
            dataGridView1.DataSource = _services.GetAllRooms();
        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please fill all the fields", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Room room = new Room
            {
                RoomNumber = textBox1.Text,
                Type = textBox3.Text,
                Price = decimal.Parse(textBox2.Text),
                Availability = true 
            };
            _services.AddRoom(room);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            LoadRooms(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["RoomID"].Value);

                Room room = new Room
                {
                    RoomID = id,
                    RoomNumber = textBox1.Text,
                    Type = textBox3.Text,
                    Price = decimal.Parse(textBox2.Text),
                    Availability = true
                };
                _services.UpdateRoom(room);
                LoadRooms();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["RoomID"].Value);

                _services.DeleteRoom(id);
                LoadRooms();
                }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                List<Room> room = readExcel<Room>(filePath);
                dataGridView1.DataSource = room;
                dataGridView1.Columns[0].Width = 100;
                dataGridView1.Columns[1].Width = 300;
                dataGridView1.Columns[2].Width = 300;
                SaveRoomsToDatabase(room);
                LoadDataFromDatabase();
            }



        }
        private void SaveRoomsToDatabase(List<Room> room)
        {
            try
            {
                foreach (var item in room)
                {
                    var existingRoom = _services.GetRoomById(item.RoomID);
                    if (existingRoom == null)
                    {
                        // Insert new record
                        _services.AddRoom(new Room
                        {
                            RoomNumber = item.RoomNumber,
                            Type = item.Type,
                            Price = item.Price,
                            Availability = item.Availability


                        });

                    }
                    else
                    {
                        existingRoom.RoomNumber = item.RoomNumber;
                        existingRoom.Type = item.Type;
                        existingRoom.Price = item.Price;
                        existingRoom.Availability = item.Availability;
                       

                        

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

                for (int row = 2; row <= worksheet.Dimension.Rows; row++)
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
            var rooms =_services.GetAllRooms();
            dataGridView1.DataSource = rooms;
        }
           
        private void button6_Click(object sender, EventArgs e)
        {
            //ExportRoomsToExcel();
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel Files|*.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                var data = _services.GetAll();
                writeExcel(data, filePath);
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowDividerDoubleClick(object sender, DataGridViewRowDividerDoubleClickEventArgs e)
        {


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

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
