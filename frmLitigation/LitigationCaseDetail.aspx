<%@ Page Title="Case Detail" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="LitigationCaseDetail.aspx.cs" Inherits="onlineLegalWF.frmLitigation.LitigationCaseDetail" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Table ID="tb_main" runat="server" CssClass="cell_content_100PC">
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <div style="background-color: gainsboro;">
                    <uc1:ucHeader runat="server" ID="ucHeader1" />
                </div>

            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow CssClass="cell_content_100PC">
            <asp:TableCell ColumnSpan="2" CssClass="cell_content_100PC">
                <asp:Panel ID="Panel1" runat="server" CssClass="div_90">
                    <table>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Case No. </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:Label ID="case_no" runat="server" CssClass="Label_md"></asp:Label>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Court </label>
                            </td>
                            <td>&nbsp;</td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="court" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                            <asp:TextBox ID="city" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">County </label>
                                        </td>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="county" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                <asp:TextBox ID="judge" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                            <asp:TextBox ID="plaintiff" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">Attorney </label>
                                        </td>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="plaintiff_attorney" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                            <asp:TextBox ID="defendant" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">Attorney </label>
                                        </td>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="defendant_attorney" runat="server" CssClass="Text_200"></asp:TextBox>
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
                                            <asp:TextBox ID="filing_date" TextMode="Date" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                        <td class="cell_content_PC_TL">
                                            <label class="Label_md">Trial Date </label>
                                        </td>
                                        <td class="cell_content_40PC_TL">
                                            <asp:TextBox ID="trial_date" TextMode="Date" runat="server" CssClass="Text_200"></asp:TextBox>
                                        </td>
                                        <td>&nbsp;</td>
                                    </tr>
                                </table>
                            </td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
                <br />
            </asp:TableCell>
        </asp:TableRow>
        
        <asp:TableRow CssClass="cell_content_100PC">
            <asp:TableCell ColumnSpan="2" CssClass="cell_content_100PC">
                <asp:Button ID="btn_update" runat="server" CssClass="btn_normal_blue" Text="Update" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" OnClick="btn_update_Click" />
                <asp:Button ID="btn_task" runat="server" CssClass="btn_normal_blue" Text="TaskLog" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" OnClick="btn_task_Click" />
                
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow ID="section_task" Visible="false" runat="server" CssClass="cell_content_100PC">
            <asp:TableCell ColumnSpan="2" CssClass="cell_content_100PC">
                <br />
                <asp:Panel ID="Panel2" runat="server" CssClass="div_90">
                    <asp:Table ID="Table1" runat="server" CssClass="cell_content_100PC">
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="4">
                                <asp:GridView ID="gvTask" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#333333" GridLines="None" CssClass="table w-100">
                                    <Columns>
                                        <asp:TemplateField HeaderText="No">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_no" Text='<%# Bind("no") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                            <ItemStyle Width="20px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Task">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_task" Text='<%# Bind("task") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Res.By">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_res_by" Text='<%# Bind("res_by") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Plan Date">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_plan_date" Text='<%# Bind("plan_date", "{0:dd/MM/yy}") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Plan">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_plan_desc" Text='<%# Bind("plan_desc") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Actual Date">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_actual_date" Text='<%# Bind("actual_date", "{0:dd/MM/yy}") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Actual">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_actual_desc" Text='<%# Bind("actual_desc") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_status" Text='<%# Bind("status") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Next Action">
                                            <ItemTemplate>
                                                <asp:Label ID="gv_nextaction_desc" Text='<%# Bind("nextaction_desc") %>' runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
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
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </asp:Panel>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <asp:HiddenField ID="hid_case_no" runat="server" />

    <div class="modal fade" id="editDataModal" role="dialog" style="">
        <div class="modal-dialog modal-lg">
            <div class="modal-content">
                <div class="modal-header" style="border: 0;">
                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                    <h4 class="modal-title" style="font-family: tahoma;">Modal Task</h4>
                </div>
                <div class="modal-body" style="font-size: 10pt; font-family: tahoma;">
                    <asp:HiddenField ID="md_req_no" runat="server" />
                    <table>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Task : </label>
                            </td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="task" runat="server" CssClass="Text_400"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Res.By : </label>
                            </td>
                            <td class="cell_content_80PC_TL">
                                <asp:DropDownList ID="ddlResbyList" runat="server" CssClass="Text_200">
                                    <asp:ListItem Value="supoj.k">supoj.k</asp:ListItem>
                                    <asp:ListItem Value="peeranat.u">peeranat.u</asp:ListItem>
                                    <asp:ListItem Value="nuttanun.su">nuttanun.su</asp:ListItem>
                                    <asp:ListItem Value="supat.ku">supat.ku</asp:ListItem>
                                    <asp:ListItem Value="wiwek.s">wiwek.s</asp:ListItem>
                                    <asp:ListItem Value="phooriwit.l">phooriwit.l</asp:ListItem>
                                    <asp:ListItem Value="nares.l">nares.l</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Plan Date : </label>
                            </td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="plan_date" TextMode="Date" runat="server" CssClass="Text_200"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Plan Description : </label>
                            </td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="plan_desc" runat="server" TextMode="MultiLine" CssClass="Text_400"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Actual Date : </label>
                            </td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="actual_date" TextMode="Date" runat="server" CssClass="Text_200"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Actual Description : </label>
                            </td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="actual_desc" runat="server" TextMode="MultiLine" CssClass="Text_400"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Status : </label>
                            </td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="status" runat="server" CssClass="Text_200"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="cell_content_20PC_TR">
                                <label class="Label_md">Next Action : </label>
                            </td>
                            <td class="cell_content_80PC_TL">
                                <asp:TextBox ID="nextaction_desc" runat="server" TextMode="MultiLine" CssClass="Text_400"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="modal-footer" style="text-align: left; border-top: 0;">
                    <asp:Button ID="btn_update_task" runat="server" Text="Update" CssClass="btn_normal_blue" OnClientClick="this.disabled = true;" UseSubmitBehavior="false" OnClick="btn_update_task_Click" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        function showModalEditData() {
            $("#editDataModal").modal('show');
        }
    </script>
</asp:Content>
