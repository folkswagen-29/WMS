<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLitigationCaseAttachment.ascx.cs" Inherits="onlineLegalWF.userControls.ucLitigationCaseAttachment" %>
<div>
    <table cellpadding="0" cellspacing="0" class="w-100">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0">
                    <tr>
                        <td class="cell_content_20PC_TR">
                            <label class="Label_md">รหัสลูกค้า : </label>
                        </td>
                        <td class="cell_content_80PC_TL">
                            <asp:Label ID="customer_no" runat="server" CssClass="Label_md"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="cell_content_20PC_TR">
                            <label class="Label_md">ชื่อ : </label>
                        </td>
                        <td class="cell_content_80PC_TL">
                            <asp:Label ID="customer_name" runat="server" CssClass="Label_md"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="cell_content_20PC_TR">
                            <label class="Label_md">สัญญาเลขที่ : </label>
                        </td>
                        <td class="cell_content_80PC_TL">
                            <asp:Label ID="contract_no" runat="server" CssClass="Label_md"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="cell_content_20PC_TR">
                            <label class="Label_md">ประเภทเอกสาร </label>
                        </td>
                        <td class="cell_content_80PC_TL">
                            <asp:DropDownList ID="type_doc" runat="server" CssClass="Text_200">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="cell_content_20PC_TR">
                            <label class="Label_md">หมายเหตุ : </label>
                        </td>
                        <td class="cell_content_80PC_TL">
                            <asp:Textbox ID="note" runat="server" TextMode="MultiLine" CssClass="Text_200"></asp:Textbox>
                        </td>
                    </tr>
                    <tr>
                        <td id="lbltitleAttach" runat="server">
                            <asp:Label ID="Label1" runat="server" CssClass="Label_md" Text="Please select and input file"></asp:Label>
                            &nbsp;
                        </td>
                        <td>
                            <asp:FileUpload ID="FileUpload1" runat="server" accept=".pdf" />
                        </td>
                        <td>
                            <asp:Button ID="btnUpload" runat="server" CssClass="btn-group" OnClick="btnUpload_Click" Text="Upload" />
                        </td>
                    </tr>
                </table>
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <div>
                    <asp:GridView ID="fileGridview" UseAccessibleHeader="true" runat="server" CssClass="table w-100" Font-Names="Tahoma" Font-Size="9pt" GridLines="None" AutoGenerateColumns="false" EmptyDataText="No Files Uploaded">
                        <Columns>
                            <asp:TemplateField HeaderText="ประเภทเอกสาร">
                                <ItemTemplate>
                                    <asp:Label ID="gv1txtNo" Text='<%# Container.DataItemIndex + 1 %>' runat="server"></asp:Label>.
                                    <asp:Label ID="gv1txtDocType" Text='<%# Eval("lit_type_doc_desc") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="เอกสาร">
                                <ItemTemplate>
                                    <asp:LinkButton ID="DownloadLink" runat="server" Text='<%# Eval("attached_filename") %>' OnClick="DownloadData" CommandArgument='<%# Eval("attached_filepath") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="วันที่อัพโหลด">
                                <ItemTemplate>
                                    <asp:Label ID="gv1txtUploaddate" runat="server" Text='<%# Bind("created_datetime" , "{0:dd/MM/yy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="หมายเหตุ">
                                <ItemTemplate>
                                    <asp:Label ID="gv1txtNote" runat="server" Text='<%# Bind("note") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteLink" runat="server" Text="Delete" OnClick="DeleteData" CommandArgument=' <%# Eval("attached_filepath") %>'><img src="../Images/icon_delete.png" height="20" /></asp:LinkButton>
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

                </div>
            </td>
        </tr>
    </table>
</div>

<asp:HiddenField ID="hidPID" runat="server" />
<asp:HiddenField ID="eformID" runat="server" />
<asp:HiddenField ID="eformSecNo" runat="server" />
<asp:HiddenField ID="hid_caseNo" runat="server" />

<div class="modal fade" id="modalattachlit" role="dialog">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header" style="border: 0;">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
            </div>
            <div class="modal-body">
                <iframe id="pdf_render_liti" runat="server" width="865" height="600" frameborder="0"></iframe>
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
        function showModalAttachLitigation() {
            $("#modalattachlit").modal('show');
        }
</script>