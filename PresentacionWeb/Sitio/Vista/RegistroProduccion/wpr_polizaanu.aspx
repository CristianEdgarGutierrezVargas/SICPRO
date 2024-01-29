<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_polizaanu.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.RegistroProduccion.wpr_polizaanu" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="post">
       <div>                    

         <div class="container">
          <div class="row">
            <div class="col-md-3">      
                <h1 class="title"> <asp:Label ID="titulo" runat="server" Text="Renovacion de Polizas"></asp:Label></h1>
                <div class="entry">
                    <img src="../../../UI/img/renovar.png" alt="" width="128" height="128" class="left">
                </div>      
            </div>    
            <div class="col-md-9">
  
                <br /><br /><br />
                  <div class="row">
                    <div class="col-md-12">      
                        <span id="fechas" style="font-weight:bold;">Fechas</span>
                    </div>
                  </div>
  
                  <div class="row">
                      <div class="col-md-2">      
                        <span>Fecha de Emisión:</span>
                      </div>
                      <div class="col-md-3">      
                         <dx:BootstrapDateEdit ID="fc_emision" ClientInstanceName="fc_emision" runat="server" Width="100%">
                              <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                             <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="form_wgr_poliza">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                   <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                               </ValidationSettings>  
                               <ClientSideEvents Init="function(s,e){  
                                                          var dt1 = new Date();  
                                                          var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                          var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                          fc_emision.SetMinDate(new Date(dt3));  
                                                          fc_emision.SetMaxDate(new Date(dt2));  
                                                       }" />  
                         </dx:BootstrapDateEdit>
                      </div>
                      <div class="col-md-3">      
                         <span>Fecha de Recepción:</span>
                      </div>
                      <div class="col-md-3">      
                         <dx:BootstrapDateEdit ID="fc_recepcion" ClientInstanceName="fc_recepcion" runat="server" Width="100%">
                              <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                              <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="form_wgr_poliza">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                    <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                              </ValidationSettings>  
                                <ClientSideEvents Init="function(s,e){  
                                                           var dt1 = new Date();  
                                                           var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                           var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                           fc_recepcion.SetMinDate(new Date(dt3));  
                                                           fc_recepcion.SetMaxDate(new Date(dt2));  
                                                        }" /> 
                         </dx:BootstrapDateEdit>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-md-2">      
                         <span>Inicio Vigencia:</span>
                      </div>
                      <div class="col-md-3">      
                         <dx:BootstrapDateEdit ID="fc_inivig" ClientInstanceName="fc_inivig" runat="server" Width="100%">
                             <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                             <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="form_wgr_poliza">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                    <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                              </ValidationSettings>  
                                <ClientSideEvents Init="function(s,e){  
                                                           var dt1 = new Date();  
                                                           var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                           var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                           fc_inivig.SetMinDate(new Date(dt3));  
                                                           fc_inivig.SetMaxDate(new Date(dt2));  
                                                        }" /> 
                         </dx:BootstrapDateEdit>
                      </div>
                      <div class="col-md-3">      
                         <span>Fin Vigencia:</span>
                      </div>
                      <div class="col-md-3">     
                          <asp:Label ID="lblFinVigencia" runat="server" Text=""></asp:Label>
                          <%--<dx:BootstrapDateEdit ID="fc_finvig" ClientInstanceName="fc_finvig" runat="server" Width="100%">
                            <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                            <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="form_wgr_poliza">
                                   <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                             </ValidationSettings>  
                               <ClientSideEvents Init="function(s,e){  
                                                          var dt1 = new Date();  
                                                          var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                          var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                          fc_finvig.SetMinDate(new Date(dt3));  
                                                          fc_finvig.SetMaxDate(new Date(dt2));  
                                                       }" /> 
                        </dx:BootstrapDateEdit>--%>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-md-2">      
                         <span id="lblnumero">N° de Poliza:</span>
                      </div>
                      <div class="col-md-3">      
                         <asp:Label ID="lblNroPoliza" runat="server" Text=""></asp:Label>
                      </div>
                      <div class="col-md-3">      
                         <span id="lblnumliquida">Nº Liquidación:</span>
                      </div>
                      <div class="col-md-3">      
                         <dx:BootstrapTextBox ID="txtNroLiquidacion" runat="server" Width="100%">
                             <CssClasses Input="form-control-sm fs-10" />
                             <ValidationSettings SetFocusOnError="True" RequiredField-IsRequired="true" ValidationGroup="form_wgr_poliza">
                                   <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                               </ValidationSettings>
                         </dx:BootstrapTextBox>  
                      </div>
                  </div>
      
                  <div class="row">
                       <div class="col-md-2">      
                          <span>Asegurado :</span>
                       </div>
                       <div class="col-md-8">                            
                           <asp:Label ID="lblAsegurado" runat="server" Text=""></asp:Label>
                       </div>
                      <div class="col-md-1">
              
                      </div>
                   </div>
      
                  <div class="row">
                       <div class="col-md-2">      
                          <span id="lbldireccion">Dirección :</span>
                       </div>
                       <div class="col-md-8">   
                          <asp:Label ID="lblDireccion" runat="server" Text=""></asp:Label>
                       </div>
                      <div class="col-md-1">
            
                      </div>
                   </div>
      
                  <div class="row">
                      <div class="col-md-2">      
                          <span>Grupo :</span>
                      </div>
                      <div class="col-md-9">      
                          <asp:Label ID="lblGrupo" runat="server" Text=""></asp:Label>
                      </div>
                  </div>
      
                  <div class="row">
                      <div class="col-md-2">      
                          <span>Cia Aseguradora :</span>
                      </div>
                      <div class="col-md-9">      
                          <asp:Label ID="lblCiaAseg" runat="server" Text=""></asp:Label>
                      </div>
                  </div>
      
                  <div class="row">
                       <div class="col-md-2">      
                           <span>Producto :</span>
                       </div>
                       <div class="col-md-9">      
                           <asp:Label ID="lblProducto" runat="server" Text=""></asp:Label>
                       </div>
                   </div>   
      
                  <div class="row">
                       <div class="col-md-2">      
                          <span>Ejecutivo:</span>
                       </div>
                       <div class="col-md-9">      
                            <dx:BootstrapComboBox ID="cmbEjecutivo" runat="server" ValueType="System.String" Width="100%">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                <ValidationSettings SetFocusOnError="True" ValidationGroup="form_wgr_poliza" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                  <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>
                       </div>
                   </div>
      
                  <div class="row">
                      <div class="col-md-2">      
                          <span>Agente Cartera:</span>
                      </div>
                      <div class="col-md-9">      
                          <asp:Label ID="lblAgente" runat="server" Text=""></asp:Label>
                      </div>
                  </div>
     
                       
                  <div class="row">
                     <div class="col-md-2">      
                         <span>Prima Total:</span>
                     </div>
                     <div class="col-md-3" style="text-align:right">      
                          <asp:Label ID="lblPrimaTotal" runat="server" Text=""></asp:Label>
                     </div>
                    <div class="col-md-1">      
                          <span>Divisa:</span>
                      </div>
                      <div class="col-md-3">      
                           <asp:Label ID="lblDivisa" runat="server" Text=""></asp:Label>
                      </div>
                 </div>
                 <div class="row">
                    <div class="col-md-2">      
                        <span id="lblprima_bruta">Prima Total Anulada:</span>
                    </div>
                    <div class="col-md-3">      
                         <dx:BootstrapSpinEdit ID="txtPrimaTotalAnulada" runat="server" Number="0" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float" ValidationGroup="form_wgr_poliza">
                            <SpinButtons ShowLargeIncrementButtons="true" />
                             <CssClasses Input="form-control-sm fs-10" />
                               <ValidationSettings SetFocusOnError="True" RequiredField-IsRequired="true" ValidationGroup="form_wgr_poliza">
                                     <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                               </ValidationSettings>
                         </dx:BootstrapSpinEdit>
                    </div>
                    <div class="col-md-1">      
                         <span>Divisa:</span>
                    </div>
                    <div class="col-md-3">      
                          <asp:Label ID="lblDivisaAnulada" runat="server" Text=""></asp:Label>
                    </div>
                 </div>
      
      
                                          
                  <div class="row">
                      <div class="col-md-2">      
                          <span id="lblmat_aseg">Observaciones:</span>
                      </div>
                      <div class="col-md-9">      
                           <dx:BootstrapMemo ID="txtObservaciones" runat="server" Rows="3" Width="100%" ValidationGroup="form_wgr_poliza"></dx:BootstrapMemo>
                      </div>
                  </div>
      
                  

                  <div class="row">
                      <div class="col-md-4">      

                      </div>
                      <div class="col-md-7">   
                          <dx:ASPxButton ID="btnNuevo" runat="server" Text="Nuevo" CssClass="msg_button_class" OnClick="btnNuevo_Click" CausesValidation="false"></dx:ASPxButton>                          
                           <dx:ASPxButton ID="btnGuardar" runat="server" Text="Guardar" CssClass="msg_button_class" OnClick="btnGuardar_Click" CausesValidation="true" ValidationGroup="form_wgr_poliza"></dx:ASPxButton>                         
                          <dx:ASPxButton ID="btnSalir" runat="server" Text="Salir" CssClass="msg_button_class" OnClick="btnSalir_Click"></dx:ASPxButton>             
                      </div>
                  </div>

            </div>
          </div>
        </div>

        <p class="links">
             <asp:Label ID="lblmensaje" runat="server" Text="Introduzca Valores" CssClass="error"></asp:Label>  
         </p>
       </div>
    </div>
</asp:Content>
