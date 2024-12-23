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
    public partial class Login : System.Web.UI.Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;


            string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            // Check if the connection string is null
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new Exception("Connection string is null or not found.");
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Users WHERE Username = @Username AND Password = @Password";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    // Add parameters to the query
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                        
                    if (reader.HasRows)
                    {
                        // User exists, proceed to home page or dashboard
                        Response.Redirect("Home.aspx");
                    }
                    else
                    {
                        // Invalid username or password
                        Response.Write("<script>alert('Invalid username or password.');</script>");
                    }

                    reader.Close();
                }
            }

        }
    
}
}