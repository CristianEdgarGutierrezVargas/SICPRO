<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_poliza.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.RegistroProduccion.wpr_poliza" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

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
    </script>

    <div class="card p-3 ">
                           

        <div class="container">
          <div class="row">
            <div class="col-md-3">      
                <h1 class="title"> Registro de Polizas</h1>
                <div class="entry">
                    <img src="../../../UI/img/poliza.gif" alt="" width="128" height="128" class="left">
                </div>      
            </div>    
            <div class="col-md-9">
      
                <br /><br /><br />

                <div class="row">
                  <div class="col-md-12">      
                      <span id="ctl00_cpmaster_fechas" style="font-weight:bold;">Fechas</span>
                  </div>
                </div>
                <%--<br />--%>
                <div class="row">
                    <div class="col-md-3">      
                      <span id="lblfecemis">Fecha de Emisión:</span>
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
                       <span id="lblfc_recepcion">Fecha de Recepción:</span>
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
                <%--<br />--%>
                <div class="row">
                    <div class="col-md-3">      
                       <span id="lblfc_inivig">Inicio Vigencia:</span>
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
                       <span id="ctl00_cpmaster_lblfc_finvig">Fin Vigencia:</span>
                    </div>
                    <div class="col-md-3">      
                       <dx:BootstrapDateEdit ID="fc_finvig" ClientInstanceName="fc_finvig" runat="server" Width="100%">
                            <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                           <ValidationSettings SetFocusOnError="True"  CausesValidation="true"  ErrorDisplayMode="ImageWithText" EnableCustomValidation="true" ValidationGroup="form_wgr_poliza">   <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                   <RequiredField ErrorText="Campo requerido" IsRequired="true"  />  
                             </ValidationSettings>  
                               <ClientSideEvents Init="function(s,e){  
                                                          var dt1 = new Date();  
                                                          var dt2 = new Date(dt1.getFullYear() + 1, dt1.getMonth(), dt1.getDate());  
                                                          var dt3 = new Date(dt1.getFullYear() - 2, dt1.getMonth(), dt1.getDate());  
                                                          fc_finvig.SetMinDate(new Date(dt3));  
                                                          fc_finvig.SetMaxDate(new Date(dt2));  
                                                       }" /> 
                       </dx:BootstrapDateEdit>  
                    </div>
                </div>
                <%--<br />--%>
                <div class="row">
                    <div class="col-md-3">      
                       <span id="lblnumero">N° de Poliza:</span>
                    </div>
                    <div class="col-md-3">      
                       <dx:BootstrapTextBox ID="txtNroPoliza" runat="server" Width="100%">
                           <CssClasses Input="form-control-sm fs-10" />
                           <ValidationSettings SetFocusOnError="True" RequiredField-IsRequired="true" ValidationGroup="form_wgr_poliza">
                                <RequiredField ErrorText="Campo requerido" IsRequired="True"></RequiredField>
                            </ValidationSettings>
                       </dx:BootstrapTextBox>
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
                <%--<br />--%>
                <div class="row">
                     <div class="col-md-3">      
                        <span id="ctl00_cpmaster_Label1">Asegurado :</span>
                     </div>
                     <div class="col-md-8">
                         <div class="row">
                             <div class="col-md-10">      
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
                             <div class="col-md-2">      
                               <dx:BootstrapButton ID="btnserper" runat="server" AutoPostBack="false" Text="..." OnClick="btnserper_Click">
                                    <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                    <SettingsBootstrap RenderOption="None" />
                                </dx:BootstrapButton>
                            </div>
                         </div>

                        <%--<dx:ASPxComboBox ID="cmbAsegurado" runat="server" ValueType="System.String" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="cmb_nomraz_SelectedIndexChanged">
                            <ValidationSettings SetFocusOnError="True" Display="Dynamic" ErrorTextPosition="Bottom" ValidationGroup="form_wgr_poliza" ErrorDisplayMode="ImageWithText" CausesValidation="false">
                              <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                            </ValidationSettings>
                        </dx:ASPxComboBox>--%>
                     </div>
                    <div class="col-md-1">
                        <%--<button type="button" name="btnserper" data-bs-toggle="modal" data-bs-target="#modal_btnserper" id="btndirper" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                          ...</button>--%>
                    </div>
                 </div>
                <%--<br />--%>
                <div class="row">
                     <div class="col-md-3">      
                        <span id="lbldireccion">Dirección :</span>
                     </div>
                     <div class="col-md-8">
                        <div class="row">
                            <div class="col-md-10">
                                <dx:BootstrapCallbackPanel ID="CallBDireccion" ClientInstanceName="CallBDireccion" runat="server" OnCallback="CallBDireccion_Callback">
                                    <ClientSideEvents EndCallback="OnEndCallbackDireccion"></ClientSideEvents>
                                    <ContentCollection>
                                        <dx:ContentControl>
                                            <dx:BootstrapTextBox runat="server" ID="desc_direccion" NullText="" Width="100%">
                                                <CssClasses Input="form-control-sm fs-10" />
                                            </dx:BootstrapTextBox>
                                            <asp:HiddenField runat="server" ID="id_direccion" Value="" />
                                        </dx:ContentControl>
                                    </ContentCollection>
                                </dx:BootstrapCallbackPanel>
                            </div>
                            <div class="col-md-2"> 
                                <dx:BootstrapButton ID="btnserdireccion" runat="server" AutoPostBack="false" Text="..." OnClick="btnserdireccion_Click">
                                    <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                    <SettingsBootstrap RenderOption="None" />
                                </dx:BootstrapButton>
                            </div>
                        </div>
                        <%--<dx:ASPxComboBox ID="cmbDireccion" runat="server" ValueType="System.String" Width="100%">                            
                        </dx:ASPxComboBox>--%>
                     </div>
                    <div class="col-md-1">
                       <%-- <button type="button" name="btndirper" data-bs-toggle="modal" data-bs-target="#modal_btndirper" id="btnserper" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                          ...
                        </button>--%>
                    </div>
                 </div>
                <%--<br />--%>
                <div class="row">
                    <div class="col-md-3">      
                        <span id="ctl00_cpmaster_Label3">Grupo :</span>
                    </div>
                    <div class="col-md-8">      
                        <dx:BootstrapComboBox ID="cmbGrupo" runat="server" ValueType="System.String" Width="100%">
                            <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                            <ValidationSettings SetFocusOnError="True" ValidationGroup="form_wgr_poliza" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                            </ValidationSettings>
                        </dx:BootstrapComboBox>
                    </div>
                </div>
                <%--<br />--%>
                <div class="row">
                    <div class="col-md-3">      
                        <span id="ctl00_cpmaster_Label2">Cia Aseguradora :</span>
                    </div>
                    <div class="col-md-8">      
                        <dx:BootstrapComboBox ID="cmbCiaAseg" runat="server" ValueType="System.String" Width="100%" AutoPostBack="True" OnSelectedIndexChanged="id_spvs_SelectedIndexChanged">
                            <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                            <ValidationSettings SetFocusOnError="True" ValidationGroup="form_wgr_poliza" ErrorDisplayMode="ImageWithText" CausesValidation="false">
                                <RequiredField ErrorText="Dato requerido" IsRequired="false" />
                            </ValidationSettings>
                        </dx:BootstrapComboBox>
                    </div>
                </div>
                <%--<br />--%>
                <div class="row">
                     <div class="col-md-3">      
                         <span id="lblnombre">Producto :</span>
                     </div>
                     <div class="col-md-8">      
                         <dx:BootstrapComboBox ID="cmbProducto" runat="server" ValueType="System.String" Width="100%">
                             <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                             <ValidationSettings SetFocusOnError="True" ValidationGroup="form_wgr_poliza" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                            </ValidationSettings>
                         </dx:BootstrapComboBox>
                     </div>
                 </div>
                <%--<br />--%>
                <div class="row">
                     <div class="col-md-3">      
                         <span id="ctl00_cpmaster_Label5">Tipo de Cartera :</span>
                     </div>
                     <div class="col-md-8">      
                         <dx:BootstrapComboBox ID="cmbTipoCartera" runat="server" ValueType="System.String" Width="100%">
                             <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                             <ValidationSettings SetFocusOnError="True" ValidationGroup="form_wgr_poliza" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                            </ValidationSettings>
                         </dx:BootstrapComboBox>
                     </div>
                 </div>
                <%--<br />--%>
                <div class="row">
                     <div class="col-md-3">      
                        <span id="ctl00_cpmaster_lblejecutivo">Ejecutivo:</span>
                     </div>
                     <div class="col-md-8">      
                          <dx:BootstrapComboBox ID="cmbEjecutivo" runat="server" ValueType="System.String" Width="100%">
                              <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                              <ValidationSettings SetFocusOnError="True" ValidationGroup="form_wgr_poliza" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                              </ValidationSettings>
                          </dx:BootstrapComboBox>
                     </div>
                 </div>
                <%--<br />--%>
                <div class="row">
                    <div class="col-md-3">      
                        <span id="ctl00_cpmaster_lblagente">Agente Cartera:</span>
                    </div>
                    <div class="col-md-8">      
                        <dx:BootstrapComboBox ID="cmbAgente" runat="server" ValueType="System.String" Width="100%">
                            <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                            <ValidationSettings SetFocusOnError="True" ValidationGroup="form_wgr_poliza" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                              <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                            </ValidationSettings>
                        </dx:BootstrapComboBox>
                    </div>
                </div>
                <%--<br />--%>
                <div class="row">
                    <div class="col-md-3">      
                        <span id="ctl00_cpmaster_Label4">Tipo Poliza:</span>
                    </div>
                    <div class="col-md-8">      
                         <dx:ASPxRadioButtonList ID="rbTipoPoliza" runat="server" RepeatDirection="Horizontal" Border-BorderStyle="None" ValueType="System.Boolean">
                             <Items>
                                 <dx:ListEditItem Text="Normal" Value="True" Selected></dx:ListEditItem>
                                 <dx:ListEditItem Text="Flotante" Value="False"></dx:ListEditItem>
                             </Items>
                         </dx:ASPxRadioButtonList>
                    </div>
                </div>
                <%--<br />--%>
                <div class="row">
                     <div class="col-md-3">      
                         <span id="lblprima_bruta">Prima Total:</span>
                     </div>
                     <div class="col-md-8">      
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 125px; height: 18px">          
                                        <%--<input name="ctl00$cpmaster$prima_bruta" type="text" value="0,00" maxlength="15" id="ctl00_cpmaster_prima_bruta" onkeypress="return(currencyFormat(this,event));" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:75px;">--%>
                                        <dx:BootstrapSpinEdit ID="txtPrimaBruta" Width="125px" runat="server" Number="0" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                            <SpinButtons ShowLargeIncrementButtons="true" />
                                        </dx:BootstrapSpinEdit>
                               
                                    </td>
                                    <td style="width: 65px; height: 18px">
                                        <span id="ctl00_cpmaster_lblnum_cuota">Nº Cuotas:</span>
                                    </td>
                                    <td style="width: 60px; height: 18px">
                                        <%--<input name="ctl00$cpmaster$num_cuota" type="text" maxlength="2" id="ctl00_cpmaster_num_cuota" onkeydown="return dFilter (event.keyCode, this, '##');" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:25px;">--%>
                                        
                                        <dx:BootstrapSpinEdit ID="txtNumCuotas" Width="50px" runat="server" Number="0" MinValue="0" MaxValue="40" Increment="1" NumberType="Float">    
                                        </dx:BootstrapSpinEdit>
                
                                    </td>
                                    <td style="width: 45px; height: 18px">
                                         <span id="ctl00_cpmaster_lblid_div">Divisa:</span>                            
                                    </td>
                                    <td style="width: 100px; height: 18px">
                                        <dx:BootstrapComboBox ID="cmbDivisa" runat="server" ValueType="System.String" Width="100px">
                                            <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                        </dx:BootstrapComboBox>

                                    </td>
                                </tr>
                        
                            </table>
                     </div>
                 </div>
                <%--<br />--%>
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
                <%--<br />--%>
                <div class="row">
                    <div class="col-md-3">      
                        <span id="lblmat_aseg">Mat. Asegurada:</span>
                    </div>
                    <div class="col-md-8">      
                         <dx:BootstrapMemo ID="txtMatAseg" runat="server" Rows="3" Width="100%"></dx:BootstrapMemo>
                    </div>
                </div>
                <%--<br />--%>

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
                                                 <dx:BootstrapDateEdit ID="dtFechaPago" ClientInstanceName="dtFechaPago" runat="server" Width="100%" 
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
                                                <dx:BootstrapSpinEdit ID="txtCuotaTotal" Width="125px" runat="server" Number="0" MinValue="0" MaxValue="10000000000" 
                                                    Increment="0.1" LargeIncrement="1" NumberType="Float" Text='<%# Bind("cuota_total") %>'>
                                                    <SpinButtons ShowLargeIncrementButtons="true" />
                                                </dx:BootstrapSpinEdit>
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
                        <dx:ASPxButton ID="btnCuotasPoliza" runat="server" Text="Guardar Poliza y Cuotas" CssClass="msg_button_class" OnClick="btnCuotasPoliza_Click" ValidationGroup="form_wgr_poliza"></dx:ASPxButton>
                       
                        <dx:ASPxButton ID="btnSalir" runat="server" Text="Salir" CssClass="msg_button_class" OnClick="btnSalir_Click"></dx:ASPxButton>
                    </div>
                </div>

            </div>
          </div>
        </div>

        <p class="links">
             <asp:Label ID="lblmensaje" runat="server" Text="Introduzca Valores" CssClass="error"></asp:Label>  
         </p>
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

        <dx:BootstrapPopupControl ID="pCDireccion" runat="server" ClientInstanceName="pCDireccion" ShowHeader="false" ShowFooter="true" Modal="true" CloseAction="None" SettingsBootstrap-Sizing="Small">
        <SettingsAdaptivity Mode="Always" MaxWidth="600px" />
        <CssClasses Content="pt-1" />
        <ContentCollection>
            <dx:ContentControl>
                <div class="row msg_button_class rounded-top-1">
                    <div class="col-12 fs-10 p-1 ">
                        <span>Busqueda de Direccion</span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        <div class="row">
                            <div class="col-12 text-center mt-2">
                                <img src="../../../UI/img/search_user.png" />
                            </div>
                            <div class="col-12 text-center mt-2">
                                <dx:BootstrapTextBox runat="server" ID="desc_direccion1" ClientInstanceName="desc_direccion1" NullText="" Width="150px">
                                    <CssClasses Input="form-control-sm fs-10" />
                                </dx:BootstrapTextBox>
                            </div>
                            <div class="col-12 text-center mt-2">
                                <dx:BootstrapButton ID="btnDireccion" runat="server" AutoPostBack="false" Text="-->" OnClick="btnDireccion_Click">
                                    <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                    <SettingsBootstrap RenderOption="None" />
                                </dx:BootstrapButton>
                            </div>
                        </div>
                    </div>
                    <div class="col-8 mt-2">

                        <dx:BootstrapGridView ID="grdDireccion" EnableCallBacks="true" runat="server" KeyFieldName="id_dir" ClientInstanceName="grdDireccion" OnDataBinding="grdDireccion_DataBinding">
                            <Settings ShowColumnHeaders="false" ShowTitlePanel="true" />
                            <SettingsText Title="Lista de Direcciones" />
                            <SettingsBehavior AllowFocusedRow="True" AllowClientEventsOnLoad="False" AllowSelectByRowClick="true" />
                            <ClientSideEvents RowClick="UpdateDetailGridDireccion" />
                            <SettingsBootstrap Striped="true" />
                            <CssClasses PanelHeading="msg_button_class p-1 fs-10 " />
                            <SettingsPager NumericButtonCount="3">
                                <PageSizeItemSettings Visible="false" Items="10, 20, 50" />
                            </SettingsPager>
                            <Columns>
                                <dx:BootstrapGridViewDataColumn FieldName="direccion" Width="200px" CssClasses-DataCell="fs-11"></dx:BootstrapGridViewDataColumn>

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
            <dx:BootstrapButton runat="server" ID="btnAceptarDireccion" OnClick="btnAceptarDireccion_Click" Text="Aceptar">
                <SettingsBootstrap RenderOption="None" Sizing="Small" />
                <CssClasses Control="msg_button_class" Text="fs-9" />
            </dx:BootstrapButton>
        </FooterContentTemplate>
    </dx:BootstrapPopupControl>





  

</asp:Content>
