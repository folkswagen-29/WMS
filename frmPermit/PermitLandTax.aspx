﻿<%@ Page Title="Tax Request" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="PermitLandTax.aspx.cs" Inherits="WMS.frmPermit.PermitLandTax" %>
<%@ Register Src="~/userControls/ucPersonSign.ascx" TagPrefix="uc2" TagName="ucPersonSign" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>
<%@ Register Src="~/userControls/ucAttachment.ascx" TagPrefix="uc3" TagName="ucAttachment" %>
<%@ Register Src="~/userControls/ucCommentlog.ascx" TagPrefix="uc4" TagName="ucCommentlog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="cell_content_100PC">
        <tr>
            <td colspan="2">
                <div style="background-color: gainsboro;">
                    <uc1:ucHeader runat="server" ID="ucHeader1" />
                </div>

            </td>
        </tr>
        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <asp:Panel ID="Panel1" runat="server" CssClass="div_90">
                    <table>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md" style="color: red;">Remark *** </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <label class="Label_md" style="color: red;">มาตรา ๑๒  ให้เจ้าของป้ายซึ่งจะต้องเสียภาษีป้าย ยื่นแบบแสดงรายการภาษีป้ายตามแบบและวิธีการที่กระทรวงมหาดไทยกำหนด ภายในเดือนมีนาคมของทุกปี</label>
                                <br />
                                <label class="Label_md" style="color: red;">Section 12: The owner of the sign who must pay sign tax have Submit a sign tax form  By March each year</label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Request No. </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:Label ID="req_no" CssClass="Label_md" runat="server" Text=""></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Documnet No. </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:Label ID="doc_no" runat="server" CssClass="Label_md"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Requester </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:DropDownList ID="type_requester" runat="server" CssClass="Text_400" OnSelectedIndexChanged="ddl_type_requester_Changed" AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Other Request </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="tof_requester_other_desc" runat="server" Enabled="false" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">BU </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:DropDownList ID="type_lt_project" runat="server" CssClass="Text_400" OnSelectedIndexChanged="type_lt_project_Changed" AutoPostBack="true">

                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Company </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="company" runat="server" CssClass="Text_600" Text="T.C.C. COMMERCIAL PROPERTY MANAGEMENT CO., LTD." Enabled="false"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Responsible Phone </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="responsible_phone" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Type of Request Tax</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:DropDownList ID="type_req_tax" runat="server" CssClass="Text_400" OnSelectedIndexChanged="type_req_tax_Changed" AutoPostBack="true">
                                    <asp:ListItem Value="05">Signage Tax / ชำระภาษีป้ายประจำปี</asp:ListItem>
                                    <asp:ListItem Value="06">Land and Building Tax / ภาษีที่ดินและสิ่งปลูกสร้าง</asp:ListItem>
                                    <asp:ListItem Value="07">Other Tax / อื่น ๆ</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Other Type of Request tax </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="tof_permitreq_other_desc" runat="server" Enabled="false" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Subject </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="permit_subject" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Description </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="permit_desc" runat="server" TextMode="MultiLine" CssClass="Text_600"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Contact Agency </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="contact_agency" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Attorney Name </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="attorney_name" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Email Accounting </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="email_accounting" runat="server" placeholder="xxxx@mail.com" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr id="section_comcode" runat="server" Visible="false">
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Com Code </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="com_code" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr id="section_gl" runat="server" Visible="false">
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">GL </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="gl" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
            </td>
        </tr>

        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                
                <asp:Panel ID="Panel3" runat="server" CssClass="div_90">
                    <uc3:ucAttachment runat="server" ID="ucAttachment1" />
                </asp:Panel>
                <br />
            </td>

        </tr>

        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <asp:Button ID="btn_save" runat="server" CssClass="btn_normal_silver" Text="Save" OnClick="btn_save_Click" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" />
                <asp:Button ID="btn_gendocumnt" runat="server" CssClass="btn_normal_silver" Text="Preview" OnClick="btn_gendocumnt_Click" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" />
                <asp:Button ID="btn_cancel" runat="server" CssClass="btn_normal_silver" Text="Cancel" OnClientClick="JavaScript:window.history.back(1); return false;" />
            </td>
        </tr>

        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <br />
                <uc4:ucCommentlog runat="server" ID="ucCommentlog1" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hid_PID" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblPID" runat="server" CssClass="Label_sm"></asp:Label>
    <div class="modal fade" id="modaldocument" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header" style="border: 0;">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <iframe id="pdf_render" runat="server" width="865" height="600" frameborder="0"></iframe>
                </div>
            </div>
        </div>
    </div>
<script type="text/javascript">
    function showModalDoc() {
        $("#modaldocument").modal('show');
    }
</script>
</asp:Content>
