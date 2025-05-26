namespace PeshawarDHASW.Application_Layer.Installment.InstallmentSummary
{
    partial class frmFileWise_Summary
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox6 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnExcelExport = new Telerik.WinControls.UI.RadButton();
            this.btn_Template_Wise_Find = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox4 = new Telerik.WinControls.UI.RadGroupBox();
            this.grd_Template_wise_search = new Telerik.WinControls.UI.RadGridView();
            this.drp_instl_Tmplt = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox6)).BeginInit();
            this.radGroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcelExport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Template_Wise_Find)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).BeginInit();
            this.radGroupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Template_wise_search)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Template_wise_search.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.drp_instl_Tmplt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox6
            // 
            this.radGroupBox6.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox6.Controls.Add(this.btnExcelExport);
            this.radGroupBox6.Controls.Add(this.btn_Template_Wise_Find);
            this.radGroupBox6.Controls.Add(this.radGroupBox4);
            this.radGroupBox6.Controls.Add(this.drp_instl_Tmplt);
            this.radGroupBox6.Controls.Add(this.radLabel6);
            this.radGroupBox6.HeaderText = "Installment Search";
            this.radGroupBox6.Location = new System.Drawing.Point(1, 2);
            this.radGroupBox6.Name = "radGroupBox6";
            this.radGroupBox6.Size = new System.Drawing.Size(1262, 699);
            this.radGroupBox6.TabIndex = 3;
            this.radGroupBox6.Text = "Installment Search";
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExcelExport.Location = new System.Drawing.Point(736, 21);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(210, 29);
            this.btnExcelExport.TabIndex = 16;
            this.btnExcelExport.Text = "Excel Export";
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // btn_Template_Wise_Find
            // 
            this.btn_Template_Wise_Find.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Template_Wise_Find.Location = new System.Drawing.Point(520, 21);
            this.btn_Template_Wise_Find.Name = "btn_Template_Wise_Find";
            this.btn_Template_Wise_Find.Size = new System.Drawing.Size(210, 29);
            this.btn_Template_Wise_Find.TabIndex = 15;
            this.btn_Template_Wise_Find.Text = "Find";
            this.btn_Template_Wise_Find.Click += new System.EventHandler(this.btn_Template_Wise_Find_Click);
            // 
            // radGroupBox4
            // 
            this.radGroupBox4.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox4.Controls.Add(this.grd_Template_wise_search);
            this.radGroupBox4.HeaderText = "Paid Installment";
            this.radGroupBox4.Location = new System.Drawing.Point(10, 56);
            this.radGroupBox4.Name = "radGroupBox4";
            this.radGroupBox4.Size = new System.Drawing.Size(1247, 638);
            this.radGroupBox4.TabIndex = 1;
            this.radGroupBox4.Text = "Paid Installment";
            // 
            // grd_Template_wise_search
            // 
            this.grd_Template_wise_search.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_Template_wise_search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.grd_Template_wise_search.Cursor = System.Windows.Forms.Cursors.Default;
            this.grd_Template_wise_search.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grd_Template_wise_search.ForeColor = System.Drawing.Color.Black;
            this.grd_Template_wise_search.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grd_Template_wise_search.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.grd_Template_wise_search.MasterTemplate.AllowAddNewRow = false;
            this.grd_Template_wise_search.MasterTemplate.AllowDeleteRow = false;
            this.grd_Template_wise_search.MasterTemplate.AllowEditRow = false;
            this.grd_Template_wise_search.MasterTemplate.AllowSearchRow = true;
            this.grd_Template_wise_search.MasterTemplate.EnableAlternatingRowColor = true;
            this.grd_Template_wise_search.MasterTemplate.EnableFiltering = true;
            this.grd_Template_wise_search.MasterTemplate.ShowTotals = true;
            this.grd_Template_wise_search.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grd_Template_wise_search.Name = "grd_Template_wise_search";
            this.grd_Template_wise_search.ReadOnly = true;
            this.grd_Template_wise_search.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grd_Template_wise_search.Size = new System.Drawing.Size(1237, 612);
            this.grd_Template_wise_search.TabIndex = 2;
            this.grd_Template_wise_search.Text = "Paid Installments";
            this.grd_Template_wise_search.CellDoubleClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grd_Template_wise_search_CellDoubleClick);
            // 
            // drp_instl_Tmplt
            // 
            this.drp_instl_Tmplt.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.drp_instl_Tmplt.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drp_instl_Tmplt.Location = new System.Drawing.Point(183, 21);
            this.drp_instl_Tmplt.Name = "drp_instl_Tmplt";
            this.drp_instl_Tmplt.Size = new System.Drawing.Size(331, 27);
            this.drp_instl_Tmplt.TabIndex = 8;
            this.drp_instl_Tmplt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.drp_instl_Tmplt_KeyPress);
            // 
            // radLabel6
            // 
            this.radLabel6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel6.Location = new System.Drawing.Point(17, 21);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(160, 25);
            this.radLabel6.TabIndex = 1;
            this.radLabel6.Text = "Installment Template";
            // 
            // frmFileWise_Summary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 702);
            this.Controls.Add(this.radGroupBox6);
            this.Name = "frmFileWise_Summary";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "File Wise Summary";
            this.Load += new System.EventHandler(this.frmFileWise_Summary_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox6)).EndInit();
            this.radGroupBox6.ResumeLayout(false);
            this.radGroupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnExcelExport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Template_Wise_Find)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox4)).EndInit();
            this.radGroupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_Template_wise_search.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Template_wise_search)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.drp_instl_Tmplt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox6;
        private Telerik.WinControls.UI.RadButton btn_Template_Wise_Find;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox4;
        private Telerik.WinControls.UI.RadGridView grd_Template_wise_search;
        private Telerik.WinControls.UI.RadDropDownList drp_instl_Tmplt;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadButton btnExcelExport;
    }
}
