<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true"
    CodeFile="ScenictopicInfo.aspx.cs" Inherits="ScenicManager_ScenictopicInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <div>
        <input type="text" class="setupTag_txt" id="tag_input" value="多个标签词之间请用空格分开" style="">
        <a id="add_tag" href="javascript:;" class="btn_normal"><em>添加标签</em></a></div>
    <div class="setupTag_boxR">
        <p class="setupTag_tip2">
            <span class="rt lightblue"><a href="#">换一换</a></span>你可能感兴趣的标签：</p>
        <div class="setupTag_list01">
            <a title="添加标签" href="#" tagid="1033"><em>+</em>上网</a><a title="添加标签" href="#" tagid="320"><em>+</em>搞笑</a><a
                title="添加标签" href="#" tagid="290"><em>+</em>吃</a><a title="添加标签" href="#" tagid="123"><em>+</em>平常心</a><a
                    title="添加标签" href="#" tagid="4640"><em>+</em>巨蟹座</a><a title="添加标签" href="#" tagid="1875"><em>+</em>爱情</a><a
                        title="添加标签" href="#" tagid="979"><em>+</em>摄影爱好者</a><a title="添加标签" href="#" tagid="56"><em>+</em>宅男</a><a
                            title="添加标签" href="#" tagid="624"><em>+</em>新闻</a><a title="添加标签" href="#" tagid="1395"><em>+</em>写作</a></div>
    </div>
    <div class="setupTag_tit MIB_linedot" id="mytagshow1">
        <a class="rt" href="javascript:void(0);" id="recommendtag">将我的标签推荐给朋友</a><em class="font_14">我已经添加的标签：</em></div>
    <div id="mytagshow2" class="setupTag_list02">
        <ul id="tag_list" class="tagList">
            <li node-type="li" title="温州医学院" onmouseover="this.className='bg';" onmouseout="this.className='';"
                class=""><a class="a1" href="http://s.weibo.com/user/&amp;tag=%E6%B8%A9%E5%B7%9E%E5%8C%BB%E5%AD%A6%E9%99%A2"
                    node-type="text">温州医学院</a><a class="a2" node-type="del" title="删除标签" tagid="180961"
                        href="#" onclick="return false"><img src="http://img.t.sinajs.cn/t36/style/images/common/transparent.gif"></a></li><li
                            node-type="li" title="30年环游世界" onmouseover="this.className='bg';" onmouseout="this.className='';"
                            class=""><a class="a1" href="http://s.weibo.com/user/&amp;tag=30%E5%B9%B4%E7%8E%AF%E6%B8%B8%E4%B8%96%E7%95%8C"
                                node-type="text">30年环游世界</a><a class="a2" node-type="del" title="删除标签" tagid="201107240006447523"
                                    href="#" onclick="return false"><img src="http://img.t.sinajs.cn/t36/style/images/common/transparent.gif"></a></li><li
                                        node-type="li" title="尝试新鲜事物" onmouseover="this.className='bg';" onmouseout="this.className='';"
                                        class=""><a class="a1" href="http://s.weibo.com/user/&amp;tag=%E5%B0%9D%E8%AF%95%E6%96%B0%E9%B2%9C%E4%BA%8B%E7%89%A9"
                                            node-type="text">尝试新鲜事物</a><a class="a2" node-type="del" title="删除标签" tagid="26317"
                                                href="#" onclick="return false"><img src="http://img.t.sinajs.cn/t36/style/images/common/transparent.gif"></a></li><li
                                                    node-type="li" title="创业" onmouseover="this.className='bg';" onmouseout="this.className='';"
                                                    class=""><a class="a1" href="http://s.weibo.com/user/&amp;tag=%E5%88%9B%E4%B8%9A"
                                                        node-type="text">创业</a><a class="a2" node-type="del" title="删除标签" tagid="1336" href="#"
                                                            onclick="return false"><img src="http://img.t.sinajs.cn/t36/style/images/common/transparent.gif"></a></li><li
                                                                node-type="li" title="dotnet" onmouseover="this.className='bg';" onmouseout="this.className='';"
                                                                class=""><a class="a1" href="http://s.weibo.com/user/&amp;tag=dotnet" node-type="text">
                                                                    dotnet</a><a class="a2" node-type="del" title="删除标签" tagid="17845" href="#" onclick="return false"><img
                                                                        src="http://img.t.sinajs.cn/t36/style/images/common/transparent.gif"></a></li><li
                                                                            node-type="li" title="不成股神成股圣" onmouseover="this.className='bg';" onmouseout="this.className='';"
                                                                            class=""><a class="a1" href="http://s.weibo.com/user/&amp;tag=%E4%B8%8D%E6%88%90%E8%82%A1%E7%A5%9E%E6%88%90%E8%82%A1%E5%9C%A3"
                                                                                node-type="text">不成股神成股圣</a><a class="a2" node-type="del" title="删除标签" tagid="201203300010224043"
                                                                                    href="#" onclick="return false"><img src="http://img.t.sinajs.cn/t36/style/images/common/transparent.gif"></a></li><li
                                                                                        node-type="li" title="川藏骑行318" onmouseover="this.className='bg';" onmouseout="this.className='';"
                                                                                        class=""><a class="a1" href="http://s.weibo.com/user/&amp;tag=%E5%B7%9D%E8%97%8F%E9%AA%91%E8%A1%8C318"
                                                                                            node-type="text">川藏骑行318</a><a class="a2" node-type="del" title="删除标签" tagid="201204290008803576"
                                                                                                href="#" onclick="return false"><img src="http://img.t.sinajs.cn/t36/style/images/common/transparent.gif"></a></li><li
                                                                                                    node-type="li" title="进城务工人员" onmouseover="this.className='bg';" onmouseout="this.className='';"
                                                                                                    class=""><a class="a1" href="http://s.weibo.com/user/&amp;tag=%E8%BF%9B%E5%9F%8E%E5%8A%A1%E5%B7%A5%E4%BA%BA%E5%91%98"
                                                                                                        node-type="text">进城务工人员</a><a class="a2" node-type="del" title="删除标签" tagid="488812"
                                                                                                            href="#" onclick="return false"><img src="http://img.t.sinajs.cn/t36/style/images/common/transparent.gif"></a></li><li
                                                                                                                node-type="li" title="财务自由之路" onmouseover="this.className='bg';" onmouseout="this.className='';"
                                                                                                                class=""><a class="a1" href="http://s.weibo.com/user/&amp;tag=%E8%B4%A2%E5%8A%A1%E8%87%AA%E7%94%B1%E4%B9%8B%E8%B7%AF"
                                                                                                                    node-type="text">财务自由之路</a><a class="a2" node-type="del" title="删除标签" tagid="221011280001646201"
                                                                                                                        href="#" onclick="return false"><img src="http://img.t.sinajs.cn/t36/style/images/common/transparent.gif"></a></li><li
                                                                                                                            node-type="li" title="Livermore" onmouseover="this.className='bg';" onmouseout="this.className='';"
                                                                                                                            class=""><a class="a1" href="http://s.weibo.com/user/&amp;tag=Livermore" node-type="text">
                                                                                                                                Livermore</a><a class="a2" node-type="del" title="删除标签" tagid="211007240000034041"
                                                                                                                                    href="#" onclick="return false"><img src="http://img.t.sinajs.cn/t36/style/images/common/transparent.gif"></a></li></ul>
        <div class="clear">
        </div>
    </div>
</asp:Content>
