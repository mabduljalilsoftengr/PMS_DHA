using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Data;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.AdventureArena
{
    public partial class AdventureArenaChallanSearch : Telerik.WinControls.UI.RadForm
    {
        public AdventureArenaChallanSearch()
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
        private void AdventureArenaChallanSearch_Load(object sender, EventArgs e)
        {
            DataLoadingTicketInformation();
        }

        private void radTextBox1_TextChanged(object sender, EventArgs e)
        {
            //GridViewSearchRowInfo searchRow = dgvChallanInformation.MasterView.TableSearchRow;
            //searchRow.SearchProgressChanged += SearchRow_SearchProgressChanged;
            //searchRow.HighlightResults = true;
            //searchRow.AutomaticallySelectFirstResult = true;
            //searchRow.Search(Findtxt.Text);
            //dgvChallanInformation.(filter);
           
        }


        private void Findtxt_TextChanging(object sender, TextChangingEventArgs e)
        {
            this.dgvChallanInformation.MasterView.TableSearchRow.Search(Findtxt.Text);
        }

        private void btnAddNewInvoice_Click(object sender, EventArgs e)
        {
            AdventureTicketChallan obj = new AdventureTicketChallan();
            obj.ShowDialog();
            DataLoadingTicketInformation();
        }

        private void MasterTemplate_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name=="Detail")
            {
                AdventureArenaChallanDetail obj = new AdventureArenaChallanDetail(e.Row.Cells["TicketGenerateID"].Value.ToString());
                obj.ShowDialog();
            }
            if (e.Column.Name== "Report")
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
                    AdventureArenaReportViewer rptViewer = new AdventureArenaReportViewer("AdventureArenaChallan",objAAds);
                    rptViewer.ShowDialog();
                    //MessageBox.Show(objAAds.Tables[0].Rows.Count.ToString());
                }
                catch (Exception)
                {
                    
                }
            }
        }
    }
}
