namespace PeshawarDHASW.Application_Layer.FileMap.SvcBenefitFiles
{
    partial class frmfileplotallotment
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
            this.components = new System.ComponentModel.Container();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dt_allotmentdate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.save = new System.Windows.Forms.Button();
            this.txt_fileno = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_plotno = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.errorallotment = new System.Windows.Forms.ErrorProvider(this.components);
            this.rad_allotmentgrdview = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_allotmentdate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorallotment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rad_allotmentgrdview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rad_allotmentgrdview.MasterTemplate)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.HeaderText = "Allotment Details";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 3);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(661, 185);
            this.radGroupBox1.TabIndex = 3;
            this.radGroupBox1.Text = "Allotment Details";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.label5);
            this.radGroupBox2.Controls.Add(this.dt_allotmentdate);
            this.radGroupBox2.Controls.Add(this.save);
            this.radGroupBox2.Controls.Add(this.txt_fileno);
            this.radGroupBox2.Controls.Add(this.label6);
            this.radGroupBox2.Controls.Add(this.txt_plotno);
            this.radGroupBox2.Controls.Add(this.label7);
            this.radGroupBox2.HeaderText = "New Allotment Detail";
            this.radGroupBox2.Location = new System.Drawing.Point(12, 207);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(353, 137);
            this.radGroupBox2.TabIndex = 4;
            this.radGroupBox2.Text = "New Allotment Detail";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Allotment Date";
            // 
            // dt_allotmentdate
            // 
            this.dt_allotmentdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dt_allotmentdate.CustomFormat = "yyyy-MM-dd";
            this.dt_allotmentdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dt_allotmentdate.Location = new System.Drawing.Point(111, 79);
            this.dt_allotmentdate.Name = "dt_allotmentdate";
            this.dt_allotmentdate.Size = new System.Drawing.Size(145, 20);
            this.dt_allotmentdate.TabIndex = 2;
            this.dt_allotmentdate.TabStop = false;
            this.dt_allotmentdate.Value = new System.DateTime(((long)(0)));
            // 
            // save
            // 
            this.save.Location = new System.Drawing.Point(110, 109);
            this.save.Name = "save";
            this.save.Size = new System.Drawing.Size(75, 23);
            this.save.TabIndex = 3;
            this.save.Text = "Save";
            this.save.UseVisualStyleBackColor = true;
            this.save.Click += new System.EventHandler(this.save_Click);
            // 
            // txt_fileno
            // 
            this.txt_fileno.Location = new System.Drawing.Point(112, 23);
            this.txt_fileno.Name = "txt_fileno";
            this.txt_fileno.Size = new System.Drawing.Size(145, 20);
            this.txt_fileno.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "File No";
            // 
            // txt_plotno
            // 
            this.txt_plotno.Location = new System.Drawing.Point(111, 50);
            this.txt_plotno.Name = "txt_plotno";
            this.txt_plotno.Size = new System.Drawing.Size(145, 20);
            this.txt_plotno.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Plot No";
            // 
            // errorallotment
            // 
            this.errorallotment.ContainerControl = this;
            // 
            // rad_allotmentgrdview
            // 
            this.rad_allotmentgrdview.Location = new System.Drawing.Point(12, 24);
            // 
            // 
            // 
            this.rad_allotmentgrdview.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "AllotmentID";
            gridViewTextBoxColumn1.HeaderText = "AllotmentID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "AllotmentID";
            gridViewTextBoxColumn2.FieldName = "FileNo";
            gridViewTextBoxColumn2.HeaderText = "FileNo";
            gridViewTextBoxColumn2.Name = "FileNo";
            gridViewTextBoxColumn2.Width = 85;
            gridViewTextBoxColumn3.FieldName = "AllotmentDate";
            gridViewTextBoxColumn3.HeaderText = "AllotmentDate";
            gridViewTextBoxColumn3.Name = "AllotmentDate";
            gridViewTextBoxColumn3.Width = 119;
            gridViewTextBoxColumn4.FieldName = "PlotNo";
            gridViewTextBoxColumn4.HeaderText = "PlotNo";
            gridViewTextBoxColumn4.Name = "PlotNo";
            gridViewTextBoxColumn4.Width = 119;
            gridViewTextBoxColumn5.FieldName = "Status";
            gridViewTextBoxColumn5.HeaderText = "Status";
            gridViewTextBoxColumn5.Name = "Status";
            gridViewTextBoxColumn5.Width = 119;
            gridViewTextBoxColumn6.FieldName = "Remarks";
            gridViewTextBoxColumn6.HeaderText = "Remarks";
            gridViewTextBoxColumn6.IsVisible = false;
            gridViewTextBoxColumn6.Name = "Remarks";
            gridViewTextBoxColumn7.HeaderText = "Message";
            gridViewTextBoxColumn7.Name = "Message";
            gridViewTextBoxColumn7.Width = 128;
            gridViewTextBoxColumn7.WrapText = true;
            gridViewCommandColumn1.DefaultText = "Delete";
            gridViewCommandColumn1.FieldName = "btndelete";
            gridViewCommandColumn1.HeaderText = "Delete";
            gridViewCommandColumn1.Name = "btndelete";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 67;
            this.rad_allotmentgrdview.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewCommandColumn1});
            this.rad_allotmentgrdview.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.rad_allotmentgrdview.Name = "rad_allotmentgrdview";
            this.rad_allotmentgrdview.Size = new System.Drawing.Size(653, 150);
            this.rad_allotmentgrdview.TabIndex = 5;
            this.rad_allotmentgrdview.Text = "rad_allotmentgrdview";
            this.rad_allotmentgrdview.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.rad_allotmentgrdview_CellClick);
            // 
            // frmfileplotallotment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 396);
            this.Controls.Add(this.rad_allotmentgrdview);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmfileplotallotment";
            this.Text = "frmfileplotallotment";
            this.Load += new System.EventHandler(this.frmfileplotallotment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dt_allotmentdate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorallotment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rad_allotmentgrdview.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rad_allotmentgrdview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private System.Windows.Forms.Button save;
        private System.Windows.Forms.TextBox txt_fileno;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_plotno;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ErrorProvider errorallotment;
        private Telerik.WinControls.UI.RadDateTimePicker dt_allotmentdate;
        private System.Windows.Forms.Label label5;
        private Telerik.WinControls.UI.RadGridView rad_allotmentgrdview;
    }
}