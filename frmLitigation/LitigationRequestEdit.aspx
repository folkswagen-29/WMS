<%@ Page Title="Litigation Edit" Async="true" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="LitigationRequestEdit.aspx.cs" Inherits="onlineLegalWF.frmLitigation.LitigationRequestEdit" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>
<%@ Register Src="~/userControls/ucAttachment.ascx" TagPrefix="uc3" TagName="ucAttachment" %>
<%@ Register Src="~/userControls/ucCommentlog.ascx" TagPrefix="uc4" TagName="ucCommentlog" %>
<%@ Register Src="~/userControls/ucLitigationCaseAttachment.ascx" TagPrefix="uc5" TagName="ucLitigationCaseAttachment" %>

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
                    <asp:Table ID="Table1" runat="server">
                        <asp:TableRow>
                            <asp:TableCell CssClass="cell_content_20PC_TR">
                                <label class="Label_md">Request No. </label>
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;</asp:TableCell>
                            <asp:TableCell CssClass="cell_content_80PC_TL">
                                <asp:Label ID="req_no" runat="server" CssClass="Label_md" Text=""></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell CssClass="cell_content_20PC_TR">
                                <label class="Label_md">Documnet No. </label>
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;</asp:TableCell>
                            <asp:TableCell CssClass="cell_content_80PC_TL">
                                <asp:Label ID="doc_no" runat="server" CssClass="Label_md"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell CssClass="cell_content_20PC_TR">
                                <label class="Label_md">Type of Request </label>
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;</asp:TableCell>
                            <asp:TableCell CssClass="cell_content_80PC_TL">
                                <asp:DropDownList ID="type_req" runat="server" CssClass="Text_400" OnSelectedIndexChanged="type_req_Changed" AutoPostBack="true">
                                </asp:DropDownList>
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell CssClass="cell_content_20PC_TR">
                                <label class="Label_md">Subject </label>
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;</asp:TableCell>
                            <asp:TableCell CssClass="cell_content_80PC_TL">
                                <asp:TextBox ID="subject" runat="server" CssClass="Text_600"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell CssClass="cell_content_20PC_TR">
                                <label class="Label_md">Description </label>
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;</asp:TableCell>
                            <asp:TableCell CssClass="cell_content_80PC_TL">
                                <asp:TextBox ID="desc" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="100px"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="row_tp_download" runat="server">
                            <asp:TableCell CssClass="cell_content_20PC_TR">
                                <%--<label class="Label_md">Upload Excel Template </label>--%>
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;</asp:TableCell>
                            <asp:TableCell CssClass="cell_content_80PC_TL">
                                <asp:Button ID="btnDownload_template" runat="server" Text="Download Template" OnClick="btnDownload_template_Click" />
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="row_tp_upload" runat="server">
                            <asp:TableCell CssClass="cell_content_20PC_TR">
                                <label class="Label_md">Upload Excel Template </label>
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;</asp:TableCell>
                            <asp:TableCell CssClass="cell_content_80PC_TL">
                                <asp:FileUpload ID="FileUpload1" runat="server" /> &nbsp; <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" /> 
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="row_gv_data" runat="server">
                            <asp:TableCell ColumnSpan="4">
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                <br />
                                <asp:GridView ID="gvExcelFile" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#333333" GridLines="None" CssClass="table w-100" OnRowCommand="gv_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ลำดับ">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="gv_req_no" Value='<%# Bind("req_no") %>' runat="server" />
                                                <asp:HiddenField ID="gv_case_no" Value='<%# Bind("case_no") %>' runat="server" />
                                                <asp:Label ID="gv_no" Text='<%# Bind("no") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="เลขที่สัญญา">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_contract_no" Text='<%# Bind("contract_no") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="BU">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_bu_name" Text='<%# Bind("bu_name") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="รหัสลูกค้า">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_customer_no" Text='<%# Bind("customer_no") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ชื่อ">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_customer_name" Text='<%# Bind("customer_name") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ห้อง">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_customer_room" Text='<%# Bind("customer_room") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ช่วงเวลาที่ค้าง">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_overdue_desc" Text='<%# Bind("overdue_desc") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="หนี้ค้างชำระ">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_outstanding_debt" Text='<%# Bind("outstanding_debt") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="หนี้ค้างชำระตามรับสภาพหนี้">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_outstanding_debt_ack_of_debt" Text='<%# Bind("outstanding_debt_ack_of_debt") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ค่าเบี้ยปรับ">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_fine_debt" Text='<%# Bind("fine_debt") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ยอดรวมสุทธิ">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_total_net" Text='<%# Bind("total_net") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="เงินประกัน">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_retention_money" Text='<%# Bind("retention_money") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ยอดหลังหักเงินประกัน">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_total_after_retention_money" Text='<%# Bind("total_after_retention_money") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="หมายเหตุ">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_remark" Text='<%# Bind("remark") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="gv_attach" runat="server" Height="20px" ImageUrl="~/images/icon_upload.png" CommandArgument="<%# Container.DataItemIndex %>" CommandName="openModal" ToolTip="AttachMent" />
                                                <%--<asp:Button ID="gv_attach" runat="server" Font-Names="tahoma" Font-Size="8pt" CommandArgument="<%# Container.DataItemIndex %>" CommandName="openModal" Text="Attachment"></asp:Button>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
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
                <asp:Button ID="btn_save" runat="server" CssClass="btn_normal_silver" Text="Save" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" OnClick="btn_save_Click" />
                <asp:Button ID="btn_submit" runat="server" CssClass="btn_normal_silver" Text="Submit" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" />
                <asp:Button ID="btn_gendocumnt" runat="server" CssClass="btn_normal_silver" Text="Preview" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" OnClick="btn_gendocumnt_Click" />
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
    <asp:HiddenField ID="req_date" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblPID" runat="server" CssClass="Label_sm"></asp:Label>
    <div class="modal fade" id="editDataModal" role="dialog" style="">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header" style="border: 0;">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title">Modal Attachment</h4>
                </div>
                <div class="modal-body" style="font-size: 10pt; font-family: tahoma;">
                    <uc5:ucLitigationCaseAttachment runat="server" id="ucLitigationCaseAttachment1" />
                </div>
            </div>
        </div>
    </div>
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
        function showModalEditData() {
            $("#editDataModal").modal('show');
        }
        function showModalDoc() {
            $("#modaldocument").modal('show');
        }
    </script>
</asp:Content>

