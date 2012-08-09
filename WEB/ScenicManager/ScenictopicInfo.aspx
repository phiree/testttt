<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true"
    CodeFile="ScenictopicInfo.aspx.cs" Inherits="ScenicManager_ScenictopicInfo" %>

<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(function () {
            $(".tagstore>a").click(function () {
                var isexsit = false;
                var selectedone = $(this).html();
                $("#taglist>a").each(function () {
                    if ($.trim($(this).html()) == $.trim(selectedone)) {
                        isexsit = true;
                    }
                });
                if (!isexsit) {
                    var content = $("#taglist").html() + "<a onclick='delitem(this)' class='hlv'>" + selectedone + "</a>";
                    $("#taglist").html(content);
                }
            });
            //            $("#btnok").click(function () {
            //                var scenicnames = "";
            //                $("#taglist>a").each(function () {
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
        });
        function delitem(obj) {
            $(obj).remove();
        }
        function saveitem() {
            var scenicnames = "";
            $("#taglist>a").each(function () {
                scenicnames += $(this).html() + "+";
            });
            $("#<%=hiddentag.ClientID%>").val(scenicnames);
        }
    </script>
    <style type="text/css">
        .hla, .hlv, .hlt, .hla:link, .hla:active, .hla:visited, .hla:hover, .hlv:link, .hlv:active, .hlv:visited, .hlv:hover, .hlt:link, .hlt:active, .hlt:visited, .hlt:hover
        {
            color: #009F3C;
            font-weight: 700;
            border: 1px solid #A6DF9E;
            background-color: #D1EFCD;
            padding: 3px 5px 3px 5px;
            margin-top: -4px;
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <p class="fuctitle">
        景区主题</p>
    <hr />
    <div id="scinfo">
        <div>
            <br />
            <asp:HiddenField ID="hiddentag" runat="server" />
            <div>
                <p>
                    你可能感兴趣的标签：</p>
                <div class="tagstore">
                    <asp:Repeater ID="rptTopicStore" runat="server">
                        <ItemTemplate>
                            <a class="hlv">
                                <%#Eval("Name")%></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
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
                    <a onclick='delitem(this)' class="hlv">
                        <%#Eval("Name") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <br />
        <asp:Button ID="btnsave" runat="server" Text="保存" OnClientClick="saveitem()" OnClick="btnsave_Click" /></div>
</asp:Content>
