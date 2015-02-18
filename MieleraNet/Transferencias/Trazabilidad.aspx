<%@ Page Language="C#" MasterPageFile="~/Mielera.Master" AutoEventWireup="true" CodeBehind="Trazabilidad.aspx.cs" Inherits="MieleraNet.Transferencias.Trazabilidad" Title="Trazabilidad de Entrada" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.XtraReports.v10.1.Web, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" cellpadding="0">
        <tr>
            <td style="width: 100px; text-align: right">
                Transferencia:</td>
            <td style="width: 100px">
                <dx:ASPxComboBox ID="cmbTrans" runat="server" DataSourceID="dsTransferencias"
                    TextField="IDTRANS" ValueField="IDTRANS" ValueType="System.String" AutoPostBack="True" OnSelectedIndexChanged="cmbTrans_SelectedIndexChanged">
                </dx:ASPxComboBox>
            </td>
        </tr>
    </table>
    <asp:ObjectDataSource ID="dsTransferencias" runat="server" SelectMethod="ObtenTransTrazabilidad"
        TypeName="MieleraNet.DAL.RecepTranMielDS">
        <SelectParameters>
            <asp:SessionParameter Name="idusuario" SessionField="idusr" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <dx:ReportToolbar id="tbTraza" runat="server" ReportViewer="<%# rvTraza %>" ShowDefaultButtons="False">
        <items>
<dx:ReportToolbarButton ItemKind="Search"></dx:ReportToolbarButton>
<dx:ReportToolbarSeparator></dx:ReportToolbarSeparator>
<dx:ReportToolbarButton ItemKind="PrintReport"></dx:ReportToolbarButton>
<dx:ReportToolbarButton ItemKind="PrintPage"></dx:ReportToolbarButton>
<dx:ReportToolbarSeparator></dx:ReportToolbarSeparator>
<dx:ReportToolbarButton Enabled="False" ItemKind="FirstPage"></dx:ReportToolbarButton>
<dx:ReportToolbarButton Enabled="False" ItemKind="PreviousPage"></dx:ReportToolbarButton>
<dx:ReportToolbarLabel ItemKind="PageLabel"></dx:ReportToolbarLabel>
<dx:ReportToolbarComboBox Width="65px" ItemKind="PageNumber"></dx:ReportToolbarComboBox>
<dx:ReportToolbarLabel ItemKind="OfLabel"></dx:ReportToolbarLabel>
<dx:ReportToolbarTextBox IsReadOnly="True" ItemKind="PageCount"></dx:ReportToolbarTextBox>
<dx:ReportToolbarButton ItemKind="NextPage"></dx:ReportToolbarButton>
<dx:ReportToolbarButton ItemKind="LastPage"></dx:ReportToolbarButton>
<dx:ReportToolbarSeparator></dx:ReportToolbarSeparator>
<dx:ReportToolbarButton ItemKind="SaveToDisk"></dx:ReportToolbarButton>
<dx:ReportToolbarButton ItemKind="SaveToWindow"></dx:ReportToolbarButton>
<dx:ReportToolbarComboBox Width="70px" ItemKind="SaveFormat"><Elements>
<dx:ListElement Value="pdf"></dx:ListElement>
<dx:ListElement Value="xls"></dx:ListElement>
<dx:ListElement Value="xlsx"></dx:ListElement>
<dx:ListElement Value="rtf"></dx:ListElement>
<dx:ListElement Value="mht"></dx:ListElement>
<dx:ListElement Value="html"></dx:ListElement>
<dx:ListElement Value="txt"></dx:ListElement>
<dx:ListElement Value="csv"></dx:ListElement>
<dx:ListElement Value="png"></dx:ListElement>
</Elements>
</dx:ReportToolbarComboBox>
</items>
        <styles>
<LabelStyle>
<Margins MarginLeft="3px" MarginRight="3px"></Margins>
</LabelStyle>
</styles>
    </dx:ReportToolbar>
    <dx:ReportViewer id="rvTraza" runat="server">
    </dx:ReportViewer>
</asp:Content>
