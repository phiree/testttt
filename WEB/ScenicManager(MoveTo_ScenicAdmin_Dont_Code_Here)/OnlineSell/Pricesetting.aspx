<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true" CodeFile="Pricesetting.aspx.cs" Inherits="ScenicManager_OnlineSell_Pricesetting2" %>
<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" Runat="Server">
<link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function btnunable() {
            alert("请先完成上述步骤，再点击上传票价");
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <p class="fuctitle">
        景区门票信息</p>
    <hr />
    <p runat="server" id="weldiv" class="priceintro" style="border:1px solid #BABABA; padding:5px;">
        &nbsp;&nbsp;&nbsp;&nbsp;<span runat="server" id="scenicname"></span>景区管理员您好，欢迎您首次登录景区门票设置页面，通过该页面您可以上传
        并设置该门票的价格，我们承诺门票价格一经我们网站核对，将以上传价格显示在网站上，绝不会提高价格来赚取差价。
    </p>
    <div id="shprice" style="border:none; padding:5px;padding-left:20px;color:#666666">
        门票设置细则：<br />
        1、请景区管理员在步骤一中填写门票的门票以及价格<br />
        2、填写完价格后请在第二步把门票的价格打印出来，盖上公章，拍照，以传真或者文件的形式上传给我们<br />
        3、如果是需要把打印的文件上传给我们，则可以通过第三个步骤，如果以发传真给我们，则可以跳过此步骤<br />
        4、提交票价信息<br />
        5、在价格提交后，该景区的门票将暂时无法上架，经过我们网站核对后，我们将第一时间通知您，核对结果，如果通过，则会第一时间把门票显示到网站上
        6、绿色的箭头表示您设置门票的进度
        <hr style="margin-left:0px;" />
        <div class="stepstate">
            <span runat="server" id="step_1" class="stepicon">→</span><a class="step" href="OnlinePrice.aspx" id="astep_1" runat="server">1.&nbsp;填写售票价格:</a><div style="display:block;clear:both"></div>
            <span runat="server" id="step_2" class="stepicon">→</span><a class="step" href="PrintScenicPrice.aspx" id="astep_2" runat="server">2.&nbsp;打印,盖公章,拍照</a><div style="display:block;clear:both"></div>
            <span runat="server" id="step_3" class="stepicon">→</span><a class="step" href="Uploadscenicprice.aspx" id="astep_3" runat="server">3.&nbsp;上传更改景区价格文件</a><div style="display:block;clear:both"></div>
            <span runat="server" id="step_4" class="stepicon">→</span><div style="margin: 0px 0px 20px 0px" id="astep_4" runat="server">
                <asp:Button ID="btnApply" runat="server" CssClass="btnapply"  onclick="btnApply_Click"  /></div>
        </div>
    </div>
</asp:Content>

