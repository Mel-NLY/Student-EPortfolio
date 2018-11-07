<%@ Page Title="" Language="C#" MasterPageFile="~/Mentor/MentorTemplate.Master" AutoEventWireup="true" CodeBehind="Project.aspx.cs" Inherits="WEBAssignmentCheckpoint1.Mentor.PendingStudentPortfolios_Project" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
        .auto-style24 {
            font-family: "Segoe UI";
            font-weight: bold;
            font-size: 30px;
        }
        .auto-style25 {
            height: 94px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td class="auto-style25">
                <asp:Label ID="lblName" runat="server" CssClass="auto-style24"></asp:Label>
                <span class="auto-style24">&nbsp;- Projects</span></td>
        </tr>
        <tr style="background-color:lightgray; padding-bottom:4em">
            <td class="auto-style1" >
                <a href="/Mentor/MentorHomePage.aspx" style="padding-left: 10px;"><asp:Label ID="lblHomePSP" runat="server" Text="Home " style="padding-left: 10px;"></asp:Label></a>
                <asp:Label ID="lblSlashPSP" runat="server" Text="/ "></asp:Label>
                <a href="/Mentor/PendingStudentPortfolios.aspx"><asp:Label ID="lblPendingStudentPortfoliosPSP" runat="server" Text="Pending Student Portfolios"></asp:Label></a>
                <asp:Label ID="Label1" runat="server" Text="/ "></asp:Label>
                <a href="/Mentor/Project.aspx"><asp:Label ID="lblNameBar" runat="server"></asp:Label><asp:Label ID="Label2" runat="server" Text=" - Projects"></asp:Label></a>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvProjects" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" style="margin-top:20px">
                    <Columns>
                        <asp:ImageField DataImageUrlField="ProjectPoster" DataImageUrlFormatString="~/Images/Project/{0}" HeaderText="Project Poster">
                            <ControlStyle Width="100px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="Title" HeaderText="Title" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:HyperLinkField DataTextField="ProjectURL" HeaderText="Project URL" />
                        <asp:BoundField DataField="Role" HeaderText="Role" />
                        <asp:BoundField DataField="Reflection" HeaderText="Reflection" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
                <asp:Label ID="lblNone" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
</asp:Content>
