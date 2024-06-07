<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testReplaceDoc2.aspx.cs" Inherits="WMS.test.testReplaceDoc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TEST </title>
    <link href="../StyleSheet/CustomStyle.css" rel="stylesheet" type="text/css"/>
    

</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager runat="server">
            <Scripts>
                <%--To learn more about bundling scripts in ScriptManager see https://go.microsoft.com/fwlink/?LinkID=301884 --%>
                <%--Framework Scripts--%>
                <asp:ScriptReference Name="jquery" />
                <%--Site Scripts--%>
            </Scripts>
        </asp:ScriptManager>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>-Please select-</asp:ListItem>
            <asp:ListItem Selected="True" Value="1">frm1</asp:ListItem>
            <asp:ListItem Value="2">frm2</asp:ListItem>
        </asp:DropDownList>
        <br />
        <div id="section1">
            <asp:Label ID="Label1" runat="server" Text="Input Message" CssClass="Label_lg_blue"></asp:Label>
&nbsp; 
            <asp:TextBox ID="TextBox1" runat="server" CssClass="Text_400"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="Type" CssClass="Label_lg_blue"></asp:Label>
&nbsp;
            
            
        </div>

        <div id="section2" style="display:none;">
            <asp:Label ID="Label2" runat="server" Text="Input Message Frm2" CssClass="Label_lg_blue"></asp:Label>
&nbsp; 
            <asp:TextBox ID="TextBox2" runat="server" CssClass="Text_400"></asp:TextBox>
            <br />
        </div>
    </form>


    <script type="text/javascript">
        $(function() {
            console.log('ddl value', $('#DropDownList1 option:selected').val());

            $('#DropDownList1').change(function (event) {
                console.log('val', $(this).val());
                if ($(this).val() == 1) {
                    $('#section1').show();
                    $('#section2').hide();
                }
                else if ($(this).val() == 2) {
                    $('#section1').hide();
                    $('#section2').show();
                }
            });
        });
    </script>
</body>
</html>
