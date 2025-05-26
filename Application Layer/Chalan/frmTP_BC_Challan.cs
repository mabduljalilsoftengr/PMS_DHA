using PeshawarDHASW.Data_Layer.clsChallan;
using PeshawarDHASW.Data_Layer.NDC;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Report.Challan;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Chalan
{
 

    public partial class frmTP_BC_Challan : Telerik.WinControls.UI.RadForm
    {
        public frmTP_BC_Challan()
        {
            InitializeComponent();
        }
        public frmTP_BC_Challan(string ChallanID)
        {
            InitializeComponent();
            lblChalanID.Text = ChallanID;
        }//lblChalanID
        private void frmTP_BC_Challan_Load(object sender, EventArgs e)
        {
            ChallanTypeBinding(cmbChallanType);
            cmbChallanType.SelectedIndex = 0;
            OwnerCategoryBinding(cmbOwnerCategory);
            // ChallanHeaderBinding(cmbChallanHeader);

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
            dgvChallanDetails.MasterTemplate.AllowEditRow = true;
            #endregion

           // DisableControls(radGroupBox1);
           // DisableControls(radGroupBox3);
            ChallanDate.Value = DateTime.Now.Date;
            txtChallanNo.Enabled = true;
            if (!string.IsNullOrEmpty(lblChalanID.Text))
            {
                FillAllField(lblChalanID.Text);
                string BusinessType = txtfileno.Text.Contains("RES") == true ? "RES" : "COM";
                ChallanHeaderBinding(cmbChallanHeader, BusinessType);
            }
            #region Get Max Challan No
            SqlParameter[] prm1 =
            {
                new SqlParameter("@Task","GetMaxChallanNo"),
            };
            DataSet ds1 = cls_dl_Challan.Challan_Reader(prm1);
            if (ds1.Tables.Count > 0 && string.IsNullOrEmpty(lblChalanID.Text.Replace("-","")))
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
        }

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

        private void DisableControls(Control con)
        {
            foreach (Control c in con.Controls)
            {
                if (c is RadButton || c is RadCheckBox || c is RadTextBox || c is RadDropDownList || c is RadCheckedDropDownList || c is RadDateTimePicker)
                    if (c.Controls.Owner.Name != "cmbChallanType")
                        c.Enabled = false;
            }
        }
        private void FindFileInformation()
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
                cmbPlotSize.Text = "";
                //if (lbllastFileName.Text != txtfileno.Text.Trim())
                //{
                //    sampleDataTable.Clear();
                //    dgvChallanDetails.DataSource = null;
                //}
                if (ds.Tables[0].Rows.Count > 0)
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
                        txtname.Text = String.Join(",", activityNames.ToArray());
                        txtCNICMask.Text = String.Join(",", activityCNICS.ToArray());

                    //Name of Member is Null which user Write
                    // txtname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    cmbOwnerCategory.SelectedValue = ds.Tables[0].Rows[0]["OwnerCategoryID"].ToString();
                    //cmbPlotSize.SelectedText = ds.Tables[0].Rows[0]["PlotSize"].ToString();

                    cmbPlotSize.Text = ds.Tables[0].Rows[0]["PlotSize"].ToString(); //cmbPlotSize.Items.IndexOf(ds.Tables[0].Rows[0]["PlotSize"].ToString());
                    txtActualMarlaSize.Text= ds.Tables[0].Rows[0]["ActualSizeinMarla"].ToString();
                    decimal MarlaConvertDigit = decimal.Parse(txtActualMarlaSize.Text.Replace(" Marla", ""));
                    decimal SqftNumber = MarlaConvertDigit * 25;
                    txtSqft.Text = SqftNumber.ToString();

                    lblMemberShipID.Text = ds.Tables[0].Rows[0]["MembershipID"].ToString();
                    lblFileMapKey.Text = ds.Tables[0].Rows[0]["FileMapKey"].ToString();
                    //txtCNICMask.Text = Helper.clsPluginHelper.DbNullIfNullOrEmpty(ds.Tables[0].Rows[0]["CNIC"].ToString())==null?null: ds.Tables[0].Rows[0]["CNIC"].ToString();
                    //bool resss = double.TryParse(ds.Tables[0].Rows[0]["TotalPaidSurchage"].ToString(), out TotalPaidSurcharge);
                    //if (TotalPaidSurcharge < 1)
                    //    TotalPaidSurcharge = 0;
                    lbllastFileName.Text = txtfileno.Text.Trim();
                }
                else
                    MessageBox.Show("No record found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        #region Challan Type Binding 
        private void ChallanTypeBinding(RadDropDownList drp_lst)
        {
           
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","selecttbbc"),
            };
            foreach (DataRow row in cls_dl_Challan.Challan_Reader(prm).Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["ChallanTypeID"].ToString();
                dataItem.Text = row["ChallanType"].ToString();
                dataItem.Tag = row["FixedFee"].ToString();
                drp_lst.Items.Add(dataItem);
            }
            drp_lst.SelectedIndex = 0;
        }
        #endregion


        #region Challan Header Binding
        private void ChallanHeaderBinding(RadDropDownList drp_lst,string BusinessType)
        {
            RadListDataItem select = new RadListDataItem();
            drp_lst.Items.Clear();
            //select.Value = 0;
            //select.Text = "-- Select Challan Type --";
            //drp_lst.Items.Add(select);
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","fillChallanHeaderTBBC"),
                new SqlParameter("@BusinessType",BusinessType)
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
        private void txtfileno_KeyDown(object sender, KeyEventArgs e)
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
            bool fanl = true;
            //bool fanl = false;
            //SqlParameter[] prm =
            //{
            //    new SqlParameter("@Task","FileActiveNotBlockStatus"),
            //    new SqlParameter("@FileNo",txtfileno.Text)
            //};
            //DataSet dst = cls_dl_NDC.NdcRetrival(prm);
            //if (dst.Tables.Count > 0)
            //{
            //    if (dst.Tables[0].Rows.Count > 0)
            //    {
            //        fanl = true;
            //        btnSave.Enabled = true;
            //    }
            //    else
            //    {
            //        MessageBox.Show("This File No. is Cancel OR Block.");
            //        fanl = false;
            //        btnSave.Enabled = false;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("This File No. is Cancel OR Block.");
            //    fanl = false;
            //    btnSave.Enabled = false;
            //}
            return fanl;
        }

        private bool PlotActiveNotBlock()
        {
            bool fanl = false;
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","FileorPlotActiveNotBlockStatus"),
                new SqlParameter("@PlotNo",txtPlotNo.Text)
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
                    MessageBox.Show("This File No. is Cancel OR Block.");
                    fanl = false;
                    btnSave.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("This File No. is Cancel OR Block.");
                fanl = false;
                btnSave.Enabled = false;
            }
            return fanl;
        }
        private void btnFind_Click(object sender, EventArgs e)
        {
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","GetOwnerDetails_TBBC"),
                new SqlParameter("@FileNo",clsPluginHelper.DbNullIfNullOrEmpty(txtfileno.Text.Trim())),
                new SqlParameter("@PlotNo",clsPluginHelper.DbNullIfNullOrEmpty(txtPlotNo.Text.Trim())),
            };

           
            DataSet ds = cls_dl_Challan.Challan_Reader(prm);
            if (ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count == 0)
                    return;
                txtname.Clear();
                cmbOwnerCategory.SelectedIndex = -1;
               // cmbPlotSize.SelectedIndex = -1;
                cmbPlotSize.Text = "";
                if (ds.Tables[0].Rows.Count > 0)
                {

                    List<string> activityNames = new List<string>();
                    List<string> activityCNICS = new List<string>();

                    foreach (DataRow row in ds.Tables[0].Rows)
                    {

                        activityNames.Add(row["Name"].ToString());
                        // activityCNICS.Add(row["CNIC"].ToString());
                        activityCNICS.Add(Helper.clsPluginHelper.DbNullIfNullOrEmpty(row["CNIC"].ToString()) == null ? null : row["CNIC"].ToString());

                    }
                    txtname.Text = String.Join(",", activityNames.ToArray());
                    txtCNICMask.Text = String.Join(",", activityCNICS.ToArray());
                    //Name of Member is Null which user Write
                    // txtname.Text = ds.Tables[0].Rows[0]["Name"].ToString();
                    cmbOwnerCategory.SelectedValue = ds.Tables[0].Rows[0]["OwnerCategoryID"].ToString();
                    // cmbPlotSize.SelectedText = ds.Tables[0].Rows[0]["PlotSize"].ToString();
                    // cmbPlotSize.Text = ds.Tables[0].Rows[0]["ActualSizeinMarla"].ToString();//cmbPlotSize.Items.IndexOf(ds.Tables[0].Rows[0]["PlotSize"].ToString());
                    cmbPlotSize.Text = ds.Tables[0].Rows[0]["PlotSize"].ToString(); //cmbPlotSize.Items.IndexOf(ds.Tables[0].Rows[0]["PlotSize"].ToString());
                    txtActualMarlaSize.Text = ds.Tables[0].Rows[0]["ActualSizeinMarla"].ToString();
                    decimal MarlaConvertDigit = decimal.Parse(txtActualMarlaSize.Text.Replace(" Marla", ""));
                    decimal SqftNumber = MarlaConvertDigit * 25;
                    txtSqft.Text = SqftNumber.ToString();
                    lblMemberShipID.Text = ds.Tables[0].Rows[0]["MembershipID"].ToString();
                    lblFileMapKey.Text = ds.Tables[0].Rows[0]["FileMapKey"].ToString();
                    txtfileno.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                    txtPlotNo.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();
                    lbllastFileName.Text = txtfileno.Text.Trim();

                }
                else
                {
                    MessageBox.Show("No record found", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                string BusinessType = txtfileno.Text.Contains("RES") == true ? "RES" : "COM";
                ChallanHeaderBinding(cmbChallanHeader, BusinessType);
            }

        }

        DataTable sampleDataTable = new DataTable();
        private void cmbChallanHeader_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbChallanHeader.SelectedIndex < 0)
                return;
            if (string.IsNullOrWhiteSpace(cmbPlotSize.Text))
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

        #region Challan Header Detail Binding Parm( PLotSize, Header Value)
        List<ChallanDetail> ChallanDetaills = new List<ChallanDetail>();
        private void ChallanHeaderDetailsBinding(RadDropDownList drp_lst)
        {
            drp_lst.Items.Clear();
            RadListDataItem select = new RadListDataItem();
            SqlParameter[] prm =
            {
                new SqlParameter("@Task","fillChallanHeaderDetailTBBC"),
                new SqlParameter("@FileMapKey", cmbChallanHeader.SelectedValue)
            };

            DataTable dt = cls_dl_Challan.Challan_Reader(prm).Tables[0];
            List<ChallanDetail> ls = new List<ChallanDetail>();
            ls = ConvertDataTable<ChallanDetail>(dt);
            ChallanDetaills = ls;
            string PlotSizeinMarla = txtActualMarlaSize.Text.Replace(" Marla", "");
            decimal PlotSizeNumber = decimal.Parse(PlotSizeinMarla);
            decimal PlotSizesqft = decimal.Parse(txtSqft.Text);
            foreach (ChallanDetail item in ls)
            {
                if (item.TypeSize == "Per-Marla")
                {
                    decimal ToSize = item.ToSize == 0 ? 999999 : item.ToSize;
                    if (item.FromSize <= PlotSizeNumber && PlotSizeNumber <= ToSize)
                    {
                        if (item.CalculationType=="Fixed")
                        {
                            RadListDataItem dataItem = new RadListDataItem();
                            dataItem.Value = item.ParDetID.ToString();
                            dataItem.Text = item.Particular.ToString();
                            dataItem.Tag = item.CDAmount.ToString();
                            drp_lst.Items.Add(dataItem);
                        }
                        else if (item.CalculationType== "Multiply")
                        {
                            RadListDataItem dataItem = new RadListDataItem();
                            dataItem.Value = item.ParDetID.ToString();
                            dataItem.Text = item.Particular.ToString();
                            decimal amount = PlotSizeNumber * item.CDAmount;
                            dataItem.Tag = amount.ToString();
                            drp_lst.Items.Add(dataItem);
                        }
                        else
                        {
                            RadListDataItem dataItem = new RadListDataItem();
                            dataItem.Value = item.ParDetID.ToString();
                            dataItem.Text = item.Particular.ToString();
                            dataItem.Tag = item.CDAmount.ToString();
                            drp_lst.Items.Add(dataItem);
                        }
                    }
                }
                if (item.TypeSize == "Per-Sqft")
                {
                    decimal ToSize = item.ToSize == 0 ? 999999 : item.ToSize;
                    if (item.FromSize <= PlotSizesqft && PlotSizesqft <= ToSize)
                    {
                        if (item.CalculationType == "Fixed")
                        {
                            RadListDataItem dataItem = new RadListDataItem();
                            dataItem.Value = item.ParDetID.ToString();
                            dataItem.Text = item.Particular.ToString();
                            dataItem.Tag = item.CDAmount.ToString();
                            drp_lst.Items.Add(dataItem);
                        }
                        else if (item.CalculationType == "Multiply")
                        {
                            RadListDataItem dataItem = new RadListDataItem();
                            dataItem.Value = item.ParDetID.ToString();
                            dataItem.Text = item.Particular.ToString();
                            decimal amount = PlotSizesqft * item.CDAmount;
                            dataItem.Tag = amount.ToString();
                            drp_lst.Items.Add(dataItem);
                        }
                        else
                        {
                            RadListDataItem dataItem = new RadListDataItem();
                            dataItem.Value = item.ParDetID.ToString();
                            dataItem.Text = item.Particular.ToString();
                            dataItem.Tag = item.CDAmount.ToString();
                            drp_lst.Items.Add(dataItem);
                        }
                    }
                }
                if (item.TypeSize == "All")
                {
                    RadListDataItem dataItem = new RadListDataItem();
                    dataItem.Value = item.ParDetID.ToString();
                    dataItem.Text = item.Particular.ToString();
                    dataItem.Tag = item.CDAmount.ToString();
                    drp_lst.Items.Add(dataItem);
                }

            }

            //foreach (DataRow row in cls_dl_Challan.Challan_Reader(prm).Tables[0].Rows)
            //{
            //    RadListDataItem dataItem = new RadListDataItem();
            //    dataItem.Value = row["ParDetID"].ToString();
            //    dataItem.Text = row["ChallanParticlar"].ToString();
            //    dataItem.Tag = row["CDAmount"].ToString();
            //    drp_lst.Items.Add(dataItem);
            //}
            drp_lst.SelectedIndex = -1;
        }
        #endregion

        private void cmbChallanHeDetail_ItemCheckedChanged(object sender, RadCheckedListDataItemEventArgs e)
        {
            RadCheckedListDataItem checkeditem = e.Item;
            if (checkeditem.Checked == true)
            {
                if (checkeditem.Value == null)
                    return;
                DataRow[] foundAuthors = sampleDataTable.Select("ID = '" + checkeditem.Value + "'");
                if (foundAuthors.Length != 0)
                {
                    return;
                }
                DataRow sampleDataRow;
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
                lblOther.Text = ChallanDetaills.Where(x => x.Particular.Contains(checkeditem.Text)).FirstOrDefault().Other;
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
        private void dgvChallanDetails_CellBeginEdit(object sender, GridViewCellCancelEventArgs e)
        {
            if (!(e.Row is GridViewNewRowInfo) && e.Row.Cells[4].Value.ToString() != "True")
            {
                e.Cancel = true;
            }
        }
        private static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }
        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
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
                using (SqlConnection Objcon = Helper.SQLHelper.createConnection())
                {

                    using (SqlTransaction sqlTrans = Objcon.BeginTransaction("TB_BC-ChallanProcess"))
                    {
                        try
                        {

                        #region Challan Generation
                        string amount_in_word = Helper.clsPluginHelper.Convert_Number_To_Text(TotalAmount, false);
                        SqlParameter param_out_ID = new SqlParameter()
                        {
                            ParameterName = "@ChallanIDOutput",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };
                            int ChallanIDOut = 0;
                            if (TotalAmount > 0)
                            {
                                // Insert / Update Record of Challan
                                string Task = "";
                                if (string.IsNullOrEmpty(lblChalanID.Text.Replace("-","")))
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
                                    new SqlParameter("@PropertyDealerID",null),
                                    new SqlParameter("@ChallanGroup","TB-BC-Challan"),
                                    param_out_ID
                                };

                                SqlCommand result = SQLHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, "ch.USP_Challan", "", prm);/// cls_dl_Challan.ChallanExecuteNonQuery(prm);
                                if (result.Parameters.Count != 0)
                                {
                                    ChallanIDOut = int.Parse(result.Parameters["@ChallanIDOutput"].Value.ToString());
                                    //Insertion Of NextOfKin
                                    if (ChallanIDOut != 0)
                                    {
                                        foreach (DataRow checkeditems in sampleDataTable.Rows)
                                        {
                                            string ChallanType = "TB-BC-Challan";

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
                                            int resulte = SQLHelper.ExecuteNonQuery(sqlTrans, CommandType.StoredProcedure, "ch.USP_Challan", prm2); //cls_dl_Challan.Challan_ExecuteNonQuery(prm2);
                                        }
                                        sqlTrans.Commit();
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
                        else
                        {
                            MessageBox.Show("Total Amount of Challan is Zero Challan Cannot be Generate.");
                        }
                            #endregion

                        }
                        catch (Exception ex)
                        {
                            sqlTrans.Rollback();
                        }
                    }
                }
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
                    cmbPlotSize.Text = ds.Tables[0].Rows[0]["PlotSize"].ToString();
                    txtActualMarlaSize.Text = ds.Tables[0].Rows[0]["AcutalSize"].ToString();
                    decimal MarlaConvertDigit = decimal.Parse(txtActualMarlaSize.Text.Replace(" Marla", ""));
                    decimal SqftNumber = MarlaConvertDigit * 25;
                    txtSqft.Text = SqftNumber.ToString();
                    lblMemberShipID.Text = ds.Tables[0].Rows[0]["MemberID"].ToString();
                    lblFileMapKey.Text = ds.Tables[0].Rows[0]["FileMapKey"].ToString();
                    txtChallanNo.Text = ds.Tables[0].Rows[0]["ChalanNo"].ToString();
                    txtRemark.Text = ds.Tables[0].Rows[0]["Description"].ToString();
                    lbllastFileName.Text = txtfileno.Text.Trim();
                    txtCNICMask.Text = Helper.clsPluginHelper.DbNullIfNullOrEmpty(ds.Tables[0].Rows[0]["CNIC"].ToString()) == null ? null : ds.Tables[0].Rows[0]["CNIC"].ToString();

                    txtfileno.Text = ds.Tables[0].Rows[0]["FileNo"].ToString();
                    txtPlotNo.Text = ds.Tables[0].Rows[0]["PlotNo"].ToString();

                    cmbChallanType.SelectedText = ds.Tables[0].Rows[0]["ChallanType"].ToString();
                    cmbChallanType.SelectedIndex = 0;
                    ChallanDate.Text = ds.Tables[0].Rows[0]["ClearDate"].ToString();
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        sampleDataTable = ds.Tables[1];
                        dgvChallanDetails.DataSource = sampleDataTable.DefaultView;
                    }
                }
            }
        }
        #endregion

        private void txtfileno_Leave(object sender, EventArgs e)
        {
            if (FileActiveNotBlock() == true)
            {
               btnFind_Click(null, null);
            }
        }

        private void txtPlotNo_Leave(object sender, EventArgs e)
        {
            if (PlotActiveNotBlock() == true)
            {
                btnFind_Click(null, null);
            }
        }
    }

    public class ChallanDetail
    {
        public int ChlnParHeadID { get; set; }
        public string ChlnType { get; set; }
        public string BusinessType { get; set; }
        public int ParHe_ParDet_MapID { get; set; }
        public int ParDetID { get; set; }
        public string FeeType { get; set; }
        public string Particular { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string CalculationType { get; set; }
        public decimal FromSize { get; set; }
        public decimal ToSize { get; set; }
        public string TypeSize { get; set; }
        public decimal CDAmount { get; set; }
        public string Other { get; set; }

    }

}
