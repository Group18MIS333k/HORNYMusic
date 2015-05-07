<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="NewUserRegistration.aspx.vb" Inherits="LonghornMusic_Team18.NewUserRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="body">
     <div style="height: 63px; width: 776px; text-align: center;">
         New User Registration<br />
        <br />
        <br />
        <br />
        <br />
        </div>
    <div style="width: 471px; margin-top: 0px; height: 400px; text-align: right;">

&nbsp;&nbsp;&nbsp; *First Name:
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp; *Last Name: <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MI:
        <asp:TextBox ID="txtInitial" runat="server" MaxLength="1"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; *Email:
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; *Password: <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;* Address: <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; City:
        <asp:TextBox ID="txtCity" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; State:
        <asp:TextBox ID="txtState" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;* Zip Code: <asp:TextBox ID="txtZip" runat="server" AutoPostBack="True" MaxLength="5"></asp:TextBox>
        <br />
        *Phone:
        <asp:TextBox ID="txtPhone" runat="server" MaxLength="10"></asp:TextBox>
        <br />
        Credit Card 1 Type:<asp:TextBox ID="txtCCType1" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        Credit Card 1 Number:<asp:TextBox ID="txtCCN1" runat="server" AutoPostBack="True" MaxLength="16"></asp:TextBox>
        <br />
        Credit Card 2 Type:<asp:TextBox ID="txtCCType2" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        Credit Card 2 Number:<asp:TextBox ID="txtCCN2" runat="server" AutoPostBack="True" MaxLength="16"></asp:TextBox>
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <asp:Button ID="btnRegister" runat="server" Text="Register" style="height: 26px" />
    </div>
    </div>
</asp:Content>
