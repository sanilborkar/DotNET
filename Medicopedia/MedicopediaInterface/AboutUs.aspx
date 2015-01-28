<%@ Page Language="C#" MasterPageFile="~/MedicopediaMasterPage.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="MedicopediaInterface.WebForm2" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>MEDICOPEDIA: About Us</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<span style="font-family: Comic Sans MS; font-weight:bold; color:blue; font-size:large; text-align: justify;">Medicopedia</span>

<p style="font-family: Comic Sans MS; font-size:medium; text-align: justify;" >
Medicopedia is the National Institutes of Health's Web site for patients and their families and friends.
Produced by the TATA Consultancy Services, it brings you information about diseases, conditions, 
and wellness issues.
</p>

<p style="font-family: Comic Sans MS; font-size:medium; text-align: justify;" >
Medicopedia offers reliable, up-to-date health information, anytime, anywhere, for free.
It is a web based medical encyclopedia that includes information about diseases, tests, symptoms and medicines.
It provides an extensive search mechanism.You can use Medicopedia to look up information on a drug or supplement.
</p> 
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="UserLabel">
    <span style="text-align:right">
    <asp:Label ID="lblUserName" runat="server" Text="Label" Font-Size="Medium" />
    </span>
    <br />
    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" Font-Size="X-Small" Text="Logout" />
        

    
</asp:Content>