<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/site1.Master" CodeBehind="SongSearch.aspx.vb" Inherits="LonghornMusic_Team18.Search" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div id="Search&Results" style="position: relative; float:left; width:90%; height:100%">
            <div id="SearchHeader" style="position:relative;float:left; width:100%; height:10%; text-align:center">
                <asp:Label ID="Label4" runat="server" Text="Music Search" Font-Size="larger"></asp:Label>
                <br />
                <asp:LinkButton ID="lnkSongs" runat="server" Enabled="false">Songs</asp:LinkButton>    &nbsp;  
                <asp:LinkButton ID="LnkArtists" runat="server">Artists</asp:LinkButton>                &nbsp;
                <asp:LinkButton ID="LnkAlbums" runat="server">Albums</asp:LinkButton>
            </div>


            <div id="Searchbox" style="position: relative; float:left;  width:90%; text-align: center;">
                Title:
                <asp:TextBox ID="txtTitle" runat="server" Width="159px"></asp:TextBox>
                        &nbsp;&nbsp;<br />
                <br />
                   Artist:
                   <asp:TextBox ID="txtArtist" runat="server" Width="159px"></asp:TextBox>
                        &nbsp;<br />
                <br />
                   Album:
                   <asp:TextBox ID="txtAlbum" runat="server" Width="159px"></asp:TextBox>
                        &nbsp;<br />
                <br />   
                 Rating:
                <asp:Label ID="Label5" runat="server" Text=":"></asp:Label>
                <asp:TextBox ID="txtRatingLower" runat="server" Width="36px"></asp:TextBox>
                
                &nbsp;to
                <asp:TextBox ID="txtRatingHigher" runat="server" Width="39px"></asp:TextBox>
                
        
                <br />
                <br />
                
        
                <asp:Button ID="btnPartialSearch" runat="server" Text="Partial Music Search" Width="166px" />
                <asp:Button ID="btnKeywordSearch" runat="server" Text="Keyword Music Search" Width="166px" />
                <br />
                <br />
               
                &nbsp;&nbsp; Sort By:
                <asp:DropDownList ID="ddlSort" runat="server" Height="16px" Width="123px">
                    <asp:ListItem>Song Title Ascending</asp:ListItem>
                    <asp:ListItem>Title Descending</asp:ListItem>
                    <asp:ListItem>Artist Name Ascending</asp:ListItem>
                    <asp:ListItem>Artist Name Descending</asp:ListItem>
                    <asp:ListItem>Rating Ascending</asp:ListItem>
                    <asp:ListItem>Rating Descending</asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:Label ID="lblMessage" runat="server" Text="[lblMessage]"></asp:Label>
                <br />
                <br />
            </div> 
            
             <div id="Genre" style="position:relative; float: right; width: 10%;height:90%;max-height: 100%">

                 <asp:CheckBoxList ID="CheckBoxList1" runat="server">
                 </asp:CheckBoxList>
   
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
