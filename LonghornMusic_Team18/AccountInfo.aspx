<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebApplication1.Master" CodeBehind="AccountInfo.aspx.vb" Inherits="LonghornMusic_Team18.AccountInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<body>
    <form id="form1" runat="server">
    <div id ="banner">
    
        <asp:Label ID="Label3" runat="server" Font-Size="XX-Large" Text="Account Information"></asp:Label>    
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
        <br />
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
        <asp:Button ID="btnModify" runat="server" Text="Modify" />
        <asp:Button ID="btnSave" runat="server" Text="Save " />
        <asp:Button ID="btnCancel" runat="server" Text="Cancel" />
        <br />    
    </div>

        <div id ="text">

            <br />
            <br />
       
            <asp:TextBox ID="txtLastName" runat="server" Enabled="False"></asp:TextBox>
       
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLastName" ErrorMessage="Last Name Required">*</asp:RequiredFieldValidator>
       
            <br />
            <asp:TextBox ID="txtFirstName" runat="server" Enabled="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFirstName" ErrorMessage="First Name Required">*</asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtInitial" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtPassword" runat="server" Enabled="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPassword" ErrorMessage="Password Required">*</asp:RequiredFieldValidator>
            <br />
            <asp:TextBox ID="txtAddress" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtCity" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtState" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtZip" runat="server" Enabled="False"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtEmail" runat="server" Enabled="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEmail" ErrorMessage="Email Required">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail" ErrorMessage="Invalid Email" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            <br />
            <asp:TextBox ID="txtPhone" runat="server" Enabled="False"></asp:TextBox>
  
        </div>

       
    </form>
</body>
</html>
</asp:Content>
