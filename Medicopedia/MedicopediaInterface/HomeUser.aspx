<%@ Page Language="C#" MasterPageFile="~/MedicopediaMasterPage.Master" AutoEventWireup="true" CodeBehind="HomeUser.aspx.cs" Inherits="MedicopediaInterface.HomeUser" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>MEDICOPEDIA: User Home</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gvTop10" runat="server" AllowPaging="True" 
    AutoGenerateColumns="False" 
        onselectedindexchanged="gvTop10_SelectedIndexChanged" CellPadding="4" 
        ForeColor="#333333" GridLines="None">
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <Columns>
            <asp:BoundField DataField="ItemID" HeaderText="Item ID" />
            <asp:BoundField DataField="AdviceName" HeaderText="Advice Name" />
            <asp:BoundField DataField="ItemDescription" HeaderText="Item Description" />
            <asp:BoundField DataField="Disease" HeaderText="Disease" />
            <asp:BoundField DataField="MedicineName" HeaderText="MedicineName" />
            <asp:BoundField DataField="UserName" HeaderText="UserName" />
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                        CommandName="Select" onclick="LinkButton1_Click1" Text="Vote"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" 
                        CommandName="Select" onclick="LinkButton2_Click1" Text="Comment"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" 
                        CommandName="Select" onclick="LinkButton3_Click1" Text="Info"></asp:LinkButton>
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
        SelectCommand="usp_GetTop10" SelectCommandType="StoredProcedure">
    </asp:SqlDataSource>
    <br />
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="UserLabel">
    <span style="text-align:right">
    <asp:Label ID="lblUserName" runat="server" Text="Label" Font-Size="Medium" />
    </span>
    <br />
    <asp:LinkButton ID="LinkButton4" OnClick="LinkButton4_Click" runat="server" Font-Size="X-Small" Text="Logout" />
</asp:Content>

