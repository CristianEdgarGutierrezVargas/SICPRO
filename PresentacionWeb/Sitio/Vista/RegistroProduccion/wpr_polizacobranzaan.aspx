<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_polizacobranzaan.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.RegistroProduccion.wpr_polizacobranzaan" %>
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
                           <span>Tipo de Cartera :</span>
                       </div>
                       <div class="col-md-9">      
                           <asp:Label ID="lblTipoCartera" runat="server" Text=""></asp:Label>
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
                           <span id="lblprima_bruta">Prima Total:</span>
                       </div>
                       <div class="col-md-9">      
                              <table style="width: 100%;">
                                  <tr>
                                      <td style="width: 160px; height: 18px">          
                                          <dx:BootstrapSpinEdit ID="txtPrimaBruta" Width="160px" runat="server" Number="0" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                              <SpinButtons ShowLargeIncrementButtons="true" />
                                          </dx:BootstrapSpinEdit>
             
                                      </td>
                                      <td style="width: 65px; height: 18px">
                                          <span>Nº Cuotas:</span>
                                      </td>
                                      <td style="width: 70px; height: 18px">                                          
                                          <dx:BootstrapSpinEdit ReadOnly="true" ID="txtNumCuotas" Width="70px" runat="server" Number="0" MinValue="0" MaxValue="40" Increment="1" NumberType="Float">    
                                          </dx:BootstrapSpinEdit>
  
                                      </td>
                                      <td style="width: 45px; height: 18px">
                                           <span>Divisa:</span>                            
                                      </td>
                                      <td style="width: 100px; height: 18px">
                                         <asp:Label ID="lblDivisa" runat="server" Text=""></asp:Label>
                                      </td>
                                  </tr>
      
                              </table>
                       </div>
                   </div>
              
                  <div class="row">
                     <div class="col-md-2">      
                         <span>Prima Neta:</span>
                     </div>
                     <div class="col-md-10">      
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 160px; height: 18px">          
                                        <dx:BootstrapSpinEdit ID="txtPrimaNeta" Width="160px" runat="server" Number="0" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                            <SpinButtons ShowLargeIncrementButtons="true" />
                                        </dx:BootstrapSpinEdit>
             
                                    </td>
                                    <td style="width: 65px; height: 18px">
                                        <span>Porcentaje:</span>
                                    </td>
                                    <td style="width: 70px; height: 18px">                                          
                                        <dx:BootstrapSpinEdit ID="txtPorcentaje" Width="70px" runat="server" Number="0" MinValue="0" MaxValue="100" Increment="1" NumberType="Float">    
                                        </dx:BootstrapSpinEdit>
  
                                    </td>
                                    <td style="width: 45px; height: 18px">
                                         <span>Comision:</span>                            
                                    </td>
                                    <td style="width: 100px; height: 18px">
                                       <dx:BootstrapSpinEdit ID="txtComision" Width="90px" runat="server" Number="0" MinValue="0" MaxValue="10000000000" Increment="1" NumberType="Float">    
                                        </dx:BootstrapSpinEdit>
                                    </td>
                                    <td style="width: 70px; height: 18px">
                                        <asp:Button ID="btnCalcular" runat="server" Text="Calcular" OnClick="btnCalcular_Click" />
                                    </td>
                                </tr>
      
                            </table>
                     </div>
                 </div>

                  <div class="row">
                       <div class="col-md-2">      
                           <span id="lbltipo_cuota">Forma de Pago</span>
                       </div>
                       <div class="col-md-9">      
                           <dx:ASPxRadioButtonList ID="tipo_cuota" runat="server" RepeatDirection="Horizontal" Border-BorderStyle="None">
                              <Items>
                                  <dx:ListEditItem Text="Contado" Value="True" Selected></dx:ListEditItem>
                                  <dx:ListEditItem Text="Crédito" Value="False"></dx:ListEditItem>
                              </Items>
                          </dx:ASPxRadioButtonList>
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
              
                  <div class="row">                       
                       <div class="col-md-12"> 
                           <div class="panel-group">
                            <div class="panel panel-default">
                              <div class="panel-body">Cuotas de la Poliza</div>
                            </div>
                            <div class="panel panel-default">
                              <div class="panel-body">

                                  <asp:GridView ID="grdCuotasPoliza" Width="100%" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                      <Columns>
                                          <asp:BoundField DataField="cuota" HeaderText="Cuota" >
                                          <ControlStyle Width="20px" />
                                          </asp:BoundField>
                                          <asp:TemplateField HeaderText="Fecha Pago">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fecha_pago") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                   <dx:BootstrapDateEdit ID="dtFechaPago" ClientInstanceName="dtFechaPago" runat="server" Width="150px" 
                                                       Date='<%# Bind("fecha_pago") %>' DateOnError="Null">
                                                       <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="ImageWithText" EnableCustomValidation="true">  <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                                               <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                                                         </ValidationSettings>  
                                                   </dx:BootstrapDateEdit>
                                              </ItemTemplate>
                                              <ControlStyle Width="50px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Cuota Total">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cuota_total") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>                                                
                                                  <dx:BootstrapSpinEdit ID="txtCuotaTotal" Width="150px" runat="server" Number="0" MinValue="0" MaxValue="10000000000" 
                                                      Increment="0.1" LargeIncrement="1" NumberType="Float" Text='<%# Bind("cuota_total") %>'>
                                                      <SpinButtons ShowLargeIncrementButtons="true" />
                                                  </dx:BootstrapSpinEdit>
                                              </ItemTemplate>
                                              <ControlStyle Width="50px" />
                                          </asp:TemplateField>
                                          <asp:BoundField DataField="cuota_neta" HeaderText="Cuota Neta">
                                          <ControlStyle Width="100px" />
                                          </asp:BoundField>
                                          <asp:BoundField DataField="cuota_comis" HeaderText="Comision" >
                                          <ControlStyle Width="100px" />
                                          </asp:BoundField>
                                      </Columns>
                                      <FooterStyle BackColor="White" ForeColor="#000066" />
                                      <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                      <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                      <RowStyle ForeColor="#000066" />
                                      <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                      <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                      <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                      <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                      <SortedDescendingHeaderStyle BackColor="#00547E" />
                                  </asp:GridView>
                              </div>
                            </div>
                          </div>
       

        
                       </div>
                   </div>

                  <div class="row">
                      <div class="col-md-4">      
    
                      </div>
                      <div class="col-md-7">   
                          <dx:ASPxButton ID="btnNuevo" runat="server" Text="Nuevo" CssClass="msg_button_class" OnClick="btnNuevo_Click"></dx:ASPxButton>
                          <dx:ASPxButton ID="btnCuotas" runat="server" Text="Cuotas" CssClass="msg_button_class" OnClick="btnCuotas_Click" ></dx:ASPxButton>                          
                          <%--<dx:ASPxButton ID="btnSalir" runat="server" Text="Salir" CssClass="msg_button_class" OnClick="btnSalir_Click"></dx:ASPxButton>--%>
                           <dx:ASPxButton ID="btnMemo" runat="server" Text="Memo" CssClass="msg_button_class" OnClick="btnMemo_Click" ></dx:ASPxButton>                          
                     
                      </div>
                  </div>

            </div>
          </div>
        </div>

        <p class="links">
             <asp:Label ID="lblmensaje" runat="server" Text="Introduzca Valores" CssClass="error"></asp:Label>  
         </p>
       </div>


        <div class="container">
            <div class="row">
                <div class="col-md-12">
                    <iframe id="re_memo_report" runat="server" src="HTMLPage1.htm" height="600" width="100%"></iframe>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
