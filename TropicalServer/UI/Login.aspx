<%@ Page Title="a" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="TropicalServer.UI.Products" %>

<%@ Register Src="~/UserControls/LoginUserControl.ascx" TagPrefix="uc1" TagName="luc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <div id="login">
            <label >MOBILE CUSTOMER ORDER TRACKING</label>
              <br/>
            <uc1:luc ID="luc1" runat="server" />
        </div>
    </div>
</asp:Content>
