using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;

namespace Library_Management_System
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid)
            {
                return;
            }

            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;

            string passwordHash = HashPassword(password);

            string connectionString =
                ConfigurationManager
                .ConnectionStrings["LibraryManagementConnection"]
                .ConnectionString;

            string query = @"
                INSERT INTO Users
                (
                    Name,
                    Email,
                    PasswordHash
                )
                VALUES
                (
                    @Name,
                    @Email,
                    @PasswordHash
                )";

            try
            {
                using (SqlConnection connection =
                       new SqlConnection(connectionString))
                {
                    using (SqlCommand command =
                           new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue(
                            "@Name", name);

                        command.Parameters.AddWithValue(
                            "@Email", email);

                        command.Parameters.AddWithValue(
                            "@PasswordHash", passwordHash);

                        connection.Open();

                        command.ExecuteNonQuery();
                    }
                }

                lblMessage.Text =
                    "Registration successful. You can now login.";

                lblMessage.CssClass =
                    "message success-message";

                txtName.Text = "";
                txtEmail.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627 ||
                    ex.Number == 2601)
                {
                    lblMessage.Text =
                        "An account with this email already exists.";

                    lblMessage.CssClass =
                        "message error-message";
                }
                else
                {
                    lblMessage.Text =
                        "Registration failed. Please try again.";

                    lblMessage.CssClass =
                        "message error-message";
                }
            }
        }

        private string HashPassword(string password)
        {
            byte[] salt = new byte[16];

            using (RandomNumberGenerator random =
                   RandomNumberGenerator.Create())
            {
                random.GetBytes(salt);
            }

            using (var pbkdf2 =
                   new Rfc2898DeriveBytes(
                       password,
                       salt,
                       100000))
            {
                byte[] hash =
                    pbkdf2.GetBytes(32);

                return Convert.ToBase64String(salt)
                    + ":"
                    + Convert.ToBase64String(hash);
            }
        }
    }
}