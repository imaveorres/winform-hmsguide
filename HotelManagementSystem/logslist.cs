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
    public partial class logslist : Form
    {
        public logslist()
        {
            InitializeComponent();
        }
        DataClasses1DataContext bb = new DataClasses1DataContext();
        SqlConnection con = new SqlConnection(HotelManagementSystem.Properties.Settings.Default.hotel_management_systemdb);

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void logslist_Load(object sender, EventArgs e)
        {
           dataGridView1.DataSource =  bb.logs_display();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("Select logs_id as Log_id,logss as Information,datetimes as DateLog  from userlogs where datetimes between '" + dtIn.Value.ToString() + "' and '" + dtOut.Value.ToString() + "'", con);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter data = new SqlDataAdapter(cmd);

            //Fill the DataTable with records from Table.
            DataTable dttbl = new DataTable();
            data.Fill(dttbl);
            dataGridView1.DataSource = dttbl;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            logrpt1 page = new logrpt1();
            page.ShowDialog();

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
