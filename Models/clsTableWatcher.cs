using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using TableDependency.Enums;
using TableDependency.Mappers;
using TableDependency.SqlClient;

namespace PeshawarDHASW.Models
{
    public class clsTableWatcher
    {
        public string _connectionString = clsMostUseVars.Connectionstring;
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
                        if (e.Entity.StatusofNDC.ToLower() == "filetransfercompleted")
                        {
                            // Send Present Message Here
                            MessageBox.Show("Student is present");

                            var notification = new System.Windows.Forms.NotifyIcon()
                            {
                                Visible = true,
                                Icon = System.Drawing.SystemIcons.Information,
                                // optional - BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info,
                                // optional - BalloonTipTitle = "My Title",
                                BalloonTipText = "My long description...",
                            };

                            // Display for 5 seconds.
                            notification.ShowBalloonTip(5000);

                            // This will let the balloon close after it's 5 second timeout
                            // for demonstration purposes. Comment this out to see what happens
                            // when dispose is called while a balloon is still visible.
                            Thread.Sleep(10000);

                            // The notification should be disposed when you don't need it anymore,
                            // but doing so will immediately close the balloon if it's visible.
                            notification.Dispose();

                        }
                        //else if (e.Entity.StatusofNDC.ToLower() == "l")
                        //{
                        //    // send Leave Message here
                        //    MessageBox.Show("Student is Leave");
                        //}
                        //else if (e.Entity.StatusofNDC.ToLower() == "a")
                        //{
                        //    // send absent Message here
                        //    MessageBox.Show("Student is absent");


                        //}
                        //else
                        //{
                        //    // send Other Message here
                        //}
                        //System.Windows.Forms.MessageBox.Show(e.Entity.NDCNo + " Inserted");
                        break;
                }

            }
        }
    }
}
