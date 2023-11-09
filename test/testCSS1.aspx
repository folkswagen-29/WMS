<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testCSS1.aspx.cs" Inherits="onlineLegalWF.test.testCSS1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../StyleSheet/CustomStyle.css" rel="stylesheet" type="text/css"/>

    
  
    <metaviewport name="viewport" content="width=device-width, initial-scale=1.0">
    </head>
    
<body>
    <form id="form1" runat="server">
       <div class="div1">

        <br />
        <table class="cell_content_100PC">
            <tr class="cell_content_100PC">
                <td colspan="2" class="cell_content_100PC">
                      <asp:Panel ID="Panel1" runat="server" CssClass="div_90">
                          <table class="auto-style1">
                              <tr>
                                  <td class="cell_content_20PC_TR">
                                      <asp:Label ID="Label1" runat="server" CssClass="Label_md" Text="Request by"></asp:Label>
                                  </td>
                                  <td>&nbsp;</td>
                                  <td class="cell_content_80PC_TL">
                                      <asp:TextBox ID="txtReqBy" runat="server" CssClass="Text_400"></asp:TextBox>
                                  </td>
                                  <td>
                                      &nbsp;</td>
                              </tr>
                              <tr>
                                  <td class="cell_content_20PC_TR">
                                      <asp:Label ID="Label2" runat="server" CssClass="Label_md" Text="Subject"></asp:Label>
                                  </td>
                                  <td>&nbsp;</td>
                                  <td class="cell_content_80PC_TL">
                                      <asp:TextBox ID="txtReqBy1" runat="server" CssClass="Text_800" TextMode="MultiLine"></asp:TextBox>
                                  </td>
                                  <td class="cell_content_60PC_TL">
                                      &nbsp;</td>
                              </tr>
                              <tr>
                                  <td class="cell_content_20PC_TR">
                                      <asp:Label ID="Label3" runat="server" CssClass="Label_md" Text="Objective"></asp:Label>
                                  </td>
                                  <td>&nbsp;</td>
                                  <td class="cell_content_80PC_TL">
                                      <asp:TextBox ID="txtReqBy0" runat="server" CssClass="Text_800" Height="150px" TextMode="MultiLine"></asp:TextBox>
                                  </td>
                                  <td class="cell_content_60PC_TL">
                                      &nbsp;</td>
                              </tr>
                          </table>
                            
                      </asp:Panel>
                    <br />
                </td>
                
            </tr>
            <tr class="cell_content_100PC">
                <td colspan="2" class="cell_content_100PC">
                     <asp:Panel ID="Panel4" runat="server" CssClass="div_90" height="400px">

                    </asp:Panel>
                </td>
                
            </tr>
            <tr class="cell_content_100PC">
                <td colspan="2" class="cell_content_100PC">
                      <asp:Button ID="Button1" runat="server" CssClass="btn_normal_silver" Text="Save" />
                      <asp:Button ID="Button2" runat="server" CssClass="btn_normal_silver" Text="Preview" />
                      <asp:Button ID="Button3" runat="server" CssClass="btn_normal_blue" Text="Approve" />
&nbsp;<asp:Button ID="Button4" runat="server" CssClass="btn_normal_red" Text="Reject" />
                </td>
                
            </tr>
            <tr>
                <td class="cell_content_40PC">
                     <asp:Panel ID="Panel2" runat="server" CssClass="div_90" height="400px">

                    </asp:Panel>
                </td>
                <td class="cell_content_60PC">
                     <asp:Panel ID="Panel3" runat="server" CssClass="div_90" height="400px">

                    </asp:Panel>
                </td>
            </tr>
        </table>
        
       </div>
    </form>
</body>
</html>
