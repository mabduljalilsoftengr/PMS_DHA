namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmBasketNDCVerification
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
            this.btn_Refresh = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdReady_For_Verification = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdReady_For_Print = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReady_For_Verification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReady_For_Verification.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdReady_For_Print)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReady_For_Print.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btn_Refresh);
            this.radGroupBox1.Controls.Add(this.radGroupBox2);
            this.radGroupBox1.Controls.Add(this.radGroupBox3);
            this.radGroupBox1.HeaderText = "Basket Main";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 1);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(488, 697);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Basket Main";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Refresh.Location = new System.Drawing.Point(24, 35);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(178, 49);
            this.btn_Refresh.TabIndex = 5;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.grdReady_For_Verification);
            this.radGroupBox2.HeaderText = "Ready For Verification";
            this.radGroupBox2.Location = new System.Drawing.Point(19, 100);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(464, 587);
            this.radGroupBox2.TabIndex = 3;
            this.radGroupBox2.Text = "Ready For Verification";
            // 
            // grdReady_For_Verification
            // 
            this.grdReady_For_Verification.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.grdReady_For_Verification.MasterTemplate.AllowAddNewRow = false;
            this.grdReady_For_Verification.MasterTemplate.AllowColumnReorder = false;
            this.grdReady_For_Verification.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "NDCNo";
            gridViewTextBoxColumn1.HeaderText = "NDCNo";
            gridViewTextBoxColumn1.Name = "NDCNo";
            gridViewTextBoxColumn1.Width = 88;
            gridViewTextBoxColumn2.FieldName = "FilePlotNo";
            gridViewTextBoxColumn2.HeaderText = "FileNo";
            gridViewTextBoxColumn2.Name = "FilePlotNo";
            gridViewTextBoxColumn2.Width = 88;
            gridViewTextBoxColumn3.FieldName = "GoBack_Remarks";
            gridViewTextBoxColumn3.HeaderText = "Back Remarks";
            gridViewTextBoxColumn3.Name = "GoBack_Remarks";
            gridViewTextBoxColumn3.Width = 204;
            gridViewCommandColumn1.DefaultText = "View";
            gridViewCommandColumn1.FieldName = "Redy_Verfcton";
            gridViewCommandColumn1.HeaderText = "Verify";
            gridViewCommandColumn1.Name = "Redy_Verfcton";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 56;
            this.grdReady_For_Verification.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewCommandColumn1});
            this.grdReady_For_Verification.MasterTemplate.EnableGrouping = false;
            this.grdReady_For_Verification.MasterTemplate.EnableSorting = false;
            this.grdReady_For_Verification.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdReady_For_Verification.Name = "grdReady_For_Verification";
            this.grdReady_For_Verification.Size = new System.Drawing.Size(454, 561);
            this.grdReady_For_Verification.TabIndex = 0;
            this.grdReady_For_Verification.Text = "radGridView1";
            this.grdReady_For_Verification.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdReady_For_Verification_CellClick);
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.grdReady_For_Print);
            this.radGroupBox3.HeaderText = "Ready For Print";
            this.radGroupBox3.Location = new System.Drawing.Point(417, 73);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(51, 27);
            this.radGroupBox3.TabIndex = 4;
            this.radGroupBox3.Text = "Ready For Print";
            this.radGroupBox3.Visible = false;
            // 
            // grdReady_For_Print
            // 
            this.grdReady_For_Print.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.grdReady_For_Print.MasterTemplate.AllowAddNewRow = false;
            this.grdReady_For_Print.MasterTemplate.AllowColumnReorder = false;
            this.grdReady_For_Print.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn4.FieldName = "NDCNo";
            gridViewTextBoxColumn4.HeaderText = "NDCNo";
            gridViewTextBoxColumn4.Name = "NDCNo";
            gridViewTextBoxColumn4.Width = 9;
            gridViewTextBoxColumn5.FieldName = "FilePlotNo";
            gridViewTextBoxColumn5.HeaderText = "FileNo";
            gridViewTextBoxColumn5.Name = "FilePlotNo";
            gridViewTextBoxColumn5.Width = 9;
            gridViewCommandColumn2.DefaultText = "Print";
            gridViewCommandColumn2.FieldName = "Redy_Print_Report";
            gridViewCommandColumn2.HeaderText = "Print Report";
            gridViewCommandColumn2.Name = "Redy_Print_Report";
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 5;
            this.grdReady_For_Print.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewCommandColumn2});
            this.grdReady_For_Print.MasterTemplate.EnableGrouping = false;
            this.grdReady_For_Print.MasterTemplate.EnableSorting = false;
            this.grdReady_For_Print.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdReady_For_Print.Name = "grdReady_For_Print";
            this.grdReady_For_Print.Size = new System.Drawing.Size(42, 54);
            this.grdReady_For_Print.TabIndex = 1;
            this.grdReady_For_Print.Text = "radGridView2";
            this.grdReady_For_Print.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdReady_For_Print_CellClick);
            // 
            // frmBasketNDCVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 700);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmBasketNDCVerification";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmBasketVerification";
            this.ThemeName = "TelerikMetroBlue";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmBasketVerification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReady_For_Verification.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReady_For_Verification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdReady_For_Print.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdReady_For_Print)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGridView grdReady_For_Verification;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadGridView grdReady_For_Print;
        private Telerik.WinControls.UI.RadButton btn_Refresh;
    }
}
