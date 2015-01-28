<%@ Page Language="C#" MasterPageFile="~/MedicopediaMasterPage.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="MedicopediaInterface.Home" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>MEDICOPEDIA: Home</title>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <asp:Label ID="Label1" runat="server" Text="You have to login to submit a query, advice or prescription."></asp:Label>
    </asp:Content>
    
    <asp:Content ID="Content3" runat="server" contentplaceholderid="UserLabel">
    <span style="text-align:right">
    <asp:Label ID="lblUserName" runat="server" Text="Label" Font-Size="Medium" />
    </span>

    
</asp:Content>