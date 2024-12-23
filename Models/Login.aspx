<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LMS_project.Models.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Page
    </title>
   <style>
        /* Body with a light gradient background */
        body {
            margin: 0;
            padding: 0;
            height: 100vh;
            background: linear-gradient(to right, #fce4ec, #f8bbd0); /* Light Pink Gradient */
            display: flex;
            justify-content: center;
            align-items: center;
            font-family: Arial, sans-serif;
            color: #333;
            position: relative;
            overflow: hidden;
        }

        /* Background 'WA' text for style */
        body::before {
            content: "WA";
            position: absolute;
            top: 15%;
            left: 50%;
            transform: translate(-50%, -50%);
            font-size: 180px;
            font-weight: bold;
            color: rgba(255, 255, 255, 0.3);
            z-index: 0;
        }

        /* Form container */
        .form-container {
            background: #fff; /* White background */
            padding: 30px;
            border-radius: 10px;
            box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.2);
            z-index: 1;
            width: 350px;
            text-align: center;
        }

        /* Header */
        h2 {
            text-align: center;
            color: #444;
            margin-bottom: 20px;
        }

        /* Form Group Styling */
        .form-group {
            margin-bottom: 20px;
            text-align: left;
        }

        label {
            display: block;
            margin-bottom: 5px;
            color: #666;
        }

        .form-group input {
            width: 100%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 5px;
            font-size: 14px;
        }

        /* Error message styling */
        .error-message {
            color: red;
            font-size: 12px;
            display: block;
            margin-top: 5px;
        }

        /* Button Styling */
        .btn-login {
            width: 100%;
            padding: 10px;
            background-color: #f48fb1; /* Light Pink */
            color: white;
            border: none;
            border-radius: 5px;
            cursor: pointer;
            font-size: 16px;
        }

        .btn-login:hover {
            background-color: #ec407a; /* Darker Pink */
        }

        /* Error Label */
        .error-label {
            color: red;
            margin-top: 15px;
            font-size: 14px;
        }
    </style>
</head>
<body>
      <div class="form-container">
        <h2>Login</h2>
        <form id="form1" runat="server">
            <div class="form-group">
                <label for="txtUsername">Username</label>
                <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvUsername" ControlToValidate="txtUsername" ErrorMessage="Username is required!" runat="server" CssClass="error-message" />
            </div>

            <div class="form-group">
                <label for="txtPassword">Password</label>
                <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPassword" ControlToValidate="txtPassword" ErrorMessage="Password is required!" runat="server" CssClass="error-message" />
            </div>

            <asp:Button ID="btnLogin" CssClass="btn-login" Text="Login" OnClick="btnLogin_Click" runat="server" />
            <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
        </form>
    </div>
</body>
</html>
