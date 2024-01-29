<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test02.aspx.cs" Inherits="onlineLegalWF.test.test02" %>

<%@ Register src="../userControls/ucAssignment.ascx" tagname="ucAssignment" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            TEST Task Assignment<br />
            Subject : xxxxxxxxxxxxxxxx<br />
            Requested by : xxxxxxxxxxx<br />
            <uc1:ucAssignment ID="ucAssignment1" runat="server" />
        </div>
        <asp:HiddenField ID="hidProcessID" runat="server" />
    </form>
</body>
</html>
