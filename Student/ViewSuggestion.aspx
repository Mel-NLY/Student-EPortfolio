<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentTemplate.Master" AutoEventWireup="true" CodeBehind="ViewSuggestion.aspx.cs" Inherits="WEBAssignmentCheckpoint1.Student.ViewSuggestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .title
        {
            font-size:30px;
            font-family:"Arial Black", Gadget, sans-serif;
        }
        .auto-style1 {
            height: 30px;
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
            <td colspan="2">
                <asp:Label ID="lblTitle" class="title" runat="server" Text="Suggestion"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td colspan="2" style="background-color:lightgray;" class="fontInput">
            <a href="/Student/StudentHomePage.aspx"><asp:Label ID="lblHomePM" runat="server" Text="Home "></asp:Label></a>
             <asp:Label ID="lblSlash"  runat="server" Text=" / "></asp:Label>
            <a href="/Student/MentorSuggestion.aspx"><asp:Label ID="lblMenSugg" runat="server" Text="Mentor's Suggestions" ></asp:Label></a>
            <asp:Label ID="lblSlash2" runat="server" Text=" / "></asp:Label>
            <asp:Label ID="lblViewSuggestion" runat="server" Text="View Suggestion" style="color:#0000FF;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td class="auto-style1 font"><strong>Mentor Name:</strong></td>
            <td class="auto-style1">
                <asp:Label ID="lblMentorName" class="fontInput" runat="server"></asp:Label>
            </td>
            <td class="auto-style1"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td class="font"><strong>Suggestion:</strong></td>
            <td>
                <asp:Label ID="lblSuggestion" class="fontInput" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
