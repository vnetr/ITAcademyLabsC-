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
    public partial class AddingAddress : Form
    {
        public AddingAddress()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter state");
                return;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Enter city");
                return;
            }
            if (textBox3.Text == "")
            {
                MessageBox.Show("Enter street");
                return;
            }
            if (textBox4.Text == "")
            {
                MessageBox.Show("Enter building");
                return;
            }
            Database DB = new Database();
            DB.OpenConnection();
            SqlCommand command = new SqlCommand("INSERT INTO[dbo].[Address]([State],[City],[Street],[Building],[Flat]) VALUES(@state, @city, @street, @building, @flat)", DB.GetConnection());
            command.Parameters.Add("@state", SqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@city", SqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@street", SqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@building", SqlDbType.VarChar).Value = textBox4.Text;
            if (textBox5.Text == "")
            {
                command.Parameters.Add("@flat", SqlDbType.Int).Value = DBNull.Value;
            }
            else
            {
                if (int.TryParse(textBox5.Text, out value))
                {
                    command.Parameters.Add("@flat", SqlDbType.Int).Value = value;
                }
                else
                {
                    MessageBox.Show("Enter correct number of flat");
                    return;
                }
            }

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Address added");
            }
            else
            {
                MessageBox.Show("Address not added");
            }

            DB.CloseConnection();
        }
    }
}
