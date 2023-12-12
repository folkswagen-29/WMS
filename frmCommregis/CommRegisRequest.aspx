<%@ Page Title="Commercial Registration Request" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="CommRegisRequest.aspx.cs" Inherits="onlineLegalWF.frmCommregis.CommRegisRequest" %>
<%@ Register Src="~/userControls/ucPersonSign.ascx" TagPrefix="uc2" TagName="ucPersonSign" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>
<%@ Register Src="~/userControls/ucAttachment.ascx" TagPrefix="uc3" TagName="ucAttachment" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager runat="server">
        <Scripts>
            <asp:ScriptReference Name="jquery" />
        </Scripts>
    </asp:ScriptManager>
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
                                <asp:TextBox ID="doc_no" runat="server" CssClass="Text_400"></asp:TextBox>
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
                                <asp:TextBox ID="company_name_th" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ชื่อบริษัท ภาษาอังกฤษ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="company_name_en" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">แบบตราประทับ</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <input type="file"  value="Input File" />
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
                                            <asp:TextBox ID="text1" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">หมวดกิจกรรม </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="text2" runat="server" CssClass="Text_200"></asp:TextBox>
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
                            <td><asp:TextBox ID="text3" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="100"></asp:TextBox></td>
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
                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">มูลค่าหุ้น </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="TextBox2" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="Text_200"></asp:TextBox></td>
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
                                            <asp:TextBox ID="TextBox4" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">จำนวน </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="TextBox5" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                            <asp:TextBox ID="TextBox6" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">ชำระแล้ว </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="TextBox7" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                <asp:TextBox ID="TextBox8" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="100"></asp:TextBox></td>
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
                                            <asp:TextBox ID="TextBox9" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">ตำแหน่ง </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="TextBox10" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                <asp:TextBox ID="TextBox11" runat="server" CssClass="Text_400"></asp:TextBox>
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
                                            <asp:TextBox ID="TextBox12" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">ใบอนุญาตเลขที่ </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="TextBox13" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                <asp:TextBox ID="TextBox14" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                <asp:TextBox ID="TextBox15" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ชื่อบริษัท ภาษาอังกฤษ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="TextBox16" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">แบบตราประทับ</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <input type="file" value="Input File" />
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
                                            <asp:TextBox ID="TextBox17" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">จำนวนหุ้นที่เพิ่ม </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="TextBox18" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                            <asp:TextBox ID="TextBox19" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">จำนวนหุ้นที่ลด </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="TextBox20" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                <asp:TextBox ID="TextBox21" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                <asp:TextBox ID="TextBox22" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="100"></asp:TextBox></td>
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
                                <asp:TextBox ID="TextBox23" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="100"></asp:TextBox></td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ข้อบังคับบริษัทย่อยที่ประกอบธุรกิจหลักหรือบริษัทย่อยธรรมดา</label>
                            </td>
                            <td>&nbsp;</td>
                            <td>
                                <asp:TextBox ID="TextBox24" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="100"></asp:TextBox></td>
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
                                            <asp:TextBox ID="TextBox25" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">ตำแหน่ง </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="TextBox26" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                            <asp:TextBox ID="TextBox27" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">ตำแหน่ง </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="TextBox28" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                            <asp:TextBox ID="TextBox37" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">สัญชาติ </label>
                                        </td>
                                        <td class="cell_content_40PC_TL" style="padding: 0;">
                                            <asp:TextBox ID="TextBox38" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                <asp:TextBox ID="TextBox39" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                            <asp:TextBox ID="TextBox29" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">อาคาร </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="TextBox30" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">ถนน </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="TextBox31" runat="server" CssClass="Text_150"></asp:TextBox>
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
                                            <asp:TextBox ID="TextBox32" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">เขต </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="TextBox33" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">จังหวัด </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="TextBox34" runat="server" CssClass="Text_150"></asp:TextBox>
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
                                            <asp:TextBox ID="TextBox35" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">เบอร์โทร </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="TextBox36" runat="server" CssClass="Text_150"></asp:TextBox>
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
                                            <asp:TextBox ID="TextBox47" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">อาคาร </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="TextBox48" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">ถนน </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="TextBox49" runat="server" CssClass="Text_150"></asp:TextBox>
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
                                            <asp:TextBox ID="TextBox50" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">เขต </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="TextBox51" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">จังหวัด </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="TextBox52" runat="server" CssClass="Text_150"></asp:TextBox>
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
                                            <asp:TextBox ID="TextBox53" runat="server" CssClass="Text_150"></asp:TextBox>
                                        </td>
                                        <td style="width: 55px; min-width: 55px; text-align: right; vertical-align: top;">
                                            <label class="Label_md">เบอร์โทร </label>
                                        </td>
                                        <td class="cell_content_PC_TL">
                                            <asp:TextBox ID="TextBox54" runat="server" CssClass="Text_150"></asp:TextBox>
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
                                <asp:TextBox ID="TextBox40" runat="server" CssClass="Text_400"></asp:TextBox>
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
                <uc3:ucAttachment runat="server" ID="ucAttachment1" />
            </td>

        </tr>
    </table>

    <script type="text/javascript">
        $(function () {
            //console.log('ddl value', $('#type_comm_regis option:selected').val());

            $('#ContentPlaceHolder1_type_comm_regis').change(function (event) {
                console.log('val', $(this).val());
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
