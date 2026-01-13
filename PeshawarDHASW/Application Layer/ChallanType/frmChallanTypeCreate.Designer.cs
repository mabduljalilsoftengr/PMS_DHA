namespace PeshawarDHASW.Application_Layer.ChallanType
{
    partial class frmChallanTypeCreate
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
            Telerik.WinControls.UI.RadListDataItem radListDataItem1 = new Telerik.WinControls.UI.RadListDataItem();
            Telerik.WinControls.UI.RadListDataItem radListDataItem2 = new Telerik.WinControls.UI.RadListDataItem();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.btnreset = new Telerik.WinControls.UI.RadButton();
            this.btnsave = new Telerik.WinControls.UI.RadButton();
            this.dpstatus = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.txtremarks = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel3 = new Telerik.WinControls.UI.RadLabel();
            this.txtdescp = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txttype = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnreset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnsave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpstatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremarks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdescp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttype)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.btnreset);
            this.radGroupBox1.Controls.Add(this.btnsave);
            this.radGroupBox1.Controls.Add(this.dpstatus);
            this.radGroupBox1.Controls.Add(this.radLabel4);
            this.radGroupBox1.Controls.Add(this.txtremarks);
            this.radGroupBox1.Controls.Add(this.radLabel3);
            this.radGroupBox1.Controls.Add(this.txtdescp);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.txttype);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.HeaderText = "Create New Challan";
            this.radGroupBox1.Location = new System.Drawing.Point(13, 13);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(473, 378);
            this.radGroupBox1.TabIndex = 0;
            this.radGroupBox1.Text = "Create New Challan";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // btnreset
            // 
            this.btnreset.Location = new System.Drawing.Point(261, 308);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(194, 46);
            this.btnreset.TabIndex = 12;
            this.btnreset.Text = "Reset";
            this.btnreset.ThemeName = "TelerikMetro";
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(27, 308);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(228, 46);
            this.btnsave.TabIndex = 11;
            this.btnsave.Text = "Save";
            this.btnsave.ThemeName = "TelerikMetro";
            this.btnsave.Click += new System.EventHandler(this.btnsave_Click);
            // 
            // dpstatus
            // 
            this.dpstatus.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            radListDataItem1.Text = "Active";
            radListDataItem2.Text = "Disable";
            this.dpstatus.Items.Add(radListDataItem1);
            this.dpstatus.Items.Add(radListDataItem2);
            this.dpstatus.Location = new System.Drawing.Point(123, 259);
            this.dpstatus.Name = "dpstatus";
            this.dpstatus.Size = new System.Drawing.Size(332, 24);
            this.dpstatus.TabIndex = 10;
            this.dpstatus.ThemeName = "TelerikMetro";
            // 
            // radLabel4
            // 
            this.radLabel4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel4.Location = new System.Drawing.Point(16, 259);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(52, 25);
            this.radLabel4.TabIndex = 9;
            this.radLabel4.Text = "Status";
            // 
            // txtremarks
            // 
            this.txtremarks.AutoSize = false;
            this.txtremarks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtremarks.Location = new System.Drawing.Point(123, 167);
            this.txtremarks.Multiline = true;
            this.txtremarks.Name = "txtremarks";
            this.txtremarks.Size = new System.Drawing.Size(332, 76);
            this.txtremarks.TabIndex = 9;
            // 
            // radLabel3
            // 
            this.radLabel3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel3.Location = new System.Drawing.Point(16, 167);
            this.radLabel3.Name = "radLabel3";
            this.radLabel3.Size = new System.Drawing.Size(70, 25);
            this.radLabel3.TabIndex = 8;
            this.radLabel3.Text = "Remarks";
            // 
            // txtdescp
            // 
            this.txtdescp.AutoSize = false;
            this.txtdescp.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdescp.Location = new System.Drawing.Point(123, 85);
            this.txtdescp.Multiline = true;
            this.txtdescp.Name = "txtdescp";
            this.txtdescp.Size = new System.Drawing.Size(332, 76);
            this.txtdescp.TabIndex = 7;
            // 
            // radLabel2
            // 
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel2.Location = new System.Drawing.Point(16, 85);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(91, 25);
            this.radLabel2.TabIndex = 6;
            this.radLabel2.Text = "Description";
            // 
            // txttype
            // 
            this.txttype.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txttype.Location = new System.Drawing.Point(123, 45);
            this.txttype.Name = "txttype";
            this.txttype.Size = new System.Drawing.Size(332, 27);
            this.txttype.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(16, 45);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(101, 25);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Challan Type";
            // 
            // frmChallanTypeCreate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 400);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmChallanTypeCreate";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Challan Type Create";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmChallanTypeCreate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnreset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnsave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dpstatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtremarks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtdescp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txttype)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadButton btnreset;
        private Telerik.WinControls.UI.RadButton btnsave;
        private Telerik.WinControls.UI.RadDropDownList dpstatus;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadTextBox txtremarks;
        private Telerik.WinControls.UI.RadLabel radLabel3;
        private Telerik.WinControls.UI.RadTextBox txtdescp;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txttype;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
