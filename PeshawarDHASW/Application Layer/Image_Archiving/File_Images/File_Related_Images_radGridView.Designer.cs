namespace PeshawarDHASW.Application_Layer.Image_Archiving.File_Images
{
    partial class File_Related_Images_radGridView
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
            this.grd_Detail = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Detail.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // grd_Detail
            // 
            this.grd_Detail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grd_Detail.Location = new System.Drawing.Point(-2, 0);
            // 
            // 
            // 
            this.grd_Detail.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.grd_Detail.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grd_Detail.Name = "grd_Detail";
            this.grd_Detail.Size = new System.Drawing.Size(1053, 725);
            this.grd_Detail.TabIndex = 0;
            this.grd_Detail.Text = "radGridView1";
            this.grd_Detail.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grd_Detail_CellClick);
            // 
            // File_Related_Images_radGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1049, 725);
            this.Controls.Add(this.grd_Detail);
            this.Name = "File_Related_Images_radGridView";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "File_Related_Images_radGridView";
            this.Load += new System.EventHandler(this.File_Related_Images_radGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grd_Detail.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grd_Detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView grd_Detail;
    }
}
