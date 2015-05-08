<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="Vote.aspx.vb" Inherits="LonghornMusic_Team18.Vote" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div style="width: 373px; margin-top: 0px; height: 267px; text-align: right;">

&nbsp;&nbsp;&nbsp; Song Name:
        <asp:TextBox ID="txtSongName" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
            &nbsp;&nbsp;&nbsp; Album Name:
        <asp:TextBox ID="txtAlbumName" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Artist Name:
        <asp:TextBox ID="txtArtistName" runat="server" ReadOnly="True" MaxLength="1"></asp:TextBox>
        <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
            <asp:GridView ID="gvComments" runat="server">
            </asp:GridView>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
    </div>

       
    <p>
        <br />
    </p>
    <asp:Button ID="btnUpvote" runat="server" Text="Upvote Comment" />
    <asp:Button ID="btnDownvote" runat="server" Text="Downvote Comment" />
        <asp:LinkButton ID="btnBack" runat="server" PostBackUrl="~/SongDetail.aspx">Back</asp:LinkButton>
    <p>
    </p>
</asp:Content>
