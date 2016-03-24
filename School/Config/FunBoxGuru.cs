using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.IO;
using System.Configuration;
using GuruDal;
using System.Text.RegularExpressions;
using System.Data;
using System.Web.Security;
using System.Text;

public class FunBoxGuru
{
    #region Messagebox
    /// <summary>
    /// Show Information MessageBox On Your Top Side of Your In Blue Color Web Page
    /// </summary>
    /// <param name="WebPage">Name Of The WebPage</param>
    /// <param name="ex">This Message Is From Guru</param>
    public static void Information(System.Web.UI.Page webPage, string message)
    {
        string title = string.Format("\"{0}\"", "Information");
        message = SplitMessage(message);
        string msg = string.Format("\"{0}\"", message);
        string color = string.Format("\"{0}\"", "#00a9ec");
        string image = string.Format("\"{0}\"", "../../assets/MetroNotification/img/MessageBox/Information.png");
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script language='javascript'>");
        sb.Append(@"ShowInformation('" + message + "')");
        sb.Append(@"</script>");
        ScriptManager.RegisterStartupScript(webPage, webPage.GetType(), "Info", sb.ToString(), false);
    }

    /// <summary>
    /// Show Error MessageBox On Your Top Side of Your In Red Color Web Page
    /// </summary>
    /// <param name="WebPage">Name Of The WebPage</param>
    /// <param name="ex">This Message Is From Guru</param>
    public static void Error(System.Web.UI.Page webPage, String ex)
    {
        ex = SplitMessage(ex);
        string message = string.Format("\"{0}\"", ex);
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script language='javascript'>");
        sb.Append(@"ShowError('" + message + "')");
        sb.Append(@"</script>");
        ScriptManager.RegisterStartupScript(webPage, webPage.GetType(), "Info", sb.ToString(), false);
    }

    /// <summary>
    /// Show Alert MessageBox On Your Top Side of Your In Orange Color Web Page
    /// </summary>
    /// <param name="WebPage">Name Of The WebPage</param>
    /// <param name="Message">This Message Is From Guru</param>
    public static void Alert(System.Web.UI.Page webPage, String message)
    {
        string title = string.Format("\"{0}\"", "Alert");
        message = SplitMessage(message);
        string msg = string.Format("\"{0}\"", message);
        string color = string.Format("\"{0}\"", "#ef9c00");
        string image = string.Format("\"{0}\"", "../../assets/MetroNotification/img/MessageBox/Alert.png");
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script language='javascript'>");
        sb.Append(@"ShowAlert('" + message + "')");
        sb.Append(@"</script>");
        ScriptManager.RegisterStartupScript(webPage, webPage.GetType(), "Info", sb.ToString(), false);
    }

    /// <summary>
    /// Show Success MessageBox On Your Top Side of Your In Green Color Web Page
    /// </summary>
    /// <param name="WebPage">Name Of The WebPage</param>
    /// <param name="Message">This Message Is From Guru</param>
    public static void Success(System.Web.UI.Page webPage, String msg)
    {

        string title = string.Format("\"{0}\"", "Success");
        msg = SplitMessage(msg);
        string message = string.Format("\"{0}\"", msg);
        string color = string.Format("\"{0}\"", "#009f3c");
        string image = string.Format("\"{0}\"", "../../assets/MetroNotification/img/MessageBox/Success.png");
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script language='javascript'>");
        sb.Append(@"ShowSuccess('" + message + "')");
        sb.Append(@"</script>");
        ScriptManager.RegisterStartupScript(webPage, webPage.GetType(), "Info", sb.ToString(), false);
    }

    public static void successbox(System.Web.UI.Page webPage, string msg)
    {
        string title = string.Format("\"{0}\"", "Success");
        msg = SplitMessage(msg);
        string message = string.Format("\"{0}\"", msg);
        string color = string.Format("\"{0}\"", "#009f3c");
        string image = string.Format("\"{0}\"", "../../assets/MetroNotification/img/MessageBox/Success.png");
        System.Text.StringBuilder sb = new System.Text.StringBuilder();
        sb.Append(@"<script language='javascript'>");
        sb.Append(@"ShowSuccess('" + message + "')");
        sb.Append(@"</script>");
        ScriptManager.RegisterStartupScript(webPage, webPage.GetType(), "Info", sb.ToString(), false);
    }

    public static String SplitMessage(string message)
    {
        return message.Replace("\"", string.Empty).Replace("'", string.Empty).Replace("\r\n", "<br />").
            Replace(System.Environment.NewLine, "<br />").Replace("\n", "<br />").Replace("\r", "<br />");
    }
    #endregion

    public static string GetLoginLog()
    {
        return GuruConvert.AsString(HttpContext.Current.Session["LOGIN_LOG_SYS_ID"].ToString());
    }
    public static string GetDisplayName()
    {
        return GuruConvert.AsString(HttpContext.Current.Session["DISPLAY_NAME"].ToString());
    }
    public static string GetRoleId()
    {
        return GuruConvert.AsString(HttpContext.Current.Session["ROLE_SYS_ID"].ToString());
    }
    public static string GetUserId()
    {
        return GuruConvert.AsString(HttpContext.Current.Session["USER_SYS_ID"].ToString());
    }
    public static Boolean CheckisValidLogin()
    {
        return GuruConvert.AsBoolean(HttpContext.Current.Session["isValid"].ToString());
    }

    #region Get Web.Config Settings UploadPath/ConnectionString
    /// <summary>
    /// Get Upload Path From Web.Config
    /// </summary>
    /// <returns>Upload Path</returns>
    public static string GetUploadPath()
    {
        return "~/Uploads/QuestionBank/";
    }
    /// <summary>
    /// Get DB Connection String From Web.Config
    /// </summary>
    /// <returns>DB Connection String</returns>
    public static string connectionstring()
    {
        return ConfigurationManager.ConnectionStrings["GuruConnectionString"].ConnectionString;
    }
    #endregion

    #region Common Functionalites Which is Used All Pages
    /// <summary>
    /// Get STATUS_SYS_ID from Dropdown list
    /// </summary>
    /// <param name="ddlStatus">DropDown Name Where to Status ID</param>
    /// <param name="StatusName">Name of The Status</param>
    /// <returns>STATUS_SYS_ID</returns>
    public static string GetStatusIDfromDropDown(DropDownList ddlStatus, string StatusName)
    {
        DataTable dt = (DataTable)ddlStatus.DataSource;
        foreach (ListItem li in ddlStatus.Items)
        {
            if (GuruConvert.AsString(li.Text).ToUpper() == StatusName.ToUpper())
            {
                return GuruConvert.AsString(li.Value);
            }
        }
        return "";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="grv"></param>
    /// <param name="isShowSysID"></param>
    /// <returns></returns>
    public static DataTable GetSearchByColumns(GridView grv, bool isShowSysID = false)
    {
        DataTable dtCols = new DataTable();
        dtCols.Columns.Add("ColumnName", typeof(string));
        dtCols.Columns.Add("DisplayName", typeof(string));

        for (int i = 0; i < grv.Columns.Count; i++)
        {
            DataControlField field = grv.Columns[i];
            if (field.GetType().Name != "BoundField")
                continue;

            BoundField bfield = field as BoundField;
            string ColumnName = bfield.DataField;
            string DisplayName = bfield.HeaderText;
            string Css_Style = bfield.ItemStyle.CssClass.ToString();

            if (ColumnName.ToUpper() == "SYS_ID" && isShowSysID == false)
                continue;

            if (ColumnName.ToUpper() == "SNO" || ColumnName.ToUpper() == "VERSION_NO" || ColumnName.ToUpper() == "STATUS_SYS_ID" || Css_Style == "NO_SEARCH")
                continue;

            dtCols.Rows.Add(ColumnName, DisplayName);
        }

        return dtCols;
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="ddl"></param>
    /// <param name="Value"></param>
    public static void SetSelectedValue(DropDownList ddl, string Value)
    {
        try
        {
            ddl.SelectedValue = Value;
        }
        catch
        {
            if (ddl.DataSource != null)
                ddl.SelectedIndex = -1;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="colname"></param>
    /// <returns></returns>
    public static string GetSearchBy(string colname)
    {
        if (colname.ToUpper() == "STATUS")
        {
            return "STATUS_SYS_ID";
        }
        else
        {
            return colname;
        }
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public static DataTable ReadCSV(string fileName)
    {
        DataTable csvDataTable = new DataTable();
        try
        {
            //no try/catch - add these in yourselfs or let exception happen
            String[] csvData = System.IO.File.ReadAllLines(fileName);

            //if no data
            if (csvData.Length == 0)
            {
                return csvDataTable;
            }

            String[] headings = csvData[0].Split(',');

            //for each heading
            for (int i = 0; i < headings.Length; i++)
            {
                ////replace spaces with underscores for column names
                //headings[i] = headings[i].Replace(" ", "_");

                //add a column for each heading
                csvDataTable.Columns.Add(headings[i]);

            }

            //populate the DataTable
            for (int i = 1; i < csvData.Length; i++)
            {
                //create new rows
                DataRow row = csvDataTable.NewRow();

                for (int j = 0; j < headings.Length; j++)
                {
                    string[] SplitData = SplitString(csvData[i]);

                    //fill them
                    row[j] = SplitData[j];
                }

                //add rows to over DataTable
                csvDataTable.Rows.Add(row);
            }

            return csvDataTable;
        }
        catch
        {
            throw;
        }
        //return the CSV DataTable
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="inputString"></param>
    /// <returns></returns>
    private static string[] SplitString(string inputString)
    {
        System.Text.RegularExpressions.RegexOptions options = ((System.Text.RegularExpressions.RegexOptions.IgnorePatternWhitespace | System.Text.RegularExpressions.RegexOptions.Multiline)
                    | System.Text.RegularExpressions.RegexOptions.IgnoreCase);
        Regex reg = new Regex("(?:^|,)(\\\"(?:[^\\\"]+|\\\"\\\")*\\\"|[^,]*)", options);
        MatchCollection coll = reg.Matches(inputString);
        string[] items = new string[coll.Count];
        int i = 0;
        foreach (Match m in coll)
        {
            items[i++] = m.Groups[0].Value.Trim('"').Trim(',').Trim('"').Trim();
        }
        return items;
    }
    #endregion

    #region Password Encryption and Decryption
    static readonly string PasswordHash = "ASDASD";
    static readonly string SaltKey = "ASDASD";
    static readonly string VIKey = "ASDASDS";
    /// <summary>
    /// Encrypt the Passwords
    /// </summary>
    /// <param name="Password"></param>
    /// <returns></returns>
    public static string EncryptPassword(string Password)
    {
        byte[] plainTextBytes = Encoding.UTF8.GetBytes(Password);

        byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
        var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
        var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));

        byte[] cipherTextBytes;

        using (var memoryStream = new MemoryStream())
        {
            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                cipherTextBytes = memoryStream.ToArray();
                cryptoStream.Close();
            }
            memoryStream.Close();
        }
        return Convert.ToBase64String(cipherTextBytes);
    }

    /// <summary>
    /// Decrypt the Password
    /// </summary>
    /// <param name="Password"></param>
    /// <returns></returns>
    public static string DecryptPassword(string Password)
    {
        byte[] cipherTextBytes = Convert.FromBase64String(Password);
        byte[] keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
        var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

        var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(VIKey));
        var memoryStream = new MemoryStream(cipherTextBytes);
        var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
        byte[] plainTextBytes = new byte[cipherTextBytes.Length];

        int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
        memoryStream.Close();
        cryptoStream.Close();
        return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
    }
    #endregion
}