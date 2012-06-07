<%@ Page Title="" Language="C#" MasterPageFile="~/UserCenter/uc.master" AutoEventWireup="true"
    CodeFile="OrderDetail.aspx.cs" Inherits="UserCenter_MyOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <link href="/theme/default/css/global.css" rel="stylesheet" type="text/css" />
    <link href="/theme/default/css/checkout.css" rel="stylesheet" type="text/css" />
    <link href="../theme/default/css/ucdefault.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function openusedetail(obj) {
            var url = "UseDetail.aspx?odid=" + obj;
            window.open(url, "", "height=300,width=400,top=0,left=0,toolbar=no,menubar=no,scrollbars=no,resizable=no,location=no,status=no");
        }

        $(document).ready(function () {
            $("[id$='txtsearchname']").InlineTip({ "tip": "请输入姓名" });
            //鼠标放到输入联系人文本框时,自动显示常用联系人
            var originalTop;
            $(".aa").hover(function () {
                if ($(this).attr("use") != "t") {
                    $("#contactlist").show();
                    var rowIndex = $(this).parent().parent().index();
                    var contactlist = $("#contactlist");
                    contactlist.show();
                    if (originalTop == null) {
                        originalTop = contactlist.position().top;
                    }
                    var left = $(this).position().left;
                    var width = $(this).width();

                    var height = $(this).parent().parent().height() * rowIndex;
                    contactlist.css({ left: left + width + 10 + "px", top: originalTop + 10 + "px" });

                    contactlist.attr("tid", $(this).attr("tid"));
                }
            });

            //点击常用联系人之后,确定一种分配关系
            //生成门票分配数据
            var assign = new Array();

            $(".assignitem").click(function () {
                var that = this;
                var ticketid = $("#contactlist").attr("tid");

                var nameinput = ".aa[tid='" + ticketid + "']";
                var idcardinput = ".bb[tid='" + ticketid + "']";
                if ($(that).attr("all") == "") {
                    nameinput = ".aa";
                    idcardinput = ".bb";
                    that = $(that).prev();
                }
                var commuserId = $(that).attr("cid");
                var name = $(that).text().trim();
                var idcard = $(that).attr("idcard");

                var inputname = $(nameinput);
                var inputidcard = $(idcardinput);
                for (var i = 0; i < inputname.length; i++) {
                    $(inputname[i]).val(name);
                    $(inputidcard[i]).val(idcard);
                    $(inputidcard[i]).attr("cid", commuserId);

                }
                $("#contactlist").hide();

            });

            $("body").click(function () {
                $("#contactlist").hide();
            });
        });

        function btn2(obj) {
            $("[id$='hfodid']").val(obj);
            $("[id$='Button2']").click();
        }

        function btnqueren(obj) {
            $("[id$='txtdetailname']").val($(obj).html().toString().trim());
            $("[id$='txtdetailidcard']").val($(obj).attr("title"));
        }



        
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ucContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="otop">
        <a href="Order.aspx" style=" margin-right:15px;color:#C9C9C9">我的订单</a><a style=" margin-right:15px; color:#C9C9C9">></a><a runat="server" id="oredernum" style="text-decoration:none">订单3</a></div>
    <div id="oscdpinfo">
        <div class="oscdptop">
            <span runat="server" id="paystate" style=" color: Black;"></span>
        </div>
        <div style="display: none">
            <asp:HiddenField ID="hfodid" runat="server" />
        </div>
        <asp:Repeater ID="rptOrderDetail" runat="server" OnItemDataBound="rptOrderDetail_ItemDataBound">
            <HeaderTemplate>
                <div class="oscdptitle">
                    <span class="oscfirst">景区名称</span><span class="oscsecond">购票方式</span><span class="oscthird">价格</span>
                    <span class="oscfour">数量</span><span class="oscfifth">小计</span><span class="oscsix">使用情况</span><span
                        class="oscseven">使用详情</span>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:HiddenField ID="hfid" runat="server" Value='<%# Eval("Id") %>' />
                <div runat="server" id="itemod" class="oscdpdetail" style="display: block;">
                    <span class="oscfirst">
                        <a href='<%# "/"+Eval("TicketPrice.Ticket.Scenic.Area.SeoName")+"/"+Eval("TicketPrice.Ticket.Scenic.SeoName")+".html"%>'><%# Eval("TicketPrice.Ticket.Scenic.Name")%></a></span><span class="oscsecond" runat="server"
                            id="buytype"></span><span class="oscthird" runat="server" id="tp"><%# Eval("TicketPrice.Price","{0:0}")%></span><span
                                class="oscfour" runat="server" id="qua"><%# Eval("Quantity")%></span><span class="oscfifth"><span
                                    id="sumprice" runat="server"></span>元</span><span class="oscsix"><span id="usedstate"
                                        runat="server"></span></span><span class="oscseven"><a id="usedetail" style="cursor: pointer"
                                            runat="server" onclick='<%# Eval("Id","openusedetail({0})") %>'>使用详情</a></span>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptOrderDetail2" runat="server" 
            onitemdatabound="rptOrderDetail2_ItemDataBound">
            <HeaderTemplate>
                <div class="oscdptitle">
                    <span class="oscfirst" style=" margin-left:0px;">景区名称</span><span class="oscsecond">预定价</span><span class="oscthird" style=" width:100px">已使用数量</span>
                    <span class="oscfour" style=" width:100px">未使用数量</span><span class="oscfifth">小计</span><span class="oscsix">使用情况</span><span
                        class="oscseven" style="margin-left:15px;">使用详情</span>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:HiddenField ID="hfid" runat="server" Value='<%# Eval("Id") %>' />
                <div runat="server" id="itemod" class="oscdpdetail" style="display: block;">
                    <span class="oscfirst" style=" margin:0px;">
                        <a href='<%# "/"+Eval("TicketPrice.Ticket.Scenic.Area.SeoName")+"/"+Eval("TicketPrice.Ticket.Scenic.SeoName")+".html"%>'><%# Eval("TicketPrice.Ticket.Scenic.Name")%></a></span>
                     <span class="oscsecond" runat="server" id="ydprice" style="margin-left:5px" ><%# Eval("TicketPrice.Price","{0:0}")%></span>
                     <span class="oscthird" runat="server" id="usedcount" style="width:100px"></span>
                     <span class="oscfour" runat="server" id="notusedcount" style="width:100px"></span>
                     <span class="oscfifth"><span id="sumprice" runat="server"></span>元</span>
                     <span class="oscsix" style="margin-left:5px"><span id="usedstate" runat="server"></span></span>
                     <span class="oscseven"><a id="usedetail" style="cursor: pointer; margin-left:0px;" runat="server" onclick='<%# Eval("Id","openusedetail({0})") %>'>使用详情</a></span>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptOrderDetail3" runat="server" 
            onitemdatabound="rptOrderDetail3_ItemDataBound">
            <HeaderTemplate>
                <div class="oscdptitle">
                    <span class="oscfirst">景区名称</span><span class="oscsecond">在线支付价</span><span class="oscthird">数量</span>
                    <span class="oscfour">小计</span>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <asp:HiddenField ID="hfid" runat="server" Value='<%# Eval("Id") %>' />
                <div runat="server" id="itemod" class="oscdpdetail" style="display: block;">
                    <span class="oscfirst">
                        <a href='<%# "/"+Eval("TicketPrice.Ticket.Scenic.Area.SeoName")+"/"+Eval("TicketPrice.Ticket.Scenic.SeoName")+".html"%>'><%# Eval("TicketPrice.Ticket.Scenic.Name")%></a></span>
                    <span class="oscsecond" runat="server" id="onlineprice" style="margin-left:5px;"><%# Eval("TicketPrice.Price","{0:0}")%></span>
                    <span class="oscthird" runat="server" id="tp"><%# Eval("Quantity")%></span>
                    <span class="oscfour" runat="server" id="sumprice"></span>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="dscdptotal" runat="server"  id="state1">
            合计:<span runat="server" id="oscticketcount"></span>张门票&nbsp;&nbsp;<span runat="server"
                id="oscticketprice"></span>元
        </div>
        <div id="state2" runat="server" class="state2">
                未使用<span runat="server" id="ydcount"></span>张门票&nbsp;&nbsp;合计<span runat="server" id="ttprice"></span>元&nbsp;<span class="jstitle">你也可以选择在线支付立省
                <span runat="server" id="jsprice"></span>元 </span>
            <asp:Button ID="Button1" runat="server" CssClass="payonline" />
            </div>
        <div id="state3" runat="server" class="state3">
            <span runat="server" id="wfcount"></span>张门票&nbsp;&nbsp;合计<span runat="server" id="wfttprice"></span>元
            <asp:Button ID="Button2" runat="server" CssClass="payonline" 
                onclick="Button2_Click" />&nbsp;&nbsp;你也可以选择<asp:Button
                ID="Button3" runat="server" CssClass="btnyd" onclick="Button3_Click" />合计&nbsp;<span runat="server" id="zbttprice"></span>元
        </div>
    </div>
    <div id="oscupdateinfo">
        <div class="oscupdatetop">
            修改游客信息<span style="margin-left: 25px; color: Black;">(景区验票系统仅识别姓名,身份证号码,请准确填写)</span>
        </div>
        <div class="oscupdatesearch">
            
            <div id="contactlist">
                <asp:Repeater runat="server" ID="rptContacts">
                <HeaderTemplate>
                          <div id="contactHead">常用联系人</div>
            <div id="contactBody"></HeaderTemplate>
                    <ItemTemplate>
                        
                            <a class="assignitem" href="javascript:void" idcard='<%#Eval("IdCard") %>' cid='<%#Eval("Id") %>'>
                                <%#Eval("Name") %></a><a href="javascript:void" style="display:none" class="assignitem" all="">全部指派</a>
                       
                    </ItemTemplate>
                    <FooterTemplate></div>
</FooterTemplate>
                </asp:Repeater>
            </div>
            <div style="padding-top:10px">
                <asp:Repeater ID="rptbind" runat="server" 
                    onitemdatabound="rptbind_ItemDataBound">
                    <ItemTemplate>
                        <asp:HiddenField ID="hfid" runat="server" Value='<%# Eval("Id") %>' />
                        <div runat="server" id="oscused" class="oscdetailname">
                            <span id="oscname" runat="server" style="width: 150px; margin-left: 10px; float: left">
                                <%# Eval("TicketPrice.Ticket.Scenic.Name")%>
                            </span><span style="color: Red; margin-left: 10px; float: left;">*</span><span style="float: left">姓名</span><asp:TextBox
                                ID="txtdetailname" Text='<%# Eval("TicketAssignList[0].Name") %>' runat="server"
                                tid='<%#Eval("Id") %>' CssClass="aa" Style="text-align: center; height: 20px;
                                width: 150px; margin-left: 10px; float: left; padding: 0px; margin-top: 0px;
                                line-height: 22px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="必填"
                                Style="float: left; width: 25px;" ControlToValidate="txtdetailname" ForeColor="Red"></asp:RequiredFieldValidator>
                            <span style="color: Red; margin-left: 20px; float: left;">*</span><span style="float: left">身份证号</span><asp:TextBox
                                ID="txtdetailidcard" runat="server" Text='<%# Eval("TicketAssignList[0].IdCard") %>'
                                Style="height: 20px; width: 150px; margin-left: 10px; float: left; padding: 0px;
                                margin-top: 0px; line-height: 20px" tid='<%#Eval("Id")%>' CssClass="bb"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="必填"
                                ControlToValidate="txtdetailidcard" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="身份证无效"
                                ControlToValidate="txtdetailidcard" ForeColor="Red" ValidationExpression="\d{17}[\d|X]|\d{15}"></asp:RegularExpressionValidator>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <div class="oscbtnsave">
                <asp:Button ID="BtnSave" runat="server" CssClass="oscbtnupdate" OnClick="BtnSave_Click" />
            </div>
        </div>
    </div>
</asp:Content>
