namespace PeshawarDHASW.Report.Simple_Layer
{
    partial class frmSimpleReport
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
            this.crystalReportViewer1 = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.btnHintData = new Telerik.WinControls.UI.RadButton();
            this.btnuserinfo = new Telerik.WinControls.UI.RadButton();
            this.userInfo = new PeshawarDHASW.Report.Datasets.Sample.UserInfo();
            this.tblMemberImagesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnAccountStatment = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHintData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnuserinfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMemberImagesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccountStatment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // crystalReportViewer1
            // 
            this.crystalReportViewer1.ActiveViewIndex = -1;
            this.crystalReportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.crystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.crystalReportViewer1.Location = new System.Drawing.Point(0, 58);
            this.crystalReportViewer1.Name = "crystalReportViewer1";
            this.crystalReportViewer1.Size = new System.Drawing.Size(1120, 572);
            this.crystalReportViewer1.TabIndex = 0;
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(13, 13);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(136, 39);
            this.radButton1.TabIndex = 1;
            this.radButton1.Text = "radButton1";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // radButton2
            // 
            this.radButton2.Location = new System.Drawing.Point(155, 13);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(136, 39);
            this.radButton2.TabIndex = 2;
            this.radButton2.Text = "radButton2";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // btnHintData
            // 
            this.btnHintData.Location = new System.Drawing.Point(297, 12);
            this.btnHintData.Name = "btnHintData";
            this.btnHintData.Size = new System.Drawing.Size(136, 39);
            this.btnHintData.TabIndex = 3;
            this.btnHintData.Text = "Hint Data";
            this.btnHintData.Click += new System.EventHandler(this.btnHintData_Click);
            // 
            // btnuserinfo
            // 
            this.btnuserinfo.Location = new System.Drawing.Point(439, 13);
            this.btnuserinfo.Name = "btnuserinfo";
            this.btnuserinfo.Size = new System.Drawing.Size(136, 39);
            this.btnuserinfo.TabIndex = 4;
            this.btnuserinfo.Text = "UserInfo";
            this.btnuserinfo.Click += new System.EventHandler(this.btnuserinfo_Click);
            // 
            // userInfo
            // 
            this.userInfo.DataSetName = "UserInfo";
            this.userInfo.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tblMemberImagesBindingSource
            // 
            this.tblMemberImagesBindingSource.DataMember = "tbl_MemberImages";
            this.tblMemberImagesBindingSource.DataSource = this.userInfo;
            // 
            // btnAccountStatment
            // 
            this.btnAccountStatment.Location = new System.Drawing.Point(723, 12);
            this.btnAccountStatment.Name = "btnAccountStatment";
            this.btnAccountStatment.Size = new System.Drawing.Size(136, 39);
            this.btnAccountStatment.TabIndex = 6;
            this.btnAccountStatment.Text = "Account Statement";
            this.btnAccountStatment.Click += new System.EventHandler(this.btnAccountStatment_Click);
            // 
            // frmSimpleReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 630);
            this.Controls.Add(this.btnAccountStatment);
            this.Controls.Add(this.btnuserinfo);
            this.Controls.Add(this.btnHintData);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.crystalReportViewer1);
            this.Name = "frmSimpleReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmSimpleReport";
            this.Load += new System.EventHandler(this.frmSimpleReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnHintData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnuserinfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMemberImagesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnAccountStatment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer crystalReportViewer1;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadButton btnHintData;
        private Telerik.WinControls.UI.RadButton btnuserinfo;
        private System.Windows.Forms.BindingSource tblMemberImagesBindingSource;
        private Datasets.Sample.UserInfo userInfo;
        private Telerik.WinControls.UI.RadButton btnAccountStatment;
    }
}
