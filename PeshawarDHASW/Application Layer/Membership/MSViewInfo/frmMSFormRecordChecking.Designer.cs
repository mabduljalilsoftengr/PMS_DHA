namespace PeshawarDHASW.Application_Layer.Membership.MSViewInfo
{
    partial class frmMSFormRecordChecking
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn9 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn10 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn11 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn12 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn13 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn14 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn15 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn16 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtchallanno = new Telerik.WinControls.UI.RadTextBox();
            this.btncheck = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.lblmessage = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdmsrecord = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtchallanno)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btncheck)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblmessage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdmsrecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdmsrecord.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(18, 18);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(134, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Enter Challan No.";
            // 
            // txtchallanno
            // 
            this.txtchallanno.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtchallanno.Location = new System.Drawing.Point(158, 17);
            this.txtchallanno.Name = "txtchallanno";
            this.txtchallanno.Size = new System.Drawing.Size(202, 27);
            this.txtchallanno.TabIndex = 1;
            // 
            // btncheck
            // 
            this.btncheck.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncheck.Location = new System.Drawing.Point(366, 17);
            this.btncheck.Name = "btncheck";
            this.btncheck.Size = new System.Drawing.Size(110, 27);
            this.btncheck.TabIndex = 2;
            this.btncheck.Text = "Check";
            this.btncheck.Click += new System.EventHandler(this.btncheck_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.lblmessage);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.btncheck);
            this.radGroupBox1.Controls.Add(this.txtchallanno);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(2, 4);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(713, 97);
            this.radGroupBox1.TabIndex = 3;
            // 
            // lblmessage
            // 
            this.lblmessage.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmessage.Location = new System.Drawing.Point(42, 58);
            this.lblmessage.Name = "lblmessage";
            this.lblmessage.Size = new System.Drawing.Size(431, 33);
            this.lblmessage.TabIndex = 3;
            this.lblmessage.Text = "#################################";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.grdmsrecord);
            this.radGroupBox2.HeaderText = "Total Record";
            this.radGroupBox2.Location = new System.Drawing.Point(2, 104);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(713, 585);
            this.radGroupBox2.TabIndex = 4;
            this.radGroupBox2.Text = "Total Record";
            // 
            // grdmsrecord
            // 
            this.grdmsrecord.Location = new System.Drawing.Point(7, 21);
            // 
            // 
            // 
            this.grdmsrecord.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn9.FieldName = "ID";
            gridViewTextBoxColumn9.HeaderText = "ID";
            gridViewTextBoxColumn9.IsVisible = false;
            gridViewTextBoxColumn9.Name = "ID";
            gridViewTextBoxColumn9.Width = 85;
            gridViewTextBoxColumn10.FieldName = "ChallanNo";
            gridViewTextBoxColumn10.HeaderText = "Challan No";
            gridViewTextBoxColumn10.Name = "ChallanNo";
            gridViewTextBoxColumn10.Width = 97;
            gridViewTextBoxColumn11.FieldName = "Amount";
            gridViewTextBoxColumn11.HeaderText = "Amount";
            gridViewTextBoxColumn11.Name = "Amount";
            gridViewTextBoxColumn11.Width = 97;
            gridViewTextBoxColumn12.FieldName = "Name";
            gridViewTextBoxColumn12.HeaderText = "Name";
            gridViewTextBoxColumn12.Name = "Name";
            gridViewTextBoxColumn12.Width = 97;
            gridViewTextBoxColumn13.FieldName = "FileNo";
            gridViewTextBoxColumn13.HeaderText = "File No.";
            gridViewTextBoxColumn13.Name = "FileNo";
            gridViewTextBoxColumn13.Width = 97;
            gridViewTextBoxColumn14.FieldName = "MembershipNo";
            gridViewTextBoxColumn14.HeaderText = "MS No.";
            gridViewTextBoxColumn14.Name = "MembershipNo";
            gridViewTextBoxColumn14.Width = 97;
            gridViewTextBoxColumn15.FieldName = "DeliverDate";
            gridViewTextBoxColumn15.HeaderText = "Deliver Date";
            gridViewTextBoxColumn15.Name = "DeliverDate";
            gridViewTextBoxColumn15.Width = 97;
            gridViewTextBoxColumn16.FieldName = "UserName";
            gridViewTextBoxColumn16.HeaderText = "User Name";
            gridViewTextBoxColumn16.Name = "UserName";
            gridViewTextBoxColumn16.Width = 99;
            this.grdmsrecord.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn9,
            gridViewTextBoxColumn10,
            gridViewTextBoxColumn11,
            gridViewTextBoxColumn12,
            gridViewTextBoxColumn13,
            gridViewTextBoxColumn14,
            gridViewTextBoxColumn15,
            gridViewTextBoxColumn16});
            this.grdmsrecord.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdmsrecord.Name = "grdmsrecord";
            this.grdmsrecord.Size = new System.Drawing.Size(696, 559);
            this.grdmsrecord.TabIndex = 0;
            this.grdmsrecord.Text = "radGridView1";
            // 
            // frmMSFormRecordChecking
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 688);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmMSFormRecordChecking";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmMSFormRecordChecking";
            this.Load += new System.EventHandler(this.frmMSFormRecordChecking_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtchallanno)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btncheck)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblmessage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdmsrecord.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdmsrecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtchallanno;
        private Telerik.WinControls.UI.RadButton btncheck;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel lblmessage;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGridView grdmsrecord;
    }
}
