using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_project.Models
{
    public partial class Reg : System.Web.UI.Page
    {
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Insert into SQL Database
            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string is null or not found.");
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Users (Username, Email, Password) VALUES (@Username, @Email, @Password)";

                using (SqlCommand cmd = new SqlCommand(query, con))
                {

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        Response.Write("<script>alert('Data inserted successfully!');</script>");
                    }
                    else
                    {
                        Response.Write("<script>alert('No data was inserted!');</script>");
                    }

                    con.Close();

                    Response.Write("<script>alert('Registration successful!');</script>");
                    Response.Redirect("Login.aspx");
                }
            }
        }
    }
}