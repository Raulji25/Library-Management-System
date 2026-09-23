<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Dashboard.aspx.cs"
    Inherits="Library_Management_System.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Dashboard - Library Management System</title>
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
            <asp:HyperLink ID="lnkBooks"
                runat="server"
                NavigateUrl="Books.aspx">
                Books
            </asp:HyperLink>

            <asp:LinkButton ID="btnLogout"
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
                Welcome,
                <asp:Label ID="lblWelcome"
                    runat="server">
                </asp:Label>
            </h1>

            <p class="dashboard-subtitle">
                Manage and view available library books.
            </p>

        </div>

        <div class="dashboard-grid">

            <!-- Books -->

            <div class="dashboard-card">

                <h3>📚 Library Books</h3>

                <p>
                    View and search all available books
                    in the library.
                </p>

                <asp:Button ID="btnBooks"
                    runat="server"
                    Text="View Books"
                    CssClass="btn btn-primary"
                    OnClick="btnBooks_Click" />

            </div>

            <!-- Account -->

            <div class="dashboard-card">

                <h3>👤 My Account</h3>

                <p>
                    You are logged in as a library user.
                </p>

                <asp:Button ID="btnLogoutCard"
                    runat="server"
                    Text="Logout"
                    CssClass="btn btn-secondary"
                    OnClick="btnLogout_Click"
                    CausesValidation="false" />

            </div>

        </div>

    </div>

    <!-- Footer -->

    <div class="footer">
        © 2026 Library Management System
    </div>

</form>

</body>
</html>