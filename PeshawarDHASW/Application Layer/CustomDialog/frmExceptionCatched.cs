using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Data_Layer.clsDBError;
using PeshawarDHASW.Data_Layer.clsErrorLog;
using PeshawarDHASW.Models;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.CustomDialog
{
    public partial class frmExceptionCatched : Telerik.WinControls.UI.RadForm
    {
        public frmExceptionCatched()
        {
            InitializeComponent();
        }

        public string Message { get; set; }
        public Exception exception { get; set; }
        public string formName { get; set; }
        public frmExceptionCatched(string ErrorMessage,Exception ex, string FormName)
        {
            Message = ErrorMessage;
            exception = ex;
            formName = FormName;
            InitializeComponent();
        }

        private void frmExceptionCatched_Load(object sender, EventArgs e)
        {
            this.ThemeName = clsUser.ThemeName;
            ThemeResolutionService.ApplyThemeToControlTree(this, clsUser.ThemeName);
            this.Text = Message;
            txtErrorMessage.Text = exception.Message;
            cls_dl_ErrorLog.ErrorLogSAvetoDB(exception, formName+" -> "+Message);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
