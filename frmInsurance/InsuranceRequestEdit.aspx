<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuranceRequestEdit.aspx.cs" Inherits="onlineLegalWF.frmInsurance.InsuranceRequestEdit" %>
<%@ Register Src="~/userControls/ucPersonSign.ascx" TagPrefix="uc1" TagName="ucPersonSign" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>InsuranceRequestEdit</title>
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
    .auto-style4 {
        width: 290px;
    }
    .auto-style5 {
        height: 110px;
    }  
    </style>
</head>
<body>
    <form id="form1" runat="server">

        <div style="font-family:Tahoma; font-size:10pt; margin-top: 20px;">
            <table cellpadding="0" cellspacing="0" style="width: 100%;" class="auto-style1">
                <tr>
                    <td class="auto-style2">
                        <label>Request No. </label>
                    </td>
                    <td colspan="3">
                        <asp:Label ID="req_no" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <label>Type of Request </label>
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="type_req" runat="server" Width="300px">
                            <asp:ListItem>-Please select-</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <label>Company </label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="company" runat="server" Width="500px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <label>Documnet No </label>
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="doc_no" runat="server" Width="500px"></asp:TextBox>
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
                    <td>
                        <label>Type of Property Insured </label>
                    </td>
                    <td colspan="3">
                        <asp:DropDownList ID="type_pi" runat="server" Width="300px">
                            <asp:ListItem>-Please select-</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <label>IndemnityPeriod </label>
                    </td>
                    <td>
                        <asp:TextBox ID="indemnity_period" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <label>SumInsured </label>
                    </td>
                    <td>
                        <asp:TextBox ID="sum_insured" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2">
                        <label for="start_date">StartDate </label>
                    </td>
                    <td>
                        <asp:TextBox ID="start_date" TextMode="Date" runat="server"></asp:TextBox>
                    </td>
                    <td class="auto-style2">
                        <label for="end_date">EndDate </label>
                    </td>
                    <td>
                        <asp:TextBox ID="end_date" TextMode="Date" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <label for="approve_des">อนุมัติ</label><br />
                        <asp:TextBox ID="approve_des" TextMode="MultiLine" runat="server" CssClass="auto-style3"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table>
                            <tr>
                                <td class="auto-style4">
                                    <asp:Label ID="Label7" runat="server" Text="จัดทำโดย"></asp:Label>
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="Label8" runat="server" Text="เสนอโดย"></asp:Label>
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="Label9" runat="server" Text="สนับสนุนโดย"></asp:Label>
                                </td>
                                <td class="auto-style4">
                                    <asp:Label ID="Label10" runat="server" Text="สนับสนุนโดย"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style5">
                                    <uc1:ucPersonSign runat="server" id="ucPersonSign1" />
                                </td>
                                <td class="auto-style5">
                                    <uc1:ucPersonSign runat="server" id="ucPersonSign2" />
                                </td>
                                <td class="auto-style5">
                                    <uc1:ucPersonSign runat="server" id="ucPersonSign3" />
                                </td>
                                <td class="auto-style5">
                                    <uc1:ucPersonSign runat="server" id="ucPersonSign4" />
                                </td>
                            </tr>
                        </table>
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
        <asp:HiddenField ID="req_date" runat="server" />
    </form>
</body>
</html>
