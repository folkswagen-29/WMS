﻿<%@ Page Title="Complete" Async="true" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="ccrcomplete.aspx.cs" Inherits="WMS.forms.ccrcomplete" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc2" TagName="ucHeader" %>
<%@ Register Src="~/userControls/ucAttachmentdata.ascx" TagPrefix="uc3" TagName="ucAttachmentdata" %>
<%@ Register Src="~/userControls/ucCommentlogdata.ascx" TagPrefix="uc4" TagName="ucCommentlogdata" %>

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
                                <label class="Label_md">เรื่อง : </label>
                            </td>
                            <td class="cell_content_80PC_TL">
                                <asp:Label ID="subject" runat="server" CssClass="Label_md"></asp:Label>
                                <label class="Label_md">เลขที่เอกสาร : </label>
                                <asp:Label ID="doc_no" runat="server" CssClass="Label_md"></asp:Label>
                                <label class="Label_md">วันที่ : </label>
                                <asp:Label ID="req_date" runat="server" CssClass="Label_md"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ชื่อบริษัท(ไทย) : </label>
                            </td>
                            <td class="cell_content_80PC_TL">
                                <asp:Label ID="companyname_th" runat="server" CssClass="Label_md"></asp:Label>
                                <label class="Label_md">ชื่อบริษัท(อังกฤษ) : </label>
                                <asp:Label ID="companyname_en" runat="server" CssClass="Label_md"></asp:Label>
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
                <uc4:ucCommentlogdata runat="server" ID="ucCommentlog1" />
            </td>
        </tr>
        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <br />
                <asp:Panel ID="Panel3" runat="server" CssClass="div_90">
                    <uc3:ucAttachmentdata runat="server" ID="ucAttachment1" />
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
