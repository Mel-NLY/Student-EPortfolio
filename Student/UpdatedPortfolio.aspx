<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentTemplate.Master" AutoEventWireup="true" CodeBehind="UpdatedPortfolio.aspx.cs" Inherits="WEBAssignmentCheckpoint1.UpdatedPortfolio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .title
        {
            font-size:30px;
            font-family:"Arial Black", Gadget, sans-serif;
        }
        .auto-style1 {
            width: 1046px;
        }
        .auto-style4 {
            width: 203px;
        }
        .font
        {   
            font-family: "Comic Sans MS", cursive, sans-serif;
            font-size: 25px;
            font-weight: bold;
        }
        .fontInput
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 20px;
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
        .auto-style5 {
            width: 202px;
        }
        .color
        {
            background-color: lightgrey;
            padding-top: 5px;
            padding-bottom: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="20" cellspacing="0" class="w-100">
        <tr>
            <td colspan="3">
                <asp:Label ID="lblTitle" class="title" runat="server" Text="Updated Portfolio"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td colspan="3" style="background-color:lightgray;" class="fontInput">
            <a href="/Student/StudentHomePage.aspx"><asp:Label ID="lblHomePM" runat="server" Text="Home "></asp:Label></a>
            <asp:Label ID="lblSlash" runat="server" Text=" / "></asp:Label>
            <a href="/Student/UpdatePortfolio.aspx"><asp:Label ID="lblUpdatePortfolio" runat="server" Text="Update Portfolio"></asp:Label></a>
            <asp:Label ID="lblSlash2" runat="server" Text=" / "></asp:Label>
            <asp:Label ID="lblUpdatedPortfolio" runat="server" Text="Updated Portfolio" style="color:#0000FF;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style5 font">
                Photo:</td>
            <td>
                <asp:Image ID="imgStudentPhoto" runat="server" Height="100px" Width="100px" />
            </td>
            <td class="auto-style1">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5 font">
                Name:</td>
            <td class="auto-stylel">
                <asp:Label ID="lblStudentName" class="fontInput" runat="server"></asp:Label>
            </td>
            <td class="auto-style1">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5 font">
                About Me:</td>
            <td>
                <asp:Label ID="lblAboutMe" class="fontInput" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5 font">
                SkillSets:</td>
            <td>
                <asp:Label ID="lblSkillSets" class="fontInput" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5 font">
                Achievements:</td>
            <td>
                <asp:Label ID="lblAchievements" class="fontInput" runat="server"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">
                <br />
                <asp:Button ID="btnEdit" class="button" runat="server" Height="80px" OnClick="btnEdit_Click" Text="Edit" Width="250px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            <td>
                <asp:Button ID="btnconfirm" class="button" runat="server" Height="80px" OnClick="btnconfirm_Click" Text="Confirm" Width="250px" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
