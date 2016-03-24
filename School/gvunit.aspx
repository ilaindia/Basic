<%@ Page Title="" Language="C#" MasterPageFile="~/scl_master.Master" AutoEventWireup="true" CodeBehind="gvunit.aspx.cs" Inherits="School.gvunit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="navication" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="brd" runat="server">
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="panel_heading" runat="server">
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="panel_controlls" runat="server">
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="content" runat="server">
    <asp:GridView ID="gvUnitList" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered"
        EmptyDataText="No Records Found !" ShowFooter="true" AllowSorting="true" ShowHeaderWhenEmpty="true"
        OnRowCommand="gvUnitList_RowCommand" OnRowDataBound="gvUnitList_RowDataBound">
        <Columns>
            <asp:TemplateField HeaderText="SNO.">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("SNO") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit Name">
                <ItemTemplate>
                    <asp:TextBox ID="txtUnitName" runat="server" CssClass="form-control" Text='<%# Eval("UNIT_NAME") %>'></asp:TextBox>
                    <asp:HiddenField ID="hfKeyvalue" runat="server" Value='<%# Eval("SYS_ID") %>' />
                </ItemTemplate>
                <FooterTemplate>
                    <asp:Button ID="btnRowAdd" runat="server" ValidationGroup="EDUCATION" Text="Add" CssClass="btn btn-green" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
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
    <%--<asp:BulletedList ID="save" runat="server" OnClick="save_Click"></asp:BulletedList>--%>
</asp:Content>
<asp:Content ID="Content7" ContentPlaceHolderID="panel_footer" runat="server">
</asp:Content>
<asp:Content ID="Content8" ContentPlaceHolderID="jvalidate" runat="server">
</asp:Content>
