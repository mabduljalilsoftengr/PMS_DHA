using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TableDependency.Enums;
using TableDependency.Mappers;
using TableDependency.SqlClient;

namespace PeshawarDHASW.Models
{
    public class Notification_On_Table_Watch
    {
        public string _connectionString = "Data Source=KHAIRULLAH-IT\\SQLEXPRESS;Initial Catalog=test;Integrated Security=true;";
        // System.Configuration.ConfigurationManager.ConnectionStrings["constring"].ConnectionString;
        private SqlTableDependency<tbl_NDC> _dependency;
        public void WatchTable()
        {
            var mapper = new ModelToTableMapper<tbl_NDC>();
            mapper.AddMapping(model => model.NDCNo, "NDCNo");
            _dependency = new SqlTableDependency<tbl_NDC>(_connectionString, "tbl_NDC", mapper);
            _dependency.OnChanged += _dependency_OnChanged;
            _dependency.OnError += _dependency_OnError;

        }

        public void StartTableWatcher()
        {
            _dependency.Start();
        }
        public void StopTableWatcher()
        {
            _dependency.Stop();
        }
        void _dependency_OnError(object sender, TableDependency.EventArgs.ErrorEventArgs e)
        {

            throw e.Error;
        }

        void _dependency_OnChanged(object sender, TableDependency.EventArgs.RecordChangedEventArgs<tbl_NDC> e)
        {

            if (e.ChangeType != ChangeType.None)
            {
                switch (e.ChangeType)
                {
                    case ChangeType.Delete:

                        break;
                    case ChangeType.Insert:
                        
                        break;
                    case ChangeType.Update:

                        if (e.Entity.GoBack_Remarks.ToLower().Contains("request from transfer branch to finance branch for ndc modification :"))
                        {
                            // Send Present Message Here
                            NotifyIcon notifyIcon = new NotifyIcon();
                            notifyIcon.Visible = true;
                            notifyIcon.BalloonTipTitle = "Notification For Finance Branch.";
                            notifyIcon.BalloonTipText = e.Entity.GoBack_Remarks; //"Student is present";
                            notifyIcon.Icon = SystemIcons.Application;
                            notifyIcon.ShowBalloonTip(30000);

                        }
                        //else if (e.Entity.GoBack_Remarks.ToLower() == "l")
                        //{
                        //    // send Leave Message here
                        //    //MessageBox.Show("Student is Leave");
                        //}
                        //else if (e.Entity.GoBack_Remarks.ToLower() == "a")
                        //{
                        //    // send absent Message here
                        //    //MessageBox.Show("Student is absent");
                        //}
                        //else
                        //{
                        //    // send Other Message here
                        //}


                        break;
                }

            }
        }

    }
}
