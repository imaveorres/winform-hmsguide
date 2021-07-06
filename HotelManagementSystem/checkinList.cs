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
    public partial class checkinList : Form
    {
        public checkinList()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(HotelManagementSystem.Properties.Settings.Default.hotel_management_systemdb);

        private void checkinList_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand command = new SqlCommand("Select * from checkin where checkin_status='Active' order by transact_id desc", con);
            command.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(command);

            //Fill the DataTable with records from Table.
            DataTable dt = new DataTable();
            sda.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd= new SqlCommand("Select * from checkin where checkin_status='Active' and checkindate between '"+dtIn.Value.ToString()+"' and '" + dtOut.Value.ToString() + "' order by transact_id desc", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter data = new SqlDataAdapter(cmd);

            //Fill the DataTable with records from Table.
            DataTable dttbl = new DataTable();
            data.Fill(dttbl);
            dataGridView1.DataSource = dttbl;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Visible = true;
            txtGuestName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtRoomNumber.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
           
            
            string oString = "Select * from room where room_num='" + txtRoomNumber.Text + "'";
            SqlCommand oCmd = new SqlCommand(oString,con);
            oCmd.Parameters.AddWithValue("@room_num", txtRoomNumber.Text);
           con.Open();
            using (SqlDataReader oReader = oCmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                   txtRoomType.Text = oReader["room_type"].ToString();
                   txtRoomRate.Text = oReader["room_rate"].ToString();
                }

                con.Close();
            }
            txtCheckin.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtCheckout.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtDays.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtSubTotal.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtAdvance.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtTotal.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
