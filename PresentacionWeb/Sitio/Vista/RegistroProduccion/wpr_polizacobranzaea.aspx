<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_polizacobranzaea.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.RegistroProduccion.wpr_polizacobranzaea" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
     <script>
     function openModal() {
         var myModal = new bootstrap.Modal(document.getElementById('exampleModal'), {});
         myModal.show();
     }
     </script>
    <div class="post">
       <div>                    

        <asp:HiddenField ID="id_clamov" runat="server" />
        <asp:HiddenField ID="por_pagar" runat="server" />
        <asp:HiddenField ID="cuota_neta1" runat="server" />
        <asp:HiddenField ID="cuota_comis1" runat="server" />
        <div class="container">
          <div class="row">
            <div class="col-md-3">      
                <h1 class="title"> <asp:Label ID="titulo" runat="server" Text="Datos de Poliza Incluida (Módulo de Cobranzas)"></asp:Label></h1>
                <div class="entry">
                    <img src="../../../UI/img/aplicacion.png" alt="" width="128" height="128" class="left">
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
                          <asp:Label ID="lblfc_finvig" runat="server" Text=""></asp:Label>
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
                          <span>Tipo Poliza:</span>
                      </div>
                      <div class="col-md-9">      
                           <asp:Label ID="lblTipoPoliza" runat="server" Text=""></asp:Label>
                      </div>
                  </div>
              
                  <div class="row">
                        <div class="col-md-2">      
                           <span>Prima Total:</span>
                        </div>
                        <div class="col-md-2">      
                            <dx:BootstrapSpinEdit ID="txtPrimaBruta" Width="160px" runat="server" Number="0" MinValue="-100000" MaxValue="100000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                <SpinButtons ShowLargeIncrementButtons="true" />
                            </dx:BootstrapSpinEdit>
                        </div>
                        <div class="col-md-2">      
                            <span>Divisa:</span>
                        </div>
                        <div class="col-md-2">      
                            <asp:Label ID="lblDivisa" runat="server" Text=""></asp:Label>
                        </div>                       
                   </div>
              
                  <div class="row">
                     <div class="col-md-2">      
                         <span>Prima Neta:</span>
                     </div>
                     <div class="col-md-2">      
                        <dx:BootstrapSpinEdit ID="txtPrimaNeta" Width="160px" runat="server" Number="0" MinValue="-100000" MaxValue="100000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                            <SpinButtons ShowLargeIncrementButtons="true" />
                        </dx:BootstrapSpinEdit>
                     </div>
                  </div>
                  
                  <div class="row">
                       <div class="col-md-2">      
                           <span>Porcentaje:</span>
                       </div>
                       <div class="col-md-2">      
                            <dx:BootstrapSpinEdit ID="txtPorcentaje" Width="70px" runat="server" Number="0" MinValue="0" MaxValue="100" Increment="1" NumberType="Float">    
                            </dx:BootstrapSpinEdit>
  
                       </div>
                    </div>
                    
                  <div class="row">
                       <div class="col-md-2">      
                           <span>Comision:</span>
                       </div>
                       <div class="col-md-2">      
                            <dx:BootstrapSpinEdit ID="txtComision" Width="90px" runat="server" Number="0" MinValue="-100000" MaxValue="100000" Increment="1" NumberType="Float">    
                            </dx:BootstrapSpinEdit>
                       </div>
                  </div>                                     
                                            
                  <div class="row">
                      <div class="col-md-2">      
                          <span id="lblmat_aseg">Mat. Asegurada:</span>
                      </div>
                      <div class="col-md-9">      
                           <dx:BootstrapMemo ID="txtMatAseg" runat="server" Rows="3" Width="100%"></dx:BootstrapMemo>
                      </div>
                  </div>
              
                  <asp:Panel ID="pnlDatosCobranza" runat="server">
                    <fieldset>
                      <legend><h4>Datos de Cobranza:</h4></legend>
 
                      <div class="row">
                         <div class="col-md-2">      
                            <span>Nro Liquidacion:</span>
                         </div>
                         <div class="col-md-4">      
                              <dx:BootstrapComboBox ID="cmbNroLiquidacion" runat="server" ValueType="System.String" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="cmbNroLiquidacion_SelectedIndexChanged">
                                  <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                  <ValidationSettings SetFocusOnError="True" ValidationGroup="form_wgr_poliza" ErrorDisplayMode="ImageWithText" CausesValidation="false">
                                    <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                  </ValidationSettings>
                              </dx:BootstrapComboBox>
                         </div>
                          <div class="col-md-2">      
                               <span>Nro de Cuotas:</span>
                            </div>
                            <div class="col-md-4">      
                                 <dx:BootstrapComboBox ID="cmbNroCuotas" runat="server" ValueType="System.String" Width="100%" OnSelectedIndexChanged="cmbNroCuotas_SelectedIndexChanged" AutoPostBack="True">
                                     <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                     <ValidationSettings SetFocusOnError="True" ValidationGroup="form_wgr_poliza" ErrorDisplayMode="ImageWithText" CausesValidation="false">
                                       <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                     </ValidationSettings>
                                 </dx:BootstrapComboBox>
                            </div>
                     </div>
                      <div class="row">
                            <div class="col-md-2">      
                               <span>Fecha de Pago:</span>
                            </div>
                            <div class="col-md-4"> 
                                <dx:BootstrapDateEdit ID="txtFechaPago" ClientInstanceName="txtFechaPago" runat="server" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="form_wgr_poliza">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                           <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                                     </ValidationSettings>  
                                       <ClientSideEvents Init="function(s,e){  
                                                                  var dt1 = new Date();  
                                                                  var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                                  var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                  txtFechaPago.SetMinDate(new Date(dt3));  
                                                                  txtFechaPago.SetMaxDate(new Date(dt2));  
                                                               }" /> 
                                </dx:BootstrapDateEdit>
                            </div>
                             <div class="col-md-2">      
                                  <span>Cuota:</span>
                               </div>
                               <div class="col-md-4">     
                                    
                                   <dx:BootstrapSpinEdit ID="txtCuotaTotal" Width="70px" runat="server" Number="0" MinValue="0" MaxValue="100" Increment="1" NumberType="Float">    
                                       <CssClasses Input="form-control-sm fs-10" />
                                      <ValidationSettings SetFocusOnError="True" RequiredField-IsRequired="true" ValidationGroup="form_wgr_poliza">
                                          <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                                      </ValidationSettings>
                                    </dx:BootstrapSpinEdit>
                               </div>
                        </div>
                      <div class="row">
                         <div class="col-md-2">      
                            <span>Monto Pago:</span>
                         </div>
                         <div class="col-md-4">      
                              <dx:BootstrapSpinEdit ID="txtMontoPago" Width="70px" runat="server" Number="0" MinValue="0" MaxValue="100" Increment="1" NumberType="Float">    
                                  <CssClasses Input="form-control-sm fs-10" />
                              </dx:BootstrapSpinEdit>
                         </div>
                          <div class="col-md-2">      
                               <span>Monto Excluido:</span>
                            </div>
                            <div class="col-md-4">      
                              <dx:BootstrapSpinEdit ID="txtMontoExcluido" Width="70px" runat="server" Number="0" MinValue="0" MaxValue="100" Increment="1" NumberType="Float">    
                                  <CssClasses Input="form-control-sm fs-10" />
                              </dx:BootstrapSpinEdit> 
                            </div>
                     </div>
                      <div class="row">
                         <div class="col-md-2">      
                            <span>Monto Pago:</span>
                         </div>
                         <div class="col-md-4">      
                              <dx:BootstrapSpinEdit ID="txtDevolucion" Width="70px" runat="server" Number="0" MinValue="0" MaxValue="100" Increment="1" NumberType="Float">    
                                  <CssClasses Input="form-control-sm fs-10" />
                              </dx:BootstrapSpinEdit>
                         </div>
                          <div class="col-md-2">      
                               <dx:ASPxButton ID="btnVerificar" runat="server" Text="Verificar" CssClass="msg_button_class" OnClick="btnVerificar_Click" ></dx:ASPxButton>                                                    
                            </div>
                            <div class="col-md-4">      
                               <dx:ASPxButton ID="btnCuotas" runat="server" Text="Guardar Cuota" CssClass="msg_button_class" OnClick="btnCuotas_Click" ></dx:ASPxButton>                                                    
                            </div>
                     </div>
                      <div class="row">
                        <div class="col-md-2">      
                           <span>Exclusion Total:</span>
                        </div>
                        <div class="col-md-2">      
                             <dx:BootstrapSpinEdit ID="txtExclusionTotal" runat="server" Number="0" MinValue="0" MaxValue="100" Increment="1" NumberType="Float">    
                                 <CssClasses Input="form-control-sm fs-10" />
                             </dx:BootstrapSpinEdit>
                        </div>
                        <div class="col-md-2">      
                              <span>Exclusion Neta:</span>
                        </div>
                        <div class="col-md-2">      
                             <dx:BootstrapSpinEdit ID="txtExclusionNeta" runat="server" Number="0" MinValue="0" MaxValue="100" Increment="1" NumberType="Float">    
                                 <CssClasses Input="form-control-sm fs-10" />
                             </dx:BootstrapSpinEdit>
                        </div>
                        <div class="col-md-2">      
                             <span>Comision Exclusion:</span>
                        </div>
                        <div class="col-md-2">      
                            <dx:BootstrapSpinEdit ID="txtComisionExclusion" runat="server" Number="0" MinValue="0" MaxValue="100" Increment="1" NumberType="Float">    
                                <CssClasses Input="form-control-sm fs-10" />
                            </dx:BootstrapSpinEdit>
                        </div>
                    </div>
                    </fieldset>
                  </asp:Panel>

                  <div class="row">
                      <div class="col-md-4">      
    
                      </div>
                      <div class="col-md-7">   
                          <dx:ASPxButton ID="btnNuevo" runat="server" Text="Nuevo" CssClass="msg_button_class" OnClick="btnNuevo_Click"></dx:ASPxButton>
                           <dx:ASPxButton ID="btnGuardar" runat="server" Text="Cuotas" CssClass="msg_button_class" OnClick="btnGuardar_Click" ></dx:ASPxButton>                          
                          
                          <dx:ASPxButton ID="btnMemo" runat="server" Text="Memo" CssClass="msg_button_class" OnClick="btnMemo_Click" ></dx:ASPxButton>                          
                          <dx:ASPxButton ID="btnSalir" runat="server" Text="Salir" CssClass="msg_button_class" OnClick="btnSalir_Click"></dx:ASPxButton>
                          
                      </div>
                  </div>
            </div>
            </div>
          </div>
        </div>

        <p class="links">
             <asp:Label ID="lblmensaje" runat="server" Text="Introduzca Valores" CssClass="error"></asp:Label>  
         </p>
       </div>


<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-xl">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Reporte</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
         <div class="container">
           <div class="row">
               <div class="col-md-12">
                   <iframe id="ifrReport" runat="server" src="HTMLPage1.htm" height="600" width="100%"></iframe>
               </div>
           </div>
        </div>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Cerrar Reporte</button>
      </div>
    </div>
  </div>
</div>

</asp:Content>
