using System;
using System.Windows.Forms;
using PeshawarDHASW.Application_Layer.Transfer.Transfer_Information.Total_Transfer_Detail;
using PeshawarDHASW.Application_Layer.Membership.Modify;
using PeshawarDHASW.Application_Layer.Installment.Sumary;

namespace PeshawarDHASW
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {           
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Helper.clsPluginHelper.SMSSEnding("03459320831","Dear Customer your FileNo: B/RES/4662 and Membership No : DPR-09271  Please use this information for your Online Challan");
             Application.Run(new FrmLogin());
            //Application.Run(new Test());
            //Application.Run(new frmReceiteSummaryReport());

            //Application.Run(new Application_Layer.Installment.InstReceive.frm_NatureOfDDAmount());
            //Application.Run(new Application_Layer.User.frmNewUser());
            //Application.Run(new Application_Layer.FileMap.TradeOff.frm_TradeOffCreate());
            //Application.Run(new Application_Layer.IN_OUT_Mail.Incoming_Mail());

            //Application.Run(new Application_Layer.IN_OUT_Mail.Incoming_Mail());
            //Application.Run(new Application_Layer.NDC.Baskets.frmReadyForFinalPrint());
            //Application.Run(new TreeViewMianForm());
            //Application.Run(new Application_Layer.Acknowledgement.IntimationReport());
            //Application.Run(new Application_Layer.FileMap.ByBack.frmByBackMainForm());
            //Application.Run(new Application_Layer.Installment.Reminder.frmReminderDuesAndSurcharge());
            //Application.Run(new Application_Layer.Installment.Reminder.frmReminderDuesAndSurcharge());
            //Application.Run(new Application_Layer.Installment.Account_Statement.AdjustmentModule.frmAddjustment_Process());
            //Application.Run(new Application_Layer.maintestform());
            //Application.Run(new Application_Layer.NDC.Baskets.frmUrgentNDCTFR_Charges());
            //Application.Run(new Application_Layer.Marketing.frmSMSToCust10DaysFuture());
            //Application.Run(new Application_Layer.Acknowledgement.frm_AcknowledgementSetting()); 
        }
    }
}
