<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="_Default, App_Web_v5zntehw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/jquery-1.4.1.js" type="text/javascript"></script>
    <script src="Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="Scripts/jquery.cookie.js" type="text/javascript"></script>
    <link href="Styles/DefaultStyle.css" rel="stylesheet" type="text/css" />
    <link href="Styles/VotingStyle.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page">
        <div id="ucNav">
            <asp:Repeater ID="Repeater2" runat="server" 
                onitemdatabound="Repeater2_ItemDataBound">
                <HeaderTemplate><div class="area">
                浙&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 江</div></HeaderTemplate>
                <ItemTemplate>
                    <a id="areaa" runat="server" class="areatour" href='<%# Eval("AreaOrder","Default.aspx?areaid={0}") %>'><%# Eval("Name") %></a>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div id="ucMain">
            <div class="play">
                <ul>
                    <li class="textbg"></li>
                    <li class="text"></li>
                    <li class="num"><a>1</a><a>2</a><a>3</a><a>4</a><a>5</a></li>
                    <li class="content"><a href="ScenicDesc.aspx?scid=1" target="_blank">
                        <img src="ScenicImg/123_image.jpg" alt="澳大利亚：体验蓝山风光，感受澳洲风情" /></a> <a href="ScenicDesc.aspx?scid=2"
                            target="_blank">
                            <img src="ScenicImg/1942462_1035049_14e6ffe916_o.jpg" alt="九月抄底旅游，马上行动" /></a>
                        <a href="ScenicDesc.aspx?scid=3" target="_blank">
                            <img src="ScenicImg/1942464_1035049_0167aafbb3_o.jpg" alt="港澳旅游：超值特价，奢华享受" /></a>
                        <a href="ScenicDesc.aspx?scid=4" target="_blank">
                            <img src="ScenicImg/1942465_1035049_d8e71a74c1_o.jpg" alt="炎炎夏日哪里去，途牛带你海滨游" /></a>
                        <a href="ScenicDesc.aspx?scid=5" target="_blank">
                            <img src="ScenicImg/safe_image.jpg" alt="定途牛旅游线路，优惠购买乐相册" /></a></li>
                </ul>
            </div>
            <script type="text/javascript">
                var t = n = 0, count = $(".content a").size();
                $(function () {
                    var play = ".play";
                    var playText = ".play .text";
                    var playNum = ".play .num a";
                    var playConcent = ".play .content a";

                    $(playConcent + ":not(:first)").hide();
                    $(playText).html($(playConcent + ":first").find("img").attr("alt"));
                    $(playNum + ":first").addClass("on");
                    $(playText).click(function () { window.open($(playConcent + ":first").attr('href'), "_blank") });
                    $(playNum).click(function () {
                        var i = $(this).text() - 1;
                        n = i;
                        if (i >= count) return;
                        $(playText).html($(playConcent).eq(i).find("img").attr('alt'));
                        $(playText).unbind().click(function () { window.open($(playConcent).eq(i).attr('href'), "_blank") })
                        $(playConcent).filter(":visible").hide().parent().children().eq(i).fadeIn(1200);
                        $(this).removeClass("on").siblings().removeClass("on");
                        $(this).removeClass("on2").siblings().removeClass("on2");
                        $(this).addClass("on").siblings().addClass("on2");
                    });
                    t = setInterval("showAuto()", 5000);
                    $(play).hover(function () { clearInterval(t) }, function () { t = setInterval("showAuto()", 5000); });
                })
                function showAuto() {
                    n = n >= (count - 1) ? 0 : ++n;
                    $(".num a").eq(n).trigger('click');
                }

            </script>
            <div id="tourcontent">
                <table cellpadding="10px">
                    <tr>
                        <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                            <HeaderTemplate>
                                <td><p style="width:200px;">浙江省杭州市</p></td></tr><tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <td>
                                    <img src='<%# Eval("Scenic.Photo","ScenicImg/{0}") %>' alt='<%# Eval("Scenic.Name") %>' />
                                    <h3>
                                        <%# Eval("Scenic.Name")%></h3>
                                    <h4>
                                        <%# Eval("Ticket.Name") %></h4>
                                    <h5 style="text-decoration: line-through">
                                        原价：<%# Eval("Price1")%></h5>
                                    <h5>
                                        预订价：<%# Eval("Price2")%></h5>
                                        <h5>
                                        优惠价：<%# Eval("Price3")%></h5>
                                        <h5>
                                        电子明信片价：<%# Eval("Price4")%></h5>
                                        <h5>
                                        实际明信片价：<%# Eval("Price5")%></h5>
                                    <a href='<%# Eval("Scenic.Id","ScenicDesc.aspx?scid={0}") %>'>查看详情</a>
                                </td>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div id="myDiv" style="display: none">
    </div>
    <div class="popupcontent" id="logindiv">
        <div>
            <span onclick="show('register')">登陆</span><span onclick="show('visitor')">游客</span></div>
        <hr />
        <div>
            <div id="visitor" style="display: none">
                <table>
                    <tr>
                        <td>
                            姓名:
                        </td>
                        <td>
                            <input type="text" id="visitorname" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            身份证:
                        </td>
                        <td>
                            <input type="text" id="visitorid" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            联系电话:
                        </td>
                        <td>
                            <input type="text" id="visitorphone" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <input type="button" value="关闭" style="float: right" onclick="hidePopup('logindiv');" />
                            <input type="button" value="确定" style="float: right" onclick="msgconfirm()" />
                        </td>
                    </tr>
                </table>
            </div>
            <div id="register" style="display: block">
                <div id="errormsg" style="display: block">
                </div>
                <table>
                    <tr>
                        <td>
                            用户名:
                        </td>
                        <td>
                            <input type="text" id="username" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            密码:
                        </td>
                        <td>
                            <input type="text" id="userpsw" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <input type="button" value="关闭" style="float: right" onclick="hidePopup('logindiv');" />
                            <input type="button" value="确定" style="float: right" onclick="loginUser()" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    <div class="popupcontent" id="confirmdiv">
    </div>
    <div id="voting" style="display: none;">
        <div style="position: relative;">
            <div style="float: right; border: 1px solid black; width: 10px; height: 8px; cursor: pointer;"
                onclick="closevoting()">
                ×</div>
            <p>
                网上投票</p>
            &nbsp;<table cellpadding="10px" style="width: 90%; margin: 0px auto; text-align: left;">
                <tr>
                    <td>
                        身份证号：
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        所要投票的景点:
                    </td>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="杭州市西湖风景区"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="Button2" runat="server" Text="投票" />&nbsp;&nbsp;&nbsp;<asp:Button
                            ID="Button3" runat="server" Text="取消" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
