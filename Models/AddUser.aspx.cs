using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_project.Models
{
    public partial class AddUser : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        protected void Submit_Click(object sender, EventArgs e)
        {
            // Get input values
            string fullName = FullName.Text.Trim();
            string username = Name.Text.Trim();
            string email = Email.Text.Trim();
            string phoneNumber = PhoneNumber.Text.Trim();

            // Validate fields
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                Response.Write("<script>alert('Please fill in all required fields.');</script>");
                return;
            }

            // SQL query to insert the new user
            string query = "INSERT INTO usersData (full_name, username, email, phone_number) " +
                           "VALUES (@FullName, @Username, @Email, @PhoneNumber)";

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        // Use parameters to insert data safely
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber ?? (object)DBNull.Value);

                        // Execute query
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }

                // Redirect to ManageUsers.aspx after successful insertion
                Response.Redirect("ManageUsers.aspx");
            }
            catch (Exception ex)
            {
                // Handle error and display a message
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }

    }
}
