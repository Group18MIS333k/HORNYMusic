<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebApplication1.Master" CodeBehind="ArtistDetail.aspx.vb" Inherits="WebApplication1.ArtistDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    
<body>
    <link href="DescriptionPageStyleSheet.css" rel="stylesheet" />
    <div id ="banner">
    
        <asp:Label ID="Label3" runat="server" Font-Size="XX-Large" Text="Artist Details"></asp:Label>    
    </div>    
    
    <div id="picture">
        <asp:Image ID="Image1" runat="server" />
       
    </div>
        
    <div id="LeftDesc">
                        <b>Artist:</b><asp:Label ID="LblArtistName" runat="server"></asp:Label>
                        <br />
                        <br />
                        <b>Album List:</b><br />
                        <asp:GridView ID="gvAlbumList" runat="server">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        
                        <br />
                        <b>Song List:</b><br />
                        <asp:GridView ID="gvSongList" runat="server">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
    </div>         

    <div id="RightDesc">

        <b>Artist Description:</b>
        <asp:Label ID="lblArtistDescription" runat="server"></asp:Label>
        <br /><br />
        <b>Ratings & Reviews:</b>
                        <asp:Label ID="LblRatingsNReviews" runat="server"></asp:Label>

    </div>
       
</body>
</html>
           
</asp:Content>
