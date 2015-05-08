<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="AddGenre.aspx.vb" Inherits="LonghornMusic_Team18.AddGenre" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  
   
    <link href="LoginStyleSheet.css" rel="stylesheet" type="text/css" />
   

    
    <div id ="banner">
    
        Add Genre</div>

       
    <div id="left">
    
        <br />
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="232px" CausesValidation="False" style="height: 26px" />
        <br />
        <br />
        <asp:Label ID="lblerror" runat="server"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;
        <br />
        <br />
&nbsp;
        &nbsp;
        &nbsp;
        <br />
        <br />
        <br />
        <br />
        <br />
    
        </div>

    
         
    <div id ="label">
        <link href="LoginStyleSheet.css" rel="stylesheet" />
        <br />
        <br />
        Genre<br />
        <br />
        <br />
        <br />
        <br />
&nbsp;<br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
&nbsp;&nbsp;
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    
    </div>

        <div id ="text">

            <br />
            <br />
            <asp:TextBox ID="txtGenre" runat="server"></asp:TextBox>
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
            <br />

        </div>

  
   

</asp:Content>
