<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wre_reportes.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ReportesSistema.wre_reportes" %>
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
              <h1 class="title"> <asp:Label ID="titulo" runat="server" Text="Renovacion de Reclamos"></asp:Label></h1>
              <div class="entry">
                  <img src="../../../UI/img/edit.png" alt="" width="128" height="128" class="left">
              </div>      
          </div>    
        </div>  

    <div class="row">
        <div class="col-md-12"> 
             <asp:HiddenField ID="hidtab" Value="nav-hist-tab" runat="server" />

             <asp:Button ID="hist_tab" style="display:none" runat="server" OnClick="hist_tab_Click"/>
             <asp:Button ID="gen_tab" style="display:none" runat="server" OnClick="gen_tab_Click"/>
              <nav>
                <div class="nav nav-tabs" id="nav-tab" role="tablist" style="padding:20px">
                  <button class="nav-link" onclick="document.getElementById('<%= hist_tab.ClientID %>').click()" id="nav-hist-tab" data-bs-toggle="tab" data-bs-target="#nav-hist" type="button" role="tab" aria-controls="nav-hist" aria-selected="true">Resumen Histórico</button>
                  <button class="nav-link" onclick="document.getElementById('<%= gen_tab.ClientID %>').click()" id="nav-gen-tab" data-bs-toggle="tab" data-bs-target="#nav-gen" type="button" role="tab" aria-controls="nav-gen" aria-selected="false">Resumen General</button>
                </div>
              </nav>
              <div class="tab-content" id="nav-tabContent">
                  <div class="tab-pane fade" id="nav-hist" role="tabpanel" aria-labelledby="nav-hist-tab">
                      <div style="padding:20px">
                        <div class="row">                         
                            <div class="col-md-2">Nro de caso</div>
                            <div class="col-md-8">
                                <dx:BootstrapTextBox ID="txtNroCasoHist" runat="server" Width="100%">
                                      <CssClasses Input="form-control-sm fs-10" />                                     
                                  </dx:BootstrapTextBox>  
                            </div>
                        </div>
                        <br />
                        <div class="row">                         
                            <div class="col-md-2">Año de Registro</div>
                            <div class="col-md-8">
                                <dx:BootstrapTextBox ID="txtAnioRegHist" runat="server" Width="100%">
                                      <CssClasses Input="form-control-sm fs-10" />                                      
                                  </dx:BootstrapTextBox>  
                            </div>
                        </div>
                        <br />

                        <div class="row">
                              <div class="col-md-4">      

                              </div>
                              <div class="col-md-7">   
                                 <dx:ASPxButton ID="btnGenerarReporteHist" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteHist_Click" ></dx:ASPxButton>                            
                              </div>
                        </div>

                          
                         
                      </div>
                  </div>
                  <div class="tab-pane fade" id="nav-gen" role="tabpanel" aria-labelledby="nav-gen-tab">
                      <div style="padding:20px">                         
    
                            <div class="row">                         
                              <div class="col-md-2">Por Oficina</div>
                              <div class="col-md-8">
                                  <dx:BootstrapComboBox ID="cmbOficina" runat="server" ValueType="System.String" Width="100%">
                                      <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                      <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_grupos" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                        <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                      </ValidationSettings>
                                  </dx:BootstrapComboBox>
                              </div>
                            </div>
                            <div class="row">                         
                                <div class="col-md-2">Por Cartera</div>
                                <div class="col-md-8">
                                    <dx:BootstrapComboBox ID="cmbCartera" runat="server" ValueType="System.String" Width="100%">
                                        <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                        <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_grupos" ErrorDisplayMode="ImageWithText" CausesValidation="true">
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
                                  <div class="col-md-2">Por Fecha de Siniestro :</div>
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
                              <div class="col-md-2">Por estado del caso</div>
                              <div class="col-md-8">
                                  <dx:BootstrapComboBox ID="cmbEstadoCaso" runat="server" ValueType="System.String" Width="100%">
                                      <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                      <ValidationSettings SetFocusOnError="True" ValidationGroup="wpr_tab_produccion" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                        <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                      </ValidationSettings>
                                  </dx:BootstrapComboBox>
                              </div>
                            </div>
                            <div class="row">
                                  <div class="col-md-4">      

                                  </div>
                                  <div class="col-md-7">   
                                     <dx:ASPxButton ID="btnGenerarReporteGen" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteGen_Click" CausesValidation="true" ValidationGroup="wpr_tab_gen"></dx:ASPxButton>                            
                                  </div>
                            </div>

                         
                  </div>
              </div>
              </div>
        </div> 
    </div>

    <div class="row">
         <div class="col-12">
             <div class="alert alert-danger" role="alert" runat="server" id="divMensajeError">
                 <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
             </div>
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
