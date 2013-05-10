<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="logs.aspx.cs" Inherits="KiLab.admin.logs" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:EntityDataSource ID="EntityDataSource1" runat="server" 
        ConnectionString="name=TesiContainer" DefaultContainerName="TesiContainer" 
        EnableFlattening="False" EntitySetName="Logs">
    </asp:EntityDataSource>
    <asp:DataList ID="DataList1" runat="server" CellPadding="4" DataKeyField="Id" 
        DataSourceID="EntityDataSource1" ForeColor="#333333">
        <AlternatingItemStyle BackColor="White" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#EFF3FB" />
        <ItemTemplate>
            Id:
            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            Testo:
            <asp:Label ID="TestoLabel" runat="server" Text='<%# Eval("Testo") %>' />
            <br />
            Data:
            <asp:Label ID="DataLabel" runat="server" Text='<%# Eval("Data") %>' />
            <br />
            CodEx:
            <asp:Label ID="CodExLabel" runat="server" Text='<%# Eval("CodEx") %>' />
            <br />
<br />
        </ItemTemplate>
        <SelectedItemStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
    </asp:DataList>
</asp:Content>
