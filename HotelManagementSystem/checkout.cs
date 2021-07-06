using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Microsoft.VisualBasic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelManagementSystem
{
    public partial class checkout : Form
    {
        public checkout()
        {
            InitializeComponent();
        }
        DataClasses1DataContext bb = new DataClasses1DataContext();

        private void checkout_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bb.checkout_disp();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            txtGuestName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtRoomNumber.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtRoomType.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtRoomRate.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtCheckin.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtAdvance.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtCheckout.Text = DateTime.Now.ToString("MM/dd/yyyy");
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = bb.checkout_disp_search(textBox1.Text);
        }

        private void txtCheckout_TextChanged(object sender, EventArgs e)
        {try
            {
                TimeSpan T = System.Convert.ToDateTime(txtCheckout.Text) - System.Convert.ToDateTime(txtCheckin.Text);
                if (T.Days < 1)
                {
                    txtCheckout.Text = System.Convert.ToString(DateTime.Now.AddDays(1));
                    txtDays.Text = "1";
                }
                else
                {
                    txtDays.Text = System.Convert.ToString(T.Days + 1);
                }
                txtSubTotal.Text = System.Convert.ToString(Conversion.Val(txtRoomRate.Text) * Conversion.Val(txtDays.Text));
            }
            catch
            {
                this.Hide();
                checkoutList page = new checkoutList();
                page.ShowDialog();
            }
        }

        private void txtTotal_TextChanged_1(object sender, EventArgs e)
        {
            if (Conversion.Val(txtSubTotal.Text) < Conversion.Val(txtAdvance.Text) || Conversion.Val(txtSubTotal.Text) == Conversion.Val(txtAdvance.Text))
            {
                txtTotal.Text = "0.00";
            }
            else
            {
                txtTotal.Text = System.Convert.ToString((Conversion.Val(txtSubTotal.Text) - Conversion.Val(txtAdvance.Text)).ToString("00.00"));
            }
        }

        private void txtCash_TextChanged(object sender, EventArgs e)
        {
            if (Conversion.Val(txtCash.Text) < Conversion.Val(txtTotal.Text))
            {
                txtChange.Text = "0.00";
            }
            else
            {
                txtChange.Text = System.Convert.ToString((Conversion.Val(txtCash.Text) - Conversion.Val(txtTotal.Text)).ToString("N"));
            }
        }


        private void bttnCheckout_Click(object sender, EventArgs e)
        {
            string checkin_stat = "CHECKOUT";
            string room_stat = "Vacant";

            if (Conversion.Val(txtCash.Text) < Conversion.Val(txtTotal.Text))
            {
                Interaction.MsgBox("Insufficient Cash!", Constants.vbExclamation, "Note");
            }
            else
            {
                bb.room_checkout(int.Parse(txtRoomNumber.Text), room_stat);
                bb.checkin_update(int.Parse(txtRoomNumber.Text), Convert.ToDateTime(txtCheckout.Text),txtDays.Text,txtSubTotal.Text,txtTotal.Text,checkin_stat);
                Interaction.MsgBox("Guest Checked out!", Constants.vbInformation, "Checkout");
                clear();

            }

        }

         public void clear()
        {
            txtGuestName.Clear();
            txtRoomNumber.Clear();
            txtRoomRate.Clear();
            txtRoomType.Clear();
            txtCheckin.Clear();
            txtCheckout.Clear();
            txtDays.Clear();
            txtAdvance.Clear();
            txtCash.Clear();
            txtChange.Clear();
            textBox1.Clear();

        }
    }
}
