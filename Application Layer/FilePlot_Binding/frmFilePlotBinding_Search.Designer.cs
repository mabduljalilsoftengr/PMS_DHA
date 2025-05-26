namespace PeshawarDHASW.Application_Layer.FilePlot_Binding
{
    partial class frmFilePlotBinding_Search
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.grd_FilePlotBinding = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnSearch = new Telerik.WinControls.UI.RadButton();
            this.txtPlotNo = new Telerik.WinControls.UI.RadTextBox();
            this.txtFileNo = new Telerik.WinControls.UI.RadTextBox();
            this.txtDocumentNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_FilePlotBinding)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_FilePlotBinding.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlotNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.grd_FilePlotBinding);
            this.radGroupBox1.HeaderText = "File Plot Binding Detail";
            this.radGroupBox1.Location = new System.Drawing.Point(7, 127);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(705, 337);
            this.radGroupBox1.TabIndex = 9;
            this.radGroupBox1.Text = "File Plot Binding Detail";
            // 
            // grd_FilePlotBinding
            // 
            this.grd_FilePlotBinding.Location = new System.Drawing.Point(9, 19);
            // 
            // 
            // 
            this.grd_FilePlotBinding.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "FP_MapID";
            gridViewTextBoxColumn1.HeaderText = "FP_MapID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "FP_MapID";
            gridViewTextBoxColumn2.FieldName = "FileMapKey_FK";
            gridViewTextBoxColumn2.HeaderText = "FileMapKey FK";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "FileMapKey_FK";
            gridViewTextBoxColumn2.Width = 45;
            gridViewTextBoxColumn3.FieldName = "FileNo";
            gridViewTextBoxColumn3.HeaderText = "File No";
            gridViewTextBoxColumn3.Name = "FileNo";
            gridViewTextBoxColumn3.Width = 157;
            gridViewTextBoxColumn4.FieldName = "PlotID_FK";
            gridViewTextBoxColumn4.HeaderText = "PlotID FK";
            gridViewTextBoxColumn4.IsVisible = false;
            gridViewTextBoxColumn4.Name = "PlotID_FK";
            gridViewTextBoxColumn4.Width = 45;
            gridViewTextBoxColumn5.FieldName = "PlotNo";
            gridViewTextBoxColumn5.HeaderText = "Plo tNo";
            gridViewTextBoxColumn5.Name = "PlotNo";
            gridViewTextBoxColumn5.Width = 157;
            gridViewTextBoxColumn6.FieldName = "Document_No";
            gridViewTextBoxColumn6.HeaderText = "Document No";
            gridViewTextBoxColumn6.Name = "Document_No";
            gridViewTextBoxColumn6.Width = 157;
            gridViewTextBoxColumn7.FieldName = "Remarks";
            gridViewTextBoxColumn7.HeaderText = "Remarks";
            gridViewTextBoxColumn7.Name = "Remarks";
            gridViewTextBoxColumn7.Width = 158;
            gridViewTextBoxColumn8.FieldName = "Status";
            gridViewTextBoxColumn8.HeaderText = "Status";
            gridViewTextBoxColumn8.Name = "Status";
            gridViewTextBoxColumn8.Width = 45;
            this.grd_FilePlotBinding.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.grd_FilePlotBinding.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grd_FilePlotBinding.Name = "grd_FilePlotBinding";
            this.grd_FilePlotBinding.Size = new System.Drawing.Size(691, 313);
            this.grd_FilePlotBinding.TabIndex = 0;
            this.grd_FilePlotBinding.Text = "radGridView1";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.btnSearch);
            this.radGroupBox2.Controls.Add(this.txtPlotNo);
            this.radGroupBox2.Controls.Add(this.txtFileNo);
            this.radGroupBox2.Controls.Add(this.txtDocumentNo);
            this.radGroupBox2.Controls.Add(this.radLabel3);
            this.radGroupBox2.Controls.Add(this.radLabel2);
            this.radGroupBox2.Controls.Add(this.radLabel1);
            this.radGroupBox2.HeaderText = "File Plot Binding Search";
            this.radGroupBox2.Location = new System.Drawing.Point(6, 0);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(708, 126);
            this.radGroupBox2.TabIndex = 10;
            this.radGroupBox2.Text = "File Plot Binding Search";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(451, 75);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(203, 46);
            this.btnSearch.TabIndex = 6;
            this.btnSearch.Text = "Search . . .";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtPlotNo
            // 
            this.txtPlotNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlotNo.Location = new System.Drawing.Point(451, 34);
            this.txtPlotNo.Name = "txtPlotNo";
            this.txtPlotNo.Size = new System.Drawing.Size(203, 27);
            this.txtPlotNo.TabIndex = 5;
            // 
            // txtFileNo
            // 
            this.txtFileNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileNo.Location = new System.Drawing.Point(132, 81);
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(183, 27);
            this.txtFileNo.TabIndex = 4;
            // 
            // txtDocumentNo
            // 
            this.txtDocumentNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocumentNo.Location = new System.Drawing.Point(132, 34);
            this.txtDocumentNo.Name = "txtDocumentNo";
            this.txtDocumentNo.Size = new System.Drawing.Size(183, 27);
            this.txtDocumentNo.TabIndex = 3;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(358, 34);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(63, 25);
            this.radLabel3.TabIndex = 2;
            this.radLabel3.Text = "Plot No";
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(16, 83);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(59, 25);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "File No";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(16, 34);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(110, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Document No";
            // 
            // frmFilePlotBinding_Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 468);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmFilePlotBinding_Search";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmFilePlotBinding_Search";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_FilePlotBinding.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_FilePlotBinding)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlotNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDocumentNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grd_FilePlotBinding;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadButton btnSearch;
        private Telerik.WinControls.UI.RadTextBox txtPlotNo;
        private Telerik.WinControls.UI.RadTextBox txtFileNo;
        private Telerik.WinControls.UI.RadTextBox txtDocumentNo;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
