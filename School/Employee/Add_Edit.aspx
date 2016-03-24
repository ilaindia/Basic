<%@ Page Title="Emp-Add_Edit" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="Add_Edit.aspx.cs" Inherits="School.Employee.Add_Edit" %>

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
    <asp:UpdateProgress ID="upProgress" AssociatedUpdatePanelID="upAsync" runat="server">
        <ProgressTemplate>
            <Guru:Progressbar ID="prg" runat="server" />
        </ProgressTemplate>
    </asp:UpdateProgress>
    <asp:UpdatePanel ID="upAsync" runat="server">
        <ContentTemplate>
            <div class="panel">
                <asp:Panel runat="server" ID="pnGenral">
                    <div class="panel-header">
                        <h4>(Step 1 of 5) Genral Info</h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-3 col-sm-6">
                                <div class="form-group">
                                    <label>Employee ID</label>
                                    <asp:TextBox ID="txtId" runat="server" CssClass="form-control" Enabled="False"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Full Name</label>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rqName" runat="server" ControlToValidate="txtName"
                                        ValidationGroup="EmployeeValidation" CssClass="Validation"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Division</label>
                                    <asp:DropDownList ID="ddlDivision" runat="server" data-search="true" CssClass="form-control">
                                        <asp:ListItem Selected="True" Value="0">[Select]</asp:ListItem>
                                        <asp:ListItem Value="Pre_Primary">Pre Primary</asp:ListItem>
                                        <asp:ListItem Value="Primary">Primary</asp:ListItem>
                                        <asp:ListItem Value="Middle">Middle</asp:ListItem>
                                        <asp:ListItem Value="Secondary">Secondary</asp:ListItem>
                                        <asp:ListItem Value="Senior_Secondary">Senior Secondary</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlDivision"
                                        ValidationGroup="EmployeeValidation" InitialValue="0" CssClass="Validation"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Grade</label>
                                    <asp:DropDownList ID="ddlGrade" runat="server" data-search="true" CssClass="form-control">
                                        <asp:ListItem Selected="True" Value="0">[Select]</asp:ListItem>
                                        <asp:ListItem Value="LKG">LKG</asp:ListItem>
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
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlGrade"
                                        ValidationGroup="EmployeeValidation" InitialValue="0" CssClass="Validation"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Desiganation</label>
                                    <asp:DropDownList ID="ddlDesignation" runat="server" data-search="true" CssClass="form-control">
                                        <asp:ListItem Selected="True" Value="0">[Select]</asp:ListItem>
                                        <asp:ListItem Value="Teacher">Teacher</asp:ListItem>
                                        <asp:ListItem Value="Office Staff">Office Staff</asp:ListItem>
                                        <asp:ListItem Value="Ministrail Staff">Ministrial Staff</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlDesignation"
                                        ValidationGroup="EmployeeValidation" InitialValue="0" CssClass="Validation"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-6">
                                <div class="form-group">
                                    <label>Date Of Birth</label>
                                    <asp:TextBox ID="txtDob" runat="server" CssClass="form-control date-picker"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtDob"
                                        ValidationGroup="EmployeeValidation" CssClass="Validation"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Place Of Birth</label>
                                    <asp:TextBox ID="txtBirthPlace" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Date Of Joining</label>
                                    <asp:TextBox ID="txtDoj" runat="server" CssClass="form-control date-picker"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtDoj"
                                        ValidationGroup="EmployeeValidation" CssClass="Validation"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Pan Card No</label>
                                    <asp:TextBox ID="txtPancard" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Passport No</label>
                                    <asp:TextBox ID="txtPassport" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-6">
                                <div class="form-group">
                                    <label>Blood Group</label>
                                    <asp:TextBox ID="txtBloodgrp" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Religion</label>
                                    <asp:DropDownList ID="ddlReligion" runat="server" data-search="true" CssClass="form-control">
                                        <asp:ListItem Selected="True" Value="0">[Select]</asp:ListItem>
                                        <asp:ListItem Value="Hindu">Hindu</asp:ListItem>
                                        <asp:ListItem Value="Christian">Christian</asp:ListItem>
                                        <asp:ListItem Value="Muslim">Muslim</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlReligion"
                                        ValidationGroup="EmployeeValidation" InitialValue="0" CssClass="Validation"></asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <label>Cast</label>
                                    <asp:TextBox ID="txtCast" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>Salary</label>
                                    <asp:TextBox ID="txtSalary" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>EPF</label>
                                    <asp:TextBox ID="txtEpf" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3 col-sm-6">
                                <div class="form-group">
                                    <label>ESI</label>
                                    <asp:TextBox ID="txtEsi" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <div class="fileinput fileinput-new" data-provides="fileinput">
                                        <p><strong>Employee Image</strong></p>
                                        <div class="fileinput-new thumbnail">
                                            <asp:Image runat="server" ID="impSliderPrev" class="img-responsive" />
                                        </div>
                                        <div class="fileinput-preview fileinput-exists thumbnail"></div>
                                        <div>
                                            <span class="btn btn-default btn-file"><span class="fileinput-new">Select image...</span><span class="fileinput-exists">Change</span>
                                                <asp:FileUpload ID="fuImage" runat="server" onchange="ShowImagePreview(this);" />
                                                <asp:HiddenField runat="server" ID="hfEmpImg" />
                                            </span>
                                            <a href="#" class="btn btn-default fileinput-exists" data-dismiss="fileinput">Remove</a>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnContact" Visible="False">
                    <div class="panel-header">
                        <h4>(Step 2 of 5) Contact Info</h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Permanent Address</label>
                                    <asp:TextBox ID="txtPremAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="form-group">
                                    <label>Present Address</label>
                                    <asp:TextBox ID="txtPresAddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Email</label>
                                    <asp:TextBox ID="txtPremEmail" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Phone</label>
                                    <asp:TextBox ID="txtPremPhone" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Emergency Contact Name</label>
                                    <asp:TextBox ID="txtContName" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-3">
                                <div class="form-group">
                                    <label>Emergency Contact Mobile</label>
                                    <asp:TextBox ID="txtContMobile" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnQualification">
                    <div class="panel-header">
                        <h4>(Step 3 of 5) Qualification Info</h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="gvQualification" runat="server" CssClass="table table-bordered" ShowFooter="true" ShowHeader="true" AutoGenerateColumns="false" OnRowDataBound="gvQualification_OnRowDataBound" OnRowCommand="gvQualification_OnRowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Qualification">
                                            <ItemTemplate>
                                                <asp:DropDownList runat="server" ID="ddlQualification" CssClass="form-control">
                                                    <asp:ListItem Value="0">[Select]</asp:ListItem>
                                                    <asp:ListItem Value="SSLC">SSLC</asp:ListItem>
                                                    <asp:ListItem Value="HSC">HSC</asp:ListItem>
                                                    <asp:ListItem Value="Diploma">Diploma</asp:ListItem>
                                                    <asp:ListItem Value="UG">UG</asp:ListItem>
                                                    <asp:ListItem Value="PG">PG</asp:ListItem>
                                                    <asp:ListItem Value="B.Ed">B.Ed</asp:ListItem>
                                                    <asp:ListItem Value="Others">Others</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hfKeyvalue" runat="server" Value='<%#Eval("SYS_ID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Subject">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtSubject" CssClass="form-control" onfocus='javascript:this.select()' Text='<%#Eval("SUBJECT") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exam or Degree">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtDegree" CssClass="form-control" onfocus='javascript:this.select()' Text='<%#Eval("DEGREE") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name Of Institution">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtIntitution" CssClass="form-control" onfocus='javascript:this.select()' Text='<%#Eval("INSTUT") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Medium Of Instruction">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtMedium" CssClass="form-control" onfocus='javascript:this.select()' Text='<%#Eval("MEDIUM") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Year Of Pass" ItemStyle-Width="100px" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtYrPass" CssClass="form-control" onfocus='javascript:this.select()' Text='<%#Eval("PASS_YEAR") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Per(%)" ItemStyle-Width="100px" HeaderStyle-Width="100px">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtPercentage" CssClass="form-control" onfocus='javascript:this.select()' Text='<%#Eval("PERCENTAGE") %>'></asp:TextBox>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="btnRowAdd" runat="server" Text="Add" CssClass="btn btn-success btn-sm" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    CommandName="AddRow" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfdelete" runat="server" Value="0" />
                                                <asp:Label ID="lbldelete" Text="deleted" runat="server" CssClass="label label-danger"
                                                    Visible="false"></asp:Label>
                                                <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                    CommandName="Deleted" CssClass="btn btn-icon btn-danger"><i class="fa fa-trash"></i> </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnExperience">
                    <div class="panel-header">
                        <h4>(Step 4 of 5) Experience Info</h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="gvExperience" runat="server" CssClass="table table-bordered" ShowFooter="true" ShowHeader="true" AutoGenerateColumns="false" OnRowDataBound="gvExperience_OnRowDataBound" OnRowCommand="gvExperience_OnRowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="School">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtSchool" CssClass="form-control" onfocus='javascript:this.select()' Text='<%#Eval("SCHOOL") %>'></asp:TextBox>
                                                <asp:HiddenField ID="hfKeyvalue" runat="server" Value='<%#Eval("SYS_ID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="From">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtFrom" CssClass="form-control" onfocus='javascript:this.select()' Text='<%#Eval("FRM_DT") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="To">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtTo" CssClass="form-control" onfocus='javascript:this.select()' Text='<%#Eval("TO_DT") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Designation">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtDesignation" CssClass="form-control" onfocus='javascript:this.select()' Text='<%#Eval("DESIGNATION") %>'></asp:TextBox>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="btnRowAdd" runat="server" Text="Add" CssClass="btn btn-success btn-sm" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    CommandName="AddRow" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfdelete" runat="server" Value="0" />
                                                <asp:Label ID="lbldelete" Text="deleted" runat="server" CssClass="label label-danger"
                                                    Visible="false"></asp:Label>
                                                <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                    CommandName="Deleted" CssClass="btn btn-icon btn-danger"><i class="fa fa-trash"></i> </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel runat="server" ID="pnFamily">
                    <div class="panel-header">
                        <h4>(Step 5 of 5) Family Info</h4>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-md-12">
                                <asp:GridView ID="gvFamily" runat="server" CssClass="table table-bordered" ShowFooter="true" ShowHeader="true" AutoGenerateColumns="false" OnRowDataBound="gvFamily_OnRowDataBound" OnRowCommand="gvFamily_OnRowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Relation">
                                            <ItemTemplate>
                                                <asp:DropDownList runat="server" ID="ddlRelation" CssClass="form-control">
                                                    <asp:ListItem Value="0">[Select]</asp:ListItem>
                                                    <asp:ListItem Value="Spouse">Spouse</asp:ListItem>
                                                    <asp:ListItem Value="Child">Child</asp:ListItem>
                                                </asp:DropDownList>
                                                <asp:HiddenField ID="hfKeyvalue" runat="server" Value='<%#Eval("SYS_ID") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtName" CssClass="form-control" onfocus='javascript:this.select()' Text='<%#Eval("NAME") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Qualificaiton">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtQualificaiton" CssClass="form-control" onfocus='javascript:this.select()' Text='<%#Eval("QUALIFICATION") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Employer Name">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtEmployerName" CssClass="form-control" onfocus='javascript:this.select()' Text='<%#Eval("EMP_NAME") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Blood Grp">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtBloodGrp" CssClass="form-control" onfocus='javascript:this.select()' Text='<%#Eval("BG") %>'></asp:TextBox>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <asp:Button ID="btnRowAdd" runat="server" Text="Add" CssClass="btn btn-success btn-sm" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"
                                                    CommandName="AddRow" />
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Medical Problem">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtMedicalProblems" CssClass="form-control" onfocus='javascript:this.select()' Text='<%#Eval("MEDIC_PROBLEM") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Physical Disability">
                                            <ItemTemplate>
                                                <asp:TextBox runat="server" ID="txtPhyDisability" CssClass="form-control" onfocus='javascript:this.select()' Text='<%#Eval("PHY_DISABILITY") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-Width="50px" HeaderStyle-Width="50px" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfdelete" runat="server" Value="0" />
                                                <asp:Label ID="lbldelete" Text="deleted" runat="server" CssClass="label label-danger"
                                                    Visible="false"></asp:Label>
                                                <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                    CommandName="Deleted" CssClass="btn btn-icon btn-danger"><i class="fa fa-trash"></i> </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <div class="panel-footer">
                    <div class="row">
                        <div class="col-md-12 text-center">
                            <asp:LinkButton runat="server" ID="btnBack" CssClass="btn btn-sm btn-fb" ValidationGroup="EmployeeValidation" OnClick="btnBack_OnClick"><i class="fa fa-arrow-circle-left"></i>&nbsp;Back</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnNext" CssClass="btn btn-sm btn-fb" ValidationGroup="EmployeeValidation" OnClick="btnNext_OnClick">Next&nbsp;<i class="fa fa-arrow-circle-right"></i></asp:LinkButton>
                            &nbsp;|<asp:LinkButton runat="server" ID="btnSave" CssClass="btn btn-sm btn-success" OnClientClick="return Confirm_Msg(this,'Are you sure do you want to Save..?', 'EmployeeValidation');" OnClick="btnSave_OnClick"><i class="fa fa-save"></i>&nbsp;Save</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnCancel" OnClientClick="return Confirm_Msg(this,'Are you sure do you want to go back to List..?');" OnClick="btnCancel_OnClick" CssClass="btn btn-sm btn-danger">Cancel&nbsp;<i class="fa fa-crosshairs"></i></asp:LinkButton>
                            <asp:HiddenField runat="server" ID="hfKeyvalue" />
                        </div>
                    </div>
                </div>
            </div>
            <script type="text/javascript">
                    function ShowImagePreview(input) {
                        if (input.files && input.files[0]) {
                            var reader = new FileReader();
                            reader.onload = function (e) {
                                $('#<%:impSliderPrev.ClientID %>').prop('src', e.target.result)
                        .width(200)
                        .height(200);
                        };
                        reader.readAsDataURL(input.files[0]);
                        }
                    }
                    function SetImgSrc(Path) {
                        console.log(Path);
                        $('#<%:impSliderPrev.ClientID %>').prop('src', Path)
                    .width(200)
                    .height(200);
                    }
            </script>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnNext" />
        </Triggers>
    </asp:UpdatePanel>
</asp:Content>
