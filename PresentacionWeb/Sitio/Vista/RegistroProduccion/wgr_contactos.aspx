<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_contactos.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.RegistroProduccion.wgr_contactos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div id="content">
            <div class="post">
                <div>
                    

                    <script type="text/javascript">
                    function Abrir()
                    {
                    window.open('wgr_personac.aspx','ventanita2' ,'height=400, width=600, top=100, left= 100, status=no, toolbar=no, menubar=no,location=no, scrollbars = yes, resizable = yes');
                    }
                function b1_onclick() {

                }

                    </script>

                    <script type="text/jscript" language="javascript" src="scripts/fieldScripts.js"></script>

                    <script type="text/javascript">
                //<![CDATA[
                Sys.WebForms.PageRequestManager._initialize('ctl00$cpmaster$smcontrol', document.getElementById('aspnetForm'));
                Sys.WebForms.PageRequestManager.getInstance()._updateControls(['tctl00$cpmaster$panel'], [], [], 90);
                //]]>
                    </script>

                    <div class="post">
                        <div id="ctl00_cpmaster_panel">
	
                                <div id="ctl00_cpmaster_msgboxpanel">
                                </div>
                                <h1 class="title">
                                    Registro de Contactos</h1>
                                <div class="entry">
                                    <img src="images/img07.jpg" alt="" width="122" height="122" class="left">
                                    <div>
                                        <table width="530" cellpadding="0" cellspacing="0">
                                            <tbody><tr>
                                                <td style="height: 18px; width: 70px;">
                                                    <input type="hidden" name="ctl00$cpmaster$id_perclie" id="ctl00_cpmaster_id_perclie" value="4546936">
                                                </td>
                                                <td style="height: 18px; width: 200px;" align="center">
                                                    <span id="ctl00_cpmaster_direccion"></span>
                                                    <input type="hidden" name="ctl00$cpmaster$id_dir" id="ctl00_cpmaster_id_dir" value="3009">
                                                </td>
                                                <td style="width: 70px; height: 18px">
                                                    &nbsp;
                                                </td>
                                                <td style="width: 4px; height: 18px">
                                                    <input type="hidden" name="ctl00$cpmaster$a" id="ctl00_cpmaster_a" value="0">
                                                    <input type="hidden" name="ctl00$cpmaster$b" id="ctl00_cpmaster_b" value="10">
                                                    <input type="hidden" name="ctl00$cpmaster$id_per" id="ctl00_cpmaster_id_per">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 70px">
                                                    <span id="ctl00_cpmaster_lblnombre">Nombre  :</span>
                                                </td>
                                                <td colspan="3">
                                                    <input name="ctl00$cpmaster$nomraz" type="text" id="ctl00_cpmaster_nomraz" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:300px;">
                                                    <input type="submit" name="ctl00$cpmaster$btnserper" value="..." id="ctl00_cpmaster_btnserper" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                                    <input type="image" name="ctl00$cpmaster$ImageButton1" id="ctl00_cpmaster_ImageButton1" title="Ver Detalles de Persona" src="images/view.png" style="background-color:Transparent;border-width:0px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="height: 24px; width: 70px;">
                                                    <span id="ctl00_cpmaster_lbllugar">Lugar :</span>
                                                </td>
                                                <td style="height: 24px; width: 200px;">
                                                    <select name="ctl00$cpmaster$id_emis" id="ctl00_cpmaster_id_emis" style="color:#0F5B96;background-color:White;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">

	                </select>
                                                </td>
                                                <td style="height: 24px; width: 100px" colspan="2">
                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 70px">
                                                    <span id="ctl00_cpmaster_lblrelacion">Relación :</span>
                                                </td>
                                                <td colspan="3">
                                                    <input name="ctl00$cpmaster$relacion" type="text" id="ctl00_cpmaster_relacion" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:250px;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4" align="center" style="height: 22px">
                                                    <input type="submit" name="ctl00$cpmaster$Button1" value="Driecciones" id="ctl00_cpmaster_Button1" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                    
                                                    <input type="submit" name="ctl00$cpmaster$btnguardar" value="Guardar" id="ctl00_cpmaster_btnguardar" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                    
                                                    <input type="submit" name="ctl00$cpmaster$btnsalir" value="Salir" id="ctl00_cpmaster_btnsalir" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center" colspan="4" style="height: 22px">
                                                    <div class="gridcontainer" style="width: 500px">
                                                        <div>

	                </div>
                                                    </div>
                                                </td>
                                            </tr>
                                        </tbody></table>
                                    </div>
                                </div>
                                <p class="links">
                                    <a class="error">
                                        <span id="ctl00_cpmaster_lblmensaje" class="error"></span></a>
                                </p>
            
                </div>
                    </div>

                </div>
            </div>
        </div>
</asp:Content>
