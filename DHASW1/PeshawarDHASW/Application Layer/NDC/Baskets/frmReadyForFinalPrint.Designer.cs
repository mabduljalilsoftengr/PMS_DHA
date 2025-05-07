namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmReadyForFinalPrint
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn2 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grdShowVerifiedNDCS = new Telerik.WinControls.UI.RadGridView();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdShowVerifiedNDCS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShowVerifiedNDCS.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grdShowVerifiedNDCS
            // 
            this.grdShowVerifiedNDCS.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdShowVerifiedNDCS.BackColor = System.Drawing.Color.White;
            this.grdShowVerifiedNDCS.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdShowVerifiedNDCS.EnableKeyMap = true;
            this.grdShowVerifiedNDCS.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grdShowVerifiedNDCS.ForeColor = System.Drawing.Color.Black;
            this.grdShowVerifiedNDCS.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdShowVerifiedNDCS.Location = new System.Drawing.Point(1, 54);
            // 
            // 
            // 
            this.grdShowVerifiedNDCS.MasterTemplate.AllowAddNewRow = false;
            this.grdShowVerifiedNDCS.MasterTemplate.AllowColumnReorder = false;
            this.grdShowVerifiedNDCS.MasterTemplate.AllowSearchRow = true;
            this.grdShowVerifiedNDCS.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "NDCNo";
            gridViewTextBoxColumn1.HeaderText = "NDCNo";
            gridViewTextBoxColumn1.Name = "NDCNo";
            gridViewTextBoxColumn1.Width = 87;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "FilePlotNo";
            gridViewTextBoxColumn2.HeaderText = "FileNo";
            gridViewTextBoxColumn2.Name = "FilePlotNo";
            gridViewTextBoxColumn2.Width = 118;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "NDCTypeNormalUrgent";
            gridViewTextBoxColumn3.HeaderText = "Type";
            gridViewTextBoxColumn3.Name = "NDCTypeNormalUrgent";
            gridViewTextBoxColumn3.Width = 129;
            gridViewTextBoxColumn4.EnableExpressionEditor = false;
            gridViewTextBoxColumn4.FieldName = "AppCacRemarks";
            gridViewTextBoxColumn4.HeaderText = "Remarks";
            gridViewTextBoxColumn4.Name = "AppCacRemarks";
            gridViewTextBoxColumn4.Width = 148;
            gridViewCommandColumn1.DefaultText = "Print";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "btnprint";
            gridViewCommandColumn1.HeaderText = "Print";
            gridViewCommandColumn1.Name = "btnprint";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 88;
            gridViewCommandColumn2.DefaultText = "Back";
            gridViewCommandColumn2.FieldName = "btnBack";
            gridViewCommandColumn2.HeaderText = "Back";
            gridViewCommandColumn2.Name = "btnBack";
            gridViewCommandColumn2.UseDefaultText = true;
            gridViewCommandColumn2.Width = 69;
            this.grdShowVerifiedNDCS.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewCommandColumn1,
            gridViewCommandColumn2});
            this.grdShowVerifiedNDCS.MasterTemplate.EnableFiltering = true;
            this.grdShowVerifiedNDCS.MasterTemplate.EnableSorting = false;
            this.grdShowVerifiedNDCS.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdShowVerifiedNDCS.Name = "grdShowVerifiedNDCS";
            this.grdShowVerifiedNDCS.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdShowVerifiedNDCS.Size = new System.Drawing.Size(655, 590);
            this.grdShowVerifiedNDCS.TabIndex = 2;
            this.grdShowVerifiedNDCS.Text = "radGridView2";
            this.grdShowVerifiedNDCS.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdShowVerifiedNDCS_CellClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Location = new System.Drawing.Point(0, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(149, 44);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmReadyForFinalPrint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 647);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.grdShowVerifiedNDCS);
            this.Name = "frmReadyForFinalPrint";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmReadyForFinalPrint";
            this.Load += new System.EventHandler(this.frmReadyForFinalPrint_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdShowVerifiedNDCS.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdShowVerifiedNDCS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grdShowVerifiedNDCS;
        private Telerik.WinControls.UI.RadButton btnRefresh;
    }
}
