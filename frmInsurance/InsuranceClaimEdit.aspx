﻿<%@ Page Title="Edit ClaimRequest" Language="C#" MasterPageFile="SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="InsuranceClaimEdit.aspx.cs" Inherits="onlineLegalWF.frmInsurance.InsuranceClaimEdit" %>
<%@ Register Src="~/userControls/ucPersonSign.ascx" TagPrefix="uc1" TagName="ucPersonSign" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc2" TagName="ucHeader" %>

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
                    <table>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Document No.</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="doc_no" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Company</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="company_name" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">BU</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:DropDownList ID="ddl_bu" runat="server" CssClass="text_200">
                                    <asp:ListItem>-Please select-</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Incident</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="incident" runat="server" TextMode="MultiLine" CssClass="Text_800" Height="150"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Date Occurred </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="occurred_date" TextMode="Date" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">Date Submission </label>
                                        </td>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="submission_date" TextMode="Date" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Incident Summary</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="incident_summary" runat="server" TextMode="MultiLine" CssClass="Text_800" Height="150"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Claim Result</label>
                            </td>
                            <td class="cell_content_80PC_TL" colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Surveyor </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="surveyor_name" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">Company</label>
                                        </td>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="surveyor_company" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Date of Settlement </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="settlement_date" TextMode="Date" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">Day of Settlement </label>
                                        </td>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="settlement_day" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <%--<td class="cell_content_20PC_TR">
                    <label class="Label_md">List Estimated losses to claim </label>
                </td>
                <td>&nbsp;</td>--%>
                            <td colspan="4">
                                <table style="border-collapse: collapse; font-size: 9pt; margin-left: auto; margin-right: auto;">
                                    <tr class="cell_content_100PC" style="color: White; background-color: #5D7B9D; font-weight: bold;">
                                        <td>
                                            <label>Estimated losses to claim</label><br />
                                            <label>มูลค่าความเสียหาย</label>
                                        </td>
                                        <td style="text-align: center;">
                                            <label>IAR</label><br />
                                            <label>ทรัพย์สินเสียหาย</label>
                                        </td>
                                        <td style="text-align: center;">
                                            <label>BI</label><br />
                                            <label>ธุรกิจหยุดชะงัก</label>
                                        </td>
                                        <td style="text-align: center;">
                                            <label>PL/CGL</label><br />
                                            <label>รับผิดบุคคลภายนอก</label>
                                        </td>
                                        <td style="text-align: center;">
                                            <label>PV</label><br />
                                            <label>สาเหตุทางการเมือง</label>
                                        </td>
                                        <td style="text-align: center;">
                                            <label>Total</label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Amount to claim มูลค่าเรียกร้อง (a)</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="iar_atc" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="bi_atc" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="pl_cgl_atc" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="pv_atc" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="ttl_atc" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Deductible ค่ารับผิดส่วนแรก (b)</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="iar_ded" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="bi_ded" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="pl_cgl_ded" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="pv_ded" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="ttl_ded" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Proceeds from claim มูลค่าสินไหม (C)</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="iar_pfc" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="bi_pfc" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="pl_cgl_pfc" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="pv_pfc" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="ttl_pfc" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <label>Under amount to claim ส่วนต่างมูลค่าการเคลม (a-b-c)</label>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="iar_uatc" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="bi_uatc" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="pl_cgl_uatc" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="pv_uatc" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:TextBox ID="ttl_uatc" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <%--<td>&nbsp;</td>--%>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Remark</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="remark" runat="server" TextMode="MultiLine" CssClass="Text_800" Height="150"></asp:TextBox>
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
                <label>For Property</label>
                <br />
            </td>
        </tr>
        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <asp:Panel ID="Panel2" runat="server" CssClass="div_90" Height="200px">
                    <table class="cell_content_100PC" style="font-family: Tahoma;">
                        <tr>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Submitted By"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Supported By"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label3" runat="server" Text="Supported By"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:ucPersonSign runat="server" ID="ucPersonSignProp1" />
                            </td>
                            <td>
                                <uc1:ucPersonSign runat="server" ID="ucPersonSignProp2" />
                            </td>
                            <td>
                                <uc1:ucPersonSign runat="server" ID="ucPersonSignProp3" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>

        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <label>For AWC</label>
                <br />
            </td>
        </tr>
        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <asp:Panel ID="Panel3" runat="server" CssClass="div_90" Height="200px">
                    <table class="cell_content_100PC">
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Submitted By"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Supported By"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Supported By"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:ucPersonSign runat="server" ID="ucPersonSignAWC1" />
                            </td>
                            <td>
                                <uc1:ucPersonSign runat="server" ID="ucPersonSignAWC2" />
                            </td>
                            <td>
                                <uc1:ucPersonSign runat="server" ID="ucPersonSignAWC3" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>

        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <asp:Button ID="btn_save" runat="server" CssClass="btn_normal_silver" Text="Save" OnClick="btn_save_Click" />
                <asp:Button ID="btn_submit" runat="server" CssClass="btn_normal_silver" Text="Submit" />
                <asp:Button ID="btn_gendocumnt" runat="server" CssClass="btn_normal_silver" Text="Preview" OnClick="btn_gendocumnt_Click" />
                <asp:Button ID="btn_cancel" runat="server" CssClass="btn_normal_silver" Text="Cancel" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="claim_no" runat="server" />
    <asp:HiddenField ID="claim_date" runat="server" />
</asp:Content>