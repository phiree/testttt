<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Voting_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            padding-top: 60px;
            padding-bottom: 40px;
            font-family: 微软雅黑,Tahoma;
        }
    </style>
    <script type="text/javascript">
        function postToWb() {
            var _url = encodeURIComponent(document.location + "?promid=" + "<%=MemberId %>&&urlfrom=" + "<%=Urlfrom%>");
            var _assname = encodeURI("125158082"); //你注册的帐号，不是昵称
            var _appkey = encodeURI("12a31cffbe8fff2182b2863bb066b7fc"); //你从腾讯获得的appkey
            var _pic = encodeURI(''); //（例如：var _pic='图片url1|图片url2|图片url3....）
            var _t = "浙江省最受欢迎的景区评选"; //$('.container hero-unit h1').valueOf(); //标题和描述信息
            var metainfo = document.getElementsByTagName("meta");
            for (var metai = 0; metai < metainfo.length; metai++) {
                if ((new RegExp('description', 'gi')).test(metainfo[metai].getAttribute("name"))) {
                    _t = metainfo[metai].attributes["content"].value;
                }
            }
            //_t = $("#herodiv h1").html() + _t; //请在这里添加你自定义的分享内容
            if (_t.length > 120) {
                _t = _t.substr(0, 117) + '...';
            }
            _t = encodeURI(_t);
            var _u = 'http://share.v.t.qq.com/index.php?c=share&a=index&url=' + _url + '&appkey=' + _appkey + '&pic=' + _pic + '&assname=' + _assname + '&title=' + _t;
            window.open(_u, '', 'width=700, height=680, top=0, left=0, toolbar=no, menubar=no, scrollbars=no, location=yes, resizable=no, status=no');
        }
    </script>
</head>
<body>
    <form id="Form1" runat="server">
    <div class="navbar navbar-fixed-top">
        <div class="navbar-inner">
            <div class="container">
                <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse"><span
                    class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span>
                </a><a class="brand" href="Default.aspx">投票专区</a>
                <div class="nav-collapse">
                    <ul class="nav">
                        <li class="active"><a>
                            <asp:LoginName ID="LoginName1" runat="server" />
                        </a></li>
                        <li>
                            <asp:LoginStatus CssClass="active" ID="LoginStatus1" runat="server" />
                        </li>
                        <li class="active" style="float: right"><a class="" href="../usercenter/MyVote.aspx">
                            我的投票</a></li>
                    </ul>
                    <ul class="nav pull-right">
                        <li class="dropdown"><a href="#" class="dropdown-toggle" data-toggle="dropdown">帐号 <b
                            class="caret active"></b></a>
                            <ul class="dropdown-menu">
                                <li><a href="#" onclick="getDoc();">info1</a></li>
                                <li><a href="#" onclick="getInfo();">info2</a></li>
                                <li><a href="#" onclick="getToken();">info3</a></li>
                                <li class="divider"></li>
                                <li><a href="#" onclick="getCookie();">Logout</a></li>
                            </ul>
                        </li>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </div>
    </div>
    <div class="container">
        <div class="subnav">
            <ul class="nav nav-pills">
                <asp:Repeater ID="rptArea2Vote" runat="server">
                    <ItemTemplate>
                        <li><a href='?areacode=<%#Eval("Code")%>'>
                            <%#Eval("Name").ToString().Split('省')[1]%></a> </li>
                    </ItemTemplate>
                    <HeaderTemplate>
                        <li><a href="VoteHot.aspx" class="btn btn-danger">热点景区</a></li></HeaderTemplate>
                </asp:Repeater>
            </ul>
        </div>
        <!-- Main hero unit for a primary marketing message or call to action -->
        <div class="hero-unit" id="herodiv">
            <h1>
                浙江省最受欢迎的景区评选</h1>
            <hr />
            <p>
                浙江旅游资源非常丰富，素有"鱼米之乡、丝茶之府、文物之邦、旅游胜地"之称。全省有重要地貌景观800多处、 水域景观200多处、生物景观100多处。人文景观100多处，自然风光与人文景观交相辉映，特色明显，知名度高。</p>
            <p>
                <a href="javascript:void(0)" onclick="postToWb();return false;" class="tmblog">
                    <img src="http://v.t.qq.com/share/images/s/b32.png"></a> </p>
        </div>
        <!-- Example row of columns -->
        <div>
            <asp:Repeater ID="rptSenic2Vote" runat="server" OnItemCommand="rptSenic2Vote_ItemCommand">
                <ItemTemplate>
                <li class="span3">
                    <div class="thumbnail"> 
                        <%--<img src="http://placehold.it/575x150" alt="">--%>
                        <img src="http://placehold.it/280x160" alt="">
                        <h3 id="scenicname">
                            <%#Eval("Name")%></h3>
                        <p>
                            <%# ((String)(Eval("Desec")??"")).Length > 35 ? ((String)Eval("Desec")).Substring(0, 32)+ "..." : Eval("Desec")%>
                        </p>
                        <p>
                            <asp:Button runat="server" CssClass="btn" Text="详情 &raquo;" ID="btnDetail" CommandName="detail"
                                CommandArgument='<%#Eval("Id")%>' />
                            <asp:Button runat="server" CssClass="btn btn-info" Text="投票 &raquo;" ID="btnVote"
                                 CommandName="vote" CommandArgument='<%#Eval("Id")%>' /></p>
                    </div></li>
                </ItemTemplate>
                <HeaderTemplate>
                    <ul class="thumbnails" style="float: left">
                </HeaderTemplate>
                <FooterTemplate>
                    </ul></FooterTemplate>
            </asp:Repeater>
        </div>
        <!-- Footer -->
        <footer class="footer">
            <a class="pull-right" href="#">Back to top</a>
        </footer>
    </div>
    </form>
</body>
</html>
<script src="../Scripts/jquery-1.7.2.min.js" type="text/javascript"></script>
<script src="../Scripts/bootstrap.js" type="text/javascript"></script>
