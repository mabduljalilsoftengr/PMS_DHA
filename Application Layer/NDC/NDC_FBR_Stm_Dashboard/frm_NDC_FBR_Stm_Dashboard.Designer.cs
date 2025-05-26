namespace PeshawarDHASW.Application_Layer.NDC.NDC_FBR_Stm_Dashboard
{
    partial class frm_NDC_FBR_Stm_Dashboard
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
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition2 = new Telerik.WinControls.UI.TableViewDefinition();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition3 = new Telerik.WinControls.UI.TableViewDefinition();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdNDC = new Telerik.WinControls.UI.RadGridView();
            this.grdFBR = new Telerik.WinControls.UI.RadGridView();
            this.grdStampDuty = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdNDC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNDC.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFBR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFBR.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStampDuty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStampDuty.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.grdNDC);
            this.radGroupBox1.HeaderText = "NDC";
            this.radGroupBox1.Location = new System.Drawing.Point(3, 1);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(362, 315);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "NDC";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.grdFBR);
            this.radGroupBox2.HeaderText = "FBR";
            this.radGroupBox2.Location = new System.Drawing.Point(371, 1);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(362, 315);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "FBR";
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.grdStampDuty);
            this.radGroupBox3.HeaderText = "Stamp Duty";
            this.radGroupBox3.Location = new System.Drawing.Point(739, 1);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(362, 315);
            this.radGroupBox3.TabIndex = 2;
            this.radGroupBox3.Text = "Stamp Duty";
            // 
            // grdNDC
            // 
            this.grdNDC.Location = new System.Drawing.Point(6, 15);
            // 
            // 
            // 
            this.grdNDC.MasterTemplate.AllowAddNewRow = false;
            this.grdNDC.MasterTemplate.AllowColumnReorder = false;
            this.grdNDC.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.grdNDC.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdNDC.Name = "grdNDC";
            this.grdNDC.ReadOnly = true;
            this.grdNDC.Size = new System.Drawing.Size(351, 293);
            this.grdNDC.TabIndex = 0;
            this.grdNDC.Text = "radGridView1";
            // 
            // grdFBR
            // 
            this.grdFBR.Location = new System.Drawing.Point(6, 15);
            // 
            // 
            // 
            this.grdFBR.MasterTemplate.AllowAddNewRow = false;
            this.grdFBR.MasterTemplate.AllowColumnReorder = false;
            this.grdFBR.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.grdFBR.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.grdFBR.Name = "grdFBR";
            this.grdFBR.ReadOnly = true;
            this.grdFBR.Size = new System.Drawing.Size(351, 293);
            this.grdFBR.TabIndex = 1;
            this.grdFBR.Text = "radGridView2";
            // 
            // grdStampDuty
            // 
            this.grdStampDuty.Location = new System.Drawing.Point(6, 17);
            // 
            // 
            // 
            this.grdStampDuty.MasterTemplate.AllowAddNewRow = false;
            this.grdStampDuty.MasterTemplate.AllowColumnReorder = false;
            this.grdStampDuty.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.grdStampDuty.MasterTemplate.ViewDefinition = tableViewDefinition3;
            this.grdStampDuty.Name = "grdStampDuty";
            this.grdStampDuty.ReadOnly = true;
            this.grdStampDuty.Size = new System.Drawing.Size(351, 293);
            this.grdStampDuty.TabIndex = 1;
            this.grdStampDuty.Text = "radGridView3";
            // 
            // frm_NDC_FBR_Stm_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1103, 321);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frm_NDC_FBR_Stm_Dashboard";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frm_NDC_FBR_Stm_Dashboard";
            this.Load += new System.EventHandler(this.frm_NDC_FBR_Stm_Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdNDC.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdNDC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFBR.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFBR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStampDuty.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdStampDuty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView grdNDC;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadGridView grdFBR;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadGridView grdStampDuty;
    }
}
