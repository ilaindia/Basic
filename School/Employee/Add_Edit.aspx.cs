using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GuruBal;
using GuruDal;
using School.Config;

namespace School.Employee
{
    public partial class Add_Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (!Page.IsPostBack)
            {
                Clear_Control();

                if (Request.QueryString.Count == 0)
                {
                    btnNew_OnClick(this, null);
                }
                else
                {
                    string str = Common.DecryptUrl(GuruConvert.AsString(((Request.QueryString.Count == 0) ? "" : Request.QueryString["ID"])));
                    btnEdit_OnClick(this, new CommandEventArgs("", str));
                }
                Common.JavascriptFunc(this, "collapsedSidebar();");
            }
        }

        protected void btnNext_OnClick(object sender, EventArgs e)
        {
            if (pnGenral.Visible)
            {
                pnGenral.Visible = pnQualification.Visible = pnExperience.Visible = pnFamily.Visible = false;
                pnContact.Visible = btnBack.Enabled = btnNext.Enabled = true;
                impSliderPrev.ImageUrl = hfEmpImg.Value = (fuImage.HasFile) ?
                            Common.UploadImg(fuImage, Common.UploadPath + "/User_Img/") :
                            (
                                (hfKeyvalue.Value == String.Empty) ?
                                    ((GuruConvert.AsString(hfEmpImg.Value) == string.Empty) ?
                                        "/App_Upload/User_Img/avatar.png" : impSliderPrev.ImageUrl)
                                : hfEmpImg.Value
                            );
            }
            else if (pnContact.Visible)
            {
                pnGenral.Visible = pnContact.Visible = pnExperience.Visible = pnFamily.Visible = false;
                pnQualification.Visible = btnBack.Enabled = btnNext.Enabled = true;

                if (gvQualification.Rows.Count == 0)
                {
                    gvQualification.DataSource = QualificationDt(1, false);
                    gvQualification.DataBind();
                }
            }
            else if (pnQualification.Visible)
            {
                pnGenral.Visible = pnContact.Visible = pnQualification.Visible = pnFamily.Visible = false;
                pnExperience.Visible = btnNext.Enabled = btnBack.Enabled = true;

                if (gvExperience.Rows.Count == 0)
                {
                    gvExperience.DataSource = ExperienceDt(1, false);
                    gvExperience.DataBind();
                }
            }
            else if (pnExperience.Visible)
            {
                pnGenral.Visible = pnContact.Visible = pnQualification.Visible = pnExperience.Visible = btnNext.Enabled = false;
                pnFamily.Visible = btnBack.Enabled = true;

                if (gvFamily.Rows.Count == 0)
                {
                    gvFamily.DataSource = FamilyDt(1, false);
                    gvFamily.DataBind();
                }
            }
        }

        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            if (pnContact.Visible)
            {
                pnContact.Visible = pnQualification.Visible = pnExperience.Visible = pnFamily.Visible = btnBack.Enabled = false;
                pnGenral.Visible = btnNext.Enabled = true;
                Common.JavascriptFunc(this, "SetImgSrc('" + ResolveUrl(hfEmpImg.Value) + "');");
            }
            else if (pnQualification.Visible)
            {
                pnGenral.Visible = pnQualification.Visible = pnExperience.Visible = pnFamily.Visible = false;
                pnContact.Visible = btnBack.Enabled = btnNext.Enabled = true;
            }
            else if (pnExperience.Visible)
            {
                pnGenral.Visible = pnContact.Visible = pnExperience.Visible = pnFamily.Visible = false;
                pnQualification.Visible = btnBack.Enabled = btnNext.Enabled = true;
            }
            else if (pnFamily.Visible)
            {
                pnGenral.Visible = pnContact.Visible = pnExperience.Visible = pnFamily.Visible = false;
                pnQualification.Visible = btnBack.Enabled = btnNext.Enabled = true;
            }
        }

        protected void Clear_Control()
        {
            pnContact.Visible = pnQualification.Visible = pnExperience.Visible = pnFamily.Visible = btnBack.Enabled = false;
            pnGenral.Visible = btnNext.Enabled = true;
            Common.JavascriptFunc(this, "SetImgSrc('" + ResolveUrl("~/App_Upload/User_Img/avatar.png") + "');");
            hfKeyvalue.Value = "";
        }

        #region QUALIFICATION GRID ADD | DELETE ROW
        protected void gvQualification_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    ((HiddenField)e.Row.FindControl("hfdelete")).Value = GuruConvert.AsString(drv["ISDELETED"]);
                    ((LinkButton)e.Row.FindControl("btnDelete")).Visible = (GuruConvert.AsString(drv["ISDELETED"]) != "1");
                    ((Label)e.Row.FindControl("lblDelete")).Visible = (GuruConvert.AsString(drv["ISDELETED"]) == "1");
                    ((DropDownList)e.Row.FindControl("ddlQualification")).SelectedValue = GuruConvert.AsString(drv["QUALIFICATION"]);
                }
            }
            catch (Exception ex)
            {
                Common.Error_Msg(this, ex);
            }
        }

        protected void gvQualification_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "AddRow")
                {
                    gvQualification.DataSource = QualificationDt(1, true);
                    gvQualification.DataBind();
                    ((DropDownList)gvQualification.Rows[gvQualification.Rows.Count - 1].FindControl("ddlQualification")).Focus();
                }
                else if (e.CommandName == "Deleted")
                {
                    ((HiddenField)gvQualification.Rows[GuruConvert.AsInt(e.CommandArgument)].FindControl("hfdelete")).Value = "1";
                    ((LinkButton)gvQualification.Rows[GuruConvert.AsInt(e.CommandArgument)].FindControl("btnDelete")).Visible = false;
                    ((Label)gvQualification.Rows[GuruConvert.AsInt(e.CommandArgument)].FindControl("lblDelete")).Visible = true;
                }
            }
            catch (Exception ex)
            {
                Common.Error_Msg(this, ex);
            }
        }

        protected DataTable QualificationDt(int newRowCnt = 1, bool isOld = false)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("SYS_ID");
            dt.Columns.Add("QUALIFICATION");
            dt.Columns.Add("SUBJECT");
            dt.Columns.Add("DEGREE");
            dt.Columns.Add("INSTUT");
            dt.Columns.Add("MEDIUM");
            dt.Columns.Add("PASS_YEAR");
            dt.Columns.Add("PERCENTAGE");
            dt.Columns.Add("ISDELETED");
            if (isOld)
            {
                for (int i = 0; i < gvQualification.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["SYS_ID"] = GuruConvert.AsString(((HiddenField)gvQualification.Rows[i].FindControl("hfKeyvalue")).Value);
                    dr["QUALIFICATION"] = GuruConvert.AsString(((DropDownList)gvQualification.Rows[i].FindControl("ddlQualification")).SelectedValue);
                    dr["SUBJECT"] = GuruConvert.AsString(((TextBox)gvQualification.Rows[i].FindControl("txtSubject")).Text);
                    dr["DEGREE"] = GuruConvert.AsString(((TextBox)gvQualification.Rows[i].FindControl("txtDegree")).Text);
                    dr["INSTUT"] = GuruConvert.AsString(((TextBox)gvQualification.Rows[i].FindControl("txtIntitution")).Text);
                    dr["MEDIUM"] = GuruConvert.AsString(((TextBox)gvQualification.Rows[i].FindControl("txtMedium")).Text);
                    dr["PASS_YEAR"] = GuruConvert.AsString(((TextBox)gvQualification.Rows[i].FindControl("txtYrPass")).Text);
                    dr["PERCENTAGE"] = GuruConvert.AsString(((TextBox)gvQualification.Rows[i].FindControl("txtPercentage")).Text);
                    dr["ISDELETED"] = GuruConvert.AsString(((HiddenField)gvQualification.Rows[i].FindControl("hfdelete")).Value);
                    dt.Rows.Add(dr);
                }
            }
            for (int i = 0; i < newRowCnt; i++)
            {
                DataRow dr = dt.NewRow();
                dr["SYS_ID"] = "";
                dr["QUALIFICATION"] = "0";
                dr["SUBJECT"] = "";
                dr["DEGREE"] = "";
                dr["INSTUT"] = "";
                dr["MEDIUM"] = "";
                dr["PASS_YEAR"] = "";
                dr["PERCENTAGE"] = "";
                dr["ISDELETED"] = "0";
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion

        #region EXPERIENCE GRID ADD | DELETED ROW
        protected void gvExperience_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    ((HiddenField)e.Row.FindControl("hfdelete")).Value = GuruConvert.AsString(drv["ISDELETED"]);
                    ((LinkButton)e.Row.FindControl("btnDelete")).Visible = (GuruConvert.AsString(drv["ISDELETED"]) != "1");
                    ((Label)e.Row.FindControl("lblDelete")).Visible = (GuruConvert.AsString(drv["ISDELETED"]) == "1");
                }
            }
            catch (Exception ex)
            {
                Common.Error_Msg(this, ex);
            }
        }
        protected void gvExperience_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "AddRow")
                {
                    gvExperience.DataSource = ExperienceDt(1, true);
                    gvExperience.DataBind();
                    ((TextBox)gvExperience.Rows[gvExperience.Rows.Count - 1].FindControl("txtSchool")).Focus();
                }
                else if (e.CommandName == "Deleted")
                {
                    ((HiddenField)gvExperience.Rows[GuruConvert.AsInt(e.CommandArgument)].FindControl("hfdelete")).Value = "1";
                    ((LinkButton)gvExperience.Rows[GuruConvert.AsInt(e.CommandArgument)].FindControl("btnDelete")).Visible = false;
                    ((Label)gvExperience.Rows[GuruConvert.AsInt(e.CommandArgument)].FindControl("lblDelete")).Visible = true;
                }
            }
            catch (Exception ex)
            {
                Common.Error_Msg(this, ex);
            }
        }
        protected DataTable ExperienceDt(int newRowCnt = 1, bool isOld = false)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("SYS_ID");
            dt.Columns.Add("SCHOOL");
            dt.Columns.Add("FRM_DT");
            dt.Columns.Add("TO_DT");
            dt.Columns.Add("DESIGNATION");
            dt.Columns.Add("ISDELETED");
            if (isOld)
            {
                for (int i = 0; i < gvExperience.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["SYS_ID"] = GuruConvert.AsString(((HiddenField)gvExperience.Rows[i].FindControl("hfKeyvalue")).Value);
                    dr["SCHOOL"] = GuruConvert.AsString(((TextBox)gvExperience.Rows[i].FindControl("txtSchool")).Text);
                    dr["FRM_DT"] = GuruConvert.AsString(((TextBox)gvExperience.Rows[i].FindControl("txtFrom")).Text);
                    dr["TO_DT"] = GuruConvert.AsString(((TextBox)gvExperience.Rows[i].FindControl("txtTo")).Text);
                    dr["DESIGNATION"] = GuruConvert.AsString(((TextBox)gvExperience.Rows[i].FindControl("txtDesignation")).Text);
                    dr["ISDELETED"] = GuruConvert.AsString(((HiddenField)gvExperience.Rows[i].FindControl("hfdelete")).Value);
                    dt.Rows.Add(dr);
                }
            }
            for (int i = 0; i < newRowCnt; i++)
            {
                DataRow dr = dt.NewRow();
                dr["SYS_ID"] = "";
                dr["SCHOOL"] = "";
                dr["FRM_DT"] = "";
                dr["TO_DT"] = "";
                dr["DESIGNATION"] = "";
                dr["ISDELETED"] = "0";
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion

        #region FAMILY GRID ADD | DELETE ROW
        protected void gvFamily_OnRowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DataRowView drv = (DataRowView)e.Row.DataItem;
                    ((HiddenField)e.Row.FindControl("hfdelete")).Value = GuruConvert.AsString(drv["ISDELETED"]);
                    ((LinkButton)e.Row.FindControl("btnDelete")).Visible = (GuruConvert.AsString(drv["ISDELETED"]) != "1");
                    ((Label)e.Row.FindControl("lblDelete")).Visible = (GuruConvert.AsString(drv["ISDELETED"]) == "1");
                    ((DropDownList)e.Row.FindControl("ddlRelation")).SelectedValue = GuruConvert.AsString(drv["RELATION_TYPE"]);
                }
            }
            catch (Exception ex)
            {
                Common.Error_Msg(this, ex);
            }
        }

        protected void gvFamily_OnRowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "AddRow")
                {
                    gvFamily.DataSource = FamilyDt(1, true);
                    gvFamily.DataBind();
                    ((DropDownList)gvFamily.Rows[gvFamily.Rows.Count - 1].FindControl("ddlRelation")).Focus();
                }
                else if (e.CommandName == "Deleted")
                {
                    ((HiddenField)gvFamily.Rows[GuruConvert.AsInt(e.CommandArgument)].FindControl("hfdelete")).Value = "1";
                    ((LinkButton)gvFamily.Rows[GuruConvert.AsInt(e.CommandArgument)].FindControl("btnDelete")).Visible = false;
                    ((Label)gvFamily.Rows[GuruConvert.AsInt(e.CommandArgument)].FindControl("lblDelete")).Visible = true;
                }
            }
            catch (Exception ex)
            {
                Common.Error_Msg(this, ex);
            }
        }

        protected DataTable FamilyDt(int newRowCnt = 1, bool isOld = false)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("SYS_ID");
            dt.Columns.Add("RELATION_TYPE");
            dt.Columns.Add("NAME");
            dt.Columns.Add("QUALIFICATION");
            dt.Columns.Add("EMP_NAME");
            dt.Columns.Add("BG");
            dt.Columns.Add("MEDIC_PROBLEM");
            dt.Columns.Add("PHY_DISABILITY");
            dt.Columns.Add("ISDELETED");
            if (isOld)
            {
                for (int i = 0; i < gvFamily.Rows.Count; i++)
                {
                    DataRow dr = dt.NewRow();
                    dr["SYS_ID"] = GuruConvert.AsString(((HiddenField)gvFamily.Rows[i].FindControl("hfKeyvalue")).Value);
                    dr["RELATION_TYPE"] = GuruConvert.AsString(((DropDownList)gvFamily.Rows[i].FindControl("ddlRelation")).SelectedValue);
                    dr["NAME"] = GuruConvert.AsString(((TextBox)gvFamily.Rows[i].FindControl("txtName")).Text);
                    dr["QUALIFICATION"] = GuruConvert.AsString(((TextBox)gvFamily.Rows[i].FindControl("txtQualificaiton")).Text);
                    dr["EMP_NAME"] = GuruConvert.AsString(((TextBox)gvFamily.Rows[i].FindControl("txtEmployerName")).Text);
                    dr["BG"] = GuruConvert.AsString(((TextBox)gvFamily.Rows[i].FindControl("txtBloodGrp")).Text);
                    dr["MEDIC_PROBLEM"] = GuruConvert.AsString(((TextBox)gvFamily.Rows[i].FindControl("txtMedicalProblems")).Text);
                    dr["PHY_DISABILITY"] = GuruConvert.AsString(((TextBox)gvFamily.Rows[i].FindControl("txtPhyDisability")).Text);
                    dr["ISDELETED"] = GuruConvert.AsString(((HiddenField)gvFamily.Rows[i].FindControl("hfdelete")).Value);
                    dt.Rows.Add(dr);
                }
            }
            for (int i = 0; i < newRowCnt; i++)
            {
                DataRow dr = dt.NewRow();
                dr["SYS_ID"] = "";
                dr["RELATION_TYPE"] = "0";
                dr["NAME"] = "";
                dr["QUALIFICATION"] = "";
                dr["EMP_NAME"] = "";
                dr["BG"] = "";
                dr["MEDIC_PROBLEM"] = "";
                dr["PHY_DISABILITY"] = "";
                dr["ISDELETED"] = "0";
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            BLL_Employee_Master bl = new BLL_Employee_Master(Guru.Get_ConnectionString, "", "");
            BLL_Employee_Experience ble = new BLL_Employee_Experience(bl.GetConnection(), "", "");
            BLL_Employee_Qualification blq = new BLL_Employee_Qualification(bl.GetConnection(), "", "");
            BLL_Employee_Family blf = new BLL_Employee_Family(bl.GetConnection(), "", "");
            bl.BeginTransaction();
            try
            {
                bl.Data.SYS_ID = hfKeyvalue.Value;
                bl.Data.ID = txtId.Text;
                bl.Data.FULL_NAME = txtName.Text;
                bl.Data.DIVISION = ddlDivision.SelectedValue;
                bl.Data.GRADE = ddlGrade.SelectedValue;
                bl.Data.DESIGNATION = ddlDesignation.SelectedValue;
                bl.Data.DOB = GuruConvert.AsDateDB(txtDob.Text);
                bl.Data.PLACE_BIRTH = txtBirthPlace.Text;
                bl.Data.DOJ = GuruConvert.AsDateDB(txtDoj.Text);
                bl.Data.PANCARD = txtPancard.Text;
                bl.Data.PASSPORT = txtPassport.Text;
                bl.Data.BG = txtBloodgrp.Text;
                bl.Data.RELIGION = ddlReligion.SelectedValue;
                bl.Data.CAST = txtCast.Text;
                bl.Data.SALARY = txtSalary.Text;
                bl.Data.ESI = txtEsi.Text;
                bl.Data.EPF = txtEpf.Text;
                bl.Data.IMG = (fuImage.HasFile) ?
                                Common.UploadImg(fuImage, Common.UploadPath + "/User_Img/") :
                                (
                                    (hfKeyvalue.Value == String.Empty) ?
                                        ((GuruConvert.AsString(hfEmpImg.Value) == string.Empty) ?
                                            "/App_Upload/User_Img/avatar.png" : impSliderPrev.ImageUrl)
                                    : hfEmpImg.Value
                                );
                bl.Data.PERM_ADDR = txtPremAddress.Text;
                bl.Data.PRES_ADDR = txtPresAddress.Text;
                bl.Data.PERM_EMAIL = txtPremEmail.Text;
                bl.Data.PERM_MOBILE = txtPremPhone.Text;
                bl.Data.EMG_CON_NAME = txtContName.Text;
                bl.Data.EMG_CON_MOBILE = txtContMobile.Text;

                string Keyvalue = bl.InsertUpdateEntry();

                DataTable dt = QualificationDt(0, true);
                foreach (DataRow dr in dt.Rows)
                {
                    blq.Data.SYS_ID = GuruConvert.AsString(dr["SYS_ID"]);
                    if (GuruConvert.AsString(dr["ISDELETED"]) == "1")
                    {
                        if (blq.Data.SYS_ID != String.Empty)
                            blq.DeleteFlag(blq.Data.SYS_ID);
                    }
                    else
                    {
                        blq.Data.QUALIFICATION = GuruConvert.AsString(dr["QUALIFICATION"]);
                        blq.Data.SUBJECT = GuruConvert.AsString(dr["SUBJECT"]);
                        blq.Data.INSTUT = GuruConvert.AsString(dr["INSTUT"]);
                        blq.Data.MEDIUM = GuruConvert.AsString(dr["MEDIUM"]);
                        blq.Data.PASS_YEAR = GuruConvert.AsString(dr["PASS_YEAR"]);
                        blq.Data.PERCENTAGE = GuruConvert.AsString(dr["PERCENTAGE"]);
                        blq.Data.EMP_SYS_ID = Keyvalue;
                        if (blq.Data.QUALIFICATION != "0")
                        {
                            blq.InsertUpdateEntry();
                        }
                    }
                }


                dt = ExperienceDt(0, true);
                foreach (DataRow dr in dt.Rows)
                {
                    ble.Data.SYS_ID = GuruConvert.AsString(dr["SYS_ID"]);
                    if (GuruConvert.AsString(dr["ISDELETED"]) == "1")
                    {
                        if (ble.Data.SYS_ID != String.Empty)
                            ble.DeleteFlag(ble.Data.SYS_ID);
                    }
                    else
                    {
                        ble.Data.SCHOOL = GuruConvert.AsString(dr["SCHOOL"]);
                        ble.Data.FRM_DT = GuruConvert.AsString(dr["FRM_DT"]);
                        ble.Data.TO_DT = GuruConvert.AsString(dr["TO_DT"]);
                        ble.Data.DESIGNATION = GuruConvert.AsString(dr["DESIGNATION"]);
                        ble.Data.EMP_SYS_ID = Keyvalue;
                        if (ble.Data.SCHOOL != "")
                        {
                            ble.InsertUpdateEntry();
                        }
                    }
                }


                dt = FamilyDt(0, true);
                foreach (DataRow dr in dt.Rows)
                {
                    blf.Data.SYS_ID = GuruConvert.AsString(dr["SYS_ID"]);
                    if (GuruConvert.AsString(dr["ISDELETED"]) == "1")
                    {
                        if (blf.Data.SYS_ID != String.Empty)
                            blf.DeleteFlag(blf.Data.SYS_ID);
                    }
                    else
                    {

                        blf.Data.RELATION_TYPE = GuruConvert.AsString(dr["RELATION_TYPE"]);
                        blf.Data.NAME = GuruConvert.AsString(dr["NAME"]);
                        blf.Data.QUALIFICATION = GuruConvert.AsString(dr["QUALIFICATION"]);
                        blf.Data.EMP_NAME = GuruConvert.AsString(dr["EMP_NAME"]);
                        blf.Data.BG = GuruConvert.AsString(dr["BG"]);
                        blf.Data.MEDIC_PROBLEM = GuruConvert.AsString(dr["MEDIC_PROBLEM"]);
                        blf.Data.PHY_DISABILITY = GuruConvert.AsString(dr["PHY_DISABILITY"]);
                        blf.Data.EMP_SYS_ID = Keyvalue;
                        if (blf.Data.RELATION_TYPE != "0")
                        {
                            blf.InsertUpdateEntry();
                        }
                    }
                }
                bl.CommitTransaction();
                Common.Success_Msg(this, "Employee Details Added Successfully...!");
                btnEdit_OnClick(this, new CommandEventArgs("", Keyvalue));
            }
            catch (Exception ex)
            {
                Common.Error_Msg(this, ex.Message);
                bl.RollbackTransaction();
            }
            finally
            {
                bl.Dispose();
            }
        }

        protected void btnNew_OnClick(object sender, EventArgs e)
        {
            BLL_Employee_Master bl = new BLL_Employee_Master(Guru.Get_ConnectionString, "", "");
            try
            {
                txtId.Text = GuruConvert.AsString(bl.ExecuteScalar(new SqlCommand("SELECT  dbo.GET_EMP_ID()")));
            }
            catch (Exception ex)
            {
                Common.Error_Msg(this, ex.Message);
            }
            finally { bl.Dispose(); }
        }
        protected void btnEdit_OnClick(object sender, CommandEventArgs e)
        {
            BLL_Employee_Master bl = new BLL_Employee_Master(Guru.Get_ConnectionString, "", "");
            try
            {
                bl.GetDataEntry(e.CommandArgument.ToString());
                hfKeyvalue.Value = bl.Data.SYS_ID;
                txtId.Text = bl.Data.ID;
                txtName.Text = bl.Data.FULL_NAME;
                ddlDivision.SelectedValue = bl.Data.DIVISION;
                ddlGrade.SelectedValue = bl.Data.GRADE;
                ddlDesignation.SelectedValue = bl.Data.DESIGNATION;
                txtDob.Text = GuruConvert.AsDateDisplay(bl.Data.DOB);
                txtBirthPlace.Text = bl.Data.PLACE_BIRTH;
                txtDoj.Text = GuruConvert.AsDateDisplay(bl.Data.DOJ);
                txtPancard.Text = bl.Data.PANCARD;
                txtPassport.Text = bl.Data.PASSPORT;
                txtBloodgrp.Text = bl.Data.BG;
                ddlReligion.SelectedValue = bl.Data.RELIGION;
                txtCast.Text = bl.Data.CAST;
                txtSalary.Text = bl.Data.SALARY;
                txtEsi.Text = bl.Data.ESI;
                txtEpf.Text = bl.Data.EPF;
                hfEmpImg.Value = bl.Data.IMG;
                txtPremAddress.Text = bl.Data.PERM_ADDR;
                txtPresAddress.Text = bl.Data.PRES_ADDR;
                txtPremEmail.Text = bl.Data.PERM_EMAIL;
                txtPremPhone.Text = bl.Data.PERM_MOBILE;
                txtContName.Text = bl.Data.EMG_CON_NAME;
                txtContMobile.Text = bl.Data.EMG_CON_MOBILE;

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM dbo.EMPLOYEE_QUALIFICATION WHERE ISDELETED <> 1 AND EMP_SYS_ID = @EMP_SYS_ID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@EMP_SYS_ID", bl.Data.SYS_ID);
                gvQualification.DataSource = bl.GetDataTable(cmd);
                gvQualification.DataBind();

                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM dbo.EMPLOYEE_EXPERIENCE WHERE ISDELETED <> 1 AND EMP_SYS_ID = @EMP_SYS_ID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@EMP_SYS_ID", bl.Data.SYS_ID);
                gvExperience.DataSource = bl.GetDataTable(cmd);
                gvExperience.DataBind();

                cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM dbo.EMPLOYEE_FAMILY WHERE ISDELETED <> 1 AND EMP_SYS_ID = @EMP_SYS_ID";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@EMP_SYS_ID", bl.Data.SYS_ID);
                gvFamily.DataSource = bl.GetDataTable(cmd);
                gvFamily.DataBind();


                Common.JavascriptFunc(this, "SetImgSrc('" + ResolveUrl(bl.Data.IMG) + "');");
            }
            catch (Exception ex)
            {
                Common.Error_Msg(this, ex.Message);
            }
            finally
            {
                bl.Dispose();
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("~/Employee/List.aspx");
        }
    }
}