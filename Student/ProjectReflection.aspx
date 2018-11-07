<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentTemplate.Master" AutoEventWireup="true" CodeBehind="ProjectReflection.aspx.cs" Inherits="WEBAssignmentCheckpoint1.Student.ProjectReflection" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .title
        {
            font-size:30px;
            font-family:"Arial Black", Gadget, sans-serif;
        }
        .auto-style1 {
            width: 204px;
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
    <table class="w-100">
        <tr>
            <td colspan="3">
                <asp:Label ID="lblTitle" class="title" runat="server" Text="Reflection"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td colspan="3" style="background-color:lightgray;" class="fontInput">
            <a href="/Student/StudentHomePage.aspx"><asp:Label ID="lblHomePM" runat="server" Text="Home "></asp:Label></a>
            <asp:Label ID="lblSlash" runat="server" Text=" / "></asp:Label>
            <a href="/Student/ProjectList.aspx"><asp:Label ID="lblProjectList" runat="server" Text="Project List"></asp:Label></a>
            <asp:Label ID="lblSlash2" runat="server" Text=" / "></asp:Label>
            <asp:Label ID="lblProjectReflection" runat="server" Text="Project Reflection" style="color:#0000FF;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1 font">Project Name:</td>
            <td>
                <asp:Label ID="lblProjectName" class="fontInput" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1 font">Reflection</td>
            <td>
                <asp:TextBox ID="txtReflection" class="fontInput" runat="server" Height="120px" Width="500px" TextMode="MultiLine" CssClass="offset-sm-0"></asp:TextBox>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <asp:Button ID="btnUpdateReflection" class="button" runat="server" Height="60px" OnClick="btnUpdateReflection_Click" Text="Update" Width="120px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnBack" class="button" runat="server" Height="60px" OnClick="btnBack_Click" Text="Back" Width="120px" />
            </td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
