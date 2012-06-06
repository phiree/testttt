<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true"
    CodeFile="OnlinePrice.aspx.cs" Inherits="ScenticManager_OnlineSell_OnlinePrice" %>

<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
    <link href="/theme/default/css/smdefault.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function Pricepd() {
            var price = $("[id$='tbxPrice']").val();
            var orderprice = $("[id$='tbxPreOrder']").val();
            var payonline = $("[id$='tbxPayOnline']").val();
            if (parseInt(price) > parseInt(orderprice) && parseInt(orderprice) > parseInt(payonline)) {
                return true;
            }
            else {
                alert("填写的价格有误，请重新填写!");
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <p class="fuctitle">
        <a style="cursor: pointer; text-decoration: none; color: #2E6391;" onclick="javascript:history.go(-1);">
            景区门票信息</a>&nbsp;>&nbsp;修改景区价格</p>
    <hr />
    <div id="updateprice">
        <div class="priceintroduction">
            门票价格介绍
            <ul>
                <li>门市价:正常销售价格</li>
                <li>预定价:网上预定价格,游客在进入景区时付款</li>
                <li>优惠价:网上支付的价格</li>
            </ul>
        </div>
        <hr style="border:0px none;border-top: 1px solid Gray; width: 95%;" />
        <table class="tableprice">
            <tr>
                <td>
                    门市价:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxPrice"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    预订价:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxPreOrder"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    优惠价:
                </td>
                <td>
                    <asp:TextBox runat="server" ID="tbxPayOnline"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button runat="server" ID="btnOK"  OnClick="btnOK_Click" CssClass="btnokprice" OnClientClick="return Pricepd()" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
