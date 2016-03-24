<%@ Page Title="Emp-List" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="List.aspx.cs" Inherits="School.Employee.List" %>

<%@ Import Namespace="School.Config" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <style>
        table.table > tbody > tr > th {
            padding: 3px !important;
            vertical-align: middle !important;
            text-align: center !important;
            text-transform: none !important;
            color: #fff !important;
            background-color: #6E62B5 !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpBody" runat="server">

    <asp:UpdateProgress ID="asyncProcess" runat="server" AssociatedUpdatePanelID="asyncPanel">
        <ProgressTemplate>
            <Guru:Progressbar ID="gpProgress" runat="server" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="asyncPanel" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-12">
                    <div class="panel">
                        <div class="panel-header bg-primary">
                            <h3>
                                <strong>
                                    <label id="lblPageStatus">List</label>
                                </strong>
                                <div class="pull-right panel-btns">
                                    <asp:LinkButton ID="btnAddNew" runat="server" CssClass="btn btn-white btn-sm" OnClick="btnAddNew_Click">Add New</asp:LinkButton>
                                </div>
                            </h3>
                        </div>
                        <div class="panel-content">
                            <div class="row">
                                <Guru:RecordSearch ID="dbRecordSearch" runat="server" OnDbRecordSearch="dbRecordSearch_DbRecordSearch" />
                            </div>
                            <div class="row">
                                <div class="col-md-12 table-responsive">
                                    <asp:GridView ID="gvListView" runat="server" CssClass="table table-bordered table-hover" EmptyDataText="No Records Found !" AllowSorting="true" ShowHeaderWhenEmpty="true" OnSorting="gvListView_Sorting" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="SNO" HeaderText="S.No" />
                                            <asp:TemplateField ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" HeaderText="Img">
                                                <ItemTemplate>
                                                    <img class="Round_Img" style="height: 50px" src="<%# Common.CheckImgPath(ResolveUrl(Eval("IMG").ToString()), "/App_Upload/User_Img/avatar.png")%>" alt="<%#Eval("FULL_NAME") %>" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ID" HeaderText="Id" SortExpression="ID" />
                                            <asp:BoundField DataField="FULL_NAME" HeaderText="Full Name" SortExpression="FULL_NAME" />
                                            <asp:BoundField DataField="DIVISION" HeaderText="Division" SortExpression="DIVISION" />
                                            <asp:BoundField DataField="GRADE" HeaderText="Grade" SortExpression="GRADE" />
                                            <asp:BoundField DataField="DESIGNATION" HeaderText="Designation" SortExpression="DESIGNATION" />
                                            <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnEdit" runat="server" OnCommand="btnEdit_Command"
                                                        CssClass="btn btn-icon btn-primary" CommandArgument='<%# Eval("SYS_ID") %>'>
                                                            <i class="fa fa-pencil"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnPrint" runat="server" OnCommand="btnPrint_Command"
                                                        CssClass="btn btn-icon btn-primary" CommandArgument='<%# Eval("SYS_ID") %>'>
                                                            <i class="fa fa-print"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnDelete" runat="server" OnCommand="btnDelete_Command"
                                                        OnClientClick="return Confirm_Msg(this,'Are you sure do you want to Delete this record..?');"
                                                        CssClass="btn btn-icon btn-danger" CommandArgument='<%# Eval("SYS_ID") %>'>
                                                            <i class="fa fa-trash-o"></i></asp:LinkButton>
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="row">
                                <Guru:Pager ID="PagerInfo" runat="server" OnPagerClick="Pager_PagerClick" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
