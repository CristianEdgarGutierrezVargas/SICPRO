<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wre_reportes.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ReportesSistema.wre_reportes" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">

    <script type="text/javascript">    
    
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
                                      <ValidationSettings SetFocusOnError="True" RequiredField-IsRequired="true" ValidationGroup="wpr_tab_hist">
                                            <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                  </dx:BootstrapTextBox>  
                            </div>
                        </div>
                        <br />
                        <div class="row">                         
                            <div class="col-md-2">Año de Registro</div>
                            <div class="col-md-8">
                                <dx:BootstrapTextBox ID="txtAnioRegHist" runat="server" Width="100%">
                                      <CssClasses Input="form-control-sm fs-10" />
                                      <ValidationSettings SetFocusOnError="True" RequiredField-IsRequired="true" ValidationGroup="wpr_tab_hist">
                                            <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                                        </ValidationSettings>
                                  </dx:BootstrapTextBox>  
                            </div>
                        </div>
                        <br />
                        <div class="row">
                              <div class="col-md-4">      

                              </div>
                              <div class="col-md-7">   
                                 <dx:ASPxButton ID="btnGenerarReporteHist" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteHist_Click" CausesValidation="true" ValidationGroup="wpr_tab_hist"></dx:ASPxButton>                            
                              </div>
                        </div>
                      </div>
                  </div>
                  <div class="tab-pane fade" id="nav-gen" role="tabpanel" aria-labelledby="nav-gen-tab">
                      <div style="padding:20px">                         
    
                            <div class="row">                         
                              <div class="col-md-2">Mes aniversario</div>
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
                                     <dx:ASPxButton ID="btnGenerarReporteGen" runat="server" Text="Generar Reporte" CssClass="msg_button_class" OnClick="btnGenerarReporteGen_Click" CausesValidation="true" ValidationGroup="wpr_tab_gen"></dx:ASPxButton>                            
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

</asp:Content>
