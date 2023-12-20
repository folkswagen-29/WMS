<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCommentlog.ascx.cs" Inherits="onlineLegalWF.userControls.ucCommentlog" %>

<link href="../StyleSheet/CustomStyle.css" rel="stylesheet" type="text/css"/>

<asp:Panel ID="Panel1" runat="server" CssClass="div_90">
    <table cellpadding="0" cellspacing="0" class="w-100">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="0" >
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" CssClass="Label_lg_blue" Text="Comment Logs"></asp:Label>
                        </td>
                        <td>&nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="comment" runat="server" CssClass="Text_600" TextMode="MultiLine" Height="90"></asp:TextBox>
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnSave" runat="server" CssClass="btn-group" OnClick="btnSave_Click" Text="Save" />
                        </td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                <br />
            </td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="3">
                <div>
                    <asp:GridView ID="commentGV" ShowHeader="false" UseAccessibleHeader="true" runat="server" CssClass="table w-100" GridLines="None" AutoGenerateColumns="false" EmptyDataText="No Comment Logs">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="gv1txtNo" Text='<%# Container.DataItemIndex + 1 %>' runat="server"></asp:Label>.
                                    <asp:Label ID="gv1txtComment" Text='<%# Eval("comment") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <label>By </label>
                                    <asp:Label ID="gv1txtCommentBy" Text='<%# Eval("by_login") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:Label ID="gv1txtCommentDate" Text='<%# Eval("created_datetime", "{0:dd/MM/yy}") %>' runat="server"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--<asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="DownloadLink" runat="server" Text='<%# Eval("attached_filename") %>' OnClick="DownloadData" CommandArgument='<%# Eval("attached_filepath") %>'></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="DeleteLink" runat="server" Text="Delete" OnClick="DeleteData" CommandArgument=' <%# Eval("attached_filepath") %>'><img src="/Images/icon_delete.png" height="20" /></asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>--%>

                        </Columns>
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <EditRowStyle BackColor="#999999" />
                        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#F9F9F3" ForeColor="#333333" />
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
    
</asp:Panel>
<br />


<asp:HiddenField ID="hidPID" runat="server" />