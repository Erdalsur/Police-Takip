namespace Policem.Services
{
    partial class FormGelmeyenPoliceler
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
            this.gridControlPoliceler = new DevExpress.XtraGrid.GridControl();
            this.gridViewPoliceler = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPoliceler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPoliceler)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlPoliceler
            // 
            this.gridControlPoliceler.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlPoliceler.Location = new System.Drawing.Point(0, 0);
            this.gridControlPoliceler.MainView = this.gridViewPoliceler;
            this.gridControlPoliceler.Name = "gridControlPoliceler";
            this.gridControlPoliceler.Size = new System.Drawing.Size(800, 450);
            this.gridControlPoliceler.TabIndex = 107;
            this.gridControlPoliceler.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPoliceler});
            // 
            // gridViewPoliceler
            // 
            this.gridViewPoliceler.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridViewPoliceler.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridViewPoliceler.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridViewPoliceler.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridViewPoliceler.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridViewPoliceler.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.gridViewPoliceler.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.gridViewPoliceler.Appearance.OddRow.Options.UseBackColor = true;
            this.gridViewPoliceler.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridViewPoliceler.Appearance.Row.Options.UseFont = true;
            this.gridViewPoliceler.Appearance.ViewCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridViewPoliceler.Appearance.ViewCaption.Options.UseFont = true;
            this.gridViewPoliceler.GridControl = this.gridControlPoliceler;
            this.gridViewPoliceler.Name = "gridViewPoliceler";
            this.gridViewPoliceler.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridViewPoliceler.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridViewPoliceler.OptionsBehavior.Editable = false;
            this.gridViewPoliceler.OptionsBehavior.ReadOnly = true;
            this.gridViewPoliceler.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPoliceler.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPoliceler.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPoliceler.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.False;
            this.gridViewPoliceler.OptionsPrint.EnableAppearanceEvenRow = true;
            this.gridViewPoliceler.OptionsView.AutoCalcPreviewLineCount = true;
            this.gridViewPoliceler.OptionsView.ColumnAutoWidth = false;
            this.gridViewPoliceler.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewPoliceler.OptionsView.ShowGroupPanel = false;
            // 
            // FormGelmeyenPoliceler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gridControlPoliceler);
            this.Name = "FormGelmeyenPoliceler";
            this.Text = "FormGelmeyenPoliceler";
            this.Load += new System.EventHandler(this.FormGelmeyenPoliceler_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlPoliceler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPoliceler)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public DevExpress.XtraGrid.GridControl gridControlPoliceler;
        public DevExpress.XtraGrid.Views.Grid.GridView gridViewPoliceler;
    }
}