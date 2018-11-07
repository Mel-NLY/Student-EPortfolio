<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentTemplate.Master" AutoEventWireup="true" CodeBehind="StudentHomePage.aspx.cs" Inherits="WEBAssignmentCheckpoint1.Student.StudentHomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .welcome
        {
            font-size: 30px;
            font-family: Tahoma, Geneva, sans-serif;
            font-weight: bold;
            color:mediumpurple;
        }
         .button {
            margin-top: 2%;
            border: 2px ridge #800080;
            width: 25%;
            padding: 1%;
            background-color: #fff;
            font-size: 12pt;
            color: #808080;
            font-weight: bold;
            font-family: 'Segoe UI';
            border-radius: 15px;
        }
        .auto-style1 {
            width: 392px;
        }
        .auto-style2 {
            width: 840px;
        }
        .auto-style3 {
            width: 392px;
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="w-100">
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td colspan="2" class="text-left">
                &nbsp;
                <asp:Label ID="lblWelcomeMsg" class="welcome" runat="server" Text=""></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">
                <asp:Button ID="btnUpdatePort" class="button" runat="server" Text="Update Portfolio" OnClick="btnUpdatePort_Click" />
                <asp:Button ID="btnCreateProj" class="button" runat="server" Text="Create Project" OnClick="btnCreateProj_Click"/>
                <br />
                <asp:Button ID="btnProj" class="button" runat="server" Text="Projects" OnClick="btnProj_Click"/>
                <asp:Button ID="btnMenSugg" class="button" runat="server" Text="Mentor Suggestion" OnClick="btnMenSugg_Click"/>
            </td>
            <td>
&nbsp;&nbsp;&nbsp;
                </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
