using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace LMS_project.Models
{
    public partial class IssueBooks : System.Web.UI.Page
    {
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
                LoadBooks();
                txtIssueDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void LoadUsers()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT user_id, username FROM usersData";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    ddlUsers.DataSource = reader;
                    ddlUsers.DataTextField = "username";
                    ddlUsers.DataValueField = "user_id";
                    ddlUsers.DataBind();

                    ddlUsers.Items.Insert(0, new ListItem("-- Select User --", "0"));
                }
            }
            catch (Exception ex)
            {
                ShowAlert($"Error loading users: {ex.Message}");
            }
        }

        private void LoadBooks()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT BookID, BookName FROM books";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataReader reader = cmd.ExecuteReader();

                    ddlBooks.DataSource = reader;
                    ddlBooks.DataTextField = "BookName";
                    ddlBooks.DataValueField = "BookID";
                    ddlBooks.DataBind();

                    ddlBooks.Items.Insert(0, new ListItem("-- Select Book --", "0"));
                }
            }
            catch (Exception ex)
            {
                ShowAlert($"Error loading books: {ex.Message}");
            }
        }

        protected void btnIssueBook_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO issue_books (book_id, user_id, issue_date, due_date) VALUES (@book_id, @user_id, @issue_date, @due_date)";
                        SqlCommand cmd = new SqlCommand(query, con);

                        cmd.Parameters.AddWithValue("@book_id", ddlBooks.SelectedValue);
                        cmd.Parameters.AddWithValue("@user_id", ddlUsers.SelectedValue);
                        cmd.Parameters.AddWithValue("@issue_date", txtIssueDate.Text);
                        cmd.Parameters.AddWithValue("@due_date", txtDueDate.Text);

                        con.Open();
                        cmd.ExecuteNonQuery();
                        ShowAlert("Book issued successfully!");
                        ClearForm();
                    }
                    Response.Redirect("Home.aspx");
                }
                catch (Exception ex)
                {
                    ShowAlert($"Error issuing book: {ex.Message}");
                }
            }
        }

        private bool ValidateInput()
        {
            if (ddlUsers.SelectedValue == "0")
            {
                ShowAlert("Please select a user.");
                return false;
            }

            if (ddlBooks.SelectedValue == "0")
            {
                ShowAlert("Please select a book.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtIssueDate.Text))
            {
                ShowAlert("Please select an issue date.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDueDate.Text))
            {
                ShowAlert("Please select a due date.");
                return false;
            }

            return true;
        }

        private void ClearForm()
        {
            ddlUsers.SelectedIndex = 0;
            ddlBooks.SelectedIndex = 0;
            txtIssueDate.Text = string.Empty;
            txtDueDate.Text = string.Empty;
        }

        private void ShowAlert(string message)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Alert", $"alert('{message}');", true);
        }
    }
}
