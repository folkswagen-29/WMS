<%@ Page Title="RequestList" Language="C#" MasterPageFile="SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="InsuranceRequestList.aspx.cs" Inherits="WMS.frmInsurance.InsuranceRequestList" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc2" TagName="ucHeader" %>
<%@ Import Namespace="WMS.Class" %> 

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="cell_content_100PC">
        <tr>
            <td colspan="2">
                <div style="background-color: gainsboro;">
                    <uc2:ucheader runat="server" id="ucHeader1" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <div class="div_90">
                    <%--<asp:GridView ID="gvReqList" runat="server" AutoGenerateColumns="false" CssClass="table" BorderWidth="0">
                        <Columns>
                            <asp:BoundField DataField="process_id" HeaderText="Process ID" />
                            <asp:BoundField DataField="subject" HeaderText="Subject" />
                            <asp:BoundField DataField="req_date" HeaderText="Submitted Date" />
                            <asp:BoundField DataField="status" HeaderText="Status" />
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:HyperLink runat="server" NavigateUrl='<%# "~/frmInsurance/InsuranceRequestEdit.aspx?id="+Eval("req_no") %>' Text="Edit"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>--%>
                    <asp:ListView ID="lvReqList" runat="server">
                        <LayoutTemplate>
                            <table id="itemPlaceholderContainer" runat="server" class="table">
                                <tr style="height: 35px;">
                                    <th>Process ID</th>
                                    <th>Subject</th>
                                    <th>Submitted Date</th>
                                    <th>Status</th>
                                    <th></th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label runat="server" Text='<%# Eval("process_id") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%# Eval("subject") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%# Utillity.ConvertDateToLongDateTime(Convert.ToDateTime(Eval("req_date")), "en") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%# Eval("status") %>' />
                                </td>
                                <td>
                                    <asp:ImageButton ID="btn_Edit" runat="server" Height="35px" PostBackUrl='<%# "~/frmInsurance/InsuranceRequestEdit.aspx?id="+Eval("req_no") %>' ImageUrl="~/images/icon_edit.png" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                
            </td>
        </tr>
    </table>
</asp:Content>