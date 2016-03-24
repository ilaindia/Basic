using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using GuruDal;

namespace School
{
    public partial class edu_details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadgv();
                clear();
                gvUnitList.DataSource = GetUnitList(true);
                gvUnitList.DataBind();
            }

        }

        SqlConnection con;
        public void sqlopen()
        {
            con = new SqlConnection();
            con.ConnectionString = @"Data Source=JADE\SQLEXPRESS;Initial Catalog=School;Integrated Security=True";
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
        }
        public void sqlclose()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        public void loadgv()
        {
            try
            {
                sqlopen();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT GENERAL.FULL_NAME as NAME, GENERAL.EMP_ID as EMP, q.QUALIFICATION as QUA, " +
                                    "e.SUBJECT as SUB, e.YEAR FROM GENERAL JOIN EDUCATION e ON GENERAL.SYS_ID = e.EMP_ID " +
                                    "JOIN QUALIFICATION q ON e.QUA_ID = Q.QUA_ID";
                SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                sqlda.Fill(ds);
                gv_cust.DataSource = ds.Tables[0];
                gv_cust.DataBind();
            }
            catch (Exception ex)
            {
                Common.Error_Msg(this, ex.Message);
            }
            finally
            {
                sqlclose();
            }
        }
        public void clear()
        {
            hid.Value = "";
            pn_listbtn.Visible = true;
            pn_enterybtn.Visible = false;
            pnl_edu.Visible = false;
            pnl_gv.Visible = true;
        }
        protected void btn_cnl_Click(object sender, EventArgs e)
        {
            loadgv();
            clear();
        }
        
        protected void btn_sve_Click(object sender, EventArgs e)
        {
            try
            {
                clear();
                sqlopen();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                DataTable dt = GetUnitList(false); 
                foreach (DataRow dr in dt.Rows)
                {
                    GuruConvert.AsString(dr["SYS_ID"]);

                    if (GuruConvert.AsString(dr["ISDELETED"]) == "1")
                    {
                        if (GuruConvert.AsString(dr["SYS_ID"]) != "") //PRIMARY KEY   GURUCONVERT.asSTRING()
                        {
                            //DELETE QUERY
                        }
                        else
                            continue;
                    }
                    else
                    {
                        // INSERT QUERY
                        cmd.CommandText = "INSERT INTO [dbo].[EDUCATION] ([EMP_ID],[QUA_ID],[SUBJECT],[DEGREE]" +
                                                   ",[INSTITUTE],[MEDIUM],[YEAR],[PERCENTAGE])" +
                                                    "VALUES (@emp,@qua,@sub,@deg,@ins,@med,@year,@per)";                       
                        cmd.Parameters.AddWithValue("@emp", dr["EMP_ID"]);
                        cmd.Parameters.AddWithValue("@qua", dr["QUA_ID"]);
                        cmd.Parameters.AddWithValue("@sub", dr["SUB"]);
                        cmd.Parameters.AddWithValue("@deg", dr["DEGREE"]);
                        cmd.Parameters.AddWithValue("@ins", dr["INSTITUTION"]);
                        cmd.Parameters.AddWithValue("@med", dr["MEDIUM"]);
                        cmd.Parameters.AddWithValue("@year", dr["YEAR"]);
                        cmd.Parameters.AddWithValue("@per", dr["PERCENTAGE"]);
                        cmd.ExecuteNonQuery();
                    }
                }
                loadgv();
                clear();
            }
            catch (Exception ex)
            {
                Common.Error_Msg(this, ex.Message);
            }
            finally
            {
                sqlclose();
            }
        }

        //protected void btn_del_Command(object sender, CommandEventArgs e)
        //{
        //    if (e.CommandName == "gvedit")
        //    {
        //        try
        //        {
        //            clear();
        //            sqlopen();
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.Connection = con;
        //            cmd.CommandText = "select * from [dbo].[edu_qua] where sys_id =" + e.CommandArgument.ToString();
        //            SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
        //            DataTable dt = new DataTable();
        //            sqlda.Fill(dt);
        //            if (dt.Rows.Count != 0 || dt != null)
        //            {
        //                hid.Value = dt.Rows[0]["sys_id"].ToString();
        //                ddl_empid.SelectedValue = dt.Rows[0]["sys_id"].ToString();
        //                ddl_qualid.SelectedValue = dt.Rows[0]["qua_id"].ToString();
        //                subject.Text = dt.Rows[0]["sub"].ToString();
        //                institute.Text = dt.Rows[0]["[institution]"].ToString();
        //                degree.Text = dt.Rows[0]["degree"].ToString();
        //                medium.Text = dt.Rows[0]["[medium]"].ToString();
        //                year.Text = dt.Rows[0]["year"].ToString();
        //                percentage.Text = dt.Rows[0]["percentage"].ToString();
        //                btn_upt.Visible = true;
        //                btn_sve.Visible = false;
        //                pn_listbtn.Visible = false;
        //                pn_enterybtn.Visible = true;
        //                pnl_usr.Visible = true;
        //                pnl_gv.Visible = false;
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Common.Error_Msg(this, ex.Message);
        //        }
        //        finally
        //        {
        //            sqlclose();
        //        }
        //    }
        //    else if (e.CommandName == "gvdelete")
        //    {
        //        try
        //        {
        //            clear();
        //            sqlopen();
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.Connection = con;
        //            cmd.CommandText = "delete from [dbo].[edu_qua] where qua_id=" + e.CommandArgument.ToString();
        //            cmd.ExecuteNonQuery();
        //            loadgv();
        //            Common.Success_Msg(this, "deleted successfull");
        //        }
        //        catch (Exception ex)
        //        {
        //            Common.Error_Msg(this, ex.Message);
        //        }
        //        finally
        //        {
        //            sqlclose();
        //        }
        //    }
        //    else if (e.CommandName == "gvPrint")
        //    {
        //        string PrintUrl = "/Report/Master_Report.aspx?REPORT_TYPE=PF&EMP_SYS_ID=" + e.CommandArgument.ToString();

        //        Common.JavascriptFunc(this, " window.open('" + PrintUrl + "', 'popup_window', 'width=700,height=700,left=400,top=0,resizable=yes');");
        //    }
        //}
        //protected void btn_upt_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        sqlopen();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = con;
        //        cmd.CommandText = "UPDATE [dbo].[edu_qua]" +
        //                            "SET [qua_id] = '" + ddl_qualid.Text + "'" +
        //                                ",[sub] = '" + subject.Text + "'" +
        //                                ",[degree] = '" + degree.Text + "'" +
        //                                ",[institution] = '" + institute.Text + "'" +
        //                                ",[medium] = '" + medium.Text + "'" +
        //                                ",[year] = '" + year.Text + "'" +
        //                                ",[percentage] = '" + percentage.Text + "'" +
        //                                "  WHERE sys_id=" + hid.Value;
        //        cmd.ExecuteNonQuery();
        //        loadgv();
        //        Common.Success_Msg(this, "Updated Successfully");
        //        clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        Common.Error_Msg(this, ex.Message);
        //    }
        //    finally
        //    {
        //        sqlclose();
        //    }

        //}

        protected void but_adnew_Click(object sender, EventArgs e)
        {
            pn_listbtn.Visible = false;
            pn_enterybtn.Visible = true;
            pnl_edu.Visible = true;
            pnl_gv.Visible = false;
        }
        protected void gvUnitList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "AddRow")
                {
                    gvUnitList.DataSource = GetUnitList(true);
                    gvUnitList.DataBind();
                }
                else if (e.CommandName == "DeleteUnit")
                {
                    ((HiddenField)gvUnitList.Rows[GuruConvert.AsInt(e.CommandArgument)].FindControl("hfDeleted")).Value = "1";
                    ((LinkButton)gvUnitList.Rows[GuruConvert.AsInt(e.CommandArgument)].FindControl("btnDeleteUnit")).Visible = false;
                    ((Label)gvUnitList.Rows[GuruConvert.AsInt(e.CommandArgument)].FindControl("lblDelete")).Visible = true;
                }
            }
            catch (Exception ex)
            {
                Common.Error_Msg(this, ex);
            }
        }

        protected void gvUnitList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    ((HiddenField)e.Row.FindControl("hfDeleted")).Value = GuruConvert.AsString(drv["ISDELETED"]);
                    ((LinkButton)e.Row.FindControl("btnDeleteUnit")).Visible = (GuruConvert.AsString(drv["ISDELETED"]) != "1");
                    ((Label)e.Row.FindControl("lblDelete")).Visible = (GuruConvert.AsString(drv["ISDELETED"]) == "1");
                }
            }
            catch (Exception ex)
            {
                Common.Error_Msg(this, ex);
            }
        }

        public DataTable GetUnitList(Boolean isAddNewRow)
        {
            try
            {
                DataTable dtList = new DataTable();
                dtList.Columns.Add("SNO");
                dtList.Columns.Add("SYS_ID");
                dtList.Columns.Add("EMP_ID");
                dtList.Columns.Add("QUA_ID");
                dtList.Columns.Add("SUB");
                dtList.Columns.Add("DEGREE");
                dtList.Columns.Add("INSTITUTION");
                dtList.Columns.Add("MEDIUM");
                dtList.Columns.Add("YEAR");
                dtList.Columns.Add("PERCENTAGE");
                dtList.Columns.Add("ISDELETED");
                for (int i = 0; i < gvUnitList.Rows.Count; i++)
                {
                    DataRow dr = dtList.NewRow();
                    dr["SNO"] = (i + 1);
                    dr["SYS_ID"] = ((HiddenField)gvUnitList.Rows[i].FindControl("hfKeyvalue")).Value;
                    dr["ISDELETED"] = ((HiddenField)gvUnitList.Rows[i].FindControl("hfDeleted")).Value;
                    dr["EMP_ID"] = ((TextBox)gvUnitList.Rows[i].FindControl("txtUnitSys")).Text;
                    dr["QUA_ID"] = ((TextBox)gvUnitList.Rows[i].FindControl("txtUnitQua")).Text;
                    dr["SUB"] = ((TextBox)gvUnitList.Rows[i].FindControl("txtUnitSub")).Text;
                    dr["DEGREE"] = ((TextBox)gvUnitList.Rows[i].FindControl("txtUnitDegree")).Text;
                    dr["INSTITUTION"] = ((TextBox)gvUnitList.Rows[i].FindControl("txtUnitIns")).Text;
                    dr["MEDIUM"] = ((TextBox)gvUnitList.Rows[i].FindControl("txtUnitMedium")).Text;
                    dr["YEAR"] = ((TextBox)gvUnitList.Rows[i].FindControl("txtUnitYear")).Text;
                    dr["PERCENTAGE"] = ((TextBox)gvUnitList.Rows[i].FindControl("txtUnitPer")).Text;

                    dtList.Rows.Add(dr);
                }

                if (isAddNewRow)
                {
                    DataRow dr1 = dtList.NewRow();
                    dr1["SNO"] = (gvUnitList.Rows.Count + 1);
                    dr1["SYS_ID"] = "";
                    dr1["EMP_ID"] = "";
                    dr1["QUA_ID"] = "";
                    dr1["SUB"] = "";
                    dr1["DEGREE"] = "";
                    dr1["INSTITUTION"] = "";
                    dr1["MEDIUM"] = "";
                    dr1["YEAR"] = "";
                    dr1["PERCENTAGE"] = "";
                    dtList.Rows.Add(dr1);
                }
                return dtList;
            }
            catch { throw; }
        }
    }
}