<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_polizacobranzain.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.RegistroProduccion.wpr_polizacobranzain" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">

    <div class="post">
       <div>                    

        <div class="container">
          <div class="row">
            <div class="col-md-3">      
                <h1 class="title"> <asp:Label ID="lblTitulo" runat="server" Text="Datos de Poliza Incluida (Módulo de Cobranzas)"></asp:Label></h1>
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
                      <div class="col-md-3">      
                        <span>Fecha de Emisión:</span>
                      </div>
                      <div class="col-md-3">      
                         <dx:ASPxDateEdit ID="fc_emision" ClientInstanceName="fc_emision" runat="server" Width="100%">
                              <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="form_wgr_poliza">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                   <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                               </ValidationSettings>  
                               <ClientSideEvents Init="function(s,e){  
                                                          var dt1 = new Date();  
                                                          var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                          var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                          fc_emision.SetMinDate(new Date(dt3));  
                                                          fc_emision.SetMaxDate(new Date(dt2));  
                                                       }" />  
                         </dx:ASPxDateEdit>
                      </div>
                      <div class="col-md-3">      
                         <span>Fecha de Recepción:</span>
                      </div>
                      <div class="col-md-3">      
                         <dx:ASPxDateEdit ID="fc_recepcion" ClientInstanceName="fc_recepcion" runat="server" Width="100%">
                              <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="form_wgr_poliza">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                    <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                              </ValidationSettings>  
                                <ClientSideEvents Init="function(s,e){  
                                                           var dt1 = new Date();  
                                                           var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                           var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                           fc_recepcion.SetMinDate(new Date(dt3));  
                                                           fc_recepcion.SetMaxDate(new Date(dt2));  
                                                        }" /> 
                         </dx:ASPxDateEdit>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-md-3">      
                         <span>Inicio Vigencia:</span>
                      </div>
                      <div class="col-md-3">      
                         <dx:ASPxDateEdit ID="fc_inivig" ClientInstanceName="fc_inivig" runat="server" Width="100%">
                             <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="form_wgr_poliza">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                    <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                              </ValidationSettings>  
                                <ClientSideEvents Init="function(s,e){  
                                                           var dt1 = new Date();  
                                                           var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                           var dt3 = new Date(dt1.getFullYear() - 1, dt1.getMonth(), dt1.getDate());  
                                                           fc_inivig.SetMinDate(new Date(dt3));  
                                                           fc_inivig.SetMaxDate(new Date(dt2));  
                                                        }" /> 
                         </dx:ASPxDateEdit>
                      </div>
                      <div class="col-md-3">      
                         <span>Fin Vigencia:</span>
                      </div>
                      <div class="col-md-3">      
                          <asp:Label ID="lblfc_finvig" runat="server" Text=""></asp:Label>
                      </div>
                  </div>

                  <div class="row">
                      <div class="col-md-3">      
                         <span id="lblnumero">N° de Poliza:</span>
                      </div>
                      <div class="col-md-3">      
                         <asp:Label ID="lblNroPoliza" runat="server" Text=""></asp:Label>
                      </div>
                      <div class="col-md-3">      
                         <span id="lblnumliquida">Nº Liquidación:</span>
                      </div>
                      <div class="col-md-3">      
                         <dx:ASPxTextBox ID="txtNroLiquidacion" runat="server" Width="100%">
                             <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" RequiredField-IsRequired="true" ValidationGroup="form_wgr_poliza">
                                   <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                               </ValidationSettings>
                         </dx:ASPxTextBox>  
                      </div>
                  </div>
                  
                  <div class="row">
                       <div class="col-md-3">      
                          <span>Asegurado :</span>
                       </div>
                       <div class="col-md-7">                            
                           <asp:Label ID="lblAsegurado" runat="server" Text=""></asp:Label>
                       </div>
                      <div class="col-md-1">
                          
                      </div>
                   </div>
                  
                  <div class="row">
                       <div class="col-md-3">      
                          <span id="lbldireccion">Dirección :</span>
                       </div>
                       <div class="col-md-7">   
                          <asp:Label ID="lblDireccion" runat="server" Text=""></asp:Label>
                       </div>
                      <div class="col-md-1">
                        
                      </div>
                   </div>
                  
                  <div class="row">
                      <div class="col-md-3">      
                          <span>Grupo :</span>
                      </div>
                      <div class="col-md-8">      
                          <asp:Label ID="lblGrupo" runat="server" Text=""></asp:Label>
                      </div>
                  </div>
                  
                  <div class="row">
                      <div class="col-md-3">      
                          <span>Cia Aseguradora :</span>
                      </div>
                      <div class="col-md-8">      
                          <asp:Label ID="lblCiaAseg" runat="server" Text=""></asp:Label>
                      </div>
                  </div>
                  
                  <div class="row">
                       <div class="col-md-3">      
                           <span>Producto :</span>
                       </div>
                       <div class="col-md-8">      
                           <asp:Label ID="lblProducto" runat="server" Text=""></asp:Label>
                       </div>
                   </div>
                  
                  <div class="row">
                       <div class="col-md-3">      
                           <span>Tipo de Cartera :</span>
                       </div>
                       <div class="col-md-8">      
                           <asp:Label ID="lblTipoCartera" runat="server" Text=""></asp:Label>
                       </div>
                   </div>
                  
                  <div class="row">
                       <div class="col-md-3">      
                          <span>Ejecutivo:</span>
                       </div>
                       <div class="col-md-8">      
                            <dx:ASPxComboBox ID="cmbEjecutivo" runat="server" ValueType="System.String" Width="100%">
                                <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" ValidationGroup="form_wgr_poliza" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                  <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                </ValidationSettings>
                            </dx:ASPxComboBox>
                       </div>
                   </div>
                  
                  <div class="row">
                      <div class="col-md-3">      
                          <span>Agente Cartera:</span>
                      </div>
                      <div class="col-md-8">      
                          <asp:Label ID="lblAgente" runat="server" Text=""></asp:Label>
                      </div>
                  </div>
                 
                  <div class="row">
                      <div class="col-md-3">      
                          <span>Tipo Poliza:</span>
                      </div>
                      <div class="col-md-8">      
                           <asp:Label ID="lblTipoPoliza" runat="server" Text=""></asp:Label>
                      </div>
                  </div>
                  
                  <div class="row">
                       <div class="col-md-3">      
                           <span id="lblprima_bruta">Prima Total:</span>
                       </div>
                       <div class="col-md-8">      
                              <table style="width: 100%;">
                                  <tr>
                                      <td style="width: 125px; height: 18px">          
                                          <dx:ASPxSpinEdit ID="txtPrimaBruta" Width="125px" runat="server" Number="0" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                              <SpinButtons ShowLargeIncrementButtons="true" />
                                          </dx:ASPxSpinEdit>
                 
                                      </td>
                                      <td style="width: 65px; height: 18px">
                                          <span>Nº Cuotas:</span>
                                      </td>
                                      <td style="width: 60px; height: 18px">                                          
                                          <dx:ASPxSpinEdit ID="txtNumCuotas" Width="50px" runat="server" Number="0" MinValue="0" MaxValue="40" Increment="1" NumberType="Float">    
                                          </dx:ASPxSpinEdit>
  
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
                     <div class="col-md-3">      
                         <span>Prima Neta:</span>
                     </div>
                     <div class="col-md-9">      
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 125px; height: 18px">          
                                        <dx:ASPxSpinEdit ID="txtPrimaNeta" Width="125px" runat="server" Number="0" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                            <SpinButtons ShowLargeIncrementButtons="true" />
                                        </dx:ASPxSpinEdit>
                 
                                    </td>
                                    <td style="width: 65px; height: 18px">
                                        <span>Porcentaje:</span>
                                    </td>
                                    <td style="width: 70px; height: 18px">                                          
                                        <dx:ASPxSpinEdit ID="txtPorcentaje" Width="70px" runat="server" Number="0" MinValue="0" MaxValue="40" Increment="1" NumberType="Float">    
                                        </dx:ASPxSpinEdit>
  
                                    </td>
                                    <td style="width: 45px; height: 18px">
                                         <span>Comision:</span>                            
                                    </td>
                                    <td style="width: 100px; height: 18px">
                                       <dx:ASPxSpinEdit ID="txtComision" Width="70px" runat="server" Number="0" MinValue="0" MaxValue="40" Increment="1" NumberType="Float">    
                                        </dx:ASPxSpinEdit>
                                    </td>
                                    <td style="width: 70px; height: 18px">
                                        <asp:Button ID="btnCalcular" runat="server" Text="Calcular" OnClick="btnCalcular_Click" />
                                    </td>
                                </tr>
          
                            </table>
                     </div>
                 </div>

                  <div class="row">
                       <div class="col-md-3">      
                           <span id="lbltipo_cuota">Forma de Pago</span>
                       </div>
                       <div class="col-md-8">      
                           <dx:ASPxRadioButtonList ID="tipo_cuota" runat="server" RepeatDirection="Horizontal" Border-BorderStyle="None">
                              <Items>
                                  <dx:ListEditItem Text="Contado" Value="True" Selected></dx:ListEditItem>
                                  <dx:ListEditItem Text="Crédito" Value="False"></dx:ListEditItem>
                              </Items>
                          </dx:ASPxRadioButtonList>
                       </div>
                   </div>
                  
                  <div class="row">
                      <div class="col-md-3">      
                          <span id="lblmat_aseg">Mat. Asegurada:</span>
                      </div>
                      <div class="col-md-8">      
                           <dx:ASPxMemo ID="txtMatAseg" runat="server" Height="71px" Width="100%"></dx:ASPxMemo>
                      </div>
                  </div>
                  
                  <div class="row">
                       <div class="col-md-2">      
           
                       </div>
                       <div class="col-md-8"> 
                           <div class="panel-group">
                            <div class="panel panel-default">
                              <div class="panel-body">Cuotas de la Poliza</div>
                            </div>
                            <div class="panel panel-default">
                              <div class="panel-body">

                                  <asp:GridView ID="grdCuotasPoliza" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                      <Columns>
                                          <asp:BoundField DataField="cuota" HeaderText="Cuota" >
                                          <ControlStyle Width="20px" />
                                          </asp:BoundField>
                                          <asp:TemplateField HeaderText="Fecha Pago">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fecha_pago") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>
                                                   <dx:ASPxDateEdit ID="dtFechaPago" ClientInstanceName="dtFechaPago" runat="server" Width="100%" 
                                                       Date='<%# Bind("fecha_pago") %>' DateOnError="Null">
                                                       <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" ErrorDisplayMode="ImageWithText" EnableCustomValidation="true">  <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                                               <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                                                         </ValidationSettings>  
                                                   </dx:ASPxDateEdit>
                                              </ItemTemplate>
                                              <ControlStyle Width="50px" />
                                          </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Cuota Total">
                                              <EditItemTemplate>
                                                  <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cuota_total") %>'></asp:TextBox>
                                              </EditItemTemplate>
                                              <ItemTemplate>                                                
                                                  <dx:ASPxSpinEdit ID="txtCuotaTotal" Width="125px" runat="server" Number="0" MinValue="0" MaxValue="10000000000" 
                                                      Increment="0.1" LargeIncrement="1" NumberType="Float" Text='<%# Bind("cuota_total") %>'>
                                                      <SpinButtons ShowLargeIncrementButtons="true" />
                                                  </dx:ASPxSpinEdit>
                                              </ItemTemplate>
                                              <ControlStyle Width="50px" />
                                          </asp:TemplateField>
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


    <div class="post">
                <h1 class="title">
                    <span id="ctl00_cpmaster_titulo" class="title">Datos de Poliza Incluida (Módulo de Cobranzas)</span></h1>
                <div class="entry">
                    <img src="images/aplicacion.png" alt="" width="128" height="128" class="left">
                    <div>
                        <table cellpadding="0" cellspacing="0" style="width: 520px">
                            <tbody><tr>
                                <td colspan="4">
                                    <span id="ctl00_cpmaster_fechas" style="font-weight:bold;">Fechas</span>
                                    <input type="hidden" name="ctl00$cpmaster$fc_reg" id="ctl00_cpmaster_fc_reg">
                                    <input type="hidden" name="ctl00$cpmaster$numpoliza" id="ctl00_cpmaster_numpoliza">
                                    <input type="hidden" name="ctl00$cpmaster$id_mom" id="ctl00_cpmaster_id_mom" value="65297">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 95px">
                                    <span id="ctl00_cpmaster_lblfecemis">Fecha de Emisión :</span>
                                </td>
                                <td>
                                    <input name="ctl00$cpmaster$fc_emision" type="text" value="15/11/2023" id="ctl00_cpmaster_fc_emision" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:75px;">
                                    
                                    <input type="image" name="ctl00$cpmaster$ibtncalendario" id="ctl00_cpmaster_ibtncalendario" src="images/Calendar_scheduleHS.png" alt="Click en la Imagen para mostrar el Calendario" style="border-width:0px;">
                                </td>
                                <td style="width: 110px">
                                    <span id="ctl00_cpmaster_lblfc_recepcion">Fecha de Recepción :</span>
                                </td>
                                <td>
                                    <input name="ctl00$cpmaster$fc_recepcion" type="text" value="15/11/2023" id="ctl00_cpmaster_fc_recepcion" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:75px;">
                                    
                                    <input type="image" name="ctl00$cpmaster$ibtncalendario1" id="ctl00_cpmaster_ibtncalendario1" src="images/Calendar_scheduleHS.png" alt="Click en la Imagen para mostrar el Calendario" style="border-width:0px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 95px">
                                    <span id="ctl00_cpmaster_lblfc_inivig">Inicio Vigencia :</span>
                                </td>
                                <td style="width: 100px">
                                    <input name="ctl00$cpmaster$fc_inivig" type="text" value="10/11/2023" id="ctl00_cpmaster_fc_inivig" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:75px;">
                                    
                                    <input type="image" name="ctl00$cpmaster$ibtncalendario2" id="ctl00_cpmaster_ibtncalendario2" src="images/Calendar_scheduleHS.png" alt="Click en la Imagen para mostrar el Calendario" style="border-width:0px;">
                                </td>
                                <td>
                                    <span id="ctl00_cpmaster_lblfc_finvig">Fin Vigencia :</span>
                                </td>
                                <td>
                                    <span id="ctl00_cpmaster_fc_finvig">18/11/2023</span>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 18px; width: 95px;">
                                    <span id="ctl00_cpmaster_lblnumero">N° de Poliza :</span>
                                </td>
                                <td style="height: 18px">
                                    <span id="ctl00_cpmaster_num_poliza">12345</span>
                                    </td><td style="height: 18px">
                                        <span id="ctl00_cpmaster_lblnumliquida">Nº Liquidación :</span>
                                    </td>
                                    <td style="height: 18px">
                                        <input name="ctl00$cpmaster$no_liquida" type="text" value="1123456" id="ctl00_cpmaster_no_liquida" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:75px;">
                                    </td>
                                
                            </tr>
                            <tr>
                                <td style="height: 18px; width: 95px;">
                                    <span id="ctl00_cpmaster_Label1">Asegurado :</span>
                                </td>
                                <td colspan="3" style="height: 18px">
                                    <span id="ctl00_cpmaster_nomraz"> ELIAS ARRAYA PABLO ENRIQUEZ</span>
                                    <input type="hidden" name="ctl00$cpmaster$id_per" id="ctl00_cpmaster_id_per" value="3142650014">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 18px; width: 95px;">
                                    <span id="ctl00_cpmaster_lbldireccion">Dirección :</span>
                                </td>
                                <td colspan="3" style="height: 18px">
                                    <span id="ctl00_cpmaster_direccion">EDIF. ENRIQUE Nº. 1760</span>
                                    <input type="hidden" name="ctl00$cpmaster$id_dir" id="ctl00_cpmaster_id_dir" value="7393">
                                </td>
                            </tr>
                            <tr>
                                <td class="style1">
                                    <span id="ctl00_cpmaster_Label3">Grupo :</span>
                                </td>
                                <td colspan="3">
                                    <span id="ctl00_cpmaster_desc_grupo">PROFIN</span>
                                    <input type="hidden" name="ctl00$cpmaster$id_gru" id="ctl00_cpmaster_id_gru" value="57">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 18px; width: 95px;">
                                    <span id="ctl00_cpmaster_Label2">Cia Aseguradora :</span>
                                </td>
                                <td style="height: 24px" colspan="3">
                                    <span id="ctl00_cpmaster_nomco"></span>
                                    <input type="hidden" name="ctl00$cpmaster$id_spvs" id="ctl00_cpmaster_id_spvs" value="207">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 18px; width: 95px;">
                                    <span id="ctl00_cpmaster_lblnombre">Producto :</span>
                                </td>
                                <td colspan="3">
                                    <span id="ctl00_cpmaster_desc_producto">ASISTENCIA GLOBAL</span>
                                    <input type="hidden" name="ctl00$cpmaster$id_producto" id="ctl00_cpmaster_id_producto" value="146">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 18px; width: 95px;">
                                    <span id="ctl00_cpmaster_lblejecutivo">Ejecutivo :</span>
                                </td>
                                <td colspan="3">
                                    <select name="ctl00$cpmaster$id_perejec" id="ctl00_cpmaster_id_perejec" style="color:#0F5B96;background-color:White;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
		<option value="0"> SELECCIONE UNA OPCIÓN</option>
		<option selected="selected" value="1545453-1">ARABE PAZ DALCY TERESA</option>
		<option value="4892935-E">CAMACHO SAAVEDRA CARLA MARIELA-E</option>
		<option value="4385642-EJ">CASTELLON GARCIA MONICA ROCIO </option>
		<option value="3270104">CHAVEZ DE LA PEÑA ROXANA</option>
		<option value="4688042">CUELLAR VARGAS PAOLA ANDREA </option>
		<option value="2715136-E">DIEZ DE MEDINA SANJINES LOURDES PATRICIA</option>
		<option value="-4855832016-">FOSSATI MIRANDA ELIANA KARINA-E</option>
		<option value="484208">GALLARDO COCA JAQUELINE</option>
		<option value="6808985-">GALLO MEDINACELI PAOLA CECILIA-E</option>
		<option value="4865989">GUTIERREZ RASSO LAURA GABRIELA</option>
		<option value="9184848-E">JOEL ALE TORO AJATA-E</option>
		<option value="3389623-">LEAÑO BADANI HERNAN</option>
		<option value="4792017E">LOAYZA YAÑEZ GRISELDA </option>
		<option value="10203040">LOPEZ CHACON SILVANA</option>
		<option value="2973792">PALACIOS VILELA SUSANA ESTHER</option>
		<option value="24488071">PIER RUTH GUEVARA AVILA</option>
		<option value="24092021">PREVICORSC</option>
		<option value="4278656-1">PRV</option>
		<option value="8340153-EJ">RAMOS CHACON JENNY</option>
		<option value="3459705-1">RDCC</option>
		<option value="190520022">RESCATE O Y M SRL</option>
		<option value="1553678">ROLANDO FELIX GUILLEN VEGA</option>
		<option value="3731033-">SANDOVAL GOMEZ CANDY MONICA-E</option>
		<option value="8992756-EJ">SCHRUPP PLATA SISMAL YESHUAR</option>
		<option value="3498271-">SOLIZ LOZADA PAOLA MARIA-E</option>
		<option value="2384433-E">TABORGA ACOSTA JUAN ALBERTO</option>
		<option value="404216027-">TRIGO RIVERO PATRICIO</option>
		<option value="10812020-">TUNO CARTAGENA DIANNE GARDENIA-E</option>
		<option value="1088655">VEIZAGA ALARCON CONSUELO </option>
		<option value="2878381">YOLANDA NICACIA GUTIERREZ RIVAS</option>

	</select>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 95px; height: 18px">
                                    <span id="ctl00_cpmaster_lblagente">Agente Cartera :</span>
                                </td>
                                <td colspan="3" style="height: 18px">
                                    <span id="ctl00_cpmaster_nomcart">*ALFARO VALVERVE JOSE*</span>
                                    <input type="hidden" name="ctl00$cpmaster$id_percart" id="ctl00_cpmaster_id_percart" value="5369550-">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 18px; width: 95px;">
                                    <span id="ctl00_cpmaster_Label4">Tipo Poliza :</span>
                                </td>
                                <td style="width: 100px">
                                    <span id="ctl00_cpmaster_clase_poliza">Normal</span>
                                </td>
                                <td style="width: 100px">
                                    &nbsp;
                                </td>
                                <td style="width: 205px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 95px; height: 18px">
                                    <span id="ctl00_cpmaster_lblprima_bruta">Prima Total :</span>
                                </td>
                                <td colspan="3" style="height: 18px">
                                    <input name="ctl00$cpmaster$prima_bruta" type="text" value="0,00" maxlength="15" id="ctl00_cpmaster_prima_bruta" onkeypress="return(currencyFormat(this,event));" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:75px;">
                                    &nbsp;
                                    <span id="ctl00_cpmaster_lblnum_cuota">Nº Cuotas :</span>
                                    &nbsp;
                                    <input name="ctl00$cpmaster$num_cuota" type="text" value="20" maxlength="2" readonly="readonly" id="ctl00_cpmaster_num_cuota" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:25px;">
                                    &nbsp;
                                    <span id="ctl00_cpmaster_lblid_div">Divisa :</span>
                                    &nbsp;
                                    <span id="ctl00_cpmaster_nomdiv">BS</span>
                                    <input type="hidden" name="ctl00$cpmaster$id_div" id="ctl00_cpmaster_id_div" value="37">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 95px; height: 18px">
                                    <span id="ctl00_cpmaster_Label5">Prima Neta :</span>
                                </td>
                                <td colspan="3" style="height: 18px">
                                    <input name="ctl00$cpmaster$prima_neta" type="text" value="0,00" id="ctl00_cpmaster_prima_neta" onkeypress="return(currencyFormat(this,event));" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:75px;">
                                    &nbsp;<span id="ctl00_cpmaster_Label6">Porcentaje :</span>
                                    <input name="ctl00$cpmaster$por_comision" type="text" value="0,00" id="ctl00_cpmaster_por_comision" onkeypress="return(currencyFormat(this,event));" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:50px;">
                                    &nbsp;<span id="ctl00_cpmaster_Label7">Comisión :</span>
                                    <input name="ctl00$cpmaster$comision" type="text" value="0,00" id="ctl00_cpmaster_comision" onkeypress="return(currencyFormat(this,event));" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:50px;">
                                    <input type="submit" name="ctl00$cpmaster$btncalculo" value="Calcular" id="ctl00_cpmaster_btncalculo" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 95px; height: 18px">
                                    <span id="ctl00_cpmaster_lbltipo_cuota">Forma de Pago</span>
                                </td>
                                <td colspan="3" style="height: 18px">
                                    <table id="ctl00_cpmaster_tipo_cuota" border="0">
		<tbody><tr>
			<td><label for="ctl00_cpmaster_tipo_cuota_0">Contado</label><input id="ctl00_cpmaster_tipo_cuota_0" type="radio" name="ctl00$cpmaster$tipo_cuota" value="True" checked="checked"></td><td><label for="ctl00_cpmaster_tipo_cuota_1">Crédito</label><input id="ctl00_cpmaster_tipo_cuota_1" type="radio" name="ctl00$cpmaster$tipo_cuota" value="False"></td>
		</tr>
	</tbody></table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 95px; height: 18px">
                                    <span id="ctl00_cpmaster_lblmat_aseg">Mat. Asegurada :</span>
                                </td>
                                <td colspan="3" style="height: 18px">
                                    <textarea name="ctl00$cpmaster$mat_aseg" rows="2" cols="20" id="ctl00_cpmaster_mat_aseg" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:250px;">TEST</textarea>
                                    <input type="hidden" name="ctl00$cpmaster$id_clamov" id="ctl00_cpmaster_id_clamov" value="44">
                                    <input type="hidden" name="ctl00$cpmaster$estado" id="ctl00_cpmaster_estado" value="COBRANZAS">
                                    <input type="hidden" name="ctl00$cpmaster$id_poliza" id="ctl00_cpmaster_id_poliza" value="37248">
                                    <input type="hidden" name="ctl00$cpmaster$id_mov" id="ctl00_cpmaster_id_mov" value="65297">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="height: 18px; text-align: center;">
                                    <div class="gridcontainer" style="width: 500px">
                                        <div>

	</div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <input type="submit" name="ctl00$cpmaster$btnnuevo" value="Nuevo" id="ctl00_cpmaster_btnnuevo" title="Registrar nueva Poliza" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                    <input type="submit" name="ctl00$cpmaster$btncuotas" value="Cuotas" id="ctl00_cpmaster_btncuotas" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                    
                                    
                                </td>
                            </tr>
                        </tbody></table>
                    </div>
                </div>
                <p class="links">
                    <span id="ctl00_cpmaster_lblmensaje" class="error"></span>
                </p>
            </div>

    
</asp:Content>
