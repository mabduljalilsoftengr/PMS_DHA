namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmNDCAgainstReport
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdNDCData = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox7 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdFBRCPRData = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox5 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdFBRSellerBuyerData = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdNDCData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNDCData.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox7)).BeginInit();
            this.radGroupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFBRCPRData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFBRCPRData.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).BeginInit();
            this.radGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFBRSellerBuyerData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFBRSellerBuyerData.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdNDCData
            // 
            this.grdNDCData.EnableKeyMap = true;
            this.grdNDCData.Location = new System.Drawing.Point(5, 11);
            // 
            // 
            // 
            this.grdNDCData.MasterTemplate.AllowSearchRow = true;
            this.grdNDCData.MasterTemplate.AutoGenerateColumns = false;
            this.grdNDCData.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "NDCNo";
            gridViewTextBoxColumn1.HeaderText = "NDCNo";
            gridViewTextBoxColumn1.Name = "NDCNo";
            gridViewTextBoxColumn1.Width = 76;
            gridViewTextBoxColumn2.FieldName = "FilePlotNo";
            gridViewTextBoxColumn2.HeaderText = "File No";
            gridViewTextBoxColumn2.Name = "FilePlotNo";
            gridViewTextBoxColumn2.Width = 76;
            gridViewTextBoxColumn3.FieldName = "StatusofNDC";
            gridViewTextBoxColumn3.HeaderText = "Status";
            gridViewTextBoxColumn3.Name = "StatusofNDC";
            gridViewTextBoxColumn3.Width = 76;
            gridViewCommandColumn1.DefaultText = "View";
            gridViewCommandColumn1.FieldName = "btnDetail";
            gridViewCommandColumn1.HeaderText = "View Detail";
            gridViewCommandColumn1.Name = "btnDetail";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 74;
            this.grdNDCData.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewCommandColumn1});
            this.grdNDCData.MasterTemplate.EnableFiltering = true;
            this.grdNDCData.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdNDCData.Name = "grdNDCData";
            this.grdNDCData.Size = new System.Drawing.Size(320, 413);
            this.grdNDCData.TabIndex = 1;
            this.grdNDCData.Text = "radGridView1";
            this.grdNDCData.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdNDCData_CellClick);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.grdNDCData);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(2, 6);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(330, 428);
            this.radGroupBox1.TabIndex = 1;
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.radGroupBox7);
            this.radGroupBox3.Controls.Add(this.radGroupBox5);
            this.radGroupBox3.HeaderText = "FBR Taxes data";
            this.radGroupBox3.Location = new System.Drawing.Point(333, -2);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(846, 436);
            this.radGroupBox3.TabIndex = 3;
            this.radGroupBox3.Text = "FBR Taxes data";
            // 
            // radGroupBox7
            // 
            this.radGroupBox7.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox7.Controls.Add(this.grdFBRCPRData);
            this.radGroupBox7.HeaderText = "FBR Seller / Buyer CPR Taxes  Data";
            this.radGroupBox7.Location = new System.Drawing.Point(428, 97);
            this.radGroupBox7.Name = "radGroupBox7";
            this.radGroupBox7.Size = new System.Drawing.Size(388, 310);
            this.radGroupBox7.TabIndex = 106;
            this.radGroupBox7.Text = "FBR Seller / Buyer CPR Taxes  Data";
            // 
            // grdFBRCPRData
            // 
            this.grdFBRCPRData.Location = new System.Drawing.Point(6, 21);
            // 
            // 
            // 
            this.grdFBRCPRData.MasterTemplate.AllowAddNewRow = false;
            this.grdFBRCPRData.MasterTemplate.AllowColumnReorder = false;
            this.grdFBRCPRData.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.grdFBRCPRData.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdFBRCPRData.Name = "grdFBRCPRData";
            this.grdFBRCPRData.ReadOnly = true;
            this.grdFBRCPRData.Size = new System.Drawing.Size(377, 284);
            this.grdFBRCPRData.TabIndex = 0;
            this.grdFBRCPRData.Text = "radGridView2";
            // 
            // radGroupBox5
            // 
            this.radGroupBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox5.Controls.Add(this.grdFBRSellerBuyerData);
            this.radGroupBox5.HeaderText = "FBR Seller / Buyer Data";
            this.radGroupBox5.Location = new System.Drawing.Point(5, 97);
            this.radGroupBox5.Name = "radGroupBox5";
            this.radGroupBox5.Size = new System.Drawing.Size(388, 310);
            this.radGroupBox5.TabIndex = 2;
            this.radGroupBox5.Text = "FBR Seller / Buyer Data";
            // 
            // grdFBRSellerBuyerData
            // 
            this.grdFBRSellerBuyerData.Location = new System.Drawing.Point(6, 21);
            // 
            // 
            // 
            this.grdFBRSellerBuyerData.MasterTemplate.AllowAddNewRow = false;
            this.grdFBRSellerBuyerData.MasterTemplate.AllowColumnReorder = false;
            this.grdFBRSellerBuyerData.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.grdFBRSellerBuyerData.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.grdFBRSellerBuyerData.Name = "grdFBRSellerBuyerData";
            this.grdFBRSellerBuyerData.ReadOnly = true;
            this.grdFBRSellerBuyerData.Size = new System.Drawing.Size(377, 284);
            this.grdFBRSellerBuyerData.TabIndex = 0;
            this.grdFBRSellerBuyerData.Text = "radGridView1";
            // 
            // frmNDCAgainstReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 438);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmNDCAgainstReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmNDCAgainstReport";
            this.Load += new System.EventHandler(this.frmNDCAgainstReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdNDCData.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNDCData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox7)).EndInit();
            this.radGroupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFBRCPRData.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFBRCPRData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).EndInit();
            this.radGroupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFBRSellerBuyerData.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFBRSellerBuyerData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdNDCData;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox7;
        private Telerik.WinControls.UI.RadGridView grdFBRCPRData;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox5;
        private Telerik.WinControls.UI.RadGridView grdFBRSellerBuyerData;
    }
}
