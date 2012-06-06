<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true"
    CodeFile="VotingStatus.aspx.cs" Inherits="ScenticManager_VotingStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <table class="tblist">
        <tr>
            <th>
                当前得票总数
            </th>
            <td>
                <asp:Label Text="0" runat="server" ID="voteGet"></asp:Label>
            </td>
        </tr>
        <tr>
            <th>
                当前排名
            </th>
            <td>
                <asp:Label Text="0" runat="server" ID="voteRank"></asp:Label>
            </td>
        </tr>
    </table>
</asp:Content>
