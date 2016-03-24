<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Master_Report.aspx.cs" Inherits="School.Report.Master_Report" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="spManager" runat="server"></asp:ScriptManager>
        <rsweb:ReportViewer ID="rvMaster" runat="server" ProcessingMode="Local"></rsweb:ReportViewer>
    </form>
</body>
</html>
