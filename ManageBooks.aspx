<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="ManageBooks.aspx.cs"
    Inherits="Library_Management_System.ManageBooks" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Manage Books - Library Management System</title>
    <link href="Style.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <nav class="navbar">
            <div class="brand">Library Management System</div>

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

            <h1 class="dashboard-title">Manage Books</h1>

            <p class="dashboard-subtitle">
                Add, edit, search and delete library books.
            </p>

            <div class="card">

                <div class="search-box">

                    <asp:TextBox
                        ID="txtSearch"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Search by book name, author, category or ISBN">
                    </asp:TextBox>

                    <asp:Button
                        ID="btnSearch"
                        runat="server"
                        Text="Search"
                        CssClass="btn btn-primary"
                        OnClick="btnSearch_Click" />

                    <asp:Button
                        ID="btnClear"
                        runat="server"
                        Text="Clear"
                        CssClass="btn btn-secondary"
                        OnClick="btnClear_Click" />

                    <asp:Button
                        ID="btnAddBook"
                        runat="server"
                        Text="+ Add New Book"
                        CssClass="btn btn-success"
                        OnClick="btnAddBook_Click" />

                </div>

                <asp:Label
                    ID="lblMessage"
                    runat="server"
                    CssClass="message">
                </asp:Label>

                <br />

                <asp:GridView
                    ID="gvBooks"
                    runat="server"
                    AutoGenerateColumns="False"
                    CssClass="data-table"
                    DataKeyNames="BookId"
                    EmptyDataText="No books found."
                    OnRowEditing="gvBooks_RowEditing"
                    OnRowCancelingEdit="gvBooks_RowCancelingEdit"
                    OnRowUpdating="gvBooks_RowUpdating"
                    OnRowDeleting="gvBooks_RowDeleting">

                    <Columns>

                        <asp:BoundField
                            DataField="BookId"
                            HeaderText="ID"
                            ReadOnly="True" />

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