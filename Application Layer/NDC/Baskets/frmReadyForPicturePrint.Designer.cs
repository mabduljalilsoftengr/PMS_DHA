namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmReadyForPicturePrint
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.grdReadyForPicture = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReadyForPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReadyForPicture.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(6, 21);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(142, 50);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grdReadyForPicture
            // 
            this.grdReadyForPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdReadyForPicture.EnableKeyMap = true;
            this.grdReadyForPicture.Location = new System.Drawing.Point(5, 77);
            // 
            // 
            // 
            this.grdReadyForPicture.MasterTemplate.AllowAddNewRow = false;
            this.grdReadyForPicture.MasterTemplate.AllowColumnReorder = false;
            this.grdReadyForPicture.MasterTemplate.AllowSearchRow = true;
            this.grdReadyForPicture.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "NDCNo";
            gridViewTextBoxColumn1.HeaderText = "NDCNo";
            gridViewTextBoxColumn1.Name = "NDCNo";
            gridViewTextBoxColumn1.Width = 156;
            gridViewTextBoxColumn2.FieldName = "FileNo";
            gridViewTextBoxColumn2.HeaderText = "FileNo";
            gridViewTextBoxColumn2.Name = "FileNo";
            gridViewTextBoxColumn2.Width = 222;
            gridViewTextBoxColumn3.FieldName = "TransferNo";
            gridViewTextBoxColumn3.HeaderText = "Transfer No";
            gridViewTextBoxColumn3.Name = "TransferNo";
            gridViewTextBoxColumn3.Width = 169;
            gridViewTextBoxColumn4.FieldName = "PurchaseTypeID";
            gridViewTextBoxColumn4.HeaderText = "PurchaseTypeID";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "PurchaseTypeID";
            gridViewTextBoxColumn4.Width = 46;
            gridViewTextBoxColumn5.FieldName = "SellerMS_String";
            gridViewTextBoxColumn5.HeaderText = "SellerMS_String";
            gridViewTextBoxColumn5.IsVisible = false;
            gridViewTextBoxColumn5.Name = "SellerMS_String";
            gridViewTextBoxColumn5.Width = 46;
            gridViewTextBoxColumn6.FieldName = "BuyerMS_String";
            gridViewTextBoxColumn6.HeaderText = "BuyerMS_String";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "BuyerMS_String";
            gridViewTextBoxColumn6.Width = 46;
            gridViewCommandColumn1.DefaultText = "Print Img";
            gridViewCommandColumn1.FieldName = "btnImageReport";
            gridViewCommandColumn1.HeaderText = "Image Print";
            gridViewCommandColumn1.Name = "btnImageReport";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 137;
            gridViewCommandColumn2.DefaultText = "Go Next";
            gridViewCommandColumn2.FieldName = "btnNext";
            gridViewCommandColumn2.HeaderText = "Next >>";
            gridViewCommandColumn2.Name = "btnNext";
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 124;
            gridViewTextBoxColumn7.FieldName = "TFRAppoimtmentID";
            gridViewTextBoxColumn7.HeaderText = "TFRAppoimtmentID";
            gridViewTextBoxColumn7.IsVisible = false;
            gridViewTextBoxColumn7.Name = "TFRAppoimtmentID";
            gridViewTextBoxColumn7.Width = 47;
            gridViewTextBoxColumn8.FieldName = "RemainingDaysForExpiry";
            gridViewTextBoxColumn8.HeaderText = "RemainingDaysForExpiry";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "RemainingDaysForExpiry";
            gridViewTextBoxColumn8.Width = 47;
            gridViewCommandColumn3.DefaultText = "Back";
            gridViewCommandColumn3.FieldName = "btnBack";
            gridViewCommandColumn3.HeaderText = "<< Back";
            gridViewCommandColumn3.Name = "btnBack";
            gridViewCommandColumn3.UseDefaultText = true;
            gridViewCommandColumn3.Width = 64;
            this.grdReadyForPicture.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewCommandColumn1,
            gridViewCommandColumn2,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewCommandColumn3});
            this.grdReadyForPicture.MasterTemplate.EnableSorting = false;
            this.grdReadyForPicture.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdReadyForPicture.Name = "grdReadyForPicture";
            this.grdReadyForPicture.Size = new System.Drawing.Size(888, 626);
            this.grdReadyForPicture.TabIndex = 1;
            this.grdReadyForPicture.Text = "radGridView1";
            this.grdReadyForPicture.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdReadyForPicture_CellClick);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.btnRefresh);
            this.radGroupBox1.Controls.Add(this.grdReadyForPicture);
            this.radGroupBox1.HeaderText = "Ready For Picture";
            this.radGroupBox1.Location = new System.Drawing.Point(2, -1);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(898, 708);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "Ready For Picture";
            // 
            // frmReadyForPicturePrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 707);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmReadyForPicturePrint";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Picture Print";
            this.Load += new System.EventHandler(this.frmReadyForPicturePrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReadyForPicture.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReadyForPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnRefresh;
        private Telerik.WinControls.UI.RadGridView grdReadyForPicture;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    }
}
