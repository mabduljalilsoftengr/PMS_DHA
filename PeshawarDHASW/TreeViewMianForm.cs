using PeshawarDHASW.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace PeshawarDHASW
{
    public partial class TreeViewMianForm : Telerik.WinControls.UI.RadForm
    {
        public TreeViewMianForm()
        {
            InitializeComponent();
            DataSet ds = SQLHelper.ExecuteDataset(SQLHelper.createConnection(), CommandType.StoredProcedure, "ControlsInfo");
            this.radTreeView1.DisplayMember = "ControlName";
            this.radTreeView1.ParentMember = "ParentID";
            this.radTreeView1.ChildMember = "Control_ID";
            this.radTreeView1.DataSource = ds.Tables[0].DefaultView;

            radDock1.MainDocumentContainer.SplitPanelElement.Fill.BackColor = Color.White;
            radDock1.MainDocumentContainer.SplitPanelElement.Fill.GradientStyle = GradientStyles.Solid;
        }

        private void radTreeView1_NodeMouseClick(object sender, RadTreeViewEventArgs e)
        {
            RadTreeViewMouseEventArgs args = e as RadTreeViewMouseEventArgs;
            string controlName = args.Node.Text.Replace("\r\n", string.Empty);
            if (controlName == "mssearch")
            {
                MessageBox.Show("Test");
                //frmTest appliationregistrationobj = new frmTest();
                //appliationregistrationobj.MdiParent = this;
                //appliationregistrationobj.WindowState = FormWindowState.Maximized;
                //radDock1.ActivateMdiChild(appliationregistrationobj);
                //appliationregistrationobj.Show();

            }
        }



        private void radTextBox1_TextChanged_1(object sender, EventArgs e)
        {
            this.radTreeView1.Filter = radTextBox1.Text;
        }
    }
}
