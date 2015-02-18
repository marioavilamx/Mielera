<%@ Page Language="C#" MasterPageFile="~/Mielera.Master" AutoEventWireup="true" CodeBehind="Envios.aspx.cs" Inherits="MieleraNet.Exp.Envios" Title="Exportacion" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxHiddenField" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" language="javascript">

function Uploader_OnUploadStart() {
    btnOK.SetText("Subiendo...");
    btnOK.SetEnabled(false);
}

function Uploader_OnUploadComplete(args) {
    if (args.isValid) {
        pcCargaArch.Hide();
    }
    btnOK.SetText("Carga Archivo");
    btnOK.SetEnabled(true);
    gridContExp.Refresh();
}

function ShowWindowList(idcont,idtipo,iddoc, documento, check, nomarch ) {
    hfCargaArch.Set("idcont", idcont);
    hfCargaArch.Set("idtipo", idtipo);
    hfCargaArch.Set("iddoc", iddoc);
    hfCargaArch.Set("nomarch", nomarch);
    lbChkList.SetText(documento);
    btnOK2.SetEnabled(false);
    pcCheck.Show();
}

function ShowWindow(idcont,idtipo,iddoc, documento, check, nomarch ) {
    hfCargaArch.Set("idcont", idcont);
    hfCargaArch.Set("idtipo", idtipo);
    hfCargaArch.Set("iddoc", iddoc);
    hfCargaArch.Set("nomarch", nomarch);
  
    lbArchivo.SetText(documento);
    pcCargaArch.Show();
}

function RowClickHandler(s, e) {
    cmbContrato.SetKeyValue(gridContratos.cpKeyValues[e.visibleIndex]);
    cmbContrato.SetText(gridContratos.cpContratos[e.visibleIndex]);
    cmbContrato.HideDropDown();
}

function RowClickHandler2(s, e) {
    cmbContratoExp.SetKeyValue(gridContratosExp.cpKeyValues[e.visibleIndex]);
    cmbContratoExp.SetText(gridContratosExp.cpContratos[e.visibleIndex]);
    //hfCargaArch.Set("cmbValue", gridContratosExp.cpKeyValues[e.visibleIndex]);
    //hfCargaArch.Set("cmbText", gridContratosExp.cpContratos[e.visibleIndex]);
    cmbContratoExp.HideDropDown();
    gridContExp.Refresh();
    gridPlan.Refresh();
    gridIntinerario.Refresh();
    callbackPanel.PerformCallback(cmbContratoExp.GetKeyValue());
    callbackPanelOS.PerformCallback(cmbContratoExp.GetKeyValue());
    var tab = pagecontrolExpCont.GetTabByName("Booking");
    //alert(tab.name);
    tab.SetEnabled(true);
}

</script>
    <dx:ASPxPageControl ID="pagecontrolExport" runat="server" ActiveTabIndex="0">
        <TabPages>
            <dx:TabPage Text="Exportaciones">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <dx:ASPxRoundPanel ID="panelContratoExport" runat="server" Width="400px" HeaderText="Exportaci&#243;n" SkinID="RoundPanelGroupBox">
                            <PanelCollection>
                                <dx:PanelContent runat="server">
                                    <table border="0" cellpadding="0" style="width: 100%; height: 100%">
                                        <tr>
                                            <td>
                                                <table border="0" cellpadding="0" style="width: 100%; height: 100%">
                                                    <tr>
                                                        <td style="width: 100px">
                                                            <dx:ASPxLabel ID="lb22" runat="server" Text="Numero Contrato:" >
                                                            </dx:ASPxLabel>
                                                        </td>
                                                        <td><dx:ASPxDropDownEdit ID="cmbContratoExp" runat="server" ClientInstanceName="cmbContratoExp" OnValueChanged="cmbContratoExp_ValueChanged" ReadOnly="True">
                                                            <DropDownWindowTemplate>
                                                                <dx:ASPxGridView ID="gridContratosExp" runat="server" ClientInstanceName="gridContratosExp" OnCustomJSProperties="gridContratosExp_CustomJSProperties" AutoGenerateColumns="False" Width="400px" DataSourceID="dsContExpTipo">
                                                                    <ClientSideEvents RowClick="RowClickHandler2" />
                                                                    <Columns>
                                                                        <dx:GridViewDataTextColumn Caption="Contrato" FieldName="NUMCONTRATO" VisibleIndex="0">
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn Caption="Fecha" FieldName="FECHALTA" VisibleIndex="1">
                                                                            <PropertiesTextEdit DisplayFormatString="d">
                                                                            </PropertiesTextEdit>
                                                                        </dx:GridViewDataTextColumn>
                                                                        <dx:GridViewDataTextColumn Caption="Nombre" FieldName="NOMBRE" VisibleIndex="2" Width="300px">
                                                                        </dx:GridViewDataTextColumn>
                                                                    </Columns>
                                                                </dx:ASPxGridView>
                                                            </DropDownWindowTemplate>
                                                        </dx:ASPxDropDownEdit>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                        </td>
                                                        <td>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxPageControl ID="pagecontrolExpCont" runat="server" ActiveTabIndex="1" Width="380px" ClientInstanceName="pagecontrolExpCont" EnableHierarchyRecreation="True" EnableViewState="False" OnActiveTabChanging="pagecontrolExpCont_ActiveTabChanging">
                                                    <TabPages>
                                                        <dx:TabPage Text="Documentos" Name="Documentos">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                    <dx:ASPxGridView ID="gridContExp" runat="server" DataSourceID="dsContExp" AutoGenerateColumns="False" OnCustomColumnDisplayText="gridContExp_CustomColumnDisplayText" KeyFieldName="IDDOC" OnCustomUnboundColumnData="gridContExp_CustomUnboundColumnData" OnHtmlRowPrepared="gridContExp_HtmlRowPrepared" ClientInstanceName="gridContExp" Width="300px">
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="DOCUMENTO" VisibleIndex="0">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="LISTO" UnboundType="Object" VisibleIndex="1">
                                                <DataItemTemplate>
                                                    <dx:ASPxButton ID="btnCargaArch" runat="server" AutoPostBack="False" EnableTheming="False" Height="18px" SkinID="none" Width="18px"><Image Url="~/Images/new.png" Height="18px" Width="18px">
                                                    </Image>
                                                        <BorderLeft BorderStyle="None" />
                                                        <BorderTop BorderStyle="None" />
                                                        <Paddings Padding="0px" />
                                                        <BorderRight BorderStyle="None" />
                                                        <BorderBottom BorderStyle="None" />
                                                        <Border BorderStyle="None" />
                                                    </dx:ASPxButton>
                                                    <dx:ASPxButton ID="btnYes" runat="server" AutoPostBack="False" EnableTheming="False" Height="18px" SkinID="none" Width="18px">
                                                        <Image Url="~/Images/yes.png" Height="18px" Width="18px">
                                                        </Image>
                                                        <Paddings Padding="0px" />
                                                        <Border BorderStyle="None" />
                                                    </dx:ASPxButton>
                                                </DataItemTemplate>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="IDCONTRATO" Visible="False" VisibleIndex="2">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="IDTIPOEXP" Visible="False" VisibleIndex="2">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="IDDOC" Visible="False" VisibleIndex="2">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="CHECKLIST" Visible="False" VisibleIndex="2">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="NOMARCH" Visible="False" VisibleIndex="2">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <SettingsPager Mode="ShowAllRecords" Visible="False">
                                        </SettingsPager>
                                    </dx:ASPxGridView>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:TabPage>
                                                        <dx:TabPage Text="Booking" Name="Booking">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:ASPxCallbackPanel ID="callbackPanel" runat="server" ClientInstanceName="callbackPanel" OnCallback="callbackPanel_Callback">
                                                                        <panelcollection>
<dx:PanelContent runat="server">
                                                                    <dx:ASPxRoundPanel ID="panelBookig" runat="server" HeaderText="Booking Confirmation" SkinID="RoundPanelGroupBox"
                                                                        Width="300px" ClientInstanceName="panelBookig">
                                                                        <PanelCollection>
                                                                            <dx:PanelContent runat="server">
                                                                                <table cellpadding="2" style="width: 100%; height: 100%">
                                                                                    <tr>
                                                                                        <td style="width: 150px">
                                                                                            <dx:ASPxLabel ID="lb31" runat="server" Text="Booking No:">
                                                                                            </dx:ASPxLabel>
                                                                                        </td>
                                                                                        <td>
                                                                                            <dx:ASPxTextBox ID="edtNoBK" runat="server" Width="170px">
                                                                                            </dx:ASPxTextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 150px">
                                                                                            <dx:ASPxLabel ID="lb32" runat="server" Text="From:">
                                                                                            </dx:ASPxLabel>
                                                                                        </td>
                                                                                        <td>
                                                                                            <dx:ASPxTextBox ID="edtFrom" runat="server" Width="170px">
                                                                                            </dx:ASPxTextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 150px">
                                                                                            <dx:ASPxLabel ID="lb33" runat="server" Text="To:">
                                                                                            </dx:ASPxLabel>
                                                                                        </td>
                                                                                        <td>
                                                                                            <dx:ASPxTextBox ID="edtTo" runat="server" Width="170px">
                                                                                            </dx:ASPxTextBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 150px">
                                                                                            <dx:ASPxLabel ID="lb34" runat="server" Text="Fecha Salida:">
                                                                                            </dx:ASPxLabel>
                                                                                        </td>
                                                                                        <td>
                                                                                            <dx:ASPxDateEdit ID="edtSalida" runat="server">
                                                                                            </dx:ASPxDateEdit>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 150px">
                                                                                            <dx:ASPxLabel ID="lb35" runat="server" Text="Fecha Llegada:">
                                                                                            </dx:ASPxLabel>
                                                                                        </td>
                                                                                        <td>
                                                                                            <dx:ASPxDateEdit ID="edtLlegada" runat="server">
                                                                                            </dx:ASPxDateEdit>
                                                                                        </td>
                                                                                    </tr>
                                                                                    <tr>
                                                                                        <td style="width: 150px">
                                                                                        </td>
                                                                                        <td>
                                                                                            <dx:ASPxButton ID="btnGrabaBK" runat="server" OnClick="btnGrabaBK_Click" Text="Graba">
                                                                                            </dx:ASPxButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                            </dx:PanelContent>
                                                                        </PanelCollection>
                                                                    </dx:ASPxRoundPanel>
                                                                    <dx:ASPxRoundPanel ID="panelPlan" runat="server" HeaderText="Intended Transport Plan"
                                                                        SkinID="RoundPanelGroupBox" Width="300px">
                                                                        <PanelCollection>
                                                                            <dx:PanelContent runat="server">
                                                                                <dx:ASPxGridView ID="gridPlan" runat="server" DataSourceID="dsPlanTransport" KeyFieldName="IDPLANTRANSP" AutoGenerateColumns="False" ClientInstanceName="gridPlan" Width="400px">
                                                                                    <Columns>
                                                                                        <dx:GridViewCommandColumn VisibleIndex="0" ButtonType="Image">
                                                                                            <EditButton Visible="True">
                                                                                                <Image ToolTip="Actualizar" Url="~/Images/edit.png">
                                                                                                </Image>
                                                                                            </EditButton>
                                                                                            <NewButton Visible="True">
                                                                                                <Image ToolTip="Nuevo" Url="~/Images/new.png">
                                                                                                </Image>
                                                                                            </NewButton>
                                                                                            <DeleteButton Visible="True">
                                                                                                <Image ToolTip="Borrar" Url="~/Images/clear.png">
                                                                                                </Image>
                                                                                            </DeleteButton>
                                                                                            <CancelButton Visible="True">
                                                                                                <Image ToolTip="Cierra el cuadro de edici&#243;n sin salvar los cambios" Url="~/Images/cancel.png">
                                                                                                </Image>
                                                                                            </CancelButton>
                                                                                            <UpdateButton Visible="True">
                                                                                                <Image ToolTip="Salva los cambios y cierra el cuadro de edici&#243;n" Url="~/Images/update.png">
                                                                                                </Image>
                                                                                            </UpdateButton>
                                                                                        </dx:GridViewCommandColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="IDPLANTRANSP" Visible="False" VisibleIndex="0">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="IDBOOKING" Visible="False" VisibleIndex="0">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption="FROM" FieldName="FROM" VisibleIndex="1">
                                                                                            <EditFormSettings CaptionLocation="Top" RowSpan="1" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption="TO" FieldName="TO" VisibleIndex="2">
                                                                                            <EditFormSettings CaptionLocation="Top" RowSpan="1" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="TRANSPORTE" VisibleIndex="5">
                                                                                            <EditFormSettings RowSpan="2" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn Caption="NO. TRANSP" FieldName="NUMEROTRANSPORTE" VisibleIndex="6">
                                                                                            <EditFormSettings RowSpan="2" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataDateColumn Caption="FECHA SALIDA" FieldName="FECHASALIDA" VisibleIndex="3">
                                                                                            <EditFormSettings RowSpan="3" />
                                                                                        </dx:GridViewDataDateColumn>
                                                                                        <dx:GridViewDataDateColumn Caption="FECHA LLEGADA" FieldName="FECHALLEGADA" VisibleIndex="4">
                                                                                            <EditFormSettings RowSpan="3" />
                                                                                        </dx:GridViewDataDateColumn>
                                                                                    </Columns>
                                                                                    <SettingsText CommandNew="Nuevo" EmptyDataRow="No existe plan de transporte" />
                                                                                </dx:ASPxGridView>
                                                                            </dx:PanelContent>
                                                                        </PanelCollection>
                                                                    </dx:ASPxRoundPanel>
                                                                    <dx:ASPxRoundPanel ID="panelIntinerario" runat="server" HeaderText="Intinerario"
                                                                        SkinID="RoundPanelGroupBox" Width="300px">
                                                                        <PanelCollection>
                                                                            <dx:PanelContent runat="server">
                                                                                <dx:ASPxGridView ID="gridIntinerario" runat="server" DataSourceID="dsIntinerario" KeyFieldName="IDINTINERARIO" AutoGenerateColumns="False" ClientInstanceName="gridIntinerario" Width="400px" OnCellEditorInitialize="gridIntinerario_CellEditorInitialize" OnParseValue="gridIntinerario_ParseValue">
                                                                                    <Columns>
                                                                                        <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0">
                                                                                            <EditButton Visible="True">
                                                                                                <Image ToolTip="Actualizar" Url="~/Images/edit.png">
                                                                                                </Image>
                                                                                            </EditButton>
                                                                                            <NewButton Visible="True">
                                                                                                <Image ToolTip="Nuevo" Url="~/Images/new.png">
                                                                                                </Image>
                                                                                            </NewButton>
                                                                                            <DeleteButton Visible="True">
                                                                                                <Image ToolTip="Borrar" Url="~/Images/clear.png">
                                                                                                </Image>
                                                                                            </DeleteButton>
                                                                                            <CancelButton Visible="True">
                                                                                                <Image ToolTip="Cierra el cuadro de edici&#243;n sin salvar los cambios" Url="~/Images/cancel.png">
                                                                                                </Image>
                                                                                            </CancelButton>
                                                                                            <UpdateButton Visible="True">
                                                                                                <Image ToolTip="Salva los cambios y cierra el cuadro de edici&#243;n" Url="~/Images/update.png">
                                                                                                </Image>
                                                                                            </UpdateButton>
                                                                                        </dx:GridViewCommandColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="IDINTINERARIO" Visible="False" VisibleIndex="0">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="IDBOOKING" Visible="False" VisibleIndex="0">
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="TIPO" VisibleIndex="1">
                                                                                            <EditFormSettings CaptionLocation="Top" RowSpan="1" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataTextColumn FieldName="UBICACION" VisibleIndex="2">
                                                                                            <EditFormSettings CaptionLocation="Top" RowSpan="1" />
                                                                                        </dx:GridViewDataTextColumn>
                                                                                        <dx:GridViewDataDateColumn FieldName="FECHA" UnboundType="DateTime" VisibleIndex="3">
                                                                                            <EditFormSettings RowSpan="2" />
                                                                                        </dx:GridViewDataDateColumn>
                                                                                        <dx:GridViewDataTimeEditColumn Caption="HORA INICIO" FieldName="HORAINICIO" VisibleIndex="4">
                                                                                            <PropertiesTimeEdit DisplayFormatString="t">
                                                                                            </PropertiesTimeEdit>
                                                                                            <EditFormSettings RowSpan="3" />
                                                                                        </dx:GridViewDataTimeEditColumn>
                                                                                        <dx:GridViewDataTimeEditColumn Caption="HORA FIN" FieldName="HORAFIN"
                                                                                            VisibleIndex="5">
                                                                                            <PropertiesTimeEdit DisplayFormatString="t">
                                                                                            </PropertiesTimeEdit>
                                                                                            <EditFormSettings RowSpan="3" />
                                                                                        </dx:GridViewDataTimeEditColumn>
                                                                                    </Columns>
                                                                                    <SettingsText CommandNew="Nuevo" EmptyDataRow="No existe plan de transporte" />
                                                                                    <SettingsEditing EditFormColumnCount="3" />
                                                                                </dx:ASPxGridView>
                                                                            </dx:PanelContent>
                                                                        </PanelCollection>
                                                                    </dx:ASPxRoundPanel>
                                                                    </dx:PanelContent>
</panelcollection>
                                                                    </dx:ASPxCallbackPanel>
                                                                    &nbsp;<br />
                                                                    <br />
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:TabPage>
                                                        <dx:TabPage Text="Orden de Salida" Name="OrdSal">
                                                            <ContentCollection>
                                                                <dx:ContentControl runat="server">
                                                                    <dx:ASPxCallbackPanel ID="callbackPanelOS" runat="server" ClientInstanceName="callbackPanelOS"
                                                                        Width="200px" OnCallback="callbackPanelOS_Callback">
                                                                        <PanelCollection>
                                                                            <dx:PanelContent runat="server">
                                                                                <dx:ASPxRoundPanel ID="panelOS" runat="server" HeaderText="Orden de Salida" SkinID="RoundPanelGroupBox"
                                                                                    Width="200px">
                                                                                    <PanelCollection>
                                                                                        <dx:PanelContent runat="server">
                                                                                            <table border="0" cellpadding="0" style="width: 100%; height: 100%">
                                                                                                <tr>
                                                                                                    <td style="width: 100px">
                                                                                                        &nbsp;Fecha:</td>
                                                                                                    <td style="width: 100px"><dx:ASPxDateEdit ID="edtFechaOS" runat="server" ClientInstanceName="edtFechaOS">
                                                                                                    </dx:ASPxDateEdit>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 100px">
                                                                                                        Origen:</td>
                                                                                                    <td style="width: 100px">
                                                                                                        <dx:ASPxTextBox ID="edtOrigenOS" runat="server" Width="170px" ClientInstanceName="edtOrigenOS">
                                                                                                        </dx:ASPxTextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 100px">
                                                                                                        <dx:ASPxLabel ID="lb41" runat="server" Text="Destino:">
                                                                                                        </dx:ASPxLabel>
                                                                                                    </td>
                                                                                                    <td style="width: 100px">
                                                                                                        <dx:ASPxTextBox ID="edtDestinoOS" runat="server" Width="170px" ClientInstanceName="edtDestinoOS">
                                                                                                        </dx:ASPxTextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </dx:PanelContent>
                                                                                    </PanelCollection>
                                                                                </dx:ASPxRoundPanel>
                                                                                <br />
                                                                                <dx:ASPxRoundPanel ID="panelOS2" runat="server" HeaderText="Informaci&#243;n General"
                                                                                    SkinID="RoundPanelGroupBox" Width="200px">
                                                                                    <PanelCollection>
                                                                                        <dx:PanelContent runat="server">
                                                                                            <table border="0" cellpadding="0" cellspacing="4" style="width: 100%; height: 100%">
                                                                                                <tr>
                                                                                                    <td style="width: 100px">
                                                                                                        Lote:</td>
                                                                                                    <td>
                                                                                                        <dx:ASPxComboBox id="edtLoteOS" runat="server" Width="170px" ValueField="IDPROD" TextField="NUMPROD" DataSourceID="dsProd" ValueType="System.Int32" IncrementalFilteringMode="StartsWith" IncrementalFilteringDelay="200" EnableIncrementalFiltering="True" EnableCallbackMode="True" CallbackPageSize="20" DropDownStyle="DropDown">
                                                                                                        </dx:ASPxComboBox></td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 100px">
                                                                                                        Tipo:</td>
                                                                                                    <td style="width: 100px"><dx:ASPxTextBox ID="edtTipoOS" runat="server" Width="170px" Text="MIEL PURA DE ABEJA">
                                                                                                    </dx:ASPxTextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 100px">
                                                                                                        Contenedor:</td>
                                                                                                    <td style="width: 100px"><dx:ASPxTextBox ID="edtContenedorOS" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 100px">
                                                                                                        Sello:</td>
                                                                                                    <td style="width: 100px"><dx:ASPxTextBox ID="edtSelloOS" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 100px">
                                                                                                        Factura:</td>
                                                                                                    <td style="width: 100px"><dx:ASPxTextBox ID="edtContratoOS" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 100px">
                                                                                                        Tambores:</td>
                                                                                                    <td style="width: 100px"><dx:ASPxTextBox ID="edtTamboresOS" runat="server" Width="170px" DisplayFormatString="N0">
                                                                                                        <MaskSettings Mask="&lt;0..10000&gt;" />
                                                                                                    </dx:ASPxTextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 100px">
                                                                                                        Peso Neto:</td>
                                                                                                    <td style="width: 100px"><dx:ASPxTextBox ID="edtPesoOS" runat="server" Width="170px">
                                                                                                        <MaskSettings Mask="&lt;0..99999g&gt;.&lt;00..99&gt;" />
                                                                                                    </dx:ASPxTextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 100px">
                                                                                                        Fletera:</td>
                                                                                                    <td style="width: 100px"><dx:ASPxTextBox ID="edtFleteraOS" runat="server" Width="170px" ClientInstanceName="edtFleteraOS">
                                                                                                    </dx:ASPxTextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 100px">
                                                                                                        Operador:</td>
                                                                                                    <td style="width: 100px">
                                                                                                        <dx:ASPxComboBox ID="edtOperador" runat="server" DataSourceID="ObjectDSChoferes"
                                                                                                            OnSelectedIndexChanged="ASPxComboBox1_SelectedIndexChanged" TextField="CHOFER"
                                                                                                            ValueField="PLACA" ValueType="System.String" AutoPostBack="True" ClientInstanceName="edtOperador" Width="170px">
                                                                                                        </dx:ASPxComboBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 100px">
                                                                                                        Placas:</td>
                                                                                                    <td style="width: 100px"><dx:ASPxTextBox ID="edtPlacas" runat="server" Width="170px">
                                                                                                    </dx:ASPxTextBox>
                                                                                                    </td>
                                                                                                </tr>
                                                                                                <tr>
                                                                                                    <td style="width: 100px">
                                                                                                    </td>
                                                                                                    <td style="width: 100px">
                                                                                                        &nbsp;</td>
                                                                                                </tr>
                                                                                            </table>
                                                                                        </dx:PanelContent>
                                                                                    </PanelCollection>
                                                                                </dx:ASPxRoundPanel>
                                                                                &nbsp;<br />
                                                                                <table border="0" cellspacing="5">
                                                                                    <tr>
                                                                                        <td style="width: 150px">
                                                                                
                                                                                
                                                                                <dx:ASPxButton ID="btnGrabaOS" runat="server" Text="Graba Orden de Salida" OnClick="btnGrabaOS_Click" Width="150px">                                                                              
                                                                                </dx:ASPxButton>
                                                                                        </td>
                                                                                        <td style="width: 100px">
                                                                                                                                                                
                                                                                <dx:ASPxButton ID="btnImprimeReport" runat="server" Text="Imprime reporte" VerticalAlign="Middle" Width="120px" >
                                                                                    <ClientSideEvents Click="function(s, e) {
 if(cmbContratoExp.GetValue()==null)
alert('Selecciona un n&#250;mero de contrato');
else
{
   window.open(&quot;../Reportes/OrdenSalida.aspx?origen=&quot; + edtOrigenOS.GetValue()+&quot;&amp;fecha=&quot;+edtFechaOS.Date+&quot;&amp;operador=&quot;+edtOperador.GetText()+&quot;&amp;destino=&quot;+edtDestinoOS.GetValue()+&quot;&amp;fletera=&quot;+edtFleteraOS.GetValue()+&quot;&quot; ); 
}
 return false;
 }"></ClientSideEvents>
                                                                                </dx:ASPxButton>
                                                                                        </td>
                                                                                    </tr>
                                                                                </table>
                                                                                &nbsp;
                                                                                
                                                                                
                                                                            </dx:PanelContent>
                                                                        </PanelCollection>
                                                                    </dx:ASPxCallbackPanel>
                                                                </dx:ContentControl>
                                                            </ContentCollection>
                                                        </dx:TabPage>
                                                    </TabPages>
                                                    <ClientSideEvents Init="function(s, e) {
	//var tab = pagecontrolExpCont.GetTabByName(&quot;Booking&quot;);
    //tab.SetEnabled(false);
}" />
                                                </dx:ASPxPageControl>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxRoundPanel>
                        <dx:ASPxPopupControl ID="pcCargaArch" runat="server" AllowDragging="True" ClientInstanceName="pcCargaArch"
                            CloseAction="CloseButton" EnableAnimation="False" HeaderText="Carga Archivo"
                            Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                            <ContentCollection>
                                <dx:PopupControlContentControl runat="server">
                                    <table border="0" cellpadding="0" style="width: 300px">
                                        <tr>
                                            <td colspan="2">
                                                <dx:ASPxLabel ID="lbArchivo" runat="server" ClientInstanceName="lbArchivo" Text="lbArchivo">
                                                </dx:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <dx:ASPxUploadControl ID="uploadControl" runat="server" OnFileUploadComplete="uploadControl_FileUploadComplete" Width="300px" ClientInstanceName="uploadControl" FileUploadMode="OnPageLoad">
                                                    <ValidationSettings MaxFileSize="2097152" MaxFileSizeErrorText="El archivo excede del maximo permitido, el cual es de {0} bytes">
                                                    </ValidationSettings>
                                                    <ClientSideEvents FileUploadComplete="function(s, e) {
	Uploader_OnUploadComplete(e);
}" FileUploadStart="function(s, e) {
	Uploader_OnUploadStart();
}" />
                                                </dx:ASPxUploadControl>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right" colspan="2">
                                                <br />
                                                <dx:ASPxButton ID="btnOK" runat="server" Text="Carga Archivo" ClientInstanceName="btnOK" Width="135px" AutoPostBack="False">
                                                    <ClientSideEvents Click="function(s, e) {
	uploadControl.UploadFile();
}" />
                                                </dx:ASPxButton>
                                                <dx:ASPxHiddenField ID="hfCargaArch" ClientInstanceName="hfCargaArch" runat="server">
                                                </dx:ASPxHiddenField>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                        </dx:ASPxPopupControl>
                        <dx:ASPxPopupControl ID="pcCheck" runat="server" AllowDragging="True" CloseAction="CloseButton"
                            EnableAnimation="False" HeaderText="Listo!" Modal="True" PopupHorizontalAlign="WindowCenter"
                            PopupVerticalAlign="WindowCenter" ClientInstanceName="pcCheck">
                            <ContentCollection>
                                <dx:PopupControlContentControl runat="server">
                                    &nbsp;<table border="0" cellpadding="0">
                                        <tr>
                                            <td>
                                                <dx:ASPxLabel ID="lbChkList" runat="server" ClientInstanceName="lbChkList" Text="lbChkList" Width="250px">
                                                </dx:ASPxLabel>
                                                <br />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxCheckBox ID="chkListo" runat="server" ClientInstanceName="chkListo" Text="Listo">
                                                    <ClientSideEvents CheckedChanged="function(s, e) {
	if (s.GetChecked())
	btnOK2.SetEnabled(true);
    else
	btnOK2.SetEnabled(false);
}" ValueChanged="function(s, e) {

}" />
                                                </dx:ASPxCheckBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="right">
                                                <dx:ASPxButton ID="btnOK2" runat="server" Text="OK" OnClick="btnOK2_Click" ClientInstanceName="btnOK2">
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </dx:PopupControlContentControl>
                            </ContentCollection>
                        </dx:ASPxPopupControl>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Liga Contrato">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                    <dx:ASPxRoundPanel id="Relacion" runat="server" Width="100%" HeaderText="Relacionar Contrato" SkinID="RoundPanelGroupBox" GroupBoxCaptionOffsetY="-14px"><PanelCollection>
                    <dx:PanelContent runat="server">
                        <table border="0" cellpadding="0">
                            <tr>
                                <td align="right">
                                    <dx:ASPxLabel ID="lb2" runat="server" Text="Numero Contrato:" >
                                    </dx:ASPxLabel>
                                    </td>
                                <td>
                                    <dx:ASPxDropDownEdit ID="cmbContrato" runat="server" ClientInstanceName="cmbContrato">
                                        <DropDownWindowTemplate>
                                            <dx:ASPxGridView ID="gridContratos" runat="server" DataSourceID="dsCont" ClientInstanceName="gridContratos" OnCustomJSProperties="gridContratos_CustomJSProperties" AutoGenerateColumns="False" Width="400px">
                                                <ClientSideEvents RowClick="RowClickHandler" />
                                                <Columns>
                                                    <dx:GridViewDataTextColumn Caption="Contrato" FieldName="NUMCONTRATO" VisibleIndex="0">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Fecha" FieldName="FECHALTA" VisibleIndex="1">
                                                        <PropertiesTextEdit DisplayFormatString="d">
                                                        </PropertiesTextEdit>
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="Nombre" FieldName="NOMBRE" VisibleIndex="2" Width="300px">
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                            </dx:ASPxGridView>
                                        </DropDownWindowTemplate>
                                    </dx:ASPxDropDownEdit>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <dx:ASPxLabel ID="lb3" runat="server" Text="Tipo Exportaci&#243;n:">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                    <dx:ASPxComboBox ID="cmbTipExp" runat="server" ValueType="System.String" DataSourceID="dsTipoExp" TextField="TIPOEXP" ValueField="IDTIPOEXP">
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                </td>
                                <td style="width: 100px">
                                    <dx:ASPxButton ID="btnGrabar" runat="server" Text="Grabar" OnClick="btnGrabar_Click">
                                    </dx:ASPxButton>
                                </td>
                            </tr>
                        </table>
                    </dx:PanelContent>
                    </PanelCollection>
                    </dx:ASPxRoundPanel>
                        <asp:ObjectDataSource ID="dsCont" runat="server" SelectMethod="ContratosSinTipo" TypeName="MieleraNet.DAL.ExportDS">
                        </asp:ObjectDataSource><asp:ObjectDataSource ID="dsTipoExp" runat="server" SelectMethod="ObtenTipoExp" TypeName="MieleraNet.DAL.ExportDS">
                        </asp:ObjectDataSource>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
        </TabPages>
    </dx:ASPxPageControl><asp:ObjectDataSource ID="dsContExp" runat="server" SelectMethod="obtenContratoExport" TypeName="MieleraNet.DAL.ExportDS">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="" Name="idcontrato" SessionField="ContExp" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:ObjectDataSource ID="dsContExpTipo" runat="server" SelectMethod="ContratosConTipo" TypeName="MieleraNet.DAL.ExportDS"></asp:ObjectDataSource><asp:ObjectDataSource ID="dsPlanTransport" runat="server" SelectMethod="ObtenPlanByBooking" TypeName="MieleraNet.DAL.ExportDS" InsertMethod="InsertaPlanTransporte" OnInserting="dsPlanTransport_Inserting" DeleteMethod="EliminaPlanTransporte" UpdateMethod="ActualizaPlanTransporte">
        <DeleteParameters>
            <asp:Parameter Name="IDPLANTRANSP" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="IDPLANTRANSP" />
            <asp:Parameter Name="FROM" />
            <asp:Parameter Name="TO" />
            <asp:Parameter Name="TRANSPORTE" />
            <asp:Parameter Name="NUMEROTRANSPORTE" />
            <asp:Parameter Name="FECHASALIDA" />
            <asp:Parameter Name="FECHALLEGADA" />
        </UpdateParameters>
        <SelectParameters>
            <asp:SessionParameter Name="IDBOOKING" SessionField="IdBooking" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="IDBOOKING" />
            <asp:Parameter Name="FROM" />
            <asp:Parameter Name="TO" />
            <asp:Parameter Name="NUMEROTRANSPORTE" />
            <asp:Parameter Name="FECHASALIDA" />
            <asp:Parameter Name="FECHALLEGADA" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:ObjectDataSource ID="dsIntinerario" runat="server" SelectMethod="ObtenIntinerarioByBooking" TypeName="MieleraNet.DAL.ExportDS" InsertMethod="InsertaIntinerario" OnInserting="dsPlanTransport_Inserting" DeleteMethod="EliminaIntinerario" UpdateMethod="ActualizaIntinerario">
        <DeleteParameters>
            <asp:Parameter Name="IDINTINERARIO" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="IDINTINERARIO" />
            <asp:Parameter Name="TIPO" />
            <asp:Parameter Name="UBICACION" />
            <asp:Parameter Name="FECHA" />
            <asp:Parameter Name="HORAINICIO" />
            <asp:Parameter Name="HORAFIN" />
        </UpdateParameters>
        <SelectParameters>
            <asp:SessionParameter Name="IDBOOKING" SessionField="IdBooking" />
        </SelectParameters>
        <InsertParameters>
            <asp:Parameter Name="IDBOOKING" />
            <asp:Parameter Name="TIPO" />
            <asp:Parameter Name="UBICACION" />
            <asp:Parameter Name="FECHA" />
            <asp:Parameter Name="HORAINICIO" />
            <asp:Parameter Name="HORAFIN" />
        </InsertParameters>
    </asp:ObjectDataSource>
    <br />
    <asp:ObjectDataSource ID="dsProd" runat="server" SelectMethod="ObtenProduccionLibres" TypeName="MieleraNet.DAL.ExportDS">
    </asp:ObjectDataSource>
    <br /><asp:ObjectDataSource ID="ObjectDSChoferes" runat="server" SelectMethod="ObtenChoferes" TypeName="MieleraNet.DAL.ExportDS">
    </asp:ObjectDataSource>
</asp:Content>
