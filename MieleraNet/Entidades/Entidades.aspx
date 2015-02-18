<%@ Page Language="C#" MasterPageFile="~/Mielera.Master" AutoEventWireup="true" CodeBehind="Entidades.aspx.cs" Inherits="MieleraNet.Entidades.Entidades" Title="Untitled Page" %>

<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxCallbackPanel" TagPrefix="dxcp" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dxp" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHiddenField" TagPrefix="dxhf" %>
<%@ Register Assembly="DevExpress.Web.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dxrp" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v10.1, Version=10.1.12.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dxe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
<script type="text/javascript"><!--
var viewsCount = 3;
function ShowPrevPage(){
    ChangeActiveViewIndex(-1); 
}
function ShowNextPage(){
    ChangeActiveViewIndex(1);
}
function ChangeActiveViewIndex(changeIndex){
    hfAnswers.Set("questionIndex", GetQuestionIndex() + changeIndex);
    cpVoting.PerformCallback();
  
}
function GetQuestionIndex(){
    return hfAnswers.Get("questionIndex");
}
function SetButtonState(){
    btnPrev.SetVisible(GetQuestionIndex() > 0);
    btnNext.SetVisible(!IsPreviewPage());
    btnSubmit.SetVisible(IsPreviewPage());
}
function IsPreviewPage(){
    return GetQuestionIndex() == (viewsCount - 1);
}
function OnEntidadChanged(s, e){
    hfAnswers.Set("month", 0);
    hfAnswers.Set("entidades", s.GetSelectedIndex());
}
function OnMonthChanged(s, e){
    hfAnswers.Set("month", s.GetSelectedIndex());
}
function OnLostFocusPN(s, e){
    hfAnswers.Set("PrimerNombre", s.GetValue());
}
function OnLostFocusSN(s, e){
    hfAnswers.Set("SegundoNombre", s.GetValue());
}
function OnLostFocusPA(s, e){
    hfAnswers.Set("PrimerApellido", s.GetValue());
}
function OnLostFocusSA(s, e){
    hfAnswers.Set("SegundoApellido", s.GetValue());
}
function OnSubmit(s, e){
    var message = "Thank you for participating in the survey. Your answers will be posted to the server. The demo will be reloaded.";
    alert(message);
}
//--></script>
<%-- BeginRegion ASPxRoundPanel --%>
<dxrp:ASPxRoundPanel ID="rp" runat="server" Width="500px" HeaderText="Entidades">
    <PanelCollection>
        <dxp:PanelContent runat="server">
<%-- EndRegion --%>
<%-- BeginRegion ASPxCallbackPanel --%>
<dxcp:ASPxCallbackPanel runat="server" ClientInstanceName="cpVoting"
    Width="400px" Height="550px" ID="cpVoting">
    <ClientSideEvents EndCallback="SetButtonState"></ClientSideEvents>
    <PanelCollection>
        <dxp:PanelContent runat="server">
<%-- EndRegion --%>  
<asp:MultiView runat="server" ActiveViewIndex="0" ID="mvVoting">
    <asp:View runat="server" ID="View1">
        Selecciona la entidad:&nbsp;<br />
        <dxe:ASPxRadioButtonList runat="server" SelectedIndex="0" Width="258px" ID="rblEntidades">
            <Border BorderStyle="None"></Border>
            <ClientSideEvents SelectedIndexChanged="OnEntidadChanged" />
        </dxe:ASPxRadioButtonList>
    </asp:View>
    <asp:View runat="server" ID="View2">
        <dxrp:ASPxRoundPanel GroupBoxCaptionOffsetY="-14px" HeaderText="Datos Generales" ID="GeneralesGroup" runat="server" SkinID="RoundPanelGroupBox" Width="100%">
            <panelcollection>
<dxp:PanelContent runat="server"><TABLE cellSpacing=0 cellPadding=2 border=0><TBODY><TR><TD align=right><dxe:ASPxLabel runat="server" Text="Primer Nombre:" ID="ASPxLabel1" __designer:wfdid="w22"></dxe:ASPxLabel>


 </TD><TD><dxe:ASPxComboBox runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" ValueType="System.String" DataSourceID="dsNombres" TextField="NOMBRE" ValueField="NOMBRE" Width="100%" ID="edtPrimerNom" __designer:wfdid="w23">
<ClientSideEvents LostFocus="OnLostFocusPN"></ClientSideEvents>
</dxe:ASPxComboBox>


 </TD></TR><TR><TD align=right><dxe:ASPxLabel runat="server" Text="Segundo Nombre:" ID="ASPxLabel2" __designer:wfdid="w24"></dxe:ASPxLabel>


 </TD><TD><dxe:ASPxComboBox runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" ValueType="System.String" DataSourceID="dsNombres" TextField="NOMBRE" ValueField="NOMBRE" Width="100%" ID="edtSegundoNom" __designer:wfdid="w25">
<ClientSideEvents LostFocus="OnLostFocusSN"></ClientSideEvents>
</dxe:ASPxComboBox>


 </TD></TR><TR><TD align=right><dxe:ASPxLabel runat="server" Text="Primer Apellido:" ID="ASPxLabel3" __designer:wfdid="w26"></dxe:ASPxLabel>


 </TD><TD><dxe:ASPxComboBox runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" ValueType="System.String" DataSourceID="dsApellidos" TextField="APELLIDO" ValueField="IDAPELLIDO" Width="100%" ID="edtPrimerAp" __designer:wfdid="w27">
<ClientSideEvents LostFocus="OnLostFocusPA"></ClientSideEvents>
</dxe:ASPxComboBox>


 </TD></TR><TR><TD align=right><dxe:ASPxLabel runat="server" Text="Segundo Apellido:" ID="ASPxLabel4" __designer:wfdid="w28"></dxe:ASPxLabel>


 </TD><TD><dxe:ASPxComboBox runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" ValueType="System.String" DataSourceID="dsApellidos" TextField="APELLIDO" ValueField="IDAPELLIDO" Width="100%" ID="edtSegundoAp" __designer:wfdid="w29">
<ClientSideEvents LostFocus="OnLostFocusSA"></ClientSideEvents>
</dxe:ASPxComboBox>


 </TD></TR><TR><TD align=right><dxe:ASPxLabel runat="server" Text="Genero:" ID="ASPxLabel5" __designer:wfdid="w30"></dxe:ASPxLabel>


 </TD><TD><dxe:ASPxComboBox runat="server" SelectedIndex="0" ValueType="System.String" ID="ASPxComboBox3" __designer:wfdid="w31"><Items>
<dxe:ListEditItem Text="Femenino" Value="0" Selected="True"></dxe:ListEditItem>
<dxe:ListEditItem Text="Masculino" Value="1"></dxe:ListEditItem>
</Items>
</dxe:ASPxComboBox>


 </TD></TR><TR><TD align=right></TD><TD></TD></TR></TBODY></TABLE></dxp:PanelContent>
</panelcollection>
        </dxrp:ASPxRoundPanel>
        <br />
<%-- Seccion de Fecha y Lugar de Nacimiento --%>     
 <dxrp:ASPxRoundPanel GroupBoxCaptionOffsetY="-14px" HeaderText="Lugar y Fecha de Nacimiento" ID="FechaNacimiento" runat="server" SkinID="RoundPanelGroupBox" Width="100%">
            <panelcollection>
<dxp:PanelContent runat="server"><TABLE cellPadding=2 border=0><TBODY><TR><TD align=right><dxe:ASPxLabel runat="server" Text="Fecha de Nacimiento:" ID="ASPxLabel6" __designer:wfdid="w1"></dxe:ASPxLabel>


 </TD><TD><dxe:ASPxDateEdit runat="server" ID="edtFechaNac" __designer:wfdid="w2"></dxe:ASPxDateEdit>


 </TD></TR><TR><TD align=right><dxe:ASPxLabel runat="server" Text="Pais:" ID="edtPais" __designer:wfdid="w3"></dxe:ASPxLabel>


 </TD><TD><dxe:ASPxComboBox runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" ValueType="System.String" TextField="APELLIDO" ValueField="IDAPELLIDO" Width="100%" ID="ASPxComboBox1" __designer:wfdid="w5">
<ClientSideEvents LostFocus="OnLostFocusSA"></ClientSideEvents>
</dxe:ASPxComboBox>


</TD></TR><TR><TD align=right><dxe:ASPxLabel runat="server" Text="Estado:" ID="ASPxLabel7" __designer:wfdid="w7"></dxe:ASPxLabel>


</TD><TD><dxe:ASPxComboBox runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" ValueType="System.String" TextField="APELLIDO" ValueField="IDAPELLIDO" Width="100%" ID="ASPxComboBox2" __designer:wfdid="w6">
<ClientSideEvents LostFocus="OnLostFocusSA"></ClientSideEvents>
</dxe:ASPxComboBox>


</TD></TR><TR><TD align=right><dxe:ASPxLabel runat="server" Text="Ciudad:" ID="lbCiudad" __designer:wfdid="w8"></dxe:ASPxLabel>


</TD><TD><dxe:ASPxComboBox runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" ValueType="System.String" TextField="APELLIDO" ValueField="IDAPELLIDO" Width="100%" ID="edtCiudad" __designer:wfdid="w9">
<ClientSideEvents LostFocus="OnLostFocusSA"></ClientSideEvents>
</dxe:ASPxComboBox>


</TD></TR></TBODY></TABLE></dxp:PanelContent>
</panelcollection>
        </dxrp:ASPxRoundPanel>
        <br />
<%-- Seccion de Datos Opcionales --%>
 <dxrp:ASPxRoundPanel GroupBoxCaptionOffsetY="-14px" HeaderText="Datos Opcionales" ID="DatosOpc" runat="server" SkinID="RoundPanelGroupBox" Width="100%">
            <panelcollection>
<dxp:PanelContent runat="server"><TABLE cellPadding=2 border=0><TBODY><TR><TD align=right><dxe:ASPxLabel runat="server" Text="Telefono:" ID="ASPxLabel8"></dxe:ASPxLabel>


 </TD><TD>&nbsp;<dxe:ASPxTextBox runat="server" Width="170px" ID="edtTelefono" __designer:wfdid="w10"></dxe:ASPxTextBox>


</TD></TR><TR><TD align=right><dxe:ASPxLabel runat="server" Text="E-Mail:" ID="ASPxLabel9"></dxe:ASPxLabel>


 </TD><TD><dxe:ASPxComboBox runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" ValueType="System.String" TextField="APELLIDO" ValueField="IDAPELLIDO" Width="100%" ID="ASPxComboBox4">
<ClientSideEvents LostFocus="OnLostFocusSA"></ClientSideEvents>
</dxe:ASPxComboBox>


 </TD></TR><TR><TD align=right><dxe:ASPxLabel runat="server" Text="Ocupaci&#243;n:" ID="ASPxLabel10"></dxe:ASPxLabel>


 </TD><TD><dxe:ASPxComboBox runat="server" DropDownStyle="DropDown" EnableIncrementalFiltering="True" IncrementalFilteringMode="StartsWith" ValueType="System.String" TextField="APELLIDO" ValueField="IDAPELLIDO" Width="100%" ID="ASPxComboBox5">
<ClientSideEvents LostFocus="OnLostFocusSA"></ClientSideEvents>
</dxe:ASPxComboBox>


 </TD></TR><TR><TD align=right><dxe:ASPxLabel runat="server" Text="Observaci&#243;n:" ID="ASPxLabel11"></dxe:ASPxLabel>


 </TD><TD><dxe:ASPxMemo runat="server" Height="71px" Width="170px" ID="ASPxMemo1" __designer:wfdid="w11"></dxe:ASPxMemo>


</TD></TR></TBODY></TABLE></dxp:PanelContent>
</panelcollection>
        </dxrp:ASPxRoundPanel>
        <br />     
     
    </asp:View>
    <asp:View runat="server" ID="View3">
        Los datos a grabar:<br /><br /> 
        <table>
            <tr><td style="padding-left: 10px;">Season:</td><td><dxe:ASPxLabel Font-Bold="true" id="lblSelectedSeason" runat="server"/></td></tr>
            <tr><td style="padding-left: 10px;">Month:</td><td><dxe:ASPxLabel Font-Bold="true" id="lblSelectedMonth" runat="server"/></td></tr>
        </table>
    </asp:View>
</asp:MultiView>
<dxhf:ASPxHiddenField runat="server" ClientInstanceName="hfAnswers" ID="hfAnswers">
</dxhf:ASPxHiddenField>
<%-- BeginRegion ASPxCallbackPanel --%>
            <asp:ObjectDataSource ID="dsNombres" runat="server" SelectMethod="ObtenNombres"
                TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource><asp:ObjectDataSource ID="dsApellidos" runat="server" SelectMethod="ObtenApellidos"
                TypeName="MieleraNet.DAL.CentralDS"></asp:ObjectDataSource>
        </dxp:PanelContent>
    </PanelCollection>
</dxcp:ASPxCallbackPanel>
<%-- EndRegion --%>
<%-- BeginRegion Navigation --%>
<table cellspacing="0" cellpadding="3" width="100%">
    <tbody>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
            <td style="text-align: right">
                <dxe:ASPxButton runat="server" AutoPostBack="False" ClientInstanceName="btnPrev"
                    ClientVisible="False" Text="Anterior" Width="70px" ID="btnPrev">
                    <ClientSideEvents Click="ShowPrevPage" />
                </dxe:ASPxButton>
            </td>
            <td style="width: 70px">
                <dxe:ASPxButton runat="server" AutoPostBack="False" ClientInstanceName="btnNext"
                    Text="Siguiente" Width="70px" ID="btnNext">
                    <ClientSideEvents Click="ShowNextPage" />
                </dxe:ASPxButton>
                <dxe:ASPxButton runat="server" ClientInstanceName="btnSubmit" ClientVisible="False"
                    Text="Grabar" Width="70px" ID="btnSubmit" OnClick="btnSubmit_Click">
                    <ClientSideEvents Click="OnSubmit" />
                </dxe:ASPxButton>
            </td>
        </tr>
    </tbody>
</table>
<script type="text/javascript">
    SetButtonState();
</script>
<%-- EndRegion --%>
<%-- BeginRegion ASPxRoundPanel --%>
        </dxp:PanelContent>
    </PanelCollection>
</dxrp:ASPxRoundPanel>
<%-- EndRegion --%>
</asp:Content>
