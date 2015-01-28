<%@ Page Language="C#" MasterPageFile="~/MedicopediaMasterPage.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="MedicopediaInterface.WebForm3" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<title>MEDICOPEDIA: Contact Us</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<span style="font-family: Comic Sans MS; font-weight:bold; color:blue; font-size:large; text-align: justify;">Medicopedia Contact</span>

<p>Contact us at: <br /><br />
<i><b>
Medicopedia Services <br />
Ahmedabad, <br />
Gujarat - 380001 <br />
INDIA</i></b>

<br /><br />
Call us at: <b>1800-456-1234</b>
</p>

</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="UserLabel">
    <span style="text-align:right">
    <asp:Label ID="lblUserName" runat="server" Text="Label" Font-Size="Medium" />
    </span>
    <br />
    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" Font-Size="X-Small" Text="Logout" />
        

    
</asp:Content>
