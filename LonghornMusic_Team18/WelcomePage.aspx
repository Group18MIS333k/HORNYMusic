<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="WelcomePage.aspx.vb" Inherits="LonghornMusic_Team18.WelcomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <div id ="banner">
    
        <asp:Label ID="Label17" runat="server" Font-Size="Larger" Text="Welcome Page"></asp:Label>
        <br />
    
    </div>

       
    <div id="left" style="height:auto;position:relative; float:left">
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
        </div>

        <div id ="text" style="height:auto; position:relative; float:left; padding-left: 25px">
           
            <asp:Panel ID="PanelLogin" runat="server" Height="70px" >
                 <asp:LinkButton ID="lnkLogin" runat="server" PostBackUrl="~/Login.aspx">Customer Log In</asp:LinkButton>
                 <br />
                 <asp:LinkButton ID="lnkEmployeeLogin" runat="server" PostBackUrl="~/EmployeeLogin.aspx">Employee Log In</asp:LinkButton>
            <br />
            <asp:LinkButton ID="lnkRegister" runat="server" PostBackUrl="~/NewUserRegistration.aspx">Register</asp:LinkButton>
            <br />
            </asp:Panel>
            
            <asp:Panel ID="PanelAccount" runat="server">
                <asp:LinkButton ID="lnkAccount" runat="server" PostBackUrl="~/AccountInfo.aspx">Manage Account</asp:LinkButton>
            <br />
       
            <asp:LinkButton ID="lnkMyMusic" runat="server" PostBackUrl="~/MyMusic.aspx">My  Music</asp:LinkButton>
       
            <br />
            <asp:LinkButton ID="lnkLogout" runat="server">Log out</asp:LinkButton>
            <br />
            <br />
            </asp:Panel>
        </div>


</body>
</html>
    </asp:Content>
