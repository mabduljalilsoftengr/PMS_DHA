namespace PeshawarDHASW.Application_Layer.TP_BC
{
    partial class frmHouseSetting
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
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewSummaryItem gridViewSummaryItem1 = new Telerik.WinControls.UI.GridViewSummaryItem();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.gdvHousedata = new Telerik.WinControls.UI.RadGridView();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.btnNewHouse = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gdvHousedata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvHousedata.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewHouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gdvHousedata
            // 
            this.gdvHousedata.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gdvHousedata.BackColor = System.Drawing.Color.White;
            this.gdvHousedata.Cursor = System.Windows.Forms.Cursors.Default;
            this.gdvHousedata.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.gdvHousedata.ForeColor = System.Drawing.SystemColors.ControlText;
            this.gdvHousedata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gdvHousedata.Location = new System.Drawing.Point(1, 52);
            // 
            // 
            // 
            this.gdvHousedata.MasterTemplate.AllowAddNewRow = false;
            this.gdvHousedata.MasterTemplate.AllowColumnReorder = false;
            this.gdvHousedata.MasterTemplate.AllowSearchRow = true;
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "Status";
            gridViewCommandColumn1.HeaderText = "Edit";
            gridViewCommandColumn1.Name = "Edit";
            gridViewCommandColumn1.Width = 194;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "HouseID";
            gridViewTextBoxColumn1.HeaderText = "HouseID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "HouseID";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "FileNo";
            gridViewTextBoxColumn2.HeaderText = "FileNo";
            gridViewTextBoxColumn2.Name = "FileNo";
            gridViewTextBoxColumn2.Width = 132;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "FileMapKey";
            gridViewTextBoxColumn3.HeaderText = "FileMapKey";
            gridViewTextBoxColumn3.IsVisible = false;
            gridViewTextBoxColumn3.Name = "FileMapKey";
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "PlotID";
            gridViewTextBoxColumn4.HeaderText = "PlotID";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "PlotID";
            gridViewTextBoxColumn5.EnableExpressionEditor = false;
            gridViewTextBoxColumn5.FieldName = "PlotNo";
            gridViewTextBoxColumn5.HeaderText = "PlotNo";
            gridViewTextBoxColumn5.Name = "PlotNo";
            gridViewTextBoxColumn5.Width = 89;
            gridViewTextBoxColumn6.EnableExpressionEditor = false;
            gridViewTextBoxColumn6.FieldName = "PlotDigit";
            gridViewTextBoxColumn6.HeaderText = "PlotDigit";
            gridViewTextBoxColumn6.Name = "PlotDigit";
            gridViewTextBoxColumn6.Width = 105;
            gridViewTextBoxColumn7.EnableExpressionEditor = false;
            gridViewTextBoxColumn7.FieldName = "Street";
            gridViewTextBoxColumn7.HeaderText = "Street";
            gridViewTextBoxColumn7.Name = "Street";
            gridViewTextBoxColumn7.Width = 91;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "Sector";
            gridViewTextBoxColumn8.HeaderText = "Sector";
            gridViewTextBoxColumn8.Name = "Sector";
            gridViewTextBoxColumn8.Width = 96;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "Phase";
            gridViewTextBoxColumn9.HeaderText = "Phase";
            gridViewTextBoxColumn9.Name = "Phase";
            gridViewTextBoxColumn9.Width = 101;
            gridViewDateTimeColumn1.EnableExpressionEditor = false;
            gridViewDateTimeColumn1.FieldName = "StartDateofConst";
            gridViewDateTimeColumn1.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn1.HeaderText = "StartDateofConst";
            gridViewDateTimeColumn1.Name = "StartDateofConst";
            gridViewDateTimeColumn1.Width = 129;
            gridViewDateTimeColumn2.EnableExpressionEditor = false;
            gridViewDateTimeColumn2.FieldName = "EndDateofConst";
            gridViewDateTimeColumn2.Format = System.Windows.Forms.DateTimePickerFormat.Long;
            gridViewDateTimeColumn2.HeaderText = "EndDateofConst";
            gridViewDateTimeColumn2.Name = "EndDateofConst";
            gridViewDateTimeColumn2.Width = 116;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "Status";
            gridViewTextBoxColumn10.HeaderText = "Status";
            gridViewTextBoxColumn10.Name = "Status";
            gridViewTextBoxColumn10.Width = 101;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "FileStatus";
            gridViewTextBoxColumn11.HeaderText = "FileStatus";
            gridViewTextBoxColumn11.Name = "FileStatus";
            gridViewTextBoxColumn11.Width = 97;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "Remarks";
            gridViewTextBoxColumn12.HeaderText = "Remarks";
            gridViewTextBoxColumn12.Name = "Remarks";
            gridViewTextBoxColumn12.Width = 193;
            this.gdvHousedata.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
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
            gridViewDateTimeColumn1,
            gridViewDateTimeColumn2,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12});
            this.gdvHousedata.MasterTemplate.EnableAlternatingRowColor = true;
            this.gdvHousedata.MasterTemplate.EnableFiltering = true;
            this.gdvHousedata.MasterTemplate.EnableGrouping = false;
            this.gdvHousedata.MasterTemplate.EnableSorting = false;
            this.gdvHousedata.MasterTemplate.ShowFilteringRow = false;
            this.gdvHousedata.MasterTemplate.ShowHeaderCellButtons = true;
            gridViewSummaryItem1.Aggregate = Telerik.WinControls.UI.GridAggregateFunction.Count;
            gridViewSummaryItem1.AggregateExpression = null;
            gridViewSummaryItem1.FormatString = "{0:#,###0}";
            gridViewSummaryItem1.Name = "FileNo";
            this.gdvHousedata.MasterTemplate.SummaryRowsTop.Add(new Telerik.WinControls.UI.GridViewSummaryRowItem(new Telerik.WinControls.UI.GridViewSummaryItem[] {
                gridViewSummaryItem1}));
            this.gdvHousedata.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gdvHousedata.Name = "gdvHousedata";
            this.gdvHousedata.ReadOnly = true;
            this.gdvHousedata.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gdvHousedata.ShowGroupPanel = false;
            this.gdvHousedata.ShowHeaderCellButtons = true;
            this.gdvHousedata.Size = new System.Drawing.Size(855, 318);
            this.gdvHousedata.TabIndex = 0;
            this.gdvHousedata.Text = "radGridView1";
            this.gdvHousedata.ThemeName = "TelerikMetro";
            this.gdvHousedata.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.gdvHousedata_CellClick);
            this.gdvHousedata.Click += new System.EventHandler(this.gdvHousedata_Click);
            // 
            // btnNewHouse
            // 
            this.btnNewHouse.Location = new System.Drawing.Point(13, 13);
            this.btnNewHouse.Name = "btnNewHouse";
            this.btnNewHouse.Size = new System.Drawing.Size(110, 24);
            this.btnNewHouse.TabIndex = 1;
            this.btnNewHouse.Text = "New House";
            this.btnNewHouse.ThemeName = "TelerikMetro";
            this.btnNewHouse.Click += new System.EventHandler(this.btnNewHouse_Click);
            // 
            // frmHouseSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 373);
            this.Controls.Add(this.btnNewHouse);
            this.Controls.Add(this.gdvHousedata);
            this.Name = "frmHouseSetting";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmHouseSetting";
            this.ThemeName = "TelerikMetro";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmHouseSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gdvHousedata.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvHousedata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewHouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gdvHousedata;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadButton btnNewHouse;
    }
}
