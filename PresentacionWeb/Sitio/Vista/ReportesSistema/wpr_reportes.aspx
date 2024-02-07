<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_reportes.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ReportesSistema.wpr_reportes" %>

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

        //function UpdateDetailGridCompania(s, e) {
        //    var index = e.visibleIndex;

        //    CallBCompania.PerformCallback(index);
        //}
        //function OnEndCallbackCompania(s, e) {

        //    pCCompania.Hide();

        //}
        //function UpdateDetailGridProducto(s, e) {
        //    var index = e.visibleIndex;

        //    CallBProducto.PerformCallback(index);
        //}
        //function OnEndCallbackProducto(s, e) {

        //    pCProducto.Hide();

        //}

        //function UpdateDetailGridDireccion(s, e) {
        //    var index = e.visibleIndex;

        //    CallBDireccion.PerformCallback(index);
        //}
        //function OnEndCallbackDireccion(s, e) {

        //    pCDireccion.Hide();

        //}

        //function activeTab(tab) {
        //    console.log(tab);
        //    ///$('.nav-tabs a[href="#' + tab + '"]').tab('show');
        //    //var someTabTriggerEl = document.querySelector('#nav-produccion-tab')
        //    //var someTabTriggerEl = document.querySelector('#' + tab + '')
        //    var someTabTriggerEl = document.querySelector('#' + tab + '')
        //    var tab = new bootstrap.Tab(someTabTriggerEl)
        //    tab.show()
        //};

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

        <%--function fncProd() {
            document.getElementById('<%= produccion.ClientID %>').click();
        }--%>
    </script>
       <div class="post">
         <div>         
           <div class="container">
            <div class="row">
              <div class="col-md-12">      
                  <h1 class="title"> <asp:Label ID="titulo" runat="server" Text="Reportes de Produccion"></asp:Label></h1>
                  <div class="entry">
                      <img src="../../../UI/img/edit.png" alt="" width="128" height="128" class="left">
                  </div>      
              </div>    
            </div>  

            <div class="row">
              <div class="col-md-12"> 
                  <asp:HiddenField ID="hidtab" Value="nav-clientes-tab" runat="server" />
                  <asp:Button ID="clientes_tab" style="display:none" runat="server" OnClick="clientes_tab_Click"/>
                  <asp:Button ID="grupos_tab" style="display:none" runat="server" OnClick="grupos_tab_Click"/>
                  <asp:Button ID="cartera_tab" style="display:none" runat="server" OnClick="cartera_tab_Click"/>
                  <asp:Button ID="produccion_tab" style="display:none" runat="server" OnClick="produccion_tab_Click"/>
                  <asp:Button ID="memo_tab" style="display:none" runat="server" OnClick="memo_tab_Click"/>
                <nav>
                  <div class="nav nav-tabs" id="nav-tab" role="tablist" style="padding:20px">
                    <button class="nav-link" onclick="document.getElementById('<%= clientes_tab.ClientID %>').click()" id="nav-clientes-tab" data-bs-toggle="tab" data-bs-target="#nav-clientes" type="button" role="tab" aria-controls="nav-clientes" aria-selected="true">Clientes</button>
                    <button class="nav-link" onclick="document.getElementById('<%= grupos_tab.ClientID %>').click()" id="nav-grupos-tab" data-bs-toggle="tab" data-bs-target="#nav-grupos" type="button" role="tab" aria-controls="nav-grupos" aria-selected="false">Grupos</button>
                    <button class="nav-link" onclick="document.getElementById('<%= cartera_tab.ClientID %>').click()" id="nav-cartera-tab" data-bs-toggle="tab" data-bs-target="#nav-cartera" type="button" role="tab" aria-controls="nav-cartera" aria-selected="false">Proy. Cartera</button>
                    <button class="nav-link" onclick="document.getElementById('<%= produccion_tab.ClientID %>').click()" id="nav-produccion-tab" data-bs-toggle="tab" data-bs-target="#nav-produccion" type="button" role="tab" aria-controls="nav-produccion" aria-selected="false">Producción General</button>                    
                    <button class="nav-link" onclick="document.getElementById('<%= memo_tab.ClientID %>').click()" id="nav-memo-tab" data-bs-toggle="tab" data-bs-target="#nav-memo" type="button" role="tab" aria-controls="nav-memo" aria-selected="false">Reimp. Memos</button>                    
                  </div>
                </nav>
                <div class="tab-content" id="nav-tabContent">
                  <div class="tab-pane fade" id="nav-clientes" role="tabpanel" aria-labelledby="nav-clientes-tab">
                    <div style="padding:20px">
                      <div class="row">                         
                          <div class="col-md-2">Por Nombre</div>
                          <div class="col-md-8">
                              <dx:BootstrapTextBox ID="txtNomclie" runat="server" Width="100%">
                                    <CssClasses Input="form-control-sm fs-10" />                                    
                                </dx:BootstrapTextBox>  
                          </div>
                      </div>
                      <br />
                      <div class="row">                         
                        <div class="col-md-2">Por Oficina</div>
                        <div class="col-md-8">
                            <dx:BootstrapComboBox ID="cmbOficina" runat="server" ValueType="System.String" Width="100%">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_clientes" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                  <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>
                        </div>
                      </div>
                      <br />
                      <div class="row">                         
                        <div class="col-md-2">Mes aniversario</div>
                        <div class="col-md-8">
                            <dx:BootstrapComboBox ID="cmbAniv" runat="server" ValueType="System.String" Width="100%">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_clientes" ErrorDisplayMode="ImageWithText" CausesValidation="true">
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
                               <dx:ASPxButton ID="btnGenerarReporteClientes" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteClientes_Click" CausesValidation="true" ValidationGroup="wpr_tab_clientes"></dx:ASPxButton>                            
                            </div>
                      </div>
                    </div>
                  </div>
                  <div class="tab-pane fade" id="nav-grupos" role="tabpanel" aria-labelledby="nav-grupos-tab">
                      <div style="padding:20px">                         
                          
                          <div class="row">                         
                            <div class="col-md-2">Grupo</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbGrupoGrupos" runat="server" ValueType="System.String" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_grupos" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                          </div>
                          <br />
                          <div class="row">                         
                              <div class="col-md-2">Sucursal</div>
                              <div class="col-md-8">
                                  <dx:BootstrapComboBox ID="cmbSucursalGrupos" runat="server" ValueType="System.String" Width="100%">
                                      <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                      <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_grupos" ErrorDisplayMode="ImageWithText" CausesValidation="true">
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
                                   <dx:ASPxButton ID="btnGenerarReporteGrupos" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteGrupos_Click" CausesValidation="true" ValidationGroup="wpr_tab_grupos"></dx:ASPxButton>                            
                                </div>
                          </div>
                        </div>
                  </div>
                  <div class="tab-pane fade" id="nav-cartera" role="tabpanel" aria-labelledby="nav-cartera-tab">
                      <div style="padding:20px">                       
                            
                        <div class="row">                         
                            <div class="col-md-2">Sucursal</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbSucursalCartera" runat="server" ValueType="System.String" Width="100%">
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
                                 <dx:ASPxButton ID="btnGenerarReporteCartera" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteCartera_Click" CausesValidation="true" ValidationGroup="wpr_tab_cartera"></dx:ASPxButton>                            
                              </div>
                        </div>
                      </div>
                  </div>
                  <div class="tab-pane fade" id="nav-produccion" role="tabpanel" aria-labelledby="nav-produccion-tab">
                      <div style="padding:20px">
                          <div class="row">                         
                              <div class="col-md-2">Por Oficina</div>
                              <div class="col-md-8">
                                  <dx:BootstrapComboBox ID="cmbSucursalProd" runat="server" ValueType="System.String" Width="100%">
                                      <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                      <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_produccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                        <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                      </ValidationSettings>
                                  </dx:BootstrapComboBox>
                              </div>
                          </div>                          
                          <div class="row">                         
                            <div class="col-md-2">Divisa</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbDivisaProd" runat="server" ValueType="System.String" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_produccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                          </div>
                          <div class="row">                         
                              <div class="col-md-2">Por Cliente</div>
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
                                <div class="col-md-2">Nro Poliza</div>
                                <div class="col-md-4">
                                    <dx:BootstrapTextBox ID="txtNumPolizaProd" runat="server" Width="100%">
                                          <CssClasses Input="form-control-sm fs-10" />
                                          <ValidationSettings SetFocusOnError="True" RequiredField-IsRequired="true" ValidationGroup="wpr_tab_produccion">
                                                <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                                          </ValidationSettings>
                                    </dx:BootstrapTextBox>  
                                </div>
                          </div>
                          <div class="row">                         
                                <div class="col-md-2">Nro Liquidacion</div>
                                <div class="col-md-4">
                                    <dx:BootstrapTextBox ID="txtNumLiquidacionProd" runat="server" Width="100%">
                                          <CssClasses Input="form-control-sm fs-10" />
                                          <ValidationSettings SetFocusOnError="True" RequiredField-IsRequired="true" ValidationGroup="wpr_tab_produccion">
                                                <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                                          </ValidationSettings>
                                    </dx:BootstrapTextBox>  
                                </div>
                          </div>
                          <div class="row">                         
                              <div class="col-md-2">Rango de Aplicacion</div>
                              <div class="col-md-4">
                                  <dx:BootstrapTextBox ID="txtDelProd" runat="server" Width="100%" Caption="Del">
                                        <CssClasses Input="form-control-sm fs-10" />
                                        <ValidationSettings SetFocusOnError="True" RequiredField-IsRequired="true" ValidationGroup="wpr_tab_produccion">
                                              <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                  </dx:BootstrapTextBox>  
                              </div>
                              <div class="col-md-4">
                                    <dx:BootstrapTextBox ID="txtAlProd" runat="server" Width="100%" Caption="Al">
                                          <CssClasses Input="form-control-sm fs-10" />
                                          <ValidationSettings SetFocusOnError="True" RequiredField-IsRequired="true" ValidationGroup="wpr_tab_produccion">
                                                <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                                          </ValidationSettings>
                                    </dx:BootstrapTextBox>  
                              </div>
                          </div>
                          <div class="row">                         
                            <div class="col-md-2">Por Cartera</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbCarteraProd" runat="server" ValueType="System.String" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_produccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                          </div>
                          <div class="row">                         
                            <div class="col-md-2">Por Ejecutivo</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbEjecutivoProd" runat="server" ValueType="System.String" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_produccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                          </div>
                          <div class="row">                         
                            <div class="col-md-2">Por Compañia</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbCompaniaProd" runat="server" ValueType="System.String" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="cmbCompaniaProd_SelectedIndexChanged">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_produccion" ErrorDisplayMode="ImageWithText" CausesValidation="False">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                          </div>
                          <div class="row">                         
                            <div class="col-md-2">Por Producto</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbProductoProd" runat="server" ValueType="System.String" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_produccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                          </div>
                          <div class="row">                         
                            <div class="col-md-2">Ramo S.P.V.S.</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbRamoProd" runat="server" ValueType="System.String" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_produccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                          </div>
                          <div class="row">                         
                            <div class="col-md-2">Por Grupo</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbGrupoProd" runat="server" ValueType="System.String" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_produccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                          </div>
                          <div class="row">                         
                            <div class="col-md-2">Movimiento</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbMovimientoProd" runat="server" ValueType="System.String" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_produccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                          </div>
                          <div class="row">                         
                            <div class="col-md-2">Por rangos de Fechas</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbRangosFechasProd" runat="server" ValueType="System.String" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_produccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                          </div>
                          <div class="row">                         
                                <div class="col-md-2">Fecha de registro :</div>
                                <div class="col-md-3">
                                    <dx:BootstrapDateEdit ID="fechaDelProd" ClientInstanceName="fechaDelProd" runat="server" Width="100%" Caption="Del">
                                         <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                        <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="wpr_tab_produccion">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                              <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                                          </ValidationSettings>  
                                          <ClientSideEvents Init="function(s,e){  
                                                                     var dt1 = new Date();  
                                                                     var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                                     var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                     fechaDelProd.SetMinDate(new Date(dt3));  
                                                                     fechaDelProd.SetMaxDate(new Date(dt2));  
                                                                  }" />  
                                    </dx:BootstrapDateEdit>  
                                </div>                                
                                <div class="col-md-3">
                                    <dx:BootstrapDateEdit ID="fechaAlProd" ClientInstanceName="fechaAlProd" runat="server" Width="100%" Caption="Al">
                                         <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                        <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="wpr_tab_produccion">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                              <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                                          </ValidationSettings>  
                                          <ClientSideEvents Init="function(s,e){  
                                                                     var dt1 = new Date();  
                                                                     var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                                     var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                     fechaAlProd.SetMinDate(new Date(dt3));  
                                                                     fechaAlProd.SetMaxDate(new Date(dt2));  
                                                                  }" />  
                                    </dx:BootstrapDateEdit>  
                                  </div>
                            </div>                            
                          <div class="row">                         
                              <div class="col-md-2">Prima Total</div>
                              <div class="col-md-4">
                                  <dx:BootstrapComboBox ID="cmbPrimaTotal" runat="server" ValueType="System.String" Width="100%">
                                      <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                      <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_produccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                        <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                      </ValidationSettings>
                                  </dx:BootstrapComboBox>
                              </div>
                            <div class="col-md-4">
                                <dx:BootstrapSpinEdit ID="txtPrimaTotal" Width="160px" runat="server" Number="0" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                    <SpinButtons ShowLargeIncrementButtons="true" />
                                </dx:BootstrapSpinEdit>
                            </div>
                                
                            </div>
                          <div class="row">                         
                              <div class="col-md-2">Prima Neta</div>
                              <div class="col-md-4">
                                  <dx:BootstrapComboBox ID="cmbPrimaNeta" runat="server" ValueType="System.String" Width="100%">
                                      <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                      <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_produccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                        <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                      </ValidationSettings>
                                  </dx:BootstrapComboBox>
                              </div>
                            <div class="col-md-4">
                                <dx:BootstrapSpinEdit ID="txtPrimaNeta" Width="160px" runat="server" Number="0" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                    <SpinButtons ShowLargeIncrementButtons="true" />
                                </dx:BootstrapSpinEdit>
                            </div>
                            </div>
                          <div class="row">
                                <div class="col-md-4">      
    
                                </div>
                                <div class="col-md-7">   
                                   <dx:ASPxButton ID="btnGenerarReporteProduccion" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteProduccion_Click" CausesValidation="false" ValidationGroup="wpr_tab_produccion"></dx:ASPxButton>                            
                                </div>
                          </div>
                        </div>
                  </div>
                  <div class="tab-pane fade" id="nav-memo" role="tabpanel" aria-labelledby="nav-memo-tab">
                      <div style="padding:20px">
                          <div class="row">                         
                              <div class="col-md-2">Copias por Pagina</div>
                              <div class="col-md-1">
                                  <dx:BootstrapComboBox ID="cmbCopiasMemo" runat="server" ValueType="System.String" Width="100%">
                                      <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                      <Items>
                                            <dx:BootstrapListEditItem Text="1" Value="1"></dx:BootstrapListEditItem>
                                            <dx:BootstrapListEditItem Selected="True" Text="2" Value="2"></dx:BootstrapListEditItem>
                                       </Items>
                                      <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_memo" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                        <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                      </ValidationSettings>
                                  </dx:BootstrapComboBox>
                              </div>
                            </div>
                            <br />
                          <div class="row">                         
                              <div class="col-md-2">Nº Póliza / Liquidación :</div>
                              <div class="col-md-3">
                                  <dx:BootstrapTextBox ID="txtNumPolizaMemo" runat="server" Width="100%">
                                        <CssClasses Input="form-control-sm fs-10" />
                                        <ValidationSettings SetFocusOnError="True" RequiredField-IsRequired="true" ValidationGroup="wpr_tab_memo">
                                              <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                                          </ValidationSettings>
                                    </dx:BootstrapTextBox>  
                              </div>
                              /
                              <div class="col-md-3">
                                    <dx:BootstrapTextBox ID="txtNumLiquidacionMemo" runat="server" Width="100%">
                                          <CssClasses Input="form-control-sm fs-10" />
                                          <ValidationSettings SetFocusOnError="True" RequiredField-IsRequired="true" ValidationGroup="wpr_tab_memo">
                                                <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                                            </ValidationSettings>
                                      </dx:BootstrapTextBox>  
                                </div>
                          </div>
                          <br />
                          <div class="row">                         
                            <div class="col-md-2">Por Cartera</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbCarteraMemo" runat="server" Width="100%" SelectedIndex="1">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_memo" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                          </div>
                          <br />
                          <div class="row">                         
                            <div class="col-md-2">Por rangos de Fechas</div>
                            <div class="col-md-8">
                                <dx:BootstrapComboBox ID="cmbFechasMemo" runat="server" ValueType="System.String" Width="100%">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_memo" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                      <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                    </ValidationSettings>
                                </dx:BootstrapComboBox>
                            </div>
                          </div>
                          <br />
                          <div class="row">                         
                                <div class="col-md-2">Fecha de registro :</div>
                                <div class="col-md-3">
                                    <dx:BootstrapDateEdit ID="fechaDel" ClientInstanceName="fechaDel" runat="server" Width="100%" Caption="Del">
                                         <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                        <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="wpr_tab_memo">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                              <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                                          </ValidationSettings>  
                                          <ClientSideEvents Init="function(s,e){  
                                                                     var dt1 = new Date();  
                                                                     var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                                     var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                     fechaDel.SetMinDate(new Date(dt3));  
                                                                     fechaDel.SetMaxDate(new Date(dt2));  
                                                                  }" />  
                                    </dx:BootstrapDateEdit>  
                                </div>                                
                                <div class="col-md-3">
                                    <dx:BootstrapDateEdit ID="fechaAl" ClientInstanceName="fechaAl" runat="server" Width="100%" Caption="Al">
                                         <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                        <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="wpr_tab_memo">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                              <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                                          </ValidationSettings>  
                                          <ClientSideEvents Init="function(s,e){  
                                                                     var dt1 = new Date();  
                                                                     var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                                     var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                     fechaAl.SetMinDate(new Date(dt3));  
                                                                     fechaAl.SetMaxDate(new Date(dt2));  
                                                                  }" />  
                                    </dx:BootstrapDateEdit>  
                                  </div>
                            </div>
                            <br />
                          <div class="row">
                                <div class="col-md-4">      
    
                                </div>
                                <div class="col-md-7">   
                                   <dx:ASPxButton ID="btnGenerarReporteMemo" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteMemo_Click" CausesValidation="true" ValidationGroup="wpr_tab_memo"></dx:ASPxButton>                            
                                </div>
                          </div>
                        </div>
                  </div>
                </div>

                <%--<dx:BootstrapTabControl runat="server" ActiveTabIndex="1" CssClasses-Tab="dxTab" CssClasses-ActiveTab="dxActTab">
                    <Tabs>
                        <dx:BootstrapTab Text="Clientes">
                            <ActiveTabTemplate>
                                <div class="row">
                                    <div class="col-md-2">.col-sm-5 .col-md-6</div>
                                    <div class="col-md-10">.col-sm-5 .offset-sm-2 .col-md-6 .offset-md-0</div>
                                </div>
                            </ActiveTabTemplate>
                        </dx:BootstrapTab>
                        <dx:BootstrapTab Text="Grupos">
                        </dx:BootstrapTab>
                        <dx:BootstrapTab Text="Proy. Cartera">
                        </dx:BootstrapTab>
                        <dx:BootstrapTab Text="Produccion General">
                             <ActiveTabTemplate>
                                 
                             </ActiveTabTemplate>
                        </dx:BootstrapTab>
                        <dx:BootstrapTab Text="Reimp. Memos">
                        </dx:BootstrapTab>
                    </Tabs>
                </dx:BootstrapTabControl>--%>
              </div>    
            </div> 
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

    <script type="text/javascript">
        function openModal() {
            var myModal = new bootstrap.Modal(document.getElementById('exampleModal'), {});
            myModal.show();
        }
    </script>
       <%--   <button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#exampleModal">
        Launch demo modal
      </button>--%>
<%--<input id="clickMe" type="button" value="clickme" onclick="activeTab('nav-produccion-tab');" />--%>

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
                         <iframe id="reportTabClientes" runat="server" src="HTMLPage1.htm" height="600" width="100%"></iframe>
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
