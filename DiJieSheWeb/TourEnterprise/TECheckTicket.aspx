<%@ Page Title="" Language="C#" MasterPageFile="~/TourEnterprise/TE.master" AutoEventWireup="true" CodeFile="TECheckTicket.aspx.cs" Inherits="TourEnterprise_TECheckTicket" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphhead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" Runat="Server">
    <asp:TextBox runat="server" ID="txtTE_info" /><asp:Button ID="BtnCheck" runat="server"
        Text="确定" />
        <div>
            <h5>团队信息：</h5>
            导游:<%= GuideName %><br />
            <%= EnterpriceName  %>&nbsp;<%= GroupName %><br />
            人数:成人<%= AdultAmount %>&nbsp;儿童<%= ChildrenAmount %>人<br />
            <h5>实际信息：</h5>
            实到人数:成人<asp:TextBox ID="txtAdultsAmount" runat="server"></asp:TextBox>儿童<asp:TextBox ID="txtChildrenAmount" runat="server"></asp:TextBox>人
        </div>
</asp:Content>

