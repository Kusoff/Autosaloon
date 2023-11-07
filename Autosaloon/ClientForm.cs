using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Autosaloon
{
   

    public partial class ClientForm : Form
    {
        private User user;
        private SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.АвтопродажиConnectionString);

        public ClientForm(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqlConnection.Open();
            Car selectedCar = (Car)comboBox1.SelectedItem;

            SqlCommand command = new SqlCommand($"INSERT Заявки (id_клиента, id_автомобиля, дата_составления)" +
                $"VALUES ({user.id_клиента}, {selectedCar.id_автомобиля}," +
                $"'{DateTime.Now.Day}.{DateTime.Now.Month}.{DateTime.Now.Year}')", sqlConnection);

            if (command.ExecuteNonQuery() > 0)
            {
                MessageBox.Show("Заявка успешно отправлена!");
            }
            else
            {
                MessageBox.Show("Заявка не отпралена!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            sqlConnection.Close();

        }

        private void ClientForm_Load(object sender, EventArgs e)
        {
            List<Car> cars = new List<Car>();
            sqlConnection.Open();
            SqlCommand command = new SqlCommand("select * from Автомобиль", sqlConnection);

            using (SqlDataReader reader = command.ExecuteReader())
                while (reader.Read())
                    cars.Add(new Car(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetInt32(3)));

            sqlConnection.Close();

            comboBox1.DataSource = cars;
            comboBox1.DisplayMember = "Марка";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
