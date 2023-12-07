<%@ Page Title="LigitationWorkAssign" Language="C#" MasterPageFile="~/frmInsurance/SiteLigalWorkFlow.Master" AutoEventWireup="true" CodeBehind="LitigationWorkAssign.aspx.cs" Inherits="onlineLegalWF.frmLitigation.LigitationWorkAssign" %>
<%@ Register Src="~/userControls/ucWorkflowlist.ascx" TagPrefix="uc2" TagName="ucWorkflowlist" %>
<%@ Register Src="~/userControls/ucHeader.ascx" TagPrefix="uc1" TagName="ucHeader" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="cell_content_100PC">
        <tr>
            <td colspan="2">
                <div style="background-color:gainsboro;">
                    <uc1:ucHeader runat="server" id="ucHeader1" />
                </div>
                
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <div class="div_90">
                    <uc2:ucWorkflowlist runat="server" id="ucWorkflowlist1" />
                </div>
            </td>
        </tr>
        
    </table>
</asp:Content>
