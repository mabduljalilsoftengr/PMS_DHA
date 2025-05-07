using PeshawarDHASW.Data_Layer.clsFileMap;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PeshawarDHASW.Application_Layer.FileMap.ByBack
{
    public partial class frmaddnewPlotSizeCtegory : Form
    {
        public frmaddnewPlotSizeCtegory()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
           SqlParameter[] searchparamFile =
           {
                new SqlParameter("@Task", "InsertNewPlotSizecategory"),
                new SqlParameter("@PlotSize", txtplotsizecategory.Text)
            };
            int rslt = cls_dl_FileMap.Main_FileMap_NonQuery(searchparamFile);
            if(rslt > 0)
            {
                MessageBox.Show("Successfull");
                this.Close();
            }
        }
    }
}
