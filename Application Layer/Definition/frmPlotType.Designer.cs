namespace PeshawarDHASW.Application_Layer.Definition
{
    partial class frmPlotType
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
            this.PlotTypeDG = new Telerik.WinControls.UI.RadGridView();
            ((System.ComponentModel.ISupportInitialize)(this.PlotTypeDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlotTypeDG.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // PlotTypeDG
            // 
            this.PlotTypeDG.AutoSizeRows = true;
            this.PlotTypeDG.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PlotTypeDG.Location = new System.Drawing.Point(0, 0);
            // 
            // 
            // 
            this.PlotTypeDG.MasterTemplate.AllowAddNewRow = false;
            this.PlotTypeDG.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.PlotTypeDG.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.PlotTypeDG.Name = "PlotTypeDG";
            this.PlotTypeDG.ReadOnly = true;
            this.PlotTypeDG.Size = new System.Drawing.Size(469, 270);
            this.PlotTypeDG.TabIndex = 0;
            this.PlotTypeDG.Text = "Plot Type";
            this.PlotTypeDG.ThemeName = "TelerikMetro";
            // 
            // frmPlotType
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 270);
            this.Controls.Add(this.PlotTypeDG);
            this.Name = "frmPlotType";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "PlotType";
            this.ThemeName = "TelerikMetro";
            this.Load += new System.EventHandler(this.frmPlotType_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PlotTypeDG.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PlotTypeDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadGridView PlotTypeDG;
    }
}
