<%@ Page Language="C#" MasterPageFile="~/MedicopediaMasterPage.Master" AutoEventWireup="true" CodeBehind="Personalize.aspx.cs" Inherits="MedicopediaInterface.WebForm1" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>MEDICOPEDIA: Personalize Your Page !!!</title>
<style type="text/css">
    .style11
    {
    }
</style>
</asp:Content>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <table>
    
    <tr>
    <td class="style11">
        <asp:Label ID="Label2" runat="server" Text="Select a background color"></asp:Label>
        </td>
    <td>
        <asp:DropDownList ID="ddlBackColor" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        </td>
    </tr>
    
    <tr>
    <td class="style11">Select left pane color</td>
    <td>
        <asp:DropDownList ID="ddlleftColor" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        </td>
    </tr>
    
    <tr>
    <td class="style11">Select logo color</td>
    <td>
        <asp:DropDownList ID="ddlLogoColor" runat="server" AutoPostBack="True">
        </asp:DropDownList>
        </td>
    </tr>
    
    <tr>
    <td class="style11" colspan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
            onclick="btnSubmit_Click" />
        </td>
    </tr>
    
    <tr>
    <td class="style11" colspan="2">
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
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


