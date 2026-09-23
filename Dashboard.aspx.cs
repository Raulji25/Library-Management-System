using System;

namespace Library_Management_System
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check whether user is logged in
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            string role = Session["Role"]?.ToString();

            // Admin should use Admin Dashboard
            if (string.Equals(
                role,
                "Admin",
                StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("AdminDashboard.aspx");
                return;
            }

            // Only normal users can access this page
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
                lblWelcome.Text =
                    Session["UserName"]?.ToString();
            }
        }

        protected void btnBooks_Click(
            object sender,
            EventArgs e)
        {
            Response.Redirect("Books.aspx");
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