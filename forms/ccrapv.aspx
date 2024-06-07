<%@ Page Title="Approve" Async="true" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="ccrapv.aspx.cs" Inherits="WMS.forms.ccrapv" %>
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
                        <tr class="moresubsidiary" style="display:none;">
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">รายชื่อบริษัทที่ขอดำเนินการ : </label>
                            </td>
                            <td class="cell_content_80PC_TL">
                                <asp:GridView ID="gv1" runat="server" ShowHeader="false" AutoGenerateColumns="False" Font-Names="Tahoma" Font-Size="10pt" GridLines="None">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <%--<asp:HiddenField ID="gv1txtreq_no" Value='<%# Bind("req_no") %>' runat="server" />--%>
                                                <asp:Label ID="gv1txtNo" Text='<%# Bind("no") %>' runat="server"></asp:Label>. 
                                                <asp:Label ID="gv1txtsubsidiary_name_th" Text='<%# Bind("subsidiary_name_th") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="ชื่อบริษัท">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="gv1txtsubsidiary_code" Value='<%# Bind("subsidiary_code") %>' runat="server" />
                                                <asp:Label ID="gv1txtsubsidiary_name_th" Text='<%# Bind("subsidiary_name_th") %>' runat="server" CssClass="Text_sm"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <%--<asp:TemplateField HeaderText="ผู้รับผิดชอบ">
                                            <ItemTemplate>
                                                <asp:TextBox ID="gv1txtassto_login" Text='<%# Bind("assto_login") %>' runat="server" CssClass="Text_sm"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="สถานะ">
                                            <ItemTemplate>
                                                <asp:TextBox ID="gv1txtstatus" Text='<%# Bind("status") %>' runat="server" CssClass="Text_sm"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="วันที่ทำรายการ">
                                            <ItemTemplate>
                                                <asp:TextBox ID="gv1txtcreated_datetime" Text='<%# Bind("created_datetime") %>' TextMode="Date" runat="server" CssClass="Text_sm"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="วันที่แก้ไขล่าสุด">
                                            <ItemTemplate>
                                                <asp:TextBox ID="gv1txtupdated_datetime" Text='<%# Bind("updated_datetime") %>' TextMode="Date" runat="server" CssClass="Text_sm"></asp:TextBox>
                                            </ItemTemplate>
                                            <ItemStyle Width="100px" />
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
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
            <td colspan="2" class="cell_content_100PC">
                <asp:Panel ID="Panel3" runat="server" CssClass="div_90">
                    <uc3:ucAttachment runat="server" ID="ucAttachment1" />
                </asp:Panel>
                <br />
            </td>
        </tr>
        
        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <asp:Button ID="btn_Approve" runat="server" CssClass="btn_normal_blue" Text="Approve" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" OnClick="btn_Approve_Click" />
                <asp:Button ID="btn_Reject" runat="server" CssClass="btn_normal_red" Text="Reject" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" OnClick="btn_Reject_Click" />
                <asp:Button ID="btn_Accept" runat="server" CssClass="btn_normal_blue" Text="Accept" Visible="false" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" OnClick="btn_Accept_Click" />
                <asp:Button ID="btn_Submit" runat="server" CssClass="btn_normal_blue" Text="Submit" Visible="false" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" OnClick="btn_Submit_Click" />
                <asp:Button ID="btn_Edit" runat="server" CssClass="btn_normal_silver" Text="Edit" Visible="false" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" OnClick="btn_Edit_Click" />
            </td>
        </tr>

        <tr class="cell_content_100PC">
            <td colspan="6" class="cell_content_100PC">
                <br />
                <uc4:ucCommentlog runat="server" ID="ucCommentlog1" />
            </td>
        </tr>
        
    </table>
    <asp:HiddenField ID="req_no" runat="server" />
    <asp:HiddenField ID="hid_PID" runat="server" />
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
