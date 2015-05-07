<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="EditSong.aspx.vb" Inherits="LonghornMusic_Team18.EditProduct" %>
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
    
      <asp:Label ID="Label1" runat="server" Text="Edit Song"></asp:Label>
        <br />
    
    </div>

    <div id ="label" style="height:auto">
        <link href="LoginStyleSheet.css" rel="stylesheet" />
        <asp:Label ID="Label6" runat="server" Text="Song Name"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Album Name"></asp:Label>
        <br />
        <asp:Label ID="Label12" runat="server" Text="Artist"></asp:Label>
        <br />
        <asp:Label ID="Label13" runat="server" Text="Genre 1"></asp:Label>
        <br />
       <asp:Label ID="Label3" runat="server" Text="Genre 2"></asp:Label>
        <br />
       <asp:Label ID="Label4" runat="server" Text="Genre 3"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Genre 4"></asp:Label>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Genre 5"></asp:Label>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Price"></asp:Label>
        <br />
        <asp:Label ID="Label14" runat="server" Text="Discount Price"></asp:Label>
        <br />
        <asp:Label ID="Label15" runat="server" Text="Featured"></asp:Label>
    
    </div>

    <div id ="text" style="height:auto">
            <asp:TextBox ID="txtSong" runat="server" style="margin-top: 0px"></asp:TextBox>
       
            <br />
       
            <asp:TextBox ID="txtDescription" runat="server" style="margin-top: 0px"></asp:TextBox>
       
            <br />
            <asp:TextBox ID="txtAlbum" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtArtist" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtGenre1" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtGenre2" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtGenre3" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtGenre4" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtGenre5" runat="server"></asp:TextBox>
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


    <div id="left" style="height:auto">
        <asp:Button ID="btnRemovefrmAlbum" runat="server" Text="Remove " Width="235px" />
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="235px" CausesValidation="False" />
        <br />
        <br />
        <asp:Button ID="btnBack" runat="server" Text="Back" Width="235px" />
        <br />
        <br />
        <asp:Button ID="btnAddSong" runat="server" Text="Add Song" Width="235px" />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="gvArtist" runat="server">
        </asp:GridView>
       
    
        </div>
  
    </form>
</body>
</html>


    </asp:Content>
