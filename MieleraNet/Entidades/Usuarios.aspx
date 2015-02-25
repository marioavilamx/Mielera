<%@ Page Language="C#" MasterPageFile="~/Mielera.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="MieleraNet.Entidades.Usuarios" Title="Usuarios" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %><%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>
<%@ Register Assembly="DevExpress.Web.v13.2, Version=13.2.8.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxPageControl ID="ASPxPageControl1" runat="server" ActiveTabIndex="0" Width="491px">
        <TabPages>
            <dx:TabPage Text="Consulta de Usuario Web">
                <ContentCollection>
                    <dx:ContentControl runat="server">
                        <dx:ASPxGridView ID="gridUsuarios" runat="server" AutoGenerateColumns="False" DataSourceID="dsUsuarios" KeyFieldName="ID">
                            <Columns>
                                <dx:GridViewCommandColumn VisibleIndex="0">
                                    <EditButton Text="Editar" Visible="True">
                                    </EditButton>
                                    <DeleteButton Text="Eliminar" Visible="True">
                                    </DeleteButton>
                                    <CancelButton Text="Cancelar">
                                    </CancelButton>
                                    <UpdateButton Text="Actualizar">
                                    </UpdateButton>
                                    <ClearFilterButton Visible="True">
                                    </ClearFilterButton>
                                </dx:GridViewCommandColumn>
                                <dx:GridViewDataTextColumn FieldName="ID" VisibleIndex="1">
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="USUARIO" VisibleIndex="2">
                                    <Settings AllowGroup="False" />
                                    <EditFormSettings Visible="False" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataTextColumn FieldName="PASS" VisibleIndex="3">
                                    <Settings AllowAutoFilter="False" ShowFilterRowMenu="False" ShowInFilterControl="False" />
                                    <EditFormSettings CaptionLocation="Top" Visible="True" />
                                </dx:GridViewDataTextColumn>
                                <dx:GridViewDataComboBoxColumn FieldName="ROLES" VisibleIndex="4">
                                <PropertiesComboBox IncrementalFilteringMode="StartsWith" EnableIncrementalFiltering="True" ValueType="System.String">
                                    <Items>
                                        <dxe:ListEditItem Text="Administrador" Value="Administrador" />
                                        <dxe:ListEditItem Text="Delegado" Value="Delegado" />
                                        <dxe:ListEditItem Text="Apicultor" Value="Apicultor" />
                                    </Items>
                                </PropertiesComboBox>
                                    <EditFormSettings CaptionLocation="Top" Visible="True" />
                                  
                                </dx:GridViewDataComboBoxColumn>
                            </Columns>
                            <Settings ShowFilterRow="True" />
                            <SettingsBehavior ConfirmDelete="True" />
                            <SettingsText ConfirmDelete="Desea que el usuario ya no tenga acceso al sitio web? " />
                        </dx:ASPxGridView>
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
            <dx:TabPage Text="Alta de Usuario Web">
                <ContentCollection>
                    <dx:ContentControl runat="server">
    <dxrp:ASPxRoundPanel ID="Relacion" runat="server" GroupBoxCaptionOffsetY="-14px"
        HeaderText="Relacionar Entidad" SkinID="RoundPanelGroupBox" Width="100%">
        <PanelCollection>
            <dxp:PanelContent runat="server">
                <table border="0" cellpadding="2">
                    <tr>
                        <td align="right"><dxe:ASPxLabel ID="ASPxLabel14" runat="server" Text="Usuarios existentes en la Empresa">
                        </dxe:ASPxLabel>
                            </td>
                        <td style="width: 240px">
                            <dxe:ASPxComboBox ID="edtEnfimo" runat="server" CallbackPageSize="20" DataSourceID="dsLocenfis"
                                DropDownStyle="DropDown" EnableCallbackMode="True" EnableIncrementalFiltering="True"
                                IncrementalFilteringDelay="200" IncrementalFilteringMode="StartsWith" TextField="NOMBRE"
                                ValueField="IDENFI" ValueType="System.Int32" Width="100%">
                            </dxe:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <dxe:ASPxLabel ID="lb5" runat="server" Text="Usuario:">
                            </dxe:ASPxLabel>
                        </td>
                        <td>
                            <dxe:ASPxTextBox ID="edtUsuario" runat="server" Width="100%">
                            </dxe:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <dxe:ASPxLabel ID="lb2" runat="server" Text="Contrase&#241;a:">
                            </dxe:ASPxLabel>
                            </td>
                        <td>
                            <dxe:ASPxTextBox ID="edtPass" runat="server" Width="100%" Password="True">
                            </dxe:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right"><dxe:ASPxLabel ID="lb3" runat="server" Text="Rol:">
                        </dxe:ASPxLabel>
                        </td>
                        <td><dxe:ASPxComboBox ID="edtRol" runat="server" ValueType="System.Int32" Width="100%" DropDownStyle="DropDown" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith">
                            <Items>
                                <dxe:ListEditItem Text="Administrador" Value="1" />
                                <dxe:ListEditItem Text="Delegado" Value="2" />
                                <dxe:ListEditItem Text="Apicultor" Value="3" />
                            </Items>
                        </dxe:ASPxComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <dxe:ASPxLabel ID="lb4" runat="server" Text="Area:">
                            </dxe:ASPxLabel>
                        </td>
                        <td>
                            <dxe:ASPxComboBox ID="edtArea" runat="server" ValueType="System.Int32" DataSourceID="dsAreas" TextField="AREA" ValueField="IDAREA" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" Width="100%" DropDownStyle="DropDown">
                                <Items>
                                    <dxe:ListEditItem Text="Administrador" Value="1" />
                                    <dxe:ListEditItem Text="Delegado" Value="2" />
                                    <dxe:ListEditItem Text="Apicultor" Value="3" />
                                </Items>
                            </dxe:ASPxComboBox>
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
                    </dx:ContentControl>
                </ContentCollection>
            </dx:TabPage>
        </TabPages>
    </dx:ASPxPageControl>
    <asp:ObjectDataSource ID="dsLocenfis" runat="server" SelectMethod="ObtenLocenfis"
        TypeName="MieleraNet.DAL.PerifericaDS"></asp:ObjectDataSource>
    <br />
    <asp:ObjectDataSource ID="dsUsuarios" runat="server" SelectMethod="ObtenUsuarioWeb"
        TypeName="MieleraNet.DAL.PerifericaDS" UpdateMethod="ActualizaUsrWeb" DeleteMethod="EliminaUsrWeb">
        <DeleteParameters>
            <asp:Parameter Name="ID" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="pass" />
            <asp:Parameter Name="roles" />
            <asp:Parameter Name="id" />
        </UpdateParameters>
    </asp:ObjectDataSource><asp:ObjectDataSource ID="dsAreas" runat="server" SelectMethod="ObtenAreas"
        TypeName="MieleraNet.DAL.PerifericaDS"></asp:ObjectDataSource>
    <dx:ASPxPopupControl id="popMB" runat="server" AllowDragging="True" ClientInstanceName="pcError"
        EnableViewState="False" HeaderText="Error" Modal="True" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter">
        <contentcollection>
                             <dx:PopupControlContentControl  runat="server">
                                 <table  border="0" cellpadding="0">
                                     <tr >
                                         <td>
                                            <dxe:ASPxLabel ID="lbError" runat="server" Text="Esto es una prueba">
                                            </dxe:ASPxLabel>
                                         </td>
                                     </tr>
                                     <tr >
                                         <td align="right">
                                             <br  />
                                             <dxe:ASPxButton ID="DlgBtnCerrar" runat="server" Text="Cerrar"  AutoPostBack="False">
                                             <ClientSideEvents  Click="function(s, e) {
	                                                                    pcError.Hide();
                                                                       }"   />
                                             </dxe:ASPxButton>
                                             <dxe:ASPxButton ID="edtOk" runat="server" Text="OK" OnClick="edtOk_Click" >
                                             </dxe:ASPxButton>
                                         </td>
                                     </tr>
                                 </table>
                             </dx:PopupControlContentControl>
                         </contentcollection>
    </dx:ASPxPopupControl>
</asp:Content>