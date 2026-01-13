namespace PeshawarDHASW.Application_Layer.Membership.Modify
{
    partial class frm_DirTransferDashBoard
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.grdIncompleteMembership = new Telerik.WinControls.UI.RadGridView();
            this.lbltotalentries = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIncompleteMembership)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIncompleteMembership.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbltotalentries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radLabel2);
            this.groupBox1.Controls.Add(this.lbltotalentries);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.grdIncompleteMembership);
            this.groupBox1.Location = new System.Drawing.Point(0, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(620, 623);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(2, 9);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(139, 51);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // grdIncompleteMembership
            // 
            this.grdIncompleteMembership.Location = new System.Drawing.Point(0, 63);
            // 
            // 
            // 
            this.grdIncompleteMembership.MasterTemplate.AllowAddNewRow = false;
            this.grdIncompleteMembership.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn6.FieldName = "MembershipNo";
            gridViewTextBoxColumn6.HeaderText = "Membership No";
            gridViewTextBoxColumn6.Name = "MembershipNo";
            gridViewTextBoxColumn6.Width = 121;
            gridViewTextBoxColumn7.FieldName = "File/Plot/Shop/Villa/ApartmentNo";
            gridViewTextBoxColumn7.HeaderText = "File No";
            gridViewTextBoxColumn7.Name = "File/Plot/Shop/Villa/ApartmentNo";
            gridViewTextBoxColumn7.Width = 121;
            gridViewTextBoxColumn8.FieldName = "Name";
            gridViewTextBoxColumn8.HeaderText = "Name";
            gridViewTextBoxColumn8.Name = "Name";
            gridViewTextBoxColumn8.Width = 121;
            gridViewTextBoxColumn9.FieldName = "NIC/NICOP";
            gridViewTextBoxColumn9.HeaderText = "NIC No";
            gridViewTextBoxColumn9.Name = "NIC/NICOP";
            gridViewTextBoxColumn9.Width = 121;
            gridViewTextBoxColumn10.FieldName = "PresentAddress";
            gridViewTextBoxColumn10.HeaderText = "Present Address";
            gridViewTextBoxColumn10.Name = "PresentAddress";
            gridViewTextBoxColumn10.Width = 119;
            this.grdIncompleteMembership.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.grdIncompleteMembership.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdIncompleteMembership.Name = "grdIncompleteMembership";
            this.grdIncompleteMembership.Size = new System.Drawing.Size(620, 558);
            this.grdIncompleteMembership.TabIndex = 0;
            this.grdIncompleteMembership.Text = "radGridView1";
            // 
            // lbltotalentries
            // 
            this.lbltotalentries.Location = new System.Drawing.Point(422, 31);
            this.lbltotalentries.Name = "lbltotalentries";
            this.lbltotalentries.Size = new System.Drawing.Size(13, 18);
            this.lbltotalentries.TabIndex = 2;
            this.lbltotalentries.Text = "#";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(227, 31);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(189, 18);
            this.radLabel2.TabIndex = 3;
            this.radLabel2.Text = "Total Remaining Incomplete Entries :";
            // 
            // frm_DirTransferDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(622, 624);
            this.Controls.Add(this.groupBox1);
            this.Name = "frm_DirTransferDashBoard";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frm_DirTransferDashBoard";
            this.Load += new System.EventHandler(this.frm_DirTransferDashBoard_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIncompleteMembership.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdIncompleteMembership)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lbltotalentries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadGridView grdIncompleteMembership;
        private Telerik.WinControls.UI.RadButton btnRefresh;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel lbltotalentries;
    }
}
