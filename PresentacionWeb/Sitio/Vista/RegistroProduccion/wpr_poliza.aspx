<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_poliza.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.RegistroProduccion.wpr_poliza" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">

            <div class="post">
                <div>
                    

    <script type="text/javascript" src="scripts/fieldScripts.js"></script>

    <script type="text/javascript" src="scripts/validaciones.js"></script>


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
               <dx:ASPxDateEdit ID="fc_emision" runat="server" Width="100%"></dx:ASPxDateEdit>
            </div>
            <div class="col-md-3">      
               <span id="lblfc_recepcion">Fecha de Recepción:</span>
            </div>
            <div class="col-md-3">      
               <dx:ASPxDateEdit ID="fc_recepcion" runat="server" Width="100%"></dx:ASPxDateEdit>
            </div>
        </div>
        <%--<br />--%>
        <div class="row">
            <div class="col-md-3">      
               <span id="lblfc_inivig">Inicio Vigencia:</span>
            </div>
            <div class="col-md-3">      
               <dx:ASPxDateEdit ID="fc_inivig" runat="server" Width="100%"></dx:ASPxDateEdit>
            </div>
            <div class="col-md-3">      
               <span id="ctl00_cpmaster_lblfc_finvig">Fin Vigencia:</span>
            </div>
            <div class="col-md-3">      
               <dx:ASPxDateEdit ID="fc_finvig" runat="server" Width="100%"></dx:ASPxDateEdit>  
            </div>
        </div>
        <%--<br />--%>
        <div class="row">
            <div class="col-md-3">      
               <span id="lblnumero">N° de Poliza:</span>
            </div>
            <div class="col-md-3">      
               <dx:ASPxTextBox ID="num_poliza" runat="server" Width="100%"></dx:ASPxTextBox>
            </div>
            <div class="col-md-3">      
               <span id="lblnumliquida">Nº Liquidación:</span>
            </div>
            <div class="col-md-3">      
               <dx:ASPxTextBox ID="no_liquida" runat="server" Width="100%"></dx:ASPxTextBox>  
            </div>
        </div>
        <%--<br />--%>
        <div class="row">
             <div class="col-md-3">      
                <span id="ctl00_cpmaster_Label1">Asegurado :</span>
             </div>
             <div class="col-md-7">      
                <dx:ASPxTextBox ID="nomraz" runat="server" Width="100%"></dx:ASPxTextBox> 
             </div>
            <div class="col-md-1">
                <button type="button" name="btnserper" data-bs-toggle="modal" data-bs-target="#modal_btnserper" id="btnserper" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                  ...
                </button>
            </div>
         </div>
        <%--<br />--%>
        <div class="row">
             <div class="col-md-3">      
                <span id="lbldireccion">Dirección :</span>
             </div>
             <div class="col-md-7">      
                <dx:ASPxTextBox ID="direccion" runat="server" Width="100%"></dx:ASPxTextBox> 
             </div>
            <div class="col-md-1">
                <button type="button" name="btnserper" data-bs-toggle="modal" data-bs-target="#modal_btnserper" id="btnserper" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                  ...
                </button>
            </div>
         </div>
        <%--<br />--%>
        <div class="row">
            <div class="col-md-3">      
                <span id="ctl00_cpmaster_Label3">Grupo :</span>
            </div>
            <div class="col-md-8">      
                <dx:ASPxComboBox ID="id_gru" runat="server" ValueType="System.String" Width="100%"></dx:ASPxComboBox>
            </div>
        </div>
        <%--<br />--%>
        <div class="row">
            <div class="col-md-3">      
                <span id="ctl00_cpmaster_Label2">Cia Aseguradora :</span>
            </div>
            <div class="col-md-8">      
                <dx:ASPxComboBox ID="id_spvs" runat="server" ValueType="System.String" Width="100%"></dx:ASPxComboBox>
            </div>
        </div>
        <%--<br />--%>
        <div class="row">
             <div class="col-md-3">      
                 <span id="lblnombre">Producto :</span>
             </div>
             <div class="col-md-8">      
                 <dx:ASPxComboBox ID="id_producto" runat="server" ValueType="System.String" Width="100%"></dx:ASPxComboBox>
             </div>
         </div>
        <%--<br />--%>
        <div class="row">
             <div class="col-md-3">      
                 <span id="ctl00_cpmaster_Label5">Tipo de Cartera :</span>
             </div>
             <div class="col-md-8">      
                 <dx:ASPxComboBox ID="id_clamov1" runat="server" ValueType="System.String" Width="100%"></dx:ASPxComboBox>
             </div>
         </div>
        <%--<br />--%>
        <div class="row">
             <div class="col-md-3">      
                <span id="ctl00_cpmaster_lblejecutivo">Ejecutivo:</span>
             </div>
             <div class="col-md-8">      
                  <dx:ASPxComboBox ID="id_perejec" runat="server" ValueType="System.String" Width="100%"></dx:ASPxComboBox>
             </div>
         </div>
        <%--<br />--%>
        <div class="row">
            <div class="col-md-3">      
                <span id="ctl00_cpmaster_lblagente">Agente Cartera:</span>
            </div>
            <div class="col-md-8">      
                <dx:ASPxComboBox ID="id_percart" runat="server" ValueType="System.String"></dx:ASPxComboBox>
            </div>
        </div>
        <%--<br />--%>
        <div class="row">
            <div class="col-md-3">      
                <span id="ctl00_cpmaster_Label4">Tipo Poliza:</span>
            </div>
            <div class="col-md-8">      
                 <dx:ASPxRadioButtonList ID="clase_poliza" runat="server" RepeatDirection="Horizontal" Border-BorderStyle="None">
                     <Items>
                         <dx:ListEditItem Text="Normal" Value="True"></dx:ListEditItem>
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
                            <td style="width: 150px; height: 18px">          
                                <%--<input name="ctl00$cpmaster$prima_bruta" type="text" value="0,00" maxlength="15" id="ctl00_cpmaster_prima_bruta" onkeypress="return(currencyFormat(this,event));" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:75px;">--%>
                                <dx:ASPxSpinEdit ID="prima_bruta" Width="150px" runat="server" Number="1.1" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                    <SpinButtons ShowLargeIncrementButtons="true" />
                                </dx:ASPxSpinEdit>
                               
                            </td>
                            <td style="width: 65px; height: 18px">
                                <span id="ctl00_cpmaster_lblnum_cuota">Nº Cuotas:</span>
                            </td>
                            <td style="width: 60px; height: 18px">
                                <%--<input name="ctl00$cpmaster$num_cuota" type="text" maxlength="2" id="ctl00_cpmaster_num_cuota" onkeydown="return dFilter (event.keyCode, this, '##');" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:25px;">--%>
                                <dx:ASPxTextBox ID="num_cuota" runat="server" Width="50px"></dx:ASPxTextBox>
                
                            </td>
                            <td style="width: 45px; height: 18px">
                                 <span id="ctl00_cpmaster_lblid_div">Divisa:</span>                            
                            </td>
                            <td style="width: 100px; height: 18px">
                                <dx:ASPxComboBox ID="id_div" runat="server" ValueType="System.String" Width="100px"></dx:ASPxComboBox>

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
                        <dx:ListEditItem Text="Contado" Value="True"></dx:ListEditItem>
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
                 <dx:ASPxMemo ID="mat_aseg" runat="server" Height="71px" Width="100%"></dx:ASPxMemo>
            </div>
        </div>
        <%--<br />--%>
        <div class="row">
            <div class="col-md-4">      
        
            </div>
            <div class="col-md-7">      
                <input type="submit" name="ctl00$cpmaster$btncuotas" value="Cuotas" id="ctl00_cpmaster_btncuotas" title="Mostrar Datos de las Cuotas de la Poliza" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                <input type="submit" name="ctl00$cpmaster$btnsalir" value="Salir" id="ctl00_cpmaster_btnsalir" title="Salir del Formulario" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">                            
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

</asp:Content>
