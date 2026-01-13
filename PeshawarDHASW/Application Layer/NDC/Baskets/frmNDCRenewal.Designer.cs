namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmNDCRenewal
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdExpireNDCData = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdExpireNDCData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExpireNDCData.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdExpireNDCData
            // 
            this.grdExpireNDCData.EnableKeyMap = true;
            this.grdExpireNDCData.Location = new System.Drawing.Point(5, 82);
            // 
            // 
            // 
            this.grdExpireNDCData.MasterTemplate.AllowSearchRow = true;
            this.grdExpireNDCData.MasterTemplate.AutoGenerateColumns = false;
            this.grdExpireNDCData.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "NDCNo";
            gridViewTextBoxColumn1.HeaderText = "NDCNo";
            gridViewTextBoxColumn1.Name = "NDCNo";
            gridViewTextBoxColumn1.Width = 78;
            gridViewTextBoxColumn2.FieldName = "FilePlotNo";
            gridViewTextBoxColumn2.HeaderText = "File No";
            gridViewTextBoxColumn2.Name = "FilePlotNo";
            gridViewTextBoxColumn2.Width = 153;
            gridViewTextBoxColumn3.FieldName = "StatusofNDC";
            gridViewTextBoxColumn3.HeaderText = "Status";
            gridViewTextBoxColumn3.Name = "StatusofNDC";
            gridViewTextBoxColumn3.Width = 153;
            gridViewCommandColumn1.DefaultText = "Generate Challan";
            gridViewCommandColumn1.FieldName = "btnGenerateRenChallan";
            gridViewCommandColumn1.HeaderText = "Generate Renewal Challan";
            gridViewCommandColumn1.Name = "btnGenerateRenChallan";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 147;
            gridViewCommandColumn2.DefaultText = "Renew";
            gridViewCommandColumn2.FieldName = "btnRenewNDC";
            gridViewCommandColumn2.HeaderText = "Renew NDC";
            gridViewCommandColumn2.Name = "btnRenewNDC";
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 128;
            this.grdExpireNDCData.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.grdExpireNDCData.MasterTemplate.EnableFiltering = true;
            this.grdExpireNDCData.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdExpireNDCData.Name = "grdExpireNDCData";
            this.grdExpireNDCData.Size = new System.Drawing.Size(676, 602);
            this.grdExpireNDCData.TabIndex = 1;
            this.grdExpireNDCData.Text = "radGridView1";
            this.grdExpireNDCData.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdExpireNDCData_CellClick);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnRefresh);
            this.radGroupBox1.Controls.Add(this.grdExpireNDCData);
            this.radGroupBox1.HeaderText = "Expired NDC\'s";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(686, 689);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "Expired NDC\'s";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(5, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(166, 55);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmNDCRenewal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(690, 690);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmNDCRenewal";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmNDCRenewal";
            this.Load += new System.EventHandler(this.frmNDCRenewal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdExpireNDCData.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdExpireNDCData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdExpireNDCData;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnRefresh;
    }
}
