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
    public partial class logrpt1 : Form
    {
        public logrpt1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(HotelManagementSystem.Properties.Settings.Default.hotel_management_systemdb);
        private void button1_Click(object sender, EventArgs e)
        {
                con.Open();
            SqlCommand cmd = new SqlCommand("Select * from userlogs where datetimes between '" + dtIn.Value.ToString() + "' and '" + dtOut.Value.ToString() + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter data = new SqlDataAdapter(cmd);

            //Fill the DataTable with records from Table.
            DataSet dttbl = new DataSet();
            data.Fill(dttbl);

            logsrpt1 sr = new logsrpt1();
            sr.SetDataSource(dttbl.Tables["table"]);
            crystalReportViewer1.ReportSource = sr;
            con.Close();
        }

        private void logrpt1_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select * from userlogs", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter data = new SqlDataAdapter(cmd);

            //Fill the DataTable with records from Table.
            DataSet dttbl = new DataSet();
            data.Fill(dttbl);

            logsrpt1 sr = new logsrpt1();
            sr.SetDataSource(dttbl.Tables["table"]);
            crystalReportViewer1.ReportSource = sr;
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dtOut_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dtIn_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
