<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucTaskList.ascx.cs" Inherits="onlineLegalWF.userControls.ucTaskList" %>
 <link href="../StyleSheet/CustomStyle.css" rel="stylesheet" type="text/css"/>
<style type="text/css">
    .auto-style1 {
        padding: 0.5%;
        margin-left: 2.5%;
        font-family: Tahoma;
        font-size: 10pt;
        color: black;
        background-color: white;
        border: 1px solid silver;
        box-shadow: silver 2px 2px;
        border-radius: 3px 3px;
        min-height: 50px;
    }
</style>
<asp:Panel ID="Panel1" runat="server"  Height="600px" CssClass="div_90">
    <asp:GridView ID="gv1" runat="server" AutoGenerateColumns="False" Width="1157px">
        <Columns>
            <asp:TemplateField HeaderText="Request No">
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnReqNo" runat="server" Font-Names="Tahoma" Font-Size="10pt" ForeColor="#003399" Width="200px"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Subject">
                  <ItemTemplate>
                    <asp:Label ID="lblSubject" runat="server" Font-Names="Tahoma" Font-Size="10pt" ForeColor="#003399" Width="250px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Request By">
                  <ItemTemplate>
                    <asp:Label ID="lblReqBy" runat="server" Font-Names="Tahoma" Font-Size="10pt" ForeColor="#003399" Width="200px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Submitted Date">
                  <ItemTemplate>
                    <asp:Label ID="lblSubmittedDate" runat="server" Font-Names="Tahoma" Font-Size="10pt" ForeColor="#003399" Width="200px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Status">
                  <ItemTemplate>
                    <asp:Label ID="lblStatus" runat="server" Font-Names="Tahoma" Font-Size="10pt" ForeColor="#003399" Width="200px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Last updated">
                 <ItemTemplate>
                    <asp:Label ID="lblLastupdated" runat="server" Font-Names="Tahoma" Font-Size="10pt" ForeColor="#003399" Width="200px"></asp:Label>
                </ItemTemplate>

            </asp:TemplateField>
            <asp:TemplateField HeaderText="Last updated by">
                  <ItemTemplate>
                    <asp:Label ID="lblLastupdateby" runat="server" Font-Names="Tahoma" Font-Size="10pt" ForeColor="#003399" Width="200px"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>

</asp:Panel>
<asp:HiddenField ID="hidLogin" runat="server" />
<asp:HiddenField ID="hidMode" runat="server" />

