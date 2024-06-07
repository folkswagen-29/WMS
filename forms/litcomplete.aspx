<%@ Page Title="Litigation Complete" Async="true" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="litcomplete.aspx.cs" Inherits="WMS.forms.litcomplete" %>
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
    <asp:HiddenField ID="hid_bucode" runat="server" />
    <asp:HiddenField ID="hid_external_domain" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblPID" runat="server" CssClass="Label_sm"></asp:Label>
</asp:Content>
