using System;
using System.Web;
using System.Web.UI;
using GuruBal;
using GuruDal;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using System.Data;
using System.Drawing.Printing;
using System.Globalization;
using System.IO;
using System.Text;
using School.Config;

namespace School.Report
{
    public partial class Master_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Load_Data();
            }
        }

        protected void Load_Data()
        {
            BLL_Common bl = new BLL_Common(Guru.Get_ConnectionString, "", "");
            try
            {
                string reportType = Common.DecryptUrl(GuruConvert.AsString(Request["Type"])).ToUpper();
                string outputType = Common.DecryptUrl(GuruConvert.AsString(Request["OutputType"])).ToUpper();

                if (reportType == "EMP_PRINT")
                {
                    SqlCommand cmd = new SqlCommand("uspEmployeePrint") {CommandType = CommandType.StoredProcedure};

                    cmd.Parameters.AddWithValue("@EMP_SYS_ID", "1");//Common.DecryptUrl(GuruConvert.AsString(Request["EMP_SYS_ID"])));
                    DataSet ds = bl.GetDataSet(cmd);
                    rvMaster.LocalReport.EnableExternalImages = true;
                    rvMaster.LocalReport.ReportPath = HttpContext.Current.Server.MapPath(System.IO.Path.Combine("~/Report/Print_Emp_Info.rdlc"));
                    rvMaster.LocalReport.DataSources.Add(new ReportDataSource("Emp_Genral_Info", ds.Tables[0]));
                    rvMaster.LocalReport.DataSources.Add(new ReportDataSource("Emp_Qua_Info", ds.Tables[1]));
                    rvMaster.LocalReport.DataSources.Add(new ReportDataSource("Emp_Exp_Info", ds.Tables[2]));
                    rvMaster.LocalReport.DataSources.Add(new ReportDataSource("Emp_Fam_Info", ds.Tables[3]));
                    string imagePath = new Uri(Server.MapPath(ds.Tables[0].Rows[0]["IMG"].ToString())).AbsoluteUri;
                    rvMaster.LocalReport.SetParameters(new ReportParameter("Emp_Image", imagePath));
                    rvMaster.LocalReport.Refresh();
                }
                if (rvMaster.LocalReport.IsReadyForRendering && outputType == "PDF")
                {
                    byte[] fileData = rvMaster.LocalReport.Render("PDF", DeviceInfo(rvMaster));
                    Context.Response.Clear();
                    Context.Response.ContentType = "application/pdf";
                    Context.Response.AddHeader("content-length", fileData.Length.ToString());
                    Context.Response.BinaryWrite(fileData);
                    HttpContext.Current.ApplicationInstance.CompleteRequest();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                bl.Dispose();
            }
        }

        protected string DeviceInfo(ReportViewer rv)
        {
            ReportViewer rv1 = new ReportViewer();
            PageSettings ps = rv.GetPageSettings();
            PaperSize paperSize = ps.PaperSize;
            Margins margins = ps.Margins;

            // The device info string defines the page range to print as well as the size of the page.
            // A start and end page of 0 means generate all pages.
            return string.Format(
                CultureInfo.InvariantCulture,
                "<DeviceInfo><OutputFormat>emf</OutputFormat><StartPage>0</StartPage><EndPage>0</EndPage><MarginTop>{0}</MarginTop><MarginLeft>{1}</MarginLeft><MarginRight>{2}</MarginRight><MarginBottom>{3}</MarginBottom><PageHeight>{4}</PageHeight><PageWidth>{5}</PageWidth></DeviceInfo>",
                ToInches(margins.Top),
                ToInches(margins.Left),
                ToInches(margins.Right),
                ToInches(margins.Bottom),
                ToInches(paperSize.Height),
                ToInches(paperSize.Width));
        }

        protected string ToInches(int hundrethsOfInch)
        {
            double inches = hundrethsOfInch / 100.0;
            return inches.ToString(CultureInfo.InvariantCulture) + "in";
        }
    }
}