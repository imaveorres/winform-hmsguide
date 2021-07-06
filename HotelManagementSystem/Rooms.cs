using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class Rooms : Form
    {
        SqlConnection con = new SqlConnection(HotelManagementSystem.Properties.Settings.Default.hotel_management_systemdb);
        DataClasses1DataContext bb = new DataClasses1DataContext();
        public Rooms()
        {
            InitializeComponent();
        }
        string remarks = "Vacant";

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" ||comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bb.room_save(int.Parse(textBox1.Text), comboBox1.SelectedItem.ToString(), textBox2.Text, remarks);
                MessageBox.Show("Successfully added Room", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = bb.room_disp();
                clear();
            }
           

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bb.room_update(int.Parse(textBox1.Text),comboBox1.SelectedItem.ToString(),textBox2.Text);
                MessageBox.Show("Updated Succesfully", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = bb.room_disp();
                clear();
            }
        }

        private void Rooms_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bb.room_disp();

        }
        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Text = "Select Room Type";
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you will Delete?", "Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (!(textBox1.Text == "" ||  comboBox1.Text == "Select Room Type" || textBox2.Text == ""))
                {
                    bb.room_delete(int.Parse(textBox1.Text));
                    MessageBox.Show("Successfully Deleted");
                    clear();
                    dataGridView1.DataSource =bb.room_disp();
                    
                }
                else
                {
                    MessageBox.Show("Select which row to delete", "Invalid",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
            }

        }
        private void textBox3_TextChanged(object sender, EventArgs e){
            dataGridView1.DataSource = bb.room_search(textBox3.Text);
        }
        private void textBox4_TextChanged(object sender, EventArgs e){
        }
    }
}
