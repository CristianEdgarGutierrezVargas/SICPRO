<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_reportes.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ReportesSistema.wpr_reportes" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


<%@ Register assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
       <div class="post">
         <div>         
           <div class="container">
            <div class="row">
              <div class="col-md-12">      
                  <h1 class="title"> <asp:Label ID="titulo" runat="server" Text="Renovacion de Polizas"></asp:Label></h1>
                  <div class="entry">
                      <img src="../../../UI/img/edit.png" alt="" width="128" height="128" class="left">
                  </div>      
              </div>    
            </div>  

            <div class="row">
              <div class="col-md-12"> 

                <nav>
                  <div class="nav nav-tabs" id="nav-tab" role="tablist">
                    <button class="nav-link active" style="color:black !important" id="nav-home-tab" data-bs-toggle="tab" data-bs-target="#nav-home" type="button" role="tab" aria-controls="nav-home" aria-selected="true">Clientes</button>
                    <button class="nav-link" style="color:black !important" id="nav-profile-tab" data-bs-toggle="tab" data-bs-target="#nav-profile" type="button" role="tab" aria-controls="nav-profile" aria-selected="false">Profile</button>
                    <button class="nav-link" style="color:black !important" id="nav-contact-tab" data-bs-toggle="tab" data-bs-target="#nav-contact" type="button" role="tab" aria-controls="nav-contact" aria-selected="false">Contact</button>
                  </div>
                </nav>
                <div class="tab-content" id="nav-tabContent">
                  <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab">
                    <div style="padding:20px">
                      <div class="row">                         
                          <div class="col-md-2">Por Nombre</div>
                          <div class="col-md-8">
                              <dx:BootstrapTextBox ID="txtNomclie" runat="server" Width="100%">
                                    <CssClasses Input="form-control-sm fs-10" />
                                    <ValidationSettings SetFocusOnError="True" RequiredField-IsRequired="true" ValidationGroup="wpr_tab_clientes">
                                          <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                                      </ValidationSettings>
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
                            <dx:BootstrapComboBox ID="cmdAniv" runat="server" ValueType="System.String" Width="100%">
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
                  <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">...</div>
                  <div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab">...</div>
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
        
</asp:Content>
