namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmReadyForTFRVerification
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.btn_Refresh = new Telerik.WinControls.UI.RadButton();
            this.grdReadyForVerification = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReadyForVerification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReadyForVerification.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox2.Controls.Add(this.btn_Refresh);
            this.radGroupBox2.Controls.Add(this.grdReadyForVerification);
            this.radGroupBox2.HeaderText = "Ready For Verification";
            this.radGroupBox2.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(614, 708);
            this.radGroupBox2.TabIndex = 3;
            this.radGroupBox2.Text = "Ready For Verification";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Refresh.Location = new System.Drawing.Point(5, 21);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(138, 38);
            this.btn_Refresh.TabIndex = 2;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // grdReadyForVerification
            // 
            this.grdReadyForVerification.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdReadyForVerification.Location = new System.Drawing.Point(5, 65);
            // 
            // 
            // 
            this.grdReadyForVerification.MasterTemplate.AllowAddNewRow = false;
            this.grdReadyForVerification.MasterTemplate.AllowColumnReorder = false;
            this.grdReadyForVerification.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "NDCNo";
            gridViewTextBoxColumn1.HeaderText = "NDCNo";
            gridViewTextBoxColumn1.Name = "NDCNo";
            gridViewTextBoxColumn1.Width = 171;
            gridViewTextBoxColumn2.FieldName = "FileNo";
            gridViewTextBoxColumn2.HeaderText = "FileNo";
            gridViewTextBoxColumn2.Name = "FileNo";
            gridViewTextBoxColumn2.Width = 171;
            gridViewTextBoxColumn3.FieldName = "TransferNo";
            gridViewTextBoxColumn3.HeaderText = "Transfer No";
            gridViewTextBoxColumn3.Name = "TransferNo";
            gridViewTextBoxColumn3.Width = 153;
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
            gridViewCommandColumn1.DefaultText = "Verify";
            gridViewCommandColumn1.FieldName = "ReadyForVerification";
            gridViewCommandColumn1.HeaderText = "Verification";
            gridViewCommandColumn1.Name = "ReadyForVerification";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 91;
            this.grdReadyForVerification.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewCommandColumn1});
            this.grdReadyForVerification.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdReadyForVerification.Name = "grdReadyForVerification";
            this.grdReadyForVerification.Size = new System.Drawing.Size(604, 631);
            this.grdReadyForVerification.TabIndex = 1;
            this.grdReadyForVerification.Text = "radGridView1";
            this.grdReadyForVerification.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdReadyForVerification_CellClick);
            // 
            // frmReadyForTFRVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 723);
            this.Controls.Add(this.radGroupBox2);
            this.Name = "frmReadyForTFRVerification";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmReadyForTFRVerification";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmReadyForVerification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReadyForVerification.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReadyForVerification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGridView grdReadyForVerification;
        private Telerik.WinControls.UI.RadButton btn_Refresh;
    }
}
