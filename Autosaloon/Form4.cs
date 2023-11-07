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
    public partial class Form4 : Form
    {
        private SqlConnection sqlConnection = new SqlConnection(Properties.Settings.Default.АвтопродажиConnectionString);

        public Form4()
        {
            InitializeComponent();
        }

        private void автомобильBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.автомобильBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.автопродажиDataSet);

        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "автопродажиDataSet.Автомобиль". При необходимости она может быть перемещена или удалена.
            this.автомобильTableAdapter.Fill(this.автопродажиDataSet.Автомобиль);
        }
    }
}
