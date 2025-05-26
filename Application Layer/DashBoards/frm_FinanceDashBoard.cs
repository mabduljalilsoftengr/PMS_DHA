using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Themes;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.DashBoards
{
    public partial class frm_FinanceDashBoard : Telerik.WinControls.UI.RadForm
    {
        public const int WM_SIZE = 5;

        private LightVisualElement examplePage;
        private RadButtonElement backButton;
        private LightVisualElement headerLabel;
        private RadTitleBarElement titleBar;

        private bool isFormMoving = false;
        private string currentExample = string.Empty;


        public frm_FinanceDashBoard()
        {
            InitializeComponent();
            this.PrepareTitleBar(); 
        }






     

        #region PrepareTitleBar
        private void PrepareTitleBar()
        {
            titleBar = new RadTitleBarElement();

            titleBar.FillPrimitive.Visibility = ElementVisibility.Hidden;
            titleBar.MaxSize = new Size(0, 50);
            titleBar.Children[1].Visibility = ElementVisibility.Hidden;

            titleBar.CloseButton.Parent.PositionOffset = new SizeF(0, 10);
            titleBar.CloseButton.MinSize = new Size(50, 50);
            titleBar.CloseButton.ButtonFillElement.Visibility = ElementVisibility.Collapsed;

            titleBar.MinimizeButton.MinSize = new Size(50, 50);
            titleBar.MinimizeButton.ButtonFillElement.Visibility = ElementVisibility.Collapsed;

            titleBar.MaximizeButton.MinSize = new Size(50, 50);
            titleBar.MaximizeButton.ButtonFillElement.Visibility = ElementVisibility.Collapsed;

            titleBar.CloseButton.SetValue(RadFormElement.IsFormActiveProperty, true);
            titleBar.MinimizeButton.SetValue(RadFormElement.IsFormActiveProperty, true);
            titleBar.MaximizeButton.SetValue(RadFormElement.IsFormActiveProperty, true);

            titleBar.Close += new TitleBarSystemEventHandler(titleBar_Close);
            titleBar.Minimize += new TitleBarSystemEventHandler(titleBar_Minimize);
            titleBar.MaximizeRestore += new TitleBarSystemEventHandler(titleBar_MaximizeRestore);
            this.radPanorama1.PanoramaElement.PanGesture += new PanGestureEventHandler(radTilePanel1_PanGesture);
            this.radPanorama1.PanoramaElement.Children.Add(titleBar);
        }

        void titleBar_Close(object sender, EventArgs args)
        {
            this.Close();
        }

        void titleBar_Minimize(object sender, EventArgs args)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        void titleBar_MaximizeRestore(object sender, EventArgs args)
        {
            if (this.WindowState != FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        void radTilePanel1_PanGesture(object sender, PanGestureEventArgs e)
        {
            if (e.IsBegin && this.titleBar.ControlBoundingRectangle.Contains(e.Location))
            {
                isFormMoving = true;
            }

            if (isFormMoving)
            {
                this.Location = new Point(this.Location.X + e.Offset.Width, this.Location.Y + e.Offset.Height);
            }
            else
            {
                e.Handled = false;
            }

            if (e.IsEnd)
            {
                isFormMoving = false;
            }
        }

        #endregion

        private void radPanorama1_Click(object sender, EventArgs e)
        {
            
        }

        private void frm_FinanceDashBoard_Load(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] param = { new SqlParameter("@Task", "DashBoardQueries") };
                DataSet dst = PeshawarDHASW.Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(param);
                 double ToDayDDsEntried =  double.Parse(dst.Tables[0].Rows[0]["ToDayDDsEntried"].ToString());
                 double TodayTotalAmount =  double.Parse(dst.Tables[0].Rows[0]["TodayTotalAmount"].ToString());

                double PreciousDayDDsEntried = double.Parse(dst.Tables[0].Rows[0]["PreciousDayDDsEntried"].ToString());
                double PreciousDayTotalAmount = double.Parse(dst.Tables[0].Rows[0]["PreciousDayTotalAmount"].ToString());

                 double CleardDDsEntried =  double.Parse(dst.Tables[0].Rows[0]["CleardDDsEntried"].ToString());
                 double ClearedTotalAmount =  double.Parse(dst.Tables[0].Rows[0]["ClearedTotalAmount"].ToString());

                 double ReceivedDDsEntried =  double.Parse(dst.Tables[0].Rows[0]["ReceivedDDsEntried"].ToString());
                 double ReceivedTotalAmount =  double.Parse(dst.Tables[0].Rows[0]["ReceivedTotalAmount"].ToString());

                 double TotalPrintedEntried =  double.Parse(dst.Tables[0].Rows[0]["TotalPrintedEntried"].ToString());
                 double TotalNotPrintedAck =  double.Parse(dst.Tables[0].Rows[0]["TotalNotPrintedAck"].ToString());

                 double TotalActiveFiles =  double.Parse(dst.Tables[0].Rows[0]["TotalActiveFiles"].ToString());
                 double TotalCancelFiles =  double.Parse(dst.Tables[0].Rows[0]["TotalCancelFiles"].ToString());

               
                string TodayDDEntried = string.Format("Today Entries " + ToDayDDsEntried.ToString() + "\n Total Amount {0:n0}", TodayTotalAmount);
                string PreciousDay_DDsEntried = string.Format("Precious Day Entries " + PreciousDayDDsEntried.ToString() + " \n Total Amount {0:n0}", PreciousDayTotalAmount);
                string ReceivedDD_Entried = string.Format("Total Received " + ReceivedDDsEntried.ToString() + " \n Total Amount {0:n0}", ReceivedTotalAmount); 
                string CleardDD_Entried = string.Format("Total Cleared DD's " + CleardDDsEntried.ToString() + " \n Total Amount {0:n0}", ClearedTotalAmount);
                string TotalActive_Files = "Total Active Files " + TotalActiveFiles.ToString();
                string TotalCancel_Files = "Total Cancel Files " + TotalCancelFiles.ToString();
                string TotalPrinted_Entried = "Total Printed Acknowledgement " + TotalPrintedEntried.ToString();
                string TotalNotPrinted_Ack = "Total Not Printed Acknowledgement " + TotalNotPrintedAck.ToString();

                TodayReceiveItem.Text = TodayDDEntried;
                PreciousDayReceiveItem.Text = PreciousDay_DDsEntried;
                TotalReceiveItem.Text = ReceivedDD_Entried;
                TotalClearedItem.Text = CleardDD_Entried;
                TotalActiveFilesItem.Text = TotalActive_Files;
                TotalCancelFilesItem.Text = TotalCancel_Files;
                TotalPrintedAcknowledgementItem.Text = TotalPrinted_Entried;
                TotalNotPrintedAcknowledgementItem.Text = TotalNotPrinted_Ack;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
          
        }
    }
}
