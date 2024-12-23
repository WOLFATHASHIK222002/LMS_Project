<%@ Page Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="IssueBooks.aspx.cs" Inherits="LMS_project.Models.IssueBooks" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f9;
        }
        .container {
            width: 60%;
            margin: 20px auto;
            background: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }
        h2 {
            text-align: center;
            color: #333;
        }
        label {
            display: block;
            margin-top: 10px;
            font-weight: bold;
        }
        select, input {
            width: 100%;
            padding: 8px;
            margin: 5px 0;
            border: 1px solid #ccc;
            border-radius: 4px;
        }
        button {
            margin-top: 15px;
            padding: 10px;
            width: 100%;
            background: #28a745;
            color: #fff;
            border: none;
            border-radius: 4px;
            font-size: 16px;
            cursor: pointer;
        }
        button:hover {
            background: #218838;
        }
    </style>

    <div class="container">
        <h2>Issue Book</h2>
     
            <label for="ddlUsers">Select User:</label>
            <asp:DropDownList ID="ddlUsers" runat="server"></asp:DropDownList>

            <label for="ddlBooks">Select Book:</label>
            <asp:DropDownList ID="ddlBooks" runat="server"></asp:DropDownList>

            <label for="txtIssueDate">Issue Date:</label>
              <asp:TextBox ID="txtIssueDate" runat="server" TextMode="Date" readonly="true"></asp:TextBox>

            <label for="txtDueDate">Due Date:</label>
            <asp:TextBox ID="txtDueDate" runat="server" TextMode="Date"></asp:TextBox>

            <asp:Button ID="btnIssueBook" runat="server" Text="Issue Book" OnClick="btnIssueBook_Click" />
    
    </div>
</asp:Content>
