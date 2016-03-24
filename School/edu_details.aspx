<%@ Page Title="" Language="C#" MasterPageFile="~/scl_master.Master" AutoEventWireup="true" CodeBehind="edu_details.aspx.cs" Inherits="School.edu_details" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="navication" runat="server">
    <li>
        <a href="general.aspx"><span class="glyphicon glyphicon-list"></span><span class="xn-text">General</span></a>
    </li>
    <li>
        <a href="contact_info.aspx"><span class="fa fa-phone"></span><span class="xn-text">Contact Details</span></a>
    </li>
    <li class="active">
        <a href="edu_details.aspx"><span class="glyphicon glyphicon-book"></span><span class="xn-text">Education Qualifications</span></a>
    </li>
    <li>
        <a href="prev_emp.aspx"><span class="fa fa-desktop"></span><span class="xn-text">Previous Employment</span></a>
    </li>
    <li>
        <a href="family_details.aspx"><span class="fa fa-users"></span><span class="xn-text">Family Details</span></a>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="brd" runat="server">
    <li><a href="general.aspx">Home</a></li>
    <li class="active">Education Qualifications</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="panel_heading" runat="server">
    Education Qualifications
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="panel_controlls" runat="server">
    <asp:Panel ID="pn_listbtn" runat="server">
        <ul class="panel-controls">
            <li>
                <asp:Button ID="but_adnew" runat="server" CssClass="btn btn-sm" Text="Add New" OnClick="but_adnew_Click" /></li>
        </ul>
    </asp:Panel>
    <%--<asp:Panel ID="pn_enterybtn" runat="server">
        <ul class="panel-controls">
            <li>
                <asp:Button ID="btn_upt" runat="server" Text="update" CssClass="btn btn-sm btn-success" OnClick="btn_upt_Click" /></li>
            <li>
                <asp:Button ID="btn_sve" runat="server" Text="save" CssClass="btn btn-sm btn-primary" OnClick="btn_sve_Click" /></li>
            <li>
                <asp:Button ID="btn_cnl" runat="server" Text="cancel" CssClass="btn btn-sm btn-default" OnClick="btn_cnl_Click" /></li>
        </ul>
    </asp:Panel>--%>
    <asp:Panel ID="pn_enterybtn" runat="server">
        <ul class="panel-controls">
            <li>
                <asp:Button ID="btn_sve" runat="server" Text="save" CssClass="btn btn-sm btn-primary" OnClick="btn_sve_Click" /></li>
            <li>
                <asp:Button ID="btn_cnl" runat="server" Text="cancel" CssClass="btn btn-sm btn-default" OnClick="btn_cnl_Click" /></li>
        </ul>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="content" runat="server">
    <asp:Panel ID="pnl_edu" runat="server">
        <asp:GridView ID="gvUnitList" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
            EmptyDataText="No Records Found !" ShowFooter="true" AllowSorting="true" ShowHeaderWhenEmpty="true"
            OnRowCommand="gvUnitList_RowCommand" OnRowDataBound="gvUnitList_RowDataBound">
            <Columns>
                <asp:TemplateField HeaderText="SNO.">
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("SNO") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="EMPLOYEE ID">
                    <ItemTemplate>
                         <asp:TextBox ID="txtUnitSys" runat="server" CssClass="form-control" Text='<%# Eval("EMP_ID") %>'></asp:TextBox>
                        <asp:HiddenField ID="hfKeyvalue" runat="server" Value='<%# Eval("SYS_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="QUALIFICATION">
                    <ItemTemplate>
                        <asp:TextBox ID="txtUnitQua" runat="server" CssClass="form-control" Text='<%# Eval("QUA_ID") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="SUBJECT">
                    <ItemTemplate>
                        <asp:TextBox ID="txtUnitSub" runat="server" CssClass="form-control" Text='<%# Eval("SUB") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="DEGREE">
                    <ItemTemplate>
                        <asp:TextBox ID="txtUnitDegree" runat="server" CssClass="form-control" Text='<%# Eval("DEGREE") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="INSTITUTION">
                    <ItemTemplate>
                        <asp:TextBox ID="txtUnitIns" runat="server" CssClass="form-control" Text='<%# Eval("INSTITUTION") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="MEDIUM">
                    <ItemTemplate>
                        <asp:TextBox ID="txtUnitMedium" runat="server" CssClass="form-control" Text='<%# Eval("MEDIUM") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="YEAR">
                    <ItemTemplate>
                        <asp:TextBox ID="txtUnitYear" runat="server" CssClass="form-control" Text='<%# Eval("YEAR") %>'></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="PERCENTAGE">
                    <ItemTemplate>
                        <asp:TextBox ID="txtUnitPer" runat="server" CssClass="form-control" Text='<%# Eval("PERCENTAGE") %>'></asp:TextBox>
                    </ItemTemplate>
                    <FooterTemplate>
                        <asp:Button ID="btnRowAdd" runat="server" Text="Add" CssClass="btn btn-green" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                            CommandName="AddRow" />
                    </FooterTemplate>
                    <FooterStyle HorizontalAlign="Right" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfDeleted" runat="server" Value="0" />
                        <asp:Label ID="lblDelete" runat="server" Text="Deleted" CssClass="label label-danger"
                            Visible="false"></asp:Label>
                        <asp:LinkButton ID="btnDeleteUnit" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                            CommandName="DeleteUnit" CssClass="btn btn-icon btn-danger"><i class="icon-remove3"></i></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="pnl_gv" runat="server">
        <asp:GridView ID="gv_cust" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" EmptyDataText="No Record Found !" ShowHeaderWhenEmpty="true">
            <Columns>
                <asp:BoundField DataField="NAME" HeaderText="NAME" />
                <asp:BoundField DataField="EMP" HeaderText="EMP_ID" />
                <asp:BoundField DataField="QUA" HeaderText="QUALIFICATION" />
                <asp:BoundField DataField="SUB" HeaderText="SUBJECT" />
                <asp:BoundField DataField="YEAR" HeaderText="YEAR" />
                <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
                    <ItemTemplate>
                        <asp:Button ID="btn_edt" runat="server" Text="Edit" CssClass="btn btn-success" CommandName="gvedit" CommandArgument='<%# Eval("SYS_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
                    <ItemTemplate>
                        <asp:Button ID="btn_del" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="gvdelete" CommandArgument='<%# Eval("SYS_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
                    <ItemTemplate>
                        <asp:Button ID="btn_print" runat="server" Text="Print" CssClass="btn btn-danger" CommandName="gvPrint" CommandArgument='<%# Eval("SYS_ID") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:HiddenField ID="hid" runat="server" />
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="panel_footer" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="jvalidate" runat="server">
</asp:Content>
