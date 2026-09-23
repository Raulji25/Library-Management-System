using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Library_Management_System
{
    public partial class ManageUsers : System.Web.UI.Page
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
                LoadUsers();
            }
        }


        // Load users
        private void LoadUsers()
        {
            using (SqlConnection con =
                   new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT
                        UserId,
                        Name,
                        Email,
                        Role
                    FROM Users
                    ORDER BY UserId";


                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    using (SqlDataAdapter da =
                           new SqlDataAdapter(cmd))
                    {
                        DataTable dt =
                            new DataTable();

                        da.Fill(dt);

                        gvUsers.DataSource = dt;
                        gvUsers.DataBind();
                    }
                }
            }
        }


        // Edit user
        protected void gvUsers_RowEditing(
    object sender,
    GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;

            LoadUsers();

            int userId =
                Convert.ToInt32(
                    gvUsers.DataKeys[e.NewEditIndex].Value);

            using (SqlConnection con =
                   new SqlConnection(connectionString))
            {
                string query = @"
            SELECT Role
            FROM Users
            WHERE UserId = @UserId";

                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@UserId",
                        userId);

                    con.Open();

                    object result =
                        cmd.ExecuteScalar();

                    string currentRole =
                        result?.ToString();

                    GridViewRow row =
                        gvUsers.Rows[e.NewEditIndex];

                    DropDownList ddlRole =
                        row.FindControl("ddlRole")
                        as DropDownList;

                    if (ddlRole != null &&
                        !string.IsNullOrEmpty(currentRole))
                    {
                        ddlRole.SelectedValue =
                            currentRole;
                    }
                }
            }
        }


        // Cancel editing
        protected void gvUsers_RowCancelingEdit(
            object sender,
            GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;

            LoadUsers();
        }


        // Update role
        protected void gvUsers_RowUpdating(
            object sender,
            GridViewUpdateEventArgs e)
        {
            int userId =
                Convert.ToInt32(
                    gvUsers.DataKeys[e.RowIndex].Value);


            GridViewRow row =
                gvUsers.Rows[e.RowIndex];


            DropDownList ddlRole =
                row.FindControl("ddlRole")
                as DropDownList;


            if (ddlRole == null)
            {
                return;
            }


            string newRole =
                ddlRole.SelectedValue;


            // Prevent changing your own role
            int currentUserId =
                Convert.ToInt32(
                    Session["UserId"]);


            if (userId == currentUserId)
            {
                lblMessage.Text =
                    "You cannot change your own role.";

                lblMessage.CssClass =
                    "message error-message";

                gvUsers.EditIndex = -1;

                LoadUsers();

                return;
            }


            using (SqlConnection con =
                   new SqlConnection(connectionString))
            {
                string query = @"
                    UPDATE Users
                    SET Role = @Role
                    WHERE UserId = @UserId";


                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@Role",
                        newRole);

                    cmd.Parameters.AddWithValue(
                        "@UserId",
                        userId);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }


            gvUsers.EditIndex = -1;

            lblMessage.Text =
                "User role updated successfully.";

            lblMessage.CssClass =
                "message success-message";

            LoadUsers();
        }


        // Delete user
        protected void gvUsers_RowDeleting(
            object sender,
            GridViewDeleteEventArgs e)
        {
            int userId =
                Convert.ToInt32(
                    gvUsers.DataKeys[e.RowIndex].Value);


            int currentUserId =
                Convert.ToInt32(
                    Session["UserId"]);


            // Prevent self-delete
            if (userId == currentUserId)
            {
                lblMessage.Text =
                    "You cannot delete your own account.";

                lblMessage.CssClass =
                    "message error-message";

                return;
            }


            using (SqlConnection con =
                   new SqlConnection(connectionString))
            {
                string query = @"
                    DELETE FROM Users
                    WHERE UserId = @UserId";


                using (SqlCommand cmd =
                       new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue(
                        "@UserId",
                        userId);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }


            lblMessage.Text =
                "User deleted successfully.";

            lblMessage.CssClass =
                "message success-message";

            LoadUsers();
        }


        // Back
        protected void btnBack_Click(
            object sender,
            EventArgs e)
        {
            Response.Redirect(
                "AdminDashboard.aspx");
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