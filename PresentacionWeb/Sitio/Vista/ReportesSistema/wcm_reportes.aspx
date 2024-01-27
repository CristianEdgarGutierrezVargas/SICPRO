<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wcm_reportes.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ReportesSistema.wcm_reportes" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
        <script type="text/javascript">    
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
                  <h1 class="title"> <asp:Label ID="titulo" runat="server" Text="Reporte de Comisiones"></asp:Label></h1>
                  <div class="entry">
                      <img src="../../../UI/img/edit.png" alt="" width="128" height="128" class="left">
                  </div>      
              </div>    
            </div>  

        <div class="row">
            <div class="col-md-12"> 
             <asp:HiddenField ID="hidtab" Value="nav-comisionesEje-tab" runat="server" />

             <asp:Button ID="comisionesEje_tab" style="display:none" runat="server" OnClick="comisionesEje_tab_Click"/>
             <asp:Button ID="spvs_tab" style="display:none" runat="server" OnClick="spvs_tab_Click"/>
             <asp:Button ID="comisiones_tab" style="display:none" runat="server" OnClick="comisiones_tab_Click"/>
             <asp:Button ID="contable_tab" style="display:none" runat="server" OnClick="contable_tab_Click"/>
             <asp:Button ID="nota_tab" style="display:none" runat="server" OnClick="nota_tab_Click"/>
             <asp:Button ID="comisionesFe_tab" style="display:none" runat="server" OnClick="comisionesFe_tab_Click"/>

                  <nav>
                    <div class="nav nav-tabs" id="nav-tab" role="tablist" style="padding:20px">
                      <button class="nav-link" onclick="document.getElementById('<%= comisionesEje_tab.ClientID %>').click()"  id="nav-comisionesEje-tab" data-bs-toggle="tab" data-bs-target="#nav-comisionesEje" type="button" role="tab" aria-controls="nav-comisionesEje" aria-selected="true">Comisiones por Ejecutivo</button>
                      <button class="nav-link" onclick="document.getElementById('<%= spvs_tab.ClientID %>').click()" id="nav-spvs-tab" data-bs-toggle="tab" data-bs-target="#nav-spvs" type="button" role="tab" aria-controls="nav-spvs" aria-selected="false">ASCII - SPVS</button>
                      <button class="nav-link" onclick="document.getElementById('<%= comisiones_tab.ClientID %>').click()" id="nav-comisiones-tab" data-bs-toggle="tab" data-bs-target="#nav-comisiones" type="button" role="tab" aria-controls="nav-comisiones" aria-selected="false">Comisiones</button>
                      <button class="nav-link" onclick="document.getElementById('<%= contable_tab.ClientID %>').click()" id="nav-contable-tab" data-bs-toggle="tab" data-bs-target="#nav-contable" type="button" role="tab" aria-controls="nav-contable" aria-selected="false">Contable 1</button>
                      <button class="nav-link" onclick="document.getElementById('<%= nota_tab.ClientID %>').click()" id="nav-nota-tab" data-bs-toggle="tab" data-bs-target="#nav-nota" type="button" role="tab" aria-controls="nav-nota" aria-selected="false">Nota Cob. Comis.</button>
                      <button class="nav-link" onclick="document.getElementById('<%= comisionesFe_tab.ClientID %>').click()" id="nav-comisionesFe-tab" data-bs-toggle="tab" data-bs-target="#nav-comisionesFe" type="button" role="tab" aria-controls="nav-comisionesFe" aria-selected="false">Comisiones a Fecha</button>
                    </div>
                  </nav>
                  <div class="tab-content" id="nav-tabContent">
                      <div class="tab-pane fade" id="nav-comisionesEje" role="tabpanel" aria-labelledby="nav-comisionesEje-tab">
                          <div style="padding:20px">

                            <div class="row">                         
                                  <div class="col-md-2">Fecha de Inicio :</div>
                                  <div class="col-md-3">
                                      <dx:BootstrapDateEdit ID="fechaInicioEje" ClientInstanceName="fechaInicioEje" runat="server" Width="100%">
                                           <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                          <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="wpr_tab_produccion">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                                <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                                            </ValidationSettings>  
                                            <ClientSideEvents Init="function(s,e){  
                                                                       var dt1 = new Date();  
                                                                       var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                                       var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                       fechaInicioEje.SetMinDate(new Date(dt3));  
                                                                       fechaInicioEje.SetMaxDate(new Date(dt2));  
                                                                    }" />  
                                      </dx:BootstrapDateEdit>  
                                  </div>
                              </div>

                            <div class="row">
                                  <div class="col-md-2">Fecha de Fin :</div>
                                  <div class="col-md-3">
                                      <dx:BootstrapDateEdit ID="fechaFinEje" ClientInstanceName="fechaFinEje" runat="server" Width="100%">
                                           <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                          <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="wpr_tab_produccion">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                                <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                                            </ValidationSettings>  
                                            <ClientSideEvents Init="function(s,e){  
                                                                       var dt1 = new Date();  
                                                                       var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                                       var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                       fechaFinEje.SetMinDate(new Date(dt3));  
                                                                       fechaFinEje.SetMaxDate(new Date(dt2));  
                                                                    }" />  
                                      </dx:BootstrapDateEdit>  
                                    </div>
                              </div>

                            <div class="row">                         
                                <div class="col-md-2">Agente Cartera</div>
                                <div class="col-md-8">
                                    <dx:BootstrapComboBox ID="cmbCarteraEje" runat="server" ValueType="System.String" Width="100%">
                                        <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_produccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                          <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                        </ValidationSettings>
                                    </dx:BootstrapComboBox>
                                </div>
                            </div>

                            <div class="row">                         
                                <div class="col-md-2">Sucursal</div>
                                <div class="col-md-8">
                                    <dx:BootstrapComboBox ID="cmbSucursalEje" runat="server" ValueType="System.String" Width="100%">
                                        <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_cartera" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                          <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                        </ValidationSettings>
                                    </dx:BootstrapComboBox>
                                </div>
                              </div>
                            
                            <div class="row">                         
                              <div class="col-md-2">Ejecutivo de cuenta</div>
                              <div class="col-md-8">
                                  <dx:BootstrapComboBox ID="cmbEjecutivoEje" runat="server" ValueType="System.String" Width="100%">
                                      <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                      <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_clientes" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                        <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                      </ValidationSettings>
                                  </dx:BootstrapComboBox>
                              </div>
                            </div>
                            
                            <div class="row">
                                  <div class="col-md-4">      
    
                                  </div>
                                  <div class="col-md-7">   
                                     <dx:ASPxButton ID="btnGenerarReporteComisionesEje" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteComisionesEje_Click" CausesValidation="true" ValidationGroup="wpr_tab_comisionesEje"></dx:ASPxButton>                            
                                  </div>
                            </div>
                          </div>
                      </div>
                      <div class="tab-pane fade" id="nav-spvs" role="tabpanel" aria-labelledby="nav-spvs-tab">
                          <div style="padding:20px">                         
        
                                <div class="row">                         
                                  <div class="col-md-2">Mes</div>
                                  <div class="col-md-8">
                                      <dx:BootstrapComboBox ID="cmbMesSpvs" runat="server" ValueType="System.String" Width="100%">
                                          <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                          <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_grupos" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                            <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                          </ValidationSettings>
                                      </dx:BootstrapComboBox>
                                  </div>
                                </div>
                                <br />
                                <div class="row">                         
                                    <div class="col-md-2">Año</div>
                                    <div class="col-md-8">
                                        <dx:BootstrapComboBox ID="cmbAnioSpvs" runat="server" ValueType="System.String" Width="100%">
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
                                         <dx:ASPxButton ID="btnGenerarReporteSpvs" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteSpvs_Click" CausesValidation="true" ValidationGroup="wpr_tab_spvs"></dx:ASPxButton>                            
                                      </div>
                                </div>
                              </div>
                      </div>
                      <div class="tab-pane fade" id="nav-comisiones" role="tabpanel" aria-labelledby="nav-comisiones-tab">
                          <div style="padding:20px">                         
                                <div class="row">                         
                                  <div class="col-md-2">Mes</div>
                                  <div class="col-md-8">
                                      <dx:BootstrapComboBox ID="cmbMesCom" runat="server" ValueType="System.String" Width="100%">
                                          <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                          <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_grupos" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                            <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                          </ValidationSettings>
                                      </dx:BootstrapComboBox>
                                  </div>
                                </div>
                                <br />
                                <div class="row">                         
                                    <div class="col-md-2">Año</div>
                                    <div class="col-md-8">
                                        <dx:BootstrapComboBox ID="cmbAnioCom" runat="server" ValueType="System.String" Width="100%">
                                            <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                            <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_grupos" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                              <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                            </ValidationSettings>
                                        </dx:BootstrapComboBox>
                                    </div>
                                  </div>
                                <br />
                                <div class="row">                         
                                  <div class="col-md-2">Reporte</div>
                                  <div class="col-md-8">
                                      <dx:BootstrapComboBox ID="cmbReporteCom" runat="server" ValueType="System.String" Width="100%">
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
                                         <dx:ASPxButton ID="btnGenerarReporteComisiones" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteComisiones_Click" CausesValidation="true" ValidationGroup="wpr_tab_comisiones"></dx:ASPxButton>                            
                                      </div>
                                </div>
                              </div>
                      </div>
                      <div class="tab-pane fade" id="nav-contable" role="tabpanel" aria-labelledby="nav-contable-tab">
                          <div style="padding:20px">                         

                                <div class="row">                         
                                  <div class="col-md-2">Mes</div>
                                  <div class="col-md-8">
                                      <dx:BootstrapComboBox ID="cmbMesCont" runat="server" ValueType="System.String" Width="100%">
                                          <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                          <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_grupos" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                            <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                          </ValidationSettings>
                                      </dx:BootstrapComboBox>
                                  </div>
                                </div>
                                <br />
                                <div class="row">                         
                                    <div class="col-md-2">Año</div>
                                    <div class="col-md-8">
                                        <dx:BootstrapComboBox ID="cmbAnioCont" runat="server" ValueType="System.String" Width="100%">
                                            <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                            <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_grupos" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                              <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                            </ValidationSettings>
                                        </dx:BootstrapComboBox>
                                    </div>
                                  </div>
                                <br />
                                <div class="row">                         
                                  <div class="col-md-2">Compañia</div>
                                  <div class="col-md-8">
                                      <dx:BootstrapComboBox ID="cmbCompaniaCont" runat="server" ValueType="System.String" Width="100%">
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
                                         <dx:ASPxButton ID="btnGenerarReporteContable" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteContable_Click" CausesValidation="true" ValidationGroup="wpr_tab_contable"></dx:ASPxButton>                            
                                      </div>
                                </div>
                              </div>
                      </div>
                      <div class="tab-pane fade" id="nav-nota" role="tabpanel" aria-labelledby="nav-v-tab">
                          <div style="padding:20px">                         
        
                            <div class="row">                         
                                  <div class="col-md-2">Fecha de Inicio :</div>
                                  <div class="col-md-3">
                                      <dx:BootstrapDateEdit ID="fechaInicioNota" ClientInstanceName="fechaInicioNota" runat="server" Width="100%">
                                           <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                          <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="wpr_tab_produccion">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                                <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                                            </ValidationSettings>  
                                            <ClientSideEvents Init="function(s,e){  
                                                                       var dt1 = new Date();  
                                                                       var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                                       var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                       fechaInicioNota.SetMinDate(new Date(dt3));  
                                                                       fechaInicioNota.SetMaxDate(new Date(dt2));  
                                                                    }" />  
                                      </dx:BootstrapDateEdit>  
                                  </div>
                              </div>

                            <div class="row">
                                  <div class="col-md-2">Fecha de Fin :</div>
                                  <div class="col-md-3">
                                      <dx:BootstrapDateEdit ID="fechaFinNota" ClientInstanceName="fechaFinNota" runat="server" Width="100%">
                                           <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                          <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="wpr_tab_produccion">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                                <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                                            </ValidationSettings>  
                                            <ClientSideEvents Init="function(s,e){  
                                                                       var dt1 = new Date();  
                                                                       var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                                       var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                       fechaFinNota.SetMinDate(new Date(dt3));  
                                                                       fechaFinNota.SetMaxDate(new Date(dt2));  
                                                                    }" />  
                                      </dx:BootstrapDateEdit>  
                                    </div>
                              </div>

                            <div class="row">                         
                                <div class="col-md-2">Compañia</div>
                                <div class="col-md-8">
                                    <dx:BootstrapComboBox ID="cmbCompaniaNota" runat="server" ValueType="System.String" Width="100%">
                                        <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_produccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                          <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                        </ValidationSettings>
                                    </dx:BootstrapComboBox>
                                </div>
                            </div>

                            <div class="row">                         
                                <div class="col-md-2">Sucursal</div>
                                <div class="col-md-8">
                                    <dx:BootstrapComboBox ID="cmbSucursalNota" runat="server" ValueType="System.String" Width="100%">
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
                                         <dx:ASPxButton ID="btnGenerarReporteNota" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteNota_Click" CausesValidation="true" ValidationGroup="wpr_tab_nota"></dx:ASPxButton>                            
                                      </div>
                                </div>
                              </div>
                      </div>
                      <div class="tab-pane fade" id="nav-comisionesFe" role="tabpanel" aria-labelledby="nav-comisionesFe-tab">
                          <div style="padding:20px">                         
        
                            <div class="row">                         
                                  <div class="col-md-2">Fecha de Inicio :</div>
                                  <div class="col-md-3">
                                      <dx:BootstrapDateEdit ID="fechaInicioComFe" ClientInstanceName="fechaInicioComFe" runat="server" Width="100%">
                                           <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                          <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="wpr_tab_produccion">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                                <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                                            </ValidationSettings>  
                                            <ClientSideEvents Init="function(s,e){  
                                                                       var dt1 = new Date();  
                                                                       var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                                       var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                       fechaInicioComFe.SetMinDate(new Date(dt3));  
                                                                       fechaInicioComFe.SetMaxDate(new Date(dt2));  
                                                                    }" />  
                                      </dx:BootstrapDateEdit>  
                                  </div>
                              </div>

                            <div class="row">
                                  <div class="col-md-2">Fecha de Fin :</div>
                                  <div class="col-md-3">
                                      <dx:BootstrapDateEdit ID="fechaFinComfe" ClientInstanceName="fechaFinComfe" runat="server" Width="100%">
                                           <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                          <ValidationSettings SetFocusOnError="True" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="wpr_tab_produccion">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                                <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                                            </ValidationSettings>  
                                            <ClientSideEvents Init="function(s,e){  
                                                                       var dt1 = new Date();  
                                                                       var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                                       var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                       fechaFinComfe.SetMinDate(new Date(dt3));  
                                                                       fechaFinComfe.SetMaxDate(new Date(dt2));  
                                                                    }" />  
                                      </dx:BootstrapDateEdit>  
                                    </div>
                              </div>
                                  <br />
                                <div class="row">
                                      <div class="col-md-4">      
    
                                      </div>
                                      <div class="col-md-7">   
                                         <dx:ASPxButton ID="btnGenerarReporteComisionesFe" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteComisionesFe_Click" CausesValidation="true" ValidationGroup="wpr_tab_comisionesFe"></dx:ASPxButton>                            
                                      </div>
                                </div>
                              </div>
                      </div>

                  </div>
            </div> 
        </div>
      </div>
    </div>
    </div>


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
