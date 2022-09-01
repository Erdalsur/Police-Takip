namespace Policem.UI.Forms
{
    partial class FrmSQLList
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
            this.SQLSec = new DevExpress.XtraEditors.SimpleButton();
            this.lbServers = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // SQLSec
            // 
            this.SQLSec.Location = new System.Drawing.Point(197, 194);
            this.SQLSec.Name = "SQLSec";
            this.SQLSec.Size = new System.Drawing.Size(75, 23);
            this.SQLSec.TabIndex = 3;
            this.SQLSec.Text = "SEÇ";
            this.SQLSec.Click += new System.EventHandler(this.SQLSec_Click);
            // 
            // lbServers
            // 
            this.lbServers.FormattingEnabled = true;
            this.lbServers.Location = new System.Drawing.Point(1, 2);
            this.lbServers.Name = "lbServers";
            this.lbServers.Size = new System.Drawing.Size(282, 186);
            this.lbServers.TabIndex = 2;
            this.lbServers.SelectedIndexChanged += new System.EventHandler(this.lbServers_SelectedIndexChanged);
            this.lbServers.DoubleClick += new System.EventHandler(this.lbServers_DoubleClick);
            // 
            // FrmSQLList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 222);
            this.Controls.Add(this.SQLSec);
            this.Controls.Add(this.lbServers);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 260);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 260);
            this.Name = "FrmSQLList";
            this.Text = "SQL Server Listesi";
            this.Activated += new System.EventHandler(this.FrmSQLList_Activated);
            this.Load += new System.EventHandler(this.FrmSQLList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton SQLSec;
        private System.Windows.Forms.ListBox lbServers;
    }
}