<%@ Page Title="" Language="C#" MasterPageFile="~/HomeTemplate.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WEBAssignmentCheckpoint1.CreateParentAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 310px;
        }
        .auto-style2 {
            width: 132px;
        }
        .auto-style3 {
            width: 310px;
            height: 15px;
        }
        .auto-style4 {
            width: 132px;
            height: 15px;
        }
        .auto-style5 {
            height: 15px;
        }
        .auto-style6 {
            height: 62px;
        }
        .auto-style7 {
            width: 310px;
            height: 36px;
        }
        .auto-style8 {
            width: 132px;
            height: 36px;
        }
        .auto-style9 {
            height: 36px;
        }
        .auto-style10 {
            width: 310px;
            height: 44px;
        }
        .auto-style11 {
            width: 132px;
            height: 44px;
        }
        .auto-style12 {
            height: 44px;
        }
        .special{
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
        .auto-style13 {
            border: 2px ridge #800080;
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
    <table class="w-100" >
        <tr>
            <td class="auto-style6" colspan="4">
                <h1 class="auto-style5" style="width: 1097px; color: #666666; text-align: center;"><strong>Create Parent Account</strong></h1>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style7">
                <asp:Label ID="lblName" runat="server" Font-Size="Large" Text="Name:"></asp:Label>
            </td>
            <td class="auto-style7">
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName" Display="Dynamic" ErrorMessage="Please Enter Name" Font-Bold="True" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <br />
                <br />
            </td>
            <td class="auto-style8"></td>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblEmail" runat="server" Font-Size="Large" Text="Email Address:"></asp:Label>
            </td>
            <td class="auto-style1">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Please Enter Email" Font-Bold="True" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <br />
                <asp:RegularExpressionValidator ID="revValidEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="Please Enter Valid Email" Font-Bold="True" ForeColor="#CC3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <br />
                <asp:CustomValidator ID="cuvEmail" runat="server" Display="Dynamic" ErrorMessage="* E-mail address has been used." Font-Bold="True" ForeColor="#CC3300" OnServerValidate="cuvEmail_ServerValidate"></asp:CustomValidator>
                <br />
            </td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td class="auto-style3"></td>
            <td class="auto-style4"></td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:RequiredFieldValidator ID="rfvPassword" runat="server" Display="Dynamic" ErrorMessage="Please Enter Password" Font-Bold="True" ForeColor="#CC3300" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                <br />
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ></asp:TextBox>
                <br />
            </td>
            <td class="auto-style4"></td>
            <td class="auto-style5"></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3">
                &nbsp;</td>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style10"></td>
            <td class="auto-style10">
                <asp:Button ID="btnCreate" runat="server" Text="Create Account" CssClass="auto-style13" Font-Bold="True" Font-Size="Large" OnClick="btnCreate_Click" Width="190px" />
            </td>
            <td class="auto-style11"></td>
            <td class="auto-style12"></td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
