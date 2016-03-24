// -----------------------------------------------------------------------
// <copyright file="GuruConvert.cs" Author="Prabakaran">
// TODO: This Code File Has Belongs To Prabakaran
// </copyright>
// -----------------------------------------------------------------------

using System.Configuration;
using System.Globalization;

namespace GuruDal
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Xml;
    using NCalc;
    public class GuruConvert
    {
        #region Numeric Operations
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
                    return decimal.Round(Convert.ToDecimal(obj.ToString().Replace(",", "")), 2, MidpointRounding.AwayFromZero);
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
        #endregion

        #region String Operations
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
        /// Returns the string with first letter caps in each word
        /// </summary>
        /// <param name="str">hello world</param>
        /// <returns>Hello World</returns>
        public static string AsFirstLetterCaps(string str)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(str);
        }
        #endregion

        #region Date & Time Operations
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
        /// Converts the string into date and format it
        /// </summary>
        /// <param name="value">date value as string</param>
        /// <returns>formatted date value</returns>
        public static string AsDateDisplay(string value)
        {
            return string.Format("{0:" + Guru.GetDateFormat + "}", Convert.ToDateTime(value));
        }
        /// <summary>
        /// Converts the string into datetime and format it 
        /// </summary>
        /// <param name="value">datetime value as string</param>
        /// <returns>formatted datetime value</returns>
        public static string AsDateTimeDisplay(string value)
        {
            return string.Format("{0:" + Guru.GetDateTimeFormat + "}", Convert.ToDateTime(value));
        }
        /// <summary>
        /// Converts the string into database date-time formate
        /// </summary>
        /// <param name="value">date value as string</param>
        /// <returns>formatted date-time value for database</returns>
        public static string AsDateDB(string value)
        {
            try
            {
                DateTime dtm = new DateTime();
                if (value.Length > 10)
                    dtm = DateTime.ParseExact(value, Guru.GetDateTimeFormat, CultureInfo.InvariantCulture);
                else
                    dtm = DateTime.ParseExact(value, Guru.GetDateFormat, CultureInfo.InvariantCulture);

                return string.Format("{0:" + Guru.GetDbDateFormat + "}", dtm);
            }
            catch (Exception)
            {
                return null;
            }
        }
        #endregion

        #region Json Operations
        /// <summary>
        /// Convert Json Data To Specified Type
        /// </summary>
        /// <param name="Json">Json String</param>
        /// <param name="typ">Type to be Convert Json String</param>
        /// <returns></returns>
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
        #endregion

        #region Boolean Operation

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
        #endregion

        #region Currency Operations
        /// <summary>
        /// Convert Amount Value In Words
        /// </summary>
        /// <param name="Amount">Amount In Numbers</param>
        /// <returns></returns>
        public static string AsCurrencytoWord(decimal Amount)
        {
            GuruConvert Gc = new GuruConvert();
            return Gc._CurrencytoWord(Amount);
        }
        #endregion

        #region Private Properties For Currency To Word Conversion
        private string ConvertTens(string MyTens)
        {
            string Result = string.Empty;
            //  Is value between 10 and 19?
            if ((AsInt(MyTens.Substring(0, 1)) == 1))
            {
                switch (AsInt(MyTens))
                {
                    case 10:
                        Result = "Ten";
                        break;
                    case 11:
                        Result = "Eleven";
                        break;
                    case 12:
                        Result = "Twelve";
                        break;
                    case 13:
                        Result = "Thirteen";
                        break;
                    case 14:
                        Result = "Fourteen";
                        break;
                    case 15:
                        Result = "Fifteen";
                        break;
                    case 16:
                        Result = "Sixteen";
                        break;
                    case 17:
                        Result = "Seventeen";
                        break;
                    case 18:
                        Result = "Eighteen";
                        break;
                    case 19:
                        Result = "Nineteen";
                        break;
                }
            }
            else
            {
                //  .. otherwise it's between 20 and 99.
                switch (AsInt(MyTens.Substring(0, 1)))
                {
                    case 2:
                        Result = "Twenty ";
                        break;
                    case 3:
                        Result = "Thirty ";
                        break;
                    case 4:
                        Result = "Forty ";
                        break;
                    case 5:
                        Result = "Fifty ";
                        break;
                    case 6:
                        Result = "Sixty ";
                        break;
                    case 7:
                        Result = "Seventy ";
                        break;
                    case 8:
                        Result = "Eighty ";
                        break;
                    case 9:
                        Result = "Ninety ";
                        break;
                }

                Result = (Result + ConvertDigit(MyTens.Substring((MyTens.Length - 1))));
            }
            return Result;
        }
        private string ConvertDigit(string MyDigit)
        {
            string Result = string.Empty;
            switch (AsInt(MyDigit))
            {
                case 1:
                    Result = "One";
                    break;
                case 2:
                    Result = "Two";
                    break;
                case 3:
                    Result = "Three";
                    break;
                case 4:
                    Result = "Four";
                    break;
                case 5:
                    Result = "Five";
                    break;
                case 6:
                    Result = "Six";
                    break;
                case 7:
                    Result = "Seven";
                    break;
                case 8:
                    Result = "Eight";
                    break;
                case 9:
                    Result = "Nine";
                    break;
                default:
                    Result = "";
                    break;
            }
            return Result;
        }
        private string ConvertHundreds(string MyNumber)
        {
            string Result = string.Empty;
            //  Exit if there is nothing to convert.
            if ((AsInt(MyNumber) == 0))
            {
                return Result;
            }
            //  Append leading zeros to number.
            MyNumber = ("000" + MyNumber).Substring((("000" + MyNumber).Length - 3));
            //  Do we have a hundreds place digit to convert?
            if ((MyNumber.Substring(0, 1) != "0"))
            {
                Result = (ConvertDigit(MyNumber.Substring(0, 1)) + " Hundred ");
            }
            //  Do we have a tens place digit to convert?
            if ((MyNumber.Substring(1, 1) != "0"))
            {
                Result = (Result + ConvertTens(MyNumber.Substring(1)));
            }
            else
            {
                //  If not, then convert the ones place digit.
                Result = (Result + ConvertDigit(MyNumber.Substring(2)));
            }
            return Result.Trim();
        }
        private string _CurrencytoWord(decimal Amount)
        {
            string MyNumber = AsString(Amount);
            string Temp = string.Empty, Rupees = string.Empty, Paise = string.Empty, Word = string.Empty;
            int Count, DecimalPlace;
            string[] Place = new string[9];
            Place[2] = " Thousand ";
            Place[3] = " lakh ";
            Place[4] = " Crore ";
            MyNumber = AsString(MyNumber);
            //  Find decimal place.
            DecimalPlace = (MyNumber.IndexOf(".") + 1);
            //  If we find decimal place...
            if ((DecimalPlace > 0))
            {
                //  Convert Paise
                Temp = (MyNumber.Substring(DecimalPlace) + "00").Substring(0, 2);
                //  Hi! Note the above line Mid function it gives right portion
                //  after the decimal point
                // if only . and no numbers such as 789. accrues, mid returns nothing
                //  to avoid error we added 00
                //  Left function gives only left portion of the string with specified places here 2
                Paise = ConvertTens(Temp);
                //  Strip off paise from remainder to convert.
                MyNumber = MyNumber.Substring(0, (DecimalPlace - 1)).Trim();
            }
            Count = 1;
            if ((MyNumber != ""))
            {
                //  Convert last 3 digits of MyNumber to Indian Rupees.
                if (MyNumber.Length >= 3)
                {
                    Temp = MyNumber.Substring((MyNumber.Length - 3));
                    Temp = ConvertHundreds(MyNumber.Substring((MyNumber.Length - 3)));
                }
                else if (MyNumber.Length >= 2)
                {
                    Temp = MyNumber.Substring((MyNumber.Length - 2));
                    Temp = ConvertHundreds(MyNumber.Substring((MyNumber.Length - 2)));
                }
                else if (MyNumber.Length >= 1)
                {
                    Temp = MyNumber.Substring((MyNumber.Length - 1));
                    Temp = ConvertHundreds(MyNumber.Substring((MyNumber.Length - 1)));
                }
                if ((Temp != ""))
                {
                    Rupees = (Temp
                                + (Place[Count] + Rupees));
                }
                if ((MyNumber.Length > 3))
                {
                    //  Remove last 3 converted digits from MyNumber.
                    MyNumber = MyNumber.Substring(0, (MyNumber.Length - 3));
                }
                else
                {
                    MyNumber = "";
                }
            }
            //  convert last two digits to of mynumber
            Count = 2;
            while ((MyNumber != ""))
            {
                Temp = ConvertTens(("0" + MyNumber).Substring((("0" + MyNumber).Length - 2)));
                if ((Temp != ""))
                {
                    Rupees = (Temp
                                + (Place[Count] + Rupees));
                }
                if ((MyNumber.Length > 2))
                {
                    //  Remove last 2 converted digits from MyNumber.
                    MyNumber = MyNumber.Substring(0, (MyNumber.Length - 2));
                }
                else
                {
                    MyNumber = "";
                }
                Count = (Count + 1);
            }
            //  Clean up rupees.
            switch (Rupees)
            {
                case "":
                    Rupees = "";
                    break;
                case "One":
                    Rupees = "One Rupee";
                    break;
                default:
                    Rupees = (Rupees + " Rupees");
                    break;
            }
            //  Clean up paise.
            switch (Paise)
            {
                case "":
                    Paise = "";
                    break;
                case "One":
                    Paise = "One Paise";
                    break;
                default:
                    Paise = (Paise + " Paise");
                    break;
            }
            if ((Rupees == ""))
            {
                Word = Paise + " Only";
            }
            else if ((Paise == ""))
            {
                Word = Rupees + " Only";
            }
            else
            {
                Word = (Rupees + (" and " + Paise) + " Only");
            }
            return Word;
        }
        #endregion

        public static string FinanceYear(string Date)
        {
            int CurrentYear = Convert.ToDateTime(Date).Year;
            int PreviousYear = Convert.ToDateTime(Date).Year - 1;
            int NextYear = Convert.ToDateTime(Date).Year + 1;
            string PreYear = PreviousYear.ToString();
            string NexYear = NextYear.ToString();
            string CurYear = CurrentYear.ToString();
            string FinYear = null;

            if (DateTime.Today.Month > 3)
                FinYear = CurYear + "-" + NexYear;
            else
                FinYear = PreYear + "-" + CurYear;
            return FinYear.Trim();
        }
    }
    public class Guru
    {
        #region Date Operations And Configuration
        /// <summary>
        /// Get the default date format for whole application
        /// </summary>
        /// <returns></returns>
        public static string GetDbDateFormat => "yyyy-MM-dd hh:mm:ss tt";

        /// <summary>
        /// Get the default date format for whole application
        /// </summary>
        /// <returns></returns>
        public static string GetDateFormat => "dd-MM-yyyy";

        /// <summary>
        /// Get the default date-time format for whole application
        /// </summary>
        /// <returns></returns>
        public static string GetDateTimeFormat => "d/MM/yyyy hh:mm:ss";

        /// <summary>
        /// Get Current Date-Time from System Date-Time
        /// </summary>
        public static string GetDateTime => DateTime.Now.ToString(GetDateTimeFormat);

        /// <summary>
        /// Get Current Date from System Date
        /// </summary>
        public static string GetDate
        {
            get
            {
                return DateTime.Now.ToString(GetDateFormat);
            }
        }
        /// <summary>
        /// Get Current Date from System Date In Db Format
        /// </summary>
        public static string GetDbDateTime
        {
            get
            {
                return DateTime.Now.ToString(GetDbDateFormat);
            }
        }
        #endregion

        #region String Operations
        /// <summary>
        /// Remove special character from the string
        /// </summary>
        /// <param name="str">String to Remove</param>
        /// <returns>string</returns> 
        public static string RemoveSplChar(string str)
        {

            return Regex.Replace(str, @"[^0-9a-zA-Z]+", "");
        }
        /// <summary>
        /// Replace a char instead of new char
        /// </summary>
        /// <param name="str">string</param>
        /// <param name="ochar">old character</param>
        /// <param name="nchar">New Character</param>
        /// <returns>string</returns>
        public static string Replace(string str, string ochar, string nchar)
        {
            return str.Replace(ochar, nchar);
        }
        #endregion

        public static string GetCurrentFinanceYear
        {
            get
            {
                int CurrentYear = DateTime.Today.Year;
                int PreviousYear = DateTime.Today.Year - 1;
                int NextYear = DateTime.Today.Year + 1;
                string PreYear = PreviousYear.ToString();
                string NexYear = NextYear.ToString();
                string CurYear = CurrentYear.ToString();
                string FinYear = null;

                if (DateTime.Today.Month > 3)
                    FinYear = CurYear + "-" + NexYear;
                else
                    FinYear = PreYear + "-" + CurYear;
                return FinYear.Trim();
            }
        }

        public static string GetFinanceYear(DateTime dt)
        {

            int CurrentYear = dt.Year;
            int PreviousYear = dt.Year - 1;
            int NextYear = dt.Year + 1;
            string PreYear = PreviousYear.ToString();
            string NexYear = NextYear.ToString();
            string CurYear = CurrentYear.ToString();
            string FinYear = null;

            if (dt.Month > 3)
                FinYear = CurYear + "-" + NexYear;
            else
                FinYear = PreYear + "-" + CurYear;
            return FinYear.Trim();
        }



        public static void ErrorLog(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLog\\" + DateTime.Now.ToString("dd-MM-yy") + "\\" + DateTime.Now.ToString("hh tt");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                sw = new StreamWriter(path + "\\ErrorLog.txt", true);
                sw.WriteLine(GuruConvert.AsDateTimeDisplay(DateTime.Now.ToString()) + ": " + GuruConvert.AsString(ex.Source) + "; " + GuruConvert.AsString(ex.Message));
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }
        public static void ErrorLog(string Message)
        {
            StreamWriter sw = null;
            try
            {
                string path = AppDomain.CurrentDomain.BaseDirectory + "\\ErrorLog\\" + DateTime.Now.ToString("dd-MM-yy") + "\\" + DateTime.Now.ToString("hh tt");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                sw = new StreamWriter(path + "\\ErrorLog.txt", true);
                sw.WriteLine(GuruConvert.AsDateTimeDisplay(DateTime.Now.ToString()) + ": " + GuruConvert.AsString(Message));
                sw.Flush();
                sw.Close();
            }
            catch
            {
            }
        }

        public static string Get_ConnectionString { get { return GuruConvert.AsString(ConfigurationManager.ConnectionStrings["GuruConnectionString"].ConnectionString); } }
    }
    public class GuruValidate
    {
        #region Email Expression
        /// <summary>
        /// Email Expression That Accept Private & Public Domain Email Id's
        /// </summary>
        public static string EmailExp
        {
            get { return @"/^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$/"; }
        }
        /// <summary>
        /// Email Expression That Only Accept Private Email Id's
        /// </summary>
        public static string PrivateEmailExp
        {
            get
            {
                GuruValidate Gv = new GuruValidate();
                return @"/^([\w-\.]+@" + Gv._PrivateEmailList + @"([\w- ]+\.)+[\w-]{2,4})?$/";
            }
        }
        private string _PrivateEmailList
        {
            get
            {
                return @"(?!gmail.com)(?!yahoo.com)(?!hotmail.com)";
            }
        }
        #endregion

        #region Mobile Expression
        /// <summary>
        /// Mobile Expression without +91 or 0
        /// </summary>
        public static string MobileWithoutCountryCodeExp
        {
            get { return @"/^((\+){0,1}91(\s){0,1}(\-){0,1}(\s){0,1}){0,1}9[0-9](\s){0,1}(\-){0,1}(\s){0,1}[1-9]{1}[0-9]{7}$/"; }
        }

        /// <summary>
        /// Mobile Expression with or without +91 or 0
        /// </summary>
        public static string MobileWithCountryCodeExp
        {
            get { return @"/^((\\+91-?)|0)?[0-9]{10}$/"; }
        }
        #endregion

        /// <summary>
        /// Validate the string in Email Format
        /// </summary>
        /// <param name="Mobile">Email Id</param>
        /// <param name="isWithCountryCode">Email Id Can be private Or Public. Default Accept Both Public & Private</param>
        /// <returns>Boolean</returns>
        public static bool Email(string Email, bool isPrivateMail = false)
        {
            return Regex.IsMatch(Email, ((isPrivateMail) ? PrivateEmailExp : EmailExp), RegexOptions.IgnoreCase);
        }
        /// <summary>
        /// Validate the string in MobileNumber Format
        /// </summary>
        /// <param name="Mobile">Mobile Number</param>
        /// <param name="isWithCountryCode">Mobile Number Format With Or Without Country Code. Default is Without Country Code</param>
        /// <returns>Boolean</returns>
        public static bool Mobile(string Mobile, bool isWithCountryCode = false)
        {

            return Regex.IsMatch(Mobile, ((isWithCountryCode) ? MobileWithCountryCodeExp : MobileWithoutCountryCodeExp), RegexOptions.IgnoreCase);
        }
    }

    public class GuruCompiler
    {
        public GuruCompiler()
        {
            Scope = new Dictionary<string, dynamic>();
        }

        static GuruCompiler()
        {
            RepeaterKey = "sxRepeat";
            IfKey = "sxIf";
            TemplateKey = "sxRun";
            IsExpressionRegex = new Regex("(?<={{).*?(?=}})");
            ForEachRegex =
                new Regex(@"^\s*([a-zA-Z_]+[\w]*)\s+in\s+(([a-zA-Z][\w]*(\.[a-zA-Z][\w]*)*)|\[(.+)(,\s*.+)*\])\s*$",
                RegexOptions.Singleline);
            Filters = new Dictionary<string, Func<object, string>>
            {
                ["currency"] = x =>
                {
                    //this is simple and dirty to support all numeric types.
                    var s = x.ToString();
                    double d;
                    double.TryParse(s, out d);
                    return d.ToString("C");
                }
            };
        }

        public static string RepeaterKey { get; set; }
        public static string IfKey { get; set; }
        public static string TemplateKey { get; set; }
        public static Dictionary<string, Func<object, string>> Filters { get; }

        private static readonly Regex IsExpressionRegex;
        private static readonly Regex ForEachRegex;
        private static readonly char[] ValidStartName =
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            '_', '$'
        };
        private static readonly char[] ValidContentName =
        {
            'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z',
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z',
            '_', '$', '1','2','3','4','5','6','7','8','9','0', '.', '[', ']'
        };

        private static readonly string[] KeyWords = { "if" };

        public XmlWriterSettings XmlWriterSettings { get; set; }

        public Dictionary<string, dynamic> Scope { get; set; }

        public GuruCompiler SetScope(Dictionary<string, dynamic> scope)
        {
            Scope = scope;
            return this;
        }

        public GuruCompiler AddKey(string key, dynamic value)
        {
            Scope[key] = value;
            return this;
        }

        /// <summary>
        /// Compiles a string template
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string CompileString(string input)
        {
            var template = "<sx.string>" + input + "</sx.string>";
            using (var reader = XmlReader.Create(new StringReader(template)))
            {
                var output = new StringBuilder();
                var ws = XmlWriterSettings ?? new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8, OmitXmlDeclaration = true };
                using (var writer = XmlWriter.Create(output, ws))
                {
                    var compiled = _readXml(reader);
                    compiled.Run(writer);
                }
                return output.ToString().Replace("<sx.string>", "").Replace("</sx.string>", "");
            }
        }

        /// <summary>
        /// Compiles a Xml template with specified URI.
        /// </summary>
        /// <param name="uri"></param>
        /// <param name="root">
        ///     Set the root to compile, to improve performance. 
        ///     example: x => x.Children.First(y => x.Name == "MyElement")
        /// </param>
        /// <returns></returns>
        public string CompileXml(string uri, Func<XmlElement, XmlElement> root = null)
        {
            using (var reader = XmlReader.Create(uri))
            {
                var output = new StringBuilder();
                var ws = XmlWriterSettings ?? new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8, OmitXmlDeclaration = true };
                using (var writer = XmlWriter.Create(output, ws))
                {
                    var compiled = _readXml(reader);
                    if (root != null)
                    {
                        compiled = root(compiled);
                    }
                    compiled.Run(writer);
                }
                return output.ToString();
            }
        }

        /// <summary>
        /// Compiles a Xml template using the specified stream with default settings. 
        /// </summary>
        /// <param name="stream"></param>
        /// <param name="root">
        ///     Set the root to compile, to improve performance. 
        ///     example: x => x.Children.First(y => x.Name == "MyElement")
        /// </param>
        /// <returns></returns>
        public string CompileXml(Stream stream, Func<XmlElement, XmlElement> root = null)
        {
            using (var reader = XmlReader.Create(stream))
            {
                var output = new StringBuilder();
                var ws = XmlWriterSettings ?? new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8, OmitXmlDeclaration = true };
                using (var writer = XmlWriter.Create(output, ws))
                {
                    var compiled = _readXml(reader);
                    if (root != null)
                    {
                        compiled = root(compiled);
                    }
                    compiled.Run(writer);
                }
                return output.ToString();
            }
        }

        /// <summary>
        /// Compiles a Xml template by using the specified text reader. 
        /// </summary>
        /// <param name="textReader"></param>
        /// <param name="root">
        ///     Set the root to compile, to improve performance. 
        ///     example: x => x.Children.First(y => x.Name == "MyElement")
        /// </param>
        /// <returns></returns>
        public string CompileXml(TextReader textReader, Func<XmlElement, XmlElement> root = null)
        {
            using (var reader = XmlReader.Create(textReader))
            {
                var output = new StringBuilder();
                var ws = XmlWriterSettings ?? new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8, OmitXmlDeclaration = true };
                using (var writer = XmlWriter.Create(output, ws))
                {
                    var compiled = _readXml(reader);
                    if (root != null)
                    {
                        compiled = root(compiled);
                    }
                    compiled.Run(writer);
                }
                return output.ToString();
            }
        }

        /// <summary>
        /// Compiles a Xml template with a specified XmlReader
        /// </summary>
        /// <param name="xmlReader"></param>
        /// <param name="root">
        ///     Set the root to compile, to improve performance. 
        ///     example: x => x.Children.First(y => x.Name == "MyElement")
        /// </param>
        /// <returns></returns>
        public string CompileXml(XmlReader xmlReader, Func<XmlElement, XmlElement> root = null)
        {
            var output = new StringBuilder();
            var ws = XmlWriterSettings ?? new XmlWriterSettings { Indent = true, Encoding = Encoding.UTF8, OmitXmlDeclaration = true };
            using (var writer = XmlWriter.Create(output, ws))
            {
                var compiled = _readXml(xmlReader);
                if (root != null)
                {
                    compiled = root(compiled);
                }
                compiled.Run(writer);
            }
            return output.ToString();
        }

        private XmlElement _readXml(XmlReader reader)
        {
            var element = new XmlElement(BufferCommands.NewDocument) { Scope = Scope };
            while (reader.Read())
            {
                switch (reader.NodeType)
                {
                    case XmlNodeType.Element:
                        element = new XmlElement(BufferCommands.NewElement)
                        {
                            Name = reader.Name,
                            Parent = element
                        };
                        for (var i = 0; i < reader.AttributeCount; i++)
                        {
                            reader.MoveToAttribute(i);
                            element.Attributes.Add(new XmlAttribute
                            {
                                Name = reader.Name,
                                Value = reader.Value
                            });
                        }
                        if (reader.AttributeCount > 0) reader.MoveToElement();
                        if (reader.IsEmptyElement) goto case XmlNodeType.EndElement;
                        break;
                    case XmlNodeType.Text:
                        new XmlElement(BufferCommands.StringContent)
                        {
                            Value = reader.Value,
                            Parent = element
                        };
                        break;
                    case XmlNodeType.EndElement:
                        element = element.Parent;
                        break;
                    case XmlNodeType.XmlDeclaration:
                    case XmlNodeType.ProcessingInstruction:
                    case XmlNodeType.Comment:
                        //ignored
                        break;
                }
            }
            var root = element.Children.First();
            return root;
        }

        public class XmlElement
        {
            private XmlElement _parent;
            public XmlElement(BufferCommands type)
            {
                Attributes = new List<XmlAttribute>();
                Children = new List<XmlElement>();
                Type = type;
            }

            private BufferCommands Type { get; }
            /// <summary>
            /// Name of the Element
            /// </summary>
            public string Name { get; set; }
            /// <summary>
            /// Content of the Element
            /// </summary>
            public string Value { get; set; }
            /// <summary>
            /// Sets Name space to xml Element
            /// </summary>
            /// <summary>
            /// Attributes in the Element
            /// </summary>
            public List<XmlAttribute> Attributes { get; }
            public XmlElement Parent
            {
                get { return _parent; }
                set
                {
                    _parent = value;
                    _parent?.Children.Add(this);
                }
            }
            /// <summary>
            /// Gets the children of this element
            /// </summary>
            public List<XmlElement> Children { get; }
            /// <summary>
            /// Scope of current Element.
            /// </summary>
            public Dictionary<string, dynamic> Scope { get; set; }
            public dynamic GetValueFromScope(string propertyName)
            {
                try
                {
                    var keys = propertyName.Split('.');
                    var digTo = keys.Count(x => x == "$parent");
                    var d = 0;
                    var p = this;

                    while (digTo > 0 && digTo + 1 > d)
                    {
                        p = p.Parent;
                        d += p.Scope != null ? 1 : 0;
                    }
                    if (digTo > 0) keys = keys.Where(x => x != "$parent").ToArray();

                    var property = new PropertyAccess(keys[0]);
                    var scope = p.Scope;
                    var parent = this;
                    while (scope == null || !scope.ContainsKey(property.Name))
                    {
                        parent = parent.Parent;
                        scope = parent.Scope;
                    }

                    var obj = scope[property.Name];
                    var level = 1;

                    while (level < keys.Length)
                    {
                        obj = property.GetValue(obj);
                        property = new PropertyAccess(keys[level]);
                        var t = obj.GetType();
                        obj = t == typeof(Dictionary<string, dynamic>) || t.IsArray
                            ? obj[property.Name]
                            : t.GetProperty(property.Name).GetValue(obj, null);
                        level++;
                    }

                    return property.GetValue(obj);
                }
                catch (Exception)
                {
                    Trace.WriteLine(propertyName + " not found. default value returned = false");
                    return false;
                }
            }
            private IEnumerable<Dictionary<string, dynamic>> Repeater()
            {
                var repeaterAttribute = Attributes.FirstOrDefault(x => x.Name == RepeaterKey);
                if (repeaterAttribute == null)
                {
                    yield return null;
                    yield break;
                }

                var expression = repeaterAttribute.Value;

                if (!ForEachRegex.IsMatch(expression))
                    throw new FormatException(
                        "Compilation Error: ForEach was expecting an expression like " +
                        "'varName in [value1, value2, value3..., valueN]'");

                var match = ForEachRegex.Match(expression);
                var repeater = match.Groups[1].ToString();
                var scopeName = match.Groups[3].ToString();
                var items = GetValueFromScope(scopeName);

                var i = 0;

                foreach (var item in items ?? new List<int>())
                {
                    var even = i % 2 == 0;
                    yield return new Dictionary<string, dynamic>
                    {
                        [repeater] = item,
                        ["$index"] = i++,
                        ["$odd"] = !even,
                        ["$even"] = even
                    };
                }
            }

            private Dictionary<string, CExpression> _cache = new Dictionary<string, CExpression>();
            private CExpression _ifCache;

            private bool If()
            {
                var at = Attributes.FirstOrDefault(x => x.Name == IfKey);
                var expression = at?.Value;
                if (string.IsNullOrEmpty(expression)) return true;
                if (_ifCache == null) _ifCache = new CExpression(expression, this);
                var e = _ifCache.Evaluate();
                bool res;
                var couldConvert = bool.TryParse(e, out res);
                return couldConvert && res;
            }

            private string Inject(string expression)
            {
                foreach (var v in IsExpressionRegex.Matches(expression).Cast<Match>()
                            .GroupBy(x => x.Value).Select(varGroup => varGroup.First().Value))
                {
                    if (!_cache.ContainsKey(v)) _cache.Add(v, new CExpression(v, this));
                    expression = expression.Replace("{{" + v + "}}", _cache[v].Evaluate());
                }
                return expression;
            }

            public void Run(XmlWriter writer)
            {
                switch (Type)
                {
                    case BufferCommands.NewElement:
                        var isTemplate = Name == TemplateKey;
                        var ns = Attributes.FirstOrDefault(x => x.Name == "xmlns");
                        foreach (var scope in Repeater())
                        {
                            Scope = scope;
                            if (!If()) continue;

                            if (!isTemplate)
                                if (ns != null) writer.WriteStartElement(Name, ns.Value);
                                else writer.WriteStartElement(Name);

                            foreach (var attribute in Attributes.Where(attribute => attribute.Name != RepeaterKey
                                                                                    && attribute.Name != IfKey))
                            {
                                writer.WriteAttributeString(attribute.Name, Inject(attribute.Value));
                            }
                            foreach (var child in Children)
                            {
                                child.Run(writer);
                            }
                            if (!isTemplate) writer.WriteEndElement();
                        }
                        break;
                    case BufferCommands.StringContent:
                        writer.WriteString(Inject(Value));
                        break;
                }
            }

            private class CExpression
            {
                public CExpression(string expression, XmlElement parent)
                {
                    Items = new List<CExpressionItem>();
                    Parent = parent;
                    OriginalExpression = expression;

                    var read = new List<char>();
                    var type = LectureType.Unknow;

                    foreach (var c in expression)
                    {
                        switch (type)
                        {
                            case LectureType.Variable:
                                if (!ValidContentName.Contains(c))
                                {
                                    var l = new string(read.ToArray());
                                    Items.Add(new CExpressionItem
                                    {
                                        FromScope = !KeyWords.Contains(l),
                                        Value = l
                                    });
                                    read.Clear();
                                    type = LectureType.Unknow;
                                }
                                break;
                            case LectureType.String:
                                if (c == '\'')
                                {
                                    read.Add('\'');
                                    Items.Add(new CExpressionItem
                                    {
                                        FromScope = false,
                                        Value = new string(read.ToArray())
                                    });
                                    read.Clear();
                                    type = LectureType.Unknow;
                                    continue;
                                }
                                break;
                            case LectureType.Constant:
                                if (ValidStartName.Contains(c) || c == '\'' || c == '|')
                                {
                                    Items.Add(new CExpressionItem
                                    {
                                        FromScope = false,
                                        Value = new string(read.ToArray())
                                    });
                                    read.Clear();
                                    type = LectureType.Unknow;
                                }
                                break;
                        }
                        if (type == LectureType.Unknow)
                        {
                            if (ValidStartName.Contains(c))
                            {
                                type = LectureType.Variable;
                            }
                            else
                                switch (c)
                                {
                                    case '\'':
                                        type = LectureType.String;
                                        break;
                                    case '|':
                                        type = LectureType.Filter;
                                        break;
                                    default:
                                        type = LectureType.Constant;
                                        break;
                                }
                        }
                        read.Add(c);
                    }
                    if (type != LectureType.Filter)
                    {
                        Items.Add(new CExpressionItem
                        {
                            FromScope = type == LectureType.Variable,
                            Value = new string(read.ToArray())
                        });
                    }
                    else
                    {
                        Filter = new string(read.ToArray()).Replace("|", "").Trim();
                    }
                }

                private List<CExpressionItem> Items { get; }
                private XmlElement Parent { get; }
                private string OriginalExpression { get; }
                private string Filter { get; }

                public string Evaluate()
                {
                    var sb = new StringBuilder();
                    var p = 0;
                    var parameters = new Dictionary<string, object>();
                    foreach (var i in Items)
                    {
                        if (i.FromScope)
                        {
                            sb.Append("[p");
                            sb.Append(p);
                            sb.Append("]");
                            parameters.Add("p" + p, Parent.GetValueFromScope(i.Value) ?? false);
                            p++;
                        }
                        else
                        {
                            sb.Append(i.Value);
                        }
                    }

                    var s = sb.ToString();
                    if (string.IsNullOrWhiteSpace(s)) return "";
                    var e = new Expression(s.Replace("&gt;", ">").Replace("&lt;", "<"), EvaluateOptions.NoCache)
                    {
                        Parameters = parameters
                    };

                    try
                    {
                        var result = e.Evaluate();
                        return Filter != null
                            ? Filters[Filter](result)
                            : result.ToString();
                    }
                    catch
                    {
                        Trace.WriteLine("Error Evaluating expression '" + OriginalExpression + "'");
                        return "{{ " + OriginalExpression + " }}";
                    }
                }
            }

            private class CExpressionItem
            {
                public bool FromScope { get; set; }
                public string Value { get; set; }
            }
        }

        public class XmlAttribute
        {
            public string Name { get; set; }
            public string Value { get; set; }
        }

        private class PropertyAccess
        {
            public PropertyAccess(string propertyName)
            {
                var ar = propertyName.Split('[', ']');
                Name = ar[0];
                Children = new List<string>();
                for (var i = 1; i < ar.Length - 1; i++)
                {
                    Children.Add(ar[i]);
                }
            }

            public string Name { get; }
            public List<string> Children { get; }

            public dynamic GetValue(dynamic obj)
            {
                dynamic r = obj;
                foreach (var child in Children)
                {
                    var t = r.GetType();
                    if (t.IsArray || obj is IEnumerable)
                    {
                        int index;
                        int.TryParse(child, out index);
                        r = r[index];
                    }
                    else
                    {
                        r = r[child];
                    }
                }
                return r;
            }
        }

        public enum BufferCommands
        {
            NewElement,
            StringContent,
            NewDocument
        }

        private enum LectureType
        {
            Variable, String, Filter, Unknow, Constant
        }
    }
}