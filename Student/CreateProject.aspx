<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentTemplate.Master" AutoEventWireup="true" CodeBehind="CreateProject.aspx.cs" Inherits="WEBAssignmentCheckpoint1.CreateProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .title
        {
            font-size:30px;
            font-family:"Arial Black", Gadget, sans-serif;
        }
        .auto-style1 {
            width: 203px;
        }
        .auto-style2 {
            width: 203px;
            height: 74px;
        }
        .auto-style3 {
            height: 74px;
        }
        .font
        {   
            font-family: "Comic Sans MS", cursive, sans-serif;
            font-size: 25px;
            font-weight: bold;
        }
        .fontInput
        {
            font-family: Arial, Helvetica, sans-serif;
            font-size: 20px;
        }
         .button {
            margin-top: 2%;
            border: 2px ridge #800080;
            width: 25%;
            padding: 1%;
            background-color: #fff;
            font-size: 12pt;
            color: #808080;
            font-weight: bold;
            font-family: 'Segoe UI';
            border-radius: 15px;
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
            <td colspan="2">
                <asp:Label ID="lblTitle" class="title" runat="server" Text="Create Project"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td colspan="2">
            <a href="/Student/StudentHomePage.aspx"><asp:Label ID="lblHomePM" class="color fontInput linkleft" runat="server" Text="Home "></asp:Label></a>
            <asp:Label ID="lblSlash" class="fontInput color" runat="server" Text=" / "></asp:Label>
            <asp:Label ID="lblCreateProject" class="color fontInput linkright" runat="server" Text="Create Project" style="color:#0000FF;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style2 font">Project Name:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtProjName" class="fontInput" runat="server"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="rfvProjName" runat="server" ControlToValidate="txtProjName" ErrorMessage="Please enter a project name" ForeColor="Red">*</asp:RequiredFieldValidator>
            &nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="auto-style1 font">Members:</td>
            <td>
                <asp:TextBox ID="txtMember" class="fontInput" runat="server" type="text"></asp:TextBox>
            &nbsp;<asp:RegularExpressionValidator ID="revMember" runat="server" ControlToValidate="txtMember" ErrorMessage="Please enter a valid member name that does not contain any numerals" ForeColor="Red" ValidationExpression="[a-zA-Z\s,]*$">*</asp:RegularExpressionValidator>
            <br />
                <asp:Label ID="lblnaming" runat="server" Text="[Please enter the FULL name of your member and if you have more than one member, <br> enter them in this format eg. John Tan,Amy Ng,Raymond Smith]" style="color:cadetblue;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1 font">Project Description:</td>
            <td>
                <br />
                <asp:TextBox ID="txtProjDescription" class="fontInput" runat="server" Height="150px" Width="950px"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="rfvProjDesc" runat="server" ControlToValidate="txtProjDescription" ErrorMessage="Please enter a project description" ForeColor="Red">*</asp:RequiredFieldValidator>
                &nbsp;&nbsp;
                <br />
            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td>
                <br />
                <asp:Button ID="btnCreate" class="button" runat="server" Text="Create" Width="950px" Height="80px" OnClick="btnCreate_Click" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            </td>
        </tr>
    </table>
</asp:Content>
