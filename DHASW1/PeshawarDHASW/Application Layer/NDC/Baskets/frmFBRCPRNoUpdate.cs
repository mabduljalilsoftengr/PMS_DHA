using PeshawarDHASW.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.NDC.Baskets
{
    public partial class frmFBRCPRNoUpdate : Telerik.WinControls.UI.RadForm
    {
        public frmFBRCPRNoUpdate()
        {
            InitializeComponent();
        }

        public frmFBRCPRNoUpdate(string CPRID,string CPRNo,string Nameowner,string Father,string Amount)
        {
            InitializeComponent();
            lblCPRID.Text = CPRID;
            txtCPRNo.Text = CPRNo;
            llbName.Text = Nameowner;
            lblFather.Text = Father;
            lblCPRAmount.Text = Amount;
        }

        private void frmFBRCPRNoUpdate_Load(object sender, EventArgs e)
        {

        }

        private void btnSavechanges_Click(object sender, EventArgs e)
        {
            try
            {


                if (string.IsNullOrWhiteSpace(txtCPRNo.Text))
                {
                    MessageBox.Show("CPR No Field is Mandatory.");
                    return;
                }


                if (MessageBox.Show(this,"Are you Sure","Warning",MessageBoxButtons.YesNo, MessageBoxIcon.Warning) ==DialogResult.Yes)
                {
                    if (txtCPRNo.Text != "NA")
                    {
                        Match m = Regex.Match(txtCPRNo.Text, @"IT-[0-9]{8}-[0-9]{4}-[0-9]{0,9}");
                        if (m.Success == false)
                        {
                            MessageBox.Show("CPR No Format [IT-20220101-0101-000000] Format is not Match.");
                            return;
                        }


                        SqlParameter[] param = {
                        new SqlParameter("@Task","CPRNoVerification"),
                        new SqlParameter("@CPRNO",txtCPRNo.Text)
                    };
                        DataSet ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(),
                            CommandType.StoredProcedure, "App.USP_NDC", param);
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                MessageBox.Show("CPR No is Already in Use.");
                                return;
                            }
                        }
                    }

                    SqlParameter[] cprnoparamupdate = {
                        new SqlParameter("@Task","CPRNoUpdate"),
                        new SqlParameter("@FBRSBCPRID",lblCPRID.Text),
                        new SqlParameter("@CPRNO",txtCPRNo.Text),
                        new SqlParameter("@userID",clsUser.ID)
                    };
                    int result = Helper.SQLHelper.ExecuteNonQuery(Helper.SQLHelper.createConnection(),
                          CommandType.StoredProcedure, "App.USP_NDC", cprnoparamupdate);
                    if (result > 0)
                    {
                        this.Close();
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
