<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/TropicalServer.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="TropicalServer.UI.Orders" EnableEventValidation="false"%>
<%@   Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"  TagPrefix="ajax"%>


<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  

    Order Date:<asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" AutoPostBack="true">
        <asp:ListItem>Today</asp:ListItem>
        <asp:ListItem>Last 7 Days</asp:ListItem>
        <asp:ListItem>Last 1 Month</asp:ListItem>
        <asp:ListItem>Last 6 Months</asp:ListItem>
    </asp:DropDownList>
    Customer ID:<asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged" AutoPostBack="true"></asp:TextBox>
    Customer Name:<asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged" AutoPostBack="true"></asp:TextBox>
    
 <ajax:AutoCompleteExtender ID="AutoCompleteExtender1"
        runat="server"
        TargetControlID="TextBox2"
         MinimumPrefixLength="1"
        EnableCaching="true"
        CompletionSetCount="100"
        CompletionInterval="100"
        ServiceMethod="AutoCompleteIt"
        ServicePath="AutoComplete.asmx">
 </ajax:AutoCompleteExtender>
    
        <asp:GridView ID="GridView1" class="dataGrid" runat="server" OnRowCancelingEdit="GridView1_RowCancelingEdit" AutoGenerateColumns="False" OnRowDeleting="GridView1_RowDeleting" OnRowUpdating="GridView1_RowUpdating"
                  OnRowEditing="GridView1_RowEditing" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" OnRowCommand="GridView1_OnRowCommand" HeaderStyle-CssClass="headerStyle" RowStyle-CssClass="itemRowStyle" AlternatingRowStyle-CssClass="alternatingItemStyle" >
<AlternatingRowStyle CssClass="alternatingItemStyle"></AlternatingRowStyle>
            <Columns>
                <asp:BoundField DataField="OrderTrackingNumber" HeaderText="OrderTrackingNumber" SortExpression="OrderTrackingNumber" />
                <asp:BoundField DataField="OrderDate" HeaderText="OrderDate" SortExpression="OrderDate" />
                <asp:BoundField DataField="OrderCustomerNumber" HeaderText="OrderCustomerNumber" SortExpression="OrderCustomerNumber" />
                <asp:BoundField DataField="CustName" HeaderText="CustName" SortExpression="CustName" />
                <asp:BoundField DataField="CustOfficeAddress1" HeaderText="CustOfficeAddress1" SortExpression="CustOfficeAddress1" />
                <asp:BoundField DataField="OrderRouteNumber" HeaderText="OrderRouteNumber" SortExpression="OrderRouteNumber" />
                <asp:TemplateField HeaderText="Edit" ShowHeader="False">
                    <EditItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Delete" ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton4" runat="server" CausesValidation="False" CommandName="Delete" Text="Delete" OnClientClick=" confirm('delete it??');"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:ButtonField  HeaderText="View" Text="View" ButtonType="Link" CommandName="GetView"/>
            </Columns>

<HeaderStyle CssClass="headerStyle"></HeaderStyle>

<RowStyle CssClass="itemRowStyle"></RowStyle>
        </asp:GridView>
  
</asp:Content>

<%--<asp:Content ID="bodyContent" ContentPlaceholderID="body" runat="server">
  <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
      <Scripts>
        <asp:ScriptReference Path="~/UI/JavaScript.js" />
      </Scripts>
  </asp:ScriptManagerProxy>--%>




