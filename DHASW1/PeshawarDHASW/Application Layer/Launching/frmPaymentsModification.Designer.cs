namespace PeshawarDHASW.Application_Layer.Launching
{
    partial class frmPaymentsModification
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.btnLoadButton = new Telerik.WinControls.UI.RadButton();
            this.grdDatagrid = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatagrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatagrid.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadButton
            // 
            this.btnLoadButton.Location = new System.Drawing.Point(5, 10);
            this.btnLoadButton.Name = "btnLoadButton";
            this.btnLoadButton.Size = new System.Drawing.Size(321, 43);
            this.btnLoadButton.TabIndex = 2;
            this.btnLoadButton.Text = "Load data";
            this.btnLoadButton.Click += new System.EventHandler(this.btnLoadButton_Click);
            // 
            // grdDatagrid
            // 
            this.grdDatagrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdDatagrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdDatagrid.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdDatagrid.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grdDatagrid.ForeColor = System.Drawing.Color.Black;
            this.grdDatagrid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdDatagrid.Location = new System.Drawing.Point(5, 60);
            // 
            // 
            // 
            this.grdDatagrid.MasterTemplate.AllowAddNewRow = false;
            this.grdDatagrid.MasterTemplate.AllowColumnReorder = false;
            this.grdDatagrid.MasterTemplate.AllowSearchRow = true;
            this.grdDatagrid.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewCommandColumn1.DefaultText = "Edit";
            gridViewCommandColumn1.FieldName = "btnEdit";
            gridViewCommandColumn1.HeaderText = "Edit";
            gridViewCommandColumn1.Name = "btnEdit";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 91;
            gridViewTextBoxColumn1.FieldName = "ApplicationFeeID";
            gridViewTextBoxColumn1.HeaderText = "ApplicationFeeID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "ApplicationFeeID";
            gridViewTextBoxColumn2.FieldName = "BankTRXID";
            gridViewTextBoxColumn2.HeaderText = "BankTRXID";
            gridViewTextBoxColumn2.Name = "BankTRXID";
            gridViewTextBoxColumn2.Width = 91;
            gridViewTextBoxColumn3.FieldName = "DepositSlipNo";
            gridViewTextBoxColumn3.HeaderText = "DepositSlipNo";
            gridViewTextBoxColumn3.Name = "DepositSlipNo";
            gridViewTextBoxColumn3.Width = 91;
            gridViewTextBoxColumn4.FieldName = "PlotSize";
            gridViewTextBoxColumn4.HeaderText = "PlotSize";
            gridViewTextBoxColumn4.Name = "PlotSize";
            gridViewTextBoxColumn4.Width = 91;
            gridViewTextBoxColumn5.FieldName = "CNIC_NICOP";
            gridViewTextBoxColumn5.HeaderText = "CNIC_NICOP";
            gridViewTextBoxColumn5.Name = "CNIC_NICOP";
            gridViewTextBoxColumn5.Width = 91;
            gridViewTextBoxColumn6.FieldName = "MobileNo";
            gridViewTextBoxColumn6.HeaderText = "MobileNo";
            gridViewTextBoxColumn6.Name = "MobileNo";
            gridViewTextBoxColumn6.Width = 91;
            gridViewTextBoxColumn7.FieldName = "Amount";
            gridViewTextBoxColumn7.HeaderText = "Amount";
            gridViewTextBoxColumn7.Name = "Amount";
            gridViewTextBoxColumn7.Width = 91;
            gridViewTextBoxColumn8.FieldName = "Status";
            gridViewTextBoxColumn8.HeaderText = "Status";
            gridViewTextBoxColumn8.Name = "Status";
            gridViewTextBoxColumn8.Width = 91;
            gridViewTextBoxColumn9.FieldName = "PaymentMode";
            gridViewTextBoxColumn9.HeaderText = "PaymentMode";
            gridViewTextBoxColumn9.Name = "PaymentMode";
            gridViewTextBoxColumn9.Width = 91;
            gridViewTextBoxColumn10.FieldName = "BankName";
            gridViewTextBoxColumn10.HeaderText = "BankName";
            gridViewTextBoxColumn10.Name = "BankName";
            gridViewTextBoxColumn10.Width = 91;
            gridViewTextBoxColumn11.FieldName = "BranchCode";
            gridViewTextBoxColumn11.HeaderText = "BranchCode";
            gridViewTextBoxColumn11.Name = "BranchCode";
            gridViewTextBoxColumn11.Width = 91;
            gridViewTextBoxColumn12.FieldName = "Category";
            gridViewTextBoxColumn12.HeaderText = "Category";
            gridViewTextBoxColumn12.Name = "Category";
            gridViewTextBoxColumn12.Width = 91;
            gridViewTextBoxColumn13.FieldName = "ApplicantName";
            gridViewTextBoxColumn13.HeaderText = "ApplicantName";
            gridViewTextBoxColumn13.Name = "ApplicantName";
            gridViewTextBoxColumn13.Width = 87;
            this.grdDatagrid.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewCommandColumn1,
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13});
            this.grdDatagrid.MasterTemplate.EnableAlternatingRowColor = true;
            this.grdDatagrid.MasterTemplate.EnableFiltering = true;
            this.grdDatagrid.MasterTemplate.EnableSorting = false;
            this.grdDatagrid.MasterTemplate.ShowFilterCellOperatorText = false;
            this.grdDatagrid.MasterTemplate.ShowFilteringRow = false;
            this.grdDatagrid.MasterTemplate.ShowHeaderCellButtons = true;
            this.grdDatagrid.MasterTemplate.ShowTotals = true;
            this.grdDatagrid.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdDatagrid.Name = "grdDatagrid";
            this.grdDatagrid.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdDatagrid.ShowHeaderCellButtons = true;
            this.grdDatagrid.Size = new System.Drawing.Size(1188, 697);
            this.grdDatagrid.TabIndex = 4;
            this.grdDatagrid.Text = "radGridView1";
            this.grdDatagrid.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdDatagrid_CellClick);
            // 
            // frmPaymentsModification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1196, 761);
            this.Controls.Add(this.grdDatagrid);
            this.Controls.Add(this.btnLoadButton);
            this.Name = "frmPaymentsModification";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmPaymentsModification";
            ((System.ComponentModel.ISupportInitialize)(this.btnLoadButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatagrid.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDatagrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnLoadButton;
        private Telerik.WinControls.UI.RadGridView grdDatagrid;
    }
}
