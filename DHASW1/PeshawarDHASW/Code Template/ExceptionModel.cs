using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PeshawarDHASW.Data_Layer.clsErrorLog;

namespace PeshawarDHASW.Code_Template
{
    class ExceptionModel
    {
        public void exceptionmodel()
        {
            try
            {

            }
            catch (Exception ex)
            {
                cls_dl_ErrorLog.ErrorLogSAvetoDB(ex, "");
            }
        }
    }
}
