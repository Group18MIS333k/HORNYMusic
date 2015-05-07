<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="ChangePassword.aspx.vb" Inherits="LonghornMusic_Team18.ChangePassword" %>
<asp:Content ID="Content1" runat="server" contentplaceholderid="ContentPlaceHolder1">

            <p>
                Change Password</p>
    <p style="height: 28px">
            &nbsp;Old Password:&nbsp;
            <asp:TextBox ID="txtOld" runat="server" TextMode="Password"></asp:TextBox>
            </p>
    <p style="height: 119px">
            New Password:
            <asp:TextBox ID="txtNew" runat="server"></asp:TextBox>
            <asp:Button ID="btnChange" runat="server" Text="Change" />
            <asp:Label ID="lblError" runat="server"></asp:Label>
            </p>
</asp:Content>

