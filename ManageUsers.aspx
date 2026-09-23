<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="ManageUsers.aspx.cs"
    Inherits="Library_Management_System.ManageUsers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Users - Library Management System</title>
    <link href="Style.css" rel="stylesheet" />
</head>

<body>

<form id="form1" runat="server">

    <nav class="navbar">

        <div class="brand">
            Library Management System
        </div>

        <div>

            <asp:HyperLink
                ID="lnkDashboard"
                runat="server"
                NavigateUrl="AdminDashboard.aspx"
                CssClass="nav-link">
                Dashboard
            </asp:HyperLink>

            <asp:Button
                ID="btnLogout"
                runat="server"
                Text="Logout"
                CssClass="btn btn-danger"
                OnClick="btnLogout_Click" />

        </div>

    </nav>


    <div class="container">

        <h1 class="dashboard-title">
            Manage Users
        </h1>

        <p class="dashboard-subtitle">
            View users and manage their roles.
        </p>


        <div class="card">

            <asp:Label
                ID="lblMessage"
                runat="server"
                CssClass="message">
            </asp:Label>

            <br />

            <asp:GridView
                ID="gvUsers"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="data-table"
                DataKeyNames="UserId"
                EmptyDataText="No users found."
                OnRowEditing="gvUsers_RowEditing"
                OnRowCancelingEdit="gvUsers_RowCancelingEdit"
                OnRowUpdating="gvUsers_RowUpdating"
                OnRowDeleting="gvUsers_RowDeleting">

                <Columns>

                    <asp:BoundField
                        DataField="UserId"
                        HeaderText="ID"
                        ReadOnly="True" />

                    <asp:BoundField
                        DataField="Name"
                        HeaderText="Name"
                        ReadOnly="True" />

                    <asp:BoundField
                        DataField="Email"
                        HeaderText="Email"
                        ReadOnly="True" />

                    <asp:TemplateField HeaderText="Role">

                        <ItemTemplate>

                            <%# Eval("Role") %>

                        </ItemTemplate>

                        <EditItemTemplate>

                            <asp:DropDownList
                                ID="ddlRole"
                                runat="server"
                                CssClass="form-control">

                                <asp:ListItem
                                    Text="User"
                                    Value="User">
                                </asp:ListItem>

                                <asp:ListItem
                                    Text="Admin"
                                    Value="Admin">
                                </asp:ListItem>

                            </asp:DropDownList>

                        </EditItemTemplate>

                    </asp:TemplateField>


                    <asp:CommandField
                        ShowEditButton="True"
                        ShowDeleteButton="True"
                        HeaderText="Actions" />

                </Columns>

            </asp:GridView>


            <br />

            <asp:Button
                ID="btnBack"
                runat="server"
                Text="Back to Admin Dashboard"
                CssClass="btn btn-secondary"
                OnClick="btnBack_Click" />

        </div>

    </div>


    <footer class="footer">
        Library Management System
    </footer>

</form>

</body>
</html>