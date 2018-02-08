<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="TropicalServer.UI.Products1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="productCategories">
        <div class="productCategoriesLabel">Product Categories</div>
            <asp:LinkButton ID="Button" class="imageStyle" Text="AREPAS"  onclick="GetProductInfo" runat="server"/><br />
            <asp:LinkButton ID="Button1" class="imageStyle" Text="CARIBBEAN LINE"  onclick="GetProductInfo" runat="server"/><br />
            <asp:LinkButton ID="Button2" class="imageStyle" Text="CENTRAL AMERICAN"  OnClick="GetProductInfo" runat="server"/><br />
            <asp:LinkButton ID="Button3" class="imageStyle" Text="DESSERTS"  OnClick="GetProductInfo" runat="server"/><br />
            <asp:LinkButton ID="Button4" class="imageStyle" Text="DOMETIC ITEMS" onclick="GetProductInfo" runat="server"/><br />
            <asp:LinkButton ID="Button5" class="imageStyle" Text="DRINKABLE YOGURTS" onclick="GetProductInfo" runat="server"/><br />
            <asp:LinkButton ID="Button6" class="imageStyle" Text="MEATS" onclick="GetProductInfo" runat="server"/><br />
            <asp:LinkButton ID="Button7" class="imageStyle" Text="MEXICAN LINE" onclick="GetProductInfo" runat="server"/><br />
            <asp:LinkButton ID="Button8" class="imageStyle" Text="OTHERS" onclick="GetProductInfo" runat="server"/><br />
            <asp:LinkButton ID="Button9" class="imageStyle" Text="PAISANO LINE" onclick="GetProductInfo" runat="server"/><br />
            <asp:LinkButton ID="Button10" class="imageStyle" Text="PER POUND ITEMS" OnClick="GetProductInfo" runat="server"/>
            
    </div>
    <div class="chartdisplay">
        <asp:GridView class="dataGrid" id="GridView1" AllowPaging="true" runat="server"  OnPageIndexChanging="GridView1_IndexChanging" PageSize="9" HeaderStyle-CssClass="headerStyle" RowStyle-CssClass="itemRowStyle" AlternatingRowStyle-CssClass="alternatingItemStyle">

    </asp:GridView>
   </div>
    <%--<div style="text-align:center">
        <asp:Button runat="server" OnClick="" />
    </div>--%>
    
   </asp:Content>
