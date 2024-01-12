<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testReplaceDoc1.aspx.cs" Inherits="onlineLegalWF.test.testReplaceDoc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <br />
            TAG NAME&nbsp; #1#&nbsp;&nbsp;
            <asp:TextBox ID="tagname1" runat="server"></asp:TextBox>
            <br />
            TAG NAME #2#&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="tagname2" runat="server"></asp:TextBox>
            <%--<br />
            <br />
            <br />
            <br />--%>
            <asp:FileUpload ID="sign_upload" runat="server" />
            <asp:Button ID="btnTestRun" runat="server" OnClick="btnTestRun_Click" Text="Test Run" />
        </div>
    </form>
</body>
</html>
