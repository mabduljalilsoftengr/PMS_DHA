namespace PeshawarDHASW.Application_Layer.FileMap
{
    partial class frmAddPlotNoAllRecordData
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
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtPlotNo = new Telerik.WinControls.UI.RadTextBox();
            this.btnSavePlotNo = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlotNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSavePlotNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 12);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(44, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Plot No";
            // 
            // txtPlotNo
            // 
            this.txtPlotNo.Location = new System.Drawing.Point(12, 36);
            this.txtPlotNo.Name = "txtPlotNo";
            this.txtPlotNo.Size = new System.Drawing.Size(229, 20);
            this.txtPlotNo.TabIndex = 1;
            // 
            // btnSavePlotNo
            // 
            this.btnSavePlotNo.Location = new System.Drawing.Point(13, 63);
            this.btnSavePlotNo.Name = "btnSavePlotNo";
            this.btnSavePlotNo.Size = new System.Drawing.Size(228, 24);
            this.btnSavePlotNo.TabIndex = 2;
            this.btnSavePlotNo.Text = "Save Plot No";
            this.btnSavePlotNo.Click += new System.EventHandler(this.btnSavePlotNo_Click);
            // 
            // frmAddPlotNoAllRecordData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 103);
            this.Controls.Add(this.btnSavePlotNo);
            this.Controls.Add(this.txtPlotNo);
            this.Controls.Add(this.radLabel1);
            this.Name = "frmAddPlotNoAllRecordData";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmAddPlotNoAllRecordData";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlotNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSavePlotNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox txtPlotNo;
        private Telerik.WinControls.UI.RadButton btnSavePlotNo;
    }
}
