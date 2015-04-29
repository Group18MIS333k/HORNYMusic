
<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/site1.Master" CodeBehind="AlbumDetail.aspx.vb" Inherits="LonghornMusic_Team18.AlbumDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                <!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    
<body>
    <link href="DescriptionPageStyleSheet.css" rel="stylesheet" />
    <div id ="banner">
    
        <asp:Label ID="Label3" runat="server" Font-Size="XX-Large" Text="Album Details"></asp:Label>    
    </div>    
    
    <div id="picture">
        <asp:Image ID="Image1" runat="server" />

    </div>
        
    <div id="LeftDesc">
                        <b>Album Name:</b><asp:Label ID="LblAlbumName" runat="server"></asp:Label>
                        <br />
                        <br />
                        <b>Artist:</b><asp:Label ID="LblArtistName" runat="server"></asp:Label>
                        <br />
                        <asp:LinkButton ID="lnkArtist" runat="server" PostBackUrl="~/ArtistDetail.aspx">Go To Artist</asp:LinkButton>
                        <br />
                        <br />
                        <b>Track List:</b><br />
                        <asp:GridView ID="gvTrackList" runat="server">
                            <Columns>
                                <asp:CommandField ShowSelectButton="True" />
                            </Columns>
                        </asp:GridView>
                        
    </div>         
            
    <div id="RightDesc">
                        <b>Price:</b>
                        <asp:Label ID="lblPrice" runat="server"></asp:Label>
                        <br /><br />
                        <b>Album Description:</b>
                        <asp:Label ID="lblAlbumDescription" runat="server"></asp:Label>
                        <br /><br />
                        <b>Ratings & Reviews:</b>
                        <asp:Label ID="lblRatingsNReviews" runat="server"></asp:Label>
                        <br /><br />
                        <asp:Button ID="BtnAdd2Cart" runat="server" Text="Add To Cart" />

    </div>
       
</body>
</html>
           
</asp:Content>
