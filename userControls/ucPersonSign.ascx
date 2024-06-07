<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPersonSign.ascx.cs" Inherits="WMS.userControls.ucPersonSign" %>
<div style="font-family:Tahoma; font-size:10pt; vertical-align:top; text-align:left ; /*width:220px;*/">

</div>
<asp:Panel ID="Panel1" runat="server" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Height="100px">
    <asp:Label ID="Label1" runat="server" Text="Name - Surname" Font-Names="Tahoma" Font-Size="10pt"></asp:Label>
    <br />
    <asp:Label ID="Label2" runat="server" Font-Names="Tahoma" Font-Size="10pt" Text="Position"></asp:Label>
    <br />
    <asp:Label ID="Label3" runat="server" Font-Names="Tahoma" Font-Size="10pt" Text="dd/MM/yyyy"></asp:Label>
</asp:Panel>