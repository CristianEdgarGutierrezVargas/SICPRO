<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_polizacobranza.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.RegistroProduccion.wpr_polizacobranza" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="post">
                <h1 class="title">
                    Registro de Polizas</h1>
                <div class="entry">
                    <img src="images/poliza.gif" alt="" width="128" height="128" class="left">
                    <div>
                        <table cellpadding="0" cellspacing="0" style="width: 520px;">
                            <tbody><tr>
                                <td colspan="4">
                                    <span id="ctl00_cpmaster_fechas" style="font-weight:bold;">Fechas</span>
                                    <input type="hidden" name="ctl00$cpmaster$fc_reg" id="ctl00_cpmaster_fc_reg" value="3/12/2023">
                                    <input type="hidden" name="ctl00$cpmaster$numpoliza" id="ctl00_cpmaster_numpoliza">
                                    <input type="hidden" name="ctl00$cpmaster$id_mom" id="ctl00_cpmaster_id_mom" value="default">
                                    <input type="hidden" name="ctl00$cpmaster$a" id="ctl00_cpmaster_a" value="0">
                                    <input type="hidden" name="ctl00$cpmaster$b" id="ctl00_cpmaster_b" value="10">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 95px">
                                    <span id="ctl00_cpmaster_lblfecemis">Fecha de Emisión :</span>
                                </td>
                                <td>
                                    <input name="ctl00$cpmaster$fc_emision" type="text" value="10/11/2023" id="ctl00_cpmaster_fc_emision" onkeydown="return dFilter (event.keyCode, this, '##/##/####');" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:75px;">
                                    
                                    <input type="image" name="ctl00$cpmaster$ibtncalendario" id="ctl00_cpmaster_ibtncalendario" src="images/Calendar_scheduleHS.png" alt="Click en la Imagen para mostrar el Calendario" style="border-width:0px;">
                                </td>
                                <td style="width: 110px">
                                    <span id="ctl00_cpmaster_lblfc_recepcion">Fecha de Recepción :</span>
                                </td>
                                <td>
                                    <input name="ctl00$cpmaster$fc_recepcion" type="text" value="10/12/2023" id="ctl00_cpmaster_fc_recepcion" onkeydown="return dFilter (event.keyCode, this, '##/##/####');" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:75px;">
                                    
                                    <input type="image" name="ctl00$cpmaster$ibtncalendario1" id="ctl00_cpmaster_ibtncalendario1" src="images/Calendar_scheduleHS.png" alt="Click en la Imagen para mostrar el Calendario" style="border-width:0px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 95px">
                                    <span id="ctl00_cpmaster_lblfc_inivig">Inicio Vigencia :</span>
                                </td>
                                <td>
                                    <input name="ctl00$cpmaster$fc_inivig" type="text" value="10/11/2023" id="ctl00_cpmaster_fc_inivig" onkeydown="return dFilter (event.keyCode, this, '##/##/####');" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:75px;">
                                    
                                    <input type="image" name="ctl00$cpmaster$ibtncalendario2" id="ctl00_cpmaster_ibtncalendario2" src="images/Calendar_scheduleHS.png" alt="Click en la Imagen para mostrar el Calendario" style="border-width:0px;">
                                </td>
                                <td>
                                    <span id="ctl00_cpmaster_lblfc_finvig">Fin Vigencia :</span>
                                </td>
                                <td>
                                    <input name="ctl00$cpmaster$fc_finvig" type="text" value="30/12/2023" id="ctl00_cpmaster_fc_finvig" onkeydown="return dFilter (event.keyCode, this, '##/##/####');" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:75px;">
                                    
                                    <input type="image" name="ctl00$cpmaster$ibtncalendario3" id="ctl00_cpmaster_ibtncalendario3" src="images/Calendar_scheduleHS.png" alt="Click en la Imagen para mostrar el Calendario" style="border-width:0px;">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 18px; width: 95px;">
                                    <span id="ctl00_cpmaster_lblnumero">N° de Poliza :</span>
                                </td>
                                <td style="height: 18px">
                                    <input name="ctl00$cpmaster$num_poliza" type="text" value="12345" id="ctl00_cpmaster_num_poliza" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:75px;">
                                    </td><td style="height: 18px">
                                        <span id="ctl00_cpmaster_lblnumliquida">Nº Liquidación :</span>
                                    </td>
                                    <td style="height: 18px">
                                        <input name="ctl00$cpmaster$no_liquida" type="text" value="123" id="ctl00_cpmaster_no_liquida" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:75px;">
                                    </td>
                                
                            </tr>
                            <tr>
                                <td style="height: 18px; width: 95px;">
                                    <span id="ctl00_cpmaster_Label1">Asegurado :</span>
                                </td>
                                <td colspan="3" style="height: 18px">
                                    <input name="ctl00$cpmaster$nomraz" type="text" value=" ELIAS ARRAYA PABLO ENRIQUEZ" id="ctl00_cpmaster_nomraz" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:250px;">
                                    <input type="submit" name="ctl00$cpmaster$btnserper" value="..." id="ctl00_cpmaster_btnserper" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                    <input type="hidden" name="ctl00$cpmaster$id_per" id="ctl00_cpmaster_id_per" value="3142650014">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 18px; width: 95px;">
                                    <span id="ctl00_cpmaster_lbldireccion">Dirección :</span>
                                </td>
                                <td colspan="3" style="height: 18px">
                                    <input name="ctl00$cpmaster$direccion" type="text" value="EDIF. ENRIQUE Nº. 1760" id="ctl00_cpmaster_direccion" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:250px;">
                                    <input type="submit" name="ctl00$cpmaster$btnserdir" value="..." id="ctl00_cpmaster_btnserdir" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                    <input type="hidden" name="ctl00$cpmaster$id_dir" id="ctl00_cpmaster_id_dir" value="7393">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <span id="ctl00_cpmaster_Label3">Grupo :</span>
                                </td>
                                <td colspan="3">
                                    <select name="ctl00$cpmaster$id_gru" id="ctl00_cpmaster_id_gru" style="color:#0F5B96;background-color:White;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
	<option value="57">PROFIN</option>
	<option value="64">TRANSPORTADORES DE HIDROCARBUROS SRL</option>
	<option value="49">GRUPO CONSTEC</option>
	<option selected="selected" value="41">GASOLINERAS JUAN CARLOS FLORES HUAYTA</option>
	<option value="52">CRDALP</option>
	<option value="55">GRUPO EMPRESARIAL G5</option>
	<option value="9">GASOLINERAS ROMULO CLURE SEVERICHE</option>
	<option value="27">FAMILIA LIMON</option>
	<option value="20">FAMILIA COGNIGNI</option>
	<option value="53">EJECUTIVOS PREVICOR</option>
	<option value="0">SIN GRUPO</option>
	<option value="43">FLIA PONCE BOJANIC</option>
	<option value="50">EJECUTIVOS PRETENSA</option>
	<option value="48">GRUPO PRETENSA</option>
	<option value="11">GASOLINERAS RICHARD SILVA</option>
	<option value="15">FAMILIA LEAÑO</option>
	<option value="56">AFINES PREVICOR</option>
	<option value="34">IMPEXPAP S.A.</option>
	<option value="6">EJECUTIVOS FIE</option>
	<option value="63">EMPRESA DE SERVICIOS DELOSUR S.A.</option>
	<option value="8">GASOLINERAS ROGER INFANTES V.</option>
	<option value="58">GRUPO WILDLIFE </option>
	<option value="12">GASOLINERAS RENE IRIARTE</option>
	<option value="35">EJECUTIVOS SAE (AUTOMOTORES)</option>
	<option value="54">NOTARIOS TARIJA</option>
	<option value="47">FAMILIA BOHRT</option>
	<option value="32">IMCRUZ</option>
	<option value="19">TARIJA ECO GESTION</option>
	<option value="62">ARTES GRAFICAS SAGITARIO SRL</option>
	<option value="59">YPFB REFINACION</option>
	<option value="1">EJECUTIVOS EISBOL</option>
	<option value="51">SPC IMPRESORES S.A.</option>
	<option value="7">GASOLINERAS SERGIO IRIARTE</option>
	<option value="46">INPROCEM</option>
	<option value="17">HOTELES CAMINO REAL</option>
	<option value="38">SUBROGADAS BANCO BISA</option>
	<option value="25">GRUPO MILOS INTERNACIONAL</option>
	<option value="31">GASOLINERAS JULIA GONZALES DE GUTIERREZ</option>
	<option value="44">PLASTIC-Z</option>
	<option value="37">VULTEXIBER</option>
	<option value="28">GRUPO HANDAL Y NOVARA</option>
	<option value="23">GRUPO SAE</option>
	<option value="61">GRUPO EKE</option>
	<option value="24">FAMILIA PEREZ</option>
	<option value="30">GRUPO HARJES Y CIA. LTDA.</option>
	<option value="5">GASOLINERAS PEDRO IRIARTE</option>
	<option value="29">GASOLINERAS IRIARTE S.R.L.</option>
	<option value="14">GASOLINERAS EDWIN IRIARTE</option>
	<option value="33">GRUPO NEMER</option>
	<option value="-1">SELECCIONE UNA OPCIÓN</option>
	<option value="21">GRUPO VELMA</option>
	<option value="13">GASOLINERAS GUAYHUA DIONICIO</option>
	<option value="45">EJECUTIVOS FUNDACION SARTAWI FINANCIERO</option>

</select>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 18px; width: 95px;">
                                    <span id="ctl00_cpmaster_Label2">Cia Aseguradora :</span>
                                </td>
                                <td colspan="3" style="height: 24px">
                                    <select name="ctl00$cpmaster$id_spvs" onchange="javascript:setTimeout('__doPostBack(\'ctl00$cpmaster$id_spvs\',\'\')', 0)" id="ctl00_cpmaster_id_spvs" style="color:#0F5B96;background-color:White;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
	<option value="0"> SELECCIONE UNA OPCIÓN</option>
	<option selected="selected" value="108">ALIANZA COMPANIA DE SEGUROS Y REASEGUROS S.A.</option>
	<option value="207">ALIANZA VIDA SEGUROS Y REASEGUROS S.A.</option>
	<option value="109">BISA SEGUROS Y REASEGUROS</option>
	<option value="201">BUPA INSURANCE  (BOLIVIA) S.A.</option>
	<option value="211">COMPAÑÍA DE SEGUROS DE VIDA FORTALEZA S.A.</option>
	<option value="113">COMPAÑÍA DE SEGUROS Y REASEGUROS FORTALEZA S.A.</option>
	<option value="110">COOPERATIVA DE SEGUROS 24 DE SEPTIEMBRE</option>
	<option value="102">CREDINFORM INTERNATIONAL S.A.</option>
	<option value="209">CREDISEGURO S.A. SEGUROS PERSONALES</option>
	<option value="101">LA BOLIVIANA CIACRUZ DE SEGUROS Y REASEGUROS S.A.</option>
	<option value="204">LA BOLIVIANA CIACRUZ SEGUROS PERSONALES S.A.</option>
	<option value="203">LA VITALICIA SEGUROS Y REASEGUROS DE VIDA S.A.</option>
	<option value="118">MERCANTIL SANTA CRUZ SEGUROS Y REASEGUROS GENERALES S.A.</option>
	<option value="115">NACIONAL SEGUROS PATRIMONIALES Y FIANZAS S.A.</option>
	<option value="206">NACIONAL VIDA SEGUROS DE PERSONAS S.A.</option>
	<option value="105">SEGUROS ILLIMANI</option>
	<option value="205">SEGUROS PROVIDA S.A.</option>
	<option value="210">SEGUROS Y REASEGUROS PERSONALES UNIVIDA S.A.</option>
	<option value="116">UNIBIENES S.A. SEGUROS Y REASEGUROS PATRIMONIALES</option>

</select>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 18px; width: 95px;">
                                    <span id="ctl00_cpmaster_lblnombre">Producto :</span>
                                </td>
                                <td colspan="3">
                                    <select name="ctl00$cpmaster$id_producto" id="ctl00_cpmaster_id_producto" style="color:#0F5B96;background-color:White;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
	<option value="-1"> SELECCIONE UNA OPCIÓN</option>
	<option value="15">ACCIDENTES PERSONALES</option>
	<option selected="selected" value="26">AERONAVEGACIÓN</option>
	<option value="40">ASISTENCIA AL VIAJERO</option>
	<option value="16">ASISTENCIA MÉDICA FAMILIAR</option>
	<option value="13">AUTOMOTORES</option>
	<option value="41">BUENA EJECUCION DE OBRA</option>
	<option value="42">CORRECTA INVERSION DE ANTICIPOS</option>
	<option value="43">CUMPLIMIENTO DE CONTRATO DE OBRA</option>
	<option value="44">CUMPLIMIENTO DE CONTRATO DE SERVICIOS</option>
	<option value="45">CUMPLIMIENTO DE CONTRATO DE SUMINISTROS</option>
	<option value="46">EQUIPO ELECTRONICO</option>
	<option value="47">EQUIPO MOVIL</option>
	<option value="6">FIDELIDAD DE EMPLEADOS</option>
	<option value="48">GARANTIA DE CUMPLIMIENTO DE OBLIGACIONES ADUANERAS</option>
	<option value="57">INCENDIO Y ALIADOS/INCENDIO TODO RIESGO</option>
	<option value="49">MONTAJE</option>
	<option value="2">MULTI RIESGO</option>
	<option value="50">MUNDISALUD</option>
	<option value="10">RAMOS TECNICOS</option>
	<option value="112">RESP CIVIL DE DIRECTORES Y OFICIALES D&amp;O</option>
	<option value="5">RESPONSABILIDA CIVIL</option>
	<option value="123">RESPONSABILIDAD CIVIL PROFESIONAL</option>
	<option value="3">ROBO Y ASALTO</option>
	<option value="11">ROTURA DE MAQUINARIA</option>
	<option value="12">SEGURO COMPRENSIVO 3D (DESHONESTIDAD, DESTRUCCION </option>
	<option value="14">SEGURO OBLIGATORIO DE ACCIDENTES DE TRANSITO</option>
	<option value="158">SEGURO ODONTOLOGIC</option>
	<option value="52">SERIEDAD DE PRESENTACION DE PROPUESTA</option>
	<option value="68">TODO RIESGO DE CONSTRUCCION</option>
	<option value="69">TODO RIESGO DE EQUIPO DE CONTRATISTAS</option>
	<option value="80">TRANSPORTE DE REMESAS</option>
	<option value="7">TRANSPORTES</option>

</select>
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 18px; width: 95px;">
                                    <span id="ctl00_cpmaster_Label5">Tipo de Cartera :</span>
                                </td>
                                <td colspan="3">
                                    <select name="ctl00$cpmaster$id_clamov1" id="ctl00_cpmaster_id_clamov1" style="color:#0F5B96;background-color:White;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
	<option value="0">SELECCIONE UNA OPCIÓN</option>
	<option selected="selected" value="42">NUEVA</option>
	<option value="43">RENOVACION</option>

</select>
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
                                    <select name="ctl00$cpmaster$id_percart" id="ctl00_cpmaster_id_percart" style="color:#0F5B96;background-color:White;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
	<option value="0"> SELECCIONE UNA OPCIÓN</option>
	<option selected="selected" value="4278656">"XIMENA ROSARIO ROMERO VILLAZON - SERVICIOS DE CONSULTORIA"</option>
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
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 18px; width: 95px;">
                                    <span id="ctl00_cpmaster_Label4">Tipo Poliza :</span>
                                </td>
                                <td style="width: 100px">
                                    <table id="ctl00_cpmaster_clase_poliza" border="0">
	                                    <tbody><tr>
		                                    <td>
                                                <label for="ctl00_cpmaster_clase_poliza_0">Normal</label><input id="ctl00_cpmaster_clase_poliza_0" type="radio" name="ctl00$cpmaster$clase_poliza" value="True"></td><td><label for="ctl00_cpmaster_clase_poliza_1">Flotante</label><input id="ctl00_cpmaster_clase_poliza_1" type="radio" name="ctl00$cpmaster$clase_poliza" value="False" checked="checked"></td>
	                                        </tr>
                                        </tbody>
                                    </table>
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
                                    <input name="ctl00$cpmaster$prima_bruta" type="text" value="10.000,00" maxlength="15" id="ctl00_cpmaster_prima_bruta" onkeypress="return(currencyFormat(this,event));" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:75px;">
                                    &nbsp;
                                    <span id="ctl00_cpmaster_lblnum_cuota">Nº Cuotas :</span>
                                    &nbsp;
                                    <input name="ctl00$cpmaster$num_cuota" type="text" value="21" maxlength="2" id="ctl00_cpmaster_num_cuota" onkeydown="return dFilter (event.keyCode, this, '##');" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:25px;">
                                    &nbsp;
                                    <span id="ctl00_cpmaster_lblid_div">Divisa :</span>
                                    &nbsp;
                                    <select name="ctl00$cpmaster$id_div" id="ctl00_cpmaster_id_div" style="color:#0F5B96;background-color:White;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
	                                    <option selected="selected" value="37">BS</option>
	                                    <option value="39">SUS</option>
	                                    <option value="38">UFV</option>
	                                    <option value="40">EU</option>
	                                    <option value="0">SELECCIONE UNA OPCIÓN</option>

                                    </select>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 95px; height: 18px">
                                    <span id="ctl00_cpmaster_lbltipo_cuota">Forma de Pago</span>
                                </td>
                                <td colspan="3" style="height: 18px">
                                    <table id="ctl00_cpmaster_tipo_cuota" border="0">
	                                <tbody><tr>
		                                <td><label for="ctl00_cpmaster_tipo_cuota_0">Contado</label><input id="ctl00_cpmaster_tipo_cuota_0" type="radio" name="ctl00$cpmaster$tipo_cuota" value="True"></td><td><label for="ctl00_cpmaster_tipo_cuota_1">Crédito</label><input id="ctl00_cpmaster_tipo_cuota_1" type="radio" name="ctl00$cpmaster$tipo_cuota" value="False" checked="checked"></td>
	                                </tr>
                                </tbody></table>
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 95px; height: 18px">
                                    <span id="ctl00_cpmaster_lblmat_aseg">Mat. Asegurada :</span>
                                </td>
                                <td colspan="3" style="height: 18px">
                                    <textarea name="ctl00$cpmaster$mat_aseg" rows="3" cols="20" id="ctl00_cpmaster_mat_aseg" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:290px;">GFJH</textarea>
                                    <input type="hidden" name="ctl00$cpmaster$prima_neta" id="ctl00_cpmaster_prima_neta" value="0">
                                    <input type="hidden" name="ctl00$cpmaster$por_comision" id="ctl00_cpmaster_por_comision" value="0">
                                    <input type="hidden" name="ctl00$cpmaster$comision" id="ctl00_cpmaster_comision" value="0">
                                    <input type="hidden" name="ctl00$cpmaster$id_clamov" id="ctl00_cpmaster_id_clamov" value="42">
                                    <input type="hidden" name="ctl00$cpmaster$estado" id="ctl00_cpmaster_estado" value="PRODUCCION">
                                    <input type="hidden" name="ctl00$cpmaster$id_poliza" id="ctl00_cpmaster_id_poliza">
                                    <input type="hidden" name="ctl00$cpmaster$id_suc" id="ctl00_cpmaster_id_suc" value="54">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <div class="gridcontainer" style="width: 295px">
                                        <div>

                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    
                                    <input type="submit" name="ctl00$cpmaster$btncuotas" value="Cuotas" id="ctl00_cpmaster_btncuotas" title="Mostrar Datos de las Cuotas de la Poliza" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                    <input type="submit" name="ctl00$cpmaster$btnsalir" value="Salir" id="ctl00_cpmaster_btnsalir" title="Salir del Formulario" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                </td>
                            </tr>
                        </tbody></table>
                    </div>
                </div>
                <p class="links">
                    <span id="ctl00_cpmaster_lblmensaje" class="error">Introduzca Valores</span>
                </p>
            </div>
</asp:Content>
