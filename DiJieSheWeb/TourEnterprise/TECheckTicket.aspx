<%@ Page Title="" Language="C#" MasterPageFile="~/TourEnterprise/TE.master" AutoEventWireup="true"
    CodeFile="TECheckTicket.aspx.cs" Inherits="TourEnterprise_TECheckTicket" %>

<%@ MasterType VirtualPath="~/TourEnterprise/TE.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" runat="Server">
    <script type="text/javascript">
        function bindbylist(obj) {
            $("[id$='hfidcard']").val($(obj).find("td").eq(1).html());
            $("[id$='btnBind']").click();
        }
        $(function () {
            $(":checkbox").each(function () {
                var that = this;
                $(that).click(function () {
                    if ($(that).attr("disabled") != "disabled" && $(that).attr("checked") == "checked") {
                        var table = $(that).parent().parent().parent();
                        var checkboxs = $(table).find(":checkbox");
                        checkboxs.each(function () {
                            if ($(this).attr("disabled") != "disabled") {
                                $(this).removeAttr("checked");
                            }
                        });
                        $(that).attr("checked", "checked");
                    }
                    else {
                        if ($(that).attr("disabled") != "disabled" && $(that).attr("checked") != "checked") {
                            $(that).removeAttr("checked");
                        }
                    }
                });
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <asp:TextBox runat="server" ID="txtTE_info" /><asp:Button ID="BtnCheck" runat="server"
        Text="确定" OnClick="txtTE_info_Click" />
    <div id="grouplist">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    导游名称
                </td>
                <td>
                    导游身份证号
                </td>
            </tr>
            <asp:Repeater runat="server" ID="rptGroupList">
                <ItemTemplate>
                    <tr onclick="bindbylist(this)" style="cursor:pointer">
                        <td><%# Eval("GuideName")%></td>
                        <td><%# Eval("GuideIdCardNo")%></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    <div runat="server" id="detailinfo">
        <asp:Repeater ID="rptTourGroupInfo" runat="server" 
            onitemdatabound="rptTourGroupInfo_ItemDataBound">
            <HeaderTemplate>
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td>
                            选择
                        </td>
                        <td>
                            团队信息
                        </td>
                    </tr>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td>
                        <input type="radio" name="selectTg" runat="server" id="rdoSelect" />
                    </td>
                    <td>
                        <asp:HiddenField runat="server" ID="hfGroupId" Value='<%# Eval("Id") %>' />
                        <h5>
                            团队信息：</h5>
                            导游:<asp:Literal ID="laGuideName" runat="server"></asp:Literal><br />
                            <asp:Literal ID="laEnterpriceName" runat="server"></asp:Literal>&nbsp;<asp:Literal ID="laGroupName" runat="server"></asp:Literal><br />
                            人数:成人<asp:Literal ID="laAdultAmount" runat="server"></asp:Literal>&nbsp;儿童<asp:Literal ID="laChildrenAmount" runat="server"></asp:Literal>人<br />
                            <h5>
                            实际信息：</h5>
                            实到人数:成人<asp:TextBox ID="txtAdultsAmount" runat="server"></asp:TextBox>儿童<asp:TextBox
                            ID="txtChildrenAmount" runat="server"></asp:TextBox>人
                        <h5>行程安排</h5>
                        <asp:Repeater runat="server" ID="rptRoute">
                            <HeaderTemplate>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td>
                                            选择
                                        </td>
                                        <td>
                                            行程时间
                                        </td>
                                        <td>
                                            行程描述
                                        </td>
                                        <td>
                                            验证信息
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID="hfRouteId" runat="server" Value='<%# Eval("Id") %>' />
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="ChSelect" runat="server" />
                                    </td>
                                    <td>
                                        起<%# Eval("BeginTime") %>至<%# Eval("EndTime") %></td>
                                    <td>
                                        <%# Eval("Description") %>
                                    </td>
                                    <td>
                                        <asp:Literal ID="LaIsCheck" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Button ID="btnCheckOut" Text="验票通过" runat="server" OnClick="btnCheckOut_Click" />
    </div>
    <div id="hiddendv" style="display:none">
        <asp:HiddenField runat="server" ID="hfidcard" />
        <asp:Button Text="text" runat="server" ID="btnBind" OnClick="btnBind_Click" />
    </div>
</asp:Content>
