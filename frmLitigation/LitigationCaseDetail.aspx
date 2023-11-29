<%@ Page Title="Case Detail" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="LitigationCaseDetail.aspx.cs" Inherits="onlineLegalWF.frmLitigation.LitigationCaseDetail" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>

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
                                <label class="Label_md">Case No. </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="case_no" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Court </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="court" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">City </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="city" runat="server" CssClass="Text_400"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">County </label>
                                        </td>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="county" runat="server" CssClass="Text_400"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Judge </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="judge" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Case Description </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="case_desc" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="100px"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Plaintiff </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="plaintiff" runat="server" CssClass="Text_400"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">Attorney </label>
                                        </td>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="plaintiff_attorney" runat="server" CssClass="Text_400"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Defendant </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="defendant" runat="server" CssClass="Text_400"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">Attorney </label>
                                        </td>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="defendant_attorney" runat="server" CssClass="Text_400"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Filing Date </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="filing_date" TextMode="Date" runat="server" CssClass="Text_400"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">Trial Date </label>
                                        </td>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="trial_date" TextMode="Date" runat="server" CssClass="Text_400"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Ref. Requet No. </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="ref_req_no" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Ref. Customer No. </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <table>
                                    <tr>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="ref_customer_no" runat="server" CssClass="Text_400"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">Ref. Customer Name </label>
                                        </td>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="ref_customer_name" runat="server" CssClass="Text_400"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Ref. Contract No </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="ref_contact_no" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="100px"></asp:TextBox>
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
                <asp:Button ID="btn_update" runat="server" CssClass="btn_normal_silver" Text="Update" />
                <asp:Button ID="btn_preview" runat="server" CssClass="btn_normal_silver" Text="Preview" />
            </td>

        </tr>
    </table>
</asp:Content>
