namespace PeshawarDHASW.Application_Layer.OpenTransfer
{
    partial class OpenTransferCheckList
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
            Telerik.WinControls.UI.GridViewCheckBoxColumn gridViewCheckBoxColumn1 = new Telerik.WinControls.UI.GridViewCheckBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnprint = new Telerik.WinControls.UI.RadButton();
            this.lblfile_no = new Telerik.WinControls.UI.RadLabel();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.lblname = new Telerik.WinControls.UI.RadLabel();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.grdTfrChecklist = new Telerik.WinControls.UI.RadGridView();
           // this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnprint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblfile_no)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblname)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTfrChecklist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTfrChecklist.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.btnprint);
            this.radGroupBox1.Controls.Add(this.lblfile_no);
            this.radGroupBox1.Controls.Add(this.radLabel7);
            this.radGroupBox1.Controls.Add(this.lblname);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.grdTfrChecklist);
            this.radGroupBox1.HeaderText = "Checklist For Transfer";
            this.radGroupBox1.Location = new System.Drawing.Point(1, -2);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(622, 584);
            this.radGroupBox1.TabIndex = 12;
            this.radGroupBox1.Text = "Checklist For Transfer";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // btnprint
            // 
            this.btnprint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnprint.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnprint.Location = new System.Drawing.Point(440, 543);
            this.btnprint.Name = "btnprint";
            this.btnprint.Size = new System.Drawing.Size(177, 35);
            this.btnprint.TabIndex = 10;
            this.btnprint.Text = "Print Check List";
            this.btnprint.ThemeName = "TelerikMetro";
            this.btnprint.Click += new System.EventHandler(this.btnprint_Click);
            // 
            // lblfile_no
            // 
            this.lblfile_no.Location = new System.Drawing.Point(51, 22);
            this.lblfile_no.Name = "lblfile_no";
            this.lblfile_no.Size = new System.Drawing.Size(13, 18);
            this.lblfile_no.TabIndex = 4;
            this.lblfile_no.Text = "#";
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(5, 22);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(44, 18);
            this.radLabel7.TabIndex = 3;
            this.radLabel7.Text = "File No.";
            // 
            // lblname
            // 
            this.lblname.Location = new System.Drawing.Point(193, 22);
            this.lblname.Name = "lblname";
            this.lblname.Size = new System.Drawing.Size(13, 18);
            this.lblname.TabIndex = 2;
            this.lblname.Text = "#";
            // 
            // radLabel3
            // 
            this.radLabel3.Location = new System.Drawing.Point(147, 22);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(39, 18);
            this.radLabel3.TabIndex = 1;
            this.radLabel3.Text = "Name:";
            // 
            // grdTfrChecklist
            // 
            this.grdTfrChecklist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTfrChecklist.BackColor = System.Drawing.Color.White;
            this.grdTfrChecklist.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdTfrChecklist.EnableHotTracking = false;
            this.grdTfrChecklist.EnableKeyMap = true;
            this.grdTfrChecklist.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.grdTfrChecklist.ForeColor = System.Drawing.Color.Black;
            this.grdTfrChecklist.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdTfrChecklist.Location = new System.Drawing.Point(5, 46);
            // 
            // 
            // 
            this.grdTfrChecklist.MasterTemplate.AllowAddNewRow = false;
            this.grdTfrChecklist.MasterTemplate.AllowColumnReorder = false;
            this.grdTfrChecklist.MasterTemplate.AllowSearchRow = true;
            this.grdTfrChecklist.MasterTemplate.AutoGenerateColumns = false;
            this.grdTfrChecklist.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "ID";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn2.EnableExpressionEditor = false;
            gridViewTextBoxColumn2.FieldName = "Particular";
            gridViewTextBoxColumn2.HeaderText = "Particular";
            gridViewTextBoxColumn2.Name = "Particular";
            gridViewTextBoxColumn2.Width = 501;
            gridViewCheckBoxColumn1.EnableExpressionEditor = false;
            gridViewCheckBoxColumn1.FieldName = "chkRecieved";
            gridViewCheckBoxColumn1.HeaderText = "Recieved";
            gridViewCheckBoxColumn1.MinWidth = 20;
            gridViewCheckBoxColumn1.Name = "chkRecieved";
            gridViewCheckBoxColumn1.Width = 91;
            this.grdTfrChecklist.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCheckBoxColumn1});
            this.grdTfrChecklist.MasterTemplate.EnableGrouping = false;
            this.grdTfrChecklist.MasterTemplate.EnableSorting = false;
            this.grdTfrChecklist.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdTfrChecklist.Name = "grdTfrChecklist";
            this.grdTfrChecklist.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdTfrChecklist.ShowGroupPanel = false;
            this.grdTfrChecklist.Size = new System.Drawing.Size(612, 491);
            this.grdTfrChecklist.TabIndex = 0;
            this.grdTfrChecklist.Text = "radGridView1";
            this.grdTfrChecklist.ThemeName = "TelerikMetro";
            // 
            // OpenTransferCheckList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 580);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "OpenTransferCheckList";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "OpenTransferCheckList";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.OpenTransferCheckList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnprint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblfile_no)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblname)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTfrChecklist.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTfrChecklist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnprint;
        private Telerik.WinControls.UI.RadLabel lblfile_no;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel lblname;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadGridView grdTfrChecklist;
        //private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
    }
}
