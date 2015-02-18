<%@ Page Language="C#" MasterPageFile="~/Mielera.Master" AutoEventWireup="true" CodeBehind="ComprasMiel.aspx.cs" Inherits="MieleraNet.Reportes.ComprasMiel" Title="Compras de Miel" %>

<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v10.1.Export, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraPivotGrid.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxPivotGrid.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPivotGrid" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" ShowHeader="False">
        <PanelCollection>
            <dx:PanelContent runat="server">
                <table border="0" cellpadding="3" cellspacing="0">
                    <tr>
                        <td>
                            <strong>Exportar a</strong> </td>
                        <td>
                            <dx:ASPxComboBox ID="listExportFormat" runat="server" style="vertical-align: middle" SelectedIndex="0" ValueType="System.String" Width="61px">
                            <Items>
								<dx:ListEditItem Text="Pdf" Value="0" Selected="True"/>
                                <dx:ListEditItem Text="Excel" Value="1"/>
                            </Items>
                            </dx:ASPxComboBox>
						</td>
						<td>
							<dx:ASPxButton ID="btnSaveAs" runat="server" ToolTip="Exportar y Salvar" style="vertical-align: middle;"  Text="Guardar" Width="51px" OnClick="btnSaveAs_Click" >
							</dx:ASPxButton>
						</td>
						<td>
							<dx:ASPxButton ID="btnOpen" runat="server" ToolTip="Exportar y Abrir" style="vertical-align: middle"  Text="Abrir" Width="51px" OnClick="btnOpen_Click">
							</dx:ASPxButton>
						</td>
                    </tr>
                </table>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxRoundPanel>

    <dx:ASPxPivotGrid ID="gridCompraMiel" runat="server" DataSourceID="objCompraMielDS" Caption="Reporte de Compras de Miel">
        <Fields>
            <dx:PivotGridField ID="fieldNombre" Area="RowArea" AreaIndex="0" FieldName="NOMBRE">
            </dx:PivotGridField>
            <dx:PivotGridField ID="fieldKG" Area="DataArea" AreaIndex="0" FieldName="KILOGRAMOS">
            </dx:PivotGridField>
            <dx:PivotGridField ID="fieldAnio" AreaIndex="0" Caption="A&#209;O" FieldName="ANIO">
            </dx:PivotGridField>
            <dx:PivotGridField ID="fieldMES" AreaIndex="1" FieldName="MES">
            </dx:PivotGridField>
            <dx:PivotGridField ID="fieldSubTotal" AllowedAreas="DataArea" Area="DataArea" AreaIndex="1"
                CellFormat-FormatString="c" CellFormat-FormatType="Numeric" FieldName="SUBTOTAL"
                SortOrder="Descending" TotalValueFormat-FormatString="c" TotalValueFormat-FormatType="Numeric">
            </dx:PivotGridField>
            <dx:PivotGridField ID="fieldContenido" AllowedAreas="ColumnArea" Area="ColumnArea"
                AreaIndex="0" FieldName="CONTENIDO">
            </dx:PivotGridField>
        </Fields>
        <OptionsPager RowsPerPage="15">
        </OptionsPager>
    </dx:ASPxPivotGrid>
    <asp:ObjectDataSource ID="objCompraMielDS" runat="server" SelectMethod="ObtenComprasMiel"
        TypeName="MieleraNet.DAL.RecepTranMielDS">
        <SelectParameters>
            <asp:Parameter Name="FechaIni" Type="DateTime" />
            <asp:Parameter Name="FechaFin" Type="DateTime" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <dx:ASPxPivotGridExporter ID="ASPxPivotGridExporter1" runat="server" ASPxPivotGridID="gridCompraMiel">
    </dx:ASPxPivotGridExporter>
    
</asp:Content>
