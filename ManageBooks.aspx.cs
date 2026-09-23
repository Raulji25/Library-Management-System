using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.WebControls;

namespace Library_Management_System
{
    public partial class ManageBooks : System.Web.UI.Page
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings[
                "LibraryManagementConnection"
            ].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {
            // Check login
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            // Check Admin role
            string role = Session["Role"]?.ToString();

            if (!string.Equals(
                role,
                "Admin",
                StringComparison.OrdinalIgnoreCase))
            {
                if (string.Equals(
                    role,
                    "User",
                    StringComparison.OrdinalIgnoreCase))
                {
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    Session.Clear();
                    Session.Abandon();

                    Response.Redirect("Login.aspx");
                }

                return;
            }

            if (!IsPostBack)
            {
                LoadBooks("");
            }
        }


        // Load books
        private void LoadBooks(string search)
        {
            using (SqlConnection con =
                   new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT
                        BookId,
                        BookName,
                        Author,
                        Category,
                        ISBN,
                        Quantity
                    FROM Books
                    WHERE
                        BookName LIKE @Search
                        OR Author LIKE @Search
                        OR Category LIKE @Search
                        OR ISBN LIKE @Search
                    ORDER BY BookName";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@Search",
                        "%" + search + "%");

                    using (SqlDataAdapter da =
                           new SqlDataAdapter(cmd))
                    {
                        DataTable dt = new DataTable();

                        da.Fill(dt);

                        gvBooks.DataSource = dt;
                        gvBooks.DataBind();
                    }
                }
            }
        }


        // Search
        protected void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            LoadBooks(txtSearch.Text.Trim());
        }


        // Clear search
        protected void btnClear_Click(
            object sender,
            EventArgs e)
        {
            txtSearch.Text = "";

            lblMessage.Text = "";

            LoadBooks("");
        }


        // Add new book
        protected void btnAddBook_Click(
            object sender,
            EventArgs e)
        {
            Response.Redirect("AddBook.aspx");
        }


        // Edit mode
        protected void gvBooks_RowEditing(
            object sender,
            GridViewEditEventArgs e)
        {
            gvBooks.EditIndex = e.NewEditIndex;

            LoadBooks(txtSearch.Text.Trim());
        }


        // Cancel edit
        protected void gvBooks_RowCancelingEdit(
            object sender,
            GridViewCancelEditEventArgs e)
        {
            gvBooks.EditIndex = -1;

            LoadBooks(txtSearch.Text.Trim());
        }


        // Update book
        protected void gvBooks_RowUpdating(
            object sender,
            GridViewUpdateEventArgs e)
        {
            int bookId =
                Convert.ToInt32(
                    gvBooks.DataKeys[e.RowIndex].Value);

            GridViewRow row =
                gvBooks.Rows[e.RowIndex];

            string bookName =
                ((TextBox)row.Cells[1].Controls[0])
                .Text.Trim();

            string author =
                ((TextBox)row.Cells[2].Controls[0])
                .Text.Trim();

            string category =
                ((TextBox)row.Cells[3].Controls[0])
                .Text.Trim();

            string isbn =
                ((TextBox)row.Cells[4].Controls[0])
                .Text.Trim();

            string quantityText =
                ((TextBox)row.Cells[5].Controls[0])
                .Text.Trim();


            if (string.IsNullOrWhiteSpace(bookName) ||
                string.IsNullOrWhiteSpace(author))
            {
                lblMessage.Text =
                    "Book name and author are required.";

                lblMessage.CssClass =
                    "message error-message";

                return;
            }


            int quantity;

            if (!int.TryParse(
                quantityText,
                out quantity) ||
                quantity < 0)
            {
                lblMessage.Text =
                    "Quantity must be a valid number greater than or equal to 0.";

                lblMessage.CssClass =
                    "message error-message";

                return;
            }


            using (SqlConnection con =
                   new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE Books
                    SET
                        BookName = @BookName,
                        Author = @Author,
                        Category = @Category,
                        ISBN = @ISBN,
                        Quantity = @Quantity
                    WHERE BookId = @BookId";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@BookName",
                        bookName);

                    cmd.Parameters.AddWithValue(
                        "@Author",
                        author);

                    cmd.Parameters.AddWithValue(
                        "@Category",
                        string.IsNullOrWhiteSpace(category)
                            ? (object)DBNull.Value
                            : category);

                    cmd.Parameters.AddWithValue(
                        "@ISBN",
                        string.IsNullOrWhiteSpace(isbn)
                            ? (object)DBNull.Value
                            : isbn);

                    cmd.Parameters.AddWithValue(
                        "@Quantity",
                        quantity);

                    cmd.Parameters.AddWithValue(
                        "@BookId",
                        bookId);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }


            gvBooks.EditIndex = -1;

            lblMessage.Text =
                "Book updated successfully.";

            lblMessage.CssClass =
                "message success-message";

            LoadBooks(txtSearch.Text.Trim());
        }


        // Delete book
        protected void gvBooks_RowDeleting(
            object sender,
            GridViewDeleteEventArgs e)
        {
            int bookId =
                Convert.ToInt32(
                    gvBooks.DataKeys[e.RowIndex].Value);


            using (SqlConnection con =
                   new SqlConnection(connectionString))
            {
                string query = @"
                    DELETE FROM Books
                    WHERE BookId = @BookId";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@BookId",
                        bookId);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }


            lblMessage.Text =
                "Book deleted successfully.";

            lblMessage.CssClass =
                "message success-message";

            LoadBooks(txtSearch.Text.Trim());
        }


        // Back to dashboard
        protected void btnBack_Click(
            object sender,
            EventArgs e)
        {
            Response.Redirect("AdminDashboard.aspx");
        }


        // Logout
        protected void btnLogout_Click(
            object sender,
            EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("Login.aspx");
        }
    }
}