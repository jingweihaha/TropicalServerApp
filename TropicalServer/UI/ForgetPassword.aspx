<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="ForgetPassword.aspx.cs" Inherits="TropicalServer.UI.ForgetPassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="text-align: center">
        <asp:TextBox ID="EmailID" runat="server"/><br />
        <asp:Button ID="Button" OnClick="GetPasswordBack" Text="Submit" runat="server" />
    </div>
</asp:Content>
