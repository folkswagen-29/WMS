<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucAssignment.ascx.cs" Inherits="onlineLegalWF.userControls.ucAssignment" %>
 <link href="../StyleSheet/CustomStyle.css" rel="stylesheet" type="text/css"/>
<style type="text/css">
    .auto-style3 {
        height: 42px;
    }
    .auto-style4 {
        margin-top: 2px;
        margin-left: 2px;
        font-family: Tahoma;
        font-size: 9pt;
        background-color: transparent;
    }
    .auto-style5 {
        height: 42px;
        width: 10px;
    }
    .auto-style6 {
        width: 10px;
    }
</style>

<asp:Panel ID="Panel1" runat="server" Height="400px">
    <table class="div0">
        <tr>
            <td colspan="6">
                <asp:Label ID="Label1" runat="server" Text="Task Assignment Update" CssClass="Text_500" Width="800px"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" CssClass="Label_sm" Text="Status" Width="200px"></asp:Label>
            </td>
            <td colspan="5">
                <asp:RadioButtonList ID="rdlAction" runat="server" CssClass="auto-style4" RepeatDirection="Horizontal">
                    <asp:ListItem Selected="True">In Progress</asp:ListItem>
                    <asp:ListItem>Reject</asp:ListItem>
                    <asp:ListItem>Pending</asp:ListItem>
                    <asp:ListItem>Complete</asp:ListItem>
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label2" runat="server" CssClass="Label_sm" Text="Assign To" Width="200px"></asp:Label>
            </td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3">
                <asp:DropDownList ID="ddlNameList" runat="server" CssClass="Label_sm">
                </asp:DropDownList>
            </td>
            <td class="auto-style5"></td>
            <td class="auto-style3"></td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style3">
                <asp:Label ID="Label3" runat="server" CssClass="Label_sm" Text="Detail" Width="200px"></asp:Label>
            </td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtTaskDesc" runat="server" Height="60px" TextMode="MultiLine" Width="600px" CssClass="Label_sm"></asp:TextBox>
            </td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
            <td class="auto-style3">&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>
                <asp:Panel ID="Panel2" runat="server">
                    <table class="w-100">
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" CssClass="btn_normal" Text="Update" Width="200px" />
                                <asp:Button ID="Button2" runat="server" CssClass="btn_normal" Text="Forward" Width="200px" />
                            </td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
            <td class="auto-style6">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="pTaskList" runat="server">
    <asp:Label ID="Label5" runat="server" Text="Historical Data" CssClass="Text_500" Width="800px"></asp:Label>
    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" Font-Names="Tahoma" Font-Size="10pt" ForeColor="#990033" ShowHeaderWhenEmpty="True" Width="1238px">
        <Columns>
            <asp:TemplateField HeaderText="No.">
                <ItemTemplate>
                    <asp:Label ID="gvNo" runat="server" Text='<%# Eval("no") %>' Font-Names="Tahoma" Font-Size="9pt"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="65px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Assign To">
                <ItemTemplate>
                    <asp:Label ID="gvAssignTo" runat="server" Text='<%# Eval("assignto") %>' Font-Names="Tahoma" Font-Size="9pt"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="150px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Detail">
                <ItemTemplate>
                    <asp:Label ID="gvDetail" runat="server" Text='<%# Eval("detail") %>' Font-Names="Tahoma" Font-Size="9pt"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Task Status">
                <ItemTemplate>
                    <asp:Label ID="gvTaskStatus" runat="server" Text='<%# Eval("taskstatus") %>' Font-Names="Tahoma" Font-Size="9pt"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="90px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Remark">
                <ItemTemplate>
                    <asp:Label ID="gvRemark" runat="server" Text='<%# Eval("remark") %>' Font-Names="Tahoma" Font-Size="9pt"></asp:Label>
                </ItemTemplate>
                <ItemStyle Width="200px" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Attachments">
                <ItemTemplate>
                    <asp:Panel ID="gvpAttachment" runat="server" Height="60px" ScrollBars="Vertical" Width="350px">
                    </asp:Panel>
                </ItemTemplate>
                <ItemStyle Width="300px" />
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="gvIbtnEdit" runat="server" Height="20px" ImageUrl="~/images/icon_edit.png" />
                    &nbsp;&nbsp;
                    <asp:ImageButton ID="gvIbtnDelete" runat="server" Height="20px" ImageUrl="~/images/icon_delete.png" />
                </ItemTemplate>
                <ItemStyle Width="200px" />
            </asp:TemplateField>
        </Columns>
        <HeaderStyle BackColor="#CCCCCC" Font-Bold="False" Font-Names="Tahoma" Font-Size="10pt" />
    </asp:GridView>
    <asp:HiddenField ID="hidPID" runat="server" />
</asp:Panel>


<p>
    &nbsp;</p>



