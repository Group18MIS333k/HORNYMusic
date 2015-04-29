<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebApplication1.Master" CodeBehind="Login.aspx.vb" Inherits="LonghornMusic_Team18.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <p>
        *customer log in<br />*customer log in views products</p>
    <p>
    </p>
    <p style="font-size: x-large; text-align: center">
        <strong>Please Log In:</strong></p>
    <p style="font-size: medium; text-align: center">
        Email Address:&nbsp;
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
