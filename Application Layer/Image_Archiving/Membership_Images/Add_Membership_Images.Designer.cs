namespace PeshawarDHASW.Application_Layer.Image_Archiving
{
    partial class Add_Image
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
            this.btn_NewImage = new Telerik.WinControls.UI.RadButton();
            this.grdImagesDetail = new Telerik.WinControls.UI.RadGridView();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.txtMembershipNo = new Telerik.WinControls.UI.RadTextBox();
            this.lblms = new Telerik.WinControls.UI.RadLabel();
            this.btnFind = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.btn_NewImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImagesDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImagesDetail.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMembershipNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_NewImage
            // 
            this.btn_NewImage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_NewImage.Location = new System.Drawing.Point(548, 12);
            this.btn_NewImage.Name = "btn_NewImage";
            this.btn_NewImage.Size = new System.Drawing.Size(231, 51);
            this.btn_NewImage.TabIndex = 0;
            this.btn_NewImage.Text = "Add New Member Images";
            this.btn_NewImage.Click += new System.EventHandler(this.btn_NewImage_Click);
            // 
            // grdImagesDetail
            // 
            this.grdImagesDetail.Location = new System.Drawing.Point(1, 69);
            // 
            // 
            // 
            this.grdImagesDetail.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.grdImagesDetail.Name = "grdImagesDetail";
            this.grdImagesDetail.Size = new System.Drawing.Size(1122, 586);
            this.grdImagesDetail.TabIndex = 1;
            this.grdImagesDetail.Text = "radGridView1";
            this.grdImagesDetail.CellClick += new Telerik.WinControls.UI.GridViewCellEventHandler(this.grdImagesDetail_CellClick);
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(883, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(231, 51);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save Data To DataBase";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtMembershipNo
            // 
            this.txtMembershipNo.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMembershipNo.Location = new System.Drawing.Point(153, 22);
            this.txtMembershipNo.Name = "txtMembershipNo";
            this.txtMembershipNo.Size = new System.Drawing.Size(303, 31);
            this.txtMembershipNo.TabIndex = 3;
            this.txtMembershipNo.TextChanged += new System.EventHandler(this.txtMembershipNo_TextChanged);
            this.txtMembershipNo.Leave += new System.EventHandler(this.txtMembershipNo_Leave);
            // 
            // lblms
            // 
            this.lblms.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblms.Location = new System.Drawing.Point(1, 23);
            this.lblms.Name = "lblms";
            this.lblms.Size = new System.Drawing.Size(153, 30);
            this.lblms.TabIndex = 4;
            this.lblms.Text = "Membership No.";
            this.lblms.Click += new System.EventHandler(this.lblms_Click);
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(462, 23);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(63, 30);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // Add_Image
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 667);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblms);
            this.Controls.Add(this.txtMembershipNo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grdImagesDetail);
            this.Controls.Add(this.btn_NewImage);
            this.Name = "Add_Image";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Add_Image";
            this.Load += new System.EventHandler(this.Add_Image_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_NewImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImagesDetail.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdImagesDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMembershipNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btn_NewImage;
        private Telerik.WinControls.UI.RadGridView grdImagesDetail;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadTextBox txtMembershipNo;
        private Telerik.WinControls.UI.RadLabel lblms;
        private Telerik.WinControls.UI.RadButton btnFind;
    }
}
