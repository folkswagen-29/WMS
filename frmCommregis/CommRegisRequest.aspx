<%@ Page Title="Commercial Registration Request" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="CommRegisRequest.aspx.cs" Inherits="onlineLegalWF.frmCommregis.CommRegisRequest" %>
<%@ Register Src="~/userControls/ucPersonSign.ascx" TagPrefix="uc2" TagName="ucPersonSign" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>
<%@ Register Src="~/userControls/ucAttachment.ascx" TagPrefix="uc3" TagName="ucAttachment" %>
<%@ Register Src="~/userControls/ucCommentlog.ascx" TagPrefix="uc4" TagName="ucCommentlog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="cell_content_100PC">
        <tr>
            <td colspan="2">
                <div style="background-color:gainsboro;">
                    <uc1:ucHeader runat="server" id="ucHeader1" />
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
                                <label class="Label_md">Type of Request </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:DropDownList ID="type_comm_regis" runat="server" CssClass="Text_200">
                                </asp:DropDownList>
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
                                <label class="Label_md">อ้างถึงมติที่ประชุม </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="mt_res_desc" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">ครั้งที่ </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="mt_res_no" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">วันที่ </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="mt_res_date" TextMode="Date" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>

                    <table id="section1">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ชื่อบริษัท ภาษาไทย </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="sec1_company_name_th" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ชื่อบริษัท ภาษาอังกฤษ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="sec1_company_name_en" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">แบบตราประทับ</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <uc3:ucAttachment runat="server" ID="ucAttachmentSec1" />
                                <%--<asp:FileUpload ID="sec1_seal_attach" runat="server" /> 
                                &nbsp; <asp:Button ID="sec1_btnUpload" runat="server" CssClass="btn-group" Text="Upload" /> 
                                &nbsp; <asp:Button ID="sec1_btnEditupload" runat="server" CssClass="btn-group" Visible="false" Text="Edit" />--%>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ที่ตั้งสำนักงาน </label>
                            </td>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เลขที่ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec1_no" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width:55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">อาคาร </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec1_building" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width:55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">ถนน </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec1_road" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">แขวง </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec1_subdistrict" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width:55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">เขต </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec1_district" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width:55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">จังหวัด </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec1_province" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">รหัสไปรษณีย์ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec1_postcode" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">เบอร์โทร </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec1_phonenumber" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ประเภทธุรกิจ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec1_typebu" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">หมวดกิจกรรม </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec1_typeactivity" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">วัตถุประสงค์ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td><asp:TextBox ID="sec1_object" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="100"></asp:TextBox></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ทุนจดทะเบียน </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec1_reg_capital" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">มูลค่าหุ้น </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec1_sharevalue" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ทุนที่เรียกชำระแล้ว </label>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:TextBox ID="sec1_paidcapital" runat="server" CssClass="Text_200"></asp:TextBox></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">โครงสร้างผู้ถือหุ้น </label>
                            </td>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ชื่อ นามสกุล </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec1_shareholdername" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">จำนวน </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec1_shareholderamount" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">มูลค่า </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec1_shareholdervalue" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">ชำระแล้ว </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec1_shareholderpaid" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">การใช้ข้อบังคับ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:TextBox ID="sec1_rule" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="100"></asp:TextBox></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">รายชื่อกรรมการ </label>
                            </td>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ชื่อ นามสกุล </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec1_directorname" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">ตำแหน่ง </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec1_directorposittion" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">รายชื่อผู้เริ่มก่อการบุคคลธรรมดาได้เข้าชื่อซื้อหุ้น </label>
                            </td>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ชื่อ นามสกุล </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <asp:TextBox ID="sec1_laymanname" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ชื่อผู้ตรวจสอบบัญชี </label>
                            </td>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ชื่อ นามสกุล </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec1_auditname" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">ใบอนุญาตเลขที่ </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec1_auditlicense" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ค่าจ้างต่อปี </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <asp:TextBox ID="sec1_costperyear" runat="server" CssClass="Text_200"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section2" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ชื่อบริษัท ภาษาไทย </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="sec2_companynameth" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ชื่อบริษัท ภาษาอังกฤษ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="sec2_companynameen" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">แบบตราประทับ</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <uc3:ucAttachment runat="server" ID="ucAttachmentSec2" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section3" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ทุนจดทะเบียนที่เพิ่ม </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec3_reg_capital_add" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">จำนวนหุ้นที่เพิ่ม </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec3_sharevalue_add" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ทุนจดทะเบียนที่ลด </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec3_reg_capital_subsidize" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">จำนวนหุ้นที่ลด </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec3_sharevalue_subsidize_amount" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">มูลค่าหุ้นที่ลด </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="sec3_sharevalue_subsidize" runat="server" CssClass="Text_200"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section4" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">วัตถุประสงค์ที่แก้ไขเพิ่มเติม</label>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:TextBox ID="sec4_object_add" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="100"></asp:TextBox></td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section5" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ข้อบังคับ</label>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:TextBox ID="sec5_ruledesc" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="100"></asp:TextBox></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ข้อบังคับบริษัทย่อยที่ประกอบธุรกิจหลักหรือบริษัทย่อยธรรมดา</label>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:TextBox ID="sec5_rule_companydesc" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="100"></asp:TextBox></td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section6" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">รายชื่อกรรมการเข้า </label>
                            </td>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ชื่อ นามสกุล </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec6_directorname_in" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">ตำแหน่ง </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec6_directorposition_in" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">รายชื่อกรรมการออก </label>
                            </td>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ชื่อ นามสกุล </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec6_directorname_out" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">ตำแหน่ง </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec6_directorposition_out" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">อายุ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec6_old" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">สัญชาติ </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="sec6_nationality" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เลขบัตรประจำตัวประชาชน / บัตรอื่น ๆ (กรณีเป็นชาวต่างชาติ) </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="sec6_identityno" runat="server" CssClass="Text_200"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ที่อยู่กรรมการที่เข้าใหม่ </label>
                            </td>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เลขที่ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec6_no" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">อาคาร </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec6_building" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">ถนน </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec6_road" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">แขวง </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec6_subdistrict" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">เขต </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec6_district" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">จังหวัด </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec6_province" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">รหัสไปรษณีย์ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec6_postcode" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">เบอร์โทร </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec6_phonenumber" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section7" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ที่ตั้งสำนักงานใหญ่</label>
                            </td>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เลขที่ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec7_no" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">อาคาร </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec7_building" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">ถนน </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec7_road" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">แขวง </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec7_subdistrict" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">เขต </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec7_district" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">จังหวัด </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec7_province" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">รหัสไปรษณีย์ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL" style="padding: 0;">
                                <table>
                                    <tr>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec7_postcode" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">เบอร์โทร </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="sec7_phonenumber" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เลขรหัสประจำบ้าน </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="sec7_housecode" runat="server" CssClass="Text_400"></asp:TextBox>
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
                <asp:Panel ID="Panel2" runat="server" CssClass="div_90" Height="200px">
                    <table class="cell_content_100PC">
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="จัดทำโดย"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="เสนอโดย"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc2:ucPersonSign runat="server" ID="ucPersonSign1" />
                            </td>
                            <td>
                                <uc2:ucPersonSign runat="server" ID="ucPersonSign2" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
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
        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <br />
                <asp:Panel ID="Panel3" runat="server" CssClass="div_90">
                    <uc3:ucAttachment runat="server" ID="ucAttachment1" />
                </asp:Panel>
                <br />
            </td>

        </tr>
        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <uc4:ucCommentlog runat="server" ID="ucCommentlog1" />
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        $(function () {
            //console.log('ddl value', $('#type_comm_regis option:selected').val());

            $('#ContentPlaceHolder1_type_comm_regis').change(function (event) {
                //console.log('val', $(this).val());
                if ($(this).val() == "01") {
                    $('#section1').show();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').hide();
                }
                else if ($(this).val() == "02") {
                    $('#section1').hide();
                    $('#section2').show();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').hide();
                }
                else if ($(this).val() == "03") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').show();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').hide();
                }
                else if ($(this).val() == "04") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').show();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').hide();
                }
                else if ($(this).val() == "05") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').show();
                    $('#section6').hide();
                    $('#section7').hide();
                }
                else if ($(this).val() == "06") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').show();
                    $('#section7').hide();
                }
                else if ($(this).val() == "07") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').show();
                }
            });
        });
    </script>
    <asp:HiddenField ID="hid_PID" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblPID" runat="server" CssClass="Label_sm"></asp:Label>
</asp:Content>
