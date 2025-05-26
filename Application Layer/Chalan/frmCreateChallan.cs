using PeshawarDHASW.Data_Layer.clsChallan;
using PeshawarDHASW.Data_Layer.clsStampDuty;
using PeshawarDHASW.Data_Layer.Installment;
using PeshawarDHASW.Data_Layer.NDC;
using PeshawarDHASW.Report.Challan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Chalan
{
    public partial class frmCreateChallan : Telerik.WinControls.UI.RadForm
    {

        public frmCreateChallan()
        {
            InitializeComponent();
        }

        private DataSet DueInformation { get; set; }
        private DataSet SellerBuyerInfo { get; set; }
        private string FileNo { get; set; }
        private bool AutoGenerateChallan { get; set; } = true;
        public bool BuyerChallanGeneratefromNDC { get; set; }
        public string Buyer_Name { get; set; }
        public string Buyer_CNIC { get; set; }
        public frmCreateChallan(bool GenerateChallanforBuyer, string File_No, string BuyerName, string BuyerCNIC)
        {
            InitializeComponent();
            BuyerChallanGeneratefromNDC = GenerateChallanforBuyer;
            FileNo = File_No;
            Buyer_Name = BuyerName;
            Buyer_CNIC = BuyerCNIC;
        }

        public frmCreateChallan(string FileNo_Possession,bool PossessionStatus)
        {
            InitializeComponent();
            txtfileno.Text = FileNo_Possession;
        }
        public frmCreateChallan(string ChallanID)
        {
            InitializeComponent();
            lblChalanID.Text = ChallanID;
        }//lblChalanID

        #region File No Change to Plot Size
        private string PlotSizeDetect(string File_No)
        {
            string FileNo = File_No.ToUpper();
            if (FileNo.Contains("OLO/A/RES") || FileNo.Contains("A/RES"))
            {
                return "2 Kanal";
                //  ddlplotbuisinesstype.SelectedItem.Text = "Residential";

            }
            else if (FileNo.Contains("OLO/B/RES") || FileNo.Contains("B/RES"))
            {
                return "1 Kanal";
                // ddlplotbuisinesstype.SelectedItem.Text = "Residential";
            }
            else if (FileNo.Contains("OLO/C/RES") || FileNo.Contains("C/RES"))
            {
                return "10 Marla";
                // ddlplotbuisinesstype.SelectedItem.Text = "Residential";
            }
            else if (FileNo.Contains("OLO/D/RES"))
            {
                return "8 Marla";
                // ddlplotbuisinesstype.SelectedItem.Text = "Residential";
            }
            else if (FileNo.Contains("OLO/G/COM"))
            {
                return "8 Marla Com";
                //ddlplotbuisinesstype.SelectedItem.Text = "Commerical";
            }
            else if (FileNo.Contains("OLO/E/RES"))
            {
                return "5 Marla";
                //ddlplotbuisinesstype.SelectedItem.Text = "Residential";
            }
            else if (FileNo.Contains("OLO/H/COM"))
            {
                return "4 Marla Com";
                //ddlplotbuisinesstype.SelectedItem.Text = "Commerical";

            }
            else
            {
                return "Invalid PlotSize Select.";
                // btnSaveandprinttheschedule.Enabled = false;
                MessageBox.Show("Select a Valid Plot Size and Category According to File No.");
            }
        }
        #endregion

        private void GenerateSellerChallan()
        {

            if (DueInformation.Tables.Count > 0)
            {

                //decimal DueAmount = decimal.Parse(DueInformation.Tables[0].Rows[0]["RemaingDueAmount"].ToString());
                // decimal DueSurcharge = decimal.Parse(DueInformation.Tables[0].Rows[0]["RemaingSurcharge"].ToString());


                //Step 1 Select Type
                cmbChallanType.Focus();
                cmbChallanType.Text = "Installment";//0
                txtfileno.Text = FileNo;
                cmbPlotSize.Text = PlotSizeDetect(FileNo);
                //Search File Info
                btnFind_Click(null, null);

                // Surcharge = 12


                DataTable dt = sampleDataTable.Copy();
                sampleDataTable.Clear();
                DataRow sampleDataRow;

                foreach (DataRow checkeditem in dt.Rows)
                {
                    sampleDataRow = sampleDataTable.NewRow();
                    sampleDataRow["ID"] = 0;
                    sampleDataRow["SerialNo"] = sampleDataTable.Rows.Count + 1;
                    sampleDataRow["Particulars"] = "Installment";
                    sampleDataRow["Amount"] = "12000";
                    sampleDataTable.Rows.Add(sampleDataRow);
                }

                dgvChallanDetails.DataSource = sampleDataTable.DefaultView;

                //cmbChallanType.SelectedText = "Other";
                //cmbChallanHeader.sel
            }
            else
            {
                MessageBox.Show("Test");
            }
        }

        DataTable sampleDataTable = new DataTable();
        private void frmCreateChallan_Load(object sender, EventArgs e)
        {

            ChallanTypeBinding(cmbChallanType);
            ChallanHeaderBinding(cmbChallanHeader);
            PlotSizeBinding(cmbPlotSize);           
            OwnerCategoryBinding(cmbOwnerCategory);

            #region Sample DataTable Column Adding
            sampleDataTable.Columns.Add("ID", typeof(string));
            sampleDataTable.Columns.Add("SerialNo", typeof(string));
            sampleDataTable.Columns.Add("Particulars", typeof(string));
            sampleDataTable.Columns.Add("Amount", typeof(float));
            sampleDataTable.Columns.Add("isReadOnly", typeof(string));
            #endregion

            #region Add Button to Grid for dgvChallanDetails
            GridViewCommandColumn familydetial = new GridViewCommandColumn();
            familydetial.Name = "DeleteRow";
            familydetial.UseDefaultText = true;
            familydetial.FieldName = "DeleteRow";
            familydetial.DefaultText = "x";
            familydetial.HeaderText = "Delete items";
            familydetial.Width = 100;
            familydetial.TextAlignment = ContentAlignment.MiddleCenter;
            dgvChallanDetails.MasterTemplate.Columns.Add(familydetial);
            #endregion

            DisableControls(radGroupBox1);
            DisableControls(radGroupBox3);
            ChallanDate.Value = DateTime.Now.Date;
            txtChallanNo.Enabled = true;
            cmbPropertyDealer.Enabled = false;
            txtChallanNo.Focus();

            if (!string.IsNullOrEmpty(lblChalanID.Text))
            {
                FillAllField(lblChalanID.Text);
            }

            #region Get Max Challan No
            SqlParameter[] prm1 =
            {
                new SqlParameter("@Task","GetMaxChallanNo"),
            };
            DataSet ds1 = cls_dl_Challan.Challan_Reader(prm1);
            if (ds1.Tables.Count > 0 && string.IsNullOrEmpty(lblChalanID.Text))
            {
                if (ds1.Tables[0].Rows.Count > 0)
                {
                    txtChallanNo.Text = ds1.Tables[0].Rows[0][0].ToString();
                }
                else
                {
                    txtChallanNo.ReadOnly = false;
                }
            }
            #endregion

            //if (AutoGenerateChallan == true)
            //{
            //    GenerateSellerChallan();
            //}
            if (BuyerChallanGeneratefromNDC == true)
            {
                txtfileno.Text = FileNo;
                txtfileno.ReadOnly = true;
                txtname.ReadOnly = true;
                txtCNICMask.ReadOnly = true;
                btnFind_Click(null, null);
                ChallanDate.Value = DateTime.Now;
            }
        }

        #region Find Challan Information
        private void FillAllField(string ChallanNo)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetDetailForEdit"),
                new SqlParameter("@ChallanID",lblChalanID.Text.Trim()),
            };
            DataSet ds = cls_dl_Challan.Challan_Reader(prm);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count == 0)
                    return;

                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtfileno.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                    txtfileno.Focus();
                    txtname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    cmbOwnerCategory.SelectedValue = ds.Tables[0].Rows[0]["OwnerCategoryID"].ToString();
                    cmbPlotSize.SelectedText = ds.Tables[0].Rows[0]["PlotSize"].ToString();
                    cmbPlotSize.SelectedIndex = cmbPlotSize.Items.IndexOf(ds.Tables[0].Rows[0]["PlotSize"].ToString());
                    lblMemberShipID.Text = ds.Tables[0].Rows[0]["MemberID"].ToString();
                    lblFileMapKey.Text = ds.Tables[0].Rows[0]["FileMapKey"].ToString();
                    txtChallanNo.Text = ds.Tables[0].Rows[0]["ChalanNo"].ToString();
                    txtRemark.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                    lbllastFileName.Text = txtfileno.Text.Trim();
                    txtCNICMask.Text = Helper.clsPluginHelper.DbNullIfNullOrEmpty(ds.Tables[0].Rows[0]["CNIC"].ToString()) == null ? null : ds.Tables[0].Rows[0]["CNIC"].ToString();

                    cmbChallanType.SelectedText = ds.Tables[0].Rows[0]["ChallanType"].ToString();
                    cmbChallanType.SelectedIndex = cmbPlotSize.Items.IndexOf(ds.Tables[0].Rows[0]["ChallanType"].ToString());
                    ChallanDate.Text = ds.Tables[0].Rows[0]["ClearDate"].ToString();
                    EnableControls(radGroupBox1);
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        sampleDataTable = ds.Tables[1];
                        dgvChallanDetails.DataSource = sampleDataTable.DefaultView;
                    }
                }
            }
        }
        #endregion

        #region  Plot Size  Binding Loading
        private void PlotSizeBinding(RadDropDownList drp_lst)
        {
            RadListDataItem select = new RadListDataItem();
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","fillPlotSize"),
            };
            foreach (DataRow row in cls_dl_Challan.Challan_Reader(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ID"].ToString();
                dataItem.Text = row["PlotSize"].ToString();
                drp_lst.Items.Add(dataItem);
            }
            drp_lst.SelectedIndex = -1;
        }

        #endregion

        #region OwnerCategoryBinding
        private void OwnerCategoryBinding(RadDropDownList drp_lst)
        {
            RadListDataItem select = new RadListDataItem();
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","fillOwnerCategory"),
            };
            foreach (DataRow row in cls_dl_Challan.Challan_Reader(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["OCID"].ToString();
                dataItem.Text = row["Category_Name"].ToString();
                drp_lst.Items.Add(dataItem);
            }
            drp_lst.SelectedIndex = -1;
        }
        #endregion

        #region Challan Type Binding 
        private void ChallanTypeBinding(RadDropDownList drp_lst)
        {
            RadListDataItem select = new RadListDataItem();
            select.Value = 0;
            select.Text = "-- Select Challan Type --";
            drp_lst.Items.Add(select);
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","select"),
            };
            foreach (DataRow row in cls_dl_Challan.Challan_Reader(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ChallanTypeID"].ToString();
                dataItem.Text = row["ChallanType"].ToString();
                dataItem.Tag = row["FixedFee"].ToString();
                drp_lst.Items.Add(dataItem);
            }
            drp_lst.SelectedIndex = -1;
        }

        #endregion

        #region Challan Header Binding
        private void ChallanHeaderBinding(RadDropDownList drp_lst)
        {
            RadListDataItem select = new RadListDataItem();
            drp_lst.Items.Clear();
            //select.Value = 0;
            //select.Text = "-- Select Challan Type --";
            //drp_lst.Items.Add(select);
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","fillChallanHeader"),
            };
            foreach (DataRow row in cls_dl_Challan.Challan_Reader(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ChlnParHeadID"].ToString();
                dataItem.Text = row["ParticularName"].ToString();
                drp_lst.Items.Add(dataItem);
            }
            drp_lst.SelectedIndex = -1;
        }
        #endregion

        #region Challan Header Detail Binding Parm( PLotSize, Header Value)
        private void ChallanHeaderDetailsBinding(RadDropDownList drp_lst)
        {
            drp_lst.Items.Clear();
            RadListDataItem select = new RadListDataItem();
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","fillChallanHeaderDetail"),
                new SqlParameter("@FileMapKey", cmbChallanHeader.SelectedValue),
                new SqlParameter("@PlotSizeID", cmbPlotSize.SelectedValue)
            };
            foreach (DataRow row in cls_dl_Challan.Challan_Reader(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ParDetID"].ToString();
                dataItem.Text = row["ChallanParticlar"].ToString();
                dataItem.Tag = row["Amount"].ToString();
                drp_lst.Items.Add(dataItem);
            }
            drp_lst.SelectedIndex = -1;
        }
        #endregion
        
        private void txtfileno_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 || e.KeyChar == (char)9)
            {
                btnFind_Click(null, null);
            }
        }

        double TotalPaidSurcharge = 0;
        private void btnFind_Click(object sender, EventArgs e)
                        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetOwnerDetails"),
                new SqlParameter("@FileNo",txtfileno.Text.Trim()),
            };


            DataSet ds = cls_dl_Challan.Challan_Reader(prm);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count == 0)
                    return;
                txtname.Clear();
                cmbOwnerCategory.SelectedIndex = -1;
                cmbPlotSize.SelectedIndex = -1;
                cmbPlotSize.Text = "";
                //if (lbllastFileName.Text != txtfileno.Text.Trim())
                //{
                //    sampleDataTable.Clear();
                //    dgvChallanDetails.DataSource = null;
                //}
                if (ds.Tables[0].Rows.Count > 0)
                {
                    if (BuyerChallanGeneratefromNDC == true)
                    {
                        txtname.Text = Buyer_Name;
                        txtCNICMask.Text = Helper.clsPluginHelper.DbNullIfNullOrEmpty(ds.Tables[0].Rows[0]["CNIC"].ToString()) == null ? null : Buyer_CNIC;
                    }
                    else
                    {
                        List<string> activityNames = new List<string>();
                        List<string> activityCNICS = new List<string>();
                       
                            //txtname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                            //txtCNICMask.Text = Helper.clsPluginHelper.DbNullIfNullOrEmpty(ds.Tables[0].Rows[0]["CNIC"].ToString()) == null ? null : ds.Tables[0].Rows[0]["CNIC"].ToString();
                         


                        foreach (DataRow row in ds.Tables[0].Rows)
                        {

                            activityNames.Add(row["Name"].ToString());
                           // activityCNICS.Add(row["CNIC"].ToString());
                            activityCNICS.Add(Helper.clsPluginHelper.DbNullIfNullOrEmpty(row["CNIC"].ToString()) == null ? null : row["CNIC"].ToString());
                             
                        }
                        txtname.Text= String.Join(",", activityNames.ToArray());
                        txtCNICMask.Text = String.Join(",", activityCNICS.ToArray());

                    }
                    //Name of Member is Null which user Write
                    // txtname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    cmbOwnerCategory.SelectedValue = ds.Tables[0].Rows[0]["OwnerCategoryID"].ToString();
                    cmbPlotSize.SelectedText = ds.Tables[0].Rows[0]["PlotSize"].ToString();
                    cmbPlotSize.SelectedIndex = cmbPlotSize.Items.IndexOf(ds.Tables[0].Rows[0]["PlotSize"].ToString());
                    lblMemberShipID.Text = ds.Tables[0].Rows[0]["MembershipID"].ToString();
                    lblFileMapKey.Text = ds.Tables[0].Rows[0]["FileMapKey"].ToString();
                    //txtCNICMask.Text = Helper.clsPluginHelper.DbNullIfNullOrEmpty(ds.Tables[0].Rows[0]["CNIC"].ToString())==null?null: ds.Tables[0].Rows[0]["CNIC"].ToString();
                    //bool resss = double.TryParse(ds.Tables[0].Rows[0]["TotalPaidSurchage"].ToString(), out TotalPaidSurcharge);
                    //if (TotalPaidSurcharge < 1)
                    //    TotalPaidSurcharge = 0;
                    lbllastFileName.Text = txtfileno.Text.Trim();
                    if (cmbChallanType.Text == "Installment")
                    {
                        double TotalAmount = 0;
                        bool res = double.TryParse(ds.Tables[0].Rows[0]["NextDueAmount"].ToString(), out TotalAmount);
                        if (TotalAmount < 0)
                            TotalAmount = 0;
                        txtAmount.Text = TotalAmount.ToString();
                        txtAmount.Focus();
                    }
                    else if (cmbChallanType.Text == "Surcharge")
                    {
                        try
                        {
                            DataSet dst = ReceiveAdjustment();
                            int Surcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= DateTime.Now)
                                                 .Sum(r => r.Field<int>("Surcharge"));
                            //  double PaidSurcharge =  
                            double RemaingSurch = Surcharge - TotalPaidSurcharge;
                            if (RemaingSurch < 1)
                                RemaingSurch = 0;
                            txtAmount.Text = RemaingSurch.ToString();
                            txtAmount.Focus();
                        }
                        catch (Exception)
                        {
                        }
                    }
                    //Fix Amount
                    else if (cmbChallanType.Text == "Nomination Fee")
                    {
                        txtAmount.Text = "6500";
                        txtAmount.Focus();
                    }

                    if (txtfileno.Text.ToUpper() == "FILEUNISSUED")
                    {
                        cmbPlotSize.Enabled = true;
                        cmbPlotSize.ShowDropDown();
                    }
                    else
                    {
                        cmbPlotSize.Enabled = false;
                    }
                }
                else
                    MessageBox.Show("No record found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void cmbChallanHeader_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbChallanHeader.SelectedIndex < 0)
                return;
            if (cmbPlotSize.SelectedIndex < 0)
            {
                MessageBox.Show("Please enter a valid File No. first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cmbChallanHeader.SelectedIndex = -1;
                txtfileno.Focus();
                return;
            }
            ChallanHeaderDetailsBinding(cmbChallanHeDetail);

            foreach (RadCheckedListDataItem itm in cmbChallanHeDetail.Items)
            {
                DataRow[] foundAuthors = sampleDataTable.Select("ID = '" + itm.Value + "'");
                if (foundAuthors.Length != 0)
                {
                    itm.Checked = true;
                }

            }
        }


        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is RadButton || c is RadCheckBox || c is RadTextBox || c is RadDropDownList || c is RadCheckedDropDownList || c is RadDateTimePicker)
                    if (c.Controls.Owner.Name != "cmbChallanType")
                        c.Enabled = false;
            }

        }

        private void EnableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is RadButton || c is RadCheckBox || c is RadTextBox || c is RadDropDownList || c is RadCheckedDropDownList || c is RadDateTimePicker)
                    c.Enabled = true;
            }

        }


        private void dgvChallanDetails_CellClick(object sender, GridViewCellEventArgs e)
        {
            try
            {
                if (e.Column.Name == "DeleteRow")
                {
                    try
                    {
                        int ID = int.Parse(dgvChallanDetails.CurrentRow.Cells["ID"].Value.ToString());
                        if (sampleDataTable.Rows.Count == 1)
                            sampleDataTable.Rows.Clear();
                        else
                            sampleDataTable = sampleDataTable.Select("ID <> '" + ID + "'").CopyToDataTable();
                        dgvChallanDetails.DataSource = sampleDataTable.DefaultView;

                        DataTable dt = sampleDataTable.Copy();
                        sampleDataTable.Clear();
                        DataRow sampleDataRow;

                        foreach (DataRow checkeditem in dt.Rows)
                        {
                            sampleDataRow = sampleDataTable.NewRow();
                            sampleDataRow["ID"] = checkeditem[0];
                            sampleDataRow["SerialNo"] = sampleDataTable.Rows.Count + 1;
                            sampleDataRow["Particulars"] = checkeditem[2];
                            sampleDataRow["Amount"] = checkeditem[3];
                            sampleDataTable.Rows.Add(sampleDataRow);
                        }

                        dgvChallanDetails.DataSource = sampleDataTable.DefaultView;
                    }
                    catch (Exception)
                    {
                        dgvChallanDetails.DataSource = null;
                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void cmbChallanType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbChallanType.Text == "Installment")
            {
                EnableControls(radGroupBox1);
                DisableControls(radGroupBox3);
                lblDueAmount.Visible = true;
                txtAmount.Visible = true;
                cmbChallanHeader.SelectedIndex = -1;
                cmbChallanHeDetail.SelectedIndex = -1;
                //dgvChallanDetails.DataSource = null;
                txtfileno.Focus();
                //sampleDataTable.Clear();
                txtAmount.Clear();
                //txtname.Enabled = false;
                cmbOwnerCategory.Enabled = false;
                cmbPlotSize.Enabled = false;
                txtCNICMask.Clear();
                txtCNICMask.ReadOnly = false;
            }
            else if (cmbChallanType.Text == "Other")
            {
                EnableControls(radGroupBox1);
                EnableControls(radGroupBox3);
                lblDueAmount.Visible = false;
                txtAmount.Visible = false;
                //dgvChallanDetails.DataSource = null;
                txtfileno.Focus();

                txtname.Enabled = true;
                cmbOwnerCategory.Enabled = false;
                cmbPlotSize.Enabled = false;
                // sampleDataTable.Clear();
                txtCNICMask.Clear();
                txtCNICMask.ReadOnly = false;
            }
            else if (cmbChallanType.Text == "Nomination Fee" || cmbChallanType.Text == "Registration Of Property Dealers"
                || cmbChallanType.Text == "Renewal Fee for Registration Of Property Dealers"
                || cmbChallanType.Text == "Security Fee" || cmbChallanType.Text == "Application Fee of Property Dealers")
            {
                EnableControls(radGroupBox1);
                DisableControls(radGroupBox3);
                lblDueAmount.Visible = true;
                txtAmount.Visible = true;
                cmbChallanHeader.SelectedIndex = -1;
                cmbChallanHeDetail.SelectedIndex = -1;
                //dgvChallanDetails.DataSource = null;
                txtname.Focus();
                txtname.Enabled = true;
                //sampleDataTable.Clear();
                txtAmount.Clear();

                cmbOwnerCategory.Enabled = false;
                cmbPlotSize.Enabled = false;

                txtCNICMask.Clear();
                txtCNICMask.ReadOnly=false;
            }
            else
            {
                DisableControls(radGroupBox1);
                DisableControls(radGroupBox3);
                lblDueAmount.Visible = false;
                txtAmount.Visible = false;
            }
        }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
                {
                    MessageBox.Show("Please enter amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                double TotalAmount;
                bool res = double.TryParse(txtAmount.Text.Trim(), out TotalAmount);
                if (!res)
                {
                    MessageBox.Show("Invalid amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                sampleDataTable.Clear();
                DataRow sampleDataRow;
                if (cmbChallanType.Text == "Installment")
                {
                    sampleDataRow = sampleDataTable.NewRow();
                    sampleDataRow["ID"] = "1";
                    sampleDataRow["SerialNo"] = sampleDataTable.Rows.Count + 1;
                    sampleDataRow["Particulars"] = "Installment Amount.";
                    sampleDataRow["Amount"] = txtAmount.Text;
                    sampleDataRow["isReadOnly"] = "True";
                    sampleDataTable.Rows.Add(sampleDataRow);
                }
                else if (cmbChallanType.Text == "Surcharge")
                {
                    sampleDataRow = sampleDataTable.NewRow();
                    sampleDataRow["ID"] = "1";
                    sampleDataRow["SerialNo"] = sampleDataTable.Rows.Count + 1;
                    sampleDataRow["Particulars"] = "Surcharge Amount.";
                    sampleDataRow["Amount"] = txtAmount.Text;
                    sampleDataRow["isReadOnly"] = "True";
                    sampleDataTable.Rows.Add(sampleDataRow);
                }
                else if (cmbChallanType.Text == "Nomination Fee")
                {
                    sampleDataRow = sampleDataTable.NewRow();
                    sampleDataRow["ID"] = "1";
                    sampleDataRow["SerialNo"] = sampleDataTable.Rows.Count + 1;
                    sampleDataRow["Particulars"] = "Nomination Fee";
                    sampleDataRow["Amount"] = txtAmount.Text;
                    sampleDataRow["isReadOnly"] = "True";
                    sampleDataTable.Rows.Add(sampleDataRow);
                }
                dgvChallanDetails.DataSource = sampleDataTable.DefaultView;
            }
        }
        private double StampFees()
        {
            #region Stamp Duty Calculation


            SqlParameter[] prmGOD =
                          {
                                new SqlParameter("@Task","GetOwnerDetailsForStampDuty"),
                                new SqlParameter("@FileNo",txtfileno.Text.Trim()),
                            };


            DataSet dsGOD = cls_dl_Challan.Challan_Reader(prmGOD);
            decimal psize = 0;
            string plotSizeId = string.Empty;
            string plotSize = dsGOD.Tables[0].Rows[0]["PlotSize"].ToString();
            string sector = dsGOD.Tables[0].Rows[0]["FileSector"].ToString();
            switch (plotSize)
            {
                case "1 Kanal":
                    plotSizeId = "1";
                    psize = 20;
                    break;
                case "8 Marla":
                    plotSizeId = "2";
                    psize = 8;
                    break;
                case "5 Marla":
                    plotSizeId = "3";
                    psize = 5;
                    break;
                case "4 Marla":
                    plotSizeId = "4";
                    psize = 4;
                    break;
                case "2 Kanal":
                    plotSizeId = "5";
                    psize = 40;
                    break;
                case "10 Marla":
                    plotSizeId = "6";
                    psize = 10;
                    break;
                case "8 Marla Com":
                    plotSizeId = "7";
                    psize = 8;
                    break;
                case "4 Marla Com":
                    plotSizeId = "8";
                    psize = 4;
                    break;
                case "1 Kanal Com":
                    plotSizeId = "11";
                    psize = 20;
                    break;
                case "16 Marla Com":
                    plotSizeId = "12";
                    psize = 16;
                    break;
                case "12 Marla Com":
                    plotSizeId = "13";
                    psize = 12;
                    break;
                case "4 Kanal Com":
                    plotSizeId = "14";
                    psize = 80;
                    break;
                case "4 Kanal":
                    plotSizeId = "15";
                    psize = 80;
                    break;
                case "8 Kanal Com":
                    plotSizeId = "16";
                    psize = 160;
                    break;
                case "5 Marla Com":
                    plotSizeId = "17";
                    psize = 5;
                    break;
                case "10 Marla Com":
                    plotSizeId = "18";
                    psize = 10;
                    break;
            }

            decimal TotalAmount = 00;
            decimal FBRvalueperMarla = 0;
            decimal percentageValue = 0.02m;
            double stampDutyAmount = 0;
            //decimal stmdtyfee_minus = Convert.ToDecimal(txtStmDtyFee_minus.Text == "" ? "0" : txtStmDtyFee_minus.Text);
            SqlParameter[] prm_ =
            {
                        new SqlParameter("@Task","Select_Stamp_Duty_NotUse_NDC"),
                        new SqlParameter("@FileNo",txtfileno.Text.Trim())
                        };
            DataSet dst_ = new DataSet();
            dst_ = cls_dl_StampDuty.StampDuty_Reader(prm_);
            if (dst_.Tables.Count > 0)
            {
                if (dst_.Tables[0].Rows.Count > 0)
                {
                    stampDutyAmount = 0;
                }
                else
                {
                    if (txtfileno.Text.ToUpper().Contains("/COM/"))
                    {
                        if (string.IsNullOrEmpty(sector))
                        {
                            FBRvalueperMarla = Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarla_ComOther"]); //FBR Per Marla Value is 1250000


                            stampDutyAmount = Convert.ToInt32(psize * FBRvalueperMarla);
                        }
                        else
                        {
                            if (sector == "ABC")
                            {
                                FBRvalueperMarla = (Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarla_ComABC"]) * percentageValue); //FBR Per Marla Value is 2500000

                                stampDutyAmount = Convert.ToInt32(psize * FBRvalueperMarla);

                            }
                            else
                            {
                                FBRvalueperMarla = (Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarla_ComOther"]) * percentageValue); //FBR Per Marla Value is  1250000
                                stampDutyAmount = Convert.ToInt32(psize * FBRvalueperMarla);
                            }
                        }

                    }
                    else
                    {
                        if (string.IsNullOrEmpty(sector))
                        {
                            FBRvalueperMarla = (Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarlaOther"]) * percentageValue); //FBR Per Marla Value is 300000


                            stampDutyAmount = Convert.ToInt32(psize * FBRvalueperMarla);
                        }
                        else
                        {
                            if (sector == "ABC")
                            {
                                FBRvalueperMarla = (Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarlaABC"]) * percentageValue); //FBR Per Marla Value 500000 

                                stampDutyAmount = Convert.ToInt32(psize * FBRvalueperMarla);

                            }
                            else
                            {
                                FBRvalueperMarla = (Convert.ToDecimal(ConfigurationManager.AppSettings["FBRValuePerMarlaOther"]) * percentageValue); //FBR Per Marla Value 300000
                                stampDutyAmount = Convert.ToInt32(psize * FBRvalueperMarla);
                            }
                        }
                    }

                }

            }

            #endregion
            return stampDutyAmount;
        }

        private void cmbChallanHeDetail_ItemCheckedChanged(object sender, RadCheckedListDataItemEventArgs e)
        {
            RadCheckedListDataItem checkeditem = e.Item;
            int stampdutyAmount = 0;
            if(checkeditem.Text=="Stamp Duty")
            stampdutyAmount = Convert.ToInt32(StampFees());
            

            if (checkeditem.Checked == true)
            {
                if (checkeditem.Text == "TFR Fee")
                {
                    //TFR Fee Check
                    SqlParameter[] prma = {
                    new SqlParameter("@Task","TFRFeeLock"),
                    new SqlParameter("@FileNo",txtfileno.Text.Trim()),
                    };
                    DataSet dsTFRFee = cls_dl_Challan.Challan_Reader(prma);
                    if (dsTFRFee.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("TFR Fee already paid for this File And Owner Information is Below."
                            + "\n-------------------------------------------\n Current Owner Name: "
                            + dsTFRFee.Tables[0].Rows[0]["OwnerName"].ToString()
                            + "\n Transferee Owner Name: " + dsTFRFee.Tables[0].Rows[0]["Transferee"].ToString()
                            , "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                if (checkeditem.Value == null)
                    return;

                if (checkeditem.Text == "Surcharge")
                {
                    try
                    {
                        DataSet dst = ReceiveAdjustment();
                        //double Surcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= DateTime.Now)
                        //                     .Sum(r => r.Field<double>("TotalDueSurcharge"));
                        int Surcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<DateTime>("DueDate") <= DateTime.Now)
                                     .Sum(r => r.Field<int>("Surcharge"));

                        int TotalWaieOffSurcharge = dst.Tables[0].AsEnumerable().Where(r => r.Field<int?>("TotalWaiveOffSurcharge") != null)
                                       .Sum(r => r.Field<int>("TotalWaiveOffSurcharge"));
                        //  double PaidSurcharge =  
                        bool resss = double.TryParse(dst.Tables[0].Rows[0]["TotalPaidSurcharge"].ToString(), out TotalPaidSurcharge);
                        if (TotalPaidSurcharge < 1)
                            TotalPaidSurcharge = 0;

                        double RemaingSurch = Surcharge - TotalPaidSurcharge - TotalWaieOffSurcharge;



                        if (RemaingSurch < 1)
                            RemaingSurch = 0;
                        checkeditem.Tag = RemaingSurch.ToString();
                    }
                    catch (Exception d)
                    {
                    }
                }

                DataRow[] foundAuthors = sampleDataTable.Select("ID = '" + checkeditem.Value + "'");
                if (foundAuthors.Length != 0)
                {
                    return;
                }
                DataRow sampleDataRow;
                //if (sampleDataTable.Rows.Count == 1)
                //{
                //    sampleDataTable.Rows.Clear();
                //}
                if (checkeditem.Text=="Stamp Duty")
                {
                    sampleDataRow = sampleDataTable.NewRow();
                    sampleDataRow["ID"] = checkeditem.Value;
                    sampleDataRow["SerialNo"] = sampleDataTable.Rows.Count + 1;
                    sampleDataRow["Particulars"] = checkeditem.Text;
                    sampleDataRow["Amount"] = stampdutyAmount;
                    if (checkeditem.Text == "Surcharge" || checkeditem.Text == "Membership Form")
                        sampleDataRow["isReadOnly"] = "True";
                    else
                        sampleDataRow["isReadOnly"] = "False";
                    sampleDataTable.Rows.Add(sampleDataRow);
                }
                else
                {
                    sampleDataRow = sampleDataTable.NewRow();
                    sampleDataRow["ID"] = checkeditem.Value;
                    sampleDataRow["SerialNo"] = sampleDataTable.Rows.Count + 1;
                    sampleDataRow["Particulars"] = checkeditem.Text;
                    sampleDataRow["Amount"] = checkeditem.Tag;
                    if (checkeditem.Text == "Surcharge" || checkeditem.Text == "Membership Form")
                        sampleDataRow["isReadOnly"] = "True";
                    else
                        sampleDataRow["isReadOnly"] = "False";
                    sampleDataTable.Rows.Add(sampleDataRow);
                }
                
            }
            else
            {
                try
                {
                    int ID = int.Parse(checkeditem.Value.ToString());
                    if (sampleDataTable.Rows.Count == 1)
                        sampleDataTable.Rows.Clear();                    
                    else
                        sampleDataTable = sampleDataTable.Select("ID <> '" + ID + "'").CopyToDataTable();
                    dgvChallanDetails.DataSource = sampleDataTable.DefaultView;

                    DataTable dt = sampleDataTable.Copy();
                    sampleDataTable.Clear();
                    DataRow sampleDataRow;

                    foreach (DataRow checkeditems in dt.Rows)
                    {
                        sampleDataRow = sampleDataTable.NewRow();
                        sampleDataRow["ID"] = checkeditems[0];
                        sampleDataRow["SerialNo"] = sampleDataTable.Rows.Count + 1;
                        sampleDataRow["Particulars"] = checkeditems[2];
                        sampleDataRow["Amount"] = checkeditems[3];
                        sampleDataRow["isReadOnly"] = checkeditems[4];
                        sampleDataTable.Rows.Add(sampleDataRow);
                    }
                }
                catch (Exception)
                {
                    dgvChallanDetails.DataSource = null;
                }
            }
            dgvChallanDetails.DataSource = sampleDataTable.DefaultView;
        }

        private void cmbPlotSize_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            cmbChallanHeader.SelectedIndex = -1;
            cmbChallanHeDetail.Items.Clear();
        }
        private DataSet ReceiveAdjustment()
        {
            DataSet dst = new DataSet();
            SqlParameter[] prmt =
                   {
                     new SqlParameter("@Task","Rece_Plan_Adjust"),
                     new SqlParameter("@FileNo",txtfileno.Text)
                    };
            int rsult = Data_Layer.Installment.cls_dl_FinanceDashBoard.AccountStatement_RecePlanAdjust(prmt);

            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Account_Statement_Reading"),
                new SqlParameter("@FileNo",txtfileno.Text)
                };

            dst = Data_Layer.Installment.cls_dl_FinanceDashBoard.InstallmentSummary_Reader(prm);
            return dst;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtChallanNo.Text.Trim()))
            {
                MessageBox.Show("Please enter Challan No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtChallanNo.Focus();
                return;
            }

            if (string.IsNullOrEmpty(txtCNICMask.Text.Trim()))
            {
                MessageBox.Show("Please enter CNIC No.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCNICMask.Focus();
                return;
            }
            //if (cmbChallanType.SelectedIndex <= 0)
            //{
            //    MessageBox.Show("Please select challan type to proceed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    cmbChallanType.ShowDropDown();
            //    return;
            //}
            if (sampleDataTable.Rows.Count == 0)
            {
                MessageBox.Show("Please provide Challan Particular(s) to proceed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtfileno.Focus();
                return;
            }
            //if (string.IsNullOrEmpty(lblChallanNo.Text.Trim()))
            {
                object sumObject;
                sumObject = sampleDataTable.Compute("Sum(Amount)", "");
                double Amt;
                bool isOk = double.TryParse(sumObject.ToString(), out Amt);
                if (isOk == false)
                {
                    MessageBox.Show("Cannot create challan for Zero amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //cmbChallanType.ShowDropDown();
                    return;
                }
                int TotalAmount = Convert.ToInt32(Amt);
                //bool res = int.TryParse(sumObject.ToString(), out TotalAmount);
                //if (TotalAmount == 0)
                //{
                //    MessageBox.Show("Cannot create challan for Zero amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //    //cmbChallanType.ShowDropDown();
                //    return;
                //}
                string amount_in_word = Helper.clsPluginHelper.Convert_Number_To_Text(TotalAmount, false);
                SqlParameter param_out_ID = new SqlParameter()
                {
                    ParameterName = "@ChallanIDOutput",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                int ChallanIDOut = 0;
                {
                    //SqlParameter[] prm1 =
                    //{
                    //   new SqlParameter("@Task","GetChallanNoInfo"),
                    //   new SqlParameter("@ChalanNo",txtChallanNo.Text.Trim()),
                    //};
                    //DataSet ds1 = cls_dl_Challan.Challan_Reader(prm1);
                    //if (ds1.Tables.Count > 0 && string.IsNullOrEmpty(lblChalanID.Text))
                    //{
                    //    if (ds1.Tables[0].Rows.Count > 0)
                    //    {
                    //        MessageBox.Show("Challan No. already exists.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //        txtChallanNo.Focus();
                    //        return;
                    //    }
                    //}
                    if (TotalAmount > 0)
                    {
                        // Insert / Update Record of Challan
                        string Task = "";
                        if (string.IsNullOrEmpty(lblChalanID.Text))
                            Task = "SaveChallan";
                        else
                            Task = "UpdateChallanEdit";

                        SqlParameter[] prm =
                        {
                        new SqlParameter("@Task", Task),
                        new SqlParameter("@ChallanID", string.IsNullOrEmpty(lblChalanID.Text)? null : lblChalanID.Text),
                        new SqlParameter("@FileMapKey", string.IsNullOrEmpty(lblFileMapKey.Text.Trim()) ? null : lblFileMapKey.Text.Trim()),
                        new SqlParameter("@MemberID", string.IsNullOrEmpty(lblMemberShipID.Text.Trim()) ? null : lblMemberShipID.Text.Trim()),
                        new SqlParameter("@Name", txtname.Text.Trim()),
                        new SqlParameter("@ChalanNo", txtChallanNo.Text.Trim()),
                        new SqlParameter("@ClearDate", ChallanDate.Value.Date),
                        new SqlParameter("@BankAccount", "0040100581377"),
                        new SqlParameter("@BankName", "Askari Bank Limited"),
                        new SqlParameter("@TotalAmount", TotalAmount),
                        new SqlParameter("@AmountInWord", amount_in_word),
                        new SqlParameter("@UserID", Models.clsUser.ID),
                        new SqlParameter("@ChallanType", cmbChallanType.Text.Trim()),
                        new SqlParameter("@Status", null),
                        new SqlParameter("@RefNo", txtDDNo.Text),
                        new SqlParameter("@CNIC",txtCNICMask.Text),
                        new SqlParameter("@Description", txtRemark.Text),
                        new SqlParameter("@PropertyDealerID", cmbPropertyDealer.Text == "" ? null : cmbPropertyDealer.SelectedValue.ToString()),
                         
                        param_out_ID
                    };
                        
                        SqlCommand result = cls_dl_Challan.ChallanExecuteNonQuery(prm);

                        if (result.Parameters.Count != 0)
                        {
                            ChallanIDOut = int.Parse(result.Parameters["@ChallanIDOutput"].Value.ToString());
                            //Insertion Of NextOfKin
                            if (ChallanIDOut != 0)
                            {
                                foreach (DataRow checkeditems in sampleDataTable.Rows)
                                {
                                    string ChallanType = null;
                                    if (checkeditems[0].ToString() == "0")
                                        ChallanType = "Installment";
                                    else if (checkeditems[0].ToString() == "-1")
                                        ChallanType = "Nomination Fee";
                                    else if (checkeditems[0].ToString() == "-2")
                                        ChallanType = "Registration Of Property Dealers";
                                    else if (checkeditems[0].ToString() == "-3")
                                        ChallanType = "Renewal Fee for Registration Of Property Dealers";
                                    else if (checkeditems[0].ToString() == "-4")
                                        ChallanType = "Security Fee";
                                    else if (checkeditems[0].ToString() == "-5")
                                        ChallanType = "Application Fee of Property Dealers";
                                    else
                                        ChallanType = "Other";

                                    SqlParameter[] prm2 =
                                    {
                                    new SqlParameter("@Task","SaveChallanDetail"),
                                    new SqlParameter("@ChallanID", ChallanIDOut),
                                    new SqlParameter("@ParticularID", checkeditems[0]),
                                    new SqlParameter("@ParticularAmount", checkeditems["Amount"]),
                                    new SqlParameter("@UserID", Models.clsUser.ID),
                                    new SqlParameter("@SerialNo", checkeditems["SerialNo"]),
                                    new SqlParameter("@Particular",checkeditems["Particulars"]),
                                    new SqlParameter("@ChallanType",ChallanType )
                                    //ChallanType
                                };
                                    try
                                    {
                                        int resulte = cls_dl_Challan.Challan_ExecuteNonQuery(prm2);
                                        if (resulte > 0)
                                        {
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }

                                DataSet ds = new DataSet();
                                SqlParameter[] prm3 =
                                {
                                new SqlParameter("@Task","GetChallReportDetail"),
                                new SqlParameter("@ChallanID",ChallanIDOut)
                            };

                                ds = cls_dl_Challan.Challan_Reader(prm3);
                                ChallanDataset _ds = new ChallanDataset();

                                _ds.Tables["tblChallan"].Merge(ds.Tables[0], true, MissingSchemaAction.Ignore);
                                _ds.Tables["tblChallanDetail"].Merge(ds.Tables[1], true, MissingSchemaAction.Ignore);
                                ds = null;
                                frmChallanReportViewer obj = new frmChallanReportViewer(_ds);
                                obj.ShowDialog();
                                this.Close();
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Total Amount of Challan is Zero Challan Cannot be Generate.");
                    }
                }
            }
        }

        private void dgvChallanDetails_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (!(e.Row is GridViewNewRowInfo) && e.Row.Cells[4].Value.ToString() != "True")
            {
                e.Cancel = true;
            }
        }

        /// <summary>
        /// FileNo Verification
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtfileno_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            
            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                if (FileActiveNotBlock() == true)
                {
                    btnFind_Click(null, null);
                }
                   
            }

        }
        private bool FileActiveNotBlock()
        {
            bool fanl = false;
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","FileActiveNotBlockStatus_Payment"),
                new SqlParameter("@FileNo",txtfileno.Text)
            };
            DataSet dst = cls_dl_NDC.NdcRetrival(prm);
            if (dst.Tables.Count > 0)
            {
                if (dst.Tables[0].Rows.Count > 0)
                {
                    fanl = true;
                    btnSave.Enabled = true;
                }
                else
                {
                    MessageBox.Show("This File No. is Cancel.");
                    fanl = false;
                    btnSave.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("This File No. is Cancel.");
                fanl = false;
                btnSave.Enabled = false;
            }
            return fanl;
        }
        private void txtAmount_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtAmount.Text.Trim()))
                {
                    MessageBox.Show("Please enter amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                double TotalAmount;
                bool res = double.TryParse(txtAmount.Text.Trim(), out TotalAmount);
                if (!res)
                {
                    MessageBox.Show("Invalid amount.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                //  sampleDataTable.Clear();
                DataRow sampleDataRow;
                if (cmbChallanType.Text == "Installment")
                {
                    DataRow[] foundAuthors = sampleDataTable.Select("ID = '0'");
                    if (foundAuthors.Length != 0)
                    {
                        return;
                    }
                    sampleDataRow = sampleDataTable.NewRow();
                    sampleDataRow["ID"] = "0";
                    sampleDataRow["SerialNo"] = sampleDataTable.Rows.Count + 1;
                    sampleDataRow["Particulars"] = "Installment Amount.";
                    sampleDataRow["Amount"] = txtAmount.Text;
                    sampleDataRow["isReadOnly"] = "True";
                    sampleDataTable.Rows.Add(sampleDataRow);
                }
                else if (cmbChallanType.Text == "Surcharge")
                {
                    DataRow[] foundAuthors = sampleDataTable.Select("ID = '12'");
                    if (foundAuthors.Length != 0)
                    {
                        return;
                    }
                    sampleDataRow = sampleDataTable.NewRow();
                    sampleDataRow["ID"] = "12";
                    sampleDataRow["SerialNo"] = sampleDataTable.Rows.Count + 1;
                    sampleDataRow["Particulars"] = "Surcharge Amount.";
                    sampleDataRow["Amount"] = txtAmount.Text;
                    sampleDataRow["isReadOnly"] = "True";
                    sampleDataTable.Rows.Add(sampleDataRow);
                }
                else if (cmbChallanType.Text == "Nomination Fee" || cmbChallanType.Text == "Registration Of Property Dealers" ||
                    cmbChallanType.Text == "Renewal Fee for Registration Of Property Dealers" || cmbChallanType.Text == "Security Fee"
                    || cmbChallanType.Text == "Application Fee of Property Dealers")
                {
                    DataRow[] foundAuthors = null;
                    if (cmbChallanType.Text == "Nomination Fee")
                    {
                        foundAuthors = sampleDataTable.Select("ID = '-1'");
                        if (foundAuthors.Length != 0)
                        {
                            return;
                        }
                    }
                    else if (cmbChallanType.Text == "Registration Of Property Dealers")
                    {
                        foundAuthors = sampleDataTable.Select("ID = '-2'");
                        if (foundAuthors.Length != 0)
                        {
                            return;
                        }
                    }
                    else if (cmbChallanType.Text == "Renewal Fee for Registration Of Property Dealers")
                    {
                        foundAuthors = sampleDataTable.Select("ID = '-3'");
                        if (foundAuthors.Length != 0)
                        {
                            return;
                        }
                    }

                    else if (cmbChallanType.Text == "Security Fee")
                    {
                        foundAuthors = sampleDataTable.Select("ID = '-4'");
                        if (foundAuthors.Length != 0)
                        {
                            return;
                        }
                    }
                    //Any New Type of Fee Introduce else if copy and CHange Text and Index
                    else if (cmbChallanType.Text == "Application Fee of Property Dealers")
                    {
                        foundAuthors = sampleDataTable.Select("ID = '-5'");
                        if (foundAuthors.Length != 0)
                        {
                            return;
                        }
                    }
                    // Add Row of New Fee to here with Index
                    sampleDataRow = sampleDataTable.NewRow();
                    if (cmbChallanType.Text == "Nomination Fee")
                        sampleDataRow["ID"] = "-1";
                    if (cmbChallanType.Text == "Registration Of Property Dealers")
                        sampleDataRow["ID"] = "-2";
                    if (cmbChallanType.Text == "Renewal Fee for Registration Of Property Dealers")
                        sampleDataRow["ID"] = "-3";
                    if (cmbChallanType.Text == "Security Fee")
                        sampleDataRow["ID"] = "-4";
                    if (cmbChallanType.Text == "Application Fee of Property Dealers")
                        sampleDataRow["ID"] = "-5";

                    sampleDataRow["SerialNo"] = sampleDataTable.Rows.Count + 1;
                    sampleDataRow["Particulars"] = cmbChallanType.Text;
                    sampleDataRow["Amount"] = txtAmount.Text;
                    sampleDataRow["isReadOnly"] = "True";
                    sampleDataTable.Rows.Add(sampleDataRow);
                }
                dgvChallanDetails.DataSource = sampleDataTable.DefaultView;
            }
        }
        /// <summary>
        /// Verification of Challan No That Exist or Not
        /// </summary>
        /// <param name="txtChallanNo">ChallanNo in Digit</param>
        /// <param name="e"></param>
        private void txtRefNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","GetChallanNoInfo"),
                    new SqlParameter("@ChalanNo",txtChallanNo.Text.Trim()),
                };
                DataSet ds = cls_dl_Challan.Challan_Reader(prm);
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        MessageBox.Show("Challan No. already exists.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtChallanNo.Focus();
                    }
                }
            }
        }


        private void txtname_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {

            if (e.KeyData == Keys.Tab || e.KeyData == Keys.Enter)
            {
                if (cmbChallanType.Text == "Nomination Fee" || cmbChallanType.Text == "Registration Of Property Dealers"
                    || cmbChallanType.Text == "Renewal Fee for Registration Of Property Dealers"
                    || cmbChallanType.Text == "Security Fee" || cmbChallanType.Text == "Application Fee of Property Dealers")
                {
                    txtAmount.Text = cmbChallanType.SelectedItem.Tag.ToString();
                    txtAmount.Focus();
                }
            }
        }

        //.......................    Property Dealers ...............  //

        private void cmbChallanType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            if (cmbChallanType.Text == "Renewal Fee for Registration Of Property Dealers")
            {              
                PropertyDealerBinding(cmbPropertyDealer);
            }
            else {
                cmbPropertyDealer.Items.Clear();
                
            }
               
        }
        private void PropertyDealerBinding(RadDropDownList drp_lst)
        {
            RadListDataItem select = new RadListDataItem();
            select.Value = 0;
            select.Text = "-- Select Dealer --";
            drp_lst.Items.Add(select);
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","Get_PropertyDealers"),
            };
            foreach (DataRow row in cls_dl_Challan.Challan_Reader(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ID"].ToString();
                dataItem.Text = row["DealerName1"].ToString();            
                drp_lst.Items.Add(dataItem);
            }
            drp_lst.SelectedIndex = -1;
        }

        private void cmbPropertyDealer_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
             
            SqlParameter[] prm =
               {
                    new SqlParameter("@Task","GetPropDealerSpecRcd"),
                    new SqlParameter("@DealerName1",cmbPropertyDealer.SelectedText),
                };
            DataSet ds = cls_dl_Challan.Challan_Reader(prm);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    txtCNICMask.Text = ds.Tables[0].Rows[0]["CNICNo1"].ToString();
                    txtCNICMask.ReadOnly = true;


                }
            }
        }
    }
}
