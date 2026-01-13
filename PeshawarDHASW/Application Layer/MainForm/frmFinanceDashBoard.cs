using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using PeshawarDHASW.Application_Layer;
using PeshawarDHASW.Helper;
using PeshawarDHASW.Properties;
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.MainForm
{
    public partial class frmFinanceDashBoard : Telerik.WinControls.UI.RadForm
    {
        void LoadNodes()
        {

            DataSet FirstNodes = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.Text, "Select * from dbo.tbl_Menu where ParentNode = 0");
           
           // int index = 0; Stopwatch watch = Stopwatch.StartNew();
            using (this.TreeMenuMain.DeferRefresh())
            {
                this.TreeMenuMain.Nodes.Clear();
                foreach (DataRow dr_Root in FirstNodes.Tables[0].Rows)
                {
                    RadTreeNode node = new RadTreeNode(dr_Root["NodeText"].ToString());
                    DataSet SecondNodes = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.Text, "Select * from dbo.tbl_Menu where ParentNode = "+dr_Root["NodeID"].ToString());
                    foreach (DataRow dr_Child in SecondNodes.Tables[0].Rows)
                    {
                        RadTreeNode child = new RadTreeNode(dr_Child["NodeText"].ToString());
                        node.Nodes.Add(child);
                    }
                    this.TreeMenuMain.Nodes.Add(node);
                }
                //for (int i = 0; i < 3125; i++)
                //{
                //    index++;
                //    //Header
                //    RadTreeNode node = new RadTreeNode("Node" + index);
                //    for (int j = 0; j < 5; j++)
                //    {
                //        index++;
                //        //Child
                //        RadTreeNode child = new RadTreeNode("Node" + index);
                //        node.Nodes.Add(child);
                //        for (int p = 0; p < 2; p++)
                //        {
                //            index++;
                //            //Child into Child
                //            RadTreeNode childChild = new RadTreeNode("Node" + index);
                //            child.Nodes.Add(childChild);
                //        }
                //    }
                //    this.TreeMenuMain.Nodes.Add(node);
                //}
            }
            
        }
        public frmFinanceDashBoard()
        {
            InitializeComponent();
            // TreeMenuMain.Filter = "Custom";
            //  var root = new RadTreeNode("AccountStatement", Resources.AcCust, true);
            // root.Nodes.Add("ABC");
            //  root.Nodes.Add("CDE");
            //  TreeMenuMain.Nodes.Add(root);
            LoadNodes();
        }

        Installment.InstReceive.frmRecePayment frmojb;
        private void NewReceive_Click(object sender, EventArgs e)
        {

            if (frmojb == null)
            {
                frmojb = new Installment.InstReceive.frmRecePayment();
                frmojb.MdiParent = this;
                frmojb.WindowState = FormWindowState.Maximized;
                frmojb.FormClosed += Frmojb_FormClosed;
                radDock1.ActivateMdiChild(frmojb);
                frmojb.Show();
            }
            else
            {
                // frmojb.BringToFront();
            }
        }

        private void Frmojb_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmojb = null;
        }

        private void frmFinanceDashBoard_Load(object sender, EventArgs e)
        {

        }

        private void radLabel1_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
        /// <summary>
        /// Menu Button Events
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeMenuMain_SelectedNodeChanged(object sender, Telerik.WinControls.UI.RadTreeViewEventArgs e)
        {
            string node = TreeMenuMain.SelectedNode.Text;
            if (node == "New Receive")
            {
                MessageBox.Show(node);
            }
            else if (node == "Search")
            {
                MessageBox.Show(node);
            }
        }

        private void txtTreeFilter_TextChanged(object sender, EventArgs e)
        {
            TreeMenuMain.Filter = txtTreeFilter.Text;
        }
    }
}
