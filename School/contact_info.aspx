<%@ Page Title="" Language="C#" MasterPageFile="~/scl_master.Master" AutoEventWireup="true" CodeBehind="contact_info.aspx.cs" Inherits="School.contact_info" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="navication" runat="server">
    <li>
        <a href="general.aspx"><span class="glyphicon glyphicon-list"></span><span class="xn-text">General</span></a>
    </li>
    <li class="active">
        <a href="contact_info.aspx"><span class="fa fa-phone"></span><span class="xn-text">Contact Details</span></a>
    </li>
    <li>
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
    <li class="active">Contact Details</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="panel_heading" runat="server">
    Contact Details
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="panel_controlls" runat="server">
    <asp:Panel ID="pn_listbtn" runat="server">
        <ul class="panel-controls">
            <li>
                <asp:Button ID="but_adnew" runat="server" CssClass="btn btn-sm" Text="Add New" OnClick="but_adnew_Click" /></li>
        </ul>
    </asp:Panel>
    <asp:Panel ID="pn_enterybtn" runat="server">
        <ul class="panel-controls">
            <li>
                <asp:Button ID="btn_upt" runat="server" Text="update" CssClass="btn btn-sm btn-success" OnClick="btn_upt_Click" /></li>
            <li>
                <asp:Button ID="btn_sve" runat="server" Text="save" CssClass="btn btn-sm btn-primary" OnClick="btn_sve_Click" /></li>
            <li>
                <asp:Button ID="btn_cnl" runat="server" Text="cancel" CssClass="btn btn-sm btn-default" OnClick="btn_cnl_Click" /></li>
        </ul>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content6" ContentPlaceHolderID="content" runat="server">
    <asp:Panel ID="pnl_usr" runat="server">
        <div class="col-md-6">
            <div class="form-group">
                <label class="col-md-3 control-label">Employee Id</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                            <asp:DropDownList ID="ddl_empid" runat="server" CssClass="form-control select" DataTextField="EMP_ID" DataValueField="SYS_ID">
                            </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Permanent Address</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                        <asp:TextBox ID="perm_ads" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Present Address</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                        <asp:TextBox ID="pres_ads" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Email</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-mail-forward"></span></span>
                        <asp:TextBox ID="mail" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="col-md-3 control-label">Mobile No</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-phone"></span></span>
                        <asp:TextBox ID="ph" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Emergency Contact Name</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                        <asp:TextBox ID="ec_name" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Emergency Contact Mobile No</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-phone"></span></span>
                        <asp:TextBox ID="ec_ph" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnl_gv" runat="server">
        <asp:GridView ID="gv_cust" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" EmptyDataText="No Record Found !" ShowHeaderWhenEmpty="true">
            <Columns>
                <asp:BoundField DataField="FULL_NAME" HeaderText="Name" />
                <asp:BoundField DataField="EMP_ID" HeaderText="Employee Id" />
                <asp:BoundField DataField="PERMANENT" HeaderText="Permenent Address" />
                <asp:BoundField DataField="PRESENT" HeaderText="Permenent Address" />
                <asp:BoundField DataField="MAIL" HeaderText="Email Id" />
                <asp:BoundField DataField="MOBILE" HeaderText="Mobile_No" />
                <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
                    <ItemTemplate>
                        <asp:Button ID="btn_edt" runat="server" Text="Edit" CssClass="btn btn-success" CommandName="gvedit" CommandArgument='<%# Eval("CNT_ID") %>' OnCommand="btn_del_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
                    <ItemTemplate>
                        <asp:Button ID="btn_del" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="gvdelete" CommandArgument='<%# Eval("SYS_ID") %>' OnCommand="btn_del_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
                    <ItemTemplate>
                        <asp:Button ID="btn_print" runat="server" Text="Print" CssClass="btn btn-danger" CommandName="gvPrint" CommandArgument='<%# Eval("SYS_ID") %>' OnCommand="btn_del_Command" />
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
