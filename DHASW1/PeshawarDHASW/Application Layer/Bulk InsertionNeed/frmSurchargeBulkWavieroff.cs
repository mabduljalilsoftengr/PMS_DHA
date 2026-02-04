using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace PeshawarDHASW.Application_Layer.Bulk_InsertionNeed
{
    public partial class frmSurchargeBulkWavieroff : Telerik.WinControls.UI.RadForm
    {
        public frmSurchargeBulkWavieroff()
        {
            InitializeComponent();
        }

        private void frmSurchargeBulkWavieroff_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds = Helper.SQLHelper.ExecuteDataset(Helper.SQLHelper.createConnection(), CommandType.Text, @"SELECT  fm.FileNo  FROM [DHAPeshawarDB].[dbo].[tbl_ReceInst] r
                INNER JOIN DHAPeshawarDB.dbo.tbl_FileMap fm ON r.FileKeyID = fm.FileMapKey
                 WHERE[Date] <= '2017-12-31' AND fm.TemplateInstKey = 5
                GROUP BY fm.FileNo HAVING  SUM(r.Amount) >= 1574990.00
                ORDER BY fm.FileNo");
            radGridView1.MasterTemplate.BeginUpdate();
            radGridView1.DataSource = ds.Tables[0].DefaultView;
            radGridView1.MasterTemplate.EndUpdate();
        }
    }
}
