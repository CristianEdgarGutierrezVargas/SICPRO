<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.Login.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    
    
		<div class="post">
			<div>    <script type="text/javascript">
//<![CDATA[
Sys.WebForms.PageRequestManager._initialize('smcontrol', document.getElementById('Principal'));
Sys.WebForms.PageRequestManager.getInstance()._updateControls(['tcontenedor'], [], [], 90);
//]]>
            </script>

        <div id="contenedor">
	
			<h1 class="title">Inicio de Sesión</h1>
			<div class="entry"> 
                <img src="../../../UI/img/lock.gif" alt="" width="128" height="128" class="left">
			<div><table width="400" cellpadding="0" cellspacing="0">
			<tbody><tr><td style="height: 18px">
			    &nbsp;</td>
			<td style="height: 18px">
			    &nbsp;</td></tr>
			    <tr>
                    <td style="height: 18px">
                        <span id="lblusuario">Usuario :</span>
                    </td>
                    <td style="height: 18px">
                        <input name="txtusuario" type="text" id="txtusuario" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;">
                        <span id="rfvusuario" title="Campo Obligatorio" style="color:Red;visibility:hidden;">*</span>
                    </td>
                </tr>
			<tr><td>
			<span id="lblcontraseña">Contraseña :</span></td>
			<td>
			<input name="txtpassword" type="password" id="txtpassword" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;">
			<span id="RequiredFieldValidator2" title="Campo Obligatorio" style="color:Red;visibility:hidden;">*</span>
			</td></tr>
			    <tr>
                    <td>
                        <span id="Label1">Tiempo de Conexion :</span>
                    </td>
                    <td>
                        <select name="sesion" id="sesion" style="color:#0F5B96;background-color:White;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;">
		                    <option value="0">Sel. una Opción</option>
		                    <option value="30">30 Minutos</option>
		                    <option value="60">60 Minutos</option>
		                    <option value="90">90 Minutos</option>

	                    </select>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
			<tr><td colspan="2" align="center">
			
			<input type="submit" name="btnaceptar" value="Aceptar" onclick="javascript:WebForm_DoPostBackWithOptions(new WebForm_PostBackOptions(&quot;btnaceptar&quot;, &quot;&quot;, true, &quot;&quot;, &quot;&quot;, false, false))" id="btnaceptar" class="msg_button_class" style="font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;"></td>
			</tr>
                <tr>
                    <td align="center" colspan="2">
                        &nbsp;</td>
                </tr>
                </tbody></table>
            </div>
			</div>
			<p class="links"><a class="error"><span id="lblmensaje" class="error"></span></a>
            </p>
</div>
                </div>
                </div>
               
</asp:Content>
