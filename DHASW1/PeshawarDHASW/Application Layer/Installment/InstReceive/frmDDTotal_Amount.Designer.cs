namespace PeshawarDHASW.Application_Layer.Installment.InstReceive
{
    partial class frmDDTotal_Amount
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.grd_TotalAmount = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grd_TotalAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_TotalAmount.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grd_TotalAmount
            // 
            this.grd_TotalAmount.Location = new System.Drawing.Point(1, 2);
            // 
            // 
            // 
            this.grd_TotalAmount.MasterTemplate.AllowAddNewRow = false;
            this.grd_TotalAmount.MasterTemplate.AllowColumnReorder = false;
            this.grd_TotalAmount.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "Amount";
            gridViewTextBoxColumn1.HeaderText = "DD Total Amount";
            gridViewTextBoxColumn1.Name = "Amount";
            gridViewTextBoxColumn1.Width = 209;
            this.grd_TotalAmount.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
            this.grd_TotalAmount.MasterTemplate.EnableGrouping = false;
            this.grd_TotalAmount.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grd_TotalAmount.Name = "grd_TotalAmount";
            this.grd_TotalAmount.ReadOnly = true;
            this.grd_TotalAmount.Size = new System.Drawing.Size(230, 108);
            this.grd_TotalAmount.TabIndex = 0;
            this.grd_TotalAmount.Text = "radGridView1";
            // 
            // frmDDTotal_Amount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 111);
            this.Controls.Add(this.grd_TotalAmount);
            this.Name = "frmDDTotal_Amount";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "DD Total Amount";
            ((System.ComponentModel.ISupportInitialize)(this.grd_TotalAmount.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_TotalAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grd_TotalAmount;
    }
}
