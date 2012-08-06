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
    <p class="fuctitle">
        景区主题管理</p>
    <hr />
    <div id="scinfo">
        <asp:HiddenField ID="hiddentag" runat="server" />
    <div >
        <p class="interesttopic">
            可选择的主题标签：(点击后选择)</p>
        <div class="tagstore">
            <asp:Repeater ID="rptTopicStore" runat="server">
                <ItemTemplate>
                    <a><%#Eval("Name")%></a>
                </ItemTemplate>
            </asp:Repeater>
            </div>
    </div>
    <br />
    <div >
        <p class="interesttopic" style="margin-top:0px">已添加的主题标签：(点击后取消)</p>
        </div>
    <div>
        <ul id="taglist">
        <asp:Repeater ID="rptTopicOwn" runat="server">
            <ItemTemplate>
            <li onclick='delitem(this)'><a><%#Eval("Name") %></a></li>
            </ItemTemplate>
        </asp:Repeater>
            </ul>
    </div>
    <asp:Button ID="btnsave" runat="server"  OnClientClick="saveitem()" onclick="btnsave_Click" CssClass="topicbtn" />
    </div >
        
</asp:Content>
