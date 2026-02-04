using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsForm;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer.CustomDialog;

namespace PeshawarDHASW.Application_Layer.Role_Form
{
    public partial class frmFormControl : Telerik.WinControls.UI.RadForm
    {
        public frmFormControl()
        {
            InitializeComponent();
        }

        private void btnSaveForm_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameters =
                        {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@Form",txtForm.Text),
                new SqlParameter("@Description",txtDescription.Text),
                new SqlParameter("@Type","Tab"),
                new SqlParameter("@Staus",dpStatus.SelectedItem.ToString()),
            };

                int result = cls_dl_Form.Form_NonQuery(parameters);
                if (result > 0)
                {
                    Clearfunction();
                }
                else
                {
                    MessageBox.Show("Contact to Adminstration.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on grdOwnerdata_CellClick.", ex, "frmFormControl");
                frmobj.ShowDialog();
            }
        
        }

        private void Clearfunction()
        {
            //Tab
            txtForm.Text = "";
            txtDescription.Text = "";
            dpStatus.SelectedIndex = 0;
            //Group Box
            txtGroupBoxName.Text = "";
            dpGroupBoxStatus.SelectedIndex = 0;
            tabDropDownList.SelectedIndex = 0;
            //Button
        }

        private void frmFormControl_Load(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parametertab =
                          {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@Type","Tab"),
            };
                DataSet ds = cls_dl_Form.Form_Reader(parametertab);
                gvtab.DataSource = ds.Tables[0].DefaultView;

                tabDropDownList.DataSource = ds.Tables[0].DefaultView;
                tabDropDownList.DisplayMember = "Form";
                tabDropDownList.ValueMember = "FID";


                SqlParameter[] parameterGroup =
                {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@Type","Group"),
            };
                DataSet dsGroup = cls_dl_Form.Form_Reader(parameterGroup);
                gvGroupBox.DataSource = dsGroup.Tables[0].DefaultView;

                dpButtonGroup.DataSource = dsGroup.Tables[0].DefaultView;
                dpButtonGroup.DisplayMember = "Form";
                dpButtonGroup.ValueMember = "FID";

                SqlParameter[] parameterButton =
                {
                new SqlParameter("@Task","Select"),
                new SqlParameter("@Type","Button"),
            };
                DataSet dsButton = cls_dl_Form.Form_Reader(parameterButton);
                gvButtonControls.DataSource = dsButton.Tables[0].DefaultView;
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on frmFormControl_Load.", ex, "frmFormControl");
                frmobj.ShowDialog();
            }


        }

        private void Update(int FID, string Form, string Description, string Type, string Status)
        {
            try
            {
                SqlParameter[] parameters =
                           {
                new SqlParameter("@Task","Update"),
                new SqlParameter("@FID",FID),
                new SqlParameter("@Form",Form),
                new SqlParameter("@Description",Description),
                new SqlParameter("@Type",Type),
                new SqlParameter("@Staus",Status)
            };
                int result = cls_dl_Form.Form_NonQuery(parameters);
                if (result > 0)
                {
                    Clearfunction();
                }
                else
                {
                    MessageBox.Show("Check to database.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on Update.", ex, "frmFormControl");
                frmobj.ShowDialog();
            }
        }

        private void BtnGroupBoxSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameters =
                           {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@Form",txtGroupBoxName.Text),
                new SqlParameter("@Description",tabDropDownList.SelectedItem.ToString()+"-"+tabDropDownList.SelectedItem.Value.ToString()),
                new SqlParameter("@Type","Group"),
                new SqlParameter("@Staus",dpGroupBoxStatus.SelectedItem.ToString()),
            };

                int result = cls_dl_Form.Form_NonQuery(parameters);
                if (result > 0)
                {
                    Clearfunction();
                }
                else
                {
                    MessageBox.Show("Contact to Adminstration.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on BtnGroupBoxSave_Click.", ex, "frmFormControl");
                frmobj.ShowDialog();
            }
        }

        private void btnButtonSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlParameter[] parameters =
                          {
                new SqlParameter("@Task","Insert"),
                new SqlParameter("@Form",txtbuttoncontrols.Text),
                new SqlParameter("@Description",dpButtonGroup.SelectedItem.ToString()+"-"+dpButtonGroup.SelectedItem.Value.ToString()),
                new SqlParameter("@Type","Button"),
                new SqlParameter("@Staus",dpButtonstatus.SelectedItem.ToString()),
            };

                int result = cls_dl_Form.Form_NonQuery(parameters);
                if (result > 0)
                {
                    Clearfunction();
                }
                else
                {
                    MessageBox.Show("Contact to Adminstration.");
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on btnButtonSave_Click.", ex, "frmFormControl");
                frmobj.ShowDialog();
            }
        }

        private void gvtab_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
               

                if (e.Column.Name == "Edit")
                {
                    int ID = 0;
                    bool M = int.TryParse(gvtab.CurrentRow.Cells[0].Value.ToString(), out ID);
                    if (M != false)
                    {
                        string Form = gvtab.CurrentRow.Cells[1].Value.ToString();
                        string Description = gvtab.CurrentRow.Cells[2].Value.ToString();
                        string Type = gvtab.CurrentRow.Cells[3].Value.ToString();
                        string Status = gvtab.CurrentRow.Cells[4].Value.ToString();
                        Update(ID, Form, Description, Type, Status);
                        frmFormControl_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Record Not Found is not exist");
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on gvtab_CellClick.", ex, "frmFormControl");
                frmobj.ShowDialog();
            }
        }

        private void gvGroupBox_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
              

                if (e.Column.Name == "Edit")
                {
                    int ID = 0;
                    bool M = int.TryParse(gvGroupBox.CurrentRow.Cells[0].Value.ToString(), out ID);
                    if (M != false)
                    {
                        string Form = gvGroupBox.CurrentRow.Cells[1].Value.ToString();
                        string Description = gvGroupBox.CurrentRow.Cells[2].Value.ToString();
                        string Type = gvGroupBox.CurrentRow.Cells[3].Value.ToString();
                        string Status = gvGroupBox.CurrentRow.Cells[4].Value.ToString();
                        Update(ID, Form, Description, Type, Status);
                        frmFormControl_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Record Not Found is not exist");
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on gvGroupBox_CellClick.", ex, "frmFormControl");
                frmobj.ShowDialog();
            }
        }

        private void gvButtonControls_CellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            try
            {
                

                if (e.Column.Name == "Edit")
                {
                    int ID = 0;
                    bool M = int.TryParse(gvButtonControls.CurrentRow.Cells[0].Value.ToString(), out ID);
                    if (M != false)
                    {
                        string Form = gvButtonControls.CurrentRow.Cells[1].Value.ToString();
                        string Description = gvButtonControls.CurrentRow.Cells[2].Value.ToString();
                        string Type = gvButtonControls.CurrentRow.Cells[3].Value.ToString();
                        string Status = gvButtonControls.CurrentRow.Cells[4].Value.ToString();
                       Update(ID, Form, Description, Type, Status);
                       frmFormControl_Load(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Record Not Found is not exist");
                    }
                }
            }
            catch (Exception ex)
            {
                frmExceptionCatched frmobj = new frmExceptionCatched("Exception is through on gvButtonControls_CellClick.", ex, "frmFormControl");
                frmobj.ShowDialog();
            }
        }
    }
}
