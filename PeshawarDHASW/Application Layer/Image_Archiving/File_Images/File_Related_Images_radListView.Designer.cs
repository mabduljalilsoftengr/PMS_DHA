namespace PeshawarDHASW.Application_Layer.Image_Archiving.File_Images
{
    partial class File_Related_Images_radListView
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
            this.lstv_Images = new Telerik.WinControls.UI.RadListView();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.lstv_Images)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // lstv_Images
            // 
            this.lstv_Images.ItemSpacing = -1;
            this.lstv_Images.Location = new System.Drawing.Point(12, 12);
            this.lstv_Images.Name = "lstv_Images";
            this.lstv_Images.Size = new System.Drawing.Size(868, 666);
            this.lstv_Images.TabIndex = 0;
            this.lstv_Images.Text = "radListView1";
            this.lstv_Images.ViewType = Telerik.WinControls.UI.ListViewType.DetailsView;
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(982, 278);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 85);
            this.radButton1.TabIndex = 0;
            this.radButton1.Text = "Grouping";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click_1);
            // 
            // File_Related_Images
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1120, 690);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.lstv_Images);
            this.Name = "File_Related_Images";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "File_Related_Images";
            this.Load += new System.EventHandler(this.File_Related_Images_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lstv_Images)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadListView lstv_Images;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}
