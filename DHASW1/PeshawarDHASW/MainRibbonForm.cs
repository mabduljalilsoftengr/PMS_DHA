using PeshawarDHASW.Application_Layer;
using PeshawarDHASW.Application_Layer.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using PeshawarDHASW.Application_Layer.Basket;
using PeshawarDHASW.Application_Layer.Chalan;
using PeshawarDHASW.Application_Layer.ChallanRece;
using PeshawarDHASW.Application_Layer.DBError;
using PeshawarDHASW.Application_Layer.FileMap;
using PeshawarDHASW.Application_Layer.Installment.DDTransfer;
using PeshawarDHASW.Application_Layer.Installment.InstReceive;
using PeshawarDHASW.Application_Layer.Logging;
using PeshawarDHASW.Application_Layer.Membership;
using PeshawarDHASW.Application_Layer.Membership.MSDataVerify;
using PeshawarDHASW.Application_Layer.NDC;
using PeshawarDHASW.Application_Layer.NDC.Baskets;
using PeshawarDHASW.Application_Layer.NDC.NDC_CheckList;
using PeshawarDHASW.Application_Layer.Role_Form;
using PeshawarDHASW.Application_Layer.SystemError;
using PeshawarDHASW.Application_Layer.Transfer;
using PeshawarDHASW.Data_Layer.clsRole;
using PeshawarDHASW.Data_Layer.clsUser;
using PeshawarDHASW.Models;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Docking;
using PeshawarDHASW.Application_Layer.User;
using PeshawarDHASW.Application_Layer.Installment.InstRece_Lock;
using PeshawarDHASW.Application_Layer.FileMap.FileCancelationProcess;
using PeshawarDHASW.Application_Layer.Caution;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Application_Layer.Membership.MSViewInfo;

namespace PeshawarDHASW
{
    public partial class MainRibbonForm : Telerik.WinControls.UI.RadRibbonForm
    {
        public MainRibbonForm()
        {

            InitializeComponent();
            radDock1.MainDocumentContainer.SplitPanelElement.Fill.BackColor = Color.White;
            radDock1.MainDocumentContainer.SplitPanelElement.Fill.GradientStyle = GradientStyles.Solid;
            //    DockWindow activeDocument = this.radDock1.DocumentManager.ActiveDocument; //documentWindow2
            //     DockWindow activeWindow = this.radDock1.ActiveWindow;
           
               
          
        }




        #region Rabbion From Load

        private void rolebaselogin()
        {
            try
            {

        
            //ContorlCounter();
            SqlParameter[] Tabparameters =
            {
                new SqlParameter("@Task","Tab"),
                new SqlParameter("@userID", clsUser.ID)
            };
            DataTable Tabdt = clsRoles.UserBaseControl(Tabparameters);

            SqlParameter[] Groupparameters =
           {
                new SqlParameter("@Task","Group"),
                new SqlParameter("@userID", clsUser.ID)
            };
            DataTable Groupdt = clsRoles.UserBaseControl(Groupparameters);

            SqlParameter[] Buttonparameters =
           {
                new SqlParameter("@Task","Button"),
                new SqlParameter("@userID", clsUser.ID)
            };
            DataTable Buttondt = clsRoles.UserBaseControl(Buttonparameters);
                SqlParameter[] Reportparameters =
                {
                new SqlParameter("@Task","Report"),
                new SqlParameter("@userID", clsUser.ID)
                };
                DataTable Reportdt = clsRoles.UserBaseControl(Reportparameters);
                clsMostUseVars.ReportDs = Reportdt;
                //load all the control from the button group in ribbon
                int total = Tabdt.Rows.Count + Groupdt.Rows.Count + Buttondt.Rows.Count;
            if (total > 0)
            {
                #region Tab 
                foreach (Telerik.WinControls.UI.RibbonTab crtl in radmainRibbon.CommandTabs)
                {
                    crtl.Enabled = false;
                    crtl.Visibility = ElementVisibility.Collapsed;
                    foreach (DataRow row in Tabdt.Rows)
                    {
                        if (crtl.AccessibleDescription == row["ControlName"].ToString().Trim())
                        {
                            crtl.Enabled = true;
                            crtl.Visibility = ElementVisibility.Visible;
                            foreach (Telerik.WinControls.UI.RadRibbonBarGroup group in crtl.Items)
                            {
                                group.Enabled = false;
                                group.Visibility = ElementVisibility.Collapsed;
                                foreach (DataRow gprow in Groupdt.Rows)
                                {
                                    string replacement1 = Regex.Replace(gprow["ControlName"].ToString().Trim(), @"\t|\n|\r", "");
                                    if (group.AccessibleDescription == replacement1)
                                    {
                                        group.Enabled = true;
                                        group.Visibility = ElementVisibility.Visible;

                                        //Telerik.WinControls.UI.RadButtonElement
                                        foreach (var Button in group.Items)
                                        {
                                            Button.Enabled = false;
                                            Button.Visibility = ElementVisibility.Collapsed;
                                            foreach (DataRow btnrow in Buttondt.Rows)
                                            {
                                                string replacement = Regex.Replace(btnrow["ControlName"].ToString().Trim(), @"\t|\n|\r", "");
                                                    //if(replacement== "btn_instPlanEdit")
                                                    //{
                                                    //    MessageBox.Show("Button name: -> ", replacement);
                                                    //}

                                           if (Button.AccessibleDescription == replacement)
                                                {
                                                        

                                                    Button.Enabled = true;
                                                    Button.Visibility = ElementVisibility.Visible;
                                                    //MessageBox.Show("Button Active -> "+Button.Text);
                                                }
                                                else
                                                {
                                                    //MessageBox.Show(btnrow["Form"].ToString());
                                                }

                                            }
                                        }
                                    }
                                }
                            }


                        }

                    }
                }
                #endregion
            }
            else
            {
                radmainRibbon.Visible = false;
                MessageBox.Show("You don't have any access to the system. Kindly contact to the System Administrator.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                Application.Restart();
            }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Fail");
                this.Close();
            }

        }
        private void MainRibbonForm_Load(object sender, EventArgs e)
        {

            this.Text = "PMS Version " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            username.Text = clsUser.Name;
            rolebaselogin();
            lblusername.Text = clsUser.Name;
            if (clsUser.ThemeName == String.Empty)
            {
                ApplyTheme("TelerikMetro");
            }
            else
            {
                ApplyTheme(clsUser.ThemeName);
            }

        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Refresh();
        }
        #endregion

        #region Registration Form

        Application_Layer.Launching.EnterNewApplication  appliationregistrationobj;

        private void btnRegistration_Click_1(object sender, EventArgs e)
        {
            if (appliationregistrationobj == null)
            {
                appliationregistrationobj = new Application_Layer.Launching.EnterNewApplication();
                appliationregistrationobj.MdiParent = this;
                appliationregistrationobj.WindowState = FormWindowState.Maximized;
                appliationregistrationobj.FormClosed += appliationregistrationobj_FormClosed;
                radDock1.ActivateMdiChild(appliationregistrationobj);
                appliationregistrationobj.Show();
            }
            else
            {
                appliationregistrationobj.BringToFront();
            }
        }
        void appliationregistrationobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            appliationregistrationobj = null;
        }




       Application_Layer.Launching.ApplicationObservation_L2  frmapplicationObsrobj;
        private void btnApplicationSearch_Click(object sender, EventArgs e)
        {
            if (frmapplicationObsrobj == null)
            {
                frmapplicationObsrobj = new Application_Layer.Launching.ApplicationObservation_L2();
                frmapplicationObsrobj.MdiParent = this;
                frmapplicationObsrobj.WindowState = FormWindowState.Maximized;
                frmapplicationObsrobj.FormClosed += FrmapplicationObsrobj_FormClosed;
                radDock1.ActivateMdiChild(frmapplicationObsrobj);
                frmapplicationObsrobj.Show();

            }
        }

        private void FrmapplicationObsrobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmapplicationObsrobj = null;
        }

        Application_Layer.Launching.ApplicaitonModificaiton frmapplicartionmodify;
        private void btnApplicationModify_Click(object sender, EventArgs e)
        {
            if (frmapplicartionmodify == null)
            {
                frmapplicartionmodify = new Application_Layer.Launching.ApplicaitonModificaiton();
                frmapplicartionmodify.MdiParent = this;
                frmapplicartionmodify.WindowState = FormWindowState.Maximized;
                frmapplicartionmodify.FormClosed += frmapplicartionmodify_FormClosed;
                radDock1.ActivateMdiChild(frmapplicartionmodify);
                frmapplicartionmodify.Show();

            }
            else
            {
                frmapplicartionmodify.Activate();
            }
        }

        void frmapplicartionmodify_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmapplicartionmodify = null;
        }

        private void MainRibbonForm_FormClosed(object sender, FormClosedEventArgs e)
        {

            Application.Exit();
        }
        #endregion

        #region Membership
        frmMembership frmMembershipobj;
        private void btnMBReg_Click(object sender, EventArgs e)
        {
            if (frmMembershipobj == null)
            {
                frmMembershipobj = new frmMembership();
                frmMembershipobj.MdiParent = this;
                frmMembershipobj.WindowState = FormWindowState.Maximized;
                frmMembershipobj.FormClosed += FrmMembershipobj_FormClosed1;
                radDock1.ActivateMdiChild(frmMembershipobj);
                frmMembershipobj.Show();
            }
            else
            {
                frmMembershipobj.Activate();
            }
        }

        private void FrmMembershipobj_FormClosed1(object sender, FormClosedEventArgs e)
        {
            frmMembershipobj = null;
        }



        #endregion

        #region Rad Ribbon Rough Work
        private void radRibbonBar1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        #region Membership Search
        private frmMembershipSearch obFrmMembershipSearch;
        private void mssearch_Click(object sender, EventArgs e)
        {
            if (obFrmMembershipSearch == null)
            {
                obFrmMembershipSearch = new frmMembershipSearch();
                obFrmMembershipSearch.MdiParent = this;
                obFrmMembershipSearch.WindowState = FormWindowState.Maximized;
                obFrmMembershipSearch.FormClosed += ObFrmMembershipSearch_FormClosed;
                radDock1.ActivateMdiChild(obFrmMembershipSearch);
                obFrmMembershipSearch.Show();
                var wnd = radDock1.ActiveWindow as HostWindow;
                var mdiForm = wnd.Content as Form;
            }
            else
            {
                obFrmMembershipSearch.Activate();
            }

        }

        private void ObFrmMembershipSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            obFrmMembershipSearch = null;
        }
        #endregion

        #region Membership Modify
        private frmMembershipModify objFrmMembershipModify;
        private void btnmodifymembeership_Click(object sender, EventArgs e)
        {
            if (objFrmMembershipModify == null)
            {
                objFrmMembershipModify = new frmMembershipModify();
                objFrmMembershipModify.MdiParent = this;
                objFrmMembershipModify.WindowState = FormWindowState.Maximized;
                objFrmMembershipModify.FormClosed += ObjFrmMembershipModify_FormClosed;
                radDock1.ActivateMdiChild(objFrmMembershipModify);
                objFrmMembershipModify.Show();
            }
            else
            {
                objFrmMembershipModify.Activate();
            }
        }

        private void ObjFrmMembershipModify_FormClosed(object sender, FormClosedEventArgs e)
        {
            objFrmMembershipModify = null;
        }
        #endregion

        #region Installment Template Create
        private Application_Layer.Installment.InstTemplate.InstTemplateCreate objInstTemplateCreate;
        private void radbtncreateinstemp_Click(object sender, EventArgs e)
        {
            if (objInstTemplateCreate == null)
            {
                objInstTemplateCreate = new Application_Layer.Installment.InstTemplate.InstTemplateCreate();
                objInstTemplateCreate.MdiParent = this;
                objInstTemplateCreate.WindowState = FormWindowState.Maximized;
                objInstTemplateCreate.FormClosed += ObjInstTemplateCreate_FormClosed;
                radDock1.ActivateMdiChild(objInstTemplateCreate);
                objInstTemplateCreate.Show();
            }
            else
            {
                objInstTemplateCreate.Activate();
            }
        }
        private void ObjInstTemplateCreate_FormClosed(object sender, FormClosedEventArgs e)
        {
            objInstTemplateCreate = null;
        }
        #endregion

        #region Installment Template Modify
        private Application_Layer.Installment.InstTemplate.InstTemplateModify objInstTemplateModify;
        private void radbtnModifyInstal_Click(object sender, EventArgs e)
        {
            if (objInstTemplateModify == null)
            {
                objInstTemplateModify = new Application_Layer.Installment.InstTemplate.InstTemplateModify();
                objInstTemplateModify.MdiParent = this;
                objInstTemplateModify.WindowState = FormWindowState.Maximized;
                objInstTemplateModify.FormClosed += ObjInstTemplateModify_FormClosed;
                radDock1.ActivateMdiChild(objInstTemplateModify);
                objInstTemplateModify.Show();
            }
            else
            {
                objInstTemplateModify.Activate();
            }
        }

        private void ObjInstTemplateModify_FormClosed(object sender, FormClosedEventArgs e)
        {
            objInstTemplateModify = null;
        }
        #endregion

        #region Installment Template Search
        private Application_Layer.Installment.InstTemplate.frmInstTemplateSearch objfrmInstTemplateSearch;
        private void btnInstTemplateSearch_Click(object sender, EventArgs e)
        {
            if (objfrmInstTemplateSearch == null)
            {
                objfrmInstTemplateSearch = new Application_Layer.Installment.InstTemplate.frmInstTemplateSearch();
                objfrmInstTemplateSearch.MdiParent = this;
                objfrmInstTemplateSearch.WindowState = FormWindowState.Maximized;
                objfrmInstTemplateSearch.FormClosed += ObjfrmInstTemplateSearch_FormClosed;
                radDock1.ActivateMdiChild(objfrmInstTemplateSearch);
                objfrmInstTemplateSearch.Show();
            }
            else
            {
                objfrmInstTemplateSearch.Activate();
            }
        }

        private void ObjfrmInstTemplateSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmInstTemplateSearch = null;
        }
        #endregion

        #region Installment Plan Create
        private Application_Layer.Installment.InstPlan.frmInstPlanCreate objfrmInstPlanCreate;
        private void btnInstPlanCreate_Click(object sender, EventArgs e)
        {
            if (objfrmInstPlanCreate == null)
            {
                objfrmInstPlanCreate = new Application_Layer.Installment.InstPlan.frmInstPlanCreate();
                objfrmInstPlanCreate.MdiParent = this;
                objfrmInstPlanCreate.WindowState = FormWindowState.Maximized;
                objfrmInstPlanCreate.FormClosed += ObjfrmInstPlanCreate_FormClosed;
                radDock1.ActivateMdiChild(objfrmInstPlanCreate);
                objfrmInstPlanCreate.Show();
            }
            else
            {
                objfrmInstPlanCreate.Activate();
            }
        }

        private void ObjfrmInstPlanCreate_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmInstPlanCreate = null;
        }
        #endregion

        #region Installment Plan Search
        private Application_Layer.Installment.InstPlan.frmInstlPlanSearch objfrmInstlPlanSearch;
        private void btnInstPlansearch_Click(object sender, EventArgs e)
        {
            if (objfrmInstlPlanSearch == null)
            {
                objfrmInstlPlanSearch = new Application_Layer.Installment.InstPlan.frmInstlPlanSearch();
                objfrmInstlPlanSearch.MdiParent = this;
                objfrmInstlPlanSearch.WindowState = FormWindowState.Maximized;
                objfrmInstlPlanSearch.FormClosed += ObjfrmInstlPlanSearch_FormClosed;
                radDock1.ActivateMdiChild(objfrmInstlPlanSearch);
                objfrmInstlPlanSearch.Show();
            }
            else
            {
                objfrmInstlPlanSearch.Activate();
            }
        }

        private void ObjfrmInstlPlanSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmInstlPlanSearch = null;
        }
        #endregion

        #region Installment Plan Modify
        private Application_Layer.Installment.InstPlan.frmInstPlanModify objfrmInstPlanModify;
        private void btnInstPlanModify_Click(object sender, EventArgs e)
        {
            if (objfrmInstPlanModify == null)
            {
                objfrmInstPlanModify = new Application_Layer.Installment.InstPlan.frmInstPlanModify();
                objfrmInstPlanModify.MdiParent = this;
                objfrmInstPlanModify.WindowState = FormWindowState.Maximized;
                objfrmInstPlanModify.FormClosed += ObjfrmInstPlanModify_FormClosed;
                radDock1.ActivateMdiChild(objfrmInstPlanModify);
                objfrmInstPlanModify.Show();
            }
            else
            {
                objfrmInstPlanModify.Activate();
            }
        }

        private void ObjfrmInstPlanModify_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmInstPlanModify = null;
        }
        #endregion

        #region File Create

        private void btnCreateFilePlot_Click(object sender, EventArgs e)
        {

        }


        #endregion

        /// ---------------------


        #region Rece DD Create
        private Application_Layer.Installment.InstReceive.frmRecePayment paymentCreateobj;
        private void btnReceDD_Click(object sender, EventArgs e)
        {
            if (paymentCreateobj == null)
            {
                paymentCreateobj = new Application_Layer.Installment.InstReceive.frmRecePayment();
                paymentCreateobj.MdiParent = this;
                paymentCreateobj.WindowState = FormWindowState.Maximized;
                paymentCreateobj.FormClosed += PaymentCreateobj_FormClosed;
                radDock1.ActivateMdiChild(paymentCreateobj);
                paymentCreateobj.Show();
            }
            else
            {
                paymentCreateobj.Activate();
            }
        }

        private void PaymentCreateobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            paymentCreateobj = null;
        }
        #endregion

        #region DD Search
        private Application_Layer.Installment.InstReceive.frmReceInstSearch paymentSearch;
        private void btnDDSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (paymentSearch == null)
                {
                    paymentSearch = new Application_Layer.Installment.InstReceive.frmReceInstSearch();
                    paymentSearch.MdiParent = this;
                    paymentSearch.WindowState = FormWindowState.Maximized;
                    paymentSearch.FormClosed += PaymentSearch_FormClosed;
                    radDock1.ActivateMdiChild(paymentSearch);
                    paymentSearch.Show();
                }
                else
                {
                    radDock1.ActivateMdiChild(paymentSearch);
                    paymentSearch.Activate();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void PaymentSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            paymentSearch = null;
        }
        #endregion

        #region DD Data Modification
        private Application_Layer.Installment.InstReceive.frmReceInstModify paymentModify;
        private void btnDDModify_Click(object sender, EventArgs e)
        {
            if (paymentModify == null)
            {
                paymentModify = new Application_Layer.Installment.InstReceive.frmReceInstModify();
                paymentModify.MdiParent = this;
                paymentModify.WindowState = FormWindowState.Maximized;
                paymentModify.FormClosed += PaymentModify_FormClosed;
                radDock1.ActivateMdiChild(paymentModify);
                paymentModify.Show();
            }
            else
            {
                paymentModify.Activate();
            }
        }

        private void PaymentModify_FormClosed(object sender, FormClosedEventArgs e)
        {
            paymentModify = null;
        }
        #endregion


        #region Admin Basket
        private Application_Layer.Membership.MSDataVerify.frmDataBasket objFrmDataBasket;
        private void btnbasket_Click(object sender, EventArgs e)
        {
            if (objFrmDataBasket == null)
            {
                objFrmDataBasket = new Application_Layer.Membership.MSDataVerify.frmDataBasket();
                objFrmDataBasket.MdiParent = this;
                objFrmDataBasket.WindowState = FormWindowState.Maximized;
                objFrmDataBasket.FormClosed += ObjFrmDataBasket_FormClosed;
                radDock1.ActivateMdiChild(objFrmDataBasket);
                objFrmDataBasket.Show();
            }
            else
            {
                objFrmDataBasket.Activate();
            }
        }

        private void ObjFrmDataBasket_FormClosed(object sender, FormClosedEventArgs e)
        {
            objFrmDataBasket = null;
        }
        #endregion

        #region DEO Basket
        private Application_Layer.Membership.MSDataVerify.frmDataOperatorBasket operatorBasket;
        private void btnDEOBasket_Click(object sender, EventArgs e)
        {
            if (operatorBasket == null)
            {
                operatorBasket = new frmDataOperatorBasket();
                operatorBasket.MdiParent = this;
                operatorBasket.WindowState = FormWindowState.Maximized;
                operatorBasket.FormClosed += OperatorBasket_FormClosed;
                radDock1.ActivateMdiChild(operatorBasket);
                operatorBasket.Show();
            }
            else
            {
                operatorBasket.Activate();
            }
        }

        private void OperatorBasket_FormClosed(object sender, FormClosedEventArgs e)
        {
            operatorBasket = null;
        }
        #endregion

        #region Verification Unit Basket
        private Application_Layer.Membership.MSDataVerify.frmVerifiedUnitBasket objverified;
        private void btnverification_Click(object sender, EventArgs e)
        {
            if (objverified == null)
            {
                objverified = new frmVerifiedUnitBasket();
                objverified.MdiParent = this;
                objverified.WindowState = FormWindowState.Maximized;
                objverified.FormClosed += Objverified_FormClosed;
                radDock1.ActivateMdiChild(objverified);
                objverified.Show();
            }
            else
            {
                objverified.Activate();
            }
        }
        private void Objverified_FormClosed(object sender, FormClosedEventArgs e)
        {
            objverified = null;
        }
        #endregion

        #region Image Upload of DD and Challan
        private frmDDChallanImagesUpload objChallanImagesUpload;
        private void btnReceImageUpload_Click(object sender, EventArgs e)
        {
            if (objChallanImagesUpload == null)
            {
                objChallanImagesUpload = new frmDDChallanImagesUpload();
                objChallanImagesUpload.MdiParent = this;
                objChallanImagesUpload.WindowState = FormWindowState.Maximized;
                objChallanImagesUpload.FormClosed += ObjChallanImagesUpload_FormClosed;
                radDock1.ActivateMdiChild(objChallanImagesUpload);
                objChallanImagesUpload.Show();
            }
            else
            {
                objChallanImagesUpload.Activate();
            }
        }

        private void ObjChallanImagesUpload_FormClosed(object sender, FormClosedEventArgs e)
        {
            objChallanImagesUpload = null;
        }
        #endregion

        #region Receive Verification Unit
        private frmReceiveVerificationUnit objFrmReceiveVerificationUnit;
        private void btnReceImageUpdate_Click(object sender, EventArgs e)
        {
            if (objFrmReceiveVerificationUnit == null)
            {
                objFrmReceiveVerificationUnit = new frmReceiveVerificationUnit();
                objFrmReceiveVerificationUnit.MdiParent = this;
                objFrmReceiveVerificationUnit.WindowState = FormWindowState.Maximized;
                objFrmReceiveVerificationUnit.FormClosed += ObjFrmReceiveVerificationUnit_FormClosed;
                radDock1.ActivateMdiChild(objFrmReceiveVerificationUnit);
                objFrmReceiveVerificationUnit.Show();
            }
            else
            {
                objFrmReceiveVerificationUnit.Activate();
            }
        }

        private void ObjFrmReceiveVerificationUnit_FormClosed(object sender, FormClosedEventArgs e)
        {
            objFrmReceiveVerificationUnit = null;
        }
        #endregion

        #region FrmReceInstFullDataView
        private frmReceInstFullDataView objFrmReceInstFullDataView;
        private void btnReceImageView_Click(object sender, EventArgs e)
        {
            if (objFrmReceInstFullDataView == null)
            {
                objFrmReceInstFullDataView = new frmReceInstFullDataView();
                objFrmReceInstFullDataView.MdiParent = this;
                objFrmReceInstFullDataView.WindowState = FormWindowState.Maximized;
                objFrmReceInstFullDataView.FormClosed += ObjFrmReceInstFullDataView_FormClosed;
                radDock1.ActivateMdiChild(objFrmReceInstFullDataView);
                objFrmReceInstFullDataView.Show();
            }
            else
            {
                objFrmReceInstFullDataView.Activate();
            }
        }

        private void ObjFrmReceInstFullDataView_FormClosed(object sender, FormClosedEventArgs e)
        {
            objFrmReceInstFullDataView = null;
        }
        #endregion

        #region objFrmBinding Basket
        private Application_Layer.Transfer.TFRType.TFRSetting.frmFileMembershipBinding objownerbinding;
        private void btnOwnerBind_Click(object sender, EventArgs e)
        {
            if (objownerbinding == null)
            {
                objownerbinding = new Application_Layer.Transfer.TFRType.TFRSetting.frmFileMembershipBinding();
                objownerbinding.MdiParent = this;
                objownerbinding.WindowState = FormWindowState.Maximized;
                objownerbinding.FormClosed += ObjFrmBindingBasket_FormClosed;
                radDock1.ActivateMdiChild(objownerbinding);
                objownerbinding.Show();
            }
            else
            {
                objownerbinding.Activate();
            }
        }

        private void ObjFrmBindingBasket_FormClosed(object sender, FormClosedEventArgs e)
        {
            objownerbinding = null;
        }
        #endregion

        #region Role Management
        private frmRoleMgt objeFrmRoleMgt;
        private void btnRole_Click(object sender, EventArgs e)
        {

            if (objeFrmRoleMgt == null)
            {
                objeFrmRoleMgt = new frmRoleMgt();
                objeFrmRoleMgt.MdiParent = this;
                objeFrmRoleMgt.WindowState = FormWindowState.Maximized;
                objeFrmRoleMgt.FormClosed += ObjeFrmRoleMgt_FormClosed;
                radDock1.ActivateMdiChild(objeFrmRoleMgt);
                objeFrmRoleMgt.Show();
            }
            else
            {
                objeFrmRoleMgt.Activate();
            }
        }

        private void ObjeFrmRoleMgt_FormClosed(object sender, FormClosedEventArgs e)
        {
            objeFrmRoleMgt = null;
        }
        #endregion
        /// <summary>
        /// Frm Control Setting is Use for User Base Control Managment
        /// and this Form Have Button,Group and Tab Addition functionality.
        /// </summary>
        #region Form Control Management Setting
        private frm_ControlSetting objFrmFormControl;
        private void btnControl_Click(object sender, EventArgs e)
        {
            if (objFrmFormControl == null)
            {
                objFrmFormControl = new frm_ControlSetting();
                objFrmFormControl.MdiParent = this;
                objFrmFormControl.WindowState = FormWindowState.Maximized;
                objFrmFormControl.FormClosed += ObjFrmFormControl_FormClosed;
                radDock1.ActivateMdiChild(objFrmFormControl);
                objFrmFormControl.Show();
            }
            else
            {
                objFrmFormControl.Activate();
            }
        }

        private void ObjFrmFormControl_FormClosed(object sender, FormClosedEventArgs e)
        {
            objFrmFormControl = null;
        }
        #endregion

        #region Permission Assigning Management
        private PermissionAssigningtoRole objAssigningtoRole;
        private void btnPermissionSetting_Click(object sender, EventArgs e)
        {
            if (objAssigningtoRole == null)
            {
                objAssigningtoRole = new PermissionAssigningtoRole();
                objAssigningtoRole.MdiParent = this;
                objAssigningtoRole.WindowState = FormWindowState.Maximized;
                objAssigningtoRole.FormClosed += ObjAssigningtoRole_FormClosed;
                radDock1.ActivateMdiChild(objAssigningtoRole);
                objAssigningtoRole.Show();
            }
            else
            {
                objAssigningtoRole.Activate();
            }
        }

        private void ObjAssigningtoRole_FormClosed(object sender, FormClosedEventArgs e)
        {
            objAssigningtoRole = null;
        }
        #endregion

        #region New Owner Setting
        private Application_Layer.Owner.FirstTimeOwnerCreation.frmFileVerification newownerobj;
        private void btnNewOwner_Click(object sender, EventArgs e)
        {
            if (newownerobj == null)
            {
                newownerobj = new Application_Layer.Owner.FirstTimeOwnerCreation.frmFileVerification();
                newownerobj.MdiParent = this;
                newownerobj.WindowState = FormWindowState.Maximized;
                newownerobj.ThemeName = this.ThemeName;
                newownerobj.FormClosed += Newownerobj_FormClosed;
                radDock1.ActivateMdiChild(newownerobj);
                newownerobj.Show();
            }
            else
            {
                newownerobj.Activate();
            }
        }

        private void Newownerobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            newownerobj = null;
        }
        #endregion

        #region Owner Search
        private Application_Layer.Owner.frmOwnerSearch ownersearch;
        private void btnOwnerSearch_Click(object sender, EventArgs e)
        {
            if (ownersearch == null)
            {
                ownersearch = new Application_Layer.Owner.frmOwnerSearch();
                ownersearch.MdiParent = this;
                ownersearch.WindowState = FormWindowState.Maximized;
                ownersearch.ThemeName = this.ThemeName;
                ownersearch.FormClosed += Ownersearch_FormClosed;
                radDock1.ActivateMdiChild(ownersearch);
                ownersearch.Show();
            }
            else
            {
                ownersearch.Activate();
            }
        }

        private void Ownersearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            ownersearch = null;
        }
        #endregion

        #region Owner Modify
        private Application_Layer.Owner.frmOwnerModify ownerModify;
        private void btnOwnerModify_Click(object sender, EventArgs e)
        {
            if (ownerModify == null)
            {
                ownerModify = new Application_Layer.Owner.frmOwnerModify();
                ownerModify.MdiParent = this;
                ownerModify.WindowState = FormWindowState.Maximized;
                ownerModify.ThemeName = this.ThemeName;
                ownerModify.FormClosed += OwnerModify_FormClosed;
                radDock1.ActivateMdiChild(ownerModify);
                ownerModify.Show();
            }
            else
            {
                ownerModify.Activate();
            }
        }

        private void OwnerModify_FormClosed(object sender, FormClosedEventArgs e)
        {
            ownerModify = null;
        }
        #endregion

        #region frm TFRAppointemnt Basket
        private Application_Layer.Transfer.TFRSetting.frmTransferBasket frmtfrbasketobject;
        private void btnTransferSetting_Click(object sender, EventArgs e)
        {
            if (frmtfrbasketobject == null)
            {
                frmtfrbasketobject = new Application_Layer.Transfer.TFRSetting.frmTransferBasket();
                frmtfrbasketobject.MdiParent = this;
                frmtfrbasketobject.WindowState = FormWindowState.Maximized;
                frmtfrbasketobject.ThemeName = this.ThemeName;
                frmtfrbasketobject.FormClosed += Frmtfrbasketobject_FormClosed;
                radDock1.ActivateMdiChild(frmtfrbasketobject);
                frmtfrbasketobject.Show();
            }
            else
            {
                frmtfrbasketobject.Activate();
            }
        }

        private void Frmtfrbasketobject_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmtfrbasketobject = null;
        }
        #endregion

        /// <summary>
        /// Splash Setting When the Software Login Confirm than this Splash Appear
        /// </summary>
        #region Splash Setting
        private Application_Layer.Splash.frmSplashSetting objFrmSplashSetting;
        private void btnsplashSetting_Click(object sender, EventArgs e)
        {
            if (objFrmSplashSetting == null)
            {
                objFrmSplashSetting = new Application_Layer.Splash.frmSplashSetting();
                objFrmSplashSetting.MdiParent = this;
                objFrmSplashSetting.WindowState = FormWindowState.Maximized;
                objFrmSplashSetting.ThemeName = this.ThemeName;
                objFrmSplashSetting.FormClosed += ObjFrmSplashSetting_FormClosed;
                radDock1.ActivateMdiChild(objFrmSplashSetting);
                objFrmSplashSetting.Show();
            }
            else
            {
                objFrmSplashSetting.Activate();
            }
        }

        private void ObjFrmSplashSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            objFrmSplashSetting = null;
        }
        #endregion

        /// <summary>
        /// NDC No Demand Certificate Module All Form Intergation
        /// </summary>

        #region NDC Create
        private frmNDCCreate frmNDCCreateobj;
        private void btnNewNDC_Click(object sender, EventArgs e)
        {
            if (frmNDCCreateobj == null)
            {
                frmNDCCreateobj = new frmNDCCreate();
                frmNDCCreateobj.MdiParent = this;
                frmNDCCreateobj.WindowState = FormWindowState.Maximized;
                frmNDCCreateobj.ThemeName = this.ThemeName;
                frmNDCCreateobj.FormClosed += FrmNDCCreateobj_FormClosed;
                radDock1.ActivateMdiChild(frmNDCCreateobj);
                frmNDCCreateobj.Show();
            }
            else
            {
                frmNDCCreateobj.Activate();
            }
        }

        private void FrmNDCCreateobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmNDCCreateobj = null;
        }
        #endregion

        #region NDC Search 
        private frmNDCSearch frmNdcSearchobj;
        private void btnNDCSearch_Click(object sender, EventArgs e)
        {

            if (frmNdcSearchobj == null)
            {
                frmNdcSearchobj = new frmNDCSearch();
                frmNdcSearchobj.MdiParent = this;
                frmNdcSearchobj.WindowState = FormWindowState.Maximized;
                frmNdcSearchobj.ThemeName = this.ThemeName;
                frmNdcSearchobj.FormClosed += FrmNdcSearchobj_FormClosed;
                radDock1.ActivateMdiChild(frmNdcSearchobj);
                frmNdcSearchobj.Show();
            }
            else
            {
                frmNdcSearchobj.Activate();
            }
        }

        private void FrmNdcSearchobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmNdcSearchobj = null;
        }
        #endregion

        #region NDC Modify Edit
        private frmNDCModify frmNdcModifyobj;
        private void btnNDCEdit_Click(object sender, EventArgs e)
        {
            if (frmNdcModifyobj == null)
            {
                frmNdcModifyobj = new frmNDCModify();
                frmNdcModifyobj.MdiParent = this;
                frmNdcModifyobj.WindowState = FormWindowState.Maximized;
                frmNdcModifyobj.ThemeName = this.ThemeName;
                frmNdcModifyobj.FormClosed += FrmNdcModifyobj_FormClosed;
                radDock1.ActivateMdiChild(frmNdcModifyobj);
                frmNdcModifyobj.Show();
            }
            else
            {
                frmNdcModifyobj.Activate();
            }
        }

        private void FrmNdcModifyobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmNdcModifyobj = null;
        }
        #endregion

        #region NDC CheckList Binding
        private frmNDC_CheckList_Binding_Updating frmoBindingUpdatingobj;
        private void btnNDCBinding_Click(object sender, EventArgs e)
        {
            if (frmoBindingUpdatingobj == null)
            {
                frmoBindingUpdatingobj = new frmNDC_CheckList_Binding_Updating();
                frmoBindingUpdatingobj.MdiParent = this;
                frmoBindingUpdatingobj.WindowState = FormWindowState.Maximized;
                frmoBindingUpdatingobj.ThemeName = this.ThemeName;
                frmoBindingUpdatingobj.FormClosed += FrmoBindingUpdatingobj_FormClosed;
                radDock1.ActivateMdiChild(frmoBindingUpdatingobj);
                frmoBindingUpdatingobj.Show();
            }
            else
            {
                frmoBindingUpdatingobj.Activate();
            }
        }

        private void FrmoBindingUpdatingobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmoBindingUpdatingobj = null;
        }
        #endregion

        #region NDC Check List
        private frmNDCCheckListCreate frmNdcCheckListCreateobj;
        private void btnNDC_CHKNew_Click(object sender, EventArgs e)
        {
            if (frmNdcCheckListCreateobj == null)
            {
                frmNdcCheckListCreateobj = new frmNDCCheckListCreate();
                frmNdcCheckListCreateobj.MdiParent = this;
                frmNdcCheckListCreateobj.WindowState = FormWindowState.Maximized;
                frmNdcCheckListCreateobj.ThemeName = this.ThemeName;
                frmNdcCheckListCreateobj.FormClosed += FrmNdcCheckListCreateobj_FormClosed;
                radDock1.ActivateMdiChild(frmNdcCheckListCreateobj);
                frmNdcCheckListCreateobj.Show();
            }
            else
            {
                frmNdcCheckListCreateobj.Activate();
            }
        }

        private void FrmNdcCheckListCreateobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmNdcCheckListCreateobj = null;
        }
        #endregion

        #region NDC Check List Search
        private void btnNDC_CHKSearch_Click(object sender, EventArgs e)
        {
           
        }

       
        #endregion

        #region NDC Check Binding
        private frmNDCCheckListModify frmNdcCheckListModify;
        private void btnNDC_CHKEdit_Click(object sender, EventArgs e)
        {
            if (frmNdcCheckListModify == null)
            {
                frmNdcCheckListModify = new frmNDCCheckListModify();
                frmNdcCheckListModify.MdiParent = this;
                frmNdcCheckListModify.WindowState = FormWindowState.Maximized;
                frmNdcCheckListModify.ThemeName = this.ThemeName;
                frmNdcCheckListModify.FormClosed += FrmNdcCheckListModify_FormClosed;
                radDock1.ActivateMdiChild(frmNdcCheckListModify);
                frmNdcCheckListModify.Show();
            }
            else
            {
                frmNdcCheckListModify.Activate();
            }
        }
        private void FrmNdcCheckListModify_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmNdcCheckListModify = null;
        }
        #endregion

        #region Basket NDC InComplete
        private frmBasketReviewedApproved frmBasketIncompleteobj;
        private void btnNDC_BasketProgress_Click(object sender, EventArgs e)
        {
            if (frmBasketIncompleteobj == null)
            {
                frmBasketIncompleteobj = new frmBasketReviewedApproved();
                frmBasketIncompleteobj.MdiParent = this;
                frmBasketIncompleteobj.WindowState = FormWindowState.Maximized;
                frmBasketIncompleteobj.ThemeName = this.ThemeName;
                frmBasketIncompleteobj.FormClosed += FrmBasketIncompleteobj_FormClosed;
                radDock1.ActivateMdiChild(frmBasketIncompleteobj);
                frmBasketIncompleteobj.Show();
            }
            else
            {
                frmBasketIncompleteobj.Activate();
            }
        }

        private void FrmBasketIncompleteobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmBasketIncompleteobj = null;
        }
        #endregion

        #region NDC Verification 
        private frm_BasketVerificationExpireCancelTFRComplete frmBasketNdcVerificationobj;
        private void btnNDC_BasketVerification_Click(object sender, EventArgs e)
        {
            if (frmBasketNdcVerificationobj == null)
            {
                frmBasketNdcVerificationobj = new frm_BasketVerificationExpireCancelTFRComplete();
                frmBasketNdcVerificationobj.MdiParent = this;
                frmBasketNdcVerificationobj.WindowState = FormWindowState.Maximized;
                frmBasketNdcVerificationobj.ThemeName = this.ThemeName;
                frmBasketNdcVerificationobj.FormClosed += FrmBasketNdcVerificationobj_FormClosed;
                radDock1.ActivateMdiChild(frmBasketNdcVerificationobj);
                frmBasketNdcVerificationobj.Show();
            }
            else
            {
                frmBasketNdcVerificationobj.Activate();
            }
        }

        private void FrmBasketNdcVerificationobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmBasketNdcVerificationobj = null;
        }
        #endregion

        #region NDC Printed Not Signed 
        private frmPrintedNotSigned frmPrintedNotSignedobj;
        private void btnNDC_BasketSigned_Click(object sender, EventArgs e)
        {
            if (frmPrintedNotSignedobj == null)
            {
                frmPrintedNotSignedobj = new frmPrintedNotSigned();
                frmPrintedNotSignedobj.MdiParent = this;
                frmPrintedNotSignedobj.WindowState = FormWindowState.Maximized;
                frmPrintedNotSignedobj.ThemeName = this.ThemeName;
                frmPrintedNotSignedobj.FormClosed += FrmPrintedNotSignedobj_FormClosed;
                radDock1.ActivateMdiChild(frmPrintedNotSignedobj);
                frmPrintedNotSignedobj.Show();
            }
            else
            {
                frmPrintedNotSignedobj.Activate();
            }
        }

        private void FrmPrintedNotSignedobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrintedNotSignedobj = null;
        }
        #endregion

        private Application_Layer.NDC.Baskets.frmReadyForMemberShipAfterTransfer frmReadyForMembershipobj;
        private void btnMS_Setting_Click(object sender, EventArgs e)
        {
            if (frmReadyForMembershipobj == null)
            {
                frmReadyForMembershipobj = new frmReadyForMemberShipAfterTransfer();
                frmReadyForMembershipobj.MdiParent = this;
                frmReadyForMembershipobj.WindowState = FormWindowState.Maximized;
                frmReadyForMembershipobj.ThemeName = this.ThemeName;
                frmReadyForMembershipobj.FormClosed += FrmReadyForMembershipobj_FormClosed;
                radDock1.ActivateMdiChild(frmReadyForMembershipobj);
                frmReadyForMembershipobj.Show();
            }
            else
            {
                frmReadyForMembershipobj.Activate();
            }
        }

        private void FrmReadyForMembershipobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmReadyForMembershipobj = null;
        }



        #region Transfer Appointment Basket

        private frmGenerateTFRAppointment frmGenerateTfrAppointmentobj;
        private void btnTFRApp_Click(object sender, EventArgs e)
        {
            if (frmGenerateTfrAppointmentobj == null)
            {
                frmGenerateTfrAppointmentobj = new frmGenerateTFRAppointment();
                frmGenerateTfrAppointmentobj.MdiParent = this;
                frmGenerateTfrAppointmentobj.WindowState = FormWindowState.Maximized;
                frmGenerateTfrAppointmentobj.ThemeName = this.ThemeName;
                frmGenerateTfrAppointmentobj.FormClosed += FrmGenerateTfrAppointmentobj_FormClosed;
                radDock1.ActivateMdiChild(frmGenerateTfrAppointmentobj);
                frmGenerateTfrAppointmentobj.Show();
            }
            else
            {
                frmGenerateTfrAppointmentobj.Activate();
            }
        }

        private void FrmGenerateTfrAppointmentobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGenerateTfrAppointmentobj = null;
        }
        #endregion


        #region Ready for Transfer 
        private frmReadyForTransfer frmReadyForTransferobj;
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (frmReadyForTransferobj == null)
            {
                frmReadyForTransferobj = new frmReadyForTransfer();
                frmReadyForTransferobj.MdiParent = this;
                frmReadyForTransferobj.WindowState = FormWindowState.Maximized;
                frmReadyForTransferobj.ThemeName = this.ThemeName;
                frmReadyForTransferobj.FormClosed += FrmReadyForTransferobj_FormClosed;
                radDock1.ActivateMdiChild(frmReadyForTransferobj);
                frmReadyForTransferobj.Show();
            }
            else
            {
                frmReadyForTransferobj.Activate();
            }
        }

        private void FrmReadyForTransferobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmReadyForTransferobj = null;
        }
        #endregion

        #region Ready for Picture
        private frmReadyForPicture frmReadyForPictureobj;
        private void btnTFRImage_Click(object sender, EventArgs e)
        {
            if (frmReadyForPictureobj == null)
            {
                frmReadyForPictureobj = new frmReadyForPicture();
                frmReadyForPictureobj.MdiParent = this;
                frmReadyForPictureobj.WindowState = FormWindowState.Maximized;
                frmReadyForPictureobj.ThemeName = this.ThemeName;
                frmReadyForPictureobj.FormClosed += FrmReadyForPictureobj_FormClosed;
                radDock1.ActivateMdiChild(frmReadyForPictureobj);
                frmReadyForPictureobj.Show();
            }
            else
            {
                frmReadyForPictureobj.Activate();
            }
        }

        private void FrmReadyForPictureobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmReadyForPictureobj = null;
        }

        #endregion

        private frmReadyForTransferReport frmReadyForTransferReportobj;
        private void btnTFRReport_Click(object sender, EventArgs e)
        {
            if (frmReadyForTransferReportobj == null)
            {
                frmReadyForTransferReportobj = new frmReadyForTransferReport();
                frmReadyForTransferReportobj.MdiParent = this;
                frmReadyForTransferReportobj.WindowState = FormWindowState.Maximized;
                frmReadyForTransferReportobj.ThemeName = this.ThemeName;
                frmReadyForTransferReportobj.FormClosed += FrmReadyForTransferReportobj_FormClosed;
                radDock1.ActivateMdiChild(frmReadyForTransferReportobj);
                frmReadyForTransferReportobj.Show();
            }
            else
            {
                frmReadyForTransferReportobj.Activate();
            }
        }

        private void FrmReadyForTransferReportobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmReadyForTransferReportobj = null;
        }

        private frmReaddyForTFRSlips frmTFRSlipReports;
        private void btnTFRVerification_Click(object sender, EventArgs e)
        {
            if (frmTFRSlipReports == null)
            {
                frmTFRSlipReports = new frmReaddyForTFRSlips();
                frmTFRSlipReports.MdiParent = this;
                frmTFRSlipReports.WindowState = FormWindowState.Maximized;
                frmTFRSlipReports.ThemeName = this.ThemeName;
                frmTFRSlipReports.FormClosed += FrmTFRSlipReports_FormClosed;
                radDock1.ActivateMdiChild(frmTFRSlipReports);
                frmTFRSlipReports.Show();
            }
            else
            {
                frmTFRSlipReports.Activate();
            }
        }

        private void FrmTFRSlipReports_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmTFRSlipReports = null;
        }
        
        private frmMSFormRecordChecking frmMemberFormRecord;
        private void btnTFRLetterImage_Click(object sender, EventArgs e)
        {
            if (frmMemberFormRecord == null)
            {
                frmMemberFormRecord = new frmMSFormRecordChecking();
                frmMemberFormRecord.MdiParent = this;
                frmMemberFormRecord.WindowState = FormWindowState.Maximized;
                frmMemberFormRecord.ThemeName = this.ThemeName;
                frmMemberFormRecord.FormClosed += FrmMemberFormRecord_FormClosed;
                radDock1.ActivateMdiChild(frmMemberFormRecord);
                frmMemberFormRecord.Show();
            }
            else
            {
                frmMemberFormRecord.Activate();
            }
        }

        private void FrmMemberFormRecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmMemberFormRecord = null;
        }

        

        public void ApplyTheme(string themeName)
        {
            this.ThemeName = themeName; ThemeResolutionService.ApplyThemeToControlTree(this, themeName);
        }

        private void radRibbonBarGroup13_Click(object sender, EventArgs e)
        {

        }



        #region View All Error
        private Application_Layer.SystemError.frmViewAllError objViewAllError;
        private void btnSystemAllError_Click(object sender, EventArgs e)
        {
            if (objViewAllError == null)
            {
                objViewAllError = new frmViewAllError();
                objViewAllError.MdiParent = this;
                objViewAllError.WindowState = FormWindowState.Maximized;
                objViewAllError.ThemeName = this.ThemeName;
                objViewAllError.FormClosed += ObjViewAllError_FormClosed;
                radDock1.ActivateMdiChild(objViewAllError);
                objViewAllError.Show();
            }
            else
            {
                objViewAllError.Activate();
            }
        }

        private void ObjViewAllError_FormClosed(object sender, FormClosedEventArgs e)
        {
            objViewAllError = null;
        }
        #endregion

        #region DbError View
        private frmDBErrorView objDbErrorView;
        private void btnDBError_Click(object sender, EventArgs e)
        {
            if (objDbErrorView == null)
            {
                objDbErrorView = new frmDBErrorView();
                objDbErrorView.MdiParent = this;
                objDbErrorView.WindowState = FormWindowState.Maximized;
                objDbErrorView.ThemeName = this.ThemeName;
                objDbErrorView.FormClosed += ObjDbErrorView_FormClosed;
                radDock1.ActivateMdiChild(objDbErrorView);
                objDbErrorView.Show();
            }
            else
            {
                objDbErrorView.Activate();
            }
        }

        private void ObjDbErrorView_FormClosed(object sender, FormClosedEventArgs e)
        {
            objDbErrorView = null;
        }
        #endregion

        #region Data Logging
        private frmDataLogging objFrmDataLogging;
        private void btnDataLog_Click(object sender, EventArgs e)
        {
            if (objFrmDataLogging == null)
            {
                objFrmDataLogging = new frmDataLogging();
                objFrmDataLogging.MdiParent = this;
                objFrmDataLogging.WindowState = FormWindowState.Maximized;
                objFrmDataLogging.ThemeName = this.ThemeName;
                objFrmDataLogging.FormClosed += ObjFrmDataLogging_FormClosed;
                radDock1.ActivateMdiChild(objFrmDataLogging);
                objFrmDataLogging.Show();
            }
            else
            {
                objFrmDataLogging.Activate();
            }

        }

        private void ObjFrmDataLogging_FormClosed(object sender, FormClosedEventArgs e)
        {
            objFrmDataLogging = null;
        }
        #endregion

        #region Theme Button Control
        private void themeChange(string varTheme)
        {
            SqlParameter[] parm =
            {
                new SqlParameter("@Task","ThemeUpdate"),
                new SqlParameter("@ThemeName",varTheme),
                new SqlParameter("@ID",clsUser.ID)
            };
            int reuslt = cls_dl_User.User_NonQuery(parm);
            clsUser.ThemeName = varTheme;
        }
        private void btnmetro_Click(object sender, EventArgs e)
        {
            themeChange("TelerikMetro");
            ApplyTheme("TelerikMetro");
        }
        private void btnaqua_Click(object sender, EventArgs e)
        {
            themeChange("Aqua");
            ApplyTheme("Aqua");
        }

        private void btnbreeze_Click(object sender, EventArgs e)
        {
            themeChange("Breeze");
            ApplyTheme("Breeze");
        }

        private void btndesert_Click(object sender, EventArgs e)
        {
            //Desert
            themeChange("Desert");
            ApplyTheme("Desert");
        }

        private void btnmetroblue_Click(object sender, EventArgs e)
        {
            //TelerikMetroBlue
            themeChange("TelerikMetroBlue");
            ApplyTheme("TelerikMetroBlue");
        }

        private void btndark_Click(object sender, EventArgs e)
        {
            //VisualStudio2012Dark
            themeChange("VisualStudio2012Dark");
            ApplyTheme("VisualStudio2012Dark");
        }

        private void btnwindow7_Click(object sender, EventArgs e)
        {
            //Windows7
            themeChange("Breeze");
            ApplyTheme("Breeze");
        }

        private void btnOffice2007Black_Click(object sender, EventArgs e)
        {
            //Office2007Black
            themeChange("Office2007Black");
            ApplyTheme("Office2007Black");
        }

        private void btnOffice2010Silver_Click(object sender, EventArgs e)
        {
            //Office2010Silver
            themeChange("Office2010Silver");
            ApplyTheme("Office2010Silver");
        }

        private void btnOffice2013Dark_Click(object sender, EventArgs e)
        {
            //Office2013Dark
            themeChange("Office2013Dark");
            ApplyTheme("Office2013Dark");
        }

        private void btnOffice2013Light_Click(object sender, EventArgs e)
        {
            //Office2013Light
            themeChange("Office2013Light");
            ApplyTheme("Office2013Light");
        }
        #endregion

        #region Acknowledgement Bulk Print
        Application_Layer.Acknowledgement.frm_BulkPrinterofAcknowledgement objfrmAcknowledgement_UserBase;
        private void btnAcknowledgementPrint_Click(object sender, EventArgs e)
        {
            if (objfrmAcknowledgement_UserBase == null)
            {
                objfrmAcknowledgement_UserBase = new Application_Layer.Acknowledgement.frm_BulkPrinterofAcknowledgement();
                objfrmAcknowledgement_UserBase.MdiParent = this;
                objfrmAcknowledgement_UserBase.WindowState = FormWindowState.Maximized;
                objfrmAcknowledgement_UserBase.ThemeName = this.ThemeName;
                objfrmAcknowledgement_UserBase.FormClosed += ObjfrmAcknowledgement_FormClosed;
                radDock1.ActivateMdiChild(objfrmAcknowledgement_UserBase);
                objfrmAcknowledgement_UserBase.Show();
            }
            else
            {
                objfrmAcknowledgement_UserBase.Activate();
            }

        }

        private void ObjfrmAcknowledgement_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmAcknowledgement_UserBase = null;
        }


        #endregion

        /// <summary>
        /// Land Branch Controls
        /// </summary>

        #region File Information

        #region New File Creation
        private Application_Layer.FileMap.frmCreateFileNoRPlot FileCreateobj;
        private void btnNewFile_Click(object sender, EventArgs e)
        {
            if (FileCreateobj == null)
            {
                FileCreateobj = new frmCreateFileNoRPlot();
                FileCreateobj.MdiParent = this;
                FileCreateobj.WindowState = FormWindowState.Maximized;
                FileCreateobj.FormClosed += FileCreateobj_FormClosed;
                radDock1.ActivateMdiChild(FileCreateobj);
                FileCreateobj.Show();
            }
            else
            {
                FileCreateobj.Activate();
            }
        }

        private void FileCreateobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileCreateobj = null;
        }
        #endregion

        #region Searching File
        private Application_Layer.FileMap.frmSearchFileRPlot FileSearchObj;
        private void btnfileSearch_Click(object sender, EventArgs e)
        {
            if (FileSearchObj == null)
            {
                FileSearchObj = new frmSearchFileRPlot();
                FileSearchObj.MdiParent = this;
                FileSearchObj.WindowState = FormWindowState.Maximized;
                FileSearchObj.FormClosed += FileSearchObj_FormClosed;
                radDock1.ActivateMdiChild(FileSearchObj);
                FileSearchObj.Show();
            }
            else
            {
                FileSearchObj.Activate();
            }
        }

        private void FileSearchObj_FormClosed(object sender, FormClosedEventArgs e)
        {
            FileSearchObj = null;
        }

        #endregion

        #region File Modify
        private Application_Layer.FileMap.frmModifyFileInformation File_Modify_obj;
        private void btnFileModify_Click(object sender, EventArgs e)
        {
            if (File_Modify_obj == null)
            {
                File_Modify_obj = new frmModifyFileInformation();
                File_Modify_obj.MdiParent = this;
                File_Modify_obj.WindowState = FormWindowState.Maximized;
                File_Modify_obj.FormClosed += File_Modify_obj_FormClosed;
                radDock1.ActivateMdiChild(File_Modify_obj);
                File_Modify_obj.Show();
            }
            else
            {
                File_Modify_obj.Activate();
            }
        }
        private void File_Modify_obj_FormClosed(object sender, FormClosedEventArgs e)
        {
            File_Modify_obj = null;
        }
        #endregion

        #endregion

        #region Plot Information Group

        #region Plot Create
        Application_Layer.Plot.frmPlot_Create objfrmPlotCreate;
        private void btnNewPlot_Click(object sender, EventArgs e)
        {
            if (objfrmPlotCreate == null)
            {
                objfrmPlotCreate = new Application_Layer.Plot.frmPlot_Create();
                objfrmPlotCreate.MdiParent = this;
                objfrmPlotCreate.WindowState = FormWindowState.Maximized;
                objfrmPlotCreate.FormClosed += ObjfrmPlotCreate_FormClosed;
                radDock1.ActivateMdiChild(objfrmPlotCreate);
                objfrmPlotCreate.Show();
            }
            else
            {
                objfrmPlotCreate.Activate();
            }
        }

        private void ObjfrmPlotCreate_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmPlotCreate = null;
        }
        #endregion

        #region Plot Search
        Application_Layer.Plot.frmPlot_Search objfrmPlotSearch;
        private void btnSearchPlot_Click(object sender, EventArgs e)
        {
            if (objfrmPlotSearch == null)
            {
                objfrmPlotSearch = new Application_Layer.Plot.frmPlot_Search();
                objfrmPlotSearch.MdiParent = this;
                objfrmPlotSearch.WindowState = FormWindowState.Maximized;
                objfrmPlotSearch.FormClosed += ObjfrmPlotSearch_FormClosed;
                radDock1.ActivateMdiChild(objfrmPlotSearch);
                objfrmPlotSearch.Show();
            }
            else
            {
                objfrmPlotSearch.Activate();
            }
        }

        private void ObjfrmPlotSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmPlotSearch = null;
        }
        #endregion

        #region Plot Modify
        Application_Layer.Plot.frmPlot_Modify objfrmplotModify;
        private void btnEditPlot_Click(object sender, EventArgs e)
        {
            if (objfrmplotModify == null)
            {
                objfrmplotModify = new Application_Layer.Plot.frmPlot_Modify();
                objfrmplotModify.MdiParent = this;
                objfrmplotModify.WindowState = FormWindowState.Maximized;
                objfrmplotModify.FormClosed += ObjfrmplotModify_FormClosed;
                radDock1.ActivateMdiChild(objfrmplotModify);
                objfrmplotModify.Show();
            }
            else
            {
                objfrmplotModify.Activate();
            }
        }

        private void ObjfrmplotModify_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmplotModify = null;
        }
        #endregion

        #endregion

        #region Sector Information

        #region Sector New
        Application_Layer.Sector.frmSector_Create objfrmsector;
        private void btnSectorNew_Click(object sender, EventArgs e)
        {
            if (objfrmsector == null)
            {
                objfrmsector = new Application_Layer.Sector.frmSector_Create();
                objfrmsector.MdiParent = this;
                objfrmsector.WindowState = FormWindowState.Maximized;
                objfrmsector.FormClosed += Objfrmsector_FormClosed;
                radDock1.ActivateMdiChild(objfrmsector);
                objfrmsector.Show();
            }
            else
            {
                objfrmsector.Activate();
            }
        }

        private void Objfrmsector_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmsector = null;
        }
        #endregion

        #region Sector Search
        Application_Layer.Sector.frmSector_Search objfrmsectorsearc;
        private void btnSectorSearch_Click(object sender, EventArgs e)
        {
            if (objfrmsectorsearc == null)
            {
                objfrmsectorsearc = new Application_Layer.Sector.frmSector_Search();
                objfrmsectorsearc.MdiParent = this;
                objfrmsectorsearc.WindowState = FormWindowState.Maximized;
                objfrmsectorsearc.FormClosed += Objfrmsectorsearc_FormClosed;
                radDock1.ActivateMdiChild(objfrmsectorsearc);
                objfrmsectorsearc.Show();
            }
            else
            {
                objfrmsectorsearc.Activate();
            }
        }

        private void Objfrmsectorsearc_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmsectorsearc = null;
        }
        #endregion

        #region Sector Modify
        Application_Layer.Sector.frmSector_Modify objfrmsectormodify;
        private void btnSectorEdit_Click(object sender, EventArgs e)
        {
            if (objfrmsectormodify == null)
            {
                objfrmsectormodify = new Application_Layer.Sector.frmSector_Modify();
                objfrmsectormodify.MdiParent = this;
                objfrmsectormodify.WindowState = FormWindowState.Maximized;
                objfrmsectormodify.FormClosed += Objfrmsectormodify_FormClosed;
                radDock1.ActivateMdiChild(objfrmsectormodify);
                objfrmsectormodify.Show();
            }
            else
            {
                objfrmsectormodify.Activate();
            }
        }

        private void Objfrmsectormodify_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmsectormodify = null;
        }
        #endregion

        #endregion

        #region Phase Information

        #region Phase Create
        Application_Layer.Phase.frmPhase_Create objPhasecreate;
        private void btnPhaseNew_Click(object sender, EventArgs e)
        {
            if (objPhasecreate == null)
            {
                objPhasecreate = new Application_Layer.Phase.frmPhase_Create();
                objPhasecreate.MdiParent = this;
                objPhasecreate.WindowState = FormWindowState.Maximized;
                objPhasecreate.FormClosed += ObjPhasecreate_FormClosed;
                radDock1.ActivateMdiChild(objPhasecreate);
                objPhasecreate.Show();
            }
            else
            {
                objPhasecreate.Activate();
            }
        }

        private void ObjPhasecreate_FormClosed(object sender, FormClosedEventArgs e)
        {
            objPhasecreate = null;
        }
        #endregion

        #region Phase Search
        Application_Layer.Phase.frmPhase_Search objPhaseSearch;
        private void btnPhaseSearch_Click(object sender, EventArgs e)
        {
            if (objPhaseSearch == null)
            {
                objPhaseSearch = new Application_Layer.Phase.frmPhase_Search();
                objPhaseSearch.MdiParent = this;
                objPhaseSearch.WindowState = FormWindowState.Maximized;
                objPhaseSearch.FormClosed += ObjPhaseSearch_FormClosed;
                radDock1.ActivateMdiChild(objPhaseSearch);
                objPhaseSearch.Show();
            }
            else
            {
                objPhaseSearch.Activate();
            }
        }

        private void ObjPhaseSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            objPhaseSearch = null;
        }
        #endregion

        #region Phase Modify
        Application_Layer.Phase.frmPhase_Modify objPhaseModify;
        private void btnPhaseEdit_Click(object sender, EventArgs e)
        {
            if (objPhaseModify == null)
            {
                objPhaseModify = new Application_Layer.Phase.frmPhase_Modify();
                objPhaseModify.MdiParent = this;
                objPhaseModify.WindowState = FormWindowState.Maximized;
                objPhaseModify.FormClosed += ObjPhaseModify_FormClosed;
                radDock1.ActivateMdiChild(objPhaseModify);
                objPhaseModify.Show();
            }
            else
            {
                objPhaseModify.Activate();
            }
        }

        private void ObjPhaseModify_FormClosed(object sender, FormClosedEventArgs e)
        {
            objPhaseModify = null;
        }
        #endregion

        #endregion

        #region DHA Information

        #region DHA Create
        Application_Layer.DHA.frmDHA_Create objDHACreate;
        private void btnDHANew_Click(object sender, EventArgs e)
        {
            if (objDHACreate == null)
            {
                objDHACreate = new Application_Layer.DHA.frmDHA_Create();
                objDHACreate.MdiParent = this;
                objDHACreate.WindowState = FormWindowState.Maximized;
                objDHACreate.FormClosed += ObjDHACreate_FormClosed;
                radDock1.ActivateMdiChild(objDHACreate);
                objDHACreate.Show();
            }
            else
            {
                objDHACreate.Activate();
            }
        }

        private void ObjDHACreate_FormClosed(object sender, FormClosedEventArgs e)
        {
            objDHACreate = null;
        }
        #endregion

        #region DHA Search
        Application_Layer.DHA.frmDHA_Search objDHASearch;
        private void btnDHASearch_Click(object sender, EventArgs e)
        {
            if (objDHASearch == null)
            {
                objDHASearch = new Application_Layer.DHA.frmDHA_Search();
                objDHASearch.MdiParent = this;
                objDHASearch.WindowState = FormWindowState.Maximized;
                objDHASearch.FormClosed += ObjDHASearch_FormClosed;
                radDock1.ActivateMdiChild(objDHASearch);
                objDHASearch.Show();
            }
            else
            {
                objDHASearch.Activate();
            }
        }

        private void ObjDHASearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            objDHASearch = null;
        }
        #endregion

        #region DHA Modify
        Application_Layer.DHA.frmDHA_Modify objDHAModify;
        private void btnDHAEdit_Click(object sender, EventArgs e)
        {
            if (objDHAModify == null)
            {
                objDHAModify = new Application_Layer.DHA.frmDHA_Modify();
                objDHAModify.MdiParent = this;
                objDHAModify.WindowState = FormWindowState.Maximized;
                objDHAModify.FormClosed += ObjDHAModify_FormClosed;
                radDock1.ActivateMdiChild(objDHAModify);
                objDHAModify.Show();
            }
            else
            {
                objDHAModify.Activate();
            }
        }

        private void ObjDHAModify_FormClosed(object sender, FormClosedEventArgs e)
        {
            objDHAModify = null;
        }
        #endregion

        #endregion

        #region Installment Summary
        Application_Layer.Installment.InstallmentSummary.frmFileWise_Summary objfrmFileWise_Summary;
        private void btnInstSummary_Click(object sender, EventArgs e)
        {
            if (objfrmFileWise_Summary == null)
            {
                objfrmFileWise_Summary = new Application_Layer.Installment.InstallmentSummary.frmFileWise_Summary();
                objfrmFileWise_Summary.MdiParent = this;
                objfrmFileWise_Summary.WindowState = FormWindowState.Maximized;
                objfrmFileWise_Summary.FormClosed += FrmInstallmentSummary_FormClosed;
                radDock1.ActivateMdiChild(objfrmFileWise_Summary);
                objfrmFileWise_Summary.Show();
            }
            else
            {
                objfrmFileWise_Summary.Activate();
            }
        }

        private void FrmInstallmentSummary_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmFileWise_Summary = null;
        }
        #endregion

        #region Installment Search
        Application_Layer.Installment.InstallmentSummary.frmInstallmentSearch frmInstallmentSearch;
        private void btnInstallmentWise_Click(object sender, EventArgs e)
        {
            if (frmInstallmentSearch == null)
            {
                frmInstallmentSearch = new Application_Layer.Installment.InstallmentSummary.frmInstallmentSearch();
                frmInstallmentSearch.MdiParent = this;
                frmInstallmentSearch.WindowState = FormWindowState.Maximized;
                frmInstallmentSearch.FormClosed += FrmInstallmentSearch_FormClosed;
                radDock1.ActivateMdiChild(frmInstallmentSearch);
                frmInstallmentSearch.Show();
            }
            else
            {
                frmInstallmentSearch.Activate();
            }
        }

        private void FrmInstallmentSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmInstallmentSearch = null;
        }
        #endregion

        #region Installment Summary Graph
        Application_Layer.Installment.InstallmentSummary.InstallmentSummaryGrap frmSummaryGrap;
        private void btnChart_Click(object sender, EventArgs e)
        {
            if (frmSummaryGrap == null)
            {
                frmSummaryGrap = new Application_Layer.Installment.InstallmentSummary.InstallmentSummaryGrap();
                frmSummaryGrap.MdiParent = this;
                frmSummaryGrap.WindowState = FormWindowState.Maximized;
                frmSummaryGrap.FormClosed += FrmSummaryGrap_FormClosed;
                radDock1.ActivateMdiChild(frmSummaryGrap);
                frmSummaryGrap.Show();
            }
            else
            {
                frmSummaryGrap.Activate();
            }
        }

        private void FrmSummaryGrap_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSummaryGrap = null;
        }
        #endregion

        #region Acknowledgement View
        Application_Layer.Installment.AcknowledgmentSearch.AcknowledgementView frmAcknowledgeView;
        private void btnSearchonFile_Click(object sender, EventArgs e)
        {
            if (frmAcknowledgeView == null)
            {
                frmAcknowledgeView = new Application_Layer.Installment.AcknowledgmentSearch.AcknowledgementView();
                frmAcknowledgeView.MdiParent = this;
                frmAcknowledgeView.WindowState = FormWindowState.Maximized;
                frmAcknowledgeView.FormClosed += FrmAcknowledgeView_FormClosed;
                radDock1.ActivateMdiChild(frmAcknowledgeView);
                frmAcknowledgeView.Show();
            }
            else
            {
                frmAcknowledgeView.Activate();
            }
        }

        private void FrmAcknowledgeView_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmAcknowledgeView = null;
        }
        #endregion

        #region Acknowledgement Dispatch
        Application_Layer.Installment.AcknowledgmentSearch.frmAcknowledgementDispatch frmAcknowledgementDispatchobj;
        private void DispatchAcknowledgement_Click(object sender, EventArgs e)
        {

            if (frmAcknowledgementDispatchobj == null)
            {
                frmAcknowledgementDispatchobj = new Application_Layer.Installment.AcknowledgmentSearch.frmAcknowledgementDispatch();
                frmAcknowledgementDispatchobj.MdiParent = this;
                frmAcknowledgementDispatchobj.WindowState = FormWindowState.Maximized;
                frmAcknowledgementDispatchobj.FormClosed += FrmAcknowledgementDispatchobj_FormClosed;
                radDock1.ActivateMdiChild(frmAcknowledgementDispatchobj);
                frmAcknowledgementDispatchobj.Show();
            }
            else
            {
                frmAcknowledgementDispatchobj.Activate();
            }
        }

        private void FrmAcknowledgementDispatchobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmAcknowledgementDispatchobj = null;
        }
        #endregion

        #region Add membership no to list which all the entry
        Application_Layer.Membership.AddMemberships.frmAddNewMembership newMembership;
        private void btnAddNewMembership_Click(object sender, EventArgs e)
        {
            if (newMembership == null)
            {
                newMembership = new Application_Layer.Membership.AddMemberships.frmAddNewMembership();
                newMembership.MdiParent = this;
                newMembership.WindowState = FormWindowState.Maximized;
                newMembership.FormClosed += NewMembership_FormClosed;
                radDock1.ActivateMdiChild(newMembership);
                newMembership.Show();
            }
            else
            {
                newMembership.Activate();
            }
        }

        private void NewMembership_FormClosed(object sender, FormClosedEventArgs e)
        {
            newMembership = null;
        }
        #endregion

        #region Edit membership no to list which all the entry
        Application_Layer.Membership.AddMemberships.frmEditMembership editMembershipobj;
        private void btnMembershipModification_Click(object sender, EventArgs e)
        {
            if (editMembershipobj == null)
            {
                editMembershipobj = new Application_Layer.Membership.AddMemberships.frmEditMembership();
                editMembershipobj.MdiParent = this;
                editMembershipobj.WindowState = FormWindowState.Maximized;
                editMembershipobj.FormClosed += EditMembershipobj_FormClosed;
                radDock1.ActivateMdiChild(editMembershipobj);
                editMembershipobj.Show();
            }
            else
            {
                editMembershipobj.Activate();
            }
        }

        private void EditMembershipobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            editMembershipobj = null;
        }
        #endregion

        #region List of DD Ready for Bank
        Application_Layer.Installment.InstReceive.frmListOfDD_ReadyForBankDeposite frmListofDD;
        private void btnDDListBank_Click(object sender, EventArgs e)
        {
            if (frmListofDD == null)
            {
                frmListofDD = new Application_Layer.Installment.InstReceive.frmListOfDD_ReadyForBankDeposite();
                frmListofDD.MdiParent = this;
                frmListofDD.WindowState = FormWindowState.Maximized;
                frmListofDD.FormClosed += FrmListofDD_FormClosed;
                radDock1.ActivateMdiChild(frmListofDD);
                frmListofDD.Show();
            }
            else
            {
                frmListofDD.Activate();
            }
        }

        private void FrmListofDD_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmListofDD = null;
        }
        #endregion

        #region File Add to Entry Section
        Application_Layer.FileMap.Add_File_In_AllFile_Table.frmCreateFile frmCreateFile;
        private void AddFile_Click(object sender, EventArgs e)
        {
            if (frmCreateFile == null)
            {
                frmCreateFile = new Application_Layer.FileMap.Add_File_In_AllFile_Table.frmCreateFile();
                frmCreateFile.MdiParent = this;
                frmCreateFile.WindowState = FormWindowState.Maximized;
                frmCreateFile.FormClosed += FrmCreateFile_FormClosed;
                radDock1.ActivateMdiChild(frmCreateFile);
                frmCreateFile.Show();
            }
            else
            {
                frmCreateFile.Activate();
            }

        }
        private void FrmCreateFile_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCreateFile = null;
        }
        #endregion

        #region File Search to Entry Section
        Application_Layer.FileMap.Add_File_In_AllFile_Table.frmModifyFile modifyFile;
        private void FileSearchInfo_Click(object sender, EventArgs e)
        {
            if (modifyFile == null)
            {
                modifyFile = new Application_Layer.FileMap.Add_File_In_AllFile_Table.frmModifyFile();
                modifyFile.MdiParent = this;
                modifyFile.WindowState = FormWindowState.Maximized;
                modifyFile.FormClosed += ModifyFile_FormClosed;
                radDock1.ActivateMdiChild(modifyFile);
                modifyFile.Show();
            }
            else
            {
                modifyFile.Activate();
            }
        }
        private void ModifyFile_FormClosed(object sender, FormClosedEventArgs e)
        {
            modifyFile = null;
        }
        #endregion

        #region Transfer Summary
        Application_Layer.TransferSummary.frmTransferSummary objfrmTransferSummary;
        private void btnFileState_Click(object sender, EventArgs e)
        {
            if (objfrmTransferSummary == null)
            {
                objfrmTransferSummary = new Application_Layer.TransferSummary.frmTransferSummary();
                objfrmTransferSummary.MdiParent = this;
                objfrmTransferSummary.WindowState = FormWindowState.Maximized;
                objfrmTransferSummary.FormClosed += ObjfrmTransferSummary_FormClosed;
                radDock1.ActivateMdiChild(objfrmTransferSummary);
                objfrmTransferSummary.Show();
            }
            else
            {
                objfrmTransferSummary.Activate();
            }

        }

        private void ObjfrmTransferSummary_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmTransferSummary = null;
        }
        #endregion

        #region DD Bulkk Clearing
        Application_Layer.Installment.InstReceive.frmClearingListOfDD_ReadyForBankDeposite frmclearingDDobj;
        private void btnDDClear_Click(object sender, EventArgs e)
        {
            if (frmclearingDDobj == null)
            {
                frmclearingDDobj = new frmClearingListOfDD_ReadyForBankDeposite();
                frmclearingDDobj.MdiParent = this;
                frmclearingDDobj.WindowState = FormWindowState.Maximized;
                frmclearingDDobj.FormClosed += FrmclearingDDobj_FormClosed;
                radDock1.ActivateMdiChild(frmclearingDDobj);
                frmclearingDDobj.Show();
            }
            else
            {
                frmclearingDDobj.Activate();
            }
        }

        private void FrmclearingDDobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmclearingDDobj = null;
        }
        #endregion

        #region Reconcile
        Application_Layer.Installment.InstallmentSummary.Recalculation_Files_For_Statement objReconcile;
        private void btnReconcile_Click(object sender, EventArgs e)
        {
            if (objReconcile == null)
            {
                objReconcile = new Application_Layer.Installment.InstallmentSummary.Recalculation_Files_For_Statement();
                objReconcile.MdiParent = this;
                objReconcile.WindowState = FormWindowState.Maximized;
                objReconcile.FormClosed += ObjReconcile_FormClosed;
                radDock1.ActivateMdiChild(objReconcile);
                objReconcile.Show();
            }
            else
            {
                objReconcile.Activate();
            }
        }

        private void ObjReconcile_FormClosed(object sender, FormClosedEventArgs e)
        {
            objReconcile = null;
        }
        #endregion

        #region New Stamp Duty
        Application_Layer.StampDuty.frmStampDuty_Create objectfrmStampDuty;
        private void btnNewStampDuty_Click(object sender, EventArgs e)
        {
            if (objectfrmStampDuty == null)
            {
                objectfrmStampDuty = new Application_Layer.StampDuty.frmStampDuty_Create();
                objectfrmStampDuty.MdiParent = this;
                objectfrmStampDuty.WindowState = FormWindowState.Maximized;
                objectfrmStampDuty.FormClosed += ObjectfrmStampDuty_FormClosed;
                radDock1.ActivateMdiChild(objectfrmStampDuty);
                objectfrmStampDuty.Show();
            }
            else
            {
                objectfrmStampDuty.Activate();
            }
        }

        private void ObjectfrmStampDuty_FormClosed(object sender, FormClosedEventArgs e)
        {
            objectfrmStampDuty = null;
        }
        #endregion

        #region Stamp Duty Search
        Application_Layer.StampDuty.frmStampDuty_Search objectsearchfrmStampDuty;
        private void btnSearchStampDuty_Click(object sender, EventArgs e)
        {
            if (objectsearchfrmStampDuty == null)
            {
                objectsearchfrmStampDuty = new Application_Layer.StampDuty.frmStampDuty_Search();
                objectsearchfrmStampDuty.MdiParent = this;
                objectsearchfrmStampDuty.WindowState = FormWindowState.Maximized;
                objectsearchfrmStampDuty.FormClosed += ObjectsearchfrmStampDuty_FormClosed;
                radDock1.ActivateMdiChild(objectsearchfrmStampDuty);
                objectsearchfrmStampDuty.Show();
            }
            else
            {
                objectsearchfrmStampDuty.Activate();
            }
        }

        private void ObjectsearchfrmStampDuty_FormClosed(object sender, FormClosedEventArgs e)
        {
            objectsearchfrmStampDuty = null;
        }
        #endregion

        #region Stamp Duty Modify
        Application_Layer.StampDuty.frm_StampDuty_Modification objectEditfrmStampDuty;
        private void btnEditStampDuty_Click(object sender, EventArgs e)
        {
            if (objectEditfrmStampDuty == null)
            {
                objectEditfrmStampDuty = new Application_Layer.StampDuty.frm_StampDuty_Modification();
                objectEditfrmStampDuty.MdiParent = this;
                objectEditfrmStampDuty.WindowState = FormWindowState.Maximized;
                objectEditfrmStampDuty.FormClosed += ObjectEditfrmStampDuty_FormClosed;
                radDock1.ActivateMdiChild(objectEditfrmStampDuty);
                objectEditfrmStampDuty.Show();
            }
            else
            {
                objectEditfrmStampDuty.Activate();
            }
        }

        private void ObjectEditfrmStampDuty_FormClosed(object sender, FormClosedEventArgs e)
        {
            objectEditfrmStampDuty = null;
        }
        #endregion

        //Application_Layer.Installment.Surcharge.frm_SurchargeWaveoffNew objnewsurcharge;
        Application_Layer.Installment.Surcharge.frmNewSurchargeRecordViewer objnewsurcharge;
        private void btnNewWavieroff_Click(object sender, EventArgs e)
        {
            if (objnewsurcharge == null)
            {
                objnewsurcharge = new Application_Layer.Installment.Surcharge.frmNewSurchargeRecordViewer();
                objnewsurcharge.MdiParent = this;
                objnewsurcharge.WindowState = FormWindowState.Maximized;
                objnewsurcharge.FormClosed += Objnewsurcharge_FormClosed;
                radDock1.ActivateMdiChild(objnewsurcharge);
                objnewsurcharge.Show();
            }
            else
            {
                objnewsurcharge.Activate();
            }
        }

        private void Objnewsurcharge_FormClosed(object sender, FormClosedEventArgs e)
        {
            objnewsurcharge = null;
        }

        // Application_Layer.Installment.Surcharge.frm_SurchargeWaveoffSearch objsearcsurcharge;
         Application_Layer.Installment.Surcharge.frmNewSurchargeLock objsearcsurchargelock;
        private void btnSearchWavieroff_Click(object sender, EventArgs e)
        {
            if (objsearcsurchargelock == null)
            {
                objsearcsurchargelock = new Application_Layer.Installment.Surcharge.frmNewSurchargeLock();
                objsearcsurchargelock.MdiParent = this;
                objsearcsurchargelock.WindowState = FormWindowState.Maximized;
                objsearcsurchargelock.FormClosed += Objsearcsurchargelock_FormClosed;
                radDock1.ActivateMdiChild(objsearcsurchargelock);
                objsearcsurchargelock.Show();
            }
            else
            {
                objsearcsurchargelock.Activate();
            }
        }

        private void Objsearcsurchargelock_FormClosed(object sender, FormClosedEventArgs e)
        {
            objsearcsurchargelock = null;
        }


        // Application_Layer.Installment.Surcharge.frm_SurchareWaveoffModify objeditsurcharge;
        Application_Layer.Installment.Surcharge.frmNewSurchargeRequestModify objsearcsurcharge;
        private void btnEditWavieroff_Click(object sender, EventArgs e)
        {
            if (objsearcsurcharge == null)
            {
                objsearcsurcharge = new Application_Layer.Installment.Surcharge.frmNewSurchargeRequestModify();
                objsearcsurcharge.MdiParent = this;
                objsearcsurcharge.WindowState = FormWindowState.Maximized;
                objsearcsurcharge.FormClosed += Objsearcsurcharge_FormClosed; ;
                radDock1.ActivateMdiChild(objsearcsurcharge);
                objsearcsurcharge.Show();
            }
            else
            {
                objsearcsurcharge.Activate();
            }
        }

        private void Objsearcsurcharge_FormClosed(object sender, FormClosedEventArgs e)
        {
            objsearcsurcharge = null;
        }

        private void btnDailyList_Click(object sender, EventArgs e)
        {
            Application_Layer.Installment.InstReceive.frm_DailyReportGenerationforAllPlot obj = new frm_DailyReportGenerationforAllPlot();
            obj.MdiParent = this;
            obj.WindowState = FormWindowState.Maximized;
            obj.Show();
        }

        Application_Layer.Installment.InstReceive.frm_NatureOfDDAmount objNatureofDD;
        private void btnNatureDD_Click(object sender, EventArgs e)
        {
            if (objNatureofDD == null)
            {
                objNatureofDD = new Application_Layer.Installment.InstReceive.frm_NatureOfDDAmount();
                objNatureofDD.MdiParent = this;
                objNatureofDD.WindowState = FormWindowState.Maximized;
                objNatureofDD.ThemeName = this.ThemeName;
                objNatureofDD.FormClosed += ObjNatureofDD_FormClosed;
                radDock1.ActivateMdiChild(objNatureofDD);
                objNatureofDD.Show();
            }
            else
            {
                objNatureofDD.Activate();
            }
        }

        private void ObjNatureofDD_FormClosed(object sender, FormClosedEventArgs e)
        {
            objNatureofDD = null;
        }

        #region Dir Transfer
        Application_Layer.Membership.Modify.frm_DirTransferDashBoard obj_frm_DirTransfer;
        private void MSEntryStatus_Click(object sender, EventArgs e)
        {
            if (obj_frm_DirTransfer == null)
            {
                obj_frm_DirTransfer = new Application_Layer.Membership.Modify.frm_DirTransferDashBoard();
                obj_frm_DirTransfer.MdiParent = this;
                obj_frm_DirTransfer.FormClosed += Obj_frm_DirTransfer_FormClosed; ;
                radDock1.ActivateMdiChild(obj_frm_DirTransfer);
                obj_frm_DirTransfer.Show();

            }
            else
            {

            }

        }

        private void Obj_frm_DirTransfer_FormClosed(object sender, FormClosedEventArgs e)
        {
            obj_frm_DirTransfer = null;
        }
        #endregion

        #region Account Statment Controls
        Application_Layer.Installment.Account_Statement.AccountStatementforCustomer objfrmfrmAccountStatement;
        private void btnAccountStatus_Click(object sender, EventArgs e)
        {
            if (objfrmfrmAccountStatement == null)
            {
                objfrmfrmAccountStatement = new Application_Layer.Installment.Account_Statement.AccountStatementforCustomer();
                objfrmfrmAccountStatement.MdiParent = this;
                objfrmfrmAccountStatement.WindowState = FormWindowState.Maximized;
                objfrmfrmAccountStatement.ThemeName = this.ThemeName;
                objfrmfrmAccountStatement.FormClosed += ObjfrmAcknowledgmentInformationSearch_FormClosed;
                radDock1.ActivateMdiChild(objfrmfrmAccountStatement);
                objfrmfrmAccountStatement.Show();
            }
            else
            {
                objfrmfrmAccountStatement.Activate();
            }
        }

        private void ObjfrmAcknowledgmentInformationSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmfrmAccountStatement = null;
        }

        Application_Layer.Installment.frmAccountStatement frmobjaccountstatment;
        private void btnAccountStatementDetail_Click(object sender, EventArgs e)
        {
            if (frmobjaccountstatment == null)
            {
                frmobjaccountstatment = new Application_Layer.Installment.frmAccountStatement();
                frmobjaccountstatment.MdiParent = this;
                frmobjaccountstatment.FormClosed += Frmobjaccountstatment_FormClosed;
                radDock1.ActivateMdiChild(frmobjaccountstatment);
                frmobjaccountstatment.Show();

            }
            else
            {

            }
        }

        private void Frmobjaccountstatment_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmobjaccountstatment = null;
        }
        Application_Layer.Installment.Account_Statement.AccountStatementinMSInformation objacstatementMS;
        private void btnAccountStatementCustomer_Click(object sender, EventArgs e)
        {
            if (objacstatementMS == null)
            {
                objacstatementMS = new Application_Layer.Installment.Account_Statement.AccountStatementinMSInformation();
                objacstatementMS.MdiParent = this;
                objacstatementMS.FormClosed += ObjacstatementMS_FormClosed;
                radDock1.ActivateMdiChild(frmobjaccountstatment);
                objacstatementMS.Show();

            }
            else
            {

            }
        }

        private void ObjacstatementMS_FormClosed(object sender, FormClosedEventArgs e)
        {
            objacstatementMS = null;
        }
        #endregion

        Application_Layer.Installment.InstallmentSummary.frmReceiptSummaryReport objReceiptSummaryReport;
        private void btnDateWiseReport_Click(object sender, EventArgs e)
        {
            if (objReceiptSummaryReport == null)
            {
                objReceiptSummaryReport = new Application_Layer.Installment.InstallmentSummary.frmReceiptSummaryReport();
                objReceiptSummaryReport.MdiParent = this;
                objReceiptSummaryReport.WindowState = FormWindowState.Maximized;
                objReceiptSummaryReport.ThemeName = this.ThemeName;
                objReceiptSummaryReport.FormClosed += ObjReceiptSummaryReport_FormClosed;
                radDock1.ActivateMdiChild(objReceiptSummaryReport);
                objReceiptSummaryReport.Show();
            }
            else
            {
                objReceiptSummaryReport.Activate();
            }
        }


        private void ObjReceiptSummaryReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            objReceiptSummaryReport = null;
        }
        Application_Layer.Transfer.Transfer_Information.Total_Transfer_Detail.frm_Total_Transfers alltransferrecords;
        private void btnTransferInfo_Click(object sender, EventArgs e)
        {
            if (alltransferrecords == null)
            {
                alltransferrecords = new Application_Layer.Transfer.Transfer_Information.Total_Transfer_Detail.frm_Total_Transfers();
                alltransferrecords.MdiParent = this;
                alltransferrecords.WindowState = FormWindowState.Maximized;
                alltransferrecords.ThemeName = this.ThemeName;
                alltransferrecords.FormClosed += Alltransferrecords_FormClosed;
                radDock1.ActivateMdiChild(alltransferrecords);
                alltransferrecords.Show();//TransferInfo---gpFileState
            }
            else
            {
                alltransferrecords.Activate();
            }
        }

        private void Alltransferrecords_FormClosed(object sender, FormClosedEventArgs e)
        {
            alltransferrecords = null;
        }

        private frmChallanSearch _objChallanSearch;
        private void btnCreateChallan_Click(object sender, EventArgs e)
        {
            if (_objChallanSearch == null)
            {
                _objChallanSearch = new frmChallanSearch();
                _objChallanSearch.MdiParent = this;
                _objChallanSearch.WindowState = FormWindowState.Maximized;
                _objChallanSearch.ThemeName = this.ThemeName;
                _objChallanSearch.FormClosed += ObjChallanCreate_FormClosed;
                radDock1.ActivateMdiChild(_objChallanSearch);
                _objChallanSearch.Show();//TransferInfo---gpFileState
            }
            else
            {
                _objChallanSearch.Activate();
            }
        }

        private void ObjChallanCreate_FormClosed(object sender, FormClosedEventArgs e)
        {
            _objChallanSearch = null;
        }

        private void radmainRibbon_ExpandedStateChanged(object sender, EventArgs e)
        {
            if (radmainRibbon.Expanded == true)
            {
                this.radDock1.Dock = DockStyle.Fill;
                radStatusStrip1.Visible = true;
            }
            else
            {
                this.radDock1.Dock = DockStyle.Fill;
                radStatusStrip1.Visible = false;
            }

        }

        private Application_Layer.Installment.DDTransfer.frm_DD_Transfer_Request objTransferRequest;
        private void btnDDTransferRequest_Click(object sender, EventArgs e)
        {
            if (objTransferRequest == null)
            {
                objTransferRequest = new frm_DD_Transfer_Request();
                objTransferRequest.MdiParent = this;
                objTransferRequest.WindowState = FormWindowState.Maximized;
                objTransferRequest.ThemeName = this.ThemeName;
                objTransferRequest.FormClosed += ObjTransferRequest_FormClosed;
                radDock1.ActivateMdiChild(objTransferRequest);
                objTransferRequest.Show();//TransferInfo---gpFileState
            }
            else
            {
                objTransferRequest.Activate();
            }
        }

        private void ObjTransferRequest_FormClosed(object sender, FormClosedEventArgs e)
        {
            objTransferRequest = null;
        }

        private Application_Layer.Installment.DDTransfer.frm_DD_Transfer_Basket objDdTransferBasket;
        private void btnDDTransferApproved_Click(object sender, EventArgs e)
        {
            if (objDdTransferBasket == null)
            {
                objDdTransferBasket = new frm_DD_Transfer_Basket();
                objDdTransferBasket.MdiParent = this;
                objDdTransferBasket.WindowState = FormWindowState.Maximized;
                objDdTransferBasket.ThemeName = this.ThemeName;
                objDdTransferBasket.FormClosed += ObjDdTransferBasket_FormClosed;
                radDock1.ActivateMdiChild(objDdTransferBasket);
                objDdTransferBasket.Show();//TransferInfo---gpFileState
            }
            else
            {
                objDdTransferBasket.Activate();
            }
        }

        private void ObjDdTransferBasket_FormClosed(object sender, FormClosedEventArgs e)
        {
            objDdTransferBasket = null;
        }

        private Application_Layer.Installment.InstReceive.frmKPKSaleTax objfrmKPKSaleTax;
        private void btnKpkSaleTax_Click(object sender, EventArgs e)
        {
            if (objfrmKPKSaleTax == null)
            {
                objfrmKPKSaleTax = new frmKPKSaleTax();
                objfrmKPKSaleTax.MdiParent = this;
                objfrmKPKSaleTax.WindowState = FormWindowState.Maximized;
                objfrmKPKSaleTax.ThemeName = this.ThemeName;
                objfrmKPKSaleTax.FormClosed += objfrmKPKSaleTax_FormClosed;
                radDock1.ActivateMdiChild(objfrmKPKSaleTax);
                objfrmKPKSaleTax.Show();
            }
            else
            {
                objfrmKPKSaleTax.Activate();
            }
        }

        private void objfrmKPKSaleTax_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmKPKSaleTax = null;
        }

        private Application_Layer.User.frmModifyUser objfrmModifyUser;
        private void btnModify_Click(object sender, EventArgs e)
        {
            if (objfrmModifyUser == null)
            {
                objfrmModifyUser = new frmModifyUser();
                objfrmModifyUser.MdiParent = this;
                objfrmModifyUser.WindowState = FormWindowState.Maximized;
                objfrmModifyUser.ThemeName = this.ThemeName;
                objfrmModifyUser.FormClosed += objfrmModifyUser_FormClosed;
                radDock1.ActivateMdiChild(objfrmModifyUser);
                objfrmModifyUser.Show();
            }
            else
            {
                objfrmModifyUser.Activate();
            }
        }

        private void objfrmModifyUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmModifyUser = null;
        }

        private Application_Layer.User.frmUserInfo objfrmSearchUser;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (objfrmSearchUser == null)
            {
                objfrmSearchUser = new frmUserInfo();
                objfrmSearchUser.MdiParent = this;
                objfrmSearchUser.WindowState = FormWindowState.Maximized;
                objfrmSearchUser.ThemeName = this.ThemeName;
                objfrmSearchUser.FormClosed += objfrmSearchUser_FormClosed;
                radDock1.ActivateMdiChild(objfrmSearchUser);
                objfrmSearchUser.Show();
            }
            else
            {
                objfrmSearchUser.Activate();
            }
        }

        private void objfrmSearchUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmSearchUser = null;
        }

        private Application_Layer.User.frmUserInsertion objfrmUserInsertion;
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (objfrmSearchUser == null)
            {
                objfrmUserInsertion = new frmUserInsertion();
                objfrmUserInsertion.MdiParent = this;
                objfrmUserInsertion.WindowState = FormWindowState.Maximized;
                objfrmUserInsertion.ThemeName = this.ThemeName;
                objfrmUserInsertion.FormClosed += objfrmUserInsertion_FormClosed;
                radDock1.ActivateMdiChild(objfrmUserInsertion);
                objfrmUserInsertion.Show();
            }
            else
            {
                objfrmUserInsertion.Activate();
            }
        }

        private void objfrmUserInsertion_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmUserInsertion = null;
        }

        private frmChallanReport _objChallanReport;
        private void btnChallanReport_Click(object sender, EventArgs e)
        {
            if (_objChallanReport == null)
            {
                _objChallanReport = new frmChallanReport();
                _objChallanReport.MdiParent = this;
                _objChallanReport.WindowState = FormWindowState.Maximized;
                _objChallanReport.ThemeName = this.ThemeName;
                _objChallanReport.FormClosed += ObjChallanReport_FormClosed;
                radDock1.ActivateMdiChild(_objChallanReport);
                _objChallanReport.Show();//TransferInfo---gpFileState
            }
            else
            {
                _objChallanReport.Activate();
            }
        }

        private void ObjChallanReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            _objChallanReport = null;
        }

        private frmInstRece_DateLock obj_IRDateLock;
        private void btnDateLock_Click(object sender, EventArgs e)
        {
            if (obj_IRDateLock == null)
            {
                obj_IRDateLock = new frmInstRece_DateLock();
                obj_IRDateLock.MdiParent = this;
                obj_IRDateLock.WindowState = FormWindowState.Maximized;
                obj_IRDateLock.ThemeName = this.ThemeName;
                obj_IRDateLock.FormClosed += Obj_IRDateLock_FormClosed;
                radDock1.ActivateMdiChild(obj_IRDateLock);
                obj_IRDateLock.Show();//TransferInfo---gpFileState
            }
            else
            {
                obj_IRDateLock.Activate();
            }
        }

        private void Obj_IRDateLock_FormClosed(object sender, FormClosedEventArgs e)
        {
            obj_IRDateLock = null;
        }

        private frmFileCancelationInitial objfrmFileCancelationInitial;
        private void btnFileCancRequest_Click(object sender, EventArgs e)
        {
            if (objfrmFileCancelationInitial == null)
            {
                objfrmFileCancelationInitial = new frmFileCancelationInitial();
                objfrmFileCancelationInitial.MdiParent = this;
                objfrmFileCancelationInitial.WindowState = FormWindowState.Maximized;
                objfrmFileCancelationInitial.ThemeName = this.ThemeName;
                objfrmFileCancelationInitial.FormClosed += objfrmFileCancelationInitial_FormClosed;
                radDock1.ActivateMdiChild(objfrmFileCancelationInitial);
                objfrmFileCancelationInitial.Show();//TransferInfo---gpFileState
            }
            else
            {
                objfrmFileCancelationInitial.Activate();
            }
        }

        private void objfrmFileCancelationInitial_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmFileCancelationInitial = null;
        }


        private frmFileCancelationInformation objFileCancelationInformation;
        private void FileCancApproval_Click(object sender, EventArgs e)
        {
            if (objFileCancelationInformation == null)
            {
                objFileCancelationInformation = new frmFileCancelationInformation();
                objFileCancelationInformation.MdiParent = this;
                objFileCancelationInformation.WindowState = FormWindowState.Maximized;
                objFileCancelationInformation.ThemeName = this.ThemeName;
                objFileCancelationInformation.FormClosed += objFileCancelationInformation_FormClosed;
                radDock1.ActivateMdiChild(objFileCancelationInformation);
                objFileCancelationInformation.Show();//TransferInfo---gpFileState
            }
            else
            {
                objFileCancelationInformation.Activate();
            }
        }

        private void objFileCancelationInformation_FormClosed(object sender, FormClosedEventArgs e)
        {
            objFileCancelationInformation = null;
        }

        private Application_Layer.DashBoards.frm_FinDashBoard frm_findashboard;
        private void btnsummaries_Click(object sender, EventArgs e)
        {
            if (frm_findashboard == null)
            {
                frm_findashboard = new Application_Layer.DashBoards.frm_FinDashBoard();
                frm_findashboard.MdiParent = this;
                frm_findashboard.WindowState = FormWindowState.Maximized;
                frm_findashboard.ThemeName = this.ThemeName;
                frm_findashboard.FormClosed += Frm_findashboard_FormClosed;
                radDock1.ActivateMdiChild(frm_findashboard);
                frm_findashboard.Show();//TransferInfo---gpFileState
            }
            else
            {
                objFileCancelationInformation.Activate();
            }
        }

        private void Frm_findashboard_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm_findashboard = null;
        }

        //     private Application_Layer.Installment.Surcharge.SurchargeWaiveOffList frmSurchargeWaiveOffList;
        private Application_Layer.Installment.Surcharge.frmNewSurchargeWavierApproval frmSurchargeWaiveOffList;
        private void btnApprovedSurchWav_Click(object sender, EventArgs e)
        {
            if (frmSurchargeWaiveOffList == null)
            {
                frmSurchargeWaiveOffList = new Application_Layer.Installment.Surcharge.frmNewSurchargeWavierApproval();
                frmSurchargeWaiveOffList.MdiParent = this;
                frmSurchargeWaiveOffList.WindowState = FormWindowState.Maximized;
                frmSurchargeWaiveOffList.ThemeName = this.ThemeName;
                frmSurchargeWaiveOffList.FormClosed += frmSurchargeWaiveOffList_FormClosed;
                radDock1.ActivateMdiChild(frmSurchargeWaiveOffList);
                frmSurchargeWaiveOffList.Show();//TransferInfo---gpFileState
            }
            else
            {
                frmSurchargeWaiveOffList.Activate();
            }
        }

        private void frmSurchargeWaiveOffList_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSurchargeWaiveOffList = null;
        }
        //
        private Application_Layer.Installment.Surcharge.frmSurchageWaiveOffRequest frmfrmSurchageWaiveOffRequest;
        private void btnChallanWaOfReq_Click(object sender, EventArgs e)
        {
            if (frmfrmSurchageWaiveOffRequest == null)
            {
                frmfrmSurchageWaiveOffRequest = new Application_Layer.Installment.Surcharge.frmSurchageWaiveOffRequest();
                frmfrmSurchageWaiveOffRequest.MdiParent = this;
                frmfrmSurchageWaiveOffRequest.WindowState = FormWindowState.Maximized;
                frmfrmSurchageWaiveOffRequest.ThemeName = this.ThemeName;
                frmfrmSurchageWaiveOffRequest.FormClosed += frmfrmSurchageWaiveOffRequest_FormClosed;
                radDock1.ActivateMdiChild(frmfrmSurchageWaiveOffRequest);
                frmfrmSurchageWaiveOffRequest.Show();//TransferInfo---gpFileState
            }
            else
            {
                frmfrmSurchageWaiveOffRequest.Activate();
            }
        }

        private void frmfrmSurchageWaiveOffRequest_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmfrmSurchageWaiveOffRequest = null;
        }

        private Application_Layer.Acknowledgement.frmAckQSR frmAckQSR;
        private void btnQSR_Click(object sender, EventArgs e)
        {
            if (frmAckQSR == null)
            {
                frmAckQSR = new Application_Layer.Acknowledgement.frmAckQSR();
                frmAckQSR.MdiParent = this;
                frmAckQSR.WindowState = FormWindowState.Maximized;
                frmAckQSR.ThemeName = this.ThemeName;
                frmAckQSR.FormClosed += FrmAckQSR_FormClosed; ;
                radDock1.ActivateMdiChild(frmAckQSR);
                frmAckQSR.Show();//TransferInfo---gpFileState
            }
            else
            {
                frmAckQSR.Activate();
            }
        }

        private void FrmAckQSR_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmAckQSR = null;
        }

        private Application_Layer.Caution.Caution_Create frmcautionCreate;
        private void btnCautionCreate_Click(object sender, EventArgs e)
        {
            if (frmcautionCreate == null)
            {
                frmcautionCreate = new Caution_Create();
                frmcautionCreate.MdiParent = this;
                frmcautionCreate.WindowState = FormWindowState.Maximized;
                frmcautionCreate.ThemeName = this.ThemeName;
                frmcautionCreate.FormClosed += FrmcautionCreate_FormClosed;
                radDock1.ActivateMdiChild(frmcautionCreate);
                frmcautionCreate.Show();
            }
            else
            {
                frmcautionCreate.Activate();
            }
        }

        private void FrmcautionCreate_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmcautionCreate = null;
        }

        private Application_Layer.Caution.Caution_Search frmcautionSearch;
        private void btnCautionSearch_Click(object sender, EventArgs e)
        {
            if (frmcautionSearch == null)
            {
                frmcautionSearch = new Caution_Search();
                frmcautionSearch.MdiParent = this;
                frmcautionSearch.WindowState = FormWindowState.Maximized;
                frmcautionSearch.ThemeName = this.ThemeName;
                frmcautionSearch.FormClosed += FrmcautionSearch_FormClosed;
                radDock1.ActivateMdiChild(frmcautionSearch);
                frmcautionSearch.Show();
            }
            else
            {
                frmcautionSearch.Activate();
            }
        }

        private void FrmcautionSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmcautionSearch = null;
        }

        private Application_Layer.Caution.Caution_Remove frmcautionremove;
        private void btnCautionModify_Click(object sender, EventArgs e)
        {
            if (frmcautionremove == null)
            {
                frmcautionremove = new Caution_Remove();
                frmcautionremove.MdiParent = this;
                frmcautionremove.WindowState = FormWindowState.Maximized;
                frmcautionremove.ThemeName = this.ThemeName;
                frmcautionremove.FormClosed += Frmcautionremove_FormClosed;
                radDock1.ActivateMdiChild(frmcautionremove);
                frmcautionremove.Show();
            }
            else
            {
                frmcautionremove.Activate();
            }
        }

        private void Frmcautionremove_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmcautionremove = null;
        }

        private Application_Layer.Chalan.frmChallanVerification frmChallanVerification;
        private void btnChallanVerification_Click(object sender, EventArgs e)
        {
            if (frmChallanVerification == null)
            {
                frmChallanVerification = new frmChallanVerification();
                frmChallanVerification.MdiParent = this;
                frmChallanVerification.WindowState = FormWindowState.Maximized;
                frmChallanVerification.ThemeName = this.ThemeName;
                frmChallanVerification.FormClosed += FrmChallanVerification_FormClosed;
                radDock1.ActivateMdiChild(frmChallanVerification);
                frmChallanVerification.Show();
            }
            else
            {
                frmChallanVerification.Activate();
            }
        }

        private void FrmChallanVerification_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmChallanVerification = null;
        }

        private Application_Layer.Installment.AcknowledgmentSearch.frmCRSAcknowledgementDispatch frmCRSAck;
        private void btnSMSSend_Click(object sender, EventArgs e)
        {
            if (frmCRSAck == null)
            {
                frmCRSAck = new Application_Layer.Installment.AcknowledgmentSearch.frmCRSAcknowledgementDispatch();
                frmCRSAck.MdiParent = this;
                frmCRSAck.WindowState = FormWindowState.Maximized;
                frmCRSAck.ThemeName = this.ThemeName;
                frmCRSAck.FormClosed += FrmCRSAck_FormClosed;
                radDock1.ActivateMdiChild(frmCRSAck);
                frmCRSAck.Show();
            }
            else
            {
                frmCRSAck.Activate();
            }
        }

        private void FrmCRSAck_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCRSAck = null;
        }

        Application_Layer.Acknowledgement.frm_BulkPrinterofAcknowledgement objfrmAcknowledgement_UserBaseCRS;
        private void btnCRSAckBulkPrinting_Click(object sender, EventArgs e)
        {
            if (objfrmAcknowledgement_UserBaseCRS == null)
            {
                objfrmAcknowledgement_UserBaseCRS = new Application_Layer.Acknowledgement.frm_BulkPrinterofAcknowledgement();
                objfrmAcknowledgement_UserBaseCRS.MdiParent = this;
                objfrmAcknowledgement_UserBaseCRS.WindowState = FormWindowState.Maximized;
                objfrmAcknowledgement_UserBaseCRS.ThemeName = this.ThemeName;
                objfrmAcknowledgement_UserBaseCRS.FormClosed += ObjfrmAcknowledgement_UserBaseCRS_FormClosed; ;
                radDock1.ActivateMdiChild(objfrmAcknowledgement_UserBaseCRS);
                objfrmAcknowledgement_UserBaseCRS.Show();
            }
            else
            {
                objfrmAcknowledgement_UserBaseCRS.Activate();
            }
        }

        private void ObjfrmAcknowledgement_UserBaseCRS_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmAcknowledgement_UserBaseCRS = null;
        }

        private Application_Layer.CRSection.frmLetterDataInfo frmDataInfoCRS;
        private void btnLetterInfo_Click(object sender, EventArgs e)
        {
            if (frmDataInfoCRS == null)
            {
                frmDataInfoCRS = new Application_Layer.CRSection.frmLetterDataInfo();
                frmDataInfoCRS.MdiParent = this;
                frmDataInfoCRS.WindowState = FormWindowState.Maximized;
                frmDataInfoCRS.ThemeName = this.ThemeName;
                frmDataInfoCRS.FormClosed += FrmDataInfoCRS_FormClosed;
                radDock1.ActivateMdiChild(frmDataInfoCRS);
                frmDataInfoCRS.Show();
            }
            else
            {
                frmDataInfoCRS.Activate();
            }
        }
        private void FrmDataInfoCRS_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmDataInfoCRS = null;
        }

        Application_Layer.FileMap.LandBrFile.frmLandBrFileCreate frmlandbrCreateobject;
        private void btnFileWithSch_Click(object sender, EventArgs e)
        {
            if (frmlandbrCreateobject == null)
            {
                frmlandbrCreateobject = new Application_Layer.FileMap.LandBrFile.frmLandBrFileCreate();
                frmlandbrCreateobject.MdiParent = this;
                frmlandbrCreateobject.WindowState = FormWindowState.Maximized;
                frmlandbrCreateobject.ThemeName = this.ThemeName;
                frmlandbrCreateobject.FormClosed += FrmlandbrCreateobject_FormClosed;
                radDock1.ActivateMdiChild(frmlandbrCreateobject);
                frmlandbrCreateobject.Show();
            }
            else
            {
                frmlandbrCreateobject.Activate();
            }
        }

        private void FrmlandbrCreateobject_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmlandbrCreateobject = null;
        }


        Application_Layer.Caution.frmCautionCheckForSalePurchase frmCautionForSaleObject;
        private void btnCautionFileCheck_Click(object sender, EventArgs e)
        {
            if (frmCautionForSaleObject == null)
            {
                frmCautionForSaleObject = new Application_Layer.Caution.frmCautionCheckForSalePurchase();
                frmCautionForSaleObject.MdiParent = this;
                frmCautionForSaleObject.WindowState = FormWindowState.Maximized;
                frmCautionForSaleObject.ThemeName = this.ThemeName;
                frmCautionForSaleObject.FormClosed += FrmCautionForSaleObject_FormClosed;
                radDock1.ActivateMdiChild(frmlandbrCreateobject);
                frmCautionForSaleObject.Show();
            }
            else
            {
                frmCautionForSaleObject.Activate();
            }
        }

        private void FrmCautionForSaleObject_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCautionForSaleObject = null;
        }

        Application_Layer.FileMap.SvcBenefitFiles.frmSvcCreateFile frmsvccreatefileobj;
        private void btnNewSvcBenefitFile_Click(object sender, EventArgs e)
        {
            if (frmsvccreatefileobj == null)
            {
                frmsvccreatefileobj = new Application_Layer.FileMap.SvcBenefitFiles.frmSvcCreateFile();
                frmsvccreatefileobj.MdiParent = this;
                frmsvccreatefileobj.WindowState = FormWindowState.Maximized;
                frmsvccreatefileobj.ThemeName = this.ThemeName;
                frmsvccreatefileobj.FormClosed += Frmsvccreatefileobj_FormClosed; ;
                radDock1.ActivateMdiChild(frmsvccreatefileobj);
                frmsvccreatefileobj.Show();
            }
            else
            {
                frmsvccreatefileobj.Activate();
            }
        }

        private void Frmsvccreatefileobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmsvccreatefileobj = null;
        }
        Application_Layer.NDC.Baskets.frmShowAllNDC_and_TransferLetter frmPrvsNDCTFRLetterobj;
        private void btnNDC_PreviousNDCTransfer_Click(object sender, EventArgs e)
        {
            if (frmPrvsNDCTFRLetterobj == null)
            {
                frmPrvsNDCTFRLetterobj = new Application_Layer.NDC.Baskets.frmShowAllNDC_and_TransferLetter();
                frmPrvsNDCTFRLetterobj.MdiParent = this;
                frmPrvsNDCTFRLetterobj.WindowState = FormWindowState.Maximized;
                frmPrvsNDCTFRLetterobj.ThemeName = this.ThemeName;
                frmPrvsNDCTFRLetterobj.FormClosed += FrmPrvsNDCTFRLetterobj_FormClosed;
                radDock1.ActivateMdiChild(frmPrvsNDCTFRLetterobj);
                frmPrvsNDCTFRLetterobj.Show();
            }
            else
            {
                frmPrvsNDCTFRLetterobj.Activate();
            }
        }

        private void FrmPrvsNDCTFRLetterobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmPrvsNDCTFRLetterobj = null;
        }

        Application_Layer.FileMap.SvcBenefitFiles.frmSvcCreateFile objfrmSvcBenefit;
        private void btnNewMiltaryFiles_Click(object sender, EventArgs e)
        {
            if (objfrmSvcBenefit == null)
            {
                objfrmSvcBenefit = new Application_Layer.FileMap.SvcBenefitFiles.frmSvcCreateFile();
                objfrmSvcBenefit.MdiParent = this;
                objfrmSvcBenefit.WindowState = FormWindowState.Maximized;
                objfrmSvcBenefit.ThemeName = this.ThemeName;
                objfrmSvcBenefit.FormClosed += ObjfrmSvcBenefit_FormClosed;
                radDock1.ActivateMdiChild(objfrmSvcBenefit);
                objfrmSvcBenefit.Show();
            }
            else
            {
                objfrmSvcBenefit.Activate();
            }
        }

        private void ObjfrmSvcBenefit_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmSvcBenefit = null;
        }
        Application_Layer.FileMap.SvcBenefitFiles.frmSvcSearch objfrmSvcBenefitSearch;
        private void btnMiltaryFilesSearch_Click(object sender, EventArgs e)
        {
            if (objfrmSvcBenefitSearch == null)
            {
                objfrmSvcBenefitSearch = new Application_Layer.FileMap.SvcBenefitFiles.frmSvcSearch();
                objfrmSvcBenefitSearch.MdiParent = this;
                objfrmSvcBenefitSearch.WindowState = FormWindowState.Maximized;
                objfrmSvcBenefitSearch.ThemeName = this.ThemeName;
                objfrmSvcBenefitSearch.FormClosed += ObjfrmSvcBenefitSearch_FormClosed;
                radDock1.ActivateMdiChild(objfrmSvcBenefitSearch);
                objfrmSvcBenefitSearch.Show();
            }
            else
            {
                objfrmSvcBenefitSearch.Activate();
            }
        }

        private void ObjfrmSvcBenefitSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmSvcBenefitSearch = null;
        }


        Application_Layer.Installment.InstReceive.frmListOfDD_ReadyForBankDeposite_Head obj_DDListDH;
        private void btn_BankLis_tDetail_Click(object sender, EventArgs e)
        {
            if (obj_DDListDH == null)
            {
                obj_DDListDH = new frmListOfDD_ReadyForBankDeposite_Head();
                obj_DDListDH.MdiParent = this;
                obj_DDListDH.WindowState = FormWindowState.Maximized;
                obj_DDListDH.ThemeName = this.ThemeName;
                obj_DDListDH.FormClosed += Obj_DDListDH_FormClosed; ;
                radDock1.ActivateMdiChild(obj_DDListDH);
                obj_DDListDH.Show();
            }
            else
            {
                obj_DDListDH.Activate();
            }
        }

        private void Obj_DDListDH_FormClosed(object sender, FormClosedEventArgs e)
        {
            obj_DDListDH = null;
        }

        Application_Layer.FileBock.frmFileBlock objfrmfilelock;
        private void btnFileLock_Click(object sender, EventArgs e)
        {
            if (objfrmfilelock == null)
            {
                objfrmfilelock = new Application_Layer.FileBock.frmFileBlock();
                objfrmfilelock.MdiParent = this;
                objfrmfilelock.WindowState = FormWindowState.Maximized;
                objfrmfilelock.ThemeName = this.ThemeName;
                objfrmfilelock.FormClosed += Objfrmfilelock_FormClosed;
                radDock1.ActivateMdiChild(objfrmfilelock);
                objfrmfilelock.Show();
            }
            else
            {
                objfrmfilelock.Activate();
            }
        }

        private void Objfrmfilelock_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmfilelock = null;
        }
        Application_Layer.NDC.Baskets.frmNDCRenewal frmNDCRenew;
        private void btnNDCRenewal_Click(object sender, EventArgs e)
        {
            if (frmNDCRenew == null)
            {
                frmNDCRenew = new Application_Layer.NDC.Baskets.frmNDCRenewal();
                frmNDCRenew.MdiParent = this;
                frmNDCRenew.WindowState = FormWindowState.Maximized;
                frmNDCRenew.ThemeName = this.ThemeName;
                frmNDCRenew.FormClosed += FrmNDCRenew_FormClosed;
                radDock1.ActivateMdiChild(frmNDCRenew);
                frmNDCRenew.Show();
            }
            else
            {
                frmNDCRenew.Activate();
            }
        }

        private void FrmNDCRenew_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmNDCRenew = null;
        }
        Application_Layer.NDC.Baskets.frmNDCAgainstReport fbrreport;
        private void btnFBRReport_Click(object sender, EventArgs e)
        {
            if (fbrreport == null)
            {
                fbrreport = new Application_Layer.NDC.Baskets.frmNDCAgainstReport();
                fbrreport.MdiParent = this;
                fbrreport.WindowState = FormWindowState.Maximized;
                fbrreport.ThemeName = this.ThemeName;
                fbrreport.FormClosed += Fbrreport_FormClosed;
                radDock1.ActivateMdiChild(fbrreport);
                fbrreport.Show();
            }
            else
            {
                fbrreport.Activate();
            }
        }

        private void Fbrreport_FormClosed(object sender, FormClosedEventArgs e)
        {
            fbrreport = null;
        }
        Application_Layer.NDC.Baskets.frmNDCAgainstDetailReport fbrdetailreport;
        private void btnFBRDetailReport_Click(object sender, EventArgs e)
        {
            if (fbrdetailreport == null)
            {
                fbrdetailreport = new Application_Layer.NDC.Baskets.frmNDCAgainstDetailReport();
                fbrdetailreport.MdiParent = this;
                fbrdetailreport.WindowState = FormWindowState.Maximized;
                fbrdetailreport.ThemeName = this.ThemeName;
                fbrdetailreport.FormClosed += Fbrdetailreport_FormClosed;
                radDock1.ActivateMdiChild(fbrdetailreport);
                fbrdetailreport.Show();
            }
            else
            {
                fbrdetailreport.Activate();
            }
        }

        private void Fbrdetailreport_FormClosed(object sender, FormClosedEventArgs e)
        {
            fbrdetailreport = null;
        }
        Application_Layer.NDC.Baskets.frmCompleteTransfer cmptrf;
        private void btApproveNDC_Click(object sender, EventArgs e)
        {
            if (cmptrf == null)
            {
                cmptrf = new Application_Layer.NDC.Baskets.frmCompleteTransfer();
                cmptrf.MdiParent = this;
                cmptrf.WindowState = FormWindowState.Maximized;
                cmptrf.ThemeName = this.ThemeName;
                cmptrf.FormClosed += Cmptrf_FormClosed;
                radDock1.ActivateMdiChild(cmptrf);
                cmptrf.Show();
            }
            else
            {
                cmptrf.Activate();
            }
        }

        private void Cmptrf_FormClosed(object sender, FormClosedEventArgs e)
        {
            cmptrf = null;
        }
        Application_Layer.StampDuty.frmVerificationStampDuty stmver;
        private void btn_Verification_Click(object sender, EventArgs e)
        {
            if (stmver == null)
            {
                stmver = new Application_Layer.StampDuty.frmVerificationStampDuty();
                stmver.MdiParent = this;
                stmver.WindowState = FormWindowState.Maximized;
                stmver.ThemeName = this.ThemeName;
                stmver.FormClosed += Stmver_FormClosed;
                radDock1.ActivateMdiChild(stmver);
                stmver.Show();
            }
            else
            {
                stmver.Activate();
            }
        }

        private void Stmver_FormClosed(object sender, FormClosedEventArgs e)
        {
            stmver = null;
        }

        Application_Layer.NDC.FBR.frm_FBR_View fbrview;
        private void btnFBRModify_Click(object sender, EventArgs e)
        {
            if (fbrview == null)
            {
                fbrview = new Application_Layer.NDC.FBR.frm_FBR_View();
                fbrview.MdiParent = this;
                fbrview.WindowState = FormWindowState.Maximized;
                fbrview.ThemeName = this.ThemeName;
                fbrview.FormClosed += Fbrmfy_FormClosed;
                radDock1.ActivateMdiChild(fbrview);
                fbrview.Show();
            }
            else
            {
                fbrview.Activate();
            }
        }

        private void Fbrmfy_FormClosed(object sender, FormClosedEventArgs e)
        {
            fbrview = null;
        }
        Application_Layer.NDC.FBR.frmImportFBRDatafrom_ExcelToDatabase fbrimport;
        private void btnFBRDataImportToDatabase_Click(object sender, EventArgs e)
        {
            if (fbrimport == null)
            {
                fbrimport = new Application_Layer.NDC.FBR.frmImportFBRDatafrom_ExcelToDatabase();
                fbrimport.MdiParent = this;
                fbrimport.WindowState = FormWindowState.Maximized;
                fbrimport.ThemeName = this.ThemeName;
                fbrimport.FormClosed += Fbrimport_FormClosed;
                radDock1.ActivateMdiChild(fbrimport);
                fbrimport.Show();
            }
            else
            {
                fbrimport.Activate();
            }
        }

        private void Fbrimport_FormClosed(object sender, FormClosedEventArgs e)
        {
            fbrimport = null;
        }


        Application_Layer.Refund.frmRefundRequest frmRefundRequest;
        private void btnRefundRequest_Click(object sender, EventArgs e)
        {
            if (frmRefundRequest == null)
            {
                frmRefundRequest = new Application_Layer.Refund.frmRefundRequest();
                frmRefundRequest.MdiParent = this;
                frmRefundRequest.WindowState = FormWindowState.Maximized;
                frmRefundRequest.ThemeName = this.ThemeName;
                frmRefundRequest.FormClosed += FrmRefundRequest_FormClosed;
                radDock1.ActivateMdiChild(frmRefundRequest);
                frmRefundRequest.Show();
            }
            else
            {
                frmRefundRequest.Activate();
            }
        }

        private void FrmRefundRequest_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmRefundRequest = null;
        }
        Application_Layer.Refund.frmRefundProcess frmRefundProcessobj;
        private void btnRefundApproved_Click(object sender, EventArgs e)
        {

            if (frmRefundProcessobj == null)
            {
                frmRefundProcessobj = new Application_Layer.Refund.frmRefundProcess();
                frmRefundProcessobj.MdiParent = this;
                frmRefundProcessobj.WindowState = FormWindowState.Maximized;
                frmRefundProcessobj.ThemeName = this.ThemeName;
                frmRefundProcessobj.FormClosed += FrmRefundProcessobj_FormClosed;
                radDock1.ActivateMdiChild(frmRefundProcessobj);
                frmRefundProcessobj.Show();
            }
            else
            {
                frmRefundProcessobj.Activate();
            }
        }

        private void FrmRefundProcessobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmRefundProcessobj = null;
        }
        Application_Layer.StampDuty.frmStampDutyBulkReportGetData frmStampDutybulkreportObj;
        private void btnStampDutyBulkReport_Click(object sender, EventArgs e)
        {
            if (frmStampDutybulkreportObj == null)
            {
                frmStampDutybulkreportObj = new Application_Layer.StampDuty.frmStampDutyBulkReportGetData();
                frmStampDutybulkreportObj.MdiParent = this;
                frmStampDutybulkreportObj.WindowState = FormWindowState.Maximized;
                frmStampDutybulkreportObj.ThemeName = this.ThemeName;
                frmStampDutybulkreportObj.FormClosed += FrmStampDutybulkreportObj_FormClosed;
                radDock1.ActivateMdiChild(frmStampDutybulkreportObj);
                frmStampDutybulkreportObj.Show();
            }
            else
            {
                frmStampDutybulkreportObj.Activate();
            }
        }

        private void FrmStampDutybulkreportObj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmStampDutybulkreportObj = null;
        }

        Application_Layer.NDC.NDC_Report.frmNDC_ReportBulk frmNDCBulkRptObj;
        private void btnNDCBulkReport_Click(object sender, EventArgs e)
        {
            if (frmNDCBulkRptObj == null)
            {
                frmNDCBulkRptObj = new Application_Layer.NDC.NDC_Report.frmNDC_ReportBulk();
                frmNDCBulkRptObj.MdiParent = this;
                frmNDCBulkRptObj.WindowState = FormWindowState.Maximized;
                frmNDCBulkRptObj.ThemeName = this.ThemeName;
                frmNDCBulkRptObj.FormClosed += FrmNDCBulkRptObj_FormClosed;
                radDock1.ActivateMdiChild(frmNDCBulkRptObj);
                frmNDCBulkRptObj.Show();
            }
            else
            {
                frmNDCBulkRptObj.Activate();
            }
        }

        private void FrmNDCBulkRptObj_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmNDCBulkRptObj = null;
        }

        Application_Layer.DashBoards.frmCustomReports objfrmCustomReports;
        private void btnAMReports_Click(object sender, EventArgs e)
        {
            if (objfrmCustomReports == null)
            {
                objfrmCustomReports = new Application_Layer.DashBoards.frmCustomReports();
                objfrmCustomReports.MdiParent = this;
                objfrmCustomReports.WindowState = FormWindowState.Maximized;
                objfrmCustomReports.ThemeName = this.ThemeName;
                objfrmCustomReports.FormClosed += ObjfrmCustomReports_FormClosed;
                radDock1.ActivateMdiChild(objfrmCustomReports);
                objfrmCustomReports.Show();
            }
            else
            {
                objfrmCustomReports.Activate();
            }
        }

        private void ObjfrmCustomReports_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmCustomReports = null;
        }
        Application_Layer.NDC.FBR.frm_FBR_Bulk_Report_GetData fbrbulkreport;
        private void btnFBRBulkReport_Click(object sender, EventArgs e)
        {
            if (fbrbulkreport == null)
            {
                fbrbulkreport = new Application_Layer.NDC.FBR.frm_FBR_Bulk_Report_GetData();
                fbrbulkreport.MdiParent = this;
                fbrbulkreport.WindowState = FormWindowState.Maximized;
                fbrbulkreport.ThemeName = this.ThemeName;
                fbrbulkreport.FormClosed += Fbrbulkreport_FormClosed;
                radDock1.ActivateMdiChild(fbrbulkreport);
                fbrbulkreport.Show();
            }
            else
            {
                fbrbulkreport.Activate();
            }
        }

        private void Fbrbulkreport_FormClosed(object sender, FormClosedEventArgs e)
        {
            fbrbulkreport = null;
        }

        Application_Layer.Installment.InstReceive.frmDDBankListSearch objddbllistsearch;
        private void btnBLDDSearch_Click(object sender, EventArgs e)
        {
            if (objddbllistsearch == null)
            {
                objddbllistsearch = new frmDDBankListSearch();
                objddbllistsearch.MdiParent = this;
                objddbllistsearch.WindowState = FormWindowState.Maximized;
                objddbllistsearch.ThemeName = this.ThemeName;
                objddbllistsearch.FormClosed += Objddbllistsearch_FormClosed;
                radDock1.ActivateMdiChild(objddbllistsearch);
                objddbllistsearch.Show();
            }
            else
            {
                objddbllistsearch.Activate();
            }
        }

        private void Objddbllistsearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            objddbllistsearch = null;
        }
        Application_Layer.NDC.NDC_FBR_Stm_Dashboard.frm_NDC_FBR_Stm_Dashboard objdashb;
        private void btnSumryRpt_Click(object sender, EventArgs e)
        {
            if (objdashb == null)
            {
                objdashb = new Application_Layer.NDC.NDC_FBR_Stm_Dashboard.frm_NDC_FBR_Stm_Dashboard();
                objdashb.MdiParent = this;
                objdashb.WindowState = FormWindowState.Maximized;
                objdashb.ThemeName = this.ThemeName;
                objdashb.FormClosed += Objdashb_FormClosed;
                radDock1.ActivateMdiChild(objdashb);
                objdashb.Show();
            }
            else
            {
                objdashb.Activate();
            }
        }

        private void Objdashb_FormClosed(object sender, FormClosedEventArgs e)
        {
            objdashb = null;
        }
        Application_Layer.Logging.frmLogHistoryForUser objlog_;
        private void radButtonElement25_Click(object sender, EventArgs e)
        {
            if (objlog_ == null)
            {
                objlog_ = new Application_Layer.Logging.frmLogHistoryForUser();
                objlog_.MdiParent = this;
                objlog_.WindowState = FormWindowState.Maximized;
                objlog_.ThemeName = this.ThemeName;
                objlog_.FormClosed += Objlog__FormClosed;
                radDock1.ActivateMdiChild(objlog_);
                objlog_.Show();
            }
            else
            {
                objlog_.Activate();
            }
        }

        private void Objlog__FormClosed(object sender, FormClosedEventArgs e)
        {
            objlog_ = null;
        }
        Application_Layer.Acknowledgement.IntimationReport objIntimation;
        private void btnIntimation_Click(object sender, EventArgs e)
        {
            if (objIntimation == null)
            {
                objIntimation = new Application_Layer.Acknowledgement.IntimationReport();
                objIntimation.MdiParent = this;
                objIntimation.WindowState = FormWindowState.Maximized;
                objIntimation.ThemeName = this.ThemeName;
                objIntimation.FormClosed += ObjIntimation_FormClosed;
                radDock1.ActivateMdiChild(objIntimation);
                objIntimation.Show();
            }
            else
            {
                objIntimation.Activate();
            }
        }

        private void ObjIntimation_FormClosed(object sender, FormClosedEventArgs e)
        {
            objIntimation = null;
        }

        Application_Layer.Launching.FinApplicationStatus objFin_ApplicationStatus;
        private void btnFinSummary_Click(object sender, EventArgs e)
        {
            if (objFin_ApplicationStatus == null)
            {
                objFin_ApplicationStatus = new Application_Layer.Launching.FinApplicationStatus();
                objFin_ApplicationStatus.MdiParent = this;
                objFin_ApplicationStatus.WindowState = FormWindowState.Maximized;
                objFin_ApplicationStatus.ThemeName = this.ThemeName;
                objFin_ApplicationStatus.FormClosed += ObjFin_ApplicationStatus_FormClosed;
                radDock1.ActivateMdiChild(objFin_ApplicationStatus);
                objFin_ApplicationStatus.Show();
            }
            else
            {
                objFin_ApplicationStatus.Activate();
            }
        }

        private void ObjFin_ApplicationStatus_FormClosed(object sender, FormClosedEventArgs e)
        {
            objFin_ApplicationStatus = null;
        }

        Application_Layer.Launching.FinBankReceiveInfoUploading objFin_Summary;
        private void btnUploadReceive_Click(object sender, EventArgs e)
        {
            if (objFin_Summary == null)
            {
                objFin_Summary = new Application_Layer.Launching.FinBankReceiveInfoUploading();
                objFin_Summary.MdiParent = this;
                objFin_Summary.WindowState = FormWindowState.Maximized;
                objFin_Summary.ThemeName = this.ThemeName;
                objFin_Summary.FormClosed += ObjFin_Summary_FormClosed;
                radDock1.ActivateMdiChild(objFin_Summary);
                objFin_Summary.Show();
            }
            else
            {
                objFin_Summary.Activate();
            }
        }

        private void ObjFin_Summary_FormClosed(object sender, FormClosedEventArgs e)
        {
            objFin_Summary = null;
        }

        Application_Layer.Launching.frmAllRecRecord objFin_Summary_AllRecord;
        private void btnBankAllTransaction_Click(object sender, EventArgs e)
        {
            if (objFin_Summary_AllRecord == null)
            {
                objFin_Summary_AllRecord = new Application_Layer.Launching.frmAllRecRecord();
                objFin_Summary_AllRecord.MdiParent = this;
                objFin_Summary_AllRecord.WindowState = FormWindowState.Maximized;
                objFin_Summary_AllRecord.ThemeName = this.ThemeName;
                objFin_Summary_AllRecord.FormClosed += ObjFin_Summary_AllRecord_FormClosed;
                radDock1.ActivateMdiChild(objFin_Summary_AllRecord);
                objFin_Summary_AllRecord.Show();
            }
            else
            {
                objFin_Summary_AllRecord.Activate();
            }
        }

        private void ObjFin_Summary_AllRecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            objFin_Summary_AllRecord = null;
        }

        Application_Layer.Launching.frmDocumentUpload objdocUpload;
        private void btnDocumentUpload_Click(object sender, EventArgs e)
        {
            if (objdocUpload == null)
            {
                objdocUpload = new Application_Layer.Launching.frmDocumentUpload();
                objdocUpload.MdiParent = this;
                objdocUpload.WindowState = FormWindowState.Maximized;
                objdocUpload.ThemeName = this.ThemeName;
                objdocUpload.FormClosed += ObjdocUpload_FormClosed;
                radDock1.ActivateMdiChild(objdocUpload);
                objdocUpload.Show();
            }
            else
            {
                objdocUpload.Activate();
            }
        }

        private void ObjdocUpload_FormClosed(object sender, FormClosedEventArgs e)
        {
            objdocUpload = null;
        }

        Application_Layer.Launching.frmDocumentAllRecords objdocallrecord;
        private void btnCompleteUploadedRecord_Click(object sender, EventArgs e)
        {
            if (objdocallrecord == null)
            {
                objdocallrecord = new Application_Layer.Launching.frmDocumentAllRecords();
                objdocallrecord.MdiParent = this;
                objdocallrecord.WindowState = FormWindowState.Maximized;
                objdocallrecord.ThemeName = this.ThemeName;
                objdocallrecord.FormClosed += Objdocallrecord_FormClosed;
                radDock1.ActivateMdiChild(objdocallrecord);
                objdocallrecord.Show();
            }
            else
            {
                objdocallrecord.Activate();
            }

        }

        private void Objdocallrecord_FormClosed(object sender, FormClosedEventArgs e)
        {
            objdocallrecord = null;
        }


        Application_Layer.Launching.frmDocumentModification objdocallrecordmodification;
        private void btnDocSetting_Click(object sender, EventArgs e)
        {
            if (objdocallrecordmodification == null)
            {
                objdocallrecordmodification = new Application_Layer.Launching.frmDocumentModification();
                objdocallrecordmodification.MdiParent = this;
                objdocallrecordmodification.WindowState = FormWindowState.Maximized;
                objdocallrecordmodification.ThemeName = this.ThemeName;
                objdocallrecordmodification.FormClosed += Objdocallrecordmodification_FormClosed;
                radDock1.ActivateMdiChild(objdocallrecordmodification);
                objdocallrecordmodification.Show();
            }
            else
            {
                objdocallrecordmodification.Activate();
            }
        }

        private void Objdocallrecordmodification_FormClosed(object sender, FormClosedEventArgs e)
        {
            objdocallrecordmodification = null;
        }
        //NewEmployee
        Application_Layer.Employee.NewEmployee objempinsertion;
        private void btnEmployeeInsertion_Click(object sender, EventArgs e)
        {
            if (objempinsertion == null)
            {
                objempinsertion = new Application_Layer.Employee.NewEmployee();
                objempinsertion.MdiParent = this;
                objempinsertion.WindowState = FormWindowState.Maximized;
                objempinsertion.ThemeName = this.ThemeName;
                objempinsertion.FormClosed += Objempinsertion_FormClosed;
                radDock1.ActivateMdiChild(objempinsertion);
                objempinsertion.Show();
            }
            else
            {
                objempinsertion.Activate();
            }
        }

        private void Objempinsertion_FormClosed(object sender, FormClosedEventArgs e)
        {
            objempinsertion = null;
        }
        Application_Layer.Employee.frmEmployeeSearch objempsearch;
        private void btnEmployeeSearch_Click(object sender, EventArgs e)
        {
            if (objempsearch == null)
            {
                objempsearch = new Application_Layer.Employee.frmEmployeeSearch();
                objempsearch.MdiParent = this;
                objempsearch.WindowState = FormWindowState.Maximized;
                objempsearch.ThemeName = this.ThemeName;
                objempsearch.FormClosed += Objempsearch_FormClosed;
                radDock1.ActivateMdiChild(objempsearch);
                objempsearch.Show();
            }
            else
            {
                objempsearch.Activate();
            }
        }

        private void Objempsearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            objempsearch = null;
        }
        Application_Layer.Employee.frmEmployeeModify objempmodify;
        private void btnEmployeeModify_Click(object sender, EventArgs e)
        {
            if (objempmodify == null)
            {
                objempmodify = new Application_Layer.Employee.frmEmployeeModify();
                objempmodify.MdiParent = this;
                objempmodify.WindowState = FormWindowState.Maximized;
                objempmodify.ThemeName = this.ThemeName;
                objempmodify.FormClosed += Objempmodify_FormClosed;
                radDock1.ActivateMdiChild(objempmodify);
                objempmodify.Show();
            }
            else
            {
                objempmodify.Activate();
            }
        }

      
        private void Objempmodify_FormClosed(object sender, FormClosedEventArgs e)
        {
            objempmodify = null;
        }

        Application_Layer.Marketing.BulkSMSSendingtoMembership objSMSSending;
        private void btnSMSSending_Click(object sender, EventArgs e)
        {
            if (objSMSSending == null)
            {
                objSMSSending = new Application_Layer.Marketing.BulkSMSSendingtoMembership();
                objSMSSending.MdiParent = this;
                objSMSSending.WindowState = FormWindowState.Maximized;
                objSMSSending.ThemeName = this.ThemeName;
                objSMSSending.FormClosed += ObjSMSSending_FormClosed;
                radDock1.ActivateMdiChild(objSMSSending);
                objSMSSending.Show();
            }
            else
            {
                objSMSSending.Activate();
            }
        }

        private void ObjSMSSending_FormClosed(object sender, FormClosedEventArgs e)
        {
            objSMSSending = null;
        }

        Application_Layer.NDC.Baskets.frm_NDCDealCancellationProcess objndcprocess;
        private void btnCancelNDC_Click(object sender, EventArgs e)
        {
            if (objndcprocess == null)
            {
                objndcprocess = new Application_Layer.NDC.Baskets.frm_NDCDealCancellationProcess();
                objndcprocess.MdiParent = this;
                objndcprocess.WindowState = FormWindowState.Maximized;
                objndcprocess.ThemeName = this.ThemeName;
                objndcprocess.FormClosed += Objndcprocess_FormClosed;
                radDock1.ActivateMdiChild(objndcprocess);
                objndcprocess.Show();
            }
            else
            {
                objndcprocess.Activate();
            }
        }

        private void Objndcprocess_FormClosed(object sender, FormClosedEventArgs e)
        {
            objndcprocess = null;
        }

        Application_Layer.Transfer.PlotsPosession.frmPosessionEntry objndcposs;
        private void btnPosCreate_Click(object sender, EventArgs e)
        {
            if (objndcposs == null)
            {
                objndcposs = new Application_Layer.Transfer.PlotsPosession.frmPosessionEntry();
                objndcposs.MdiParent = this;
                objndcposs.WindowState = FormWindowState.Maximized;
                objndcposs.ThemeName = this.ThemeName;
                objndcposs.FormClosed += Objndcposs_FormClosed;
                radDock1.ActivateMdiChild(objndcposs);
                objndcposs.Show();
            }
            else
            {
                objndcposs.Activate();
            }
        }

        private void Objndcposs_FormClosed(object sender, FormClosedEventArgs e)
        {
            objndcposs = null;
        }
        Application_Layer.Transfer.PlotsPosession.frmPosessionVerificationbyTFR objtfrpos;
        private void btnPosTFRVerification_Click(object sender, EventArgs e)
        {
            if (objtfrpos == null)
            {
                objtfrpos = new Application_Layer.Transfer.PlotsPosession.frmPosessionVerificationbyTFR();
                objtfrpos.MdiParent = this;
                objtfrpos.WindowState = FormWindowState.Maximized;
                objtfrpos.ThemeName = this.ThemeName;
                objtfrpos.FormClosed += Objtfrpos_FormClosed;
                radDock1.ActivateMdiChild(objtfrpos);
                objtfrpos.Show();
            }
            else
            {
                objtfrpos.Activate();
            }
        }

        private void Objtfrpos_FormClosed(object sender, FormClosedEventArgs e)
        {
            objtfrpos = null;
        }
        Application_Layer.PlotsPosession.frmPosessionRcievedByFinanceBr objfinpos;
        private void btnFinanceVerification_Click(object sender, EventArgs e)
        {

            if (objfinpos == null)
            {
                objfinpos = new Application_Layer.PlotsPosession.frmPosessionRcievedByFinanceBr();
                objfinpos.MdiParent = this;
                objfinpos.WindowState = FormWindowState.Maximized;
                objfinpos.ThemeName = this.ThemeName;
                objfinpos.FormClosed += Objfinpos_FormClosed;
                radDock1.ActivateMdiChild(objfinpos);
                objfinpos.Show();
            }
            else
            {
                objfinpos.Activate();
            }
        }

        private void Objfinpos_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfinpos = null;
        }

        Application_Layer.PlotsPosession.frmPossessionChallanSearch objPOsSearch;
        private void PosChallanSearch_Click(object sender, EventArgs e)
        {
            if (objPOsSearch == null)
            {
                objPOsSearch = new Application_Layer.PlotsPosession.frmPossessionChallanSearch();
                objPOsSearch.MdiParent = this;
                objPOsSearch.WindowState = FormWindowState.Maximized;
                objPOsSearch.ThemeName = this.ThemeName;
                objPOsSearch.FormClosed += ObjPOsSearch_FormClosed;
                radDock1.ActivateMdiChild(objPOsSearch);
                objPOsSearch.Show();
            }
            else
            {
                objPOsSearch.Activate();
            }
        }

        private void ObjPOsSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            objPOsSearch = null;
        }

        Application_Layer.PlotsPosession.frmPossessionChallanReport objPOsChallanReport;
        private void PosChallanReport_Click(object sender, EventArgs e)
        {
            if (objPOsChallanReport == null)
            {
                objPOsChallanReport = new Application_Layer.PlotsPosession.frmPossessionChallanReport();
               objPOsChallanReport.MdiParent = this;
               objPOsChallanReport.WindowState = FormWindowState.Maximized;
               objPOsChallanReport.ThemeName = this.ThemeName;
                objPOsChallanReport.FormClosed += ObjPOsChallanReport_FormClosed;
                radDock1.ActivateMdiChild(objPOsChallanReport);
                objPOsChallanReport.Show();
            }
            else
            {
                objPOsChallanReport.Activate();
            }
        }

        private void ObjPOsChallanReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            objPOsChallanReport = null;
        }

        Application_Layer.PlotsPosession.frmPossessionChallanVerification objPosChallanVerification;
        private void PosChallanVerification_Click(object sender, EventArgs e)
        {
            if (objPosChallanVerification == null)
            {
                objPosChallanVerification = new Application_Layer.PlotsPosession.frmPossessionChallanVerification();
                objPosChallanVerification.MdiParent = this;
                objPosChallanVerification.WindowState = FormWindowState.Maximized;
                objPosChallanVerification.ThemeName = this.ThemeName;
                objPosChallanVerification.FormClosed += ObjPosChallanVerification_FormClosed;
                radDock1.ActivateMdiChild(objPosChallanVerification);
                objPosChallanVerification.Show();
            }
            else
            {
                objPosChallanVerification.Activate();
            }
        }

        private void ObjPosChallanVerification_FormClosed(object sender, FormClosedEventArgs e)
        {
            objPosChallanVerification = null;
        }

        Application_Layer.Installment.Discount.frmDiscountRequest objDiscountRequest;
        private void btnDiscountRequest_Click(object sender, EventArgs e)
        {
            if (objDiscountRequest == null)
            {
                objDiscountRequest = new Application_Layer.Installment.Discount.frmDiscountRequest();
                objDiscountRequest.MdiParent = this;
                objDiscountRequest.WindowState = FormWindowState.Maximized;
                objDiscountRequest.ThemeName = this.ThemeName;
                objDiscountRequest.FormClosed += ObjDiscountRequest_FormClosed;
                radDock1.ActivateMdiChild(objDiscountRequest);
                objDiscountRequest.Show();
            }
            else
            {
                objDiscountRequest.Activate();
            }
        }

        private void ObjDiscountRequest_FormClosed(object sender, FormClosedEventArgs e)
        {
            objDiscountRequest = null;
        }

        Application_Layer.Installment.Discount.frmDiscountApproval objfrmDiscountApproval;
        private void btnDiscountApproved_Click(object sender, EventArgs e)
        {
            if (objfrmDiscountApproval == null)
            {
                objfrmDiscountApproval = new Application_Layer.Installment.Discount.frmDiscountApproval();
                objfrmDiscountApproval.MdiParent = this;
                objfrmDiscountApproval.WindowState = FormWindowState.Maximized;
                objfrmDiscountApproval.ThemeName = this.ThemeName;
                objfrmDiscountApproval.FormClosed += ObjfrmDiscountApproval_FormClosed;
                radDock1.ActivateMdiChild(objfrmDiscountApproval);
                objfrmDiscountApproval.Show();
            }
            else
            {
                objfrmDiscountApproval.Activate();
            }
        }

        private void ObjfrmDiscountApproval_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmDiscountApproval = null;
        }
        Application_Layer.AuthorizedDealer.frmNewPropertyDealerRegistration objfrmprpdlr;
        private void btnUploadDealers_Click(object sender, EventArgs e)
        {
            if (objfrmprpdlr == null)
            {
                objfrmprpdlr = new Application_Layer.AuthorizedDealer.frmNewPropertyDealerRegistration();
                objfrmprpdlr.MdiParent = this;
                objfrmprpdlr.WindowState = FormWindowState.Maximized;
                objfrmprpdlr.ThemeName = this.ThemeName;
                objfrmprpdlr.FormClosed += Objfrmprpdlr_FormClosed;
                radDock1.ActivateMdiChild(objfrmprpdlr);
                objfrmprpdlr.Show();
            }
            else
            {
                objfrmprpdlr.Activate();
            }
        }

        private void Objfrmprpdlr_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmprpdlr = null;
        }
        Application_Layer.Marketing.frmSMSPakageOfMarketing objfrmsmspakg;
        private void btnSMSPakage_Click(object sender, EventArgs e)
        {
            if (objfrmsmspakg == null)
            {
                objfrmsmspakg = new Application_Layer.Marketing.frmSMSPakageOfMarketing();
                objfrmsmspakg.MdiParent = this;
                objfrmsmspakg.WindowState = FormWindowState.Maximized;
                objfrmsmspakg.ThemeName = this.ThemeName;
                objfrmsmspakg.FormClosed += Objfrmsmspakg_FormClosed;
                radDock1.ActivateMdiChild(objfrmsmspakg);
                objfrmsmspakg.Show();
            }
            else
            {
                objfrmsmspakg.Activate();
            }
        }

        private void Objfrmsmspakg_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmsmspakg = null;
        }
        Application_Layer.Refund.frmRefundModify objfrmrefundcpm;
        private void btnRfndModify_Click(object sender, EventArgs e)
        {
            if (objfrmrefundcpm == null)
            {
                objfrmrefundcpm = new Application_Layer.Refund.frmRefundModify();
                objfrmrefundcpm.MdiParent = this;
                objfrmrefundcpm.WindowState = FormWindowState.Maximized;
                objfrmrefundcpm.ThemeName = this.ThemeName;
                objfrmrefundcpm.FormClosed += Objfrmrefundcpm_FormClosed;
                radDock1.ActivateMdiChild(objfrmrefundcpm);
                objfrmrefundcpm.Show();
            }
            else
            {
                objfrmrefundcpm.Activate();
            }
        }

        private void Objfrmrefundcpm_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmrefundcpm = null;
        }
        Application_Layer.AuthorizedDealer.frmPropetyDealerDetail objfrmprpdlrsrch;
        private void btnSearchDealer_Click(object sender, EventArgs e)
        {
            if (objfrmprpdlrsrch == null)
            {
                objfrmprpdlrsrch = new Application_Layer.AuthorizedDealer.frmPropetyDealerDetail();
                objfrmprpdlrsrch.MdiParent = this;
                objfrmprpdlrsrch.WindowState = FormWindowState.Maximized;
                objfrmprpdlrsrch.ThemeName = this.ThemeName;
                objfrmprpdlrsrch.FormClosed += Objfrmprpdlrsrch_FormClosed;
                radDock1.ActivateMdiChild(objfrmprpdlrsrch);
                objfrmprpdlrsrch.Show();
            }
            else
            {
                objfrmprpdlrsrch.Activate();
            }
        }

        private void Objfrmprpdlrsrch_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmprpdlrsrch = null;
        }
        Application_Layer.NDC.Baskets.frmReadyForPicturePrint objfrmimgprint;
        private void btnImagePrint_Click(object sender, EventArgs e)
        {
            //  frmReadyForPicturePrint
            if (objfrmimgprint == null)
            {
                objfrmimgprint = new Application_Layer.NDC.Baskets.frmReadyForPicturePrint();
                objfrmimgprint.MdiParent = this;
                objfrmimgprint.WindowState = FormWindowState.Maximized;
                objfrmimgprint.ThemeName = this.ThemeName;
                objfrmimgprint.FormClosed += Objfrmimgprint_FormClosed;
                radDock1.ActivateMdiChild(objfrmimgprint);
                objfrmimgprint.Show();
            }
            else
            {
                objfrmimgprint.Activate();
            }
        }

        private void Objfrmimgprint_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmimgprint = null;
        }

        Application_Layer.Acknowledgement.frm_AcknowledgementSetting objfrmAckSetting;
        private void btnAckLock_Click(object sender, EventArgs e)
        {
            if (objfrmAckSetting == null)
            {
                objfrmAckSetting = new Application_Layer.Acknowledgement.frm_AcknowledgementSetting();
                objfrmAckSetting.MdiParent = this;
                objfrmAckSetting.WindowState = FormWindowState.Maximized;
                objfrmAckSetting.ThemeName = this.ThemeName;
                objfrmAckSetting.FormClosed += ObjfrmAckSetting_FormClosed;
                radDock1.ActivateMdiChild(objfrmAckSetting);
                objfrmAckSetting.Show();
            }
            else
            {
                objfrmAckSetting.Activate();
            }
        }

        private void ObjfrmAckSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmAckSetting = null;
        }
        // ApplicationPaymentScrutinyComplete_L3
        Application_Layer.Launching.ApplicationPaymentScrutinyComplete_L3 apppayscrcpmlet;
        private void btnAppPaymentScrutiny_Click(object sender, EventArgs e)
        {
            if (apppayscrcpmlet == null)
            {
                apppayscrcpmlet = new Application_Layer.Launching.ApplicationPaymentScrutinyComplete_L3();
                apppayscrcpmlet.MdiParent = this;
                apppayscrcpmlet.WindowState = FormWindowState.Maximized;
                apppayscrcpmlet.ThemeName = this.ThemeName;
                apppayscrcpmlet.FormClosed += Apppayscrcpmlet_FormClosed;
                radDock1.ActivateMdiChild(apppayscrcpmlet);
                apppayscrcpmlet.Show();
            }
            else
            {
                apppayscrcpmlet.Activate();
            }
        }

        private void Apppayscrcpmlet_FormClosed(object sender, FormClosedEventArgs e)
        {
            apppayscrcpmlet = null;
        }

        Application_Layer.Launching.FinBankReceiveInfoUploading_OnlineFeeVerification appOnlinepayverification;
        private void btnchallanverify_Click(object sender, EventArgs e)
        {
            if (appOnlinepayverification == null)
            {
                appOnlinepayverification = new Application_Layer.Launching.FinBankReceiveInfoUploading_OnlineFeeVerification();
                appOnlinepayverification.MdiParent = this;
                appOnlinepayverification.WindowState = FormWindowState.Maximized;
                appOnlinepayverification.ThemeName = this.ThemeName;
                appOnlinepayverification.FormClosed += AppOnlinepayverification_FormClosed;
                radDock1.ActivateMdiChild(appOnlinepayverification);
                appOnlinepayverification.Show();
            }
            else
            {
                appOnlinepayverification.Activate();
            }
        }

        private void AppOnlinepayverification_FormClosed(object sender, FormClosedEventArgs e)
        {
            appOnlinepayverification = null;
        }
        Application_Layer.Launching.frmDetail appdetail;
        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (appdetail == null)
            {
                appdetail = new Application_Layer.Launching.frmDetail();
                appdetail.MdiParent = this;
                appdetail.WindowState = FormWindowState.Maximized;
                appdetail.ThemeName = this.ThemeName;
                appdetail.FormClosed += Appdetail_FormClosed;
                radDock1.ActivateMdiChild(appdetail);
                appdetail.Show();
            }
            else
            {
                appdetail.Activate();
            }
        }

        private void Appdetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            appdetail = null;
        }
        Application_Layer.NDC.Baskets.frmNDCReport_Reprint ndcreprint;
        private void btnreprintndc_Click(object sender, EventArgs e)
        {
            if (ndcreprint == null)
            {
                ndcreprint = new Application_Layer.NDC.Baskets.frmNDCReport_Reprint();
                ndcreprint.MdiParent = this;
                ndcreprint.WindowState = FormWindowState.Maximized;
                ndcreprint.ThemeName = this.ThemeName;
                ndcreprint.FormClosed += Ndcreprint_FormClosed;
                radDock1.ActivateMdiChild(ndcreprint);
                ndcreprint.Show();
            }
            else
            {
                ndcreprint.Activate();
            }
        }

        private void Ndcreprint_FormClosed(object sender, FormClosedEventArgs e)
        {
            ndcreprint = null;
        }

        Application_Layer.Launching.frmPaymentsModification appaymodification;
        private void btnEditPay_Click(object sender, EventArgs e)
        {
            if (appaymodification == null)
            {
                appaymodification = new Application_Layer.Launching.frmPaymentsModification();
                appaymodification.MdiParent = this;
                appaymodification.WindowState = FormWindowState.Maximized;
                appaymodification.ThemeName = this.ThemeName;
                appaymodification.FormClosed += Appaymodification_FormClosed;
                radDock1.ActivateMdiChild(appaymodification);
                appaymodification.Show();
            }
            else
            {
                appaymodification.Activate();
            }
        }

        private void Appaymodification_FormClosed(object sender, FormClosedEventArgs e)
        {
            appaymodification = null;
        }


        Application_Layer.Installment.InstReceive.frmListOfDD_ReadyForBankDeposite frmListofDDForBankList;
        private void btnBankList_DetailSearch_Click(object sender, EventArgs e)
        {
            if (frmListofDDForBankList == null)
            {
                frmListofDDForBankList = new Application_Layer.Installment.InstReceive.frmListOfDD_ReadyForBankDeposite();
                frmListofDDForBankList.MdiParent = this;
                frmListofDDForBankList.WindowState = FormWindowState.Maximized;
                frmListofDDForBankList.FormClosed += FrmListofDDForBankList_FormClosed;
                radDock1.ActivateMdiChild(frmListofDDForBankList);
                frmListofDDForBankList.Show();
            }
            else
            {
                frmListofDDForBankList.Activate();
            }
        }

        private void FrmListofDDForBankList_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmListofDDForBankList = null;
        }

        private void radRibbonBarGroup9_Click(object sender, EventArgs e)
        {

        }

        Application_Layer.Installment.Surcharge.SurchrageWaiverApplication.frmSurchargeWaiverApplicationEntry frmSurAppEntry;
        private void btnSurWvrAppEntry_Click(object sender, EventArgs e)
        {
            if (frmSurAppEntry == null)
            {
                frmSurAppEntry = new Application_Layer.Installment.Surcharge.SurchrageWaiverApplication.frmSurchargeWaiverApplicationEntry();
                frmSurAppEntry.MdiParent = this;
                frmSurAppEntry.WindowState = FormWindowState.Maximized;
                frmSurAppEntry.FormClosed += FrmSurAppEntry_FormClosed;
                radDock1.ActivateMdiChild(frmSurAppEntry);
                frmSurAppEntry.Show();
            }
            else
            {
                frmSurAppEntry.Activate();
            }
        }

        private void FrmSurAppEntry_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSurAppEntry = null;
        }
        Application_Layer.Installment.Surcharge.SurchrageWaiverApplication.frmSurchargeWaiverApplicationSearchReport frmSur_App_Search_Report;
        private void btnSurAppSearchReport_Click(object sender, EventArgs e)
        {
            if (frmSur_App_Search_Report == null)
            {
                frmSur_App_Search_Report = new Application_Layer.Installment.Surcharge.SurchrageWaiverApplication.frmSurchargeWaiverApplicationSearchReport();
                frmSur_App_Search_Report.MdiParent = this;
                frmSur_App_Search_Report.WindowState = FormWindowState.Maximized;
                frmSur_App_Search_Report.FormClosed += FrmSurAppSearchReport_FormClosed;
                radDock1.ActivateMdiChild(frmSur_App_Search_Report);
                frmSur_App_Search_Report.Show();
            }
            else
            {
                frmSur_App_Search_Report.Activate();
            }
        }

        private void FrmSurAppSearchReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSur_App_Search_Report = null;
        }
        Application_Layer.Installment.Surcharge.SurchrageWaiverApplication.frmSurWaiverAppProgressBasket frmSurWaiverAppProgressBasket;
        private void btnProgress_Click(object sender, EventArgs e)
        {
            if (frmSurWaiverAppProgressBasket == null)
            {
                frmSurWaiverAppProgressBasket = new Application_Layer.Installment.Surcharge.SurchrageWaiverApplication.frmSurWaiverAppProgressBasket();
                frmSurWaiverAppProgressBasket.MdiParent = this;
                frmSurWaiverAppProgressBasket.WindowState = FormWindowState.Maximized;
                frmSurWaiverAppProgressBasket.FormClosed += FrmSurWaiverAppProgressBasket_FormClosed;
                radDock1.ActivateMdiChild(frmSurWaiverAppProgressBasket);
                frmSurWaiverAppProgressBasket.Show();
            }
            else
            {
                frmSurWaiverAppProgressBasket.Activate();
            }
        }

        private void FrmSurWaiverAppProgressBasket_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSurWaiverAppProgressBasket = null;
        }
        //Application_Layer.Marketing.frmSendSMSToSpecificCustomers frmSMStoSpcificCustomers;
        Application_Layer.Marketing.frmSMSForGeneralPurpose frmSMStoSpcificCustomers;
        private void btnSMSSendToSpecificCust_Click(object sender, EventArgs e)
        {
            if (frmSMStoSpcificCustomers == null)
            {
                frmSMStoSpcificCustomers = new Application_Layer.Marketing.frmSMSForGeneralPurpose();
                frmSMStoSpcificCustomers.MdiParent = this;
                frmSMStoSpcificCustomers.WindowState = FormWindowState.Maximized;
                frmSMStoSpcificCustomers.FormClosed += FrmSMStoSpcificCustomers_FormClosed;
                radDock1.ActivateMdiChild(frmSMStoSpcificCustomers);
                frmSMStoSpcificCustomers.Show();
            }
            else
            {
                frmSMStoSpcificCustomers.Activate();
            }
        }

        private void FrmSMStoSpcificCustomers_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSMStoSpcificCustomers = null;
        }

        Application_Layer.Installment.Account_Statement.AdjustmentModule.frmAddjustment_Process frmAdjPrc;
        private void btnDiscount_Click(object sender, EventArgs e)
        {
            if (frmAdjPrc == null)
            {
                frmAdjPrc = new Application_Layer.Installment.Account_Statement.AdjustmentModule.frmAddjustment_Process();
                frmAdjPrc.MdiParent = this;
                frmAdjPrc.WindowState = FormWindowState.Maximized;
                frmAdjPrc.FormClosed += FrmAdjPrc_FormClosed;
                radDock1.ActivateMdiChild(frmAdjPrc);
                frmAdjPrc.Show();
            }
            else
            {
                frmAdjPrc.Activate();
            }
        }

        private void FrmAdjPrc_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmAdjPrc = null;
        }

        Application_Layer.Installment.Account_Statement.AdjustmentModule.frmAdjustment adjmnt;
        private void btnadjustment_Click(object sender, EventArgs e)
        {
            if (adjmnt == null)
            {
                adjmnt = new Application_Layer.Installment.Account_Statement.AdjustmentModule.frmAdjustment();
                adjmnt.MdiParent = this;
                adjmnt.WindowState = FormWindowState.Maximized;
                adjmnt.FormClosed += Adjmnt_FormClosed;
                radDock1.ActivateMdiChild(adjmnt);
                adjmnt.Show();
            }
            else
            {
                adjmnt.Activate();
            }
        }

        private void Adjmnt_FormClosed(object sender, FormClosedEventArgs e)
        {
            adjmnt = null;
        }
        Application_Layer.Installment.Reminder.frmReminderDuesAndSurcharge frmrmndrletter;
        private void btnReminderLetter_Click(object sender, EventArgs e)
        {
            if (frmrmndrletter == null)
            {
                frmrmndrletter = new Application_Layer.Installment.Reminder.frmReminderDuesAndSurcharge();
                frmrmndrletter.MdiParent = this;
                frmrmndrletter.WindowState = FormWindowState.Maximized;
                frmrmndrletter.FormClosed += Frmrmndrletter_FormClosed;
                radDock1.ActivateMdiChild(frmrmndrletter);
                frmrmndrletter.Show();
            }
            else
            {
                frmrmndrletter.Activate();
            }
        }

        private void Frmrmndrletter_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmrmndrletter = null;
        }

        Application_Layer.Marketing.frmSMSToCust10DaysFuture frm10daysmsfuture;
        private void btnsms10dayfuture_Click(object sender, EventArgs e)
        {
            if (frm10daysmsfuture == null)
            {
                frm10daysmsfuture = new Application_Layer.Marketing.frmSMSToCust10DaysFuture();
                frm10daysmsfuture.MdiParent = this;
                frm10daysmsfuture.WindowState = FormWindowState.Maximized;
                frm10daysmsfuture.FormClosed += Frm10daysmsfuture_FormClosed;
                radDock1.ActivateMdiChild(frm10daysmsfuture);
                frm10daysmsfuture.Show();
            }
            else
            {
                frm10daysmsfuture = null;
            }
        }

        private void Frm10daysmsfuture_FormClosed(object sender, FormClosedEventArgs e)
        {
            throw new NotImplementedException();
        }

        Application_Layer.FileMap.ByBack.frmByBackApproved frmbybackapp;
        private void btnByBackApproval_Click(object sender, EventArgs e)
        {
            if (frmbybackapp == null)
            {
                frmbybackapp = new Application_Layer.FileMap.ByBack.frmByBackApproved();
                frmbybackapp.MdiParent = this;
                frmbybackapp.WindowState = FormWindowState.Maximized;
                frmbybackapp.FormClosed += Frmbybackapp_FormClosed;
                radDock1.ActivateMdiChild(frmbybackapp);
                frmbybackapp.Show();
            }
            else
            {
                frmbybackapp = null;
            }
        }

        private void Frmbybackapp_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmbybackapp = null;
        }
        
        

        

        Application_Layer.FileMap.ByBack.frmByBackMainForm frmbybackappmainform;

        private void btnByBackEntry_Click(object sender, EventArgs e)
        {
            if (frmbybackappmainform == null)
            {
                frmbybackappmainform = new Application_Layer.FileMap.ByBack.frmByBackMainForm();
                frmbybackappmainform.MdiParent = this;
                frmbybackappmainform.WindowState = FormWindowState.Maximized;
                frmbybackappmainform.FormClosed += Frmbybackappmainform_FormClosed;
                radDock1.ActivateMdiChild(frmbybackappmainform);
                frmbybackappmainform.Show();
            }
            else
            {
                frmbybackappmainform = null;
            }
        }
        private void Frmbybackappmainform_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmbybackappmainform = null;
        }

        Application_Layer.Installment.Discount.frmDiscountSummaryReport objDiscountSummaryReport;
        private void DiscountReport_Click(object sender, EventArgs e)
        {
            if (objDiscountSummaryReport == null)
            {
                objDiscountSummaryReport = new Application_Layer.Installment.Discount.frmDiscountSummaryReport();
                objDiscountSummaryReport.MdiParent = this;
                objDiscountSummaryReport.WindowState = FormWindowState.Maximized;
                objDiscountSummaryReport.FormClosed += Frmbybackappmainform_FormClosed;
                radDock1.ActivateMdiChild(objDiscountSummaryReport);
                objDiscountSummaryReport.Show();
            }
            else
            {
                objDiscountSummaryReport = null;
            }
        }
        Application_Layer.NDC.Baskets.frmUrgentNDCTFR_Charges undctfr;
        private void btnUrgentTFR_Click(object sender, EventArgs e)
        {
            if (undctfr == null)
            {
                undctfr = new Application_Layer.NDC.Baskets.frmUrgentNDCTFR_Charges();
                undctfr.MdiParent = this;
                undctfr.WindowState = FormWindowState.Maximized;
                undctfr.FormClosed += Undctfr_FormClosed;
                radDock1.ActivateMdiChild(undctfr);
                undctfr.Show();
            }
            else
            {
                undctfr = null;
            }
        }

        private void Undctfr_FormClosed(object sender, FormClosedEventArgs e)
        {
            undctfr = null;
        }

        Application_Layer.FileMap.ByBack.frmBuyBackProgress frmbbupdatfin;
        private void btnBuybackupdate_Click(object sender, EventArgs e)
        {
            if (frmbbupdatfin == null)
            {
                frmbbupdatfin = new Application_Layer.FileMap.ByBack.frmBuyBackProgress();
                frmbbupdatfin.MdiParent = this;
                frmbbupdatfin.WindowState = FormWindowState.Maximized;
                frmbbupdatfin.FormClosed += Frmbbupdatfin_FormClosed;
                radDock1.ActivateMdiChild(frmbbupdatfin);
                frmbbupdatfin.Show();
            }
            else
            {
                frmbbupdatfin = null;
            }
        }

        private void Frmbbupdatfin_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmbbupdatfin = null;
        }
    
        Application_Layer.FileMap.ByBack.frmBuybackModify_Mkt frmbbcancelfin;
        private void btnbuybackprocesscancel_Click_1(object sender, EventArgs e)
        {

            if (frmbbcancelfin == null)
            {
                frmbbcancelfin = new Application_Layer.FileMap.ByBack.frmBuybackModify_Mkt();
                frmbbcancelfin.MdiParent = this;
                frmbbcancelfin.WindowState = FormWindowState.Maximized;
                frmbbcancelfin.FormClosed += Frmbbcancelfin_FormClosed;
                radDock1.ActivateMdiChild(frmbbcancelfin);
                frmbbcancelfin.Show();
            }
            else
            {
                frmbbcancelfin = null;
            }
        }
        private void Frmbbcancelfin_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmbbcancelfin = null;
        }
        Application_Layer.Installment.Account_Statement.AccountStatementforNewCustomer newcustomerac;
        private void btnCustomerAccountStatment_Click(object sender, EventArgs e)
        {
            if (newcustomerac == null)
            {
                newcustomerac = new Application_Layer.Installment.Account_Statement.AccountStatementforNewCustomer();
                newcustomerac.MdiParent = this;
                newcustomerac.WindowState = FormWindowState.Maximized;
                newcustomerac.FormClosed += Newcustomerac_FormClosed;
                radDock1.ActivateMdiChild(newcustomerac);
                newcustomerac.Show();
            }
            else
            {
                newcustomerac = null;
            }
        }

        private void Newcustomerac_FormClosed(object sender, FormClosedEventArgs e)
        {
            newcustomerac = null;
        }


        Application_Layer.DashBoards.FinanceDashBoard objfinanceDb;
        private void btnAdvReport_Click(object sender, EventArgs e)
        {
            if (objfinanceDb == null)
            {
                objfinanceDb = new Application_Layer.DashBoards.FinanceDashBoard();
                objfinanceDb.MdiParent = this;
                objfinanceDb.WindowState = FormWindowState.Maximized;
                objfinanceDb.FormClosed += ObjfinanceDb_FormClosed;
                radDock1.ActivateMdiChild(objfinanceDb);
                objfinanceDb.Show();
            }
            else
            {
                objfinanceDb = null;
            }
        }

        private void ObjfinanceDb_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfinanceDb = null;
        }

        Application_Layer.Installment.Surcharge.SurchrageWaiverApplication.frmSurWaiverAppPrint 
            objSurcWavierApp = new Application_Layer.Installment.Surcharge.SurchrageWaiverApplication.frmSurWaiverAppPrint();
        private void btnSurcWavierAppPrint_Click(object sender, EventArgs e)
        {
            if (objSurcWavierApp == null)
            {
                objSurcWavierApp = new Application_Layer.Installment.Surcharge.SurchrageWaiverApplication.frmSurWaiverAppPrint();
                objSurcWavierApp.MdiParent = this;
                objSurcWavierApp.WindowState = FormWindowState.Maximized;
                objSurcWavierApp.FormClosed += ObjfinanceDb_FormClosed;
                radDock1.ActivateMdiChild(objSurcWavierApp);
                objSurcWavierApp.Show();
            }
            else
            {
                objSurcWavierApp = null;
            }
        }

        Application_Layer.IN_OUT_Mail.IncomingMailNew objIncoming;

        private void btnIncoming_Click(object sender, EventArgs e)
        {
            if (objIncoming == null)
            {
                objIncoming = new Application_Layer.IN_OUT_Mail.IncomingMailNew();
                objIncoming.MdiParent = this;
                objIncoming.WindowState = FormWindowState.Maximized;
                objIncoming.FormClosed += ObjIncoming_FormClosed;
                radDock1.ActivateMdiChild(objIncoming);
                objIncoming.Show();
            }
            else
            {
                objIncoming = null;
            }
        }

        private void ObjIncoming_FormClosed(object sender, FormClosedEventArgs e)
        {
            objIncoming = null;
        }

        Application_Layer.NDC.Baskets.frmReadyForFinalPrint objfnfprint;
        private void btnfinalprintndc_Click(object sender, EventArgs e)
        {
            if (objfnfprint == null)
            {
                objfnfprint = new Application_Layer.NDC.Baskets.frmReadyForFinalPrint();
                objfnfprint.MdiParent = this;
                objfnfprint.WindowState = FormWindowState.Maximized;
                objfnfprint.FormClosed += Objfnfprint_FormClosed;
                radDock1.ActivateMdiChild(objfnfprint);
                objfnfprint.Show();
            }
            else
            {
                objIncoming = null;
            }
        }

        private void Objfnfprint_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfnfprint = null;
        }

        Application_Layer.FileMap.SvcBenefitFiles.frmSvcModification objSvcmodify;
        private void btnSvcBenefitModify_Click(object sender, EventArgs e)
        {
            if (objSvcmodify == null)
            {
                objSvcmodify = new Application_Layer.FileMap.SvcBenefitFiles.frmSvcModification();
                objSvcmodify.MdiParent = this;
                objSvcmodify.WindowState = FormWindowState.Maximized;
                objSvcmodify.FormClosed += ObjSvcmodify_FormClosed;
                radDock1.ActivateMdiChild(objSvcmodify);
                objSvcmodify.Show();
            }
            else
            {
                objSvcmodify = null;
            }
        }

        private void ObjSvcmodify_FormClosed(object sender, FormClosedEventArgs e)
        {
            objSvcmodify = null;
        }


        Application_Layer.FileMap.frmLandBrReport objlandbrreport;
        private void btnTotalFileInfo_Click(object sender, EventArgs e)
        {
            if (objlandbrreport == null)
            {
                objlandbrreport = new frmLandBrReport();
                objlandbrreport.MdiParent = this;
                objlandbrreport.WindowState = FormWindowState.Maximized;
                objlandbrreport.FormClosed += Objlandbrreport_FormClosed;
                radDock1.ActivateMdiChild(objlandbrreport);
                objlandbrreport.Show();
            }
            else
            {
                objlandbrreport = null;
            }
        }

        private void Objlandbrreport_FormClosed(object sender, FormClosedEventArgs e)
        {
            objlandbrreport = null;
        }

        Application_Layer.TransferSummary.frmTransferReport objTransferReport;
        private void TransferReport_Click(object sender, EventArgs e)
        {
            if (objTransferReport == null)
            {
                objTransferReport = new Application_Layer.TransferSummary.frmTransferReport();
                objTransferReport.MdiParent = this;
                objTransferReport.WindowState = FormWindowState.Maximized;
                objTransferReport.FormClosed += ObjTransferReport_FormClosed;
                radDock1.ActivateMdiChild(objTransferReport);
                objTransferReport.Show();
            }
            else
            {
                objTransferReport = null;
            }
        }

        private void ObjTransferReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            objTransferReport = null;
        }

        Application_Layer.NDC.FBR.frmFBR_FilerNonFilerReport objFilerNonfiler;
        private void btnFiler_NonFiler_Click(object sender, EventArgs e)
        {
            if (objFilerNonfiler == null)
            {
                objFilerNonfiler = new Application_Layer.NDC.FBR.frmFBR_FilerNonFilerReport();
                objFilerNonfiler.MdiParent = this;
                objFilerNonfiler.WindowState = FormWindowState.Maximized;
                objFilerNonfiler.FormClosed += ObjFilerNonfiler_FormClosed;
                radDock1.ActivateMdiChild(objFilerNonfiler);
                objFilerNonfiler.Show();
            }
            else
            {
                objFilerNonfiler = null;
            }
        }

        private void ObjFilerNonfiler_FormClosed(object sender, FormClosedEventArgs e)
        {
            objFilerNonfiler = null;
        }


        Application_Layer.FileMap.ByBack.frmBuyBackModification objbuybackedit;
        private void BuyBackEdit_Click(object sender, EventArgs e)
        {
            if (objbuybackedit == null)
            {
                objbuybackedit = new Application_Layer.FileMap.ByBack.frmBuyBackModification();
                objbuybackedit.MdiParent = this;
                objbuybackedit.WindowState = FormWindowState.Maximized;
                objbuybackedit.FormClosed += Objbuybackedit_FormClosed;
                radDock1.ActivateMdiChild(objbuybackedit);
                objbuybackedit.Show();
            }
            else
            {
                objbuybackedit = null;
            }
        }

        private void Objbuybackedit_FormClosed(object sender, FormClosedEventArgs e)
        {
            objbuybackedit = null;
        }

        Application_Layer.Amalgamation.frmAmalgamationView objAmalgamation;
        private void btnAmalgamation_Click(object sender, EventArgs e)
        {
            if (objAmalgamation == null)
            {
                objAmalgamation = new Application_Layer.Amalgamation.frmAmalgamationView();
                objAmalgamation.MdiParent = this;
                objAmalgamation.WindowState = FormWindowState.Maximized;
                objAmalgamation.FormClosed += ObjAmalgamation_FormClosed;
                radDock1.ActivateMdiChild(objAmalgamation);
                objAmalgamation.Show();
            }
            else
            {
                objAmalgamation = null;
            }
        }

        private void ObjAmalgamation_FormClosed(object sender, FormClosedEventArgs e)
        {
            objAmalgamation = null;
        }

      

        Application_Layer.NDC.TradeOffNDC tradeoffndc;
        private void TRD_NDC_Click(object sender, EventArgs e)
        {
            if (tradeoffndc == null)
            {
                tradeoffndc = new TradeOffNDC();
                tradeoffndc.MdiParent = this;
                tradeoffndc.WindowState = FormWindowState.Maximized;
                tradeoffndc.FormClosed += Tradeoffndc_FormClosed;
                radDock1.ActivateMdiChild(tradeoffndc);
                tradeoffndc.Show();
            }
            else
            {
                tradeoffndc = null;
            }
        }
        private void Tradeoffndc_FormClosed(object sender, FormClosedEventArgs e)
        {
            tradeoffndc = null;
        }

        Application_Layer.Image_Archiving.frmBulkFileUpload objbulkimage;
        private void btnFileArch_Click(object sender, EventArgs e)
        {
            if (objbulkimage == null)
            {
                objbulkimage = new Application_Layer.Image_Archiving.frmBulkFileUpload();
                objbulkimage.MdiParent = this;
                objbulkimage.WindowState = FormWindowState.Maximized;
                objbulkimage.FormClosed += Objbulkimage_FormClosed;
                radDock1.ActivateMdiChild(objbulkimage);
                objbulkimage.Show();
            }
            else
            {
                objbulkimage = null;
            }
        }

        private void Objbulkimage_FormClosed(object sender, FormClosedEventArgs e)
        {
            objbulkimage = null;
        }

        Application_Layer.AdventureArena.AdventureArenaContractor contractor;
        private void btnContractor_Click(object sender, EventArgs e)
        {
            if (contractor == null)
            {
                contractor = new Application_Layer.AdventureArena.AdventureArenaContractor();
                contractor.MdiParent = this;
                contractor.WindowState = FormWindowState.Maximized;
                contractor.FormClosed += Contractor_FormClosed;
                radDock1.ActivateMdiChild(contractor);
                contractor.Show();
            }
            else
            {
                contractor = null;
            }
        }

        private void Contractor_FormClosed(object sender, FormClosedEventArgs e)
        {
            contractor = null;
        }

        Application_Layer.AdventureArena.AdventureArenaTicketHead tickethead;
        private void btnTicketHeads_Click(object sender, EventArgs e)
        {
            if (tickethead == null)
            {
                tickethead = new Application_Layer.AdventureArena.AdventureArenaTicketHead();
                tickethead.MdiParent = this;
                tickethead.WindowState = FormWindowState.Maximized;
                tickethead.FormClosed += Tickethead_FormClosed;
                radDock1.ActivateMdiChild(tickethead);
                tickethead.Show();
            }
            else
            {
                tickethead = null;
            }
        }

        private void Tickethead_FormClosed(object sender, FormClosedEventArgs e)
        {
            tickethead = null;
        }

        Application_Layer.AdventureArena.AdventureArenaTicketBook ticketbook;
        private void btnTicketBook_Click(object sender, EventArgs e)
        {
            if (ticketbook == null)
            {
                ticketbook = new Application_Layer.AdventureArena.AdventureArenaTicketBook();
                ticketbook.MdiParent = this;
                ticketbook.WindowState = FormWindowState.Maximized;
                ticketbook.FormClosed += Ticketbook_FormClosed; ;
                radDock1.ActivateMdiChild(ticketbook);
                ticketbook.Show();
            }
            else
            {
                ticketbook = null;
            }
        }

        private void Ticketbook_FormClosed(object sender, FormClosedEventArgs e)
        {
            ticketbook = null;
        }

        Application_Layer.AdventureArena.AdventureArenaChallanSearch challansearch;
        private void btnInvoiceSearch_Click(object sender, EventArgs e)
        {
            if (challansearch == null)
            {
                challansearch = new Application_Layer.AdventureArena.AdventureArenaChallanSearch();
                challansearch.MdiParent = this;
                challansearch.WindowState = FormWindowState.Maximized;
                challansearch.FormClosed += Challansearch_FormClosed;
                radDock1.ActivateMdiChild(challansearch);
                challansearch.Show();
            }
            else
            {
                challansearch = null;
            }
        }

        private void Challansearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            challansearch = null;
        }

        Application_Layer.AdventureArena.AdventureArenaModification challanedit;
        private void btnInvoiceEdit_Click(object sender, EventArgs e)
        {
            if (challanedit == null)
            {
                challanedit = new Application_Layer.AdventureArena.AdventureArenaModification();
                challanedit.MdiParent = this;
                challanedit.WindowState = FormWindowState.Maximized;
                challanedit.FormClosed += Challanedit_FormClosed;
                radDock1.ActivateMdiChild(challanedit);
                challanedit.Show();
            }
            else
            {
                challanedit = null;
            }
        }

        private void Challanedit_FormClosed(object sender, FormClosedEventArgs e)
        {
            challanedit = null;
        }

        Application_Layer.AdventureArena.AdventureArenaChallanVerification challanverify;
        private void btnAdventureArenaVerification_Click(object sender, EventArgs e)
        {
            if (challanverify == null)
            {
                challanverify = new Application_Layer.AdventureArena.AdventureArenaChallanVerification();
                challanverify.MdiParent = this;
                challanverify.WindowState = FormWindowState.Maximized;
                challanverify.FormClosed += Challanverify_FormClosed;
                radDock1.ActivateMdiChild(challanverify);
                challanverify.Show();
            }
            else
            {
                challanverify = null;
            }
        }

        private void Challanverify_FormClosed(object sender, FormClosedEventArgs e)
        {
            challanverify = null;
        }

        Application_Layer.Chalan.frmTBBCDChallanSearch tbbcd;
        private void btnTB_BCDChallan_Click(object sender, EventArgs e)
        {
            if (tbbcd == null)
            {
                tbbcd = new frmTBBCDChallanSearch();
                tbbcd.MdiParent = this;
                tbbcd.WindowState = FormWindowState.Maximized;
                tbbcd.FormClosed += Tbbcd_FormClosed;
                radDock1.ActivateMdiChild(tbbcd);
                tbbcd.Show();
            }
            else
            {
                tbbcd = null;
            }
        }

        private void Tbbcd_FormClosed(object sender, FormClosedEventArgs e)
        {
            tbbcd = null;
        }

        frmchallancrud challanSetting;
        private void btnChallanSetting_Click(object sender, EventArgs e)
        {
            if (challanSetting == null)
            {
                challanSetting = new frmchallancrud();
                challanSetting.MdiParent = this;
                challanSetting.WindowState = FormWindowState.Maximized;
                challanSetting.FormClosed += ChallanSetting_FormClosed;
                radDock1.ActivateMdiChild(challanSetting);
                challanSetting.Show();
            }
            else
            {
                challanSetting = null;
            }
        }

        private void ChallanSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            challanSetting = null;
        }

        Application_Layer.Contractor.frmContractorView objContractorView;
        private void btnContractorSearch_Click(object sender, EventArgs e)
        {
            if (objContractorView == null)
            {
                objContractorView = new Application_Layer.Contractor.frmContractorView();
                objContractorView.MdiParent = this;
                objContractorView.WindowState = FormWindowState.Maximized;
                objContractorView.FormClosed += ObjContractorView_FormClosed;
                radDock1.ActivateMdiChild(objContractorView);
                objContractorView.Show();
            }
            else
            {
                objContractorView = null;
            }
        }

        private void ObjContractorView_FormClosed(object sender, FormClosedEventArgs e)
        {
            objContractorView = null;
        }
        Application_Layer.Contractor.frmSearchContractor objSearchContractor;
        private void btnContractorEdit_Click(object sender, EventArgs e)
        {
            if (objSearchContractor == null)
            {
                objSearchContractor = new Application_Layer.Contractor.frmSearchContractor();
                objSearchContractor.MdiParent = this;
                objSearchContractor.WindowState = FormWindowState.Maximized;
                objSearchContractor.FormClosed += ObjSearchContractor_FormClosed;
                radDock1.ActivateMdiChild(objSearchContractor);
                objSearchContractor.Show();
            }
            else
            {
                objSearchContractor = null;
            }
        }

        private void ObjSearchContractor_FormClosed(object sender, FormClosedEventArgs e)
        {
            objSearchContractor = null;
        }

        Application_Layer.DashBoards.frmGeneralReport frmGNReport;
        private void btnGNReport_Click(object sender, EventArgs e)
        {
            if (frmGNReport == null)
            {
                frmGNReport = new Application_Layer.DashBoards.frmGeneralReport();
                frmGNReport.MdiParent = this;
                frmGNReport.WindowState = FormWindowState.Maximized;
                frmGNReport.FormClosed += FrmGNReport_FormClosed;
                radDock1.ActivateMdiChild(frmGNReport);
                frmGNReport.Show();
            }
            else
            {
                frmGNReport = null;
            }
        }

        private void FrmGNReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmGNReport = null;
        }

        Application_Layer.TP_BC.frmHouseSetting objHouse;
        private void btnHouse_Click_1(object sender, EventArgs e)
        {
            if (objHouse == null)
            {
                objHouse = new Application_Layer.TP_BC.frmHouseSetting();
                objHouse.MdiParent = this;
                objHouse.WindowState = FormWindowState.Maximized;
                objHouse.FormClosed += ObjHouse_FormClosed;
                radDock1.ActivateMdiChild(objHouse);
                objHouse.Show();
            }
            else
            {
                objHouse = null;
            }
        }
        private void ObjHouse_FormClosed(object sender, FormClosedEventArgs e)
        {
            objHouse = null;
        }

        Application_Layer.NDC.Baskets.frmFBRCPRData objfrmdata;
        private void btnCPRChnge_Click(object sender, EventArgs e)
        {
            if (objfrmdata == null)
            {
                objfrmdata = new frmFBRCPRData();
                objfrmdata.MdiParent = this;
                objfrmdata.WindowState = FormWindowState.Maximized;
                objfrmdata.FormClosed += Objfrmdata_FormClosed;
                radDock1.ActivateMdiChild(objfrmdata);
                objfrmdata.Show();
            }
            else
            {
                objfrmdata = null;
            }
        }

        private void Objfrmdata_FormClosed(object sender, FormClosedEventArgs e)
        {
            objfrmdata = null;
        }

        Application_Layer.Online_Files.frmOnlineFiles objOnlineFiles;
        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            if (objOnlineFiles == null)
            {
                objOnlineFiles = new Application_Layer.Online_Files.frmOnlineFiles();
                objOnlineFiles.MdiParent = this;
                objOnlineFiles.WindowState = FormWindowState.Maximized;
                objOnlineFiles.FormClosed += ObjHouse_FormClosed;
                radDock1.ActivateMdiChild(objOnlineFiles);
                objOnlineFiles.Show();
            }
            else
            {
                objOnlineFiles = null;
            }
        }


        Application_Layer.OpenNDC.frmPreTransferGrid PreTransferGrid;
        private void btnPreTransfer_Click(object sender, EventArgs e)
        {
            if (PreTransferGrid == null)
            {
                PreTransferGrid = new Application_Layer.OpenNDC.frmPreTransferGrid();
                PreTransferGrid.MdiParent = this;
                PreTransferGrid.WindowState = FormWindowState.Maximized;
                PreTransferGrid.FormClosed += PreTransferGrid_FormClosed;
                radDock1.ActivateMdiChild(PreTransferGrid);
                PreTransferGrid.Show();
            }
            else
            {
                PreTransferGrid = null;
            }
        }

        private void PreTransferGrid_FormClosed(object sender, FormClosedEventArgs e)
        {
            PreTransferGrid = null;
        }

        Application_Layer.OpenNDC.OpenNDCConverttoNormal openndcconvert;
        private void btnNDCConvert_Click(object sender, EventArgs e)
        {
            if (openndcconvert == null)
            {
                openndcconvert = new Application_Layer.OpenNDC.OpenNDCConverttoNormal();
                openndcconvert.MdiParent = this;
                openndcconvert.WindowState = FormWindowState.Maximized;
                openndcconvert.FormClosed += Openndcconvert_FormClosed;
                radDock1.ActivateMdiChild(openndcconvert);
                openndcconvert.Show();
            }
            else
            {
                openndcconvert = null;
            }
        }

        private void Openndcconvert_FormClosed(object sender, FormClosedEventArgs e)
        {
            openndcconvert = null;
        }

        Application_Layer.OpenTransfer.frmOpenTransfer opentransfer;
        private void OpenTransferList_Click(object sender, EventArgs e)
        {
            if (opentransfer == null)
            {
                opentransfer = new Application_Layer.OpenTransfer.frmOpenTransfer();
                opentransfer.MdiParent = this;
                opentransfer.WindowState = FormWindowState.Maximized;
                opentransfer.FormClosed += Opentransfer_FormClosed;
                radDock1.ActivateMdiChild(opentransfer);
                opentransfer.Show();
            }
            else
            {
                opentransfer = null;
            }
        }

        private void Opentransfer_FormClosed(object sender, FormClosedEventArgs e)
        {
            opentransfer = null;
        }

        Application_Layer.OpenTransfer.OpenTransferCompleteReport frmotcr;
        private void OpenTransferReport_Click(object sender, EventArgs e)
        {
            if (frmotcr == null)
            {
                frmotcr = new Application_Layer.OpenTransfer.OpenTransferCompleteReport();
                frmotcr.MdiParent = this;
                frmotcr.WindowState = FormWindowState.Maximized;
                frmotcr.FormClosed += Frmotcr_FormClosed;
                radDock1.ActivateMdiChild(frmotcr);
                frmotcr.Show();
            }
            else
            {
                frmotcr = null;
            }
        }

        private void Frmotcr_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmotcr = null;
        }
        private Application_Layer.Installment.InstPlan.frmInstalPlanEdit objfrmInstalPlanEdit;
        private void btn_instPlanEdit_Click(object sender, EventArgs e)
        {
            if (objfrmInstalPlanEdit == null)
            {
                objfrmInstalPlanEdit = new Application_Layer.Installment.InstPlan.frmInstalPlanEdit();
                objfrmInstalPlanEdit.MdiParent = this;
                objfrmInstalPlanEdit.WindowState = FormWindowState.Maximized;
                objfrmInstalPlanEdit.FormClosed += ObjfrmInstPlanModify_FormClosed;
                radDock1.ActivateMdiChild(objfrmInstalPlanEdit);
                objfrmInstalPlanEdit.Show();
            }
            else
            {
                objfrmInstalPlanEdit.Activate();
            }
        }

        Application_Layer.Installment.Sumary.frmReceiteSummaryReport rtsmrrpt;
        private void btnreceitsummary_Click(object sender, EventArgs e)
        {
            if (rtsmrrpt == null)
            {
                rtsmrrpt = new Application_Layer.Installment.Sumary.frmReceiteSummaryReport();
                rtsmrrpt.MdiParent = this;
                rtsmrrpt.WindowState = FormWindowState.Maximized;
                rtsmrrpt.ThemeName = this.ThemeName;
                rtsmrrpt.FormClosed += Rtsmrrpt_FormClosed;
                radDock1.ActivateMdiChild(rtsmrrpt);
                rtsmrrpt.Show();
            }
            else
            {
                rtsmrrpt.Activate();
            }
        }

        private void Rtsmrrpt_FormClosed(object sender, FormClosedEventArgs e)
        {
            rtsmrrpt = null;
        }
    }

}
