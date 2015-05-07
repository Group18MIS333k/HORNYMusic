<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/site1.Master" CodeBehind="OrderHistory.aspx.vb" Inherits="LonghornMusic_Team18.OrderHistory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p style="text-align: center; font-size: xx-large">
        <strong>Order History</strong></p>
    <p style="text-align: center; font-size: small">
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="gvOrderHistory" runat="server">
            <Columns>
                <asp:CommandField ShowSelectButton="True"></asp:CommandField>
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
