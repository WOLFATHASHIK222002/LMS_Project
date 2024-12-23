using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS_project.Models
{
    public partial class ManageBooks : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindBooksGrid();
            }
        }

        // Method to bind data to GridView
        private void BindBooksGrid()
        {
            
                string query = "SELECT * FROM books";
                try
                {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gvBooks.DataSource = dt;
                    gvBooks.DataBind();
                }
              
                }
            catch (Exception ex)
            {
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }

        protected void btnAddBook_Click(object sender, EventArgs e)
        {
            string bookName = txtBookName.Text;
            string author = txtAuthor.Text;
            string isbn = txtISBN.Text;
            string year = txtYear.Text;

            if (string.IsNullOrEmpty(bookName) || string.IsNullOrEmpty(author) || string.IsNullOrEmpty(year) || string.IsNullOrEmpty(isbn))
            {
                Response.Write("<script>alert('All fields are required');</script>");
                return;
            }
           

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "INSERT INTO books (BookName, Author, ISBN, Year, total_copies) VALUES (@BookName, @Author, @ISBN, @Year, @TotalCopies)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@BookName", bookName);
                    cmd.Parameters.AddWithValue("@Author", author);
                    cmd.Parameters.AddWithValue("@ISBN", isbn);
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@TotalCopies", 1); // Default total copies to 1

                    con.Open();
                    cmd.ExecuteNonQuery();

                }
            

            // Clear fields and rebind the grid
            ClearFields();
            BindBooksGrid();
        }


        // Row editing
        protected void gvBooks_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvBooks.EditIndex = e.NewEditIndex;
            BindBooksGrid();
        }

        // Row updating
        protected void gvBooks_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                // Retrieve the BookID
                int bookID = Convert.ToInt32(gvBooks.DataKeys[e.RowIndex].Value);

                // Retrieve updated values from GridView
                TextBox txtBookName = (TextBox)gvBooks.Rows[e.RowIndex].FindControl("txtBookName");
                TextBox txtAuthor = (TextBox)gvBooks.Rows[e.RowIndex].FindControl("txtAuthor");
                TextBox txtISBN = (TextBox)gvBooks.Rows[e.RowIndex].FindControl("txtISBN");
                TextBox txtYear = (TextBox)gvBooks.Rows[e.RowIndex].FindControl("txtYear");

                string bookName = txtBookName?.Text;
                string author = txtAuthor?.Text;
                string isbn = txtISBN?.Text;
                int year = Convert.ToInt32(txtYear?.Text);

                // Update query
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "UPDATE books SET BookName = @BookName, author = @Author, ISBN = @ISBN, Year = @Year WHERE BookID = @BookID";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@BookName", bookName);
                    cmd.Parameters.AddWithValue("@Author", author);
                    cmd.Parameters.AddWithValue("@ISBN", isbn);
                    cmd.Parameters.AddWithValue("@Year", year);
                    cmd.Parameters.AddWithValue("@BookID", bookID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                // Exit edit mode and rebind data
                gvBooks.EditIndex = -1;
                BindBooksGrid();
            }
            catch (Exception ex)
            {
                Response.Write($"Error: {ex.Message}");
            }
        }

        // Row deleting
        protected void gvBooks_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                // Retrieve the BookID
                int bookID = Convert.ToInt32(gvBooks.DataKeys[e.RowIndex].Value);

                // Delete query
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM books WHERE BookID = @BookID";
                    SqlCommand cmd = new SqlCommand(query, con);

                    cmd.Parameters.AddWithValue("@BookID", bookID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                }

                // Rebind data
                BindBooksGrid();
            }
            catch (Exception ex)
            {
                Response.Write($"Error: {ex.Message}");
            }
        }

        // Cancel editing
        protected void gvBooks_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvBooks.EditIndex = -1;
            BindBooksGrid();
        }

        // Helper method to clear text fields
        private void ClearFields()
        {
            txtBookName.Text = "";
            txtAuthor.Text = "";
            txtISBN.Text = "";
            txtYear.Text = "";
        }
    }
}
