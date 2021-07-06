using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class salesrpts : Form
    {
        public salesrpts()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(HotelManagementSystem.Properties.Settings.Default.hotel_management_systemdb);
        ReportDocument bb = new ReportDocument();
        private void button1_Click(object sender, EventArgs e)
        {
       
            con.Open();
            SqlCommand cmd = new SqlCommand("select convert(nvarchar(MAX), checkoutdate, 101) as 'DaySales',sum(CAST(subtotal AS decimal(18, 2))) as 'PAYMENT'  FROM checkin where (checkin_status = 'CHECKOUT' or checkin_status ='CANCELLED RESERVATION') and (checkoutdate between '" + dtIn.Value.ToString() + "' and '" + dtOut.Value.ToString() + "') group by checkoutdate UNION select 'TOTAL', sum(CAST(subtotal AS decimal(18, 2))) as 'PAYMENT' from checkin where (checkin_status = 'CHECKOUT' or checkin_status ='CANCELLED RESERVATION') and (checkoutdate between '" + dtIn.Value.ToString() + "' and '" + dtOut.Value.ToString() + "') ", con);    
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter data = new SqlDataAdapter(cmd);

            //Fill the DataTable with records from Table.
            DataSet dttbl = new DataSet();
            data.Fill(dttbl);

            salesrpt srp = new salesrpt();
            srp.SetDataSource(dttbl.Tables["table"]);
            crystalReportViewer2.ReportSource = srp;
            crystalReportViewer2.Refresh();
            con.Close();
        }

        private void salesrpts_Load(object sender, EventArgs e)
        {
            bb.Load(@"C:\Users\Lenovo\documents\visual studio 2015\Projects\HotelManagementSystem\HotelManagementSystem\salesrpt.rpt");
            crystalReportViewer2.ReportSource = bb;
            crystalReportViewer2.Refresh();
            
        }
    }
}
