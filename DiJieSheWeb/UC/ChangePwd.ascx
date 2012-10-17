<<<<<<< HEAD
﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangePwd.ascx.cs" Inherits="UC_ChangePwd" %>
    <div class="detail_titlebg">
        更改密码
    </div>
<asp:ChangePassword ID="ChangePassword1" runat="server" 
    oncontinuebuttonclick="ChangePassword1_ContinueButtonClick">
    <ChangePasswordTemplate>
        <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
            <tr>
                <td>
                    <table cellpadding="0">
                        <tr>
                            <td align="right">
                                <asp:Label ID="CurrentPasswordLabel" runat="server" 
                                    AssociatedControlID="CurrentPassword">密码:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" 
                                    ControlToValidate="CurrentPassword" ErrorMessage="必须填写“密码”。" 
                                    ToolTip="必须填写“密码”。" ValidationGroup="ctl00$ChangePassword1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="NewPasswordLabel" runat="server" 
                                    AssociatedControlID="NewPassword">新密码:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" 
                                    ControlToValidate="NewPassword" ErrorMessage="必须填写“新密码”。" ToolTip="必须填写“新密码”。" 
                                    ValidationGroup="ctl00$ChangePassword1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="ConfirmNewPasswordLabel" runat="server" 
                                    AssociatedControlID="ConfirmNewPassword">确认新密码:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" 
                                    ControlToValidate="ConfirmNewPassword" ErrorMessage="必须填写“确认新密码”。" 
                                    ToolTip="必须填写“确认新密码”。" ValidationGroup="ctl00$ChangePassword1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:CompareValidator ID="NewPasswordCompare" runat="server" 
                                    ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                                    Display="Dynamic" ErrorMessage="“确认新密码”与“新密码”项必须匹配。" 
                                    ValidationGroup="ctl00$ChangePassword1"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color:Red;">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Button ID="ChangePasswordPushButton" runat="server" 
                                    CommandName="ChangePassword" Text="更改密码"  CssClass="btn"
                                    ValidationGroup="ctl00$ChangePassword1" />
                            </td>
                            <td>
                                <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CssClass="btn"
                                    CommandName="Cancel" Text="取消" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ChangePasswordTemplate>
</asp:ChangePassword>
=======
﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ChangePwd.ascx.cs" Inherits="UC_ChangePwd" %>
    <div class="detail_titlebg">
        更改密码
    </div>
<asp:ChangePassword ID="ChangePassword1" runat="server" 
    oncontinuebuttonclick="ChangePassword1_ContinueButtonClick">
    <ChangePasswordTemplate>
        <table cellpadding="1" cellspacing="0" style="border-collapse:collapse;">
            <tr>
                <td>
                    <table cellpadding="0">
                        <tr>
                            <td align="right">
                                <asp:Label ID="CurrentPasswordLabel" runat="server" 
                                    AssociatedControlID="CurrentPassword">密码:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="CurrentPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="CurrentPasswordRequired" runat="server" 
                                    ControlToValidate="CurrentPassword" ErrorMessage="必须填写“密码”。" 
                                    ToolTip="必须填写“密码”。" ValidationGroup="ctl00$ChangePassword1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="NewPasswordLabel" runat="server" 
                                    AssociatedControlID="NewPassword">新密码:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="NewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="NewPasswordRequired" runat="server" 
                                    ControlToValidate="NewPassword" ErrorMessage="必须填写“新密码”。" ToolTip="必须填写“新密码”。" 
                                    ValidationGroup="ctl00$ChangePassword1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="ConfirmNewPasswordLabel" runat="server" 
                                    AssociatedControlID="ConfirmNewPassword">确认新密码:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="ConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmNewPasswordRequired" runat="server" 
                                    ControlToValidate="ConfirmNewPassword" ErrorMessage="必须填写“确认新密码”。" 
                                    ToolTip="必须填写“确认新密码”。" ValidationGroup="ctl00$ChangePassword1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:CompareValidator ID="NewPasswordCompare" runat="server" 
                                    ControlToCompare="NewPassword" ControlToValidate="ConfirmNewPassword" 
                                    Display="Dynamic" ErrorMessage="“确认新密码”与“新密码”项必须匹配。" 
                                    ValidationGroup="ctl00$ChangePassword1"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color:Red;">
                                <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Button ID="ChangePasswordPushButton" runat="server" 
                                    CommandName="ChangePassword" Text="更改密码"  CssClass="btn"
                                    ValidationGroup="ctl00$ChangePassword1" />
                            </td>
                            <td>
                                <asp:Button ID="CancelPushButton" runat="server" CausesValidation="False" CssClass="btn"
                                    CommandName="Cancel" Text="取消" />
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </ChangePasswordTemplate>
</asp:ChangePassword>
>>>>>>> d74df8dae97ded101156199514f50f8bfb9b400f
