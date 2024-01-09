<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_listacob2.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ValidacionProduccion.wpr_listacob2" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container">


     <script type="text/javascript">    
         var isDetailRowExpanded = new Array();
         function OnRowClick(s, e) {
             if (isDetailRowExpanded[e.visibleIndex] != true)
                 s.ExpandDetailRow(e.visibleIndex);
             else
                 s.CollapseDetailRow(e.visibleIndex);
         }
         function OnDetailRowExpanding(s, e) {
             isDetailRowExpanded[e.visibleIndex] = true;
         }
         function OnDetailRowCollapsing(s, e) {
             isDetailRowExpanded[e.visibleIndex] = false;
         }

         function OnRowDblClick(s, e) {
             var index = e.visibleIndex;

             CallBGridPoliza.PerformCallback(index);
         }

         function UpdateDetailGrid(s, e) {
             var index = e.visibleIndex;

             CallBPersona.PerformCallback(index);
         }
         function OnEndCallbackPersona(s, e) {

             pCPersona.Hide();

         }

         function UpdateDetailGridCompania(s, e) {
             var index = e.visibleIndex;

             CallBCompania.PerformCallback(index);
         }
         function OnEndCallbackCompania(s, e) {

             pCCompania.Hide();

         }
         function UpdateDetailGridProducto(s, e) {
             var index = e.visibleIndex;

             CallBProducto.PerformCallback(index);
         }
         function OnEndCallbackProducto(s, e) {

             pCProducto.Hide();

         }
     </script>



     <asp:Panel runat="server" ID="panel" CssClass="rounded">
         <div id="msgboxpanel" runat="server"></div>

         <div class="card p-3 bg-light rounded">
             <h6 class="text-info fw-bold fs-8">Listado de Polizas</h6>
             <div class="row">
                 <div class="col-12 col-sm-12 col-md-5">
                     <div class="row">
                         <div class="col-4">
                             <asp:Label runat="server" ID="lblnumero" Text="N° de Poliza :" CssClass="fs-10"></asp:Label>
                         </div>
                         <div class="col-8">
                             <dx:BootstrapTextBox runat="server" ID="num_poliza" NullText="Número de Poliza" Text="%">
                                 <CssClasses Input="form-control-sm fs-10" />
                             </dx:BootstrapTextBox>
                         </div>
                     </div>
                     <div class="row mt-1">
                         <div class="col-4">
                             <asp:Label runat="server" ID="lblasegurado" Text="Asegurado :" CssClass="fs-10"></asp:Label>
                         </div>
						 <div class="col-8 col-sm-8 col-md-8 col-lg-8 col-xl-8 col-xxl-8">
                            <div class="d-flex">
							 <div class="flex-grow-1">
                                 <dx:BootstrapCallbackPanel ID="CallBPersona" ClientInstanceName="CallBPersona" runat="server" OnCallback="CallBPersona_Callback">
                                     <ClientSideEvents EndCallback="OnEndCallbackPersona"></ClientSideEvents>
                                     <ContentCollection>
                                         <dx:ContentControl>
                                             <dx:BootstrapTextBox runat="server" ID="nomraz" NullText="" >
                                                 <CssClasses Input="form-control-sm fs-10" />
                                             </dx:BootstrapTextBox>
                                             <asp:HiddenField runat="server" ID="id_per" Value="" />
                                         </dx:ContentControl>
                                     </ContentCollection>
                                 </dx:BootstrapCallbackPanel>
</div>
                                 <dx:BootstrapButton ID="btnserper" runat="server" AutoPostBack="false" Text="..." OnClick="btnserper_Click">
                                     <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                     <SettingsBootstrap RenderOption="None" />
                                 </dx:BootstrapButton>
                             </div>

                         </div>
                     </div>
                     <div class="row mt-1">
                         <div class="col-4 pe-0">
                             <asp:Label runat="server" ID="lblcompania" Text="Cia Aseguradora:" CssClass="fs-10"></asp:Label>
                         </div>
                         <div class="col-8">
                             <div class="d-flex">
 <div class="flex-grow-1">
                                 <dx:BootstrapCallbackPanel ID="CallBCompania" ClientInstanceName="CallBCompania" runat="server" OnCallback="CallBCompania_Callback">
                                     <ClientSideEvents EndCallback="OnEndCallbackCompania"></ClientSideEvents>
                                     <ContentCollection>
                                         <dx:ContentControl>
                                             <dx:BootstrapTextBox runat="server" ID="nomco" NullText="" >
                                                 <CssClasses Input="form-control-sm fs-10" />
                                             </dx:BootstrapTextBox>
                                             <asp:HiddenField runat="server" ID="id_spvs" Value="" />
                                         </dx:ContentControl>
                                     </ContentCollection>
                                 </dx:BootstrapCallbackPanel>
 </div>
                                 <dx:BootstrapButton ID="btnsercom" runat="server" AutoPostBack="false" Text="..." OnClick="btnsercom_Click">
                                     <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                     <SettingsBootstrap RenderOption="None" />
                                 </dx:BootstrapButton>
                             </div>

                         </div>
                     </div>
                     <div class="row mt-1">
                         <div class="col-4">
                             <asp:Label runat="server" ID="lblproducto" Text="Producto :" CssClass="fs-10"></asp:Label>
                         </div>
                         <div class="col-8">
                             <div class="d-flex">
							  <div class="flex-grow-1">
                                 <dx:BootstrapCallbackPanel ID="CallBProducto" ClientInstanceName="CallBProducto" runat="server" OnCallback="CallBProducto_Callback">
                                     <ClientSideEvents EndCallback="OnEndCallbackProducto"></ClientSideEvents>
                                     <ContentCollection>
                                         <dx:ContentControl>
                                             <dx:BootstrapTextBox runat="server" ID="desc_producto" NullText="" >
                                                 <CssClasses Input="form-control-sm fs-10" />
                                             </dx:BootstrapTextBox>
                                             <asp:HiddenField runat="server" ID="id_producto" Value="" />
                                         </dx:ContentControl>
                                     </ContentCollection>
                                 </dx:BootstrapCallbackPanel>
   </div>
                                 <dx:BootstrapButton ID="btnserprod" runat="server" AutoPostBack="false" Text="..." OnClick="btnserprod_Click">
                                     <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                     <SettingsBootstrap RenderOption="None" />
                                 </dx:BootstrapButton>
                             </div>

                         </div>
                     </div>
                     <div class="row mt-1 msg_button_class">
                         <div class="col-12 ">
                             <div class="d-flex flex-row-reverse ">
                                 <dx:BootstrapCheckBox ID="vigencia" runat="server"></dx:BootstrapCheckBox>
                                 <asp:Label runat="server" ID="chkLabel" Text="Por Vigencia" CssClass="fs-10 mt-1 me-1"></asp:Label>
                             </div>
                         </div>
                     </div>
                     <div class="row mt-1">
                         <div class="col-4">
                             <asp:Label runat="server" ID="lblfc_inivig" Text="Del" CssClass="fs-10"></asp:Label>

                         </div>
                         <div class="col-8">
                             <dx:BootstrapDateEdit ID="fc_inivig" runat="server" CalendarProperties-CssClasses-Button="btn-sm">
                                 <CssClasses Button="btn-sm" Input="form-control-sm fs-10" Calendar="fs-10" />
                             </dx:BootstrapDateEdit>
                         </div>
                     </div>
                     <div class="row mt-1">
                         <div class="col-4">
                             <asp:Label runat="server" ID="lblfc_finvig" Text="Al" CssClass="fs-10"></asp:Label>
                         </div>
                         <div class="col-8">
                             <dx:BootstrapDateEdit ID="fc_finvig" runat="server"  CalendarProperties-CssClasses-Button="btn-sm">
                                 <CssClasses Button="btn-sm" Input="form-control-sm fs-10"  Calendar="fs-10" />
                             </dx:BootstrapDateEdit>
                             <asp:HiddenField runat="server" ID="id_clamov" Value="" />
                         </div>
                     </div>
                     <div class="row mt-1 msg_button_class">
                         <div class="col-12 ">
                             <div class="d-flex flex-row-reverse ">
                                 <dx:BootstrapCheckBox ID="porvencer" runat="server"></dx:BootstrapCheckBox>
                                 <asp:Label runat="server" ID="Label1" Text="Por Vencer" CssClass="fs-10 mt-1 me-1"></asp:Label>
                             </div>
                         </div>

                     </div>
                     <div class="row mt-1">
                         <div class="col-4 pe-0">
                             <asp:Label runat="server" ID="lblcuotavencidas" Text="Polizas Vencidas:" CssClass="fs-10"></asp:Label>
                         </div>
                         <div class="col-8">
                             <dx:BootstrapDateEdit ID="fc_polizavencida" runat="server"  CalendarProperties-CssClasses-Button="btn-sm">
                                 <CssClasses Button="btn-sm" Input="form-control-sm fs-10"  Calendar="fs-10"  />
                             </dx:BootstrapDateEdit>
                         </div>
                     </div>
                     <div class="row mt-1">
                         <div class="col-12 text-center">
                             <dx:BootstrapButton ID="btnnuevo" runat="server" AutoPostBack="false" Text="Nuevo" OnClick="btnnuevo_Click">
                                 <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                 <SettingsBootstrap RenderOption="None" />
                             </dx:BootstrapButton>
                             <dx:BootstrapButton ID="btnbuscar" runat="server" AutoPostBack="false" Text="Buscar" OnClick="btnbuscar_Click">
                                 <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                 <SettingsBootstrap RenderOption="None" />
                             </dx:BootstrapButton>
                         </div>
                     </div>
                 </div>
                 <div class="col-12 col-sm-12 col-md-7 col-lg-7 col-xl-7 col-xxl-7 mt-4 mt-lg-0 p-0 p-sm-0 p-md-0 ">
                     <asp:Panel runat="server" ID="gridcontainer" Visible="false">
                         <dx:BootstrapGridView ID="gridpoliza" ClientInstanceName="gridpoliza" runat="server" KeyFieldName="id_poliza" OnDataBinding="gridpoliza_DataBinding">
                             <Settings ShowColumnHeaders="true" ShowTitlePanel="true" />
                             <SettingsText Title="Pólizas Registradas" />
                             <SettingsBehavior AllowFocusedRow="True" AllowClientEventsOnLoad="False" AllowSelectByRowClick="true" />
                             <ClientSideEvents RowDblClick="OnRowDblClick" RowClick="OnRowClick" DetailRowExpanding="OnDetailRowExpanding" DetailRowCollapsing="OnDetailRowCollapsing" />
                             <SettingsBootstrap Striped="true" />
                             <CssClasses PanelHeading="msg_button_class p-1 fs-10 " HeaderRow="thTabla" />
                             <SettingsPager NumericButtonCount="3">
                                 <PageSizeItemSettings Visible="false" Items="10, 20, 50" />
                             </SettingsPager>
                             <SettingsDetail ShowDetailRow="true" ShowDetailButtons="false" />

                             <Columns>
                                 <dx:BootstrapGridViewDateColumn Caption="N° Póliza" FieldName="num_poliza" Width="20px">
                                 </dx:BootstrapGridViewDateColumn>
                                 <dx:BootstrapGridViewDateColumn Caption="Cliente" FieldName="nomraz" Width="130px">
                                 </dx:BootstrapGridViewDateColumn>
                                 <dx:BootstrapGridViewDateColumn Caption="Ini. Vigencia" FieldName="fc_inivig" Width="20px">
                                 </dx:BootstrapGridViewDateColumn>
                                 <dx:BootstrapGridViewDateColumn Caption="Fin Vigencia" FieldName="fc_finvig" Width="20px">
                                 </dx:BootstrapGridViewDateColumn>
                                 <dx:BootstrapGridViewDateColumn FieldName="fc_emision" Visible="false">
                                 </dx:BootstrapGridViewDateColumn>
                                 <dx:BootstrapGridViewDateColumn FieldName="no_liquida" Visible="false">
                                 </dx:BootstrapGridViewDateColumn>
                                 <dx:BootstrapGridViewDateColumn FieldName="prima_bruta" Visible="false">
                                 </dx:BootstrapGridViewDateColumn>
                                 <dx:BootstrapGridViewDateColumn FieldName="id_gru" Visible="false">
                                 </dx:BootstrapGridViewDateColumn>
                                 <dx:BootstrapGridViewDateColumn FieldName="id_spvs" Visible="false">
                                 </dx:BootstrapGridViewDateColumn>
                                 <dx:BootstrapGridViewDateColumn FieldName="id_producto" Visible="false">
                                 </dx:BootstrapGridViewDateColumn>
                                 <dx:BootstrapGridViewDateColumn FieldName="tipo_cuota" Visible="false">
                                 </dx:BootstrapGridViewDateColumn>
                                    <dx:BootstrapGridViewDateColumn FieldName="id_perejec" Visible="false">
</dx:BootstrapGridViewDateColumn>
                             </Columns>
                             <Templates>
                                 <DetailRow>
                                     <div class="divScroll">
                                         <div class="divDetails">
                                             <div class="row">
                                                 <div class="col-12">
                                                     <span class="text-info fw-bold fs-8">Datos de Poliza Renovada (Módulo de Cobranzas)</span>
                                                 </div>
                                             </div>
                                             <div class="row">
                                                 <div class="col-4">
                                                     <span class="fs-11 fw-bold ">Inicio de Vigencia: </span>
                                                     <asp:Label runat="server" ID="lblIniVig" Text='<%# Bind("fc_inivig","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                 </div>
                                                 <div class="col-4">
                                                     <span class="fs-11 fw-bold ">Fin de Vigencia: </span>
                                                     <asp:Label runat="server" ID="lblFinVig" Text='<%# Bind("fc_finvig","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                 </div>
                                                 <div class="col-4">
                                                     <span class="fs-11 fw-bold ">Fin de Emision: </span>
                                                     <asp:Label runat="server" ID="lblEmision" Text='<%# Eval("fc_emision","{0:dd/MM/yyyy}") %>'></asp:Label>
                                                 </div>
                                             </div>
                                             <div class="row">
                                                 <div class="col-4">
                                                     <span class="fs-11 fw-bold ">Nº Poliza: </span>
                                                     <asp:Label runat="server" ID="lblNumPoliza" Text='<%# Bind("num_poliza") %>'></asp:Label>
                                                 </div>
                                                 <div class="col-4">
                                                     <span class="fs-11 fw-bold ">Nº Liquidación: </span>
                                                     <asp:Label runat="server" ID="Label3" Text='<%# Bind("no_liquida") %>'></asp:Label>
                                                 </div>
                                                 <div class="col-4">
                                                     <span class="fs-11 fw-bold ">Prima Neta: </span>
                                                     <asp:Label runat="server" ID="Label4" Text='<%# Bind("prima_bruta") %>'></asp:Label>
                                                 </div>

                                                 <div class="col-12">
                                                     <span class="fs-11 fw-bold ">Asegurado: </span>
                                                     <asp:Label runat="server" ID="lblAsegurado" Text='<%# Bind("nomraz") %>'></asp:Label>
                                                 </div>

                                                 <div class="col-12">
                                                     <span class="fs-11 fw-bold ">Grupo: </span>
                                                     <asp:Label runat="server" ID="lblGrupo" Text='<%#  Grupo(Eval("id_gru")) %>'></asp:Label>
                                                 </div>
                                                 <div class="col-12">
                                                     <span class="fs-11 fw-bold ">Cia. Aseguradora: </span>
                                                     <asp:Label runat="server" ID="lblCompania" Text='<%# CompaniaAseg(Eval("id_spvs")) %>'></asp:Label>
                                                 </div>
                                                 <div class="col-6">
                                                     <span class="fs-11 fw-bold ">Producto: </span>
                                                     <asp:Label runat="server" ID="lblProducto" Text='<%# NombreProducto(Eval("id_producto")) %>'></asp:Label>
                                                 </div>
                                                 <div class="col-6">
                                                     <span class="fs-11 fw-bold ">Tipo: </span>
                                                     <asp:Label runat="server" ID="Label2" Text='<%# TipoPoliza(Eval("id_poliza")) %>'></asp:Label>
                                                 </div>
                                                 <div class="col-12">
                                                     <span class="fs-11 fw-bold ">Ejecutivo: </span>
                                                     <asp:Label runat="server" ID="lblEjecutivo" Text='<%# Ejecutivo(Eval("id_perejec")) %>'></asp:Label>
                                                 </div>
                                                 <div class="col-12">
                                                     <span class="fs-11 fw-bold ">Forma de Pago: </span>
                                                     <asp:Label runat="server" ID="lblFormaPago" Text='<%# FormaPago(Eval("tipo_cuota")) %>'></asp:Label>
                                                 </div>
                                             </div>
                                         </div>
                                     </div>
                                 </DetailRow>
                             </Templates>
                         </dx:BootstrapGridView>
                         <dx:BootstrapCallbackPanel ID="CallBGridPoliza" ClientInstanceName="CallBGridPoliza" runat="server" OnCallback="CallBGridPoliza_Callback"></dx:BootstrapCallbackPanel>
                     </asp:Panel>

                 </div>
             </div>


             <p class="links">
                 <asp:Label runat="server" ID="lblmensaje" Text="" CssClass="fs-10 text-danger"></asp:Label>


             </p>
         </div>

     </asp:Panel>

     <dx:BootstrapPopupControl ID="pCPersona" runat="server" ClientInstanceName="pCPersona" ShowHeader="false" ShowFooter="true" Modal="true" CloseAction="None" SettingsBootstrap-Sizing="Small">
         <SettingsAdaptivity Mode="Always" MaxWidth="500px" />
         <CssClasses Content="pt-1" />
         <ContentCollection>
             <dx:ContentControl>
                 <div class="row msg_button_class rounded-top-1">
                     <div class="col-12 fs-10 p-1 ">
                         <span>Busqueda de Persona por Nombre o Razón Social</span>
                     </div>
                 </div>
                 <div class="row">
                     <div class="col-4">
                         <div class="row">
                             <div class="col-12 text-center mt-2">
                                 <img src="../../../UI/img/search_user.png" />
                             </div>
                             <div class="col-12 text-center mt-2">
                                 <dx:BootstrapTextBox runat="server" ID="nomraz1" ClientInstanceName="nomraz1" NullText="" Width="150px">
                                     <CssClasses Input="form-control-sm fs-10" />
                                 </dx:BootstrapTextBox>
                             </div>
                             <div class="col-12 text-center mt-2">
                                 <dx:BootstrapButton ID="btnserper1" runat="server" AutoPostBack="false" Text="-->" OnClick="btnserper1_Click">
                                     <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                     <SettingsBootstrap RenderOption="None" />
                                 </dx:BootstrapButton>
                             </div>
                         </div>
                     </div>
                     <div class="col-8 mt-2">

                         <dx:BootstrapGridView ID="grdPersonas" EnableCallBacks="true" runat="server" KeyFieldName="id_per" ClientInstanceName="grdPersonas" OnDataBinding="grdPersonas_DataBinding">
                             <Settings ShowColumnHeaders="false" ShowTitlePanel="true" />
                             <SettingsText Title="Lista de Personas" />
                             <SettingsBehavior AllowFocusedRow="True" AllowClientEventsOnLoad="False" AllowSelectByRowClick="true" />
                             <ClientSideEvents RowClick="UpdateDetailGrid" />
                             <SettingsBootstrap Striped="true" />
                             <CssClasses PanelHeading="msg_button_class p-1 fs-10 " />
                             <SettingsPager NumericButtonCount="3">
                                 <PageSizeItemSettings Visible="false" Items="10, 20, 50" />
                             </SettingsPager>
                             <Columns>
                                 <dx:BootstrapGridViewDataColumn FieldName="nomraz" Width="200px" CssClasses-DataCell="fs-11"></dx:BootstrapGridViewDataColumn>

                             </Columns>

                         </dx:BootstrapGridView>
                     </div>
                 </div>
                 <div class="row">
                     <div class="col-12">
                     </div>
                 </div>
             </dx:ContentControl>
         </ContentCollection>
         <FooterContentTemplate>
             <dx:BootstrapButton runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" Text="Aceptar">
                 <SettingsBootstrap RenderOption="None" Sizing="Small" />
                 <CssClasses Control="msg_button_class" Text="fs-9" />
             </dx:BootstrapButton>
         </FooterContentTemplate>
     </dx:BootstrapPopupControl>

     <dx:BootstrapPopupControl ID="pCCompania" runat="server" ClientInstanceName="pCCompania" ShowHeader="false" ShowFooter="true" Modal="true" CloseAction="None" SettingsBootstrap-Sizing="Small">
         <SettingsAdaptivity Mode="Always" MaxWidth="600px" />
         <CssClasses Content="pt-1" />
         <ContentCollection>
             <dx:ContentControl>
                 <div class="row msg_button_class rounded-top-1">
                     <div class="col-12 fs-10 p-1 ">
                         <span>Busqueda de Persona por Nombre o Razón Social</span>
                     </div>
                 </div>
                 <div class="row">
                     <div class="col-4">
                         <div class="row">
                             <div class="col-12 text-center mt-2">
                                 <img src="../../../UI/img/search_user.png" />
                             </div>
                             <div class="col-12 text-center mt-2">
                                 <dx:BootstrapTextBox runat="server" ID="nomco1" ClientInstanceName="nomraz1" NullText="" Width="150px">
                                     <CssClasses Input="form-control-sm fs-10" />
                                 </dx:BootstrapTextBox>
                             </div>
                             <div class="col-12 text-center mt-2">
                                 <dx:BootstrapButton ID="btnnomco" runat="server" AutoPostBack="false" Text="-->" OnClick="btnnomco_Click">
                                     <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                     <SettingsBootstrap RenderOption="None" />
                                 </dx:BootstrapButton>
                             </div>
                         </div>
                     </div>
                     <div class="col-8 mt-2">

                         <dx:BootstrapGridView ID="grdCompania" EnableCallBacks="true" runat="server" KeyFieldName="id_spvs" ClientInstanceName="grdCompania" OnDataBinding="grdCompania_DataBinding">
                             <Settings ShowColumnHeaders="false" ShowTitlePanel="true" />
                             <SettingsText Title="Lista de Personas" />
                             <SettingsBehavior AllowFocusedRow="True" AllowClientEventsOnLoad="False" AllowSelectByRowClick="true" />
                             <ClientSideEvents RowClick="UpdateDetailGridCompania" />
                             <SettingsBootstrap Striped="true" />
                             <CssClasses PanelHeading="msg_button_class p-1 fs-10 " />
                             <SettingsPager NumericButtonCount="3">
                                 <PageSizeItemSettings Visible="false" Items="10, 20, 50" />
                             </SettingsPager>
                             <Columns>
                                 <dx:BootstrapGridViewDataColumn FieldName="nomraz" Width="200px" CssClasses-DataCell="fs-11"></dx:BootstrapGridViewDataColumn>

                             </Columns>

                         </dx:BootstrapGridView>
                     </div>
                 </div>
                 <div class="row">
                     <div class="col-12">
                     </div>
                 </div>
             </dx:ContentControl>
         </ContentCollection>
         <FooterContentTemplate>
             <dx:BootstrapButton runat="server" ID="btnAceptarCompania" OnClick="btnAceptarCompania_Click" Text="Aceptar">
                 <SettingsBootstrap RenderOption="None" Sizing="Small" />
                 <CssClasses Control="msg_button_class" Text="fs-9" />
             </dx:BootstrapButton>
         </FooterContentTemplate>
     </dx:BootstrapPopupControl>

     <dx:BootstrapPopupControl ID="pCProducto" runat="server" ClientInstanceName="pCProducto" ShowHeader="false" ShowFooter="true" Modal="true" CloseAction="None" SettingsBootstrap-Sizing="Small">
         <SettingsAdaptivity Mode="Always" MaxWidth="600px" />
         <CssClasses Content="pt-1" />
         <ContentCollection>
             <dx:ContentControl>
                 <div class="row msg_button_class rounded-top-1">
                     <div class="col-12 fs-10 p-1 ">
                         <span>Busqueda de Persona por Nombre o Razón Social</span>
                     </div>
                 </div>
                 <div class="row">
                     <div class="col-4">
                         <div class="row">
                             <div class="col-12 text-center mt-2">
                                 <img src="../../../UI/img/search_user.png" />
                             </div>
                             <div class="col-12 text-center mt-2">
                                 <dx:BootstrapTextBox runat="server" ID="desc_producto1" ClientInstanceName="desc_producto1" NullText="" Width="150px">
                                     <CssClasses Input="form-control-sm fs-10" />
                                 </dx:BootstrapTextBox>
                             </div>
                             <div class="col-12 text-center mt-2">
                                 <dx:BootstrapButton ID="btnProd" runat="server" AutoPostBack="false" Text="-->" OnClick="btnProd_Click">
                                     <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                     <SettingsBootstrap RenderOption="None" />
                                 </dx:BootstrapButton>
                             </div>
                         </div>
                     </div>
                     <div class="col-8 mt-2">

                         <dx:BootstrapGridView ID="grdProducto" EnableCallBacks="true" runat="server" KeyFieldName="id_producto" ClientInstanceName="grdProducto" OnDataBinding="grdProducto_DataBinding">
                             <Settings ShowColumnHeaders="false" ShowTitlePanel="true" />
                             <SettingsText Title="Lista de Personas" />
                             <SettingsBehavior AllowFocusedRow="True" AllowClientEventsOnLoad="False" AllowSelectByRowClick="true" />
                             <ClientSideEvents RowClick="UpdateDetailGridProducto" />
                             <SettingsBootstrap Striped="true" />
                             <CssClasses PanelHeading="msg_button_class p-1 fs-10 " />
                             <SettingsPager NumericButtonCount="3">
                                 <PageSizeItemSettings Visible="false" Items="10, 20, 50" />
                             </SettingsPager>
                             <Columns>
                                 <dx:BootstrapGridViewDataColumn FieldName="desc_prod" Width="200px" CssClasses-DataCell="fs-11"></dx:BootstrapGridViewDataColumn>

                             </Columns>

                         </dx:BootstrapGridView>
                     </div>
                 </div>
                 <div class="row">
                     <div class="col-12">
                     </div>
                 </div>
             </dx:ContentControl>
         </ContentCollection>
         <FooterContentTemplate>
             <dx:BootstrapButton runat="server" ID="btnAceptarProducto" OnClick="btnAceptarProducto_Click" Text="Aceptar">
                 <SettingsBootstrap RenderOption="None" Sizing="Small" />
                 <CssClasses Control="msg_button_class" Text="fs-9" />
             </dx:BootstrapButton>
         </FooterContentTemplate>
     </dx:BootstrapPopupControl>
 </div>
</asp:Content>
