<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebApplication1.Master" CodeBehind="EmployeeLogin.aspx.vb" Inherits="WebApplication1.EmployeeLogin" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <p>
        *Employee log in<br />*employee logs in to manage customers and other things</p>
    <p>
    </p>
    <p style="font-size: x-large; text-align: center">
        <strong>Please Log In:</strong></p>
    <p style="font-size: medium; text-align: center">
        Employee ID:&nbsp;
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    </p>
    <p style="font-size: medium; text-align: center">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Password:&nbsp;
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
    </p>
    <p style="font-size: medium; text-align: center">
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnLogin" runat="server" Text="Login" Width="144px" />
    </p>
    <p style="font-size: medium; text-align: center">
        <asp:Label ID="lblError" runat="server" Text="[lblError]"></asp:Label>
    </p>

</asp:Content>
