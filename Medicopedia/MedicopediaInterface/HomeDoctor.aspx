<%@ Page Language="C#" MasterPageFile="~/MedicopediaMasterPage.Master" AutoEventWireup="true" CodeBehind="HomeDoctor.aspx.cs" Inherits="MedicopediaInterface.WebForm5" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>MEDICOPEDIA: Doctor Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvTop10" runat="server" AllowPaging="True" 
        AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ItemID" 
        onselectedindexchanged="gvTop10_SelectedIndexChanged" CellPadding="4" 
        ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="ItemID" HeaderText="ItemID" 
                InsertVisible="False" ReadOnly="True" SortExpression="ItemID" />
            <asp:BoundField DataField="AdviceName" HeaderText="AdviceName" 
                SortExpression="AdviceName" />
            <asp:BoundField DataField="ItemDescription" HeaderText="ItemDescription" 
                SortExpression="ItemDescription" />
            <asp:BoundField DataField="Disease" HeaderText="Disease" 
                SortExpression="Disease" />
            <asp:BoundField DataField="MedicineName" HeaderText="MedicineName" 
                SortExpression="MedicineName" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" 
                SortExpression="UserName" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:Medicopedia_A40ConnectionString %>" 
        SelectCommand="usp_GetTop10" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    <br />
    My Worklist: Forwarded Queries<br />
    <br />
    
    <asp:GridView ID="gvWorklist" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" 
        onselectedindexchanging="gvWorklist_SelectedIndexChanging">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="QueryID" HeaderText="Query ID" />
            <asp:BoundField DataField="QueryTitle" HeaderText="Query Title" />
            <asp:BoundField DataField="SymptomsInQuery" HeaderText="Symptoms" />
            <asp:BoundField DataField="UserName" HeaderText="Forwarded By" />
            <asp:BoundField DataField="Disease" HeaderText="Disease" />
            <asp:CommandField ButtonType="Button" SelectText="Advise" 
                ShowSelectButton="True" />
        </Columns>
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <EditRowStyle BackColor="#999999" />
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    </asp:GridView>
    
    
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="UserLabel">
    <span style="text-align:right">
    <asp:Label ID="lblUserName" runat="server" Text="Label" Font-Size="Medium" />
    </span>
    <br />
    <asp:LinkButton ID="LinkButton4" OnClick="LinkButton4_Click" runat="server" Font-Size="X-Small" Text="Logout" />
</asp:Content>


