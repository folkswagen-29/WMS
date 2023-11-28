<%@ Page Title="Litigation Edit" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="LitigationRequestEdit.aspx.cs" Inherits="onlineLegalWF.frmLitigation.LitigationRequestEdit" %>
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
                                <label class="Label_md">Request No. </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:Label ID="req_no" runat="server" Text=""></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Documnet No. </label>
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
                        <%--<tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Upload Excel Template </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:FileUpload ID="FileUpload1" runat="server" /> &nbsp; <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" /> 
                            </td>
                            <td>&nbsp;</td>
                        </tr>--%>
                        <tr>
                            <td colspan="4">
                                <table class="table w-100" cellspacing="0" cellpadding="4" id="tb_detail" style="color: #333333; border-collapse: collapse;">
                                    <tbody>
                                        <tr style="color: White; background-color: #5D7B9D; font-weight: bold;">
                                            <th scope="col">ลำดับ</th>
                                            <th scope="col">เลขที่สัญญา</th>
                                            <th scope="col">รหัสลูกค้า</th>
                                            <th scope="col">ชื่อ</th>
                                            <th scope="col">ห้อง</th>
                                            <th scope="col">ช่วงเวลาที่ค้าง</th>
                                            <th scope="col">หนี้ค้างชำระ</th>
                                            <th scope="col">หนี้ค้างชำระตามรับสภาพหนี้</th>
                                            <th scope="col">ค่าเบี้ยปรับ</th>
                                            <th scope="col">ยอดรวมสุทธิ</th>
                                            <th scope="col">ยอดหลัง</th>
                                            <th scope="col">หมายเหตุ</th>
                                        </tr>
                                        <tr style="color: #333333; background-color: #F7F6F3;">
                                            <td>1</td>
                                            <td>0001</td>
                                            <td>awc0001</td>
                                            <td>ทดสอบ1</td>
                                            <td>xxx</td>
                                            <td>xxxxxxxxx</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>xxxxxxx</td>
                                        </tr>
                                        <tr style="color: #284775; background-color: White;">
                                            <td>2</td>
                                            <td>0002</td>
                                            <td>awc0002</td>
                                            <td>ทดสอบ2</td>
                                            <td>xxx</td>
                                            <td>xxxxxxxxx</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>xxxxxxx</td>
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
                <label>Task Management : Assign to..</label>
                <br />
            </td>
        </tr>
        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <asp:Panel ID="Panel2" runat="server" CssClass="div_90">
                    <table>
                        <tr>
                            <td colspan="4">
                                <table class="table w-100" cellspacing="0" cellpadding="4" id="tb_detail_assign" style="color: #333333; border-collapse: collapse;">
                                    <tbody>
                                        <tr style="color: White; background-color: #5D7B9D; font-weight: bold;">
                                            <th scope="col">ลำดับ</th>
                                            <th scope="col">เลขที่สัญญา</th>
                                            <th scope="col">รหัสลูกค้า</th>
                                            <th scope="col">ชื่อ</th>
                                            <th scope="col">ห้อง</th>
                                            <th scope="col">ช่วงเวลาที่ค้าง</th>
                                            <th scope="col">หนี้ค้างชำระ</th>
                                            <th scope="col">หนี้ค้างชำระตามรับสภาพหนี้</th>
                                            <th scope="col">ค่าเบี้ยปรับ</th>
                                            <th scope="col" class="auto-style17">ยอดรวมสุทธิ</th>
                                            <th scope="col">ยอดหลัง</th>
                                            <th scope="col">หมายเหตุ</th>
                                            <th scope="col">สถานะ</th>
                                            <th scope="col">กำหนดผู้รับผิดชอบ</th>
                                        </tr>
                                        <tr style="color: #333333; background-color: #F7F6F3;">
                                            <td>1</td>
                                            <td>0001</td>
                                            <td>awc0001</td>
                                            <td>ทดสอบ1</td>
                                            <td>xxx</td>
                                            <td>xxxxxxxxx</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td class="auto-style17">n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>xxxxxxx</td>
                                            <td>new</td>
                                            <td><asp:TextBox ID="txt1" runat="server"></asp:TextBox></td>
                                        </tr>
                                        <tr style="color: #284775; background-color: White;">
                                            <td>2</td>
                                            <td>0002</td>
                                            <td>awc0002</td>
                                            <td>ทดสอบ2</td>
                                            <td>xxx</td>
                                            <td>xxxxxxxxx</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td class="auto-style17">n,nnn,nn.nn</td>
                                            <td>n,nnn,nn.nn</td>
                                            <td>xxxxxxx</td>
                                            <td>new</td>
                                            <td><asp:TextBox ID="txt2" runat="server"></asp:TextBox></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>

        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content2" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style17 {
            width: 77px;
        }
    </style>
</asp:Content>

