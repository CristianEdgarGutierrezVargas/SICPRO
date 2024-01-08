<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_entregarecibos.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ModuloComisiones.wpr_entregarecibos" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container">
        <div class="card p-3">
            <h1 class="title">Entrega de Recibos</h1>
            <div class="row">
                <div class="col-12 col-sm-12 col-md-3">
                    <img src="../../../UI/img/img07.jpg" alt="" width="122" height="122" class="left">
                </div>

                <div class="col-12 col-sm-12 col-md-9">

                    <div class="row">
                        <div class="col-3 col-sm-2">
                            <span id="Label3">Sucursal:</span>
                        </div>

                        <div class="col-9 col-sm-10">
                            <dx:BootstrapComboBox ID="id_suc" runat="server" ValueType="System.String">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-11" ListBox="fs-10" Control="fs-10" />

                            </dx:BootstrapComboBox>

                        </div>

                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 pe-0 col-3 col-sm-2">
                            <span id="Label1">Cobrador:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-9 col-sm-5">
                            <dx:BootstrapComboBox ID="id_perucb" runat="server" ValueType="System.String">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-11" ListBox="fs-10" Control="fs-10" />

                            </dx:BootstrapComboBox>

                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-3 col-sm-1 pe-0">
                            <span id="lblanio">Año:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-9 col-sm-3">
                            <dx:BootstrapComboBox ID="año" runat="server" ValueType="System.String">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-11" ListBox="fs-10" Control="fs-10" />

                            </dx:BootstrapComboBox>
                            <%--  <select name="ctl00$cpmaster$año" onchange="javascript:setTimeout('__doPostBack(\'ctl00$cpmaster$año\',\'\')', 0)" id="ctl00_cpmaster_año" style="color: #0F5B96; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <option selected="selected" value="-1">SEL UNA OPCION</option>
                                <option value="2008">2008</option>
                                <option value="2009">2009</option>
                                <option value="2010">2010</option>
                                <option value="2011">2011</option>
                                <option value="2012">2012</option>
                                <option value="2013">2013</option>
                                <option value="2014">2014</option>
                                <option value="2015">2015</option>
                                <option value="2016">2016</option>
                                <option value="2017">2017</option>
                                <option value="2018">2018</option>

                            </select>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-3 col-sm-2 pe-0">
                            <span id="lbldel">N° de Recibo:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-9 col-sm-4">
                            <dx:BootstrapComboBox ID="id_recibo" runat="server" ValueType="System.String">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-11" ListBox="fs-10" Control="fs-10" />

                            </dx:BootstrapComboBox>
                            <%-- <select name="ctl00$cpmaster$id_recibo" id="ctl00_cpmaster_id_recibo" style="color: #0F5B96; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                            </select>--%>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-3 col-sm-2">
                            <span id="Label2">Al Recibo:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-9 col-sm-4">
                            <dx:BootstrapComboBox ID="id_recibo1" runat="server" ValueType="System.String">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-11" ListBox="fs-10" Control="fs-10" />

                            </dx:BootstrapComboBox>
                            <%--<select name="ctl00$cpmaster$id_recibo1" id="ctl00_cpmaster_id_recibo1" style="color: #0F5B96; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                            </select>--%>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-3 col-sm-2">
                            <span id="lblal">Fecha Entrega:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-9 col-sm-8">
                            <dx:BootstrapDateEdit ID="fecha_entregado" runat="server" CalendarProperties-CssClasses-Button="btn-sm">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" Calendar="fs-10" />

                            </dx:BootstrapDateEdit>

                            <%--       <input name="ctl00$cpmaster$fecha_entregado" type="text" id="ctl00_cpmaster_fecha_entregado" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 70px;">

                            <input type="image" name="ctl00$cpmaster$ibtncalendario" id="ctl00_cpmaster_ibtncalendario" src="images/Calendar_scheduleHS.png" alt="Click en la Imagen para mostrar el Calendario" style="border-width: 0px;">
                            --%>
                        </div>

                    </div>

                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-12">
                            <dx:BootstrapButton runat="server" ID="btnguardar" Text="Aceptar">
                                <SettingsBootstrap RenderOption="None" Sizing="Small" />
                                <CssClasses Control="msg_button_class" Text="fs-9" />
                            </dx:BootstrapButton>
                            <%--     <input type="submit" name="ctl00$cpmaster$btnguardar" value="Guardar" id="ctl00_cpmaster_btnguardar" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                            --%>
                        </div>
                    </div>


                </div>
            </div>
            <p class="links">
                <a class="error"><span id="ctl00_cpmaster_lblmensaje" class="error"></span></a>
            </p>
        </div>
    </div>
</asp:Content>
