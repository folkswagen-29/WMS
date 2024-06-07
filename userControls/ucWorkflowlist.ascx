<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucWorkflowlist.ascx.cs" Inherits="WMS.userControls.ucWorkflowlist" %>
<%--<asp:ScriptManager runat="server">
    <Scripts>
        <asp:ScriptReference Name="jquery" />
        <asp:ScriptReference Name="bootstrap" />
    </Scripts>
</asp:ScriptManager>--%>
<div style="font-family:Tahoma;font-size:10pt;">
    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" CssClass="w-100 table">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:TemplateField HeaderText="No.">
                <ItemTemplate>
                    <asp:Label ID="gv1lblNo" Text='<%# Bind("No") %>' runat="server" Font-Names="Tahoma" Font-Size="9pt"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="45px" Height="35px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Process ID">
                <ItemTemplate>
                    <asp:Label ID="gv1lblProcessID" Text='<%# Bind("ProcessID") %>' runat="server" Font-Names="Tahoma" Font-Size="9pt"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="80px" Height="35px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Process Name">
                <ItemTemplate>
                    <asp:Label ID="gv1lblProcessName" Text='<%# Bind("ProcessName") %>' runat="server" Font-Names="Tahoma" Font-Size="9pt"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="100px" Height="35px"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Subject">
                <ItemTemplate>
                    <asp:Label ID="gv1lblSubject" Text='<%# Bind("Subject") %>' runat="server" Font-Names="Tahoma" Font-Size="9pt"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="180px" Height="35px"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Requested Date">
                <ItemTemplate>
                    <asp:Label ID="gv1lblRequestedDate" Text='<%# Bind("RequestedDate") %>' runat="server" Font-Names="Tahoma" Font-Size="9pt"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="100px" Height="35px"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Submitted Date">
                <ItemTemplate>
                    <asp:Label ID="gv1lblSubmittedDate" Text='<%# Bind("SubmittedDate") %>' runat="server" Font-Names="Tahoma" Font-Size="9pt"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="100px" Height="35px"/>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                    <asp:Label ID="gv1lblStatus" Text='<%# Bind("Status") %>' runat="server" Font-Names="Tahoma" Font-Size="9pt"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="150px" Height="35px"/>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <table >
                        <tr>
                            <td>
                                <asp:ImageButton ID="ImageButton1" runat="server" Height="35px" ImageUrl="~/images/icon_edit.png" />
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton2" runat="server" Height="35px" ImageUrl="~/images/icon_delete.png" />
                            </td>
                              <td>
                                <asp:ImageButton ID="ImageButton3" runat="server" Height="35px" ImageUrl="~/images/icon_assign_job.png" OnClick="Assign_Click" />

                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="150px" Height="35px"/>
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
</div>

<asp:HiddenField ID="hidMode" runat="server" />

<div class="modal fade" id="myModal" role="dialog">
    <div class="modal-dialog">
        <div class="modal-content">
            <div class="modal-header" style="border: 0;">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <h4 class="modal-title">Modal Assign</h4>
            </div>
            <div class="modal-body">
                <%--<table>
                    <tr>
                        <td class="cell_content_20PC_TR">
                            <label class="Label_md">Process ID : </label>
                        </td>
                        <td class="cell_content_80PC_TL">
                            <asp:Label ID="process_id" runat="server" Text="xxxx"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="cell_content_20PC_TR">
                            <label class="Label_md">Subject : </label>
                        </td>
                        <td class="cell_content_80PC_TL">
                            <asp:Label ID="subject" runat="server" Text="xxxx"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="cell_content_20PC_TR">
                            <label class="Label_md">Request By : </label>
                        </td>
                        <td class="cell_content_80PC_TL">
                            <asp:Label ID="req_by" runat="server" Text="xxxxx"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="cell_content_20PC_TR">
                            <label class="Label_md">Submitted Date : </label>
                        </td>
                        <td class="cell_content_80PC_TL">
                            <asp:Label ID="submitted_date" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <label class="Label_md">Please select staff to assign </label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:TextBox ID="assign_name" runat="server" CssClass="Text_200"></asp:TextBox>&nbsp; 
                            <asp:Image ImageUrl="~/images/icon_assign_job.png" runat="server" />
                        </td>
                    </tr>
                </table>--%>
                <div>
                    <label class="Label_md">Process ID : </label> <asp:Label ID="process_id" class="Label_md" runat="server" Text="xxxx"></asp:Label><br />
                    <label class="Label_md">Subject : </label> <asp:Label ID="subject" class="Label_md" runat="server" Text="xxxx"></asp:Label><br />
                    <label class="Label_md">Request By : </label> <asp:Label ID="reg_by" class="Label_md" runat="server" Text="xxxx"></asp:Label><br />
                    <label class="Label_md">Submitted Date : </label> <asp:Label ID="submitted_date" class="Label_md" runat="server" Text="xxxx"></asp:Label><br />
                    <br /><label class="Label_md">Please select staff to assign </label>
                    <div>
                        <asp:TextBox ID="assign_name" class="Label_md" runat="server" CssClass="Text_200"></asp:TextBox>&nbsp; 
                        <asp:Image ImageUrl="~/images/icon_assign_job.png" Height="30px" runat="server" />
                    </div>
                    
                </div>
                
            </div>
            <div class="modal-footer" style="text-align: left; border-top: 0;">
                <asp:Button runat="server" Text="Assign" CssClass="btn_normal_blue" />
            </div>
        </div>
    </div>
</div>

<script type="text/javascript">
        function showModal() {
            $("#myModal").modal('show');
        }

        $(function () {
            $("#btnShow").click(function () {
                showModal();
            });
        });
</script>