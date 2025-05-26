namespace PeshawarDHASW.Application_Layer.Installment.InstRece_Lock
{
    partial class frmInstRece_DateLock
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radDateLock = new Telerik.WinControls.UI.RadGridView();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radDateLock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDateLock.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radDateLock);
            this.radGroupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(730, 468);
            this.radGroupBox1.TabIndex = 0;
            // 
            // radDateLock
            // 
            this.radDateLock.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(219)))), ((int)(((byte)(255)))));
            this.radDateLock.Cursor = System.Windows.Forms.Cursors.Default;
            this.radDateLock.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radDateLock.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.radDateLock.ForeColor = System.Drawing.Color.Black;
            this.radDateLock.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.radDateLock.Location = new System.Drawing.Point(2, 18);
            // 
            // 
            // 
            this.radDateLock.MasterTemplate.AllowAddNewRow = false;
            this.radDateLock.MasterTemplate.AllowColumnReorder = false;
            this.radDateLock.MasterTemplate.AllowSearchRow = true;
            this.radDateLock.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "LockDateID";
            gridViewTextBoxColumn1.HeaderText = "LockDateID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "LockDateID";
            gridViewTextBoxColumn1.ReadOnly = true;
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "LockMonth";
            gridViewTextBoxColumn2.HeaderText = "Lock Month";
            gridViewTextBoxColumn2.Name = "LockMonth";
            gridViewTextBoxColumn2.ReadOnly = true;
            gridViewTextBoxColumn2.Width = 236;
            gridViewTextBoxColumn3.EnableExpressionEditor = false;
            gridViewTextBoxColumn3.FieldName = "LockDate";
            gridViewTextBoxColumn3.HeaderText = "Lock Date";
            gridViewTextBoxColumn3.Name = "LockDate";
            gridViewTextBoxColumn3.ReadOnly = true;
            gridViewTextBoxColumn3.Width = 236;
            gridViewCheckBoxColumn1.EditMode = Telerik.WinControls.UI.EditMode.OnValueChange;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "LockStatus";
            gridViewCheckBoxColumn1.HeaderText = "Lock Status";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "LockStatus";
            gridViewCheckBoxColumn1.Width = 235;
            this.radDateLock.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewCheckBoxColumn1});
            this.radDateLock.MasterTemplate.EnableFiltering = true;
            this.radDateLock.MasterTemplate.ShowFilteringRow = false;
            this.radDateLock.MasterTemplate.ShowHeaderCellButtons = true;
            this.radDateLock.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radDateLock.Name = "radDateLock";
            this.radDateLock.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.radDateLock.ShowHeaderCellButtons = true;
            this.radDateLock.Size = new System.Drawing.Size(726, 448);
            this.radDateLock.TabIndex = 0;
            this.radDateLock.Text = "radGridView1";
            this.radDateLock.ThemeName = "TelerikMetro";
            this.radDateLock.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radDateLock_CellValueChanged);
            // 
            // frmInstRece_DateLock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 468);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmInstRece_DateLock";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmInstRece_DateLock";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmInstRece_DateLock_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radDateLock.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radDateLock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView radDateLock;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
    }
}
