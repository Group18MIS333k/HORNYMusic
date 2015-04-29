<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="ManageCustomer.aspx.vb" Inherits="LonghornMusic_Team18.ManageCustomer" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="body">
     <div style="height: 134px; width: 772px; text-align: center;">
        Manage Customers
        <br />
        <br />
        Select Customer:
        <asp:DropDownList ID="ddlCustomer" runat="server" Height="16px" Width="185px" AutoPostBack="True">
        </asp:DropDownList>
        <br />
        Account Enabled:&nbsp;
        <asp:RadioButtonList ID="rbAccountEnabled" runat="server" Height="16px" Width="780px">
            <asp:ListItem Selected="True">Yes</asp:ListItem>
            <asp:ListItem>No</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <br />
        </div>
    <div style="width: 471px; margin-top: 0px; height: 400px; text-align: right;">

&nbsp;&nbsp;&nbsp; First Name:
        <asp:TextBox ID="txtFirstName" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp; Last Name:
        <asp:TextBox ID="txtLastName" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MI:
        <asp:TextBox ID="txtInitial" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Email:
        <asp:TextBox ID="txtEmail" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Password:
        <asp:TextBox ID="txtPassword" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Address:
        <asp:TextBox ID="txtAddress" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; City:
        <asp:TextBox ID="txtCity" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; State:
        <asp:TextBox ID="txtState" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp; Zip Code:
        <asp:TextBox ID="txtZip" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        Phone:
        <asp:TextBox ID="txtPhone" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" />
        <asp:Button ID="btnModify" runat="server" Text="Modify" />
        <asp:Button ID="btnSave" runat="server" Enabled="False" Text="Save" Visible="False" />
        <asp:Button ID="btnAbortModify" runat="server" Text="Abort Modify" />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <asp:Button ID="btnConfirmDelete" runat="server" Enabled="False" Text="Confirm Delete" Visible="False" />
        <asp:Button ID="btnAbortDelete" runat="server" Enabled="False" Text="Abort Delete" Visible="False" />
    </div>
    </div>
</asp:Content>
