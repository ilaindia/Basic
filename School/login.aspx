<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="School.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - MVM School</title>
    <webopt:BundleReference ValidateRequestMode="Enabled" runat="server" Path="~/Content/Login" />
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/jquery") %>
    </asp:PlaceHolder>
    <style>
        .select2-choice:hover {
            color: #000 !important;
        }
    </style>
</head>
<body class="account" data-page="login">
    <!-- BEGIN LOGIN BOX -->
    <div class="container" id="login-block">
        <div class="row">
            <div class="col-sm-6 col-md-4 col-md-offset-4">
                <div class="account-wall">
                    <form id="lgForm" runat="server">
                        <asp:ScriptManager runat="server" ID="sm"></asp:ScriptManager>
                        <asp:UpdateProgress ID="upProgress" AssociatedUpdatePanelID="upAsync" runat="server">
                            <ProgressTemplate>
                                <Guru:Progressbar ID="prg" runat="server" />
                            </ProgressTemplate>
                        </asp:UpdateProgress>
                        <asp:UpdatePanel ID="upAsync" runat="server">
                            <ContentTemplate>
                                <i class="user-img icons-faces-users-03"></i>
                                <div class="form-signin" role="form">
                                    <div class="form-group">
                                        <div class="append-icon">
                                            <asp:TextBox ID="txtUserName" runat="server" CssClass="form-control form-white username" placeholder="Username"></asp:TextBox>
                                            <i class="icon-user"></i>
                                        </div>
                                    </div>
                                    <div class="form-group">
                                        <div class="append-icon m-b-20">
                                            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" CssClass="form-control form-white password" placeholder="Password"></asp:TextBox>
                                            <i class="icon-lock"></i>
                                        </div>
                                    </div>
                                    <asp:LinkButton ID="btnLogin" runat="server" CssClass="btn btn-lg btn-danger btn-block ladda-button" OnClick="btnLogin_Click" data-style="expand-left">Sign In</asp:LinkButton>
                                    <div class="clearfix">
                                        <p class="pull-left m-t-20"><a id="password" href="#" onclick="return forgetPassword();">Forgot password?</a></p>
                                    </div>
                                </div>
                                <div class="form-password" role="form">
                                    <div class="append-icon m-b-20">
                                        <asp:TextBox CssClass="form-control form-white username" ID="txtUsernameForget" placeholder="Username" required runat="server"></asp:TextBox>
                                        <i class="icon-lock"></i>
                                    </div>
                                    <asp:LinkButton ID="btnForgotPassword" runat="server" OnClick="btnForgotPassword_OnClickd_Click" CssClass="btn btn-lg btn-danger btn-block ladda-button" data-style="expand-left">Send Password Reset Link</asp:LinkButton>
                                    <div class="clearfix">
                                        <p class="pull-left m-t-20"><a id="login" href="#" onclick="return signIn()">Sign In</a></p>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </form>
                </div>
            </div>
        </div>
        <p class="account-copyright">
            <span>Copyright © <%:DateTime.Now.Year.ToString() %> </span><span>Saravanan-B.Tech (IT)</span>.<span>All rights reserved.</span>
        </p>
    </div>
    <asp:PlaceHolder runat="server">
        <%: Scripts.Render("~/bundles/Login") %>
    </asp:PlaceHolder>
    <script type="text/javascript">

        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(Init);
        function Error_Msg(msg) {
            swal({
                title: '<span style="color:#DD6B55">Please Confirm</span>',
                text: msg,
                showCancelButton: false,
                confirmButtonColor: '#3CA2BB',
                confirmButtonText: 'OK',
                closeOnConfirm: true
            });
        }
        $(document).ready(function () {
            Init();
        });
        function Init() {
            if ($.fn.select2) {
                setTimeout(function () {
                    $('select').each(function () {
                        function format(state) {
                            var state_id = state.id;
                            if (!state_id) return state.text; // optgroup
                            var res = state_id.split("-");
                            if (res[0] == 'image') {
                                if (res[2]) return "<img class='flag' src='assets/images/flags/" + res[1].toLowerCase() + "-" + res[2].toLowerCase() + ".png' style='width:27px;padding-right:10px;margin-top: -3px;'/>" + state.text;
                                else return "<img class='flag' src='assets/images/flags/" + res[1].toLowerCase() + ".png' style='width:27px;padding-right:10px;margin-top: -3px;'/>" + state.text;
                            }
                            else {
                                return state.text;
                            }
                        }
                        $(this).select2({
                            formatResult: format,
                            formatSelection: format,
                            placeholder: $(this).data('placeholder') ? $(this).data('placeholder') : '',
                            allowClear: $(this).data('allowclear') ? $(this).data('allowclear') : true,
                            minimumInputLength: $(this).data('minimumInputLength') ? $(this).data('minimumInputLength') : -1,
                            minimumResultsForSearch: $(this).data('search') ? 1 : -1,
                            dropdownCssClass: $(this).data('style') ? 'form-white' : ''
                        });
                    });
                }, 200);
            }
        }
        function forgetPassword() {
            $('.form-signin').slideUp(300, function () {
                $('.form-password').slideDown(300);
            });
            return false;
        }
        function signIn() {
            $('.form-password').slideUp(300, function () {
                $('.form-signin').slideDown(300);
            });
            return false;
        }
    </script>
</body>
</html>
