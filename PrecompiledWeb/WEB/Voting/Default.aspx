<%@ page language="C#" autoeventwireup="true" inherits="Voting_Default, App_Web_cxsm5bsl" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <script src="../Scripts/jquery-1.4.1.js" type="text/javascript"></script>
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
            var _url = encodeURIComponent(document.location + "?uid=this_is_my_testid");
            var _assname = encodeURI("125158082"); //你注册的帐号，不是昵称
            var _appkey = encodeURI("12a31cffbe8fff2182b2863bb066b7fc"); //你从腾讯获得的appkey
            var _pic = encodeURI(''); //（例如：var _pic='图片url1|图片url2|图片url3....）
            var _t = "Mother fucker Title"; //$('.container hero-unit h1').valueOf(); //标题和描述信息
            var metainfo = document.getElementsByTagName("meta");
            for (var metai = 0; metai < metainfo.length; metai++) {
                if ((new RegExp('description', 'gi')).test(metainfo[metai].getAttribute("name"))) {
                    _t = metainfo[metai].attributes["content"].value;
                }
            }
            _t = document.title + _t; //请在这里添加你自定义的分享内容
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
    <div class="navbar navbar-fixed-top">
        <div class="navbar-inner">
            <div class="container">
                <a class="btn btn-navbar" data-toggle="collapse" data-target=".nav-collapse"><span
                    class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span>
                </a><a class="brand" href="#">投票专区</a>
                <div class="nav-collapse">
                    <ul class="nav">
                        <form id="Form1" runat="server">
                        <li class="active">
                            <asp:LoginName ID="LoginName1" runat="server" />
                        </li>
                        <li>
                            <asp:LoginStatus ID="LoginStatus1" runat="server" />
                        </li>
                        </form>
                    </ul>
                </div>
                <!--/.nav-collapse -->
            </div>
        </div>
    </div>
    <div class="container">
        <div class="subnav">
          <ul class="nav nav-pills">
            <li><a href="#javascript">杭州景区</a></li>
            <li><a href="#modals">宁波景区</a></li>
            <li><a href="#dropdowns">温州景区</a></li>
            <li><a href="#scrollspy">绍兴景区</a></li>
            <li><a href="#tabs">丽水景区</a></li>
            <li><a href="#tooltips">嘉兴景区</a></li>
            <li><a href="#popovers">湖州景区</a></li>
            <li><a href="#alerts">舟山景区</a></li>
            <li><a href="#buttons">金华景区</a></li>
            <li><a href="#collapse">衢州景区</a></li>
          </ul>
        </div>
        <!-- Main hero unit for a primary marketing message or call to action -->
        <div class="hero-unit">
            <h1>
                浙江省最受欢迎的景区评选</h1>
            <hr />
            <p>
                浙江旅游资源非常丰富，素有"鱼米之乡、丝茶之府、文物之邦、旅游胜地"之称。全省有重要地貌景观800多处、 水域景观200多处、生物景观100多处。人文景观100多处，自然风光与人文景观交相辉映，特色明显，知名度高。</p>
            <p>
                <a href="javascript:void(0)" onclick="postToWb();return false;" class="tmblog">
                    <img src="http://v.t.qq.com/share/images/s/b32.png"></a></p>
        </div>
        <!-- Example row of columns -->
        <div class="row">
            <asp:Repeater ID="rptSenic2Vote" runat="server">
                <ItemTemplate>
                    <div class="span6">
                        <h2>
                            <%#Eval("Name")%></h2>
                        <p>
                            <%#Eval("Desec") %>
                        </p>
                        <p>
                            <a class="btn" href="#">View details &raquo;</a></p>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</body>
</html>
