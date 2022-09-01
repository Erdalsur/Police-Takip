namespace Policem.UI.Forms.Selection
{
    partial class FrmMusteriSec
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new DevExpress.XtraEditors.TextEdit();
            this.gridControlMusteriler = new DevExpress.XtraGrid.GridControl();
            this.gridMusteri = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMusteriler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMusteri)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 37);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Müşteri";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(50, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(239, 20);
            this.textBox1.TabIndex = 4;
            this.textBox1.EditValueChanged += new System.EventHandler(this.TextBox1_TextChanged);
            // 
            // gridControlMusteriler
            // 
            this.gridControlMusteriler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlMusteriler.Location = new System.Drawing.Point(0, 37);
            this.gridControlMusteriler.MainView = this.gridMusteri;
            this.gridControlMusteriler.Name = "gridControlMusteriler";
            this.gridControlMusteriler.Size = new System.Drawing.Size(301, 284);
            this.gridControlMusteriler.TabIndex = 104;
            this.gridControlMusteriler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridMusteri});
            // 
            // gridMusteri
            // 
            this.gridMusteri.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridMusteri.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridMusteri.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridMusteri.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridMusteri.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridMusteri.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridMusteri.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gridMusteri.Appearance.OddRow.Options.UseBackColor = true;
            this.gridMusteri.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridMusteri.Appearance.Row.Options.UseFont = true;
            this.gridMusteri.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridMusteri.Appearance.ViewCaption.Options.UseFont = true;
            this.gridMusteri.GridControl = this.gridControlMusteriler;
            this.gridMusteri.Name = "gridMusteri";
            this.gridMusteri.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridMusteri.OptionsBehavior.Editable = false;
            this.gridMusteri.OptionsBehavior.ReadOnly = true;
            this.gridMusteri.OptionsCustomization.AllowGroup = false;
            this.gridMusteri.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.gridMusteri.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
            this.gridMusteri.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.gridMusteri.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.False;
            this.gridMusteri.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gridMusteri.OptionsView.ColumnAutoWidth = false;
            this.gridMusteri.OptionsView.EnableAppearanceEvenRow = true;
            this.gridMusteri.OptionsView.ShowGroupPanel = false;
            this.gridMusteri.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridMusteri_RowClick);
            this.gridMusteri.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridMusteri_FocusedRowChanged);
            // 
            // FrmMusteriSec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 321);
            this.Controls.Add(this.gridControlMusteriler);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmMusteriSec";
            this.Text = "Müşteri Seçimi";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FrmMusteriSec_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textBox1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMusteriler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMusteri)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit textBox1;
        private DevExpress.XtraGrid.GridControl gridControlMusteriler;
        private DevExpress.XtraGrid.Views.Grid.GridView gridMusteri;
    }
}