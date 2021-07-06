using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using Microsoft.VisualBasic;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class checkoutList : Form
    {
        public checkoutList()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(HotelManagementSystem.Properties.Settings.Default.hotel_management_systemdb);
        DataClasses1DataContext bb = new DataClasses1DataContext();

        private void checkoutList_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource =bb.checkout_List();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from checkin where checkin_status='CHECKOUT' and checkoutdate between '" + dtIn.Value.ToString() + "' and '" + dtOut.Value.ToString() + "' order by transact_id desc", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter data = new SqlDataAdapter(cmd);

            //Fill the DataTable with records from Table.
            DataTable dttbl = new DataTable();
            data.Fill(dttbl);
            dataGridView1.DataSource = dttbl;
            con.Close();
        }
    }
}
