namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    partial class frmPrintedNotSigned
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
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdPrinted_NotSigned = new Telerik.WinControls.UI.RadGridView();
            this.btn_Refresh = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrinted_NotSigned)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrinted_NotSigned.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Refresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.btn_Refresh);
            this.radGroupBox3.Controls.Add(this.grdPrinted_NotSigned);
            this.radGroupBox3.HeaderText = "Printed And Not-Signed";
            this.radGroupBox3.Location = new System.Drawing.Point(12, 12);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(517, 690);
            this.radGroupBox3.TabIndex = 3;
            this.radGroupBox3.Text = "Printed And Not-Signed";
            // 
            // grdPrinted_NotSigned
            // 
            this.grdPrinted_NotSigned.Location = new System.Drawing.Point(5, 68);
            // 
            // 
            // 
            this.grdPrinted_NotSigned.MasterTemplate.AllowAddNewRow = false;
            this.grdPrinted_NotSigned.MasterTemplate.AllowColumnReorder = false;
            this.grdPrinted_NotSigned.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "NDCNo";
            gridViewTextBoxColumn1.HeaderText = "NDCNo";
            gridViewTextBoxColumn1.Name = "NDCNo";
            gridViewTextBoxColumn1.Width = 193;
            gridViewTextBoxColumn2.FieldName = "FilePlotNo";
            gridViewTextBoxColumn2.HeaderText = "FileNo";
            gridViewTextBoxColumn2.Name = "FilePlotNo";
            gridViewTextBoxColumn2.Width = 193;
            gridViewCommandColumn1.DefaultText = "View";
            gridViewCommandColumn1.FieldName = "Prnt_NotSnd";
            gridViewCommandColumn1.HeaderText = "View";
            gridViewCommandColumn1.Name = "Prnt_NotSnd";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 102;
            this.grdPrinted_NotSigned.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1});
            this.grdPrinted_NotSigned.MasterTemplate.EnableGrouping = false;
            this.grdPrinted_NotSigned.MasterTemplate.EnableSorting = false;
            this.grdPrinted_NotSigned.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdPrinted_NotSigned.Name = "grdPrinted_NotSigned";
            this.grdPrinted_NotSigned.Size = new System.Drawing.Size(507, 617);
            this.grdPrinted_NotSigned.TabIndex = 1;
            this.grdPrinted_NotSigned.Text = "radGridView2";
            this.grdPrinted_NotSigned.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdPrinted_NotSigned_CellClick);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Refresh.Location = new System.Drawing.Point(16, 21);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(144, 41);
            this.btn_Refresh.TabIndex = 2;
            this.btn_Refresh.Text = "Refresh";
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // frmPrintedNotSigned
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 704);
            this.Controls.Add(this.radGroupBox3);
            this.Name = "frmPrintedNotSigned";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmPrintedNotSigned";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmPrintedNotSigned_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPrinted_NotSigned.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdPrinted_NotSigned)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Refresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadGridView grdPrinted_NotSigned;
        private Telerik.WinControls.UI.RadButton btn_Refresh;
    }
}
