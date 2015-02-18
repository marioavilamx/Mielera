<%@ Page Language="C#" MasterPageFile="~/Mielera.Master" AutoEventWireup="true" CodeBehind="RecepcioMiel.aspx.cs" Inherits="MieleraNet.Transferencias.RecepcioMiel" Title="Untitled Page" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" language="javascript">
function mueveReloj(){ 
    momentoActual = new Date(); 
    hora = momentoActual.getHours(); 
    minuto = momentoActual.getMinutes(); 
    segundo = momentoActual.getSeconds(); 

    str_segundo = new String (segundo); 
    if (str_segundo.length == 1) 
       segundo = "0" + segundo; 

    str_minuto = new String (minuto); 
    if (str_minuto.length == 1) 
       minuto = "0" + minuto; 

    str_hora = new String (hora);
    if (str_hora.length == 1) 
       hora = "0" + hora;

    horaImprimible = hora + " : " + minuto + " : " + segundo;
    lbHora2.SetText(horaImprimible);
    setTimeout("mueveReloj()",1000);
} 


</script>
    <dx:ASPxPageControl ID="pagecontrolRecepMiel" runat="server" ActiveTabIndex="0">
        <TabPages>
<dx:TabPage Text="Recepcion de Miel"><ContentCollection>
<dx:ContentControl runat="server">
    <table border="0" cellpadding="0" style="width: 100%; height: 100%">
        <tr>
            <td colspan="2">
                <table border="0" cellpadding="0" style="width: 100%; height: 100%">
                    <tr>
                        <td style="width: 160px">
                            <dx:ASPxLabel ID="L1" runat="server" Text="Selecciona Transferencia">
                            </dx:ASPxLabel>
                        </td>
                        <td align="left">
                            <dx:ASPxComboBox ID="cmbTranferencias" runat="server" AutoPostBack="True" DataSourceID="dsTransfARecep"
                                TextField="IDTRANS" ValueField="IDTRANS" ValueType="System.String" OnValueChanged="cmbTranferencias_ValueChanged" ClientInstanceName="cmbTranferencias">
                            </dx:ASPxComboBox>
                        </td>
                        <td align="left">
                            <dx:ASPxCheckBox ID="chkReimp" runat="server" AutoPostBack="True" OnCheckedChanged="chkReimp_CheckedChanged"
                                Text="Reimpresion">
                            </dx:ASPxCheckBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                &nbsp;<dx:ASPxRoundPanel ID="panelGeneral" runat="server" HeaderText="Datos Generales"
                    SkinID="RoundPanelGroupBox" Width="100%">
                    <PanelCollection>
                        <dx:PanelContent runat="server">
                <table border="1" cellpadding="0" style="width: 100%; height: 100%">
                    <tr>
                        <td style="width: 130px">
                            Hora:</td>
                        <td>
                            <dx:ASPxLabel ID="lbHora2" runat="server" BackColor="White" ClientInstanceName="lbHora2"
                                ForeColor="#00C000">
                                <ClientSideEvents Init="mueveReloj" />
                            </dx:ASPxLabel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 130px">
                            Delegado:</td>
                        <td>
                            <dx:ASPxLabel ID="lbDelegado" runat="server" Text="lbDelegado">
                            </dx:ASPxLabel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 130px; height: 16px">
                            Area:</td>
                        <td style="height: 16px">
                            <dx:ASPxLabel ID="lbArea" runat="server" Text="lbArea">
                            </dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
                        </dx:PanelContent>
                    </PanelCollection>
                </dx:ASPxRoundPanel>
            </td>
        </tr>
        <tr>
            <td colspan="2" align="right">
                &nbsp;<dx:ASPxGridView ID="gridTamb" runat="server" AutoGenerateColumns="False" ClientInstanceName="gridTambEnv"
                    DataSourceID="dsNoMuestreados" KeyFieldName="IDTAMBOR" OnCommandButtonInitialize="gridTamb_CommandButtonInitialize" OnCustomColumnDisplayText="gridTamb_CustomColumnDisplayText" Width="500px">
                    <Styles>
                        <Footer Wrap="False">
                        </Footer>
                        <TitlePanel HorizontalAlign="Center">
                        </TitlePanel>
                    </Styles>
                    <SettingsPager PageSize="200">
                        <Summary AllPagesText="Pagina: {0} - {1} ({2} registros)" Text="Pagina {0} de {1} ({2} registros)" />
                    </SettingsPager>
                    <TotalSummary>
                        <dx:ASPxSummaryItem DisplayFormat="Total {0:c}" FieldName="TOT" SummaryType="Sum" />
                    </TotalSummary>
                    <SettingsText EmptyDataRow="No existe compra pendiente por aceptar" Title="Tambores de la Transferencia" />
                    <Columns>
                        <dx:GridViewDataTextColumn Caption="Tambor" FieldName="IDTAMBOR" VisibleIndex="0" Width="60px">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Kilogramos" FieldName="KG" VisibleIndex="1">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="P/Unitario" FieldName="PRECIOUNITARIO" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="SubTotal" FieldName="TOT" VisibleIndex="3" Width="120px">
                            <PropertiesTextEdit DisplayFormatString="c">
                            </PropertiesTextEdit>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Muestreado" FieldName="STATUS" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="5" Width="40px">
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                            <HeaderTemplate>
                                <input onclick="gridTambEnv.SelectAllRowsOnPage(this.checked);" title="Select/Unselect all rows on the page"
                                    type="checkbox" />
                            </HeaderTemplate>
                        </dx:GridViewCommandColumn>
                    </Columns>
                    <Settings ShowFooter="True" ShowTitlePanel="True" ShowVerticalScrollBar="True" />
                </dx:ASPxGridView>
                <table border="0" cellpadding="0">
                    <tr>
                        <td>
                            <dx:ASPxButton ID="btnReimprimir" runat="server" Text="Imprimir Etiquetas" AutoPostBack="False" Visible="False">
                                <ClientSideEvents Click="function(s, e) {
	if (cmbTranferencias.GetValue() == null)
		alert('Por favor elija una transferencia');
	else
	     window.open(&quot;../Reportes/ImpMuestras.aspx?idtrans=&quot; + cmbTranferencias.GetValue(), &quot;_blank&quot;,&quot;scrollbars=1, width=800,height=600&quot;); 
	return false;	

}" />
                            </dx:ASPxButton>
                        </td>
                        <td style="height: 30px">
                            <dx:ASPxButton ID="btnMuestrear" runat="server" Text="Realizar Muestreo" OnClick="btnMuestrear_Click" Visible="False">
                            </dx:ASPxButton>
                        </td>
                        <td style="height: 30px">
                            <dx:ASPxButton ID="btnAceptaTran" runat="server" Text="Acepta Transferencia" OnClick="btnAceptaTran_Click">
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
                &nbsp;</td>
            <td style="width: 100px">
            </td>
        </tr>
        <tr>
            <td style="width: 100px">
            </td>
            <td style="width: 100px">
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="dsNoMuestreados" runat="server" SelectMethod="ObtenTamboresPorTransferencia"
        TypeName="MieleraNet.DAL.MuestreoDS">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmbTranferencias" Name="idtrans" PropertyName="Value"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    </dx:ContentControl>
</ContentCollection>
</dx:TabPage>
<dx:TabPage Text="Historial de Miel Recepcionada"><ContentCollection>
<dx:ContentControl runat="server">
    <dx:ASPxGridView ID="gridHistorialRec" runat="server" AutoGenerateColumns="False"
        DataSourceID="dsHistTranMiel" KeyFieldName="IDTRANS">
        <Columns>
            <dx:GridViewDataHyperLinkColumn FieldName="IDTRANS" VisibleIndex="0">
                <PropertiesHyperLinkEdit NavigateUrlFormatString="../Reportes/ImpRecepTran.aspx?idtran={0}"
                    Target="_blank">
                </PropertiesHyperLinkEdit>
            </dx:GridViewDataHyperLinkColumn>
            <dx:GridViewDataTextColumn Caption="Area de Transferencia" FieldName="IDAREAB" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Fecha de Env&#237;o" FieldName="FECHA" VisibleIndex="2">
                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
        </Columns>
        <Settings ShowTitlePanel="True" />
        <SettingsText Title="Historial de Recepciones de Transferencias de Miel" />
        <SettingsDetail ShowDetailRow="True" />
        <Styles>
            <TitlePanel Font-Bold="True" HorizontalAlign="Center">
            </TitlePanel>
        </Styles>
        <Templates>
            <DetailRow>
                <dx:ASPxGridView ID="gridTambores" runat="server" DataSourceID="dsHistTamb" KeyFieldName="IDTAMBOR"
                    OnBeforePerformDataSelect="gridTambores_BeforePerformDataSelect">
                    <SettingsDetail IsDetailGrid="True" />
                </dx:ASPxGridView>
            </DetailRow>
        </Templates>
    </dx:ASPxGridView>
    <asp:ObjectDataSource ID="dsHistTranMiel" runat="server" SelectMethod="ObtenHistRecepTransfMiel"
        TypeName="MieleraNet.DAL.RecepTranMielDS">
        <SelectParameters>
            <asp:SessionParameter Name="idarea" SessionField="idarea" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsHistTamb" runat="server" SelectMethod="ObtenHistTamboresRecepcionTransferenciaMiel"
        TypeName="MieleraNet.DAL.RecepTranMielDS">
        <SelectParameters>
            <asp:SessionParameter Name="idtransferencia" SessionField="idHistRecepTranMiel" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</dx:ContentControl>
</ContentCollection>
</dx:TabPage>
</TabPages>
    </dx:ASPxPageControl>
    &nbsp;

    <asp:ObjectDataSource ID="dsTransfARecep" runat="server" SelectMethod="ObtenTransferenciasARecepcionar"
        TypeName="MieleraNet.DAL.MuestreoDS">
        <SelectParameters>
            <asp:SessionParameter Name="idarea" SessionField="idarea" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsReimprimir" runat="server" SelectMethod="ObtenTransferenciasAReimprimir"
        TypeName="MieleraNet.DAL.MuestreoDS">
        <SelectParameters>
            <asp:SessionParameter Name="idUsuario" SessionField="idusr" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <dx:ASPxPopupControl ID="popMB" runat="server" AllowDragging="True" ClientInstanceName="pcError"
        EnableViewState="False" HeaderText="MieleraNet" Modal="True" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter">
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <table border="0" cellpadding="0">
                    <tr>
                        <td>
                            <dx:ASPxLabel ID="lbError" runat="server" Text="Esto es una prueba">
                            </dx:ASPxLabel>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <br />
                            <dx:ASPxButton ID="DlgBtnCerrar" runat="server" AutoPostBack="False" Text="Cerrar">
                                <ClientSideEvents Click="function(s, e) {
	                                                                    pcError.Hide();
                                                                       }" />
                            </dx:ASPxButton>
                        </td>
                    </tr>
                </table>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
</asp:Content>
