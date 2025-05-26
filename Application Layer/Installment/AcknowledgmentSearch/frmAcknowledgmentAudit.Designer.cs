namespace PeshawarDHASW.Application_Layer.Installment.AcknowledgmentSearch
{
    partial class frmAcknowledgmentAudit
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn2 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn3 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn4 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdQSR = new Telerik.WinControls.UI.RadGridView();
            this.grdAudit = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdQSR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQSR.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAudit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAudit.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.radGroupBox3);
            this.radGroupBox1.Controls.Add(this.radGroupBox2);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 2);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(968, 687);
            this.radGroupBox1.TabIndex = 0;
            // 
            // grdQSR
            // 
            this.grdQSR.Location = new System.Drawing.Point(9, 21);
            // 
            // 
            // 
            this.grdQSR.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.grdQSR.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdQSR.Name = "grdQSR";
            this.grdQSR.Size = new System.Drawing.Size(949, 342);
            this.grdQSR.TabIndex = 0;
            // 
            // grdAudit
            // 
            this.grdAudit.Location = new System.Drawing.Point(6, 16);
            // 
            // 
            // 
            this.grdAudit.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "AckaudtID";
            gridViewTextBoxColumn1.HeaderText = "AckaudtID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "AckaudtID";
            gridViewTextBoxColumn2.FieldName = "FinAckID";
            gridViewTextBoxColumn2.HeaderText = "Ack ID";
            gridViewTextBoxColumn2.IsVisible = false;
            gridViewTextBoxColumn2.Name = "FinAckID";
            gridViewTextBoxColumn2.Width = 231;
            gridViewTextBoxColumn3.FieldName = "SNo";
            gridViewTextBoxColumn3.HeaderText = "S. No";
            gridViewTextBoxColumn3.Name = "SNo";
            gridViewTextBoxColumn3.Width = 46;
            gridViewTextBoxColumn4.FieldName = "AuditDate";
            gridViewTextBoxColumn4.HeaderText = "Audit Date";
            gridViewTextBoxColumn4.Name = "AuditDate";
            gridViewTextBoxColumn4.Width = 293;
            gridViewTextBoxColumn5.FieldName = "Description";
            gridViewTextBoxColumn5.HeaderText = "Description";
            gridViewTextBoxColumn5.Name = "Description";
            gridViewTextBoxColumn5.Width = 293;
            gridViewTextBoxColumn6.FieldName = "Name";
            gridViewTextBoxColumn6.HeaderText = "Name";
            gridViewTextBoxColumn6.Name = "Name";
            gridViewTextBoxColumn6.Width = 293;
            this.grdAudit.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6});
            this.grdAudit.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdAudit.Name = "grdAudit";
            this.grdAudit.Size = new System.Drawing.Size(943, 277);
            this.grdAudit.TabIndex = 1;
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.grdQSR);
            this.radGroupBox2.HeaderText = "QSR";
            this.radGroupBox2.HeaderTextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.radGroupBox2.Location = new System.Drawing.Point(3, 314);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(961, 368);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "QSR";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.grdAudit);
            this.radGroupBox3.HeaderText = "Audit";
            this.radGroupBox3.HeaderTextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.radGroupBox3.Location = new System.Drawing.Point(9, 3);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(951, 298);
            this.radGroupBox3.TabIndex = 2;
            this.radGroupBox3.Text = "Audit";
            // 
            // frmAcknowledgmentAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 692);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmAcknowledgmentAudit";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmAckAudit";
            this.Load += new System.EventHandler(this.frmAcknowledgmentAudit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdQSR.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdQSR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAudit.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAudit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grdQSR;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadGridView grdAudit;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
    }
}
