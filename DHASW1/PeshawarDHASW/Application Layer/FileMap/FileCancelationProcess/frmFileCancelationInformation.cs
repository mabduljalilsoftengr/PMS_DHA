using PeshawarDHASW.Application_Layer.CustomDialog;
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

namespace PeshawarDHASW.Application_Layer.FileMap.FileCancelationProcess
{
    public partial class frmFileCancelationInformation : Telerik.WinControls.UI.RadForm
    {
        public frmFileCancelationInformation()
        {
            InitializeComponent();
        }

        private void frmFileCancelationInformation_Load(object sender, EventArgs e)
        {
            SqlParameter param_out_ID = new SqlParameter()
            {
                ParameterName = "@FileCanceltion",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };

            SqlParameter[] parameters =
                           {
                                new SqlParameter("@Task", "SelectInformation_Pending_Cancel_Approved"),
                               
                               param_out_ID
                            };
           DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.Connectionstring, CommandType.StoredProcedure, "usp_tbl_FileCancelation", parameters);

            grd_PendingFile.DataSource = ds.Tables[0].DefaultView;
            grd_ApprovedFile.DataSource = ds.Tables[1].DefaultView;
            grd_CancelFiles.DataSource = ds.Tables[2].DefaultView;
        }

        private void MasterTemplate_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "Attachement")
            {
                try
                {
                    int TDDI_ID = int.Parse(e.Row.Cells["FileCancelationID"].Value.ToString()); // ReceID
                    SqlParameter[] param =
                               {
                    new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                    new SqlParameter("@CFID",TDDI_ID)
                };
                    DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_tbl_FileCancelationImages", param); 
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Membership.MSImage.frmPhotoViewer obj = new Membership.MSImage.frmPhotoViewer(ds.Tables[0]);
                            obj.Show();
                        }
                        else
                        {
                            MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                }
            }
            //Setting Approved Cancel

            if (e.Column.Name == "Status")
            {
                int TDDI_ID = int.Parse(e.Row.Cells["FileCancelationID"].Value.ToString()); // ReceID


                CustomizeMessageBox obj = new CustomizeMessageBox("File is ready for Cancelation.\n Do you want to..", true);
                obj.ShowDialog();
                if (obj.status != null)
                {
                    if (obj.status == "Approve")
                    {
                        SqlParameter param_out_ID = new SqlParameter()
                        {
                            ParameterName = "@FileCanceltion",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };

                        SqlParameter[] prm =
                        {
                            new SqlParameter("@Task","ApproveRequestofCancelation"),
                            new SqlParameter("@FileCancelationID", TDDI_ID),
                            new SqlParameter("@Status", "Approved"),
                            new SqlParameter("@ApprovedRemarks", obj.Remarks),
                            new SqlParameter("@AprovedbyUser", Models.clsUser.ID),
                            param_out_ID
                        };
                        int rslt =  SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "usp_tbl_FileCancelation", prm);
                        if (rslt != 0)
                        {
                            MessageBox.Show("Transaction has been Approved successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        frmFileCancelationInformation_Load(null,null);
                    }
                    else if (obj.status == "Cancel")
                    {
                        SqlParameter param_out_ID = new SqlParameter()
                        {
                            ParameterName = "@FileCanceltion",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };

                        SqlParameter[] prm =
                        {
                            new SqlParameter("@Task","ApproveRequestofCancelation"),
                            new SqlParameter("@FileCancelationID", TDDI_ID),
                            new SqlParameter("@Status", "Cancelled"),
                            new SqlParameter("@ApprovedRemarks", obj.Remarks),
                            new SqlParameter("@AprovedbyUser", Models.clsUser.ID),
                            param_out_ID
                        };
                        int rslt = SQLHelper.ExecuteNonQuery(SQLHelper.createConnection(), CommandType.StoredProcedure, "usp_tbl_FileCancelation", prm);
                        if (rslt != 0)
                        {
                            MessageBox.Show("Transaction has been Cancelled successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        frmFileCancelationInformation_Load(null, null);
                    }

                }
            }

        }

        private void grd_ApprovedFile_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "Attachement")
            {
                try
                {
                    int TDDI_ID = int.Parse(e.Row.Cells["FileCancelationID"].Value.ToString()); // ReceID
                    SqlParameter[] param =
                               {
                    new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                    new SqlParameter("@CFID",TDDI_ID)
                };
                    DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_tbl_FileCancelationImages", param);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Membership.MSImage.frmPhotoViewer obj = new Membership.MSImage.frmPhotoViewer(ds.Tables[0]);
                            obj.Show();
                        }
                        else
                        {
                            MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void grd_CancelFiles_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Column.Name == "Attachement")
            {
                try
                {
                    int TDDI_ID = int.Parse(e.Row.Cells["FileCancelationID"].Value.ToString()); // ReceID
                    SqlParameter[] param =
                               {
                    new SqlParameter("@Task","Select"),//usp_tbl_DDTransferImages
                    new SqlParameter("@CFID",TDDI_ID)
                };
                    DataSet ds = SQLHelper.ExecuteDataset(clsMostUseVars.VerifiedImageConnectionstring, CommandType.StoredProcedure, "usp_tbl_FileCancelationImages", param);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                            Membership.MSImage.frmPhotoViewer obj = new Membership.MSImage.frmPhotoViewer(ds.Tables[0]);
                            obj.Show();
                        }
                        else
                        {
                            MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("No attachment(s) available.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            frmFileCancelationInformation_Load(null, null);
        }
    }
}
