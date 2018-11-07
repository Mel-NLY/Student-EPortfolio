<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentTemplate.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="WEBAssignmentCheckpoint1.Student.Project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .title
        {
            font-size:30px;
            font-family:"Arial Black", Gadget, sans-serif;
        }
        .fontInput
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 20px;
        }
        .auto-style1 {
            width: 300px;
        }
        .auto-style2 {
            width: 200px;
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
         .linkleft
        {
            padding-left: 15px;
        }
        .linkright
        {
            padding-right: 15px;
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
    <table cellpadding="0" cellspacing="0" class="w-100">
        <tr>
            <td colspan="3">
                <asp:Label ID="lblTitle" class="title" runat="server" Text="Project"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td colspan="3" style="background-color:lightgray;">
            <a href="/Student/StudentHomePage.aspx"><asp:Label ID="lblHomePM" runat="server" Text="Home "></asp:Label></a>
            <asp:Label ID="lblSlash" runat="server" Text=" / "></asp:Label>
            <a href="/Student/ProjectList.aspx"><asp:Label ID="lblProjectList" runat="server" Text="Project List" ></asp:Label></a>
            <asp:Label ID="lblSlash2" runat="server" Text=" / "></asp:Label>
            <asp:Label ID="lblProject"  runat="server" Text="Project" style="color:#0000FF;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style1">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2 font">
                Poster:</td>
            <td>
                <asp:Image ID="imgViewPoster" runat="server" Height="100px" Width="100px" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2 font">Project Name: </td>
            <td>
                <asp:Label ID="lblViewProjName" class="fontInput" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2 font">Project URL:</td>
            <td>
                <asp:Label ID="lblViewProjURL" class="fontInput" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2 font">Leader:</td>
            <td>
                <asp:Label ID="lblViewLeader" class="fontInput" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2 font">Member:</td>
            <td>
                <asp:Label ID="lblViewMember" class="fontInput" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2 font">Project Description:</td>
            <td>
                <asp:Label ID="lblViewProjDesc" class="fontInput" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnBack" class="button" runat="server" Height="60px" OnClick="btnBack_Click" Text="Back" Width="120px" />
            </td>
            <td></td>
        </tr>
    </table>
</asp:Content>
