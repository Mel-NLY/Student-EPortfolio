<%@ Page Title="" Language="C#" MasterPageFile="~/HomeTemplate.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WEBAssignmentCheckpoint1.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 584px;
        }
        .auto-style2 {
            width: 103px;
            height: 79px;
        }
        .auto-style3 {
            width: 103px;
            height: 62px;
        }
        .auto-style4 {
            height: 62px;
        }
        .auto-style5 {
            height: 79px;
        }
        .auto-style6 {
            border: 2px ridge #800080;
            width: 15%;
            padding: 1%;
            background-color: #fff;
            font-family: "Segoe UI";
            font-size: 12pt;
            color: #808080;
            font-weight: bold;
            border-radius: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td colspan="3">
                <h1 class="auto-style5" style="width: 1097px; color: #666666; text-align: center;"><strong>Login</strong></h1>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" rowspan="3" style="padding-top:30px">
                <asp:Image ID="imgICT" runat="server" ImageAlign="Right" ImageUrl="/Images/ICT logo.jpg" Width="60%" style="margin-right:5%"/>
            </td>
            <td class="auto-style3" style="padding-top:30px">
                <asp:Label ID="lblEmail" runat="server" Text="Email : "></asp:Label>
            </td>
            <td class="auto-style4" style="padding-top:30px">
                <asp:TextBox ID="tbEmail" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <asp:Label ID="lblPassword" runat="server" Text="Password : "></asp:Label>
            </td>
            <td class="auto-style5">
                <asp:TextBox ID="tbPassword" runat="server" TextMode="Password"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <strong>
                <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="auto-style6" OnClick="btnLogin_Click" />
                </strong>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
