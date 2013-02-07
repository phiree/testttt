<%@ Page Title="" Language="C#" MasterPageFile="~/sm.master" AutoEventWireup="true"
    CodeFile="ScenictopicInfo.aspx.cs" Inherits="ScenicManager_ScenictopicInfo" %>

<%@ MasterType VirtualPath="~/sm.master" %>
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
        });
        function delitem(obj) {
            $(obj).remove();
        }
        function saveitem() {
            var scenicnames = "";
            $("#taglist>a").each(function () {
                scenicnames += $.trim($(this).html()) + "+";
            });
            $("#<%=hiddentag.ClientID%>").val(scenicnames);
        }
    </script>
    <style type="text/css">
        .hla, .hlv, .hlt, .hla:link, .hla:active, .hla:visited, .hla:hover, .hlv:link, .hlv:active, .hlv:visited, .hlv:hover, .hlt:link, .hlt:active, .hlt:visited, .hlt:hover
        {
            display:block;
            float:left;
            color: #009F3C;
            font-weight: 700;
            border: 1px solid #A6DF9E;
            background-color: #D1EFCD;
            padding: 3px 5px 3px 5px;
            margin-top: 5px;
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
                <p style="margin-left:15px;">
                    你可能感兴趣的标签（单击标签添加）：</p>
                <div class="tagstore">
                    <asp:Repeater ID="rptTopicStore" runat="server">
                        <ItemTemplate>
                            <a class="hlv" style="margin-bottom:0px;">
                                <%#Eval("Name")%></a>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <br />
        <div style="clear:both; padding-top:20px;">
            <p style="margin-left:10px;">
                我已经添加的标签（单击标签删除）：</p>
        </div>
        <div id="taglist" style="margin-left:15px;">
            <asp:Repeater ID="rptTopicOwn" runat="server">
                <ItemTemplate>
                    <a onclick='delitem(this)' class="hlv">
                        <%#Eval("Name") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div style="clear:both;"></div>
        <br />
        <asp:Button ID="btnsave" runat="server" OnClientClick="saveitem()" OnClick="btnsave_Click" CssClass="btnsaveimg enable" style="clear:both;margin-left:15px;margin-bottom:20px;" /></div>
</asp:Content>
