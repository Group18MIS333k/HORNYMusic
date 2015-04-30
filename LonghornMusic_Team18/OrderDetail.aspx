<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/site1.Master" CodeBehind="OrderDetail.aspx.vb" Inherits="LonghornMusic_Team18.OrderDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <p style="text-align: center; font-size: xx-large">
        <strong>Order Detail</strong></p>
    <p style="text-align: center; font-size: small">
&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:GridView ID="gvOrderDetail" runat="server">
            <Columns>
                <asp:CommandField ShowSelectButton="True"></asp:CommandField>
            </Columns>
        </asp:GridView>
    </p>
</asp:Content>
