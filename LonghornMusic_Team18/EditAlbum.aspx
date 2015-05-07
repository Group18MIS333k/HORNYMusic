<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditAlbum.aspx.vb" Inherits="LonghornMusic_Team18.EditAlbum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="LoginStyleSheet.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
    <div id ="banner">
    
        Edit Album<br />
    
    </div>

       
    <div id="left">
    
        <br />
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="232px" CausesValidation="False" style="height: 26px" />
        <br />
        <br />
        <asp:Button ID="btnAddAlbum" runat="server" Text="Add Album" Width="235px" />
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" Text="Add Song" Width="232px" />
        <br />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        Song List:<br />
        <asp:GridView ID="gvSongList" runat="server" style="margin-top: 0px">
            <Columns>
                <asp:CommandField SelectText="Remove" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <br />
&nbsp;
        &nbsp;
        &nbsp;
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
        &nbsp;&nbsp;<br />
        <asp:Label ID="Label10" runat="server" Text="Album Name"></asp:Label>
        <br />
        Description<br />
        <asp:Label ID="Label12" runat="server" Text="Artist"></asp:Label>
        <br />
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
       
            <br />
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



