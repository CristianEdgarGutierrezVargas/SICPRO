<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_datospolizacuotas.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wpr_datospolizacuotas" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Modificación de Cuotas de Polizas</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <img src="../../../UI/img/renovar.png" alt="" width="122" height="122">
            </div>
            <div class="col-10">
                <div class="row">Fechas
                    <asp:HiddenField ID="fc_reg" runat="server" />
                    <asp:HiddenField ID="id_movimiento" runat="server" />
                    <asp:HiddenField ID="id_mom" runat="server" />
                </div>
                <div class="row">
                    <div class="col-3">
                        Fecha de Emisión :
                    </div>
                    <div class="col-3">
                        <dx:ASPxLabel ID="fc_emision" runat="server" Text=""></dx:ASPxLabel>
                    </div>
                    <div class="col-3">
                        Fecha de Recepción :
                    </div>
                    <div class="col-3">
                        <dx:ASPxLabel ID="fc_recepcion" runat="server" Text=""></dx:ASPxLabel>
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        Inicio Vigencia :
                    </div>
                    <div class="col-3">
                        <dx:ASPxLabel ID="fc_inivig" runat="server" Text=""></dx:ASPxLabel>
                    </div>
                    <div class="col-3">
                        Fin Vigencia :
                    </div>
                    <div class="col-3">
                        <dx:ASPxLabel ID="fc_finvig" runat="server" Text=""></dx:ASPxLabel>
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        N° de Poliza :
                    </div>
                    <div class="col-3">
                        <dx:ASPxLabel ID="num_poliza" runat="server" Text=""></dx:ASPxLabel>
                    </div>
                    <div class="col-3">
                        Nº Liquidación :
                    </div>
                    <div class="col-3">
                        <dx:ASPxLabel ID="no_liquida" runat="server" Text=""></dx:ASPxLabel>
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        Asegurado :
                    </div>
                    <div class="col-5">
                        <dx:ASPxLabel ID="nomraz" runat="server" Text=""></dx:ASPxLabel>
                        <asp:HiddenField ID="id_per" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        Dirección :
                    </div>
                    <div class="col-5">
                        <dx:ASPxLabel ID="direccion" runat="server" Text=""></dx:ASPxLabel>
                        <asp:HiddenField ID="id_dir" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        Grupo :
                    </div>
                    <div class="col-5">
                        <dx:ASPxLabel ID="desc_grupo" runat="server" Text=""></dx:ASPxLabel>
                        <asp:HiddenField ID="id_gru" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        Cia Aseguradora :
                    </div>
                    <div class="col-5">
                        <dx:ASPxLabel ID="nomco" runat="server" Text=""></dx:ASPxLabel>
                        <asp:HiddenField ID="id_spvs" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        Producto :
                    </div>
                    <div class="col-5">
                        <dx:ASPxLabel ID="desc_producto" runat="server" Text=""></dx:ASPxLabel>
                        <asp:HiddenField ID="id_producto" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        Ejecutivo :
                    </div>
                    <div class="col-5">
                        <dx:ASPxLabel ID="nomejec" runat="server" Text=""></dx:ASPxLabel>
                        <asp:HiddenField ID="id_perejecu" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        Agente Cartera :
                    </div>
                    <div class="col-5">
                        <dx:ASPxLabel ID="nomcart" runat="server" Text=""></dx:ASPxLabel>
                        <asp:HiddenField ID="id_percart" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        Tipo Poliza :
                    </div>
                    <div class="col-5">
                        <dx:ASPxLabel ID="clase_poliza" runat="server" Text=""></dx:ASPxLabel>
                    </div>
                </div>
                <div class="row">
                    <div class="col-2">
                        Prima Total :
                    </div>
                    <div class="col-2">
                        <dx:ASPxLabel ID="prima_bruta" runat="server" Text=""></dx:ASPxLabel>
                    </div>
                    <div class="col-2">
                        Nº Cuotas :
                    </div>
                    <div class="col-2">
                        <dx:ASPxTextBox ID="num_cuota" runat="server" CssClass="w-100"></dx:ASPxTextBox>
                    </div>
                    <div class="col-2">
                        Divisa :
                    </div>
                    <div class="col-2">
                        <dx:ASPxLabel ID="nomdiv" runat="server" Text=""></dx:ASPxLabel>
                        <asp:HiddenField ID="id_div" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        Forma de Pago :
                    </div>
                    <div class="col-5">
                        <dx:ASPxLabel ID="tipo_cuota" runat="server" Text=""></dx:ASPxLabel>
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        Mat. Asegurada :
                    </div>
                    <div class="col-5">
                        <dx:ASPxLabel ID="mat_aseg" runat="server" Text=""></dx:ASPxLabel>
                        <asp:HiddenField ID="prima_neta" runat="server" />
                        <asp:HiddenField ID="por_comision" runat="server" />
                        <asp:HiddenField ID="comision" runat="server" />
                        <asp:HiddenField ID="id_clamov" runat="server" />
                        <asp:HiddenField ID="estado" runat="server" />
                        <asp:HiddenField ID="id_poliza" runat="server" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%--
                       
                            <td></td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <div class="gridcontainer" style="width: 375px">
                                    <div>
                                        <table class="grid" cellspacing="0" cellpadding="0" rules="all" border="1" id="ctl00_cpmaster_gridcuotas" style="width: 375px; border-collapse: collapse;">
                                            <caption>
                                                Cantidad de Cuotas de la Póliza
                                            </caption>
                                            <tr>
                                                <th align="center" scope="col">N° Poliza</th>
                                                <th align="center" scope="col">N° Cuota</th>
                                                <th align="center" scope="col">Fecha Pago</th>
                                                <th align="center" scope="col">Cuota Total</th>
                                                <th align="center" scope="col">&nbsp;</th>
                                            </tr>
                                            <tr onmouseout="this.className = this.orignalclassName;" onmouseover="this.orignalclassName = this.className;this.className = 'altoverow';">
                                                <td align="center" style="width: 80px;">
                                                    <span id="ctl00_cpmaster_gridcuotas_ctl02_num_poliza">6501268</span>
                                                </td>
                                                <td align="center" style="width: 80px;">
                                                    <span id="ctl00_cpmaster_gridcuotas_ctl02_cuota">0</span>
                                                </td>
                                                <td align="left" style="width: 100px;">
                                                    <input name="ctl00$cpmaster$gridcuotas$ctl02$fecha_pago" type="text" value="01/03/2008" id="ctl00_cpmaster_gridcuotas_ctl02_fecha_pago" onkeydown="return dFilter (event.keyCode, this, '##/##/####');" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 70px;" />
                                                    <input type="image" name="ctl00$cpmaster$gridcuotas$ctl02$ibtncalendario" id="ctl00_cpmaster_gridcuotas_ctl02_ibtncalendario" src="images/Calendar_scheduleHS.png" alt="Click en la Imagen para mostrar el Calendario" style="border-width: 0px;" />

                                                </td>
                                                <td align="left" style="width: 80px;">
                                                    <input name="ctl00$cpmaster$gridcuotas$ctl02$cuota_total" type="text" value="0,00" id="ctl00_cpmaster_gridcuotas_ctl02_cuota_total" onkeypress="return(currencyFormat(this,event));" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 75px;" />
                                                </td>
                                                <td style="width: 35px;">
                                                    <input type="image" name="ctl00$cpmaster$gridcuotas$ctl02$img1" id="ctl00_cpmaster_gridcuotas_ctl02_img1" src="images/lc_save.png" style="background-color: Transparent; height: 20px; width: 20px; border-width: 0px;" />
                                                </td>
                                            </tr>
                                            <tr class="footerstyle">
                                                <td>&nbsp;</td>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <span id="ctl00_cpmaster_gridcuotas_ctl03_suma">Totales</span>
                                                </td>
                                                <td align="left">
                                                    <input name="ctl00$cpmaster$gridcuotas$ctl03$scuota_total" type="text" value="0,00" readonly="readonly" id="ctl00_cpmaster_gridcuotas_ctl03_scuota_total" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 75px;" />
                                                </td>
                                                <td>&nbsp;</td>
                                            </tr>
                                        </table>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <input type="submit" name="ctl00$cpmaster$btnnuevo" value="Nuevo" id="ctl00_cpmaster_btnnuevo" title="Registrar nueva Poliza" class="msg_button_class" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" />
                                <input type="submit" name="ctl00$cpmaster$btnguardar" value="Cuotas" id="ctl00_cpmaster_btnguardar" class="msg_button_class" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" />

                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <p class="links">
                <span id="ctl00_cpmaster_lblmensaje" class="error">Introduzca Valores</span>
            </p>
        </div>

    </div>
    --%>
</asp:Content>
