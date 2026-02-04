using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Online_Files
{
    public partial class frmNewOnlineFile : Telerik.WinControls.UI.RadForm
    {
        public frmNewOnlineFile()
        {
            InitializeComponent();
        }

        private void btnFindFile_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] duplicateparam =
                {
                    new SqlParameter("@Task","FilePlotDuplicateFind"),
                    new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                    new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text))
                };
                DataSet dsDuplicate = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection_ComplaintMgt(), CommandType.StoredProcedure, "dbo.USP_File", duplicateparam);
                if (dsDuplicate.Tables.Count > 0)
                {
                    if (dsDuplicate.Tables[0].Rows.Count > 0)
                    {
                        string ExistRecord = dsDuplicate.Tables[0].Rows[0]["ExistRecord"].ToString();
                        int Count = int.Parse(ExistRecord);
                        if (Count > 0)
                        {
                            MessageBox.Show("File | Plot House Record is Already Exist.");
                            return;
                        }
                        else
                        {
                            SqlParameter[] param =
                             {
                                    new SqlParameter("@Task","NewRecordSearch"),
                                    new SqlParameter("@FileNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtFileNo.Text)),
                                    new SqlParameter("@PlotNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text))
                                };
                            DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_FileUpload", param);
                            if (ds.Tables.Count > 0)
                            {
                                if (ds.Tables[0].Rows.Count > 0)
                                {
                                    lblFileNo.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                                    lblPlotNo.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();
                                    lblSector.Text = ds.Tables[0].Rows[0]["Sector"].ToString();
                                    Fullname.Text = ds.Tables[0].Rows[0]["Fullname"].ToString();
                                    lblCNIC.Text = ds.Tables[0].Rows[0]["CNIC"].ToString();
                                    lblMobileNo.Text = ds.Tables[0].Rows[0]["MobileNo"].ToString();
                                }
                                else
                                {
                                    MessageBox.Show("File No | Plot No is Invalid. ");
                                }
                            }
                        }
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUploadOnline_Click(object sender, EventArgs e)
        {
            try
            {

                if(MessageBox.Show("Are you sure to upload data ?", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                   if (lblFileNo.Text == "-" || string.IsNullOrWhiteSpace(lblFileNo.Text))
                   {
                       MessageBox.Show("FileNo | Plot No is Invalid");
                       return;
                   }
                   
                   
                   SqlParameter[] param =
                   {
                       new SqlParameter("@Task","NewRecord"),
                       new SqlParameter("@FileID",lblFileID.Text),
                       new SqlParameter("@FileNo",lblFileNo.Text),
                       new SqlParameter("@PlotNo",lblPlotNo.Text),
                       new SqlParameter("@Sector",lblSector.Text),
                       new SqlParameter("@FullName",Fullname.Text),
                       new SqlParameter("@CNIC",lblCNIC.Text),
                       new SqlParameter("@MobileNo",lblMobileNo.Text),
                       new SqlParameter("@Status","Active"),
                       new SqlParameter("@DateTime",DateTime.Now)
                   };
                   int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection_ComplaintMgt(), CommandType.StoredProcedure, "dbo.USP_File", param);
                   if (result > 0)
                   {
                       MessageBox.Show("Upload Successfull");
                       this.Close();
                   }
                   else
                   {
                       MessageBox.Show("Please Contact to IT Branch.");
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
