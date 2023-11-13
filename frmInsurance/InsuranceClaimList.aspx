﻿<%@ Page Title="ClaimRequestList" Language="C#" MasterPageFile="SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="InsuranceClaimList.aspx.cs" Inherits="onlineLegalWF.frmInsurance.InsuranceClaimList" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc2" TagName="ucHeader" %>
<%@ Import Namespace="onlineLegalWF.Class" %> 

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
                    <asp:ListView ID="lvClaimList" runat="server">
                        <LayoutTemplate>
                            <table id="itemPlaceholderContainer" runat="server" class="table">
                                <tr style="height: 35px;">
                                    <th>Process ID</th>
                                    <th>Company Name</th>
                                    <th>Incident</th>
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
                                    <asp:Label runat="server" Text='<%# Eval("company_name") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%# Eval("incident") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%# Utillity.ConvertDateToLongDateTime(Convert.ToDateTime(Eval("claim_date")), "en") %>' />
                                </td>
                                <td>
                                    <asp:Label runat="server" Text='<%# Eval("status") %>' />
                                </td>
                                <td>
                                    <asp:ImageButton ID="btn_Edit" runat="server" Height="35px" PostBackUrl='<%# "~/frmInsurance/InsuranceClaimEdit.aspx?id="+Eval("claim_no") %>' ImageUrl="~/images/icon_edit.png" />
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
                
            </td>
        </tr>
    </table>
</asp:Content>
