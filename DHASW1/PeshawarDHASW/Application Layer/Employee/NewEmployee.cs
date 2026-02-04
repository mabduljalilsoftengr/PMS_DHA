using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using PeshawarDHASW.Data_Layer.clsEmployee;
using PeshawarDHASW.Application_Layer.CustomDialog;
using System.IO;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Employee
{
    public partial class NewEmployee : Telerik.WinControls.UI.RadForm
    {
        public int Emp_ID { get; set; } = 0;
        public NewEmployee()
        {
            InitializeComponent();
        }
        public NewEmployee(int get_empid)
        {
            Emp_ID = get_empid;
            InitializeComponent();
            btnnewemployeesave.Text = "Update";
        }

        private void btnnewemployeesave_Click(object sender, EventArgs e)
        {
            if(Emp_ID <= 0)
            {
                #region Insertion
                Insert_Employee();
                #endregion
            }
            else
            {
                #region Updation
                Update_Employee(Emp_ID);
                #endregion
            }


        }
        #region Data Table      
        //private DataTable Employee_Bio_Data()
        //{
        //    DataTable Emp_Bio_Data = new DataTable();
        //    try
        //    {
        //        DataTable_column DHPNo = new DataTable_column() { ColmnName = "DHPNo", type = typeof(string) };
        //        DataTable_column Name = new DataTable_column() { ColmnName = "Name", type = typeof(string) };
        //        DataTable_column S_Off = new DataTable_column() { ColmnName = "S_Off", type = typeof(string) };
        //        DataTable_column Designation = new DataTable_column() { ColmnName = "Designation", type = typeof(string) };
        //        DataTable_column BPS = new DataTable_column() { ColmnName = "BPS", type = typeof(string) };
        //        DataTable_column Branch = new DataTable_column() { ColmnName = "Branch", type = typeof(string) };
        //        DataTable_column Marital_Status = new DataTable_column() { ColmnName = "Marital_Status", type = typeof(string) };
        //        DataTable_column Domecile = new DataTable_column() { ColmnName = "Domecile", type = typeof(string) };
        //        DataTable_column Age = new DataTable_column() { ColmnName = "Age", type = typeof(string) };
        //        DataTable_column CNIC_No = new DataTable_column() { ColmnName = "CNIC_No", type = typeof(string) };
        //        DataTable_column Mother_Tongue = new DataTable_column() { ColmnName = "Mother_Tongue", type = typeof(string) };
        //        DataTable_column Date_Of_Employee = new DataTable_column() { ColmnName = "Date_Of_Employee", type = typeof(DateTime) };
        //        DataTable_column Nationality = new DataTable_column() { ColmnName = "Nationality", type = typeof(string) };
        //        DataTable_column Weapon_Held = new DataTable_column() { ColmnName = "Weapon_Held", type = typeof(string) };
        //        DataTable_column Vehicle_MotorCycle = new DataTable_column() { ColmnName = "Vehicle_MotorCycle", type = typeof(string) };
        //        DataTable_column Driving_Licence = new DataTable_column() { ColmnName = "Driving_Licence", type = typeof(string) };
        //        DataTable_column Mobile = new DataTable_column() { ColmnName = "Mobile", type = typeof(string) };
        //        DataTable_column Email = new DataTable_column() { ColmnName = "Email", type = typeof(string) };
        //        DataTable_column Image = new DataTable_column() { ColmnName = "Image", type = typeof(byte[]) };
        //        DataTable_column Moh = new DataTable_column() { ColmnName = "Moh", type = typeof(string) };
        //        DataTable_column Village = new DataTable_column() { ColmnName = "Village", type = typeof(string) };
        //        DataTable_column Teh = new DataTable_column() { ColmnName = "Teh", type = typeof(string) };
        //        DataTable_column Dist = new DataTable_column() { ColmnName = "Dist", type = typeof(string) };
        //        DataTable_column Civ_Qual = new DataTable_column() { ColmnName = "Civ_Qual", type = typeof(string) };
        //        DataTable_column Mill_Qual = new DataTable_column() { ColmnName = "Mill_Qual", type = typeof(string) };
        //        DataTable_column Present_Address = new DataTable_column() { ColmnName = "Present_Address", type = typeof(string) };
        //        DataTable_column Permanent_Address = new DataTable_column() { ColmnName = "Permanent_Address", type = typeof(string) };
        //        List<DataTable_column> colmn = new List<DataTable_column>();
        //        //colmn.Add(DHPNo);
        //        //colmn.Add(Name);
        //        //colmn.Add(S_Off);  colmn.Add(Designation);    colmn.Add(BPS);      colmn.Add(Branch);
        //        colmn.Add(DHPNo);  colmn.Add(Name);           colmn.Add(S_Off);    colmn.Add(Designation);
        //        colmn.Add(BPS);    colmn.Add(Branch);  colmn.Add(Marital_Status);     colmn.Add(Domecile);
        //        colmn.Add(Age);    colmn.Add(CNIC_No);  colmn.Add(Mother_Tongue);     colmn.Add(Date_Of_Employee);
        //        colmn.Add(Nationality);              colmn.Add(Weapon_Held);          colmn.Add(Vehicle_MotorCycle);
        //        colmn.Add(Driving_Licence);          colmn.Add(Mobile);               colmn.Add(Email);
        //        colmn.Add(Image);     colmn.Add(Moh);     colmn.Add(Village);        colmn.Add(Teh);
        //        colmn.Add(Dist);      colmn.Add(Civ_Qual);   colmn.Add(Mill_Qual);   colmn.Add(Present_Address);
        //        colmn.Add(Permanent_Address);
        //        Emp_Bio_Data = clsPluginHelper.ColmnsCreateinDatatable(colmn);
        //        DataRow row = Emp_Bio_Data.NewRow();
        //        row["DHPNo"] = txtDHPNo.Text;      row["Name"] = txt_e_name.Text;     row["S_Off"] = txtSonOf.Text;
        //        row["Designation"] = txtDesignation.Text;     row["BPS"] = txtBPS.Text;     row["Branch"] = lblchallanno.Text;
        //        row["Marital_Status"] = DateTime.Now; row["Domecile"] = "Expire"; row["Age"] = lblchallanno.Text;
        //        row["CNIC_No"] = DateTime.Now; row["Mother_Tongue"] = "Expire"; row["Date_Of_Employee"] = lblchallanno.Text;

        //        row["Nationality"] = DateTime.Now; row["Weapon_Held"] = "Expire"; row["Vehicle_MotorCycle"] = lblchallanno.Text;
        //        row["Driving_Licence"] = DateTime.Now; row["Mobile"] = "Expire"; row["Email"] = lblchallanno.Text;
        //        row["Image"] = DateTime.Now; row["Moh"] = "Expire"; row["Village"] = lblchallanno.Text;
        //        row["Teh"] = DateTime.Now; row["Dist"] = "Expire"; row["Civ_Qual"] = lblchallanno.Text;

        //        row["Mill_Qual"] = DateTime.Now; row["Present_Address"] = "Expire"; row["Permanent_Address"] = lblchallanno.Text;
        //        Emp_Bio_Data.Rows.Add(row);
        //    }
        //    catch (Exception ex)
        //    {
        //        frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on ChallanRecieve.", ex, "frmTransferVerification");
        //        frmobj.ShowDialog();
        //    }
        //    return Emp_Bio_Data;
        //}
        #endregion
        private void Insert_Employee()
        {
            try
            {
                int rslt_ = 0, rslt = 0;
                string hlt = chkhealth.CheckState == CheckState.Checked ? "Health Insurance" : "";
                string lif = chklife.CheckState == CheckState.Checked ? "Group Life Insurance" : "";
                string life = lif == "Group Life Insurance" ? ", " + lif : lif;
                string drpinsurancetype = hlt + life;

                SqlParameter param_out_EmpID = new SqlParameter()
                {
                    ParameterName = "@EmpID_Out",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                SqlParameter[] parameters =
                {
                      new SqlParameter("@Task", "Insert_EmpBio"),
                      new SqlParameter("@DHPNo",txtDHPNo.Text),
                      new SqlParameter("@Name",txt_e_name.Text),
                      new SqlParameter("@S_Off",txtSonOf.Text),
                      new SqlParameter("@SpouseName",txtspousename.Text),
                      new SqlParameter("@Designation",drpDesignation.SelectedItem.ToString()),
                      new SqlParameter("@BPS",txtBPS.Text),
                      new SqlParameter("@Branch",drpBranch.SelectedItem.ToString()),
                      new SqlParameter("@Marital_Status",drpMaritalStatus.SelectedItem.ToString()),
                      new SqlParameter("@Domecile",txt_e_domicile.Text),
                      new SqlParameter("@Age",txtAge.Text),
                      new SqlParameter("@CNIC_No",txt_e_nic.Text),
                      new SqlParameter("@Mother_Tongue",txtMotherTongue.Text),
                      new SqlParameter("@Date_Of_Employee",dtpDateOfEmployement.Value.Date),
                      new SqlParameter("@Nationality",txtNationality.Text),
                      new SqlParameter("@EmpCategory",drpempcategory.SelectedItem.ToString()),
                      new SqlParameter("@Weapon_Held",txtWeapon.Text),
                      new SqlParameter("@Vehicle_MotorCycle",txtVehicle_Motor.Text),
                      new SqlParameter("@Driving_Licence",txtDrivingLicence.Text),
                      new SqlParameter("@Mobile",txt_e_mobile.Text),
                      new SqlParameter("@Email",txt_e_email.Text),
                      new SqlParameter("@Image",Image_To_Byte()),
                      new SqlParameter("@Moh",txtMoh.Text),
                      new SqlParameter("@Village",txtVillage.Text),
                      new SqlParameter("@Teh",txtTeh.Text),
                      new SqlParameter("@Dist",txtDist.Text),
                      new SqlParameter("@Civ_Qual",txtCiv_Qualification.Text),
                      new SqlParameter("@Mill_Qual",txt_miltry_Qualification.Text),
                      new SqlParameter("@Present_Address",txtPresentAddress.Text),
                      new SqlParameter("@Permanent_Address",txt_permentaddress.Text),
                      new SqlParameter("@Office_Location",txtlocation.SelectedItem.ToString()),
                      new SqlParameter("@Gender",drpGender.SelectedItem.ToString()),
                      new SqlParameter("@DateofEnd",dtpenddate.Value.Date),
                      new SqlParameter("@Religion",drprelegion.SelectedItem.ToString()),
                      new SqlParameter("@DOB",dtpdob.Value.Date),
                      new SqlParameter("@Service_Type",drpservicetype.SelectedItem.ToString()),
                      new SqlParameter("@Employee_Type",drpemployeetype.SelectedItem.ToString()),
                      new SqlParameter("@Insurance_Type",drpinsurancetype),
                      new SqlParameter("@Employee_Status",drpemployeestatus.SelectedItem.ToString()),
                      param_out_EmpID,
                };
                SqlCommand result;
                result = Data_Layer.clsEmployee.cls_dl_Employee.Employee_PersonalInfo_outparameter(parameters);
                if (result.Parameters.Count != 0)
                {
                    //if ( 0 == 0)
                    //{

                    //}
                    //else
                    //{
                    int EmpNewID = int.Parse(result.Parameters["@EmpID_Out"].Value.ToString());
                    #region Next of Kin and Children Insertion
                    if(grd_NokDetail.RowCount > 0)
                    {
                        foreach (GridViewRowInfo row in grd_NokDetail.Rows)
                        {
                            string NameofKin = row.Cells["NameofKin"].Value.ToString();
                            string Relation = row.Cells["Relation"].Value.ToString();
                            string NIC_NICOP = row.Cells["NIC_NICOP"].Value.ToString();
                            string Address = row.Cells["Address"].Value.ToString();
                            string MobileNo = row.Cells["MobileNo"].Value.ToString();
                            string Nok_Status = row.Cells["Nok_Status"].Value.ToString();
                            SqlParameter[] prmtr =
                            {
                            new SqlParameter("@Task","Insert_EmpNextOfKin"),
                            new SqlParameter("@EmpID",EmpNewID),
                            new SqlParameter("@NameofKin",NameofKin),
                            new SqlParameter("@Relation",Relation),
                            new SqlParameter("@NIC_NICOP",NIC_NICOP),
                            new SqlParameter("@Address",Address),
                            new SqlParameter("@MobileNo",MobileNo),
                            new SqlParameter("@Nok_Status",Nok_Status)
                          };
                             rslt_ = cls_dl_Employee.Employee_NonQuery(prmtr, "[App].[usp_tbl_Employee]");

                        }
                    }
                    
                    #endregion

                    #region Previous Employement Insertion
                    if(grd_PreviousEmp.RowCount > 0)
                    {
                        foreach (GridViewRowInfo row1 in grd_PreviousEmp.Rows)
                        {
                            string Organization = row1.Cells["Organization"].Value.ToString();
                            string Designation = row1.Cells["Designation"].Value.ToString();
                            DateTime FromDate = Convert.ToDateTime(row1.Cells["FromDate"].Value.ToString());
                            DateTime ToDate = Convert.ToDateTime(row1.Cells["ToDate"].Value.ToString());

                            SqlParameter[] prmtr =
                            {
                            new SqlParameter("@Task","Insert_EmpPrevEmployement"),
                            new SqlParameter("@EmpID",EmpNewID),
                            new SqlParameter("@Organization",Organization),
                            new SqlParameter("@Designation",Designation),
                            new SqlParameter("@FromDate",FromDate),
                            new SqlParameter("@ToDate",ToDate)
                            };
                             rslt = cls_dl_Employee.Employee_NonQuery(prmtr, "[App].[usp_tbl_Employee]");

                        }
                    }
                   
                    #endregion
                    if(rslt > 0 || rslt_ > 0)
                    {
                        MessageBox.Show("Insertion Successfull.");
                    }
                }
               
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Insert_Employee.", ex, "NewEmployee");
                frmobj.ShowDialog();

            }
        }
        private Byte[] Image_To_Byte()
        {
            MemoryStream ms = new MemoryStream();
            pcbEmployee.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
            Byte[] Image = ms.ToArray();
            return Image;
        }
        private void Update_Employee(int getemp)
        {
            try
            {
                string hlt = chkhealth.CheckState == CheckState.Checked ? "Health Insurance" : "";
                string lif = chklife.CheckState == CheckState.Checked ? "Group Life Insurance" : "";
                string life = lif == "Group Life Insurance" ? ", " + lif : lif;
                string drpinsurancetype = hlt + life;
                #region Updation
                SqlParameter[] parameters =
                {
                   new SqlParameter("@Task", "Update"),
                   new SqlParameter("@DHPNo",txtDHPNo.Text),
                   new SqlParameter("@Name",txt_e_name.Text),
                   new SqlParameter("@S_Off",txtSonOf.Text),
                   new SqlParameter("@SpouseName",txtspousename.Text),
                   new SqlParameter("@Designation",drpDesignation.SelectedItem.ToString()),
                   new SqlParameter("@BPS",txtBPS.Text),
                   new SqlParameter("@Branch",drpBranch.SelectedItem.ToString()),
                   new SqlParameter("@Marital_Status",drpMaritalStatus.SelectedItem.ToString()),
                   new SqlParameter("@Domecile",txt_e_domicile.Text),
                   new SqlParameter("@Age",txtAge.Text),
                   new SqlParameter("@CNIC_No",txt_e_nic.Text),
                   new SqlParameter("@Mother_Tongue",txtMotherTongue.Text),
                   new SqlParameter("@Date_Of_Employee",dtpDateOfEmployement.Value.Date),
                   new SqlParameter("@Nationality",txtNationality.Text),
                   new SqlParameter("@EmpCategory",drpempcategory.SelectedItem.ToString()),
                   new SqlParameter("@Weapon_Held",txtWeapon.Text),
                   new SqlParameter("@Vehicle_MotorCycle",txtVehicle_Motor.Text),
                   new SqlParameter("@Driving_Licence",txtDrivingLicence.Text),
                   new SqlParameter("@Mobile",txt_e_mobile.Text),
                   new SqlParameter("@Email",txt_e_email.Text),
                   new SqlParameter("@Image",Image_To_Byte()),
                   new SqlParameter("@Moh",txtMoh.Text),
                   new SqlParameter("@Village",txtVillage.Text),
                   new SqlParameter("@Teh",txtTeh.Text),
                   new SqlParameter("@Dist",txtDist.Text),
                   new SqlParameter("@Civ_Qual",txtCiv_Qualification.Text),
                   new SqlParameter("@Mill_Qual",txt_miltry_Qualification.Text),
                   new SqlParameter("@Present_Address",txtPresentAddress.Text),
                   new SqlParameter("@Permanent_Address",txt_permentaddress.Text),
                   new SqlParameter("@Office_Location",txtlocation.SelectedItem.ToString()),
                   new SqlParameter("@Gender",drpGender.SelectedItem.ToString()),
                   new SqlParameter("@DateofEnd",dtpenddate.Value.Date),
                   new SqlParameter("@Religion",drprelegion.SelectedItem.ToString()),
                   new SqlParameter("@DOB",dtpdob.Value.Date),
                   new SqlParameter("@Service_Type",drpservicetype.SelectedItem.ToString()),
                   new SqlParameter("@Employee_Type",drpemployeetype.SelectedItem.ToString()),
                   new SqlParameter("@Insurance_Type",drpinsurancetype),
                   new SqlParameter("@Employee_Status",drpemployeestatus.SelectedItem.ToString()),
                   new SqlParameter("@ID",Emp_ID)
                };
                int result = Data_Layer.clsEmployee.cls_dl_Employee.Employee_NonQuery(parameters, "App.usp_tbl_Employee");
                if (result > 0)
                {
                    MessageBox.Show("Updation Successful.");
                    this.Close();
                }
                else
                {
                    throw new Exception("Error Occur in data New Employee");
                }
                #endregion

            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Update_Employee.", ex, "NewEmployee");
                frmobj.ShowDialog();
            }
        }

        private void NewEmployee_Load(object sender, EventArgs e)
        {
            if (Emp_ID != 0)
            {
                LoadBranchDesignation();
                LoadEmployeeData(Emp_ID);
            }
            else
            {
                LoadBranchDesignation();
            }
        }
        ////private void ChallanHeaderDetailsBinding(RadDropDownList drp_lst)
        ////{
        ////    drp_lst.Items.Clear();
        ////    RadListDataItem select = new RadListDataItem();
        ////    SqlParameter[] prm =
        ////    {
        ////        new SqlParameter("@Task","fillChallanHeaderDetail"),
        ////        new SqlParameter("@FileMapKey", cmbChallanHeader.SelectedValue),
        ////        new SqlParameter("@PlotSizeID", cmbPlotSize.SelectedValue)
        ////    };
        ////    foreach (DataRow row in cls_dl_Challan.Challan_Reader(prm).Tables[0].Rows)
        ////    {
        ////        RadListDataItem dataItem = new RadListDataItem();
        ////        dataItem.Value = row["ParDetID"].ToString();
        ////        dataItem.Text = row["ChallanParticlar"].ToString();
        ////        dataItem.Tag = row["Amount"].ToString();
        ////        drp_lst.Items.Add(dataItem);
        ////    }
        ////    drp_lst.SelectedIndex = -1;
        ////}
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
        private void LoadEmployeeData(int getemp)
        {
            try
            {
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","Select_Emp_Detail"),
                    new SqlParameter("@ID",getemp)
                };
                DataSet ds = new DataSet();
                ds = cls_dl_Employee.Employee_Reader(prm, "App.usp_tbl_Employee");
                txtDHPNo.Text = ds.Tables[0].Rows[0]["DHPNo"].ToString();
                txt_e_name.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                txtSonOf.Text = ds.Tables[0].Rows[0]["S_Off"].ToString();
                
                txtspousename.Text = ds.Tables[0].Rows[0]["SpouseName"].ToString();
                drpemployeestatus.SelectedIndex = drpemployeestatus.FindString(ds.Tables[0].Rows[0]["Employee_Status"].ToString());
                drpDesignation.SelectedIndex = drpDesignation.FindString(ds.Tables[0].Rows[0]["Designation"].ToString());//ds.Tables[0].Rows[0]["Designation"].ToString();
                txtBPS.Text = ds.Tables[0].Rows[0]["BPS"].ToString();
                drpBranch.SelectedIndex = drpBranch.FindString(ds.Tables[0].Rows[0]["Branch"].ToString());
                drpMaritalStatus.SelectedIndex = drpMaritalStatus.FindString(ds.Tables[0].Rows[0]["Marital_Status"].ToString());
                txt_e_domicile.Text = ds.Tables[0].Rows[0]["Domecile"].ToString();
                txtAge.Text = ds.Tables[0].Rows[0]["Age"].ToString();
                txt_e_nic.Text = ds.Tables[0].Rows[0]["CNIC_No"].ToString();
                txtMotherTongue.Text = ds.Tables[0].Rows[0]["Mother_Tongue"].ToString(); 
                dtpDateOfEmployement.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["Date_Of_Employee"].ToString());
                txtNationality.Text = ds.Tables[0].Rows[0]["Nationality"].ToString();

                drpempcategory.SelectedIndex = drpempcategory.FindString(ds.Tables[0].Rows[0]["EmpCategory"].ToString());
                txtWeapon.Text = ds.Tables[0].Rows[0]["Weapon_Held"].ToString();
                txtVehicle_Motor.Text = ds.Tables[0].Rows[0]["Vehicle_MotorCycle"].ToString();
                txtDrivingLicence.Text = ds.Tables[0].Rows[0]["Driving_Licence"].ToString();
                txt_e_mobile.Text = ds.Tables[0].Rows[0]["Mobile"].ToString();
                txtlocation.SelectedIndex = txtlocation.FindString(ds.Tables[0].Rows[0]["Office_Location"].ToString());
                drpGender.SelectedIndex = drpGender.FindString(ds.Tables[0].Rows[0]["Gender"].ToString());
                dtpenddate.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateofEnd"].ToString());
                drprelegion.SelectedIndex = drprelegion.FindString(ds.Tables[0].Rows[0]["Religion"].ToString());
                dtpdob.Value = Convert.ToDateTime(ds.Tables[0].Rows[0]["DoB"].ToString());
                drpservicetype.SelectedIndex = drpservicetype.FindString(ds.Tables[0].Rows[0]["Service_Type"].ToString());
                drpemployeetype.SelectedIndex = drpemployeetype.FindString(ds.Tables[0].Rows[0]["Employee_Type"].ToString());

                string instpe = ds.Tables[0].Rows[0]["Insurance_Type"].ToString();
                if(instpe.Contains("Group Life Insurance") && instpe.Contains("Health Insurance"))
                {
                    chkhealth.CheckState = CheckState.Checked;
                    chklife.CheckState = CheckState.Checked;
                }
                else if(instpe.Contains("Group Life Insurance") && !instpe.Contains("Health Insurance"))
                {
                    chklife.CheckState = CheckState.Checked;
                }
                else if (!instpe.Contains("Group Life Insurance") && instpe.Contains("Health Insurance"))
                {
                    chkhealth.CheckState = CheckState.Checked;
                }

                txtCiv_Qualification.Text = ds.Tables[0].Rows[0]["Civ_Qual"].ToString();
                txt_miltry_Qualification.Text = ds.Tables[0].Rows[0]["Mill_Qual"].ToString();
                txtMoh.Text = ds.Tables[0].Rows[0]["Moh"].ToString();
                txtVillage.Text = ds.Tables[0].Rows[0]["Village"].ToString();
                txtTeh.Text = ds.Tables[0].Rows[0]["Teh"].ToString();
                txtDist.Text = ds.Tables[0].Rows[0]["Dist"].ToString();
                txtPresentAddress.Text = ds.Tables[0].Rows[0]["Present_Address"].ToString();
                txt_permentaddress.Text = ds.Tables[0].Rows[0]["Permanent_Address"].ToString();
                txt_e_email.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                pcbEmployee.Image = ImageRetrive(ds.Tables[0].Rows[0]["Image"], "Image");

                BindColumnwithGrid();

                grd_NokDetail.DataSource = ds.Tables[1].DefaultView;
                grd_PreviousEmp.DataSource = ds.Tables[2].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on LoadEmployeeData.", ex, "NewEmployee");
                frmobj.ShowDialog();
            }
        }
        private Image ImageRetrive(object table, string fieldName)
        {
            byte[] imgData = (byte[])table;
            MemoryStream ms = new MemoryStream(imgData);
            ms.Position = 0;
            return Image.FromStream(ms);
        }

        private void BindColumnwithGrid()
        {
            if (!grd_NokDetail.MasterView.ViewTemplate.Columns.Contains("btn_nextofkinmodify"))
             { 
                GridViewCommandColumn nextofkin = new GridViewCommandColumn();
                nextofkin.Name = "btn_nextofkinmodify";
                nextofkin.UseDefaultText = true;
                nextofkin.FieldName = "btn_nextofkinmodify";
                nextofkin.DefaultText = "Modify";
                nextofkin.Width = 80;
                nextofkin.TextAlignment = ContentAlignment.MiddleCenter;
                nextofkin.HeaderText = "Modify";
                grd_NokDetail.MasterTemplate.Columns.Add(nextofkin);
             }
            if (!grd_NokDetail.MasterView.ViewTemplate.Columns.Contains("btn_nextofkinAdd"))
            {
                GridViewCommandColumn nextofkin = new GridViewCommandColumn();
                nextofkin.Name = "btn_nextofkinAdd";
                nextofkin.UseDefaultText = true;
                nextofkin.FieldName = "btn_nextofkinAdd";
                nextofkin.DefaultText = "Add";
                nextofkin.Width = 80;
                nextofkin.TextAlignment = ContentAlignment.MiddleCenter;
                nextofkin.HeaderText = "Add";
                grd_NokDetail.MasterTemplate.Columns.Add(nextofkin);
            }
            if (!grd_PreviousEmp.MasterView.ViewTemplate.Columns.Contains("btn_PreEmpModify"))
            {
                GridViewCommandColumn premp = new GridViewCommandColumn();
                premp.Name = "btn_PreEmpModify";
                premp.UseDefaultText = true;
                premp.FieldName = "btn_PreEmpModify";
                premp.DefaultText = "Modify";
                premp.Width = 80;
                premp.TextAlignment = ContentAlignment.MiddleCenter;
                premp.HeaderText = "Modify";
                grd_PreviousEmp.MasterTemplate.Columns.Add(premp);
            }
            if (!grd_PreviousEmp.MasterView.ViewTemplate.Columns.Contains("btn_PreEmpAdd"))
            {
                GridViewCommandColumn premp = new GridViewCommandColumn();
                premp.Name = "btn_PreEmpAdd";
                premp.UseDefaultText = true;
                premp.FieldName = "btn_PreEmpAdd";
                premp.DefaultText = "Add";
                premp.Width = 80;
                premp.TextAlignment = ContentAlignment.MiddleCenter;
                premp.HeaderText = "Add";
                grd_PreviousEmp.MasterTemplate.Columns.Add(premp);
            }

        }
        private void btnBrowseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter =
                @"Images         (*.BMP;*.JPEG;*.GIF,*.PNG,*.TIFF)|*.BMP;*.JPG;*.GIF;*.PNG;*.TIFF| All files (.)|*.*";
            openFileDialog1.Title = "Select Photos";
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                pcbEmployee.Image = new Bitmap(openFileDialog1.FileName);
            }

        }

        private void radButton1_Click(object sender, EventArgs e)
        {

        }

        private void grd_NokDetail_CellClick(object sender, GridViewCellEventArgs e)
        {
            if(Emp_ID > 0)
            {
                if(e.Column.Name == "btn_nextofkinmodify")
                {
                    
                        int nokid = int.Parse(e.Row.Cells["NokID"].Value.ToString());
                        string name = e.Row.Cells["NameofKin"].Value.ToString();
                        string relatn = e.Row.Cells["Relation"].Value.ToString();
                        string nic = e.Row.Cells["NIC_NICOP"].Value.ToString();
                        string adrs = e.Row.Cells["Address"].Value.ToString();
                        string mblno = e.Row.Cells["MobileNo"].Value.ToString();
                        string nokstatus = e.Row.Cells["Nok_Status"].Value.ToString();
                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","Modify_NOK"),
                        new SqlParameter("@NameofKin",name),
                        new SqlParameter("@Relation",relatn),
                        new SqlParameter("@NIC_NICOP",nic),
                        new SqlParameter("@Address",adrs),
                        new SqlParameter("@MobileNo",mblno),
                        new SqlParameter("@Nok_Status",nokstatus),
                        new SqlParameter("@NokID",nokid)
                    };
                    int rslt = cls_dl_Employee.Employee_NonQuery(prm, "[App].[usp_tbl_Employee]");
                    MessageBox.Show("Updation Successful.");
                    NewEmployee_Load(sender,e);
                }
                else if(e.Column.Name == "btn_nextofkinAdd")
                {
                    //int nokid = int.Parse(e.Row.Cells["NokID"].Value.ToString());
                    string name = e.Row.Cells["NameofKin"].Value.ToString();
                    string relatn = e.Row.Cells["Relation"].Value.ToString();
                    string nic = e.Row.Cells["NIC_NICOP"].Value.ToString();
                    string adrs = e.Row.Cells["Address"].Value.ToString();
                    string mblno = e.Row.Cells["MobileNo"].Value.ToString();
                    string nokstatus = e.Row.Cells["Nok_Status"].Value.ToString();
                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","Add_NOK"),
                        new SqlParameter("@NameofKin",name),
                        new SqlParameter("@Relation",relatn),
                        new SqlParameter("@NIC_NICOP",nic),
                        new SqlParameter("@Address",adrs),
                        new SqlParameter("@MobileNo",mblno),
                        new SqlParameter("@Nok_Status",nokstatus),
                        new SqlParameter("@ID",Emp_ID)
                    };
                    int rslt = cls_dl_Employee.Employee_NonQuery(prm, "[App].[usp_tbl_Employee]");
                    MessageBox.Show("Insertion Successful.");
                    NewEmployee_Load(sender, e);
                }
            }
        }

        private void grd_PreviousEmp_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (Emp_ID > 0)
            {
                if(e.Column.Name == "btn_PreEmpModify")
                {
                    int PEmp_ID = int.Parse(e.Row.Cells["PEmp_ID"].Value.ToString());
                    string Organization = e.Row.Cells["Organization"].Value.ToString();
                    string Designation = e.Row.Cells["Designation"].Value.ToString();
                    DateTime FromDate = Convert.ToDateTime(e.Row.Cells["FromDate"].Value.ToString());
                    DateTime ToDate = Convert.ToDateTime(e.Row.Cells["ToDate"].Value.ToString());
                    
                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","Modify_PrvEmp"),
                        new SqlParameter("@Organization",Organization),
                        new SqlParameter("@Designation",Designation),
                        new SqlParameter("@FromDate",FromDate),
                        new SqlParameter("@ToDate",ToDate),
                        new SqlParameter("@PEmp_ID",PEmp_ID)
                    };
                    int rslt = cls_dl_Employee.Employee_NonQuery(prm, "[App].[usp_tbl_Employee]");
                    MessageBox.Show("Updation Successful.");
                    NewEmployee_Load(sender, e);
                }
                else if (e.Column.Name == "btn_PreEmpAdd")
                {
                    string Organization = e.Row.Cells["Organization"].Value.ToString();
                    string Designation = e.Row.Cells["Designation"].Value.ToString();
                    DateTime FromDate = Convert.ToDateTime(e.Row.Cells["FromDate"].Value.ToString());
                    DateTime ToDate = Convert.ToDateTime(e.Row.Cells["ToDate"].Value.ToString());

                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","Add_PrvEmp"),
                        new SqlParameter("@Organization",Organization),
                        new SqlParameter("@Designation",Designation),
                        new SqlParameter("@FromDate",FromDate),
                        new SqlParameter("@ToDate",ToDate),
                        new SqlParameter("@ID",Emp_ID)
                    };
                    int rslt = cls_dl_Employee.Employee_NonQuery(prm, "[App].[usp_tbl_Employee]");
                    MessageBox.Show("Insertion Successful.");
                    NewEmployee_Load(sender, e);
                }
            }
        }
    }
}
