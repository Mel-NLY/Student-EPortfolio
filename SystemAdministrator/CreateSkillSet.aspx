<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdministrator/SystemAdminTemplate.Master" AutoEventWireup="true" CodeBehind="CreateSkillSet.aspx.cs" Inherits="WEBAssignmentCheckpoint1.SystemAdministrator.CreateSkillSet" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 200px;
        }
        .auto-style2 {
            width: 200px;
            height: 34px;
            font-family: Arial;
            font-weight: bold;
        }
        .auto-style3 {
            height: 34px;
        }
        .auto-style4 {
            width: 200px;
            font-family: Arial;
            font-weight: bold;
        }
        .auto-style5 {
            width: 200px;
            height: 35px;
            font-family: Arial;
            font-weight: bold;
        }
        .auto-style6 {
            height: 35px;
        }
        .auto-style7 {
            width: 200px;
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
            <td class="auto-style4">&nbsp;</td>
            <td class="auto-style8">Create Skill Set</td>
        </tr>
        <tr>
            <td class="auto-style2">&nbsp;</td>
            <td class="auto-style3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style5">Skill Sets</td>
            <td class="auto-style6">
                <asp:TextBox ID="txtSkillSetsCreated" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvSkillSets" runat="server" ControlToValidate="txtSkillSetsCreated" Display="Dynamic" ErrorMessage="Please enter something for skill sets"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cuvSkillSets" runat="server" CssClass="auto-style9" Display="Dynamic" ErrorMessage="Skill set already exist inside database please choose a new one" OnServerValidate="cuvSkillSets_ServerValidate"></asp:CustomValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style6">
                <asp:Button ID="btnSkillSetConfirm" runat="server" Text="Confirm" OnClick="btnSkillSetConfirm_Click" />
                &nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnSkillSetReset" runat="server" Text="Reset" CausesValidation="false" OnClick="btnSkillSetReset_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <asp:Label ID="lblSkillSetStatus" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
