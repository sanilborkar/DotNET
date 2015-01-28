<%@ Page Language="C#" MasterPageFile="~/MedicopediaMasterPage.Master" AutoEventWireup="true" CodeBehind="Comment.aspx.cs" Inherits="MedicopediaInterface.Comment" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<title>MEDICOPEDIA: Comment</title>

<script type="text/javascript">
function DoValidate1()
{
    var comment = document.getElementById('<%=txtComment.ClientID%>');
    if(comment.value == "")
    {
        alert("Please enter your comment(s)");
        comment.focus();
        return false;
    }
        
        return true;
        
}
</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
<tr><td>&nbsp;</td><td>&nbsp;</td></tr>
<tr><td>
    <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
    </td><td>
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
    </td></tr>
<tr><td>
    <asp:Label ID="lblComment" runat="server" Text="Comment"></asp:Label>
    </td><td>
        <asp:TextBox ID="txtComment" runat="server" TextMode="MultiLine"></asp:TextBox>
    </td></tr>
<tr><td>
    <asp:Label ID="lblMsg" runat="server" Text="Label"></asp:Label>
    </td><td>
        &nbsp;</td></tr>
<tr><td></td><td>
    <asp:Button ID="btnComment" runat="server" onclick="btnComment_Click" OnClientClick="return DoValidate1();" 
        Text="Comment" />
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
        onclick="btnCancel_Click" />
    </td></tr>








</table>
</asp:Content>

<asp:Content ID="Content3" runat="server" contentplaceholderid="UserLabel">
    <span style="text-align:right">
    <asp:Label ID="lblUserName" runat="server" Text="Label" Font-Size="Medium" />
    </span>
    <br />
    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" Font-Size="X-Small" Text="Logout" />
        

    
</asp:Content>