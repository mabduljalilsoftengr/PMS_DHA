namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frm_NDCDealCancellationProcess
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn2 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition4 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox8 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdCancelNDC = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdImagePreview = new Telerik.WinControls.UI.RadGridView();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnResfresh = new Telerik.WinControls.UI.RadButton();
            this.btngoback = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox8)).BeginInit();
            this.radGroupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdCancelNDC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCancelNDC.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdImagePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImagePreview.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnResfresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btngoback)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox8
            // 
            this.radGroupBox8.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox8.Controls.Add(this.grdCancelNDC);
            this.radGroupBox8.HeaderText = "Waiting for Refund (Cancel NDC\'s)";
            this.radGroupBox8.Location = new System.Drawing.Point(4, 62);
            this.radGroupBox8.Name = "radGroupBox8";
            this.radGroupBox8.Size = new System.Drawing.Size(390, 283);
            this.radGroupBox8.TabIndex = 15;
            this.radGroupBox8.Text = "Waiting for Refund (Cancel NDC\'s)";
            // 
            // grdCancelNDC
            // 
            this.grdCancelNDC.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdCancelNDC.EnableKeyMap = true;
            this.grdCancelNDC.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.grdCancelNDC.MasterTemplate.AllowAddNewRow = false;
            this.grdCancelNDC.MasterTemplate.AllowColumnReorder = false;
            this.grdCancelNDC.MasterTemplate.AllowSearchRow = true;
            this.grdCancelNDC.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn5.FieldName = "NDCNo";
            gridViewTextBoxColumn5.HeaderText = "NDCNo";
            gridViewTextBoxColumn5.Name = "NDCNo";
            gridViewTextBoxColumn5.Width = 87;
            gridViewTextBoxColumn6.FieldName = "FilePlotNo";
            gridViewTextBoxColumn6.HeaderText = "FileNo";
            gridViewTextBoxColumn6.Name = "FilePlotNo";
            gridViewTextBoxColumn6.Width = 134;
            gridViewCommandColumn3.DefaultText = "Report";
            gridViewCommandColumn3.FieldName = "btnRefund";
            gridViewCommandColumn3.HeaderText = "Report";
            gridViewCommandColumn3.Name = "btnRefund";
            gridViewCommandColumn3.UseDefaultText = true;
            gridViewCommandColumn3.Width = 96;
            gridViewCommandColumn4.DefaultText = "Img";
            gridViewCommandColumn4.FieldName = "btnAttachments";
            gridViewCommandColumn4.HeaderText = "Attach";
            gridViewCommandColumn4.Name = "btnAttachments";
            gridViewCommandColumn4.UseDefaultText = true;
            gridViewCommandColumn4.Width = 45;
            this.grdCancelNDC.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewCommandColumn3,
            gridViewCommandColumn4});
            this.grdCancelNDC.MasterTemplate.EnableGrouping = false;
            this.grdCancelNDC.MasterTemplate.EnableSorting = false;
            this.grdCancelNDC.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.grdCancelNDC.Name = "grdCancelNDC";
            this.grdCancelNDC.Size = new System.Drawing.Size(380, 257);
            this.grdCancelNDC.TabIndex = 1;
            this.grdCancelNDC.Text = "radGridView2";
            this.grdCancelNDC.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdCancelNDC_CellClick);
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.grdImagePreview);
            this.radGroupBox3.HeaderText = "Image Preview";
            this.radGroupBox3.Location = new System.Drawing.Point(400, 61);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(390, 284);
            this.radGroupBox3.TabIndex = 16;
            this.radGroupBox3.Text = "Image Preview";
            // 
            // grdImagePreview
            // 
            this.grdImagePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdImagePreview.EnableKeyMap = true;
            this.grdImagePreview.Location = new System.Drawing.Point(5, 20);
            // 
            // 
            // 
            this.grdImagePreview.MasterTemplate.AllowAddNewRow = false;
            this.grdImagePreview.MasterTemplate.AllowColumnReorder = false;
            this.grdImagePreview.MasterTemplate.AllowSearchRow = true;
            this.grdImagePreview.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewImageColumn2.FieldName = "MemberImage";
            gridViewImageColumn2.HeaderText = "Image Preview";
            gridViewImageColumn2.Name = "MemberImage";
            gridViewImageColumn2.Width = 274;
            gridViewTextBoxColumn7.FieldName = "ImageName";
            gridViewTextBoxColumn7.HeaderText = "Name";
            gridViewTextBoxColumn7.Name = "ImageName";
            gridViewTextBoxColumn7.Width = 86;
            gridViewTextBoxColumn8.FieldName = "Description";
            gridViewTextBoxColumn8.HeaderText = "Description";
            gridViewTextBoxColumn8.IsVisible = false;
            gridViewTextBoxColumn8.Name = "Description";
            gridViewTextBoxColumn8.Width = 44;
            this.grdImagePreview.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewImageColumn2,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.grdImagePreview.MasterTemplate.EnableGrouping = false;
            this.grdImagePreview.MasterTemplate.EnableSorting = false;
            this.grdImagePreview.MasterTemplate.ViewDefinition = tableViewDefinition4;
            this.grdImagePreview.Name = "grdImagePreview";
            this.grdImagePreview.Size = new System.Drawing.Size(380, 258);
            this.grdImagePreview.TabIndex = 1;
            this.grdImagePreview.Text = "radGridView2";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(400, 354);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(229, 40);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "Save and Go Next";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnResfresh
            // 
            this.btnResfresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResfresh.Location = new System.Drawing.Point(5, 12);
            this.btnResfresh.Name = "btnResfresh";
            this.btnResfresh.Size = new System.Drawing.Size(229, 40);
            this.btnResfresh.TabIndex = 18;
            this.btnResfresh.Text = "Refresh";
            this.btnResfresh.Click += new System.EventHandler(this.btnResfresh_Click);
            // 
            // btngoback
            // 
            this.btngoback.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngoback.Location = new System.Drawing.Point(165, 354);
            this.btngoback.Name = "btngoback";
            this.btngoback.Size = new System.Drawing.Size(229, 40);
            this.btngoback.TabIndex = 19;
            this.btngoback.Text = "Go Back";
            this.btngoback.Click += new System.EventHandler(this.btngoback_Click);
            // 
            // frm_NDCDealCancellationProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 398);
            this.Controls.Add(this.btngoback);
            this.Controls.Add(this.btnResfresh);
            this.Controls.Add(this.radGroupBox8);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.btnSave);
            this.Name = "frm_NDCDealCancellationProcess";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frm_NDCDealCancellationProcess";
            this.Load += new System.EventHandler(this.frm_NDCDealCancellationProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox8)).EndInit();
            this.radGroupBox8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdCancelNDC.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCancelNDC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdImagePreview.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImagePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnResfresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btngoback)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox8;
        private Telerik.WinControls.UI.RadGridView grdCancelNDC;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadGridView grdImagePreview;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnResfresh;
        private Telerik.WinControls.UI.RadButton btngoback;
    }
}
