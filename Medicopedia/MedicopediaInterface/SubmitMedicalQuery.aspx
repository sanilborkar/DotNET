<%@ Page Language="C#" MasterPageFile="~/MedicopediaMasterPage.Master" AutoEventWireup="true" CodeBehind="SubmitMedicalQuery.aspx.cs" Inherits="MedicopediaInterface.SubmitMedicalQuery" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<title>MEDICOPEDIA: Submit Medical Query</title>

    <style type="text/css">
        .style11
        {
            width: 124px;
        }
    </style>
    

<%--validations--%>
<script  type="text/javascript" >

  function DoValidate(){


var queryTitle = document.getElementById('<%=txtQueryTitle.ClientID%>');
  var disease = document.getElementById('<%=txtDisease.ClientID%>');
  var symptoms = document.getElementById('<%=txtSymptoms.ClientID%>'); 
  var earlierRecords = document.getElementById('<%=txtEarlierRecords.ClientID%>');

	
//	Query Title
	 if(queryTitle.value=="")
    {
    alert("Please enter the query title");
 queryTitle.focus();
    return false;
    }
   
   
 // disease   
if(disease.value=="")
    {
    alert("Please the suspected disease");
    disease.focus();
    return false;
    }

    
    // symptoms
  if(symptoms.value=="")
    {
    alert("Please enter the symptoms");
 symptoms.focus();
    return false;
    }
    

    
    
  
return true;
}  
//close
</script>
    
    
    
    
    
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Post Your Query</h3>
<table>
<tr><td style="margin-left: 80px">
    <asp:Label ID="lblQueryTitle" runat="server" Text="Query Title"></asp:Label>
    </td><td>
        <asp:TextBox ID="txtQueryTitle" runat="server"></asp:TextBox>
    </td><td class="style11">Enter subject of the query</td></tr>
<tr><td style="margin-left: 80px">
    <asp:Label ID="lblUserName" runat="server" Text="Enter Your Name"></asp:Label>
    </td><td>
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
    </td><td class="style11">&nbsp;</td></tr>
<tr><td style="margin-left: 40px">
    <asp:Label ID="lblDisease" runat="server" Text="Enter the Name of Disease"></asp:Label>
    </td><td style="margin-left: 40px">
        <asp:TextBox ID="txtDisease" runat="server"></asp:TextBox>
    </td><td style="margin-left: 40px" class="style11">&nbsp;</td></tr>
<tr><td>
    <asp:Label ID="lblSymptoms" runat="server" Text="Enter Symptoms"></asp:Label>
    </td><td>
        <asp:TextBox ID="txtSymptoms" runat="server" TextMode="MultiLine"></asp:TextBox>
    </td><td class="style11">&nbsp;</td></tr>
<tr><td>
    <asp:Label ID="lblEarlierRecords" runat="server" 
        Text="Enter details of Earlier Report"></asp:Label>
    s</td><td>
        <asp:TextBox ID="txtEarlierRecords" runat="server" TextMode="MultiLine"></asp:TextBox>
    </td><td valign="bottom" class="style11">(maximum 100 characters)</td></tr>


<tr><td>&nbsp;</td></tr>


<tr><td>&nbsp;</td><td>
    <asp:Button ID="btnPost" runat="server" Text="Submit" onclick="btnPost_Click" OnClientClick="return DoValidate();" />
    </td><td class="style11">
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" 
            onclick="btnCancel_Click" />
    </td></tr>


</table>
</asp:Content>
<asp:Content ID="Content3" runat="server" contentplaceholderid="UserLabel">
    <span style="text-align:right">
    <asp:Label ID="lblUserName1" runat="server" Text="Label" Font-Size="Medium" />
    </span>
    <br />
    <asp:LinkButton ID="LinkButton1" OnClick="LinkButton1_Click" runat="server" Font-Size="X-Small" Text="Logout" />
</asp:Content>