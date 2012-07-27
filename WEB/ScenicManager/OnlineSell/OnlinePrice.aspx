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
        function findObj(theObj, theDoc) {
            var p, i, foundObj;
            if (!theDoc) theDoc = document;
            if ((p = theObj.indexOf("?")) > 0 && parent.frames.length)
            { theDoc = parent.frames[theObj.substring(p + 1)].document; theObj = theObj.substring(0, p); } if (!(foundObj = theDoc[theObj]) && theDoc.all) foundObj = theDoc.all[theObj]; for (i = 0; !foundObj && i < theDoc.forms.length; i++) foundObj = theDoc.forms[i][theObj]; for (i = 0; !foundObj && theDoc.layers && i < theDoc.layers.length; i++) foundObj = findObj(theObj, theDoc.layers[i].document); if (!foundObj && document.getElementById) foundObj = document.getElementById(theObj); return foundObj;
        }
        //添加一个参与人填写行
        function AddSignRow() { //读取最后一行的行号，存放在txtTRLastIndex文本框中 
            var txtTRLastIndex = findObj("txtTRLastIndex", document);
            var rowID = parseInt(txtTRLastIndex.value);
            var signFrame = findObj("SignFrame", document);
            //添加行
            var newTR = signFrame.insertRow(signFrame.rows.length);
            newTR.id = "SignItem" + rowID;
            //添加列:序号
            var newNameTD = newTR.insertCell(0);
            //添加列内容
            newNameTD.innerHTML = newTR.rowIndex.toString();
            //添加列:姓名
            var newNameTD = newTR.insertCell(1);
            //添加列内容
            newNameTD.innerHTML = "<input name='txtName" + rowID + "' id='txtName" + rowID + "' type='text' size='12' />";
            //添加列:电子邮箱
            var newEmailTD = newTR.insertCell(2);
            //添加列内容
            newEmailTD.innerHTML = "<input name='txtEMail" + rowID + "' id='txtEmail" + rowID + "' type='text' size='20' />";
            //添加列:电话
            var newTelTD = newTR.insertCell(3);
            //添加列内容
            newTelTD.innerHTML = "<input name='txtTel" + rowID + "' id='txtTel" + rowID + "' type='text' size='10' />";
            //添加列:手机
            var newMobileTD = newTR.insertCell(4);
            //添加列内容
            newMobileTD.innerHTML = "<input name='txtMobile" + rowID + "' id='txtMobile" + rowID + "' type='text' size='12' />";
            //添加列:公司名
            var newCompanyTD = newTR.insertCell(5);
            //添加列内容
            newCompanyTD.innerHTML = "<input name='txtCompany" + rowID + "' id='txtCompany" + rowID + "' type='text' size='20' />";
            //添加列:删除按钮
            var newDeleteTD = newTR.insertCell(6);
            //添加列内容
            newDeleteTD.innerHTML = "<div align='center' style='width:40px'><a href='javascript:;' onclick=\"DeleteSignRow('SignItem" + rowID + "')\">删除</a></div>";
            //将行号推进下一行
            txtTRLastIndex.value = (rowID + 1).toString();
        }
        //删除指定行
        function DeleteSignRow(rowid) {
            var signFrame = findObj("SignFrame", document);
            var signItem = findObj(rowid, document);

            //获取将要删除的行的Index
            var rowIndex = signItem.rowIndex;

            //删除指定Index的行
            signFrame.deleteRow(rowIndex);

            //重新排列序号，如果没有序号，这一步省略
            for (i = rowIndex; i < signFrame.rows.length; i++) {
                signFrame.rows[i].cells[0].innerHTML = i.toString();
            }
        } //清空列表
        function ClearAllSign() {
            if (confirm('确定要清空所有参与人吗？')) {
                var signFrame = findObj("SignFrame", document);
                var rowscount = signFrame.rows.length;

                //循环删除行,从最后一行往前删除
                for (i = rowscount - 1; i > 0; i--) {
                    signFrame.deleteRow(i);
                }

                //重置最后行号为1
                var txtTRLastIndex = findObj("txtTRLastIndex", document);
                txtTRLastIndex.value = "1";

                //预添加一行
                AddSignRow();
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
                <li>景区现付价:网上预定价格,游客在进入景区时付款</li>
                <li>网上订购价:网上支付的价格</li>
            </ul>
        </div>
        <hr style="border: 0px none; border-top: 1px solid Gray; width: 95%;" />
        <table class="tableprice">
            <thead>
                <tr>
                    <td>
                        景区门票
                    </td>
                    <td>
                        门票原价
                    </td>
                    <td>
                        明信片优惠价
                    </td>
                    <td>
                        景区现付价
                    </td>
                    <td>
                        在线支付价
                    </td>
                    <td>
                        <input type="button" style="width: 25px;" value="+" />
                    </td>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptPrice" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td>
                                <input type="text" value='<%# Eval("Name") %>' />
                            </td>
                            <td>
                                <input type="text" value='<%# ((IList<Model.TicketPrice>)Eval("TicketPrice"))[0].Price.ToString("0") %>'
                                    style="width: 80px;" />
                            </td>
                            <td>
                                <input type="text" value='<%# ((IList<Model.TicketPrice>)Eval("TicketPrice"))[1].Price.ToString("0")%>'
                                    style="width: 80px;" />
                            </td>
                            <td>
                                <input type="text" value='<%# ((IList<Model.TicketPrice>)Eval("TicketPrice"))[2].Price.ToString("0") %>'
                                    style="width: 80px;" />
                            </td>
                            <td>
                                <input type="text" value='<%# ((IList<Model.TicketPrice>)Eval("TicketPrice"))[3].Price.ToString("0") %>'
                                    style="width: 80px;" />
                            </td>
                            <td>
                                <input type="button" style="width: 25px;" value="-" />
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tr>
                <td>
                    <asp:Button runat="server" ID="btnOK" OnClick="btnOK_Click" CssClass="btnokprice"
                        OnClientClick="return Pricepd()" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
