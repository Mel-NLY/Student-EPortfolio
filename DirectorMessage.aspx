<%@ Page Title="" Language="C#" MasterPageFile="~/HomeTemplate.Master" AutoEventWireup="true" CodeBehind="DirectorMessage.aspx.cs" Inherits="WEBAssignmentCheckpoint1.DirectorMessage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 483px;
        }
        .auto-style2 {
            margin-right: 0px;
        }
        .auto-style5 {
            width: 1609px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="w-100">
        <tr>
            <td colspan="2">
                <h1 class="auto-style5" style="width: 1097px; color: #666666; text-align: center;"><strong>Director's Message</strong></h1>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" style="padding-top:30px">
                <asp:Image ID="imgDirector" runat="server" CssClass="auto-style2" ImageAlign="Middle" ImageUrl="/Images/ICTDirector.jpg" Width="80%" />
            </td>
            <td class="auto-style5" style="padding-top:30px">
                <asp:Label style="font-weight:500;" ID="lblMessage" runat="server" Text="&lt;b&gt;Dear ICTians, &lt;b/&gt;&lt;br&gt;"></asp:Label>
                <br />
                <asp:Label style="font-weight:200;" ID="lblDirectorMessage2" runat="server" Text="The School of ICT has organised this annual showcase to celebrate the successful completion of our graduates’ journey in NP. This event is also a showcase of your skills, knowledge, passion and creativity to prepare you for the industry or even further studies.&lt;br&gt;"></asp:Label>
                <br />
                <asp:Label style="font-weight:200;" ID="lblDirectorMessage3" runat="server" Text="As you graduate with a diploma earned through 3 years of learning journey with us, I believe it will open up many exciting opportunities and pathways for you. As digital business transformation becomes a driving force for small and large enterprises, your skills become valuable in helping these companies innovate and scale up. Being in an industry that changes very rapidly, it is important for you to recognise that you need to pursue knowledge, competencies and skills continually throughout your career. Education doesn't stop after you graduate from NP, or for some of you, from the University."></asp:Label>
                <br />
                <br />
                <asp:Label style="font-weight:200;" ID="lblDirectorMessage4" runat="server" Text="I want to congratulate every graduating ICTian and offer you my best wishes in all your future endeavours."></asp:Label>
                <br />
                <br />
                <asp:Label style="font-weight:200;" ID="lblDirectorMessage5" runat="server" Text="In closing, I would like to take this opportunity to thank our important stakeholders namely our Advisory Committee, industry partners, University partners, ICT staff, alumni and parents who have all contributed and supported us in the learning journey of every ICTian."></asp:Label>
                <br />
                <asp:Label style="font-weight:500;" ID="lblDirectorMessage6" runat="server" Text="&lt;br&gt;&lt;b&gt;Yours Sincerely, &lt;br&gt;Ng Poh Oon&lt;b/&gt;"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
        </tr>
    </table>
</asp:Content>
