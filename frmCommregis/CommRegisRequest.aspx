<%@ Page Title="Commercial Registration Request" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="CommRegisRequest.aspx.cs" Inherits="onlineLegalWF.frmCommregis.CommRegisRequest" %>
<%@ Register Src="~/userControls/ucPersonSign.ascx" TagPrefix="uc2" TagName="ucPersonSign" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>


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
                                <label class="Label_md">ที่ตั้งสำนักงาน </label>
                            </td>
                            <td colspan="3">&nbsp;</td>
                        </tr>
                    </table>
                    <table id="section2" style="display:none;">
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Request No2. </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
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
    </table>

    <script type="text/javascript">
        $(function () {
            //console.log('ddl value', $('#type_comm_regis option:selected').val());

            $('#ContentPlaceHolder1_type_comm_regis').change(function (event) {
                console.log('val', $(this).val());
                if ($(this).val() == "01") {
                    $('#section1').show();
                    $('#section2').hide();
                }
                else if ($(this).val() == "02") {
                    $('#section1').hide();
                    $('#section2').show();
                }
            });
        });
    </script>
</asp:Content>
