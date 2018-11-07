<%@ Page Title="" Language="C#" MasterPageFile="~/Parent/ParentsTemplate.Master" AutoEventWireup="true" CodeBehind="PostMessageToMentor.aspx.cs" Inherits="WEBAssignmentCheckpoint1.Parent.PostMessageToMentor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 310px;
        }
        .auto-style2 {
            width: 131px;
        }
        .auto-style3 {
            width: 301px;
        }
        .auto-style4 {
            width: 310px;
            height: 30px;
        }
        .auto-style5 {
            width: 131px;
            height: 20px;
        }
        .auto-style6 {
            width: 301px;
            height: 20px;

        }
        .auto-style7 {
            height: 30px;
        }
        .auto-style8 {
            width: 310px;
            height: 20px;
        }
        .auto-style9 {
            height: 20px;
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
        .auto-style10 {
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
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">
                <asp:Label ID="lblMName" runat="server" Text="Mentor Name:"></asp:Label>
            </td>
            <td class="auto-style3">
                <asp:GridView ID="gvmentor" runat="server" DataKeyNames ="MentorID" OnSelectedIndexChanged="gvmentor_SelectedIndexChanged">
                    <Columns>
                        <asp:CommandField ButtonType="Button" ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8"></td>
            <td class="auto-style5"></td>
            <td class="auto-style6">
                <asp:Label ID="lblMentor" runat="server"></asp:Label>
            </td>
            <td class="auto-style9"></td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style5">
                <asp:Label ID="Label2" runat="server" Text="Title:"></asp:Label>
            </td>
            <td class="auto-style6">
                <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                <br />
                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle" Display="Dynamic" ErrorMessage="Please Insert a Title" ForeColor="#CC3300"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style9">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td class="auto-style9">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style7" colspan="2">
                <asp:Label ID="lblMentorMessage" runat="server" Font-Size="Large" Text="Message to Mentor:"></asp:Label>
            </td>
            <td class="auto-style7">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td colspan="2" rowspan="2">
                <asp:TextBox ID="txtMessage" runat="server" Height="200px" Width="450px" TextMode="MultiLine"></asp:TextBox>
                <br />
                <br />
                <asp:RequiredFieldValidator ID="rfvMessage" runat="server" ControlToValidate="txtMessage" ErrorMessage="*Please Insert a Message" ForeColor="#CC3300"></asp:RequiredFieldValidator>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td colspan="2">
                <asp:Label ID="lblAlert" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="#CC3300"></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style2">
                <asp:Button ID="btnSubmit" runat="server" CssClass="auto-style10" Font-Bold="True" Font-Size="Medium" Text="Submit" OnClick="btnSubmit_Click" Width="120px" />
            </td>
            <td class="auto-style3">&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
