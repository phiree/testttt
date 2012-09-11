<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="EditScenic.aspx.cs" Inherits="Manager_ScenicManage_EditScenic" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script src="/Scripts/jquery.cookie.js" type="text/javascript"></script>
    <script src="/Scripts/Verification.js" type="text/javascript"></script>
    <script src="/Scripts/jquery.uploadify.min.js" type="text/javascript"></script>
    <link href="/Styles/uploadify.css" rel="stylesheet" type="text/css" />
    <script src="/Scripts/swfobject.js" type="text/javascript"></script>
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
    <script src="/ckeditor/ckeditor.js" type="text/javascript"></script>
    <link href="/theme/default/css/scenic.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/EditHTML.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            var editor = CKEDITOR.replace("<%=tbxDetail.ClientID %>", {
                toolbar: [
                //加粗     斜体，     下划线      穿过线      下标字        上标字
                ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', 'Source']
             ]
            });
            editor.config['contentsCss'] = ['/theme/default/css/scenic.css', '/theme/default/css/TCCSS.css', '/theme/default/css/global.css', '/theme/default/css/default.css', '/theme/bp/screen.css',
            '/theme/bp/print.css', '/theme/default/css/MasterPage.css', '/theme/default/css/EditHTML.css'];
            var editor2 = CKEDITOR.replace("<%=tbxBookNote.ClientID %>", {
                toolbar: [
                //加粗     斜体，     下划线      穿过线      下标字        上标字
                ['Bold', 'Italic', 'Underline', 'Strike', 'Subscript', 'Superscript', 'Source']
             ]
            });
            editor2.config['contentsCss'] = ['/theme/default/css/scenic.css', '/theme/default/css/TCCSS.css', '/theme/default/css/global.css', '/theme/default/css/default.css', '/theme/bp/screen.css',
            '/theme/bp/print.css', '/theme/default/css/MasterPage.css'];
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <p class="fuctitle">
        景区信息编辑</p><a href="Default.aspx">返回列表</a>
    <hr />
    <div id="scinfoedit">
        <table>
            <tr>
                <td>景区名称
                </td>
                <td>
                <asp:TextBox runat="server" ID="tbxName"></asp:TextBox>
                </td>
            </tr>
              <tr>
                <td>SeoName               </td>
                <td><asp:TextBox runat="server" ID="tbxSeoName"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>地址
                </td>
                <td><asp:TextBox runat="server" ID="tbxAddress"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>序号
                </td>
                <td><asp:TextBox runat="server" ID="tbxOrder"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>A级
                </td>
                <td>
                <asp:RadioButtonList runat="server" ID="rblLevel" RepeatDirection="Horizontal">
                 <asp:ListItem Value="">无</asp:ListItem>
                <asp:ListItem Value="5A">5A</asp:ListItem>
                 <asp:ListItem Value="4A">4A</asp:ListItem> 
                 <asp:ListItem Value="3A">3A</asp:ListItem>
                </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>交通信息
                </td>
                <td><asp:TextBox runat="server" ID="tbxTransfer"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>所属区域
                </td>
                <td>
                <asp:TextBox runat="server" ID="tbxArea"></asp:TextBox>
                </td>
            </tr>


             <tr>
                <td>简介
                </td>
                <td><asp:TextBox runat="server" ID="tbxDesc"></asp:TextBox>
                </td>
            </tr>
            
             <tr>
                <td>详情
                </td>
                <td>  <CKEditor:CKEditorControl ID="tbxDetail" runat="server"></CKEditor:CKEditorControl>
                </td>
            </tr>

             <tr>
                <td>预订说明
                </td>
                <td>   <CKEditor:CKEditorControl ID="tbxBookNote" runat="server"></CKEditor:CKEditorControl>
                </td>
            </tr>


        </table>
      
    </div>
    <asp:Button ID="BtnSave" runat="server" CssClass="btnsaveimg" Style="margin-left: 20px;
        margin-bottom: 20px;" OnClick="BtnSave_Click" />
</asp:Content>
