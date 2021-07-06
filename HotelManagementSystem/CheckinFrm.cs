using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Microsoft.VisualBasic;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class CheckinFrm : Form
    {
        DataClasses1DataContext bb = new DataClasses1DataContext();
        SqlConnection con = new SqlConnection(HotelManagementSystem.Properties.Settings.Default.hotel_management_systemdb);
        public CheckinFrm()
        {
            InitializeComponent();
        }


        private void dtCheckOutDate_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan T = dtCheckOutDate.Value - DateTime.Now;
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

        private void CheckinFrm_Load(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            string room_stat = "OCCUPIED";
            string checkin_stat = "Active";
            DateTime time = DateTime.Now;
            string format = "MM/dd/yyyy";
            checkin.Text = time.ToString(format);
            try
            {
                bb.checkin_save(textBox1.Text, int.Parse(textBox2.Text), System.Convert.ToDateTime(checkin.Text), System.Convert.ToDateTime(dtCheckOutDate.Text), txtDaysNumber.Text, txtSubTotal.Text, textBox6.Text, lblTotal.Text, checkin_stat);
                bb.checkin_room_update(int.Parse(textBox2.Text), room_stat);
                Interaction.MsgBox("Guest Successfully Checked In!", Constants.vbInformation, "CheckIn");
                clear();
                this.Hide();
                checkinList list = new checkinList();
                list.ShowDialog();

            }
            catch (Exception ex)
            {
                if (textBox1.Text == "" || textBox2.Text == "" || checkin.Text == "" || dtCheckOutDate.Text == "" || txtDaysNumber.Text == "" || txtSubTotal.Text == "" || textBox6.Text == "")
                {
                    MessageBox.Show("Fill all information");
                }
                MessageBox.Show(ex.Message);
            }

        }

        public void clear()
        {

            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            txtRoomRate.Clear();
            checkin.Clear();
            txtDaysNumber.Clear();
            txtSubTotal.Clear();
            textBox6.Clear();
            lblTotal.Clear();
            textBox4.Clear();

            
            }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtRoomRate.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void lblTotal_TextChanged(object sender, EventArgs e)
        {
            if (Conversion.Val(txtSubTotal.Text) < Conversion.Val(textBox6.Text) || Conversion.Val(txtSubTotal.Text) == Conversion.Val(textBox6.Text))
            {
                lblTotal.Text = "0.00";
            }
            else
            {
                lblTotal.Text = System.Convert.ToString((Conversion.Val(txtSubTotal.Text) - Conversion.Val(textBox6.Text)).ToString("00.00"));
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bb.room_search(textBox4.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string a = System.Convert.ToString(Interaction.MsgBox("Cancel Transaction?", (int)Constants.vbQuestion + Constants.vbYesNo, "Cancel"));
            if (a == Constants.vbNo.ToString())
            {
                clear();
            }
            else
            {
                this.Hide();
            }
            
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {

            if (Conversion.Val(txtCash.Text) < Conversion.Val(textBox6.Text))
            {
                txtChange.Text = "0.00";
            }
            else
            {
                txtChange.Text = System.Convert.ToString((Conversion.Val(txtCash.Text) - Conversion.Val(textBox6.Text)).ToString("N"));
            }
        }

    }
}
