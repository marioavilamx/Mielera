<%@ Page Language="C#" MasterPageFile="~/Mielera.Master" AutoEventWireup="true" CodeBehind="solicitud.aspx.cs" Inherits="MieleraNet.Solicitudes.solicitud" Title="Solicitud de Anticipos y Suministros" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxPageControl ID="pagecontrolSolicitud" runat="server" ActiveTabIndex="2">
        <tabpages>
            <dx:TabPage Text="Consulta">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <dx:ASPxGridView ID="gridSolicitud" runat="server" DataSourceID="ObjectDSAnticipos" AutoGenerateColumns="False" OnCustomButtonCallback="gridSolicitud_CustomButtonCallback" OnCustomColumnDisplayText="gridSolicitud_CustomColumnDisplayText" KeyFieldName="IDSOLREC">
                            <Settings ShowTitlePanel="True" />
                            <SettingsText Title="Solicitudes Pendientes de Enviar" />
                            <Styles>
                                <TitlePanel HorizontalAlign="Center">
                                </TitlePanel>
                            </Styles>
                            <Columns>
                                <dx:GridViewDataTextColumn FieldName="FEHOR1" VisibleIndex="0" Caption="FECHA">
                                    <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NOMBRE" VisibleIndex="1">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="EDO" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="$ SUMINISTRO" FieldName="TOPESOS" VisibleIndex="3">
                                    <PropertiesTextEdit DisplayFormatString="c">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="$ ANTICIPO" FieldName="MONTOSOL" VisibleIndex="4">
                                    <PropertiesTextEdit DisplayFormatString="c">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="PAGADO" VisibleIndex="5">
                                    <PropertiesTextEdit DisplayFormatString="c">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="TIPO" FieldName="ESSUMINISTRO" VisibleIndex="6">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="IDSOLREC" VisibleIndex="7" Caption="FOLIO">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="8">
                                    <ClearFilterButton Visible="True">
                                    </ClearFilterButton>
                                    <CustomButtons>
                                        <dx:GridViewCommandColumnCustomButton ID="Enviar">
                                            <Image ToolTip="Env&#237;a Solicitud" Url="~/Images/enviar.jpg">
                                            </Image>
                                        </dx:GridViewCommandColumnCustomButton>
                                    </CustomButtons>
                                </dx:GridViewCommandColumn>
                            </Columns>
                            <Templates>
                                <DetailRow>
                                    <dx:ASPxGridView ID="gridDetalleSol" runat="server" DataSourceID="ObjectDSDetealleSolcitud"
                                        KeyFieldName="IDSOLIC" OnBeforePerformDataSelect="ASPxGridView1_BeforePerformDataSelect" AutoGenerateColumns="False">
                                        <SettingsDetail IsDetailGrid="True" />
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="NOMBRE" VisibleIndex="0">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="KILOS" VisibleIndex="1">
                                                <PropertiesTextEdit DisplayFormatString="n">
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="PUNTI" FieldName="PREU" VisibleIndex="2">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="TAMBORES" VisibleIndex="3">
                                                <PropertiesTextEdit DisplayFormatString="{0:N0}">
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="FEMAX" VisibleIndex="4">
                                                <PropertiesTextEdit DisplayFormatString="dd/MM/yy">
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="FRAMUES" VisibleIndex="5">
                                                <PropertiesTextEdit DisplayFormatString="{0:N0}">
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                    </dx:ASPxGridView>
                                    <asp:ObjectDataSource ID="ObjectDSDetealleSolcitud" runat="server" SelectMethod="ObtenAnticiposDetallePorIdSolicitud"
                                        TypeName="MieleraNet.DAL.AnticipoDS">
                                        <SelectParameters>
                                            <asp:SessionParameter DefaultValue="" Name="idsolrec" SessionField="idDetalleSolRec"
                                                Type="String" />
                                        </SelectParameters>
                                    </asp:ObjectDataSource>
                                </DetailRow>
                            </Templates>
                            <SettingsDetail ShowDetailRow="True" />
                        </dx:ASPxGridView>
                        <asp:ObjectDataSource ID="ObjectDSAnticipos" runat="server" SelectMethod="ObtenAnticiposPorDelegado"
                            TypeName="MieleraNet.DAL.AnticipoDS">
                            <SelectParameters>
                                <asp:SessionParameter Name="iddelegado" SessionField="idusr" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        &nbsp;&nbsp;<br />
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Nueva Solicitud">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <table border="0" cellpadding="0" style="width: 400px; height: 100%">
                            <tr>
                                <td style="text-align: right">
                                    Fecha:</td>
                                <td style="text-align: left">
                                    <dx:ASPxLabel ID="lbFechaHoy" runat="server" ForeColor="#00C000">
                                    </dx:ASPxLabel>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <dx:ASPxRadioButton ID="rbAnticipo" runat="server" AutoPostBack="True" Checked="True"
                                        GroupName="Solicitud" OnCheckedChanged="rbAnticipo_CheckedChanged" Text="Anticipo">
                                    </dx:ASPxRadioButton>
                                </td>
                                <td>
                                    <dx:ASPxRadioButton ID="rbSum" runat="server" AutoPostBack="True" GroupName="Solicitud"
                                        OnCheckedChanged="rbSum_CheckedChanged" Text="Suministro">
                                    </dx:ASPxRadioButton>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:MultiView ID="mvSolic" runat="server" ActiveViewIndex="0" EnableViewState="False">
                                        <asp:View ID="View1" runat="server">
                                            <table border="0" cellpadding="0" style="width: 100%">
                                                <tr>
                                                    <td style="width: 110px; text-align: right">
                                                        Monto Solicitado:</td>
                                                    <td>
                                                        <dx:ASPxTextBox ID="edtMonto" runat="server" Width="170px">
                                                            <MaskSettings Mask="$&lt;0..999999g&gt;.&lt;00..99&gt;" IncludeLiterals="DecimalSymbol" />
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 110px; text-align: right">
                                                        Observaciones:</td>
                                                    <td>
                                                        <dx:ASPxMemo ID="edtAntObsr" runat="server" Height="71px" Width="170px">
                                                        </dx:ASPxMemo>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                        <asp:View ID="View2" runat="server">
                                            <table border="0" cellpadding="0" style="width: 100%; height: 100%">
                                                <tr>
                                                    <td style="width: 100px; text-align: right;">
                                                        Apicultor:</td>
                                                    <td>
                                                        <dx:ASPxComboBox ID="edtApicultor" runat="server" DataSourceID="dsLocenfis" IncrementalFilteringMode="Contains"
                                                            TextField="NOMBRE" ValueField="IDENFI2" ValueType="System.String">
                                                        </dx:ASPxComboBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px; text-align: right">
                                                        Kilos:</td>
                                                    <td>
                                                        <dx:ASPxTextBox ID="edtKilos" runat="server" Width="170px">
                                                            <MaskSettings IncludeLiterals="None" Mask="&lt;0..99999g&gt;.&lt;00..99&gt;" />
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px; text-align: right">
                                                        Precio Unitario:</td>
                                                    <td>
                                                        <dx:ASPxTextBox ID="edtPrecio" runat="server" Width="170px">
                                                            <MaskSettings Mask="$&lt;0..99999g&gt;.&lt;00..99&gt;" IncludeLiterals="DecimalSymbol" />
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px; text-align: right">
                                                        Tambores:</td>
                                                    <td>
                                                        <dx:ASPxTextBox ID="edtTambores" runat="server" Width="170px">
                                                            <MaskSettings Mask="&lt;0..100000&gt;" />
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px; text-align: right">
                                                        Frascos:</td>
                                                    <td>
                                                        <dx:ASPxTextBox ID="edtFrascos" runat="server" Width="170px">
                                                            <MaskSettings Mask="&lt;0..100000&gt;" />
                                                        </dx:ASPxTextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px; text-align: right">
                                    Fecha Max:</td>
                                                    <td>
                                                        <dx:ASPxDateEdit ID="edtFechaMax" runat="server" Width="170px">
                                                        </dx:ASPxDateEdit>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 100px; text-align: right">
                                                        Observaciones:</td>
                                                    <td>
                                                        <dx:ASPxMemo ID="edtObser" runat="server" Height="71px" Width="170px">
                                                        </dx:ASPxMemo>
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:View>
                                    </asp:MultiView>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                </td>
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    <dx:ASPxButton ID="btnGrabar" runat="server" Text="Grabar Solicitud" OnClick="btnGrabar_Click">
                                    </dx:ASPxButton>
                                </td>
                                <td style="width: 100px">
                                    <dx:ASPxButton ID="btnEnviar" runat="server" Text="Env&#237;a Solicitud" OnClick="btnEnviar_Click" Visible="False">
                                    </dx:ASPxButton>
                                </td>
                                <td style="width: 100px">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Historial">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <dx:ASPxGridView ID="gridHistorial" runat="server" DataSourceID="ObjectDSHistorial" AutoGenerateColumns="False">
                            <Settings ShowTitlePanel="True" />
                            <SettingsText Title="Historial de Solicitudes" />
                            <Styles>
                                <TitlePanel HorizontalAlign="Center">
                                </TitlePanel>
                            </Styles>
                            <Columns>
                                <dx:GridViewDataTextColumn Caption="FOLIO" FieldName="IDSOLREC" VisibleIndex="0">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="FECHA" FieldName="FEHOR1" VisibleIndex="1">
                                    <PropertiesTextEdit DisplayFormatString="dd/MM/yy">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="ESTATUS" FieldName="EDO" VisibleIndex="2">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="NOMBRE" VisibleIndex="3">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="OBSERVACIONES" FieldName="OBSERS" VisibleIndex="4">
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="$ SUMINISTRO" FieldName="TOPESOS" VisibleIndex="5">
                                    <PropertiesTextEdit DisplayFormatString="c">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="$ ANTICIPO" FieldName="MONTOSOL" VisibleIndex="6">
                                    <PropertiesTextEdit DisplayFormatString="c">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="PAGADO" VisibleIndex="7">
                                    <PropertiesTextEdit DisplayFormatString="c">
                                    </PropertiesTextEdit>
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn Caption="TIPO" FieldName="ESSUMINISTRO" VisibleIndex="8">
                                </dx:GridViewDataTextColumn>
                            </Columns>
                        </dx:ASPxGridView>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
        </tabpages>
    </dx:ASPxPageControl>
    <asp:ObjectDataSource ID="dsLocenfis" runat="server" SelectMethod="ObtenApicultoresPorDelegado"
        TypeName="MieleraNet.DAL.CentralDS">
        <SelectParameters>
            <asp:SessionParameter Name="delegado" SessionField="idusr" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource><asp:ObjectDataSource ID="ObjectDSHistorial" runat="server" SelectMethod="ObtenAnticiposHistorialPorDelegado"
                            TypeName="MieleraNet.DAL.AnticipoDS">
        <SelectParameters>
            <asp:SessionParameter Name="iddelegado" SessionField="idusr" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <dx:ASPxPopupControl id="popMB" runat="server" AllowDragging="True" ClientInstanceName="pcError"
        EnableViewState="False" HeaderText="Información" Modal="True" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter">
        <contentcollection>
                             <dx:PopupControlContentControl  runat="server">
                                 <table  border="0" cellpadding="0">
                                     <tr>
                                         <td >
                                            <dx:ASPxLabel  ID="lbError" runat="server" Text="Esto es una prueba">
                                            </dx:ASPxLabel>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="right">
                                             <br  />
                                             <dx:ASPxButton ID="DlgBtnCerrar" runat="server" Text="Cerrar"  AutoPostBack="False">
                                             <ClientSideEvents  Click="function(s, e) {
	            pcError.Hide();
                window.location = &quot;Solicitud.aspx&quot;;
                }"  />
                                             </dx:ASPxButton>
                                         </td>
                                     </tr>
                                </table>
                         </dx:PopupControlContentControl>
                         </contentcollection>
    </dx:ASPxPopupControl>
    
</asp:Content>
