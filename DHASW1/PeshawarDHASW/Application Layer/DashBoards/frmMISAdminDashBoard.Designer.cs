namespace PeshawarDHASW.Application_Layer.DashBoards
{
    partial class frmMISAdminDashBoard
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
            Telerik.WinControls.UI.CategoricalAxis categoricalAxis1 = new Telerik.WinControls.UI.CategoricalAxis();
            Telerik.WinControls.UI.LinearAxis linearAxis1 = new Telerik.WinControls.UI.LinearAxis();
            Telerik.WinControls.UI.CartesianArea cartesianArea2 = new Telerik.WinControls.UI.CartesianArea();
            Telerik.WinControls.UI.CategoricalAxis categoricalAxis2 = new Telerik.WinControls.UI.CategoricalAxis();
            Telerik.WinControls.UI.LinearAxis linearAxis2 = new Telerik.WinControls.UI.LinearAxis();
            this.telerikMetroTheme1 = new Telerik.WinControls.Themes.TelerikMetroTheme();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dpuserinfo = new Telerik.WinControls.UI.RadDropDownList();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radChartView1 = new Telerik.WinControls.UI.RadChartView();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.PerformanceChart = new Telerik.WinControls.UI.RadChartView();
            this.btnProfmanceChecker = new Telerik.WinControls.UI.RadButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpuserinfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PerformanceChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProfmanceChecker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(4, 13);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1073, 486);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dpuserinfo);
            this.tabPage1.Controls.Add(this.radGroupBox2);
            this.tabPage1.Controls.Add(this.radGroupBox1);
            this.tabPage1.Controls.Add(this.btnProfmanceChecker);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1065, 460);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data Entry Progress";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dpuserinfo
            // 
            this.dpuserinfo.Location = new System.Drawing.Point(9, 22);
            this.dpuserinfo.Name = "dpuserinfo";
            this.dpuserinfo.Size = new System.Drawing.Size(201, 24);
            this.dpuserinfo.TabIndex = 4;
            this.dpuserinfo.Text = "radDropDownList1";
            this.dpuserinfo.ThemeName = "TelerikMetro";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.radGroupBox2.Controls.Add(this.radChartView1);
            this.radGroupBox2.HeaderText = "Speed Chart";
            this.radGroupBox2.Location = new System.Drawing.Point(548, 52);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(511, 402);
            this.radGroupBox2.TabIndex = 3;
            this.radGroupBox2.Text = "Speed Chart";
            this.radGroupBox2.ThemeName = "TelerikMetro";
            // 
            // radChartView1
            // 
            this.radChartView1.AreaDesign = cartesianArea1;
            categoricalAxis1.IsPrimary = true;
            linearAxis1.AxisType = Telerik.Charting.AxisType.Second;
            linearAxis1.IsPrimary = true;
            linearAxis1.TickOrigin = null;
            this.radChartView1.Axes.AddRange(new Telerik.WinControls.UI.Axis[] {
            categoricalAxis1,
            linearAxis1});
            this.radChartView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radChartView1.Location = new System.Drawing.Point(2, 18);
            this.radChartView1.Name = "radChartView1";
            this.radChartView1.SelectionMode = Telerik.WinControls.UI.ChartSelectionMode.MultipleDataPoints;
            this.radChartView1.ShowGrid = false;
            this.radChartView1.ShowPanZoom = true;
            this.radChartView1.ShowToolTip = true;
            this.radChartView1.ShowTrackBall = true;
            this.radChartView1.Size = new System.Drawing.Size(507, 382);
            this.radChartView1.TabIndex = 0;
            this.radChartView1.Text = "radChartView1";
            this.radChartView1.ThemeName = "TelerikMetro";
            ((Telerik.WinControls.UI.ChartTitleElement)(this.radChartView1.GetChildAt(0).GetChildAt(0).GetChildAt(0))).BorderTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(9)))));
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.radGroupBox1.Controls.Add(this.PerformanceChart);
            this.radGroupBox1.HeaderText = "Speed Chart";
            this.radGroupBox1.Location = new System.Drawing.Point(7, 52);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(535, 402);
            this.radGroupBox1.TabIndex = 2;
            this.radGroupBox1.Text = "Speed Chart";
            this.radGroupBox1.ThemeName = "TelerikMetro";
            // 
            // PerformanceChart
            // 
            this.PerformanceChart.AreaDesign = cartesianArea2;
            categoricalAxis2.IsPrimary = true;
            linearAxis2.AxisType = Telerik.Charting.AxisType.Second;
            linearAxis2.IsPrimary = true;
            linearAxis2.TickOrigin = null;
            this.PerformanceChart.Axes.AddRange(new Telerik.WinControls.UI.Axis[] {
            categoricalAxis2,
            linearAxis2});
            this.PerformanceChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PerformanceChart.LegendTitle = "Performance";
            this.PerformanceChart.Location = new System.Drawing.Point(2, 18);
            this.PerformanceChart.Name = "PerformanceChart";
            this.PerformanceChart.SelectionMode = Telerik.WinControls.UI.ChartSelectionMode.MultipleDataPoints;
            this.PerformanceChart.ShowDrillNavigation = true;
            this.PerformanceChart.ShowGrid = false;
            this.PerformanceChart.ShowPanZoom = true;
            this.PerformanceChart.ShowTitle = true;
            this.PerformanceChart.ShowToolTip = true;
            this.PerformanceChart.ShowTrackBall = true;
            this.PerformanceChart.Size = new System.Drawing.Size(531, 382);
            this.PerformanceChart.TabIndex = 0;
            this.PerformanceChart.Text = "radChartView1";
            this.PerformanceChart.ThemeName = "TelerikMetro";
            ((Telerik.WinControls.UI.ChartTitleElement)(this.PerformanceChart.GetChildAt(0).GetChildAt(0).GetChildAt(0))).BorderTopColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(9)))));
            // 
            // btnProfmanceChecker
            // 
            this.btnProfmanceChecker.Location = new System.Drawing.Point(216, 22);
            this.btnProfmanceChecker.Name = "btnProfmanceChecker";
            this.btnProfmanceChecker.Size = new System.Drawing.Size(93, 24);
            this.btnProfmanceChecker.TabIndex = 1;
            this.btnProfmanceChecker.Text = "Load Chart";
            this.btnProfmanceChecker.ThemeName = "TelerikMetro";
            this.btnProfmanceChecker.Click += new System.EventHandler(this.btnProfmanceChecker_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1065, 460);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Control";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // frmMISAdminDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 511);
            this.Controls.Add(this.tabControl1);
            this.Name = "frmMISAdminDashBoard";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "MIS Admin DashBoard";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmMISAdminDashBoard_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dpuserinfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radChartView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PerformanceChart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnProfmanceChecker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.Themes.TelerikMetroTheme telerikMetroTheme1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private Telerik.WinControls.UI.RadChartView PerformanceChart;
        private System.Windows.Forms.TabPage tabPage2;
        private Telerik.WinControls.UI.RadButton btnProfmanceChecker;
        private Telerik.WinControls.UI.RadDropDownList dpuserinfo;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadChartView radChartView1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
    }
}
