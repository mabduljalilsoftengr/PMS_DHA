namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmReadyForMembership
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdNDC_FileNo = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdReady_For_Membership = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            this.radGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNDC_FileNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNDC_FileNo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReady_For_Membership)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReady_For_Membership.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnRefresh);
            this.radGroupBox1.Controls.Add(this.radGroupBox4);
            this.radGroupBox1.Controls.Add(this.radGroupBox2);
            this.radGroupBox1.HeaderText = "Basket Main";
            this.radGroupBox1.Location = new System.Drawing.Point(21, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1018, 770);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "Basket Main";
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(20, 34);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(170, 52);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refrsh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.Controls.Add(this.grdNDC_FileNo);
            this.radGroupBox4.HeaderText = "Total New Members(Buyers of File) against NDC";
            this.radGroupBox4.Location = new System.Drawing.Point(372, 34);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.Size = new System.Drawing.Size(347, 665);
            this.radGroupBox4.TabIndex = 5;
            this.radGroupBox4.Text = "Total New Members(Buyers of File) against NDC";
            this.radGroupBox4.Visible = false;
            // 
            // grdNDC_FileNo
            // 
            this.grdNDC_FileNo.Location = new System.Drawing.Point(0, 21);
            // 
            // 
            // 
            this.grdNDC_FileNo.MasterTemplate.AllowAddNewRow = false;
            this.grdNDC_FileNo.MasterTemplate.AllowColumnReorder = false;
            this.grdNDC_FileNo.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "NDCNo";
            gridViewTextBoxColumn1.HeaderText = "NDCNo";
            gridViewTextBoxColumn1.Name = "NDCNo";
            gridViewTextBoxColumn1.Width = 68;
            gridViewTextBoxColumn2.FieldName = "FilePlotNo";
            gridViewTextBoxColumn2.HeaderText = "FileNo";
            gridViewTextBoxColumn2.Name = "FilePlotNo";
            gridViewTextBoxColumn2.Width = 103;
            gridViewTextBoxColumn3.FieldName = "Total_Members";
            gridViewTextBoxColumn3.HeaderText = "Total Members";
            gridViewTextBoxColumn3.Name = "Total_Members";
            gridViewTextBoxColumn3.Width = 55;
            gridViewCommandColumn1.DefaultText = "Next >>";
            gridViewCommandColumn1.FieldName = "Next_To_TFRAppointment";
            gridViewCommandColumn1.HeaderText = "Next To TFR App >>";
            gridViewCommandColumn1.Name = "Next_To_TFRAppointment";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 74;
            this.grdNDC_FileNo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewCommandColumn1});
            this.grdNDC_FileNo.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdNDC_FileNo.Name = "grdNDC_FileNo";
            this.grdNDC_FileNo.Size = new System.Drawing.Size(318, 718);
            this.grdNDC_FileNo.TabIndex = 1;
            this.grdNDC_FileNo.Text = "radGridView2";
            this.grdNDC_FileNo.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdNDC_FileNo_CellClick);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.grdReady_For_Membership);
            this.radGroupBox2.HeaderText = "Ready For Membership";
            this.radGroupBox2.Location = new System.Drawing.Point(15, 100);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(351, 665);
            this.radGroupBox2.TabIndex = 3;
            this.radGroupBox2.Text = "Ready For Membership";
            // 
            // grdReady_For_Membership
            // 
            this.grdReady_For_Membership.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.grdReady_For_Membership.MasterTemplate.AllowAddNewRow = false;
            this.grdReady_For_Membership.MasterTemplate.AllowColumnReorder = false;
            this.grdReady_For_Membership.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn4.FieldName = "NDCNo";
            gridViewTextBoxColumn4.HeaderText = "NDCNo";
            gridViewTextBoxColumn4.Name = "NDCNo";
            gridViewTextBoxColumn4.Width = 117;
            gridViewTextBoxColumn5.FieldName = "FileNo";
            gridViewTextBoxColumn5.HeaderText = "FileNo";
            gridViewTextBoxColumn5.Name = "FileNo";
            gridViewTextBoxColumn5.Width = 118;
            gridViewCommandColumn2.DefaultText = "Creat";
            gridViewCommandColumn2.FieldName = "Rady_Membr_Forward";
            gridViewCommandColumn2.HeaderText = "MS Creat";
            gridViewCommandColumn2.Name = "Rady_Membr_Forward";
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 87;
            this.grdReady_For_Membership.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewCommandColumn2});
            this.grdReady_For_Membership.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdReady_For_Membership.Name = "grdReady_For_Membership";
            this.grdReady_For_Membership.Size = new System.Drawing.Size(341, 718);
            this.grdReady_For_Membership.TabIndex = 0;
            this.grdReady_For_Membership.Text = "radGridView1";
            this.grdReady_For_Membership.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdReady_For_Membership_CellClick);
            // 
            // frmReadyForMembership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 794);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmReadyForMembership";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmBasketMembership";
            this.ThemeName = "TelerikMetroBlue";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBasketMembership_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            this.radGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNDC_FileNo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNDC_FileNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReady_For_Membership.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReady_For_Membership)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGridView grdReady_For_Membership;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private Telerik.WinControls.UI.RadGridView grdNDC_FileNo;
        private Telerik.WinControls.UI.RadButton btnRefresh;
    }
}
