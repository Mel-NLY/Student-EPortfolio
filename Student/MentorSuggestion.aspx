<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentTemplate.Master" AutoEventWireup="true" CodeBehind="MentorSuggestion.aspx.cs" Inherits="WEBAssignmentCheckpoint1.MentorSuggestion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .title
        {
            font-size:30px;
            font-family:"Arial Black", Gadget, sans-serif;
        }
        .fontInput
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 20px;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td colspan="3" class="text-center">
                <asp:Label ID="lblTitle" class="title" runat="server" Text="Mentor's Suggestions"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td colspan="3" class="text-center">
            <a href="/Student/StudentHomePage.aspx"><asp:Label ID="lblHomePM" class="color fontInput linkleft" runat="server" Text="Home "></asp:Label></a>
            <asp:Label ID="lblSlash" class="fontInput color" runat="server" Text=" / "></asp:Label>
            <asp:Label ID="lblMenSugg" class="color fontInput linkright" runat="server" Text="Mentor's Suggestion" style="color:#0000FF;"></asp:Label>
            </td>
        </tr>
    </table>
    <div class="text-left">
&nbsp;<asp:GridView ID="gvMentorSuggestion" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowCommand="gvMentorSuggestion_RowCommand" Width="100%" BackColor="Purple" BorderColor="Purple">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775"/>
        <Columns>
            <asp:BoundField DataField="Name" HeaderText="Mentor Name" />
            <asp:BoundField DataField="Description" HeaderText="Suggestion" />
            <asp:BoundField DataField="Status" HeaderText="Acknowledged"/>
            <asp:HyperLinkField Text="View" DataNavigateUrlFields="SuggestionID" DataNavigateUrlFormatString="ViewSuggestion.aspx?suggestionid={0}" />
            <asp:ButtonField Text="Acknowledge" ButtonType="Button" CommandName="UpdateStatus" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    </div>
    <br />
</asp:Content>
