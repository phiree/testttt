<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true" CodeFile="ScenicPicture.aspx.cs" Inherits="ScenicManager_ScenicPicture" %>
<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
    <link href="../theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/jquery.uploadify.min.js" type="text/javascript"></script>
    <link href="/Styles/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/swfobject.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("[id$='FileUpload1']").uploadify({
                'uploader': '../Scripts/uploadify.swf',
                'script': 'Upload.ashx?mark=upload',
                'cancelImg': '/Scripts/uploadify-cancel.png',
                'folder': 'Upload',
                'multi': false,
                'auto': true,
                'fileExt': '*.jpg;*.gif;*.png',
                'fileDesc': 'Image Files (.JPG, .GIF, .PNG)',
                'buttonText': '选择文件',
                'wmode ': 'transparent ',
                'width': '76',
                'height': '31',
                'buttonImg': '/theme/default/image/btnupload.png',
                'onComplete': function (event, queueId, fileObj, response, data) {
                    var x = "Upload/" + response + "";
                    $("[#uploadimg").attr("src", x);
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
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <p class="fuctitle">
        景区图片管理</p>
    <hr />
    <asp:HiddenField ID="hfimgurl" runat="server" />
    <div id="scpic">
        <div class="scpics">
            <span>点击进入景区图库</span>
            <a href="/ScenicManager/ScenicPictureShow.aspx?type=1">主图</a>
            <a href="/ScenicManager/ScenicPictureShow.aspx?type=2">辅图</a>
            <a href="/ScenicManager/ScenicPictureShow.aspx?type=3">备图</a>
        </div>
        <hr class="scpicsper" />
        <div class="scpicmain">
            <span>上传图片</span>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width:100px">
                        
                    </td>
                    <td style="width:550px">
                        <img id="uploadimg" width="500px" height="350px" />
                    </td>
                </tr>
                <tr>
                    <td>
                        上传
                    </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td>
                        图片类型
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlpictype" runat="server">
                            <asp:ListItem Value="1">主图</asp:ListItem>
                            <asp:ListItem Value="2">辅图</asp:ListItem>
                            <asp:ListItem Value="3">备图</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        图片名称
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        图片描述
                    </td>
                    <td>
                        <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Width="500px" Height="60px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnok" runat="server"  CssClass="btnsaveimg" 
                            onclick="btnok_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>

