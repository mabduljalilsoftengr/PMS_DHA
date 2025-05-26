namespace PeshawarDHASW.Application_Layer.AuthorizedDealer
{
    partial class frmPropetyDealerDetail
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdPropertyDealerDetail = new Telerik.WinControls.UI.RadGridView();
            this.btnResresh = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdPropertyDealerDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPropertyDealerDetail.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnResresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdPropertyDealerDetail
            // 
            this.grdPropertyDealerDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPropertyDealerDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdPropertyDealerDetail.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdPropertyDealerDetail.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grdPropertyDealerDetail.ForeColor = System.Drawing.Color.Black;
            this.grdPropertyDealerDetail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdPropertyDealerDetail.Location = new System.Drawing.Point(3, 46);
            // 
            // 
            // 
            this.grdPropertyDealerDetail.MasterTemplate.AllowAddNewRow = false;
            this.grdPropertyDealerDetail.MasterTemplate.AllowColumnReorder = false;
            this.grdPropertyDealerDetail.MasterTemplate.AllowSearchRow = true;
            this.grdPropertyDealerDetail.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "ID";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "RegnNo";
            gridViewTextBoxColumn2.HeaderText = "Reg No";
            gridViewTextBoxColumn2.Name = "RegnNo";
            gridViewTextBoxColumn2.Width = 102;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "DealerName1";
            gridViewTextBoxColumn3.HeaderText = "Dealer Name";
            gridViewTextBoxColumn3.Name = "DealerName1";
            gridViewTextBoxColumn3.Width = 102;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "CNICNo1";
            gridViewTextBoxColumn4.HeaderText = "CNIC No.";
            gridViewTextBoxColumn4.Name = "CNICNo1";
            gridViewTextBoxColumn4.Width = 102;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "BussinessTitle";
            gridViewTextBoxColumn5.HeaderText = "Bussiness Title";
            gridViewTextBoxColumn5.Name = "BussinessTitle";
            gridViewTextBoxColumn5.Width = 102;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "BussinessAddress";
            gridViewTextBoxColumn6.HeaderText = "Bussiness Address";
            gridViewTextBoxColumn6.Name = "BussinessAddress";
            gridViewTextBoxColumn6.Width = 102;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "ContactNumber1";
            gridViewTextBoxColumn7.HeaderText = "Contact Number";
            gridViewTextBoxColumn7.Name = "ContactNumber1";
            gridViewTextBoxColumn7.Width = 102;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "EmailAddress1";
            gridViewTextBoxColumn8.HeaderText = "Email Address";
            gridViewTextBoxColumn8.Name = "EmailAddress1";
            gridViewTextBoxColumn8.Width = 102;
            gridViewCommandColumn1.DefaultText = "Detail";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "btnShowPaymentDetail";
            gridViewCommandColumn1.HeaderText = "Payment Detail";
            gridViewCommandColumn1.Name = "btnShowPaymentDetail";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 101;
            this.grdPropertyDealerDetail.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewCommandColumn1});
            this.grdPropertyDealerDetail.MasterTemplate.EnableFiltering = true;
            this.grdPropertyDealerDetail.MasterTemplate.EnableGrouping = false;
            this.grdPropertyDealerDetail.MasterTemplate.EnableSorting = false;
            this.grdPropertyDealerDetail.MasterTemplate.ShowFilteringRow = false;
            this.grdPropertyDealerDetail.MasterTemplate.ShowHeaderCellButtons = true;
            this.grdPropertyDealerDetail.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdPropertyDealerDetail.Name = "grdPropertyDealerDetail";
            this.grdPropertyDealerDetail.ReadOnly = true;
            this.grdPropertyDealerDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdPropertyDealerDetail.ShowGroupPanel = false;
            this.grdPropertyDealerDetail.ShowHeaderCellButtons = true;
            this.grdPropertyDealerDetail.Size = new System.Drawing.Size(829, 351);
            this.grdPropertyDealerDetail.TabIndex = 0;
            this.grdPropertyDealerDetail.Text = "radGridView1";
            this.grdPropertyDealerDetail.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdPropertyDealerDetail_CellClick);
            // 
            // btnResresh
            // 
            this.btnResresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResresh.Location = new System.Drawing.Point(5, 8);
            this.btnResresh.Name = "btnResresh";
            this.btnResresh.Size = new System.Drawing.Size(160, 32);
            this.btnResresh.TabIndex = 1;
            this.btnResresh.Text = "Refresh";
            this.btnResresh.Click += new System.EventHandler(this.btnResresh_Click);
            // 
            // frmPropetyDealerDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 398);
            this.Controls.Add(this.btnResresh);
            this.Controls.Add(this.grdPropertyDealerDetail);
            this.Name = "frmPropetyDealerDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmPropetyDealerDetail";
            this.Load += new System.EventHandler(this.frmPropetyDealerDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPropertyDealerDetail.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPropertyDealerDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnResresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdPropertyDealerDetail;
        private Telerik.WinControls.UI.RadButton btnResresh;
    }
}
