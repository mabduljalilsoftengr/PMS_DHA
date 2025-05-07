using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Launching
{
    public partial class frmPaymentsModification : Telerik.WinControls.UI.RadForm
    {
        public frmPaymentsModification()
        {
            InitializeComponent();
        }

        private void btnLoadButton_Click(object sender, EventArgs e)
        {
            getdata();
        }
        private void getdata()
        {
            try
            {
                SqlParameter[] param =
                {
                    new SqlParameter("@Task","GetAllPaymentsForEditing")
                };
                DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.CommercialLaunching", param);
                grdDatagrid.DataSource = ds.Tables[0].DefaultView;
                foreach (var item in grdDatagrid.Columns)
                {
                    item.BestFit();
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void grdDatagrid_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {

            
            if (e.Column.Name == "btnEdit")
            {
                int ApplicationFeeID = int.Parse(e.Row.Cells["ApplicationFeeID"].Value.ToString());
                string CNIC_NICOP = e.Row.Cells["CNIC_NICOP"].Value.ToString();
                string PlotSize = e.Row.Cells["PlotSize"].Value.ToString();
                decimal Amount = Convert.ToDecimal(e.Row.Cells["Amount"].Value.ToString());
                string sts = "";
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","GetdataForUpdatePayment"),
                    new SqlParameter("@ApplicationFeeID",ApplicationFeeID),
                 };
                DataSet dst = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.CommercialLaunching", prm);

                    if(dst.Tables.Count > 0)
                    {
                        if (dst.Tables[0].Rows.Count > 0)
                        {
                             sts = dst.Tables[0].Rows[0]["ApplicationStatus"].ToString();
                        }
                    }
                
                    if(sts == "ValidForBalloting" || sts == "Fee-Received")
                    {
                        MessageBox.Show("Sorry ! Synched Data Couldn't be Mdified.");
                    }
                    else
                    {
                     SqlParameter[] prmtr =
                      {
                       new SqlParameter("@Task","UpdatePayment"),
                        new SqlParameter("@ApplicationFeeID",ApplicationFeeID),
                        new SqlParameter("@CNIC_NICOP",CNIC_NICOP),
                        new SqlParameter("@PlotSize",PlotSize),
                        new SqlParameter("@Amount",Amount)
                      };
                        int rslt = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "Launching.CommercialLaunching", prmtr);
                        if (rslt > 0)
                        {
                            MessageBox.Show("Successfull.");
                            getdata();
                        }
                    }
                 
            }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
