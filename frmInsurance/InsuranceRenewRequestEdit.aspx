<%@ Page Title="Edit Renew Request" Language="C#" MasterPageFile="SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="InsuranceRenewRequestEdit.aspx.cs" Inherits="onlineLegalWF.frmInsurance.InsuranceRenewRequestEdit" %>
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
                                    <asp:ListItem Value="02" Selected="True">Renew insurance</asp:ListItem>
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
                                <asp:TextBox ID="company_name" runat="server" CssClass="Text_400"></asp:TextBox>
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
                                <label class="Label_md">BU </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:DropDownList ID="ddl_bu" runat="server" CssClass="Text_200">
                                    <asp:ListItem>-Please select-</asp:ListItem>
                                </asp:DropDownList>
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
                                        <td>
                                            <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#333333" GridLines="None">
                                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="No">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="gv1txtNo" Text='<%# Bind("No") %>' runat="server" CssClass="Text_60"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="60px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Property Insured">
                                                        <ItemTemplate>
                                                            <asp:HiddenField ID="gv1txttop_ins_code" Value='<%# Bind("Top_Ins_Code") %>' runat="server" />
                                                            <asp:TextBox ID="gv1txtPropertyInsured" Text='<%# Bind("PropertyInsured") %>' runat="server" CssClass="Text_sm"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Indemnity Period">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="gv1txtIndemnityPeriod" Text='<%# Bind("IndemnityPeriod") %>' runat="server" CssClass="Text_sm"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Sum Insured">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="gv1txtSumInsured" Text='<%# Bind("SumInsured") %>' runat="server" CssClass="Text_sm"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="130px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Start Date">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="gv1txtSdate" Text='<%# Bind("StartDate") %>' TextMode="Date" runat="server" CssClass="Text_sm"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="End Date">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="gv1txtEdate" Text='<%# Bind("EndDate") %>' TextMode="Date" runat="server" CssClass="Text_sm"></asp:TextBox>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="100px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <EditRowStyle BackColor="#999999" />
                                                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
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
                <%--<asp:Button ID="btn_cancel" runat="server" CssClass="btn_normal_silver" Text="Cancel" />--%>
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
    <asp:HiddenField ID="req_date" runat="server" />
    <asp:HiddenField ID="hid_PID" runat="server" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Label ID="lblPID" runat="server" CssClass="Label_sm"></asp:Label>
</asp:Content>
