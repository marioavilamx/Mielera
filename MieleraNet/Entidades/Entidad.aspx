<%@ Page Language="C#" MasterPageFile="~/Mielera.Master" AutoEventWireup="true" CodeBehind="Entidad.aspx.cs" Inherits="MieleraNet.Entidades.Entidad" Title="Mielera - Entidades" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dxtc" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxClasses" tagprefix="dxw" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%-- EndRegion --%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<!-- 
<style type="text/css">
        .errorsList {
            background-image: url(../Images/bgError.png);
            border: solid red 1px;
            margin:20px;
            color:red;
            padding:10px;
        }
</style> 
-->
<%-- Empieza seccion de javascript --%>
<script type="text/javascript">
function OnNameValidation(s, e) {
    var name = e.value;
    if (name == null)
        return;
    if (name.length < 2)
        e.isValid = false;
}
function ShowHideVS(s, e) {
    if (e.visible)
        document.getElementById("errorsContainer").style.display = "block";
    else
        document.getElementById("errorsContainer").style.display = "none";
}
</script>
<%-- Termina seccion de javascript --%>
    <table border="0" cellpadding="0">
        <tr>
            <td style="width: 100px">

    <asp:MultiView ID="mvEntidades" runat="server" ActiveViewIndex="0" EnableTheming="True">
     <asp:View runat="server" ID="vEntidad">
<dxtc:ASPxPageControl ID="pagecontrolEntidades" runat="server" ActiveTabIndex="0" TabAlign="Justify" TabPosition="Top" EnableCallBacks="True" EnableHierarchyRecreation="True">
    <TabPages>
        <dxtc:TabPage Text="Persona Fisica">
            <ContentCollection>
                <dxw:ContentControl runat="server">
                <div id="Div1" runat="server" style="width: 450px; height: 720px">
                    <dxrp:ASPxRoundPanel ID="GeneralesGroup" runat="server" GroupBoxCaptionOffsetY="-14px"
                        HeaderText="Datos Generales" SkinID="RoundPanelGroupBox" Width="100%" HorizontalAlign="Left">
                        <PanelCollection>
                            <dxp:PanelContent runat="server">
                                <table border="0" cellpadding="2" cellspacing="0">
                                    <tr>
                                        <td align="right" style="width: 150px">
                                            <dxe:ASPxLabel ID="ASPxLabel1" runat="server" Text="Primer Nombre:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dxe:ASPxComboBox ID="edtPrimerNom" runat="server" DataSourceID="dsNombres" DropDownStyle="DropDown"
                                                EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" TextField="NOMBRE"
                                                ValueField="NOMBRE" ValueType="System.String" Width="100%" CallbackPageSize="20" EnableCallbackMode="True" IncrementalFilteringDelay="200">
                                                <ValidationSettings SetFocusOnError="True" ErrorText="El nombre debe contener almenos dos caracteres" Display="Dynamic" ValidationGroup="vsFisica">
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
                                            </dxe:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 150px">
                                            <dxe:ASPxLabel ID="ASPxLabel2" runat="server" Text="Segundo Nombre:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dxe:ASPxComboBox ID="edtSegundoNom" runat="server" DataSourceID="dsNombres" DropDownStyle="DropDown"
                                                EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" TextField="NOMBRE"
                                                ValueField="NOMBRE" ValueType="System.String" Width="100%" CallbackPageSize="20" EnableCallbackMode="True" IncrementalFilteringDelay="200">
                                            </dxe:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 150px">
                                            <dxe:ASPxLabel ID="ASPxLabel3" runat="server" Text="Primer Apellido:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dxe:ASPxComboBox ID="edtPrimerAp" runat="server" DataSourceID="dsApellidos" DropDownStyle="DropDown"
                                                EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" TextField="APELLIDO"
                                                ValueField="IDAPELLIDO" ValueType="System.String" Width="100%" IncrementalFilteringDelay="200" CallbackPageSize="20" EnableCallbackMode="True">
                                            </dxe:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 150px">
                                            <dxe:ASPxLabel ID="ASPxLabel4" runat="server" Text="Segundo Apellido:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dxe:ASPxComboBox ID="edtSegundoAp" runat="server" DataSourceID="dsApellidos" DropDownStyle="DropDown"
                                                EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" TextField="APELLIDO"
                                                ValueField="IDAPELLIDO" ValueType="System.String" Width="100%" IncrementalFilteringDelay="200" CallbackPageSize="20" EnableCallbackMode="True">
                                            </dxe:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 150px">
                                            <dxe:ASPxLabel ID="ASPxLabel5" runat="server" Text="Genero:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dxe:ASPxComboBox ID="edtGenero" runat="server" ValueType="System.Char" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" Width="100%">
                                                <Items>
                                                    <dxe:ListEditItem Text="Femenino" Value="f" />
                                                    <dxe:ListEditItem Text="Masculino" Value="m" />
                                                </Items>
                                            </dxe:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 150px">
                                        </td>
                                        <td style="width: 300px">
                                        </td>
                                    </tr>
                                </table>
                            </dxp:PanelContent>
                        </PanelCollection>
                    </dxrp:ASPxRoundPanel>
                    <br />
                    <dxrp:ASPxRoundPanel ID="FechaNacimiento" runat="server" GroupBoxCaptionOffsetY="-14px"
                        HeaderText="Lugar y Fecha de Nacimiento" SkinID="RoundPanelGroupBox" Width="100%">
                        <PanelCollection>
                            <dxp:PanelContent runat="server">
                                <table border="0" cellpadding="2">
                                    <tr>
                                        <td align="right" style="width: 150px">
                                            <dxe:ASPxLabel ID="ASPxLabel6" runat="server" Text="Fecha de Nacimiento:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dxe:ASPxDateEdit ID="edtFechaNac" runat="server" Width="100%">
                                            </dxe:ASPxDateEdit>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 150px">
                                            <dxe:ASPxLabel ID="edtPais" runat="server" Text="Pais:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dxe:ASPxComboBox ID="edtPaisPF" runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True"
                                                IncrementalFilteringMode="StartsWith" TextField="PAIS" ValueField="IDPAIS"
                                                ValueType="System.String" Width="100%" DataSourceID="dsPaises">
                                            </dxe:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 150px">
                                            <dxe:ASPxLabel ID="ASPxLabel7" runat="server" Text="Estado:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dxe:ASPxComboBox ID="edtEstadoPF" runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True"
                                                IncrementalFilteringMode="StartsWith" TextField="EDOPRO" ValueField="IDEDOPRO"
                                                ValueType="System.String" Width="100%" DataSourceID="dsEstados">
                                            </dxe:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 150px">
                                            <dxe:ASPxLabel ID="lbCiudad" runat="server" Text="Ciudad:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dxe:ASPxComboBox ID="edtCiudadPF" runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True"
                                                IncrementalFilteringMode="StartsWith" TextField="CIUDAD" ValueField="IDCIUD"
                                                ValueType="System.String" Width="100%" DataSourceID="dsCiudades" CallbackPageSize="20" EnableCallbackMode="True">
                                            </dxe:ASPxComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </dxp:PanelContent>
                        </PanelCollection>
                    </dxrp:ASPxRoundPanel>
                    <br />
                    <dxrp:ASPxRoundPanel ID="Relacion" runat="server" GroupBoxCaptionOffsetY="-14px"
                        HeaderText="Relacionar Entidad" SkinID="RoundPanelGroupBox" Width="100%">
                        <PanelCollection>
                            <dxp:PanelContent runat="server">
                                <table border="0" cellpadding="2">
                                    <tr>
                                        <td align="right" style="width: 150px">
                                            <dxe:ASPxLabel ID="ASPxLabel13" runat="server" Text="Relaci&#243;n:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dxe:ASPxComboBox ID="edtRelacionesPF" runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True"
                                                IncrementalFilteringMode="StartsWith" TextField="RELAC" ValueField="IDRELAC"
                                                ValueType="System.Int32" Width="100%" DataSourceID="dsRelaciones">
                                            </dxe:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 150px">
                                            <dxe:ASPxLabel ID="ASPxLabel14" runat="server" Text="Con:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dxe:ASPxComboBox ID="edtConPF" runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True"
                                                IncrementalFilteringMode="StartsWith" TextField="NOMBRE" ValueField="IDENFI"
                                                ValueType="System.Int32" Width="100%" DataSourceID="dsCentrosAcopio" EnableCallbackMode="True" IncrementalFilteringDelay="200" CallbackPageSize="20">
                                            </dxe:ASPxComboBox>
                                        </td>
                                    </tr>
                                </table>
                            </dxp:PanelContent>
                        </PanelCollection>
                    </dxrp:ASPxRoundPanel>
                    <br />
                    <dxrp:ASPxRoundPanel ID="DatosOpc" runat="server" GroupBoxCaptionOffsetY="-14px"
                        HeaderText="Datos Opcionales" SkinID="RoundPanelGroupBox" Width="100%">
                        <PanelCollection>
                            <dxp:PanelContent runat="server">
                                <table border="0" cellpadding="2">
                                    <tr>
                                        <td align="right" style="width: 150px;">
                                            <dxe:ASPxLabel ID="ASPxLabel8" runat="server" Text="Tel&#233;fono:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td style="width: 300px;">
                                            <dxe:ASPxTextBox ID="edtTelefono" runat="server" Width="100%">
                                             <MaskSettings Mask="(999) 999-9999" IncludeLiterals="None" />
                                            </dxe:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 150px">
                                            <dxe:ASPxLabel ID="ASPxLabel9" runat="server" Text="E-Mail:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                        <dxe:ASPxTextBox ID="edtEmail" runat="server" Width="100%">
                                             <ValidationSettings SetFocusOnError="True">
                                                    <RegularExpression ErrorText="E-mail Invalido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                                                    </RegularExpression>
                                                    <ErrorImage Height="16px" Width="16px" AlternateText="Error:" Url="~/Images/iconError.png">
                                                    </ErrorImage>
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
                                            </dxe:ASPxTextBox>
                                        
                                            </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 150px">
                                            <dxe:ASPxLabel ID="ASPxLabel10" runat="server" Text="Ocupaci&#243;n:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dxe:ASPxComboBox ID="edtOcup" runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True"
                                                IncrementalFilteringMode="StartsWith" TextField="OCUP" ValueField="IDOCUP"
                                                ValueType="System.String" Width="100%" DataSourceID="dsOcupaciones">
                                            </dxe:ASPxComboBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" style="width: 150px">
                                            <dxe:ASPxLabel ID="ASPxLabel11" runat="server" Text="Observaci&#243;n:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dxe:ASPxMemo ID="edtObs" runat="server" Height="71px" Width="100%">
                                            </dxe:ASPxMemo>
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
                                <dxe:ASPxButton ID="btnGrabar" runat="server" Text="Grabar" OnClick="btnGrabar_Click" ValidationGroup="vsFisica">
                                </dxe:ASPxButton>
                            </td>
                        </tr>
                    </table>
                    </div>
        
        <%-- Comienza La pestaa de la PERSONA MORAL --%>
                </dxw:ContentControl>
            </ContentCollection>
        </dxtc:TabPage>
        <dxtc:TabPage Text="Persona Moral">
            <ContentCollection>
                <dxw:ContentControl runat="server">
                <div id="Div2" runat="server" style="width: 400px; height: 390px">
                   <dxrp:ASPxRoundPanel ID="Legales" runat="server" GroupBoxCaptionOffsetY="-14px"
                        HeaderText="Datos Segun en registros legales" SkinID="RoundPanelGroupBox" Width="100%">
                    <PanelCollection>
                        <dxp:PanelContent runat="server">
                            <table border="0" cellpadding="2">
                                <tr>
                                    <td align="right" style="width: 150px">
                                        <dxe:ASPxLabel ID="lbRS" runat="server" Text="Nombre de la Empresa:">
                                        </dxe:ASPxLabel>
                                    </td>
                                    <td style="width: 300px">
                                        <dxe:ASPxComboBox ID="edtCorpo" runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True"
                                                IncrementalFilteringMode="StartsWith" TextField="CORP" ValueField="IDCORP"
                                                ValueType="System.Int32" Width="100%" DataSourceID="dsCorps" EnableCallbackMode="True" IncrementalFilteringDelay="200" CallbackPageSize="20">
                                        </dxe:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 150px">
                                        <dxe:ASPxLabel ID="lbSufijo" runat="server" Text="Terminaci&#243;n Legal:">
                                        </dxe:ASPxLabel>
                                    </td>
                                    <td style="width: 300px">
                                        <dxe:ASPxComboBox ID="edtTermLeg" runat="server" ValueType="System.String" DataSourceID="dsTermLeg" EnableIncrementalFiltering="True" IncrementalFilteringDelay="200" IncrementalFilteringMode="StartsWith" TextField="SUFI" ValueField="IDSUFI" Width="100%">
                                        </dxe:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 150px">
                                       <dxe:ASPxLabel ID="lbFechaReg" runat="server" Text="Fecha de Registro:">
                                        </dxe:ASPxLabel>
                                    </td>
                                    <td style="width: 300px">
                                      <dxe:ASPxDateEdit ID="edtFechaPM" runat="server" Width="100%">
                                            </dxe:ASPxDateEdit>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 150px">
                                        <dxe:ASPxLabel ID="lbPaisReg" runat="server" Text="Pa&#237;s de Registro:">
                                        </dxe:ASPxLabel>
                                    </td>
                                    <td style="width: 300px">
                                        <dxe:ASPxComboBox ID="edtPaisReg" runat="server" ValueType="System.String" DataSourceID="dsPaises" EnableIncrementalFiltering="True" IncrementalFilteringDelay="200" IncrementalFilteringMode="StartsWith" TextField="PAIS" ValueField="IDPAIS" Width="100%">
                                        </dxe:ASPxComboBox>
                                       
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 150px">
                                        <dxe:ASPxLabel ID="lbEstado" runat="server" Text="Estado:">
                                        </dxe:ASPxLabel>
                                    </td>
                                    <td style="width: 300px">
                                        <dxe:ASPxComboBox ID="edtEstadoReg" runat="server" ValueType="System.String" DataSourceID="dsEstados" EnableIncrementalFiltering="True" IncrementalFilteringDelay="200" IncrementalFilteringMode="StartsWith" TextField="EDOPRO" ValueField="IDEDOPRO" Width="100%">
                                        </dxe:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 150px">
                                        <dxe:ASPxLabel ID="lbCiudadReg" runat="server" Text="Ciudad:">
                                        </dxe:ASPxLabel>
                                    </td>
                                    <td style="width: 300px">
                                        <dxe:ASPxComboBox ID="edtCiudadReg" runat="server" ValueType="System.String" DataSourceID="dsCiudades" EnableIncrementalFiltering="True" IncrementalFilteringDelay="200" IncrementalFilteringMode="StartsWith" TextField="CIUDAD" ValueField="IDCIUD" CallbackPageSize="20" EnableCallbackMode="True" Width="100%">
                                        </dxe:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 150px">
                                        <dxe:ASPxLabel ID="lb12" runat="server" Text="RFC:">
                                        </dxe:ASPxLabel>
                                    </td>
                                    <td style="width: 300px">
                                        <dxe:ASPxComboBox ID="edtRFC" runat="server" ValueType="System.String" Width="100%">
                                        </dxe:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" style="width: 150px">
                                        <dxe:ASPxLabel ID="lb13" runat="server" Text="Giro:">
                                        </dxe:ASPxLabel>
                                    </td>
                                    <td style="width: 300px">
                                        <dxe:ASPxComboBox ID="edtGiro" runat="server" ValueType="System.String" DataSourceID="dsGiros" EnableIncrementalFiltering="True" IncrementalFilteringDelay="200" IncrementalFilteringMode="StartsWith" TextField="GIRO" ValueField="IDGIRO" Width="100%">
                                        </dxe:ASPxComboBox>
                                    </td>
                                </tr>
                                <tr>
                                        <td align="right" style="width: 150px">
                                            <dxe:ASPxLabel ID="lb14" runat="server" Text="Observaci&#243;n:">
                                            </dxe:ASPxLabel>
                                        </td>
                                        <td style="width: 300px">
                                            <dxe:ASPxMemo ID="edtObservacionPM" runat="server" Height="71px" Width="100%">
                                            </dxe:ASPxMemo>
                                        </td>
                                    </tr>
                            </table>
                        </dxp:PanelContent>
                    </PanelCollection>
                </dxrp:ASPxRoundPanel>
                <table border="0" cellpadding="0">
                        <tr>
                            <td style="width: 100%">
                            </td>
                            <td>
                                <dxe:ASPxButton ID="btnGrabaPM" runat="server" Text="Grabar" OnClick="btnGrabaPM_Click">
                                </dxe:ASPxButton>
                            </td>
                        </tr>
                    </table>                
                </div>
                </dxw:ContentControl>
            </ContentCollection>
        </dxtc:TabPage>
        
    </TabPages>
    <TabStyle Width="100px">
    </TabStyle>
</dxtc:ASPxPageControl>
</asp:View>
<%-- Comienza la vista de la alta de direccion --%>
<asp:View runat="server" ID="vDireccion">
<dxtc:ASPxPageControl ID="pagecontrolDir" runat="server" ActiveTabIndex="0" TabAlign="Justify" TabPosition="Top" EnableCallBacks="True" EnableHierarchyRecreation="True">
    <TabPages>
        <dxtc:TabPage Text="Alta de Direcciones">
            <ContentCollection>
                <dxw:ContentControl runat="server">
                <div id="Div3" runat="server" style="width: 400px; height: 500px">

    <table border="0" cellpadding="0">
        <tr>
            <td>
                <dxe:ASPxLabel ID="lbDirecEnt" runat="server" Text="La Direcci&#243;n corresponde a:">
                </dxe:ASPxLabel>
            </td>
            <td style="width: 100px">
                <dxe:ASPxComboBox ID="edtEntidad" runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True"
                                                IncrementalFilteringMode="StartsWith" TextField="NOMBRE" ValueField="IDENFI"
                                                ValueType="System.Int32" Width="200px" DataSourceID="dsCentrosAcopio" EnableCallbackMode="True" IncrementalFilteringDelay="200">
                </dxe:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td>
            <br />
            </td>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <dxe:ASPxLabel ID="lbTipoRel" runat="server" Text="Relaci&#243;n o Tipo de direcci&#243;n">
                </dxe:ASPxLabel>
            </td>
            <td style="width: 100px">
                <dxe:ASPxComboBox ID="edtTipDir" runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True"
                                                IncrementalFilteringMode="StartsWith" TextField="TIPDIR" ValueField="IDTIPDIR"
                                                ValueType="System.String" Width="100%" CallbackPageSize="20" DataSourceID="dsTipodir" EnableCallbackMode="True" IncrementalFilteringDelay="200">
                </dxe:ASPxComboBox>
            </td>
        </tr>
    </table>
    <br />
    <dxrp:ASPxRoundPanel ID="panelDirecc" runat="server" GroupBoxCaptionOffsetY="-14px"
                        HeaderText="Datos de la direcci&#243;n" SkinID="RoundPanelGroupBox" Width="100%">
        <PanelCollection>
            <dxp:PanelContent runat="server">
                <table border="0" cellpadding="2">
                    <tr>
                        <td align="right" style="width: 150px">
                            <dxe:ASPxLabel ID="lbD1" runat="server" Text="Calle Frontal:">
                            </dxe:ASPxLabel>
                        </td>
                        <td style="width: 300px">
                            <dxe:ASPxComboBox ID="edtCalleFront" runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True"
                                                IncrementalFilteringMode="StartsWith" TextField="CALLE" ValueField="IDCALLE"
                                                ValueType="System.String" Width="100%" CallbackPageSize="20" DataSourceID="dsCalles" EnableCallbackMode="True">
                            </dxe:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 150px">
                            <dxe:ASPxLabel ID="lbD2" runat="server" Text="N&#250;mero Exterior:">
                            </dxe:ASPxLabel>
                        </td>
                        <td style="width: 300px">
                            <dxe:ASPxComboBox ID="edtNumExt" runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True"
                                                IncrementalFilteringMode="StartsWith" TextField="NUMEX" ValueField="IDNUMEX"
                                                ValueType="System.String" Width="100%" CallbackPageSize="20" DataSourceID="dsNumExt" EnableCallbackMode="True">
                            </dxe:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 150px">
                            <dxe:ASPxLabel ID="lbD3" runat="server" Text="N&#250;mero Interior:">
                            </dxe:ASPxLabel>
                        </td>
                        <td style="width: 300px">
                            <dxe:ASPxComboBox ID="edtNumInt" runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True"
                                                IncrementalFilteringMode="StartsWith" TextField="NUMIN" ValueField="IDNUMIN"
                                                ValueType="System.String" Width="100%" CallbackPageSize="20" DataSourceID="dsNumInt" EnableCallbackMode="True" IncrementalFilteringDelay="200">
                            </dxe:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 150px">
                            <dxe:ASPxLabel ID="lbD4" runat="server" Text="Calle Izquierda:">
                            </dxe:ASPxLabel>
                        </td>
                        <td style="width: 300px">
                            <dxe:ASPxComboBox ID="edtCalleIzq" runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True"
                                                IncrementalFilteringMode="StartsWith" TextField="CALLE" ValueField="IDCALLE"
                                                ValueType="System.String" Width="100%" CallbackPageSize="20" DataSourceID="dsCalles" EnableCallbackMode="True">
                            </dxe:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 150px">
                            <dxe:ASPxLabel ID="lbD5" runat="server" Text="Calle Derecha:">
                            </dxe:ASPxLabel>
                        </td>
                        <td style="width: 300px">
                            <dxe:ASPxComboBox ID="edtCalleDer" runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True"
                                                IncrementalFilteringMode="StartsWith" TextField="CALLE" ValueField="IDCALLE"
                                                ValueType="System.String" Width="100%" CallbackPageSize="20" DataSourceID="dsCalles" EnableCallbackMode="True">
                            </dxe:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 150px">
                            <dxe:ASPxLabel ID="lbD6" runat="server" Text="Colonia:">
                            </dxe:ASPxLabel>
                        </td>
                        <td style="width: 300px">
                            <dxe:ASPxComboBox ID="edtColonia" runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True"
                                                IncrementalFilteringMode="StartsWith" TextField="COLONIA" ValueField="IDCOLONIA"
                                                ValueType="System.String" Width="100%" DataSourceID="dsColonias" CallbackPageSize="20" EnableCallbackMode="True">
                            </dxe:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 150px">
                            <dxe:ASPxLabel ID="lbD7" runat="server" Text="C&#243;digo Postal:">
                            </dxe:ASPxLabel>
                        </td>
                        <td style="width: 300px">
                            <dxe:ASPxComboBox ID="edtCodPosDir" runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True"
                                                IncrementalFilteringMode="StartsWith" TextField="CODPO" ValueField="IDCODPO"
                                                ValueType="System.String" Width="100%" DataSourceID="dsCodPos" CallbackPageSize="20" EnableCallbackMode="True">
                            </dxe:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 150px">
                            <dxe:ASPxLabel ID="lbD8" runat="server" Text="Pais:">
                            </dxe:ASPxLabel>
                        </td>
                        <td style="width: 300px">
                            <dxe:ASPxComboBox ID="edtPaisDir" runat="server" ValueType="System.String" DataSourceID="dsPaises" EnableIncrementalFiltering="True" IncrementalFilteringDelay="200" IncrementalFilteringMode="StartsWith" TextField="PAIS" ValueField="IDPAIS" Width="100%">
                            </dxe:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 150px">
                            <dxe:ASPxLabel ID="lbD9" runat="server" Text="Estado:">
                            </dxe:ASPxLabel>
                        </td>
                        <td style="width: 300px">
                            <dxe:ASPxComboBox ID="edtEstadoDir" runat="server" ValueType="System.String" DataSourceID="dsEstados" EnableIncrementalFiltering="True" IncrementalFilteringDelay="200" IncrementalFilteringMode="StartsWith" TextField="EDOPRO" ValueField="IDEDOPRO" Width="100%">
                            </dxe:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 150px">
                            <dxe:ASPxLabel ID="lbD10" runat="server" Text="Ciudad:">
                            </dxe:ASPxLabel>
                        </td>
                        <td style="width: 300px">
                            <dxe:ASPxComboBox ID="edtCiudadDir" runat="server" ValueType="System.String" DataSourceID="dsCiudades" EnableIncrementalFiltering="True" IncrementalFilteringDelay="200" IncrementalFilteringMode="StartsWith" TextField="CIUDAD" ValueField="IDCIUD" CallbackPageSize="20" EnableCallbackMode="True" Width="100%">
                            </dxe:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 150px">
                            <dxe:ASPxLabel ID="lbD11" runat="server" Text="Municipio:">
                            </dxe:ASPxLabel>
                        </td>
                        <td style="width: 300px">
                            <dxe:ASPxComboBox ID="edtMunicipio" runat="server" ValueType="System.String" DataSourceID="dsMunicipios" EnableIncrementalFiltering="True" IncrementalFilteringDelay="200" IncrementalFilteringMode="StartsWith" TextField="MUNIP" ValueField="IDMUNIP" CallbackPageSize="20" EnableCallbackMode="True" Width="100%">
                            </dxe:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 150px">
                            <dxe:ASPxLabel ID="lbD12" runat="server" Text="Clase:">
                            </dxe:ASPxLabel>
                        </td>
                        <td style="width: 300px">
                            <dxe:ASPxComboBox ID="edtClase" runat="server" DropDownStyle="DropDown"
                                                ValueType="System.Int32" Width="100%" SelectedIndex="0" CallbackPageSize="20" EnableCallbackMode="True">
                                <Items>
                                    <dxe:ListEditItem Selected="True" Text="Calle num&#233;rica estructurada" Value="1" />
                                    <dxe:ListEditItem Text="No estructurada o Incompatible" Value="2" />
                                    <dxe:ListEditItem Text="Calle alfab&#233;tica estructurada" Value="3" />
                                </Items>
                            </dxe:ASPxComboBox>
                        </td>
                    </tr>
                </table>
              
            </dxp:PanelContent>
        </PanelCollection>
    </dxrp:ASPxRoundPanel>
                    <table border="0" cellpadding="0">
                        <tr>
                            <td style="width: 100%">
                            </td>
                            <td>
                                <dxe:ASPxButton ID="btnGrabaDir" runat="server" Text="Grabar" OnClick="btnGrabaDir_Click">
                                </dxe:ASPxButton>
                            </td>
                        </tr>
                    </table>

</div>
</dxw:ContentControl>
</ContentCollection>
</dxtc:TabPage>
</TabPages>   
</dxtc:ASPxPageControl>
</asp:View>
</asp:MultiView></td>
            <td>
                 <div class="errorsList" id="errorsContainer">
             Por favor verifique los siguientes datos:
             <dxe:ASPxValidationSummary ID="vsValidationSummary1" runat="server" RenderMode="BulletedList" Width="243px"
                         Paddings-PaddingLeft="14px" ClientInstanceName="validationSummary" ValidationGroup="vsFisica">
                 <ClientSideEvents VisibilityChanged="ShowHideVS" />
                 <Paddings PaddingLeft="14px" />
             </dxe:ASPxValidationSummary>
                     
         </div>
        <dx:ASPxPopupControl ID="popMB" runat="server" AllowDragging="True" EnableViewState="False" ClientInstanceName="pcError"
                         HeaderText="Error" Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter">
                         <ContentCollection>
                             <dx:PopupControlContentControl runat="server">
                                 <table border="0" cellpadding="0">
                                     <tr>
                                         <td>
                                            <dxe:ASPxLabel ID="lbError" runat="server" Text="Esto es una prueba">
                                            </dxe:ASPxLabel>
                                         </td>
                                     </tr>
                                     <tr>
                                         <td align="right">
                                             <br />
                                             <dxe:ASPxButton ID="DlgBtnCerrar" runat="server" Text="Cerrar"  AutoPostBack="False">
                                             <ClientSideEvents Click="function(s, e) {
	                                                                    pcError.Hide();
                                                                       }" />
                                             </dxe:ASPxButton><dxe:ASPxButton ID="edtOk" runat="server" Text="OK" OnClick="edtOk_Click" >
                                             </dxe:ASPxButton>
                                         </td>
                                     </tr>
                                 </table>
                             </dx:PopupControlContentControl>
                         </ContentCollection>
                     </dx:ASPxPopupControl>
            </td>
        </tr>
    </table>
    &nbsp;
    <asp:ObjectDataSource ID="dsNombres" runat="server" SelectMethod="ObtenNombres" TypeName="MieleraNet.DAL.CentralDS">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsApellidos" runat="server" SelectMethod="ObtenApellidos"
        TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource><asp:ObjectDataSource ID="dsPaises" runat="server" SelectMethod="ObtenPais"
        TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource><asp:ObjectDataSource ID="dsCentrosAcopio" runat="server" SelectMethod="ObtenCentroAcopio"
        TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource><asp:ObjectDataSource ID="dsEstados" runat="server" SelectMethod="ObtenEstados"
        TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsCiudades" runat="server" SelectMethod="ObtenCiudades"
        TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsRelaciones" runat="server" SelectMethod="ObtenRelaciones"
        TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource><asp:ObjectDataSource ID="dsOcupaciones" runat="server" SelectMethod="ObtenOcupaciones"
        TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsTermLeg" runat="server" SelectMethod="ObtenTermLegales"
        TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsGiros" runat="server" SelectMethod="ObtenGiros"
        TypeName="MieleraNet.DAL.CentralDS">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsMunicipios" runat="server" SelectMethod="ObtenMunicipios"
        TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsCodPos" runat="server" SelectMethod="ObtenCodPos"
        TypeName="MieleraNet.DAL.CentralDS">
    </asp:ObjectDataSource><asp:ObjectDataSource ID="dsCorps" runat="server" SelectMethod="ObtenCorps"
        TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsColonias" runat="server" SelectMethod="ObtenColonias"
        TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource><asp:ObjectDataSource ID="dsTipodir" runat="server" SelectMethod="ObtenTipoDir"
        TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource><asp:ObjectDataSource ID="dsCalles" runat="server" SelectMethod="ObtenCalles"
        TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsNumInt" runat="server" SelectMethod="ObtenNumInt"
        TypeName="MieleraNet.DAL.CentralDS">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="dsNumExt" runat="server" SelectMethod="ObtenNumExt"
        TypeName="MieleraNet.DAL.CentralDS">
    </asp:ObjectDataSource>
    <br />
</asp:Content>
