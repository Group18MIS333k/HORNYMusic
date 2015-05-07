<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="ManageEmployees.aspx.vb" Inherits="LonghornMusic_Team18.ManageEmployees" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="body">
     <div style="height: 89px; width: 772px; text-align: center;">
         Manage Employees
        <br />
         <asp:LinkButton ID="lnkEmpSplash" runat="server">Back to Employee Splash</asp:LinkButton>
        <br />
        Select Employee:
        <asp:DropDownList ID="ddlEmployee" runat="server" Height="16px" Width="185px" AutoPostBack="True">
        </asp:DropDownList>
         &nbsp;
        <br />
         <asp:Button ID="btnNewEmployee" runat="server" Text="New Employee" />
        <br />
        </div>
    <div style="width: 471px; margin-top: 0px; height: 400px; text-align: right;">

        &nbsp;&nbsp;&nbsp; EmpID:
        <asp:TextBox ID="txtEmpID" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" Height="17px" Width="134px" Enabled="False" Visible="False" />
        &nbsp;&nbsp;&nbsp; Password:
        <asp:TextBox ID="txtPassword" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; *First Name:
        <asp:TextBox ID="txtFirstName" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;*Last Name :<asp:TextBox ID="txtLastName" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; MI :<asp:TextBox ID="txtInitial" runat="server" ReadOnly="True" MaxLength="1"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; *Address:
        <asp:TextBox ID="txtAddress" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; City:
        <asp:TextBox ID="txtCity" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; State:
        <asp:TextBox ID="txtState" runat="server" ReadOnly="True"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp; *Zip Code:
        <asp:TextBox ID="txtZip" runat="server" AutoPostBack="True" ReadOnly="True" MaxLength="5"></asp:TextBox>
        <br />
        *Phone:
        <asp:TextBox ID="txtPhone" runat="server" ReadOnly="True" MaxLength="10"></asp:TextBox>
        <br />
        *SSN: <asp:TextBox ID="txtSSN" runat="server" Enabled="False" ReadOnly="True" MaxLength="9"></asp:TextBox>
        <br />
        Employee Type:
        <asp:TextBox ID="txtEmpType" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
        <br />
        Active:<asp:TextBox ID="txtActive" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
        <br />
        <asp:Button ID="btnFire" runat="server" Text="Fire" />
        <asp:Button ID="btnModify" runat="server" Text="Modify" />
        <asp:Button ID="btnSave" runat="server" Enabled="False" Text="Save" Visible="False" />
        <asp:Button ID="btnAbortModify" runat="server" Text="Abort Modify" Enabled="False" Visible="False" />
        <asp:Label ID="lblError" runat="server"></asp:Label>
        <asp:Button ID="btnConfirmFire" runat="server" Enabled="False" Text="Confirm Fire" Visible="False" />
        <asp:Button ID="btnAbortFire" runat="server" Enabled="False" Text="Abort Fire" Visible="False" />
        <asp:Button ID="btnRehire" runat="server" Text="Rehire" Enabled="False" Visible="False" />
        <asp:Button ID="btnDemote" runat="server" Enabled="False" Text="Demote" Visible="False" />
        <asp:Button ID="btnPromote" runat="server" Text="Promote" />
    </div>
    </div>
</asp:Content>
