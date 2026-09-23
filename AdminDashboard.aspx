<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="AdminDashboard.aspx.cs"
    Inherits="Library_Management_System.AdminDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Admin Dashboard - Library Management System</title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
</head>

<body>

<form id="form1" runat="server">

    <!-- Navigation -->

    <div class="navbar">

        <div class="brand">
            Library Management System
        </div>

        <div>

            <asp:LinkButton ID="btnLogoutTop"
                runat="server"
                OnClick="btnLogout_Click"
                CausesValidation="false">
                Logout
            </asp:LinkButton>

        </div>

    </div>

    <!-- Main Content -->

    <div class="container">

        <div class="card">

            <h1 class="dashboard-title">
                Admin Dashboard
            </h1>

            <p class="dashboard-subtitle">
                Welcome,
                <asp:Label ID="lblWelcome"
                    runat="server">
                </asp:Label>
            </p>

            <p>
                Manage library books and system users.
            </p>

        </div>

        <div class="dashboard-grid">

            <!-- Manage Books -->

            <div class="dashboard-card">

                <h3>📚 Manage Books</h3>

                <p>
                    Add, view, update and delete
                    library books.
                </p>

                <asp:Button ID="btnManageBooks"
                    runat="server"
                    Text="Manage Books"
                    CssClass="btn btn-primary"
                    OnClick="btnManageBooks_Click" />

            </div>

            <!-- Manage Users -->

            <div class="dashboard-card">

                <h3>👥 Manage Users</h3>

                <p>
                    View users and manage their
                    account roles.
                </p>

                <asp:Button ID="btnManageUsers"
                    runat="server"
                    Text="Manage Users"
                    CssClass="btn btn-success"
                    OnClick="btnManageUsers_Click" />

            </div>

            <!-- View Books -->

            <div class="dashboard-card">

                <h3>🔎 View Books</h3>

                <p>
                    View the complete library
                    collection.
                </p>

                <asp:Button ID="btnViewBooks"
                    runat="server"
                    Text="View Books"
                    CssClass="btn btn-secondary"
                    OnClick="btnViewBooks_Click" />

            </div>

        </div>

    </div>

    <div class="footer">
        © 2026 Library Management System
    </div>

</form>

</body>
</html>