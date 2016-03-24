using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace School
{
    public partial class general : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadgv();
                clear();
            }

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
                sqlopen();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "INSERT INTO [dbo].[GENERAL] ([FULL_NAME]" +
                                   ",[DIVISION],[GRADE],[DESIGNATION],[DOB],[POB],[DOJ]" +
                                   ",[PAN],[PASSPORT],[BLOOD],[RELIGION],[CASTE]) values" +
                                   "(@name,@division,@grade,@desi,@dob,@pob,@doj,@pan,@passport,@blood,@religion,@caste)";
                cmd.Parameters.AddWithValue("@name", fn.Text);
                cmd.Parameters.AddWithValue("@division", division.Text);
                cmd.Parameters.AddWithValue("@grade", grade.Text);
                cmd.Parameters.AddWithValue("@desi", desi.Text);
                cmd.Parameters.AddWithValue("@dob", dob.Text);
                cmd.Parameters.AddWithValue("@pob", pob.Text);
                cmd.Parameters.AddWithValue("@doj", doj.Text);
                cmd.Parameters.AddWithValue("@pan", pan.Text);
                cmd.Parameters.AddWithValue("@passport", passport.Text);
                cmd.Parameters.AddWithValue("@blood", blood.Text);
                cmd.Parameters.AddWithValue("@religion", religion.Text);
                cmd.Parameters.AddWithValue("@caste", caste.Text);
                cmd.ExecuteNonQuery();
                Common.Success_Msg(this, "Insert Successfull");
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
                cmd.CommandText = "SELECT * FROM [dbo].[GENERAL]";
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
            fn.Text = "";
            emp_id.Text = "";
            dob.Text = "";
            pob.Text = "";
            doj.Text = "";
            pan.Text = "";
            passport.Text = "";
            blood.Text = "";
            caste.Text = "";
            btn_upt.Visible = false;
            btn_sve.Visible = true;
            pn_listbtn.Visible = true;
            pn_enterybtn.Visible = false;
            pnl_usr.Visible = false;
            pnl_gv.Visible = true;
        }
        protected void btn_del_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "gvedit")
            {
                try
                {
                    clear();
                    sqlopen();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "select * from [dbo].[GENERAL] where SYS_ID =" + e.CommandArgument.ToString();
                    SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    if (dt.Rows.Count != 0 || dt != null)
                    {
                        hid.Value = dt.Rows[0]["SYS_ID"].ToString();
                        fn.Text = dt.Rows[0]["FULL_NAME"].ToString();
                        division.SelectedValue = dt.Rows[0]["DIVISION"].ToString();
                        grade.SelectedValue = dt.Rows[0]["GRADE"].ToString();
                        desi.SelectedValue = dt.Rows[0]["DESIGNATION"].ToString();
                        dob.Text = dt.Rows[0]["DOB"].ToString();
                        pob.Text = dt.Rows[0]["POB"].ToString();
                        doj.Text = dt.Rows[0]["DOJ"].ToString();
                        pan.Text = dt.Rows[0]["PAN"].ToString();
                        passport.Text = dt.Rows[0]["PASSPORT"].ToString();
                        blood.Text = dt.Rows[0]["BLOOD"].ToString();
                        religion.SelectedValue = dt.Rows[0]["RELIGION"].ToString();
                        caste.Text = dt.Rows[0]["CASTE"].ToString();
                        btn_upt.Visible = true;
                        btn_sve.Visible = false;
                        pn_listbtn.Visible = false;
                        pn_enterybtn.Visible = true;
                        pnl_usr.Visible = true;
                        pnl_gv.Visible = false;
                    }
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
            else if (e.CommandName == "gvdelete")
            {
                try
                {
                    clear();
                    sqlopen();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    cmd.CommandText = "delete from [dbo].[GENERAL] where SYS_ID=" + e.CommandArgument.ToString();
                    cmd.ExecuteNonQuery();
                    loadgv();
                    Common.Success_Msg(this, "deleted successfull");
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
            else if (e.CommandName == "gvPrint")
            {
                string PrintUrl = "/Report/Master_Report.aspx?REPORT_TYPE=PF&EMP_SYS_ID=" + e.CommandArgument.ToString();

                Common.JavascriptFunc(this, " window.open('" + PrintUrl + "', 'popup_window', 'width=700,height=700,left=400,top=0,resizable=yes');");
            }
        }
        protected void btn_upt_Click(object sender, EventArgs e)
        {
            try
            {
                sqlopen();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "UPDATE [dbo].[GENERAL]" +
                                    "SET [FULL_NAME] = '" + fn.Text + "'" +
                                        ",[DIVISION] = '" + division.SelectedValue + "'" +
                                        ",[GRADE] = '" + grade.SelectedValue + "'" +
                                        ",[DESIGNATION] = '" + desi.SelectedValue + "'" +
                                        ",[DOB] = '" + dob.Text + "'" +
                                        ",[POB] = '" + pob.Text + "'" +
                                        ",[DOJ] = '" + doj.Text + "'" +
                                        ",[PAN] = '" + pan.Text + "'" +
                                        ",[PASSPORT] = '" + passport.Text + "'" +
                                        ",[BLOOD] = '" + blood.Text + "'" +
                                        ",[RELIGION] = '" + religion.SelectedValue + "'" +
                                        ",[CASTE] = '" + caste.Text + "'" +
                                        "  WHERE SYS_ID=" + hid.Value;
                cmd.ExecuteNonQuery();
                loadgv();
                Common.Success_Msg(this, "Updated Successfully");
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
        protected void but_adnew_Click(object sender, EventArgs e)
        {
            pn_listbtn.Visible = false;
            pn_enterybtn.Visible = true;
            pnl_usr.Visible = true;
            pnl_gv.Visible = false;
        }
    }
}