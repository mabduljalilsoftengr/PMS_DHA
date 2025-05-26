namespace PeshawarDHASW.Application_Layer.FileMap.Add_File_In_AllFile_Table
{
    partial class frmModifyFile
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
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radgrdAllFileNo = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.radgrdAllFileNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgrdAllFileNo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radgrdAllFileNo
            // 
            this.radgrdAllFileNo.Location = new System.Drawing.Point(5, 16);
            // 
            // 
            // 
            gridViewTextBoxColumn1.FieldName = "ID";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn1.Width = 100;
            gridViewTextBoxColumn2.FieldName = "FileNo";
            gridViewTextBoxColumn2.HeaderText = "FileNo";
            gridViewTextBoxColumn2.Name = "FileNo";
            gridViewTextBoxColumn2.Width = 140;
            gridViewCommandColumn1.DefaultText = "Modify File";
            gridViewCommandColumn1.FieldName = "modify_file";
            gridViewCommandColumn1.HeaderText = "Modify";
            gridViewCommandColumn1.Name = "modify_file";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 100;
            this.radgrdAllFileNo.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1});
            this.radgrdAllFileNo.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radgrdAllFileNo.Name = "radgrdAllFileNo";
            this.radgrdAllFileNo.Size = new System.Drawing.Size(884, 378);
            this.radgrdAllFileNo.TabIndex = 0;
            this.radgrdAllFileNo.Text = "radGridView1";
            this.radgrdAllFileNo.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radgrdAllFileNo_CellClick);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radgrdAllFileNo);
            this.radGroupBox1.HeaderText = "File Modification";
            this.radGroupBox1.Location = new System.Drawing.Point(2, -2);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(894, 398);
            this.radGroupBox1.TabIndex = 1;
            this.radGroupBox1.Text = "File Modification";
            // 
            // frmModifyFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 402);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmModifyFile";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmModifyFile";
            this.Load += new System.EventHandler(this.frmModifyFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radgrdAllFileNo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radgrdAllFileNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView radgrdAllFileNo;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    }
}
