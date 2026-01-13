using PeshawarDHASW.Application_Layer.Membership.MSImage;
using PeshawarDHASW.Data_Layer.clsPosession;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Transfer.PlotsPosession
{
    public partial class frmPosessionVerificationbyTFR : Telerik.WinControls.UI.RadForm
    {
        public frmPosessionVerificationbyTFR()
        {
            InitializeComponent();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadPsessionData();
        }
        private void LoadPsessionData()
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetPosessionData")
            };
            DataSet ds = cls_dl_posession.Posession_Reader(prm);
            grdPosession.DataSource = ds.Tables[0].DefaultView;
            grdExpirePosession.DataSource = ds.Tables[1].DefaultView;
        }

        private void grdPosession_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int pid = int.Parse(e.Row.Cells["PID"].Value.ToString());

                if (e.Column.Name == "btnUploadDoc")
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.Multiselect = true;
                    openFileDialog1.Filter =
                        @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                    openFileDialog1.Title = "Select Photos";

                    DialogResult dr = openFileDialog1.ShowDialog();
                    if (dr == System.Windows.Forms.DialogResult.OK)
                    {
                        Image obj = new Bitmap(openFileDialog1.FileName);
                        MemoryStream ms = new MemoryStream();
                        obj.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                        Byte[] Img = ms.ToArray();
                        if (MessageBox.Show( "Are you sure you want to save Document.", "Attention !", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            SqlParameter[] prm =
                            {
                            new SqlParameter("@Task","InsertPosessionImage"),
                            new SqlParameter("@PID",pid),
                            new SqlParameter("@Image", Img),
                            new SqlParameter("@ImageName", DateTime.Now.ToString("yyyyMMdd") + "-2"),
                            new SqlParameter("@Description", "Attachments of Posession Form Part-2.")
                        };
                            int rslt = cls_dl_posession.Posession_NonQuery(prm);
                            MessageBox.Show("Posession Apply Form scan copy is saved successfuly.", "Success !", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                    }
                }
                else if (e.Column.Name == "btnVerifyPs")
                {
                        #region Verification
                        string fileno = e.Row.Cells["FileNo"].Value.ToString();
                        SqlParameter[] prm =
                        {
                        new SqlParameter("@Task","CheckCaution"),
                        new SqlParameter("@FileNo",fileno)
                        };
                        DataSet dst = cls_dl_posession.Posession_Reader(prm);
                        if (dst.Tables.Count > 0)
                        {
                            if (dst.Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show( "This File No. is under caution." + Environment.NewLine
                                + "Caution : " + dst.Tables[0].Rows[0]["Cauction"].ToString(), "Warning!",
                                MessageBoxButtons.OK,MessageBoxIcon.Warning );
                            }
                            else
                            {
                            if (MessageBox.Show("Are you sure that this File No." + e.Row.Cells["FileNo"].Value.ToString() +
                               " is not under any litigation / caution and" + Environment.NewLine
                               + "move the case to Finance branch for further processing.", "Confirm!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                               {
                                  SqlParameter[] prmtr =
                                  {
                                  new SqlParameter("@Task","UpdateStatusPs"),
                                  new SqlParameter("@Status","VerifiedByTFR"),
                                  new SqlParameter("@PID",pid)
                                  };
                                  int rslt = cls_dl_posession.Posession_NonQuery(prmtr);
                                  if (rslt > 0)
                                  {
                                      MessageBox.Show("The Plot detail is successfuly verified by "
                                      +Models.clsUser.Name + Environment.NewLine
                                      +"and forwarded to Finance branch for further process.","Success."
                                      ,MessageBoxButtons.OK,MessageBoxIcon.Information);
                                      LoadPsessionData();
                                  }
                               }
                            }
                        }
                        #endregion
                }
                else if(e.Column.Name == "btnViewImage")
                {
                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","ViewPosessionImages"),
                        new SqlParameter("@PID",pid)
                    };
                    DataSet ds = cls_dl_posession.Posession_Reader(prm);
                    frmPhotoViewer frm = new frmPhotoViewer(ds.Tables[0]);
                    frm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmPosessionVerificationbyTFR_Load(object sender, EventArgs e)
        {
            LoadPsessionData();
        }
    }
}
