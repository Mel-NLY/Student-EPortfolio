<%@ Page Title="" Language="C#" MasterPageFile="~/HomeTemplate.Master" AutoEventWireup="true" CodeBehind="StudentePortfolio.aspx.cs" Inherits="WEBAssignmentCheckpoint1.StudentePortfolio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            width: 1097px;
            color: #666666;
            text-align: center;
        }
        
        table tr td
        {
            border-collapse: collapse;
            border: 1px solid black;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 class="auto-style5"><strong>Student ePortfolios</strong></h1>
    <br />
    <br />
    <asp:GridView ID="gvStudentPortfolio" runat="server" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" AutoGenerateColumns="False" Width="100%">
        <AlternatingRowStyle BackColor="#CCCCCC" />
        <Columns>
            <asp:ImageField DataImageUrlField="StudentID" DataImageUrlFormatString="~/Images/Student/{0}.jpg" HeaderText="Student Photo">
                <ControlStyle Height="150px" Width="120px" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:ImageField>
            <asp:BoundField DataField="Name" HeaderText="Student Name" >
            <ControlStyle Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Course" HeaderText="Course">
            <ControlStyle Width="80px" />
            </asp:BoundField>
            <asp:BoundField DataField="ExternalLink" HeaderText="External Link">
            <ControlStyle Width="6000px" />
            </asp:BoundField>
            <asp:HyperLinkField DataNavigateUrlFields="StudentID,Name" DataNavigateUrlFormatString="Portfolio.aspx?studentid={0}&amp;name={1}" Text="View" >
            <ControlStyle Width="80px" />
            <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:HyperLinkField>
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <br />
</asp:Content>
