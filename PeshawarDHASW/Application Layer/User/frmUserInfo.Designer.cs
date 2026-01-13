namespace PeshawarDHASW.Application_Layer.User
{
    partial class frmUserInfo
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
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn1 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.rgvUserInfo = new Telerik.WinControls.UI.RadGridView();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.rgvUserInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvUserInfo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // rgvUserInfo
            // 
            this.rgvUserInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rgvUserInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.rgvUserInfo.Cursor = System.Windows.Forms.Cursors.Default;
            this.rgvUserInfo.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.rgvUserInfo.ForeColor = System.Drawing.Color.Black;
            this.rgvUserInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.rgvUserInfo.Location = new System.Drawing.Point(1, 30);
            // 
            // 
            // 
            this.rgvUserInfo.MasterTemplate.AllowAddNewRow = false;
            this.rgvUserInfo.MasterTemplate.AllowColumnReorder = false;
            this.rgvUserInfo.MasterTemplate.AllowSearchRow = true;
            gridViewCommandColumn1.DefaultText = "Change";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "Signature";
            gridViewCommandColumn1.HeaderText = "Signature";
            gridViewCommandColumn1.Name = "Signature";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 101;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "ID";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Branch";
            gridViewTextBoxColumn2.HeaderText = "Branch";
            gridViewTextBoxColumn2.Name = "Branch";
            gridViewTextBoxColumn2.Width = 131;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "username";
            gridViewTextBoxColumn3.HeaderText = "Username";
            gridViewTextBoxColumn3.Name = "username";
            gridViewTextBoxColumn3.Width = 117;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "Name";
            gridViewTextBoxColumn4.HeaderText = "Employee Name";
            gridViewTextBoxColumn4.Name = "User_Name";
            gridViewTextBoxColumn4.Width = 109;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Father";
            gridViewTextBoxColumn5.HeaderText = "Father";
            gridViewTextBoxColumn5.Name = "Father";
            gridViewTextBoxColumn5.Width = 118;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "Email";
            gridViewTextBoxColumn6.HeaderText = "Email";
            gridViewTextBoxColumn6.Name = "Email";
            gridViewTextBoxColumn6.Width = 169;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "Mobile";
            gridViewTextBoxColumn7.HeaderText = "Mobile";
            gridViewTextBoxColumn7.Name = "Mobile";
            gridViewTextBoxColumn7.Width = 146;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Phone";
            gridViewTextBoxColumn8.HeaderText = "Phone";
            gridViewTextBoxColumn8.Name = "Phone";
            gridViewTextBoxColumn8.Width = 144;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "Address";
            gridViewTextBoxColumn9.HeaderText = "Address";
            gridViewTextBoxColumn9.Name = "Address";
            gridViewTextBoxColumn9.Width = 162;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "status";
            gridViewTextBoxColumn10.HeaderText = "Status";
            gridViewTextBoxColumn10.Name = "status";
            gridViewTextBoxColumn10.Width = 152;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "Secret_Code";
            gridViewTextBoxColumn11.HeaderText = "Secret Code";
            gridViewTextBoxColumn11.Name = "Secret_Code";
            gridViewTextBoxColumn11.Width = 123;
            gridViewImageColumn1.EnableExpressionEditor = false;
            gridViewImageColumn1.FieldName = "signatureImage";
            gridViewImageColumn1.HeaderText = "Signature";
            gridViewImageColumn1.Name = "signatureImage";
            gridViewImageColumn1.Width = 185;
            this.rgvUserInfo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            gridViewImageColumn1});
            this.rgvUserInfo.MasterTemplate.EnableFiltering = true;
            this.rgvUserInfo.MasterTemplate.EnableGrouping = false;
            this.rgvUserInfo.MasterTemplate.EnableSorting = false;
            this.rgvUserInfo.MasterTemplate.ShowFilteringRow = false;
            this.rgvUserInfo.MasterTemplate.ShowHeaderCellButtons = true;
            this.rgvUserInfo.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rgvUserInfo.Name = "rgvUserInfo";
            this.rgvUserInfo.ReadOnly = true;
            this.rgvUserInfo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rgvUserInfo.ShowGroupPanel = false;
            this.rgvUserInfo.ShowHeaderCellButtons = true;
            this.rgvUserInfo.Size = new System.Drawing.Size(1098, 442);
            this.rgvUserInfo.TabIndex = 0;
            this.rgvUserInfo.Text = "radGridView1";
            this.rgvUserInfo.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rgvUserInfo_CellClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(110, 24);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 472);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.rgvUserInfo);
            this.Name = "frmUserInfo";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmUserInfo";
            this.Load += new System.EventHandler(this.frmUserInfo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rgvUserInfo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rgvUserInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView rgvUserInfo;
        private Telerik.WinControls.UI.RadButton btnRefresh;
    }
}
