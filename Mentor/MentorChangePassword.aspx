<%@ Page Title="" Language="C#" MasterPageFile="~/Mentor/MentorTemplate.Master" AutoEventWireup="true" CodeBehind="MentorChangePassword.aspx.cs" Inherits="WEBAssignmentCheckpoint1.Mentor.MentorChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            height: 34px;
        }
        .auto-style4 {
            height: 34px;
            width: 266px;
        }
        .auto-style5 {
            width: 266px;
        }
        .auto-style6 {
            height: 35px;
        }
        .auto-style8{
            border: 2px ridge #800080;
            width: 130px;
            padding: 1%;
            background-color: #fff;
            font-family: "Segoe UI";
            font-size: 12pt;
            color: #808080;
            font-weight: bold;
            border-radius: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td colspan="2">
                <asp:Label ID="lblChangePassword" runat="server" Text="Change Password" style="padding:7px;font-size:30px;font-weight:bold;font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;"></asp:Label>
            </td>
        </tr>
        <tr style="background-color:lightgray;">
            <td colspan="2" class="auto-style6">
                <a href="MentorHomePage.aspx" style="padding-left: 10px;"><asp:Label ID="lblTrackingBar" runat="server" Text="Home "></asp:Label></a>
                <asp:Label ID="lblSlash" runat="server" Text="/ "></asp:Label>
                <a href="MentorChangePassword.aspx"><asp:Label ID="lblCP" runat="server" Text="Change Password"></asp:Label></a>
            </td>
        </tr>
        <tr>
            <td class="auto-style4" style="padding-top:2em; padding-left:4em;">
                <asp:Label ID="lblCurrentPassword" runat="server" Text="Enter Current Password : "></asp:Label>
            </td>
            <td class="auto-style3" style="padding-top:2em">
                <asp:TextBox ID="tbCurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCurrentPassword" runat="server" Display="Dynamic" ErrorMessage="Please enter your current password" ForeColor="Red" ControlToValidate="tbCurrentPassword">*</asp:RequiredFieldValidator>
            &nbsp;<asp:CustomValidator ID="cvCurrentPassword" runat="server" ControlToValidate="tbCurrentPassword" ErrorMessage="Current Password is Invalid/Not found" ForeColor="Red" OnServerValidate="cvCurrentPassword_ServerValidate">*</asp:CustomValidator>
            &nbsp;<asp:CompareValidator ID="cvCompareOldNew" runat="server" ControlToCompare="tbNewPassword" ControlToValidate="tbCurrentPassword" Display="Dynamic" ErrorMessage="Current password and New password cannot be the same" ForeColor="Red" Operator="NotEqual">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" style="padding-left:4em; padding-top:1%; padding-bottom:1%">
                <asp:Label ID="lblNewPassword" runat="server" Text="Enter New Password : "></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="tbNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" Display="Dynamic" ErrorMessage="Please enter a new password" ForeColor="Red" ControlToValidate="tbNewPassword">*</asp:RequiredFieldValidator>
            &nbsp;<asp:RegularExpressionValidator ID="revPassword" runat="server" ControlToValidate="tbNewPassword" ErrorMessage="Password needs to be at least 8 characters long" ForeColor="Red" ValidationExpression="^.{8,}$">*</asp:RegularExpressionValidator>
            &nbsp;<asp:RegularExpressionValidator ID="revPasswordDigit" runat="server" ControlToValidate="tbNewPassword" ErrorMessage="Password needs to have at least 1 digit" ForeColor="Red" ValidationExpression="^.*(?=.*\d).*$">*</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" style="padding-left:4em;">
                <asp:Label ID="lblCfmNewPassword" runat="server" Text="Confirm New Password :"></asp:Label>
            </td>
            <td style="padding-bottom:1%">
                <asp:TextBox ID="tbCfmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvCfmPassword" runat="server" Display="Dynamic" ErrorMessage="Please reenter your new password" ForeColor="Red" ControlToValidate="tbCfmNewPassword">*</asp:RequiredFieldValidator>
            &nbsp;<asp:CompareValidator ID="cvCfmPassword" runat="server" ControlToCompare="tbNewPassword" ControlToValidate="tbCfmNewPassword" Display="Dynamic" ErrorMessage="Passwords do not match" ForeColor="Red">*</asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" style="padding-left:4em;padding-bottom:1%">
                &nbsp;</td>
            <td>
                <asp:Button ID="btnCfmPassword" class="auto-style8" runat="server" Text="Confirm" OnClick="btnCfmPassword_Click" />
                <asp:ValidationSummary ID="vsError" runat="server" ForeColor="Red" Width="638px" />
                <br />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
