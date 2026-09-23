<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Login.aspx.cs"
    Inherits="Library_Management_System.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login - Library Management System</title>

    <link href="Style.css" rel="stylesheet" type="text/css" />
</head>

<body>

    <form id="form1" runat="server">

        <div class="auth-container">

            <div class="card">

                <h1 class="auth-title">
                    Library Management System
                </h1>

                <h2 class="auth-title">
                    Login
                </h2>

                <div class="form-group">

                    <asp:Label ID="lblEmail"
                        runat="server"
                        Text="Email">
                    </asp:Label>

                    <asp:TextBox ID="txtEmail"
                        runat="server"
                        CssClass="form-control"
                        TextMode="Email">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator
                        ID="rfvEmail"
                        runat="server"
                        ControlToValidate="txtEmail"
                        ErrorMessage="Email is required."
                        CssClass="validation-error"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>

                </div>

                <div class="form-group">

                    <asp:Label ID="lblPassword"
                        runat="server"
                        Text="Password">
                    </asp:Label>

                    <asp:TextBox ID="txtPassword"
                        runat="server"
                        CssClass="form-control"
                        TextMode="Password">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator
                        ID="rfvPassword"
                        runat="server"
                        ControlToValidate="txtPassword"
                        ErrorMessage="Password is required."
                        CssClass="validation-error"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>

                </div>

                <asp:Label ID="lblMessage"
                    runat="server"
                    CssClass="message error-message">
                </asp:Label>

                <div class="form-group">

                    <asp:Button ID="btnLogin"
                        runat="server"
                        Text="Login"
                        CssClass="btn btn-primary"
                        OnClick="btnLogin_Click" />

                </div>

                <div style="text-align:center;">

                    <span>Don't have an account?</span>

                    <asp:HyperLink ID="lnkRegister"
                        runat="server"
                        NavigateUrl="Register.aspx">
                        Register
                    </asp:HyperLink>

                </div>

            </div>

        </div>

    </form>

</body>
</html>