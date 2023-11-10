<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuranceRequest.aspx.cs" Inherits="onlineLegalWF.frmInsurance.InsuranceRequest" %>
<%@ Register Src="~/userControls/ucPersonSign.ascx" TagPrefix="uc1" TagName="ucPersonSign" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>InsuranceRequest</title>
    <link href="../StyleSheet/CustomStyle.css" rel="stylesheet" type="text/css" />
    <metaviewport name="viewport" content="width=device-width, initial-scale=1.0">
</head>
<body>
    <form id="form1" runat="server">
        <div class="div1">
            <br />
            <table class="cell_content_100PC">
                <tr class="cell_content_100PC">
                    <td colspan="2" class="cell_content_100PC">
                          <asp:Panel ID="Panel1" runat="server" CssClass="div_90">
                              <table>
                                  <tr>
                                      <td class="cell_content_20PC_TR">
                                          <label class="Label_md">Request No. </label>
                                      </td>
                                      <td>&nbsp;</td>
                                      <td class="cell_content_80PC_TL">
                                          <asp:Label ID="req_no" runat="server" Text=""></asp:Label>
                                      </td>
                                      <td>&nbsp;</td>
                                  </tr>
                                  <tr>
                                      <td class="cell_content_20PC_TR">
                                          <label class="Label_md">Type of Request </label>
                                      </td>
                                      <td>&nbsp;</td>
                                      <td class="cell_content_80PC_TL">
                                          <asp:DropDownList ID="type_req" runat="server" CssClass="Text_200">
                                              <%--<asp:ListItem>-Please select-</asp:ListItem>
                                            <asp:ListItem Value="01" Selected="True">ขอประกันภัยใหม่ เพิ่มทุน, ยกเลิก</asp:ListItem>
                                            <asp:ListItem Value="02">ขอต่ออายุประกันภัย</asp:ListItem>--%>
                                          </asp:DropDownList>
                                      </td>
                                      <td>&nbsp;</td>
                                  </tr>
                                  <tr>
                                      <td class="cell_content_20PC_TR">
                                          <label class="Label_md">Company </label>
                                      </td>
                                      <td>&nbsp;</td>
                                      <td class="cell_content_80PC_TL">
                                          <asp:TextBox ID="company" runat="server" CssClass="Text_400"></asp:TextBox>
                                      </td>
                                      <td>&nbsp;</td>
                                  </tr>
                                  <tr>
                                      <td class="cell_content_20PC_TR">
                                          <label class="Label_md">Documnet No. </label>
                                      </td>
                                      <td>&nbsp;</td>
                                      <td class="cell_content_80PC_TL">
                                          <asp:TextBox ID="doc_no" runat="server" CssClass="Text_400"></asp:TextBox>
                                      </td>
                                      <td>&nbsp;</td>
                                  </tr>
                                  <tr>
                                      <td class="cell_content_20PC_TR">
                                          <label class="Label_md">BU </label>
                                      </td>
                                      <td>&nbsp;</td>
                                      <td class="cell_content_80PC_TL">
                                          <asp:DropDownList ID="ddl_bu" runat="server" CssClass="Text_200">
                                              <asp:ListItem>-Please select-</asp:ListItem>
                                          </asp:DropDownList>
                                      </td>
                                      <td>&nbsp;</td>
                                  </tr>
                                  <tr>
                                      <td class="cell_content_20PC_TR">
                                          <label class="Label_md">Subject </label>
                                      </td>
                                      <td>&nbsp;</td>
                                      <td class="cell_content_80PC_TL">
                                          <asp:TextBox ID="subject" runat="server" CssClass="Text_800" TextMode="MultiLine"></asp:TextBox>
                                      </td>
                                      <td>&nbsp;</td>
                                  </tr>
                                  <tr>
                                      <td class="cell_content_20PC_TR">
                                          <label class="Label_md">To </label>
                                      </td>
                                      <td>&nbsp;</td>
                                      <td class="cell_content_80PC_TL">
                                          <asp:TextBox ID="to" runat="server" CssClass="Text_400"></asp:TextBox>
                                      </td>
                                      <td>&nbsp;</td>
                                  </tr>
                                  <tr>
                                      <td class="cell_content_20PC_TR">
                                          <label class="Label_md">Purpose </label>
                                      </td>
                                      <td>&nbsp;</td>
                                      <td class="cell_content_80PC_TL">
                                          <asp:TextBox ID="purpose" runat="server" CssClass="Text_800" Height="150px" TextMode="MultiLine"></asp:TextBox>
                                      </td>
                                      <td>&nbsp;</td>
                                  </tr>
                                  <tr>
                                      <td class="cell_content_20PC_TR">
                                          <label class="Label_md">Background </label>
                                      </td>
                                      <td>&nbsp;</td>
                                      <td class="cell_content_80PC_TL">
                                          <asp:TextBox ID="background" runat="server" CssClass="Text_800" Height="150px" TextMode="MultiLine"></asp:TextBox>
                                      </td>
                                      <td>&nbsp;</td>
                                  </tr>
                                  <tr>
                                      <td class="cell_content_20PC_TR">
                                          <label class="Label_md">Type of Property Insured </label>
                                      </td>
                                      <td>&nbsp;</td>
                                      <td class="cell_content_80PC_TL">
                                          <asp:DropDownList ID="type_pi" runat="server" CssClass="Text_400">
                                          </asp:DropDownList>
                                      </td>
                                      <td>&nbsp;</td>
                                  </tr>
                                  <tr>
                                      <td class="cell_content_20PC_TR">
                                          <label class="Label_md">IndemnityPeriod </label>
                                      </td>
                                      <td>&nbsp;</td>
                                      <td class="cell_content_80PC_TL">
                                          <%--<asp:TextBox ID="indemnity_period" runat="server" CssClass="Text_200"></asp:TextBox>--%>
                                          <table>
                                              <tr>
                                                  <td class="cell_content_40PC_TL">
                                                      <asp:TextBox ID="indemnity_period" runat="server" CssClass="Text_200"></asp:TextBox>
                                                  </td>
                                                  <td>&nbsp;</td>
                                                  <td class="cell_content_PC_TL">
                                                      <label class="Label_md">SumInsured </label>
                                                  </td>
                                                  <td class="cell_content_40PC_TL">
                                                      <asp:TextBox ID="sum_insured" runat="server" CssClass="Text_200"></asp:TextBox>
                                                  </td>
                                                  <td>&nbsp;</td>
                                              </tr>
                                          </table>
                                      </td>
                                      <td>&nbsp;</td>
                                  </tr>
                                  <tr>
                                      <td class="cell_content_20PC_TR">
                                          <label class="Label_md">StartDate </label>
                                      </td>
                                      <td>&nbsp;</td>
                                      <td class="cell_content_80PC_TL">
                                          <table>
                                              <tr>
                                                  <td class="cell_content_40PC_TL">
                                                      <asp:TextBox ID="start_date" TextMode="Date" runat="server" CssClass="Text_200"></asp:TextBox>
                                                  </td>
                                                  <td>&nbsp;</td>
                                                  <td class="cell_content_PC_TL">
                                                      <label class="Label_md">EndDate </label>
                                                  </td>
                                                  <td class="cell_content_40PC_TL">
                                                      <asp:TextBox ID="end_date" TextMode="Date" runat="server" CssClass="Text_200"></asp:TextBox>
                                                  </td>
                                                  <td>&nbsp;</td>
                                              </tr>
                                          </table>
                                      </td>
                                      <td>&nbsp;</td>
                                  </tr>
                                  <tr>
                                      <td class="cell_content_20PC_TR">
                                          <label class="Label_md">Approve </label>
                                      </td>
                                      <td>&nbsp;</td>
                                      <td class="cell_content_80PC_TL">
                                          <asp:TextBox ID="approve_des" runat="server" CssClass="Text_800" Height="150px" TextMode="MultiLine"></asp:TextBox>
                                      </td>
                                      <td>&nbsp;</td>
                                  </tr>
                              </table>
                          </asp:Panel>
                        <br />
                    </td>
                </tr>
                <tr class="cell_content_100PC">
                    <td colspan="2" class="cell_content_100PC">
                        <asp:Panel ID="Panel2" runat="server" CssClass="div_90" Height="200px">
                            <table class="cell_content_100PC">
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server" Text="จัดทำโดย"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label8" runat="server" Text="เสนอโดย"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label9" runat="server" Text="สนับสนุนโดย"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="Label10" runat="server" Text="สนับสนุนโดย"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <uc1:ucPersonSign runat="server" ID="ucPersonSign1" />
                                    </td>
                                    <td>
                                        <uc1:ucPersonSign runat="server" ID="ucPersonSign2" />
                                    </td>
                                    <td>
                                        <uc1:ucPersonSign runat="server" ID="ucPersonSign3" />
                                    </td>
                                    <td>
                                        <uc1:ucPersonSign runat="server" ID="ucPersonSign4" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                         <br />
                    </td>

                </tr>

                <tr class="cell_content_100PC">
                    <td colspan="2" class="cell_content_100PC">
                        <asp:Button ID="btn_save" runat="server" CssClass="btn_normal_silver" Text="Save" OnClick="btn_save_Click" />
                        <asp:Button ID="btn_submit" runat="server" CssClass="btn_normal_silver" Text="Submit" />
                        <asp:Button ID="btn_gendocumnt" runat="server" CssClass="btn_normal_silver" Text="Preview" OnClick="btn_gendocumnt_Click" />
                        <asp:Button ID="btn_cancel" runat="server" CssClass="btn_normal_silver" Text="Cancel" />
                    </td>

                </tr>
            </table>
        </div>
    </form>
</body>
</html>
