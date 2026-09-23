using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Web.UI;

namespace Library_Management_System
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
                return;

            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            string connectionString =
                ConfigurationManager
                    .ConnectionStrings["LibraryManagementConnection"]
                    .ConnectionString;

            string query = @"
                SELECT UserId, Name, Email, PasswordHash, Role
                FROM Users
                WHERE Email = @Email";

            using (SqlConnection connection =
                   new SqlConnection(connectionString))
            using (SqlCommand command =
                   new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@Email", email);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedHash =
                            reader["PasswordHash"].ToString();

                        if (VerifyPassword(password, storedHash))
                        {
                            Session["UserId"] = reader["UserId"].ToString();
                            Session["UserName"] = reader["Name"].ToString();
                            Session["Email"] = reader["Email"].ToString();
                            Session["Role"] = reader["Role"].ToString();

                            if (string.Equals(
                                reader["Role"].ToString(),
                                "Admin",
                                StringComparison.OrdinalIgnoreCase))
                            {
                                Response.Redirect("AdminDashboard.aspx");
                            }
                            else
                            {
                                Response.Redirect("Dashboard.aspx");
                            }

                            return;
                        }
                    }
                }
            }

            lblMessage.Text = "Invalid email or password.";
        }

        private bool VerifyPassword(
            string password,
            string storedPassword)
        {
            try
            {
                string[] parts = storedPassword.Split(':');

                if (parts.Length != 2)
                    return false;

                byte[] salt =
                    Convert.FromBase64String(parts[0]);

                byte[] storedHash =
                    Convert.FromBase64String(parts[1]);

                using (var pbkdf2 =
                    new Rfc2898DeriveBytes(
                        password,
                        salt,
                        100000))
                {
                    byte[] computedHash =
                        pbkdf2.GetBytes(32);

                    if (computedHash.Length != storedHash.Length)
                        return false;

                    for (int i = 0; i < computedHash.Length; i++)
                    {
                        if (computedHash[i] != storedHash[i])
                            return false;
                    }

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}