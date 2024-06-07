﻿<%@ Page Title="Tracking Renew" Language="C#" MasterPageFile="SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="InsuranceTrackingRenew.aspx.cs" Inherits="WMS.frmInsurance.InsuranceTrackingRenew" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc2" TagName="ucHeader" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="cell_content_100PC">
        <tr>
            <td colspan="2">
                <div style="background-color: gainsboro;">
                    <uc2:ucHeader runat="server" ID="ucHeader1" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="div_90">
                    <asp:ListView ID="ListView1" runat="server">
                        <LayoutTemplate>
                            <table id="itemPlaceholderContainer" runat="server" class="table">
                                <tr class="gv_header_blue" style="height: 30px;">
                                    <th><asp:CheckBox ID="chkHeader" runat="server" AutoPostBack="true" OnCheckedChanged="CheckAll" /></th>
                                    <th>Type</th>
                                    <th>Bussiness Group/BU</th>
                                    <th>Status</th>
                                    <th>Submitted Date</th>
                                    <th>IAR</th>
                                    <th>BI</th>
                                    <th>CGL($)</th>
                                    <th>PL</th>
                                    <th>PV</th>
                                    <th>LPG</th>
                                    <th>D&O</th>
                                    <%--<th></th>--%>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                    <asp:HiddenField ID="req_no" Value='<%# Eval("RequestNo") %>' runat="server" />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%# Eval("Type") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%# Eval("BuName") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%# Eval("Status") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%# Eval("RequestDate") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%# Eval("IARSumInsured") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%# Eval("BISumInsured") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%# Eval("CGLSumInsured") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%# Eval("PLSumInsured") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%# Eval("PVSumInsured") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%# Eval("LPGSumInsured") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%# Eval("DOSumInsured") %>' />
                                </td>
                                <%--<td>
                                    <table style="color: #333333; border-collapse: collapse;">
                                        <tr>
                                            <td style="border: 0px !important;">
                                                <asp:ImageButton ID="btn_Edit" runat="server" Height="35px" ImageUrl="~/images/icon_edit.png" />
                                            </td>
                                            <td style="border: 0px !important;">
                                                <asp:ImageButton ID="btn_Delete" runat="server" Height="35px" ImageUrl="~/images/icon_delete.png" />
                                            </td>
                                            <td style="border: 0px !important;">
                                                <asp:Button runat="server" CssClass="btn_small_red pointer" Text="Reject" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>--%>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                    <br />
                    <div>
                        <asp:Button runat="server" CssClass="btn_normal_blue pointer" Text="GenMemo" OnClick="Approve_Click" />
                        <%--<asp:Button runat="server" CssClass="btn_normal_silver pointer" Text="Preview" />--%>
                    </div>
                </div>
            </td>
        </tr>
    </table>
    
</asp:Content>
