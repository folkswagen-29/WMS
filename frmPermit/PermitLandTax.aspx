<%@ Page Title="Land and Building Tax Request" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="PermitLandTax.aspx.cs" Inherits="onlineLegalWF.frmPermit.PermitLandTax" %>
<%@ Register Src="~/userControls/ucPersonSign.ascx" TagPrefix="uc2" TagName="ucPersonSign" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>
<%@ Register Src="~/userControls/ucAttachment.ascx" TagPrefix="uc3" TagName="ucAttachment" %>
<%@ Register Src="~/userControls/ucCommentlog.ascx" TagPrefix="uc4" TagName="ucCommentlog" %>

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
                                <label class="Label_md">Requester </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:DropDownList ID="type_requester" runat="server" CssClass="Text_400">
                                    <asp:ListItem Value="01">Retall Group Officer / กลุ่มรีเทล</asp:ListItem>
                                    <asp:ListItem Value="02">Commetcial Group Officer / กลุ่มคอมเมอร์เซียล</asp:ListItem>
                                    <asp:ListItem Value="03">Hospitality Group  Officer / กลุ่มโรงแรม</asp:ListItem>
                                    <asp:ListItem Value="04">Others / อื่นๆ</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Subject/Project </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:DropDownList ID="type_project" runat="server" CssClass="Text_200">
                                    <asp:ListItem>เลอ เมอริเดียน เชียงใหม่</asp:ListItem>
                                    <asp:ListItem>ภูเก็ต แมริออท</asp:ListItem>
                                    <asp:ListItem>คอร์ท ยาท ภูเก็ต</asp:ListItem>
                                    <asp:ListItem>บันยันทรี สมุย</asp:ListItem>
                                    <asp:ListItem>วนาเบลล์</asp:ListItem>
                                    <asp:ListItem>เชอราตัน สมุย</asp:ListItem>
                                    <asp:ListItem>มิเลีย สมุย</asp:ListItem>
                                    <asp:ListItem>บันยันทรี พัทยา (จอมเทียน)</asp:ListItem>
                                    <asp:ListItem>พันธ์ทิพย์ งามวงศ์วาน</asp:ListItem>
                                    <asp:ListItem>ตลาดต่อยอด อยุธยา </asp:ListItem>
                                    <asp:ListItem>อิมพีเรียล แม่ปิง</asp:ListItem>
                                    <asp:ListItem>มิเลีย เชียงใหม่</asp:ListItem>
                                    <asp:ListItem>บันยันทรี กระบี่</asp:ListItem>
                                    <asp:ListItem>แมริออท มาร์คีส์ ควีนสปาร์ค</asp:ListItem>
                                    <asp:ListItem>ดับเบิ้ล ทรี</asp:ListItem>
                                    <asp:ListItem>ฮิลตัน สุขุมวิท</asp:ListItem>
                                    <asp:ListItem>เลอ เมอริเดียน กรุงเทพ</asp:ListItem>
                                    <asp:ListItem>แมริออท สุรวงศ์</asp:ListItem>
                                    <asp:ListItem>EAC</asp:ListItem>
                                    <asp:ListItem>ดิ แอทธินี  AHLC+ ราชินีมูลนิธิ</asp:ListItem>
                                    <asp:ListItem>แกรนด์ โซเล</asp:ListItem>
                                    <asp:ListItem>แมริออท พัทยา</asp:ListItem>
                                    <asp:ListItem>แมริออท หัวหิน</asp:ListItem>
                                    <asp:ListItem>อิมพีเรียล หัวหิน</asp:ListItem>
                                    <asp:ListItem>อาคาร 208</asp:ListItem>
                                    <asp:ListItem>Empire Tower</asp:ListItem>
                                    <asp:ListItem>ดิ โอกุระ </asp:ListItem>
                                    <asp:ListItem>แอทธินี ทาวเวอร์</asp:ListItem>
                                    <asp:ListItem>พันธ์ทิพย์ เชียงใหม่ </asp:ListItem>
                                    <asp:ListItem>เจริญกรุง 93</asp:ListItem>
                                    <asp:ListItem>แมริออท พัทยา</asp:ListItem>
                                    <asp:ListItem>เอเชีย ทีค</asp:ListItem>
                                    <asp:ListItem>Gateway บางซื่อ</asp:ListItem>
                                    <asp:ListItem>ซิกม่า</asp:ListItem>
                                    <asp:ListItem>อินไซค์ สุขุมวิท 50</asp:ListItem>
                                    <asp:ListItem>พันธ์ทิพย์ ประตูน้ำ</asp:ListItem>
                                    <asp:ListItem>OP Place</asp:ListItem>
                                    <asp:ListItem>ฮอลิเดย์ อินน์ เอ็กซ์เพรส</asp:ListItem>
                                    <asp:ListItem>ลาซาล อเวนิว</asp:ListItem>
                                    <asp:ListItem>ตะวันนา 1</asp:ListItem>
                                    <asp:ListItem>Inter Link</asp:ListItem>
                                    <asp:ListItem>ล้ง 1919 </asp:ListItem>
                                    <asp:ListItem>Gateway เอกมัย</asp:ListItem>
                                    <asp:ListItem>บุญมีพัฒนา</asp:ListItem>
                                    <asp:ListItem>เริงชัย</asp:ListItem>
                                    <asp:ListItem>เวิ้งนาครเขษม </asp:ListItem>
                                    <asp:ListItem>อิมม์ โฮเต๊ล เจริญกรุง</asp:ListItem>
                                    <asp:ListItem>ทรงวาด โรงแรม</asp:ListItem>
                                    <asp:ListItem>ทรงวาด ที่จอดรถ</asp:ListItem>
                                    <asp:ListItem>ลาซาล (ฝั่งตรงข้าม)</asp:ListItem>
                                    <asp:ListItem>โกลเด้นไทรแองเกิ้ล</asp:ListItem>
                                    <asp:ListItem>บุดดา มิวเซียม</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">หน่วยงานที่ต้องไปติดต่อ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="contact_agency" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">ชื่อผู้รับมอบอำนาจ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="attorney_name" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">email ของบัญชีที่ต้องการให้รับทราบ </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="email_accounting" runat="server" CssClass="Text_400"></asp:TextBox>
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
                                <asp:Label ID="Label7" runat="server" Text="รับผิดชอบโดย"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="อนุมัติโดย"></asp:Label>
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
        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <uc4:ucCommentlog runat="server" ID="ucCommentlog1" />
            </td>
        </tr>
    </table>
    <asp:HiddenField ID="hid_PID" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblPID" runat="server" CssClass="Label_sm"></asp:Label>
</asp:Content>
