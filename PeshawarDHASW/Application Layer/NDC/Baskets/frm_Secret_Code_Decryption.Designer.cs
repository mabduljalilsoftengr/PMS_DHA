namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frm_Secret_Code_Decryption
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.grd_SecretCode = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grd_SecretCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_SecretCode.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.grd_SecretCode);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(754, 514);
            this.radGroupBox1.TabIndex = 0;
            // 
            // grd_SecretCode
            // 
            this.grd_SecretCode.Location = new System.Drawing.Point(5, 9);
            // 
            // 
            // 
            this.grd_SecretCode.MasterTemplate.AllowAddNewRow = false;
            this.grd_SecretCode.MasterTemplate.AllowColumnReorder = false;
            this.grd_SecretCode.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "ID";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn2.FieldName = "username";
            gridViewTextBoxColumn2.HeaderText = "UserName";
            gridViewTextBoxColumn2.Name = "username";
            gridViewTextBoxColumn2.Width = 241;
            gridViewTextBoxColumn3.FieldName = "Name";
            gridViewTextBoxColumn3.HeaderText = "Name";
            gridViewTextBoxColumn3.Name = "Name";
            gridViewTextBoxColumn3.Width = 241;
            gridViewTextBoxColumn4.FieldName = "Secret_Code";
            gridViewTextBoxColumn4.HeaderText = "Secret_Code";
            gridViewTextBoxColumn4.Name = "Secret_Code";
            gridViewTextBoxColumn4.Width = 242;
            this.grd_SecretCode.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewTextBoxColumn3,
            gridViewTextBoxColumn4});
            this.grd_SecretCode.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grd_SecretCode.Name = "grd_SecretCode";
            this.grd_SecretCode.ReadOnly = true;
            this.grd_SecretCode.Size = new System.Drawing.Size(743, 500);
            this.grd_SecretCode.TabIndex = 0;
            this.grd_SecretCode.Text = "radGridView1";
            // 
            // frm_Secret_Code_Decryption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 538);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frm_Secret_Code_Decryption";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frm_Secret_Code_Decrytion";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frm_Secret_Code_Decryption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grd_SecretCode.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_SecretCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grd_SecretCode;
    }
}
