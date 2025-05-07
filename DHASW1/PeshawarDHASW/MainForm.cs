using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using PeshawarDHASW.Application_Layer;

namespace PeshawarDHASW
{
    public partial class MainForm : Telerik.WinControls.UI.RadForm
    {
        public MainForm()
        {
            InitializeComponent();
           
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            foreach (Control ctl in this.Controls)
            {
                if (ctl is MdiClient)
                {
                    ctl.BackgroundImage = Properties.Resources.logo;
                    ctl.BackColor = System.Drawing.Color.White;
                    this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
                    break;
                }
            }
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            this.Refresh();
        }

        frmApplicationRegistration appliationregistrationobj;
        private void btnregistration_Click(object sender, EventArgs e)
        {
            if (appliationregistrationobj == null)
            {
                appliationregistrationobj = new frmApplicationRegistration();
                appliationregistrationobj.MdiParent = this;
                appliationregistrationobj.WindowState = FormWindowState.Maximized;
                appliationregistrationobj.FormClosed += appliationregistrationobj_FormClosed;
                appliationregistrationobj.Show();
            }
            else
            {
                appliationregistrationobj.BringToFront();
            }
        }

        void appliationregistrationobj_FormClosed(object sender, FormClosedEventArgs e)
        {
            appliationregistrationobj = null;
        }
    }
}
