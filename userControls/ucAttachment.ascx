<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAttachment.ascx.cs" Inherits="onlineLegalWF.userControls.ucAttachment" %>
<div>
    <table cellpadding="0" cellspacing="0" class="w-100">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0">
                    <tr id="seal_attach" runat="server">
                        <td>
                            <asp:Label ID="lblSecAttach" runat="server" CssClass="Label_lg_blue" Text="Attachments"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
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
                    <asp:GridView ID="fileGridview" ShowHeader="false" UseAccessibleHeader="true" runat="server" CssClass="table w-100" GridLines="None" AutoGenerateColumns="false" EmptyDataText="No Files Uploaded">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="gv1txtNo" Text='<%# Container.DataItemIndex + 1 %>' runat="server"></asp:Label>.
                                        <asp:Label ID="gv1txtFilename" Text='<%# Eval("attached_filename") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="DownloadLink" runat="server" Text='<%# Eval("attached_filename") %>' OnClick="DownloadData" CommandArgument='<%# Eval("attached_filepath") %>'></asp:LinkButton>
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

<div class="modal fade" id="modalattach" role="dialog" runat="server">
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
    function showModalAttach() {
        $("#modalattach").modal('show');
    }
</script>