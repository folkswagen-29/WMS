﻿<%@ Title="Insurance Approve" Language="C#" MasterPageFile="SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="InsuranceApprove.aspx.cs" Inherits="WMS.frmInsurance.InsuranceApprove" %>
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
                <asp:Button runat="server" CssClass="btn_normal_blue" Text="Approve" />
                <asp:Button runat="server" CssClass="btn_normal_red" Text="Reject" />
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
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblPID" runat="server" CssClass="Label_sm"></asp:Label>
</asp:Content>