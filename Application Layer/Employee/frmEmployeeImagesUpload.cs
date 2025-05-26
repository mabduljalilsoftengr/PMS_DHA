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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Employee
{
    public partial class frmEmployeeImagesUpload : Telerik.WinControls.UI.RadForm
    {
        public frmEmployeeImagesUpload()
        {
            InitializeComponent();
        }

        private int EMPID { get; set; }
        private string DHPNo { get; set; }
        private string SName { get; set; }
        private string CNINo { get; set; }
        private DataTable dstbl { get; set; }
             
        public frmEmployeeImagesUpload(int empid,string dhp, string name, string nic, DataTable dt)
        {
            InitializeComponent();
            EMPID = empid;
            DHPNo = dhp;
            Name = name;
            CNINo = nic;
            dstbl = dt;
        }
        public frmEmployeeImagesUpload(int getEMPID,string getDHPNo,string getName,string getCNICNo)
        {
            InitializeComponent();
            DataTable dt = new DataTable();
            EMPID = getEMPID;
            DHPNo = getDHPNo;
            Name = getName;
            CNINo = getCNICNo;
            dstbl = dt;
        }
        private void frmEmployeeImagesUpload_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.MinimumSize = this.Size;
            this.MaximumSize = this.Size;

            lblcnicno.Text = CNINo;
            lbldhpno.Text = DHPNo;
            lblname.Text = Name;
            grdimagedetail.TableElement.RowHeight = 200;
            grdimagedetail.Columns["Image"].ImageLayout = ImageLayout.Stretch;
            grdimagedetail.DataSource = dstbl.DefaultView;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int result = 0;
            foreach (GridViewRowInfo rw in grdimagedetail.Rows)
            {
                string name = rw.Cells["Name"].Value.ToString();
                string des = rw.Cells["Description"].Value.ToString();

                Image img = (Image)(rw.Cells["Image"].Value);
                MemoryStream ms = new MemoryStream();
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                Byte[] Im = ms.ToArray();
                
                SqlParameter[] prm =
                {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@EmpImage",Im),
                new SqlParameter("@ImageName",name),
                new SqlParameter("@Description",des),
                new SqlParameter("@Emp_ID",EMPID)
                };
                result = Helper.SQLHelper.ExecuteNonQuery(
                                                              clsMostUseVars.VerifiedImageConnectionstring,
                                                              CommandType.StoredProcedure,
                                                              "dbo.usp_tbl_EmployeeImages",
                                                              prm
                                                              );
                
            }
            if (result > 0)
            {
                if (MessageBox.Show("Successfull.", "Success.", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                {
                    this.Close();
                }

            }

        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            #region Image Uploading
            ///////////   Declare Table
            DataTable dt = new DataTable();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Multiselect = true;
            openFileDialog1.Filter =
                @"Images (*.BMP;*.JPG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
            openFileDialog1.Title = "Select Photos";

            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {

                dt.Clear();
                dt.Columns.Add("Image", typeof(Image));
                dt.Columns.Add("Name", typeof(string));
                dt.Columns.Add("Description", typeof(string));


                string[] files = openFileDialog1.FileNames;
                int i = 1;
                foreach (var pngFile in files)
                {
                    try
                    {
                        DataRow _ravi = dt.NewRow();

                        _ravi["Image"] = Image.FromFile(pngFile);
                        _ravi["Name"] = DateTime.Now.ToString("yyyyMMdd") + "_" + i;
                        _ravi["Description"] = "";
                        dt.Rows.Add(_ravi);
                        i = i + 1;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("This is not an image file");
                    }
                }

                grdimagedetail.DataSource = dt.DefaultView;
            }
            #endregion
        }
    }
}
