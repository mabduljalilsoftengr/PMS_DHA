namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmTransferLetterImageUpload_Basket
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdTFRLetterImageUpload = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTFRLetterImageUpload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTFRLetterImageUpload.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.grdTFRLetterImageUpload);
            this.radGroupBox1.HeaderText = "Image Upload";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(635, 656);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Image Upload";
            // 
            // grdTFRLetterImageUpload
            // 
            this.grdTFRLetterImageUpload.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTFRLetterImageUpload.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.grdTFRLetterImageUpload.MasterTemplate.AllowAddNewRow = false;
            this.grdTFRLetterImageUpload.MasterTemplate.AllowColumnReorder = false;
            this.grdTFRLetterImageUpload.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "TransferNo";
            gridViewTextBoxColumn1.HeaderText = "Transfer No";
            gridViewTextBoxColumn1.Name = "TransferNo";
            gridViewTextBoxColumn1.Width = 122;
            gridViewTextBoxColumn2.FieldName = "FileNo";
            gridViewTextBoxColumn2.HeaderText = "File No";
            gridViewTextBoxColumn2.Name = "FileNo";
            gridViewTextBoxColumn2.Width = 122;
            gridViewTextBoxColumn3.FieldName = "NDCNo";
            gridViewTextBoxColumn3.HeaderText = "NDC No";
            gridViewTextBoxColumn3.Name = "NDCNo";
            gridViewTextBoxColumn3.Width = 122;
            gridViewTextBoxColumn4.FieldName = "TransferDate";
            gridViewTextBoxColumn4.HeaderText = "Transfer Date";
            gridViewTextBoxColumn4.Name = "TransferDate";
            gridViewTextBoxColumn4.Width = 122;
            gridViewCommandColumn1.DefaultText = "Upload";
            gridViewCommandColumn1.FieldName = "TFR_LetterImageUpload";
            gridViewCommandColumn1.HeaderText = "Transfer Letter Image";
            gridViewCommandColumn1.Name = "TFR_LetterImageUpload";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 120;
            this.grdTFRLetterImageUpload.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewCommandColumn1});
            this.grdTFRLetterImageUpload.MasterTemplate.EnableGrouping = false;
            this.grdTFRLetterImageUpload.MasterTemplate.EnableSorting = false;
            this.grdTFRLetterImageUpload.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdTFRLetterImageUpload.Name = "grdTFRLetterImageUpload";
            this.grdTFRLetterImageUpload.ShowGroupPanel = false;
            this.grdTFRLetterImageUpload.Size = new System.Drawing.Size(625, 630);
            this.grdTFRLetterImageUpload.TabIndex = 0;
            this.grdTFRLetterImageUpload.Text = "radGridView1";
            this.grdTFRLetterImageUpload.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdTFRLetterImageUpload_CellClick);
            // 
            // frmTransferLetterImageUpload_Basket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 670);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmTransferLetterImageUpload_Basket";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmTransferLetterImageUpload_Basket";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmTransferLetterImageUpload_Basket_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTFRLetterImageUpload.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTFRLetterImageUpload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grdTFRLetterImageUpload;
    }
}
