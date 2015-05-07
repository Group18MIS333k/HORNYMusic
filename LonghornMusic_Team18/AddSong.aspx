<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddSong.aspx.vb" Inherits="LonghornMusic_Team18.AddSong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="LoginStyleSheet.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
    <div id ="banner">
    
        Add Song<br />
    
    </div>

       
    <div id="left">
    
        <br />
        <br />
        <br />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="232px" CausesValidation="False" style="height: 26px" />
        <br />
        <br />
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
        <asp:GridView ID="gvSong" runat="server">
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <br />
    
        </div>

    
         
    <div id ="label">
        <link href="LoginStyleSheet.css" rel="stylesheet" />
        <br />
        <br />
        &nbsp;<asp:Label ID="Label6" runat="server" Text="Song Name"></asp:Label>
        <br />
        &nbsp;Description<br />
        <asp:Label ID="Label10" runat="server" Text="Album Name"></asp:Label>
        <br />
        <asp:Label ID="Label12" runat="server" Text="Artist"></asp:Label>
        <br />
        <asp:Label ID="Label13" runat="server" Text="Genre"></asp:Label>
        &nbsp;1<br />
        Genre 2<br />
        Genre 3<br />
        Genre 4<br />
        Genre 5<br />
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
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
       
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
                <asp:ListItem Value="Y">Yes</asp:ListItem>
                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
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