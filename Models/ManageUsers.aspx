<%@ Page Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="LMS_project.Models.ManageUsers" %>



 <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
      <link rel="stylesheet" href="style.css">
        <!-- Main Content -->
        <div class="content">
            <h2>Manage Users</h2>
            
          
      <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" 
    DataKeyNames="user_Id"   
    CssClass="gridview" AllowPaging="True" PageSize="10"
    OnPageIndexChanging="gvUsers_PageIndexChanging"
    OnRowEditing="gvUsers_RowEditing"
    OnRowCancelingEdit="gvUsers_RowCancelingEdit"
    OnRowUpdating="gvUsers_RowUpdating"
    OnRowDeleting="gvUsers_RowDeleting">

    <Columns>
        <asp:BoundField DataField="user_Id" HeaderText="User ID" ReadOnly="True" />
        <asp:TemplateField HeaderText="Username">
            <ItemTemplate>
                <%# Eval("username") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtUserName" runat="server" Text='<%# Bind("username") %>' />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Email">
            <ItemTemplate>
                <%# Eval("email") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("email") %>' />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Phone Number">
            <ItemTemplate>
                <%# Eval("phone_number") %>
            </ItemTemplate>
            <EditItemTemplate>
                <asp:TextBox ID="txtPhone" runat="server" Text='<%# Bind("phone_number") %>' />
            </EditItemTemplate>
        </asp:TemplateField>
        <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
    </Columns>
</asp:GridView>


            <!-- Add New User Button -->
            <div class="add-button">
                <a href="AddUser.aspx" >Add New User</a>
            </div>
        </div>
</asp:Content>
