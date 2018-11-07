<%@ Page Title="" Language="C#" MasterPageFile="~/Parent/ParentsTemplate.Master" AutoEventWireup="true" CodeBehind="SubmitViewingRequest.aspx.cs" Inherits="WEBAssignmentCheckpoint1.Parent.SubmitViewingRequest" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 190px;
        }
        .auto-style2 {
            width: 585px;
        }
        .auto-style3 {
            width: 200px;
        }
        .auto-style4 {
            width: 200px;
            height: 15px;
        }
        .auto-style5 {
            width: 190px;
            height: 15px;
        }
        .auto-style6 {
            width: 585px;
            height: 15px;
        }
        .auto-style7 {
            height: 15px;
        }
        .special
        {
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
        .auto-style8 {
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
    <table cellpadding="0" cellspacing="0" class="w-100">
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">
                <asp:Label ID="lblViewing" runat="server" Font-Bold="True" Font-Size="XX-Large" Text="Viewing Request"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1">
                <asp:Label ID="Label1" runat="server" Font-Size="Large" Text="Name of Parent:"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:Label ID="lblParent" runat="server"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style5"></td>
            <td class="auto-style6"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1">
                <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="Name of Child:"></asp:Label>
            </td>
            <td class="auto-style2">
                <asp:TextBox ID="txtChild" runat="server" Font-Bold="True"></asp:TextBox>
                <br />
                <asp:Label ID="lblError" runat="server"></asp:Label>
                <br />
                <asp:RequiredFieldValidator ID="rfvCheck" runat="server" ControlToValidate="txtChild" Display="Dynamic" ErrorMessage="* Please Insert Child's Name" Font-Bold="True" ForeColor="#FF3300"></asp:RequiredFieldValidator>
                <br />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style5"></td>
            <td class="auto-style6"></td>
            <td class="auto-style7"></td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">
                <asp:CheckBox ID="chkCorrect" runat="server" Text="The Above Information is Correct" />
                <br />
                <asp:Label ID="lblInfo" runat="server"></asp:Label>
                <br />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">
                <asp:Button ID="btnSubmit" runat="server" CssClass="auto-style8" Font-Bold="True" Text="Submit" OnClick="btnSubmit_Click" Width="90px" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
