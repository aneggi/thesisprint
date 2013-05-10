<%@ Page Title="" Language="C#" MasterPageFile="~/admin/Admin.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="KiLab.admin.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:EntityDataSource ID="EDS_ordini" runat="server" 
        ConnectionString="name=TesiContainer" DefaultContainerName="TesiContainer" 
        EnableDelete="True" EnableFlattening="False" EnableInsert="True" 
        EnableUpdate="True" EntitySetName="Ordine">
    </asp:EntityDataSource>
    <br />
    <asp:MultiView ID="MV1" runat="server" ActiveViewIndex="0" 
        ClientIDMode="AutoID">
        <asp:View ID="List" runat="server">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
                AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" 
                DataKeyNames="Id" DataSourceID="EDS_ordini" ForeColor="#333333" 
                GridLines="None" PageSize="25">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" 
                        SortExpression="Id" />
                    <asp:BoundField DataField="Data" HeaderText="Data" SortExpression="Data" />
                    <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                    <asp:BoundField DataField="Token" HeaderText="Token" SortExpression="Token" />
                    <asp:BoundField DataField="TokenScadenza" HeaderText="TokenScadenza" 
                        SortExpression="TokenScadenza" />
                    <asp:CheckBoxField DataField="Eliminato" HeaderText="Eliminato" 
                        SortExpression="Eliminato" />
                    <asp:BoundField DataField="StAperto10" HeaderText="StAperto10" 
                        SortExpression="StAperto10" />
                    <asp:BoundField DataField="StPagato20" HeaderText="StPagato20" 
                        SortExpression="StPagato20" />
                    <asp:BoundField DataField="StInvioBozza30" HeaderText="StInvioBozza30" 
                        SortExpression="StInvioBozza30" />
                    <asp:BoundField DataField="StRicezioneFile40" HeaderText="StRicezioneFile40" 
                        SortExpression="StRicezioneFile40" />
                    <asp:BoundField DataField="StAttesaSpedizione50" 
                        HeaderText="StAttesaSpedizione50" SortExpression="StAttesaSpedizione50" />
                    <asp:BoundField DataField="StSpedito60" HeaderText="StSpedito60" 
                        SortExpression="StSpedito60" />
                    <asp:BoundField DataField="StChiuso70" HeaderText="StChiuso70" 
                        SortExpression="StChiuso70" />
                    <asp:BoundField DataField="SpedTipo" HeaderText="SpedTipo" 
                        SortExpression="SpedTipo" />
                    <asp:BoundField DataField="Spedriserva" HeaderText="Spedriserva" 
                        SortExpression="Spedriserva" />
                    <asp:BoundField DataField="SpedNome" HeaderText="SpedNome" 
                        SortExpression="SpedNome" />
                    <asp:BoundField DataField="SpedCognome" HeaderText="SpedCognome" 
                        SortExpression="SpedCognome" />
                    <asp:BoundField DataField="SpedIndirizzo" HeaderText="SpedIndirizzo" 
                        SortExpression="SpedIndirizzo" />
                    <asp:BoundField DataField="SpedCitta" HeaderText="SpedCitta" 
                        SortExpression="SpedCitta" />
                    <asp:BoundField DataField="GiornoLaurea" HeaderText="GiornoLaurea" 
                        SortExpression="GiornoLaurea" />
                    <asp:BoundField DataField="SpedCAP" HeaderText="SpedCAP" 
                        SortExpression="SpedCAP" />
                    <asp:BoundField DataField="CodFiscalePersonale" 
                        HeaderText="CodFiscalePersonale" SortExpression="CodFiscalePersonale" />
                    <asp:BoundField DataField="StampeBN" HeaderText="StampeBN" 
                        SortExpression="StampeBN" />
                    <asp:BoundField DataField="StampeColori" HeaderText="StampeColori" 
                        SortExpression="StampeColori" />
                    <asp:BoundField DataField="CostoBN" HeaderText="CostoBN" 
                        SortExpression="CostoBN" />
                    <asp:BoundField DataField="CostoCOLORI" HeaderText="CostoCOLORI" 
                        SortExpression="CostoCOLORI" />
                    <asp:BoundField DataField="CostoSpedizione" HeaderText="CostoSpedizione" 
                        SortExpression="CostoSpedizione" />
                    <asp:BoundField DataField="CostoFisso" HeaderText="CostoFisso" 
                        SortExpression="CostoFisso" />
                    <asp:BoundField DataField="TipoRillegatura" HeaderText="TipoRillegatura" 
                        SortExpression="TipoRillegatura" />
                    <asp:BoundField DataField="CostoRillegatura" HeaderText="CostoRillegatura" 
                        SortExpression="CostoRillegatura" />
                    <asp:CheckBoxField DataField="BozzaAcquistata" HeaderText="BozzaAcquistata" 
                        SortExpression="BozzaAcquistata" />
                    <asp:BoundField DataField="CostoBozza" HeaderText="CostoBozza" 
                        SortExpression="CostoBozza" />
                    <asp:BoundField DataField="IVA" HeaderText="IVA" SortExpression="IVA" />
                    <asp:BoundField DataField="CostoTotale" HeaderText="CostoTotale" 
                        SortExpression="CostoTotale" />
                    <asp:BoundField DataField="FatturaEmessa" HeaderText="FatturaEmessa" 
                        SortExpression="FatturaEmessa" />
                    <asp:BoundField DataField="CopieStampare" HeaderText="CopieStampare" 
                        SortExpression="CopieStampare" />
                    <asp:CheckBoxField DataField="CartaPlus" HeaderText="CartaPlus" 
                        SortExpression="CartaPlus" />
                    <asp:CheckBoxField DataField="FronteRetro" HeaderText="FronteRetro" 
                        SortExpression="FronteRetro" />
                    <asp:BoundField DataField="Cellulare" HeaderText="Cellulare" 
                        SortExpression="Cellulare" />
                    <asp:BoundField DataField="CostoCartaPlus" HeaderText="CostoCartaPlus" 
                        SortExpression="CostoCartaPlus" />
                    <asp:BoundField DataField="PagamentoId" HeaderText="PagamentoId" 
                        SortExpression="PagamentoId" />
                    <asp:BoundField DataField="Note" HeaderText="Note" SortExpression="Note" />
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
        </asp:View>
    </asp:MultiView>
    </asp:Content>
