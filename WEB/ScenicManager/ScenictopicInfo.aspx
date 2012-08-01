<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true"
    CodeFile="ScenictopicInfo.aspx.cs" Inherits="ScenicManager_ScenictopicInfo" %>
    
<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
    <script type="text/javascript">
        $(function () {
            $(".tagstore>a").click(function () {
                var content = $("#taglist").html() + "<li>" + $(this).html() + "</li>";
                $("#taglist").html(content);
            });
            $("#taglist>li").click(function () {
                alert("hi~");
                $(this).remove();
            });
            $("#btnok").click(function () {
                $("#taglist>li");
                $.ajax({
                    type: "Post",
                    url: "TopicHandler.ashx",
                    dataType: "json",
                    data: { 'ticketname': ticketname, 'yuanjia': yuanjia, 'mingxipianjia': mingxipianjia, 'xianfujia': xianfujia, 'zaixianjia': zaixianjia, "ticketid": ticketid, "scid": scid },
                    success: function (data, status) {
                        result &= data;
                    }
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <div >
<br />
    <div>
        <p>
            你可能感兴趣的标签：</p>
        <div class="tagstore">
            <asp:Repeater ID="rptTopicStore" runat="server">
                <ItemTemplate>
                    <a><%#Eval("Name") %></a>
                </ItemTemplate>
            </asp:Repeater>
            </div>
    </div></div>
    <br />
    <div >
        <p>我已经添加的标签：</p>
        </div>
    <div>
        <ul id="taglist">
        <asp:Repeater ID="rptTopicOwn" runat="server">
            <ItemTemplate>
            <li><%#Eval("Name") %></li>
            </ItemTemplate>
        </asp:Repeater>
            </ul>
        <div class="clear">
        </div>
    </div>
    <input id="btnok" type="button"value="确定" />
</asp:Content>
