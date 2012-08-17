<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="ScenicTopicSetting2.aspx.cs" Inherits="Manager_ScenicTopicSetting2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            //添加主题分类到景区主题
            $(".deltopic").click(function () {
                var isexsit = false;
                var selectedone = $(this).html();
                $("#taglist>a").each(function () {
                    if ($.trim($(this).html()) == $.trim(selectedone)) {
                        isexsit = true;
                    }
                });
                if (!isexsit) {
                    var content = $("#taglist").html() + "<a onclick='delitem(this)' class='hlv'>" + selectedone + "<a class='delfunc' onclick='delitem(this)'>×</a></a>";
                    $("#taglist").html(content);
                }
            });

            //            $("#btnok").click(function () {
            //                var scenicnames = "";
            //                $("#taglist>li").each(function () {
            //                    scenicnames += $(this).html() + "+";
            //                });
            //                $.ajax({
            //                    type: "Post",
            //                    url: "TopicHandler.ashx",
            //                    dataType: "json",
            //                    data: { 'scenicnames': scenicnames, "scid": 10 },
            //                    success: function (data, status) {
            //                        alert("ok");
            //                    }
            //                });
            //            });

            //添加主题分类
            $("#btn_newitem").click(function () {
                $.ajax({
                    type: "Post",
                    url: "TopicNewHandler.ashx",
                    dataType: "json",
                    data: { 'newitem': $("#txt_newitem").val() },
                    success: function (data, status) {
                        $(".tagstore").html($(".tagstore").html() + "<a>" + $("#txt_newitem").val() + "</a><a class='deltopic' onclick='deltopic(this)'>-</a>");
                    }
                });
            });
        });

        //删除主题分类
        function deltopic(obj) {
            var item = $.trim($(obj).prev().html());
            var r = confirm("是否删除" + item + "吗？");
            if (r) {
                $.ajax({
                    type: "Post",
                    url: "TopicDelHandler.ashx",
                    dataType: "json",
                    data: { 'delitem': item },
                    success: function (data, status) {
                        $(obj).remove();
                    }
                });
            }
            else {
                return;
            }
        }

        //删除景区主题
        function delitem(obj) {
            $(obj).prev().remove();
            $(obj).remove();
        }

        //保存景区主题
        function saveitem() {
            var scenicnames = "";
            $("#taglist>a").each(function () {
                scenicnames += $.trim($(this).html()) + "+";
            });
            $("#<%=hiddentag.ClientID%>").val(scenicnames);
        }
    </script>
    <style type="text/css">
        .deltopic, .hlv, .deltopic:link, .deltopic:active, .deltopic:visited, .deltopic:hover, .hlv:link, .hlv:active, .hlv:visited, .hlv:hover
        {
            color: #009F3C;
            font-weight: 700;
            border: #A6DF9E;
            background-color: #D1EFCD;
            padding: 3px 5px 3px 5px;
            margin-top: -4px;
            cursor: pointer;
        }
        .delfunc
        {
            color: #009F3C;
            font-weight: 700;
            border: #A6DF9E;
            background-color: #D1EFCD;
            padding: 3px 5px 3px 5px;
            margin-top: -4px;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <div>
        <br />
        <asp:HiddenField ID="hiddentag" runat="server" />
        <div>
            <p>
                你可能感兴趣的标签：</p>
            <div class="tagstore">
                <asp:Repeater ID="rptTopicStore" runat="server">
                    <ItemTemplate>
                        <a class="deltopic">
                            <%#Eval("Name")%><a class="delfunc" onclick='deltopic(this)'> ×</a></a>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <input id="txt_newitem" type="text" />
            <input id="btn_newitem" type="button" value="添加" />
        </div>
    </div>
    <br />
    <div>
        <p>
            我已经添加的标签：</p>
    </div>
    <div id="taglist">
        <asp:Repeater ID="rptTopicOwn" runat="server">
            <ItemTemplate>
                <a class="hlv">
                    <%#Eval("Name") %><a class="delfunc" onclick='delitem(this)'> ×</a></a>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <asp:Button ID="btnsave" runat="server" Text="保存" OnClientClick="saveitem()" OnClick="btnsave_Click" />
    <a href="/manager/ScenicTopicSetting.aspx">返回</a>
</asp:Content>
