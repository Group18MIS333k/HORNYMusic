<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/site1.Master" CodeBehind="SongDetail.aspx.vb" Inherits="LonghornMusic_Team18.SongDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    
<body>
    <link href="DescriptionPageStyleSheet.css" rel="stylesheet" />
    <div id ="banner">
    
        <asp:Label ID="Label3" runat="server" Font-Size="XX-Large" Text="Song Details"></asp:Label>    
    </div>    
    
    <div id="picture">
        
        <asp:Image ID="Image1" runat="server" />
       
    </div>
        
    <div id="LeftDesc">
                        <b>Song:<br />
                        <asp:GridView ID="gvSongDescription" runat="server">
                        </asp:GridView>
                        </b>
                        <br />
                        <br />
                        <b>Artist:</b><asp:Label ID="LblArtistName" runat="server"></asp:Label>
                        <br />
                        <asp:LinkButton ID="lnkArtist" runat="server" PostBackUrl="~/ArtistDetail.aspx">Go To Artist</asp:LinkButton>
                        <br />
                        <br />
                        <b>Album:</b><asp:Label ID="LblAlbumName" runat="server"></asp:Label>
                        <br />
                        <asp:LinkButton ID="LnkAlbum" runat="server" PostBackUrl="~/AlbumDetail.aspx">Go To Album</asp:LinkButton>
                        <br />
                        <br />
                        <b>Genres:</b>                        
                        <asp:GridView ID="gvGenres" runat="server">
                        </asp:GridView>
    </div>         

    <div id="RightDesc">
        <b>Price:</b>
        <asp:Label ID="lblPrice" runat="server"></asp:Label>
        <br />
       
        <br /><br />
        <b>Ratings & Reviews:</b>
                        <br />
        <asp:GridView ID="gvSongRR" runat="server">
        </asp:GridView>
                        <br /><br />
                        <asp:Button ID="BtnAdd2Cart" runat="server" Text="Add To Cart" />

        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" />
        <asp:Button ID="btnDelete" runat="server" Text="Delete From Cart" />
        <asp:GridView ID="gvAdd2Cart" runat="server">
        </asp:GridView>

    </div>
       
</body>
</html>
           
</asp:Content>
