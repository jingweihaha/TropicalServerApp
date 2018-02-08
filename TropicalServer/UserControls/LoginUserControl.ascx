<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginUserControl.ascx.cs" Inherits="TropicalServer.UserControls.LoginUserControl" %>
<asp:Label id="useridlbl" runat="server">
           Login ID:
        </asp:Label>
        <asp:TextBox id="useridtextbox" runat="server"/><br />
        <asp:Label Id="passwordlbl" runat="server">
           Password:
        </asp:Label>
        <asp:TextBox id="passwordtextbox" runat="server"/>
        <br/>
    
        <asp:CheckBox id="remember" runat="server"/>
        <asp:Button id="loginButton" Text="Log-In" runat="server" OnClick="LoginButton_Click"/><br />
        <asp:HyperLink Text="forgotUsername" runat="server" NavigateUrl="#" ID="link1"/>
    <asp:HyperLink Text="forgotPassword" runat="server" NavigateUrl="../UI/ForgetPassword.aspx" ID= "link2"/>