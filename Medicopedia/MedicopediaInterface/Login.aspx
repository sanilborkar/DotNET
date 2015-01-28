<%@ Page Language="C#" MasterPageFile="~/MedicopediaMasterPage.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MedicopediaInterface.Login" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>MEDICOPEDIA: Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
Login&nbsp;&nbsp;(Sign in with your registered email ID)&nbsp;&nbsp;
</h3>
    <p>
        <asp:Label ID="lblLoginAs" runat="server" Text="Login As"></asp:Label>
        &nbsp;<asp:DropDownList ID="ddlRole" runat="server" AutoPostBack="True">
            <asp:ListItem>---Select---</asp:ListItem>
            <asp:ListItem>User</asp:ListItem>
            <asp:ListItem>Doctor</asp:ListItem>
            <asp:ListItem>Admin</asp:ListItem>
        </asp:DropDownList>
</p>
<table style="height: 89px; width: 249px">
<tr><td>
    <asp:Label ID="lblUserName" runat="server" Text="Enter Username"></asp:Label>
    </td><td>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    </td></tr>
<tr><td>
    <asp:Label ID="lblPassword" runat="server" Text="Enter Password"></asp:Label>
    </td><td>
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
    </td></tr>
<tr><td>
    &nbsp;</td><td>
    <asp:Button ID="btnLogin" runat="server" Text="Login" onclick="btnLogin_Click" />
    </td></tr>


<tr><td colspan="2">
    <asp:Label ID="lblmsg" runat="server"></asp:Label>
    </td></tr>


</table>




</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="UserLabel">
    <span style="text-align:right">
    <asp:Label ID="lblUserName1" runat="server" Text="Label" Font-Size="Medium" />
    </span>
</asp:Content>