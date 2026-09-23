using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class AddBook : System.Web.UI.Page
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
        }


        protected void btnAddBook_Click(
            object sender,
            EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }


            string bookName =
                txtBookName.Text.Trim();

            string author =
                txtAuthor.Text.Trim();

            string category =
                txtCategory.Text.Trim();

            string isbn =
                txtISBN.Text.Trim();

            int quantity;

            if (!int.TryParse(
                txtQuantity.Text.Trim(),
                out quantity))
            {
                lblMessage.Text =
                    "Please enter a valid quantity.";

                lblMessage.CssClass =
                    "message error-message";

                return;
            }


            try
            {
                using (SqlConnection con =
                       new SqlConnection(connectionString))
                {
                    string query = @"
                        INSERT INTO Books
                        (
                            BookName,
                            Author,
                            Category,
                            ISBN,
                            Quantity
                        )
                        VALUES
                        (
                            @BookName,
                            @Author,
                            @Category,
                            @ISBN,
                            @Quantity
                        )";


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


                        con.Open();

                        cmd.ExecuteNonQuery();
                    }
                }


                lblMessage.Text =
                    "Book added successfully.";

                lblMessage.CssClass =
                    "message success-message";


                txtBookName.Text = "";
                txtAuthor.Text = "";
                txtCategory.Text = "";
                txtISBN.Text = "";
                txtQuantity.Text = "";
            }
            catch (Exception)
            {
                lblMessage.Text =
                    "Unable to add the book. Please try again.";

                lblMessage.CssClass =
                    "message error-message";
            }
        }


        protected void btnCancel_Click(
            object sender,
            EventArgs e)
        {
            Response.Redirect("ManageBooks.aspx");
        }


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