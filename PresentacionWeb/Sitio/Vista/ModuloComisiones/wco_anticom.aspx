<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wco_anticom.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ModuloComisiones.wco_anticom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <script type="text/javascript">

</script>
    <div id="container">
        <div class="card p-3">

            <h1 class="title">Registro de Anticipo sobre comisiones</h1>
            <div class="row">
                <div class="col-4 col-sm-4 col-md-4 col-lg-4 text-center">
                    <img src="images/poliza.gif" alt="" width="128" height="128" class="left">
                </div>
                <div class="col-8 col-sm-8 col-md-7 col-lg-6">
            
                            <div class="row">
                                
                                <div class="col-2">

                                    <span id="ctl00_cpmaster_Label2">Ejecutivo de Cartera :</span>
                                </div>
                                <div class="col-4">
                                    <select name="ctl00$cpmaster$id_percart" id="ctl00_cpmaster_id_percart" style="color: #0F5B96; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                        <option value="0">SELECCIONE UNA OPCIÓN</option>
                                        <option value="4278656">"XIMENA ROSARIO ROMERO VILLAZON - SERVICIOS DE CONSULTORIA"</option>
                                        <option value="5369550-">*ALFARO VALVERVE JOSE*</option>
                                        <option value="-5369550-">-ALFARO VALVERVE JOSE- E.A.</option>
                                        <option value="244514027">ABC MULTISERVICE S.R.L.</option>
                                        <option value="5369550">ALFARO VALVERDE JOSE-A</option>
                                        <option value="2384433-JA">ALMANZA LOPEZ JONNY FRANCISCO - C</option>
                                        <option value="6779496">ALVAREZ FERNANDEZ JOSE LUIS</option>
                                        <option value="3353792-E">BALDIVIA BARRERA MONICA ALEJANDRA (C)</option>
                                        <option value="7271335">BALLON SANDOVAL CHRISTIAN RODRIGO-A</option>
                                        <option value="6889725">BLANCO QUIROGA MISHEL CRISTINA</option>
                                        <option value="4892935-A">CAMACHO SAAVEDRA CARLA MARIELA-A</option>
                                        <option value="5473062-EF">CAMACHO VALLEJOS SULEYDI-EF</option>
                                        <option value="1332444010">CARVAJAL VLADIMIR </option>
                                        <option value="144478023DC">DESARROLLO PREVICOR</option>
                                        <option value="2715136">DIEZ DE MEDINA SANJINES LOURDES PATRICIA</option>
                                        <option value="4445976">ESPINOZA GUTIERREZ LINETTE</option>
                                        <option value="2319993-">FERNANDEZ-DAVILA PINELL EDWIN NELSON</option>
                                        <option value="6808985">GALLO MEDINACELI PAOLA CECILIA-A</option>
                                        <option value="4865989-">GUTIERREZ RASSO LAURA GABRIELA</option>
                                        <option value="2228902-A">IMAÑA LAZO DAGNER-A</option>
                                        <option value="3389623&quot;30&quot;">LEAÑO BADANI HERNAN "30"</option>
                                        <option value="3389623">LEAÑO BADANI HERNAN ALEXIS-50</option>
                                        <option value="4792017-1">LOAYZA YAÑEZ GRISELDA</option>
                                        <option value="6851582">LOPEZ CHACON SILVANA</option>
                                        <option value="4307751">MARIACA OBLITAS PAOLA CESILIA</option>
                                        <option value="625902PG">MEDINACELI SANDOVAL LIDIA REMEDIOS-PG</option>
                                        <option value="3390625-">MOLINA JUANES IVAN</option>
                                        <option value="6762236-LG">MORALES LINARES ALEJANDRO TITO-LG</option>
                                        <option value=" 3424423-A">ORTEGA RIOS MIRIAM CONSUELO-A</option>
                                        <option value="4269453">PERALES HENRICH CARLOS MARCELO</option>
                                        <option value="4269453-20">PERALES HENRICH CARLOS MARCELO-20</option>
                                        <option value="275255">PREVICOR CORREDORES Y ASESORES DE SEGUROS SRL</option>
                                        <option value="8992756-SCZ-20">PREVICOR SCZ SS-20</option>
                                        <option value="1553678-1-RG">PREVICOR SCZ-RG</option>
                                        <option value="8340153-A">PREVICOR-JR</option>
                                        <option value="9184847">PREVICOR-JTA</option>
                                        <option value="4309476CV">RAMIREZ SALAMANCA ERICK REYNALDO-CV</option>
                                        <option value="465384">REQUENA VILELA FLAVIO ISAAC</option>
                                        <option value="3498271">SOLIZ LOZADA PAOLA MARIA</option>
                                        <option value="2384433-37">TABORGA ACOSTA JUAN ALBERTO-37</option>
                                        <option value="2384433">TABORGA ACOSTA JUAN ALBERTO-A</option>
                                        <option value="E-11603382">TEJERINA ROBERTO-PS</option>
                                        <option value="2384433-PT">TRIGO RIVERO PATRICIO ARNOLDO "30"</option>
                                        <option value="404216027">TRIGO RIVERO PATRICIO ARNOLDO"50"</option>
                                        <option value="2716552-60">TRIGO RIVERO PATRICIO ARNOLDO-60</option>
                                        <option value="4898066&quot;50&quot;">ULLOA BUTRON FABIOLA P</option>
                                        <option value="4898066-30">ULLOA BUTRON FABIOLA PAOLA "30"</option>
                                        <option value="275255015">VALDA RAMIREZ ROLANDO</option>
                                        <option value="275255015GL">VALDA RAMIREZ ROLANDO-GL</option>
                                        <option value="5126025-1K">VALDA ROMAY VIVIAN CECILIA</option>

                                    </select>
                                </div>
                            </div>
                           
                            <div class="row">
                                
                                <div class="col-2">
                                    <span id="ctl00_cpmaster_Label3">Fecha de Solicitud :</span>
                                </div>
                                <div class="col-4">
                                    <input name="ctl00$cpmaster$fc_solicitud" type="text" value="15/1/2024" id="ctl00_cpmaster_fc_solicitud" onkeydown="return dFilter (event.keyCode, this, '##/##/####');" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 75px;">

                                    <input type="image" name="ctl00$cpmaster$ibtncalendario" id="ctl00_cpmaster_ibtncalendario" src="images/Calendar_scheduleHS.png" alt="Click en la Imagen para mostrar el Calendario" style="border-width: 0px;">
                                </div>
                            </div>
                          
                            <div class="row">
                                
                                <div class="col-2">
                                    <span id="ctl00_cpmaster_Label4">Documento :</span>
                                </div>
                                <div class="col-4">
                                    <input name="ctl00$cpmaster$doc_cont" type="text" maxlength="15" id="ctl00_cpmaster_doc_cont" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 163px;">
                                </div>
                            </div>
                         
                            <div class="row">
                               
                                <div class="col-2">
                                    <span id="ctl00_cpmaster_Label5">Importe :</span>
                                </div>
                                <div class="col-4">
                                    <input name="ctl00$cpmaster$imp_anticipo" type="text" value="0,00" maxlength="15" id="ctl00_cpmaster_imp_anticipo" onkeypress="return(currencyFormat(this,event));" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 75px;">
                                    <span id="ctl00_cpmaster_Label7">&nbsp;&nbsp;&nbsp;en $us</span>
                                </div>
                            </div>
                         
                            <div class="row">
                                
                                <div  class="col-2">
                                    <span id="ctl00_cpmaster_Label6">Concepto :</span>
                                </div>
                                <div class="col-4">
                                    <textarea name="ctl00$cpmaster$desc_anti" rows="3" cols="20" id="ctl00_cpmaster_desc_anti" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 353px;"></textarea>
                                </div>
                            </div>
                           
                            <tr>
                                <td class="style1" align="center" colspan="3">
                                    <input type="submit" name="ctl00$cpmaster$Button1" value="Guardar" id="ctl00_cpmaster_Button1" class="msg_button_class" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                    <input type="submit" name="ctl00$cpmaster$Button2" value="Nuevo" id="ctl00_cpmaster_Button2" class="msg_button_class" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                </td>
                            </tr>
                         
                     
                </div>
            </div>
            <p class="links">
                <span id="ctl00_cpmaster_lblmensaje" class="error">Introduzca Valores</span>
            </p>
 </div>
    </div>
</asp:Content>
