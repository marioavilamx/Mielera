<%@ Page Language="C#" MasterPageFile="~/Mielera.Master" AutoEventWireup="true" CodeBehind="SagarpaEnt.aspx.cs" Inherits="MieleraNet.Reportes.SagarpaEnt" Title="Reportes de Trazabilidad" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.XtraReports.v13.2.Web, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.XtraReports.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
    <%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0">
        <TabPages>
            <dx:TabPage Text="Trazabilidad de Entrada">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <dxrp:ASPxRoundPanel ID="RelacionEnt" runat="server" GroupBoxCaptionOffsetY="-14px"
                        HeaderText="Genarar Reporte" SkinID="RoundPanelGroupBox" Width="100%">
                        <PanelCollection>
                            <dx:PanelContent runat="server">
                                <table border="0" cellpadding="2">
                                    <tr>
                                        <td align="right" style="width: 150px">
                                        </td>
                                        <td style="width: 300px">
                                            <dx:ASPxCheckBox ID="chkNombre" runat="server" Text="Nombre Visible" ClientInstanceName="chkNombre">
                                            </dx:ASPxCheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 150px">
                                            <dx:ASPxLabel ID="lb1" runat="server" Text="A&#241;o:">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dx:ASPxComboBox ID="cmbAnio" runat="server" DataSourceID="dsAnios" TextField="MIFECHA"
                                                ValueField="MIFECHA" ValueType="System.String" AutoPostBack="True" ClientInstanceName="cmbAnio" OnSelectedIndexChanged="cmbAnio_SelectedIndexChanged">
                                            </dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 150px">
                                            <dx:ASPxLabel ID="lb2" runat="server" Text="Lote:">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dx:ASPxComboBox ID="cmbLotes" runat="server" DataSourceID="dsLotes" TextField="NUMPROD"
                                                ValueField="IDPROD" ValueType="System.String" AutoPostBack="True" OnSelectedIndexChanged="cmbLotes_SelectedIndexChanged" ClientInstanceName="cmbLotes">
                                            </dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 150px">
                                        </td>
                                        <td style="width: 300px">
                                            &nbsp;<table border="0" cellpadding="0">
                                                <tr>
                                                    <td style="width: 100px">
                                                        <dx:ASPxButton ID="btnGenEntrada" runat="server" Text="Genera Entrada" Enabled="False">
                                                            <clientsideevents click="function(s, e) {
	window.open(&quot;../Reportes/ImpSagarpaTrazEnt.aspx?idProd=&quot; + cmbLotes.GetValue() +&quot;&amp;bNom=&quot;+ chkNombre.GetChecked()+&quot;&amp;bSalida=true&quot; , &quot;_blank&quot;,&quot;scrollbars=1, width=800,height=600&quot;); 
return false;
}"></clientsideevents>
                                                        </dx:ASPxButton>
                                                    </td>
                                                    <td style="width: 100px">
                                                        <dx:ASPxButton ID="btnGenEntradaIntegradora" runat="server" Text="Genera Entrada Integradora" Enabled="False" Width="124px">
                                                            <clientsideevents click="function(s, e) {
	window.open(&quot;../Reportes/ImpSagarpaTrazEnt.aspx?idProd=&quot; + cmbLotes.GetValue() +&quot;&amp;bNom=&quot;+ chkNombre.GetChecked()+&quot;&amp;bSalida=false&quot; , &quot;_blank&quot;,&quot;scrollbars=1, width=800,height=600&quot;); 
return false;
}"></clientsideevents>
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </table>
                            <asp:ObjectDataSource ID="dsLotes" runat="server" SelectMethod="ObtenLoteHist" TypeName="MieleraNet.DAL.PerifericaDS" OldValuesParameterFormatString="original_{0}">
                            <SelectParameters>
                                <asp:ControlParameter ControlID="cmbAnio" Name="mifecha" PropertyName="Value" Type="Int16" />
                            </SelectParameters>
                        </asp:ObjectDataSource>&nbsp;&nbsp;
                            </dx:PanelContent>
                        </PanelCollection>
                    </dxrp:ASPxRoundPanel>
                        <asp:ObjectDataSource ID="dsAnios" runat="server" SelectMethod="ObtenAniosHist" TypeName="MieleraNet.DAL.PerifericaDS">
                        </asp:ObjectDataSource>
                        &nbsp; &nbsp;
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Trazabilidad de Salida">
                <ContentCollection>
                    <dx:ContentControl runat="server"><dxrp:ASPxRoundPanel ID="Relacion" runat="server" GroupBoxCaptionOffsetY="-14px"
                        HeaderText="Genarar Reporte" SkinID="RoundPanelGroupBox" Width="100%">
                        <PanelCollection>
                            <dx:PanelContent runat="server">
                                <table border="0" cellpadding="2">
                                    <tr>
                                        <td align="right" style="width: 100px">
                                        </td>
                                        <td style="width: 300px">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            <dx:ASPxLabel ID="ASPxLabel13" runat="server" Text="A&#241;o:">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dx:ASPxComboBox ID="cmbAnioSal" runat="server" DataSourceID="dsAniosSal" TextField="MIFECHA"
                                                ValueField="MIFECHA" ValueType="System.String" AutoPostBack="True" ClientInstanceName="cmbAnio" OnSelectedIndexChanged="cmbAnioSal_SelectedIndexChanged">
                                            </dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            <dx:ASPxLabel ID="ASPxLabel14" runat="server" Text="Lote:">
                                            </dx:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dx:ASPxComboBox ID="cmbLotesSal" runat="server" DataSourceID="dsLotesSal" TextField="NUMPROD"
                                                ValueField="IDPROD" ValueType="System.String" AutoPostBack="True" OnSelectedIndexChanged="cmbLotesSal_SelectedIndexChanged" ClientInstanceName="cmbLotesSal">
                                            </dx:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            Fecha Salida:</td>
                                        <td style="width: 300px">
                                            <dx:ASPxDateEdit ID="edtFecha" runat="server" ClientInstanceName="edtFecha">
                                            </dx:ASPxDateEdit>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            Exportacion Kg:</td>
                                        <td style="width: 300px">
                                            <dx:ASPxTextBox ID="edtKilogramos" runat="server" ClientInstanceName="edtKilogramos"
                                                Width="170px">
                                                <masksettings mask="&lt;0..99999g&gt;.&lt;00..99&gt;"></masksettings>
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px">
                                            Destino:</td>
                                        <td style="width: 300px">
                                            <dx:ASPxTextBox ID="edtDestino" runat="server" ClientInstanceName="edtDestino" Width="170px">
                                            </dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px">
                                        </td>
                                        <td style="width: 300px">
                                            &nbsp;<table border="0" cellpadding="0">
                                                <tr>
                                                    <td style="width: 100px">
                                                        <dx:ASPxButton ID="btnGenSalida" runat="server" Text="Genera Salida" Enabled="False">
                                                            <clientsideevents click="function(s, e) {
	window.open(&quot;../Reportes/ImpSagarpaTrazSal.aspx?fSalida=&quot; + edtFecha.GetDate().getDate()+'/'+ (edtFecha.GetDate().getMonth()+1)+'/'+edtFecha.GetDate().getFullYear()+&quot;&amp;kg=&quot; +edtKilogramos.GetValue()+&quot;&amp;idProd=&quot; + cmbLotesSal.GetValue() +&quot;&amp;bNom=&quot;+ chkNombre.GetChecked()+&quot;&amp;bSalida=true&quot; , &quot;_blank&quot;,&quot;scrollbars=1, width=1000,height=700&quot;); 
return false;
}"></clientsideevents>
                                                        </dx:ASPxButton>
                                                    </td>
                                                    <td style="width: 100px">
                                                        <dx:ASPxButton ID="btnSalidaConcentrado" runat="server" Text="Genera Salida Integradora" Enabled="False" Width="138px">
                                                            <clientsideevents click="function(s, e) {
                                                
	window.open(&quot;../Reportes/ImpSagarpaTrazSal.aspx?fSalida=&quot; + edtFecha.GetDate().getDate()+'/'+ (edtFecha.GetDate().getMonth()+1)+'/'+edtFecha.GetDate().getFullYear()+&quot;&amp;kg=&quot; +edtKilogramos.GetValue()+&quot;&amp;idProd=&quot; + cmbLotesSal.GetValue() +&quot;&amp;bNom=&quot;+ chkNombre.GetChecked()+&quot;&amp;bSalida=false&amp;Dest=&quot; + edtDestino.GetValue() , &quot;_blank&quot;,&quot;scrollbars=1, width=1000,height=700&quot;); 
return false;
}"></clientsideevents>
                                                        </dx:ASPxButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 100px">
                                        </td>
                                        <td style="width: 300px">
                                        </td>
                                    </tr>
                                </table>
                                <asp:ObjectDataSource ID="dsLotesSal" runat="server" SelectMethod="ObtenLoteHist" TypeName="MieleraNet.DAL.PerifericaDS" OldValuesParameterFormatString="original_{0}">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="cmbAnioSal" Name="mifecha" PropertyName="Value" Type="Int16" />
                                    </SelectParameters>
                                </asp:ObjectDataSource><asp:ObjectDataSource ID="dsAniosSal" runat="server" SelectMethod="ObtenAniosHist" TypeName="MieleraNet.DAL.PerifericaDS">
                                </asp:ObjectDataSource>&nbsp;&nbsp;
                            </dx:PanelContent>
                        </PanelCollection>
                        </dxrp:ASPxRoundPanel>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
        </TabPages>
    </dx:ASPxPageControl>
    &nbsp; &nbsp; &nbsp;
</asp:Content>
