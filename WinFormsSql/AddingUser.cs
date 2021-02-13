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
    public partial class AddingUser : Form
    {
        public AddingUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value;
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
            if (textBox6.Text == "")
            {
                MessageBox.Show("Enter phone number");
                return;
            }
            if ((textBox5.Text == "") ||(textBox5.Text.Length<4))
            {
                MessageBox.Show("Enter login or login too short");
                return;
            }
            if ((textBox4.Text == "")||(textBox4.Text.Length<6))
            {
                MessageBox.Show("Enter password or password too short");
                return;
            }
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Choose address");
                return;
            }
            Database DB = new Database();
            DB.OpenConnection();
            SqlCommand command = new SqlCommand("INSERT INTO[dbo].[Users]([First_name],[Middle_name],[Last_name],[Address_ID],[Phone],[Login], [Password]) VALUES(@fname, @mname, @lname, @aid, @phone, @login, @password)", DB.GetConnection());
            command.Parameters.Add("@fname", SqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@mname", SqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@lname", SqlDbType.VarChar).Value = textBox3.Text;
            Address add = (Address)comboBox1.SelectedItem;
            command.Parameters.Add("@aid", SqlDbType.Int).Value = add.ID;
            command.Parameters.Add("@login", SqlDbType.VarChar).Value = textBox5.Text;
            command.Parameters.Add("@password", SqlDbType.VarChar).Value = textBox4.Text;

            if (int.TryParse(textBox6.Text, out value))
            {
                  command.Parameters.Add("@phone", SqlDbType.Int).Value = value;
            }
            else
            {
                MessageBox.Show("Enter correct number of phone");
                return;
            }
            

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("User added");
            }
            else
            {
                MessageBox.Show("User not added");
            }
            DB.CloseConnection();
        }

        private void AddingUser_Load(object sender, EventArgs e)
        {
            Database DB = new Database();
            DB.OpenConnection();
            SqlCommand comm = new SqlCommand("SELECT * FROM [dbo].[Address]", DB.GetConnection());
            SqlDataReader DR = comm.ExecuteReader();
            comboBox1.Items.Clear();
            while (DR.Read())
            {
                Address address = new Address();
                address.ID = (int)DR[0];
                address.name = DR[1].ToString() + " " + DR[2].ToString() + " " + DR[3].ToString() + " " + DR[4].ToString() + " " + DR[5].ToString() + " "; 
                comboBox1.Items.Add(address);
                comboBox1.DisplayMember="name";
            }
            DB.CloseConnection();
        }
    }
}
