namespace PeshawarDHASW.Application_Layer.Installment.InstReceive.InstReceiveModify
{
    partial class frmDDAudit
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
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.Data.SortDescriptor sortDescriptor1 = new Telerik.WinControls.Data.SortDescriptor();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radgdInstReceive = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radgdInstReceive)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgdInstReceive.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radgdInstReceive
            // 
            this.radgdInstReceive.AutoScroll = true;
            this.radgdInstReceive.AutoSizeRows = true;
            this.radgdInstReceive.BackColor = System.Drawing.Color.White;
            this.radgdInstReceive.Cursor = System.Windows.Forms.Cursors.Default;
            this.radgdInstReceive.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radgdInstReceive.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.radgdInstReceive.ForeColor = System.Drawing.SystemColors.ControlText;
            this.radgdInstReceive.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radgdInstReceive.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.radgdInstReceive.MasterTemplate.AddNewRowPosition = Telerik.WinControls.UI.SystemRowPosition.Bottom;
            this.radgdInstReceive.MasterTemplate.AllowAddNewRow = false;
            this.radgdInstReceive.MasterTemplate.AllowRowReorder = true;
            this.radgdInstReceive.MasterTemplate.AllowSearchRow = true;
            this.radgdInstReceive.MasterTemplate.AutoExpandGroups = true;
            this.radgdInstReceive.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "FileNo";
            gridViewTextBoxColumn1.HeaderText = "File No.";
            gridViewTextBoxColumn1.Name = "FileNo";
            gridViewTextBoxColumn1.Width = 57;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "DDNo";
            gridViewTextBoxColumn2.HeaderText = "DDNo";
            gridViewTextBoxColumn2.Name = "DDNo";
            gridViewTextBoxColumn2.Width = 88;
            gridViewTextBoxColumn3.DataType = typeof(System.DateTime);
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "Date";
            gridViewTextBoxColumn3.FormatString = "{0:dd/MMM/yyyy}";
            gridViewTextBoxColumn3.HeaderText = "Rece. Date";
            gridViewTextBoxColumn3.Name = "Date";
            gridViewTextBoxColumn3.Width = 88;
            gridViewTextBoxColumn4.DataType = typeof(System.DateTime);
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "DDGenerationDate";
            gridViewTextBoxColumn4.FormatString = "{0:dd/MMM/yyyy}";
            gridViewTextBoxColumn4.HeaderText = "DD Gen. Date";
            gridViewTextBoxColumn4.Name = "DDGenerationDate";
            gridViewTextBoxColumn4.Width = 91;
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "Amount";
            gridViewTextBoxColumn5.FormatString = "{0:#,###0.00;(#,###0.00);0}";
            gridViewTextBoxColumn5.HeaderText = "Amount";
            gridViewTextBoxColumn5.Name = "Amount";
            gridViewTextBoxColumn5.Width = 96;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "DDStatus";
            gridViewTextBoxColumn6.HeaderText = "DDStatus";
            gridViewTextBoxColumn6.Name = "DDStatus";
            gridViewTextBoxColumn6.Width = 90;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "DDClearanceDate";
            gridViewTextBoxColumn7.FormatString = "{0:dd/MMM/yyyy}";
            gridViewTextBoxColumn7.HeaderText = "Clearance Date";
            gridViewTextBoxColumn7.Name = "DDClearanceDate";
            gridViewTextBoxColumn7.Width = 85;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Remarks";
            gridViewTextBoxColumn8.HeaderText = "Remarks";
            gridViewTextBoxColumn8.Multiline = true;
            gridViewTextBoxColumn8.Name = "Remarks";
            gridViewTextBoxColumn8.SortOrder = Telerik.WinControls.UI.RadSortOrder.Ascending;
            gridViewTextBoxColumn8.Width = 125;
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.FieldName = "EntryDate";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            gridViewDateTimeColumn1.FormatString = "{0:dd/MMM/yyyy}";
            gridViewDateTimeColumn1.HeaderText = "Trans.. Date";
            gridViewDateTimeColumn1.Name = "EntryDate";
            gridViewDateTimeColumn1.Width = 83;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "username";
            gridViewTextBoxColumn9.HeaderText = "User";
            gridViewTextBoxColumn9.Name = "username";
            gridViewTextBoxColumn9.Width = 71;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "Rece_ID";
            gridViewTextBoxColumn10.HeaderText = "Trx ID";
            gridViewTextBoxColumn10.Name = "Rece_ID";
            gridViewTextBoxColumn10.Width = 127;
            this.radgdInstReceive.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8,
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10});
            this.radgdInstReceive.MasterTemplate.EnableAlternatingRowColor = true;
            this.radgdInstReceive.MasterTemplate.EnableFiltering = true;
            this.radgdInstReceive.MasterTemplate.PageSize = 100;
            this.radgdInstReceive.MasterTemplate.ShowChildViewCaptions = true;
            this.radgdInstReceive.MasterTemplate.ShowFilteringRow = false;
            this.radgdInstReceive.MasterTemplate.ShowHeaderCellButtons = true;
            sortDescriptor1.PropertyName = "Remarks";
            this.radgdInstReceive.MasterTemplate.SortDescriptors.AddRange(new Telerik.WinControls.Data.SortDescriptor[] {
            sortDescriptor1});
            this.radgdInstReceive.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radgdInstReceive.Name = "radgdInstReceive";
            this.radgdInstReceive.ReadOnly = true;
            this.radgdInstReceive.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radgdInstReceive.ShowChildViewCaptions = true;
            this.radgdInstReceive.ShowHeaderCellButtons = true;
            this.radgdInstReceive.Size = new System.Drawing.Size(1012, 465);
            this.radgdInstReceive.TabIndex = 1;
            this.radgdInstReceive.Text = "radGridView1";
            this.radgdInstReceive.ThemeName = "TelerikMetro";
            this.radgdInstReceive.CellFormatting += new Telerik.WinControls.UI.CellFormattingEventHandler(this.MasterTemplate_CellFormatting);
            // 
            // frmDDAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 465);
            this.Controls.Add(this.radgdInstReceive);
            this.Name = "frmDDAudit";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DD Audit Trail";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmDDAudit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radgdInstReceive.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgdInstReceive)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView radgdInstReceive;
    }
}
