<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentTemplate.Master" AutoEventWireup="true" CodeBehind="UpdateProject.aspx.cs" Inherits="WEBAssignmentCheckpoint1.UpdateProject" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .title
        {
            font-size:30px;
            font-family:"Arial Black", Gadget, sans-serif;
        }
        .buttons
        {
            font-family: Verdana, Geneva, sans-serif;
            color: black;
            background-color: aliceblue;
            border-radius: 5px;
        }
        .auto-style1 {
            width: 204px;
        }
        .auto-style2 {
            font-weight: 600;
        }
        .auto-style3 {
            color: #666666;
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
    <table cellpadding="20" cellspacing="0" class="w-100">
        <tr>
            <td colspan="3">
                <asp:Label ID="lblTitle" class="title" runat="server" Text="Update Project"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td colspan="3" style="background-color:lightgray;" class="fontInput">
            <a href="/Student/StudentHomePage.aspx"><asp:Label ID="lblHomePM" runat="server" Text="Home "></asp:Label></a>
            <asp:Label ID="lblSlash" runat="server" Text=" / "></asp:Label>
            <a href="/Student/ProjectList.aspx"><asp:Label ID="lblProjectList" runat="server" Text="Project List"></asp:Label></a>
            <asp:Label ID="lblSlash2" runat="server" Text=" / "></asp:Label>
            <asp:Label ID="lblUpdateProject" runat="server" Text="Update Project" style="color:#0000FF;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style3">
                <asp:Image ID="imgPoster" class="fontInput" runat="server" Height="100px" BorderColor="Black" ForeColor="SkyBlue"/>
            </td>
        </tr>
        <tr>
            <td class="auto-style1 font">Poster:</td>
            <td class="auto-style3">
                <asp:FileUpload ID="upPoster" class="fontInput" runat="server" />
&nbsp;&nbsp;
                <br />
                <br />
&nbsp;<asp:Button ID="btnUpload" class="fontInput buttons" runat="server" OnClick="btnUpload_Click" Text="Upload" />
&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMsg" class="fontInput" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1 font">Project Name:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtUpdateProjName" class="fontInput" runat="server" Width="407px"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="rfvUpdateProjName" runat="server" ControlToValidate="txtUpdateProjName" ErrorMessage="Please enter a project name" ForeColor="Red">*</asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="auto-style1 font">Project URL:</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtURL" class="fontInput" runat="server" Width="632px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1 font">Leader:</td>
            <td>
                <asp:Label ID="lblLeader" class="fontInput" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1 font">Members:</td>
            <td>
                <asp:TextBox ID="txtMember" class="fontInput" runat="server" text=" " Width="399px"></asp:TextBox>
                 &nbsp;<asp:RegularExpressionValidator ID="revMember" runat="server" ControlToValidate="txtMember" ErrorMessage="Please enter a valid member name that does not contain any numerals" ForeColor="Red" ValidationExpression="[a-zA-Z\s,]*$">*</asp:RegularExpressionValidator>
            <br />
                <asp:Label ID="lblnaming" runat="server" Text="[Please enter the FULL name of your member and if you have more than one member, <br> enter them in this format eg. John Tan,Amy Ng,Raymond Smith]" style="color:cadetblue;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1 font">Project Description:</td>
            <td>
                <asp:TextBox ID="txtUpdateProjDescription" class="fontInput" runat="server" Height="150px" Width="950px" TextMode="MultiLine"></asp:TextBox>
                &nbsp;<asp:RequiredFieldValidator ID="rfvUpdateProjDesc" runat="server" ControlToValidate="txtUpdateProjDescription" ErrorMessage="Please enter a project description" ForeColor="Red">*</asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>
            &nbsp;&nbsp;<asp:Button ID="btnUpdateProject" class="button" runat="server" Height="80px" OnClick="btnUpdateProject_Click" Text="Update" Width="360px" />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnReflection" class="button" runat="server" Height="80px" OnClick="btnReflection_Click" Text="Reflection" Width="360px" />
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
