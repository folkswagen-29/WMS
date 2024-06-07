﻿<%@ Page Title="Approve" Async="true" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="apv.aspx.cs" Inherits="WMS.forms.apv" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc2" TagName="ucHeader" %>
<%@ Register Src="~/userControls/ucAttachment.ascx" TagPrefix="uc3" TagName="ucAttachment" %>
<%@ Register Src="~/userControls/ucCommentlog.ascx" TagPrefix="uc4" TagName="ucCommentlog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="cell_content_100PC" style="font-family: Tahoma;">
        <tr>
            <td colspan="2">
                <div style="background-color: gainsboro;">
                    <uc2:ucHeader runat="server" ID="ucHeader1" />
                </div>
            </td>
        </tr>
        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <asp:Panel ID="Panel1" runat="server" CssClass="div_90">
                    <table class="cell_content_100PC">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">From : </label>
                            </td>
                            <td class="cell_content_80PC_TL">
                                <asp:Label ID="from" runat="server" CssClass="Label_md"></asp:Label>
                            <label class="Label_md">Document No. : </label>
                            <asp:Label ID="doc_no" runat="server" CssClass="Label_md"></asp:Label>
                            <label class="Label_md">Submitted Date : </label>
                            <asp:Label ID="req_date" runat="server" CssClass="Label_md"></asp:Label>
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
        <tr class="cell_content_100PC">
            <td colspan="6" class="cell_content_100PC">
                <uc4:ucCommentlog runat="server" ID="ucCommentlog1" />
            </td>
        </tr>
        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <asp:Button ID="btn_Approve" runat="server" CssClass="btn_normal_blue" Text="Approve" OnClick="btn_Approve_Click" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" />
                <asp:Button ID="btn_Reject" runat="server" CssClass="btn_normal_red" Text="Reject" OnClick="btn_Reject_Click" />
            </td>
        </tr>
        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <br />
                <asp:Panel ID="Panel3" runat="server" CssClass="div_90">
                    <uc3:ucAttachment runat="server" ID="ucAttachment1" />
                </asp:Panel>
                <br />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="req_no" runat="server" />
    <asp:HiddenField ID="hid_PID" runat="server" />
    <asp:HiddenField ID="hid_bucode" runat="server" />
    <asp:HiddenField ID="hid_external_domain" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblPID" runat="server" CssClass="Label_sm"></asp:Label>
    <div class="modal fade" id="modalreject" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header" style="border: 0;">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div><asp:Label ID="Label2" runat="server" CssClass="Label_lg" Text="Comment"></asp:Label></div>
                    <asp:TextBox ID="comment" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="90"></asp:TextBox>
                </div>
                <div class="modal-footer" style="text-align: left; border-top: 0;">
                    <asp:Button ID="btn_reject_submit" runat="server" Text="Submit" CssClass="btn_normal_blue" OnClick="btn_reject_submit_Click" />
                </div>
            </div>
        </div>
    </div>

    <script type="text/javascript">
        function showModalReject() {
            $("#modalreject").modal('show');
        }
    </script>
</asp:Content>
