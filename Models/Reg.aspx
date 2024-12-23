<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Reg.aspx.cs" Inherits="LMS_project.Models.Reg" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <style>
     /* Background Styling */
     body {
         margin: 0;
         padding: 0;
         height: 100vh;
         background: linear-gradient(to right, #ff9a9e, #fad0c4);
         display: flex;
         justify-content: center;
         align-items: center;
         font-family: Arial, sans-serif;
         color: #333;
         position: relative;
         overflow: hidden;
     }

     /* Stylish 'WA' text in the background */
     body::before {
         content: "WA";
         position: absolute;
         top: 20%;
         left: 50%;
         transform: translate(-50%, -50%);
         font-size: 200px;
         font-weight: bold;
         color: rgba(255, 255, 255, 0.2);
         z-index: 0;
     }

     /* Form Container */
     .form-container {
         background: #fff;
         padding: 30px;
         border-radius: 10px;
         box-shadow: 0px 4px 6px rgba(0, 0, 0, 0.2);
         z-index: 1;
         width: 350px;
     }

     /* Header */
     h2 {
         text-align: center;
         color: #444;
         margin-bottom: 20px;
     }

     /* Input Fields */
     .form-group {
         margin-bottom: 15px;
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

     /* Validators */
     .error-message {
         color: red;
         font-size: 12px;
         display: block;
     }

     /* Button */
     .btn-register {
         width: 100%;
         padding: 10px;
         background-color: #ff6b6b;
         color: white;
         border: none;
         border-radius: 5px;
         cursor: pointer;
         font-size: 16px;
     }

     .btn-register:hover {
         background-color: #e05656;
     }
      /* Link Style */
        .link {
            text-align: center;
            margin-top: 10px;
        }

        .link a {
            color: #ff6b6b;
            text-decoration: none;
        }

        .link a:hover {
            text-decoration: underline;
        }
 </style>
</head>
<body>
    <div class="form-container">
    <h2>Register</h2>
    <form id="form1" runat="server">
        <div class="form-group">
            <label for="txtUsername">Username</label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsername" ControlToValidate="txtUsername" ErrorMessage="Username is required!" runat="server" CssClass="error-message" />
        </div>

        <div class="form-group">
            <label for="txtEmail">Email</label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" ControlToValidate="txtEmail" ErrorMessage="Email is required!" runat="server" CssClass="error-message" />
            <asp:RegularExpressionValidator ID="revEmail" ControlToValidate="txtEmail" ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$" ErrorMessage="Invalid Email!" runat="server" CssClass="error-message" />
        </div>

        <div class="form-group">
            <label for="txtPassword">Password</label>
            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" ControlToValidate="txtPassword" ErrorMessage="Password is required!" runat="server" CssClass="error-message" />
            <asp:RegularExpressionValidator ID="revPassword" ControlToValidate="txtPassword" ValidationExpression="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{6,}$" ErrorMessage="Password must be at least 6 characters, include 1 uppercase, 1 lowercase, and 1 digit." runat="server" CssClass="error-message" />
        </div>

        <div class="form-group">
            <label for="txtConfirmPassword">Confirm Password</label>
            <asp:TextBox ID="txtConfirmPassword" TextMode="Password" runat="server"></asp:TextBox>
            <asp:CompareValidator ID="cvPassword" ControlToValidate="txtConfirmPassword" ControlToCompare="txtPassword" ErrorMessage="Passwords do not match!" runat="server" CssClass="error-message" />
        </div>

       
         <div class="link">
                <span>Already have an account? </span>
                <asp:HyperLink ID="lnkLogin" runat="server" NavigateUrl="Login.aspx" Text="Login here"></asp:HyperLink>
            </div><asp:Button ID="btnRegister" CssClass="btn-register" Text="Register" OnClick="btnRegister_Click" runat="server" />
    </form>
</div>
</body>
</html>
