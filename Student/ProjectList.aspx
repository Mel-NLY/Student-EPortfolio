<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentTemplate.Master" AutoEventWireup="true" CodeBehind="ProjectList.aspx.cs" Inherits="WEBAssignmentCheckpoint1.ProjectList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .title
        {
            font-size:30px;
            font-family:"Arial Black", Gadget, sans-serif;
        }
         .linkleft
        {
            padding-left: 15px;
        }
        .linkright
        {
            padding-right: 15px;
        }
        .color
        {
            background-color: lightgrey;
            padding-top: 5px;
            padding-bottom: 5px;
        }
        .fontInput
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td class="text-center">
                <asp:Label ID="lblTitle" class="title" runat="server" Text="Projects"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td class="text-center fontInput">
            <a href="/Student/StudentHomePage.aspx"><asp:Label ID="lblHomePM" class="color fontInput linkleft" runat="server" Text="Home "></asp:Label></a>
            <asp:Label ID="lblSlash" class="fontInput color" runat="server" Text=" / "></asp:Label>
            <asp:Label ID="lblProjectList" class="color fontInput linkright" runat="server" Text="Project List" style="color:#0000FF;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="text-center">
                &nbsp;</td>
        </tr>
    </table>
    <asp:GridView ID="gvProjectList" runat="server" BackColor="#CCCCCC" BorderColor="#999999" BorderStyle="Solid" BorderWidth="3px" CellPadding="4" CellSpacing="2" ForeColor="Black" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Project Name">
            <ControlStyle Height="20px" Width="120px" />
            </asp:BoundField>
            <asp:BoundField DataField="Description" HeaderText="Project Description">
            <ControlStyle Height="20px" Width="50px" />
            </asp:BoundField>
            <asp:HyperLinkField Text="View" DataNavigateUrlFields="ProjectID" DataNavigateUrlFormatString="Project.aspx?projectid={0}" />
            <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="ProjectID" DataNavigateUrlFormatString="UpdateProject.aspx?projectid={0}" />
            <asp:HyperLinkField DataNavigateUrlFields="ProjectID" DataNavigateUrlFormatString="ProjectReflection.aspx?projectid={0}" Text="Reflection" />
        </Columns>
        <FooterStyle BackColor="#CCCCCC" />
        <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#CCCCCC" ForeColor="Black" HorizontalAlign="Left" />
        <RowStyle BackColor="White" />
        <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#808080" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#383838" />
    </asp:GridView>
    <br />
    </asp:Content>
