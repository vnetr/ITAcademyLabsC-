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
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Database db = new Database();
            db.OpenConnection();
            SqlCommand command = new SqlCommand("SELECT TABLE_NAME FROM information_schema.TABLES WHERE TABLE_TYPE='BASE TABLE'", db.GetConnection());
            SqlDataReader DR = command.ExecuteReader();
            comboBox1.Items.Clear();
            while (DR.Read())
            {

                comboBox1.Items.Add(DR[0].ToString());

            }
            db.CloseConnection();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                return;
            }
            Database db = new Database();
            db.OpenConnection();
            SqlDataAdapter DA = new SqlDataAdapter("SELECT * FROM "+comboBox1.SelectedItem.ToString(),db.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS, "All records");
            dataGridView1.DataSource=DS.Tables["All records"];
            dataGridView1.Refresh();
            db.CloseConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddingAddress AD = new AddingAddress();
            AD.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddingConnection AC = new AddingConnection();
            AC.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddingUser AU = new AddingUser();
            AU.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AddingService AS = new AddingService();
            AS.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.OpenConnection();
            SqlDataAdapter DA = new SqlDataAdapter("SELECT S.Name FROM[dbo].[User_Services] US INNER JOIN[dbo].[Services_City] SC ON US.Services_City_ID = SC.ID RIGHT JOIN[dbo].[Services] S ON SC.Services_ID = S.ID WHERE SC.Services_ID IS NULL ", db.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS, "All records");
            dataGridView1.DataSource = DS.Tables["All records"];
            dataGridView1.Refresh();
            db.CloseConnection();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.OpenConnection();
            SqlDataAdapter DA = new SqlDataAdapter("SELECT * FROM[dbo].[Users] U INNER JOIN[dbo].[Address] A ON A.ID = U.Address_ID INNER JOIN[dbo].[User_Services] US ON A.ID = US.Address_ID WHERE U.Login IN (  SELECT U.Login    FROM[dbo].[Users] U     WHERE U.Login = Login GROUP BY U.Login HAVING COUNT(*) > 1 ) AND US.Activation_Date > '2020-08-16' AND A.City = 'Lviv' ", db.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS, "All records");
            dataGridView1.DataSource = DS.Tables["All records"];
            dataGridView1.Refresh();
            db.CloseConnection();

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Database db = new Database();
            db.OpenConnection();
            SqlDataAdapter DA = new SqlDataAdapter("SELECT * FROM[dbo].[Users] U INNER JOIN[dbo].[Address] A ON A.ID = U.Address_ID INNER JOIN[dbo].[User_Services] US ON A.ID = US.Address_ID WHERE  US.Activation_Date > '2018-01-11' AND(A.City = 'Lviv' OR A.City = 'Kyiv' OR A.City = 'Dnipro') ", db.GetConnection());
            DataSet DS = new DataSet();
            DA.Fill(DS, "All records");
            dataGridView1.DataSource = DS.Tables["All records"];
            dataGridView1.Refresh();
            db.CloseConnection();

        }

        private void button12_Click(object sender, EventArgs e)
        {
            UpdateAddress UA = new UpdateAddress();
            UA.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            UpdateConnectionType UCT = new UpdateConnectionType();
            UCT.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            UpdateUser UU = new UpdateUser();
            UU.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            UpdateService US = new UpdateService();
            US.Show();
        }
    }
}
