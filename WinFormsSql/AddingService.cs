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

namespace WinFormsSql
{
    public partial class AddingService : Form
    {
        public AddingService()
        {
            InitializeComponent();
        }

        private void AddingService_Load(object sender, EventArgs e)
        {
            Database DB = new Database();
            DB.OpenConnection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [dbo].[Connection_type]", DB.GetConnection());
            SqlDataReader DR = comm.ExecuteReader();
            comboBox1.Items.Clear();
            while (DR.Read())
            {
                Address address = new Address();
                address.ID = (int)DR[0];
                address.name = DR[1].ToString();
                comboBox1.Items.Add(address);
                comboBox1.DisplayMember = "name";
            }
            DB.CloseConnection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal value;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter first name");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter middle name");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Enter last name");
                return;
            }
 
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Choose connection type");
                return;
            }
            Database DB = new Database();
            DB.OpenConnection();
            SqlCommand command = new SqlCommand("INSERT INTO [dbo].[Services]([Name],[Connection_Type_ID],[Release_date],[Monthly_fee]) VALUES(@name, @cid, @rd, @mf)", DB.GetConnection());
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@rd", SqlDbType.VarChar).Value = textBox2.Text;
            Address add = (Address)comboBox1.SelectedItem;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = add.ID;

            if(decimal.TryParse(textBox3.Text, out value))
            {
                command.Parameters.Add("@mf", SqlDbType.Decimal).Value = value;
            }
            else
            {
                MessageBox.Show("Enter correct number monthly fee");
                return;
            }


            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Service added");
            }
            else
            {
                MessageBox.Show("Service not added");
            }
            DB.CloseConnection();
        }
    }
}
