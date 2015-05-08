<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="MyMusicPage.aspx.vb" Inherits="LonghornMusic_Team18.MyMusicPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span style="font-size: xx-large">My Music<br />
    <br />
    </span>
    <asp:Label ID="Label4" runat="server" Text="Want to Rate, Review, Or Comment?"></asp:Label>
    <br />
    Select Below whether you want to rate Artist, Album, Or Song and then select the Rate Button<br />
    <asp:DropDownList ID="ddlRateReview" runat="server" AutoPostBack="True">
        <asp:ListItem>Select Option</asp:ListItem>
        <asp:ListItem>Album</asp:ListItem>
        <asp:ListItem>Artist</asp:ListItem>
        <asp:ListItem>Song</asp:ListItem>
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Sort Music By: "></asp:Label>
    <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
    <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
    <br />
&nbsp;<asp:GridView ID="gvMyMusic" runat="server">
        <Columns>
            <asp:ButtonField ButtonType="Button" CommandName="Select" HeaderText="Rate" ShowHeader="True" Text="Rate" />
        </Columns>
    </asp:GridView>
</asp:Content>
