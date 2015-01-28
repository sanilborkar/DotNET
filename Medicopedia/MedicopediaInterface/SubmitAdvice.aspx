<%@ Page Language="C#" MasterPageFile="~/MedicopediaMasterPage.Master" AutoEventWireup="true"
    CodeBehind="SubmitAdvice.aspx.cs" Inherits="MedicopediaInterface.WebForm10" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<title>MEDICOPEDIA: Submit Advice</title>

    <%--validations--%>

    <script type="text/javascript">

  function DoValidate(){

var advice = document.getElementById('<%=txtAdvice.ClientID%>');
	
//	Advice
	 if(advice.value=="")
    {
    alert("Please enter tour advice");
 advice.focus();
    return false;
    }
  
return true;
}  

    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>
        Post Your Advice</h3>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="Enter Query Id"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblQueryId" runat="server" Text="Label"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Advice"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="txtAdvice" runat="server" TextMode="MultiLine"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Text="Advice By"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Label ID="lblAdviceBy" runat="server" Text="Label"></asp:Label>
    &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Text="Advice Status"></asp:Label>
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox ID="chkStatus" Text="Need more info"
        runat="server" />
    <br />
    <br />
    <center>
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return DoValidate();" OnClick="btnSubmit_Click" />
        &nbsp&nbsp<asp:Button ID="btnRedirect" runat="server" Text="Redirect" OnClick="btnRedirect_Click" />
        &nbsp;&nbsp;<br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:GridView ID="gvSpecialists" runat="server" AllowPaging="True" Width="235px"
            Visible="False" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333"
            GridLines="None" OnSelectedIndexChanged="gvSpecialists_SelectedIndexChanged">
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <Columns>
                <asp:BoundField DataField="UserId" HeaderText="Doctor ID" />
                <asp:BoundField DataField="UserName" HeaderText="Doctor Name" />
                <asp:BoundField DataField="Specialization" HeaderText="Specialization" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="False" CommandName="Select"
                            Text="Add" />
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
        <br />
        <br />
        <asp:LinkButton ID="lnkBack" runat="server" PostBackUrl="~/Home.aspx">Back</asp:LinkButton>
        <br />
    </center>
</asp:Content>
<asp:Content ID="Content3" runat="server" ContentPlaceHolderID="UserLabel">
    <span style="text-align: right">
        <asp:Label ID="lblUserName" runat="server" Text="Label" Font-Size="Medium" />
    </span>
    <br />
    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" Font-Size="X-Small"
        Text="Logout" />
</asp:Content>
