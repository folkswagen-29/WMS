<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UcAttachForm.ascx.cs" Inherits="onlineLegalWF.userControls.UcAttachForm" %>
<%-- <link href="../StyleSheet/CustomStyle.css" rel="stylesheet" type="text/css"/>
<asp:ScriptManager ID="scriptfrmattach" runat="server">
    <Scripts>
        <asp:ScriptReference Name="jquery" />
        <asp:ScriptReference Name="bootstrap" />
    </Scripts>
</asp:ScriptManager>--%>

<%--<div>
    <asp:FileUpload ID="frm_attach" runat="server" /> 
&nbsp; <asp:Button ID="frm_attach_btnEditupload" runat="server" CssClass="btn-group" Visible="false" Text="Edit" />
&nbsp; <asp:Button ID="frm_attach_btnUpload" runat="server" CssClass="btn-group" Text="Upload" OnClick="frm_attach_btnUpload_Click" /> 
</div>--%>

<div>
    <asp:FileUpload ID="myFile" Style="display: none" runat="server" onchange="upload()" />
    <asp:LinkButton ID="lblFile" runat="server" Text="" OnClick="DownloadData" CommandArgument="" Visible="false"></asp:LinkButton>
    &nbsp; <input type="button" id="btn_upload" runat="server" value="Input File" onclick="showBrowseDialog()" />
    &nbsp; <asp:Button runat="server" ID="hideButton" Text="" Style="display: none;" OnClick="uploadData" />
</div>

<asp:HiddenField ID="hidPID" runat="server" />
<asp:HiddenField ID="eform_name" runat="server" />
<asp:HiddenField ID="eform_item_no" runat="server" />

<div class="modal fade" id="modalfrmattach" role="dialog">
    <div class="modal-dialog modal-lg">
        <div class="modal-content">
            <div class="modal-header" style="border: 0;">
                <button type="button" class="close" data-dismiss="modal">&times;</button>
                <%--<h4 class="modal-title">Modal Attach</h4>--%>
            </div>
            <div class="modal-body">
                <iframe id="frm_pdf_render" runat="server" width="865" height="600" frameborder="0"></iframe>
            </div>
            <%--<div class="modal-footer" style="text-align: left; border-top: 0;">
                <asp:Button runat="server" Text="Assign" CssClass="btn_normal_blue" />
            </div>--%>
        </div>
    </div>
</div>

<script type="text/javascript" language="javascript">
    function showBrowseDialog() {
        var fileuploadctrl = document.getElementById('<%= myFile.ClientID %>');
        fileuploadctrl.click();
    }

    function upload() {
        var btn = document.getElementById('<%= hideButton.ClientID %>');
        btn.click();
    }

    function showModalAttachFrm() {
        $("#modalfrmattach").modal('show');
    }
</script>