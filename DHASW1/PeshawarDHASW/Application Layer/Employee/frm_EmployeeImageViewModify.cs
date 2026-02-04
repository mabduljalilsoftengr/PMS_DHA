using PeshawarDHASW.Helper;
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

namespace PeshawarDHASW.Application_Layer.Employee
{
    public partial class frm_EmployeeImageViewModify : Telerik.WinControls.UI.RadForm
    {
        private int EMPID { get; set; }
        private string DHPNo { get; set; }
        private string SName { get; set; }
        private string CNICNo { get; set; }
        private DataSet dst { get; set; }
        public frm_EmployeeImageViewModify()
        {
            InitializeComponent();
        }

        public frm_EmployeeImageViewModify(int emp_ID_,string dpno, string nm, string nic, DataSet dst_)
        {
            InitializeComponent();
            EMPID = emp_ID_;
            DHPNo = dpno;
            SName = nm;
            CNICNo = nic;
            dst = dst_ ;

        }

        private void frm_EmployeeImageViewModify_Load(object sender, EventArgs e)
        {

            lbldhpno.Text = DHPNo;
            lblname.Text = Name;
            lblcnicno.Text = CNICNo;
            grdimagedetail.DataSource = dst.Tables[0].DefaultView;
        }

        private void grdimagedetail_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.Name == "EmpImage")
            {
                byte[] imgData = (byte[])e.Row.Cells["EmpImage"].Value;
                MemoryStream ms = new MemoryStream(imgData);
                ms.Position = 0;
                pcbEmpImgBox.Image = Image.FromStream(ms);
            }
            else if(e.Column.Name == "btnModifyEmp_Img")
            {
                int imdid = int.Parse(e.Row.Cells["EmpImgID"].Value.ToString());
                #region Image Uploading 
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                // openFileDialog1.Multiselect = true;
                openFileDialog1.Filter =
                    @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
                openFileDialog1.Title = "Select Photos";

                DialogResult dr = openFileDialog1.ShowDialog();
                if (dr == System.Windows.Forms.DialogResult.OK)
                {
                    string[] files = openFileDialog1.FileNames;
                    int i = 1;
                    foreach (var pngFile in files)
                    {
                        try
                        {
                            Image img = Image.FromFile(pngFile);
                            MemoryStream ms = new MemoryStream();
                            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            Byte[] Im = ms.ToArray();
                            
                            grdimagedetail.Rows[e.RowIndex].Cells["EmpImage"].Value = Im;

                            SqlParameter[] prmt =
                            {
                                new SqlParameter("@Task","UpdateEmpImage"),
                                new SqlParameter("@EmpImgID",imdid),
                                new SqlParameter("@EmpImage",Im)
                            };
                            int result = Helper.SQLHelper.ExecuteNonQuery(
                                                              clsMostUseVars.VerifiedImageConnectionstring,
                                                              CommandType.StoredProcedure,
                                                              "dbo.usp_tbl_EmployeeImages",
                                                              prmt
                                                              );
                            MessageBox.Show("Updation Successfull.");

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("This is not an image file");
                        }
                    }

                }
                #endregion
            }
            else if(e.Column.Name == "btnEmpImg_Add")
            {
                frmEmployeeImagesUpload frm = new frmEmployeeImagesUpload(EMPID, DHPNo, SName, CNICNo);
                frm.Show();
            }
        }
    }
}
