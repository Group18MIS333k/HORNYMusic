<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="AddArtist.aspx.vb" Inherits="LonghornMusic_Team18.AddArtist" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server" >

    <div id ="banner">
    <asp:Label ID="Label1" runat="server" Text="Add Artist"></asp:Label>
    <br />
    </div>
       
 
    <div id ="label" style="height:auto">
        <link href="LoginStyleSheet.css" rel="stylesheet" />
        <strong>
        New Artist</strong><br />
        <br />
        <asp:Label ID="Label12" runat="server" Text="Artist"></asp:Label>
        <br />
       <asp:Label ID="Label2" runat="server" Text="Description"></asp:Label> 
        <br />
        <asp:Label ID="Label15" runat="server" Text="Featured"></asp:Label>
        <br />
        <br />
        <br />
        <strong>&nbsp;Song</strong><br />
        <asp:Label ID="Label6" runat="server" Text="Song Name"></asp:Label>
        &nbsp;<br />
        <asp:Label ID="Label18" runat="server" Text="Description"></asp:Label>
        <br />
        <asp:Label ID="Label10" runat="server" Text="Album Name"></asp:Label>
        <br />
        <asp:Label ID="Label13" runat="server" Text="Genre 1"></asp:Label>
        <br />
       <asp:Label ID="Label3" runat="server" Text="Genre 2"></asp:Label>
        <br />
       <asp:Label ID="Label4" runat="server" Text="Genre 3"></asp:Label>
        <br />
        <asp:Label ID="Label5" runat="server" Text="Genre 4"></asp:Label>
        <br />
        <asp:Label ID="Label7" runat="server" Text="Genre 5"></asp:Label>
        <br />
        <asp:Label ID="Label8" runat="server" Text="Price"></asp:Label>
        <br />
        <asp:Label ID="Label14" runat="server" Text="Discount Price"></asp:Label>
        <br />
        <asp:Label ID="Label17" runat="server" Text="Featured"></asp:Label>

        <br />

    </div>

        <div id ="text" style="height:auto">

            <br />
            <br />
            <asp:TextBox ID="txtArtist" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            <br />
            <asp:RadioButtonList ID="radFeatured" runat="server">
                <asp:ListItem Value="Y">Yes</asp:ListItem>
                <asp:ListItem Selected="True" Value="N">No</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <br />
            <br />
       
            <asp:TextBox ID="txtSong" runat="server" style="margin-top: 0px"></asp:TextBox>
       
            <br />
       
            <asp:TextBox ID="txtSongDescription" runat="server" style="margin-top: 0px"></asp:TextBox>
       
            <br />
            <asp:TextBox ID="txtAlbum" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtGenre1" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtGenre2" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtGenre3" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtGenre4" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtGenre5" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            <br />
            <asp:TextBox ID="txtDiscountPrice" runat="server"></asp:TextBox>
            <br />
            <asp:RadioButtonList ID="radFeatured0" runat="server">
                <asp:ListItem>Yes</asp:ListItem>
                <asp:ListItem Selected="True">No</asp:ListItem>
            </asp:RadioButtonList>

            <br />

        </div>

           <div id="left" style="height:auto">
        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="230px" CausesValidation="False" style="margin-left:100px"/>
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
               <br />
               <asp:GridView ID="gvNewArtist" runat="server" Visible="False">
               </asp:GridView>
               <asp:GridView ID="gvAlbum" runat="server" Visible="False">
               </asp:GridView>
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
               <br />
        </div>

  
</asp:Content>