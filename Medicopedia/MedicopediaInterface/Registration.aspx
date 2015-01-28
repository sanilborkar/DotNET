<%@ Page Language="C#" MasterPageFile="~/MedicopediaMasterPage.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="MedicopediaInterface.Registration" Title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<title>MEDICOPEDIA: Registration</title>

    <style type="text/css">
        .style1
        {
    }
        .style2
        {
            width: 434px;
        }
        .style3
        {
            width: 165px;
        }
        .style4
        {
            width: 417px;
        }
        .style11
        {
            width: 97px;
        }
        .style12
        {
            height: 59px;
            }
    .style13
    {
        height: 22px;
    }
    </style>
    
    
   <script  type="text/javascript" >
   //validations
  function DoValidate(){
  var alphaExp = /^[a-zA-Z\s]+$/;
  var emailExp = /^[\w\-\.\+]+\@[a-zA-Z0-9\.\-]+\.[a-zA-z0-9]{2,4}$/;
var licenceExp=/^[0-9]+$/;

var role = document.getElementById('<%=ddlRegistered.ClientID%>')
var userRole = role.options[role.selectedIndex].value;
var DOB=document.getElementById('<%=txtDOB.ClientID%>');
  var username=document.getElementById('<%=txtName.ClientID%>');
  var email=document.getElementById('<%=txtEmailid.ClientID%>');
  var licenceNum=document.getElementById('<%=txtLicensenumber.ClientID%>'); 
  var specialization=document.getElementById('<%=txtSpecialization.ClientID%>');
var password1=document.getElementById ('<%=txtPassword.ClientID%>');
var cPassword=document.getElementById('<%=txtConfirmpassword.ClientID%>');
	
	// user role
	if(userRole == "")
	{
	alert("Please select a user role");
	role.focus();
	return false;
	}
	
	
//	username name
	 if(username.value=="")
    { 
    alert("Please enter your name");
 username.focus();
    return false;
    }
   if(!username.value.match(alphaExp))
    {alert ("Please enter only letters");
    return false;}
   
 //email   
if(email.value=="")
    {
    alert("Please enter your email");
    email.focus();
    return false;
    }
 if(!email.value.match(emailExp))
    {
    alert("Please enter proper email");
   email.focus();
    return false;
    }
    
    // password
  if(password1.value=="")
    {
    alert("Please enter your Password");
 password1.focus();
    return false;
    }
    //confirm password
if(cPassword.value=="")
    {
    alert("Please confirm your password");
    cPassword.focus();
    return false;
    }
    //password=confirm password
    if(!cPassword.value.match(password1.value))
    {
    alert("Passwords do not match.");
    cPassword.focus();
    return false;
    }
    if (DOB.value=="")
    {
    alert("Please enter your date of birth");
   DOB.focus();
    return false;
    }
 if (licenceNum.value=="")
    {
    alert("Please enter your License Number");
    licenceNum.focus();
    return false;
    }
if(!licenceNum.value.match(licenceExp))
    { alert("Please enter proper License Number");
    licenceNum.focus();
    return false;
                               
    }
   // else alert("byeeee");
    
  if (specialization.value=="")
    {
    alert("Please enter your Specialization");
    specialization.focus();
    return false;
    }
    if(!specialization.value.match(alphaExp))
    {
    alert("Please enter correct specialization");
    specialization.focus();
    return false;
    }

  
return true;
}  
//close
</script>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat ="server">
    
      <table>
      <tr> <td class="style11">
          Enter Your Details</td></tr>
<tr>
    <td class="style12">
        <asp:Label ID="lbl_registeras" runat="server" Text="Register As" ></asp:Label>
        </td>
    <td class="style2" colspan="2">&nbsp;<asp:DropDownList ID="ddlRegistered" runat="server" 
            AutoPostBack="True" onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
            style="margin-left: 0px">
        <asp:ListItem></asp:ListItem>
        <asp:ListItem>User</asp:ListItem>
        <asp:ListItem>Doctor</asp:ListItem>
        </asp:DropDownList>
        
        </td>
    </tr>
    <tr>
    <td class="style12">
        <asp:Label ID="lblName" runat="server" Text="Name" ></asp:Label>
        </td>
    <td class="style2" colspan="2">
        <asp:TextBox ID="txtName" runat="server" Width="150px" ></asp:TextBox>
       
        </td>
    </tr>
 
        <tr>
    <td class="style12">
        <asp:Label ID="lblEmailid" runat="server" Text="Email Id"></asp:Label>
        </td>
    <td class="style2" colspan="2">
        <asp:TextBox ID="txtEmailid" runat="server" Width="250px"></asp:TextBox>
       
        </td>
        </tr>
        <tr>
    <td class="style12">
        <asp:Label ID="lblPassword" runat="server" Text="Password" 
           ></asp:Label>
        </td>
    <td class="style2" colspan="2">
        <asp:TextBox ID="txtPassword" runat="server" Width="150px" TextMode="Password"></asp:TextBox>
        
        </td>
        </tr>
        <tr>
    <td valign="top" class="style11" >
        <asp:Label ID="lblConfirmpassword" runat="server" Text="Confirm Password" ></asp:Label>
        </td>
    <td class="style2" colspan="2">
        <asp:TextBox ID="txtConfirmpassword" runat="server" Width="150px" 
            TextMode="Password"></asp:TextBox></td> 
       
      
        </tr>
   
    <tr>
    <td class="style12" valign="top">
        <asp:Label ID="lblGender" runat="server" Text="Gender" ></asp:Label>
        </td>
    <td class="style3">
        <asp:RadioButtonList ID="rbl_gender" runat="server" 
            RepeatDirection="Horizontal">
            <asp:ListItem Selected="True">Male</asp:ListItem>  
            <asp:ListItem>Female</asp:ListItem>
        </asp:RadioButtonList>
        </td>
    
    </tr>
    <tr>
    <td class="style12" valign="top">
        <asp:Label ID="lblDOB" runat="server" Text="DateOfBirth"></asp:Label>
        <br />
        (MM/DD/YYYY)</td>
    <td class="style2" colspan="2">
        <asp:TextBox ID="txtDOB" runat="server" Width="150px"></asp:TextBox>
        
       
        &nbsp;<asp:RangeValidator ID="RangeValidator1" runat="server" 
            ControlToValidate="txtDOB" Display="Dynamic" 
            ErrorMessage="Please enter a valid date" MaximumValue="12/31/3000" 
            MinimumValue="01/01/1000" Type="Date"></asp:RangeValidator>
        
       
        </td>
    </tr>
    <tr>
    <td class="style12" valign="top">
        <asp:Label ID="lblInterestedin" runat="server" Text="Interested In(Optional)" 
           ></asp:Label>
        </td>
    <td class="style2" colspan="2">
        <asp:TextBox ID="txtIinterestedin" runat="server" TextMode="MultiLine"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
    <td class="style12">
        <asp:Label ID="lblLicensenumber" runat="server" Text="LicenseNumber" 
            Visible="False" ></asp:Label>
        </td>
    <td class="style2" colspan="2">
        <asp:TextBox ID="txtLicensenumber" runat="server" Visible="False" 
            Width="150px"></asp:TextBox>
       
        </td>
    </tr>
    <tr>
    <td class="style12">
        <asp:Label ID="lblSpecialization" runat="server" Text="Specialization" 
            Visible="False"></asp:Label>
        </td>
    <td class="style2" colspan="2">
        <asp:TextBox ID="txtSpecialization" runat="server" Visible="False" 
            Width="150px"></asp:TextBox>
               <br />
        </td>
    </tr>
    <tr>
    <td class="style12">
        <asp:Button ID="btnSubmit" runat="server" Text="Submit" 
            onclick="btnSubmit_Click" OnClientClick="return DoValidate();" />
        </td>
         <td class="style1">
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" />
        </td>
    <td class="style2">&nbsp;</td>
    </tr>
    <tr>
    <td class="style13" colspan="3">
        <asp:Label ID="lblMsg" runat="server"></asp:Label>
        </td>
    </tr>
    <tr>
    <td class="style13" colspan="3">
        <asp:LinkButton ID="lnkLogin" runat="server" PostBackUrl="~/Login.aspx" 
            Visible="False">Click here to Login</asp:LinkButton>
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