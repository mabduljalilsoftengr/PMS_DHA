namespace PeshawarDHASW.Application_Layer.Installment.InstallmentSummary
{
    partial class InstallmentSummaryGrap
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
            Telerik.WinControls.UI.CartesianArea cartesianArea1 = new Telerik.WinControls.UI.CartesianArea();
            this.radPageView1 = new Telerik.WinControls.UI.RadPageView();
            this.radPageViewPage1 = new Telerik.WinControls.UI.RadPageViewPage();
            this.drpInstallmentTemplate = new Telerik.WinControls.UI.RadDropDownList();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radChartView1 = new Telerik.WinControls.UI.RadChartView();
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).BeginInit();
            this.radPageView1.SuspendLayout();
            this.radPageViewPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInstallmentTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPageView1
            // 
            this.radPageView1.Controls.Add(this.radPageViewPage1);
            this.radPageView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPageView1.Location = new System.Drawing.Point(0, 0);
            this.radPageView1.Name = "radPageView1";
            this.radPageView1.SelectedPage = this.radPageViewPage1;
            this.radPageView1.Size = new System.Drawing.Size(1006, 595);
            this.radPageView1.TabIndex = 0;
            this.radPageView1.Text = "radPageView1";
            // 
            // radPageViewPage1
            // 
            this.radPageViewPage1.Controls.Add(this.drpInstallmentTemplate);
            this.radPageViewPage1.Controls.Add(this.radLabel1);
            this.radPageViewPage1.Controls.Add(this.radChartView1);
            this.radPageViewPage1.ItemSize = new System.Drawing.SizeF(108F, 28F);
            this.radPageViewPage1.Location = new System.Drawing.Point(10, 37);
            this.radPageViewPage1.Name = "radPageViewPage1";
            this.radPageViewPage1.Size = new System.Drawing.Size(985, 547);
            this.radPageViewPage1.Text = "Installment Report";
            // 
            // drpInstallmentTemplate
            // 
            this.drpInstallmentTemplate.DropDownStyle = Telerik.WinControls.RadDropDownStyle.DropDownList;
            this.drpInstallmentTemplate.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.drpInstallmentTemplate.Location = new System.Drawing.Point(170, 3);
            this.drpInstallmentTemplate.Name = "drpInstallmentTemplate";
            this.drpInstallmentTemplate.Size = new System.Drawing.Size(337, 27);
            this.drpInstallmentTemplate.TabIndex = 3;
            this.drpInstallmentTemplate.SelectedIndexChanged += new Telerik.WinControls.UI.Data.PositionChangedEventHandler(this.drpInstallmentTemplate_SelectedIndexChanged);
            // 
            // radLabel1
            // 
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLabel1.Location = new System.Drawing.Point(4, 3);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(160, 25);
            this.radLabel1.TabIndex = 2;
            this.radLabel1.Text = "Installment Template";
            // 
            // radChartView1
            // 
            this.radChartView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            cartesianArea1.ShowGrid = true;
            this.radChartView1.AreaDesign = cartesianArea1;
            this.radChartView1.Location = new System.Drawing.Point(4, 36);
            this.radChartView1.Name = "radChartView1";
            this.radChartView1.SelectionMode = Telerik.WinControls.UI.ChartSelectionMode.MultipleDataPoints;
            this.radChartView1.ShowLegend = true;
            this.radChartView1.ShowPanZoom = true;
            this.radChartView1.ShowTitle = true;
            this.radChartView1.ShowToolTip = true;
            this.radChartView1.ShowTrackBall = true;
            this.radChartView1.Size = new System.Drawing.Size(978, 508);
            this.radChartView1.TabIndex = 0;
            this.radChartView1.Text = "radChartView1";
            this.radChartView1.ThemeName = "TelerikMetro";
            this.radChartView1.Click += new System.EventHandler(this.radChartView1_Click);
            // 
            // InstallmentSummaryGrap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 595);
            this.Controls.Add(this.radPageView1);
            this.Name = "InstallmentSummaryGrap";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Installment Summary Graph";
            this.Load += new System.EventHandler(this.InstallmentSummaryGrap_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPageView1)).EndInit();
            this.radPageView1.ResumeLayout(false);
            this.radPageViewPage1.ResumeLayout(false);
            this.radPageViewPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.drpInstallmentTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPageView radPageView1;
        private Telerik.WinControls.UI.RadPageViewPage radPageViewPage1;
        private Telerik.WinControls.UI.RadChartView radChartView1;
        private Telerik.WinControls.UI.RadDropDownList drpInstallmentTemplate;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
