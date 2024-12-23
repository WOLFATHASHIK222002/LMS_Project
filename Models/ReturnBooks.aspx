<%@ Page Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="ReturnBooks.aspx.cs" Inherits="LMS_project.Models.ReturnBooks"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <style>
        .overdue { color: red; }
        table {
            width: 100%;
            border-collapse: collapse;
        }
        th, td {
            padding: 10px;
            border: 1px solid #ddd;
            text-align: center;
        }
        th {
            background-color: #f4f4f4;
        }
        button {
            padding: 5px 10px;
            background: #dc3545;
            color: white;
            border: none;
            cursor: pointer;
        }
    </style>
     <h2 style="text-align:center;">Return Books</h2>


 <asp:GridView ID="gvIssuedBooks" runat="server" AutoGenerateColumns="False" OnRowCommand="gvIssuedBooks_RowCommand">
        <Columns>
            <asp:BoundField DataField="issue_id" HeaderText="Issue ID" />
            <asp:BoundField DataField="username" HeaderText="User Name" />
            <asp:BoundField DataField="BookName" HeaderText="Book Name" />
            <asp:BoundField DataField="Author" HeaderText="Author" />
            <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
            <asp:BoundField DataField="due_date" HeaderText="Due Date" DataFormatString="{0:yyyy-MM-dd}" ItemStyle-CssClass="overdue" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnReturn" runat="server" Text="Received" CommandName="ReturnBook" CommandArgument='<%# Eval("issue_id") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MyConnectionString %>"
        SelectCommand="SELECT issue_id, username, BookName, due_date 
                       FROM issue_books 
                       JOIN usersData ON issue_books.user_id = usersData.user_id
                       JOIN books ON issue_books.book_id = books.BookID
                       WHERE status = 'Issued'">
    </asp:SqlDataSource>
  </asp:Content>
