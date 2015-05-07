<%@ Page Title="Add Album" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="AddAlbum.aspx.vb" Inherits="LonghornMusic_Team18.AddAlbum" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <p style="width: 100%; 	position: relative;	text-align: center;	font-size: larger;">
    
        <asp:Label ID="Label1" runat="server" Text="Add Album"></asp:Label>
    </p>

    <p style=" width: 50%;	position: relative;	float: left;height: auto;">
        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="232px"  CausesValidation="False"  Enabled="False" />
        <br />
        <br />
        
        <asp:Label ID="lblArtistSearch" runat="server" Text="Artist Search"></asp:Label>
        <br />
        <asp:TextBox ID="txtArtistSearch" runat="server"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Button ID="btnSearchArtist" runat="server" Text="Search Artist" Width="120px" />
        <br />
        <asp:GridView ID="gvArtistSearch" runat="server" style="margin-top:10px">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Label ID="lblPickSongs" runat="server" Text="Pick Songs:"></asp:Label>
        <br />
        <asp:GridView ID="gvSongs" runat="server" style="margin-top:10PX">
            <Columns>
                <asp:CommandField SelectText="Add Song" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:GridView ID="gvNewAlbum" runat="server" Visible="False">
        </asp:GridView>
   
    </p>

    <p style="position: relative;float: left;width: 15%;text-align: left;line-height: 23px;height: auto;top: 0px;left: 0px"> 
         <br />
        <br />
        <br />
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
        <br />
         <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <asp:Label ID="lblalbum" runat="server" Text="" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lblartist" runat="server" Text="" Visible="False"></asp:Label><br /> 

    </p>

    <p style="position: relative;float: left;width: 30%;line-height: 23px;top: 0px;left: 4px;height: auto">
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
            <asp:TextBox ID="txtDiscountPrice" runat="server"></asp:TextBox>
            <br />
            <asp:RadioButtonList ID="radFeatured" runat="server">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem Selected="True">No</asp:ListItem>
            </asp:RadioButtonList>

    </p>


</asp:Content>
