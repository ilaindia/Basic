using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GuruBal;
using GuruDal;
using School.Config;

namespace School.Employee
{
    public partial class List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Pager.CurrentIndex = 1;
                Load_Data();
            }
        }


        protected void Load_Data()
        {
            BLL_Employee_Master bl = new BLL_Employee_Master(Guru.Get_ConnectionString, "", "");
            try
            {
                bl.Pager.OrderBy = Grid.GetSortExpression(gvListView, "FULL_NAME");
                bl.Pager.OrderType = Grid.GetSortDirection(gvListView);
                bl.Pager.SearchBy = FunBoxGuru.GetSearchBy(dbRecordSearch.SelectedColumn);
                bl.Pager.SearchText = GuruConvert.AsString(dbRecordSearch.SearchText);
                bl.Pager.PageNumber = Pager.CurrentIndex;
                bl.Pager.PageSize = GuruConvert.AsInt(dbRecordSearch.SelectedRecord);

                gvListView.DataSource = bl.GetMasterList();
                gvListView.DataBind();
                gvListView.HeaderRow.TableSection = TableRowSection.TableHeader;
                Grid.SetSortDirection(gvListView, bl.Pager.OrderBy, bl.Pager.OrderType);

                if (!Page.IsPostBack)
                {
                    dbRecordSearch.ColumnDatasource = FunBoxGuru.GetSearchByColumns(gvListView);
                }

                Decimal PageCalc = GuruConvert.AsDecimal(bl.Pager.ItemCount) / GuruConvert.AsDecimal(bl.Pager.PageSize);
                Pager.ItemCount = GuruConvert.AsInt(Math.Ceiling(PageCalc));
                int frmIdx = (Pager.CurrentIndex - 1) * bl.Pager.PageSize + 1;
                if (bl.Pager.ItemCount < frmIdx)
                    frmIdx = bl.Pager.ItemCount;
                int toIdx = (Pager.CurrentIndex * bl.Pager.PageSize);
                if (bl.Pager.ItemCount < toIdx)
                    toIdx = bl.Pager.ItemCount;
                PagerInfo.Information = "Page Info: " + Pager.CurrentIndex + " on " + Pager.ItemCount + " Pages | Record Info: " + frmIdx.ToString() + " to " + toIdx.ToString() + " from " + bl.Pager.ItemCount.ToString() + " Records";
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

        #region Pager | Searching | Sorting
        protected void Pager_PagerClick(object sender, EventArgs e)
        {
            Load_Data();
        }
        protected void gvListView_Sorting(object sender, GridViewSortEventArgs e)
        {
            try
            {
                Grid.ChangeSortDirection(gvListView, e.SortExpression);
                Load_Data();
            }
            catch (Exception ex)
            {
                Common.Error_Msg(this, ex);
            }
        }
        protected void dbRecordSearch_DbRecordSearch(object sender, EventArgs e)
        {
            Pager.CurrentIndex = 1;
            Load_Data();
        }
        #endregion

        protected void btnEdit_Command(object sender, CommandEventArgs e)
        {
            Response.Redirect("Add_Edit.aspx?ID="+Common.EncryptUrl(e.CommandArgument.ToString()));
        }

        protected void btnDelete_Command(object sender, CommandEventArgs e)
        {
            BLL_Employee_Master bl = new BLL_Employee_Master(Guru.Get_ConnectionString, "", "");
            try
            {
                bl.DeleteFlag(e.CommandArgument.ToString());
                Load_Data();
                Common.Success_Msg(this, "Record Deleted Successfully");
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

        protected void btnPrint_Command(object sender, CommandEventArgs e)
        {
            string parameters = "Type=" + Common.EncryptUrl("Emp_Print") + "&OutputType=" + Common.EncryptUrl("PDF"); ;
            parameters += "&EMP_SYS_ID=" + Common.EncryptUrl(GuruConvert.AsString(e.CommandArgument));
            string PrintUrl = ResolveUrl("~/Report/Master_Report.aspx?" + parameters);
            Common.JavascriptFunc(this, " window.open('" + PrintUrl + "', 'popup_window', 'width=700,height=700,left=400,top=0,resizable=yes');");
        }

        protected void btnAddNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add_Edit.aspx");


        }
    }
}