<%@ Page Title="License Request" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="PermitLicense.aspx.cs" Inherits="onlineLegalWF.frmPermit.PermitLicense" %>
<%@ Register Src="~/userControls/ucPersonSign.ascx" TagPrefix="uc2" TagName="ucPersonSign" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>
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
                                <asp:ListItem Value="01">Retail Group Officer / กลุ่มรีเทล</asp:ListItem>
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
                                <asp:ListItem Value="CYM">CYM</asp:ListItem>
                                <asp:ListItem Value="MSBK">MSBK</asp:ListItem>
                                <asp:ListItem Value="westin">westin</asp:ListItem>
                                <asp:ListItem Value="MSM">MSM</asp:ListItem>
                                <asp:ListItem Value="MLCM">MLCM</asp:ListItem>
                                <asp:ListItem Value="INS">INS</asp:ListItem>
                                <asp:ListItem Value="VBL">VBL</asp:ListItem>
                                <asp:ListItem Value="SSRM">SSRM</asp:ListItem>
                                <asp:ListItem Value="PMN">PMN</asp:ListItem>
                                <asp:ListItem Value="OPB">OPB</asp:ListItem>
                                <asp:ListItem Value="LMB">LMB</asp:ListItem>
                                <asp:ListItem Value="HES">HES</asp:ListItem>
                                <asp:ListItem Value="HTBK">HTBK</asp:ListItem>
                                <asp:ListItem Value="DTH">DTH</asp:ListItem>
                                <asp:ListItem Value="BYTKB">BYTKB</asp:ListItem>
                                <asp:ListItem Value="BYSM">BYSM</asp:ListItem>
                                <asp:ListItem Value="LMCM">LMCM</asp:ListItem>
                                <asp:ListItem Value="ASTS">ASTS</asp:ListItem>
                                <asp:ListItem Value="BMQ">BMQ</asp:ListItem>
                                <asp:ListItem Value="AHLC">AHLC</asp:ListItem>
                                <asp:ListItem Value="MHH">MHH</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="cell_content_20PC_TR">
                            <label class="Label_md">Type of Request License</label>
                        </td>
                        <td>&nbsp;</td>
                        <td class="cell_content_80PC_TL">
                            <asp:DropDownList ID="type_req_license" runat="server" CssClass="Text_400">
                                <asp:ListItem Value="01">Request  License  / ขอมีใบอนุญาต </asp:ListItem>
                                <asp:ListItem Value="02">Renew License / ขอต่ออายุใบอนุญาต  </asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="cell_content_20PC_TR">
                            <label class="Label_md">License List</label>
                        </td>
                        <td>&nbsp;</td>
                        <td class="cell_content_80PC_TL">
                            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="Text_400">
                                <asp:ListItem Value="01">Hotel License </asp:ListItem>
                                <asp:ListItem Value="02">Hotel Manager Certificate </asp:ListItem>
                                <asp:ListItem Value="03">Operation Hotel License </asp:ListItem>
                                <asp:ListItem Value="04">Swimming Pool License </asp:ListItem>
                                <asp:ListItem Value="05">Bakery License </asp:ListItem>
                                <asp:ListItem Value="06">Preservation Food License </asp:ListItem>
                                <asp:ListItem Value="07">Laundry licnese </asp:ListItem>
                                <asp:ListItem Value="08">Fitness Center License  </asp:ListItem>
                                <asp:ListItem Value="09">Beauty License</asp:ListItem>
                                <asp:ListItem Value="10">Massage Thai License </asp:ListItem>
                                <asp:ListItem Value="11">Suana License </asp:ListItem>
                                <asp:ListItem Value="12">Entertainment License </asp:ListItem>
                                <asp:ListItem Value="13">Spa License </asp:ListItem>
                                <asp:ListItem Value="14">Food & Beverage Licenses  </asp:ListItem>
                                <asp:ListItem Value="15">Certificate of notification operation of the food(>200Sq)</asp:ListItem>
                                <asp:ListItem Value="16">Generator Elictricity License </asp:ListItem>
                                <asp:ListItem Value="17">Money Exchange License </asp:ListItem>
                                <asp:ListItem Value="18">To selling alcohol at restricted time </asp:ListItem>
                                <asp:ListItem Value="19">Foreign Liquor Sales License </asp:ListItem>
                                <asp:ListItem Value="20">Cigarette Sale (Thai -Foreign) License </asp:ListItem>
                                <asp:ListItem Value="21">license Establish Radio Station </asp:ListItem>
                                <asp:ListItem Value="22">Walkie – Talkie License </asp:ListItem>
                                <asp:ListItem Value="23">Music Copyright License </asp:ListItem>
                                <asp:ListItem Value="24">Ammunition License </asp:ListItem>
                                <asp:ListItem Value="25">LPG License</asp:ListItem>
                                <asp:ListItem Value="26">Gas Notifications </asp:ListItem>
                                <asp:ListItem Value="27">Excise  Permit(Spa) </asp:ListItem>
                                <asp:ListItem Value="28">Artesian well Permit</asp:ListItem>
                                <asp:ListItem Value="29">Usage Ground Water License </asp:ListItem>
                                <asp:ListItem Value="30">Boiller License </asp:ListItem>
                                <asp:ListItem Value="31">Boiler notification </asp:ListItem>
                                <asp:ListItem Value="32">Energy Saving notification </asp:ListItem>
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
</table>
</asp:Content>
