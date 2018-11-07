<%@ Page Title="" Language="C#" MasterPageFile="~/HomeTemplate.Master" AutoEventWireup="true" CodeBehind="ConfirmAddParent.aspx.cs" Inherits="WEBAssignmentCheckpoint1.ConfirmAddParent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td>
                <asp:Label ID="lblAlert" runat="server" Text="The following Account has been created successfully."></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblN" runat="server" Text="Name:"></asp:Label>
&nbsp;&nbsp;
                <asp:Label ID="lblName" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblE" runat="server" Text="Email:"></asp:Label>
&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblEmail" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <br />
                <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Back to Login Page" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
