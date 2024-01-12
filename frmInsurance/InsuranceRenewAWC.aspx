<%@ Page Title="AWCRenewInusurance Memo" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="InsuranceRenewAWC.aspx.cs" Inherits="onlineLegalWF.frmInsurance.InsuranceRenewAWC" %>
<%@ Register Src="~/userControls/ucPersonSign.ascx" TagPrefix="uc1" TagName="ucPersonSign" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc2" TagName="ucHeader" %>
<%@ Register Src="~/userControls/ucAttachment.ascx" TagPrefix="uc3" TagName="ucAttachment" %>
<%@ Register Src="~/userControls/ucCommentlog.ascx" TagPrefix="uc4" TagName="ucCommentlog" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="cell_content_100PC">
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
                                <label class="Label_md">To </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="to" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Company </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="company_name" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Subject </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="subject" runat="server" CssClass="Text_600" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Description </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="description" runat="server" CssClass="Text_600" Height="150px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Summary Insured </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <table>
                                    <tr class="text_center">
                                        <td colspan="6">
                                            <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#333333" GridLines="None">
                                                <alternatingrowstyle backcolor="White" forecolor="#284775" />
                                                <columns>
                                                    <asp:TemplateField HeaderText="กลุ่มธุรกิจ">
                                                        <itemtemplate>
                                                            <asp:TextBox ID="gv1txtTYPE_PROP" Text='<%# Bind("TYPE_PROP") %>' runat="server" CssClass="Text_sm"></asp:TextBox>
                                                        </itemtemplate>
                                                        <itemstyle width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="IAR">
                                                        <itemtemplate>
                                                            <%--<asp:HiddenField ID="gv1txttop_ins_code" Value='<%# Bind("Top_Ins_Code") %>' runat="server" />--%>
                                                            <asp:TextBox ID="gv1txtIAR" Text='<%# Bind("IAR") %>' runat="server" CssClass="Text_sm"></asp:TextBox>
                                                        </itemtemplate>
                                                        <itemstyle width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="BI">
                                                        <itemtemplate>
                                                            <asp:TextBox ID="gv1txtBI" Text='<%# Bind("BI") %>' runat="server" CssClass="Text_sm"></asp:TextBox>
                                                        </itemtemplate>
                                                        <itemstyle width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="CGL_PL">
                                                        <itemtemplate>
                                                            <asp:TextBox ID="gv1txtCGL_PL" Text='<%# Bind("CGL_PL") %>' runat="server" CssClass="Text_sm"></asp:TextBox>
                                                        </itemtemplate>
                                                        <itemstyle width="130px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="PV">
                                                        <itemtemplate>
                                                            <asp:TextBox ID="gv1txtPV" Text='<%# Bind("PV") %>' runat="server" CssClass="Text_sm"></asp:TextBox>
                                                        </itemtemplate>
                                                        <itemstyle width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="LPG">
                                                        <itemtemplate>
                                                            <asp:TextBox ID="gv1txtLPG" Text='<%# Bind("LPG") %>' runat="server" CssClass="Text_sm"></asp:TextBox>
                                                        </itemtemplate>
                                                        <itemstyle width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="D_O">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="gv1txtD_O" Text='<%# Bind("D_O") %>' runat="server" CssClass="Text_sm"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateField>
                                                </columns>
                                                <editrowstyle backcolor="#999999" />
                                                <footerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
                                                <headerstyle backcolor="#5D7B9D" font-bold="True" forecolor="White" />
                                                <pagerstyle backcolor="#284775" forecolor="White" horizontalalign="Center" />
                                                <rowstyle backcolor="#F7F6F3" forecolor="#333333" />
                                                <selectedrowstyle backcolor="#E2DED6" font-bold="True" forecolor="#333333" />
                                                <sortedascendingcellstyle backcolor="#E9E7E2" />
                                                <sortedascendingheaderstyle backcolor="#506C8C" />
                                                <sorteddescendingcellstyle backcolor="#FFFDF8" />
                                                <sorteddescendingheaderstyle backcolor="#6F8DAE" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
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
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="สนับสนุนโดย"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Text="สนับสนุนโดย"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc1:ucPersonSign runat="server" ID="ucPersonSign1" />
                            </td>
                            <td>
                                <uc1:ucPersonSign runat="server" ID="ucPersonSign2" />
                            </td>
                            <td>
                                <uc1:ucPersonSign runat="server" ID="ucPersonSign3" />
                            </td>
                            <td>
                                <uc1:ucPersonSign runat="server" ID="ucPersonSign4" />
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
                <asp:Button ID="btn_cancel" runat="server" CssClass="btn_normal_silver" Text="Cancel" OnClientClick="JavaScript:window.history.back(1); return false;" />
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
    <asp:HiddenField ID="hid_PID" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblPID" runat="server" CssClass="Label_sm"></asp:Label>
</asp:Content>
