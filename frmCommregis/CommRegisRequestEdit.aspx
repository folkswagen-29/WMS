<%@ Page Title="Commercial Registration RequestEdit" Async="true" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="CommRegisRequestEdit.aspx.cs" Inherits="WMS.frmCommregis.CommRegisRequestEdit" %>
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
                                <asp:Label ID="req_no" CssClass="Label_md" runat="server" Text=""></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Type of Request </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:DropDownList ID="type_comm_regis" runat="server" CssClass="Text_400">
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr class="other">
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Type of Request Other </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="toc_regis_desc_other" runat="server" CssClass="Text_400 other"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr class="subsidiary" style="display: none;">
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Subsidiary </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:DropDownList ID="ddl_subsidiary" runat="server" CssClass="Text_400">
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
                        <tr class="other" style="display: none;">
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">รายละเอียด </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="other_desc" runat="server" TextMode="MultiLine" CssClass="Text_600"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr class="meeting">
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
                        <tr class="company" style="display: none;">
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ชื่อบริษัท ภาษาไทย </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="company_name_th" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr class="company" style="display: none;">
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ชื่อบริษัท ภาษาอังกฤษ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="company_name_en" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr class="moresubsidiary" style="display: none;">
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ขอมากกว่า 1 บริษัท</label>
                                &nbsp;
                                <asp:CheckBox ID="cb_more" CssClass="cb_more" runat="server" />
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL more_cb_sub" style="display: none;">
                                <asp:CheckBox ID="chkHeader" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll" /> <label class="Label_md"> เลือกทั้งหมด</label>
                                <asp:CheckBoxList ID="cb_subsidiary_multi" runat="server" CssClass="Text_400"></asp:CheckBoxList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>

                    <table id="section1">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">RD Register</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:CheckBox ID="sec1_cb_rd" runat="server" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เอกสารที่ต้องใช้ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>ชื่อของบริษัท ภาษาไทย/ภาษาอังกฤษ (ที่ใช้จดทะเบียน)</li>
                                    <li>แบบตราประทับของบริษัท</li>
                                    <li>เลขที่อยู่ ที่ตั้งสำนักงานใหญ่/สาขาของบริษัท</li>
                                    <li>วัตถุประสงค์ของบริษัทกลุ่มโรงแรม/รีเทล</li>
                                    <li>ทุนจดทะเบียน / มูลค่าหุ้น / ทุนที่เรียกชำระ (เต็มจำนวนหรือไม่)</li>
                                    <li>โครงสร้างจำนวนและรายชื่อผู้ถือหุ้น</li>
                                    <li>ใช้ข้อบังคับบริษัทแบบใด (เป็นบริษัทย่อยธรรมดา หรือ บริษัทย่อยหลักฯ)</li>
                                    <li>รายชื่อกรรมการ/ อำนาจกรรมการ</li>
                                    <li>จำนวนและรายชื่อผู้เริ่มก่อการบุคคลธรรมดาได้เข้าชื่อซื้อหุ้น</li>
                                    <li>ชื่อผู้สอบบัญชี / ใบอนุญาตเลขที่ / ค่าจ้างกี่บาทต่อปี</li>
                                    <li>รอบระยะเวลาบัญชี</li>
                                    <li>หมวดกิจกรรม / ประเภทธุรกิจ</li>
                                    <li>หมายเหตุ :
                                        <br />
                                        มติอนุมัติให้ดำเนินการจาก committee
                                        <br />
                                        presentation for committee (Matterials)
                                    </li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เอกสารประกอบการดำเนินงานของฝ่ายกฎหมาย</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>มติอนุมัติให้ดำเนินการและ อนุมัติชื่อบริษัท (ต้องมี) Excom</li>
                                    <li>สำเนาบัตรประชาชนและสำเนาทะเบียนบ้าน หรือบัตรอื่นๆ (กรณีเป็นชาวต่างชาติ) ผู้เริ่มก่อการ</li>
                                    <li>สำเนาบัตรประชาชนและสำเนาทะเบียนบ้าน หรือบัตรอื่นๆ (กรณีเป็นชาวต่างชาติ) กรรมการบริษัท</li>
                                    <li>สำเนาบัตรประชาชนและสำเนาทะเบียนบ้าน หรือบัตรอื่นๆ (กรณีเป็นชาวต่างชาติ) พยาน 2 คน</li>
                                    <li>สำเนาทะเบียนบ้านที่ตั้งสำนักงานใหญ่ และสำนักงานสาขา (กรณีใช้ที่อยู่อื่นนอกเหนือจากตึกเอ็มไพร์)</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr id="rdregis1" style="display: none;">
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">หลักฐานเพิ่มเติมที่ต้องแนบ</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>ชื่อบริษัทที่ให้ดำเนินการจดทะเบียนภาษีมูลค่าเพิ่ม </li>
                                    <li>ชื่อ ที่อยู่ของสถานประกอบการ </li>
                                    <li>ประเภทสถานประกอบการ คือ บ้านพัก อาคารพาณิชย์ อาคารสำนักงาน อาคารโรงงาน อาคารชุด อื่นๆ</li>
                                    <li>วันที่รายรับถึงเกณฑ์จดทะเบียน</li>
                                    <li>ประเภทของการประกอบกิจการ คือ ผลิต ส่งออก ขายส่ง ขายปลีก ให้บริการ</li>
                                    <li>สัญญาเช่าอาคาร หรือ หนังสือยินยอมให้ใช้สถานที่ (Legal document หรือ Counselling : Legal Work flow)หรือ เอกสารแสดงกรรมสิทธิ์ของผู้ให้เช่า เช่น โฉนดที่ดิน</li>
                                    <li>สำเนาทะเบียนบ้านที่ตั้งสถานประกอบการ</li>
                                    <li>แผนที่ตั้งสถานประกอบการและภาพถ่ายสถานประกอบการ</li>
                                    <li>อนุมัติให้ดำเนินการ (อนุมัติภายในของ C-Level (บัญชี))</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section2" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เอกสารที่ต้องใช้ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>ชื่อบริษัทใหม่ (ที่ใช้จดทะเบียน)</li>
                                    <li>แบบตราประทับของบริษัท</li>
                                    <li>มติอนุมัติให้ดำเนินการ และอนุมัติชื่อบริษัท (ต้องมี) CEO & President / MACO</li>
                                    <li>เอกสารสรุปรายละเอียดอื่นๆที่เกี่ยวข้อง เช่น presentation ที่ใช้ตอนขออนุมัติต่อ committee</li>
                                    <li>วันที่มีการเปลี่ยนแปลง</li>
                                    <li>แจ้งหลังจากเปลี่ยนแปลงภายใน 15 วัน</li>
                                    <li>ชื่อใหม่ของผู้ประกอบการ และสถานประกอบการ</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">หลักฐานเพิ่มเติมที่ต้องแนบ</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>ใบทะเบียนภาษีมูลค่าเพิ่ม ฉบับจริง</li>
                                    <li>อนุมัติให้ดำเนินการ (อนุมัติภายในของ C-Level)</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section3" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เอกสารที่ต้องใช้ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>ทุน จำนวนหุ้น ที่เพิ่ม </li>
                                    <li>ทุน จำนวนหุ้น หรือ มูลค่าหุ้นที่ลด</li>
                                    <li>รายชื่อผู้ถือหุ้น</li>
                                    <li>มติอนุมัติให้ดำเนินการ(ต้องมี) Excom</li>
                                    <li>เอกสารสรุปรายละเอียดอื่นๆที่เกี่ยวข้อง เช่น presentation ที่ใช้ตอนขออนุมัติต่อ committee</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section4" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เอกสารที่ต้องใช้ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>ข้อความวัตถุประสงค์ที่แก้ไขเพิ่มเติม </li>
                                    <li>มติอนุมัติให้ดำเนินการ(ต้องมี) CEO & President </li>
                                    <li>เอกสารสรุปรายละเอียดอื่นๆที่เกี่ยวข้อง เช่น presentation ที่ใช้ตอนขออนุมัติต่อ committee</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section5" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เอกสารที่ต้องใช้ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>รายละเอียดข้อบังคับใหม่</li>
                                    <li>ข้อบังคับบริษัทย่อยที่ประกอบธุรกิจหลักหรือบริษัทย่อยธรรมดา</li>
                                    <li>มติอนุมัติให้ดำเนินการ (ต้องมี)Excom</li>
                                    <li>เอกสารสรุปรายละเอียดที่เกี่ยวข้อง</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section6" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">RD Register</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:CheckBox ID="sec6_cb_rd" runat="server" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เอกสารที่ต้องใช้ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>ชื่อ นามสกุล กรรมการเข้า / กรรมการออก</li>
                                    <li>ที่อยู่ อายุ สัญชาติ เลขบัตรประจำตัวประชาชนหรือ บัตรอื่น ๆ (กรณีเป็นชาวต่างชาติ) ของกรรมการเข้าใหม่</li>
                                    <li>มติอนุมัติให้ดำเนินการ(ต้องมี) ประกาศจาก HR / ผลของการลาออก / Excom</li>
                                    <li>สำเนาบัตรประจำตัวประชาชนและสำเนาทะเบียนบ้านกรรมการเข้าใหม่</li>
                                    <li>สำเนาใบมรณบัตร (ใช้เฉพาะกรณีกรรมการถึงแก่กรรม)</li>
                                    <li>เอกสารสรุปรายละเอียดๆ ที่เกี่ยวข้อง เช่น presentation ที่ใช้ตอนขออนุมัติจาก committee</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr id="rdregis6" style="display: none;">
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">หลักฐานเพิ่มเติมที่ต้องแนบ</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>สถานที่เดิมที่อยู่</li>
                                    <li>สถานที่ใหม่ </li>
                                    <li>แจ้งล่วงหน้าไม่น้อยกว่า 15 วัน</li>
                                    <li>กำหนดวันที่ย้ายเข้า</li>
                                    <li>สัญญาเช่าอาคาร หรือ หนังสือยินยอมให้ใช้สถานที่ (ต้องส่งตัวจริงเท่านั้น) หรือ เอกสารแสดงกรรมสิทธิ์ของผู้ให้เช่า เช่น โฉนดที่ดิน</li>
                                    <li>สำเนาทะเบียนบ้านที่ตั้งสถานประกอบการ</li>
                                    <li>แผนที่ตั้งสถานประกอบการและภาพถ่ายสถานประกอบการ</li>
                                    <li>อนุมัติให้ดำเนินการ (อนุมัติภายในของ C-Level (บัญชี))</li>
                                    <li>ใบทะเบียนภาษีมูลค่าเพิ่ม ฉบับจริง</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section7" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เอกสารที่ต้องใช้ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>ที่ตั้งแห่งใหม่ของสำนักงานใหญ่</li>
                                    <li>เลขรหัสประจำบ้าน </li>
                                    <li>มติอนุมัติให้ดำเนินการ (ต้องมี) Excom</li>
                                    <li>สำเนาทะเบียนบ้านที่ตั้งสำนักงานใหญ่ และสำนักงานสาขา แผนที่ตั้ง</li>
                                    <li>เอกสารสรุปรายละเอียดๆ ที่เกี่ยวข้อง เช่น presentation ที่ใช้ตอนขออนุมัติจาก committee</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section8" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">RD Register</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:CheckBox ID="sec8_cb_rd" runat="server" />
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เอกสารที่ต้องใช้ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>ที่ตั้งสำนักงานสาขา</li>
                                    <li>สัญญาเช่าอาคาร หรือ หนังสือยินยอมให้ใช้สถานที่ (ต้องส่งตัวจริงเท่านั้น) หรือ เอกสารแสดงกรรมสิทธิ์ของผู้ให้เช่า เช่น โฉนด</li>
                                    <li>สำเนาทะเบียนบ้านที่ตั้งสถานประกอบการ</li>
                                    <li>แผนที่ตั้งสถานประกอบการและภาพถ่ายสถานประกอบการ</li>
                                    <li>อนุมัติให้ดำเนินการ (อนุมัติภายในของ C-Level)</li>
                                    <li>ใบทะเบียนภาษีมูลค่าเพิ่ม ฉบับจริง ถ้าหายต้องไปแจ้งความด้วย</li>
                                    <li>มติอนุมัติให้ดำเนินการ(ต้องมี)อนุมัติภายในของหน่วยงาน โดยมี CFO อนุมัติเท่านั้น</li>
                                    <li>เอกสารสรุปรายละเอียดๆ ที่เกี่ยวข้อง เช่น presentation ที่ใช้ตอนขออนุมัติจาก committee</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr id="rdregis8" style="display: none;">
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">หลักฐานเพิ่มเติมที่ต้องแนบ</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>สถานที่เดิมที่อยู่</li>
                                    <li>กรณีเพิ่มสาขาแจ้งล่วงหน้าไม่น้อยกว่า 15 วัน</li>
                                    <li>กรณีลดสาขาแจ้งหลังจากเปลี่ยนแปลงภายใน 15 วัน</li>
                                    <li>วันที่มีผล</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section9" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เอกสารที่ต้องใช้ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>รายชื่อบริษัทที่ควบเข้ากัน</li>
                                    <li>ชื่อบริษัทใหม่ / ตราประทับบริษัท</li>
                                    <li>วัตถุประสงค์ของบริษัทที่ประกอบกิจการค้า</li>
                                    <li>ทุนจดทะเบียน เป็นทุนรวมของทุกบริษัทที่ควบเข้ากัน</li>
                                    <li>ข้อบังคับย่อยประกอบธุรกิจหลักหรือย่อยธรรมดา</li>
                                    <li>กรรมการ และอำนาจกรรมการ</li>
                                    <li>จำนวนของผู้ถือหุ้น / มูลค่าหุ้น</li>
                                    <li>ที่ตั้งสำนักงานใหญ่/ สำนักงานสาขา</li>
                                    <li>มติอนุมัติให้ดำเนินการ(ต้องมี) Excom</li>
                                    <li>รายละเอียดอื่นๆที่เกี่ยวข้อง</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section10" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เอกสารที่ต้องใช้ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>ตารางสรุปการปิดงบการเงิน</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section11" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เอกสารที่ต้องใช้ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>รายละเอียดสำหรับจดทะเบียน</li>
                                    <li>มติอนุมัติให้ดำเนินการ(ต้องมี) BOD AWC/ Excom/ AGM/ EGM</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section12" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เอกสารที่ต้องใช้ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>เปลี่ยนแปลงเมื่อวันที่</li>
                                    <li>แจ้งหลังจากเปลี่ยนแปลง(DBD)ภายใน 15 วัน</li>
                                    <li>ประเภทกิจการ คือ ผลิต ส่งออก ขายส่ง ขายปลึก ให้บริการ</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section13" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เอกสารที่ต้องใช้ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>บริษัทที่ต้องการจด Pos</li>
                                    <li>วันที่มีผลเปิดใช้เครื่อง Pos</li>
                                    <li>จำนวนเครื่อง Pos</li>
                                    <li>ยกเลิกกี่เครื่อง</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">หลักฐานเพิ่มเติมที่ต้องแนบ</label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>แบบคำขออนุมัติใช้เครื่องบันทึกการเก็บเงิน ภ.พ.06 (ส่วนกลางจัดเตรียมให้)</li>
                                    <li>แบบแจ้งการจัดทำและการจัดเก็บเอกสารหลักฐานข้อมูลอิเล็กทรอนิกส์ ภ.อ.11 (ส่วนกลางจัดเตรียมให้)</li>
                                    <li>รายละเอียดประเภทของเครื่องบันทึกการเก็บเงิน</li>
                                    <li>แบบฟอร์มแสดงคุณสมบัติเครื่องบันทึกเงินสดที่ใช้ในงาน หรือ Flowchart ระบบ POS  (โบชัวร์โฆษณา คุณสมบัติเครื่อง POS) </li>
                                    <li>แผนการเก็บเงินนผังแสดงตำแหน่งการวางของเครื่องบันทึก</li>
                                    <li>รูปแบบการเชื่อมต่อเครื่องบันทึกการเก็บเงินกับอุปกรณ์อื่นๆ</li>
                                    <li>ตัวอย่างการเชื่อมต่ออุปกรณ์เครือข่าย</li>
                                    <li>รายละเอียดระบบรักษาความปลอดภัย </li>
                                    <li>ตัวอย่างใบกำกับภาษีอย่างย่อและตัวอย่างรายงานยอดขายที่ออกจากตัวเครื่อง</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section14" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เอกสารที่ใช้ในการจดทะเบียนพานิชย์ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>สำเนาบัตรประจำบัตรประจำตัวประชาชนเจ้าของกิจการ </li>
                                    <li>สำเนาทะเบียนบ้านเจ้าของกิจการ</li>
                                    <li>แผนที่ สถานที่ในการประกอบพณิชยกิจ</li>
                                    <li>หนังสือมอบอำนาจพร้อมติดอาการแสตมป์ 10 บาท (ถ้ามี)</li>
                                    <li>สำเนาบัตรประจำตัวประชาชนผู้รับมอบอำนาจ (ถ้ามี)</li>
                                    <li>สำเนาบัตรประจำตัวประชาชนผู้รับมอบอำนาจ (ถ้ามี) กรณีเจ้าของกิจการมิได้เป็นเจ้าบ้าน ณ สถานประกอบการนั้น (เพิ่มเติม)</li>
                                    <li>สำเนาบัตรประชาชน ของผู้จัดการแพตฟอร์ม (ผู้รับผิดชอบ แพตฟอร์ม)</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">กรณีเช่ามีสถานะเป็นบริษัท </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>สำเนาสัญญาเช่าพร้อมรับรองสำเนาถูกต้อง</li>
                                    <li>หนังสือรับรองบริษัท พร้อมลงนามลามมือชื่อของผู้มีอำนาจกระทำการแทนบริษัท</li>
                                    <li>สำเนาบัตรประจำตัวประชาชนผู้มีอำนาจกระทำการแทนบริษัท</li>
                                </ol>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section99" style="display: none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">เอกสารที่ต้องใช้ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <ol style="font-family: Tahoma; font-size: 10pt;">
                                    <li>รายละเอียดเอกสารอื่นๆ ที่เกี่ยวข้อง</li>
                                </ol>
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
                <asp:Panel ID="Panel3" runat="server" CssClass="div_90">
                    <uc3:ucAttachment runat="server" ID="ucAttachment1" />
                </asp:Panel>
                <br />
            </td>
        </tr>

        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <asp:Button ID="btn_save" runat="server" CssClass="btn_normal_silver" Text="Save" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" OnClick="btn_save_Click" />
                <asp:Button ID="btn_submit" runat="server" CssClass="btn_normal_silver" Text="Submit" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" OnClick="btn_submit_Click" />
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

    <script type="text/javascript">
        function BindControlEvents() {
            $('#ContentPlaceHolder1_cb_more').on('change', function () {
                if ($(this).is(':checked') == true) {
                    $('.more_cb_sub').show();
                }
                else {
                    $('.more_cb_sub').hide();
                }
            });

            $('#ContentPlaceHolder1_sec1_cb_rd').on('change', function () {
                if ($(this).is(':checked') == true) {
                    $('#rdregis1').show();
                }
                else {
                    $('#rdregis1').hide();
                }
            });

            $('#ContentPlaceHolder1_sec6_cb_rd').on('change', function () {
                if ($(this).is(':checked') == true) {
                    $('#rdregis6').show();
                }
                else {
                    $('#rdregis6').hide();
                }
            });

            $('#ContentPlaceHolder1_sec8_cb_rd').on('change', function () {
                if ($(this).is(':checked') == true) {
                    $('#rdregis8').show();
                }
                else {
                    $('#rdregis8').hide();
                }
            });

            $('#ContentPlaceHolder1_type_comm_regis').on('change', function (event) {
                if ($(this).val() == "01") {
                    $('#section1').show();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').hide();
                    $('#section8').hide();
                    $('#section9').hide();
                    $('#section10').hide();
                    $('#section11').hide();
                    $('#section12').hide();
                    $('#section13').hide();
                    $('#section14').hide();
                    $('#section99').hide();
                    $('.subsidiary').hide();
                    $('.company').show();
                    $('.moresubsidiary').hide();
                    $('.other').hide();
                    $('.meeting').show();
                }
                else if ($(this).val() == "02") {
                    $('#section1').hide();
                    $('#section2').show();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').hide();
                    $('#section8').hide();
                    $('#section9').hide();
                    $('#section10').hide();
                    $('#section11').hide();
                    $('#section12').hide();
                    $('#section13').hide();
                    $('#section14').hide();
                    $('#section99').hide();
                    $('.subsidiary').show();
                    $('.company').show();
                    $('.moresubsidiary').hide();
                    $('.other').hide();
                    $('.meeting').show();
                }
                else if ($(this).val() == "03") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').show();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').hide();
                    $('#section8').hide();
                    $('#section9').hide();
                    $('#section10').hide();
                    $('#section11').hide();
                    $('#section12').hide();
                    $('#section13').hide();
                    $('#section14').hide();
                    $('#section99').hide();
                    $('.subsidiary').show();
                    $('.company').hide();
                    $('.moresubsidiary').show();
                    $('.other').hide();
                    $('.meeting').show();
                }
                else if ($(this).val() == "04") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').show();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').hide();
                    $('#section8').hide();
                    $('#section9').hide();
                    $('#section10').hide();
                    $('#section11').hide();
                    $('#section12').hide();
                    $('#section13').hide();
                    $('#section14').hide();
                    $('#section99').hide();
                    $('.subsidiary').show();
                    $('.company').hide();
                    $('.moresubsidiary').show();
                    $('.other').hide();
                    $('.meeting').show();
                }
                else if ($(this).val() == "05") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').show();
                    $('#section6').hide();
                    $('#section7').hide();
                    $('#section8').hide();
                    $('#section9').hide();
                    $('#section10').hide();
                    $('#section11').hide();
                    $('#section12').hide();
                    $('#section13').hide();
                    $('#section14').hide();
                    $('#section99').hide();
                    $('.subsidiary').show();
                    $('.company').hide();
                    $('.moresubsidiary').show();
                    $('.other').hide();
                    $('.meeting').show();
                }
                else if ($(this).val() == "06") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').show();
                    $('#section7').hide();
                    $('#section9').hide();
                    $('#section10').hide();
                    $('#section11').hide();
                    $('#section12').hide();
                    $('#section13').hide();
                    $('#section14').hide();
                    $('#section99').hide();
                    $('.subsidiary').show();
                    $('.company').hide();
                    $('.moresubsidiary').show();
                    $('.other').hide();
                    $('.meeting').show();
                }
                else if ($(this).val() == "07") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').show();
                    $('#section8').hide();
                    $('#section9').hide();
                    $('#section10').hide();
                    $('#section11').hide();
                    $('#section12').hide();
                    $('#section13').hide();
                    $('#section14').hide();
                    $('#section99').hide();
                    $('.subsidiary').show();
                    $('.company').hide();
                    $('.moresubsidiary').show();
                    $('.other').hide();
                    $('.meeting').show();
                }
                else if ($(this).val() == "08") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').hide();
                    $('#section8').show();
                    $('#section9').hide();
                    $('#section10').hide();
                    $('#section11').hide();
                    $('#section12').hide();
                    $('#section13').hide();
                    $('#section14').hide();
                    $('#section99').hide();
                    $('.subsidiary').show();
                    $('.company').hide();
                    $('.moresubsidiary').show();
                    $('.other').hide();
                    $('.meeting').show();
                }
                else if ($(this).val() == "09") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').hide();
                    $('#section8').hide();
                    $('#section9').show();
                    $('#section10').hide();
                    $('#section11').hide();
                    $('#section12').hide();
                    $('#section13').hide();
                    $('#section14').hide();
                    $('#section99').hide();
                    $('.subsidiary').show();
                    $('.company').hide();
                    $('.moresubsidiary').show();
                    $('.other').hide();
                    $('.meeting').show();
                }
                else if ($(this).val() == "10") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').hide();
                    $('#section8').hide();
                    $('#section9').hide();
                    $('#section10').show();
                    $('#section11').hide();
                    $('#section12').hide();
                    $('#section13').hide();
                    $('#section14').hide();
                    $('#section99').hide();
                    $('.subsidiary').show();
                    $('.company').hide();
                    $('.moresubsidiary').show();
                    $('.other').hide();
                    $('.meeting').show();
                }
                else if ($(this).val() == "11") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').hide();
                    $('#section8').hide();
                    $('#section9').hide();
                    $('#section10').hide();
                    $('#section11').show();
                    $('#section12').hide();
                    $('#section13').hide();
                    $('#section14').hide();
                    $('#section99').hide();
                    $('.subsidiary').show();
                    $('.company').hide();
                    $('.moresubsidiary').show();
                    $('.other').hide();
                    $('.meeting').show();
                }
                else if ($(this).val() == "12") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').hide();
                    $('#section8').hide();
                    $('#section9').hide();
                    $('#section10').hide();
                    $('#section11').hide();
                    $('#section12').show();
                    $('#section13').hide();
                    $('#section14').hide();
                    $('#section99').hide();
                    $('.subsidiary').show();
                    $('.company').hide();
                    $('.moresubsidiary').show();
                    $('.other').hide();
                    $('.meeting').hide();
                }
                else if ($(this).val() == "13") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').hide();
                    $('#section8').hide();
                    $('#section9').hide();
                    $('#section10').hide();
                    $('#section11').hide();
                    $('#section12').hide();
                    $('#section13').show();
                    $('#section14').hide();
                    $('#section99').hide();
                    $('.subsidiary').show();
                    $('.company').hide();
                    $('.moresubsidiary').show();
                    $('.other').hide();
                    $('.meeting').hide();
                }
                else if ($(this).val() == "14") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').hide();
                    $('#section8').hide();
                    $('#section9').hide();
                    $('#section10').hide();
                    $('#section11').hide();
                    $('#section12').hide();
                    $('#section13').hide();
                    $('#section14').show();
                    $('#section99').hide();
                    $('.subsidiary').show();
                    $('.company').hide();
                    $('.moresubsidiary').show();
                    $('.other').hide();
                    $('.meeting').hide();
                }
                else if ($(this).val() == "15") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').hide();
                    $('#section8').hide();
                    $('#section9').hide();
                    $('#section10').hide();
                    $('#section11').hide();
                    $('#section12').hide();
                    $('#section13').hide();
                    $('#section14').hide();
                    $('#section99').hide();
                    $('.subsidiary').show();
                    $('.company').hide();
                    $('.moresubsidiary').show();
                    $('.other').hide();
                    $('.meeting').show();

                }
                else if ($(this).val() == "99") {
                    $('#section1').hide();
                    $('#section2').hide();
                    $('#section3').hide();
                    $('#section4').hide();
                    $('#section5').hide();
                    $('#section6').hide();
                    $('#section7').hide();
                    $('#section8').hide();
                    $('#section9').hide();
                    $('#section10').hide();
                    $('#section11').hide();
                    $('#section12').hide();
                    $('#section13').hide();
                    $('#section14').hide();
                    $('#section99').show();
                    $('.subsidiary').show();
                    $('.company').hide();
                    $('.moresubsidiary').hide();
                    $('.other').show();
                    $('.meeting').hide();
                }
            });
        }

        $(document).ready(function () {
            // bind your jQuery events here initially
            BindControlEvents();
        });
    </script>
    <asp:HiddenField ID="hid_PID" runat="server" />
    <asp:HiddenField ID="req_date" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblPID" runat="server" CssClass="Label_sm"></asp:Label>
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
    function showModalDoc() {
        $("#modaldocument").modal('show');
    }
</script>
</asp:Content>

