<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenulist.ascx.cs" Inherits="onlineLegalWF.userControls.ucMenulist" %>
   <link href="../StyleSheet/CustomStyle.css" rel="stylesheet" type="text/css"/>
<asp:Panel ID="pMenu" runat="server" Height="600px" CssClass="menu w-100">
    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" 
        Font-Names="tahoma" Font-Size="10pt" BorderStyle="None" BorderWidth="0px" 
        GridLines="None" ShowHeader="False"
        OnRowCommand="gv_RowCommand" 
        >
        <Columns>
            <asp:TemplateField HeaderText="MenuGroupIcon" ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="gvibtnMenuIcon" ImageUrl='<%# Bind("menu_icon_filename") %>' runat="server" CommandName="expandmenu" CommandArgument='<%# Container.DataItemIndex %>' Height="22px" />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="MenuName">
                <ItemTemplate>
                    <table cellpadding="0" cellspacing="0" class="w-100">
                        <tr>
                            <td>
                                <asp:LinkButton ID="gvlbtnMenu" runat="server" CommandArgument="<%# Container.DataItemIndex %>" CommandName="expandmenu" Font-Names="tahoma" Font-Size="10pt" ForeColor="Black" Text='<%# Bind("menu_group_name") %>' Font-Bold="True"></asp:LinkButton>
                                <asp:Label ID="gvlblMenuGroupName" runat="server" Text='<%# Bind("menu_group_name") %>' Visible="False">  </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                 <asp:GridView ID="gvA" runat="server" AutoGenerateColumns="False" 
                                    Font-Names="tahoma" Font-Size="10pt" BorderStyle="None" BorderWidth="0px" 
                                    GridLines="None" ShowHeader="False"
                                    OnRowCommand="gvA_RowCommand" 
                                    >
                                    <Columns>
                                        <asp:TemplateField HeaderText="MenuItemIcon" ShowHeader="False">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="gvAibtnMenuItemIcon" ImageUrl='<%# Bind("menu_icon_filename") %>' runat="server" CommandName="openprogram" CommandArgument='<%# Container.DataItemIndex %>' Height="22px" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MenuName">
                                            <ItemTemplate>
                                                <table cellpadding="0" cellspacing="0" class="w-100">
                                                    <tr>
                                                        <td>
                                                            <asp:LinkButton ID="gvAlbtnMenu" runat="server"  CommandArgument="<%# Container.DataItemIndex %>" CommandName="openprogram" Font-Names="tahoma" Font-Size="10pt" ForeColor="#333333" Text='<%# Bind("menu_name") %>'></asp:LinkButton>
                                                            <%# Eval("menu_name").ToString() == "Inbox" ? "<span id='inbox_notify' class='badge-notify'>0</span>" : "" %>
                                                            <asp:Label ID="gvAlblMenuCode" runat="server" Text='<%# Bind("menu_code") %>' Visible="False">  </asp:Label>
                                                            <asp:Label ID="gvAlblMenuUrl" runat="server" Text='<%# Bind("menu_url") %>' Visible="False">  </asp:Label>
                                                            <asp:Label ID="gvAlblMenuGroupName" runat="server" Text='<%# Bind("menu_group_name") %>' Visible="False">  </asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <ItemStyle Width="250px" HorizontalAlign="Left" VerticalAlign="Top" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </ItemTemplate>
                <ItemStyle Width="250px" HorizontalAlign="Left" VerticalAlign="Top" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Panel>

