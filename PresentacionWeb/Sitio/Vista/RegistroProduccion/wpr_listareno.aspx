<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_listareno.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.RegistroProduccion.wpr_listareno" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    
    <div class="post">
       <div>                    

        <div class="container">
          <div class="row">
              <div class="col-md-12"> 
                  <h1 class="title"> Renovación de Polizas</h1>      
              </div>
              <br />
            <div class="col-md-5">      
                
                <div class="row">
                    <div class="col-md-3"> 
                        N° Poliza:
                    </div>
                    <div class="col-md-8"> 
                        <dx:ASPxTextBox ID="num_poliza" runat="server" Width="100%">
                            <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" RequiredField-IsRequired="true" ValidationGroup="form_wgr_persona">
                                <RequiredField ErrorText="Este campo es requerido" IsRequired="True"></RequiredField>
                            </ValidationSettings>
                        </dx:ASPxTextBox> 
                    </div>
                    <div class="col-md-1"> 
                    </div>
                </div>        
                 <div class="row">
                     <div class="col-md-3"> 
                         Asegurado:
                     </div>
                     <div class="col-md-8"> 
                         <dx:ASPxTextBox ID="ASPxTextBox1" runat="server" Width="100%">
                             <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" RequiredField-IsRequired="true" ValidationGroup="form_wgr_persona">
                                 <RequiredField ErrorText="Este campo es requerido" IsRequired="True"></RequiredField>
                             </ValidationSettings>
                         </dx:ASPxTextBox> 
                     </div>
                     <div class="col-md-1"> 
                        <button type="button" name="btnserper" data-bs-toggle="modal" data-bs-target="#modal_btnserper" id="btnserper" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                          ...
                        </button>
                     </div>
                 </div>
                 <div class="row">
                     <div class="col-md-3"> 
                         Cia Aseguradora:
                     </div>
                     <div class="col-md-8"> 
                         <dx:ASPxTextBox ID="ASPxTextBox2" runat="server" Width="100%">
                             <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" RequiredField-IsRequired="true" ValidationGroup="form_wgr_persona">
                                 <RequiredField ErrorText="Este campo es requerido" IsRequired="True"></RequiredField>
                             </ValidationSettings>
                         </dx:ASPxTextBox> 
                     </div>
                     <div class="col-md-1"> 
                        <button type="button" name="btnserper" data-bs-toggle="modal" data-bs-target="#modal_btnserper" id="btnserper" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                          ...
                        </button>
                     </div>
                 </div>  
                <div class="row">
                    <div class="col-md-3"> 
                        Producto:
                    </div>
                    <div class="col-md-8"> 
                        <dx:ASPxTextBox ID="ASPxTextBox3" runat="server" Width="100%">
                            <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" RequiredField-IsRequired="true" ValidationGroup="form_wgr_persona">
                                <RequiredField ErrorText="Este campo es requerido" IsRequired="True"></RequiredField>
                            </ValidationSettings>
                        </dx:ASPxTextBox> 
                    </div>
                    <div class="col-md-1"> 
                       <button type="button" name="btnserper" data-bs-toggle="modal" data-bs-target="#modal_btnserper" id="btnserper" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                         ...
                       </button>
                    </div>
                </div>  

                <div class="row">
                    <div class="col-md-12">
                        
                        <div class="card">   
                           
                          <div class="card-body">
                            <h5 class="card-title" style="text-align:right">Por Vigencia
                                <asp:CheckBox ID="CheckBox2" runat="server" />
                            </h5>
                                <div class="row">
                                    <div class="col-md-6">
                                         Del <dx:ASPxDateEdit ID="fc_inivig" ClientInstanceName="fc_inivig" runat="server" Width="100%">
                                             <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="form_wgr_persona">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                                 <RequiredField ErrorText="Este campo es requerido" IsRequired="true"  />  
                                             </ValidationSettings>  
                                             <ClientSideEvents Init="function(s,e){  
                                                                        var dt1 = new Date();  
                                                                        var dt2 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                        var dt3 = new Date(dt1.getFullYear() - 100, dt1.getMonth(), dt1.getDate());  
                                                                        fc_inivig.SetMinDate(new Date(dt3));  
                                                                        fc_inivig.SetMaxDate(new Date(dt2));  
                                                                     }" />  
                                         </dx:ASPxDateEdit>
                                    </div>
                                    <div class="col-md-6">
                                        Al <dx:ASPxDateEdit ID="fc_finvig" ClientInstanceName="fc_finvig" runat="server" Width="100%">
                                            <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="form_wgr_persona">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                                <RequiredField ErrorText="Este campo es requerido" IsRequired="true"  />  
                                            </ValidationSettings>  
                                            <ClientSideEvents Init="function(s,e){  
                                                                       var dt1 = new Date();  
                                                                       var dt2 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                       var dt3 = new Date(dt1.getFullYear() - 100, dt1.getMonth(), dt1.getDate());  
                                                                       fc_inivig.SetMinDate(new Date(dt3));  
                                                                       fc_inivig.SetMaxDate(new Date(dt2));  
                                                                    }" />  
                                        </dx:ASPxDateEdit>
                                    </div>
                                </div>
                          </div>
                        </div>
                    </div>
                </div>  
                <div class="row">
                    <div class="col-md-12"> 
                        <div class="card">                         
                          <div class="card-body">
                            <h5 class="card-title" style="text-align:right">Por Vencer
                                <asp:CheckBox ID="CheckBox1" runat="server" />
                            </h5>
                            <div class="row">
                                <div class="col-md-6">
                                     Polizas Vencidas: <dx:ASPxDateEdit ID="ASPxDateEdit1" ClientInstanceName="fc_inivig" runat="server" Width="100%">
                                         <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="form_wgr_persona">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                             <RequiredField ErrorText="Este campo es requerido" IsRequired="true"  />  
                                         </ValidationSettings>  
                                         <ClientSideEvents Init="function(s,e){  
                                                                    var dt1 = new Date();  
                                                                    var dt2 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                                    var dt3 = new Date(dt1.getFullYear() - 100, dt1.getMonth(), dt1.getDate());  
                                                                    fc_inivig.SetMinDate(new Date(dt3));  
                                                                    fc_inivig.SetMaxDate(new Date(dt2));  
                                                                 }" />  
                                     </dx:ASPxDateEdit>
                                </div>
                            </div>
                          </div>
                        </div>
                    </div>
                </div>  
                <div class="row">
                    <div class="col-md-12" style="text-align:center">
                        <dx:ASPxButton ID="btnNuevo" runat="server" Text="Nuevo" CssClass="msg_button_class" OnClick="btnNuevo_Click"></dx:ASPxButton>  
                        <dx:ASPxButton ID="btnBuscar" runat="server" Text="Buscar" CssClass="msg_button_class" OnClick="btnBuscar_Click"></dx:ASPxButton>
                    </div>
                </div>
            </div>    
            <div class="col-md-7"> 
                <dx:ASPxGridView ID="grdListaReno" Width="100%" runat="server" KeyFieldName="cuota" OnDataBinding="grdListaReno_DataBinding" AutoGenerateColumns="False"
                    EnableRowsCache="false">
                    <SettingsPager Visible="False">
                    </SettingsPager>
                       <SettingsEditing Mode="Batch">
                           <BatchEditSettings EditMode="Cell" KeepChangesOnCallbacks="False" StartEditAction="Click" />
                    </SettingsEditing>
                       <SettingsPopup>
                       <FilterControl AutoUpdatePosition="False"></FilterControl>
                       </SettingsPopup>
                    <Columns>
                        <dx:GridViewDataTextColumn VisibleIndex="0" FieldName="cuota" Caption="Nro Poliza" Width="30">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn VisibleIndex="1" FieldName="cuota" Caption="Cliente" Width="100">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn VisibleIndex="2" FieldName="cuota" Caption="Ini Vigencia" Width="20">
                        </dx:GridViewDataTextColumn>
                        <dx:GridViewDataTextColumn VisibleIndex="3" FieldName="cuota" Caption="Fin Vigencia" Width="20">
                        </dx:GridViewDataTextColumn>
                        
                    </Columns>
                </dx:ASPxGridView>
            </div>
          </div>
        </div>

       <%-- <p class="links">
             <asp:Label ID="lblmensaje" runat="server" Text="Introduzca Valores" CssClass="error"></asp:Label>  
         </p>--%>

    

                </div>
            </div>
</asp:Content>
