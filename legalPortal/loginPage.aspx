<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginPage.aspx.cs" Inherits="onlineLegalWF.legalPortal.loginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Online Legal Request</title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 320px;
        }
        .auto-style3 {
            height: 34px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            &nbsp;<p> &nbsp;</p>

            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>
                        <asp:Panel ID="Panel1" runat="server" Height="600px" Width="600px">
                            <table cellpadding="0" cellspacing="0" class="auto-style1">
                                <tr>
                                    <td colspan="4">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="Label1" runat="server" Font-Names="tahoma" Font-Size="12pt" ForeColor="#990000" Text="Online Legal Request"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <asp:Label ID="Label2" runat="server" Font-Names="tahoma" Font-Size="10pt" ForeColor="#666666" Text="Now we can service you the Commercial Registration, Insurance Request, Permit Request, Litigation Services"></asp:Label>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Label ID="Label3" runat="server" Font-Names="tahoma" Font-Size="10pt" Text="User Login"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtLoginName" runat="server" Width="200px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>
                                        <asp:Label ID="Label4" runat="server" Font-Names="tahoma" Font-Size="10pt" Text="Password"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Width="200px"></asp:TextBox>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td class="auto-style3"></td>
                                    <td class="auto-style3"></td>
                                    <td class="auto-style3">
                                        <asp:Button ID="btnLogin" runat="server" Height="30px" Text="Login" Width="120px" OnClick="btnLogin_Click" />
                                    </td>
                                    <td class="auto-style3"></td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;<asp:LinkButton ID="lbtnRegistration" runat="server" Font-Names="Tahoma" Font-Size="10pt" ForeColor="#336699">Register</asp:LinkButton>
                                    </td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
