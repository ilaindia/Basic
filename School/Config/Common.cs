using System;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GuruDal;

namespace School.Config
{
    public class Usr
    {
        public static string SysId => GuruConvert.AsString(HttpContext.Current.Session["USR_SYS_ID"]);
        public static string Name => GuruConvert.AsString(HttpContext.Current.Session["USR_NAME"]);
        public static string Img => GuruConvert.AsString(HttpContext.Current.Session["USR_IMG"]);
        public static bool IsAuthedicate => GuruConvert.AsBoolean(HttpContext.Current.Session["isAuthedicate"]);
    }
    public class Company
    {
        public static string SysId => GuruConvert.AsString(HttpContext.Current.Session["CMPNY_SYS_ID"]);
        public static string Name => GuruConvert.AsString(HttpContext.Current.Session["CMPNY_NAME"]);
        public static string Img => GuruConvert.AsString(HttpContext.Current.Session["CMPNY_IMG"]);
    }
    public class Common
    {
        public static string UploadPath => "/App_Upload/";

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
        }
        public static void Error_Msg(Control ctrl, string msg)
        {
            msg = msg.Replace("'", "");
            Regex regx = new Regex(@"\r\n|\r|\n+");
            msg = regx.Replace(msg, "<br/>");
            ScriptManager.RegisterStartupScript(ctrl, typeof(Page), Guid.NewGuid().ToString(), "Error_Msg('" + msg + "');", true);
        }
        public static void Datepicker(Control ctrl)
        {
            ScriptManager.RegisterStartupScript(ctrl, typeof(Page), Guid.NewGuid().ToString(), "Datepicker();", true);
        }

        public static void JavascriptFunc(Control ctrl, string functionality)
        {
            ScriptManager.RegisterStartupScript(ctrl, typeof(Page), Guid.NewGuid().ToString(), functionality, true);
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
        }

        public static void Dropdown_Template(Control ctrl)
        {
            ScriptManager.RegisterStartupScript(ctrl, typeof(Page), Guid.NewGuid().ToString(), "Dropdown_Template();", true);
        }
        #endregion

        #region Password Encryption and Decryption
        //static readonly string PasswordHash = "Guru_passwordhash";
        //static readonly string SaltKey = "Guru_saltkey";
        //static readonly string VIKey = "Guru_vikey";
        /// <summary>
        /// Encrypt the Passwords
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string EncryptPassword(string password)
        {
            string encryptionKey = "PODAPARATHESI";
            byte[] clearBytes = Encoding.Unicode.GetBytes(password);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                if (encryptor != null)
                {
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        password = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            return password;
        }

        /// <summary>
        /// Decrypt the Password
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string DecryptPassword(string password)
        {
            string encryptionKey = "PODAPARATHESI";
            byte[] cipherBytes = Convert.FromBase64String(password);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                if (encryptor != null)
                {
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        password = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            return password;
        }

        public static string EncryptUrl(string urlParameters)
        {
            string encryptionKey = "PODAPARATHESI";
            byte[] clearBytes = Encoding.Unicode.GetBytes(urlParameters);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                if (encryptor != null)
                {
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }
                        urlParameters = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            return urlParameters.Replace("+", "__");
        }

        public static string DecryptUrl(string urlParameters)
        {
            string encryptionKey = "PODAPARATHESI";
            urlParameters = urlParameters.Replace("__", "+");
            byte[] cipherBytes = Convert.FromBase64String(urlParameters);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(encryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                if (encryptor != null)
                {
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }
                        urlParameters = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            return urlParameters;
        }
        #endregion
        public static string CheckImgPath(string logoPath, string defaultPath)
        {
            Page pg = new Page();
            return (File.Exists(pg.Server.MapPath(logoPath))) ? logoPath : defaultPath;
        }

        public static string UploadImg(FileUpload fuImage, string uploadPath)
        {

            string filename = $"{DateTime.Now:yyMMddHHmmssms}" + "_" + fuImage.FileName;

            if (!Directory.Exists(HttpContext.Current.Server.MapPath(Path.Combine(uploadPath))))
            {
                Directory.CreateDirectory(HttpContext.Current.Server.MapPath(Path.Combine(uploadPath)));
            }
            fuImage.PostedFile.SaveAs(HttpContext.Current.Server.MapPath(Path.Combine(uploadPath)) + "/" + filename);
            Page pg = new Page();
            return pg.ResolveUrl(uploadPath + "/" + filename);
        }
    }
}