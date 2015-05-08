<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/site1.Master" CodeBehind="ShoppingCart.aspx.vb" Inherits="LonghornMusic_Team18.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="font-size: large">
        <strong>Review your Cart:</strong></p>
    <p>
        <asp:Button ID="btnCheckout" runat="server" Text="Checkout " Width="141px" />
    </p>
    <p>
        <asp:GridView ID="gvShoppingCart" runat="server">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </p>

      <p>
&nbsp; Subtotal:
        <asp:Label ID="lblSubtotal" runat="server" Text="[lblSubtotal]"></asp:Label>
    </p>
    <p>
&nbsp; Savings:
        <asp:Label ID="lblSavings" runat="server" Text="[lblDiscount]"></asp:Label>
    </p>
    <p>
&nbsp;&nbsp;Tax @ 8.25%:
        <asp:Label ID="lblTax" runat="server" Text="[lblTax]"></asp:Label>
    </p>
    <p>
&nbsp;&nbsp;Total Price:
        <asp:Label ID="lblTotal" runat="server" Text="[lblTotal]"></asp:Label>
    </p>
    
</asp:Content>
