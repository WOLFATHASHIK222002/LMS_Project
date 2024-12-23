<%@ Page Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="AddUser.aspx.cs" Inherits="LMS_project.Models.AddUser" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <style>
 .content {
            width: 40%;
            margin: auto;
            border: 1px solid #ccc;
            padding: 20px;
            border-radius: 10px;
            background-color: #f9f9f9;
        }
        .content div {
            margin-bottom: 15px;
        }
        .content label {
            display: block;
            margin-bottom: 5px;
            font-weight: bold;
        }
        .content input[type="text"], .content input[type="email"], .content button {
            width: 100%;
            padding: 10px;
            margin-top: 5px;
            border: 1px solid #ccc;
            border-radius: 5px;
        }
        .content button {
            background-color: #007bff;
            color: white;
            border: none;
            cursor: pointer;
        }
        .content button:hover {
            background-color: #0056b3;
}

     </style>
        <div class="content">
            <h2>Add New User</h2>
 <div>
                <label for="FullName">Full Name:</label>
                <asp:TextBox ID="FullName" runat="server" CssClass="input"></asp:TextBox>
            </div>
            <div>
                <label for="Name">Username:</label>
                <asp:TextBox ID="Name" runat="server" CssClass="input"></asp:TextBox>
            </div>
            <div>
                <label for="Email">Email:</label>
                <asp:TextBox ID="Email" runat="server" CssClass="input" TextMode="Email"></asp:TextBox>
            </div>
            <div>
                <label for="PhoneNumber">Phone Number:</label>
                <asp:TextBox ID="PhoneNumber" runat="server" CssClass="input"></asp:TextBox>
            </div>

            <div>
                <asp:Button ID="btnAddUser" runat="server" Text="Add User" OnClick="Submit_Click" />
            </div>
         
        </div>
</asp:Content>
