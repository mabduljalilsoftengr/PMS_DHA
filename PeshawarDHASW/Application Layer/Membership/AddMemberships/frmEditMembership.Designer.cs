namespace PeshawarDHASW.Application_Layer.Membership.AddMemberships
{
    partial class frmEditMembership
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.MSDataView = new Telerik.WinControls.UI.RadGridView();
            this.btnRefresh = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MSDataView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MSDataView.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox1.Controls.Add(this.MSDataView);
            this.radGroupBox1.HeaderText = "Membership";
            this.radGroupBox1.Location = new System.Drawing.Point(13, 43);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(648, 421);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Membership";
            // 
            // MSDataView
            // 
            this.MSDataView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MSDataView.Location = new System.Drawing.Point(6, 22);
            // 
            // 
            // 
            this.MSDataView.MasterTemplate.AllowAddNewRow = false;
            this.MSDataView.MasterTemplate.AllowColumnReorder = false;
            this.MSDataView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "ID";
            gridViewTextBoxColumn1.HeaderText = "ID";
            gridViewTextBoxColumn1.IsVisible = false;
            gridViewTextBoxColumn1.Name = "ID";
            gridViewTextBoxColumn1.Width = 308;
            gridViewTextBoxColumn2.FieldName = "MSNO";
            gridViewTextBoxColumn2.HeaderText = "MSNO";
            gridViewTextBoxColumn2.Name = "MSNO";
            gridViewTextBoxColumn2.Width = 456;
            gridViewCommandColumn1.DefaultText = "Edit";
            gridViewCommandColumn1.FieldName = "Edit";
            gridViewCommandColumn1.HeaderText = "Edit";
            gridViewCommandColumn1.Name = "Edit";
            gridViewCommandColumn1.UseDefaultText = true;
            gridViewCommandColumn1.Width = 161;
            this.MSDataView.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1,
            gridViewTextBoxColumn2,
            gridViewCommandColumn1});
            this.MSDataView.MasterTemplate.EnableFiltering = true;
            this.MSDataView.MasterTemplate.EnableGrouping = false;
            this.MSDataView.MasterTemplate.EnablePaging = true;
            this.MSDataView.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.MSDataView.Name = "MSDataView";
            this.MSDataView.Size = new System.Drawing.Size(637, 394);
            this.MSDataView.TabIndex = 0;
            this.MSDataView.Text = "radGridView1";
            this.MSDataView.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.MSDataView_CellClick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(13, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(648, 33);
            this.btnRefresh.TabIndex = 1;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmEditMembership
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 476);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmEditMembership";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Edit Membership";
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MSDataView.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MSDataView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnRefresh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView MSDataView;
        private Telerik.WinControls.UI.RadButton btnRefresh;
    }
}
