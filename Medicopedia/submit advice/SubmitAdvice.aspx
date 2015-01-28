<%@ Page Language="C#" MasterPageFile="~/MedicopediaMasterPage.Master" AutoEventWireup="true" CodeBehind="SubmitAdvice.aspx.cs" Inherits="MedicopediaInterface.WebForm10" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Post Your Advice</h3>
    <br />

<br />
<asp:Label ID="Label2" runat="server" Text="Enter Query Id"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtQueryid" runat="server"></asp:TextBox>
<br />
<br />
    <asp:Label ID="Label5" runat="server" Text="Advice"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtAdvice" runat="server" TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
<asp:Label ID="Label4" runat="server" Text="Advice By"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="txtAdviceBy" runat="server"></asp:TextBox>
<br />
<br />
<asp:Label ID="Label3" runat="server" Text="Advice Status"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<asp:DropDownList ID="ddlAdviceStatus" runat="server">
</asp:DropDownList>
<br />
<br />

<center>
 <asp:Button ID="btnSubmit" runat="server" Text="Submit " 
        onclick="btnSubmit_Click" />
    &nbsp&nbsp<asp:Button ID="btnRedirect" runat="server" Text="Redirect" 
        onclick="btnRedirect_Click" />
&nbsp;&nbsp;<br />
    <br />
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
       
        onselectedindexchanging="GridView1_SelectedIndexChanging" Width="235px" 
        Visible="False">
        <Columns>
            <asp:CommandField ButtonType="Button" SelectText="Add" 
                ShowSelectButton="True" />
        </Columns>
    </asp:GridView>
    <br />
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Medicopedia_A40ConnectionString %>" 
        SelectCommand="SELECT [Name], [Specialization] FROM [Medical_Specialist]">
    </asp:SqlDataSource>
    <br />
    <br />
    <br />
</center>























</asp:Content>
