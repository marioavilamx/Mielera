<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImpCortesxFecha.aspx.cs" Inherits="MieleraNet.Reportes.ImpCortesxFecha" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.XtraReports.v14.2.Web, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>
            <table border="0" cellpadding="0">
                <tr>
                    <td style="width: 100px; text-align: right">
                        De:</td>
                    <td style="width: 100px">
                        <dx:ASPxDateEdit ID="edtFechaIni" runat="server">
                        </dx:ASPxDateEdit>
                    </td>
                    <td style="width: 100px; text-align: right">
                        Al:</td>
                    <td style="width: 100px">
                        <dx:ASPxDateEdit ID="edtFechaFin" runat="server">
                        </dx:ASPxDateEdit>
                    </td>
                    <td style="width: 100px; text-align: right">
                        <dx:ASPxButton ID="btnGenRep" runat="server" OnClick="btnGenRep_Click" Text="Generar">
                        </dx:ASPxButton>
                    </td>
                    <td style="width: 100px; text-align: right">
                        <asp:HyperLink ID="linkRegresar" runat="server" NavigateUrl="~/Index.aspx">Regresar</asp:HyperLink></td>
                </tr>
            </table>
            <dx:ReportToolbar ID="ReportToolbar1" runat="server" ReportViewer="<%# ReportViewer1 %>"
                ShowDefaultButtons="False">
                <Items>
                    <dx:ReportToolbarButton ItemKind='Search' />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton ItemKind='PrintReport' />
                    <dx:ReportToolbarButton ItemKind='PrintPage' />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton Enabled='False' ItemKind='FirstPage' />
                    <dx:ReportToolbarButton Enabled='False' ItemKind='PreviousPage' />
                    <dx:ReportToolbarLabel ItemKind='PageLabel' />
                    <dx:ReportToolbarComboBox ItemKind='PageNumber' Width='65px'>
                    </dx:ReportToolbarComboBox>
                    <dx:ReportToolbarLabel ItemKind='OfLabel' />
                    <dx:ReportToolbarTextBox IsReadOnly='True' ItemKind='PageCount' />
                    <dx:ReportToolbarButton ItemKind='NextPage' />
                    <dx:ReportToolbarButton ItemKind='LastPage' />
                    <dx:ReportToolbarSeparator />
                    <dx:ReportToolbarButton ItemKind='SaveToDisk' />
                    <dx:ReportToolbarButton ItemKind='SaveToWindow' />
                    <dx:ReportToolbarComboBox ItemKind='SaveFormat' Width='70px'>
                        <Elements>
                            <dx:ListElement Value='pdf' />
                            <dx:ListElement Value='xls' />
                            <dx:ListElement Value='xlsx' />
                            <dx:ListElement Value='rtf' />
                            <dx:ListElement Value='mht' />
                            <dx:ListElement Value='html' />
                            <dx:ListElement Value='txt' />
                            <dx:ListElement Value='csv' />
                            <dx:ListElement Value='png' />
                        </Elements>
                    </dx:ReportToolbarComboBox>
                </Items>
                <Styles>
                    <LabelStyle>
                        <Margins MarginLeft='3px' MarginRight='3px' />
                    </LabelStyle>
                </Styles>
            </dx:ReportToolbar>
            <dx:ReportViewer ID="ReportViewer1" runat="server">
            </dx:ReportViewer>
        </div>
    
    </div>
    </form>
</body>
</html>
