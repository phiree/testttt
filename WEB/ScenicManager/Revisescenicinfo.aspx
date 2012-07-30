<%@ Page Title="" Language="C#" MasterPageFile="~/ScenicManager/sm.master" AutoEventWireup="true"
    CodeFile="Revisescenicinfo.aspx.cs" Inherits="ScenicManager_Updatescenicinfo" %>

<%@ MasterType VirtualPath="~/ScenicManager/sm.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="smHeader" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphmain" runat="Server">
    <div>
        开启网上售票功能</div>
    <div>
        1: <a href="/ScenicManager/UpdateScenticInfo.aspx">完善景区资料</a>
    </div>
    <div>
        2:<a href="OnlineSell/CheckPrice.aspx">填写售票价格</a>
    </div>
    <div>
        3:<a href="/ScenicManager/OnlineSell/Print.aspx">打印,盖公章,拍照</a>
    </div>
    <div>
        4:<a href="/ScenicManager/UploadContract.aspx?module=<%=module %>&scenicid=<%=scenicid %>">上传"开启网上售票"文件</a>
    </div>
    <div>
        <asp:Button runat="server" ID="btnApply" Text="重新申请" OnClick="btnApply_Click" />
    </div>
</asp:Content>
