namespace PeshawarDHASW.Application_Layer.NDC
{
    partial class Caution_Info_Prompt
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
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn5 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn6 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn7 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn8 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.btnOK = new Telerik.WinControls.UI.RadButton();
            this.grdMessageBox = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessageBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessageBox.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.btnOK);
            this.radGroupBox1.Controls.Add(this.grdMessageBox);
            this.radGroupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radGroupBox1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox1.HeaderText = "Caution Information";
            this.radGroupBox1.HeaderTextAlignment = System.Drawing.ContentAlignment.TopCenter;
            this.radGroupBox1.Location = new System.Drawing.Point(5, 12);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(647, 360);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Caution Information";
            // 
            // radLabel1
            // 
            this.radLabel1.BackColor = System.Drawing.Color.Pink;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(5, 36);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(638, 30);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "There is Cautions on this FileNo , Please Read  the Following Information.";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(530, 320);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 31);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // grdMessageBox
            // 
            this.grdMessageBox.Location = new System.Drawing.Point(5, 67);
            // 
            // 
            // 
            this.grdMessageBox.MasterTemplate.AllowAddNewRow = false;
            this.grdMessageBox.MasterTemplate.AllowColumnReorder = false;
            this.grdMessageBox.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn5.FieldName = "Name";
            gridViewTextBoxColumn5.HeaderText = "Name";
            gridViewTextBoxColumn5.Name = "Name";
            gridViewTextBoxColumn5.Width = 155;
            gridViewTextBoxColumn6.FieldName = "MembershipNo";
            gridViewTextBoxColumn6.HeaderText = "Membership No";
            gridViewTextBoxColumn6.Name = "MembershipNo";
            gridViewTextBoxColumn6.Width = 155;
            gridViewTextBoxColumn7.FieldName = "Cauction";
            gridViewTextBoxColumn7.HeaderText = "Cauction";
            gridViewTextBoxColumn7.Name = "Cauction";
            gridViewTextBoxColumn7.Width = 155;
            gridViewTextBoxColumn8.FieldName = "Caution_Level";
            gridViewTextBoxColumn8.HeaderText = "Caution Level";
            gridViewTextBoxColumn8.Name = "Caution_Level";
            gridViewTextBoxColumn8.Width = 155;
            this.grdMessageBox.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn5,
            gridViewTextBoxColumn6,
            gridViewTextBoxColumn7,
            gridViewTextBoxColumn8});
            this.grdMessageBox.MasterTemplate.EnableGrouping = false;
            this.grdMessageBox.MasterTemplate.EnableSorting = false;
            this.grdMessageBox.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdMessageBox.Name = "grdMessageBox";
            this.grdMessageBox.ReadOnly = true;
            this.grdMessageBox.Size = new System.Drawing.Size(638, 247);
            this.grdMessageBox.TabIndex = 0;
            this.grdMessageBox.Text = "radGridView1";
            // 
            // Caution_Info_Prompt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 373);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "Caution_Info_Prompt";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Caution_Info_Prompt";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.Caution_Info_Prompt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessageBox.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdMessageBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grdMessageBox;
        private Telerik.WinControls.UI.RadButton btnOK;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
