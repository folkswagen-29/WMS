<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAttachment.ascx.cs" Inherits="onlineLegalWF.userControls.ucAttachment" %>
 <link href="../StyleSheet/CustomStyle.css" rel="stylesheet" type="text/css"/>
<style type="text/css">
    .auto-style1 {
        width: 100px;
    }
</style>
<div>
    <asp:Panel ID="Panel1" runat="server" CssClass="div_90">
        <table cellpadding="0" cellspacing="0" class="w-100">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="0" >
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" CssClass="Label_lg_blue" Text="Attachments"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" CssClass="Label_md" Text="Please select and input file"></asp:Label>
                            </td>
                            <td>&nbsp;
                                <asp:FileUpload ID="FileUpload1" runat="server" />
                            </td>
                            <td>
                                <asp:Button ID="btnUpload" runat="server" CssClass="btn-group" OnClick="btnUpload_Click" Text="Upload" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</div>

<asp:HiddenField ID="hidPID" runat="server" />
