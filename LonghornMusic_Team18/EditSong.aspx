<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditSong.aspx.vb" Inherits="LonghornMusic_Team18.EditProduct" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="LoginStyleSheet.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
    <div id ="banner">
    
        Edit Song<br />
    
    </div>

       
    <div id="left">
    
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="232px" CausesValidation="False" style="height: 26px" />
        <br />
        <br />
        <asp:Button ID="btnAddSong" runat="server" Text="Add Song" Width="232px" />
        <br />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;
        &nbsp;
        &nbsp;
        <asp:GridView ID="gvArtist" runat="server" Visible="False">
        </asp:GridView>
        <br />
        <br />
        <asp:GridView ID="gvAlbum" runat="server" Visible="False">
        </asp:GridView>
        <br />
        <asp:GridView ID="gvSongs" runat="server" Visible="False">
        </asp:GridView>
        <br />
        <br />
    
        </div>

    
         
    <div id ="label">
        <link href="LoginStyleSheet.css" rel="stylesheet" />
        <br />
        <br />
        &nbsp;<asp:Label ID="Label6" runat="server" Text="Song Name"></asp:Label>
        &nbsp;<br />
        Description<br />
        <asp:Label ID="Label10" runat="server" Text="Album Name"></asp:Label>
        <br />
        <asp:Label ID="Label12" runat="server" Text="Artist"></asp:Label>
        <br />
        <asp:Label ID="Label13" runat="server" Text="Genre"></asp:Label>
        1<br />
        Genre2<br />
        Genre3<br />
        Genre 4<br />
        Genre5<br />
        Price<br />
        <asp:Label ID="Label14" runat="server" Text="Discount Price"></asp:Label>
        <br />
        <asp:Label ID="Label15" runat="server" Text="Featured"></asp:Label>
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
            <br />
       
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


