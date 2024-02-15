<%@ Page Title="Renew Request" Async="true" Language="C#" MasterPageFile="SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="InsuranceRenewRequest.aspx.cs" Inherits="onlineLegalWF.frmInsurance.InsuranceRenewRequest" %>
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
                                <asp:DropDownList ID="type_req" runat="server" CssClass="Text_200">
                                    <asp:ListItem Value="07" Selected="True">Renew insurance</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">BU </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:DropDownList ID="ddl_bu" runat="server" CssClass="Text_200" OnSelectedIndexChanged="ddl_bu_Changed" AutoPostBack="true">
                                    <asp:ListItem>-Please select-</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Company </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="company_name" runat="server" CssClass="Text_600" Enabled="false"></asp:TextBox>
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
                                <label class="Label_md">Purpose </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="purpose" runat="server" CssClass="Text_600" Height="150px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Background </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="background" runat="server" CssClass="Text_600" Height="150px" TextMode="MultiLine"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Property Insured Name </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="prop_ins_name" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">List Insured </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <table>
                                    <tr class="text_center">
                                        <td colspan="6">
                                            <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#333333" GridLines="None">
                                                <alternatingrowstyle backcolor="White" forecolor="#284775" />
                                                <columns>
                                                    <asp:TemplateField HeaderText="No">
                                                        <itemtemplate>
                                                            <asp:TextBox ID="gv1txtNo" Text='<%# Bind("No") %>' runat="server" CssClass="Text_20"></asp:TextBox>
                                                        </itemtemplate>
                                                        <itemstyle width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Property Insured">
                                                        <itemtemplate>
                                                            <asp:HiddenField ID="gv1txttop_ins_code" Value='<%# Bind("Top_Ins_Code") %>' runat="server" />
                                                            <asp:TextBox ID="gv1txtPropertyInsured" Text='<%# Bind("PropertyInsured") %>' runat="server" CssClass="Text_sm"></asp:TextBox>
                                                        </itemtemplate>
                                                        <itemstyle width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="GOP">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="gv1txtGop" Text='<%# Bind("GOP") %>' runat="server" CssClass="Text_sm" OnTextChanged="GopChanged" AutoPostBack="true"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Indemnity Period">
                                                        <itemtemplate>
                                                            <asp:TextBox ID="gv1txtIndemnityPeriod" Text='<%# Bind("IndemnityPeriod") %>' runat="server" CssClass="Text_sm" OnTextChanged="IndemnityPeriodChanged" AutoPostBack="true"></asp:TextBox>
                                                        </itemtemplate>
                                                        <itemstyle width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sum Insured">
                                                        <itemtemplate>
                                                            <asp:TextBox ID="gv1txtSumInsured" Text='<%# Bind("SumInsured") %>' runat="server" CssClass="Text_sm"></asp:TextBox>
                                                        </itemtemplate>
                                                        <itemstyle width="130px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Start Date">
                                                        <itemtemplate>
                                                            <asp:TextBox ID="gv1txtSdate" Text='<%# Bind("StartDate") %>' TextMode="Date" runat="server" CssClass="Text_sm"></asp:TextBox>
                                                        </itemtemplate>
                                                        <itemstyle width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="End Date">
                                                        <itemtemplate>
                                                            <asp:TextBox ID="gv1txtEdate" Text='<%# Bind("EndDate") %>' TextMode="Date" runat="server" CssClass="Text_sm"></asp:TextBox>
                                                        </itemtemplate>
                                                        <itemstyle width="100px" />
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
        <%--<tr class="cell_content_100PC">
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

        </tr>--%>

        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <asp:Button ID="btn_save" runat="server" CssClass="btn_normal_silver" Text="Save" OnClick="btn_save_Click" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" />
                <asp:Button ID="btn_submit" runat="server" CssClass="btn_normal_silver" Text="Submit" OnClick="btn_submit_Click" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" />
                <asp:Button ID="btn_gendocumnt" runat="server" CssClass="btn_normal_silver" Text="Preview" OnClick="btn_gendocumnt_Click" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" />
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
