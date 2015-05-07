<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="EditAlbum.aspx.vb" Inherits="LonghornMusic_Team18.EditAlbum" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="LoginStyleSheet.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
    <div id ="banner">
    
        <asp:Label ID="Label1" runat="server" Text="Edit Album"></asp:Label><br />
    
    </div>

       
    <div id="left" style="height:auto">
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="235px" CausesValidation="False" />
        <br />
        <br />
        <asp:Button ID="btnAddAlbum" runat="server" Text="Add Album" Width="235px" />
        <br />
        <br />
        <asp:Button ID="BtnAddSong" runat="server" Text="Add Song" Width="235px" />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />

        Song List:
        <br />
        <asp:GridView ID="gvSongList" runat="server" style="margin-top: 0px">
            <Columns>
                <asp:CommandField SelectText="Remove" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        </div>

           
    <div id ="label" style="height:auto">
        <link href="LoginStyleSheet.css" rel="stylesheet" />
        <asp:Label ID="Label10" runat="server" Text="Album Name"></asp:Label>
        <br />
                <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
<br />
        <asp:Label ID="Label12" runat="server" Text="Artist"></asp:Label>
        <br />
                <asp:Label ID="Label3" runat="server" Text="Price"></asp:Label>
<br />
        <asp:Label ID="Label14" runat="server" Text="Discount Price"></asp:Label>
        <br />
        <asp:Label ID="Label15" runat="server" Text="Featured"></asp:Label>
    
    </div>

        <div id ="text"  style="height:auto">
            <asp:TextBox ID="txtAlbum" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtArtist" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtDiscountPrice" runat="server"></asp:TextBox>
            <br />
            <asp:RadioButtonList ID="radFeatured" runat="server">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem Selected="True">No</asp:ListItem>
            </asp:RadioButtonList>
        </div>

  
    </form>
</body>
</html>

</asp:content>


