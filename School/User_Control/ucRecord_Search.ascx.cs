using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace School.User_Control
{
    public partial class ucRecord_Search : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        #region RECORD
        protected void ddlRecordSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnDBSearch(sender, e);
        }
        public string SelectedRecord
        {
            get
            {
                return ddlRecordSearch.SelectedValue;
            }
            set
            {
                this.ddlRecordSearch.SelectedValue = value;
            }
        } 
        #endregion

        #region SEARCHING
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            OnDBSearch(sender, e);
        }
        public string SelectedColumn
        {
            get
            {
                return ddlColName.SelectedValue;
            }
            set
            {
                this.ddlColName.SelectedValue = value;
            }
        }
        public string SearchText
        {
            get
            {
                return txtSearchText.Text;
            }
            set
            {
                txtSearchText.Text = value;
            }
        }
        public DataTable ColumnDatasource
        {
            set
            {
                this.ddlColName.DataSource = value;
                this.ddlColName.DataBind();
            }
        } 
        #endregion


        public event EventHandler DbRecordSearch;
        protected virtual void OnDBSearch(object sender, EventArgs e)
        {
            if (DbRecordSearch != null)
            {
                DbRecordSearch(this, e);
            }
        }
    }
}