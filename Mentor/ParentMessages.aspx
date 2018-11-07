<%@ Page Title="" Language="C#" MasterPageFile="~/Mentor/MentorTemplate.Master" AutoEventWireup="true" CodeBehind="ParentMessages.aspx.cs" Inherits="WEBAssignmentCheckpoint1.Mentor.ParentMessages" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style4 {
            height: 36px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td>
                <asp:Label ID="lblParentMessages" runat="server" Text="Parent Messages" style="padding:7px;font-size:30px;font-weight:bold;font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;"></asp:Label>
            </td>
        </tr>
        <tr style="background-color:lightgray;">
            <td class="auto-style4">
                <a href="/Mentor/MentorHomePage.aspx" style="padding-left: 10px;"><asp:Label ID="lblHomePM" runat="server" Text="Home "></asp:Label></a>
                <asp:Label ID="lblSlashPM" runat="server" Text=" / "></asp:Label>
                <a href="/Mentor/ParentMessages.aspx"><asp:Label ID="lblParentMessagesPM" runat="server" Text="Parent Messages"></asp:Label></a>
            </td>
        </tr>
        <tr>
            <td style="padding-top:2em;">
                <asp:GridView ID="gvParentMessage" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="MessageID" HeaderText="Message ID" />
                        <asp:BoundField DataField="ParentName" HeaderText="Parent Name" />
                        <asp:BoundField DataField="DateTimePosted" HeaderText="DateTime Posted" />
                        <asp:BoundField DataField="DateTimeUpdated" HeaderText="DateTime Updated" />
                        <asp:HyperLinkField DataNavigateUrlFields="MessageID" DataNavigateUrlFormatString="Replies.aspx?MessageId={0}&amp;ParentId={0}" Text="Reply" />
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
            </td> 
        </tr>
        </table>
</asp:Content>
