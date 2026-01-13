using PeshawarDHASW.Application_Layer.CustomDialog;
using PeshawarDHASW.Data_Layer.clsEmployee;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using PeshawarDHASW.Helper;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Employee
{
    public partial class frmEmployeeModify : Telerik.WinControls.UI.RadForm
    {
        private DataSet ds { get; set; }
        public frmEmployeeModify()
        {
            InitializeComponent();
        }

        private void btnemployeesearch_Click(object sender, EventArgs e)
        {
            BindDataWithGrid();
        }
        private void LoadBranchDesignation()
        {
            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select --";
            this.drpDesignation.Items.Add(Select);
            SqlParameter[] param =
            {
               new SqlParameter("@Task", "LoadDataBranchDesignation")
            };

            foreach (DataRow row in cls_dl_Employee.Employee_Reader(param, "[App].[usp_tbl_Employee]").Tables[1].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["DesignationID"].ToString();
                dataItem.Text = row["DesignationName"].ToString();
                this.drpDesignation.Items.Add(dataItem);
            }
            drpDesignation.SelectedIndex = 0;




            RadListDataItem Selectb = new RadListDataItem();
            Selectb.Value = 0;
            Selectb.Text = "-- Select --";
            this.drpBranch.Items.Add(Selectb);
            foreach (DataRow row in cls_dl_Employee.Employee_Reader(param, "[App].[usp_tbl_Employee]").Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["BranchID"].ToString();
                dataItem.Text = row["BranchName"].ToString();
                this.drpBranch.Items.Add(dataItem);
            }
            drpBranch.SelectedIndex = 0;

        }
        private void BindDataWithGrid()
        {
            try
            {
                SqlParameter[] parameters =
                {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@DHPNo",txt_e_empno.Text==""?null:txt_e_empno.Text),
                new SqlParameter("@Name",txt_e_name.Text==""?null:txt_e_name.Text),
                new SqlParameter("@Service_Type",drpservicetype.SelectedItem.ToString() =="-- Select --"?null:drpservicetype.SelectedItem.ToString()),
                new SqlParameter("@Employee_Type",drpemployeetype.SelectedItem.ToString() =="-- Select --"?null:drpemployeetype.SelectedItem.ToString()),
                new SqlParameter("@EmpCategory",drpempcategory.SelectedItem.ToString() =="-- Select --"?null:drpempcategory.SelectedItem.ToString()),              
                new SqlParameter("@Branch",drpBranch.SelectedItem.ToString() == "-- Select --"?null:drpBranch.SelectedItem.ToString()),
                new SqlParameter("@Designation",drpDesignation.SelectedItem.ToString() == "-- Select --"?null:drpDesignation.SelectedItem.ToString()),
                new SqlParameter("@BPS",txtbps.Text==""?null:txtbps.Text),
                new SqlParameter("@Mobile",txt_e_mobile.Text==""?null:txt_e_mobile.Text),
                new SqlParameter("@CNIC_No",txtcnic.Text==""?null:txtcnic.Text),
                new SqlParameter("@Office_Location",txtlocation.Text==""?null:txtlocation.Text)
                };
                ds = cls_dl_Employee.Employee_Reader(parameters, "App.usp_tbl_Employee");
                //this.grdEmployeeModify.Columns["Image"].Width = 100;
                //grdEmployeeModify.TableElement.RowHeight = 100;
                //grdEmployeeModify.GridElement.RowHeight = 200;
                grdEmployeeModify.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BindDataWithGrid.", ex, "frmEmployeeModify");
                frmobj.ShowDialog();

            }

        }

        private void frmEmployeeModify_Load(object sender, EventArgs e)
        {
            drpempcategory.SelectedIndex = 0;
            drpemployeetype.SelectedIndex = 0;
            drpservicetype.SelectedIndex = 0;
            LoadBranchDesignation();
            BindDataWithGrid();
            
        }

        private void grdEmployeeModify_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                int empID = int.Parse(e.Row.Cells["ID"].Value.ToString());
                if (e.Column.Name == "Emp_Modify")
                {
                    NewEmployee frm = new NewEmployee(empID);
                    frm.ShowDialog();
                }
                else if(e.Column.Name == "btnUploadImg")
                {
                    int emp_ID_ = int.Parse(e.Row.Cells["ID"].Value.ToString());
                    string dpno = e.Row.Cells["DHPNo"].Value.ToString();
                    string nm = e.Row.Cells["Name"].Value.ToString();
                    string nic = e.Row.Cells["CNIC_No"].Value.ToString();
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
                        
                    }
                    #endregion

                    frmEmployeeImagesUpload frm = new frmEmployeeImagesUpload(emp_ID_, dpno, nm, nic, dt);
                    frm.ShowDialog();
                }
                else if(e.Column.Name == "btnViewImage")
                {
                    int emp_ID_ = int.Parse(e.Row.Cells["ID"].Value.ToString());
                    string dpno = e.Row.Cells["DHPNo"].Value.ToString();
                    string nm = e.Row.Cells["Name"].Value.ToString();
                    string nic = e.Row.Cells["CNIC_No"].Value.ToString();
                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","Select"),
                        new SqlParameter("@Emp_ID",emp_ID_)
                    };
                    DataSet dst = Helper.SQLHelper.ExecuteDataset(
                                                              clsMostUseVars.VerifiedImageConnectionstring,
                                                              CommandType.StoredProcedure,
                                                              "dbo.usp_tbl_EmployeeImages",
                                                              prm
                                                              );
                    frm_EmployeeImageViewModify frm = new frm_EmployeeImageViewModify(emp_ID_, dpno, nm, nic, dst);
                    frm.ShowDialog();

                }
                else if(e.Column.Name == "btnReport")
                {
                    int emp_ID_ = int.Parse(e.Row.Cells["ID"].Value.ToString());
                    SqlParameter[] prmt =
                    {
                        new SqlParameter("@Task","Select"),
                        new SqlParameter("@ID",emp_ID_)
                    };
                    DataSet dst = cls_dl_Employee.Employee_Reader(prmt, "[App].[usp_tbl_Employee]");
                    frm_Employee_Report frm = new frm_Employee_Report(dst,"SingleReport");
                    frm.Show();
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdEmployeeModify_CellClick.", ex, "frmEmployeeModify");
                frmobj.ShowDialog();
            }
           
        }

        private void btnBulkReport_Click(object sender, EventArgs e)
        {
            frm_Employee_Report frm = new frm_Employee_Report(ds,"BulkReport");
            frm.Show();
        }
    }
}
