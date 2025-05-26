using PeshawarDHASW.Application_Layer.Owner.FirstTimeOwnerCreation.MultiOwnerCreation;
using PeshawarDHASW.Application_Layer.Owner.FirstTimeOwnerCreation.SingleOwnerCreation;
using PeshawarDHASW.Data_Layer.Owner;
using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsOwnerType;
using PeshawarDHASW.Data_Layer.clsTypeofPruchase;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.Owner.FirstTimeOwnerCreation
{
    public partial class frmFileVerification : Telerik.WinControls.UI.RadForm
    {
        public frmFileVerification()
        {
            InitializeComponent();
        }
        public string FileNO { get; set; }
        
        private void btnFileVerification_Click(object sender, EventArgs e)
        {
            if (txtFileNumber.Text != "")
            {
                SqlParameter[] parameterofSingle =
                {
                new SqlParameter("@Task","FileNumberVerification"),
                new SqlParameter("@Fileno",txtFileNumber.Text),
                new SqlParameter("@tfrID","1")
            };
                DataSet dsforSingle = new DataSet();
                dsforSingle = cls_dl_Owner.Owner_Reader(parameterofSingle);
                int countforSingle = int.Parse(dsforSingle.Tables[0].Rows[0]["Owner"].ToString());
                SqlParameter[] parameterforMultiple =
              {
                new SqlParameter("@Task","FileNumberVerification"),
                new SqlParameter("@Fileno",txtFileNumber.Text),
                new SqlParameter("@tfrID","2")
            };
                DataSet dsforMultipe = new DataSet();
                dsforMultipe = cls_dl_Owner.Owner_Reader(parameterforMultiple);
                int countforMultiple = int.Parse(dsforMultipe.Tables[0].Rows[0]["Owner"].ToString());
                if (countforSingle != 0)
                {
                    lblDescription.Visible = true;
                    //lblDescription1.Visible = true;
                    lblDescription.Text = "This File NO is already in use ";
                    //lblDescription1.Text = "So Select Owner Type From Below";
                }
                else if (countforSingle == 0 && countforMultiple == 1)
                {
                    MessageBox.Show("This FileNo use for Multiple Owners,But you Don't Complete all Owner, So Please Enter AllOwners Data.");
                    this.Hide();
                    FileNO = txtFileNumber.Text;
                    frmMultiOwnerCreate frmmult = new frmMultiOwnerCreate(FileNO,2);
                    frmmult.ShowDialog();
                }
                else if (countforSingle == 0 && countforMultiple == 0)
                {
                    lblDescription.Visible = true;
                    lblDescription1.Visible = true;
                    lblDescription.Text = "This File NO is Don't Allocated to any Owner.";
                    lblDescription1.Text = "So Select Owner Type From Below.";
                    ddlOwnerType.Visible = true;
                }
                else if (countforSingle == 0 && countforMultiple > 1)
                {
                    lblDescription.Visible = true;
                    //lblDescription1.Visible = true;
                    lblDescription.Text = "This File NO Allocation is Completed.";
                    //lblDescription1.Text = "So Select Owner Type From Below";
                }
            }
            else
            {
                MessageBox.Show("Please Enter FileNO !");
            }
        }

        private void frmFileVerification_Load(object sender, EventArgs e)
        {
            BindTypeOfOwnerData();
           
        }
        private void BindTypeOfOwnerData()
        {
            RadListDataItem Select = new RadListDataItem();
            Select.Value = 0;
            Select.Text = "-- Select Owner Type --";
            this.ddlOwnerType.Items.Add(Select);
            SqlParameter[] param =
            {
             new SqlParameter("@Task","SelectTop2TransferType_NewOwner")
            };
            DataSet ds = new DataSet();
            ds = cls_dl_TransferType.TypeofTansfer_Reader(param);
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                RadListDataItem dataItem = new RadListDataItem();
                dataItem.Value = row["TypeID"].ToString();
                dataItem.Text = row["Name"].ToString();
                this.ddlOwnerType.Items.Add(dataItem);
            }
            
        }

        private void ddlOwnerType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            FileNO = txtFileNumber.Text;
            if (ddlOwnerType.SelectedIndex == 1)
            {
                this.Hide();
                SingleOwnerCreate objsngl = new SingleOwnerCreate(FileNO,1);
                objsngl.ShowDialog();
            }
            else if(ddlOwnerType.SelectedIndex == 2)
            {
                this.Hide();
                frmMultiOwnerCreate objmulti = new frmMultiOwnerCreate(FileNO, 2);
                objmulti.ShowDialog();
            }
        }
    }
}
