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
    public partial class contact_info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                clear();
                loadgv();
                dropdown();           
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
                cmd.CommandText = "INSERT INTO [dbo].[CONTACT]([CNT_ID],[PERMANENT],[PRESENT]" +
                                   ",[MAIL],[MOBILE],[EC_NAME],[EC_MOBILE])" +
                                   "VALUES (@con_id,@perm_ads,@pres_ads,@mail,@ph,@ec_name,@ec_ph)";
                cmd.Parameters.AddWithValue("@con_id", ddl_empid.SelectedValue);
                cmd.Parameters.AddWithValue("@perm_ads", perm_ads.Text);
                cmd.Parameters.AddWithValue("@pres_ads", pres_ads.Text);
                cmd.Parameters.AddWithValue("@mail", mail.Text);
                cmd.Parameters.AddWithValue("@ph", ph.Text);
                cmd.Parameters.AddWithValue("@ec_name", ec_name.Text);
                cmd.Parameters.AddWithValue("@ec_ph", ec_ph.Text);
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
                cmd.CommandText = "SELECT * FROM CONTACT C join GENERAL G ON C.CNT_ID=G.SYS_ID";
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
            perm_ads.Text = "";
            pres_ads.Text = "";
            mail.Text = "";
            ph.Text = "";
            ec_name.Text = "";
            ec_ph.Text = "";
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
                    cmd.CommandText = "select * from [dbo].[CONTACT] where CNT_ID =" + e.CommandArgument.ToString();
                    SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    if (dt.Rows.Count != 0 || dt != null)
                    {
                        hid.Value = dt.Rows[0]["SYS_ID"].ToString();
                        ddl_empid.SelectedValue = dt.Rows[0]["CNT_ID"].ToString();
                        perm_ads.Text = dt.Rows[0]["PERMANENT"].ToString();
                        pres_ads.Text = dt.Rows[0]["PRESENT"].ToString();
                        mail.Text = dt.Rows[0]["MAIL"].ToString();
                        ph.Text = dt.Rows[0]["MOBILE"].ToString();
                        ec_name.Text = dt.Rows[0]["EC_NAME"].ToString();
                        ec_ph.Text = dt.Rows[0]["EC_MOBILE"].ToString();
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
                    cmd.CommandText = "delete from [dbo].[CONTACT] where SYS_ID=" + e.CommandArgument.ToString();
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
                cmd.CommandText = "UPDATE [dbo].[CONTACT]" +
                                    "SET [PERMANENT] = '" + perm_ads.Text + "'" +
                                        ",[CNT_ID] = '" + ddl_empid.SelectedValue + "'" +
                                        ",[PRESENT] = '" + pres_ads.Text + "'" +
                                        ",[MAIL] = '" + mail.Text + "'" +
                                        ",[MOBILE] = '" + ph.Text + "'" +
                                        ",[EC_NAME] = '" + ec_name.Text + "'" +
                                        ",[EC_MOBILE] = '" + ec_ph.Text + "'" +
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
        public void dropdown()
        {
            try
            {
                sqlopen();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SELECT * FROM [dbo].[GENERAL]";
                cmd.ExecuteNonQuery();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddl_empid.DataSource = dt;
                ddl_empid.DataBind();
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
    }
}