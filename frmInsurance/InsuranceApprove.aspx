<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuranceApprove.aspx.cs" Inherits="onlineLegalWF.frmInsurance.InsuranceApprove" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>InsuranceApprove</title>
    <link href="../StyleSheet/CustomStyle.css" rel="stylesheet" type="text/css"/>
    <style type="text/css">
        .auto-style1 {
            width: 150px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family:Tahoma; font-size:10pt; margin-top: 20px;">
            <table cellpadding="0" cellspacing="0">
                <tr>
                    <td class="auto-style1">
                        <label>From &nbsp;</label>
                    </td>
                    <td>
                        <asp:label ID="from" runat="server"></asp:label>
                    </td>
                    <td class="auto-style1">
                        <label>Document No. &nbsp;</label>
                    </td>
                    <td class="auto-style1">
                        <asp:label ID="doc_no" runat="server"></asp:label>
                    </td><td>
                        <label>Submitted Date &nbsp;</label>
                    </td>
                    <td>
                        <asp:label ID="req_date" runat="server"></asp:label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <label>Subject &nbsp;</label>
                    </td>
                    <td colspan="5">
                        <asp:Label ID="subject" runat="server" Text="Label"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="6">
                        <table border="0">
                            <tr>
                                <td></td>
                                <td colspan="4">
                                    <iframe id="pdf_render" runat="server" width="640" height="480" frameborder="0"></iframe>
                                </td>
                                <td></td>
                            </tr>
                        </table>
                        
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>&nbsp;</label>
                    </td>
                    <td colspan="2">
                        <table border="0">
                            <tr>
                                <td>
                                    <asp:Button runat="server" CssClass="btn_normal_blue pointer" Text="Approve" />
                                </td>
                                <td>
                                    <asp:Button runat="server" CssClass="btn_normal_red pointer" Text="Reject" />
                                </td>
                            </tr>
                        </table>
                    </td>
                     <td>
                         <label>&nbsp;</label>
                     </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="req_no" runat="server" />
    </form>
</body>
</html>
