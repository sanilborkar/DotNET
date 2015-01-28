<%@ Page Language="C#" MasterPageFile="~/MedicopediaMasterPage.Master" AutoEventWireup="true" CodeBehind="VoteAndCommentInfo.aspx.cs" Inherits="MedicopediaInterface.VoteAndCommentInfo" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<title>MEDICOPEDIA: Vote and Comment Information</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <%--  query name--%>
   <tr>
    <td>
    <asp:Label ID="Adviceid" runat="server" Text="Advice ID"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblAdviceId" runat="server" Text="Label"></asp:Label>
    </td>
    </tr>
        <%--   no of positive votes--%>
    <tr>
    <td>
    <asp:Label ID="lblQueryTitle" runat="server" Text="Advice Name"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblAdviceName" runat="server" Text="Label"></asp:Label>
    </td>
    </tr>
        <%-- no of negetive votes--%>
    <tr>
    <td>
    <asp:Label ID="lblNoPositiveVotes" runat="server" Text="No Of Positive Votes"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblPosVotes" runat="server" Text="Label"></asp:Label>
    </td>
    </tr>
        <%--  comments--%>
    <tr>
    <td>
    <asp:Label ID="lblNoOfNegativeVotes" runat="server" Text="No Of Negative Votes"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblNegVotes" runat="server" Text="Label"></asp:Label>
    </td>
    </tr>
  <%--  comments--%>
    <tr>
    <td>
     <asp:Label ID="lblComments" runat="server" Text="Comments"></asp:Label>
    </td>
    <td>
   <asp:Repeater ID="RepComments" runat="server">
   <HeaderTemplate></HeaderTemplate>
    <ItemTemplate>
        <table>
        <tr>
        <td> <%# Container.DataItem %> </td>
        </tr>
        </table>

    </ItemTemplate>
    <FooterTemplate></FooterTemplate>
    </asp:Repeater> 
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
              ConnectionString="<%$ ConnectionStrings:Medicopedia_A40ConnectionString %>" 
              SelectCommand="SELECT [Comment] FROM [Comments]"></asp:SqlDataSource>
    </td>
    </tr>
    <%--show button--%>
    <tr>
    <td>
        &nbsp;</td>
    <td>
        <asp:Button ID="btnBack" runat="server" Text="Back" 
            onclick="btnBack_Click" /> &nbsp;</td>
    </tr>
    <tr>
    <td colspan="2">
        &nbsp;</td>
    </tr>
    <tr>
    <td colspan="2">
        <asp:LinkButton ID="lnkXML" runat="server" onclick="lnkXML_Click">Save a copy 
        (VoteAndCommentInfo.xml)</asp:LinkButton>
        </td>
    </tr>
    <tr>
    <td colspan="2">
        <asp:Label ID="lblXMLSuccess" runat="server"></asp:Label>
        </td>
    </tr>
    </table>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="UserLabel">
    <span style="text-align:right">
    <asp:Label ID="lblUserName" runat="server" Text="Label" Font-Size="Medium" />
    </span>
    <br />
    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" Font-Size="X-Small" Text="Logout" />
</asp:Content>