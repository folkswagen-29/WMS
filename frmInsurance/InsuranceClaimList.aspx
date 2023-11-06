<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuranceClaimList.aspx.cs" Inherits="onlineLegalWF.frmInsurance.InsuranceClaimList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>InsuranceClaimList</title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:GridView ID="gvClaimList" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="process_id" HeaderText="Process ID" />
                <asp:BoundField DataField="company_name" HeaderText="Company Name" />
                <asp:BoundField DataField="incident" HeaderText="Incident" />
                <asp:BoundField DataField="claim_date" HeaderText="Submitted Date" />
                <asp:BoundField DataField="status" HeaderText="Status" />
                <asp:TemplateField HeaderText="Action">
                    <ItemTemplate>
                        <asp:HyperLink runat="server" NavigateUrl='<%# "~/frmInsurance/InsuranceClaimEdit.aspx?id="+Eval("claim_no") %>' Text="Edit"></asp:HyperLink>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </form>
</body>
</html>
