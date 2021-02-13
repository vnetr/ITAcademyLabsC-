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
    public partial class AddingConnection : Form
    {
        public AddingConnection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Enter Name");
                return;
            }
            Database DB = new Database();
            DB.OpenConnection();
            SqlCommand command = new SqlCommand("INSERT INTO[dbo].[Connection_type]([Name]) VALUES(@name)", DB.GetConnection());
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = textBox1.Text;

            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Connection type added");
            }
            else
            {
                MessageBox.Show("Connection type not added");
            }
            DB.CloseConnection();
        }
    }
}
