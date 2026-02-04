namespace PeshawarDHASW.Application_Layer.Image_Archiving
{
    partial class frmBulkFileUpload
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
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn1 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 0", "SNo");
            Telerik.WinControls.UI.ListViewDetailColumn listViewDetailColumn2 = new Telerik.WinControls.UI.ListViewDetailColumn("Column 1", "Status Description");
            this.label1 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblSuccessmessage = new Telerik.WinControls.UI.RadLabel();
            this.btnUploadFiletoServer = new Telerik.WinControls.UI.RadButton();
            this.btnCustomFolderUpload = new Telerik.WinControls.UI.RadButton();
            this.radListView1 = new Telerik.WinControls.UI.RadListView();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            ((System.ComponentModel.ISupportInitialize)(this.lblSuccessmessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUploadFiletoServer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomFolderUpload)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Status :";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(68, 82);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(129, 16);
            this.lblStatus.TabIndex = 10;
            this.lblStatus.Text = "Data Loading Status";
            // 
            // lblSuccessmessage
            // 
            this.lblSuccessmessage.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuccessmessage.Location = new System.Drawing.Point(15, 99);
            this.lblSuccessmessage.Name = "lblSuccessmessage";
            this.lblSuccessmessage.Size = new System.Drawing.Size(12, 21);
            this.lblSuccessmessage.TabIndex = 9;
            this.lblSuccessmessage.Text = "*";
            // 
            // btnUploadFiletoServer
            // 
            this.btnUploadFiletoServer.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUploadFiletoServer.Location = new System.Drawing.Point(12, 12);
            this.btnUploadFiletoServer.Name = "btnUploadFiletoServer";
            this.btnUploadFiletoServer.Size = new System.Drawing.Size(185, 55);
            this.btnUploadFiletoServer.TabIndex = 12;
            this.btnUploadFiletoServer.Text = "Start File Uploading";
            this.btnUploadFiletoServer.ThemeName = "TelerikMetro";
            this.btnUploadFiletoServer.Click += new System.EventHandler(this.btnUploadFiletoServer_Click);
            // 
            // btnCustomFolderUpload
            // 
            this.btnCustomFolderUpload.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCustomFolderUpload.Location = new System.Drawing.Point(203, 12);
            this.btnCustomFolderUpload.Name = "btnCustomFolderUpload";
            this.btnCustomFolderUpload.Size = new System.Drawing.Size(277, 55);
            this.btnCustomFolderUpload.TabIndex = 13;
            this.btnCustomFolderUpload.Text = "Start Custom Folder File Uploading";
            this.btnCustomFolderUpload.ThemeName = "TelerikMetro";
            this.btnCustomFolderUpload.Click += new System.EventHandler(this.btnCustomFolderUpload_Click);
            // 
            // radListView1
            // 
            this.radListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            listViewDetailColumn1.HeaderText = "SNo";
            listViewDetailColumn1.Width = 50F;
            listViewDetailColumn2.HeaderText = "Status Description";
            listViewDetailColumn2.Width = 850F;
            this.radListView1.Columns.AddRange(new Telerik.WinControls.UI.ListViewDetailColumn[] {
            listViewDetailColumn1,
            listViewDetailColumn2});
            this.radListView1.EnableFiltering = true;
            this.radListView1.ItemSpacing = -1;
            this.radListView1.Location = new System.Drawing.Point(13, 127);
            this.radListView1.Name = "radListView1";
            this.radListView1.ShowGridLines = true;
            this.radListView1.ShowGroups = true;
            this.radListView1.Size = new System.Drawing.Size(902, 428);
            this.radListView1.TabIndex = 14;
            this.radListView1.Text = "radListView1";
            this.radListView1.ThemeName = "TelerikMetro";
            this.radListView1.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            // 
            // frmBulkFileUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(927, 559);
            this.Controls.Add(this.radListView1);
            this.Controls.Add(this.btnCustomFolderUpload);
            this.Controls.Add(this.btnUploadFiletoServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblSuccessmessage);
            this.Name = "frmBulkFileUpload";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmBulkFileUpload";
            this.ThemeName = "TelerikMetro";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.lblSuccessmessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnUploadFiletoServer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCustomFolderUpload)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblStatus;
        private Telerik.WinControls.UI.RadLabel lblSuccessmessage;
        private Telerik.WinControls.UI.RadButton btnUploadFiletoServer;
        private Telerik.WinControls.UI.RadButton btnCustomFolderUpload;
        private Telerik.WinControls.UI.RadListView radListView1;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
    }
}
