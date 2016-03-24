using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GuruDal;
public class Grid
{
    public static void ChangeSortDirection(GridView gv, string OrderBy)
    {
        foreach (DataControlFieldHeaderCell headerCell in gv.HeaderRow.Cells)
        {
            int columnIndex = gv.HeaderRow.Cells.GetCellIndex(headerCell);
            if (GuruConvert.AsString(headerCell.ContainingField.SortExpression).ToUpper() == OrderBy.ToUpper())
            {
                if (gv.HeaderRow.Cells[columnIndex].CssClass == "sorting_asc")
                {
                    gv.HeaderRow.Cells[columnIndex].CssClass = "sorting_desc";
                }
                else
                {
                    gv.HeaderRow.Cells[columnIndex].CssClass = "sorting_asc";
                }
            }
            else
            {
                gv.HeaderRow.Cells[columnIndex].CssClass = "sorting";
            }
        }
    }

    public static void SetSortDirection(GridView gv, string OrderBy, string OrderType)
    {
        foreach (DataControlFieldHeaderCell headerCell in gv.HeaderRow.Cells)
        {
            int columnIndex = gv.HeaderRow.Cells.GetCellIndex(headerCell);
            if (GuruConvert.AsString(headerCell.ContainingField.SortExpression).ToUpper() == OrderBy.ToUpper())
            {
                if (OrderType.ToUpper() == "ASC")
                {
                    gv.HeaderRow.Cells[columnIndex].CssClass = "sorting_asc";
                }
                else
                {
                    gv.HeaderRow.Cells[columnIndex].CssClass = "sorting_desc";
                }
            }
            else
            {
                if (GuruConvert.AsString(headerCell.ContainingField.SortExpression) != "")
                    gv.HeaderRow.Cells[columnIndex].CssClass = "sorting";
            }
        }
    }

    public static string GetSortExpression(GridView gv, string defaulSortExpression)
    {
        try
        {
            foreach (DataControlFieldHeaderCell headercell in gv.HeaderRow.Cells)
            {
                if (headercell.CssClass.ToString() == "sorting_desc")
                {
                    return headercell.ContainingField.SortExpression;
                }
                else if (headercell.CssClass.ToString() == "sorting_asc")
                {
                    return headercell.ContainingField.SortExpression;
                }
            }
            return defaulSortExpression;
        }
        catch
        {
            return defaulSortExpression;
        }
    }

    public static string GetSortDirection(GridView gv, string DefaultDirection = "ASC")
    {
        try
        {
            foreach (DataControlFieldHeaderCell headercell in gv.HeaderRow.Cells)
            {
                if (headercell.CssClass.ToString() == "sorting_desc")
                {
                    return "DESC";
                }
                else if (headercell.CssClass.ToString() == "sorting_asc")
                {
                    return "ASC";
                }
            }
            return "DESC";
        }
        catch
        {
            return DefaultDirection;
        }
    }
}

public class CreateItemTemplate : ITemplate
{
    //Field to store the ListItemType value
    private ListItemType myListItemType;
    public string _colname;
    public string _colno;
    //private string _label_name;
    public CreateItemTemplate()
    {
        //
        // TODO: Add default constructor logic here
        //
    }

    //Parameterrised constructor
    public CreateItemTemplate(ListItemType Item, string colno, string colname)
    {
        myListItemType = Item;
        _colno = colno;
        _colname = colname;
    }

    //Overwrite the InstantiateIn() function of the ITemplate interface.
    public void InstantiateIn(System.Web.UI.Control container)
    {
        //Code to create the ItemTemplate and its field.
        if (myListItemType == ListItemType.Item)
        {
            //if (!_colname.Contains("WEEKNO"))
            //{
            //    Label lbl = new Label();
            //    lbl.ID = "lbl" + _colname;
            //    //lbl.DataBinding += new EventHandler(txtWeekPrice_DataBinding);
            //    container.Controls.Add(lbl);
        }
    }

    /// <summary>
    /// This is the event, which will be raised when the binding happens.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void txtWeekPrice_DataBinding(object sender, EventArgs e)
    {
        TextBox txtdata = (TextBox)sender;
        GridViewRow container = (GridViewRow)txtdata.NamingContainer;
        object dataValue = DataBinder.Eval(container.DataItem, "WEEKNO_" + _colno);
        if (dataValue != DBNull.Value)
        {
            txtdata.Text = dataValue.ToString();
        }
    }

    ///// <summary>
    ///// This is the event, which will be raised when the binding happens.
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //void txtabel_DataBinding(object sender, EventArgs e)
    //{
    //    TextBox txtdata = (TextBox)sender;
    //    GridViewRow container = (GridViewRow)txtdata.NamingContainer;
    //    object dataValue = DataBinder.Eval(container.DataItem, "WEEKNO_" + _colno);
    //    if (dataValue != DBNull.Value)
    //    {
    //        txtdata.Text = dataValue.ToString();
    //    }
    //}

    /// <summary>
    /// This is the event, which will be raised when the binding happens.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void hfkeyfied_DataBinding(object sender, EventArgs e)
    {
        HiddenField txtdata = (HiddenField)sender;
        GridViewRow container = (GridViewRow)txtdata.NamingContainer;
        object dataValue = DataBinder.Eval(container.DataItem, "SYS_ID_" + _colno);
        if (dataValue != DBNull.Value)
        {
            txtdata.Value = dataValue.ToString();
        }
    }

    /// <summary>
    /// This is the event, which will be raised when the binding happens.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void hfversion_DataBinding(object sender, EventArgs e)
    {
        HiddenField txtdata = (HiddenField)sender;
        GridViewRow container = (GridViewRow)txtdata.NamingContainer;
        object dataValue = DataBinder.Eval(container.DataItem, "VERSION_NO_" + _colno);
        if (dataValue != DBNull.Value)
        {
            txtdata.Value = dataValue.ToString();
        }
    }

    /// <summary>
    /// This is the event, which will be raised when the binding happens.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void hfyear_DataBinding(object sender, EventArgs e)
    {
        HiddenField txtdata = (HiddenField)sender;
        GridViewRow container = (GridViewRow)txtdata.NamingContainer;
        object dataValue = DataBinder.Eval(container.DataItem, "YEAR_" + _colno);
        if (dataValue != DBNull.Value)
        {
            txtdata.Value = dataValue.ToString();
        }
    }

    /// <summary>
    /// This is the event, which will be raised when the binding happens.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void hfmonth_DataBinding(object sender, EventArgs e)
    {
        HiddenField txtdata = (HiddenField)sender;
        GridViewRow container = (GridViewRow)txtdata.NamingContainer;
        object dataValue = DataBinder.Eval(container.DataItem, "MONTH_" + _colno);
        if (dataValue != DBNull.Value)
        {
            txtdata.Value = dataValue.ToString();
        }
    }
}