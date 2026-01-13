namespace PeshawarDHASW.Application_Layer.DashBoards
{
    partial class frm_FinanceDashBoard
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
            this.radPanorama1 = new Telerik.WinControls.UI.RadPanorama();
            this.ReceiveInformationGroup = new Telerik.WinControls.UI.TileGroupElement();
            this.TodayReceiveItem = new Telerik.WinControls.UI.RadLiveTileElement();
            this.PreciousDayReceiveItem = new Telerik.WinControls.UI.RadLiveTileElement();
            this.TotalClearedItem = new Telerik.WinControls.UI.RadLiveTileElement();
            this.TotalReceiveItem = new Telerik.WinControls.UI.RadLiveTileElement();
            this.FileInformationGroup = new Telerik.WinControls.UI.TileGroupElement();
            this.TotalActiveFilesItem = new Telerik.WinControls.UI.RadLiveTileElement();
            this.TotalCancelFilesItem = new Telerik.WinControls.UI.RadLiveTileElement();
            this.AcknowledgementInformationGroup = new Telerik.WinControls.UI.TileGroupElement();
            this.TotalPrintedAcknowledgementItem = new Telerik.WinControls.UI.RadLiveTileElement();
            this.TotalNotPrintedAcknowledgementItem = new Telerik.WinControls.UI.RadLiveTileElement();
            ((System.ComponentModel.ISupportInitialize)(this.radPanorama1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radPanorama1
            // 
            this.radPanorama1.AutoScroll = true;
            this.radPanorama1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(23)))), ((int)(((byte)(117)))));
            this.radPanorama1.BackgroundImage = global::PeshawarDHASW.Properties.Resources.bg_pattern;
            this.radPanorama1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.radPanorama1.Groups.AddRange(new Telerik.WinControls.RadItem[] {
            this.ReceiveInformationGroup,
            this.FileInformationGroup,
            this.AcknowledgementInformationGroup});
            this.radPanorama1.Location = new System.Drawing.Point(0, 0);
            this.radPanorama1.Name = "radPanorama1";
            this.radPanorama1.RowsCount = 4;
            this.radPanorama1.ScrollBarAlignment = Telerik.WinControls.UI.HorizontalScrollAlignment.Bottom;
            this.radPanorama1.ShowGroups = true;
            this.radPanorama1.Size = new System.Drawing.Size(1092, 641);
            this.radPanorama1.TabIndex = 0;
            this.radPanorama1.Text = "Finance Dash Board";
            this.radPanorama1.ThemeName = "TelerikMetroBlue";
            this.radPanorama1.Click += new System.EventHandler(this.radPanorama1_Click);
            // 
            // ReceiveInformationGroup
            // 
            this.ReceiveInformationGroup.CellSize = new System.Drawing.Size(250, 150);
            this.ReceiveInformationGroup.DrawBorder = false;
            this.ReceiveInformationGroup.DrawFill = false;
            this.ReceiveInformationGroup.DrawImage = true;
            this.ReceiveInformationGroup.DrawText = true;
            this.ReceiveInformationGroup.EnableElementShadow = false;
            this.ReceiveInformationGroup.EnableFocusBorder = false;
            this.ReceiveInformationGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ReceiveInformationGroup.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.TodayReceiveItem,
            this.PreciousDayReceiveItem,
            this.TotalClearedItem,
            this.TotalReceiveItem});
            this.ReceiveInformationGroup.Margin = new System.Windows.Forms.Padding(100);
            this.ReceiveInformationGroup.Name = "ReceiveInformationGroup";
            this.ReceiveInformationGroup.RowsCount = 4;
            this.ReceiveInformationGroup.Text = "Receive Information";
            // 
            // TodayReceiveItem
            // 
            this.TodayReceiveItem.ColSpan = 2;
            this.TodayReceiveItem.GradientStyle = Telerik.WinControls.GradientStyles.Solid;
            this.TodayReceiveItem.Image = global::PeshawarDHASW.Properties.Resources.icons8_today_96;
            this.TodayReceiveItem.ImageAlignment = System.Drawing.ContentAlignment.TopRight;
            this.TodayReceiveItem.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TodayReceiveItem.Name = "TodayReceiveItem";
            this.TodayReceiveItem.Text = "Today Receive";
            this.TodayReceiveItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // PreciousDayReceiveItem
            // 
            this.PreciousDayReceiveItem.ColSpan = 2;
            this.PreciousDayReceiveItem.Image = global::PeshawarDHASW.Properties.Resources.icons8_minus_1_day_96;
            this.PreciousDayReceiveItem.ImageAlignment = System.Drawing.ContentAlignment.TopRight;
            this.PreciousDayReceiveItem.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PreciousDayReceiveItem.Name = "PreciousDayReceiveItem";
            this.PreciousDayReceiveItem.Row = 1;
            this.PreciousDayReceiveItem.Text = "Precious Day Receive";
            this.PreciousDayReceiveItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // TotalClearedItem
            // 
            this.TotalClearedItem.ColSpan = 2;
            this.TotalClearedItem.Name = "TotalClearedItem";
            this.TotalClearedItem.Row = 3;
            this.TotalClearedItem.Text = "Total Cleared";
            // 
            // TotalReceiveItem
            // 
            this.TotalReceiveItem.ColSpan = 2;
            this.TotalReceiveItem.Image = global::PeshawarDHASW.Properties.Resources.icons8_cash_in_hand_96;
            this.TotalReceiveItem.ImageAlignment = System.Drawing.ContentAlignment.TopRight;
            this.TotalReceiveItem.ImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TotalReceiveItem.Name = "TotalReceiveItem";
            this.TotalReceiveItem.Row = 2;
            this.TotalReceiveItem.Text = "Total Receive";
            this.TotalReceiveItem.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            // 
            // FileInformationGroup
            // 
            this.FileInformationGroup.AutoSize = true;
            this.FileInformationGroup.CellSize = new System.Drawing.Size(250, 250);
            this.FileInformationGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.FileInformationGroup.GradientStyle = Telerik.WinControls.GradientStyles.Linear;
            this.FileInformationGroup.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.TotalActiveFilesItem,
            this.TotalCancelFilesItem});
            this.FileInformationGroup.Margin = new System.Windows.Forms.Padding(0, 100, 100, 100);
            this.FileInformationGroup.Name = "FileInformationGroup";
            this.FileInformationGroup.RowsCount = 2;
            this.FileInformationGroup.Text = "File Information";
            // 
            // TotalActiveFilesItem
            // 
            this.TotalActiveFilesItem.ColSpan = 2;
            this.TotalActiveFilesItem.Name = "TotalActiveFilesItem";
            this.TotalActiveFilesItem.Text = "Total Active File";
            // 
            // TotalCancelFilesItem
            // 
            this.TotalCancelFilesItem.ColSpan = 2;
            this.TotalCancelFilesItem.Name = "TotalCancelFilesItem";
            this.TotalCancelFilesItem.Row = 1;
            this.TotalCancelFilesItem.Text = "TotalCancelFilesItem";
            this.TotalCancelFilesItem.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AcknowledgementInformationGroup
            // 
            this.AcknowledgementInformationGroup.AutoSize = true;
            this.AcknowledgementInformationGroup.CellSize = new System.Drawing.Size(250, 250);
            this.AcknowledgementInformationGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.AcknowledgementInformationGroup.Items.AddRange(new Telerik.WinControls.RadItem[] {
            this.TotalPrintedAcknowledgementItem,
            this.TotalNotPrintedAcknowledgementItem});
            this.AcknowledgementInformationGroup.Margin = new System.Windows.Forms.Padding(0, 100, 100, 100);
            this.AcknowledgementInformationGroup.Name = "AcknowledgementInformationGroup";
            this.AcknowledgementInformationGroup.RowsCount = 2;
            this.AcknowledgementInformationGroup.Text = "Acknowledgement Information";
            // 
            // TotalPrintedAcknowledgementItem
            // 
            this.TotalPrintedAcknowledgementItem.ColSpan = 2;
            this.TotalPrintedAcknowledgementItem.Name = "TotalPrintedAcknowledgementItem";
            this.TotalPrintedAcknowledgementItem.Text = "Total Printed Acknowledgement";
            // 
            // TotalNotPrintedAcknowledgementItem
            // 
            this.TotalNotPrintedAcknowledgementItem.ColSpan = 2;
            this.TotalNotPrintedAcknowledgementItem.Name = "TotalNotPrintedAcknowledgementItem";
            this.TotalNotPrintedAcknowledgementItem.Row = 1;
            this.TotalNotPrintedAcknowledgementItem.Text = "Total Not Printed Acknowledgement";
            // 
            // frm_FinanceDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1092, 641);
            this.Controls.Add(this.radPanorama1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_FinanceDashBoard";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frm_FinanceDashBoard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_FinanceDashBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.radPanorama1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadPanorama radPanorama1;
        private Telerik.WinControls.UI.TileGroupElement ReceiveInformationGroup;
        private Telerik.WinControls.UI.RadLiveTileElement TodayReceiveItem;
        private Telerik.WinControls.UI.RadLiveTileElement PreciousDayReceiveItem;
        private Telerik.WinControls.UI.RadLiveTileElement TotalClearedItem;
        private Telerik.WinControls.UI.RadLiveTileElement TotalReceiveItem;
        private Telerik.WinControls.UI.TileGroupElement FileInformationGroup;
        private Telerik.WinControls.UI.RadLiveTileElement TotalActiveFilesItem;
        private Telerik.WinControls.UI.RadLiveTileElement TotalCancelFilesItem;
        private Telerik.WinControls.UI.TileGroupElement AcknowledgementInformationGroup;
        private Telerik.WinControls.UI.RadLiveTileElement TotalPrintedAcknowledgementItem;
        private Telerik.WinControls.UI.RadLiveTileElement TotalNotPrintedAcknowledgementItem;
    }
}
