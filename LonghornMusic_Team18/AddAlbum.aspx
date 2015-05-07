<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="AddAlbum.aspx.vb" Inherits="LonghornMusic_Team18.AddAlbum" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="LoginStyleSheet.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
    <div id ="banner">
    
        Add Album<br />
    
    </div>

       
    <div id="left">
    
        <br />
        <br />
        <br />
        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="232px" CausesValidation="False" style="height: 26px" Enabled="False" />
        <br />
        <br />
        <asp:Button ID="btnHome" runat="server" Text="Go Home" Visible="False" Width="233px" />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        &nbsp;<asp:Label ID="lblalbum" runat="server" Text="Label" Visible="False"></asp:Label>
        &nbsp;&nbsp;
        <br />
        <asp:Label ID="lblartist" runat="server" Text="Label" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" Visible="False">
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="lblArtistSearch" runat="server" Text="Artist Search"></asp:Label>
        <br />
        <asp:TextBox ID="txtArtistSearch" runat="server"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Button ID="btnSearchArtist" runat="server" Text="Search Artist" Width="116px" />
        <br />
        <asp:GridView ID="gvArtistSearch" runat="server" style="margin-top: 0px">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblPickSongs" runat="server" Text="Pick Songs:"></asp:Label>
        <br />
        <asp:GridView ID="gvSongs" runat="server">
            <Columns>
                <asp:CommandField SelectText="Add Song" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <br />
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
            <asp:TextBox ID="txtArtist" runat="server" ReadOnly="True"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtDiscountPrice" runat="server">0</asp:TextBox>
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