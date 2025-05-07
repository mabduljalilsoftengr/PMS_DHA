namespace PeshawarDHASW.Application_Layer.Control_Management
{
    partial class ControlSetting
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
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.btnControl_New = new Telerik.WinControls.UI.RadPageViewPage();
            this.btnControl_Search = new Telerik.WinControls.UI.RadPageViewPage();
            this.btnControl_Edit = new Telerik.WinControls.UI.RadPageViewPage();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.btnControl_New);
            this.radPageView1.Controls.Add(this.btnControl_Search);
            this.radPageView1.Controls.Add(this.btnControl_Edit);
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Location = new System.Drawing.Point(0, 0);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.btnControl_Edit;
            this.radPageView1.Size = new System.Drawing.Size(1329, 380);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.Text = "radPageView1";
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).ShowItemPinButton = false;
            ((Telerik.WinControls.UI.RadPageViewStripElement)(this.radPageView1.GetChildAt(0))).ShowItemCloseButton = false;
            // 
            // btnControl_New
            // 
            this.btnControl_New.ItemSize = new System.Drawing.SizeF(79F, 28F);
            this.btnControl_New.Location = new System.Drawing.Point(10, 37);
            this.btnControl_New.Name = "btnControl_New";
            this.btnControl_New.Size = new System.Drawing.Size(1308, 332);
            this.btnControl_New.Text = "New Control";
            // 
            // btnControl_Search
            // 
            this.btnControl_Search.AccessibleDescription = "btnControl_Search";
            this.btnControl_Search.AccessibleName = "btnControl_Search";
            this.btnControl_Search.ItemSize = new System.Drawing.SizeF(49F, 28F);
            this.btnControl_Search.Location = new System.Drawing.Point(10, 37);
            this.btnControl_Search.Name = "btnControl_Search";
            this.btnControl_Search.Size = new System.Drawing.Size(1308, 332);
            this.btnControl_Search.Text = "Search";
            // 
            // btnControl_Edit
            // 
            this.btnControl_Edit.AccessibleDescription = "btnControl_Edit";
            this.btnControl_Edit.ItemSize = new System.Drawing.SizeF(35F, 28F);
            this.btnControl_Edit.Location = new System.Drawing.Point(10, 37);
            this.btnControl_Edit.Name = "btnControl_Edit";
            this.btnControl_Edit.Size = new System.Drawing.Size(1308, 332);
            this.btnControl_Edit.Text = "Edit";
            // 
            // ControlSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 380);
            this.Controls.Add(this.radPageView1);
            this.Name = "ControlSetting";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "ControlSetting";
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage btnControl_New;
        private Telerik.WinControls.UI.RadPageViewPage btnControl_Search;
        private Telerik.WinControls.UI.RadPageViewPage btnControl_Edit;
    }
}
