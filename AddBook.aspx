<%@ Page Language="C#" AutoEventWireup="true"
    CodeBehind="AddBook.aspx.cs"
    Inherits="Library_Management_System.AddBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Add Book - Library Management System</title>
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

        <div class="auth-container">

            <div class="card">

                <h1 class="auth-title">
                    Add New Book
                </h1>

                <p class="dashboard-subtitle">
                    Enter the details of the new book.
                </p>


                <!-- Book Name -->

                <div class="form-group">

                    <label>Book Name</label>

                    <asp:TextBox
                        ID="txtBookName"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Enter book name">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator
                        ID="rfvBookName"
                        runat="server"
                        ControlToValidate="txtBookName"
                        ErrorMessage="Book name is required."
                        CssClass="validation-error"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>

                </div>


                <!-- Author -->

                <div class="form-group">

                    <label>Author</label>

                    <asp:TextBox
                        ID="txtAuthor"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Enter author name">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator
                        ID="rfvAuthor"
                        runat="server"
                        ControlToValidate="txtAuthor"
                        ErrorMessage="Author is required."
                        CssClass="validation-error"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>

                </div>


                <!-- Category -->

                <div class="form-group">

                    <label>Category</label>

                    <asp:TextBox
                        ID="txtCategory"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Example: Programming">
                    </asp:TextBox>

                </div>


                <!-- ISBN -->

                <div class="form-group">

                    <label>ISBN</label>

                    <asp:TextBox
                        ID="txtISBN"
                        runat="server"
                        CssClass="form-control"
                        placeholder="Enter ISBN">
                    </asp:TextBox>

                </div>


                <!-- Quantity -->

                <div class="form-group">

                    <label>Quantity</label>

                    <asp:TextBox
                        ID="txtQuantity"
                        runat="server"
                        CssClass="form-control"
                        TextMode="Number"
                        placeholder="Enter quantity">
                    </asp:TextBox>

                    <asp:RequiredFieldValidator
                        ID="rfvQuantity"
                        runat="server"
                        ControlToValidate="txtQuantity"
                        ErrorMessage="Quantity is required."
                        CssClass="validation-error"
                        Display="Dynamic">
                    </asp:RequiredFieldValidator>

                    <asp:RangeValidator
                        ID="rvQuantity"
                        runat="server"
                        ControlToValidate="txtQuantity"
                        MinimumValue="0"
                        MaximumValue="100000"
                        Type="Integer"
                        ErrorMessage="Quantity must be 0 or greater."
                        CssClass="validation-error"
                        Display="Dynamic">
                    </asp:RangeValidator>

                </div>


                <!-- Message -->

                <asp:Label
                    ID="lblMessage"
                    runat="server"
                    CssClass="message">
                </asp:Label>


                <br />


                <!-- Buttons -->

                <asp:Button
                    ID="btnAddBook"
                    runat="server"
                    Text="Add Book"
                    CssClass="btn btn-success"
                    OnClick="btnAddBook_Click" />

                <asp:Button
                    ID="btnCancel"
                    runat="server"
                    Text="Cancel"
                    CssClass="btn btn-secondary"
                    CausesValidation="false"
                    OnClick="btnCancel_Click" />

            </div>

        </div>

    </div>


    <footer class="footer">
        Library Management System
    </footer>

</form>

</body>
</html>