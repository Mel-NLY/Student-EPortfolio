<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdministrator/SystemAdminTemplate.Master" AutoEventWireup="true" CodeBehind="CreateStudentAccount.aspx.cs" Inherits="WEBAssignmentCheckpoint1.SystemAdministrator.CreateStudentAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 200px;
        }
        .auto-style6 {
            width: 200px;
            height: 35px;
        }
        .auto-style7 {
            height: 35px;
        }
        .auto-style8 {
            font-family: Arial;
            font-size: large;
            font-weight: bold;
        }
        .auto-style9 {
            font-family: "Segoe UI";
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="w-100">
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style8">Create Student Account</td>
        </tr>
        <tr>
            <td class="auto-style6">Student ID<br />
                <br />
                Name</td>
            <td class="auto-style7">
                <asp:Label ID="lblStudentID" runat="server"></asp:Label>
                <br />
                <br />
                <asp:TextBox ID="txtStudentName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvStudentName" runat="server" ControlToValidate="txtStudentName" Display="Dynamic" ErrorMessage="Please enter a name"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revStudentName" runat="server" ControlToValidate="txtStudentName" ErrorMessage="Only letters should be used" ValidationExpression="^[A-Za-z]*$"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Email Address</td>
            <td class="auto-style7">
                <asp:TextBox ID="txtStudentEmail" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revStudentEmail" runat="server" ControlToValidate="txtStudentEmail" Display="Dynamic" ErrorMessage="Please enter a valid email address" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                <asp:CustomValidator ID="cuvStudentEmail" runat="server" CssClass="auto-style9" Display="Dynamic" OnServerValidate="cuvStudentEmail_ServerValidate"></asp:CustomValidator>
                <asp:RequiredFieldValidator ID="rfvStudentEmail" runat="server" ControlToValidate="txtStudentEmail" ErrorMessage="Please enter student email address"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Course</td>
            <td class="auto-style7">
                <asp:TextBox ID="txtStudentCourse" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvStudentCourses" runat="server" ControlToValidate="txtStudentCourse" Display="Dynamic" ErrorMessage="Please enter a Course"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6">Mentor</td>
            <td class="auto-style7">
                <asp:DropDownList ID="ddlStudentMentor" runat="server">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvMentorDDL" runat="server" ControlToValidate="ddlStudentMentor" ErrorMessage="Please select a valid mentor option" InitialValue="--Select--"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style7">
                </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style7">
                <asp:Button ID="btnStudentConfirm" runat="server" Text="Confirm" OnClick="btnStudentConfirm_Click" />
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnStudentReset" runat="server" Text="Reset" CausesValidation="false" OnClick="btnStudentReset_Click" />
                <br />
                <asp:Label ID="lblStudentStatus" runat="server"></asp:Label>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>
