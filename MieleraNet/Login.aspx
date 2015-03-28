<%@ Page Language="C#" MasterPageFile="~/Mielera.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="MieleraNet.Login" Title="MieleraNet" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style type="text/css">
    .menu{
        display: table-cell;
        width: 0%;
    }

    .encabezado{
        display:none;
    }
    .footer {
        display:none;
    }

</style>
<div class="wraper centrar login">
    <div class="wraper-row inlineblock textdecoration height10">
        <div class="wraper-cell ">
            <asp:LinkButton ID="btnProdLink" runat="server" OnClick="btnProdLink_Click" CssClass="icon-home3 fon-size textdecoration"></asp:LinkButton>
          
        </div>
        <div class="wraper-cell">
            <asp:LinkButton ID="btnDemoLink" runat="server" CssClass="icon-wrench fon-size textdecoration" OnClick="btnDemoLink_Click"></asp:LinkButton>
        </div>
    </div>  
    <div class="wraper-row height10">
        <div class="wraper-cell icon-user-tie">
            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text="Usuario:"></dx:ASPxLabel>
            <dx:ASPxTextBox ID="edtUsuario" runat="server" Text="" Width="100%" NullText="Ingrese su usuario"></dx:ASPxTextBox>
        </div>
        <div class="wraper-cell icon-key">
            <dx:ASPxLabel ID="ASPxLabel2" runat="server" Text="Contrasea"></dx:ASPxLabel>
            <dx:ASPxTextBox ID="edtPassword" runat="server" Password="True" Text="admin" Width="100%" NullText="Ingrese su contraseña"></dx:ASPxTextBox>
        </div>    
    </div>
    
    <div>
        <dx:ASPxComboBox ID="edtEmpresas" runat="server" DataSourceID="dsEmpresas" TextField="NOMBRE" ValueField="IDEMPRESA" ValueType="System.Int32" Width="100%" SelectedIndex="1"></dx:ASPxComboBox>
    </div>
    <div class="boton">
        <dx:ASPxButton ID="btnLogin" runat="server" OnClick="btnLogin_Click" Text="Ingresar"></dx:ASPxButton>
    </div>
</div>
    <asp:ObjectDataSource ID="dsEmpresas" runat="server" SelectMethod="ObtenEmpresas"
        TypeName="MieleraNet.DAL.CentralDS">
    </asp:ObjectDataSource>
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
