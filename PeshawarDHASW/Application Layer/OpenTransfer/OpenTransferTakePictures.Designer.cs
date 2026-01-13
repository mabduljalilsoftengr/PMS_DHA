namespace PeshawarDHASW.Application_Layer.OpenTransfer
{
    partial class OpenTransferTakePictures
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
            Telerik.WinControls.UI.GridViewImageColumn gridViewImageColumn1 = new Telerik.WinControls.UI.GridViewImageColumn();
            Telerik.WinControls.UI.GridViewTextBoxColumn gridViewTextBoxColumn1 = new Telerik.WinControls.UI.GridViewTextBoxColumn();
            Telerik.WinControls.UI.GridViewCommandColumn gridViewCommandColumn1 = new Telerik.WinControls.UI.GridViewCommandColumn();
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radGroupBox3 = new Telerik.WinControls.UI.RadGroupBox();
            this.grdImagesContainer = new Telerik.WinControls.UI.RadGridView();
            this.radGroupBox6 = new Telerik.WinControls.UI.RadGroupBox();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.mainviewpicture = new System.Windows.Forms.PictureBox();
            this.radGroupBox5 = new Telerik.WinControls.UI.RadGroupBox();
            this.btn_Add_To_Grid = new Telerik.WinControls.UI.RadButton();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.btnimagebrowse = new Telerik.WinControls.UI.RadButton();
            this.btnTakePicture = new Telerik.WinControls.UI.RadButton();
            this.btnstartcam = new Telerik.WinControls.UI.RadButton();
            this.cmbCamera = new System.Windows.Forms.ComboBox();
            this.radLabel30 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel31 = new Telerik.WinControls.UI.RadLabel();
            this.OrigionalImage = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).BeginInit();
            this.radGroupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdImagesContainer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImagesContainer.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox6)).BeginInit();
            this.radGroupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainviewpicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).BeginInit();
            this.radGroupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Add_To_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnimagebrowse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTakePicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnstartcam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel30)).BeginInit();
            this.radLabel30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel31)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrigionalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox3
            // 
            this.radGroupBox3.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox3.Controls.Add(this.grdImagesContainer);
            this.radGroupBox3.HeaderText = "Images Container";
            this.radGroupBox3.Location = new System.Drawing.Point(640, 72);
            this.radGroupBox3.Name = "radGroupBox3";
            this.radGroupBox3.Size = new System.Drawing.Size(401, 392);
            this.radGroupBox3.TabIndex = 30;
            this.radGroupBox3.Text = "Images Container";
            this.radGroupBox3.ThemeName = "TelerikMetro";
            // 
            // grdImagesContainer
            // 
            this.grdImagesContainer.BackColor = System.Drawing.Color.White;
            this.grdImagesContainer.Cursor = System.Windows.Forms.Cursors.Default;
            this.grdImagesContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.grdImagesContainer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grdImagesContainer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grdImagesContainer.Location = new System.Drawing.Point(5, 18);
            // 
            // 
            // 
            gridViewImageColumn1.EnableExpressionEditor = false;
            gridViewImageColumn1.HeaderText = "Image";
            gridViewImageColumn1.ImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            gridViewImageColumn1.Name = "TFRImage";
            gridViewImageColumn1.Width = 200;
            gridViewTextBoxColumn1.EnableExpressionEditor = false;
            gridViewTextBoxColumn1.FieldName = "Remarks";
            gridViewTextBoxColumn1.HeaderText = "Remarks";
            gridViewTextBoxColumn1.Name = "Remarks";
            gridViewTextBoxColumn1.Width = 122;
            gridViewCommandColumn1.DefaultText = "X";
            gridViewCommandColumn1.EnableExpressionEditor = false;
            gridViewCommandColumn1.FieldName = "btn_Remove";
            gridViewCommandColumn1.HeaderText = "Remove";
            gridViewCommandColumn1.Name = "btn_Remove";
            gridViewCommandColumn1.UseDefaultText = true;
            this.grdImagesContainer.MasterTemplate.Columns.AddRange(new Telerik.WinControls.UI.GridViewDataColumn[] {
            gridViewImageColumn1,
            gridViewTextBoxColumn1,
            gridViewCommandColumn1});
            this.grdImagesContainer.MasterTemplate.EnableGrouping = false;
            this.grdImagesContainer.MasterTemplate.EnableSorting = false;
            this.grdImagesContainer.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdImagesContainer.Name = "grdImagesContainer";
            this.grdImagesContainer.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.grdImagesContainer.Size = new System.Drawing.Size(391, 369);
            this.grdImagesContainer.TabIndex = 0;
            this.grdImagesContainer.Text = "radGridView1";
            this.grdImagesContainer.ThemeName = "TelerikMetro";
            this.grdImagesContainer.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdImagesContainer_CellClick);
            // 
            // radGroupBox6
            // 
            this.radGroupBox6.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox6.Controls.Add(this.radGroupBox1);
            this.radGroupBox6.Controls.Add(this.mainviewpicture);
            this.radGroupBox6.HeaderText = "Image";
            this.radGroupBox6.Location = new System.Drawing.Point(4, 74);
            this.radGroupBox6.Name = "radGroupBox6";
            this.radGroupBox6.Size = new System.Drawing.Size(628, 390);
            this.radGroupBox6.TabIndex = 29;
            this.radGroupBox6.Text = "Image";
            this.radGroupBox6.ThemeName = "TelerikMetro";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.HeaderText = "radGroupBox1";
            this.radGroupBox1.Location = new System.Drawing.Point(745, 0);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(200, 320);
            this.radGroupBox1.TabIndex = 26;
            this.radGroupBox1.Text = "radGroupBox1";
            // 
            // mainviewpicture
            // 
            this.mainviewpicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainviewpicture.Location = new System.Drawing.Point(2, 18);
            this.mainviewpicture.Name = "mainviewpicture";
            this.mainviewpicture.Size = new System.Drawing.Size(624, 370);
            this.mainviewpicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.mainviewpicture.TabIndex = 0;
            this.mainviewpicture.TabStop = false;
            // 
            // radGroupBox5
            // 
            this.radGroupBox5.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox5.Controls.Add(this.btn_Add_To_Grid);
            this.radGroupBox5.Controls.Add(this.btnSave);
            this.radGroupBox5.Controls.Add(this.btnimagebrowse);
            this.radGroupBox5.Controls.Add(this.btnTakePicture);
            this.radGroupBox5.Controls.Add(this.btnstartcam);
            this.radGroupBox5.Controls.Add(this.cmbCamera);
            this.radGroupBox5.Controls.Add(this.radLabel30);
            this.radGroupBox5.HeaderText = "Seller Information";
            this.radGroupBox5.Location = new System.Drawing.Point(3, 2);
            this.radGroupBox5.Name = "radGroupBox5";
            this.radGroupBox5.Size = new System.Drawing.Size(1043, 66);
            this.radGroupBox5.TabIndex = 28;
            this.radGroupBox5.Text = "Seller Information";
            this.radGroupBox5.ThemeName = "TelerikMetro";
            // 
            // btn_Add_To_Grid
            // 
            this.btn_Add_To_Grid.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Add_To_Grid.Location = new System.Drawing.Point(675, 26);
            this.btn_Add_To_Grid.Name = "btn_Add_To_Grid";
            this.btn_Add_To_Grid.Size = new System.Drawing.Size(164, 28);
            this.btn_Add_To_Grid.TabIndex = 13;
            this.btn_Add_To_Grid.Text = "Capture Picture";
            this.btn_Add_To_Grid.ThemeName = "TelerikMetro";
            this.btn_Add_To_Grid.Click += new System.EventHandler(this.btn_Add_To_Grid_Click);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(854, 25);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(177, 28);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.ThemeName = "TelerikMetro";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnimagebrowse
            // 
            this.btnimagebrowse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnimagebrowse.Location = new System.Drawing.Point(520, 27);
            this.btnimagebrowse.Name = "btnimagebrowse";
            this.btnimagebrowse.Size = new System.Drawing.Size(139, 28);
            this.btnimagebrowse.TabIndex = 11;
            this.btnimagebrowse.Text = "Browse . . . ";
            this.btnimagebrowse.ThemeName = "TelerikMetro";
            this.btnimagebrowse.Click += new System.EventHandler(this.btnimagebrowse_Click);
            // 
            // btnTakePicture
            // 
            this.btnTakePicture.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTakePicture.Location = new System.Drawing.Point(384, 27);
            this.btnTakePicture.Name = "btnTakePicture";
            this.btnTakePicture.Size = new System.Drawing.Size(119, 28);
            this.btnTakePicture.TabIndex = 10;
            this.btnTakePicture.Text = "Stop Cam";
            this.btnTakePicture.ThemeName = "TelerikMetro";
            this.btnTakePicture.Click += new System.EventHandler(this.btnTakePicture_Click);
            // 
            // btnstartcam
            // 
            this.btnstartcam.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnstartcam.Location = new System.Drawing.Point(249, 27);
            this.btnstartcam.Name = "btnstartcam";
            this.btnstartcam.Size = new System.Drawing.Size(123, 28);
            this.btnstartcam.TabIndex = 9;
            this.btnstartcam.Text = "Start Cam";
            this.btnstartcam.ThemeName = "TelerikMetro";
            this.btnstartcam.Click += new System.EventHandler(this.btnstartcam_Click);
            // 
            // cmbCamera
            // 
            this.cmbCamera.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCamera.FormattingEnabled = true;
            this.cmbCamera.Location = new System.Drawing.Point(70, 27);
            this.cmbCamera.Name = "cmbCamera";
            this.cmbCamera.Size = new System.Drawing.Size(167, 28);
            this.cmbCamera.TabIndex = 8;
            // 
            // radLabel30
            // 
            this.radLabel30.Controls.Add(this.radLabel31);
            this.radLabel30.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel30.Location = new System.Drawing.Point(10, 27);
            this.radLabel30.Name = "radLabel30";
            this.radLabel30.Size = new System.Drawing.Size(54, 22);
            this.radLabel30.TabIndex = 3;
            this.radLabel30.Text = "Image";
            // 
            // radLabel31
            // 
            this.radLabel31.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel31.Location = new System.Drawing.Point(5, 25);
            this.radLabel31.Name = "radLabel31";
            this.radLabel31.Size = new System.Drawing.Size(13, 22);
            this.radLabel31.TabIndex = 10;
            this.radLabel31.Text = "-";
            // 
            // OrigionalImage
            // 
            this.OrigionalImage.Location = new System.Drawing.Point(749, 470);
            this.OrigionalImage.Name = "OrigionalImage";
            this.OrigionalImage.Size = new System.Drawing.Size(4608, 3456);
            this.OrigionalImage.TabIndex = 31;
            this.OrigionalImage.TabStop = false;
            this.OrigionalImage.Visible = false;
            // 
            // OpenTransferTakePictures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1046, 482);
            this.Controls.Add(this.OrigionalImage);
            this.Controls.Add(this.radGroupBox3);
            this.Controls.Add(this.radGroupBox6);
            this.Controls.Add(this.radGroupBox5);
            this.Name = "OpenTransferTakePictures";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "OpenTransferTakePictures";
            this.ThemeName = "TelerikMetro";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OpenTransferTakePictures_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox3)).EndInit();
            this.radGroupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdImagesContainer.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImagesContainer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox6)).EndInit();
            this.radGroupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainviewpicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox5)).EndInit();
            this.radGroupBox5.ResumeLayout(false);
            this.radGroupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Add_To_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnimagebrowse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnTakePicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnstartcam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel30)).EndInit();
            this.radLabel30.ResumeLayout(false);
            this.radLabel30.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel31)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrigionalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox3;
        private Telerik.WinControls.UI.RadGridView grdImagesContainer;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox6;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private System.Windows.Forms.PictureBox mainviewpicture;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox5;
        private Telerik.WinControls.UI.RadButton btn_Add_To_Grid;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadButton btnimagebrowse;
        private Telerik.WinControls.UI.RadButton btnTakePicture;
        private Telerik.WinControls.UI.RadButton btnstartcam;
        private System.Windows.Forms.ComboBox cmbCamera;
        private Telerik.WinControls.UI.RadLabel radLabel30;
        private Telerik.WinControls.UI.RadLabel radLabel31;
        private System.Windows.Forms.PictureBox OrigionalImage;
    }
}
