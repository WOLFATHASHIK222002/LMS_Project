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
    public partial class WebForm1 : System.Web.UI.Page
    {
        // Connection string (you may need to update it with your actual connection details)
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Bind data to the page when it first loads
                BindDashboardData();
                BindRecentActivities();
                BindNotifications();
                InsertDueDateNotification();
            }
        }


        // Method to bind dashboard data (Total Books, Total Users, Books Issued)
        private void BindDashboardData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Get Total Books
                string totalBooksQuery = "SELECT COUNT(*) FROM books";
                SqlCommand cmdBooks = new SqlCommand(totalBooksQuery, conn);
                int totalBooks = (int)cmdBooks.ExecuteScalar();

                // Get Total Users
                string totalUsersQuery = "SELECT COUNT(*) FROM usersData";
                SqlCommand cmdUsers = new SqlCommand(totalUsersQuery, conn);
                int totalUsers = (int)cmdUsers.ExecuteScalar();

                // Get Books Issued
                string booksIssuedQuery = "SELECT COUNT(*) FROM issue_books WHERE return_date IS NULL";
                SqlCommand cmdIssued = new SqlCommand(booksIssuedQuery, conn);
                int booksIssued = (int)cmdIssued.ExecuteScalar();

                // Update the UI controls with dynamic values
                lblTotalBooks.Text = totalBooks.ToString();
                lblTotalUsers.Text = totalUsers.ToString();
                lblBooksIssued.Text = booksIssued.ToString();
            }
        }

        // Method to bind recent activities
        private void BindRecentActivities()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Correct query to fetch the top 5 recent activities
                string activitiesQuery = "SELECT TOP 5 activity_type, details FROM ActivityLogs ORDER BY activity_date DESC";
                SqlCommand cmdActivities = new SqlCommand(activitiesQuery, conn);
                SqlDataReader reader = cmdActivities.ExecuteReader();

                // Clear the existing content to avoid appending duplicates on postback
                recentActivitiesList.Text = "";

                // Bind the recent activities to the list
                while (reader.Read())
                {
                    string activityDescription = reader["activity_type"].ToString() + ": " + reader["details"].ToString();
                    recentActivitiesList.Text += $"<li>{activityDescription}</li>";
                }
            }
        }



        // Method to bind notifications
        private void BindNotifications()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // SQL query to fetch notifications (modify if needed)
                string notificationsQuery = "SELECT TOP 5 message FROM Notifications ORDER BY notification_date DESC";
                SqlCommand cmdNotifications = new SqlCommand(notificationsQuery, conn);
                SqlDataReader reader = cmdNotifications.ExecuteReader();

                // Create a HashSet to store unique messages to avoid duplicates
                HashSet<string> existingNotifications = new HashSet<string>();

                // Clear existing notifications
                notificationsList.InnerHtml = "";  // Clear previous notifications from the Literal control

                // Loop through and bind new notifications
                while (reader.Read())
                {
                    string notificationMessage = reader["message"].ToString();

                    // Check if the notification message has already been displayed
                    if (!existingNotifications.Contains(notificationMessage))
                    {
                        // Add it to the HashSet to prevent future duplicates
                        existingNotifications.Add(notificationMessage);

                        // Add it to the Literal control's InnerHtml property (for HTML content)
                        notificationsList.InnerHtml += $"<li>{notificationMessage}</li>";
                    }
                }
            }
        }

        private void InsertDueDateNotification()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Fetch books with due date 3 days from now
                string query = @"
            INSERT INTO Notifications (user_id, notification_type, message)
            SELECT 
                ib.user_id, 
                'Due Date Warning', 
                CONCAT('Book: ', b.BookName, ' is due in 3 days. Please return it by ', ib.due_date)
            FROM 
                issue_books ib
            JOIN 
                books b ON ib.book_id = b.BookID
            WHERE 
                ib.due_date BETWEEN GETDATE() AND DATEADD(DAY, 3, GETDATE()) 
                AND ib.status = 'Issued'";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
            }
        }



    }
}