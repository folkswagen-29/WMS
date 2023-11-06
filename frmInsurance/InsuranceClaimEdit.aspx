<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuranceClaimEdit.aspx.cs" Inherits="onlineLegalWF.frmInsurance.InsuranceClaimEdit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>InsuranceClaimEdit</title>
    <style type="text/css">
        .auto-style1 {
            width: 1200px;
        }
        .auto-style2 {
            width: 180px;
        }
        .auto-style3 {
            width: 500px;
            height: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family:Tahoma; font-size:10pt;margin-top: 20px;">
            <table cellpadding="0" cellspacing="0" class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <label>Document No.</label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="doc_no" runat="server" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <label>Company </label>
                    </td>
                    <td >
                        <asp:TextBox ID="company_name" runat="server" Width="500px"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <label>BU </label>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddl_bu" runat="server" Width="300px">
                            <asp:ListItem>-Please select-</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <label>Incident </label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="incident" runat="server" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <label>Date Occurred </label>
                    </td>
                    <td>
                        <asp:TextBox ID="occurred_date" TextMode="Date" runat="server" ></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <label>Date Submissio </label>
                    </td>
                    <td>
                        <asp:TextBox ID="submission_date" TextMode="Date" runat="server" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <label>Incident Summary</label><br />
                        <asp:TextBox ID="incident_summary" TextMode="MultiLine" runat="server" CssClass="auto-style3"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <label>Claim Result</label>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <label>Surveyor</label>
                    </td>
                    <td>
                        <asp:TextBox ID="surveyor_name" runat="server" Width="300px"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <label>Company</label>
                    </td>
                    <td>
                        <asp:TextBox ID="surveyor_company" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <label>Date of Settlement </label>
                    </td>
                    <td>
                        <asp:TextBox ID="settlement_date" TextMode="Date" runat="server" ></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <label>Day of Settlement </label>
                    </td>
                    <td>
                        <asp:TextBox ID="settlement_day" runat="server" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table border="1">
                            <tr>
                                <td>
                                    <label>Estimated losses to claim</label><br />
                                    <label>มูลค่าความเสียหาย</label>
                                </td>
                                <td style="width: 150px; text-align: center;">
                                    <label>IAR</label><br />
                                    <label>ทรัพย์สินเสียหาย</label>
                                </td>
                                <td style="width: 150px; text-align: center;">
                                    <label>BI</label><br />
                                    <label>ธุรกิจหยุดชะงัก</label>
                                </td>
                                <td style="width: 150px; text-align: center;">
                                    <label>PL/CGL</label><br />
                                    <label>รับผิดบุคคลภายนอก</label>
                                </td>
                                <td style="width: 150px; text-align: center;">
                                    <label>PV</label><br />
                                    <label>สาเหตุทางการเมือง</label>
                                </td>
                                <td style="width: 150px; text-align: center;">
                                    <label>Total</label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Amount to claim มูลค่าเรียกร้อง (a)</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="iar_atc" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="bi_atc" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="pl_cgl_atc" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="pv_atc" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="ttl_atc" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Deductible ค่ารับผิดส่วนแรก (b)</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="iar_ded" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="bi_ded" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="pl_cgl_ded" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="pv_ded" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="ttl_ded" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Proceeds from claim มูลค่าสินไหม (C)</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="iar_pfc" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="bi_pfc" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="pl_cgl_pfc" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="pv_pfc" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="ttl_pfc" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <label>Under amount to claim ส่วนต่างมูลค่าการเคลม (a-b-c)</label>
                                </td>
                                <td>
                                    <asp:TextBox ID="iar_uatc" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="bi_uatc" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="pl_cgl_uatc" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="pv_uatc" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="ttl_uatc" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <label>Remark</label><br />
                        <asp:TextBox ID="remark" TextMode="MultiLine" runat="server" CssClass="auto-style3"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        &nbsp;
                        </td>
                    <td colspan="3">
                        <asp:Button ID="btn_save" runat="server" Text="Save" Width="200px" OnClick="btn_save_Click" />
                        &nbsp;&nbsp;<asp:Button ID="btn_gendocumnt" runat="server" Text="TestGenDocumnet" Width="200px" OnClick="btn_gendocumnt_Click" />

                    </td>
                </tr>
            </table>
        </div>
        <asp:HiddenField ID="claim_no" runat="server" />
        <asp:HiddenField ID="claim_date" runat="server" />
    </form>
</body>
</html>
