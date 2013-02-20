<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/uc.master" AutoEventWireup="true"
    CodeFile="OrderDetail.aspx.cs" Inherits="Hotels_OrderDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <style type="text/css">
        .order .tips
        {
            border: 1px solid #B7B7B7;
            background: #fffcd3;
            padding: 5px 25px 5px 10px;
            line-height:2em;
        }
        .bold
        {
            font-weight: bold;
        }
        .t18
        {
            font-size: 23px !important;
        }
        .orange
        {
            color: #B05200;
        }
        .osper
        {
            border: none !important;
            border-bottom: 1px dashed #CDCDCD !important;
            margin: 5px 0px 5px 0px;
            width: 90%;
            display: block;
            background: none;
        }
        .mt5{margin-top:5px;}
        p{margin-bottom:5px;}
        a:hover{color: #F60;
            text-decoration: underline;
            cursor: pointer;}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ucContent" runat="Server">
    <div class="order">
        <div class="tips">
            <p class="left">
                订单号：<asp:Label Text="lblorderid" runat="server" ID="lblorderid" />
                &nbsp;&nbsp;&nbsp;&nbsp;预订日期：<asp:Label Text="lblbookdate" runat="server" ID="lblbookdate" /><br>
                订单取消时间：<asp:Label Text="lblcindate" runat="server" ID="lblcindate" />&nbsp;24:00前<span
                    class="bold">免费取消</span>
            </p>
            <p class="right">
                <span>总金额：</span><span class="t18 orange">¥<asp:Label ID="lbltotalprice" CssClass="t18 orange bold"
                    Text="lbltotalprice" runat="server" /></span><br>
                <span>预订状态：<asp:Label ID="lblorderstatus" Text="lblorderstatus" runat="server" /></span>
            </p>
            <div class="clear">
            </div>
        </div>
        <div class="p10 mt5">
            <div class="pb5">
                <span class="larrowIcon ml10"></span>&nbsp;<span class="bold jdwidth">酒店信息</span>
                <span class="pl20">
                    <input method="updateOrder" type="button" class="gray_btn" onmousedown="this.className='gray_btn_on'"
                        onmouseup="this.className='gray_btn'" onmouseout="this.className='gray_btn'"
                        onfocus="this.blur()" value="修改"></span>
                        <a href="/usercenter/HotelOrder.aspx" style="float:right;margin-right:30px;margin-top:10px;">返回订单列表</a>
            </div>
            <table width="740" border="0" cellpadding="0" cellspacing="0" class="n_tab mt5 ml20">
                <tbody>
                    <tr>
                        <td colspan="3" class="t14">
                            <a class="t14 Anone" target="_blank" runat="server" id="ahotelname"><b>
                                <asp:Label Text="lblhotelname" runat="server" ID="lblhotelname" /></b></a>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            地<span class="simsun">&nbsp;&nbsp;&nbsp;&nbsp;</span>址：<asp:Label Text="lbladdress"
                                runat="server" ID="lbladdress" />
                            &nbsp;&nbsp; <span class="MapIcon"><a target="_blank" href="http://hotel.elong.com/detailmap_cn_01201081.html">
                            </a></span>
                        </td>
                    </tr>
                    <tr>
                        <td width="247">
                            电<span class="simsun">&nbsp;&nbsp;&nbsp;&nbsp;</span>话：<asp:Label Text="lblphone"
                                runat="server" ID="lblphone" />
                        </td>
                        <td width="252">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            入住日期：<asp:Label Text="lblcin" runat="server" ID="lblcin" />
                        </td>
                        <td>
                            离店日期：<asp:Label Text="lblcout" runat="server" ID="lblcout" />
                        </td>
                        <td>
                            到店时间：<asp:Label Text="lblarrivalearlytime" runat="server" ID="lblarrivalearlytime" />--
                            <asp:Label Text="lblarrivallatetime" runat="server" ID="lblarrivallatetime" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            房<span class="simsun">&nbsp;</span>间<span class="simsun">&nbsp;</span>数：<asp:Label
                                Text="lblroomnum" runat="server" ID="lblroomnum" />间
                        </td>
                        <td>
                            房<span class="simsun">&nbsp;&nbsp;&nbsp;&nbsp;</span>型：<asp:Label Text="lblroomtype"
                                runat="server" ID="lblroomtype" />
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </tbody>
            </table>
            <hr class="osper" />
            <div class="mt15">
                <span class="larrowIcon ml10"></span>&nbsp;<span class="bold">联系人信息</span> <span
                    class="pl20"><a name="changeCustom"></a>
                    <input type="button" class="gray_btn" onmousedown="this.className='gray_btn_on'"
                        onmouseup="this.className='gray_btn'" onmouseout="this.className='gray_btn'"
                        onfocus="this.blur()" value="修改" id="mod" method="mod"></span>
            </div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="n_list attach mt5 other"
                id="custom">
                <tbody>
                    <tr>
                        <td width="35%" class="pl20">
                            联系人姓名：<asp:Label Text="lblconname" runat="server" ID="lblconname" />
                        </td>
                        <td width="32%">
                            联系电话：<asp:Label Text="lblconphone" runat="server" ID="lblconphone" />
                        </td>
                        <td width="33%">
                            E-mail：
                        </td>
                    </tr>
                </tbody>
            </table>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="n_list attach mt5 other"
                id="modCustom" style="display: none">
                <tbody>
                    <tr>
                        <td width="35%" class="pl20">
                            联系人姓名：<input type="text" value="哈斯卡" style="width: 120px">
                            <input class="fi_in_w3" type="button" name="list" value=" ">
                        </td>
                        <td width="32%">
                            联系电话：<input type="text" value="180****7925">
                        </td>
                        <td width="33%">
                            E-mail：<input type="text" value="">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" class="pl20">
                            <div class="tc pt5">
                                <input type="button" class="gray_btn" name="ok" onmousedown="this.className='gray_btn_on'"
                                    onmouseup="this.className='gray_btn'" onmouseout="this.className='gray_btn'"
                                    onfocus="this.blur()" value="确定">
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <hr class="osper" />
            <div class="mt15">
                <span class="larrowIcon ml10"></span>&nbsp;<span class="bold">入住信息</span> <span class="pl20">
                    <input type="button" class="gray_btn" id="updateInfact" method="mod" onmousedown="this.className='gray_btn_on'"
                        onmouseup="this.className='gray_btn'" onmouseout="this.className='gray_btn'"
                        onfocus="this.blur()" value="修改">
                </span>
            </div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="n_list attach mt5 other">
                <tbody>
                    <tr id="infactTr">
                        <td class="pl20">
                            <ul class="rzgj_nat">
                                <li>
                                    <div>
                                        入住人：</div>
                                </li>
                                <li method="content">
                                    <div>
                                        <asp:Label Text="lblguestname" runat="server" ID="lblguestname" /></div>
                                </li>
                            </ul>
                        </td>
                    </tr>
                    <tr style="display: none" method="editInfactTr">
                        <td class="pl20">
                            <ul class="rzgj_natmod">
                                <li class="rzgj_natmodtxtbar">
                                    <div>
                                        入住人：</div>
                                </li>
                                <li method="group">
                                    <div>
                                        <input type="text" value="哈斯卡" method="name" orderitem="51079313"><input class="fi_in_w3"
                                            type="button" method="mod" name="infactDrop" value=" "></div>
                                </li>
                            </ul>
                        </td>
                    </tr>
                    <tr style="display: none" method="editInfactTr">
                        <td colspan="3" class="pl20">
                            <div class="tc pt5">
                                <input type="button" class="gray_btn" id="editInfactOk" onmousedown="this.className='gray_btn_on'"
                                    onmouseup="this.className='gray_btn'" onmouseout="this.className='gray_btn'"
                                    onfocus="this.blur()" value="确定">
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <hr class="osper" />
            <div class="mt15">
                <span class="larrowIcon ml10"></span>&nbsp;<span class="bold">支付信息</span></div>
            <table width="100%" border="0" cellspacing="0" cellpadding="0" class="n_list attach mt5 other">
                <tbody>
                    <tr>
                        <td width="35%" class="pl20">
                            支付类型：前台自付
                        </td>
                        <td width="32%">
                            支付方式：现金/银行卡
                        </td>
                        <td width="33%">
                            担保情况：未担保
                        </td>
                    </tr>
                    <tr>
                    </tr>
                </tbody>
            </table>
            <div class="tc mt20">
                <input method="updateOrder" type="button" id="modOrder" value="修改订单" onfocus="this.blur()"
                    onmouseout="this.className='search_bt'" onmouseup="this.className='search_bt'"
                    onmousedown="this.className='search_bt_an'" class="search_bt">
                <input type="button" value="取消订单" onfocus="this.blur()" onmouseout="this.className='search_bt ml20'"
                    onmouseup="this.className='search_bt ml20'" onmousedown="this.className='search_bt_an ml20'"
                    class="search_bt ml20" id="cancelBtn">
            </div>
        </div>
    </div>
</asp:Content>
