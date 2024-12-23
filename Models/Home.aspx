<%@ Page Language="C#" MasterPageFile="Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LMS_project.Models.WebForm1" %>


   
   
    <asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
        <link rel="stylesheet" href="style.css">
 
    <div class="content">
        <h2>Welcome to the Admin Dashboard</h2>

        <div class="dashboard-container">
            <div class="dashboard-box">
                <h3>Total Books</h3>
             
                <asp:Label  class="count" ID="lblTotalBooks" runat="server"></asp:Label>
                <p>Books in the Library</p>
            </div>

            <div class="dashboard-box">
                <h3>Total Users</h3>
              
                      <asp:Label  class="count" ID="lblTotalUsers" runat="server"></asp:Label>

                <p>Registered Users</p>
            </div>

            <div class="dashboard-box">
                <h3>Books Issued</h3>
              
                      <asp:Label  class="count" ID="lblBooksIssued" runat="server"></asp:Label>
                <p>Issued Books</p>
            </div>
        </div>

        <!-- Recent Activities -->
       <div class="recent-activities">
            <h3>Recent Activities</h3>
           <asp:Literal ID="recentActivitiesList" runat="server"></asp:Literal>

        </div>

        <!-- Notifications -->
        <div class="notifications">
            <h3>Notifications</h3>
           <ul id="notificationsList" runat="server">
</ul>

        </div>
    </div>

</asp:Content>
