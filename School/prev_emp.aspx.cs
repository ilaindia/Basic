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
    public partial class prev_emp : System.Web.UI.Page
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
                cmd.CommandText = "INSERT INTO [dbo].[gendral_info] ([full_name],[emp_id]" +
                                   ",[division],[grade],[designation],[dob],[pob],[doj]" +
                                   ",[pan_card_no],[passport_no],[blood_group],[religion],[caste])" +
                                    "values ('" + fn.Text + "','" + emp_id.Text + "','" + division.SelectedValue + "','" +
                                    grade.SelectedValue + "','" + desi.SelectedValue + "','" + dob.Text + "','" +
                                    pob.Text + "','" + doj.Text + "','" + pan.Text + "','" +
                                    passport.Text + "','" + blood.Text + "','" + religion.SelectedValue + "','" + caste.Text + "')";
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
                cmd.CommandText = "SELECT * FROM [dbo].[gendral_info]";
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
            //division.SelectedValue = "";
            //grade.SelectedValue = "";
            //desi.SelectedValue = "";
            dob.Text = "";
            pob.Text = "";
            doj.Text = "";
            pan.Text = "";
            passport.Text = "";
            blood.Text = "";
            //religion.SelectedValue = "";
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
                    cmd.CommandText = "select * from [dbo].[gendral_info] where sys_id =" + e.CommandArgument.ToString();
                    SqlDataAdapter sqlda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sqlda.Fill(dt);
                    if (dt.Rows.Count != 0 || dt != null)
                    {
                        hid.Value = dt.Rows[0]["sys_id"].ToString();
                        fn.Text = dt.Rows[0]["full_name"].ToString();
                        emp_id.Text = dt.Rows[0]["emp_id"].ToString();
                        division.SelectedValue = dt.Rows[0]["division"].ToString();
                        grade.SelectedValue = dt.Rows[0]["grade"].ToString();
                        desi.SelectedValue = dt.Rows[0]["designation"].ToString();
                        dob.Text = dt.Rows[0]["dob"].ToString();
                        pob.Text = dt.Rows[0]["pob"].ToString();
                        doj.Text = dt.Rows[0]["doj"].ToString();
                        pan.Text = dt.Rows[0]["pan_card_no"].ToString();
                        passport.Text = dt.Rows[0]["passport_no"].ToString();
                        blood.Text = dt.Rows[0]["blood_group"].ToString();
                        religion.SelectedValue = dt.Rows[0]["religion"].ToString();
                        caste.Text = dt.Rows[0]["caste"].ToString();
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
                    cmd.CommandText = "delete from [dbo].[gendral_info] where sys_id=" + e.CommandArgument.ToString();
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
                cmd.CommandText = "UPDATE [dbo].[gendral_info]" +
                                    "SET [full_name] = '" + fn.Text + "'" +
                                        ",[emp_id] = '" + emp_id.Text + "'" +
                                        ",[division] = '" + division.SelectedValue + "'" +
                                        ",[grade] = '" + grade.SelectedValue + "'" +
                                        ",[designation] = '" + desi.SelectedValue + "'" +
                                        ",[dob] = '" + dob.Text + "'" +
                                        ",[pob] = '" + pob.Text + "'" +
                                        ",[doj] = '" + doj.Text + "'" +
                                        ",[pan_card_no] = '" + pan.Text + "'" +
                                        ",[passport_no] = '" + passport.Text + "'" +
                                        ",[blood_group] = '" + blood.Text + "'" +
                                        ",[religion] = '" + religion.SelectedValue + "'" +
                                        ",[caste] = '" + caste.Text + "'" +
                                        "  WHERE sys_id=" + hid.Value;
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