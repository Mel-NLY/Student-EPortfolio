<%@ Page Title="" Language="C#" MasterPageFile="~/Mentor/MentorTemplate.Master" AutoEventWireup="true" CodeBehind="StudentSkillSetSearch.aspx.cs" Inherits="WEBAssignmentCheckpoint1.Mentor.StudentSkillSetSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 62px;
        }
        .auto-style4 {
            height: 37px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td class="auto-style1">
                <asp:Label ID="lblSearchSkill" runat="server" Text="Search Student Skill Sets" style="padding:7px;font-size:30px;font-weight:bold;font-family:'Segoe UI', Tahoma, Geneva, Verdana, sans-serif;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td style="background-color:lightgray;" class="auto-style4">
                <a href="/Mentor/MentorHomePage.aspx"><asp:Label ID="lblHomeSSSS" runat="server" Text="Home " style="padding-left: 10px;"></asp:Label></a>
                <asp:Label ID="lblSlashSSSS" runat="server" Text="/ "></asp:Label>
                <a href="/Mentor/StudentSkillSetSearch.aspx"><asp:Label ID="lblSearchSkillSSSS" runat="server" Text="Search Student Skill Sets"></asp:Label></a>
            </td>
        </tr>
        <tr>
            <td  style="padding-top:2em">
                <asp:Label ID="lblSearch" runat="server" Text="Search : "></asp:Label>
                <asp:DropDownList ID="ddlSearch" runat="server" AutoPostBack="True" OnSelectedIndexChanged="btnSearch_Click">
                    <asp:ListItem Value="All">All</asp:ListItem>
                    <asp:ListItem Value="ASP.NET">ASP.NET</asp:ListItem>
                    <asp:ListItem Value="HTML Scripting"></asp:ListItem>
                    <asp:ListItem Value="JavaScripting"></asp:ListItem>
                    <asp:ListItem Value="Agile Project Management"></asp:ListItem>
                    <asp:ListItem Value="User Experience Design"></asp:ListItem>
                    <asp:ListItem Value="Database Design"></asp:ListItem>
                    <asp:ListItem Value="Spreadsheet Engineering"></asp:ListItem>
                    <asp:ListItem Value="Data Analytics"></asp:ListItem>
                    <asp:ListItem Value="SAP Software Configuration"></asp:ListItem>
                    <asp:ListItem>Network Configuration</asp:ListItem>
                    <asp:ListItem>Web Design</asp:ListItem>
                    <asp:ListItem>Android Programming</asp:ListItem>
                    <asp:ListItem>iOS Programming</asp:ListItem>
                    <asp:ListItem>SAP ERP Solutions</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="gvSkillSet" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="StudentID" HeaderText="Student ID" />
                        <asp:BoundField DataField="Name" HeaderText="Student Name" />
                        <asp:BoundField DataField="Course" HeaderText="Course" />
                        <asp:BoundField DataField="SkillSetName" HeaderText="Skill Sets" />
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
                <asp:Label ID="lblNone" runat="server" style="margin:20px;"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
