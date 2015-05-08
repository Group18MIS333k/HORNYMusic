<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RateReview.aspx.vb" Inherits="LonghornMusic_Team18.RateReview" MasterPageFile="~/Site1.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id ="banner">
    
        <asp:Label ID="Label1" runat="server" Text="Rate and Review"></asp:Label>
        <br />
    
    </div>

       
    <div id="left" style="height:auto">
        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="235px" />
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="235px" CausesValidation="False" />
        <br />
        <br />
        <asp:Button ID="btnDelete" runat="server" Text="Delete Review" Width="235px" CausesValidation="False" />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        <asp:GridView ID="gvReview" runat="server">
        </asp:GridView>
        <br />
        <br />

    
        </div>

    <div id ="label" style="height:auto">
        <link href="LoginStyleSheet.css" rel="stylesheet" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="Review: "></asp:Label>
        <br />
        <asp:Label ID="Label10" runat="server" Text="100 chr limit"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label11" runat="server" Text="Rating"></asp:Label>
      
    </div>

        <div id ="text" style="height:auto">

            <asp:TextBox ID="txtReview" runat="server" Height="92px" MaxLength="100" TextMode="MultiLine" Width="241px">Enter review here</asp:TextBox>
       
            <br />
            <br />
            <br />
            <asp:RadioButtonList ID="radRating" runat="server">
                <asp:ListItem Value="1.0">1</asp:ListItem>
                <asp:ListItem Value="2.0">2</asp:ListItem>
                <asp:ListItem Value="3.0">3</asp:ListItem>
                <asp:ListItem Value="4.0">4</asp:ListItem>
                <asp:ListItem Selected="True" Value="5.0">5</asp:ListItem>
            </asp:RadioButtonList>
            <br />
           
        </div>

  


</asp:Content>
