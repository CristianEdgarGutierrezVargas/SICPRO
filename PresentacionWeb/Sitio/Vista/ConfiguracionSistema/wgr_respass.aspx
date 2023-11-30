<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_respass.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wgr_respass" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <!-- Inicio Contenido -->
    <div id="content">
        <div class="post">
            <div>
                <script type="text/javascript" language="javascript" src="../../../Scripts/SicPro/fieldScripts.js"></script>
                <div class="post">
                    <div id="cpmaster_panel">
                        <asp:Panel ID="msgboxpanel" runat="server" Visible="false">
                            <div style="position: fixed; background-color: #888888; border: 1px solid #999999; z-index: 50; left: 30%; right: 20%; top: 15%; width: 510px" id="msgbox">
                                <div style="margin: 5px; width: 300px">
                                    <table width="500" align="center" style="background-color: #FFFFFF; border: 1px solid #999999;">
                                        <tbody>
                                            <tr>
                                                <td colspan="2" style="font-family: tahoma; font-size: 11px; font-weight: bold; padding-left: 5px; background-image: url(../../../UI/img/msg_title_1.jpg); color: #FFFFFF; height: 22px;">Confirmacion</td>
                                            </tr>
                                            <tr>
                                                <td valign="top" style="width: 100px; text-align: center;">
                                                    <img src="../../../UI/img/msg_icon_1.png" width="48" height="48"></td>
                                                <td style="font-family: tahoma; font-size: 11px; padding-left: 5px;">Cambio de Clave realizado con éxito</td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="border-top: 1px solid #CCCCCC; padding-top: 5px; text-align: right;">
                                                    <a href="../Default.aspx" class="msg_button_class">Aceptar</a>&nbsp;			
                                                </td>
                                            </tr>
                                        </tbody>
                                    </table>
                                </div>
                            </div>
                        </asp:Panel>


                        <h1 class="title">Reseteo de Password</h1>
                        <div class="entry">
                            <img src="../../../Scripts/images/img07.jpg" alt="" width="122" height="122" class="left" />
                            <div>
                                <table width="500" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td style="height: 18px; width: 110px;">&nbsp;</td>
                                        <td style="height: 18px; width: 200px;">&nbsp;</td>
                                        <td style="width: 98px; height: 18px">&nbsp;</td>
                                        <td style="width: 4px; height: 18px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="height: 18px; width: 110px;">&nbsp;</td>
                                        <td style="height: 18px; width: 200px;">&nbsp;</td>
                                        <td style="width: 98px; height: 18px">&nbsp;</td>
                                        <td style="width: 4px; height: 18px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="height: 18px; width: 110px;">&nbsp;</td>
                                        <td style="height: 18px; width: 200px;">&nbsp;</td>
                                        <td style="width: 98px; height: 18px">&nbsp;</td>
                                        <td style="width: 4px; height: 18px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="height: 18px; width: 110px;">
                                            <span id="cpmaster_lblusuario">Usuario :</span>
                                        </td>
                                        <td colspan="2" style="height: 18px;">
                                            <asp:DropDownList ID="id_per" runat="server"></asp:DropDownList>
                                        </td>
                                        <td style="width: 4px; height: 18px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">&nbsp;</td>
                                        <td style="width: 200px">&nbsp;</td>
                                        <td style="width: 98px">&nbsp;</td>
                                        <td style="width: 4px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td style="width: 110px">&nbsp;</td>
                                        <td style="width: 200px">&nbsp;</td>
                                        <td style="width: 98px">&nbsp;</td>
                                        <td style="width: 4px">&nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center" style="height: 22px">
                                            <asp:Button ID="btnguardar" runat="server" Text="Guardar" CssClass="msg_button_class" OnClick="btnguardar_Click" />
                                            <%--<input type="submit" name="ctl00$cpmaster$btnguardar" value="Guardar" id="cpmaster_btnguardar" class="msg_button_class" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" />--%>

                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </div>
                        <p class="links">
                            <asp:Label ID="lblmensaje" runat="server" CssClass="error"></asp:Label>
                            <%--<a class="error"><span id="cpmaster_lblmensaje" class="error"></span></a>--%>
                        </p>
                    </div>
                </div>

            </div>
        </div>
    </div>
    <!-- Fin Contenido -->
</asp:Content>




