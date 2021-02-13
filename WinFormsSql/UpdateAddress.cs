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
    public partial class UpdateAddress : Form
    {
        public UpdateAddress()
        {
            InitializeComponent();
        }

        private void UpdateAddress_Load(object sender, EventArgs e)
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
                comboBox1.DisplayMember = "name";
            }
            DB.CloseConnection();
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
            SqlCommand command = new SqlCommand("UPDATE [dbo].[Address] SET [State]=@state, [City]=@city,[Street]=@street,[Building]=@building,[Flat]=@flat WHERE ID=@aid", DB.GetConnection());
            command.Parameters.Add("@state", SqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@city", SqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@street", SqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@building", SqlDbType.VarChar).Value = textBox4.Text;
            Address add = (Address)comboBox1.SelectedItem;
            command.Parameters.Add("@aid", SqlDbType.Int).Value = add.ID;
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
                MessageBox.Show("Address updated");
            }
            else
            {
                MessageBox.Show("Address not updated");
            }

            DB.CloseConnection();
        }
    }
}
