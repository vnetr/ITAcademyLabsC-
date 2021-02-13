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
    public partial class UpdateConnectionType : Form
    {
        public UpdateConnectionType()
        {
            InitializeComponent();
        }

        private void UpdateConnectionType_Load(object sender, EventArgs e)
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
            if (textBox5.Text == "")
            {
                MessageBox.Show("Enter Name");
                return;
            }
            Database DB = new Database();
            DB.OpenConnection();
            SqlCommand command = new SqlCommand("UPDATE [dbo].[Connection_type] SET Name=@name WHERE ID=@cid", DB.GetConnection());
            command.Parameters.Add("@name", SqlDbType.VarChar).Value = textBox5.Text;
            Address add = (Address)comboBox1.SelectedItem;
            command.Parameters.Add("@cid", SqlDbType.Int).Value = add.ID;
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Connection type updated");
            }
            else
            {
                MessageBox.Show("Connection type not updated");
            }
            DB.CloseConnection();
        }
    
    }
}
