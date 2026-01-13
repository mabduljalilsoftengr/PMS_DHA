using PeshawarDHASW.Data_Layer.clsUser;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeshawarDHASW.Helper
{
    //class UserHelper
    //{
    //    //public static string GetUserBranch()
    //    //{
    //    //    SqlParameter[] prmt =
    //    //    {
    //    //        new SqlParameter("@Task", "SelectByUserID"),
    //    //        new SqlParameter("@UserID", Models.clsUser.ID)
    //    //    };

    //    //    DataSet ds = cls_dl_User.UserReader(prmt);

    //    //    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //    //    {
    //    //        return ds.Tables[0].Rows[0]["Branch"].ToString();
    //    //    }

    //    //    return "";
    //    //}

    //    public static string GetUserBranch()
    //    {
    //        string query = @"
    //            SELECT UserID, UserName, Branch 
    //            FROM Users 
    //            WHERE UserID = @UserID";

    //        SqlParameter[] prmt =
    //        {
    //            new SqlParameter("@UserID", Models.clsUser.ID)
    //        };

    //        DataSet ds = UserReaderByQuery(query, prmt);

    //        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
    //        {
    //            return ds.Tables[0].Rows[0]["Branch"].ToString();
    //        }

    //        return "";
    //    }

    //    public static DataSet UserReaderByQuery(string query, SqlParameter[] prmt)
    //    {
    //        string Conn = clsMostUseVars.Connectionstring;
    //        using (SqlConnection con = new SqlConnection(Conn))
    //        {
    //            using (SqlCommand cmd = new SqlCommand(query, con))
    //            {
    //                cmd.CommandType = CommandType.Text;   // RAW SQL
    //                cmd.Parameters.AddRange(prmt);

    //                SqlDataAdapter da = new SqlDataAdapter(cmd);
    //                DataSet ds = new DataSet();
    //                da.Fill(ds);
    //                return ds;
    //            }
    //        }
    //    }

    //}

    public static class UserHelper 
    {
        public static string GetUserBranch()
        {
            string Conn = clsMostUseVars.Connectionstring;

            string query = @"
                            SELECT ID, UserName, Branch
                            FROM dbo.tbl_user
                            WHERE ID = @UserID";

            using (SqlConnection con = new SqlConnection(Conn))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@UserID", Models.clsUser.ID);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        return ds.Tables[0].Rows[0]["Branch"].ToString();
                    }
                }
            }

            return "";
        }
    }

}
