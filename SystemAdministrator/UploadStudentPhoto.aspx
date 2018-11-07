<%@ Page Title="" Language="C#" MasterPageFile="~/SystemAdministrator/SystemAdminTemplate.Master" AutoEventWireup="true" CodeBehind="UploadStudentPhoto.aspx.cs" Inherits="WEBAssignmentCheckpoint1.SystemAdministrator.UploadStudentPhoto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            width: 200px;
            height: 24px;
        }
        .auto-style3 {
            height: 24px;
            font-family: Arial;
            font-weight: bold;
            font-size: large;
        }
        .auto-style4 {
            width: 200px;
            height: 35px;
        }
        .auto-style5 {
            height: 35px;
        }
        .auto-style6 {
            width: 200px;
            height: 90px;
        }
        .auto-style7 {
            height: 90px;
        }
        .auto-style8 {
            width: 200px;
            height: 34px;
        }
        .auto-style9 {
            height: 34px;
        }
        .auto-style10 {
            font-family: "Segoe UI";
            font-size: medium;
            color: #FF0000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="0" cellspacing="0" class="w-100">
        <tr>
            <td class="auto-style2"></td>
            <td class="auto-style3">Upload Student Photos</td>
        </tr>
        <tr>
            <td class="auto-style4">Name of Student:<br />
                <br />
                </td>
            <td class="auto-style5">
                <asp:DropDownList ID="ddlChooseStudent" runat="server" Height="21px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvStudentDdl" runat="server" ControlToValidate="ddlChooseStudent" ErrorMessage="Please select a valid option" InitialValue="--Select--"></asp:RequiredFieldValidator>
                <br />
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style8">Image Upload:</td>
            <td class="auto-style9">
                <asp:FileUpload ID="upPhoto" runat="server" />
                <asp:CustomValidator ID="cuvImgExtension" runat="server" OnServerValidate="cuvImgExtension_ServerValidate1"></asp:CustomValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="upPhoto" ErrorMessage="Only jpeg file is allowed" ValidationExpression="(.*jpg$)"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style6"></td>
            <td class="auto-style7">
                <asp:Label ID="lblMsg" runat="server" CssClass="auto-style10"></asp:Label>
                <br />
                <asp:Image ID="imgStudentPhoto" runat="server" Height="75px" Width="119px" />
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style5">
                &nbsp;
                <asp:Button ID="btnImgConfirm" runat="server" Text="Confirm" OnClick="btnImgConfirm_Click" />
                &nbsp;&nbsp;&nbsp;
                </td>
        </tr>
    </table>
</asp:Content>
