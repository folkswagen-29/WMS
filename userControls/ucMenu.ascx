<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenu.ascx.cs" Inherits="onlineLegalWF.userControls.ucMenu" %>
<style type="text/css">
    .auto-style4 {
       height:auto; 
    }
    .auto-style5 {
        width: 14px; height:auto; 
    }
    .auto-style6 {
        width: 14px; height:auto; 
      
    }
    .auto-style7 {
        width: 8px; height:auto; 
      
    }
    .auto-style8 {
        width: 8px; height:auto; 
    }
    .auto-style9 {
        width: 4px; height:auto; 
     
    }
    .auto-style10 {
        width: 4px; height:auto; 
    }
    .auto-style11 {
        width: 8px; height:auto; 
  
    }
    .auto-style12 {
        width: 4px; height:auto; 
       
    }
    .auto-style13 {
        width: 14px; height:auto; 
      
    }
    .auto-style14 {
        height:auto;
        width: 250px;
    }
    .auto-style15 {
        width: 250px; height:auto; 
    }
    .auto-style16 {
        width: 250px;
    }
</style>
<div style="font-family: tahoma; font-size: 10pt ; vertical-align:top; text-align:left; height:auto" >
    <table style="font-family: tahoma; font-size: 10pt; background-color: lightslategray" class="w-100">
        <tr>
            <td colspan="4">
                <asp:Label ID="Label1" runat="server" Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" Text="My Working Space" Font-Bold="True"></asp:Label>
            </td>


        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style4" colspan="2">&nbsp;
             
        <asp:LinkButton ID="lbtn1" runat="server" ForeColor="White" OnClick="lbtn1_Click">My Request List</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td colspan="2">&nbsp;
            <asp:LinkButton ID="lbtn2" runat="server" ForeColor="White">My Task List</asp:LinkButton>

            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td colspan="2">&nbsp;
            <asp:LinkButton ID="lbtn3" runat="server" ForeColor="White">Completed List</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td colspan="2">&nbsp;

            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="10pt" ForeColor="Black" Text="Shortcut menu" Font-Bold="True"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td colspan="2">

                <asp:LinkButton ID="lbtn4" runat="server" Width="150px" Font-Bold="True" ForeColor="#333333">Legal Request Insurance</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style16">

                <asp:LinkButton ID="lbtn5" runat="server" ForeColor="White" OnClick="lbtn5_Click">Insurance Request</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style16">

                <asp:LinkButton ID="LinkButton1" runat="server" ForeColor="White" OnClick="LinkButton1_Click">Insurance Renew Request</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style16">

                <asp:LinkButton ID="lbtn6" runat="server" ForeColor="White" OnClick="lbtn6_Click">Claim Request</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style16">

                <asp:LinkButton ID="lbtn7" runat="server" ForeColor="White">Tracking Report</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style16">

                <asp:LinkButton ID="lbtn17" runat="server" ForeColor="White" OnClick="lbtn17_Click">Tracking Renew Insurance</asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td colspan="2">

                <%--        <asp:LinkButton ID="lbtn8" runat="server" Width="150px" Font-Bold="True" ForeColor="#333333">Legal Request - Commercial Registration</asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style16">

                <%--<asp:LinkButton ID="lbtn9" runat="server" ForeColor="White">Commercial Registration Request</asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td class="auto-style11"></td>
            <td class="auto-style12"></td>
            <td class="auto-style13"></td>
            <td class="auto-style14">

                <%--        <asp:LinkButton ID="lbtn10" runat="server" ForeColor="White">Work Assignment</asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style16">

                <%--        <asp:LinkButton ID="lbtn11" runat="server" ForeColor="White">Tracking Report</asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style6"></td>
            <td class="auto-style14"></td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td colspan="2">

                <%--<asp:LinkButton ID="lbtn12" runat="server" Width="150px" Font-Bold="True" ForeColor="#333333">Legal Request - Permit</asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style16">

                <%--<asp:LinkButton ID="lbtn13" runat="server" ForeColor="White">Permit Request</asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style16">

                <%--<asp:LinkButton ID="lbtn14" runat="server" ForeColor="White">Work Assignment</asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style16">

                <%--<asp:LinkButton ID="lbtn15" runat="server" ForeColor="White">Tracking Report</asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td colspan="2">

                <%--<asp:LinkButton ID="lbtn16" runat="server" Width="150px" Font-Bold="True" ForeColor="#333333">Legal Request - Ligitation</asp:LinkButton>--%>
            </td>
        </tr>
        <tr>
            <td class="auto-style7"></td>
            <td class="auto-style9">&nbsp;</td>
            <td class="auto-style6"></td>
            <td class="auto-style14"></td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
        <tr>
            <td class="auto-style8">&nbsp;</td>
            <td class="auto-style10">&nbsp;</td>
            <td class="auto-style5">&nbsp;</td>
            <td class="auto-style16">&nbsp;</td>
        </tr>
    </table>
</div>