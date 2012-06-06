<%@ page title="" language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="ScenicDesc, App_Web_v5zntehw" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="Styles/Site.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="page">
        <asp:Repeater ID="Repeater1" runat="server">
            <ItemTemplate>
                <div id="scimg">
                    <img src='<%# Eval("Scenic.Photo","ScenicImg/{0}") %>' alt='<%# Eval("Ticket.Name") %>'  width="200px" height="180px"/></div>
                <div id="scdetial">
                    <p>
                        <%# Eval("Ticket.Name") %></p>
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
                    <p><%# Eval("Scenic.Desec") %></p>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        购买数量<asp:TextBox ID="TotalNum" runat="server"></asp:TextBox>
        省份证号<asp:TextBox ID="IDCard" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="支付" OnClick="Button1_Click" />
    </div>
</asp:Content>
