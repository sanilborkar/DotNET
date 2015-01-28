<%@ Page Language="C#" MasterPageFile="~/MedicopediaMasterPage.Master" AutoEventWireup="true" CodeBehind="ErrorPage.aspx.cs" Inherits="MedicopediaInterface.WebForm13" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>MEDICOPEDIA: Error !!!</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    <span style="font-size: large; font-family: Arial Black"> ERROR !!! </span><br /><br />
    We have encountered an error. Please try again.
    <br /><br />
    Redirected from: &nbsp; &nbsp;
    <asp:Label runat="server" ID="lblError" ></asp:Label>
        </p>
    <p>
        <asp:Label ID="lblErrDesc" runat="server"></asp:Label>
        </p>
        
        <br /><br />
        
    <asp:LinkButton ID="lnkBack" runat="server">Click here to go Back</asp:LinkButton>
</asp:Content>


<asp:Content ID="Content3" runat="server" contentplaceholderid="UserLabel">
    <span style="text-align:right">
    <asp:Label ID="lblUserName" runat="server" Text="Label" Font-Size="Medium" />
    </span>
</asp:Content>