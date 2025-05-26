namespace PeshawarDHASW.Application_Layer.IN_OUT_Mail
{
    partial class Incoming_Mail
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.RGV_IncomingMail = new Telerik.WinControls.UI.RadGridView();
            this.btnIncomingMailNew = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RGV_IncomingMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGV_IncomingMail.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIncomingMailNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.RGV_IncomingMail);
            this.radGroupBox1.HeaderText = "Incoming Mail Information";
            this.radGroupBox1.Location = new System.Drawing.Point(2, 30);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1167, 354);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Incoming Mail Information";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // RGV_IncomingMail
            // 
            this.RGV_IncomingMail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RGV_IncomingMail.BackColor = System.Drawing.Color.White;
            this.RGV_IncomingMail.Cursor = System.Windows.Forms.Cursors.Default;
            this.RGV_IncomingMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.RGV_IncomingMail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RGV_IncomingMail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RGV_IncomingMail.Location = new System.Drawing.Point(5, 35);
            // 
            // 
            // 
            this.RGV_IncomingMail.MasterTemplate.AllowAddNewRow = false;
            this.RGV_IncomingMail.MasterTemplate.AllowColumnReorder = false;
            this.RGV_IncomingMail.MasterTemplate.AllowDeleteRow = false;
            this.RGV_IncomingMail.MasterTemplate.AllowSearchRow = true;
            this.RGV_IncomingMail.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn8.EnableExpressionEditor = false;
            gridViewTextBoxColumn8.FieldName = "DiaryNo";
            gridViewTextBoxColumn8.HeaderText = "DiaryNo";
            gridViewTextBoxColumn8.Name = "DiaryNo";
            gridViewTextBoxColumn8.Width = 125;
            gridViewTextBoxColumn9.EnableExpressionEditor = false;
            gridViewTextBoxColumn9.FieldName = "LtrNo";
            gridViewTextBoxColumn9.HeaderText = "Letter No";
            gridViewTextBoxColumn9.Name = "LtrNo";
            gridViewTextBoxColumn9.Width = 118;
            gridViewTextBoxColumn10.EnableExpressionEditor = false;
            gridViewTextBoxColumn10.FieldName = "ReceivedDate";
            gridViewTextBoxColumn10.HeaderText = "Received Date";
            gridViewTextBoxColumn10.Name = "ReceivedDate";
            gridViewTextBoxColumn10.Width = 100;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "Date_FileNo";
            gridViewTextBoxColumn11.HeaderText = "Letter Name";
            gridViewTextBoxColumn11.Name = "Date_FileNo";
            gridViewTextBoxColumn11.Width = 107;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "Subject";
            gridViewTextBoxColumn12.HeaderText = "Subject";
            gridViewTextBoxColumn12.Name = "Subject";
            gridViewTextBoxColumn12.Width = 150;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "FromWhomReceived";
            gridViewTextBoxColumn13.HeaderText = "From Whom Received";
            gridViewTextBoxColumn13.Name = "FromWhomReceived";
            gridViewTextBoxColumn13.Width = 164;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.FieldName = "Remarks";
            gridViewTextBoxColumn14.HeaderText = "Remarks";
            gridViewTextBoxColumn14.Name = "Remarks";
            gridViewTextBoxColumn14.Width = 149;
            gridViewCommandColumn3.DefaultText = "Edit";
            gridViewCommandColumn3.EnableExpressionEditor = false;
            gridViewCommandColumn3.HeaderText = "Edit";
            gridViewCommandColumn3.Name = "btnEdit";
            gridViewCommandColumn3.UseDefaultText = true;
            gridViewCommandColumn3.Width = 113;
            gridViewCommandColumn4.DefaultText = "Docments";
            gridViewCommandColumn4.EnableExpressionEditor = false;
            gridViewCommandColumn4.FieldName = "ScanDoc";
            gridViewCommandColumn4.HeaderText = "Document";
            gridViewCommandColumn4.Name = "ScanDoc";
            gridViewCommandColumn4.UseDefaultText = true;
            gridViewCommandColumn4.Width = 113;
            this.RGV_IncomingMail.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn8,
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewCommandColumn3,
            gridViewCommandColumn4});
            this.RGV_IncomingMail.MasterTemplate.EnableFiltering = true;
            this.RGV_IncomingMail.MasterTemplate.ShowFilteringRow = false;
            this.RGV_IncomingMail.MasterTemplate.ShowHeaderCellButtons = true;
            this.RGV_IncomingMail.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.RGV_IncomingMail.Name = "RGV_IncomingMail";
            this.RGV_IncomingMail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RGV_IncomingMail.ShowHeaderCellButtons = true;
            this.RGV_IncomingMail.Size = new System.Drawing.Size(1157, 313);
            this.RGV_IncomingMail.TabIndex = 0;
            this.RGV_IncomingMail.Text = "radGridView1";
            this.RGV_IncomingMail.ThemeName = "TelerikMetro";
            this.RGV_IncomingMail.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.RGV_IncomingMail_CellClick);
            // 
            // btnIncomingMailNew
            // 
            this.btnIncomingMailNew.Location = new System.Drawing.Point(12, 0);
            this.btnIncomingMailNew.Name = "btnIncomingMailNew";
            this.btnIncomingMailNew.Size = new System.Drawing.Size(218, 24);
            this.btnIncomingMailNew.TabIndex = 1;
            this.btnIncomingMailNew.Text = "New";
            this.btnIncomingMailNew.ThemeName = "TelerikMetro";
            this.btnIncomingMailNew.Click += new System.EventHandler(this.btnIncomingMailNew_Click);
            // 
            // Incoming_Mail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1170, 390);
            this.Controls.Add(this.btnIncomingMailNew);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "Incoming_Mail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Incoming_Mail";
            this.ThemeName = "TelerikMetro";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Incoming_Mail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RGV_IncomingMail.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGV_IncomingMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnIncomingMailNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView RGV_IncomingMail;
        private Telerik.WinControls.UI.RadButton btnIncomingMailNew;
    }
}
