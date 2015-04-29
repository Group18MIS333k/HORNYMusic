<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="WelcomePage.aspx.vb" Inherits="LonghornMusic_Team18.WelcomePage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="LoginStyleSheet.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
    <div id ="banner">
    
        <asp:Label ID="Label17" runat="server" Font-Size="Larger" Text="Welcome Page"></asp:Label>
        <br />
    
    </div>

       
    <div id="left">
    
        <br />
        <br />
        <asp:Label ID="Label18" runat="server" Text="Featured Songs"></asp:Label>
        <br />
        <asp:GridView ID="gvFeaturedSongs" runat="server">
        </asp:GridView>
        <br />
        <asp:Label ID="Label19" runat="server" Text="Featured Albums"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvFeaturedAlbums" runat="server">
        </asp:GridView>
        <br />
        <br />
        &nbsp;&nbsp;
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;
        &nbsp;
        &nbsp;
        <br />
        <br />
        <br />
        </div>

    
         
    <div id ="label">
        <link href="LoginStyleSheet.css" rel="stylesheet" />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        <br />
        <br />
&nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        <br />
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
           
            <asp:Panel ID="PanelLogin" runat="server" Height="41px">
                 <asp:LinkButton ID="lnkLogin" runat="server" PostBackUrl="~/Login.aspx">Customer Log In</asp:LinkButton>
                 <br />
                 <asp:LinkButton ID="lnkEmployeeLogin" runat="server" PostBackUrl="~/EmployeeLogin.aspx">Employee Log In</asp:LinkButton>
            <br />
            <asp:LinkButton ID="lnkRegister" runat="server" PostBackUrl="~/NewUserRegistration.aspx">Register</asp:LinkButton>
            <br />
            </asp:Panel>
            <br />

            <br />
            
            <asp:Panel ID="Panel1" runat="server">
                <asp:LinkButton ID="lnkAccount" runat="server" PostBackUrl="~/AccountInformation.aspx">Account Details</asp:LinkButton>
            <br />
       
            <asp:LinkButton ID="lnkMyMusic" runat="server" PostBackUrl="~/MyMusic.aspx">My  Music</asp:LinkButton>
       
            <br />
            <asp:LinkButton ID="lnkLogout" runat="server">Log out</asp:LinkButton>
            <br />
            <br />
            </asp:Panel>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />

        </div>

  
    </form>
</body>
</html>
