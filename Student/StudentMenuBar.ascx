<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="StudentMenuBar.ascx.cs" Inherits="WEBAssignmentCheckpoint1.StudentMenuBar" %>

<!-- A grey navbar that expands horizontally at medium device -->
<nav class="navbar navbar-expand-md navbar-light" style="background-color:#f7f7f7">
    <!-- The brand(or icon) of the navbar -->
    <img src="/Images/ABC Polytechnic Logo.jpg" style="width:100px;"/>
    <!-- Toggle/collapsible Button, also known as hamburger button -->
    <button class="navbar-toggler" type="button"
        data-toggle="collapse" data-target="#staffNavbar" >
        <span class="navbar-toggler-icon" ></span>
    </button>
    <!-- Links in the navbar, displayed as drop-down list when collapsed -->
    <div class="collapse navbar-collapse" id="staffNavbar" >
        <!-- Links that are aligned to the left,
            mr-auto:right margin auto-adjusted -->
        <ul class =" navbar-nav mr-auto">
            <li class="nav-item" >
                <a class="nav-link" href="UpdatePortfolio.aspx" style="font-weight:bold;">Update Portfolio</a>
            </li>
            <li class="nav-item" >
                <a class="nav-link" href="CreateProject.aspx" style="font-weight:bold;">Create Project</a>
            </li>
            <li class="nav-item" >
                <a class="nav-link" href="ProjectList.aspx" style="font-weight:bold;">Projects</a>
            </li>
            <li class="nav-item" >
                <a class="nav-link" href="MentorSuggestion.aspx" style="font-weight:bold;">Suggestions</a>
            </li>
        </ul>
        <!-- Linksthat are aligned to the right,
            ml-auto: left margin auto-adjusted -->
        <ul class="navbar-nav ml-auto">
            <li class="nav-item" style="margin-right:10px">
                <!-- A Web Form Control button for logging out user -->
                <asp:Button ID="btnLogOut" runat="server" Text="Log Out" CssClass="btn btn-link nav-link" style="font-weight:bold; border-color: Black;" OnClick="btnLogOut_Click"/>
            </li>
        </ul>
    </div>
</nav>
