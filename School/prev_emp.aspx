<%@ Page Title="" Language="C#" MasterPageFile="~/scl_master.Master" AutoEventWireup="true" CodeBehind="prev_emp.aspx.cs" Inherits="School.prev_emp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="navication" runat="server">
    <li>
        <a href="general.aspx"><span class="glyphicon glyphicon-list"></span><span class="xn-text">General</span></a>
    </li>
    <li>
        <a href="contact_info.aspx"><span class="fa fa-phone"></span><span class="xn-text">Contact Details</span></a>
    </li>
    <li>
        <a href="edu_details.aspx"><span class="glyphicon glyphicon-book"></span><span class="xn-text">Education Qualifications</span></a>
    </li>
    <li class="active">
        <a href="prev_emp.aspx"><span class="fa fa-desktop"></span><span class="xn-text">Previous Employment</span></a>
    </li>
    <li>
        <a href="family_details.aspx"><span class="fa fa-users"></span><span class="xn-text">Family Details</span></a>
    </li>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="brd" runat="server">
    <li><a href="general.aspx">Home</a></li>
    <li class="active">Previous Employment</li>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="panel_heading" runat="server">
    Previous Employment
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
                <label class="col-md-3 control-label">Full Name</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                        <asp:TextBox ID="fn" name="f_name" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Employee ID No</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                        <asp:TextBox ID="emp_id" name="emp_id" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Division</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                        <asp:DropDownList ID="division" runat="server" CssClass="form-control select">
                            <asp:ListItem Selected="True" Value="Pre Primary">Pre Primary</asp:ListItem>
                            <asp:ListItem Value="Primary">Primary</asp:ListItem>
                            <asp:ListItem Value="Middle">Middle</asp:ListItem>
                            <asp:ListItem Value="Secondary">Secondary</asp:ListItem>
                            <asp:ListItem Value="Senior Secondary">Senior Secondary</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Grade</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                        <asp:DropDownList ID="grade" runat="server" CssClass="form-control select">
                            <asp:ListItem Selected="True" Value="LKG">LKG</asp:ListItem>
                            <asp:ListItem Value="UKG">UKG</asp:ListItem>
                            <asp:ListItem Value="I">I</asp:ListItem>
                            <asp:ListItem Value="II">II</asp:ListItem>
                            <asp:ListItem Value="III">III</asp:ListItem>
                            <asp:ListItem Value="IV">IV</asp:ListItem>
                            <asp:ListItem Value="V">V</asp:ListItem>
                            <asp:ListItem Value="VI">VI</asp:ListItem>
                            <asp:ListItem Value="VII">VII</asp:ListItem>
                            <asp:ListItem Value="VIII">VIII</asp:ListItem>
                            <asp:ListItem Value="IX">IX</asp:ListItem>
                            <asp:ListItem Value="X">X</asp:ListItem>
                            <asp:ListItem Value="XI">XI</asp:ListItem>
                            <asp:ListItem Value="XII">XII</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Desiganation</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                        <asp:DropDownList ID="desi" runat="server" CssClass="form-control select">
                            <asp:ListItem Selected="True" Value="Teacher">Teacher</asp:ListItem>
                            <asp:ListItem Value="Office Staff">Office Staff</asp:ListItem>
                            <asp:ListItem Value="Ministrail Staff">Ministrial Staff</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Date of Birth</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-calendar"></span></span>
                        <asp:TextBox ID="dob" name="date" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Place of Birth</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                        <asp:TextBox ID="pob" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Date of Joining</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-calendar"></span></span>
                        <asp:TextBox ID="doj" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-6">
            <div class="form-group">
                <label class="col-md-3 control-label">PAN Card No</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-credit-card"></span></span>
                        <asp:TextBox ID="pan" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Passport No</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-credit-card"></span></span>
                        <asp:TextBox ID="passport" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Blood Group</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-plus-square"></span></span>
                        <asp:TextBox ID="blood" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Religion</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                        <asp:DropDownList ID="religion" runat="server" CssClass="form-control select">
                            <asp:ListItem Selected="True" Value="Hindu">Hindu</asp:ListItem>
                            <asp:ListItem Value="Christian">Christian</asp:ListItem>
                            <asp:ListItem Value="Muslim">Muslim</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Caste</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                        <asp:TextBox ID="caste" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">Salary</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                        <asp:TextBox ID="salary" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">EPF</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                        <asp:TextBox ID="epf" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <label class="col-md-3 control-label">ESI</label>
                <div class="col-md-9">
                    <div class="input-group">
                        <span class="input-group-addon"><span class="fa fa-pencil"></span></span>
                        <asp:TextBox ID="esi" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="pnl_gv" runat="server">
        <asp:GridView ID="gv_cust" runat="server" CssClass="table table-bordered" AutoGenerateColumns="false" EmptyDataText="No Record Found !" ShowHeaderWhenEmpty="true">
            <Columns>
                <asp:BoundField DataField="full_name" HeaderText="Full Name" />
                <asp:BoundField DataField="emp_id" HeaderText="Employe Id" />
                <asp:BoundField DataField="division" HeaderText="Division" />
                <asp:BoundField DataField="grade" HeaderText="Grade" />
                <asp:BoundField DataField="designation" HeaderText="Designation" />
                <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
                    <ItemTemplate>
                        <asp:Button ID="btn_edt" runat="server" Text="Edit" CssClass="btn btn-success" CommandName="gvedit" CommandArgument='<%# Eval("sys_id") %>' OnCommand="btn_del_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
                    <ItemTemplate>
                        <asp:Button ID="btn_del" runat="server" Text="Delete" CssClass="btn btn-danger" CommandName="gvdelete" CommandArgument='<%# Eval("sys_id") %>' OnCommand="btn_del_Command" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderStyle-Width="20px" ItemStyle-Width="20px">
                    <ItemTemplate>
                        <asp:Button ID="btn_print" runat="server" Text="Print" CssClass="btn btn-danger" CommandName="gvPrint" CommandArgument='<%# Eval("sys_id") %>' OnCommand="btn_del_Command" />
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
