<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/site1.Master" CodeBehind="AccountInfo.aspx.vb" Inherits="LonghornMusic_Team18.AccountInfo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div id ="banner">
    
        <asp:Label ID="Label3" runat="server" Font-Size="XX-Large" Text="Account Information"></asp:Label>    
    </div>    
         
    <div style="width: 471px; margin-top: 0px; height: 400px; text-align: right;">

&nbsp;&nbsp;&nbsp; *First Name:
        <asp:TextBox ID="txtFirstName" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp; *Last Name:
        <asp:TextBox ID="txtLastName" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MI:
        <asp:TextBox ID="txtInitial" runat="server" ReadOnly="True" MaxLength="1"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; *Email:
        <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Button ID="btnChangePass" runat="server" Height="18px" Text="Change Password" Width="127px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; *Password:
        <asp:TextBox ID="txtPassword" runat="server" ReadOnly="True" TextMode="Password"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; *Address:
        <asp:TextBox ID="txtAddress" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; City:
        <asp:TextBox ID="txtCity" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; State:
        <asp:TextBox ID="txtState" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp; *Zip Code:
        <asp:TextBox ID="txtZip" runat="server" ReadOnly="True" AutoPostBack="True" MaxLength="5"></asp:TextBox>
        <br />
        *Phone:
        <asp:TextBox ID="txtPhone" runat="server" ReadOnly="True" MaxLength="10"></asp:TextBox>
        <br />
        Credit Card 1 Type:<asp:TextBox ID="txtCCType1" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        Credit Card 1 Number<asp:TextBox ID="txtCCN1" runat="server" AutoPostBack="True" ReadOnly="True" MaxLength="16"></asp:TextBox>
        <br />
        Credit Card 2 Type<asp:TextBox ID="txtCCType2" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        Credit Card 2 Number<asp:TextBox ID="txtCCN2" runat="server" AutoPostBack="True" ReadOnly="True" MaxLength="16"></asp:TextBox>
        <br />
        <asp:Button ID="btnModify" runat="server" Text="Modify" />
        <asp:Button ID="btnSave" runat="server" Enabled="False" Text="Save" Visible="False" />
        <asp:Button ID="btnAbortModify" runat="server" Text="Abort Modify" Enabled="False" Visible="False" />
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </div>

       
 
</asp:Content>
