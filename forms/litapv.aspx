<%@ Page Title="Litigation Approve" Async="true" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="litapv.aspx.cs" Inherits="WMS.forms.litapv" %>
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
                    <asp:Table ID="tb_1" runat="server" CssClass="cell_content_100PC">
                        <asp:TableRow>
                            <asp:TableCell CssClass="cell_content_20PC_TR">
                                <label class="Label_md">Document No. : </label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="cell_content_80PC_TL">
                            <asp:Label ID="doc_no" runat="server" CssClass="Label_md"></asp:Label>
                            <label class="Label_md">Submitted Date : </label>
                            <asp:Label ID="req_date" runat="server" CssClass="Label_md"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell CssClass="cell_content_20PC_TR">
                                <label class="Label_md">Subject : </label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="cell_content_80PC_TL">
                                <asp:Label ID="subject" runat="server" CssClass="Label_md"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell CssClass="cell_content_20PC_TR">
                                <label class="Label_md">Description : </label>
                            </asp:TableCell>
                            <asp:TableCell CssClass="cell_content_80PC_TL">
                                <asp:Label ID="desc" runat="server" CssClass="Label_md"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="row_gv_data" runat="server">
                            <asp:TableCell ColumnSpan="4">
                                <asp:GridView ID="gvExcelFile" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Tahoma" Font-Size="8pt" ForeColor="#333333" BorderColor="#000" CssClass="table w-100">
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
                                <br />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="6">
                                <table style="margin-left: auto; margin-right: auto;">
                                    <tr class="cell_content_100PC">
                                        <td colspan="6">
                                            <iframe id="pdf_render" runat="server" width="900" height="600" frameborder="0"></iframe>
                                        </td>
                                    </tr>
                                </table>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
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
                <asp:Button ID="btn_assign" runat="server" CssClass="btn_normal_blue" Text="Assign" Visible="false" OnClick="btn_assign_Click" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" />
                <asp:Button ID="btn_Reject" runat="server" CssClass="btn_normal_red" Text="Reject" OnClick="btn_Reject_Click" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" />
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
    <asp:HiddenField ID="hid_assto_login" runat="server" />
    <div class="modal fade" id="assignModal" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header" style="border: 0;">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title" style="font-family: tahoma;">Modal Assign</h4>
                </div>
                <div class="modal-body" style="font-size: 10pt; font-family: tahoma;">
                    <table>
                        <tr>
                            <td class="cell_content_10PC_TR">
                                <label class="Label_md">Assign To : </label>
                            </td>
                            <td class="cell_content_90PC_TL">
                                <asp:DropDownList ID="ddlAssign_NameList" runat="server" CssClass="Text_200">
                                    <asp:ListItem Value="supoj.k">supoj.k</asp:ListItem>
                                    <asp:ListItem Value="peeranat.u">peeranat.u</asp:ListItem>
                                    <asp:ListItem Value="nuttanun.su">nuttanun.su</asp:ListItem>
                                    <asp:ListItem Value="supat.ku">supat.ku</asp:ListItem>
                                    <asp:ListItem Value="wiwek.s">wiwek.s</asp:ListItem>
                                    <asp:ListItem Value="phooriwit.l">phooriwit.l</asp:ListItem>
                                    <asp:ListItem Value="nares.l">nares.l</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="modal-footer" style="text-align: left; border-top: 0;">
                    <asp:Button ID="btn_update_modal" runat="server" Text="Update" CssClass="btn_normal_blue" OnClick="Assign_Update_Click" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" />
                </div>
            </div>
        </div>
    </div>
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
        function showModalAssign() {
            $("#assignModal").modal('show');
        }
    </script>
</asp:Content>
