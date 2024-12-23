using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LMS_project.Models
{
    public partial class ManageUsers : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUsersGrid();
            }
        }

        private void BindUsersGrid()
        {
            string query = "SELECT user_id, username, email, phone_number FROM usersData"; // Make sure you include all necessary fields.
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvUsers.DataSource = dt;
                    gvUsers.DataBind();
                }
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }


        // Row editing
        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            BindUsersGrid();
        }

        // Row cancel editing
        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            BindUsersGrid();
        }

        // Row updating
        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                // Retrieve the user ID
                int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value); // Ensure DataKeyNames="userId" is set

                // Retrieve updated values from GridView
                GridViewRow row = gvUsers.Rows[e.RowIndex];
                TextBox txtUserName = row.FindControl("txtUserName") as TextBox;
                TextBox txtEmail = row.FindControl("txtEmail") as TextBox;
                TextBox txtPhone = row.FindControl("txtPhone") as TextBox;

                string userName = txtUserName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string phoneNumber = txtPhone.Text.Trim();

                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(phoneNumber))
                {
                    Response.Write("<script>alert('All fields are required');</script>");
                    return;
                }

                string query = "UPDATE usersData SET username = @UserName, email = @Email, phone_number = @PhoneNumber WHERE user_id = @UserId";

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    cmd.Parameters.AddWithValue("@UserName", userName);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", phoneNumber);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                // Exit edit mode and rebind data
                gvUsers.EditIndex = -1;
                BindUsersGrid();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }



        // Row deleting
        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // Retrieve the user ID from DataKeys
                int userId = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value); // Ensure DataKeyNames="userId" is set

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM usersData WHERE user_id = @UserId";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@UserId", userId);
                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                // Rebind data
                BindUsersGrid();
            }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }




        protected void gvUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvUsers.PageIndex = e.NewPageIndex;
            BindUsersGrid();
        }

    }
}
