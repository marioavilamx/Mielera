<%@ Page Language="C#"  MasterPageFile="~/Mielera.master"  AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="MieleraNet.Index" %>

<%@ Register Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a"
    Namespace="DevExpress.Web" TagPrefix="dx" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <strong><span style="font-size: 16pt"><span style="color: navy">
    </span></span></strong>
    &nbsp;<dx:ASPxRoundPanel ID="panelRecBook" runat="server"
        HeaderText="Recordatorio Booking" SkinID="RoundPanelGroupBox" Width="200px">
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxGridView ID="gridRecBook" runat="server" DataSourceID="dsRecBook">
                </dx:ASPxGridView>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxRoundPanel>
    <br />
    <br />
    <dx:ASPxRoundPanel ID="panelRecMuestras" runat="server" HeaderText="Recordatorio Muestras"
        SkinID="RoundPanelGroupBox" Width="200px">
        <PanelCollection>
            <dx:PanelContent runat="server">
                <dx:ASPxGridView ID="gridRecMuestras" runat="server" DataSourceID="dsRecBook">
                </dx:ASPxGridView>
            </dx:PanelContent>
        </PanelCollection>
    </dx:ASPxRoundPanel>
    <asp:ObjectDataSource ID="dsRecBook" runat="server" SelectMethod="ObtenBookingRecordatorio"
        TypeName="MieleraNet.DAL.ExportDS"></asp:ObjectDataSource>

</asp:Content>

