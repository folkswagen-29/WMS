<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestWF01.aspx.cs" Inherits="WMS.test.TestWF01" %>

<%@ Register src="../userControls/ucAttachment.ascx" tagname="ucAttachment" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            PID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblPID" runat="server"></asp:Label>
            <br />
            <br />
            Subject&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtSubject" runat="server" Width="630px"></asp:TextBox>
            <br />
            <br />
            From&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtSubject0" runat="server" Width="630px"></asp:TextBox>
            <br />
            To&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtSubject1" runat="server" Width="630px"></asp:TextBox>
            <br />
            Process ID&nbsp;&nbsp;
            <asp:TextBox ID="txtProcessID" runat="server" Width="630px"></asp:TextBox>
            <br />
        </div>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Save" Width="169px" />
        <asp:Button ID="Button2" runat="server" Text="Submit" Width="169px" />
        <asp:Button ID="Button3" runat="server" Text="Approve" Width="169px" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" Text="Reject" Width="169px" />
        <asp:BulletedList ID="BulletedList1" runat="server" BulletStyle="Numbered">
            <asp:ListItem>Test</asp:ListItem>
        </asp:BulletedList>
    </form>
</body>
</html>
