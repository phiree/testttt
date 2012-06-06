<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true"
    CodeFile="UploadContract.aspx.cs" Inherits="ScenticManager_OnlineSell_UploadContract" %>

<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
    <script type="text/javascript" src="../Scripts/jquery-1.4.1.min.js"></script>
    <script src="../Scripts/jquery.uploadify.min.js" type="text/javascript"></script>
    <script src="../Scripts/swfobject.js" type="text/javascript"></script>
    <script type="text/javascript">
        function temp(mark) {
            alert(mark);
        }
        $(document).ready(function () {
            $("[id$='FileUpload1']").uploadify({
                'uploader': '../Scripts/uploadify.swf',
                'script': 'Upload.ashx?mark=upload',
                'cancelImg': '/Scripts/uploadify-cancel.png',
                'folder': 'Upload',
                'multi': false,
                'auto': true,
                'fileExt': '*.jpg;*.gif;*.png',
                'fileDesc': 'Image Files (.JPG, .GIF, .PNG2)',
                'buttonText': '选择文件',
                'wmode ': 'transparent ',
                'width': '110',
                'onComplete': function (event, queueId, fileObj, response, data) {
                    var x = "Upload/" + response + "";
                    $("[id$='ScenicImg']").attr("src", x);
                    $("[id$='hfimgurl']").val(response);
                }
            });
        });
        ///删除上传的图片。
        function deleteImg() {
            $.ajax({
                cache: true,
                url: "/Upload.ashx?mark=delete",
                type: "POST",
                dataType: "json"
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <br />
    <br />
    <asp:Image ID="ScenicImg" runat="server" Height="200px" Width="250px" />
    <div>
        <br />
    </div>
    选择图片:<asp:FileUpload runat="server" ID="FileUpload1" />
    <asp:Button runat="server" ID="btnUpload" Text="上传" OnClick="btnUpload_Click" />
    <br />
    &nbsp;<asp:HiddenField ID="hfimgurl" runat="server" />
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</asp:Content>
