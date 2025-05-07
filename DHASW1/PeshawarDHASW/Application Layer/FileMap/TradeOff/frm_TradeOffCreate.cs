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

namespace PeshawarDHASW.Application_Layer.FileMap.TradeOff
{
    public partial class frm_TradeOffCreate : Form
    {
        public frm_TradeOffCreate()
        {
            InitializeComponent();
        }
        DataTable dt_bl = new DataTable();
        DataTable dt_bl_offrd = new DataTable();

        private DataTable TradeOff()
        {
            DataTable dttrd = new DataTable();
            dttrd.Clear();
            dttrd.Columns.Add("Description");
            dttrd.Columns.Add("Remarks");
            DataRow _ravi = dttrd.NewRow();
            _ravi["Description"] = txtdescription.Text;
            _ravi["Remarks"] = txtremarks.Text;
            dttrd.Rows.Add(_ravi);

            return dttrd;
        }
        private DataTable TradeOffFor()
        {
            DataTable dttrdfor = new DataTable();
            dttrdfor.Clear();
            dttrdfor.Columns.Add("FileNo");
            dttrdfor.Columns.Add("Plotsize"); 
            dttrdfor.Columns.Add("MSNO");
            dttrdfor.Columns.Add("Name");
            dttrdfor.Columns.Add("CNIC"); 
            dttrdfor.Columns.Add("TotalReceAmount");
            foreach (GridViewRowInfo dr in grdtrdfor.Rows)
            {
                DataRow _ravifor = dttrdfor.NewRow();
                _ravifor["FileNo"] = dr.Cells["FileNo"].Value.ToString();
                _ravifor["Plotsize"] = dr.Cells["Plotsize"].Value.ToString();
                _ravifor["MSNO"] = dr.Cells["MSNO"].Value.ToString();
                _ravifor["Name"] = dr.Cells["Name"].Value.ToString();
                _ravifor["CNIC"] = dr.Cells["CNIC"].Value.ToString();
                _ravifor["TotalReceAmount"] = dr.Cells["TotalReceAmount"].Value.ToString();
                dttrdfor.Rows.Add(_ravifor);
            }
            return dttrdfor;
        }
        private DataTable TradeOffOffered()
        {
            DataTable dttrdoffred = new DataTable();
            dttrdoffred.Clear();
            dttrdoffred.Columns.Add("FileNo");
            dttrdoffred.Columns.Add("Plotsize");
            foreach (GridViewRowInfo dr in grdtrdoffered.Rows)
            {
                DataRow _ravioffred = dttrdoffred.NewRow();
                _ravioffred["FileNo"] = dr.Cells["FileNo"].Value.ToString();
                _ravioffred["Plotsize"] = dr.Cells["Plotsize"].Value.ToString();

                dttrdoffred.Rows.Add(_ravioffred);
            }
            return dttrdoffred;
        }
        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                  
                  //////////////////// Trade off ////////////////////
                  TradeOff();
                  ////////////////// Trade Off For ////////////////////
                  TradeOffFor();
                  ////////////////// Trade Off offred ////////////////////
                  TradeOffOffered();
                  //////////////////////////////////////////////////////
                  
                  SqlParameter[] parmtr =
                  {
                       new SqlParameter("@Task","TradeOffCreate"),
                       new SqlParameter(){ ParameterName = "@tbl_TradeOff",SqlDbType = SqlDbType.Structured, SqlValue = TradeOff()},
                       new SqlParameter(){ ParameterName = "@tbl_TradeOff_For_Files",SqlDbType = SqlDbType.Structured, SqlValue = TradeOffFor()},
                       new SqlParameter(){ ParameterName = "@tbl_TradeOff_Offered_Files",SqlDbType = SqlDbType.Structured, SqlValue = TradeOffOffered()}
                  };
                  int rslt =  cls_dl_FileMap.FileMap_NonQuery(parmtr);
                  if(rslt > 0)
                  {
                      MessageBox.Show("Successful.");
                      grdtrdfor.DataSource = null;
                      grdtrdoffered.DataSource = null;
                      txtdescription.Text = "";
                      txtremarks.Text = "";
                }
            }
            catch (Exception EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void btnfind_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (var item in grdtrdfor.Rows)
                {
                    if (item.Cells["FileNo"].Value.ToString() == txtfileno.Text)
                    {
                        MessageBox.Show("File No / Plot No is already in the List");
                        return;
                    }
                }

                SqlParameter[] param = {
                    new SqlParameter("@Task","TradeOff_For_Files_Verification"),
                    new SqlParameter("@FileNo",txtfileno.Text)
                };

                int forFilecount = int.Parse(Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_FileMap", param).ToString());

                if (forFilecount>0)
                {
                    MessageBox.Show("File is Already Exist in Trade for Files List.");
                    btnaddtogrid.Enabled = false;
                    return;
                }
                SqlParameter[] parmtr =
                  {
                  new SqlParameter("@Task","FindDataForTradeOff"),
                  new SqlParameter("@FileNo",txtfileno.Text)
                    };
                DataSet dst = cls_dl_FileMap.FileMap_Reader(parmtr);
                txtmsno.Text = dst.Tables[0].Rows[0]["MembershipNo"].ToString();
                txtcnic.Text = dst.Tables[0].Rows[0]["CNIC"].ToString();
                txtplotsize.Text = dst.Tables[0].Rows[0]["PlotSize"].ToString();
                txtname.Text = dst.Tables[0].Rows[0]["Name"].ToString();
                txttotalrece.Text = dst.Tables[0].Rows[0]["TotalReceivedAmount"].ToString();
                btnaddtogrid.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

           


        }

        private void btnaddtogrid_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("FileNo");
                dt.Columns.Add("MSNO");
                dt.Columns.Add("CNIC");
                dt.Columns.Add("Plotsize");
                dt.Columns.Add("Name");
                dt.Columns.Add("TotalReceAmount");
                DataRow dr = dt.NewRow();
                dr["FileNo"] = txtfileno.Text;
                dr["MSNO"] = txtmsno.Text;
                dr["CNIC"] = txtcnic.Text;
                dr["Plotsize"] = txtplotsize.Text;
                dr["Name"] = txtname.Text;
                dr["TotalReceAmount"] = txttotalrece.Text;
                dt.Rows.Add(dr);
                dt_bl.Merge(dt);
                grdtrdfor.DataSource = dt_bl.DefaultView;
                ClearFor();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void ClearFor()
        {
            txtfileno.Text = "";
            txtmsno.Text = "";
            txtcnic.Text = "";
            txtplotsize.Text = "";
            txtname.Text = "";
            txttotalrece.Text = "";   
        }
        private void Clear_Offered()
        {
            txtfilenooffr.Text = "";
            txtplotsizeoffrd.Text = "";
        }
        private void btnaddtogrdoffred_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (var item in grdtrdoffered.Rows)
                {
                    if (item.Cells["FileNo"].Value.ToString() == txtfilenooffr.Text)
                    {
                        MessageBox.Show("File No / Plot No is already in the List");
                        return;
                    }
                }

                SqlParameter[] param = {
                    new SqlParameter("@Task","TradeOff_Offered_Files_Verification"),
                    new SqlParameter("@FileNo",txtfilenooffr.Text)
                };
                int OfferFilecount = int.Parse(Helper.SQLHelper.ExecuteScalar(Helper.SQLHelper.createConnection(), CommandType.StoredProcedure, "App.USP_tbl_FileMap", param).ToString());

                if (OfferFilecount > 0)
                {
                    MessageBox.Show("File/Plot No is Already Exist in Trade Offer Files List.");
                    return;
                }


                DataTable dt = new DataTable();
                dt.Clear();
                dt.Columns.Add("FileNo");
                dt.Columns.Add("Plotsize");
                DataRow dr = dt.NewRow();
                dr["FileNo"] = txtfilenooffr.Text;
                dr["Plotsize"] = txtplotsizeoffrd.SelectedItem.ToString();
                dt.Rows.Add(dr);
                dt_bl_offrd.Merge(dt);
                grdtrdoffered.DataSource = dt_bl_offrd.DefaultView;
                Clear_Offered();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frm_TradeOffCreate_Load(object sender, EventArgs e)
        {
            // BindColumnWithOffredFiles();
        }
        private void BindColumnWithOffredFiles()
        {
            GridViewComboBoxColumn comboColumn = new GridViewComboBoxColumn("Plot size");
            //set the column data source - the possible column values
            comboColumn.DataSource = new String[] { "1 Kanal", "5 Marla", "10 Marla" };
            //set the FieldName - the column will retrieve the value from "Phone" column in the data table
            comboColumn.FieldName = "Plotsize";
            comboColumn.Name = "Plotsize";
            comboColumn.Width = 150;
            //add the column to the grid
            grdtrdoffered.Columns.Add(comboColumn);
        }

    }
}
