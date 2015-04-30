<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="RateReview.aspx.vb" Inherits="LonghornMusic_Team18.RateReview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="LoginStyleSheet.css" rel="stylesheet" type="text/css" />
    </head>
<body>
    <form id="form1" runat="server">
    <div id ="banner">
    
        Rate and Review&nbsp;
        <br />
    
    </div>

       
    <div id="left">
    
        <br />
        <br />
        <br />
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="232px" CausesValidation="False" style="height: 26px" />
        <br />
        <br />
        <asp:Button ID="btnDelete" runat="server" Text="Delete Review" Width="232px" CausesValidation="False" />
        <br />
        <br />
        <br />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <br />
        &nbsp;&nbsp;&nbsp;
        <br />
        <asp:Button ID="Button1" runat="server" Text="Email" />
        <br />
&nbsp;
        &nbsp;
        &nbsp;
        <br />
        <asp:Button ID="Button2" runat="server" Text="Checkout" />
        <br />
        <br />
        <br />
        <br />
    
        </div>

    
         
    <div id ="label">
        <link href="LoginStyleSheet.css" rel="stylesheet" />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="Label6" runat="server" Text="Review "></asp:Label>
        <br />
        <asp:Label ID="Label10" runat="server" Text="100 chr limit"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label11" runat="server" Text="Rating"></asp:Label>
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
       
            <asp:TextBox ID="txtReview" runat="server" Height="92px" MaxLength="100" TextMode="MultiLine" Width="241px">Enter review here</asp:TextBox>
       
            <br />
            <br />
            <br />
            <asp:RadioButtonList ID="radRating" runat="server">
                <asp:ListItem>1</asp:ListItem>
                <asp:ListItem>2</asp:ListItem>
                <asp:ListItem>3</asp:ListItem>
                <asp:ListItem>4</asp:ListItem>
                <asp:ListItem>5</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            Gift?<asp:RadioButtonList ID="radgift" runat="server">
                <asp:ListItem>yes</asp:ListItem>
                <asp:ListItem>no</asp:ListItem>
            </asp:RadioButtonList>
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

  
    </form>
</body>
</html>

