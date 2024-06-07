﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="testCSS1.aspx.cs" Inherits="WMS.test.testCSS1" %>

<%@ Register src="../userControls/ucMenulist.ascx" tagname="ucMenulist" tagprefix="uc1" %>

<%@ Register src="../userControls/ucAttachment.ascx" tagname="ucAttachment" tagprefix="uc2" %>
<%--<%@ Register Src="~/userControls/ucAttachment.ascx" TagPrefix="uc3" TagName="ucAttachment" %>--%>


<%--<%@ Register Src="~/userControls/UcAttachForm.ascx" TagPrefix="uc3" TagName="UcAttachForm" %>--%>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="../StyleSheet/CustomStyle.css" rel="stylesheet" type="text/css"/>

    
  
    <metaviewport name="viewport" content="width=device-width, initial-scale=1.0">
    <style type="text/css">
        .auto-style1 {
            width: 201px;
        }
        .auto-style2 {
            min-width: 40%;
            border-left-style: none;
            border-left-color: inherit;
            border-left-width: 0px;
            border-right-color: transparent;
            border-right-width: 0px;
            border-top-style: none;
            border-top-color: inherit;
            border-top-width: 0px;
            border-bottom-color: transparent;
            border-bottom-width: 0px;
            background-color: transparent;
        }
    </style>
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
                                      <asp:Label ID="Label4" runat="server" CssClass="Label_md" Text="Document No."></asp:Label>
                                  </td>
                                  <td>&nbsp;</td>
                                  <td class="cell_content_80PC_TL">
                                      <asp:Label ID="lblDocNo" runat="server" CssClass="Label_md"></asp:Label>
                                  </td>
                                  <td>
                                      &nbsp;</td>
                              </tr>
                              <tr>
                                  <td class="cell_content_20PC_TR">
                                      <asp:Label ID="Label1" runat="server" CssClass="Label_md" Text="Request by"></asp:Label>
                                  </td>
                                  <td>&nbsp;</td>
                                  <td class="cell_content_80PC_TL">
                                      <asp:TextBox ID="txtReqBy" runat="server" CssClass="Text_400"></asp:TextBox>
                                  </td>
                                  <td>&nbsp;</td>
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
                      <asp:Button ID="Button1" runat="server" CssClass="btn_normal_silver" Text="Save" OnClick="Button1_Click" />
                      <asp:Button ID="Button2" runat="server" CssClass="btn_normal_silver" Text="Preview" />
                      <asp:Button ID="Button3" runat="server" CssClass="btn_normal_blue" Text="Approve" />
&nbsp;<asp:Button ID="Button4" runat="server" CssClass="btn_normal_red" Text="Reject" />
                      <br />
                      <uc2:ucAttachment ID="ucAttachment1" runat="server" />
                      <br />
                      <asp:Label ID="lblPID" runat="server" CssClass="Label_sm"></asp:Label>
                </td>
                
            </tr>
            <tr>
                <td class="cell_content_40PC">
                     <asp:Panel ID="Panel2" runat="server" CssClass="div_90" height="400px">

                    </asp:Panel>
                </td>
                <td class="auto-style1">
                     <asp:Panel ID="Panel3" runat="server" CssClass="div_90" height="400px">

                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                     <uc1:ucMenulist ID="ucMenulist1" runat="server" />
                     <br />
                     <br />
                     <br />
                </td>
            </tr>
            <tr>
                <td class="auto-style2" colspan="2">
                    <%--<uc3:UcAttachForm runat="server" ID="UcAttachForm1" />--%>
                    <uc2:ucAttachment runat="server" ID="ucAttachmentEform" />
                    <br />
                    <br />
                    <br />
                </td>
            </tr>
        </table>
        
       </div>
    </form>
</body>
</html>
