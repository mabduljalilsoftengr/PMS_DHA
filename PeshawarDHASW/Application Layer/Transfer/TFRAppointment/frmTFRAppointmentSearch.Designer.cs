namespace PeshawarDHASW.Application_Layer.Transfer.TFRAppointment
{
    partial class frmTFRAppointmentSearch
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
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn2 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.TFRAppointmentSearch = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.txtPlotNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.btnSearchAppointment = new Telerik.WinControls.UI.RadButton();
            this.txtNDC = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtfileno = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.TFRAppointmentSearch)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TFRAppointmentSearch.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlotNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchAppointment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNDC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfileno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // TFRAppointmentSearch
            // 
            this.TFRAppointmentSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TFRAppointmentSearch.Location = new System.Drawing.Point(13, 131);
            // 
            // 
            // 
            this.TFRAppointmentSearch.MasterTemplate.AllowAddNewRow = false;
            this.TFRAppointmentSearch.MasterTemplate.AllowColumnReorder = false;
            this.TFRAppointmentSearch.MasterTemplate.AutoGenerateColumns = false;
            this.TFRAppointmentSearch.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "TFRAppoimtmentID";
            gridViewTextBoxColumn1.HeaderText = "TFRAppoimtmentID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "TFRAppoimtmentID";
            gridViewTextBoxColumn1.Width = 156;
            gridViewTextBoxColumn2.FieldName = "FileMapKey";
            gridViewTextBoxColumn2.HeaderText = "FileMapKey";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "FileMapKey";
            gridViewTextBoxColumn2.Width = 58;
            gridViewTextBoxColumn3.FieldName = "NDCNo";
            gridViewTextBoxColumn3.HeaderText = "NDCNo";
            gridViewTextBoxColumn3.Name = "NDCNo";
            gridViewTextBoxColumn3.Width = 61;
            gridViewTextBoxColumn4.FieldName = "FileNo";
            gridViewTextBoxColumn4.HeaderText = "FileNo";
            gridViewTextBoxColumn4.Name = "FileNo";
            gridViewTextBoxColumn4.Width = 212;
            gridViewDateTimeColumn1.FieldName = "IssueDate";
            gridViewDateTimeColumn1.HeaderText = "IssueDate";
            gridViewDateTimeColumn1.Name = "IssueDate";
            gridViewDateTimeColumn1.Width = 212;
            gridViewDateTimeColumn2.FieldName = "ExpireDate";
            gridViewDateTimeColumn2.HeaderText = "Date of Exprie";
            gridViewDateTimeColumn2.Name = "ExpireDate";
            gridViewDateTimeColumn2.Width = 212;
            gridViewTextBoxColumn5.FieldName = "Status";
            gridViewTextBoxColumn5.HeaderText = "Status";
            gridViewTextBoxColumn5.Name = "Status";
            gridViewTextBoxColumn5.Width = 67;
            this.TFRAppointmentSearch.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewDateTimeColumn1,
            gridViewDateTimeColumn2,
            gridViewTextBoxColumn5});
            this.TFRAppointmentSearch.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.TFRAppointmentSearch.Name = "TFRAppointmentSearch";
            this.TFRAppointmentSearch.ReadOnly = true;
            this.TFRAppointmentSearch.Size = new System.Drawing.Size(781, 397);
            this.TFRAppointmentSearch.TabIndex = 0;
            this.TFRAppointmentSearch.Text = "radGridView1";
            this.TFRAppointmentSearch.ThemeName = "TelerikMetro";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.txtPlotNo);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.btnSearchAppointment);
            this.radGroupBox1.Controls.Add(this.txtNDC);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.txtfileno);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.HeaderText = "Search Option`s";
            this.radGroupBox1.Location = new System.Drawing.Point(13, 13);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(781, 112);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "Search Option`s";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // txtPlotNo
            // 
            this.txtPlotNo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlotNo.Location = new System.Drawing.Point(445, 33);
            this.txtPlotNo.Name = "txtPlotNo";
            this.txtPlotNo.Size = new System.Drawing.Size(152, 27);
            this.txtPlotNo.TabIndex = 8;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(377, 33);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(63, 25);
            this.radLabel3.TabIndex = 6;
            this.radLabel3.Text = "Plot No";
            // 
            // btnSearchAppointment
            // 
            this.btnSearchAppointment.Location = new System.Drawing.Point(377, 70);
            this.btnSearchAppointment.Name = "btnSearchAppointment";
            this.btnSearchAppointment.Size = new System.Drawing.Size(220, 27);
            this.btnSearchAppointment.TabIndex = 11;
            this.btnSearchAppointment.Text = "Search Appointment";
            this.btnSearchAppointment.ThemeName = "TelerikMetro";
            this.btnSearchAppointment.Click += new System.EventHandler(this.btnSearchAppointment_Click);
            // 
            // txtNDC
            // 
            this.txtNDC.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNDC.Location = new System.Drawing.Point(132, 70);
            this.txtNDC.Name = "txtNDC";
            this.txtNDC.Size = new System.Drawing.Size(239, 27);
            this.txtNDC.TabIndex = 10;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(20, 70);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(106, 25);
            this.radLabel2.TabIndex = 9;
            this.radLabel2.Text = "NDC Number";
            // 
            // txtfileno
            // 
            this.txtfileno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtfileno.Location = new System.Drawing.Point(132, 33);
            this.txtfileno.Name = "txtfileno";
            this.txtfileno.Size = new System.Drawing.Size(239, 27);
            this.txtfileno.TabIndex = 7;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(20, 32);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(63, 25);
            this.radLabel1.TabIndex = 5;
            this.radLabel1.Text = "File No ";
            // 
            // frmTFRAppointmentSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 540);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.TFRAppointmentSearch);
            this.Name = "frmTFRAppointmentSearch";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "TFR Appointment Search";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmTFRAppointmentSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TFRAppointmentSearch.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TFRAppointmentSearch)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlotNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSearchAppointment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNDC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtfileno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGridView TFRAppointmentSearch;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadTextBox txtPlotNo;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadButton btnSearchAppointment;
        private Telerik.WinControls.UI.RadTextBox txtNDC;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtfileno;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
