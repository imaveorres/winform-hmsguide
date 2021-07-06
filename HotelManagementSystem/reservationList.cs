using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class reservationList : Form
    {
        public reservationList()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(HotelManagementSystem.Properties.Settings.Default.hotel_management_systemdb);
        DataClasses1DataContext bb = new DataClasses1DataContext();
        private void reservationList_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bb.reservation_List();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            panel1.Visible = true;

            txtGuestName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtRoomNumber.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtRoomType.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtRoomRate.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtCheckin.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtCheckout.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtDays.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtSubTotal.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            txtAdvance.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
            txtTotal.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
            
        }

        private void Checkin_Click(object sender, EventArgs e)
        {
            string checkin_stat = "Active";
            string room_stat = "OCCUPIED";
                bb.checkin_room_update(int.Parse(txtRoomNumber.Text), room_stat);
            bb.reserve_checkin(int.Parse(txtRoomNumber.Text),checkin_stat);
                Interaction.MsgBox("Guest Successfully Checked In!", Constants.vbInformation, "CheckIn");
                clear();
                this.Hide();
                checkinList list = new checkinList();
                list.ShowDialog();
        }
        public void clear()
        {
            panel1.Visible = false;
            txtGuestName.Clear();
            txtRoomNumber.Clear();
            txtRoomType.Clear();
            txtRoomRate.Clear();
            txtCheckin.Clear();
            txtSubTotal.Clear();
            txtAdvance.Clear();
            txtTotal.Clear();
            txtDays.Clear();
     
        }

        private void button3_Click(object sender, EventArgs e)
        {
             string checkin_stat = "CHECKOUT";
            string room_stat = "Vacant";
          
                bb.room_checkout(int.Parse(txtRoomNumber.Text), room_stat);
                bb.checkin_update(int.Parse(txtRoomNumber.Text), Convert.ToDateTime(txtCheckout.Text), txtDays.Text, txtSubTotal.Text, txtTotal.Text, checkin_stat);
                Interaction.MsgBox("Guest Cancelled Reservation!", Constants.vbInformation, "Cancel Successfully");
                dataGridView1.DataSource = bb.reservation_List();
            clear();
        }
    }
}
