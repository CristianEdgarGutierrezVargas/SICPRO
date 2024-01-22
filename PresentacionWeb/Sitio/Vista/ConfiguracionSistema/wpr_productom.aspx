<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_productom.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wpr_productom" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Modificación de Productos</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <img src="../../../UI/img/img07.jpg" alt="" width="122" height="122">
            </div>
            <span class="border border-3 rounded w-75 pt-2 mb-2">
                <div class="col-10">
                    <div class="row p-2">
                        <div class="col-2">
                            Compañia:
                        </div>
                        <div class="col-8">
                            <asp:DropDownList ID="id_spvs" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <asp:ListItem Value="-1" Text="SELECCIONE UNA OPCIÓN"></asp:ListItem>
                                <asp:ListItem Value="108" Text="ALIANZA COMPANIA DE SEGUROS Y REASEGUROS S.A."></asp:ListItem>
                                <asp:ListItem Value="207" Text="ALIANZA VIDA SEGUROS Y REASEGUROS S.A."></asp:ListItem>
                                <asp:ListItem Value="109" Text="BISA SEGUROS Y REASEGUROS"></asp:ListItem>
                                <asp:ListItem Value="201" Text="BUPA INSURANCE  (BOLIVIA) S.A."></asp:ListItem>
                                <asp:ListItem Value="211" Text="COMPAÑÍA DE SEGUROS DE VIDA FORTALEZA S.A."></asp:ListItem>
                                <asp:ListItem Value="113" Text="COMPAÑÍA DE SEGUROS Y REASEGUROS FORTALEZA S.A."></asp:ListItem>
                                <asp:ListItem Value="110" Text="COOPERATIVA DE SEGUROS 24 DE SEPTIEMBRE"></asp:ListItem>
                                <asp:ListItem Value="102" Text="CREDINFORM INTERNATIONAL S.A."></asp:ListItem>
                                <asp:ListItem Value="209" Text="CREDISEGURO S.A. SEGUROS PERSONALES"></asp:ListItem>
                                <asp:ListItem Value="101" Text="LA BOLIVIANA CIACRUZ DE SEGUROS Y REASEGUROS S.A."></asp:ListItem>
                                <asp:ListItem Value="204" Text="LA BOLIVIANA CIACRUZ SEGUROS PERSONALES S.A."></asp:ListItem>
                                <asp:ListItem Value="203" Text="LA VITALICIA SEGUROS Y REASEGUROS DE VIDA S.A."></asp:ListItem>
                                <asp:ListItem Value="118" Text="MERCANTIL SANTA CRUZ SEGUROS Y REASEGUROS GENERALES S.A."></asp:ListItem>
                                <asp:ListItem Value="115" Text="NACIONAL SEGUROS PATRIMONIALES Y FIANZAS S.A."></asp:ListItem>
                                <asp:ListItem Value="206" Text="NACIONAL VIDA SEGUROS DE PERSONAS S.A."></asp:ListItem>
                                <asp:ListItem Value="105" Text="SEGUROS ILLIMANI"></asp:ListItem>
                                <asp:ListItem Value="205" Text="SEGUROS PROVIDA S.A."></asp:ListItem>
                                <asp:ListItem Value="210" Text="SEGUROS Y REASEGUROS PERSONALES UNIVIDA S.A."></asp:ListItem>
                                <asp:ListItem Value="116" Text="UNIBIENES S.A. SEGUROS Y REASEGUROS PATRIMONIALES"></asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Producto:
                        </div>
                        <div class="col-8">
                            <asp:DropDownList ID="id_producto" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <asp:ListItem Value="-1" Text="SELECCIONE UNA OPCIÓN"></asp:ListItem>
                                <asp:ListItem Value="15" Text="ACCIDENTES PERSONALES"></asp:ListItem>
                                <asp:ListItem Value="146" Text="ASISTENCIA GLOBAL"></asp:ListItem>
                                <asp:ListItem Value="16" Text="ASISTENCIA MÉDICA FAMILIAR"></asp:ListItem>
                                <asp:ListItem Value="149" Text="COVID"></asp:ListItem>
                                <asp:ListItem Value="22" Text="DESGRAVAMEN HIPOTECARIO"></asp:ListItem>
                                <asp:ListItem Value="64" Text="SALUD"></asp:ListItem>
                                <asp:ListItem Value="145" Text="SALUD MUNDIAL"></asp:ListItem>
                                <asp:ListItem Value="81" Text="SEPELIO A CORTO PLAZO"></asp:ListItem>
                                <asp:ListItem Value="71" Text="VIDA ANUAL RENOVABLE"></asp:ListItem>
                                <asp:ListItem Value="147" Text="VIDA CON FONDO DE AHORRO (AÑO 2)"></asp:ListItem>
                                <asp:ListItem Value="148" Text="VIDA CON FONDO DE AHORRO (AÑO 3 EN ADELANTE)"></asp:ListItem>
                                <asp:ListItem Value="82" Text="VIDA EN GRUPO A CORTO PLAZO "></asp:ListItem>
                                <asp:ListItem Value="17" Text="VIDA INDIVIDUAL Y CORTO PLAZO"></asp:ListItem>
                                <asp:ListItem Value="74" Text="VIDA TEMPORAL 1ER AÑO"></asp:ListItem>
                                <asp:ListItem Value="72" Text="VIDA TEMPORAL 2DO A 6TO AÑO"></asp:ListItem>
                                <asp:ListItem Value="73" Text="VIDA TEMPORAL 7MO AÑOS EN ADELANTE"></asp:ListItem>
                                <asp:ListItem Value="18" Text="VIDA TEMPORAL LARGO PLAZO 1ER AÑO"></asp:ListItem>
                                <asp:ListItem Value="19" Text="VIDA TEMPORAL LARGO PLAZO 2DO AÑO"></asp:ListItem>
                                <asp:ListItem Value="20" Text="VIDA TEMPORAL LARGO PLAZO 3,4 Y 5TO AÑOS"></asp:ListItem>
                                <asp:ListItem Value="21" Text="VIDA TEMPORAL LARGO PLAZO 6TO AÑO ADELANTE"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Riesgo:
                        </div>
                        <div class="col-8">
                            <asp:DropDownList ID="id_riesgo" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <asp:ListItem Value="-1" Text="SELECCIONE UNA OPCIÓN"></asp:ListItem>
                                <asp:ListItem Value="91-12-00" Text="ACCIDENTES PERSONALES"></asp:ListItem>
                                <asp:ListItem Value="93-50-00" Text="ACCIDENTES PERSONALES"></asp:ListItem>
                                <asp:ListItem Value="91-06-03" Text="ACCIDENTES PERSONALES DE AERONAVEGACION"></asp:ListItem>
                                <asp:ListItem Value="91-06-00" Text="AERONAVEGACION"></asp:ListItem>
                                <asp:ListItem Value="93-47-01" Text="ASISTENCIA MEDICA"></asp:ListItem>
                                <asp:ListItem Value="91-05-00" Text="AUTOMOTORES"></asp:ListItem>
                                <asp:ListItem Value="92-23-00" Text="BUENA EJECUCION DE OBRA"></asp:ListItem>
                                <asp:ListItem Value="91-06-02" Text="CASCO DE AERONAVEGACION"></asp:ListItem>
                                <asp:ListItem Value="92-26-00" Text="CORRECTA INVERSION DE ANTICIPOS"></asp:ListItem>
                                <asp:ListItem Value="92-22-00" Text="CUMPLIMIENTO DE CONTRATO DE OBRA"></asp:ListItem>
                                <asp:ListItem Value="92-24-00" Text="CUMPLIMIENTO DE CONTRATO DE SERVICIOS"></asp:ListItem>
                                <asp:ListItem Value="92-25-00" Text="CUMPLIMIENTO DE CONTRATO DE SUMINISTROS"></asp:ListItem>
                                <asp:ListItem Value="92-30-00" Text="CUMPLIMIENTO DE OBLIGACIONE LEGALES Y CONTRACTUALE"></asp:ListItem>
                                <asp:ListItem Value="d-d-d" Text="D"></asp:ListItem>
                                <asp:ListItem Value="95-62-00" Text="DEFUNCION Y/O SEPELIO"></asp:ListItem>
                                <asp:ListItem Value="93-45-00" Text="DEFUNCION Y/O SEPELIO DE CORTO PLAGO"></asp:ListItem>
                                <asp:ListItem Value="93-44-00" Text="DEFUNCION Y/O SEPELIO DE LARGO PLAGO"></asp:ListItem>
                                <asp:ListItem Value="93-48-01" Text="DESGRAVAMEN HIPOTECARIO"></asp:ListItem>
                                <asp:ListItem Value="93-49-01" Text="DESGRAVAMEN HIPOTECARIO ANUAL RENOVABLE"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-1">
                            Fórmula:
                        </div>
                        <div class="col-1">
                            <p class="fw-bold" style="text-align: right;">PT</p>
                        </div>
                        <div class="col-2">
                            <asp:DropDownList ID="opera" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; width: 60px;">
                                <asp:ListItem Value="!--" Text="!--"></asp:ListItem>
                                <asp:ListItem Value="false" Text="*"></asp:ListItem>
                                <asp:ListItem Value="true" Text="/"></asp:ListItem>
                            </asp:DropDownList>

                        </div>
                        <div class="col-2">
                            <asp:TextBox ID="evaluar" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px;">0,00</asp:TextBox>
                        </div>
                        <div class="col-4"></div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Comisión:
                        </div>
                        <div class="col-2">
                            <asp:TextBox ID="comis_riesgo" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 50px;">0,00</asp:TextBox>
                        </div>
                        <div class="col-2">
                            Por. a Crédito :
                        </div>
                        <div class="col-2">
                            <asp:TextBox ID="por_cred" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 50px;">0,00</asp:TextBox>
                        </div>
                        <div class="col-2">
                            Plus Neta :
                        </div>
                        <div class="col-2">
                            <asp:TextBox ID="plus_neta" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 50px;">0,00</asp:TextBox>
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-3">
                            Form. Contado :
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="form_riesgo1" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px;">0,00</asp:TextBox>
                        </div>
                        <div class="col-2">
                            <img src="../../../UI/img/lc_checkbox.png" alt="" width="24px" height="24px">
                        </div>
                        <div class="col-3">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-3">
                            Form. Contado :
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="form_riesgo2" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px;">0,00</asp:TextBox>
                        </div>
                        <div class="col-2">
                            <img src="../../../UI/img/lc_checkbox.png" alt="" width="24px" height="24px">
                        </div>
                        <div class="col-3">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                        </div>
                        <div class="col-2">
                            <dx:ASPxButton ID="btnnuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;"></dx:ASPxButton>
                        </div>
                        <div class="col-2">
                            <dx:ASPxButton ID="btnguardarr" runat="server" Text="Guardar" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;"></dx:ASPxButton>
                        </div>
                        <div class="col-2">
                            <dx:ASPxButton ID="btnsalir" runat="server" Text="Salir" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;"></dx:ASPxButton>
                        </div>
                        <div class="col-2">
                        </div>

                    </div>
                </div>
            </span>
        </div>
    </div>
</asp:Content>
