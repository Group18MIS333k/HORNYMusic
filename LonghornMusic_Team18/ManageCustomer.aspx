<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/WebApplication1.Master" CodeBehind="ManageCustomer.aspx.vb" Inherits="WebApplication1.ManageCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div id="body">
     <div style="height: 134px; width: 772px; text-align: center;">
        Manage Customers
        <br />
        <br />
        Select Customer:
        <asp:DropDownList ID="ddlCustomer" runat="server" Height="16px" Width="185px">
        </asp:DropDownList>
        <br />
        Account Enabled:&nbsp;
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" Height="16px" Width="780px">
            <asp:ListItem Selected="True">Yes</asp:ListItem>
            <asp:ListItem>No</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        </div>
    <div style="width: 471px; margin-top: 0px; height: 400px; text-align: right;">

&nbsp;&nbsp;&nbsp; First Name:
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp; Last Name:
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MI:
        <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Email:
        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Password:
        <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Address:
        <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; City:
        <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; State:
        <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp; Zip Code:
        <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
        <br />
        <br />
    </div>
    </div>
</asp:Content>
