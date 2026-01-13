using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.AdventureArena
{
    public partial class AdventureArenaChallanVerification : Telerik.WinControls.UI.RadForm
    {
        public AdventureArenaChallanVerification()
        {
            InitializeComponent();
        }

        private void DataLoadingTicketInformation()
        {
            try
            {
                SqlParameter[] param = {
                    new SqlParameter("@Task","ChallanInformation")
                };
                DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                    , "App.USP_AdventureChallan", param
                    );
                dgvChallanInformation.DataSource = ds.Tables[0].DefaultView;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void radButton1_Click(object sender, EventArgs e)
        {
            this.dgvChallanInformation.MasterView.TableSearchRow.Search(Findtxt.Text);
        }

        private void AdventureArenaChallanVerification_Load(object sender, EventArgs e)
        {
            DataLoadingTicketInformation();
        }

        private void dgvChallanInformation_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "Detail")
            {
                AdventureArenaChallanDetail obj = new AdventureArenaChallanDetail(e.Row.Cells["TicketGenerateID"].Value.ToString());
                obj.ShowDialog();
            }
            if (e.Column.Name == "Report")
            {
                try
                {
                    SqlParameter[] param =
                    {
                        new SqlParameter("@Task","GetReportSourceofAdventureArena"),
                        new SqlParameter("@TicketGenerateID",e.Row.Cells["TicketGenerateID"].Value.ToString()),
                    };
                    DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                   , "App.USP_AdventureChallan", param
                   );
                    Report.AdventureArena.AdventureArenaDs objAAds = new Report.AdventureArena.AdventureArenaDs();
                    objAAds.tbl_AdventureTicketChallanHead.Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                    objAAds.tbl_AdventureTicketChallanDetail.Merge(ds.Tables[1], true, MissingSchemaAction.Ignore);
                    AdventureArenaReportViewer rptViewer = new AdventureArenaReportViewer("AdventureArenaChallan", objAAds);
                    rptViewer.ShowDialog();
                }
                catch (Exception)
                {

                }
            }
            if (e.Column.Name == "Verified")
            {
                if (e.Row.Cells["StatusofChallan"].Value.ToString() == "Pending")
                {


                    AdventureArenaMessagebox obj = new AdventureArenaMessagebox("Challan Details will never be modified after update.\n Do you want..", true);
                    obj.ShowDialog();
                    if (obj.status == "Approve")
                    {
                        try
                        {
                            SqlParameter[] param = {
                        new SqlParameter("@Task","VerifiedChallan"),
                        new SqlParameter("@TicketGenerateID",e.Row.Cells["TicketGenerateID"].Value.ToString()),
                        new SqlParameter("@VerifiedStatus","Received"),
                        new SqlParameter("@StatusofChallan","Received"),
                         new SqlParameter("@VerifiedDate",DateTime.Now),
                         new SqlParameter("@Remarks",obj.Remarks)
                         };
                            int ds = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                            , "App.USP_AdventureChallan", param
                          );
                            DataLoadingTicketInformation();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Adventure Arena Challan Clearance Fail. Error ::--" + ex.Message);
                        }

                    }
                    else if (obj.status == "Cancel")
                    {
                        try
                        {
                            SqlParameter[] param = {
                        new SqlParameter("@Task","VerifiedChallan"),
                        new SqlParameter("@TicketGenerateID",e.Row.Cells["TicketGenerateID"].Value.ToString()),
                        new SqlParameter("@VerifiedStatus","Cancelled"),
                        new SqlParameter("@StatusofChallan","Cancelled"),
                         new SqlParameter("@VerifiedDate",DateTime.Now),
                         new SqlParameter("@Remarks",obj.Remarks)
                         };
                            int ds = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure
                            , "App.USP_AdventureChallan", param
                          );
                            DataLoadingTicketInformation();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Adventure Arena Challan Clearance Fail. Error ::--" + ex.Message);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Challan is Already is Received.");
                }
            }
        }
    }
}
