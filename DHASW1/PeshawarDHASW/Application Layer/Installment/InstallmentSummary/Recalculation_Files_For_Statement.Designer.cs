namespace PeshawarDHASW.Application_Layer.Installment.InstallmentSummary
{
    partial class Recalculation_Files_For_Statement
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.ReCalBar = new Telerik.WinControls.UI.RadProgressBar();
            this.lblmessage = new Telerik.WinControls.UI.RadLabel();
            this.btn_RecalculationOfReceAdjustment = new Telerik.WinControls.UI.RadButton();
            this.btn_LoadFiles = new Telerik.WinControls.UI.RadButton();
            this.grd_Files = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReCalBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblmessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_RecalculationOfReceAdjustment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_LoadFiles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Files)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Files.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.ReCalBar);
            this.radGroupBox1.Controls.Add(this.lblmessage);
            this.radGroupBox1.Controls.Add(this.btn_RecalculationOfReceAdjustment);
            this.radGroupBox1.Controls.Add(this.btn_LoadFiles);
            this.radGroupBox1.Controls.Add(this.grd_Files);
            this.radGroupBox1.HeaderText = "Recalculation";
            this.radGroupBox1.Location = new System.Drawing.Point(2, 4);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(797, 442);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Recalculation";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // ReCalBar
            // 
            this.ReCalBar.Location = new System.Drawing.Point(349, 134);
            this.ReCalBar.Name = "ReCalBar";
            this.ReCalBar.Size = new System.Drawing.Size(438, 24);
            this.ReCalBar.TabIndex = 4;
            this.ReCalBar.Text = "radProgressBar1";
            this.ReCalBar.ThemeName = "TelerikMetro";
            // 
            // lblmessage
            // 
            this.lblmessage.Location = new System.Drawing.Point(420, 110);
            this.lblmessage.Name = "lblmessage";
            this.lblmessage.Size = new System.Drawing.Size(9, 18);
            this.lblmessage.TabIndex = 3;
            this.lblmessage.Text = ".";
            // 
            // btn_RecalculationOfReceAdjustment
            // 
            this.btn_RecalculationOfReceAdjustment.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_RecalculationOfReceAdjustment.Location = new System.Drawing.Point(348, 64);
            this.btn_RecalculationOfReceAdjustment.Name = "btn_RecalculationOfReceAdjustment";
            this.btn_RecalculationOfReceAdjustment.Size = new System.Drawing.Size(439, 40);
            this.btn_RecalculationOfReceAdjustment.TabIndex = 2;
            this.btn_RecalculationOfReceAdjustment.Text = "Re-Calculate";
            this.btn_RecalculationOfReceAdjustment.ThemeName = "TelerikMetro";
            this.btn_RecalculationOfReceAdjustment.Click += new System.EventHandler(this.btn_RecalculationOfReceAdjustment_Click);
            // 
            // btn_LoadFiles
            // 
            this.btn_LoadFiles.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_LoadFiles.Location = new System.Drawing.Point(348, 21);
            this.btn_LoadFiles.Name = "btn_LoadFiles";
            this.btn_LoadFiles.Size = new System.Drawing.Size(439, 37);
            this.btn_LoadFiles.TabIndex = 1;
            this.btn_LoadFiles.Text = "Load File";
            this.btn_LoadFiles.ThemeName = "TelerikMetro";
            this.btn_LoadFiles.Click += new System.EventHandler(this.btn_LoadFiles_Click);
            // 
            // grd_Files
            // 
            this.grd_Files.Location = new System.Drawing.Point(10, 21);
            // 
            // 
            // 
            this.grd_Files.MasterTemplate.AllowAddNewRow = false;
            this.grd_Files.MasterTemplate.AllowColumnReorder = false;
            this.grd_Files.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "FileNo";
            gridViewTextBoxColumn1.HeaderText = "File No";
            gridViewTextBoxColumn1.Name = "FileNo";
            gridViewTextBoxColumn1.Width = 311;
            this.grd_Files.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
            this.grd_Files.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grd_Files.Name = "grd_Files";
            this.grd_Files.ReadOnly = true;
            this.grd_Files.Size = new System.Drawing.Size(332, 416);
            this.grd_Files.TabIndex = 0;
            this.grd_Files.Text = "radGridView1";
            this.grd_Files.ThemeName = "TelerikMetro";
            // 
            // Recalculation_Files_For_Statement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 445);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "Recalculation_Files_For_Statement";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "All Files Recieve Adjustment For Account Statement";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.Recalculation_Files_For_Statement_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReCalBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblmessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_RecalculationOfReceAdjustment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_LoadFiles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Files.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Files)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btn_RecalculationOfReceAdjustment;
        private Telerik.WinControls.UI.RadButton btn_LoadFiles;
        private Telerik.WinControls.UI.RadGridView grd_Files;
        private Telerik.WinControls.UI.RadLabel lblmessage;
        private Telerik.WinControls.UI.RadProgressBar ReCalBar;
    }
}
