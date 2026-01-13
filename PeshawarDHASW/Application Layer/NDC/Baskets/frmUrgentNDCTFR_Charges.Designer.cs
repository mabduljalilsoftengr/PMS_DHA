namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmUrgentNDCTFR_Charges
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn21 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn22 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn23 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn24 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.dtpcurrentdate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.grdurgentchallans = new Telerik.WinControls.UI.RadGridView();
            this.btnrefresh = new Telerik.WinControls.UI.RadButton();
            this.btnexcelexport = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpcurrentdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdurgentchallans)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdurgentchallans.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnrefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnexcelexport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnexcelexport);
            this.radGroupBox1.Controls.Add(this.dtpcurrentdate);
            this.radGroupBox1.Controls.Add(this.grdurgentchallans);
            this.radGroupBox1.Controls.Add(this.btnrefresh);
            this.radGroupBox1.HeaderText = "Urgent NDC\'s with Urgent Challan\'s";
            this.radGroupBox1.Location = new System.Drawing.Point(5, 6);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(943, 619);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Urgent NDC\'s with Urgent Challan\'s";
            // 
            // dtpcurrentdate
            // 
            this.dtpcurrentdate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpcurrentdate.Location = new System.Drawing.Point(297, 26);
            this.dtpcurrentdate.Name = "dtpcurrentdate";
            this.dtpcurrentdate.Size = new System.Drawing.Size(339, 27);
            this.dtpcurrentdate.TabIndex = 2;
            this.dtpcurrentdate.TabStop = false;
            this.dtpcurrentdate.Value = new System.DateTime(((long)(0)));
            // 
            // grdurgentchallans
            // 
            this.grdurgentchallans.Location = new System.Drawing.Point(7, 66);
            // 
            // 
            // 
            this.grdurgentchallans.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn17.FieldName = "NDCNo";
            gridViewTextBoxColumn17.HeaderText = "NDC No.";
            gridViewTextBoxColumn17.Name = "NDCNo";
            gridViewTextBoxColumn17.Width = 108;
            gridViewTextBoxColumn18.FieldName = "FilePlotNo";
            gridViewTextBoxColumn18.HeaderText = "File No.";
            gridViewTextBoxColumn18.Name = "FilePlotNo";
            gridViewTextBoxColumn18.Width = 108;
            gridViewTextBoxColumn19.FieldName = "NDCTypeNormalUrgent";
            gridViewTextBoxColumn19.HeaderText = "NDC Type";
            gridViewTextBoxColumn19.Name = "NDCTypeNormalUrgent";
            gridViewTextBoxColumn19.Width = 110;
            gridViewTextBoxColumn20.FieldName = "UrgentNDCChallanNo";
            gridViewTextBoxColumn20.HeaderText = "Urgent NDC Challan No.";
            gridViewTextBoxColumn20.Name = "UrgentNDCChallanNo";
            gridViewTextBoxColumn20.Width = 135;
            gridViewTextBoxColumn21.FieldName = "UrgentNDCStatus";
            gridViewTextBoxColumn21.HeaderText = "Challan Status";
            gridViewTextBoxColumn21.Name = "UrgentNDCStatus";
            gridViewTextBoxColumn21.Width = 135;
            gridViewTextBoxColumn22.FieldName = "TFRType";
            gridViewTextBoxColumn22.HeaderText = "TFR Type";
            gridViewTextBoxColumn22.Name = "TFRType";
            gridViewTextBoxColumn22.Width = 106;
            gridViewTextBoxColumn23.FieldName = "UrgentTransferChallanNo";
            gridViewTextBoxColumn23.HeaderText = "Urgent Transfer Challan No.";
            gridViewTextBoxColumn23.Name = "UrgentTransferChallanNo";
            gridViewTextBoxColumn23.Width = 135;
            gridViewTextBoxColumn24.FieldName = "UrgentTFRStatus";
            gridViewTextBoxColumn24.HeaderText = "Challan Status";
            gridViewTextBoxColumn24.Name = "UrgentTFRStatus";
            gridViewTextBoxColumn24.Width = 76;
            this.grdurgentchallans.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20,
            gridViewTextBoxColumn21,
            gridViewTextBoxColumn22,
            gridViewTextBoxColumn23,
            gridViewTextBoxColumn24});
            this.grdurgentchallans.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.grdurgentchallans.Name = "grdurgentchallans";
            this.grdurgentchallans.Size = new System.Drawing.Size(927, 547);
            this.grdurgentchallans.TabIndex = 1;
            this.grdurgentchallans.Text = "radGridView1";
            // 
            // btnrefresh
            // 
            this.btnrefresh.Location = new System.Drawing.Point(7, 21);
            this.btnrefresh.Name = "btnrefresh";
            this.btnrefresh.Size = new System.Drawing.Size(246, 39);
            this.btnrefresh.TabIndex = 0;
            this.btnrefresh.Text = "Refresh";
            this.btnrefresh.Click += new System.EventHandler(this.btnrefresh_Click);
            // 
            // btnexcelexport
            // 
            this.btnexcelexport.Location = new System.Drawing.Point(688, 20);
            this.btnexcelexport.Name = "btnexcelexport";
            this.btnexcelexport.Size = new System.Drawing.Size(246, 39);
            this.btnexcelexport.TabIndex = 3;
            this.btnexcelexport.Text = "Excel Export";
            this.btnexcelexport.Click += new System.EventHandler(this.btnexcelexport_Click);
            // 
            // frmUrgentNDCTFR_Charges
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(951, 631);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmUrgentNDCTFR_Charges";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmUrgentNDCTFR_Charges";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpcurrentdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdurgentchallans.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdurgentchallans)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnrefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnexcelexport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grdurgentchallans;
        private Telerik.WinControls.UI.RadButton btnrefresh;
        private Telerik.WinControls.UI.RadDateTimePicker dtpcurrentdate;
        private Telerik.WinControls.UI.RadButton btnexcelexport;
    }
}
