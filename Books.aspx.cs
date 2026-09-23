using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Library_Management_System
{
    public partial class Books : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            string role = Session["Role"]?.ToString();

            if (string.Equals(
                role,
                "Admin",
                StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("AdminDashboard.aspx");
                return;
            }

            if (!string.Equals(
                role,
                "User",
                StringComparison.OrdinalIgnoreCase))
            {
                Session.Clear();
                Session.Abandon();

                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadBooks("");
            }
        }

        private void LoadBooks(string search)
        {
            string connectionString =
                ConfigurationManager
                .ConnectionStrings[
                    "LibraryManagementConnection"]
                .ConnectionString;

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

            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            using (SqlCommand command =
                   new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue(
                    "@Search",
                    "%" + search + "%");

                using (SqlDataAdapter adapter =
                       new SqlDataAdapter(command))
                {
                    DataTable table = new DataTable();

                    adapter.Fill(table);

                    gvBooks.DataSource = table;
                    gvBooks.DataBind();
                }
            }
        }

        protected void btnSearch_Click(
            object sender,
            EventArgs e)
        {
            LoadBooks(txtSearch.Text.Trim());
        }

        protected void btnClear_Click(
            object sender,
            EventArgs e)
        {
            txtSearch.Text = "";

            LoadBooks("");
        }

        protected void btnBack_Click(
            object sender,
            EventArgs e)
        {
            Response.Redirect("Dashboard.aspx");
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