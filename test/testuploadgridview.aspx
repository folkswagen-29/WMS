<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testuploadgridview.aspx.cs" Inherits="WMS.test.testuploadgridview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test File Uploading</title>
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/3.5.1/jquery.min.js"></script> 
    <link href="../StyleSheet/CustomStyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">   
        <h3>Test File Uploading</h3>
        <table>
            <thead>
                <tr>
                    <th></th>
                    <th></th>

                    <th>
                        <asp:FileUpload ID="myFile" runat="server" CssClass="btn btn-warning" /></th>
                    <th></th>
                    <th>
                        <asp:Button ID="btnUpload" Text="upload" runat="server" CssClass="btn btn-success" OnClick="uploadData" /></th>
                </tr>
            </thead>
        </table>    
        <hr />    
        <div>    
            <asp:GridView ID="fileGridview" UseAccessibleHeader="true" runat="server" CssClass="table w-100" GridLines="None" AutoGenerateColumns="false" EmptyDataText="No Files Uploaded">
                <Columns>
                    <%--<asp:BoundField DataField="Text" HeaderText="File Name" />--%>
                    <asp:TemplateField HeaderText="File Name">
                        <ItemTemplate>
                            <asp:Label ID="gv1txtNo" Text='<%# Eval("No") %>' runat="server"></asp:Label>.
                            <asp:Label ID="gv1txtFilename" Text='<%# Eval("FileName") %>' runat="server"></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <%--<asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="Preview" runat="server" Text='<%# Eval("FileName") %>' OnClick="PreviewData" CommandArgument='<%# Eval("Files") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>--%>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="DownloadLink" runat="server" Text='<%# Eval("FileName") %>' OnClick="DownloadData" CommandArgument='<%# Eval("Files") %>'></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton ID="DeleteLink" runat="server" Text="Delete" OnClick="DeleteData" CommandArgument=' <%# Eval("Files") %>'><img src="/Images/icon_delete.png" height="20" /></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>

                </Columns>
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>    
  
        </div>    
    </form>

    <script type="text/javascript">    

        $(document).ready(function () {
            $('#fileGridview').DataTable();
        });
    </script>  
</body>
</html>
