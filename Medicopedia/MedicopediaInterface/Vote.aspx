<%@ Page Language="C#" MasterPageFile="~/MedicopediaMasterPage.Master" AutoEventWireup="true" CodeBehind="Vote.aspx.cs" Inherits="MedicopediaInterface.Vote" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>MEDICOPEDIA: Vote</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Post Your Vote</h3>
    <br />
    <table>
    <tr>
    <td>
    <asp:Label ID="Adviceid" runat="server" Text="Advice ID"></asp:Label>
    </td>
    <td>
        <asp:Label ID="lblAdviceId" runat="server" Text="Label"></asp:Label>
    </td>
    </tr>
<tr>
         <td>

<asp:Label ID="lblQueryTitle" runat="server" Text="Advice Name"></asp:Label>
        </td>

        <td>
<asp:TextBox ID="txtQueryTitle" runat="server" TextMode="MultiLine" 
             Width="200px" Enabled="False"  ></asp:TextBox>
        </td>
            
</tr>
             
<tr>
        <td>     
<asp:Label ID="lblNoPositiveVotes" runat="server" Text="No Of Positive Votes"></asp:Label>
       </td> 

       <td>
       
<asp:TextBox ID="txtNoPositiveVotes" runat="server" Width="40px" Enabled="False"></asp:TextBox>

      </td>
</tr> 
<tr>
        <td>     
<asp:Label ID="lblNoOfNegativeVotes" runat="server" Text="No Of Negative Votes"></asp:Label>
       </td> 

       <td>
       
<asp:TextBox ID="txtNoOfNegativeVote" runat="server" Width="40px" Enabled="False"></asp:TextBox>

      </td>
</tr> 

<tr>    
      <td>
    <asp:Label ID="lblComments" runat="server" Text="Comments"></asp:Label>
      </td>

      <td>
    <asp:Repeater ID="RepComments" runat="server">
    <HeaderTemplate></HeaderTemplate>
    <ItemTemplate>
  
        <table>
        <tr>
        <td> <%# Container.DataItem %> </td>
        </tr>
        </table>

    </ItemTemplate>
    <FooterTemplate></FooterTemplate>
    </asp:Repeater>
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
              ConnectionString="<%$ ConnectionStrings:Medicopedia_A40ConnectionString %>" 
              SelectCommand="SELECT [Comment] FROM [Comments]"></asp:SqlDataSource>
     </td>
</tr>
   
<tr>
     <td>
    <asp:Button ID="btnVoteFor" runat="server" Text="Vote For Advice" 
        Width="149px" onclick="btnVoteFor_Click" Enabled="False" />
    </td>

    <td>
    <asp:Button ID="btnVoteAgainst" runat="server" Text="Vote Against Advice" 
        Width="149px" onclick="btnVoteAgainst_Click" Enabled="False" />
    </td>
    
</tr>
   
<tr>
     <td>
         <asp:Button ID="btnShow" runat="server" onclick="btnShow_Click" Text="show" />
    </td>

    <td>
        <asp:Button ID="btnBack" runat="server" onclick="btnBack_Click" 
            Text="Back" />
     </td>
    
</tr>
   
<tr>
     <td>
         &nbsp;</td>

    <td>
        &nbsp;</td>
    
</tr>
   
<tr>
     <td colspan="2">
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