<%@ Page Title="" Language="C#" MasterPageFile="~/Parent/ParentsTemplate.Master" AutoEventWireup="true" CodeBehind="ViewChildPortfolio.aspx.cs" Inherits="WEBAssignmentCheckpoint1.Parent.ViewChildPortfolio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 205px;
        }
    </style>
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                &nbsp;<asp:GridView ID="gvSelectStudent" runat="server" OnSelectedIndexChanged="gvSelectStudent_SelectedIndexChanged" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField HeaderText="Name" DataField="Name" />
                        <asp:CommandField ShowSelectButton="True" />
                    </Columns>
                </asp:GridView>
                <br />
                <br />
                <asp:Label ID="lblStudProfile" runat="server" Text="Student Profile" Font-Bold="True" Font-Size="X-Large"></asp:Label>
                <br />
                <br />
                <asp:Image ID="imgView" Height ="250px" Width ="250px" runat="server" />
                <br />
                <br />
                <table class="w-100">
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label2" runat="server" Text="Course:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblCourse" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label4" runat="server" Text="Description:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblDescription" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label5" runat="server" Text="Achievement:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblAchievement" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1">
                            <asp:Label ID="Label6" runat="server" Text="External Link:"></asp:Label>
                        </td>
                        <td>
                            <asp:Label ID="lblLink" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                <asp:GridView ID="gvProject" runat="server">
                </asp:GridView>
                <br />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
