<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="MyMusicPage.aspx.vb" Inherits="LonghornMusic_Team18.MyMusicPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <span style="font-size: xx-large">My Music<br />
    <br />
    </span>
    <asp:Label ID="Label4" runat="server" Text="Want to Rate, Review, Or Comment?"></asp:Label>
    <asp:DropDownList ID="ddlRateReview" runat="server"></asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="Label5" runat="server" Text="Sort Music By: "></asp:Label>
    <br />
&nbsp;<asp:GridView ID="GridView1" runat="server"></asp:GridView>
</asp:Content>
