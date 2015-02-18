<%@ Page Language="C#" MasterPageFile="~/Mielera.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MieleraNet.Login" Title="MieleraNet" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<table style="margin-left: 0px; text-align: left">
        <tr>
            <td>
            </td>
            <td colspan="2">
                <table border="0" cellpadding="0">
                    <tr>
                        <td style="width: 100px">
                            &nbsp;
                            <asp:ImageButton ID="btnProd" runat="server" Height="30px" ImageUrl="~/Images/Home.png"
                                Width="30px" OnClick="btnProd_Click" /></td>
                        <td style="width: 100px">
                            &nbsp;
                            <asp:ImageButton ID="btnDemo" runat="server" Height="30px" ImageUrl="~/Images/Demo.jpg"
                                Width="30px" OnClick="btnDemo_Click" /></td>
                    </tr>
                </table>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/user.png" /></td>
            <td style="width: 80px">
                <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Usuario:">
                                </dx:ASPxLabel>
            </td>
            <td style="width: 200px">
                <dx:ASPxTextBox ID="edtUsuario" runat="server" Text="" Width="100%">
                                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Image ID="Image2" runat="server" ImageUrl="~/App_Themes/security_keyandlock.png" /></td>
            <td style="width: 80px">
                <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Contrasea">
                            </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxTextBox ID="edtPassword" runat="server" Password="True" Text="admin" Width="100%">
                                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
            <td>
            <asp:Image ID="Image3" runat="server" ImageUrl="~/App_Themes/user.png" />
            </td>
            <td style="width: 80px">
                <dx:ASPxLabel ID="lbEmpresas" runat="server" Text="Empresas">
                </dx:ASPxLabel>
            </td>
            <td>
                <dx:ASPxComboBox ID="edtEmpresas" runat="server" DataSourceID="dsEmpresas" TextField="NOMBRE" ValueField="IDEMPRESA" ValueType="System.Int32" Width="100%" SelectedIndex="1">
                </dx:ASPxComboBox>
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td style="width: 80px">
            </td>
            <td>
            <br />
                <dx:ASPxButton ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Ingresar">
                </dx:ASPxButton>
            </td>
        </tr>
</table>
    <asp:ObjectDataSource ID="dsEmpresas" runat="server" SelectMethod="ObtenEmpresas"
        TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource>
    <dx:ASPxPopupControl id="popMB" runat="server" AllowDragging="True" ClientInstanceName="pcError"
        EnableViewState="False" HeaderText="Error" Modal="True" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter">
        <contentcollection>
                             <dx:PopupControlContentControl  runat="server">
                                 <table  border="0" cellpadding="0">
                                     <tr>
                                         <td style="height: 19px" >
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
                                                                       }"  />
                                             </dx:ASPxButton>
                                         </td>
                                     </tr>
                                </table>
                         </dx:PopupControlContentControl>
                         </contentcollection>
    </dx:ASPxPopupControl>
</asp:Content>
