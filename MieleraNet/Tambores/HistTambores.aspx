<%@ Page Language="C#" MasterPageFile="~/Mielera.Master" AutoEventWireup="true" CodeBehind="HistTambores.aspx.cs" Inherits="MieleraNet.Tambores.HistTambores" Title="Untitled Page" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:aspxgridview id="gridHistorialRec" runat="server" datasourceid="dsHistTabRecep"
        keyfieldname="ID" AutoGenerateColumns="False">
<Templates><DetailRow>
<dx:ASPxGridView id="gridTambores" runat="server" KeyFieldName="IDENVIO" DataSourceID="dsTambores" OnBeforePerformDataSelect="gridTambores_BeforePerformDataSelect">
<SettingsDetail IsDetailGrid="True"></SettingsDetail>
</dx:ASPxGridView> 
</DetailRow>
</Templates>

<SettingsDetail ShowDetailRow="True"></SettingsDetail>
        <Columns>
            <dx:GridViewDataHyperLinkColumn FieldName="ID" VisibleIndex="0">
                <PropertiesHyperLinkEdit NavigateUrlFormatString="../Reportes/repTambores.aspx?idtran={0}&amp;rep=1" Target="_blank">
                </PropertiesHyperLinkEdit>
            </dx:GridViewDataHyperLinkColumn>
            <dx:GridViewDataTextColumn Caption="Fecha de Env&#237;o" FieldName="FECHA_ENVIO"
                VisibleIndex="1">
                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ORIGEN" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DESTINO" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
        </Columns>
        <Styles>
            <TitlePanel Font-Bold="True" HorizontalAlign="Center">
            </TitlePanel>
        </Styles>
        <SettingsText Title="Lista de Tambores Vac&#237;os Recepcionados" />
        <Settings ShowTitlePanel="True" />
</dx:aspxgridview>
    &nbsp;&nbsp;
    <asp:ObjectDataSource ID="dsHistTabRecep" runat="server" SelectMethod="ObtenHistorialTamboresRecepcionados"
        TypeName="MieleraNet.DAL.TransferenciasDS">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="idusuario" Type="String" />
            <asp:Parameter DefaultValue="51" Name="idarea" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    &nbsp;
    <asp:ObjectDataSource ID="dsTambores" runat="server" SelectMethod="ObtenTamboresPorIdTransferencia"
        TypeName="MieleraNet.DAL.TransferenciasDS">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="" Name="idtransferencia" SessionField="idHistTamRec"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
