using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Helper;
using Telerik.WinControls;
using  System.IO;


namespace PeshawarDHASW.Application_Layer.Practice
{
    public partial class frmDGPaging : Telerik.WinControls.UI.RadForm
    {
        public frmDGPaging()
        {
            InitializeComponent();
        }

        private void frmDGPaging_Load(object sender, EventArgs e)
        {

        }






        #region SQL Trasaction
        SqlTransaction OwnerTransfersetting;

        private void SqlTransactionfunction(SqlTransaction _trans,List<SqlCommand> _Command, List<object> _SqlParameter  )
        {
            
            if (_Command.Count == _SqlParameter.Count)
            {
                try
                {
                    for (int i = 0; i < _Command.Count; i++)
                    {
                        SqlCommand cmd = _Command[i];
                        SqlParameter[] param = (SqlParameter[])_SqlParameter[i];
                        cmd.Transaction = _trans;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = SQLHelper.createConnection();
                        for (int j = 0; j < param.Length; j++)
                        {
                            cmd.Parameters.Add(param[j]);
                        }
                        cmd.ExecuteNonQuery();
                    }
                    _trans.Commit();
                }
                catch (Exception ex)
                {
                      _trans.Rollback();
                }
            }
            else
            {
                //error
            }
        }

        #endregion

        #region Tuples
        private Tuple<string,int,int,int> tuples_tutorial(Tuple<string, int, int, int> tr)
        {
            Tuple<Tuple<int, int>, Tuple<string, string>> str;
           
            Tuple<string,int,int,int> tupl = new Tuple<string, int, int, int>(item1:tr.Item1+"ABCC",item2:tr.Item2*10, item3:tr.Item3*21,item4:tr.Item4*11);
            return tupl;
        }

        private void Tuplesusing()
        {

            Tuple<string, int, int, int> trr = new Tuple<string, int, int, int>("ABC", 1, 2, 3);
            var tr = tuples_tutorial(trr);
            MessageBox.Show(tr.Item1.ToString());
            MessageBox.Show(tr.Item2.ToString());
            MessageBox.Show(tr.Item3.ToString());
            MessageBox.Show(tr.Item4.ToString());
        }
#endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //Scanner oScanner = new Scanner();
            //oScanner.Scann();
            //button1.Text = "Image scanned";
            //OpenFileDialog dlg = new OpenFileDialog();
            //if (dlg.ShowDialog() == DialogResult.OK)
            //{
            //    pictureBox1.Image = Image.FromFile(dlg.FileName);
            //}
        }
    }
    public class Scanner
    {
        //WiaDotNet.WiaDevice oDevice;
        //WiaDotNet.Item oItem;
        //WIA.CommonDialogClass dlg;
        //public Scanner()
        //{
        //    dlg = new WIA.CommonDialogClass();
        //    oDevice = dlg.ShowSelectDevice(WIA.WIADeviceType.ScannerDeviceType, true, false);
        //}
        //public void Scann()
        //{
        //    dlg.ShowAcquisitionWizard(oDevice);
        //}

    }
}
