namespace PeshawarDHASW.Application_Layer.Acknowledgement
{
    partial class frmAcknowledgement_UserBase
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.AckGDV = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.AckGDV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AckGDV.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // AckGDV
            // 
            this.AckGDV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AckGDV.Location = new System.Drawing.Point(5, 21);
            // 
            // 
            // 
            this.AckGDV.MasterTemplate.AllowAddNewRow = false;
            this.AckGDV.MasterTemplate.AllowColumnReorder = false;
            this.AckGDV.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "Rece_ID";
            gridViewTextBoxColumn1.HeaderText = "Rece_ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "Rece_ID";
            gridViewTextBoxColumn1.VisibleInColumnChooser = false;
            gridViewTextBoxColumn1.Width = 29;
            gridViewTextBoxColumn2.FieldName = "FileNo";
            gridViewTextBoxColumn2.HeaderText = "FileNo";
            gridViewTextBoxColumn2.Name = "FileNo";
            gridViewTextBoxColumn2.Width = 107;
            gridViewTextBoxColumn3.FieldName = "DDNo";
            gridViewTextBoxColumn3.HeaderText = "DDNo";
            gridViewTextBoxColumn3.Name = "DDNo";
            gridViewTextBoxColumn3.Width = 107;
            gridViewTextBoxColumn4.FieldName = "Amount";
            gridViewTextBoxColumn4.HeaderText = "Amount";
            gridViewTextBoxColumn4.Name = "Amount";
            gridViewTextBoxColumn4.Width = 118;
            gridViewTextBoxColumn5.FieldName = "Date";
            gridViewTextBoxColumn5.HeaderText = "Date";
            gridViewTextBoxColumn5.Name = "Date";
            gridViewTextBoxColumn5.Width = 119;
            gridViewCommandColumn1.DefaultText = "Create";
            gridViewCommandColumn1.FieldName = "Create";
            gridViewCommandColumn1.HeaderText = "Acknowledgement";
            gridViewCommandColumn1.Name = "btnCreate";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 248;
            this.AckGDV.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4,
            gridViewTextBoxColumn5,
            gridViewCommandColumn1});
            this.AckGDV.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.AckGDV.Name = "AckGDV";
            this.AckGDV.ReadOnly = true;
            this.AckGDV.Size = new System.Drawing.Size(716, 491);
            this.AckGDV.TabIndex = 0;
            this.AckGDV.Text = "radGridView1";
            this.AckGDV.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.AckGDV_CellClick);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.AckGDV);
            this.radGroupBox1.HeaderText = "Demand Draft Information";
            this.radGroupBox1.Location = new System.Drawing.Point(13, 13);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(726, 517);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "Demand Draft Information";
            // 
            // frmAcknowledgement_UserBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 542);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmAcknowledgement_UserBase";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmAcknowledgement_UserBase";
            this.Load += new System.EventHandler(this.frmAcknowledgement_UserBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AckGDV.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AckGDV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView AckGDV;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    }
}
