namespace PeshawarDHASW.Application_Layer.Launching
{
    partial class frmDocImageViewing
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
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.DGV_ImageInfo = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.pb_Doc = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ImageInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ImageInfo.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Doc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radGroupBox1.Controls.Add(this.DGV_ImageInfo);
            this.radGroupBox1.HeaderText = "Image Information";
            this.radGroupBox1.Location = new System.Drawing.Point(2, 2);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(377, 510);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Image Information";
            // 
            // DGV_ImageInfo
            // 
            this.DGV_ImageInfo.Location = new System.Drawing.Point(6, 21);
            // 
            // 
            // 
            this.DGV_ImageInfo.MasterTemplate.AllowAddNewRow = false;
            this.DGV_ImageInfo.MasterTemplate.AllowColumnReorder = false;
            this.DGV_ImageInfo.MasterTemplate.ViewDefinition = tableViewDefinition2;
            this.DGV_ImageInfo.Name = "DGV_ImageInfo";
            this.DGV_ImageInfo.ReadOnly = true;
            this.DGV_ImageInfo.Size = new System.Drawing.Size(366, 484);
            this.DGV_ImageInfo.TabIndex = 0;
            this.DGV_ImageInfo.Text = "radGridView1";
            this.DGV_ImageInfo.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.DGV_ImageInfo_CellClick);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox2.Controls.Add(this.pb_Doc);
            this.radGroupBox2.HeaderText = "Picture Information";
            this.radGroupBox2.Location = new System.Drawing.Point(385, 1);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(522, 510);
            this.radGroupBox2.TabIndex = 1;
            this.radGroupBox2.Text = "Picture Information";
            // 
            // pb_Doc
            // 
            this.pb_Doc.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Doc.Location = new System.Drawing.Point(2, 18);
            this.pb_Doc.Name = "pb_Doc";
            this.pb_Doc.Size = new System.Drawing.Size(518, 490);
            this.pb_Doc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_Doc.TabIndex = 0;
            this.pb_Doc.TabStop = false;
            // 
            // frmDocImageViewing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 524);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmDocImageViewing";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmDocImageViewing";
            this.Load += new System.EventHandler(this.frmDocImageViewing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ImageInfo.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ImageInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Doc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadGridView DGV_ImageInfo;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private System.Windows.Forms.PictureBox pb_Doc;
    }
}
