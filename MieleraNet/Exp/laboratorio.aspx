<%@ Page Language="C#" MasterPageFile="~/Mielera.Master" AutoEventWireup="true" CodeBehind="laboratorio.aspx.cs" Inherits="MieleraNet.Exp.laboratorio" Title="Laboratorio" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxRoundPanel ID="rpanelLab" runat="server" HeaderText="Laboratorio" Width="300px">
        <PanelCollection>
            <dx:PanelContent runat="server">
                <table>
                    <tr>
                        <td>
                            <table border="0" cellpadding="0">
                                <tr>
                                    <td style="text-align: right">
                                        Año:</td>
                                    <td>
                                        <dx:ASPxComboBox ID="cmbAnio" runat="server" AutoPostBack="True" ClientInstanceName="cmbAnio"
                                            DataSourceID="dsAnios" OnSelectedIndexChanged="cmbAnio_SelectedIndexChanged"
                                            TextField="MIFECHA" ValueField="MIFECHA" ValueType="System.String">
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        Lote:</td>
                                    <td>
                                        <dx:ASPxComboBox ID="cmbLotes" runat="server" AutoPostBack="True" ClientInstanceName="cmbLotes"
                                            DataSourceID="dsLotes" OnSelectedIndexChanged="cmbLotes_SelectedIndexChanged"
                                            TextField="NUMPROD" ValueField="IDPROD" ValueType="System.String">
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;<dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0">
                                <TabPages>
                                    <dx:TabPage Text="Fisico-Quimico">
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <table border="0" cellpadding="0" style="width: 100%; height: 100%">
                                                    <tr>
                                                        <td>
                                                            Fecha:</td>
                                                        <td align="left">
                                                            <dx:ASPxDateEdit ID="edtFecha" runat="server">
                                                            </dx:ASPxDateEdit>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Empresa:</td>
                                                        <td align="left">
                                                            <dx:ASPxComboBox ID="edtEmpresa" runat="server" DataSourceID="objDSEmpresas" TextField="LABORATORIO"
                                                                ValueField="IDLABORATORIO" ValueType="System.Int32">
                                                            </dx:ASPxComboBox>
                                                            <asp:ObjectDataSource ID="objDSEmpresas" runat="server" SelectMethod="ObtenLaboratorios"
                                                                TypeName="MieleraNet.DAL.ExportDS">
                                                                <SelectParameters>
                                                                    <asp:Parameter DefaultValue="LOCAL" Name="tipo" Type="String" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Reporte No.</td>
                                                        <td align="left">
                                                            <dx:ASPxTextBox ID="edtNumRep" runat="server" Width="170px">
                                                            </dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Nuestra Referencia</td>
                                                        <td align="left">
                                                            <dx:ASPxTextBox ID="edtFactura" runat="server" Width="170px">
                                                            </dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 150px">
                                                            Producto:</td>
                                                        <td align="left">
                                                            <dx:ASPxTextBox ID="edtProducto" runat="server" Width="170px">
                                                            </dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Descripción de la Muestra/Lote:</td>
                                                        <td align="left">
                                                            <dx:ASPxTextBox ID="edtDesc" runat="server" Width="170px">
                                                            </dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Temperatura de Muestra:</td>
                                                        <td align="left">
                                                            <dx:ASPxTextBox ID="edtTemperatura" runat="server" Width="170px">
                                                            </dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Empaquetado/Calidad:</td>
                                                        <td align="left">
                                                            <dx:ASPxTextBox ID="edtEmpaquetado" runat="server" Width="170px">
                                                            </dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Inicio del Análisis</td>
                                                        <td align="left">
                                                            <dx:ASPxDateEdit ID="edtFechaIni" runat="server">
                                                            </dx:ASPxDateEdit>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Fin del Análisis</td>
                                                        <td align="left">
                                                            <dx:ASPxDateEdit ID="edtFechaFin" runat="server">
                                                            </dx:ASPxDateEdit>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <dx:ASPxButton ID="btnGrabaFis" runat="server" Text="Grabar Cambios" Wrap="True" OnClick="btnGrabaFis_Click">
                                                            </dx:ASPxButton>
                                                        </td>
                                                        <td align="left">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <dx:ASPxGridView ID="gridFQDet" runat="server" AutoGenerateColumns="False" KeyFieldName="IDMOVREPORTE" DataSourceID="objDSFQDet">
                                                                <Columns>
                                                                    <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0">
                                                                        <EditButton Visible="True">
                                                                            <Image ToolTip="Actualizar" Url="~/Images/edit.png">
                                                                            </Image>
                                                                        </EditButton>
                                                                        <CancelButton Visible="True">
                                                                            <Image ToolTip="Cierra el cuadro de edici&#243;n sin salvar los cambios" Url="~/Images/cancel.png">
                                                                            </Image>
                                                                        </CancelButton>
                                                                        <UpdateButton Visible="True">
                                                                            <Image ToolTip="Salva los cambios y cierra el cuadro de edici&#243;n" Url="~/Images/update.png">
                                                                            </Image>
                                                                        </UpdateButton>
                                                                    </dx:GridViewCommandColumn>
                                                                    <dx:GridViewDataTextColumn Caption="IDMOVREPORTE" FieldName="IDMOVREPORTE" Visible="False" VisibleIndex="0">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="IDREPORTE" FieldName="IDREPORTE" Visible="False" VisibleIndex="0">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="TIPO" FieldName="TIPOANALISIS" VisibleIndex="1">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="ANALISIS" FieldName="ANALISIS" VisibleIndex="2">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="RESULTADO" FieldName="RESULTADO" VisibleIndex="3">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="UNIDAD" FieldName="UNIDAD" VisibleIndex="4">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="LIMITE DE DETECCION" FieldName="LIMTIEDETECCION"
                                                                        VisibleIndex="5">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="METODO" FieldName="METODO" VisibleIndex="6">
                                                                    </dx:GridViewDataTextColumn>
                                                                </Columns>
                                                            </dx:ASPxGridView>
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2" style="text-align: right">
                                                            <dx:ASPxButton ID="btnRepFisico" runat="server" Text="Reporte Fisico - Quimico" Enabled="False" AutoPostBack="False">
                                                                <ClientSideEvents Click="function(s, e) {
	window.open(&quot;../Reportes/ImpFisicoQuimico.aspx?idProd=&quot; + cmbLotes.GetValue() , &quot;_blank&quot;,&quot;scrollbars=1, width=800,height=600&quot;); 
return false;
}" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                    <dx:TabPage Text="Reporte de An&#225;lisis">
                                        <ContentCollection>
                                            <dx:ContentControl runat="server">
                                                <table border="0" cellpadding="0" style="width: 100%; height: 100%">
                                                    <tr>
                                                        <td style="width: 100px">
                                                            Report No.</td>
                                                        <td>
                                                            <dx:ASPxTextBox ID="edtNorepana" runat="server" Width="170px">
                                                                <ValidationSettings CausesValidation="True" ErrorText="Requerido" SetFocusOnError="True"
                                                                    ValidationGroup="Analisis">
                                                                    <RequiredField ErrorText="*Requerido" IsRequired="True" />
                                                                </ValidationSettings>
                                                            </dx:ASPxTextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px">
                                                            Fecha:</td>
                                                        <td>
                                                            <dx:ASPxDateEdit ID="edtFechaExt" runat="server">
                                                                <ValidationSettings CausesValidation="True" ErrorText="Requerido" ValidationGroup="Analisis">
                                                                    <RequiredField ErrorText="*Requerido" IsRequired="True" />
                                                                </ValidationSettings>
                                                            </dx:ASPxDateEdit>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            Empresa:</td>
                                                        <td align="left">
                                                            <dx:ASPxComboBox ID="edtEmpresaExt" runat="server" DataSourceID="objDSEmpresasExt" TextField="LABORATORIO"
                                                                ValueField="IDLABORATORIO" ValueType="System.Int32">
                                                                <ValidationSettings CausesValidation="True" ValidationGroup="Analisis">
                                                                    <RequiredField ErrorText="*Requerido" IsRequired="True" />
                                                                </ValidationSettings>
                                                            </dx:ASPxComboBox>
                                                            <asp:ObjectDataSource ID="objDSEmpresasExt" runat="server" SelectMethod="ObtenLaboratorios"
                                                                TypeName="MieleraNet.DAL.ExportDS">
                                                                <SelectParameters>
                                                                    <asp:Parameter DefaultValue="EXTERNA" Name="tipo" Type="String" />
                                                                </SelectParameters>
                                                            </asp:ObjectDataSource>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 100px; height: 19px">
                                                        </td>
                                                        <td style="height: 19px">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <dx:ASPxButton ID="btnAddRep" runat="server" Text="Agrega Reporte" Enabled="False" OnClick="btnAddRep_Click" ValidationGroup="Analisis">
                                                            </dx:ASPxButton>
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <dx:ASPxGridView ID="gridRepAna" runat="server" AutoGenerateColumns="False" Width="300px" DataSourceID="objDSAnalisis" KeyFieldName="IDREPORTE">
                                                                <Columns>
                                                                    <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0">
                                                                         <DeleteButton Visible="True">
                                                                                                <Image ToolTip="Borrar" Url="~/Images/clear.png">
                                                                                                </Image>
                                                                                            </DeleteButton>
                                                                    </dx:GridViewCommandColumn>
                                                                    <dx:GridViewDataTextColumn Caption="IDREPORTE" FieldName="IDREPORTE" Visible="False"
                                                                        VisibleIndex="0">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="NO. REPORTE" FieldName="FOLIO" VisibleIndex="1">
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="FECHA" FieldName="FECHA" VisibleIndex="2">
                                                                        <PropertiesTextEdit DisplayFormatString="d">
                                                                            <MaskSettings Mask="dd/MM/yyyy" />
                                                                        </PropertiesTextEdit>
                                                                    </dx:GridViewDataTextColumn>
                                                                    <dx:GridViewDataTextColumn Caption="IDLABORATORIO" FieldName="IDLABORATORIO" Visible="False"
                                                                        VisibleIndex="3">
                                                                    </dx:GridViewDataTextColumn>
                                                                </Columns>
                                                                <Settings ShowTitlePanel="True" />
                                                                <SettingsText Title="Reportes de An&#225;lisis" />
                                                                <Styles>
                                                                    <TitlePanel HorizontalAlign="Center">
                                                                    </TitlePanel>
                                                                </Styles>
                                                            </dx:ASPxGridView>
                                                            <asp:ObjectDataSource ID="objDSAnalisis" runat="server" SelectMethod="ObtenReporteAnalisisByNumProd"
                                                                TypeName="MieleraNet.DAL.ExportDS" DeleteMethod="EliminaAnalisisReport">
                                                                <SelectParameters>
                                                                    <asp:Parameter Name="numprod" Type="String" />
                                                                </SelectParameters>
                                                                <DeleteParameters>
                                                                    <asp:Parameter Name="IDREPORTE" Type="Int32" />
                                                                </DeleteParameters>
                                                            </asp:ObjectDataSource>
                                                            &nbsp;&nbsp;
                                                            <br />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="2">
                                                            <dx:ASPxButton ID="btnRepLab" runat="server" Text="Trazabilidad del Laboratorio" Enabled="False">
                                                                <ClientSideEvents Click="function(s, e) {
	window.open(&quot;../Reportes/ImpTrazLab.aspx?idProd=&quot; + cmbLotes.GetValue() , &quot;_blank&quot;,&quot;scrollbars=1, width=800,height=600&quot;); 
return false;
}" />
                                                            </dx:ASPxButton>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                    <dx:TabPage Text="Certificado">
                                        <ContentCollection>
                                            <dx:ContentControl runat="server"><table border="0" cellpadding="0" style="width: 100%; height: 100%">
                                                <tr>
                                                    <td>
                                                        Cliente:</td>
                                                    <td align="left">
                                                        <dx:ASPxComboBox ID="edtCliente" runat="server" CallbackPageSize="250" DataSourceID="objDSCliente"
                                                            EnableCallbackMode="True" IncrementalFilteringDelay="2000" IncrementalFilteringMode="Contains"
                                                            TextField="Nombre" ValueField="IDENFIMO" ValueType="System.Int32">
                                                            <Columns>
                                                                <dx:ListBoxColumn Caption="NOMBRE" FieldName="NOMBRE" Name="colNombre" />
                                                            </Columns>
                                                        </dx:ASPxComboBox>
                                                        <asp:ObjectDataSource ID="objDSCliente" runat="server" SelectMethod="ObtenDatosCliente"
                                                            TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Fecha:</td>
                                                    <td align="left">
                                                        <dx:ASPxDateEdit ID="edtCFecha" runat="server">
                                                        </dx:ASPxDateEdit>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px">
                                                        Reporte No.</td>
                                                    <td>
                                                        <dx:ASPxTextBox ID="edtCReportNo" runat="server" Width="170px">
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px">
                                                        Invoice:</td>
                                                    <td>
                                                        <dx:ASPxTextBox ID="edtCRef" runat="server" Width="170px">
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px">
                                                        Contrac:</td>
                                                    <td>
                                                        <dx:ASPxTextBox ID="edtCContract" runat="server" Width="170px">
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 150px">
                                                        Conteiner:</td>
                                                    <td><dx:ASPxTextBox ID="edtConteiner" runat="server" Width="170px">
                                                    </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Our reference:</td>
                                                    <td>
                                                       <dx:ASPxTextBox ID="edtCOurRef" runat="server" Width="170px">
                                                    </dx:ASPxTextBox>
                                                       <td>
                                                           &nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Product:</td>
                                                    <td>
                                                        <dx:ASPxTextBox ID="edtCProducto" runat="server" Width="170px">
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Samples description/batch:</td>
                                                    <td>
                                                        <dx:ASPxTextBox ID="edtCLote" runat="server" Width="170px">
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Samples temp:</td>
                                                    <td>
                                                        <dx:ASPxTextBox ID="edtCTemp" runat="server" Width="170px">
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Packing/Quality:</td>
                                                    <td>
                                                        <dx:ASPxTextBox ID="edtCCalidad" runat="server" Width="170px">
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        Start of analysis</td>
                                                    <td>
                                                        <dx:ASPxDateEdit ID="edtCFechaInicio" runat="server">
                                                        </dx:ASPxDateEdit>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        End of analysis</td>
                                                    <td>
                                                        <dx:ASPxDateEdit ID="edtCFechaFin" runat="server">
                                                        </dx:ASPxDateEdit>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <dx:ASPxButton ID="btnGrabaCert" runat="server" Text="Grabar Cambios" Enabled="False" OnClick="btnGrabaCert_Click">
                                                        </dx:ASPxButton>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <dx:ASPxGridView ID="gridCertificDet" runat="server" AutoGenerateColumns="False" DataSourceID="objDSCertDet" KeyFieldName="IDDETCERTIFICADO">
                                                            <Columns>
                                                                <dx:GridViewCommandColumn ButtonType="Image"  VisibleIndex="0">
                                                                    <EditButton Visible="True">
                                                                    <Image ToolTip="Actualizar" Url="~/Images/edit.png">
                                                                            </Image>
                                                                    </EditButton>
                                                                    <CancelButton Visible="True">
                                                                            <Image ToolTip="Cierra el cuadro de edici&#243;n sin salvar los cambios" Url="~/Images/cancel.png">
                                                                            </Image>
                                                                        </CancelButton>
                                                                        <UpdateButton Visible="True">
                                                                            <Image ToolTip="Salva los cambios y cierra el cuadro de edici&#243;n" Url="~/Images/update.png">
                                                                            </Image>
                                                                        </UpdateButton>
                                                                </dx:GridViewCommandColumn>
                                                                <dx:GridViewDataTextColumn FieldName="IDDETCERTIFICADO" Visible="False" VisibleIndex="0">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn FieldName="IDCERTIFICADO" Visible="False" VisibleIndex="0">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="TIPO" FieldName="TIPOANALISIS" VisibleIndex="2" Visible="False">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Analysis" FieldName="ANALISIS" VisibleIndex="3">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Result" FieldName="RESULT" VisibleIndex="4">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Unit" FieldName="UNIT" VisibleIndex="5">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Limit of detection" FieldName="LIMITOFDETECTION"
                                        VisibleIndex="6">
                                                                </dx:GridViewDataTextColumn>
                                                                <dx:GridViewDataTextColumn Caption="Method" FieldName="METHOD" VisibleIndex="7">
                                                                </dx:GridViewDataTextColumn>
                                                            </Columns>
                                                        </dx:ASPxGridView>
                                                        <asp:ObjectDataSource ID="objDSCertDet" runat="server" SelectMethod="ObtenCertificadoByIdCertificado" TypeName="MieleraNet.DAL.ExportDS" UpdateMethod="AcutalizaCertificadoDet">
                                                            <SelectParameters>
                                                                <asp:Parameter Name="IDCERTIFICADO" Type="Int32" />
                                                            </SelectParameters>
                                                            <UpdateParameters>
                                                                <asp:Parameter Name="IDDETCERTIFICADO" Type="Int32" />
                                                                <asp:Parameter Name="IDCERTIFICADO" Type="Int32" />
                                                                <asp:Parameter Name="ANALISIS" Type="String" />
                                                                <asp:Parameter Name="RESULT" Type="String" />
                                                                <asp:Parameter Name="UNIT" Type="String" />
                                                                <asp:Parameter Name="LIMITOFDETECTION" Type="String" />
                                                                <asp:Parameter Name="METHOD" Type="String" />
                                                            </UpdateParameters>
                                                        </asp:ObjectDataSource>
                                                        &nbsp;&nbsp;
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="text-align: right">
                                                                    <dx:ASPxButton ID="btnRepCertificado" runat="server" Text="Imprimir Certificado de An&#225;lisis" Enabled="False" AutoPostBack="False">
                                                                        <ClientSideEvents Click="function(s, e) {
	window.open(&quot;../Reportes/ImpCertificadoAnalisis.aspx?idProd=&quot; + cmbLotes.GetValue() , &quot;_blank&quot;,&quot;scrollbars=1, width=800,height=600&quot;); 
return false;
}" />
                                                                    
                                                                    </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </table>
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:TabPage>
                                </TabPages>
                            </dx:ASPxPageControl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                    </tr>
                </table>
    <asp:ObjectDataSource ID="dsLotes" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="ObtenLoteHist" TypeName="MieleraNet.DAL.PerifericaDS">
        <SelectParameters>
            <asp:ControlParameter ControlID="cmbAnio" Name="mifecha" PropertyName="Value" Type="Int16" />
        </SelectParameters>
    </asp:ObjectDataSource>
                <asp:ObjectDataSource ID="dsAnios" runat="server" SelectMethod="ObtenAniosHist" TypeName="MieleraNet.DAL.PerifericaDS">
                </asp:ObjectDataSource>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxRoundPanel>
    <asp:ObjectDataSource ID="objDSFQDet" runat="server" SelectMethod="ObtenFisicoQuimicoByIdReporte"
        TypeName="MieleraNet.DAL.ExportDS" UpdateMethod="AcutalizaFisicoQuimicoDet">
        <SelectParameters>
            <asp:Parameter Name="idReporte" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="IDMOVREPORTE" />
            <asp:Parameter Name="IDREPORTE"  />
            <asp:Parameter Name="TIPOANALISIS" />
            <asp:Parameter Name="ANALISIS"  />
            <asp:Parameter Name="RESULTADO"  />
            <asp:Parameter Name="UNIDAD" />
            <asp:Parameter Name="LIMTIEDETECCION"  />
            <asp:Parameter Name="METODO" />
        </UpdateParameters>
    </asp:ObjectDataSource>
</asp:Content>
