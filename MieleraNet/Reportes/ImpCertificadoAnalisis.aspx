<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImpCertificadoAnalisis.aspx.cs" Inherits="MieleraNet.Reportes.ImpCertificadoAnalisis" %>

<%@ Register Assembly="DevExpress.XtraReports.v10.1.Web, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Reporte Certificado de Analisis</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <dx:reporttoolbar id="rptoolbarFQ" runat="server" reportviewer="<%# rpviewerFQ %>"
            showdefaultbuttons="False"><Items>
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
</Items>

<Styles>
<LabelStyle>
<Margins MarginLeft="3px" MarginRight="3px"></Margins>
</LabelStyle>
</Styles>
</dx:reporttoolbar>
    
    </div>
        <dx:reportviewer id="rpviewerFQ" runat="server"></dx:reportviewer>
    </form>
</body>
</html>
