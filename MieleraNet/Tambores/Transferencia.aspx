<%@ Page Language="C#" MasterPageFile="~/Mielera.Master" AutoEventWireup="true" CodeBehind="Transferencia.aspx.cs" Inherits="MieleraNet.Tambores.Transferencia" Title="Transferencia de Tambores" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHiddenField" TagPrefix="dxhf" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<%-- Empieza seccion de javascript --%>
<script type="text/javascript">
function OnRangoValidation(s, e) {
    var name = e.value;
    if (name == null)
        return;
    alert(edtTamFin.GetValue())
        e.isValid = false;
}

function edtFinalKeyDown(s,e)
{
  if (e.htmlEvent.keyCode == 13) {
    var ini = parseInt(edtTamIni.GetValue());
    var fin = parseInt(edtTamFin.GetValue());
    //alert(ini + '-----' + fin);
    if (ini > fin)
    {
        alert("El valor Inicial no puede ser mas grande que el valor final");
    }else{
        hfLista.Set("TamIni",edtTamIni.GetValue());
        hfLista.Set("TamFin",edtTamFin.GetValue());
        panelCallback.PerformCallback("GrabaTamborRango");
        edtTamIni.SetValue("");
        edtTamFin.SetValue("");
    }
    
  }
}

function ListBoxKeyDown(s,e){
 if (e.htmlEvent.keyCode == 46) {
    //hfLista.Set("ListaSelec",listboxTambores. );
    var items = listboxTambores.GetSelectedItems();
    hfLista.Set("idarea",items[0].value);
    listboxTambores.PerformCallback(items[0].text);
   
  }
}

function edtTamborKeyDown(s,e){
 if (e.htmlEvent.keyCode == 13) {
    if(SelInd.GetChecked() == true)
    {
        var tambor = edtTambor.GetValue()
        if (tambor == null)
            return;
       if (tambor.length > 0)
       {
          panelCallback.PerformCallback("GrabaTambor");
          edtTambor.SetValue("");
       }
    }
  }
}

function OnAddList(s, e) {
    if(SelInd.GetChecked() == true)
    {
        var tambor = edtTambor.GetValue()
        if (tambor == null)
            return;
       if (tambor.length > 0)
       {
          panelCallback.PerformCallback("GrabaTambor");
       }
    }
}

</script>

<dx:aspxpagecontrol id="pagecontrolTrans" runat="server" activetabindex="0"><TabPages>
<dx:TabPage Text="Alta Transferencia"><ContentCollection>
    <dx:ContentControl runat="server">
      <table cellpadding="0" cellspacing="0">
        <tr><td>
                  <dxrp:ASPxRoundPanel ID="Relacion" runat="server" GroupBoxCaptionOffsetY="-14px"
                HeaderText="Selecciona las &#225;reas" SkinID="RoundPanelGroupBox" Width="300px">
                <PanelCollection>
                    <dxp:PanelContent runat="server">
                        <table border="0" cellpadding="2">
                            <tr>
                                <td align="right"><dxe:ASPxLabel ID="lb1" runat="server" Text="Origen:">
                                </dxe:ASPxLabel>
                                    </td>
                                <td style="width: 100%">
                                    <dxe:ASPxComboBox ID="edtOrigen" runat="server" DataSourceID="dsAreas" DropDownStyle="DropDown"
                                        EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" TextField="AREA"
                                        ValueField="IDAREA" ValueType="System.Int32" Width="100%">
                                        <Items>
                                            <dxe:ListEditItem Text="Administrador" Value="1" />
                                            <dxe:ListEditItem Text="Operador" Value="2" />
                                            <dxe:ListEditItem Text="Apicultor" Value="3" />
                                        </Items>
                                    </dxe:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <dxe:ASPxLabel ID="lb5" runat="server" Text="Destino:">
                                    </dxe:ASPxLabel>
                                </td>
                                <td>
                                    <dxe:ASPxComboBox ID="edtDestino" runat="server" DataSourceID="dsAreas" DropDownStyle="DropDown"
                                        EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" TextField="AREA"
                                        ValueField="IDAREA" ValueType="System.Int32" Width="100%">
                                        <Items>
                                            <dxe:ListEditItem Text="Administrador" Value="1" />
                                            <dxe:ListEditItem Text="Operador" Value="2" />
                                            <dxe:ListEditItem Text="Apicultor" Value="3" />
                                        </Items>
                                    </dxe:ASPxComboBox>
                                </td>
                            </tr>
                        </table>
                    </dxp:PanelContent>
                </PanelCollection>
            </dxrp:ASPxRoundPanel>
            <dxrp:ASPxRoundPanel ID="ASPxRoundPanel1" runat="server" GroupBoxCaptionOffsetY="-14px"
                HeaderText="Selecci&#243;n de Tambores" SkinID="RoundPanelGroupBox" Width="300px">
                <PanelCollection>
                    <dxp:PanelContent runat="server">
                        <table border="0" cellpadding="2">
                            <tr>
                                <td align="right">
                                    <dxe:ASPxRadioButton ID="rbIndividual" runat="server" Checked="True" GroupName="TipoAlta"
                                        Text="Individual" ClientInstanceName="SelInd">
                                        <ClientSideEvents CheckedChanged="function(s, e) {
	
    if(SelInd.GetChecked() == true){
         document.getElementById(&quot;divIndividual&quot;).style.display = &quot;&quot;;
         document.getElementById(&quot;divRango&quot;).style.display = &quot;none&quot;;
    }else{
        document.getElementById(&quot;divIndividual&quot;).style.display = &quot;none&quot;;
        document.getElementById(&quot;divRango&quot;).style.display = &quot;&quot;;
    }

}" Init="function(s, e) {
	    if(SelInd.GetChecked() == true){
         document.getElementById(&quot;divIndividual&quot;).style.display = &quot;&quot;;
         document.getElementById(&quot;divRango&quot;).style.display = &quot;none&quot;;
    }else{
        document.getElementById(&quot;divIndividual&quot;).style.display = &quot;none&quot;;
        document.getElementById(&quot;divRango&quot;).style.display = &quot;&quot;;
    }
}" />
                                    </dxe:ASPxRadioButton>
                                    </td>
                                <td style="width: 100%">
                                    <dxe:ASPxRadioButton ID="rbRango" runat="server" GroupName="TipoAlta" SpriteImageUrl="~/Images/iconError.png"
                                        Text="Por Rangos">
                                    </dxe:ASPxRadioButton>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <div id="divIndividual">
                                    <table border="0" cellpadding="0">
                                             <tr>
                                                 <td><dxe:ASPxLabel ID="lb21" runat="server" Text="Num. Tambor">
                                                      </dxe:ASPxLabel>
                                                 </td>
                                                 <td><dxe:ASPxTextBox ID="edtTambor" runat="server" Width="118px" DisplayFormatString="N0" ClientInstanceName="edtTambor">
                                                     <MaskSettings Mask="999999" PromptChar=" " />
                                                     <ValidationSettings>
                                                         <RequiredField ErrorText="" />
                                                     </ValidationSettings>
                                                     <ClientSideEvents KeyDown="edtTamborKeyDown" />
                                                    </dxe:ASPxTextBox>
                                                  </td> 
                                             </tr>
                                    </table>
                                    </div>
                                     <div id="divRango">
                                         <table border="0" cellpadding="0" style="width: 100%; height: 100%">
                                             <tr>
                                                 <td colspan="2">
                                                     <dxe:ASPxLabel ID="lb22" runat="server" Text="Rango de Tambores">
                                                     </dxe:ASPxLabel>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                     <dxe:ASPxLabel ID="lb24" runat="server" Text="Inicial">
                                                     </dxe:ASPxLabel>
                                                 </td>
                                                 <td style="width: 100%">
                                                     <dxe:ASPxTextBox ID="edtTamIni" runat="server" Width="118px" DisplayFormatString="N0" ClientInstanceName="edtTamIni">
                                                         <MaskSettings Mask="999999" PromptChar=" " />
                                                     </dxe:ASPxTextBox>
                                                 </td>
                                             </tr>
                                             <tr>
                                                 <td>
                                                     <dxe:ASPxLabel ID="lb23" runat="server" Text="Final">
                                                     </dxe:ASPxLabel>
                                                 </td>
                                                 <td style="width: 100%">
                                                     <dxe:ASPxTextBox ID="edtTamFin" runat="server" Width="118px" DisplayFormatString="N0" ClientInstanceName="edtTamFin">
                                                         <MaskSettings Mask="999999" PromptChar=" " />
                                                         <ValidationSettings ErrorText="">
                                                         </ValidationSettings>
                                                         <ClientSideEvents KeyDown="edtFinalKeyDown" />
                                                     </dxe:ASPxTextBox>
                                                 </td>
                                             </tr>
                                         </table>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center">
                                    <dxe:ASPxButton ID="btnAddLista" runat="server" Text="Agregar tambor(es) a la lista" ValidationGroup="vgIndividual" AutoPostBack="False" Visible="False">
                                        <ClientSideEvents Click="OnAddList" />
                                    </dxe:ASPxButton>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table border="0" cellpadding="0">
                                        <tr>
                                            <td style="width: 100px">
                                                <dxe:ASPxLabel ID="lb25" runat="server" Text="Tambores de la Transferencia Pendiente:">
                                                </dxe:ASPxLabel>
                                                <dxe:ASPxLabel ID="lbIdTran" runat="server">
                                                </dxe:ASPxLabel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <dx:ASPxCallbackPanel ID="panelCallback" runat="server" ClientInstanceName="panelCallback"
                                                    Width="200px" OnCallback="CallbackPanel_Callback">
                                                    <PanelCollection>
                                                        <dxp:PanelContent runat="server">
                                                                                              
                                                <dxe:ASPxListBox ID="listboxTambores" runat="server" Height="200px"
                                                    Width="100px" ClientInstanceName="listboxTambores" TextField="NUM_TAMBOR" ValueField="ID" ValueType="System.Int32" DataSourceID="dsTransferencias" OnCallback="listboxTambores_Callback">
                                                    <ClientSideEvents KeyDown="ListBoxKeyDown" />
                                                </dxe:ASPxListBox>
                                                            <dxe:ASPxButton ID="btnEliminar" runat="server" Text="Eliminar Todo" AutoPostBack="False">
                                                                <ClientSideEvents Click="function(s, e) {
	
	panelCallback.PerformCallback(&quot;EliminaListaTambores&quot;);
}" />
                                                            </dxe:ASPxButton>
                                                                <dx:ASPxPopupControl id="popMB" runat="server" AllowDragging="True" ClientInstanceName="pcError"
                                                                    EnableViewState="False" HeaderText="Error" Modal="True" PopupHorizontalAlign="WindowCenter"
                                                                    PopupVerticalAlign="WindowCenter">
                                                                    <contentcollection>
<dx:PopupControlContentControl runat="server"><TABLE cellPadding=0 border=0><TBODY><TR><TD><dxe:ASPxLabel runat="server" ID="lbError" __designer:wfdid="w24"></dxe:ASPxLabel>



 </TD></TR><TR><TD align=right><BR /><dxe:ASPxButton runat="server" AutoPostBack="False" Text="Cerrar" ID="DlgBtnCerrar" __designer:wfdid="w25">
<ClientSideEvents Click="function(s, e) {   
     pcError.Hide();
     if(SelInd.GetChecked() == true)
     {
        edtTambor.SetFocus();
     }else
		edtTamIni.SetFocus();
}"></ClientSideEvents>
</dxe:ASPxButton>



 </TD></TR></TBODY></TABLE></dx:PopupControlContentControl>
</contentcollection>
                                                                </dx:ASPxPopupControl>
                                                                <dxhf:ASPxHiddenField runat="server" ClientInstanceName="hfLista" ID="hfLista">
                                                                </dxhf:ASPxHiddenField>

                                                        </dxp:PanelContent>
                                                    </PanelCollection>
                                                </dx:ASPxCallbackPanel>
                                                
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </dxp:PanelContent>
                </PanelCollection>
            </dxrp:ASPxRoundPanel>
            <table border="0" cellpadding="0" style="text-align: right">
                                <tr>
                                    <td style="width: 100%">
                                    </td>
                                    <td style="text-align: right">
                                        <dxe:ASPxButton ID="btnEnviaTran" runat="server" Text="Enviar Transferencia" OnClick="btnGrabar_Click" ValidationGroup="vsFisica">
                                        </dxe:ASPxButton>
                                    </td>
                                </tr>
                            </table>
            </td>
        <td style="WIDTH: 100%; padding-left: 10px;" valign="top">
            <dx:ASPxGridView ID="gridTransferencias" runat="server"
                DataSourceID="dsTambEnv" KeyFieldName="ID" AutoGenerateColumns="False">
                <Settings ShowTitlePanel="True" />
                <SettingsText Title="Lista de Tambores Enviados" />
                <SettingsDetail ShowDetailRow="True" />
                <Styles>
                    <TitlePanel Font-Bold="True" HorizontalAlign="Center">
                    </TitlePanel>
                </Styles>
                <Templates>
                    <DetailRow>
                        <dx:ASPxGridView ID="gridTambores" runat="server" DataSourceID="dsTambores" KeyFieldName="IDENVIO"
                    OnBeforePerformDataSelect="gridTambores_BeforePerformDataSelect">
                            <SettingsDetail IsDetailGrid="True" />
                        </dx:ASPxGridView>
                    </DetailRow>
                </Templates>
                <Columns>
                    <dx:GridViewDataHyperLinkColumn FieldName="ID" VisibleIndex="0">
                        <PropertiesHyperLinkEdit NavigateUrlFormatString="../Reportes/repTambores.aspx?idtran={0}&amp;rep=2">
                        </PropertiesHyperLinkEdit>
                    </dx:GridViewDataHyperLinkColumn>
                    <dx:GridViewDataTextColumn FieldName="ORIGEN" VisibleIndex="1">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="DESTINO" VisibleIndex="2">
                    </dx:GridViewDataTextColumn>
                    <dx:GridViewDataTextColumn FieldName="FECHA_ENVIO" VisibleIndex="3">
                    </dx:GridViewDataTextColumn>
                </Columns>
            </dx:ASPxGridView>
            &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
        </td></tr>
      </table>
    </dx:ContentControl>
</ContentCollection>
</dx:TabPage>
<dx:TabPage Text="Historial de Env&#237;os"><ContentCollection>
<dx:ContentControl runat="server">
    <dx:ASPxGridView ID="gridHistorialTran" runat="server" DataSourceID="dsHistTran" KeyFieldName="ID" AutoGenerateColumns="False">
        <SettingsDetail ShowDetailRow="True" />
        <Templates>
            <DetailRow>
                <dx:ASPxGridView ID="gridTambores" runat="server" DataSourceID="dsTambores" KeyFieldName="IDENVIO"
                    OnBeforePerformDataSelect="gridTambores_BeforePerformDataSelect">
                    <SettingsDetail IsDetailGrid="True" />
                </dx:ASPxGridView>
            </DetailRow>
        </Templates>
        <Settings ShowTitlePanel="True" />
        <SettingsText Title="Lista de Tambores Vac&#237;os Enviados" />
        <Styles>
            <TitlePanel Font-Bold="True" HorizontalAlign="Center">
            </TitlePanel>
        </Styles>
        <Columns>
            <dx:GridViewDataHyperLinkColumn FieldName="ID" VisibleIndex="0">
                <PropertiesHyperLinkEdit NavigateUrlFormatString="../Reportes/repTambores.aspx?idtran={0}&amp;rep=2">
                </PropertiesHyperLinkEdit>
            </dx:GridViewDataHyperLinkColumn>
            <dx:GridViewDataTextColumn FieldName="FECHA_ENVIO" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ORIGEN" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="DESTINO" VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="IDDELEGADO" VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="IDSUARIO" VisibleIndex="5">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="STATUS" VisibleIndex="6">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="ACTIVA" VisibleIndex="7">
            </dx:GridViewDataTextColumn>
        </Columns>
    </dx:ASPxGridView>
</dx:ContentControl>
</ContentCollection>
</dx:TabPage>
    <dx:TabPage Text="Tambores enviados en mi Ruta">
        <ContentCollection>
            <dx:ContentControl runat="server">
                <dx:ASPxGridView ID="gridRecepcion" ClientInstanceName="gridRecepcion" runat="server" AutoGenerateColumns="False" DataSourceID="dsTambRecep" KeyFieldName="NUM_TAMBOR">
                    <Columns>
                        <dx:GridViewCommandColumn ShowSelectCheckbox="True" VisibleIndex="0">
                            <HeaderTemplate>
                                 <input type="checkbox" onclick="gridRecepcion.SelectAllRowsOnPage(this.checked);" title="Select/Unselect all rows on the page" />
                            </HeaderTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataTextColumn Caption="#Tambor" FieldName="NUM_TAMBOR" VisibleIndex="1">
                            <CellStyle HorizontalAlign="Center">
                            </CellStyle>
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="idEnvio" FieldName="IDENVIO" VisibleIndex="2">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Origen" FieldName="ORIGEN" VisibleIndex="3">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn Caption="Destino" FieldName="DESTINO" VisibleIndex="4">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn FieldName="IDDESTINO" Visible="False" VisibleIndex="5">
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Settings ShowTitlePanel="True" />
                    <SettingsText Title="Tambores a Recepcionar" />
                    <Styles>
                        <TitlePanel Font-Bold="True" HorizontalAlign="Center">
                        </TitlePanel>
                    </Styles>
                    <SettingsPager PageSize="300">
                    </SettingsPager>
                </dx:ASPxGridView>
                <dxe:ASPxButton ID="btnRecep" runat="server" OnClick="btnRecep_Click" Text="Recepcionar">
                </dxe:ASPxButton>
            </dx:ContentControl>
        </ContentCollection>
    </dx:TabPage>
</TabPages>
</dx:aspxpagecontrol>
    <asp:ObjectDataSource ID="dsAreas" runat="server" SelectMethod="ObtenAreas" TypeName="MieleraNet.DAL.PerifericaDS">
    </asp:ObjectDataSource><asp:ObjectDataSource ID="dsTambEnv" runat="server" SelectMethod="ObtenTamboresEnviados" TypeName="MieleraNet.DAL.PerifericaDS">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsTransferencias" runat="server" SelectMethod="ObtenTamboresPendientes2" TypeName="MieleraNet.DAL.TransferenciasDS">
        <SelectParameters>
            <asp:SessionParameter Name="idusr" SessionField="idusr" Type="Int32" />
            <asp:SessionParameter Name="idarea" SessionField="idarea" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>    
    <br />
    <asp:ObjectDataSource ID="dsHistTran" runat="server" SelectMethod="ObtenHistorialTransferencias" TypeName="MieleraNet.DAL.TransferenciasDS">
        <SelectParameters>
            <asp:Parameter DefaultValue="0" Name="idusuario" Type="String" />
            <asp:Parameter DefaultValue="51" Name="idarea" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsTambores" runat="server" SelectMethod="ObtenTamboresPorIdTransferencia" TypeName="MieleraNet.DAL.TransferenciasDS">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="" Name="idtransferencia" SessionField="idHistTran"
                Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource><asp:ObjectDataSource ID="dsTambRecep" runat="server" SelectMethod="ObtenTamboresARecepcionar" TypeName="MieleraNet.DAL.TransferenciasDS">
        <SelectParameters>
            <asp:SessionParameter DefaultValue="usrNivel" Name="nivel" SessionField="usrNivel"
                Type="String" />
            <asp:SessionParameter DefaultValue="" Name="area" SessionField="idarea" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
</asp:Content>
