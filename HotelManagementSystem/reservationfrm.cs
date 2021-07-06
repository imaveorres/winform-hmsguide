using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class reservationfrm : Form
    {
        public reservationfrm()
        {
            InitializeComponent();
        }
        DataClasses1DataContext bb = new DataClasses1DataContext();
        SqlConnection con = new SqlConnection(HotelManagementSystem.Properties.Settings.Default.hotel_management_systemdb);
        private void reservationfrm_Load(object sender, EventArgs e)
        {

            con.Open();
            SqlCommand command = new SqlCommand("Select * from room where room_remarks='Vacant'", con);
            command.CommandType = CommandType.Text;
            SqlDataAdapter sda = new SqlDataAdapter(command);

            //Fill the DataTable with records from Table.
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count == 0)
            {
                textBox5.Visible = true;
            }
            else
            {
                dataGridView1.DataSource = dt;
            }


            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRoomNumber.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtRoomType.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtRoomRate.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void dtCheckOutDate_ValueChanged(object sender, EventArgs e)
        {

            TimeSpan T = dtCheckOutDate.Value - dtCheckInDate.Value;
            if (T.Days < 1)
            {
                dtCheckOutDate.Text = System.Convert.ToString(DateTime.Now.AddDays(1));
                txtDaysNumber.Text = "1";
            }
            else
            {
                txtDaysNumber.Text = System.Convert.ToString(T.Days + 1);
            }
            txtSubTotal.Text = System.Convert.ToString(Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDaysNumber.Text));
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (Conversion.Val(txtSubTotal.Text) < Conversion.Val(txtAdvance.Text) || Conversion.Val(txtSubTotal.Text) == Conversion.Val(txtAdvance.Text))
            {
                textBox1.Text = "0.00";
            }
            else
            {
                textBox1.Text = System.Convert.ToString((Conversion.Val(txtSubTotal.Text) - Conversion.Val(txtAdvance.Text)).ToString("00.00"));
            }
        }

        public void clear()
        {
            txtGuestName.Clear();
            textBox1.Clear();
            txtRoomNumber.Clear();
            txtRoomRate.Clear();
            txtDaysNumber.Clear();
            txtSubTotal.Clear();
            txtAdvance.Clear();
            textBox4.Clear();


        }


        private void bttnReserve_Click(object sender, EventArgs e)
        {
            string room_stat = "RESERVED";
            string checkin_stat = "Has Reservation";

            try
            {
                bb.checkin_save(txtGuestName.Text, int.Parse(txtRoomNumber.Text), dtCheckInDate.Value,dtCheckOutDate.Value, txtDaysNumber.Text, txtSubTotal.Text, txtAdvance.Text, textBox1.Text, checkin_stat);
                bb.checkin_room_update(int.Parse(txtRoomNumber.Text), room_stat);
                Interaction.MsgBox("Guest Successfully Reserve the Room!", Constants.vbInformation, "Room Resrvation");
           
                clear();
                this.Hide();

                reservationList list = new reservationList();
                list.ShowDialog();

            }
            catch (Exception ex)
            {
                if (txtGuestName.Text==""||textBox1.Text == "" || txtRoomNumber.Text == "" ||  txtDaysNumber.Text == "" || txtSubTotal.Text == "" || txtAdvance.Text == "")
                {
                    MessageBox.Show("Fill all information");
                }
                MessageBox.Show(ex.Message);
            }
        }
    }
}
