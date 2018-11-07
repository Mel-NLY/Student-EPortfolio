<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MenuBar.ascx.cs" Inherits="WEBAssignmentCheckpoint1.MenuBar" %>
<!-- A grey navbar that expands horizontally at medium device -->
<nav class="navbar navbar-expand-md navbar-light" style="background-color:#f7f7f7">
    <!-- The brand(or icon) of the navbar -->
    <a class="navbar-brand" href=>
        <img src="./Images/ABC Polytechnic Logo.jpg" style="width:100px;"/>
    </a>
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
                <a class="nav-link" href="/DirectorMessage.aspx" style="font-weight:bold;">Director's Message</a>
            </li>
            <li class="nav-item" >
                <a class="nav-link" href="/StudentePortfolio.aspx" style="font-weight:bold;">Student E-Portfolios</a>
            </li>
        </ul>
        <!-- Linksthat are aligned to the right,
            ml-auto: left margin auto-adjusted -->
        <ul class="navbar-nav ml-auto">
            <li class="nav-item" style="margin-right:10px">
                <!-- A Web Form Control button for logging out user -->
                <asp:Button ID="btnRegister" runat="server" Text="Register" CausesValidation="false" CssClass="btn btn-link nav-link" style="font-weight:bold; border-color: Black;" OnClick="btnRegister_Click"/>
            </li>
            <li class="nav-item">
                <!-- A Web Form Control button for logging out user -->
                <asp:Button ID="btnLogIn" runat="server" Text="Log In" CausesValidation="false" CssClass="btn btn-link nav-link" style="font-weight:bold; border-color: Black;" OnClick="btnLogIn_Click"/>
            </li>
        </ul>
    </div>
</nav>