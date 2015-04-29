<%@ Page Language="vb" AutoEventWireup="false" MasterPageFile="~/Site1.Master" CodeBehind="MyMusic.aspx.vb" Inherits="LonghornMusic_Team18.MyMusic" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        .auto-style1 {
            width: 100px;
            height: 23px;
        }
        .auto-style2 {
            width: 195px;
            height: 23px;
        }
        .auto-style3 {
            width: 303px;
            height: 23px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; My Music bitccccccjh<br />
            <table>
                <tr>
                    <td class="auto-style1">
                        (ddlDept)</td>
                    <td class="auto-style1">
                    </td>
                    <td class="auto-style2">
                        (radSort)</td>
                    <td class="auto-style3">
                        &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                        &nbsp; &nbsp;&nbsp; (txtTitle)</td>
                </tr>
                <tr>
                    <td style="width: 100px">
                        &nbsp;</td>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 195px">
                        <asp:RadioButtonList ID="radSort" runat="server" AutoPostBack="True">
                            <asp:ListItem Value="Title">Sort by Title</asp:ListItem>
                            <asp:ListItem Value="Artist">Sort By Artist</asp:ListItem>
                            <asp:ListItem Value="Genre">Sort by Genre</asp:ListItem>
                        </asp:RadioButtonList></td>
                    <td style="width: 303px">
                        &nbsp;<asp:Label ID="label334" runat="server" Text="Search "></asp:Label>
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                        <asp:Button ID="btnKeywordSearch" runat="server" Text="Keyword Title Search" />
                        <br />
                        <asp:Button ID="btnPartialSearch" runat="server" Text="Keyword Artist Search" Width="185px" />
                        <br />
                        <asp:Button ID="Button1" runat="server" Text="Keyword Album Search" Width="184px" />
                        <br />
                        <asp:Button ID="Button2" runat="server" Text="Keyword Genre Search" Width="181px" />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 100px">
                        Records in Grid:</td>
                    <td style="width: 100px">
                        <asp:Label ID="lblRecords" runat="server"></asp:Label></td>
                    <td style="width: 195px">
                        <asp:Button ID="btnShowAll" runat="server" Text="ShowAll" /></td>
                    <td style="width: 303px">
                        Number Good Searches:
                        <asp:Label ID="lblSearches" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 100px">
                    </td>
                    <td style="width: 195px">
                    </td>
                    <td style="width: 303px">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label></td>
                </tr>
            </table>
        </div>
        <asp:GridView ID="gvMusicLibrary" runat="server">
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>