<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuranceApprove.aspx.cs" Inherits="onlineLegalWF.frmInsurance.InsuranceApprove" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>InsuranceApprove</title>
    <link href="../StyleSheet/CustomStyle.css" rel="stylesheet" type="text/css"/>
    <metaviewport name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>
    <form id="form1" runat="server">
        <div class="div1">
            <table class="cell_content_100PC" style="font-family: Tahoma;">
                <tr class="cell_content_100PC">
                    <td colspan="2" class="cell_content_100PC">
                        <asp:Panel ID="Panel1" runat="server" CssClass="div_90">
                            <table class="cell_content_100PC">
                                <tr>
                                    <td class="cell_content_20PC_TR">
                                        <label class="Label_md">From : </label>
                                    </td>
                                    <td class="cell_content_80PC_TL">
                                        <asp:Label ID="from" runat="server" CssClass="Label_md"></asp:Label>&nbsp;
                                        <label class="Label_md">Document No. : </label>&nbsp;
                                        <asp:Label ID="doc_no" runat="server" CssClass="Label_md"></asp:Label>&nbsp;
                                        <label class="Label_md">Submitted Date : </label>&nbsp;
                                        <asp:Label ID="req_date" runat="server" CssClass="Label_md"></asp:Label>&nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="cell_content_20PC_TR">
                                        <label class="Label_md">Subject : </label>
                                    </td>
                                    <td class="cell_content_80PC_TL">
                                        <asp:Label ID="subject" runat="server" CssClass="Label_md"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="6">
                                        <table style="margin-left: auto; margin-right: auto;">
                                            <tr class="cell_content_100PC">
                                                <td colspan="6">
                                                    <iframe id="pdf_render" runat="server" width="900" height="600" frameborder="0"></iframe>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>

                        </asp:Panel>
                        <br />
                    </td>

                </tr>
                <%--<tr class="cell_content_100PC">
                    <td colspan="2" class="cell_content_100PC">
                        <asp:Panel ID="Panel2" runat="server" CssClass="div_90">
                            <table style="border-collapse: collapse; font-size: 9pt; margin-left: auto; margin-right: auto;">
                                <tr>
                                    <td colspan="4">
                                        <iframe id="pdf_render" runat="server" width="920" height="680" frameborder="0"></iframe>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>--%>
                <tr class="cell_content_100PC">
                    <td colspan="2" class="cell_content_100PC">
                        <asp:Button runat="server" CssClass="btn_normal_blue" Text="Approve" />
                        <asp:Button runat="server" CssClass="btn_normal_red" Text="Reject" />
                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="req_no" runat="server" />
    </form>
</body>
</html>
