<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuranceRenewRequestList.aspx.cs" Inherits="onlineLegalWF.frmInsurance.InsuranceRenewRequestList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>InsuranceRenewRequestList</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="gvRenewReqList" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="process_id" HeaderText="Process ID" />
                <asp:BoundField DataField="subject" HeaderText="Subject" />
                <asp:BoundField DataField="req_date" HeaderText="Submitted Date" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" NavigateUrl='<%# "~/frmInsurance/InsuranceRenewRequestEdit.aspx?id="+Eval("req_no") %>' Text="Edit"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
