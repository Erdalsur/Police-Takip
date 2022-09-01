namespace Policem.UI.Forms
{
    partial class FrmPoliceTara
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
            DevExpress.Utils.ContextButton contextButton1 = new DevExpress.Utils.ContextButton();
            this.button1 = new System.Windows.Forms.Button();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.button2 = new System.Windows.Forms.Button();
            this.ımageSlider1 = new DevExpress.XtraEditors.Controls.ImageSlider();
            ((System.ComponentModel.ISupportInitialize)(this.ımageSlider1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sayfa Tara";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 41);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Kaydet";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // ımageSlider1
            // 
            contextButton1.Caption = "Sil";
            contextButton1.Id = new System.Guid("a5046b78-e175-4b46-9c4d-19d3e657a36c");
            contextButton1.ImageOptions.Image = global::Policem.UI.Properties.Resources.Delete;
            contextButton1.Name = "btnSayfaSil";
            this.ımageSlider1.ContextButtons.Add(contextButton1);
            this.ımageSlider1.Cursor = System.Windows.Forms.Cursors.Default;
            this.ımageSlider1.Location = new System.Drawing.Point(93, 3);
            this.ımageSlider1.Name = "ımageSlider1";
            this.ımageSlider1.Size = new System.Drawing.Size(628, 407);
            this.ımageSlider1.TabIndex = 3;
            this.ımageSlider1.Text = "ımageSlider1";
            this.ımageSlider1.ContextButtonClick += new DevExpress.Utils.ContextItemClickEventHandler(this.ımageSlider1_ContextButtonClick);
            // 
            // FrmPoliceTara
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 412);
            this.Controls.Add(this.ımageSlider1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(740, 450);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(740, 450);
            this.Name = "FrmPoliceTara";
            this.Text = "Police Tarama";
            this.Load += new System.EventHandler(this.FormTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ımageSlider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button button2;
        private DevExpress.XtraEditors.Controls.ImageSlider ımageSlider1;
    }
}