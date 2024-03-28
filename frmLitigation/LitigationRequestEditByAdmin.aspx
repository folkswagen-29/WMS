<%@ Page Title="Litigation Admin Edit" Async="true" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="LitigationRequestEditByAdmin.aspx.cs" Inherits="onlineLegalWF.frmLitigation.LitigationRequestEditByAdmin" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>
<%@ Register Src="~/userControls/ucAttachment.ascx" TagPrefix="uc3" TagName="ucAttachment" %>
<%@ Register Src="~/userControls/ucCommentlog.ascx" TagPrefix="uc4" TagName="ucCommentlog" %>
<%@ Register Src="~/userControls/ucLitigationCaseAttachment.ascx" TagPrefix="uc5" TagName="ucLitigationCaseAttachment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="tb_main" runat="server" CssClass="cell_content_100PC">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <div style="background-color: gainsboro;">
                    <uc1:ucHeader runat="server" ID="ucHeader1" />
                </div>

            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow CssClass="cell_content_100PC">
            <asp:TableCell ColumnSpan="2" CssClass="cell_content_100PC">
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
                                <asp:DropDownList ID="type_req" runat="server" Enabled="false" CssClass="Text_400">
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
                                <asp:TextBox ID="subject" runat="server" Enabled="false" CssClass="Text_600"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell CssClass="cell_content_20PC_TR">
                                <label class="Label_md">Description </label>
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;</asp:TableCell>
                            <asp:TableCell CssClass="cell_content_80PC_TL">
                                <asp:TextBox ID="desc" runat="server" Enabled="false" CssClass="Text_600" TextMode="MultiLine" Height="100px"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>&nbsp;</asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow ID="row_gv_data" runat="server">
                            <asp:TableCell ColumnSpan="4">
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                <br />
                                <asp:GridView ID="gvExcelFile" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Tahoma" Font-Size="8pt" ForeColor="#333333" GridLines="None" CssClass="table w-100" OnRowCommand="gv_RowCommand">
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
                                        <asp:TemplateField HeaderText="สถานะ">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_status" Text='<%# Bind("status") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ผู้รับผิดชอบ">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_assto_login" Text='<%# Bind("assto_login") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <table>
                                                    <tr>
                                                        <asp:HiddenField ID="hid_url_detail" runat="server" Value='<%# Bind("url_detail") %>' />
                                                        <%--<td><asp:ImageButton ID="gv_attach" runat="server" Height="20px" ImageUrl="~/images/icon_upload.png" CommandArgument="<%# Container.DataItemIndex %>" CommandName="openModal" ToolTip="AttachMent" /></td>--%>
                                                        <td><asp:ImageButton ID="gv_btnEdit" runat="server" Height="20px" ImageUrl="~/images/icon_edit.png" CommandArgument="<%# Container.DataItemIndex %>" CommandName="openModalAssign" ToolTip="Update" /></td>
                                                        <td><asp:ImageButton ID="gv_btnDetail" runat="server" Height="20px" ImageUrl="~/images/icon_view.png" ToolTip="View Detail" CommandArgument="<%# Container.DataItemIndex %>" CommandName="openNewTab" /></td>
                                                    </tr>
                                                </table>
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
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow CssClass="cell_content_100PC">
            <asp:TableCell ColumnSpan="2" CssClass="cell_content_100PC">
                <asp:Panel ID="Panel3" runat="server" CssClass="div_90">
                    <uc3:ucAttachment runat="server" ID="ucAttachment1" />
                </asp:Panel>
                <br />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow CssClass="cell_content_100PC">
            <asp:TableCell ColumnSpan="2" CssClass="cell_content_100PC">
                <uc4:ucCommentlog runat="server" ID="ucCommentlog1" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow CssClass="cell_content_100PC">
            <asp:TableCell ColumnSpan="2" CssClass="cell_content_100PC">
                <asp:Button ID="btn_Submit" runat="server" CssClass="btn_normal_blue" Text="Submit" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" OnClick="btn_Submit_Click" />
                <asp:Button ID="btn_Reject" runat="server" CssClass="btn_normal_red" Text="Reject" OnClick="btn_Reject_Click" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:HiddenField ID="hid_PID" runat="server" />
    <asp:HiddenField ID="req_date" runat="server" />
    <div class="modal fade" id="assignModal" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header" style="border: 0;">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title" style="font-family: tahoma;">Modal Assign</h4>
                </div>
                <div class="modal-body" style="font-size: 10pt; font-family: tahoma;">
                    <asp:HiddenField ID="hid_case_no" runat="server" />
                    <table>
                        <tr>
                            <td class="cell_content_10PC_TR">
                                <label class="Label_md">Status : </label>
                            </td>
                            <td class="cell_content_90PC_TL">
                                <asp:RadioButtonList ID="rdlAction" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="verify" Selected="True">verify</asp:ListItem>
                                    <asp:ListItem Value="In Progress">In Progress</asp:ListItem>
                                    <asp:ListItem Value="Close Request & Proceeding">Close Request & Proceeding</asp:ListItem>
                                    <asp:ListItem Value="Close Request & Close Litigation">Close Request & Close Litigation</asp:ListItem>
                                    <asp:ListItem Value="Close Request & No Proceeding ">Close Request & No Proceeding</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                        </tr>
                        <tr>
                            <td class="cell_content_10PC_TR">
                                <label class="Label_md">Assign To : </label>
                            </td>
                            <td class="cell_content_90PC_TL">
                                <asp:DropDownList ID="ddlNameList" runat="server" CssClass="Text_200">
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
                    <asp:Button ID="btn_update_all_modal" runat="server" Text="Update" CssClass="btn_normal_blue" Visible="false" />
                </div>
            </div>
        </div>
    </div>
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
    <div class="modal fade" id="modalreject" role="dialog">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header" style="border: 0;">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                </div>
                <div class="modal-body">
                    <div>
                        <asp:Label ID="Label2" runat="server" CssClass="Label_lg" Text="Comment"></asp:Label></div>
                    <asp:TextBox ID="comment" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="90"></asp:TextBox>
                </div>
                <div class="modal-footer" style="text-align: left; border-top: 0;">
                    <asp:Button ID="btn_reject_submit" runat="server" Text="Submit" CssClass="btn_normal_blue" OnClick="btn_reject_submit_Click" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function showModalEditData() {
            $("#editDataModal").modal('show');
        }
        function showModalAssign() {
            $("#assignModal").modal('show');
        }
        function showModalReject() {
            $("#modalreject").modal('show');
        }
    </script>
</asp:Content>
