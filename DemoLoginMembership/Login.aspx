<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="DemoLoginMembership.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 235px;
        }
        .auto-style2 {
            width: 96px;
        }
    </style>
</head>
<body>
    
    <form id="form1" runat="server">
        <table style="width:100%;">
            <tr>
                <td class="auto-style2">
                    <asp:Label ID="Label3" runat="server" Text="Login Form"></asp:Label>
                </td>
                <td class="auto-style1">&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style2">
                    User name:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtUsername" runat="server" Width="214px"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="This field can be blank" ControlToValidate="txtUsername"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2">
                    Password:</td>
                <td class="auto-style1">
                    <asp:TextBox ID="txtPassword" runat="server" EnableViewState="False" Width="209px" EnableTheming="True" TextMode="Password"></asp:TextBox>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="This field can be blank" ControlToValidate="txtPassword"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style2"></td>
                <td class="auto-style1">
                    <asp:Button ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Login" Width="67px" />
                </td>
                <td>
                    <asp:CheckBox ID="cbRememberme" runat="server" Text="Remember me" />
                    <asp:DropDownList ID="DropDownList1" runat="server">
                        <asp:ListItem>Membership</asp:ListItem>
                        <asp:ListItem>Apache LDAP</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
        </table>
    </form>
    
</body>
</html>
