using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class managestaff : Form
    {
        public managestaff()
        {
            InitializeComponent();
        }
        DataClasses1DataContext bb = new DataClasses1DataContext();
        int id;
        private void managestaff_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource =  bb.user_disp();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(textBox2.Text != textBox4.Text )
            {
                MessageBox.Show("Password does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bb.save_user(textBox1.Text, comboBox1.SelectedItem.ToString(), textBox2.Text);
                MessageBox.Show("Successfully added Staff", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = bb.user_disp();
                clear();
            }
         
        }
        public void clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            comboBox1.Text = "Select Position";
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Fill in all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (textBox2.Text != textBox4.Text)
            {
                MessageBox.Show("Password does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                bb.user_update(id, textBox1.Text, comboBox1.SelectedItem.ToString(), textBox2.Text);
                MessageBox.Show("Successfully updated Staff", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = bb.user_disp();
                clear();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you will Delete?", "Delete", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                if (!(textBox1.Text == "" || comboBox1.Text == "Select Position" || textBox2.Text == ""))
                {
                    bb.user_delete(id);
                    MessageBox.Show("Successfully Deleted");
                    clear();
                   dataGridView1.DataSource= bb.user_disp();

                }
                else
                {
                    MessageBox.Show("Select which row to delete", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
