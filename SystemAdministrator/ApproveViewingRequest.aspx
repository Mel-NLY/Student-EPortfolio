<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdministrator/SystemAdminTemplate.Master" AutoEventWireup="true" CodeBehind="ApproveViewingRequest.aspx.cs" Inherits="WEBAssignmentCheckpoint1.SystemAdministrator.ApproveViewingRequestSysAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="w-100">
        <tr>
            <td class="auto-style1">Approve Viewing Request:</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <asp:GridView ID="gvViewingRequest" runat="server" AllowPaging="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCommand="gvViewingRequest_RowCommand" PageSize="5">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="ViewingRequestID" HeaderText="Viewing Request ID" />
                        <asp:BoundField DataField="ParentID" HeaderText="Parent ID" />
                        <asp:BoundField DataField="StudentName" HeaderText="Student Name" />
                        <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                        <asp:BoundField DataField="Status" HeaderText="Status" />
                        <asp:ButtonField CommandName="Approve" Text="Approve" />
                        <asp:ButtonField CommandName="Reject" Text="Reject" />
                    </Columns>
                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                    <SortedAscendingCellStyle BackColor="#FDF5AC" />
                    <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                </asp:GridView>
                <asp:Label ID="lblUpdate" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
