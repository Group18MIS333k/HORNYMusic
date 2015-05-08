<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="EditArtist.aspx.vb" Inherits="LonghornMusic_Team18.EditArtist" %>
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
    
        <asp:Label ID="Label1" runat="server" Text="Edit Artist"></asp:Label><br />
    
    </div>

       
    <div id="left" style="height:auto">
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="232px" CausesValidation="False" style="height: 26px" />
        <br />
        <br />
        <asp:Button ID="btnAddArtist" runat="server" Text="Add Artist" Width="232px" />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>

        <br />
        <br />
        <asp:GridView ID="gvArtist" runat="server">
        </asp:GridView>
        <br />
        <br />
        <br />
        <br />
        <br />

        </div>

    
         
    <div id ="label" style="height:auto">
        <link href="LoginStyleSheet.css" rel="stylesheet" />
        <asp:Label ID="Label12" runat="server" Text="Artist"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label15" runat="server" Text="Featured"></asp:Label>

    </div>

        <div id ="text" style="height:auto">

            <asp:TextBox ID="txtArtist" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            <br />
            <asp:RadioButtonList ID="radFeatured" runat="server">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem Selected="True">No</asp:ListItem>
            </asp:RadioButtonList>
          
        </div>

  
    </form>
</body>
</html>
    </asp:Content>
