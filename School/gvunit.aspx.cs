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
    public partial class gvunit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                gvUnitList.DataSource = GetUnitList(true);
                gvUnitList.DataBind();
            }

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
                dtList.Columns.Add("UNIT_NAME");
                dtList.Columns.Add("ISDELETED");
                for (int i = 0; i < gvUnitList.Rows.Count; i++)
                {
                    DataRow dr = dtList.NewRow();
                    dr["SNO"] = (i + 1);
                    dr["SYS_ID"] = ((HiddenField)gvUnitList.Rows[i].FindControl("hfKeyvalue")).Value;
                    dr["ISDELETED"] = ((HiddenField)gvUnitList.Rows[i].FindControl("hfDeleted")).Value;
                    dr["UNIT_NAME"] = ((TextBox)gvUnitList.Rows[i].FindControl("txtUnitName")).Text;

                    dtList.Rows.Add(dr);
                }

                if (isAddNewRow)
                {
                    DataRow dr1 = dtList.NewRow();
                    dr1["SNO"] = (gvUnitList.Rows.Count + 1);
                    dr1["UNIT_NAME"] = "";
                    dr1["SYS_ID"] = "";
                    dtList.Rows.Add(dr1);
                }
                return dtList;
            }
            catch { throw; }
        }

        //protected void save_Click(object sender, BulletedListEventArgs e)
        //{
        //    DataTable dt = GetUnitList(false);
        //    foreach(DataRow dr in dt.Rows)
        //    {
        //        GuruConvert.AsString(dr["UNIT_NAME"]);

        //        if (GuruConvert.AsString(dr["ISDELETED"]) == "1")
        //        {
        //            if (bl.UnitData.SYS_ID != "") //PRIMARY KEY   GURUCONVERT.asSTRING()
        //            {
        //                bl.DeleteUnitFlag(bl.UnitData.SYS_ID); //DELETE QUERY
        //            }
        //            else
        //                continue;
        //        }
        //        else
        //        {
        //            bl.InsertUpdateUnitEntry(); // INSERT QUERY
        //        }
        //    }
        //}
    }
}