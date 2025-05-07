namespace PeshawarDHASW.Application_Layer.Image_Archiving
{
    partial class SelectScanner
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnScanDocuments = new Telerik.WinControls.UI.RadButton();
            this.btnAddImagesToGrid = new Telerik.WinControls.UI.RadButton();
            this.lbDevices = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnScanDocuments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddImagesToGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(22, 162);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(68, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Devices ";
            // 
            // btnScanDocuments
            // 
            this.btnScanDocuments.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanDocuments.Location = new System.Drawing.Point(22, 3);
            this.btnScanDocuments.Name = "btnScanDocuments";
            this.btnScanDocuments.Size = new System.Drawing.Size(369, 51);
            this.btnScanDocuments.TabIndex = 2;
            this.btnScanDocuments.Text = "Scan Documents";
            this.btnScanDocuments.Click += new System.EventHandler(this.btnScanDocuments_Click);
            // 
            // btnAddImagesToGrid
            // 
            this.btnAddImagesToGrid.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddImagesToGrid.Location = new System.Drawing.Point(22, 80);
            this.btnAddImagesToGrid.Name = "btnAddImagesToGrid";
            this.btnAddImagesToGrid.Size = new System.Drawing.Size(369, 51);
            this.btnAddImagesToGrid.TabIndex = 3;
            this.btnAddImagesToGrid.Text = "Add Images To Grid";
            this.btnAddImagesToGrid.Click += new System.EventHandler(this.btnAddImagesToGrid_Click);
            // 
            // lbDevices
            // 
            this.lbDevices.FormattingEnabled = true;
            this.lbDevices.Location = new System.Drawing.Point(87, 162);
            this.lbDevices.Name = "lbDevices";
            this.lbDevices.Size = new System.Drawing.Size(304, 30);
            this.lbDevices.TabIndex = 4;
            // 
            // SelectScanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 209);
            this.Controls.Add(this.lbDevices);
            this.Controls.Add(this.btnAddImagesToGrid);
            this.Controls.Add(this.btnScanDocuments);
            this.Controls.Add(this.radLabel1);
            this.Name = "SelectScanner";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "SelectScanner";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnScanDocuments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAddImagesToGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton btnScanDocuments;
        private Telerik.WinControls.UI.RadButton btnAddImagesToGrid;
        private System.Windows.Forms.ListBox lbDevices;
    }
}
