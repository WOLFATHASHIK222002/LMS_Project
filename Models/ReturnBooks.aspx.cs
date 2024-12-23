using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LMS_project.Models
{
    public partial class ReturnBooks : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadIssuedBooks();
            }
        }

        private void LoadIssuedBooks()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                issue_books.issue_id, 
                usersData.username, 
                books.BookName, 
                books.author, 
                usersData.phone_number AS PhoneNumber, 
                issue_books.due_date 
            FROM 
                issue_books 
            JOIN usersData ON issue_books.user_id = usersData.user_id 
            JOIN books ON issue_books.book_id = books.BookID 
            WHERE 
                issue_books.status = 'Issued'";

                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                System.Data.DataTable dt = new System.Data.DataTable();
                adapter.Fill(dt);

                gvIssuedBooks.DataSource = dt;
                gvIssuedBooks.DataBind();
            }
        }


        protected void gvIssuedBooks_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ReturnBook")
            {
                int issueId = Convert.ToInt32(e.CommandArgument);

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    // Update the issue status to 'Returned' and set the return date
                    string updateQuery = "UPDATE issue_books SET status = 'Returned', return_date = GETDATE() WHERE issue_id = @issue_id";
                    SqlCommand cmdUpdate = new SqlCommand(updateQuery, con);
                    cmdUpdate.Parameters.AddWithValue("@issue_id", issueId);

                    con.Open();
                    cmdUpdate.ExecuteNonQuery();

                    // Delete the notification related to this book return
                    string deleteNotificationQuery = "DELETE FROM Notifications WHERE user_id IN (SELECT user_id FROM issue_books WHERE issue_id = @issue_id)";
                    SqlCommand cmdDeleteNotification = new SqlCommand(deleteNotificationQuery, con);
                    cmdDeleteNotification.Parameters.AddWithValue("@issue_id", issueId);
                    cmdDeleteNotification.ExecuteNonQuery();

                    con.Close();
                }

                // Reload the issued books grid and notifications
                LoadIssuedBooks();  // Reload books after return action
                
            }
        }

    }
}
