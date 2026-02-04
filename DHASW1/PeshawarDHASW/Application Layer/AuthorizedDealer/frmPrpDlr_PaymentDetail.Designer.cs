namespace PeshawarDHASW.Application_Layer.AuthorizedDealer
{
    partial class frmPrpDlr_PaymentDetail
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdPaymentDetail = new Telerik.WinControls.UI.RadGridView();
            this.radActive = new Telerik.WinControls.UI.RadRadioButton();
            this.radInActive = new Telerik.WinControls.UI.RadRadioButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnChangeStatus = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentDetail.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radInActive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnChangeStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdPaymentDetail
            // 
            this.grdPaymentDetail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdPaymentDetail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grdPaymentDetail.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdPaymentDetail.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grdPaymentDetail.ForeColor = System.Drawing.Color.Black;
            this.grdPaymentDetail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdPaymentDetail.Location = new System.Drawing.Point(1, 49);
            // 
            // 
            // 
            this.grdPaymentDetail.MasterTemplate.AllowAddNewRow = false;
            this.grdPaymentDetail.MasterTemplate.AllowColumnReorder = false;
            this.grdPaymentDetail.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "ChallanID";
            gridViewTextBoxColumn9.HeaderText = "ChallanID";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "ChallanID";
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "RegistrationDate";
            gridViewTextBoxColumn10.HeaderText = "Registration Date";
            gridViewTextBoxColumn10.Name = "RegistrationDate";
            gridViewTextBoxColumn10.Width = 67;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "CreateDate";
            gridViewTextBoxColumn11.HeaderText = "Create Date";
            gridViewTextBoxColumn11.Name = "CreateDate";
            gridViewTextBoxColumn11.Width = 113;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "Name";
            gridViewTextBoxColumn12.HeaderText = "Name";
            gridViewTextBoxColumn12.Name = "Name";
            gridViewTextBoxColumn12.Width = 113;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "CNIC";
            gridViewTextBoxColumn13.HeaderText = "CNIC";
            gridViewTextBoxColumn13.Name = "CNIC";
            gridViewTextBoxColumn13.Width = 113;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.FieldName = "ChalanNo";
            gridViewTextBoxColumn14.HeaderText = "Challan No";
            gridViewTextBoxColumn14.Name = "ChalanNo";
            gridViewTextBoxColumn14.Width = 113;
            gridViewTextBoxColumn15.EnableExpressionEditor = false;
            gridViewTextBoxColumn15.FieldName = "TotalAmount";
            gridViewTextBoxColumn15.HeaderText = "Total Amount";
            gridViewTextBoxColumn15.Name = "TotalAmount";
            gridViewTextBoxColumn15.Width = 113;
            gridViewTextBoxColumn16.EnableExpressionEditor = false;
            gridViewTextBoxColumn16.FieldName = "Particular";
            gridViewTextBoxColumn16.HeaderText = "Particular";
            gridViewTextBoxColumn16.Name = "Particular";
            gridViewTextBoxColumn16.Width = 72;
            this.grdPaymentDetail.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16});
            this.grdPaymentDetail.MasterTemplate.EnableGrouping = false;
            this.grdPaymentDetail.MasterTemplate.EnableSorting = false;
            this.grdPaymentDetail.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdPaymentDetail.Name = "grdPaymentDetail";
            this.grdPaymentDetail.ReadOnly = true;
            this.grdPaymentDetail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdPaymentDetail.Size = new System.Drawing.Size(719, 351);
            this.grdPaymentDetail.TabIndex = 0;
            this.grdPaymentDetail.Text = "radGridView1";
            // 
            // radActive
            // 
            this.radActive.Location = new System.Drawing.Point(14, 17);
            this.radActive.Name = "radActive";
            this.radActive.Size = new System.Drawing.Size(51, 18);
            this.radActive.TabIndex = 1;
            this.radActive.Text = "Active";
            // 
            // radInActive
            // 
            this.radInActive.Location = new System.Drawing.Point(80, 16);
            this.radInActive.Name = "radInActive";
            this.radInActive.Size = new System.Drawing.Size(65, 18);
            this.radInActive.TabIndex = 2;
            this.radInActive.Text = "In-Active";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radInActive);
            this.radGroupBox1.Controls.Add(this.radActive);
            this.radGroupBox1.HeaderText = "Status";
            this.radGroupBox1.Location = new System.Drawing.Point(2, 1);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(153, 42);
            this.radGroupBox1.TabIndex = 3;
            this.radGroupBox1.Text = "Status";
            // 
            // btnChangeStatus
            // 
            this.btnChangeStatus.Location = new System.Drawing.Point(172, 12);
            this.btnChangeStatus.Name = "btnChangeStatus";
            this.btnChangeStatus.Size = new System.Drawing.Size(110, 30);
            this.btnChangeStatus.TabIndex = 4;
            this.btnChangeStatus.Text = "Change Status";
            this.btnChangeStatus.Click += new System.EventHandler(this.btnChangeStatus_Click);
            // 
            // frmPrpDlr_PaymentDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 404);
            this.Controls.Add(this.btnChangeStatus);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.grdPaymentDetail);
            this.Name = "frmPrpDlr_PaymentDetail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmPrpDlr_PaymentDetail";
            this.Load += new System.EventHandler(this.frmPrpDlr_PaymentDetail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentDetail.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPaymentDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radInActive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnChangeStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdPaymentDetail;
        private Telerik.WinControls.UI.RadRadioButton radActive;
        private Telerik.WinControls.UI.RadRadioButton radInActive;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnChangeStatus;
    }
}
