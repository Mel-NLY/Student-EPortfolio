<%@ Page Title="" Language="C#" MasterPageFile="~/HomeTemplate.Master" AutoEventWireup="true" CodeBehind="Portfolio.aspx.cs" Inherits="WEBAssignmentCheckpoint1.Student.Portfolio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="w-100">
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">
                Student Photo:</td>
            <td>
                <asp:Image ID="imgViewPortfolio" runat="server" Height="120px" Width="120px" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">
                Name:</td>
            <td class="auto-style1">
                <asp:Label ID="lblStudentName" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">
                About Me:</td>
            <td>
                <asp:Label ID="lblAboutMe" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">
                SkillSets:</td>
            <td>
                <asp:Label ID="lblSkillSets" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="auto-style4">
                Achievements:</td>
            <td>
                <asp:Label ID="lblAchievements" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
