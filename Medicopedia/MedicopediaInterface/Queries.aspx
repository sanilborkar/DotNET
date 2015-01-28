<%@ Page Language="C#" MasterPageFile="~/MedicopediaMasterPage.Master" AutoEventWireup="true" CodeBehind="Queries.aspx.cs" Inherits="MedicopediaInterface.Queries" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>MEDICOPEDIA: Queries</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
    AutoGenerateColumns="False" DataSourceID="SqlDataSource1" 
        DataKeyNames="QueryID"  
        onselectedindexchanged="GridView1_SelectedIndexChanged" PageSize="5" 
        CellPadding="4" ForeColor="#333333" GridLines="None"
        >
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="QueryID" HeaderText="QueryID" 
                SortExpression="QueryID" InsertVisible="False" ReadOnly="True" />
            <asp:BoundField DataField="QueryTitle" HeaderText="QueryTitle" 
                SortExpression="QueryTitle" />
            <asp:BoundField DataField="SymptomsInQuery" HeaderText="SymptomsInQuery" 
                SortExpression="SymptomsInQuery" />
            <asp:BoundField DataField="UserId" HeaderText="UserId" 
                SortExpression="UserId" />
            <asp:BoundField DataField="Disease" HeaderText="Disease" 
                SortExpression="Disease" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnAdvise" runat="server" CausesValidation="False" 
                            CommandName="Select" onclick="btnAdvise_Click" Text="Advise" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:Button ID="btnPrescribe" runat="server" OnClick="btnPrescribe_Click" CausesValidation="False" 
                        CommandName="Select" Text="Prescribe" />
                </ItemTemplate>
            </asp:TemplateField>
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
    
        
        
        SelectCommand="SELECT [QueryTitle], [SymptomsInQuery], [UserId], [Disease], [QueryID] FROM [Query]">
</asp:SqlDataSource>

</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="UserLabel">
    <span style="text-align:right">
    <asp:Label ID="lblUserName" runat="server" Text="Label" Font-Size="Medium" />
    </span>
    <br />
    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" Font-Size="X-Small" Text="Logout" />
</asp:Content>