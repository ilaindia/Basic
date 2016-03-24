using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GuruBal;
using GuruDal;
using School.Config;

namespace School
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                LoadFormData();
            }
        }
        public void LoadFormData()
        {
            BLL_Common bl = new BLL_Common(Guru.Get_ConnectionString, Usr.Name, Company.Name);
            try
            {

            }
            catch (Exception ex)
            {
                Common.Error_Msg(this, ex);
            }
            finally
            {
                bl.Dispose();
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            BLL_Common bl = new BLL_Common(Guru.Get_ConnectionString, Usr.Name, Company.Name);
            try
            {
                
            }
            catch (Exception ex)
            {
                Common.Error_Msg(this, ex);
            }
            finally
            {
                bl.Dispose();
            }
        }

        protected void btnForgotPassword_OnClickd_Click(object sender, EventArgs e)
        {
            
        }
    }
}