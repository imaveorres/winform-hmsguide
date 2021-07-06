using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace HotelManagementSystem {
    public partial class HomePage : Form {
        private int childFormNumber = 0;
        public HomePage(){
            InitializeComponent();
        }
        private void ShowNewForm(object sender, EventArgs e) {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }
        private void OpenFile(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK) {
                string FileName = openFileDialog.FileName;
            }
        }
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK) {
                string FileName = saveFileDialog.FileName;
            }
        }
        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }
        private void CutToolStripMenuItem_Click(object sender, EventArgs e) {
        }
        private void CopyToolStripMenuItem_Click(object sender, EventArgs e) {
        }
        private void PasteToolStripMenuItem_Click(object sender, EventArgs e) {
        }
        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e) {
            LayoutMdi(MdiLayout.Cascade);
        }
        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e) {
            LayoutMdi(MdiLayout.TileVertical);
        }
        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e) {
            LayoutMdi(MdiLayout.TileHorizontal);
        }
        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e) {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }
        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach (Form childForm in MdiChildren) {
                childForm.Close();
            }
        }
        private void manageRoomsToolStripMenuItem_Click(object sender, EventArgs e) {
            Rooms room = new Rooms();
            room.ShowDialog();
        }
        private void viewLogsToolStripMenuItem_Click(object sender, EventArgs e) {
            logslist lists = new logslist();
            lists.ShowDialog();
        }
        private void salesReportToolStripMenuItem_Click(object sender, EventArgs e) {
            salesrpts rpt = new salesrpts();
            rpt.ShowDialog();
        }
        private void logoutToolStripMenuItem_Click(object sender, EventArgs e) {
            managestaff page = new managestaff();
            page.ShowDialog();
        }
        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e) {
            this.Hide();
            Form1 login = new Form1();
            login.ShowDialog();
        }
    }
}
