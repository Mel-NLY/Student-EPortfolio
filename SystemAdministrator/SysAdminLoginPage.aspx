<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdministrator/SystemAdminTemplate.Master" AutoEventWireup="true" CodeBehind="SysAdminLoginPage.aspx.cs" Inherits="WEBAssignmentCheckpoint1.SystemAdministrator.SysAdminLoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 200px;
        }
        .auto-style2 {
            width: 200px;
            height: 35px;
            font-family: Arial;
            font-weight: bold;
        }
        .auto-style3 {
            height: 35px;
        }
        .auto-style4 {
            font-family: Arial;
            font-size: large;
            font-weight: bold;
        }
        .auto-style5 {
            width: 200px;
            font-family: Arial;
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="w-100">
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style4">System Admin Login Page</td>
        </tr>
        <tr>
            <td class="auto-style2">Login ID:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtSysAdminUser" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2">Password:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtSysAdminPassword" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <asp:Button ID="btnSysAdminLogin" runat="server" Text="Login" />
&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSysAdminReset" runat="server" Text="Reset" />
            </td>
        </tr>
    </table>
</asp:Content>
