<%@ Page Title="" Language="C#" MasterPageFile="~/Parent/ParentsTemplate.Master" AutoEventWireup="true" CodeBehind="ParentHome.aspx.cs" Inherits="WEBAssignmentCheckpoint1.Parent.ParentHome" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 30px;
        }
        .auto-style6 {
            height: 10px;
        }
        .auto-style7 {
            width: 5px;
        }
        .auto-style8 {
            width: 60px;
        }
        .auto-style9 {
            width: 1005px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100" >
        <tr>
            <td class="auto-style1" colspan="4"></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Parent's Welcome to ABC Polytechnic." Font-Names="Corbel" Font-Underline="True"></asp:Label>
            </td>
            <td class="auto-style7">
                
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                
                </td>
        </tr>
        <tr>
            <td class="auto-style1" colspan="4"></td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style9">
                <asp:Label ID="Label2" runat="server" Text="Information Technology" Font-Names="Elephant" ForeColor="#CC3300"></asp:Label>
            </td>
            <td rowspan="2" class="auto-style8">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Image ID="Image4" runat="server" Height="350px" ImageAlign="Right" ImageUrl="~/Images/ABC Polytechnic Logo.jpg" />
            </td>
            <td class="auto-style7">
                &nbsp;&nbsp;&nbsp;
                <asp:Label ID="Label4" runat="server" Text="Animation &amp; 3D Arts" Font-Names="Elephant" Font-Size="12pt" ForeColor="#33CC33"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2" class="auto-style9">
                <asp:Label ID="Label3" runat="server" Text="Financial Informatics" Font-Names="Elephant" Font-Size="12pt" ForeColor="#3333CC"></asp:Label>
            </td>
            <td class="auto-style7">&nbsp;&nbsp;
                <asp:Label ID="Label5" runat="server" Text="Multimedia &amp; Animation" Font-Names="Elephant" Font-Size="11.2pt" ForeColor="#FF9933"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style6" colspan="4"></td>
        </tr>
        <tr>
            <td colspan="4" class="auto-style1">
                <asp:Image ID="Image6" runat="server" Height="100px" ImageUrl="~/Images/NPcrest.jpg" />
                <asp:Image ID="Image7" runat="server" Height="100px" ImageAlign="Right" ImageUrl="~/Images/ICT logo.jpg" Width="230px" />
            </td>
        </tr>
        </table>
</asp:Content>
