namespace HotelManagementSystem
{
    partial class StaffHomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.checkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkinListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkINListToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.checkOUTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkOutFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkOutListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservationFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservationListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkToolStripMenuItem,
            this.checkOUTToolStripMenuItem,
            this.reservationToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1141, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // checkToolStripMenuItem
            // 
            this.checkToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkinListToolStripMenuItem,
            this.checkINListToolStripMenuItem1});
            this.checkToolStripMenuItem.Name = "checkToolStripMenuItem";
            this.checkToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.checkToolStripMenuItem.Text = "Check In";
            // 
            // checkinListToolStripMenuItem
            // 
            this.checkinListToolStripMenuItem.Name = "checkinListToolStripMenuItem";
            this.checkinListToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.checkinListToolStripMenuItem.Text = "Check-In Form";
            this.checkinListToolStripMenuItem.Click += new System.EventHandler(this.checkinListToolStripMenuItem_Click);
            // 
            // checkINListToolStripMenuItem1
            // 
            this.checkINListToolStripMenuItem1.Name = "checkINListToolStripMenuItem1";
            this.checkINListToolStripMenuItem1.Size = new System.Drawing.Size(153, 22);
            this.checkINListToolStripMenuItem1.Text = "Active Guest";
            this.checkINListToolStripMenuItem1.Click += new System.EventHandler(this.checkINListToolStripMenuItem1_Click);
            // 
            // checkOUTToolStripMenuItem
            // 
            this.checkOUTToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkOutFormToolStripMenuItem,
            this.checkOutListToolStripMenuItem});
            this.checkOUTToolStripMenuItem.Name = "checkOUTToolStripMenuItem";
            this.checkOUTToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.checkOUTToolStripMenuItem.Text = "Check Out";
            // 
            // checkOutFormToolStripMenuItem
            // 
            this.checkOutFormToolStripMenuItem.Name = "checkOutFormToolStripMenuItem";
            this.checkOutFormToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.checkOutFormToolStripMenuItem.Text = "Check Out Form";
            this.checkOutFormToolStripMenuItem.Click += new System.EventHandler(this.checkOutFormToolStripMenuItem_Click);
            // 
            // checkOutListToolStripMenuItem
            // 
            this.checkOutListToolStripMenuItem.Name = "checkOutListToolStripMenuItem";
            this.checkOutListToolStripMenuItem.Size = new System.Drawing.Size(161, 22);
            this.checkOutListToolStripMenuItem.Text = "Check Out List";
            this.checkOutListToolStripMenuItem.Click += new System.EventHandler(this.checkOutListToolStripMenuItem_Click);
            // 
            // reservationToolStripMenuItem
            // 
            this.reservationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reservationFormToolStripMenuItem,
            this.reservationListToolStripMenuItem});
            this.reservationToolStripMenuItem.Name = "reservationToolStripMenuItem";
            this.reservationToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.reservationToolStripMenuItem.Text = "Reservation";
            // 
            // reservationFormToolStripMenuItem
            // 
            this.reservationFormToolStripMenuItem.Name = "reservationFormToolStripMenuItem";
            this.reservationFormToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.reservationFormToolStripMenuItem.Text = "Reservation Form";
            this.reservationFormToolStripMenuItem.Click += new System.EventHandler(this.reservationFormToolStripMenuItem_Click);
            // 
            // reservationListToolStripMenuItem
            // 
            this.reservationListToolStripMenuItem.Name = "reservationListToolStripMenuItem";
            this.reservationListToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.reservationListToolStripMenuItem.Text = "Reservation List";
            this.reservationListToolStripMenuItem.Click += new System.EventHandler(this.reservationListToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1});
            this.toolStrip.Location = new System.Drawing.Point(0, 24);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1141, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "ToolStrip";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 506);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1141, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // StaffHomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1141, 528);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "StaffHomePage";
            this.Text = "StaffHomePage";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem checkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkinListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkOUTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkINListToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem checkOutFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkOutListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservationFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservationListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
    }
}



