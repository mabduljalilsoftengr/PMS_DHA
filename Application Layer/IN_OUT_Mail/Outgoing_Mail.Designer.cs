namespace PeshawarDHASW.Application_Layer.IN_OUT_Mail
{
    partial class Outgoing_Mail
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn17 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn18 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn19 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn20 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn3 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn4 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.btnOutgoingMailNew = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.RGV_OutgoingMail = new Telerik.WinControls.UI.RadGridView();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            ((System.ComponentModel.ISupportInitialize)(this.btnOutgoingMailNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RGV_OutgoingMail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGV_OutgoingMail.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOutgoingMailNew
            // 
            this.btnOutgoingMailNew.Location = new System.Drawing.Point(12, 5);
            this.btnOutgoingMailNew.Name = "btnOutgoingMailNew";
            this.btnOutgoingMailNew.Size = new System.Drawing.Size(110, 24);
            this.btnOutgoingMailNew.TabIndex = 3;
            this.btnOutgoingMailNew.Text = "New";
            this.btnOutgoingMailNew.ThemeName = "TelerikMetro";
            this.btnOutgoingMailNew.Click += new System.EventHandler(this.btnOutgoingMailNew_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.RGV_OutgoingMail);
            this.radGroupBox1.HeaderText = "Incoming Mail Information";
            this.radGroupBox1.Location = new System.Drawing.Point(2, 35);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(1135, 354);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "Incoming Mail Information";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // RGV_OutgoingMail
            // 
            this.RGV_OutgoingMail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RGV_OutgoingMail.BackColor = System.Drawing.Color.White;
            this.RGV_OutgoingMail.Cursor = System.Windows.Forms.Cursors.Default;
            this.RGV_OutgoingMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.RGV_OutgoingMail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.RGV_OutgoingMail.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.RGV_OutgoingMail.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.RGV_OutgoingMail.MasterTemplate.AllowAddNewRow = false;
            this.RGV_OutgoingMail.MasterTemplate.AllowColumnReorder = false;
            this.RGV_OutgoingMail.MasterTemplate.AllowDeleteRow = false;
            this.RGV_OutgoingMail.MasterTemplate.AllowSearchRow = true;
            this.RGV_OutgoingMail.MasterTemplate.AutoGenerateColumns = false;
            gridViewTextBoxColumn11.EnableExpressionEditor = false;
            gridViewTextBoxColumn11.FieldName = "SerNo";
            gridViewTextBoxColumn11.HeaderText = "Doc No";
            gridViewTextBoxColumn11.Name = "SerNo";
            gridViewTextBoxColumn11.Width = 86;
            gridViewTextBoxColumn12.EnableExpressionEditor = false;
            gridViewTextBoxColumn12.FieldName = "FileNo";
            gridViewTextBoxColumn12.HeaderText = "FileNo";
            gridViewTextBoxColumn12.Name = "FileNo";
            gridViewTextBoxColumn12.Width = 78;
            gridViewTextBoxColumn13.EnableExpressionEditor = false;
            gridViewTextBoxColumn13.FieldName = "ReceivedDate";
            gridViewTextBoxColumn13.HeaderText = "Received Date";
            gridViewTextBoxColumn13.Name = "ReceivedDate";
            gridViewTextBoxColumn13.Width = 81;
            gridViewTextBoxColumn14.EnableExpressionEditor = false;
            gridViewTextBoxColumn14.FieldName = "LtrNo";
            gridViewTextBoxColumn14.HeaderText = "Letter No";
            gridViewTextBoxColumn14.Name = "LtrNo";
            gridViewTextBoxColumn14.Width = 92;
            gridViewTextBoxColumn15.EnableExpressionEditor = false;
            gridViewTextBoxColumn15.FieldName = "Date_FileNo";
            gridViewTextBoxColumn15.HeaderText = "Letter Name";
            gridViewTextBoxColumn15.Name = "Date_FileNo";
            gridViewTextBoxColumn15.Width = 99;
            gridViewTextBoxColumn16.EnableExpressionEditor = false;
            gridViewTextBoxColumn16.FieldName = "Subject";
            gridViewTextBoxColumn16.HeaderText = "Subject";
            gridViewTextBoxColumn16.Name = "Subject";
            gridViewTextBoxColumn16.Width = 100;
            gridViewTextBoxColumn17.EnableExpressionEditor = false;
            gridViewTextBoxColumn17.FieldName = "ToWhomFwd";
            gridViewTextBoxColumn17.HeaderText = "To Whom Fwd";
            gridViewTextBoxColumn17.Name = "ToWhomFwd";
            gridViewTextBoxColumn17.Width = 117;
            gridViewTextBoxColumn18.EnableExpressionEditor = false;
            gridViewTextBoxColumn18.FieldName = "ReceivedBy";
            gridViewTextBoxColumn18.HeaderText = "ReceivedBy";
            gridViewTextBoxColumn18.Name = "ReceivedBy";
            gridViewTextBoxColumn18.Width = 110;
            gridViewTextBoxColumn19.EnableExpressionEditor = false;
            gridViewTextBoxColumn19.FieldName = "Remarks";
            gridViewTextBoxColumn19.HeaderText = "Remarks";
            gridViewTextBoxColumn19.Name = "Remarks";
            gridViewTextBoxColumn19.Width = 111;
            gridViewTextBoxColumn20.EnableExpressionEditor = false;
            gridViewTextBoxColumn20.FieldName = "Status";
            gridViewTextBoxColumn20.HeaderText = "Status";
            gridViewTextBoxColumn20.Name = "Status";
            gridViewTextBoxColumn20.Width = 107;
            gridViewCommandColumn3.DefaultText = "Edit";
            gridViewCommandColumn3.EnableExpressionEditor = false;
            gridViewCommandColumn3.HeaderText = "Edit";
            gridViewCommandColumn3.Name = "btnEdit";
            gridViewCommandColumn3.UseDefaultText = true;
            gridViewCommandColumn3.Width = 133;
            gridViewCommandColumn4.DefaultText = "Docs";
            gridViewCommandColumn4.EnableExpressionEditor = false;
            gridViewCommandColumn4.FieldName = "Docs";
            gridViewCommandColumn4.HeaderText = "Docs";
            gridViewCommandColumn4.Name = "btnDoc";
            gridViewCommandColumn4.UseDefaultText = true;
            this.RGV_OutgoingMail.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16,
            gridViewTextBoxColumn17,
            gridViewTextBoxColumn18,
            gridViewTextBoxColumn19,
            gridViewTextBoxColumn20,
            gridViewCommandColumn3,
            gridViewCommandColumn4});
            this.RGV_OutgoingMail.MasterTemplate.EnableFiltering = true;
            this.RGV_OutgoingMail.MasterTemplate.ShowFilteringRow = false;
            this.RGV_OutgoingMail.MasterTemplate.ShowHeaderCellButtons = true;
            this.RGV_OutgoingMail.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.RGV_OutgoingMail.Name = "RGV_OutgoingMail";
            this.RGV_OutgoingMail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.RGV_OutgoingMail.ShowHeaderCellButtons = true;
            this.RGV_OutgoingMail.Size = new System.Drawing.Size(1125, 327);
            this.RGV_OutgoingMail.TabIndex = 0;
            this.RGV_OutgoingMail.Text = "radGridView1";
            this.RGV_OutgoingMail.ThemeName = "TelerikMetro";
            this.RGV_OutgoingMail.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.RGV_OutgoingMail_CellClick);
            // 
            // Outgoing_Mail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 395);
            this.Controls.Add(this.btnOutgoingMailNew);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "Outgoing_Mail";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Outgoing_Mail";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.Outgoing_Mail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnOutgoingMailNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RGV_OutgoingMail.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RGV_OutgoingMail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnOutgoingMailNew;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView RGV_OutgoingMail;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
    }
}
