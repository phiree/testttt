<%@ Page Title="" Language="C#" MasterPageFile="~/TourEnterprise/TE.master" AutoEventWireup="true"
    CodeFile="TECheckTicket.aspx.cs" Inherits="TourEnterprise_TECheckTicket" %>

<%@ MasterType VirtualPath="~/TourEnterprise/TE.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" runat="Server">
    <script src="/Scripts/CheckTicket.js" type="text/javascript"></script>
    <%--<link href="/theme/default/css/Print.css" rel="stylesheet" type="text/css" />--%>
    <script type="text/javascript">
        
        function bindbylist(obj) {
            $("[id$='hfidcard']").val($.trim($(obj).find("td").eq(1).find("span").html()));
            $("[id$='btnBind']").click();
        }
        function printTicket(info) {
            if (confirm(info)) {
                $("[id$='btnPrint']").click(function () {
                    window.open($(this).attr("href"), '', 'fullscreen=yes');
                });

                // 触发单击事件（会执行所有绑定的单击事件处理函数） 
                $("[id$='btnPrint']").click(); 
            }
        }
    </script>
    <script src="/Scripts/jquery.autocomplete.js" type="text/javascript"></script>
    <link href="/theme/default/css/jquery.autocomplete.css" rel="stylesheet" type="text/css" />
    <object id="aaa" classid="clsid:6c78bcd1-ac43-4fb9-8d89-d9f7b717d021" style=" height:0px;">
    </object>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <asp:HiddenField ID="hfetid" runat="server" />
    <div class="detail_titlebg">
        验证
    </div>
    <div class="searchdiv">
        <h5>
            按导游姓名或者身份证号查询</h5>
        <asp:TextBox runat="server" ID="txtTE_info" Style="margin-right: 10px;width:250px;" /><asp:Button
            ID="BtnCheck" runat="server" Text="确定" OnClick="txtTE_info_Click" CssClass="btn" />
        <span id="yklistt"><span style="margin-left: 20px; padding-left: 0px; cursor: pointer; vertical-align: middle;"
            onmouseover="showyklist()">导游列表&nbsp;&nbsp;</span><img onmouseover="showyklist()" height="15px"
                width="10px" src="/theme/default/image/downicon.png" style="vertical-align: middle;
                cursor: pointer;" /></span>
    </div>
    <div runat="server" id="detailinfo" class="detailinfo">
        <asp:Repeater ID="rptTourGroupInfo" runat="server" OnItemDataBound="rptTourGroupInfo_ItemDataBound">
            <HeaderTemplate>
                <table border="0" cellpadding="0" cellspacing="0">
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <asp:CheckBox ID="cbSelect" runat="server" />
                    </td>
                    <td>
                        <asp:HiddenField ID="hfrouteId" runat="server" />
                        <h5>团队信息:</h5>
                        <p>导游:<asp:Literal ID="laGuideName" runat="server"></asp:Literal></p>
                        <p>团队名称:<%# Eval("Name") %></p>
                        <p>人数:成人<%# Eval("AdultsAmount")%>人&nbsp;儿童<%# Eval("ChildrenAmount")%>人</p>
                            <h5>实际信息：</h5>
                            实到人数:成人<asp:TextBox ID="txtAdultsAmount" runat="server"></asp:TextBox>&nbsp;儿童<asp:TextBox
                            ID="txtChildrenAmount" runat="server"></asp:TextBox>人
                    </td>
                    <td>
                        <asp:Literal ID="laChecked" runat="server"></asp:Literal>
                    </td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
        <tr>
            <td></td>
            <td>
                <asp:Button ID="btnCheckOut" Text="验证通过" runat="server" OnClick="btnCheckOut_Click" CssClass="btn" style=" display:block; float:left;margin-right:10px" />
                <a id="btnPrint" runat="server"  class="btn" href="" target="_blank" style="display:block; text-decoration:none; text-align:center; line-height:20px;color:#009383; float:left; display:none">打印凭证</a>
                
            </td>
            <td></td>
        </tr>
        </table>
    </div>
    <div class="remark">
         <p class="wkintr">
        身份证读卡器的驱动下载地址:<a href="http://productbbs.it168.com/thread-67620-1-1.html">下载地址</a>
        </p>
        <p class="wkintr">
            首次进入该页面，请先下载身份证读卡器程序，安装到本地电脑后，打开IE浏览器，进入该页面后浏览器会提示是否运行该加载项，点击允许，即可使用：
            <a href="/ScenicManager/setup.exe">身份证读卡器程序下载</a>
        </p>
    </div>
    <div id="hiddendv" style="display: none">
        <asp:HiddenField runat="server" ID="hfidcard" />
        <asp:Button Text="text" runat="server" ID="btnBind" OnClick="btnBind_Click" />
    </div>
    <div id="listname" class="yklist" style="display: none;">
        <table cellpadding="0" cellspacing="0" style="margin: 15px auto; margin-bottom: 0px;
            width: 200px; table-layout: fixed">
            <tr style="width: 150px; background-color: #E9E9E9">
                <td style="width: 60px; padding: 0px; padding-right: 0px; padding-left: 0px; padding-right: 0px;">
                    <span style="display: block; width: 60px; margin: 0px; margin-left: 0px; margin-right: 0px;">
                        导游姓名</span>
                </td>
                <td style="width: 135px; padding-left: 0px; padding-right: 0px;">
                    <span style="display: block; width: 135px">身份证号</span>
                </td>
            </tr>
        </table>
        <div style="margin-right: 10px; padding: 0px; height: 250px; width: 215px; overflow-x: hidden;
            overflow-y: auto;">
            <asp:Repeater ID="rptGroupList" runat="server">
                <HeaderTemplate>
                    <table cellpadding="0" cellspacing="0" style="display: block; margin-bottom: 0px;
                        border-top: 0px none; width: 200px; table-layout: fixed">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr onmouseover="cgbg(this)" onmouseout="cgbg2(this)" style="cursor: pointer;" onclick="bindbylist(this)">
                        <td style="width: 60px; background-color: #F7F7F7; padding-left: 0px; padding-right: 0px;
                            margin-left: 0px; margin-right: 0px;">
                            <span style="display: block; width: 60px;">
                                <%# Eval("Name") %></span>
                        </td>
                        <td style="width: 135px; background-color: #F7F7F7; padding: 0px;">
                            <span style="display: block; width: 125px">
                                <%# Eval("IdCard").ToString().Substring(0,6) %>********<%# Eval("IdCard").ToString().Substring(14) %></span></td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
