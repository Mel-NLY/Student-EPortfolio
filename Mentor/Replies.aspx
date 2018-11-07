<%@ Page Title="" Language="C#" MasterPageFile="~/Mentor/MentorTemplate.Master" AutoEventWireup="true" CodeBehind="Replies.aspx.cs" Inherits="WEBAssignmentCheckpoint1.Mentor.Replies" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style3 {
            width: 364px;
        }
        .auto-style4 {
            width: 361px;
        }
        .auto-style5 {
            font-size: 30px;
            font-weight: 400;
        }
        .auto-style6 {
            width: 9px;
        }
        .auto-style7 {
            width: 87px;
        }
        .auto-style8 {
            font-family: "Segoe UI";
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td colspan="3">
                <asp:Label ID="lblReplies" runat="server" Text="Replies" style="padding:7px;font-size:30px;font-weight:bold;font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;"></asp:Label>
            </td>
        </tr>
        <tr style="background-color:lightgray;">
            <td colspan="3" class="auto-style4">
                <a href="/Mentor/MentorHomePage.aspx"><asp:Label ID="lblHomePM" runat="server" Text="Home "></asp:Label></a>
                <asp:Label ID="lblSlashPM" runat="server" Text=" / "></asp:Label>
                <a href="/Mentor/ParentMessages.aspx"><asp:Label ID="lblParentMessagesPM" runat="server" Text="Parent Messages"></asp:Label></a>
                <asp:Label ID="Label1" runat="server" Text=" / "></asp:Label>
                <a href="/Mentor/Replies.aspx"><asp:Label ID="Label2" runat="server" Text="Replies"></asp:Label></a>
            </td>
        </tr>
        <tr>
            <td colspan="3" class="auto-style5">
                <asp:Label ID="lblOriginalParent" runat="server" CssClass="auto-style8"></asp:Label>
                <span class="auto-style8">&nbsp;:
                <asp:Label ID="lblOriginalMessage" runat="server"></asp:Label>
                </span>
            </td>
        </tr>
        <tr >
            <td style="padding-top:2%" colspan="3">
                <asp:GridView ID="gvReply" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="MentorName" HeaderText="From Mentor" />
                        <asp:BoundField DataField="ParentName" HeaderText="From Parent" />
                        <asp:BoundField DataField="Text" HeaderText="Replies" />
                        <asp:BoundField DataField="DateTimePosted" HeaderText="DateTime Posted" />
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
        <tr >
            <td class="auto-style6" style="padding-top:2%">
                <asp:Label ID="lblMentor" runat="server" Text="Mentor : "></asp:Label>
            </td>
            <td class="auto-style4" style="padding-top:2%" colspan="2">
                <asp:Label ID="lblMentorName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="auto-style6" style="padding-top:2%">
                <asp:Label ID="lblParent" runat="server" Text="To : "></asp:Label>
            </td>
            <td class="auto-style7" style="padding-top:2%">
                <asp:Label ID="lblParentName" runat="server"></asp:Label>
            </td>
            <td class="auto-style3" style="padding-top:2%">
                <asp:Label ID="lblChild" runat="server" Text="Parent/Guardian of : "></asp:Label>
                <asp:Label ID="lblStudent" runat="server"></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="auto-style6" style="padding-top:2%">
                Message :
            </td>
            <td class="auto-style4" style="padding-top:2%" colspan="2">
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
        </tr>
        <tr >
            <td class="auto-style6" style="padding-top:2%">
                <asp:Label ID="lblReply" runat="server" Text="Reply : "></asp:Label>
            </td>
            <td class="auto-style4" style="padding-top:2%" colspan="2">
                <asp:TextBox ID="tbReply" runat="server" Height="133px" Width="606px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvReply" runat="server" ControlToValidate="tbReply" ErrorMessage="*Reply box cannot be left empty" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">
                &nbsp;</td>
            <td class="auto-style4" colspan="2">
                <asp:Button ID="btnSubmitReply" runat="server" Text="Submit Reply" style="margin-top:2%;border: 2px ridge #800080;
            width: 25%;
            padding: 1%;
            background-color: #fff;font-size: 12pt;
            color: #808080;
            font-weight: bold;
            border-radius: 5px; font-family:'Segoe UI'
        }" OnClick="btnSubmitReply_Click"/>
                <asp:Label ID="lblSuccessful" runat="server"></asp:Label>
            </td>
        </tr>
 </table>
</asp:Content>
