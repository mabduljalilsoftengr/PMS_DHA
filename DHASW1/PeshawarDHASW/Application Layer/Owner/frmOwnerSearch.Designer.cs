namespace PeshawarDHASW.Application_Layer.Owner
{
    partial class frmOwnerSearch
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn31 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn32 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn33 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn34 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn35 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn36 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn37 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn38 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn39 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn40 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            this.telerikMetroBlueTheme1 = new Telerik.WinControls.Themes.TelerikMetroBlueTheme();
            this.grdOwnerdata = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btn_Search = new Telerik.WinControls.UI.RadButton();
            this.txtRateOfSale = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtMSNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtFileNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.grdOwnerdata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOwnerdata.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateOfSale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMSNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdOwnerdata
            // 
            this.grdOwnerdata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdOwnerdata.EnableKeyMap = true;
            this.grdOwnerdata.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.grdOwnerdata.MasterTemplate.AllowAddNewRow = false;
            this.grdOwnerdata.MasterTemplate.AllowColumnReorder = false;
            this.grdOwnerdata.MasterTemplate.AllowSearchRow = true;
            this.grdOwnerdata.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn31.FieldName = "OwnerID";
            gridViewTextBoxColumn31.HeaderText = "OwnerID";
            gridViewTextBoxColumn31.IsVisible = false;
            gridViewTextBoxColumn31.Name = "OwnerID";
            gridViewTextBoxColumn32.FieldName = "FileNo";
            gridViewTextBoxColumn32.HeaderText = "File NO";
            gridViewTextBoxColumn32.Name = "FileNo";
            gridViewTextBoxColumn32.Width = 137;
            gridViewTextBoxColumn33.FieldName = "FileMapKey";
            gridViewTextBoxColumn33.HeaderText = "FileMapKey";
            gridViewTextBoxColumn33.IsVisible = false;
            gridViewTextBoxColumn33.Name = "FileMapKey";
            gridViewTextBoxColumn34.FieldName = "MembershipNo";
            gridViewTextBoxColumn34.HeaderText = "MS NO";
            gridViewTextBoxColumn34.Name = "MembershipNo";
            gridViewTextBoxColumn34.Width = 137;
            gridViewTextBoxColumn35.FieldName = "ID";
            gridViewTextBoxColumn35.HeaderText = "ID";
            gridViewTextBoxColumn35.IsVisible = false;
            gridViewTextBoxColumn35.Name = "ID";
            gridViewTextBoxColumn36.FieldName = "Status";
            gridViewTextBoxColumn36.HeaderText = "Status";
            gridViewTextBoxColumn36.Name = "Status";
            gridViewTextBoxColumn36.Width = 107;
            gridViewTextBoxColumn37.FieldName = "TPName";
            gridViewTextBoxColumn37.HeaderText = "Type Purchase";
            gridViewTextBoxColumn37.Name = "TPName";
            gridViewTextBoxColumn37.Width = 107;
            gridViewTextBoxColumn38.FieldName = "RateofSale";
            gridViewTextBoxColumn38.HeaderText = "Rate of Sale";
            gridViewTextBoxColumn38.Name = "RateofSale";
            gridViewTextBoxColumn38.Width = 137;
            gridViewTextBoxColumn39.FieldName = "DateofPurchase";
            gridViewTextBoxColumn39.HeaderText = "Date of Purchase";
            gridViewTextBoxColumn39.Name = "DateofPurchase";
            gridViewTextBoxColumn39.Width = 117;
            gridViewTextBoxColumn40.FieldName = "DateofSell";
            gridViewTextBoxColumn40.HeaderText = "DateofSell";
            gridViewTextBoxColumn40.Name = "DateofSell";
            gridViewTextBoxColumn40.Width = 117;
            this.grdOwnerdata.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn31,
            gridViewTextBoxColumn32,
            gridViewTextBoxColumn33,
            gridViewTextBoxColumn34,
            gridViewTextBoxColumn35,
            gridViewTextBoxColumn36,
            gridViewTextBoxColumn37,
            gridViewTextBoxColumn38,
            gridViewTextBoxColumn39,
            gridViewTextBoxColumn40});
            this.grdOwnerdata.MasterTemplate.EnableFiltering = true;
            this.grdOwnerdata.MasterTemplate.EnablePaging = true;
            this.grdOwnerdata.MasterTemplate.EnableSorting = false;
            this.grdOwnerdata.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.grdOwnerdata.Name = "grdOwnerdata";
            this.grdOwnerdata.ReadOnly = true;
            this.grdOwnerdata.Size = new System.Drawing.Size(878, 332);
            this.grdOwnerdata.TabIndex = 0;
            this.grdOwnerdata.Text = "Owner Data";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.grdOwnerdata);
            this.radGroupBox2.HeaderText = "Owner Data";
            this.radGroupBox2.Location = new System.Drawing.Point(12, 118);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(883, 358);
            this.radGroupBox2.TabIndex = 4;
            this.radGroupBox2.Text = "Owner Data";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btn_Search);
            this.radGroupBox1.Controls.Add(this.txtRateOfSale);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.txtMSNo);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.txtFileNo);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.HeaderText = "Search";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(883, 100);
            this.radGroupBox1.TabIndex = 3;
            this.radGroupBox1.Text = "Search";
            // 
            // btn_Search
            // 
            this.btn_Search.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Search.Location = new System.Drawing.Point(744, 40);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(119, 38);
            this.btn_Search.TabIndex = 10;
            this.btn_Search.Text = "Search";
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // txtRateOfSale
            // 
            this.txtRateOfSale.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRateOfSale.Location = new System.Drawing.Point(446, 21);
            this.txtRateOfSale.Name = "txtRateOfSale";
            this.txtRateOfSale.Size = new System.Drawing.Size(174, 27);
            this.txtRateOfSale.TabIndex = 9;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(334, 21);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(97, 25);
            this.radLabel3.TabIndex = 8;
            this.radLabel3.Text = "Rate Of Sale";
            // 
            // txtMSNo
            // 
            this.txtMSNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMSNo.Location = new System.Drawing.Point(111, 68);
            this.txtMSNo.Name = "txtMSNo";
            this.txtMSNo.Size = new System.Drawing.Size(174, 27);
            this.txtMSNo.TabIndex = 7;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(21, 70);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(61, 25);
            this.radLabel2.TabIndex = 6;
            this.radLabel2.Text = "MS NO";
            // 
            // txtFileNo
            // 
            this.txtFileNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileNo.Location = new System.Drawing.Point(111, 21);
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(174, 27);
            this.txtFileNo.TabIndex = 4;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(20, 21);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(62, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "File NO";
            // 
            // frmOwnerSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 502);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmOwnerSearch";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmOwnerSearch";
            this.ThemeName = "TelerikMetroBlue";
            this.Load += new System.EventHandler(this.frmOwnerSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdOwnerdata.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOwnerdata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRateOfSale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMSNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroBlueTheme telerikMetroBlueTheme1;
        private Telerik.WinControls.UI.RadGridView grdOwnerdata;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btn_Search;
        private Telerik.WinControls.UI.RadTextBox txtRateOfSale;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtMSNo;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtFileNo;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
