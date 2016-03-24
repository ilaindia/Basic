// -----------------------------------------------------------------------
// <copyright file="GuruConvert.cs" company="Guru Tech">
// TODO: This Code File Has Belongs To Guru Tech
// </copyright>
// -----------------------------------------------------------------------
namespace GuruDal
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    /// <summary>
    /// Basic operations like Converting, First Letter Caps in a string, Get the first day and Last day of month.
    /// </summary>
    public class GuruConvert
    {
        /// <summary>
        /// Converts the object value into decimal value
        /// </summary>
        /// <param name="obj">Any object value</param>
        /// <returns>Decimal value</returns>
        public static decimal AsDecimal(object obj)
        {
            try
            {
                if (obj == null)
                {
                    return 0;
                }
                else if (obj.ToString().Trim() != string.Empty)
                {
                    return Convert.ToDecimal(obj.ToString().Replace(",", ""));
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Converts the object value into Integer.
        /// </summary>
        /// <param name="obj">Any object value</param>
        /// <returns>Integer value</returns>
        public static int AsInt(object obj)
        {
            try
            {
                if (obj == null)
                {
                    return 0;
                }
                else if (obj.ToString().Trim() != string.Empty)
                {
                    return Convert.ToInt32(obj.ToString().Replace(",", ""));
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Converts the object value into Integer.
        /// </summary>
        /// <param name="obj">Any object value</param>
        /// <returns>Integer value</returns>
        public static Int64 AsInt64(object obj)
        {
            try
            {
                if (obj == null)
                {
                    return 0;
                }
                else if (obj.ToString().Trim() != string.Empty)
                {
                    return Convert.ToInt64(obj.ToString());
                }
                else
                {
                    return 0;
                }
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Converts the object value into string.
        /// </summary>
        /// <param name="obj">null, Hello World</param>
        /// <returns>string.Empty, Hello World</returns>
        public static string AsString(object obj)
        {
            try
            {
                if (obj == null)
                {
                    return string.Empty;
                }
                else
                {
                    return Convert.ToString(obj).Trim();
                }
            }
            catch
            {
                return "";
            }
        }

        /// <summary>
        /// Converts the object value into string.
        /// </summary>
        /// <param name="obj">null, Hello World</param>
        /// <returns>string.Empty, Hello World</returns>
        public static string AsStringNull(object obj)
        {
            try
            {
                if (obj == null)
                {
                    return "NULL";
                }
                else if (obj.ToString().Trim() == "")
                {
                    return "NULL";
                }
                else
                {
                    return Convert.ToString(obj).Trim();
                }
            }
            catch
            {
                return "NULL";
            }
        }

        /// <summary>
        /// Converts the object value into boolean data type.
        /// </summary>
        /// <param name="obj">1, 0, Y, N, YES, NO</param>
        /// <returns>true, false, true, false, true, false, true, false</returns>
        public static bool AsBoolean(object obj)
        {
            try
            {
                return Convert.ToBoolean(obj);
            }
            catch
            {
                if (obj == null)
                {
                    return false;
                }

                string objStr = obj.ToString().ToUpper();
                if (objStr == "TRUE")
                {
                    return true;
                }
                else if (objStr == "FALSE")
                {
                    return false;
                }
                else if (objStr == "1")
                {
                    return true;
                }
                else if (objStr == "0")
                {
                    return false;
                }
                else if (objStr == "Y")
                {
                    return true;
                }
                else if (objStr == "N")
                {
                    return false;
                }
                else if (objStr == "YES")
                {
                    return true;
                }
                else
                    return (objStr == "NO") ? false : false;
            }
        }

        /// <summary>
        /// Get the default date format for whole application
        /// </summary>
        /// <returns></returns>
        public static string GetDateFormat()
        {
            return "dd-MM-yyyy";
        }

        /// <summary>
        /// Converts the string into date and format it
        /// </summary>
        /// <param name="value">date value as string</param>
        /// <returns>formatted date value</returns>
        public static string GetDateDisplay(string value)
        {
            return string.Format("{0:" + GetDateFormat() + "}", Convert.ToDateTime(value));
        }

        /// <summary>
        /// Get the default datetime format for whole application
        /// </summary>
        /// <returns></returns>
        public static string GetDateTimeFormat()
        {
            return "dd-MM-yyyy";
        }

        /// <summary>
        /// Converts the string into datetime and format it 
        /// </summary>
        /// <param name="value">datetime value as string</param>
        /// <returns>formatted datetime value</returns>
        public static string AsDateTimeDisplay(string value)
        {
            return string.Format("{0:" + GetDateTimeFormat() + "}", Convert.ToDateTime(value));
        }

        /// <summary>
        /// Converts the string into database datetime formate
        /// </summary>
        /// <param name="value">date value as string</param>
        /// <returns>formatted datetime value for database</returns>
        public static string AsDateDB(string value)
        {
            DateTime dtm = new DateTime();
            if (value.Length > 10)
                dtm = DateTime.ParseExact(value, GetDateTimeFormat(), CultureInfo.InvariantCulture);
            else
                dtm = DateTime.ParseExact(value, GetDateFormat(), CultureInfo.InvariantCulture);

            return string.Format("{0:yyyy-MM-dd HH:mm:ss:ms}", dtm);
        }

        /// <summary>
        /// Convert the object into Date and Time.
        /// </summary>
        /// <param name="obj">any object value</param>
        /// <returns>Date and Time</returns>
        public static DateTime AsDate(object obj)
        {
            DateTime dtm = new DateTime();
            try
            {
                return Convert.ToDateTime(obj);
            }
            catch
            {
                return dtm;
            }
        }

        /// <summary>
        /// Returns the string with first letter caps in each word
        /// </summary>
        /// <param name="str">hello world</param>
        /// <returns>Hello World</returns>
        public static string AsFirstLetterCaps(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }

        public static Object JsonToObject(string Json, Type typ)
        {
            System.IO.StringReader sr = new System.IO.StringReader(Json);
            Newtonsoft.Json.JsonTextReader reader = new Newtonsoft.Json.JsonTextReader(sr);
            try
            {
                Newtonsoft.Json.JsonSerializer json = new Newtonsoft.Json.JsonSerializer();
                json.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
                json.ObjectCreationHandling = Newtonsoft.Json.ObjectCreationHandling.Replace;
                json.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
                json.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                return json.Deserialize(reader, typ);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                reader.Close();
            }
        }

        public static void ErrorLog(Exception ex, string Folder)
        {
            StreamWriter sw = null;
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\App_Log\\" + Folder + "\\" + DateTime.Now.ToString("dd-MM-yy");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                sw = new StreamWriter(path + "\\App_Log.txt", true);
                sw.WriteLine(GuruConvert.AsDateTimeDisplay(DateTime.Now.ToString("dd-MM-yyyy")) + ": " + GuruConvert.AsString(ex.Message));
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }
        public static void ErrorLog(string Message, string Folder)
        {
            StreamWriter sw = null;
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\App_Log\\" + Folder + "\\" + DateTime.Now.ToString("dd-MM-yy");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                sw = new StreamWriter(path + "\\App_Log.txt", true);
                sw.WriteLine(GuruConvert.AsDateTimeDisplay(DateTime.Now.ToString("dd-MM-yyyy")) + ": " + GuruConvert.AsString(Message));
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }
    }
}
