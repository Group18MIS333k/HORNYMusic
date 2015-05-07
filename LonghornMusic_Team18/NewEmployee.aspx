<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="NewEmployee.aspx.vb" Inherits="LonghornMusic_Team18.NewEmployee" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="body">
     <div style="height: 89px; width: 772px; text-align: center;">
         New Employees
        <br />
         &nbsp;
        <br />
         <asp:Button ID="btnSaveEmp" runat="server" Text="Save New Employee" />
         <asp:Button ID="btnClear" runat="server" Text="Clear" />
        <br />
        </div>
    <div style="width: 471px; margin-top: 0px; height: 400px; text-align: right;">

        &nbsp;&nbsp;&nbsp; *Password:
        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; *First Name:
        <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*Last Name: <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MI: <asp:TextBox ID="txtInitial" runat="server" MaxLength="1"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; *Address:
        <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; City:
        <asp:TextBox ID="txtCity" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; State:
        <asp:TextBox ID="txtState" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp; *Zip Code:
        <asp:TextBox ID="txtZip" runat="server" AutoPostBack="True" MaxLength="5"></asp:TextBox>
        <br />
        *Phone:
        <asp:TextBox ID="txtPhone" runat="server" MaxLength="10"></asp:TextBox>
        <br />
        *SSN: <asp:TextBox ID="txtSSN" runat="server" MaxLength="9"></asp:TextBox>
        <br />
        <asp:CheckBox ID="ckbxManager" runat="server" Font-Size="Medium" Text="Manager?                                                        " TextAlign="Left" />
        <br />
        <asp:Button ID="btnBack" runat="server" Text="Back to Manage Employees" />
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </div>
    </div>
</asp:Content>
