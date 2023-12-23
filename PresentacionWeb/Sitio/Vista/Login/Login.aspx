<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.Login.Login" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-11">
                <div class="card card-body p-4">
                    <h6 class="  fw-bold">Inicio de Sesión</h6>
                    <div class="row">
                        <div class="col-3">
                            <img src="../../../UI/img/lock.gif" alt="" width="128" height="128" class="left">
                        </div>
                        
                        <div class="col-5">
                            <table width="400" cellpadding="0" cellspacing="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 18px">&nbsp;</td>
                                        <td style="height: 18px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="height: 18px">
                                            <span id="lblusuario">Usuario :</span>
                                        </td>
                                        <td style="height: 18px">
                                            <input name="txtusuario" type="text" id="txtusuario" style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px;">
                                            <span id="rfvusuario" title="Campo Obligatorio" style="color: Red; visibility: hidden;">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span id="lblcontraseña">Contraseña :</span></td>
                                        <td>
                                            <input name="txtpassword" type="password" id="txtpassword" style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px;">
                                            <span id="RequiredFieldValidator2" title="Campo Obligatorio" style="color: Red; visibility: hidden;">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span id="Label1">Tiempo de Conexion :</span>
                                        </td>
                                        <td>
                                            <select name="sesion" id="sesion" style="color: #0F5B96; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                                <option value="0">Sel. una Opción</option>
                                                <option value="30">30 Minutos</option>
                                                <option value="60">60 Minutos</option>
                                                <option value="90">90 Minutos</option>

                                            </select>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>&nbsp;</td>
                                        <td>&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" align="center">
                                            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnAceptar_Click" />
                                    </tr>
                                    <tr>
                                        <td align="center" colspan="2">&nbsp;</td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <p class="links">
                        <a class="error"><span id="lblmensaje" class="error"></span></a>
                    </p>
                </div>

            </div>
        </div>

    </div>


</asp:Content>
