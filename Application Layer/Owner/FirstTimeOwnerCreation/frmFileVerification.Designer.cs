namespace PeshawarDHASW.Application_Layer.Owner.FirstTimeOwnerCreation
{
    partial class frmFileVerification
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.ddlOwnerType = new Telerik.WinControls.UI.RadDropDownList();
            this.lblDescription1 = new Telerik.WinControls.UI.RadLabel();
            this.lblDescription = new Telerik.WinControls.UI.RadLabel();
            this.btnFileVerification = new Telerik.WinControls.UI.RadButton();
            this.txtFileNumber = new Telerik.WinControls.UI.RadTextBox();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlOwnerType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFileVerification)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radLabel1);
            this.groupBox1.Controls.Add(this.ddlOwnerType);
            this.groupBox1.Controls.Add(this.lblDescription1);
            this.groupBox1.Controls.Add(this.lblDescription);
            this.groupBox1.Controls.Add(this.btnFileVerification);
            this.groupBox1.Controls.Add(this.txtFileNumber);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(385, 318);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File Verification";
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(21, 29);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(59, 24);
            this.radLabel1.TabIndex = 4;
            this.radLabel1.Text = "File No";
            this.radLabel1.Visible = false;
            // 
            // ddlOwnerType
            // 
            this.ddlOwnerType.Location = new System.Drawing.Point(21, 225);
            this.ddlOwnerType.Name = "ddlOwnerType";
            this.ddlOwnerType.Size = new System.Drawing.Size(345, 34);
            this.ddlOwnerType.TabIndex = 5;
            this.ddlOwnerType.ThemeName = "TelerikMetro";
            this.ddlOwnerType.Visible = false;
            this.ddlOwnerType.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.ddlOwnerType_SelectedIndexChanged);
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.ddlOwnerType.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // lblDescription1
            // 
            this.lblDescription1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription1.Location = new System.Drawing.Point(21, 179);
            this.lblDescription1.Name = "lblDescription1";
            this.lblDescription1.Size = new System.Drawing.Size(79, 24);
            this.lblDescription1.TabIndex = 4;
            this.lblDescription1.Text = "radLabel1";
            this.lblDescription1.Visible = false;
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(21, 149);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(79, 24);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "radLabel1";
            this.lblDescription.Visible = false;
            // 
            // btnFileVerification
            // 
            this.btnFileVerification.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFileVerification.Location = new System.Drawing.Point(21, 99);
            this.btnFileVerification.Name = "btnFileVerification";
            this.btnFileVerification.Size = new System.Drawing.Size(345, 37);
            this.btnFileVerification.TabIndex = 2;
            this.btnFileVerification.Text = "Verify File NO";
            this.btnFileVerification.ThemeName = "TelerikMetro";
            this.btnFileVerification.Click += new System.EventHandler(this.btnFileVerification_Click);
            // 
            // txtFileNumber
            // 
            this.txtFileNumber.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileNumber.Location = new System.Drawing.Point(21, 59);
            this.txtFileNumber.Name = "txtFileNumber";
            this.txtFileNumber.NullText = "Enter File Number here For Verification ";
            this.txtFileNumber.Size = new System.Drawing.Size(345, 34);
            this.txtFileNumber.TabIndex = 1;
            this.txtFileNumber.ThemeName = "TelerikMetro";
            // 
            // frmFileVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 339);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmFileVerification";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmFileVerification";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmFileVerification_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ddlOwnerType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblDescription)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFileVerification)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFileNumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private Telerik.WinControls.UI.RadButton btnFileVerification;
        private Telerik.WinControls.UI.RadTextBox txtFileNumber;
        private Telerik.WinControls.UI.RadLabel lblDescription;
        private Telerik.WinControls.UI.RadLabel lblDescription1;
        private Telerik.WinControls.UI.RadDropDownList ddlOwnerType;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
    }
}
