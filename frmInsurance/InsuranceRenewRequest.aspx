<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuranceRenewRequest.aspx.cs" Inherits="onlineLegalWF.frmInsurance.InsuranceRenewRequest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Renew Insurance</title>
    <style type="text/css">
        .auto-style1 {
            width: 1000px;
        }
        .auto-style2 {
            width: 170px;
        }
        .auto-style3 {
            width: 400px;
            height: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-family:Tahoma; font-size:10pt;margin-top: 20px;">
    <table cellpadding="0" cellspacing="0" class="auto-style1">
        <tr>
            <td class="auto-style2">
                <label>Request No. </label>
            </td>
            <td colspan="3">
                <asp:Label ID="req_no" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <label>Document No.</label>
            </td>
            <td>
                <asp:TextBox ID="doc_no" runat="server" Width="500px"></asp:TextBox>
            </td>
            <td class="auto-style2">
                <label style="margin-left: 10px;">BU </label>
            </td>
            <td>
                <asp:DropDownList ID="ddl_bu" runat="server" Width="300px">
                    <asp:ListItem>-Please select-</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <label>Subject </label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="subject" runat="server" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                <label>To </label>
            </td>
            <td colspan="3">
                <asp:TextBox ID="to" runat="server" Width="500px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <label>Type of Request </label>
            </td>
            <td colspan="3">
                <asp:DropDownList ID="type_req" runat="server" Width="300px">
                    <asp:ListItem>-Please select-</asp:ListItem>
                    <asp:ListItem Value="02" Selected="True">Renew insurance</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <label for="purpose">วัตถุประสงค์</label><br />
                <asp:TextBox ID="purpose" TextMode="MultiLine" runat="server" CssClass="auto-style3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <label>ที่มาและเหตุผล</label><br />
                <asp:TextBox ID="background" TextMode="MultiLine" runat="server" CssClass="auto-style3"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <label>รายการ</label><br />
                <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" CellPadding="4" Font-Names="Tahoma" Font-Size="9pt" ForeColor="#333333" GridLines="None" Width="698px">
                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                    <Columns>
                        <asp:TemplateField HeaderText="No">
                            <ItemTemplate>
                                <asp:TextBox ID="gv1txtNo" Text='<%# Bind("No") %>'  runat="server" Font-Names="Tahoma" Font-Size="9pt" Width="60px"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="60px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Property Insured">
                            <ItemTemplate>
                                <asp:HiddenField ID="gv1txttop_ins_code" Value='<%# Bind("Top_Ins_Code") %>' runat="server" />
                                <asp:TextBox ID="gv1txtPropertyInsured" Text='<%# Bind("PropertyInsured") %>'  runat="server" Font-Names="Tahoma" Font-Size="9pt" Width="100px"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Indemnity Period">
                            <ItemTemplate>
                                <asp:TextBox ID="gv1txtIndemnityPeriod" Text='<%# Bind("IndemnityPeriod") %>' runat="server" Font-Names="Tahoma" Font-Size="9pt" Width="100px"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sum Insured">
                            <ItemTemplate>
                                <asp:TextBox ID="gv1txtSumInsured" Text='<%# Bind("SumInsured") %>' runat="server" Font-Names="Tahoma" Font-Size="9pt" Width="100px"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="130px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Start Date">
                            <ItemTemplate>
                                <asp:TextBox ID="gv1txtSdate" Text='<%# Bind("StartDate") %>' TextMode="Date" runat="server" Font-Names="Tahoma" Font-Size="9pt" Width="130px"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="End Date">
                            <ItemTemplate>
                                <asp:TextBox ID="gv1txtEdate" Text='<%# Bind("EndDate") %>' TextMode="Date" runat="server" Font-Names="Tahoma" Font-Size="9pt" Width="130px"></asp:TextBox>
                            </ItemTemplate>
                            <ItemStyle Width="100px" />
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
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:HiddenField ID="hidMode" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="auto-style2">
                &nbsp;
                </td>
            <td colspan="3">
                <asp:Button ID="btn_save" runat="server" Text="Save" Width="200px" OnClick="btn_save_Click" />
                &nbsp;&nbsp;<asp:Button ID="btn_gendocumnt" runat="server" Text="TestGenDocumnet" Width="200px" OnClick="btn_gendocumnt_Click" />

            </td>
        </tr>
    </table>
</div>
    </form>
</body>
</html>
