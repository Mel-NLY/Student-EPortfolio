<%@ Page Title="" Language="C#" MasterPageFile="~/Student/StudentTemplate.Master" AutoEventWireup="true" CodeBehind="UpdatePortfolio.aspx.cs" Inherits="WEBAssignmentCheckpoint1.UpdatePortfolio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .title
        {
            font-size:30px;
            font-family:"Arial Black", Gadget, sans-serif;
        }
        .auto-style1 {
            height: 30px;
        }
        .auto-style2 {
            height: 30px;
            width: 203px;
        }
        .auto-style3 {
            width: 203px;
        }
        .auto-style4 {
            color: #666666;
            background-color: #FFFFFF;
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
        .buttons
        {
            font-family: Verdana, Geneva, sans-serif;
            color: black;
            background-color: aliceblue;
            border-radius: 5px;
        }
        .color
        {
            background-color: lightgrey;
            padding-top: 5px;
            padding-bottom: 5px;
        }
        .linkleft
        {
            padding-left: 15px;
        }
        .linkright
        {
            padding-right: 15px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table cellpadding="20" cellspacing="0" class="w-100">
        <tr>
            <td colspan="3">
                <asp:Label ID="lblTitle" class="title" runat="server" Text="Update Portfolio"></asp:Label>  
            </td>
        </tr>
        <tr>
            <td colspan="3">
            <a href="/Student/StudentHomePage.aspx"><asp:Label ID="lblHomePM" class="color fontInput linkleft" runat="server" Text="Home "></asp:Label></a>
            <asp:Label ID="lblSlash" class="fontInput color" runat="server" Text=" / "></asp:Label>
            <asp:Label ID="lblUpdatePortfolio" class="color fontInput linkright" runat="server" Text="Update Portfolio" style="color:#0000FF;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="font">Photo:</td>
            <td class="auto-style1">
                <asp:Image ID="imgStudentPhoto" class="fontInput" runat="server" Height="100px" BorderColor="Black" ForeColor="SkyBlue" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1 font">&nbsp;</td>
            <td class="auto-style3">
                <asp:FileUpload ID="upStudentPhoto" class="fontInput" runat="server" />
&nbsp;&nbsp;
                <br />
                <br />
&nbsp;<asp:Button ID="btnUpload" runat="server" class="fontInput buttons" OnClick="btnUpload_Click" Text="Upload" />
&nbsp;&nbsp;&nbsp;
                <asp:Label ID="lblMsg" class="fontInput" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2 font">Name:</td>
            <td class="auto-style1">
                &nbsp;
                <asp:Label ID="lblStudentName" class="fontInput color" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style3 font">About Me:</td>
            <td>
                <asp:TextBox ID="txtAboutMe" class="fontInput" runat="server" Height="150px" Width="802px" TextMode="MultiLine"></asp:TextBox>
            &nbsp;<asp:RequiredFieldValidator ID="rfvAboutMe" runat="server" ControlToValidate="txtAboutMe" ErrorMessage="Please enter a description of yourself" ForeColor="Red">*</asp:RequiredFieldValidator>
            &nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
        <tr>
            <td class="auto-style3 font">SkillSets:</td>
            <td>
                <asp:CheckBoxList ID="chkSkillSets" class="fontInput" runat="server">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3 font">Achievements:</td>
            <td>
                <asp:TextBox ID="txtAchievement" class="fontInput" runat="server" Width="772px"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td class="auto-style3"></td>
            <td>
                <asp:Button ID="btnUpdatePortfolio" class="button" runat="server" Height="80px" OnClick="btnUpdatePortfolio_Click" Text="Update!" Width="818px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style3">&nbsp;</td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            </td>
        </tr>
    </table>
</asp:Content>
