<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wco_reportes.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ReportesSistema.wco_reportes" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">

    <script type="text/javascript">    
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

    function UpdateDetailGridDireccion(s, e) {
        var index = e.visibleIndex;

        CallBDireccion.PerformCallback(index);
    }
    function OnEndCallbackDireccion(s, e) {

        pCDireccion.Hide();

    }

        function openModal() {
            var myModal = new bootstrap.Modal(document.getElementById('exampleModal'), {});
            myModal.show();
        }
    $(document).ready(function () {
        var st = $(this).find("input[id*='hidtab']").val();
        if (st == null)
            st = 0;

        //$('[id$=tabs]').tabs({ selected: st });
        console.log(st);
        var someTabTriggerEl = document.querySelector('#' + st + '')
        var tab = new bootstrap.Tab(someTabTriggerEl)
        tab.show()
    });
       
    </script>
    <div class="post">
      <div>         
        <div class="container">
         <div class="row">
           <div class="col-md-12">      
               <h1 class="title"><b> <asp:Label ID="titulo" runat="server" Text="Reportes de Cobranza"></asp:Label></b></h1>                    
           </div>    
         </div> 
         <br />
         <div class="row">
          <div class="col-md-12">   
                <asp:HiddenField ID="hidtab" Value="v-pills-clientes-tab" runat="server" />

                <asp:Button ID="clientes_tab" style="display:none" runat="server" OnClick="clientes_tab_Click"/>
                <asp:Button ID="vcmto_tab" style="display:none" runat="server" OnClick="vcmto_tab_Click"/>
                <asp:Button ID="pagos_tab" style="display:none" runat="server" OnClick="pagos_tab_Click"/>
                <asp:Button ID="estado_tab" style="display:none" runat="server" OnClick="estado_tab_Click"/>
                <asp:Button ID="reimp_tab" style="display:none" runat="server" OnClick="reimp_tab_Click"/>
                <asp:Button ID="cobranzas_tab" style="display:none" runat="server" OnClick="cobranzas_tab_Click"/>
                <asp:Button ID="recibos_tab" style="display:none" runat="server" OnClick="recibos_tab_Click"/>

             <div class="d-flex align-items-start">
              <div class="nav flex-column nav-pills me-3" id="v-pills-tab" role="tablist" aria-orientation="vertical" style="width:200px">
                <button class="nav-link" onclick="document.getElementById('<%= clientes_tab.ClientID %>').click()" id="v-pills-clientes-tab" data-bs-toggle="pill" data-bs-target="#v-pills-clientes" type="button" role="tab" aria-controls="v-pills-clientes" aria-selected="true">Est. Cta. Clientes</button>
                <button class="nav-link" onclick="document.getElementById('<%= vcmto_tab.ClientID %>').click()" id="v-pills-vcmto-tab" data-bs-toggle="pill" data-bs-target="#v-pills-vcmto" type="button" role="tab" aria-controls="v-pills-vcmto" aria-selected="false">Vcmto. Días</button>
                <button class="nav-link" onclick="document.getElementById('<%= pagos_tab.ClientID %>').click()" id="v-pills-pagos-tab" data-bs-toggle="pill" data-bs-target="#v-pills-pagos" type="button" role="tab" aria-controls="v-pills-pagos" aria-selected="false">Pagos Pend. Cias.</button>
                <button class="nav-link" onclick="document.getElementById('<%= estado_tab.ClientID %>').click()" id="v-pills-estado-tab" data-bs-toggle="pill" data-bs-target="#v-pills-estado" type="button" role="tab" aria-controls="v-pills-estado" aria-selected="false">Est.Cta. Pago Cia.</button>
                <button class="nav-link" onclick="document.getElementById('<%= reimp_tab.ClientID %>').click()" id="v-pills-reimp-tab" data-bs-toggle="pill" data-bs-target="#v-pills-reimp" type="button" role="tab" aria-controls="v-pills-reimp" aria-selected="false">Reimp.Liq.Cob.</button>
                <button class="nav-link" onclick="document.getElementById('<%= cobranzas_tab.ClientID %>').click()" id="v-pills-cobranzas-tab" data-bs-toggle="pill" data-bs-target="#v-pills-cobranzas" type="button" role="tab" aria-controls="v-pills-cobranzas" aria-selected="false">Cobranzas a Fecha</button>
                <button class="nav-link" onclick="document.getElementById('<%= recibos_tab.ClientID %>').click()" id="v-pills-recibos-tab" data-bs-toggle="pill" data-bs-target="#v-pills-recibos" type="button" role="tab" aria-controls="v-pills-recibos" aria-selected="false">Recibos X Asignar</button>
              </div>
              <div class="tab-content" id="v-pills-tabContent" style="width:100%">
                <div class="tab-pane fade" id="v-pills-clientes" role="tabpanel" aria-labelledby="v-pills-clientes-tab">
                    <div style="padding:20px">
                        <div class="row">                         
                          <div class="col-md-2">Cliente</div>
                          <div class="col-md-8">
                              <div class="d-flex">
                                    <div class="flex-grow-1">
                                        <dx:BootstrapCallbackPanel ID="CallBPersona" ClientInstanceName="CallBPersona" runat="server" OnCallback="CallBPersona_Callback">
                                            <ClientSideEvents EndCallback="OnEndCallbackPersona"></ClientSideEvents>
                                            <ContentCollection>
                                                <dx:ContentControl>
                                                    <dx:BootstrapTextBox runat="server" ID="nomraz" NullText="" Width="100%">
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

                         <div class="row">                         
                             <div class="col-md-2">Compañia</div>
                             <div class="col-md-8">
                                 <dx:BootstrapComboBox ID="cmbCompaniaClientes" runat="server" ValueType="System.String" Width="100%">
                                     <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                     <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_produccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                       <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                     </ValidationSettings>
                                 </dx:BootstrapComboBox>
                             </div>
                         </div>
                        <div class="row">                         
                            <div class="col-md-2">Cartera</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbCarteraClientes" runat="server" ValueType="System.String" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_produccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                        </div>

                        <div class="row">                         
                             <div class="col-md-2">Póliza :</div>
                             <div class="col-md-3">
                                 <dx:BootstrapTextBox ID="txtNumPolizaClientes" runat="server" Width="100%">
                                       <CssClasses Input="form-control-sm fs-10" />
                                       <ValidationSettings SetFocusOnError="True" RequiredField-IsRequired="true" ValidationGroup="wpr_tab_memo">
                                             <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                                         </ValidationSettings>
                                   </dx:BootstrapTextBox>  
                             </div>
                        </div>
                        <div class="row">   
                           <div class="col-md-2">Liquidación :</div>
                           <div class="col-md-3">
                               <dx:BootstrapTextBox ID="txtNumLiquidacionClientes" runat="server" Width="100%">
                                     <CssClasses Input="form-control-sm fs-10" />
                                     <ValidationSettings SetFocusOnError="True" RequiredField-IsRequired="true" ValidationGroup="wpr_tab_memo">
                                           <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                                       </ValidationSettings>
                                 </dx:BootstrapTextBox>  
                           </div>
                        </div>
                        <div class="row">
                             <div class="col-md-3">      
                                 <span id="lbltipo_cuota">¿Historico?</span>
                             </div>
                             <div class="col-md-8">      
                                 <dx:ASPxRadioButtonList ID="historicoCliente" runat="server" RepeatDirection="Horizontal" Border-BorderStyle="None">
                                    <Items>
                                        <dx:ListEditItem Text="Si" Value="True" Selected></dx:ListEditItem>
                                        <dx:ListEditItem Text="No" Value="False"></dx:ListEditItem>
                                    </Items>
                                </dx:ASPxRadioButtonList>
                             </div>
                         </div>
                        <br />
                        <div class="row">
                              <div class="col-md-4">      

                              </div>
                              <div class="col-md-7">   
                                 <dx:ASPxButton ID="btnGenerarReporteClientes" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteClientes_Click" CausesValidation="true"></dx:ASPxButton>                            
                              </div>
                        </div>
                    </div>
                </div>
                <div class="tab-pane fade" id="v-pills-vcmto" role="tabpanel" aria-labelledby="v-pills-vcmto-tab">
                    <div style="padding:20px">
                          <div class="row">                         
                            <div class="col-md-2">Cartera</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbCarteraVcmto" runat="server" ValueType="System.String" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_vcmto" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                          </div>
                          <div class="row">                         
                            <div class="col-md-2">Sucursal</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbSucursalVcmto" runat="server" ValueType="System.String" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_vcmto" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                          </div>
                            <div class="row">                         
                              <div class="col-md-2">Compañia</div>
                              <div class="col-md-8">
                                  <dx:BootstrapComboBox ID="cmbCompaniaVcmto" runat="server" ValueType="System.String" Width="100%">
                                      <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                      <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_vcmto" ErrorDisplayMode="ImageWithText" CausesValidation="False">
                                        <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                      </ValidationSettings>
                                  </dx:BootstrapComboBox>
                              </div>
                            </div>
                            <div class="row">                         
                              <div class="col-md-2">Grupo</div>
                              <div class="col-md-8">
                                  <dx:BootstrapComboBox ID="cmbGrupoVcmto" runat="server" ValueType="System.String" Width="100%">
                                      <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                      <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_vcmto" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                        <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                      </ValidationSettings>
                                  </dx:BootstrapComboBox>
                              </div>
                            </div>
                            <div class="row">                         
                                <div class="col-md-2">Vencidas / Vencer :</div>
                                <div class="col-md-3">
                                    <dx:BootstrapTextBox ID="txtVenc1Vcmto" runat="server" Width="100%">
                                          <CssClasses Input="form-control-sm fs-10" />
                                          <ValidationSettings SetFocusOnError="True" RequiredField-IsRequired="true" ValidationGroup="wpr_tab_vcmto">
                                                <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                                            </ValidationSettings>
                                      </dx:BootstrapTextBox>  
                                </div>
                                Y
                                <div class="col-md-3">
                                      <dx:BootstrapTextBox ID="txtVenc2Vcmto" runat="server" Width="100%">
                                            <CssClasses Input="form-control-sm fs-10" />
                                            <ValidationSettings SetFocusOnError="True" RequiredField-IsRequired="true" ValidationGroup="wpr_tab_vcmto">
                                                  <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                                              </ValidationSettings>
                                        </dx:BootstrapTextBox>  
                                  </div>
                            </div>
                            <div class="row">                         
                              <div class="col-md-2">Dias Entre</div>
                              <div class="col-md-8">
                                  <dx:BootstrapComboBox ID="cmbDiasVcmto" runat="server" Width="100%" SelectedIndex="0">
                                      <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                      <Items>
                                          <dx:BootstrapListEditItem Selected="True" Text="Vencidas" Value="1"></dx:BootstrapListEditItem>
                                          <dx:BootstrapListEditItem Text="Por Vencer" Value="2"></dx:BootstrapListEditItem>
                                      </Items>

                                      <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_vcmto" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                        <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                      </ValidationSettings>
                                  </dx:BootstrapComboBox>
                              </div>
                            </div>

                          <div class="row">                         
                              <div class="col-md-2">Listado al :</div>
                              <div class="col-md-3">
                                  <dx:BootstrapDateEdit ID="listadoVcmto" ClientInstanceName="listadoVcmto" runat="server" Width="100%">
                                       <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                      <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="wpr_tab_vcmto">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                            <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                                        </ValidationSettings>  
                                        <ClientSideEvents Init="function(s,e){  
                                                                   var dt1 = new Date();  
                                                                   var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                                   var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                   listadoVcmto.SetMinDate(new Date(dt3));  
                                                                   listadoVcmto.SetMaxDate(new Date(dt2));  
                                                                }" />  
                                  </dx:BootstrapDateEdit>  
                              </div>
                          </div>
                        <br />
                        <div class="row">
                              <div class="col-md-4">      

                              </div>
                              <div class="col-md-7">   
                                 <dx:ASPxButton ID="btnGenerarReporteVcmto" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteVcmto_Click" CausesValidation="true"></dx:ASPxButton>                            
                              </div>
                        </div>

                    </div>
                </div>
                <div class="tab-pane fade" id="v-pills-pagos" role="tabpanel" aria-labelledby="v-pills-pagos-tab">
                    <div style="padding:20px">
                        <div class="row">                         
                            <div class="col-md-2">Sucursal</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbSucursalPagos" runat="server" ValueType="System.String" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_cartera" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                              <div class="col-md-4">      

                              </div>
                              <div class="col-md-7">   
                                 <dx:ASPxButton ID="btnGenerarReportePagos" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReportePagos_Click" CausesValidation="true"></dx:ASPxButton>                            
                              </div>
                        </div>
                    </div>
                </div>
                <div class="tab-pane fade" id="v-pills-estado" role="tabpanel" aria-labelledby="v-pills-estado-tab">
                    <div style="padding:20px">
                        <div class="row">                         
                            <div class="col-md-2">Sucursal</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbSucursalEstado" runat="server" ValueType="System.String" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_cartera" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                        </div>
                        <div class="row">                         
                              <div class="col-md-2">Compañia</div>
                              <div class="col-md-8">
                                  <dx:BootstrapComboBox ID="cmbCompaniaEstado" runat="server" ValueType="System.String" Width="100%">
                                      <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                      <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_vcmto" ErrorDisplayMode="ImageWithText" CausesValidation="False">
                                        <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                      </ValidationSettings>
                                  </dx:BootstrapComboBox>
                              </div>
                        </div>
                        <br />
                        <div class="row">
                              <div class="col-md-4">      

                              </div>
                              <div class="col-md-7">   
                                 <dx:ASPxButton ID="btnGenerarReporteEstado" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteEstado_Click" CausesValidation="true"></dx:ASPxButton>                            
                              </div>
                        </div>
                    </div>
                </div>
                <div class="tab-pane fade" id="v-pills-reimp" role="tabpanel" aria-labelledby="v-pills-reimp-tab">
                    <div style="padding:20px">
                        <div class="row">                         
                            <div class="col-md-2">Sucursal</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbSucursalReimp" runat="server" ValueType="System.String" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="cmbSucursalReimp_SelectedIndexChanged" >
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_cartera" ErrorDisplayMode="ImageWithText" CausesValidation="false">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                        </div>

                         <div class="row">                         
                             <div class="col-md-2">Cobrador</div>
                             <div class="col-md-8">
                                 <dx:BootstrapComboBox ID="cmbCobradorReimp" runat="server" ValueType="System.String" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="cmbCobradorReimp_SelectedIndexChanged">
                                     <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                     <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_cartera" ErrorDisplayMode="ImageWithText" CausesValidation="false">
                                       <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                     </ValidationSettings>
                                 </dx:BootstrapComboBox>
                             </div>
                         </div>

                         <div class="row">                         
                             <div class="col-md-2">Nro Liquidacion</div>
                             <div class="col-md-8">
                                 <dx:BootstrapComboBox ID="cmbLiquidacionReimp" runat="server" ValueType="System.String" Width="100%">
                                     <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                     <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_cartera" ErrorDisplayMode="ImageWithText" CausesValidation="false">
                                       <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                     </ValidationSettings>
                                 </dx:BootstrapComboBox>
                             </div>
                         </div>
                        <br />
                        <div class="row">
                              <div class="col-md-4">      

                              </div>
                              <div class="col-md-7">   
                                 <dx:ASPxButton ID="btnGenerarReporteReimp" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteReimp_Click" CausesValidation="true"></dx:ASPxButton>                            
                              </div>
                        </div>
                    </div>
                </div>
                <div class="tab-pane fade" id="v-pills-cobranzas" role="tabpanel" aria-labelledby="v-pills-cobranzas-tab">
                    <div style="padding:20px">
                        <div class="row">                         
                            <div class="col-md-2">Sucursal</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbSucursalCobranza" runat="server" ValueType="System.String" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_cartera" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                        </div>

                        <div class="row">                         
                              <div class="col-md-2">Fecha de Inicio :</div>
                              <div class="col-md-3">
                                  <dx:BootstrapDateEdit ID="fechaInicioCobranza" ClientInstanceName="fechaInicioCobranza" runat="server" Width="100%">
                                       <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                      <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="wpr_tab_produccion">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                            <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                                        </ValidationSettings>  
                                        <ClientSideEvents Init="function(s,e){  
                                                                   var dt1 = new Date();  
                                                                   var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                                   var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                   fechaInicioCobranza.SetMinDate(new Date(dt3));  
                                                                   fechaInicioCobranza.SetMaxDate(new Date(dt2));  
                                                                }" />  
                                  </dx:BootstrapDateEdit>  
                              </div>
                          </div>

                        <div class="row">
                              <div class="col-md-2">Fecha de Fin :</div>
                              <div class="col-md-3">
                                  <dx:BootstrapDateEdit ID="fechaFinCobranza" ClientInstanceName="fechaFinCobranza" runat="server" Width="100%">
                                       <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                      <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="wpr_tab_produccion">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                            <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                                        </ValidationSettings>  
                                        <ClientSideEvents Init="function(s,e){  
                                                                   var dt1 = new Date();  
                                                                   var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                                   var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                   fechaFinCobranza.SetMinDate(new Date(dt3));  
                                                                   fechaFinCobranza.SetMaxDate(new Date(dt2));  
                                                                }" />  
                                  </dx:BootstrapDateEdit>  
                                </div>
                          </div>
                        <br />
                        <div class="row">
                              <div class="col-md-4">      

                              </div>
                              <div class="col-md-7">   
                                 <dx:ASPxButton ID="btnGenerarReporteCobranzas" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteCobranzas_Click" CausesValidation="true"></dx:ASPxButton>                            
                              </div>
                        </div>
                    </div>
                </div>
                <div class="tab-pane fade" id="v-pills-recibos" role="tabpanel" aria-labelledby="v-pills-recibos-tab">
                    <div style="padding:20px">
                        <div class="row">                         
                            <div class="col-md-2">Sucursal</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbSucursalRecibos" runat="server" ValueType="System.String" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_cartera" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                              <div class="col-md-4">      

                              </div>
                              <div class="col-md-7">   
                                 <dx:ASPxButton ID="btnGenerarReporteRecibos" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteRecibos_Click" CausesValidation="true"></dx:ASPxButton>                            
                              </div>
                        </div>
                    </div>
                </div>
              </div>
            </div>
          </div>    
        </div> 
         <br />
        </div>
      </div>
    </div>

   <dx:BootstrapPopupControl ID="pCPersona" runat="server" ClientInstanceName="pCPersona" ShowHeader="false" ShowFooter="true" Modal="true" CloseAction="None" SettingsBootstrap-Sizing="Small">
        <SettingsBootstrap Sizing="Small"></SettingsBootstrap>

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
                                <dx:BootstrapGridViewDataColumn FieldName="nomraz" Width="200px" CssClasses-DataCell="fs-11">
                                    <CssClasses DataCell="fs-11"></CssClasses>
                                </dx:BootstrapGridViewDataColumn>

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

        <!-- Modal -->
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
