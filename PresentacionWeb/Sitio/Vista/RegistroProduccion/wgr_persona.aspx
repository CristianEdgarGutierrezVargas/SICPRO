<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_persona.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.RegistroProduccion.RegistroPersonas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div id="content">
            <div class="post">
                <div>                   
                    <script type="text/javascript" src="scripts/fieldScripts.js"></script>
                    <script type="text/javascript" src="scripts/validaciones.js"></script>

                    <script type="text/javascript">
                    function Abrir()
                    {
                        window.open('wgr_buscar.aspx','ventanita2' ,'height=300, width=450, top=100, left= 100, status=no, toolbar=no, menubar=no,location=no, scrollbars = yes, resizable = yes');
                    }
                    function mOvr(src,clrOver)
                    {
                        if (!src.contains(event.fromElement)) 
                        {
                            src.style.cursor = 'hand';
                            src.bgColor = clrOver;   
                        }
                    }
                    function mOut(src,clrIn) 
                    {
                        if (!src.contains(event.toElement)) 
                        {
                            src.style.cursor = 'default';
                            src.bgColor = clrIn;
                        }
                    }
                    function mClk1(a1,a2)
                    {        
                        document.getElementById("ctl00_cpmaster_id_per").value = a1;
                        document.getElementById("ctl00_cpmaster_nomraz").value = a2;
                        document.getElementById("pagedimmer").style.visibility = "hidden";
                        document.getElementById("msgbox").style.visibility = "hidden";
                        __doPostBack("ctl00$cpmaster$b1","");
                    }
                    function f()
                    {
                        __doPostBack("ctl00$cpmaster$btnserper","");
                    }
                    </script>

                    <script type="text/javascript">
                    //<![CDATA[
                    Sys.WebForms.PageRequestManager._initialize('ctl00$cpmaster$smcontrol', document.getElementById('aspnetForm'));
                    Sys.WebForms.PageRequestManager.getInstance()._updateControls(['tctl00$cpmaster$ctl00'], [], [], 90);
                    //]]>
                    </script>

                    <div id="ctl00_cpmaster_ctl00">
	
                       <div id="ctl00_cpmaster_msgboxpanel"></div> 
                            <div class="post">
                            <h1 class="title">Registro de Personas</h1>
			                    <div class="entry"> <img src="../../../UI/img/add-user.gif" alt="" width="122" height="122" class="left">
			                    <div>
                                    <table width="500">
                                        <tbody><tr><td style="height: 18px">


                                                <span id="ctl00_cpmaster_lblcodigo">Documento Identificación :</span></td>
                                            <td style="height: 18px">
                                                <input name="ctl00$cpmaster$id_per" type="text" id="ctl00_cpmaster_id_per" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;" class="normalfld">
                                                <span id="ctl00_cpmaster_lblid">(C.I, NIT, otros)</span>
                                                <input type="hidden" name="ctl00$cpmaster$hid_per" id="ctl00_cpmaster_hid_per">
                                                <input type="hidden" name="ctl00$cpmaster$a" id="ctl00_cpmaster_a" value="0">
                                                <input type="hidden" name="ctl00$cpmaster$b" id="ctl00_cpmaster_b" value="10">
                                            </td>
                                        </tr>
                                        <tr><td>
                                                <span id="ctl00_cpmaster_lblnombre">Nombre o Razon Social :</span></td>
                                            <td id="btnper">
                                                <input name="ctl00$cpmaster$nomraz" type="text" id="ctl00_cpmaster_nomraz" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:250px;" class="normalfld">
                                                &nbsp;
                                                <input type="submit" name="ctl00$cpmaster$btnserper" value="..." id="ctl00_cpmaster_btnserper" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">

                                                <button type="button" name="btnserper" data-bs-toggle="modal" data-bs-target="#modal_btnserper" id="btnserper" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                                  ...
                                                </button>


                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                &nbsp;<span id="ctl00_cpmaster_Label1">Sucursal :</span>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="id_suc" runat="server"></asp:DropDownList>
                                                <select name="ctl00$cpmaster$id_suc" id="ctl00_cpmaster_id_suc" style="color:#0F5B96;background-color:White;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                                    
	                    </select>
                                            </td>
                                        </tr>
                                        <tr><td style="height: 18px">
                                                <span id="ctl00_cpmaster_lbltipoper">Tipo de Persona :</span></td>
                                            <td style="height: 18px">
                                                <select name="ctl00$cpmaster$id_tper" id="ctl00_cpmaster_id_tper" style="color:#0F5B96;background-color:White;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">

	                    </select>
                                                </td>
                                        </tr>
                                        <tr><td style="height: 24px">
                                                <span id="ctl00_cpmaster_lblfecha_nac">Fecha de Nacimiento :</span></td>
                                            <td style="height: 24px">
                                                <input name="ctl00$cpmaster$fechaaniv" type="text" value="//" id="ctl00_cpmaster_fechaaniv" onkeydown="return dFilter (event.keyCode, this, '##/##/####');" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;">
                                                <input type="image" name="ctl00$cpmaster$ibtncalendario" id="ctl00_cpmaster_ibtncalendario" src="images/Calendar_scheduleHS.png" alt="Click en la Imagen para mostrar el Calendario" style="border-width:0px;">
                            
                                                </td>
                                        </tr>
                                        <tr><td>
                                                <span id="ctl00_cpmaster_lblsal">Salutación Personal :</span></td>
                                            <td>
                                                <select name="ctl00$cpmaster$id_sal" id="ctl00_cpmaster_id_sal" style="color:#0F5B96;background-color:White;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">

	                    </select></td>
                                        </tr>
                                        <tr><td>
                                                <span id="ctl00_cpmaster_lblrol">Tipo de Rol :</span></td>
                                            <td>
                                                <select name="ctl00$cpmaster$id_rol" id="ctl00_cpmaster_id_rol" style="color:#0F5B96;background-color:White;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">

	                                            </select></td>


                                        </tr>
                                        <tr><td>
                                                <span id="ctl00_cpmaster_lbltipodoc">Tipo de Documento :</span></td>
                                            <td>
                                                <select name="ctl00$cpmaster$id_tdoc" onchange="javascript:setTimeout('__doPostBack(\'ctl00$cpmaster$id_tdoc\',\'\')', 0)" id="ctl00_cpmaster_id_tdoc" style="color:#0F5B96;background-color:White;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">

	                    </select></td>
                                        </tr>
                                        <tr><td>
                                                <span id="ctl00_cpmaster_lblldoc">Emisión del Documento :</span></td>
                                            <td>
                                                <select name="ctl00$cpmaster$id_emis" id="ctl00_cpmaster_id_emis" style="color:#0F5B96;background-color:White;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">

	                    </select></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <span id="ctl00_cpmaster_lblnit">Datos de Facturación :</span>
                                            </td>
                                            <td>
                                                <input name="ctl00$cpmaster$nit_fac" type="text" maxlength="50" id="ctl00_cpmaster_nit_fac" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:250px;">
                                            </td>
                                        </tr>
                                        <tr><td colspan="2" align="center">
                            
                                                <input type="submit" name="ctl00$cpmaster$btnguardar" value="Guardar" id="ctl00_cpmaster_btnguardar" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                            
                            
                                                <input type="button" name="ctl00$cpmaster$b1" value="Buscar" onclick="javascript:__doPostBack('ctl00$cpmaster$b1','')" id="ctl00_cpmaster_b1" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                                <input type="submit" name="ctl00$cpmaster$btnsalir" value="Salir" id="ctl00_cpmaster_btnsalir" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                                </td>
                                        </tr>
                                    </tbody></table>
                                </div>
			                    </div>
			                    <p class="links">
                                    <span id="ctl00_cpmaster_lblmensaje" class="error">Introduzca Valores</span>
                                        </p>
                                </div>
            
                    </div>
            
                </div>
            </div>
        </div>


<!-- Modal -->
<div class="modal fade" id="modal_btnserper" tabindex="-1" aria-labelledby="Busca Persona" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Modal title</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Save changes</button>
      </div>
    </div>
  </div>
</div>

</asp:Content>
