<%@ Page Title="Action Plan & Update" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="LitigationActionPlan.aspx.cs" Inherits="onlineLegalWF.frmLitigation.LitigationActionPlan" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>

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
                                <label class="Label_md">Document No. </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="doc_no" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Subject </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="subject" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="100px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Customer Code </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="customer_code" runat="server" CssClass="Text_400"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">Name </label>
                                        </td>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="customer_name" runat="server" CssClass="Text_400"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Address </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="address" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="100px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Email </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="email" runat="server" CssClass="Text_400"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">Mobile </label>
                                        </td>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="mobile" runat="server" CssClass="Text_400"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <label>ประวัติ</label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <table class="table w-100" cellspacing="0" cellpadding="4" id="tb_detail" style="color: #333333; border-collapse: collapse;">
                                    <tbody>
                                        <tr style="color: White; background-color: #5D7B9D; font-weight: bold;">
                                            <th scope="col">เลที่ใบแจ้งหนี้</th>
                                            <th scope="col">ชื่อ</th>
                                            <th scope="col">ห้อง</th>
                                            <th scope="col">ช่วงเวลาที่ค้าง</th>
                                            <th scope="col">หนี้ค้างชำระ</th>
                                            <th scope="col">ค่าเบี้ยปรับ</th>
                                            <th scope="col">ยอดรวมสุทธิ</th>
                                        </tr>
                                        <tr style="color: #333333; background-color: #F7F6F3;">
                                            <td>awc0001</td>
                                            <td>ทดสอบ1</td>
                                            <td>xxx</td>
                                            <td>xxxxxxxxx</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                        </tr>
                                        <tr style="color: #284775; background-color: White;">
                                            <td>awc0002</td>
                                            <td>ทดสอบ2</td>
                                            <td>xxx</td>
                                            <td>xxxxxxxxx</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                        </tr>
                                    </tbody>
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
                <asp:Button ID="btn_create" runat="server" CssClass="btn_normal_silver" Text="Create" />
            </td>
        </tr>
    </table>
</asp:Content>
