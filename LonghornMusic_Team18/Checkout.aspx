<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebApplication1.Master" CodeBehind="Checkout.aspx.vb" Inherits="LonghornMusic_Team18.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="font-size: x-large; text-align: center">
        <strong>Checkout</strong></p>
    <br />
    <asp:Panel ID="pnlInitialCheckout" runat="server" Height="526px" Width="802px">
        <p style="font-size: medium; text-align: left">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Subtotal:
            <asp:Label ID="lblCheckoutSubtotal0" runat="server" Text="[lblCheckoutSubtotal]"></asp:Label>
        </p>
        <p style="font-size: medium; text-align: left">
            &nbsp; Tax @ 8.25%:
            <asp:Label ID="lblCheckoutTax0" runat="server" Text="[lblCheckoutTax]"></asp:Label>
        </p>
        <p style="font-size: medium; text-align: left">
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Total:
            <asp:Label ID="lblCheckoutTotal0" runat="server" Text="[lblCheckoutTotal]"></asp:Label>
        </p>
        <p style="font-size: medium; text-align: left">
            Select Payment Method:&nbsp;
            <asp:DropDownList ID="ddlPaymentMethod0" runat="server" Height="16px" Width="193px">
            </asp:DropDownList>
        </p>
        <asp:Panel ID="pnlAddPaymentMethod0" runat="server" Visible="False">
            Enter a New Payment Method:
            <br />
            <br />
            &nbsp;Name on Card:
            <asp:TextBox ID="TextBox5" runat="server" Width="200px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp; Card Number:
            <asp:TextBox ID="TextBox6" runat="server" Width="197px"></asp:TextBox>
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; CVC:
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        </asp:Panel>
        <br />
        Is this purchase a Gift?<asp:RadioButtonList ID="RadioButtonList2" runat="server" Height="32px" Width="86px">
            <asp:ListItem>Yes</asp:ListItem>
            <asp:ListItem>No</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        If gift, please enter recipient&#39;s email address:
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lblErrorGift0" runat="server" Text="[lblErrorGift]"></asp:Label>
        <br />
        <br />
        <asp:Button ID="btnProceed0" runat="server" Text="Proceed With Order" Width="187px" />
        <br />
        <br />
        <asp:GridView ID="gvCheckoutCart0" runat="server">
        </asp:GridView>
        <br />
        <asp:Panel ID="pnlFinalCheckout" runat="server">
            <span style="font-size: large"><strong>You&#39;re Almost Done! Review your Order and Finish Transaction!</strong></span><br />
            <br />
            Order Total:
            <asp:Label ID="lblOrderTotal" runat="server" Text="[lblOrderTotal]"></asp:Label>
            <br />
            <br />
            Payment Method Used:
            <asp:Label ID="lblPaymentUsed" runat="server" Text="[lblPaymentUsed]"></asp:Label>
            &nbsp;*use ddlSelectedIndex.toString
            <br />
            <br />
            Email Address:
            <asp:Label ID="lblEmail" runat="server" Text="[lblEmail]"></asp:Label>
            &nbsp;*use user if recipient field is blank<br />
            <br />
            <asp:Button ID="btnConfirmOrder" runat="server" Text="Confirm Order" Width="157px" />
            <br />
            <br />
            <asp:Label ID="lblConfirmationMessage" runat="server" Text="[lblConfirmationMessage]"></asp:Label>
            <br />
            <br />
            <asp:LinkButton ID="lnkHomePage" runat="server">Back to Home Page</asp:LinkButton>
        </asp:Panel>
    </asp:Panel>
</asp:Content>
