<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Register.aspx.cs"
    Inherits="Library_Management_System.Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Register - Library Management System</title>
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
                Create Account
            </h2>

            <!-- Name -->

            <div class="form-group">

                <asp:Label ID="lblName"
                    runat="server"
                    Text="Full Name">
                </asp:Label>

                <asp:TextBox ID="txtName"
                    runat="server"
                    CssClass="form-control">
                </asp:TextBox>

                <asp:RequiredFieldValidator
                    ID="rfvName"
                    runat="server"
                    ControlToValidate="txtName"
                    ErrorMessage="Name is required."
                    CssClass="validation-error"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>

            </div>

            <!-- Email -->

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

            <!-- Password -->

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

            <!-- Confirm Password -->

            <div class="form-group">

                <asp:Label ID="lblConfirmPassword"
                    runat="server"
                    Text="Confirm Password">
                </asp:Label>

                <asp:TextBox ID="txtConfirmPassword"
                    runat="server"
                    CssClass="form-control"
                    TextMode="Password">
                </asp:TextBox>

                <asp:RequiredFieldValidator
                    ID="rfvConfirmPassword"
                    runat="server"
                    ControlToValidate="txtConfirmPassword"
                    ErrorMessage="Please confirm your password."
                    CssClass="validation-error"
                    Display="Dynamic">
                </asp:RequiredFieldValidator>

                <asp:CompareValidator
                    ID="cvPassword"
                    runat="server"
                    ControlToValidate="txtConfirmPassword"
                    ControlToCompare="txtPassword"
                    ErrorMessage="Passwords do not match."
                    CssClass="validation-error"
                    Display="Dynamic">
                </asp:CompareValidator>

            </div>

            <!-- Message -->

            <asp:Label ID="lblMessage"
                runat="server"
                CssClass="message">
            </asp:Label>

            <!-- Register Button -->

            <div class="form-group">

                <asp:Button ID="btnRegister"
                    runat="server"
                    Text="Create Account"
                    CssClass="btn btn-primary"
                    OnClick="btnRegister_Click" />

            </div>

            <div style="text-align:center;">

                <span>Already have an account?</span>

                <asp:HyperLink ID="lnkLogin"
                    runat="server"
                    NavigateUrl="Login.aspx">
                    Login
                </asp:HyperLink>

            </div>

        </div>

    </div>

</form>

</body>
</html>