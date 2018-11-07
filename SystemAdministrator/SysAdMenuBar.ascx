<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SysAdMenuBar.ascx.cs" Inherits="WEBAssignmentCheckpoint1.SysAdMenuBar" %>
<!-- A grey navbar that expands horizontally at medium device -->
<nav class="navbar navbar-expand-md navbar-light" style="background-color:#f7f7f7">
    <!-- The brand(or icon) of the navbar -->
    <a class="navbar-brand" href="SystemAdminHomePage.aspx">
        <img src="../Images/ABC Polytechnic Logo.jpg" style="width:100px;"/>
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
                <a class="nav-link" href="CreateMentorAccount.aspx" style="font-weight:bold;">Create Mentor Account</a>
            </li>
            <li class="nav-item" >
                <a class="nav-link" href="CreateStudentAccount.aspx" style="font-weight:bold;">Create Student Account</a>
            </li>
            <li class="nav-item" >
                <a class="nav-link" href="CreateSkillSet.aspx" style="font-weight:bold;">Create Choices of Skill Sets</a>
            </li>
            <li class="nav-item" >
                <a class="nav-link" href="UploadStudentPhoto.aspx" style="font-weight:bold;">Upload Student Photo</a>
            </li>
            <li class="nav-item">
                <a class="nav-link" href="ApproveViewingRequest.aspx" style="font-weight:bold;">Approve Viewing Request</a>
            </li>
        </ul>
        <!-- Linksthat are aligned to the right,
            ml-auto: left margin auto-adjusted -->
        <ul class="navbar-nav ml-auto">
            <li class="nav-item" style="margin-right:10px">
                <!-- A Web Form Control button for logging out user -->
                <asp:Button ID="btnLogOut" runat="server" Text="Log Out" CausesValidation="false" CssClass="btn btn-link nav-link" style="font-weight:bold; border-color: Black;" OnClick="btnLogOut_Click"/>
            </li>
        </ul>
    </div>
</nav>
