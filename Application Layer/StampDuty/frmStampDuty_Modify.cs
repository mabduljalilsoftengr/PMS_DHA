using PeshawarDHASW.Data_Layer.clsStampDuty;
using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.StampDuty
{
    public partial class frmStampDuty_Modify : Telerik.WinControls.UI.RadForm
    {
        public frmStampDuty_Modify()
        {
            InitializeComponent();
        }
        public frmStampDuty_Modify(int stmid)
        {
            InitializeComponent();
            LoadData(stmid);
        }

        private void btn_Find_Click(object sender, EventArgs e)
        {
            //LoadData();
        }
        private void LoadData( int StampDuty_ID)
        {
            SqlParameter[] prm =
            {
              new SqlParameter("@Task","StampDuty_Modification"),
              new SqlParameter("@StmpDuty_ID",StampDuty_ID),
              //new SqlParameter("@RefNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtReferenceNo.Text)),
              //new SqlParameter("@Name",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtName.Text)),
              //new SqlParameter("@CNIC",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtCNIC.Text)),
              //new SqlParameter("@MembershipNo",Helper.clsPluginHelper.DbNullIfNullOrEmpty(txtMSNo.Text)),
            };
            DataSet dst = new DataSet();
            dst = cls_dl_StampDuty.StampDuty_Reader(prm);
            grd_StampDuty_Data.DataSource = dst.Tables[0].DefaultView;
            grd_stamp_duty_seller_buyer.DataSource = dst.Tables[1].DefaultView;
        }

        private void frmStampDuty_Modify_Load(object sender, EventArgs e)
        {
           // LoadData();
        }

        private void grd_StampDuty_Data_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
          if(e.Column.Name == "Modify_StampDuty")
          {
               int rowno =  grd_StampDuty_Data.CurrentRow.Index;
                SqlParameter[] prm =
                {
                    new SqlParameter("@Task","Update_Stamp_Duty"),
                    new SqlParameter("@StmpDuty_ID",int.Parse(e.Row.Cells["StmpDuty_ID"].Value.ToString())),
                    new SqlParameter("@RefNo",e.Row.Cells["RefNo"].Value.ToString()),
                    new SqlParameter("@FileNo",e.Row.Cells["FileNo"].Value.ToString()),
                    new SqlParameter("@Type",e.Row.Cells["Type"].Value.ToString()),
                    new SqlParameter("@Amount",e.Row.Cells["Amount"].Value.ToString()),
                    new SqlParameter("@Amount_In_Words",e.Row.Cells["Amount_In_Words"].Value.ToString()),
                    new SqlParameter("@Remarks",e.Row.Cells["Remarks"].Value.ToString()),
                    new SqlParameter("@Status", e.Row.Cells["Status"].Value.ToString()),
                    new SqlParameter("@Stm_Generation_Date",DateTime.Parse(e.Row.Cells["Stm_Generation_Date"].Value.ToString())),
                    new SqlParameter("@Stm_Deposite_Date",DateTime.Parse(e.Row.Cells["Stm_Deposite_Date"].Value.ToString())),
                    new SqlParameter("@user_ID",Models.clsUser.ID)
                };
                int rslt = cls_dl_StampDuty.StampDuty_NonQuery(prm);
                if(rslt > 0)
                {
                    RadMessageBox.Show("Updation is Successfull.");
                }                
            }
            else if (e.Column.Name == "Make_Report")
            {
                //int rowindx = grd_StampDuty_Data.CurrentRow.Index;
                int stmp_duty_id = int.Parse(e.Row.Cells["StmpDuty_ID"].Value.ToString());
                if(stmp_duty_id > 0)
                {
                    SqlParameter[] prm =
                    {
                        new SqlParameter("@Task","Retrive_Stamp_Duty_Data_For_Report"),
                        new SqlParameter("@StmpDuty_ID",stmp_duty_id)
                    };
                    DataSet dst = new DataSet();
                    dst = cls_dl_StampDuty.StampDuty_Reader(prm);
                    dst.Tables[0].Columns.Add(new DataColumn("UserName", typeof(string)));
                    string username = dst.Tables[0].Rows[0]["userName"].ToString(); 
                    foreach (DataRow dr in dst.Tables[0].Rows)
                    {
                        dr["UserName"] = username;
                    }
                    if (dst.Tables.Count > 0)
                    {
                        frmStampDuty_Report_Viewer frmobj = new frmStampDuty_Report_Viewer(dst);
                        frmobj.ShowDialog();
                    }
                }               
            }
        }

        private void grd_stamp_duty_seller_buyer_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.Name == "Modify_Stmp_Duty_Seller_Buyer")
            {
                int rowno = grd_stamp_duty_seller_buyer.CurrentRow.Index;
                if ("Seller" == grd_stamp_duty_seller_buyer.Rows[rowno].Cells[1].Value.ToString())
                {
                    MessageBox.Show("The Seller Information is also incorrect in"+Environment.NewLine+
                                    "Transfer Branch data, So please Modify the" + Environment.NewLine +
                                    "Seller record in Transfer Branch Data also.","Attention!",MessageBoxButtons.OK
                                    ,MessageBoxIcon.Warning);

                }
                //else
                //{
                    SqlParameter[] prm =
                    {
                    new SqlParameter("@Task","Update_Stamp_DUty_Buyer_seller"),
                    new SqlParameter("@StampDuty_BUyer_Seller_ID",int.Parse(grd_stamp_duty_seller_buyer.Rows[rowno].Cells["Stm_Dt_SellerBuyer_ID"].Value.ToString())),
                    new SqlParameter("@Type",grd_stamp_duty_seller_buyer.Rows[rowno].Cells["Type"].Value.ToString()),
                    new SqlParameter("@Name",grd_stamp_duty_seller_buyer.Rows[rowno].Cells["Name"].Value.ToString()),
                    new SqlParameter("@CNIC",grd_stamp_duty_seller_buyer.Rows[rowno].Cells["CNIC"].Value.ToString()),
                    //new SqlParameter("@FileNo",grd_stamp_duty_seller_buyer.Rows[rowno].Cells[4].Value.ToString()),
                    new SqlParameter("@MembershipNo",grd_stamp_duty_seller_buyer.Rows[rowno].Cells["MembershipNo"].Value.ToString()),
                    new SqlParameter("@StmpDuty_ID",grd_stamp_duty_seller_buyer.Rows[rowno].Cells["StampDuty_ID"].Value.ToString()),
                    };
                    int rslt = cls_dl_StampDuty.StampDuty_NonQuery(prm);
                    if (rslt > 0)
                    {
                        RadMessageBox.Show("Updation is Successfull.");
                        this.Close();
                        
                    }
                //}
                
            }
        }

        private void grd_StampDuty_Data_CellEndEdit(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if(e.Column.Name == "Amount")
            {
                int rowind = grd_StampDuty_Data.CurrentRow.Index;
                int amount = int.Parse(grd_StampDuty_Data.ChildRows[rowind].Cells["Amount"].Value.ToString()); 
                int stmp_dty_ID = int.Parse(grd_StampDuty_Data.ChildRows[rowind].Cells["StmpDuty_ID"].Value.ToString());
                string amount_in_word = Helper.clsPluginHelper.Convert_Number_To_Text(amount,false);
                grd_StampDuty_Data.ChildRows[rowind].Cells["Amount_In_Words"].Value = amount_in_word;
                //SqlParameter[] prm =
                //{
                //    new SqlParameter("@Task","Update_Amount_In_Words"),
                //    new SqlParameter("@Amount_In_Words",amount_in_word),
                //    new SqlParameter("@StmpDuty_ID",stmp_dty_ID)
                //};
                //int rslt = cls_dl_StampDuty.StampDuty_NonQuery(prm);
                //if(rslt > 0)
                //{
                //    //LoadData();
                //}
            }
        }
    }
}
