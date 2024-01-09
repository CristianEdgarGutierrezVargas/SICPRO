<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_recibocomisiones.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ModuloComisiones.wpr_recibocomisiones" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container">
        <div class="card p-3">
            <h1 class="fs-7 fw-bold text-info">Registro de Recibos</h1>
            <div class="row">
                <div class="col-4 col-sm-4 col-md-4 col-lg-4 text-center">
                    <img src="../../../UI/img/img07.jpg" alt="" width="122" height="122" class="left">
                </div>

                <div class="col-8 col-sm-8 col-md-7 col-lg-6">

                    <div class="row">
                        <div class="col-2">
                            <span id="lbldel">Del :</span>
                        </div>
                        <div class="col-4">

                            <dx:BootstrapTextBox runat="server" ID="del" NullText="cheque" Text="">
                                <CssClasses Input="form-control-sm fs-10" />
                            </dx:BootstrapTextBox>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-2">
                            <span id="lblal">Al :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4">
                            <dx:BootstrapTextBox runat="server" ID="al" NullText="cheque" Text="">
                                <CssClasses Input="form-control-sm fs-10" />
                            </dx:BootstrapTextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-2">
                            <span id="lblanio">Año :</span>
                        </div>
                        <div class="col-4">
                            <dx:BootstrapTextBox runat="server" ID="anio" NullText="cheque" Text="">
                                <CssClasses Input="form-control-sm fs-10" />
                            </dx:BootstrapTextBox>
                        </div>

                    </div>


                    <div class="row">
                        <div class="col-12">
                            <dx:BootstrapButton runat="server" ID="btnguardar" Text="Aceptar">
                                <SettingsBootstrap RenderOption="None" Sizing="Small" />
                                <CssClasses Control="msg_button_class" Text="fs-9" />
                            </dx:BootstrapButton>
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
