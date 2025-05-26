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
using Telerik.WinControls.UI;

namespace PeshawarDHASW.Application_Layer.FileMap.SvcBenefitFiles
{
    public partial class frmfileplotallotment : Form
    {
        public frmfileplotallotment()
        {
            InitializeComponent();
        }
        private string File_No { get; set; }
        private string Plot_No { get; set; }
        private string Plot_Size { get; set; }
        private int Plot_Type { get; set; }
        private int Sector { get; set; }
        private string SqYard { get; set; }
        private string Kanal { get; set; }
        private string Marla { get; set; }
        public string AllotmentDate { get; set; }
        public string Remarks { get; set; }
        public string AttachRemarks { get; set; }
        DataSet ds = new DataSet();

        public frmfileplotallotment(string FileNo, string PlotNo, string PlotSize, int PlotType, int Sect, string AllotDate, string remk, string conditionRemarks, DataSet dst)
        {
            InitializeComponent();
            File_No = FileNo;
            Plot_No = PlotNo;
            Plot_Size = PlotSize;
            Sector = Sect;
            Plot_Type = PlotType;
            AllotmentDate = AllotDate;
            Remarks = remk;
            AttachRemarks = conditionRemarks;
            ds = dst;
            if (Plot_Size == "10 Marla") { SqYard = "250"; Kanal = null; Marla = Plot_Size; }
            else if (Plot_Size == "8 Marla") { SqYard = "200"; Kanal = null; Marla = Plot_Size; }
            else if (Plot_Size == "5 Marla") { SqYard = "125"; Kanal = null; Marla = Plot_Size; }
            else if (Plot_Size == "4 Marla") { SqYard = "100"; Kanal = null; Marla = Plot_Size; }
            else if (Plot_Size == "1 Kanal") { SqYard = "500"; Kanal = Plot_Size; Marla = null; }
            else if (Plot_Size == "2 Kanal") { SqYard = "1000"; Kanal = Plot_Size; Marla = null; }
        }

        private void frmfileplotallotment_Load(object sender, EventArgs e)
        {
            rad_allotmentgrdview.DataSource = ds.Tables[0].DefaultView;


        }
        private void save_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txt_fileno.Text.Trim()))
                {
                    errorallotment.SetError(txt_fileno, "Please Enter File No.");
                    return;
                }
                if (string.IsNullOrEmpty(txt_plotno.Text.Trim()))
                {
                    errorallotment.SetError(txt_plotno, "Please Enter Plot No.");
                    return;
                }

                SqlParameter[] parameters =
                {
                    new SqlParameter("@Task","Create_Allotment"),
                    new SqlParameter("@FileNo", txt_fileno.Text),
                    new SqlParameter("@PlotNo", txt_plotno.Text),
                    new SqlParameter("@AllotmentDate", dt_allotmentdate.Text),
                    new SqlParameter("@Kanal", Kanal),
                    new SqlParameter("@Marla", Marla),
                    new SqlParameter("@SqYard",SqYard),
                    new SqlParameter("@Sector_ID",Sector),
                    new SqlParameter("@PlotBusinessTypeID",Plot_Type),
                    new SqlParameter("@Remarks", Remarks),
                    new SqlParameter("@AttachRemarks", AttachRemarks),
                    new SqlParameter("@userID",Models.clsUser.ID),

                };
                //  int result = 0;

                ds = cls_dl_FileMap.Allotment_Reader(parameters);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    string msg = ds.Tables[0].Rows[0]["Message"].ToString();
                    MessageBox.Show(msg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearAllotmentfunction();
                    rad_allotmentgrdview.DataSource = ds.Tables[0].DefaultView;
                }
                else
                {
                    MessageBox.Show("Unable to save record Please contact to the Administrator!.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void ClearAllotmentfunction()
        {
            txt_fileno.Text = "";
            txt_plotno.Text = "";
        }

        private void rad_allotmentgrdview_CellClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "btndelete")
            {
                int altid = int.Parse(e.Row.Cells["AllotmentID"].Value.ToString());
                string flNo = e.Row.Cells["FileNo"].Value.ToString();
                string pltNo = e.Row.Cells["PlotNo"].Value.ToString();
                // delete allotment detail
                if (MessageBox.Show("Are you sure you want to delete this record", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    SqlParameter[] parameters =
                   {
                    new SqlParameter("@Task","Delete_Allotment"),
                    new SqlParameter("@AllotmentID",altid),
                       new SqlParameter("@FileNo",flNo),
                          new SqlParameter("@PlotNo",pltNo),
                };
                   // int result = 0;
                    ds = cls_dl_FileMap.Allotment_Reader(parameters);
                    if (ds.Tables.Count > 0)
                    {
                        if (ds.Tables[0].Rows.Count > 0)
                        {
                         
                            MessageBox.Show("Allotment deleted successfully.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            rad_allotmentgrdview.DataSource = null;
                            rad_allotmentgrdview.DataSource = ds.Tables[0].DefaultView;
                        }
                    }
                    rad_allotmentgrdview.DataSource=null;
                }
            }
        }
    }
}
