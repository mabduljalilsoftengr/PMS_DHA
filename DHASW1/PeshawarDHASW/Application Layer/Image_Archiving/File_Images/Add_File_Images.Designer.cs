namespace PeshawarDHASW.Application_Layer.Image_Archiving.File_Images
{
    partial class Add_File_Images
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
            this.btnFind = new Telerik.WinControls.UI.RadButton();
            this.lblms = new Telerik.WinControls.UI.RadLabel();
            this.txtFileNo = new Telerik.WinControls.UI.RadTextBox();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.grdImagesDetail = new Telerik.WinControls.UI.RadGridView();
            this.btn_NewFileImage = new Telerik.WinControls.UI.RadButton();
            this.btn_Browse = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImagesDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImagesDetail.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_NewFileImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Browse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(435, 14);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(63, 30);
            this.btnFind.TabIndex = 11;
            this.btnFind.Text = "Find";
            // 
            // lblms
            // 
            this.lblms.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblms.Location = new System.Drawing.Point(4, 14);
            this.lblms.Name = "lblms";
            this.lblms.Size = new System.Drawing.Size(74, 30);
            this.lblms.TabIndex = 10;
            this.lblms.Text = "File No.";
            // 
            // txtFileNo
            // 
            this.txtFileNo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileNo.Location = new System.Drawing.Point(82, 13);
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.Size = new System.Drawing.Size(347, 31);
            this.txtFileNo.TabIndex = 9;
            this.txtFileNo.Leave += new System.EventHandler(this.txtFileNo_Leave);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(893, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(231, 51);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save Data To DataBase";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grdImagesDetail
            // 
            this.grdImagesDetail.Location = new System.Drawing.Point(4, 60);
            // 
            // 
            // 
            this.grdImagesDetail.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdImagesDetail.Name = "grdImagesDetail";
            this.grdImagesDetail.Size = new System.Drawing.Size(1122, 586);
            this.grdImagesDetail.TabIndex = 7;
            this.grdImagesDetail.Text = "radGridView1";
            this.grdImagesDetail.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdImagesDetail_CellClick);
            // 
            // btn_NewFileImage
            // 
            this.btn_NewFileImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NewFileImage.Location = new System.Drawing.Point(505, 3);
            this.btn_NewFileImage.Name = "btn_NewFileImage";
            this.btn_NewFileImage.Size = new System.Drawing.Size(162, 51);
            this.btn_NewFileImage.TabIndex = 6;
            this.btn_NewFileImage.Text = "Add New File Images";
            this.btn_NewFileImage.Click += new System.EventHandler(this.btn_NewFileImage_Click);
            // 
            // btn_Browse
            // 
            this.btn_Browse.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Browse.Location = new System.Drawing.Point(678, 3);
            this.btn_Browse.Name = "btn_Browse";
            this.btn_Browse.Size = new System.Drawing.Size(106, 51);
            this.btn_Browse.TabIndex = 12;
            this.btn_Browse.Text = "Browse . . .";
            this.btn_Browse.Click += new System.EventHandler(this.btn_Browse_Click);
            // 
            // Add_File_Images
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1132, 658);
            this.Controls.Add(this.btn_Browse);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblms);
            this.Controls.Add(this.txtFileNo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdImagesDetail);
            this.Controls.Add(this.btn_NewFileImage);
            this.Name = "Add_File_Images";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Add_File_Images";
            this.Load += new System.EventHandler(this.Add_File_Images_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImagesDetail.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImagesDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_NewFileImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Browse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnFind;
        private Telerik.WinControls.UI.RadLabel lblms;
        private Telerik.WinControls.UI.RadTextBox txtFileNo;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadGridView grdImagesDetail;
        private Telerik.WinControls.UI.RadButton btn_NewFileImage;
        private Telerik.WinControls.UI.RadButton btn_Browse;
    }
}
