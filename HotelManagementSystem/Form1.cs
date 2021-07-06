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
namespace HotelManagementSystem {
    public partial class Form1 : Form {
        SqlConnection con = new SqlConnection(HotelManagementSystem.Properties.Settings.Default.hotel_management_systemdb);
        DataClasses1DataContext bb = new DataClasses1DataContext();
        public Form1() {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e) {
            con.Open();
            SqlCommand command = new SqlCommand("listview_users", con);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter sda = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) {
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
        private void button1_Click(object sender, EventArgs e) {
            string password = textBox1.Text;
            string position = textBox3.Text;
            string logss = textBox2.Text + '-'+ textBox3.Text;
            int result;
            result = bb.user_login(textBox2.Text, password).Count();
            if(result==0) {
                if (textBox1.Text != "" && textBox2.Text != "") {
                    MessageBox.Show("User and Password does not match", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else if (textBox1.Text == "") {
                    MessageBox.Show("Input Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                } else if (textBox1.Text == "" && textBox2.Text == "") {
                    MessageBox.Show("Select user and input Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }else if (textBox2.Text == "") {
                    MessageBox.Show("Double click the name to select user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }else {
                bb.sp_logs(logss);
                if (position == "Admin") {
                    MessageBox.Show("Successfully Login", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    HomePage page = new HomePage();
                    page.Show();
                }else {
                    MessageBox.Show("Successfully Login", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    StaffHomePage page = new StaffHomePage();
                    page.Show();
                }
            }
        }
        private void Label1_Click(object sender, EventArgs e) {
        }
        private void label3_Click(object sender, EventArgs e){
        }
    }
}
