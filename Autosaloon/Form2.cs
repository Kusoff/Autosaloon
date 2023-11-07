using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Autosaloon
{
    public partial class Form2 : Form
    {
        List<User> users = new List<User>();
        List<Manager> admins = new List<Manager>(); //test

        SqlCommand sqlCommand;
        SqlConnection sqlConnection;
        private User user;

        public Form2()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        public void SelectUsers()
        {
            //подключение к БД Автопродажи 
            sqlConnection = new SqlConnection(Properties.Settings.Default.АвтопродажиConnectionString);
            sqlConnection.Open();
            sqlCommand = new SqlCommand("Select * from Клиенты", sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // если есть строки
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    users.Add(new User(Convert.ToInt32(sqlDataReader[0]), Convert.ToString(sqlDataReader[1]), Convert.ToDateTime(sqlDataReader[2]), Convert.ToString(sqlDataReader[3]), Convert.ToString(sqlDataReader[4])));

                }
            }
            sqlDataReader.Close();
        }
        // тест 
        public void SelectAdmins()
        {
            //подключение к БД Автопродажи
            sqlConnection = new SqlConnection(Properties.Settings.Default.АвтопродажиConnectionString);
            sqlConnection.Open();
            sqlCommand = new SqlCommand("Select * from Сотрудники", sqlConnection);
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            // если есть строки 
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    admins.Add(new Manager(Convert.ToString(sqlDataReader[3]), Convert.ToString(sqlDataReader[4])));

                }
            }
            sqlDataReader.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) &&
            !string.IsNullOrWhiteSpace(textBox1.Text) &&
            !string.IsNullOrEmpty(textBox2.Text) &&
            !string.IsNullOrWhiteSpace(textBox2.Text))
            {
                string login = textBox1.Text;
                string password = textBox2.Text;

                int tempForUsers = 0;
                int tempForAdmins = 0;

                for (int i = 0; i < users.Count; i++)
                {
                    if (users[i].логин == login && users[i].пароль == password)
                    {

                        Hide();
                        ClientForm userform = new ClientForm(users[i]);
                        userform.ShowDialog();
                        Close();
                        return;
                    }
                    else
                        tempForUsers++;
                }
                if (tempForUsers == users.Count)
                {
                    //test
                    for (int i = 0; i < admins.Count; i++)
                    {
                        if (admins[i].логин == login && admins[i].пароль == password)
                        {
                            Hide();
                            Form3 adminform = new Form3();
                            adminform.ShowDialog();
                            Close();
                            return;
                        }
                        else
                            tempForAdmins++;
                    }
                    if (tempForAdmins == admins.Count)
                    {

                        MessageBox.Show("Неправильный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                else
                    MessageBox.Show("Все данные должен быть заполнены", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SelectUsers();
            SelectAdmins();
        }
    }
}
