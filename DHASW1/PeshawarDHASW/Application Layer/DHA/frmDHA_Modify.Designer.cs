namespace PeshawarDHASW.Application_Layer.DHA
{
    partial class frmDHA_Modify
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
            Telerik.WinControls.UI.GridViewDateTimeColumn gridViewDateTimeColumn1 = new Telerik.WinControls.UI.GridViewDateTimeColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFind = new Telerik.WinControls.UI.RadButton();
            this.txtGPSXY = new Telerik.WinControls.UI.RadTextBox();
            this.txtName = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grdDHADetail = new Telerik.WinControls.UI.RadGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGPSXY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdDHADetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDHADetail.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.txtGPSXY);
            this.groupBox1.Controls.Add(this.txtName);
            this.groupBox1.Controls.Add(this.radLabel2);
            this.groupBox1.Controls.Add(this.radLabel1);
            this.groupBox1.Location = new System.Drawing.Point(6, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(787, 100);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search";
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(661, 37);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(100, 31);
            this.btnFind.TabIndex = 4;
            this.btnFind.Text = "Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtGPSXY
            // 
            this.txtGPSXY.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtGPSXY.Location = new System.Drawing.Point(402, 37);
            this.txtGPSXY.Name = "txtGPSXY";
            this.txtGPSXY.Size = new System.Drawing.Size(216, 31);
            this.txtGPSXY.TabIndex = 3;
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(85, 37);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(205, 31);
            this.txtName.TabIndex = 2;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(316, 37);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(66, 30);
            this.radLabel2.TabIndex = 1;
            this.radLabel2.Text = "GPSXY";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(6, 38);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(61, 30);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.grdDHADetail);
            this.groupBox2.Location = new System.Drawing.Point(6, 114);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(787, 365);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detail";
            // 
            // grdDHADetail
            // 
            this.grdDHADetail.Location = new System.Drawing.Point(6, 17);
            // 
            // 
            // 
            this.grdDHADetail.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "DHA_ID";
            gridViewTextBoxColumn1.HeaderText = "DHA ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "DHA_ID";
            gridViewTextBoxColumn2.FieldName = "Name";
            gridViewTextBoxColumn2.HeaderText = "Name";
            gridViewTextBoxColumn2.Name = "Name";
            gridViewTextBoxColumn2.Width = 235;
            gridViewDateTimeColumn1.FieldName = "StartingDate";
            gridViewDateTimeColumn1.HeaderText = "Starting Date";
            gridViewDateTimeColumn1.Name = "Starting Date";
            gridViewDateTimeColumn1.Width = 235;
            gridViewTextBoxColumn3.FieldName = "GPSXY";
            gridViewTextBoxColumn3.HeaderText = "GPSXY";
            gridViewTextBoxColumn3.Name = "GPSXY";
            gridViewTextBoxColumn3.Width = 210;
            gridViewCommandColumn1.DefaultText = "Modify";
            gridViewCommandColumn1.FieldName = "btn_Modify";
            gridViewCommandColumn1.HeaderText = "Modify";
            gridViewCommandColumn1.Name = "btn_Modify";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 72;
            this.grdDHADetail.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewDateTimeColumn1,
            gridViewTextBoxColumn3,
            gridViewCommandColumn1});
            this.grdDHADetail.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdDHADetail.Name = "grdDHADetail";
            this.grdDHADetail.Size = new System.Drawing.Size(770, 342);
            this.grdDHADetail.TabIndex = 0;
            this.grdDHADetail.Text = "radGridView1";
            this.grdDHADetail.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdDHADetail_CellClick);
            // 
            // frmDHA_Modify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 489);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmDHA_Modify";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "DHA_Modify";
            this.Load += new System.EventHandler(this.frmDHA_Modify_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGPSXY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdDHADetail.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDHADetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadButton btnFind;
        private Telerik.WinControls.UI.RadTextBox txtGPSXY;
        private Telerik.WinControls.UI.RadTextBox txtName;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private System.Windows.Forms.GroupBox groupBox2;
        private Telerik.WinControls.UI.RadGridView grdDHADetail;
    }
}
