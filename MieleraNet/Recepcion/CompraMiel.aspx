<%@ Page Language="C#" MasterPageFile="~/Mielera.Master" AutoEventWireup="true" CodeBehind="CompraMiel.aspx.cs" Inherits="MieleraNet.Recepcion.CompraMiel" Title="Compra y Envio de Miel" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script type="text/javascript" language="javascript">
function ValidaKilos(s, e) {
    var name = e.value;
    if (name == null)
        return;
    if (name < 1)
        e.isValid = false;
}

function OnNameValidation(s, e) {
    var name = e.value;
    if (name == null)
        return;
    if (name.length < 2)
        e.isValid = false;
}

function DropDownHandler(s, e) {
    SynchronizeFocusedRow();
}
function GridViewInitHandler(s, e) {
    //SynchronizeFocusedRow();
}
function RowClickHandler(s, e) {
    DropDownEdit.SetKeyValue(gridApicultor.cpKeyValues[e.visibleIndex]);
    DropDownEdit.SetText(gridApicultor.cpNombreApicultor[e.visibleIndex]);
    DropDownEdit.HideDropDown();
}
function EndCallbackHandler(s, e) {
    DropDownEdit.AdjustDropDownWindow();
    /*UpdateEditBox();
    if (gridApicultor.cpError.length > 0)
        alert(gridApicultor.cpError)*/
}
function SynchronizeFocusedRow() {
    var keyValue = DropDownEdit.GetKeyValue();
    var index = -1;
    if(keyValue != null)
        index = ASPxClientUtils.ArrayIndexOf(gridApicultor.cpKeyValues, keyValue);
    gridApicultor.SetFocusedRowIndex(index);
    gridApicultor.MakeRowVisible(index);
    UpdateEditBox();
}
function UpdateEditBox() {
    var rowIndex = gridApicultor.GetFocusedRowIndex();
    var focusedEmployeeName = rowIndex == -1 ? "" : gridApicultor.cpNombreApicultor[rowIndex];
    var employeeNameInEditBox = DropDownEdit.GetText();
    if(employeeNameInEditBox != focusedEmployeeName)
        DropDownEdit.SetText(focusedEmployeeName);
}

function RowClickHandlerTambor(s, e) {
    edtTamboraLlenar.SetText(gridTamDisp.cpNumTambor[e.visibleIndex]);
    lbStk.SetText(gridTamDisp.cpStock[e.visibleIndex]);
    lbCap.SetText(gridTamDisp.cpCapacidad[e.visibleIndex]);
    edtTamboraLlenar.HideDropDown();
}

function hoy()
{
    var fechaActual = new Date();
 
    dia = fechaActual.getDate();
    mes = fechaActual.getMonth() +1;
    anno = fechaActual.getYear();
   
 
    if (dia <10) dia = "0" + dia;
    if (mes <10) mes = "0" + mes;   
 
    fechaHoy = dia + "/" + mes + "/" + anno;
    
    return fechaHoy;
}

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
    lbHora.SetText(horaImprimible);
    lbHora2.SetText(horaImprimible);
    lbFecha.SetText(hoy());
    lbFecha2.SetText(hoy());
    //document.form1.reloj.value = horaImprimible; 

    setTimeout("mueveReloj()",1000);
} 

function FormatIDApic()
{
    /*var idapic = edtIDApic.GetText()
    var parteid = idapic.substring(0,9);
    var UltimoNum = idapic.substring(7,8);
    switch(UltimoNum){
        case "1": edtIDApic.SetText(parteid+"A"); break;
        case "2": edtIDApic.SetText(parteid+"B"); break;
        case "3": edtIDApic.SetText(parteid+"C"); break;
        case "4": edtIDApic.SetText(parteid+"D"); break;
        case "5": edtIDApic.SetText(parteid+"E"); break;
        case "6": edtIDApic.SetText(parteid+"F"); break;
        case "7": edtIDApic.SetText(parteid+"G"); break;
        case "8": edtIDApic.SetText(parteid+"H"); break;
        case "9": edtIDApic.SetText(parteid+"I"); break;
    }*/
}
</script>
    <dx:ASPxPageControl ID="pagecontrolCompraMiel" runat="server" ActiveTabIndex="0">
        <TabPages>
            <dx:TabPage Text="Compra de Miel">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <table border="0" cellpadding="0">
                            <tr>
                                <td colspan="2">
                                    <table border="0" cellpadding="0" style="width: 100%">
                                        <tr>
                                            <td>
                                                Fecha:
                                                <dx:ASPxLabel ID="lbFecha2" runat="server" BackColor="White" ForeColor="#00C000" ClientInstanceName="lbFecha2">
                                                    <ClientSideEvents Init="mueveReloj" />
                                                </dx:ASPxLabel>
                                            </td>
                                            <td>
                                                Hora:&nbsp;
                                                <dx:ASPxLabel ID="lbHora" runat="server" ClientInstanceName="lbHora" BackColor="White" ForeColor="#00C000">
                                                    <ClientSideEvents Init="mueveReloj" />
                                                </dx:ASPxLabel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxLabel ID="lb5" runat="server" Text="N&#250;mero de Transferencia:">
                                    </dx:ASPxLabel>
                                    <dx:ASPxLabel ID="lbNumTran" runat="server">
                                    </dx:ASPxLabel>
                                </td>
                            </tr>
                            <tr>
                                
                                <td style="width: 100px">
                                <br />
                                    <dx:ASPxLabel ID="bl1" runat="server" Text="Apicultor:">
                                    </dx:ASPxLabel>
                                </td>
                                <td style="width: 100px">
                                <br />
                                    <dx:ASPxDropDownEdit ID="DropDownEdit" runat="server" ClientInstanceName="DropDownEdit" Width="200px" AllowUserInput="False" EnableAnimation="False">
                                        <DropDownWindowTemplate>
                                            <dx:ASPxGridView ID="gridApicultor" ClientInstanceName="gridApicultor" runat="server" AutoGenerateColumns="False" DataSourceID="dsLocenfis" KeyFieldName="IDENFI2" OnCustomJSProperties="gridApicultor_CustomJSProperties" Width="200px" OnRowInserting="GridView_RowInserting">
                                                <Columns>
                                                    <dx:GridViewCommandColumn ButtonType="Image" VisibleIndex="0">
                                                        <NewButton Visible="True">
                                                            <Image ToolTip="Nuevo" Url="~/Images/new.png">
                                                            </Image>
                                                        </NewButton>
                                                        <CancelButton Visible="True">
                                                            <Image ToolTip="Cierra el cuadro de edici&#243;n sin salvar los cambios" Url="~/Images/cancel.png">
                                                            </Image>
                                                        </CancelButton>
                                                        <UpdateButton Visible="True">
                                                            <Image ToolTip="Salva los cambios y cierra el cuadro de edici&#243;n" Url="~/Images/update.png">
                                                            </Image>
                                                        </UpdateButton>
                                                        <ClearFilterButton Text="Limpia Filtro" Visible="True">
                                                        </ClearFilterButton>
                                                        <CellStyle Wrap="False">
                                                        </CellStyle>
                                                    </dx:GridViewCommandColumn>
                                                    <dx:GridViewDataTextColumn FieldName="IDENFI2" Visible="False">
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn FieldName="NOMBRE" VisibleIndex="1">
                                                        <EditFormSettings Visible="False" />
                                                    </dx:GridViewDataTextColumn>
                                                    
                                                </Columns>
                                                <Settings ShowFilterRow="True" />
                                                <ClientSideEvents Init="GridViewInitHandler"
                                                                  RowClick="RowClickHandler"
                                                                  EndCallback="EndCallbackHandler" />
                                               
                                                <Templates>
                                                    <EditForm>
                                                        <%-- Empieza la forma de Alta de apicultor --%>
                                                        <dx:ASPxPageControl ID="pagectrlApic" runat="server" ActiveTabIndex="0" OnActiveTabChanged="pagectrlApic_ActiveTabChanged">
                                                            <TabPages>
                                                                <dx:TabPage Text="Relaciona Apicultor">
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                            <table border="0" cellpadding="0">
                                                                                <tr>
                                                                                    <td style="width: 100px">
                                                                                        <dx:ASPxLabel ID="ASPxLabel6" runat="server" Text="Apicultor:">
                                                                                        </dx:ASPxLabel>
                                                                                        &nbsp;
                                                                                    </td>
                                                                                    <td style="width: 100px">
                                                                                    <dx:ASPxComboBox id="edtEntidad" runat="server" Width="270px" ValueField="IDENFI" TextField="NOMBRE" DataSourceID="dsApicultores" ValueType="System.Int32" IncrementalFilteringMode="Contains" IncrementalFilteringDelay="2000" DropDownStyle="DropDown" CallbackPageSize="250" EnableAnimation="False" EnableCallbackMode="True" EnableClientSideAPI="True">
                                                                                        <Columns>
                                                                                            <dx:ListBoxColumn FieldName="NOMBRE" />
                                                                                            <dx:ListBoxColumn Caption="CLAVE" FieldName="IDENFI" Width="20px" />
                                                                                        </Columns>
                                                                                    </dx:ASPxComboBox>
                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:TabPage>
                                                                <dx:TabPage Text="Alta Apicultor">
                                                                    <ContentCollection>
                                                                        <dx:ContentControl runat="server">
                                                                        <dx:ASPxRoundPanel ID="GeneralesGroup" runat="server" GroupBoxCaptionOffsetY="-14px"
                                                                            HeaderText="Datos Generales" SkinID="RoundPanelGroupBox" Width="100%" HorizontalAlign="Left">
                                                                            <PanelCollection>
                                                                                <dx:PanelContent runat="server">
                                                                                    <table border="0" cellpadding="2" cellspacing="0">
                                                                                        <tr>
                                                                                            <td align="right" style="width: 150px">
                                                                                                <dx:ASPxLabel ID="ASPxLabel9" runat="server" Text="ID Apicultor:">
                                                                                                </dx:ASPxLabel>
                                                                                            </td>
                                                                                            <td style="width: 300px">
                                                                                                <dx:ASPxTextBox ID="edtIDApic" runat="server" ClientInstanceName="edtIDApic" Width="170px" MaxLength="7">
                                                                                                    <ClientSideEvents LostFocus="FormatIDApic" />
                                                                                                    <MaskSettings Mask="00-00000-a" />
                                                                                                </dx:ASPxTextBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right" style="width: 150px">
                                                                                                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Primer Nombre:">
                                                                                                </dx:ASPxLabel>
                                                                                            </td>
                                                                                            <td style="width: 300px">
                                                                                                <dx:ASPxComboBox ID="edtPrimerNom" runat="server" DataSourceID="dsNombres" DropDownStyle="DropDown"
                                                                                                    EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" TextField="NOMBRE"
                                                                                                    ValueField="NOMBRE" ValueType="System.String" Width="100%" CallbackPageSize="20" EnableCallbackMode="True" IncrementalFilteringDelay="200">
                                                                                                    <ValidationSettings SetFocusOnError="True" ErrorText="El nombre debe contener almenos dos caracteres" Display="Dynamic">
                                                                                                        <ErrorImage Height="16px" Width="16px" AlternateText="Error" Url="~/Images/iconError.png" />
                                                                                                        <RequiredField IsRequired="True" ErrorText="El nombre se obligatorio" />
                                                                                                        <ErrorFrameStyle ForeColor="Red">
                                                                                                            <Paddings Padding="3px" PaddingLeft="4px" />
                                                                                                            <BackgroundImage ImageUrl="~/Images/bgError.png" />
                                                                                                            <Border BorderColor="#FD4D3E" BorderStyle="Solid" BorderWidth="1px" />
                                                                                                            <ErrorTextPaddings PaddingRight="3px" />
                                                                                                        </ErrorFrameStyle>
                                                                                                    </ValidationSettings>
                                                                                                    <FocusedStyle>
                                                                                                        <Border BorderColor="Black" BorderStyle="Solid" BorderWidth="1px" />
                                                                                                    </FocusedStyle>
                                                                                                    <InvalidStyle BackColor="#FFF5F5">
                                                                                                        <Border BorderColor="Red" BorderStyle="Solid" BorderWidth="1px" />
                                                                                                    </InvalidStyle>
                                                                                                    <ClientSideEvents Validation="OnNameValidation" />
                                                                                                </dx:ASPxComboBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right" style="width: 150px">
                                                                                                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Segundo Nombre:">
                                                                                                </dx:ASPxLabel>
                                                                                            </td>
                                                                                            <td style="width: 300px">
                                                                                                <dx:ASPxComboBox ID="edtSegundoNom" runat="server" DataSourceID="dsNombres" DropDownStyle="DropDown"
                                                                                                    EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" TextField="NOMBRE"
                                                                                                    ValueField="NOMBRE" ValueType="System.String" Width="100%" CallbackPageSize="20" EnableCallbackMode="True" IncrementalFilteringDelay="200">
                                                                                                </dx:ASPxComboBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right" style="width: 150px">
                                                                                                <dx:ASPxLabel ID="ASPxLabel3" runat="server" Text="Primer Apellido:">
                                                                                                </dx:ASPxLabel>
                                                                                            </td>
                                                                                            <td style="width: 300px">
                                                                                                <dx:ASPxComboBox ID="edtPrimerAp" runat="server" DataSourceID="dsApellidos" DropDownStyle="DropDown"
                                                                                                    EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" TextField="APELLIDO"
                                                                                                    ValueField="IDAPELLIDO" ValueType="System.String" Width="100%" IncrementalFilteringDelay="200" CallbackPageSize="20" EnableCallbackMode="True">
                                                                                                </dx:ASPxComboBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                            <td align="right" style="width: 150px">
                                                                                                <dx:ASPxLabel ID="ASPxLabel4" runat="server" Text="Segundo Apellido:">
                                                                                                </dx:ASPxLabel>
                                                                                            </td>
                                                                                            <td style="width: 300px">
                                                                                                <dx:ASPxComboBox ID="edtSegundoAp" runat="server" DataSourceID="dsApellidos" DropDownStyle="DropDown"
                                                                                                    EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" TextField="APELLIDO"
                                                                                                    ValueField="IDAPELLIDO" ValueType="System.String" Width="100%" IncrementalFilteringDelay="200" CallbackPageSize="20" EnableCallbackMode="True">
                                                                                                </dx:ASPxComboBox>
                                                                                            </td>
                                                                                        </tr>
                                                                                        <tr>
                                                                                        <td align="right" style="width: 150px">
                                                                                            <dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="Genero:">
                                                                                            </dx:ASPxLabel>
                                                                                        </td>
                                                                                        <td style="width: 300px">
                                                                                            <dx:ASPxComboBox ID="edtGenero" runat="server" ValueType="System.Char" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" Width="100%">
                                                                                                <Items>
                                                                                                    <dx:ListEditItem Text="Femenino" Value="f" />
                                                                                                    <dx:ListEditItem Text="Masculino" Value="m" />
                                                                                                </Items>
                                                                                            </dx:ASPxComboBox>
                                                                                        </td>
                                                                                    </tr>
                                                                                    </table>
                                                                                </dx:PanelContent>
                                                                            </PanelCollection>
                                                                        </dx:ASPxRoundPanel>
                                                                        <br />
                                                                        <dx:ASPxRoundPanel id="FechaNacimiento" runat="server" Width="100%" HeaderText="Lugar y Fecha de Nacimiento" SkinID="RoundPanelGroupBox" GroupBoxCaptionOffsetY="-14px"><PanelCollection>
                                                                            <dx:PanelContent runat="server">
                                                                            <table border="0" cellpadding="2">
                                                                                <tr>
                                                                                    <td align="right" style="width: 150px">
                                                                                        <dx:ASPxLabel ID="lb6" runat="server" Text="Fecha de Nacimiento:">
                                                                                        </dx:ASPxLabel>
                                                                                    </td>
                                                                                    <td style="width: 300px">
                                                                                        <dx:ASPxDateEdit ID="edtFechaNac" runat="server" Width="100%">
                                                                                        </dx:ASPxDateEdit>
                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" style="width: 150px">
                                                                                        <dx:ASPxLabel runat="server" Text="Pais:" ID="edtPais"></dx:ASPxLabel>

                                                                                    </td>
                                                                                    <td style="width: 300px">
                                                                                        <dx:ASPxComboBox runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" ValueType="System.String" DataSourceID="dsPaises" TextField="PAIS" ValueField="IDPAIS" Width="100%" ID="edtPaisPF"></dx:ASPxComboBox>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" style="width: 150px">
                                                                                        <dx:ASPxLabel runat="server" Text="Estado:" ID="ASPxLabel7"></dx:ASPxLabel>

                                                                                    </td>
                                                                                    <td style="width: 300px">
                                                                                        <dx:ASPxComboBox runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" ValueType="System.String" DataSourceID="dsEstados" TextField="EDOPRO" ValueField="IDEDOPRO" Width="100%" ID="edtEstadoPF"></dx:ASPxComboBox>

                                                                                    </td>
                                                                                </tr>
                                                                                <tr>
                                                                                    <td align="right" style="width: 150px">
                                                                                        <dx:ASPxLabel runat="server" Text="Ciudad:" ID="lbCiudad"></dx:ASPxLabel>

                                                                                    </td>
                                                                                    <td style="width: 300px">
                                                                                        <dx:ASPxComboBox runat="server" DropDownStyle="DropDown" CallbackPageSize="20" EnableCallbackMode="True" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" ValueType="System.String" DataSourceID="dsCiudades" TextField="CIUDAD" ValueField="IDCIUD" Width="100%" ID="edtCiudadPF"></dx:ASPxComboBox>

                                                                                    </td>
                                                                                </tr>
                                                                            </table>
                                                                        </dx:PanelContent>
                                                                        </PanelCollection>
                                                                        </dx:ASPxRoundPanel>
                                                                        </dx:ContentControl>
                                                                    </ContentCollection>
                                                                </dx:TabPage>
                                                            </TabPages>
                                                        </dx:ASPxPageControl>
                                                        <%-- Termina la forma de Alta de apicultor --%>
                                                        <dx:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton" runat="server"></dx:ASPxGridViewTemplateReplacement>
                                                        <dx:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton" runat="server"></dx:ASPxGridViewTemplateReplacement>
                                                    </EditForm>
                                                </Templates>
                                                <SettingsText CommandCancel="Cancelar" CommandUpdate="Aceptar" />
                                                <SettingsBehavior AutoFilterRowInputDelay="600" />
                                            </dx:ASPxGridView>
                                        </DropDownWindowTemplate>
                                        <ClientSideEvents DropDown="DropDownHandler" />
                                        <ValidationSettings ValidationGroup="AddCompra">
                                            <RequiredField ErrorText="Seleccione un Apicultor" IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxDropDownEdit>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px"><dx:ASPxLabel ID="lb6" runat="server" Text="Tambor:">
                                </dx:ASPxLabel>
                                </td>
                                <td style="width: 100px">
                                    <dx:ASPxDropDownEdit ID="edtTamboraLlenar" ClientInstanceName="edtTamboraLlenar" runat="server" Width="200px">
                                        <DropDownWindowTemplate>
                                            <dx:ASPxGridView ID="gridTamDisp" runat="server" DataSourceID="dsTambDisp" KeyFieldName="NUM_TAMBOR" OnCustomJSProperties="gridTamDisp_CustomJSProperties" OnHtmlRowPrepared="gridTamDisp_HtmlRowPrepared" ClientInstanceName="gridTamDisp" AutoGenerateColumns="False">
                                                <ClientSideEvents RowClick="RowClickHandlerTambor" />
                                                <Columns>
                                                    <dx:GridViewDataTextColumn Caption="Tambor" FieldName="NUM_TAMBOR" UnboundType="String"
                                                        VisibleIndex="0">
                                                        <Settings AutoFilterCondition="BeginsWith" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="STK" FieldName="STK" VisibleIndex="1">
                                                        <Settings AllowHeaderFilter="True" />
                                                    </dx:GridViewDataTextColumn>
                                                    <dx:GridViewDataTextColumn Caption="CAPACIDAD" FieldName="CAPACIDAD" VisibleIndex="2">
                                                        <Settings AllowAutoFilter="False" />
                                                    </dx:GridViewDataTextColumn>
                                                </Columns>
                                                <Settings ShowFilterRow="True" />
                                                <SettingsPager PageSize="20">
                                                </SettingsPager>
                                            </dx:ASPxGridView>
                                        </DropDownWindowTemplate>
                                        <ValidationSettings ValidationGroup="AddCompra">
                                            <RequiredField ErrorText="Seleccione un tambor" IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxDropDownEdit>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                </td>
                                <td style="width: 100px">
                                    <table>
                                        <tr>
                                            <td style="width: 100px">
                                                Stock:</td>
                                            <td style="width: 100px">
                                                <dx:ASPxLabel ID="lbStk" runat="server" ClientInstanceName="lbStk">
                                                </dx:ASPxLabel>
                                            </td>
                                            <td style="width: 100px">
                                                Cap:</td>
                                            <td style="width: 100px">
                                                <dx:ASPxLabel ID="lbCap" runat="server" ClientInstanceName="lbCap">
                                                </dx:ASPxLabel>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px"><dx:ASPxLabel ID="ASPxLabel5" runat="server" Text="TipoMiel:">
                                </dx:ASPxLabel>
                                </td>
                                <td style="width: 100px">
                                    <dx:ASPxComboBox ID="edtTipoMiel" runat="server" ValueType="System.String" DataSourceID="dsTipoMiel" TextField="CONTENIDO" ValueField="IDCONTENIDO">
                                        <ValidationSettings ValidationGroup="AddCompra">
                                            <RequiredField ErrorText="Seleccione un tipo de Miel" IsRequired="True" />
                                        </ValidationSettings>
                                    </dx:ASPxComboBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px"><dx:ASPxLabel ID="lb61" runat="server" Text="Kilogramos:">
                                </dx:ASPxLabel>
                                </td>
                                <td style="width: 100px">
                                    <dx:ASPxTextBox ID="edtKilogramos" runat="server" Width="170px" ClientInstanceName="edtKilogramos">
                                        <ClientSideEvents Validation="ValidaKilos" />
                                        <ValidationSettings ValidationGroup="AddCompra">
                                            <RequiredField ErrorText="Indique la cantidad a comprar" IsRequired="True" />
                                        </ValidationSettings>
                                        <MaskSettings Mask="&lt;0..99999g&gt;.&lt;00..99&gt;" />
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 100px">
                                    <dx:ASPxLabel ID="lb8" runat="server" Text="P/Unitario:">
                                    </dx:ASPxLabel>
                                </td>
                                <td style="width: 100px">
                                    <dx:ASPxTextBox ID="edtPrecio" runat="server" Width="170px">
                                    <MaskSettings Mask="$&lt;0..99999g&gt;.&lt;00..99&gt;" IncludeLiterals="DecimalSymbol" />
                                    </dx:ASPxTextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    &nbsp;<table border="0" cellpadding="0">
                                        <tr>
                                            <td style="width: 110px">
                                                <dx:ASPxButton ID="btnAddComp" runat="server" Text="Agregar Compra" Wrap="False" OnClick="btnAddComp_Click" ValidationGroup="AddCompra">
                                                </dx:ASPxButton>
                                            </td>
                                            <td style="width: 100px">
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <dx:ASPxGridView ID="gridCompPend" runat="server" DataSourceID="dsCompraPendiente" AutoGenerateColumns="False">
                                        <SettingsText EmptyDataRow="No existe compra pendiente por aceptar" />
                                        <Columns>
                                            <dx:GridViewDataTextColumn FieldName="TAMBOR" VisibleIndex="0">
                                                <PropertiesTextEdit DisplayFormatString="n0">
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="APICULTOR" VisibleIndex="1">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="TIPO DE MIEL" FieldName="TIPOMIEL" VisibleIndex="2">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="KILOGRAMOS" VisibleIndex="3">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="P/UNITARIO" FieldName="PRECIOUNIT" VisibleIndex="4">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn FieldName="SUBTOTAL" VisibleIndex="5">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                    <MaskSettings Mask="$&lt;0..99999g&gt;.&lt;00..99&gt;" />
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                    </dx:ASPxGridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: right">
                                    <table border="0" cellpadding="0">
                                        <tr>
                                            <td>
                                    <dx:ASPxButton ID="btnAceptaCompra" runat="server" OnClick="btnAceptaCompra_Click"
                                        Text="Aceptar Compra">
                                    </dx:ASPxButton>
                                            </td>
                                            <td>
                                                <dx:ASPxButton ID="btnCancel" runat="server" Text="Cancelar" OnClick="btnCancel_Click">
                                                </dx:ASPxButton>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                <br />
                                    <dx:ASPxGridView ID="gridPendTrans" runat="server" DataSourceID="dsComprasRealizadas" AutoGenerateColumns="False" OnCustomColumnDisplayText="gridPendTrans_CustomColumnDisplayText">
                                        <Settings ShowTitlePanel="True" />
                                        <SettingsText Title="Compras Realizadas" />
                                        <Styles>
                                            <TitlePanel HorizontalAlign="Center">
                                            </TitlePanel>
                                        </Styles>
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="Apicultor" FieldName="NOMBRE" VisibleIndex="0">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Tipo/Miel" FieldName="CONTENIDO" VisibleIndex="1">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Total Kilogramos" FieldName="KG" VisibleIndex="2">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Total" FieldName="ST" VisibleIndex="3">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="No. Compra" FieldName="IDCOMPRA" VisibleIndex="4">
                                                <PropertiesTextEdit DisplayFormatString="n0">
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                    </dx:ASPxGridView>
                                </td>
                            </tr>
                        </table>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Transferencia de Miel">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                    <dx:ASPxRoundPanel id="DatosTran" runat="server" Width="100%" HeaderText="Datos de la Transferencia" SkinID="RoundPanelGroupBox" GroupBoxCaptionOffsetY="-14px"><PanelCollection>
                        <dx:PanelContent runat="server">
                            <table border="1" cellpadding="0" style="width: 100%; height: 100%">
                                <tr>
                                    <td style="width: 130px">
                                        Fecha:</td>
                                    <td>
                                        <dx:ASPxLabel ID="lbFecha" runat="server" BackColor="White" ForeColor="#00C000" ClientInstanceName="lbFecha">
                                            <ClientSideEvents Init="mueveReloj" />
                                        </dx:ASPxLabel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 130px">
                                        Hora:</td>
                                    <td><dx:ASPxLabel ID="lbHora2" runat="server" ClientInstanceName="lbHora2" BackColor="White" ForeColor="#00C000">
                                        <ClientSideEvents Init="mueveReloj" />
                                    </dx:ASPxLabel>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 130px">
                                        Transferencia Activa:</td>
                                    <td>
                                        <dx:ASPxLabel ID="lbNoTran" runat="server" Text="lbNoTran" ClientInstanceName="lbNoTran">
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
                                    <td style="width: 130px; height: 16px;">
                                        Area:</td>
                                    <td style="height: 16px">
                                        <dx:ASPxLabel ID="lbArea" runat="server" Text="lbArea">
                                        </dx:ASPxLabel>
                                    </td>
                                </tr>
                            </table>
                            <strong>
                                <br />
                                        Selecciona el area de la transferencia, luego las compras 
                            <br />
                            que se desean agregar
                                        en la transferencia :</strong><br />
                            <br />
                            <table border="1" cellpadding="0">
                                <tr>
                                    <td style="width: 130px">
                                        Area de Transferencia</td>
                                    <td style="width: 100px">
                                        <dx:ASPxComboBox ID="comboPlantas" runat="server" ValueType="System.String" DataSourceID="dsPlantas" TextField="AREA" ValueField="IDTIPDIR">
                                        </dx:ASPxComboBox>
                                    </td>
                                </tr>
                            </table>
                            &nbsp;<br />
                            <table border="0" cellpadding="0" style="width: 100%; height: 100%">
                                <tr>
                                    <td style="text-align: right"><dx:ASPxGridView ID="gridTambEnv" ClientInstanceName="gridTambEnv" runat="server" DataSourceID="dsCompRealizadasTamb" AutoGenerateColumns="False" KeyFieldName="IDTAMBOR" OnCommandButtonInitialize="gridTambEnv_CommandButtonInitialize" OnCustomColumnDisplayText="gridTambEnv_CustomColumnDisplayText" Width="500px">
                                        <SettingsText EmptyDataRow="No existe compra pendiente por aceptar" Title="Lista de Tambores con Miel a Env&#237;ar" />
                                        <Settings ShowTitlePanel="True" ShowFooter="True" ShowVerticalScrollBar="True" />
                                        <Styles>
                                            <TitlePanel HorizontalAlign="Center">
                                            </TitlePanel>
                                            <Footer Wrap="False">
                                            </Footer>
                                        </Styles>
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="Tambor" FieldName="IDTAMBOR" VisibleIndex="0" Width="60px">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Kilogramos" FieldName="KG" VisibleIndex="1">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="P/Unitario" FieldName="PRECIOUNITARIO" VisibleIndex="2">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="SubTotal" FieldName="TOT" VisibleIndex="3" Width="130px">
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
                                                     <input type="checkbox" onclick="gridTambEnv.SelectAllRowsOnPage(this.checked);" title="Select/Unselect all rows on the page" />
                                                </HeaderTemplate>
                                            </dx:GridViewCommandColumn>
                                            <dx:GridViewDataTextColumn FieldName="IDTRANS" Visible="False" VisibleIndex="6">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                        <TotalSummary>
                                            <dx:ASPxSummaryItem DisplayFormat="Total {0:c}" FieldName="TOT" SummaryType="Sum" />
                                        </TotalSummary>
                                        <SettingsPager PageSize="200">
                                            <Summary AllPagesText="Pagina: {0} - {1} ({2} registros)" Text="Pagina {0} de {1} ({2} registros)" />
                                        </SettingsPager>
                                    </dx:ASPxGridView>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="text-align: right">
                                        <table border="0" cellpadding="0">
                                            <tr>
                                                <td>
                                                    <dx:ASPxButton ID="btnReimprimir" runat="server" Text="Imprimir Etiquetas" Visible="False" AutoPostBack="False">
                                                        <ClientSideEvents Click="function(s, e) {
window.open(&quot;../Reportes/ImpMuestras.aspx?idtrans=&quot; + lbNoTran.GetText(), &quot;_blank&quot;,&quot;scrollbars=1, width=800,height=600&quot;); 
return false;	

}" />
                                                    </dx:ASPxButton>
                                                </td>
                                                <td style="height: 30px">
                                                    <dx:ASPxButton ID="btnMuestrear" runat="server" Text="Realizar Muestreo" OnClick="btnMuestrear_Click" ClientInstanceName="btnMuestrear">
                                                        <ClientSideEvents Click="function(s, e) {
	e.processOnServer = confirm('&#191;Esta seguro de realizar las Muestras de los tambores seleccionados?');

}" />
                                                    </dx:ASPxButton>
                                                </td>
                                                <td style="height: 30px">
                                                    <dx:ASPxButton ID="btnEnvTran" runat="server" Text="Enviar Transferencia" OnClick="btnEnvTran_Click">
                                                    </dx:ASPxButton>
                                                </td>
                                            </tr>
                                        </table>
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px">
                                    </td>
                                </tr>
                            </table>
                        </dx:PanelContent>
                        </PanelCollection>
                    </dx:ASPxRoundPanel>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Historial de Transferencias de Miel">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <dx:ASPxGridView ID="gridHistorialRec" runat="server" AutoGenerateColumns="False"
                            DataSourceID="dsHistTranMiel" KeyFieldName="IDTRANS" OnBeforePerformDataSelect="gridHistorialRec_BeforePerformDataSelect">
                            <Columns>
                                <dx:GridViewDataHyperLinkColumn FieldName="IDTRANS" VisibleIndex="0">
                                    <PropertiesHyperLinkEdit NavigateUrlFormatString="../Reportes/ImpTransMiel.aspx?idtran={0}"
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
                            <SettingsText Title="Transferencias de Miel" />
                            <SettingsDetail ShowDetailRow="True" />
                            <Styles>
                                <TitlePanel Font-Bold="True" HorizontalAlign="Center">
                                </TitlePanel>
                            </Styles>
                            <Templates>
                                <DetailRow>
                                    <dx:ASPxGridView ID="gridTambores" runat="server" DataSourceID="dsHistTamb" KeyFieldName="IDTAMBOR"
                                        OnBeforePerformDataSelect="gridTambores_BeforePerformDataSelect" AutoGenerateColumns="False">
                                        <SettingsDetail IsDetailGrid="True" />
                                        <Columns>
                                            <dx:GridViewDataTextColumn Caption="IdTambor" FieldName="IDTAMBOR" VisibleIndex="0">
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Kilogramos" FieldName="KILOGRAMOS" VisibleIndex="1">
                                                <PropertiesTextEdit DisplayFormatString="n">
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Subtotal" FieldName="SUBTOTAL" VisibleIndex="2">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="PUnitario" FieldName="PRECIOUNIT" VisibleIndex="3">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="Total" FieldName="TOTALTRANS" VisibleIndex="4">
                                                <PropertiesTextEdit DisplayFormatString="c">
                                                </PropertiesTextEdit>
                                            </dx:GridViewDataTextColumn>
                                            <dx:GridViewDataTextColumn Caption="idTrans" FieldName="IDTRANS" VisibleIndex="5">
                                            </dx:GridViewDataTextColumn>
                                        </Columns>
                                    </dx:ASPxGridView>
                                </DetailRow>
                            </Templates>
                        </dx:ASPxGridView>
                        &nbsp;&nbsp;
                        <asp:ObjectDataSource ID="dsHistTranMiel" runat="server" SelectMethod="ObtenHistTransferenciaMiel"
                            TypeName="MieleraNet.DAL.CompraMielDS">
                            <SelectParameters>
                                <asp:SessionParameter Name="idusuario" SessionField="idusr" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="dsHistTamb" runat="server" SelectMethod="ObtenHistTamboresTransferenciaMiel"
                            TypeName="MieleraNet.DAL.CompraMielDS">
                            <SelectParameters>
                                <asp:SessionParameter Name="idtransferencia" SessionField="idHistTranMiel" Type="String" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
        </TabPages>
    </dx:ASPxPageControl>
                                                                                    <asp:ObjectDataSource ID="dsNombres" runat="server" SelectMethod="ObtenNombresCache" TypeName="MieleraNet.DAL.CentralDS">
                                                                                    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsLocenfis" runat="server" SelectMethod="ObtenApicultoresPorDelegado"
        TypeName="MieleraNet.DAL.CentralDS">
        <SelectParameters>
            <asp:SessionParameter Name="delegado" SessionField="idusr" Type="String" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsApellidos" runat="server" SelectMethod="ObtenApellidosCache"
        TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsPaises" runat="server" SelectMethod="ObtenPais" TypeName="MieleraNet.DAL.CentralDS">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsEstados" runat="server" SelectMethod="ObtenEstados" TypeName="MieleraNet.DAL.CentralDS">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsCiudades" runat="server" SelectMethod="ObtenCiudades"
        TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource><asp:ObjectDataSource ID="dsTambDisp" runat="server" SelectMethod="ObtenTamboresDisponiblesLlenados"
        TypeName="MieleraNet.DAL.CompraMielDS">
            <SelectParameters>
                <asp:SessionParameter Name="iddelegado" SessionField="idusr" Type="Int32" />
                <asp:SessionParameter Name="idarea" SessionField="idarea" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsApicultores" runat="server" SelectMethod="ObtenLocenfis"
        TypeName="MieleraNet.DAL.PerifericaDS"></asp:ObjectDataSource><asp:ObjectDataSource ID="dsTipoMiel" runat="server" SelectMethod="ObtenTiposMiel"
        TypeName="MieleraNet.DAL.CompraMielDS"></asp:ObjectDataSource><asp:ObjectDataSource ID="dsCompraPendiente" runat="server" SelectMethod="ObtenTamboresCompraPendienteAceptar"
        TypeName="MieleraNet.DAL.CompraMielDS">
            <SelectParameters>
                <asp:SessionParameter Name="idusuario" SessionField="idusr" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource><asp:ObjectDataSource ID="dsComprasRealizadas" runat="server" SelectMethod="ObtenComprasRealizadas"
        TypeName="MieleraNet.DAL.CompraMielDS">
            <SelectParameters>
                <asp:SessionParameter Name="idusuario" SessionField="idusr" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource><asp:ObjectDataSource ID="dsCompRealizadasTamb" runat="server" SelectMethod="ComprasRealizadasAgrupadasPorTamborPorTransferir"
        TypeName="MieleraNet.DAL.CompraMielDS">
            <SelectParameters>
                <asp:SessionParameter Name="idusuario" SessionField="idusr" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsPlantas" runat="server" SelectMethod="ObtenPlantasFiltrado"
        TypeName="MieleraNet.DAL.CompraMielDS">
        <SelectParameters>
            <asp:SessionParameter Name="idArea" SessionField="idarea" Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <dx:ASPxPopupControl ID="popMB" runat="server" AllowDragging="True" ClientInstanceName="pcError"
        EnableViewState="False" HeaderText="Error" Modal="True" PopupHorizontalAlign="WindowCenter"
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
