<%@ Page Title="LegalPortal" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="legalPortal.aspx.cs" Inherits="onlineLegalWF.legalPortal.legalPortal" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>
<%@ Register Src="~/userControls/ucTaskList.ascx" TagPrefix="uc2" TagName="ucTaskList" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="cell_content_100PC">
        <tr>
            <td colspan="2">
                <div style="background-color:gainsboro;">
                    <uc1:ucHeader runat="server" id="ucHeader1" />
                </div>
                
            </td>
        </tr>
        <tr class="cell_content_100PC">
            <td colspan="2" class="cell_content_100PC">
                <uc2:ucTaskList runat="server" id="ucTaskList1" />
            </td>
        </tr>
    </table>
</asp:Content>
