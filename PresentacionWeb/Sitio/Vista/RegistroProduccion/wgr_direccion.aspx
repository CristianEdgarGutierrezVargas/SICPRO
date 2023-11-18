<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_direccion.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.RegistroProduccion.wgr_direccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div id="content">
            <div class="post">
                <div>
                    

                <script type="text/javascript" src="scripts/fieldScripts.js"></script>

                <div class="post">
                    <script type="text/javascript">
            //<![CDATA[
            Sys.WebForms.PageRequestManager._initialize('ctl00$cpmaster$smcontrol', document.getElementById('aspnetForm'));
            Sys.WebForms.PageRequestManager.getInstance()._updateControls(['tctl00$cpmaster$panel'], [], [], 90);
            //]]>
                    </script>

                    <div id="ctl00_cpmaster_panel">
	
                            <h1 class="title">
                                Registro de Direcciones</h1>
                            <div class="entry">
                                <img src="images/direccion.png" alt="" width="128" height="128" class="left">
                                <div>
                                    <table width="520" cellpadding="0" cellspacing="0">
                                        <tbody><tr>
                                            <td style="height: 18px;" colspan="2">
                                                <span id="ctl00_cpmaster_lblnombre"></span>
                                            </td>
                                            <td style="height: 18px" colspan="2">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 18px; width: 70px;">
                                                &nbsp;
                                            </td>
                                            <td style="height: 18px; width: 200px;">
                                                <input type="hidden" name="ctl00$cpmaster$id_dir" id="ctl00_cpmaster_id_dir">
                                            </td>
                                            <td style="width: 70px; height: 18px">
                                                <input type="hidden" name="ctl00$cpmaster$id_per" id="ctl00_cpmaster_id_per" value="4546936">
                                            </td>
                                            <td style="width: 4px; height: 18px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 70px">
                                                <span id="ctl00_cpmaster_lblcontraseña">Dirección :</span>
                                            </td>
                                            <td style="width: 200px">
                                                <input name="ctl00$cpmaster$direccion" type="text" id="ctl00_cpmaster_direccion" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:200px;">
                                            </td>
                                            <td style="width: 70px">
                                                &nbsp;
                                            </td>
                                            <td style="width: 4px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 24px; width: 70px;">
                                                <span id="ctl00_cpmaster_Label1">Tipo :</span>
                                            </td>
                                            <td style="height: 24px; width: 200px;">
                                                <select name="ctl00$cpmaster$id_tpdir" id="ctl00_cpmaster_id_tpdir" style="color:#0F5B96;background-color:White;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">

	            </select>
                                            </td>
                                            <td style="width: 70px; height: 24px">
                                                <span id="ctl00_cpmaster_Label9">Lugar :</span>
                                            </td>
                                            <td style="width: 4px; height: 24px">
                                                <select name="ctl00$cpmaster$id_emis" id="ctl00_cpmaster_id_emis" style="color:#0F5B96;background-color:White;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">

	            </select>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 70px">
                                                <span id="ctl00_cpmaster_Label2">Teléfono :</span>
                                            </td>
                                            <td style="width: 200px">
                                                <input name="ctl00$cpmaster$telf_dir" type="text" id="ctl00_cpmaster_telf_dir" onkeydown="return dFilter (event.keyCode, this, '########');" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:100px;">
                                            </td>
                                            <td style="width: 70px">
                                                <span id="ctl00_cpmaster_Label3">N° Interno :</span>
                                            </td>
                                            <td style="width: 4px">
                                                <input name="ctl00$cpmaster$int_dire" type="text" id="ctl00_cpmaster_int_dire" onkeydown="return dFilter (event.keyCode, this, '####');" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:100px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 70px">
                                                <span id="ctl00_cpmaster_Label4">Celular :</span>
                                            </td>
                                            <td style="width: 200px">
                                                <input name="ctl00$cpmaster$telf_cel" type="text" id="ctl00_cpmaster_telf_cel" onkeydown="return dFilter (event.keyCode, this, '#########');" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:100px;">
                                            </td>
                                            <td style="width: 70px">
                                                <span id="ctl00_cpmaster_Label5">Fax :</span>
                                            </td>
                                            <td style="width: 4px">
                                                <input name="ctl00$cpmaster$telf_fax" type="text" id="ctl00_cpmaster_telf_fax" onkeydown="return dFilter (event.keyCode, this, '#########');" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:100px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 70px">
                                                <span id="ctl00_cpmaster_Label6">E-Mail :</span>
                                            </td>
                                            <td style="width: 200px">
                                                <input name="ctl00$cpmaster$email" type="text" id="ctl00_cpmaster_email" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:200px;">
                                            </td>
                                            <td style="width: 70px">
                                                <span id="ctl00_cpmaster_Label7">N° Casilla :</span>
                                            </td>
                                            <td style="width: 4px">
                                                <input name="ctl00$cpmaster$casilla" type="text" id="ctl00_cpmaster_casilla" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:100px;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 70px">
                                                <span id="ctl00_cpmaster_Label8">Sitio Web :</span>
                                            </td>
                                            <td style="width: 200px">
                                                <input name="ctl00$cpmaster$web" type="text" id="ctl00_cpmaster_web" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:200px;">
                                            </td>
                                            <td style="width: 70px">
                                                &nbsp;
                                            </td>
                                            <td style="width: 4px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 22px">
                                                <input type="submit" name="ctl00$cpmaster$btnpersona" value="Persona" id="ctl00_cpmaster_btnpersona" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                    
                                                <input type="submit" name="ctl00$cpmaster$btnguardar" value="Guardar" id="ctl00_cpmaster_btnguardar" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                    
                                    
                                                <input type="submit" name="ctl00$cpmaster$Button1" value="  Salir  " id="ctl00_cpmaster_Button1" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4" style="height: 22px">
                                                <div class="gridcontainer" style="width: 500px">
                                                    <div>
		            <table class="grid" cellspacing="0" cellpadding="0" rules="all" border="1" id="ctl00_cpmaster_grddireccion" style="width:500px;border-collapse:collapse;">
			            <caption>
				            Lista de Direcciones
			            </caption><tbody><tr>
				            <th align="center" scope="col">&nbsp;</th><th align="center" scope="col">Código</th><th align="center" scope="col">Dirección</th><th align="center" scope="col">Descripción</th>
			            </tr><tr onmouseout="this.className = this.orignalclassName;" onmouseover="this.orignalclassName = this.className;this.className = 'altoverow';" class="">
				            <td style="width:25px;">
                                                                    <input type="image" name="ctl00$cpmaster$grddireccion$ctl02$img1" id="ctl00_cpmaster_grddireccion_ctl02_img1" title="Seleccionar Registro" src="images/front.png" style="background-color:Transparent;height:20px;width:20px;border-width:0px;">
                                                                </td><td align="center" style="width:80px;">
                                                                    <span id="ctl00_cpmaster_grddireccion_ctl02_id_dir">3009</span>
                                                                </td><td align="left" style="width:300px;">
                                                                    <span id="ctl00_cpmaster_grddireccion_ctl02_direccion">CAPCEM</span>
                                                                </td><td align="left" style="width:100px;">
                                                                    <span id="ctl00_cpmaster_grddireccion_ctl02_desc_param">TRABAJO</span>
                                                                </td>
			            </tr>
		            </tbody></table>
	            </div>
                                                </div>
                                            </td>
                                        </tr>
                                    </tbody></table>
                                </div>
                            </div>
                            <p class="links">
                                <a class="error">
                                    <span id="ctl00_cpmaster_lblmensaje" class="error">Error al Generar la Consulta</span></a>
                            </p>
            
            </div>
                </div>

                </div>
            </div>
        </div>
</asp:Content>
