using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace sql8
{
    public partial class Form1 : Form
    {

        NetrebiakEntities DB = new NetrebiakEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DB.Addresses.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int value;
            if ((string.IsNullOrWhiteSpace(textBox1.Text) && textBox1.Text.Length > 0) || (textBox1.Text == " ") || (textBox1.Text == ""))
            {
                MessageBox.Show("Enter State");
                return;
            }
            if ((string.IsNullOrWhiteSpace(textBox2.Text) && textBox2.Text.Length > 0) || (textBox2.Text == " ") || (textBox2.Text == ""))
            {
                MessageBox.Show("Enter City");
                return;
            }
            if ((string.IsNullOrWhiteSpace(textBox3.Text) && textBox3.Text.Length > 0) || (textBox3.Text == " ") || (textBox3.Text == ""))
            {
                MessageBox.Show("Enter Street");
                return;
            }
            if ((string.IsNullOrWhiteSpace(textBox4.Text) && textBox4.Text.Length > 0) || (textBox4.Text == " ") || (textBox4.Text == ""))
            {
                MessageBox.Show("Enter Building");
                return;
            }
            if (int.TryParse(textBox5.Text, out value))
            {
                DB.p_insert_Address(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, value);
                MessageBox.Show("Address added");
            

            }
            else if (textBox5.Text == "")
            {
                DB.p_insert_Address(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, null); 
                MessageBox.Show("Address added");
                

            }
            else
            {
                MessageBox.Show("Enter correct number of flat");
                return;
            }
            dataGridView1.DataSource = DB.Addresses.ToList();
        }
    }
}
