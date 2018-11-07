<%@ Page Title="" Language="C#" MasterPageFile="~/Mentor/MentorTemplate.Master" AutoEventWireup="true" CodeBehind="Suggestions.aspx.cs" Inherits="WEBAssignmentCheckpoint1.Mentor.Suggestions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 74px;
        }
        .auto-style2 {
            height: 43px;
        }
        .auto-style3{
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
        .auto-style4 {
            font-weight: bold;
            font-size: 30px;
        }
        .auto-style5 {
            border: 2px ridge #800080;
            width: 25%;
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
    <table class="w-100">
        <tr>
            <td colspan="4">
                <asp:Label ID="lblProfileSugg" runat="server" class="auto-style4"></asp:Label>
                <span class="auto-style4">&nbsp;- Suggestions</span></td>
            <td class="auto-style30">
                &nbsp;</td>
        </tr>
        <tr style="background-color:lightgray; padding-bottom:4em">
            <td class="auto-style2" colspan="4" >
                <a href="/Mentor/MentorHomePage.aspx" style="padding-left: 10px;"><asp:Label ID="lblHomePSP" runat="server" Text="Home " style="padding-left: 10px;"></asp:Label></a>
                <asp:Label ID="lblSlashPSP" runat="server" Text="/ "></asp:Label>
                <a href="/Mentor/PendingStudentPortfolios.aspx"><asp:Label ID="lblPendingStudentPortfoliosPSP" runat="server" Text="Pending Student Portfolios"></asp:Label></a>
                <asp:Label ID="Label1" runat="server" Text="/ "></asp:Label>
                <a href="/Mentor/Suggestions.aspx"><asp:Label ID="lblProfileSuggBar" runat="server" style="font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;"></asp:Label><asp:Label ID="Label4" runat="server" Text="- Suggestions"></asp:Label></a>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" >
                &nbsp;</td>
            <td class="auto-style1" style="padding-top:5%" colspan="2">
                <asp:GridView ID="gvSuggestions" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="Description" HeaderText="Previous Suggestions" />
                        <asp:BoundField DataField="DateCreated" HeaderText="Date Created" />
                        <asp:BoundField DataField="Status" HeaderText="Suggestion Status" />
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
            <td class="auto-style1" >
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" >
                &nbsp;</td>
            <td class="auto-style1" style="padding-top:5%">
                Enter Suggestion :</td>
            <td class="auto-style1" style="padding-top:5%">
                <asp:TextBox ID="tbSuggestions" runat="server" Height="155px" Width="598px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvSuggestion" runat="server" ControlToValidate="tbSuggestions" ErrorMessage="*Suggestion box cannot be left empty" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            <td class="auto-style1" >
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style1" >
                &nbsp;</td>
            <td class="auto-style1" >
                &nbsp;</td>
            <td class="auto-style1" >
                <asp:Button ID="btnSubmit" CssClass="auto-style3" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
                <asp:Button ID="btnApproveProfile" CssClass="auto-style5" runat="server" Text="Approve Profile" OnClick="btnApproveProfile_Click" CausesValidation="false" />
                <asp:Label ID="lblMessage" runat="server"></asp:Label>
            </td>
            <td class="auto-style1" >
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
