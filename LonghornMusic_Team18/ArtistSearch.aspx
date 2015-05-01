<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/site1.Master" CodeBehind="ArtistSearch.aspx.vb" Inherits="LonghornMusic_Team18.ArtistSearch" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="Search&Results" style="position: relative; float:left; width:90%; height:100%">
            <div id="SearchHeader" style="position:relative;float:left; width:100%; height:10%; text-align:center">
                <asp:Label ID="Label4" runat="server" Text="Music Search" Font-Size="larger"></asp:Label>
                <br />
                <asp:LinkButton ID="lnkSongs" runat="server" PostBackUrl="~/SearchSong.aspx">Songs</asp:LinkButton>    &nbsp;  
                <asp:LinkButton ID="LnkArtists" runat="server" Enabled="False">Artists</asp:LinkButton>                &nbsp;
                <asp:LinkButton ID="LnkAlbums" runat="server" PostBackUrl="~/AlbumSearch.aspx">Albums</asp:LinkButton>
            </div>


            <div id="Searchbox" style="position: relative; float:left;  width:90%; text-align: center;">
                Name:
                <asp:TextBox ID="txtName" runat="server" Width="133px"></asp:TextBox>
                        &nbsp;&nbsp;<br />
                 Rating (Optional)
                <asp:Label ID="Label5" runat="server" Text=":"></asp:Label>
                <asp:TextBox ID="txtRatingLower" runat="server" Width="36px"></asp:TextBox>
                
                &nbsp;to
                <asp:TextBox ID="txtRatingHigher" runat="server" Width="39px"></asp:TextBox>
                     
                <br />
                     
                <asp:Button ID="btnPartialSearch" runat="server" Text="Partial Artist Search" Width="166px" />
                <asp:Button ID="btnKeywordSearch" runat="server" Text="Keyword Artist Search" Width="166px" />
                <br />
                <br />
                
                &nbsp;&nbsp; Sort By:
                <asp:DropDownList ID="ddlSort" runat="server" Height="16px" Width="123px">
                    <asp:ListItem>Name Ascending</asp:ListItem>
                    <asp:ListItem>Name Descending</asp:ListItem>
                    <asp:ListItem>Rating Ascending</asp:ListItem>
                    <asp:ListItem>Rating Descending</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="lblMessage" runat="server" Text="[lblMessage]"></asp:Label>
                <br />
                <br />
            </div> 
            
             <div id="Genre" style="position:relative; float: right; width: 10%;height:90%;max-height: 100%">

            <asp:ListBox ID="lbxGenre" runat="server"></asp:ListBox>
   
        </div>



            <div id="Gridview">

                <asp:Label ID="lblRecords" runat="server" Text="[lblRecords]"></asp:Label>
            <asp:GridView ID="gvSearchResults" runat="server" Width="272px">
                <Columns>
                    <asp:CommandField ShowSelectButton="True"></asp:CommandField>
                </Columns>
            </asp:GridView>
                     
        </div>
     
            
                  
        </div>
</asp:Content>
