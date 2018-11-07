<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdministrator/SystemAdminTemplate.Master" AutoEventWireup="true" CodeBehind="CreateMentorAccount.aspx.cs" Inherits="WEBAssignmentCheckpoint1.SystemAdministrator.CreateMentorAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 200px;
            font-size: large;
        }
        .auto-style3 {
            width: 200px;
            font-family: Arial;
            font-weight: bold;
            color: #202326;
            height: 35px;
        }
        .auto-style4 {
            height: 35px;
        }
        .auto-style5 {
            width: 200px;
            height: 35px;
        }
        .auto-style6 {
            font-family: Arial;
            font-weight: bold;
        }
        .auto-style7 {
            font-size: large;
        }
        .auto-style8 {
            font-family: "Segoe UI";
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr class="auto-style6">
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style7">Create Mentor Account</td>
        </tr>
        <tr>
            <td class="auto-style3">Mentor ID<br />
                <br />
                Name</td>
            <td class="auto-style4">
                <asp:Label ID="lblMentorID" runat="server"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="txtMentorName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvMentorName" runat="server" ControlToValidate="txtMentorName" Display="Dynamic" ErrorMessage="Please enter the name"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revMentorName" runat="server" ControlToValidate="txtMentorName" ErrorMessage="Only letters should be used" ValidationExpression="^[A-Za-z]*$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">Email Address</td>
            <td class="auto-style4">
                <asp:TextBox ID="txtMentorEmail" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revMentorEmail" runat="server" ControlToValidate="txtMentorEmail" Display="Dynamic" ErrorMessage="Please enter a valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:CustomValidator ID="cuvMentorEmail" runat="server" CssClass="auto-style8" Display="Dynamic" OnServerValidate="cuvMentorEmail_ServerValidate"></asp:CustomValidator>
                <asp:RequiredFieldValidator ID="rfvMentorEmail" runat="server" ControlToValidate="txtMentorEmail" ErrorMessage="Please enter mentor email address"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style4">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5"></td>
            <td class="auto-style4">
                <asp:Button ID="btnMentorConfirm" runat="server" Text="Confirm" OnClick="btnMentorConfirm_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnMentorReset" runat="server" Text="Reset" CausesValidation="false" OnClick="btnMentorReset_Click" />
                <br />
                <asp:Label ID="lblMentorStatus" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
