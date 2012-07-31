<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true"
    CodeFile="ScenictopicInfo.aspx.cs" Inherits="ScenicManager_ScenictopicInfo" %>
    
<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
    <style type="text/css">
        .setupTag_box {
        overflow: hidden;
        margin-top: 10px;
        height: 160px;
        background: url("../../../images/setup/t36/tips_bg.jpg?id=1341302813656") no-repeat 50% 0;
        -moz-border-radius: 3px 3px 0 0;
        -webkit-border-radius: 3px 3px 0 0;
        border-color: #D7F5FF;
        border-right: 1px solid #D7F5FF;
        border-style: none solid solid;
        border-width: 0 1px 1px;
        }
        .setupTag_boxL {
        float: left;
        padding-top: 60px;
        width: 360px;
        padding-left: 24px;
        }
    .setupTag_boxR {
        -moz-border-radius: 3px;
        background: none repeat scroll 0 0 white;
        display: inline;
        float: right;
        height: 110px;
        margin: 10px 10px 0 0;
        padding: 15px 20px;
        width: 290px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <div class="setupTag_box">
        <div class="setupTag_boxL">
        <input type="text" value="多个标签词之间请用空格分开"/>
        <input type="button" value="添加标签" />
        </div>
    <div class="setupTag_boxR">
        <p>
            你可能感兴趣的标签：</p>
        <div class="setupTag_list01">
            <asp:Repeater ID="rptTopicStore" runat="server">
                <ItemTemplate><a title="添加标签" href="#" tagid='<%#Eval("Id") %>'><em>+</em><%#Eval("Name") %></a>
                </ItemTemplate>
            </asp:Repeater>
            </div>
    </div></div>
    <div class="setupTag_tit MIB_linedot" id="mytagshow1">
        <em class="font_14">我已经添加的标签：</em>
        </div>
    <div id="mytagshow2" class="setupTag_list02">
        <ul id="tag_list" class="tagList">
        <asp:Repeater ID="rptTopicOwn" runat="server">
            <ItemTemplate>
            <li node-type="li" title='<%#Eval("Name") %>' onmouseover="this.className='bg';" onmouseout="this.className='';"
                class=""><a class="a1" href="#" node-type="text"><%#Eval("Name") %></a> <a class="a2" node-type="del"
                    title="删除标签" tagid="180961" href="#" onclick="return false">
                    <img src="http://img.t.sinajs.cn/t36/style/images/common/transparent.gif"></a></li>
            </ItemTemplate>
        </asp:Repeater>
            </ul>
        <div class="clear">
        </div>
    </div>
</asp:Content>
