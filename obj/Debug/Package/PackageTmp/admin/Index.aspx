<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="KiLab.admin.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:EntityDataSource ID="EDS_ordini" runat="server" 
        ConnectionString="name=TesiContainer" DefaultContainerName="TesiContainer" 
        EnableDelete="True" EnableFlattening="False" EnableInsert="True" 
        EnableUpdate="True" EntitySetName="Ordine">
    </asp:EntityDataSource>
    <asp:MultiView ID="MV1" runat="server" ActiveViewIndex="0" 
        ClientIDMode="AutoID">
        <asp:View ID="List" runat="server">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                DataKeyNames="Id" DataSourceID="EDS_ordini" ForeColor="#333333" 
                GridLines="None" PageSize="25">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                        ShowSelectButton="True" />
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" 
                        SortExpression="Id" />
                    <asp:BoundField DataField="Data" HeaderText="Data" SortExpression="Data" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:CheckBoxField DataField="Eliminato" HeaderText="Eliminato" 
                        SortExpression="Eliminato" />
                    <asp:BoundField DataField="StPagato20" HeaderText="StPagato20" 
                        SortExpression="StPagato20" />
                    <asp:BoundField DataField="StSpedito60" HeaderText="StSpedito60" 
                        SortExpression="StSpedito60" />
                    <asp:BoundField DataField="SpedNome" HeaderText="SpedNome" 
                        SortExpression="SpedNome" />
                    <asp:BoundField DataField="SpedCognome" HeaderText="SpedCognome" 
                        SortExpression="SpedCognome" />
                    <asp:BoundField DataField="CodFiscalePersonale" 
                        HeaderText="CodFiscalePersonale" SortExpression="CodFiscalePersonale" />
                    <asp:BoundField DataField="CostoTotale" HeaderText="CostoTotale" 
                        SortExpression="CostoTotale" />
                    <asp:BoundField DataField="FatturaEmessa" HeaderText="FatturaEmessa" 
                        SortExpression="FatturaEmessa" />
                    <asp:BoundField DataField="Cellulare" HeaderText="Cellulare" 
                        SortExpression="Cellulare" />
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
        </asp:View>
        <asp:View ID="Details" runat="server">
            <asp:DetailsView ID="DetailsView1" runat="server" CellPadding="4" 
                DataSourceID="EDS_ordini" ForeColor="#333333" GridLines="None" Height="50px" 
                Width="125px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <CommandRowStyle BackColor="#E2DED6" Font-Bold="True" />
                <EditRowStyle BackColor="#999999" />
                <FieldHeaderStyle BackColor="#E9ECF1" Font-Bold="True" />
                <Fields>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                        ShowInsertButton="True" />
                </Fields>
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            </asp:DetailsView>
        </asp:View>
    </asp:MultiView>
    <p>
    </p>
</asp:Content>
