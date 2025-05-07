namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    partial class frmLandProviderQuoaDetail
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.grddatadetail = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnloaddata = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grddatadetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grddatadetail.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnloaddata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.grddatadetail);
            this.radGroupBox1.HeaderText = "Detail";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 86);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(843, 588);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Detail";
            // 
            // grddatadetail
            // 
            this.grddatadetail.Location = new System.Drawing.Point(13, 26);
            // 
            // 
            // 
            this.grddatadetail.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn5.FieldName = "LPID";
            gridViewTextBoxColumn5.HeaderText = "LPID";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "LPID";
            gridViewTextBoxColumn5.Width = 115;
            gridViewTextBoxColumn6.FieldName = "TotalByBack";
            gridViewTextBoxColumn6.HeaderText = "Total By Back";
            gridViewTextBoxColumn6.Name = "TotalByBack";
            gridViewTextBoxColumn6.Width = 169;
            gridViewTextBoxColumn7.FieldName = "Name";
            gridViewTextBoxColumn7.HeaderText = "Name";
            gridViewTextBoxColumn7.Name = "Name";
            gridViewTextBoxColumn7.Width = 238;
            gridViewTextBoxColumn8.FieldName = "CNIC";
            gridViewTextBoxColumn8.HeaderText = "CNIC";
            gridViewTextBoxColumn8.Name = "CNIC";
            gridViewTextBoxColumn8.Width = 269;
            gridViewCommandColumn2.DefaultText = "Detail";
            gridViewCommandColumn2.FieldName = "btnDetail";
            gridViewCommandColumn2.HeaderText = "Detail";
            gridViewCommandColumn2.Name = "btnDetail";
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 124;
            this.grddatadetail.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewCommandColumn2});
            this.grddatadetail.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grddatadetail.Name = "grddatadetail";
            this.grddatadetail.Size = new System.Drawing.Size(818, 552);
            this.grddatadetail.TabIndex = 0;
            this.grddatadetail.Text = "radGridView1";
            this.grddatadetail.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grddatadetail_CellClick);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.btnloaddata);
            this.radGroupBox2.HeaderText = "Load Data";
            this.radGroupBox2.Location = new System.Drawing.Point(12, 3);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(843, 77);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Load Data";
            // 
            // btnloaddata
            // 
            this.btnloaddata.Location = new System.Drawing.Point(14, 21);
            this.btnloaddata.Name = "btnloaddata";
            this.btnloaddata.Size = new System.Drawing.Size(274, 44);
            this.btnloaddata.TabIndex = 0;
            this.btnloaddata.Text = "Load Data";
            this.btnloaddata.Click += new System.EventHandler(this.btnloaddata_Click);
            // 
            // frmLandProviderQuoaDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(867, 676);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmLandProviderQuoaDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmLandProviderQuoaDetail";
            this.Load += new System.EventHandler(this.frmLandProviderQuoaDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grddatadetail.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grddatadetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnloaddata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grddatadetail;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadButton btnloaddata;
    }
}
