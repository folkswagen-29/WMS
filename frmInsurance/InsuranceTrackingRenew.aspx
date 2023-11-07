<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuranceTrackingRenew.aspx.cs" Inherits="onlineLegalWF.frmInsurance.InsuranceTrackingRenew" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>InsuranceTrackingRenew</title>
    <link href="../StyleSheet/CustomStyle.css" rel="stylesheet" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ListView ID="ListView1" runat="server">
                <LayoutTemplate>
                    <table id="itemPlaceholderContainer" runat="server" class="table">
                        <tr class="table_header_grey_centermiddle" style="height: 30px;">
                            <td></td>
                            <td>No.</td>
                            <td>Bussiness Group/BU</td>
                            <td>Status</td>
                            <td>Submitted Date</td>
                            <td>IAR</td>
                            <td>BI</td>
                            <td>CGL/PL</td>
                            <td>PV</td>
                            <td>LPG</td>
                            <td>D&O</td>
                            <td></td>
                        </tr>
                        <tr id="itemPlaceholder" runat="server">
                        </tr>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:CheckBox ID="CheckBox1" runat="server" />
                            <%--<asp:HiddenField ID="req_date" runat="server" />--%>
                            <asp:HiddenField ID="req_no" Value='<%# Eval("RequestNo") %>' runat="server" />
                        </td>
                        <td>
                            <asp:Label runat="server" Text='<%# Eval("ProcressID") %>' />
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
                            <asp:Label runat="server" Text='<%# Eval("CGLPLSumInsured") %>' />
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
                        <td>
                            <div>
                                <asp:Button runat="server" CssClass="pointer" Text="Edit" />
                                <asp:Button runat="server" CssClass="pointer" Text="Delete" />
                                <asp:Button runat="server" CssClass="btn_small_red pointer" Text="Reject" />
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:ListView>
            <br />
            <div>
                <asp:Button runat="server" CssClass="btn_normal_blue pointer" Text="Approve" OnClick="Approve_Click" />
                <asp:Button runat="server" CssClass="btn_normal_silver pointer" Text="Preview" />
            </div>
        </div>
    </form>
</body>
</html>
