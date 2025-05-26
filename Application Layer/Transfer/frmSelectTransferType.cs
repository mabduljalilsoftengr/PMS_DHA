using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Application_Layer.Transfer.TFRType;
using Telerik.WinControls;
using PeshawarDHASW.Data_Layer.Owner;
using System.Data.SqlClient;
using PeshawarDHASW.Data_Layer;
using Telerik.WinControls.UI;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Transfer
{
    public partial class frmSelectTransferType : Telerik.WinControls.UI.RadForm
    {
        public frmSelectTransferType()
        {
            InitializeComponent();
        }

        public string passFileNo { get; set; }
        public int passChallanNO { get; set; }
        public int passNDCNumber { get; set; }
        public int TFRAppID { get; set; }
        public frmSelectTransferType(string FileNo,int ChallnNO, int NDCNo ,int get_TFRappID)
        {
            passNDCNumber = NDCNo;
            passFileNo = FileNo;
            passChallanNO = ChallnNO;
            TFRAppID = get_TFRappID;
            InitializeComponent();
        }
        private void btnTFRTypeSelect_Click(object sender, EventArgs e)
        {
            try
            {
                //One Seller to One Buyer Transfer
                if (raddpTFRType.SelectedIndex != -1)
                {
                    RadListDataItem Select = raddpTFRType.SelectedItem;
                    int TFRTypeID = 0;
                    bool TFRCheck = int.TryParse(Select.Value.ToString(), out TFRTypeID);
                    if (TFRCheck)
                    {
                        this.Hide();
                        frmTFRType obj = new frmTFRType(passFileNo, passChallanNO, passNDCNumber, TFRTypeID, TFRAppID);
                        obj.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Selection");
                    }
                }
                else
                {
                    MessageBox.Show("Select Any Option in DropDown.");
                }


                //this.Close();
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnTFRTypeSelect_Click.", ex, "frmSelectTransferType");
                frmobj.ShowDialog();
            }
           
        }

        private void raddpTFRType_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {

        }

        private void frmSelectTransferType_Load(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parmt =
                {
                new SqlParameter("@Task","Select")
                };
                DataSet dds = new DataSet();
                dds = cls_dl_TypeofPurchase.TypeofPurchase_Reader(parmt);
                raddpTFRType.DataSource = dds.Tables[0].DefaultView;
                raddpTFRType.DisplayMember = "Name";
                raddpTFRType.ValueMember = "TypeID";
                RadListDataItem Select = new RadListDataItem();
                Select.Value = 0;
                Select.Text = "-- Select Transfer Type --";
                this.raddpTFRType.Items.Add(Select);
                Helper.clsPluginHelper.RadDropDownSelectByText(raddpTFRType, "-- Select--");
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmSelectTransferType_Load.", ex, "frmSelectTransferType");
                frmobj.ShowDialog();
            }
           
        }
    }
}
