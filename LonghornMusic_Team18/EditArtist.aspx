<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="EditArtist.aspx.vb" Inherits="LonghornMusic_Team18.EditArtist" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="LoginStyleSheet.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
    <div id ="banner">
    
        Edit Artist<br />
    
    </div>

       
    <div id="left">
    
        <br />
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="232px" CausesValidation="False" style="height: 26px" />
        <br />
        <br />
        <asp:Button ID="btnAddArtist" runat="server" Text="Add Artist" Width="232px" />
        <br />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;
        <br />
        <asp:GridView ID="gvArtist" runat="server">
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
        <asp:Label ID="Label12" runat="server" Text="Artist"></asp:Label>
        <br />
        Description<br />
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
            <asp:TextBox ID="txtArtist" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
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