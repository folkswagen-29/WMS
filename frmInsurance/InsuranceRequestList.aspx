<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsuranceRequestList.aspx.cs" Inherits="onlineLegalWF.frmInsurance.InsuranceRequestList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>InsuranceRequestList</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>

        <asp:GridView ID="gvReqList" runat="server" AutoGenerateColumns="false">
            <Columns>
                    <asp:BoundField DataField="process_id" HeaderText="Process ID" />
                    <asp:BoundField DataField="subject" HeaderText="Subject" />
                    <asp:BoundField DataField="req_date" HeaderText="Submitted Date" />
                    <asp:BoundField DataField="status" HeaderText="Status" />
                    <%--<asp:TemplateField HeaderText="Action">
                        <ItemTemplate>
                            
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                </Columns>
        </asp:GridView>

    </div>
    </form>
</body>
</html>
