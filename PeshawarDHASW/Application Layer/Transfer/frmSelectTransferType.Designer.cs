namespace PeshawarDHASW.Application_Layer.Transfer
{
    partial class frmSelectTransferType
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
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnTFRTypeSelect = new Telerik.WinControls.UI.RadButton();
            this.raddpTFRType = new Telerik.WinControls.UI.RadDropDownList();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTFRTypeSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.raddpTFRType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radGroupBox1.Controls.Add(this.btnTFRTypeSelect);
            this.radGroupBox1.Controls.Add(this.raddpTFRType);
            this.radGroupBox1.HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            this.radGroupBox1.HeaderText = "Select Transfer Type";
            this.radGroupBox1.Location = new System.Drawing.Point(138, 100);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(432, 193);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Select Transfer Type";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            ((Telerik.WinControls.UI.RadGroupBoxElement)(this.radGroupBox1.GetChildAt(0))).HeaderAlignment = Telerik.WinControls.UI.HeaderAlignment.Center;
            ((Telerik.WinControls.UI.GroupBoxContent)(this.radGroupBox1.GetChildAt(0).GetChildAt(0))).Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            ((Telerik.WinControls.UI.GroupBoxHeader)(this.radGroupBox1.GetChildAt(0).GetChildAt(1))).Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // btnTFRTypeSelect
            // 
            this.btnTFRTypeSelect.Location = new System.Drawing.Point(64, 107);
            this.btnTFRTypeSelect.Name = "btnTFRTypeSelect";
            this.btnTFRTypeSelect.Size = new System.Drawing.Size(309, 44);
            this.btnTFRTypeSelect.TabIndex = 1;
            this.btnTFRTypeSelect.Text = "Processed to Next Step";
            this.btnTFRTypeSelect.ThemeName = "TelerikMetro";
            this.btnTFRTypeSelect.Click += new System.EventHandler(this.btnTFRTypeSelect_Click);
            // 
            // raddpTFRType
            // 
            this.raddpTFRType.Location = new System.Drawing.Point(64, 66);
            this.raddpTFRType.Name = "raddpTFRType";
            this.raddpTFRType.Size = new System.Drawing.Size(309, 34);
            this.raddpTFRType.TabIndex = 0;
            this.raddpTFRType.ThemeName = "TelerikMetro";
            this.raddpTFRType.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.raddpTFRType_SelectedIndexChanged);
            ((Telerik.WinControls.UI.RadDropDownListElement)(this.raddpTFRType.GetChildAt(0))).Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            // 
            // frmSelectTransferType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 420);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmSelectTransferType";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Select Transfer Type";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmSelectTransferType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnTFRTypeSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.raddpTFRType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnTFRTypeSelect;
        private Telerik.WinControls.UI.RadDropDownList raddpTFRType;
    }
}
