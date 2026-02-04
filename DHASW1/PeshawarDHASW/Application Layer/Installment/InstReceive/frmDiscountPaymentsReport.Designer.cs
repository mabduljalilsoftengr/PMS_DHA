namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    partial class frmDiscountPaymentsReport
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnexcelexport = new Telerik.WinControls.UI.RadButton();
            this.btngetdata = new Telerik.WinControls.UI.RadButton();
            this.grddiscountdata = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnexcelexport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btngetdata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grddiscountdata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grddiscountdata.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnexcelexport);
            this.radGroupBox1.Controls.Add(this.btngetdata);
            this.radGroupBox1.Controls.Add(this.grddiscountdata);
            this.radGroupBox1.HeaderText = "Discount Detail";
            this.radGroupBox1.Location = new System.Drawing.Point(5, 5);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1085, 600);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Discount Detail";
            // 
            // btnexcelexport
            // 
            this.btnexcelexport.Location = new System.Drawing.Point(795, 21);
            this.btnexcelexport.Name = "btnexcelexport";
            this.btnexcelexport.Size = new System.Drawing.Size(282, 42);
            this.btnexcelexport.TabIndex = 2;
            this.btnexcelexport.Text = "Excel Export";
            this.btnexcelexport.Click += new System.EventHandler(this.btnexcelexport_Click);
            // 
            // btngetdata
            // 
            this.btngetdata.Location = new System.Drawing.Point(7, 21);
            this.btngetdata.Name = "btngetdata";
            this.btngetdata.Size = new System.Drawing.Size(298, 42);
            this.btngetdata.TabIndex = 1;
            this.btngetdata.Text = "Get Data";
            this.btngetdata.Click += new System.EventHandler(this.btngetdata_Click);
            // 
            // grddiscountdata
            // 
            this.grddiscountdata.EnableKeyMap = true;
            this.grddiscountdata.Location = new System.Drawing.Point(5, 69);
            // 
            // 
            // 
            this.grddiscountdata.MasterTemplate.AllowSearchRow = true;
            this.grddiscountdata.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "TRXID";
            gridViewTextBoxColumn1.HeaderText = "TRXID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "TRXID";
            gridViewTextBoxColumn2.FieldName = "MembershipNo";
            gridViewTextBoxColumn2.HeaderText = "MembershipNo";
            gridViewTextBoxColumn2.Name = "MembershipNo";
            gridViewTextBoxColumn2.Width = 112;
            gridViewTextBoxColumn3.FieldName = "Name";
            gridViewTextBoxColumn3.HeaderText = "Name";
            gridViewTextBoxColumn3.Name = "Name";
            gridViewTextBoxColumn3.Width = 112;
            gridViewTextBoxColumn4.FieldName = "FileNo";
            gridViewTextBoxColumn4.HeaderText = "FileNo";
            gridViewTextBoxColumn4.Name = "FileNo";
            gridViewTextBoxColumn4.Width = 112;
            gridViewTextBoxColumn5.FieldName = "Amount";
            gridViewTextBoxColumn5.HeaderText = "Amount";
            gridViewTextBoxColumn5.Name = "Amount";
            gridViewTextBoxColumn5.Width = 112;
            gridViewTextBoxColumn6.FieldName = "AmountInwords";
            gridViewTextBoxColumn6.HeaderText = "AmountInwords";
            gridViewTextBoxColumn6.Name = "AmountInwords";
            gridViewTextBoxColumn6.Width = 112;
            gridViewTextBoxColumn7.FieldName = "DDNo";
            gridViewTextBoxColumn7.HeaderText = "DDNo";
            gridViewTextBoxColumn7.Name = "DDNo";
            gridViewTextBoxColumn7.Width = 112;
            gridViewTextBoxColumn8.FieldName = "BankName";
            gridViewTextBoxColumn8.HeaderText = "BankName";
            gridViewTextBoxColumn8.Name = "BankName";
            gridViewTextBoxColumn8.Width = 112;
            gridViewTextBoxColumn9.FieldName = "ReceieveDate";
            gridViewTextBoxColumn9.HeaderText = "ReceieveDate";
            gridViewTextBoxColumn9.Name = "ReceieveDate";
            gridViewTextBoxColumn9.Width = 112;
            gridViewTextBoxColumn10.FieldName = "DDGenerationDate";
            gridViewTextBoxColumn10.HeaderText = "DDGenerationDate";
            gridViewTextBoxColumn10.Name = "DDGenerationDate";
            gridViewTextBoxColumn10.Width = 112;
            gridViewTextBoxColumn11.FieldName = "DDStatus";
            gridViewTextBoxColumn11.HeaderText = "DDStatus";
            gridViewTextBoxColumn11.Name = "DDStatus";
            gridViewTextBoxColumn11.Width = 55;
            this.grddiscountdata.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            gridViewTextBoxColumn11});
            this.grddiscountdata.MasterTemplate.EnableFiltering = true;
            this.grddiscountdata.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grddiscountdata.Name = "grddiscountdata";
            this.grddiscountdata.Size = new System.Drawing.Size(1075, 526);
            this.grddiscountdata.TabIndex = 0;
            this.grddiscountdata.Text = "radGridView1";
            // 
            // frmDiscountPaymentsReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 607);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmDiscountPaymentsReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmDiscountReport";
            this.Load += new System.EventHandler(this.frmDiscountPaymentsReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnexcelexport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btngetdata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grddiscountdata.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grddiscountdata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btngetdata;
        private Telerik.WinControls.UI.RadGridView grddiscountdata;
        private Telerik.WinControls.UI.RadButton btnexcelexport;
    }
}
