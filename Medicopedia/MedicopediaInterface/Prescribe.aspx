<%@ Page Language="C#" MasterPageFile="~/MedicopediaMasterPage.Master" AutoEventWireup="true" CodeBehind="Prescribe.aspx.cs" Inherits="MedicopediaInterface.Prescribe" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>MEDICOPEDIA: Prescribe</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <br />
    <br />
    <asp:Label ID="lblQuery" runat="server" Text="Query:"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtQuery" runat="server" TextMode="MultiLine" Width="187px"></asp:TextBox>
          <br />
    <br />
    <asp:Label ID="lblPrescription" runat="server" Text="Prescription:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtPrescribe" runat="server" TextMode="MultiLine" Width="193px"></asp:TextBox>
      <br />
    <br />
    <asp:Button ID="btnPost" runat="server" Text="Post" Width="65px" 
        onclick="btnPost_Click" />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" Width="65px" 
        onclick="btnCancel_Click" />

</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="UserLabel">
    <span style="text-align:right">
    <asp:Label ID="lblUserName" runat="server" Text="Label" Font-Size="Medium" />
    </span>
    <br />
    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" Font-Size="X-Small" Text="Logout" />
</asp:Content>