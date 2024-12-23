<%@ Page Language="C#"  MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="ManageBooks.aspx.cs" Inherits="LMS_project.Models.ManageBooks" %>

  

 <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link rel="stylesheet" href="style.css">
     <style>
         /* Manage Book GridView Styling */

           @media (max-width: 768px) {
      .content-container {
          padding: 10px;
      }

      .gridview th, .gridview td {
          padding: 8px;
          font-size: 12px;
      }

      .input-field {
          padding: 6px 8px;
          font-size: 12px;
      }

      .btn {
          padding: 8px 15px;
          font-size: 14px;
      }
  } 
#gvBooks th, #gvBooks td {
    padding: 12px;
    text-align: left;
    border: 1px solid #ddd;
    font-size: 14px;
}

#gvBooks th {
    background-color: #f2f2f2;
    color: #333;
}

#gvBooks .input-field {
    width: 100%;
    padding: 8px;
    margin: 5px 0;
    border-radius: 4px;
    border: 1px solid #ddd;
}

/* Edit Button and Delete Button Styles */
#gvBooks .edit-button, #gvBooks .delete-button {
    padding: 6px 12px;
    background-color: #3498db;
    color: white;
    border: none;
    cursor: pointer;
    border-radius: 4px;
    transition: background-color 0.3s ease;
}

#gvBooks .edit-button:hover {
    background-color: #2980b9;
}

#gvBooks .delete-button {
    background-color: #e74c3c;
}

#gvBooks .delete-button:hover {
    background-color: #c0392b;
}

     </style>
    <h2>Manage Books</h2>

    <!-- Add New Book Form -->
    <div class="add-book-form">
        <h3>Add New Book</h3>
        <asp:TextBox ID="txtBookName" runat="server" placeholder="Book Name" CssClass="input-field"></asp:TextBox>
        <asp:TextBox ID="txtAuthor" runat="server" placeholder="Author" CssClass="input-field"></asp:TextBox>
        <asp:TextBox ID="txtISBN" runat="server" placeholder="ISBN" CssClass="input-field"></asp:TextBox>
        <asp:TextBox ID="txtYear" runat="server" placeholder="Year of Publication" CssClass="input-field"></asp:TextBox>
        <asp:Button ID="btnAddBook" runat="server" Text="Add Book" OnClick="btnAddBook_Click" CssClass="btn" />
    </div>

    <!-- Book List Table -->
    <div class="book-list">
        <h3>List of Books</h3>
   <asp:GridView ID="gvBooks" runat="server" AutoGenerateColumns="False"
    OnRowEditing="gvBooks_RowEditing" 
    OnRowUpdating="gvBooks_RowUpdating" 
    OnRowDeleting="gvBooks_RowDeleting" 
    OnRowCancelingEdit="gvBooks_RowCancelingEdit" 
    CssClass="gridview" DataKeyNames="BookID">

    <Columns>
       
        <asp:BoundField DataField="BookID" HeaderText="Book ID" ReadOnly="True" />

        <asp:TemplateField HeaderText="Book Name">
            <ItemTemplate>
                <%# Eval("BookName") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtBookName" runat="server" Text='<%# Bind("BookName") %>' CssClass="input-field" />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="Author">
            <ItemTemplate>
                <%# Eval("author") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtAuthor" runat="server" Text='<%# Bind("author") %>' CssClass="input-field" />
            </EditItemTemplate>
        </asp:TemplateField>

        <asp:TemplateField HeaderText="ISBN">
            <ItemTemplate>
                <%# Eval("ISBN") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtISBN" runat="server" Text='<%# Bind("ISBN") %>' CssClass="input-field" />
            </EditItemTemplate>
        </asp:TemplateField>

    
        <asp:TemplateField HeaderText="Year of Publication">
            <ItemTemplate>
                <%# Eval("Year") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtYear" runat="server" Text='<%# Bind("Year") %>' CssClass="input-field" />
            </EditItemTemplate>
        </asp:TemplateField>

      
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>



    </div>
</asp:Content>

