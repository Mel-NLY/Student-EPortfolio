<%@ Page Title="" Language="C#" MasterPageFile="~/Mentor/MentorTemplate.Master" AutoEventWireup="true" CodeBehind="PendingStudentPortfolios.aspx.cs" Inherits="WEBAssignmentCheckpoint1.Mentor.PendingStudentPortfolios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 35px;
        }
        .auto-style41 {
            height: 62px;
        }
        .auto-style42 {
            height: 52px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td class="auto-style41">
                <asp:Label ID="lblPendingStudentPortfolios" runat="server" Text="Pending Student Portfolios" style="padding:7px;font-size:30px;font-weight:bold;font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;"></asp:Label>
            </td>
        </tr>
        <tr style="background-color:lightgray;">
            <td class="auto-style1" >
                <a href="/Mentor/MentorHomePage.aspx" style="padding-left: 10px;"><asp:Label ID="lblHomePSP" runat="server" Text="Home " style="padding-left: 10px;"></asp:Label></a>
                <asp:Label ID="lblSlashPSP" runat="server" Text="/ "></asp:Label>
                <a href="/Mentor/PendingStudentPortfolios.aspx"><asp:Label ID="lblPendingStudentPortfoliosPSP" runat="server" Text="Pending Student Portfolios"></asp:Label></a>
            </td>
        </tr>
        <tr>
            <td class="auto-style42">
                <asp:GridView ID="gvStudentProfile" runat="server" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" style="margin:20px" AllowPaging="True" OnPageIndexChanging="gvStudentProfile_PageIndexChanging" PageSize="2" OnRowUpdating="gvStudentProfile_RowUpdating">
                    <Columns>
                        <asp:ImageField DataImageUrlField="Photo" DataImageUrlFormatString="~/Images/Student/{0}" HeaderText="Photo">
                            <ControlStyle Width="100px" />
                        </asp:ImageField>
                        <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                        <asp:BoundField DataField="Name" HeaderText="Student Name" />
                        <asp:BoundField DataField="Course" HeaderText="Course" />
                        <asp:BoundField DataField="Description" HeaderText="Description" />
                        <asp:BoundField DataField="Achievement" HeaderText="Achievement" />
                        <asp:CheckBoxField DataField="Status" HeaderText="Profile Approved" ValidateRequestMode="Enabled" >
                        <ControlStyle Width="50px" />
                        </asp:CheckBoxField>
                        <asp:HyperLinkField DataNavigateUrlFields="StudentId" DataNavigateUrlFormatString="Project.aspx?StudentId={0}" Text="View Projects" />
                        <asp:HyperLinkField DataNavigateUrlFields="StudentId" DataNavigateUrlFormatString="Suggestions.aspx?StudentId={0}&amp;SuggestionId={0}" Text="Add Suggestions" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" ForeColor="Black"/>
                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Center" />
                    <SelectedRowStyle BackColor="#CC3333" Font-Bold="False" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#F7F7F7" />
                    <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                    <SortedDescendingCellStyle BackColor="#E5E5E5" />
                    <SortedDescendingHeaderStyle BackColor="#242121" />
                </asp:GridView>
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        </table>
</asp:Content>
