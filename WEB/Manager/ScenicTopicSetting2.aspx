<%@ Page Title="" Language="C#" MasterPageFile="~/Manager/manager.master" AutoEventWireup="true"
    CodeFile="ScenicTopicSetting2.aspx.cs" Inherits="Manager_ScenicTopicSetting2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        $(function () {
            $(".tagstore>a").click(function () {
                var isexsit = false;
                var selectedone = $(this).html();
                $("#taglist>li").each(function () {
                    if ($.trim($(this).html()) == $.trim(selectedone)) {
                        isexsit = true;
                    }
                });
                if (!isexsit) {
                    var content = $("#taglist").html() + "<li onclick='delitem(this)'>" + selectedone + "</li>";
                    $("#taglist").html(content);
                }
            });
            $("#btnok").click(function () {
                var scenicnames = "";
                $("#taglist>li").each(function () {
                    scenicnames += $(this).html() + "+";
                });
                $.ajax({
                    type: "Post",
                    url: "TopicHandler.ashx",
                    dataType: "json",
                    data: { 'scenicnames': scenicnames, "scid": 10 },
                    success: function (data, status) {
                        alert("ok");
                    }
                });
            });
            $("#btn_newitem").click(function () {
                $.ajax({
                    type: "Post",
                    url: "TopicNewHandler.ashx",
                    dataType: "json",
                    data: { 'newitem': $("#txt_newitem").val() },
                    success: function (data, status) {
                        $(".tagstore").html($(".tagstore").html() + "<a>" + $("#txt_newitem").val() + "</a>");
                    }
                });
            });
        });
        function delitem(obj) {
            $(obj).remove();
        }
        function saveitem() {
            var scenicnames = "";
            $("#taglist>li").each(function () {
                scenicnames += $(this).html() + "+";
            });
            $("#<%=hiddentag.ClientID%>").val(scenicnames);
        }
    </script>
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
                        <a>
                            <%#Eval("Name")%></a>
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
    <div>
        <ul id="taglist">
            <asp:Repeater ID="rptTopicOwn" runat="server">
                <ItemTemplate>
                    <li onclick='delitem(this)'>
                        <%#Eval("Name") %></li>
                </ItemTemplate>
            </asp:Repeater>
        </ul>
    </div>
    <asp:Button ID="btnsave" runat="server" Text="保存" OnClientClick="saveitem()" OnClick="btnsave_Click" />
    <a href="/manager/ScenicTopicSetting.aspx">返回</a>
</asp:Content>
