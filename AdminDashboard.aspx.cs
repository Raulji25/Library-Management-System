using System;

namespace Library_Management_System
{
    public partial class AdminDashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

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
                lblWelcome.Text =
                    Session["UserName"]?.ToString();
            }
        }

        protected void btnManageBooks_Click(
            object sender,
            EventArgs e)
        {
            Response.Redirect("ManageBooks.aspx");
        }

        protected void btnManageUsers_Click(
            object sender,
            EventArgs e)
        {
            Response.Redirect("ManageUsers.aspx");
        }

        protected void btnViewBooks_Click(
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