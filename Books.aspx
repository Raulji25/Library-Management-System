<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="Books.aspx.cs"
    Inherits="Library_Management_System.Books" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Books - Library Management System</title>
    <link href="Style.css" rel="stylesheet" type="text/css" />
</head>

<body>

<form id="form1" runat="server">

    <div class="navbar">

        <div class="brand">
            Library Management System
        </div>

        <div>
            <asp:HyperLink ID="lnkDashboard"
                runat="server"
                NavigateUrl="Dashboard.aspx">
                Dashboard
            </asp:HyperLink>

            <asp:LinkButton ID="btnLogout"
                runat="server"
                OnClick="btnLogout_Click"
                CausesValidation="false">
                Logout
            </asp:LinkButton>
        </div>

    </div>

    <div class="container">

        <div class="card">

            <h1>Library Books</h1>

            <p class="dashboard-subtitle">
                View and search available books.
            </p>

            <div class="search-box">

                <asp:TextBox ID="txtSearch"
                    runat="server"
                    CssClass="form-control"
                    placeholder="Search by book, author, category or ISBN">
                </asp:TextBox>

                <asp:Button ID="btnSearch"
                    runat="server"
                    Text="Search"
                    CssClass="btn btn-primary"
                    OnClick="btnSearch_Click" />

                <asp:Button ID="btnClear"
                    runat="server"
                    Text="Clear"
                    CssClass="btn btn-secondary"
                    OnClick="btnClear_Click"
                    CausesValidation="false" />

            </div>

            <asp:GridView ID="gvBooks"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="data-table"
                EmptyDataText="No books found.">

                <Columns>

                    <asp:BoundField
                        DataField="BookId"
                        HeaderText="ID" />

                    <asp:BoundField
                        DataField="BookName"
                        HeaderText="Book Name" />

                    <asp:BoundField
                        DataField="Author"
                        HeaderText="Author" />

                    <asp:BoundField
                        DataField="Category"
                        HeaderText="Category" />

                    <asp:BoundField
                        DataField="ISBN"
                        HeaderText="ISBN" />

                    <asp:BoundField
                        DataField="Quantity"
                        HeaderText="Quantity" />

                </Columns>

            </asp:GridView>

            <br />

            <asp:Button ID="btnBack"
                runat="server"
                Text="Back to Dashboard"
                CssClass="btn btn-secondary"
                OnClick="btnBack_Click"
                CausesValidation="false" />

        </div>

    </div>

    <div class="footer">
        © 2026 Library Management System
    </div>

</form>

</body>
</html>