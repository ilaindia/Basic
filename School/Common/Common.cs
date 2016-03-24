using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Net;
public class Common
{
    #region Register JQuery Messagebox/GridScrollBar/Date&Time Picker/RadioButton Scripts on the Page
    /// <summary>
    /// Show Jquery Success Message Box
    /// </summary>
    /// <param name="ctrl">ctrl as Page Name Were Message Box Wants to Show</param>
    /// <param name="msg">Message as String Which is Display in Messagebox</param>
    public static void Success_Msg(Control ctrl, string msg)
    {
        msg = msg.Replace("'", "");
        Regex regx = new Regex(@"\r\n|\r|\n+");
        msg = regx.Replace(msg, "<br/>");
        ScriptManager.RegisterStartupScript(ctrl, typeof(Page), Guid.NewGuid().ToString(), "Success_Msg('" + msg + "');", true);
        return;
    }

    /// <summary>
    /// Show Jquery Error Message Box
    /// </summary>
    /// <param name="ctrl">ctrl as Page Name Were Message Box Wants to Show</param>
    /// <param name="ex">ex as Exception Which Error Message was Display in Messagebox</param>
    public static void Error_Msg(Control ctrl, Exception ex)
    {
        String msg = ex.Message.Replace("'", "");
        Regex regx = new Regex(@"\r\n|\r|\n+");
        msg = regx.Replace(msg, "<br/>");
        ScriptManager.RegisterStartupScript(ctrl, typeof(Page), Guid.NewGuid().ToString(), "Error_Msg('" + msg + "');", true);
        return;
    }
    public static void Error_Msg(Control ctrl, string msg)
    {
        msg = msg.Replace("'", "");
        Regex regx = new Regex(@"\r\n|\r|\n+");
        msg = regx.Replace(msg, "<br/>");
        ScriptManager.RegisterStartupScript(ctrl, typeof(Page), Guid.NewGuid().ToString(), "Error_Msg('" + msg + "');", true);
        return;
    }
    public static void Datepicker(Control ctrl)
    {
        ScriptManager.RegisterStartupScript(ctrl, typeof(Page), Guid.NewGuid().ToString(), "Datepicker();", true);
        return;
    }

    public static void JavascriptFunc(Control ctrl, string Functionality)
    {
        ScriptManager.RegisterStartupScript(ctrl, typeof(Page), Guid.NewGuid().ToString(), Functionality, true);
        return;
    }

    /// <summary>
    /// Show Jquery Worning Message Box
    /// </summary>
    /// <param name="ctrl">ctrl as Page Name Were Message Box Wants to Show</param>
    /// <param name="ex">ex as String Which is Display in Messagebox</param>
    public static void Warning_Msg(Control ctrl, string ex)
    {
        String msg = ex.Replace("'", "");
        Regex regx = new Regex(@"\r\n|\r|\n+");
        msg = regx.Replace(msg, "<br/>");
        ScriptManager.RegisterStartupScript(ctrl, typeof(Page), Guid.NewGuid().ToString(), "Warning_Msg('" + msg + "');", true);
        return;
    }

    public static void Dropdown_Template(Control ctrl)
    {
        ScriptManager.RegisterStartupScript(ctrl, typeof(Page), Guid.NewGuid().ToString(), "Dropdown_Template();", true);
        return;
    }
    #endregion

}