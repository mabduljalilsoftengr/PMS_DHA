namespace PeshawarDHASW.Application_Layer.Installment.InstPlan
{
    partial class frmInstalPlanEdit
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.planEditGridView = new Telerik.WinControls.UI.RadGridView();
            this.btn_viewPlan = new System.Windows.Forms.Button();
            this.dS_planEdit1 = new PeshawarDHASW.Application_Layer.Installment.InstPlan.DS_planEdit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planEditGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planEditGridView.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dS_planEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.planEditGridView);
            this.radGroupBox1.HeaderText = "File Installment Plan";
            this.radGroupBox1.Location = new System.Drawing.Point(-1, 287);
            this.radGroupBox1.Name = "radGroupBox1";
            // 
            // 
            // 
            this.radGroupBox1.RootElement.AutoSizeMode = Telerik.WinControls.RadAutoSizeMode.Auto;
            this.radGroupBox1.Size = new System.Drawing.Size(1131, 569);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "File Installment Plan";
            // 
            // planEditGridView
            // 
            this.planEditGridView.Location = new System.Drawing.Point(2, 18);
            // 
            // 
            // 
            this.planEditGridView.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            gridViewTextBoxColumn1.FieldName = "Edit";
            gridViewTextBoxColumn1.HeaderText = "Edit";
            gridViewTextBoxColumn1.Name = "Edit";
            gridViewTextBoxColumn1.Width = 1106;
            this.planEditGridView.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewTextBoxColumn1});
            this.planEditGridView.MasterTemplate.DataSource = this.dS_planEdit1;
            this.planEditGridView.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.planEditGridView.Name = "planEditGridView";
            this.planEditGridView.Size = new System.Drawing.Size(1127, 549);
            this.planEditGridView.TabIndex = 0;
            this.planEditGridView.Text = "radGridView1";
            // 
            // btn_viewPlan
            // 
            this.btn_viewPlan.Location = new System.Drawing.Point(503, 110);
            this.btn_viewPlan.Name = "btn_viewPlan";
            this.btn_viewPlan.Size = new System.Drawing.Size(145, 55);
            this.btn_viewPlan.TabIndex = 1;
            this.btn_viewPlan.Text = "View Plan";
            this.btn_viewPlan.UseVisualStyleBackColor = true;
            this.btn_viewPlan.Click += new System.EventHandler(this.btn_viewPlan_Click);
            // 
            // dS_planEdit1
            // 
            this.dS_planEdit1.DataSetName = "DS_planEdit";
            this.dS_planEdit1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // frmInstalPlanEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 855);
            this.Controls.Add(this.btn_viewPlan);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmInstalPlanEdit";
            // 
            // 
            // 
            //this.RootElement.ApplyShapeToControl = true;
            //this.Text = "frmInstalPlanEdit";
            //this.Load += new System.EventHandler(this.frmInstalPlanEdit_Load);
            //((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            //this.radGroupBox1.ResumeLayout(false);
            //((System.ComponentModel.ISupportInitialize)(this.planEditGridView.MasterTemplate)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.planEditGridView)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this.dS_planEdit1)).EndInit();
            //((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            //this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView planEditGridView;
        private System.Windows.Forms.Button btn_viewPlan;
        private DS_planEdit dS_planEdit1;
    }
}
