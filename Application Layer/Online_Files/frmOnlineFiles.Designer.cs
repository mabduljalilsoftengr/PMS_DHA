namespace PeshawarDHASW.Application_Layer.Online_Files
{
    partial class frmOnlineFiles
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
            this.gdvFiledata = new Telerik.WinControls.UI.RadGridView();
            this.btnNewFile = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.gdvFiledata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvFiledata.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // gdvFiledata
            // 
            this.gdvFiledata.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.gdvFiledata.Cursor = System.Windows.Forms.Cursors.Default;
            this.gdvFiledata.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gdvFiledata.ForeColor = System.Drawing.Color.Black;
            this.gdvFiledata.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.gdvFiledata.Location = new System.Drawing.Point(12, 69);
            // 
            // 
            // 
            this.gdvFiledata.MasterTemplate.AllowAddNewRow = false;
            this.gdvFiledata.MasterTemplate.AllowColumnReorder = false;
            this.gdvFiledata.MasterTemplate.AllowSearchRow = true;
            this.gdvFiledata.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.gdvFiledata.MasterTemplate.EnableAlternatingRowColor = true;
            this.gdvFiledata.MasterTemplate.EnableFiltering = true;
            this.gdvFiledata.MasterTemplate.ShowFilteringRow = false;
            this.gdvFiledata.MasterTemplate.ShowHeaderCellButtons = true;
            this.gdvFiledata.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.gdvFiledata.Name = "gdvFiledata";
            this.gdvFiledata.ReadOnly = true;
            this.gdvFiledata.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gdvFiledata.ShowHeaderCellButtons = true;
            this.gdvFiledata.Size = new System.Drawing.Size(861, 335);
            this.gdvFiledata.TabIndex = 0;
            this.gdvFiledata.Text = "radGridView1";
            this.gdvFiledata.ThemeName = "TelerikMetro";
            // 
            // btnNewFile
            // 
            this.btnNewFile.Location = new System.Drawing.Point(12, 27);
            this.btnNewFile.Name = "btnNewFile";
            this.btnNewFile.Size = new System.Drawing.Size(112, 36);
            this.btnNewFile.TabIndex = 1;
            this.btnNewFile.Text = "New File";
            this.btnNewFile.ThemeName = "TelerikMetro";
            this.btnNewFile.Click += new System.EventHandler(this.btnNewFile_Click);
            // 
            // frmOnlineFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 416);
            this.Controls.Add(this.btnNewFile);
            this.Controls.Add(this.gdvFiledata);
            this.Name = "frmOnlineFiles";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmOnlineFiles";
            ((System.ComponentModel.ISupportInitialize)(this.gdvFiledata.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gdvFiledata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnNewFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView gdvFiledata;
        private Telerik.WinControls.UI.RadButton btnNewFile;
    }
}
