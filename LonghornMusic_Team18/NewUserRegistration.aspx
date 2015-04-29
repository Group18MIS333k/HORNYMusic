<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="NewUserRegistration.aspx.vb" Inherits="LonghornMusic_Team18.NewUserRegistration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="LoginStyleSheet.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
    <div id ="banner">
    
        <asp:Label ID="Label3" runat="server" Font-Size="XX-Large" Text="Register"></asp:Label>
        &nbsp;&nbsp;
        <br />
    
    </div>

       
         
    <div id ="label">
        <link href="LoginStyleSheet.css" rel="stylesheet" />
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Text="Last Name"></asp:Label>
        <br />
        <asp:Label ID="Label10" runat="server" Text="First Name"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Initial"></asp:Label>
        <br />
        <asp:Label ID="Label9" runat="server" Text="Password"></asp:Label>
&nbsp;<br />
        <asp:Label ID="Label11" runat="server" Text="Address"></asp:Label>
        <br />
        <asp:Label ID="Label12" runat="server" Text="City"></asp:Label>
        <br />
        <asp:Label ID="Label13" runat="server" Text="State"></asp:Label>
        <br />
        <asp:Label ID="Label14" runat="server" Text="ZipCode"></asp:Label>
        <br />
        <asp:Label ID="Label15" runat="server" Text="Email"></asp:Label>
        <br />
        <asp:Label ID="Label16" runat="server" Text="Phone Number"></asp:Label>
        <br />
&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>

        <div id ="text">

            <br />
            <br />
       
            <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
       
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last Name Required">*</asp:RequiredFieldValidator>
       
            <br />
            <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First Name Required">*</asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtInitial" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password Required">*</asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtState" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtZip" runat="server" MaxLength="5"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Required">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            <br />
            <asp:TextBox ID="txtPhone" runat="server" MaxLength="10"></asp:TextBox>
            <br />
            <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label>
            <br />
            <br />
            <br />

        </div>

        <div id ="right">

            <br />
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True"></asp:TextBox>
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="btnRegister" runat="server" Text="Register" />

        </div>
  
    </form>
</body>
</html>

       
