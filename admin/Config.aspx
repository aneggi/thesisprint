<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="Config.aspx.cs" Inherits="KiLab.admin.Config" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="RilegaturaID" DataSourceID="EDS_rilegatura" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="RilegaturaID" HeaderText="RilegaturaID" 
                ReadOnly="True" SortExpression="RilegaturaID" />
            <asp:BoundField DataField="Titolo" HeaderText="Titolo" 
                SortExpression="Titolo" />
            <asp:BoundField DataField="Descrizione" HeaderText="Descrizione" 
                SortExpression="Descrizione" />
            <asp:BoundField DataField="Foto" HeaderText="Foto" SortExpression="Foto" />
            <asp:CheckBoxField DataField="delete" HeaderText="delete" 
                SortExpression="delete" />
            <asp:BoundField DataField="Costo" HeaderText="Costo" SortExpression="Costo" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <br />
    <br />
    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
        CellPadding="4" DataKeyNames="SpedizID" DataSourceID="EDS_spedizione" 
        ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
        <Columns>
            <asp:CommandField ShowEditButton="True" />
            <asp:BoundField DataField="SpedizID" HeaderText="SpedizID" ReadOnly="True" 
                SortExpression="SpedizID" />
            <asp:BoundField DataField="Titolo" HeaderText="Titolo" 
                SortExpression="Titolo" />
            <asp:BoundField DataField="Descrizione" HeaderText="Descrizione" 
                SortExpression="Descrizione" />
            <asp:BoundField DataField="Prezzo" HeaderText="Prezzo" 
                SortExpression="Prezzo" />
            <asp:CheckBoxField DataField="deleted" HeaderText="deleted" 
                SortExpression="deleted" />
        </Columns>
        <EditRowStyle BackColor="#999999" />
        <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#E9E7E2" />
        <SortedAscendingHeaderStyle BackColor="#506C8C" />
        <SortedDescendingCellStyle BackColor="#FFFDF8" />
        <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
    </asp:GridView>
    <br />
    <asp:EntityDataSource ID="EDS_rilegatura" runat="server" 
        ConnectionString="name=TesiContainer" DefaultContainerName="TesiContainer" 
        EnableFlattening="False" EnableInsert="True" EnableUpdate="True" 
        EntitySetName="Rilegatura">
    </asp:EntityDataSource>
    <asp:EntityDataSource ID="EDS_spedizione" runat="server" 
        ConnectionString="name=TesiContainer" DefaultContainerName="TesiContainer" 
        EnableFlattening="False" EnableInsert="True" EnableUpdate="True" 
        EntitySetName="Spediz">
    </asp:EntityDataSource>
</asp:Content>
