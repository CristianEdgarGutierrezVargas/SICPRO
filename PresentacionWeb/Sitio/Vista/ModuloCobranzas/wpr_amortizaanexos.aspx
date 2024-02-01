<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_amortizaanexos.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ModuloCobranzas.wpr_amortizaanexos" %>


<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container p-3">
        <div class="card p-2">
            <h1 class="title">Amortización de Cuotas</h1>
            <div class="row">
                <div class="col-12 col-sm-12 col-md-3 col-lg-2 col-xl-2">
                    <img src="/UI/img/amortiza2.png" alt="" width="122" height="122" class="left">
                </div>
                <div class="col-12 col-sm-12 col-md-9 col-lg-10 col-xl-10">

                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3 col-xxl-3">
                            <span id="lblnombre">Cliente/Asegurado:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-8 col-lg-9 col-xl-9 col-xxl-9">
                            <div class="d-flex">
                                <dx:BootstrapTextBox runat="server" ID="nomraz" NullText="" Text="" Width="280px">
                                    <CssClasses Input="form-control-sm fs-10" />
                                    <ValidationSettings>
                                        <RequiredField IsRequired="true" ErrorText="" />
                                    </ValidationSettings>
                                </dx:BootstrapTextBox>
                                <dx:BootstrapButton runat="server" ID="btnserper" Text="...">
                                    <SettingsBootstrap RenderOption="None" Sizing="Small" />
                                    <CssClasses Control="msg_button_class ms-2" Text="fs-9" />
                                </dx:BootstrapButton>
                            </div>
                            <asp:HiddenField ID="a" runat="server" />
                            <asp:HiddenField ID="b" runat="server" />
                            <asp:HiddenField ID="id_per" runat="server" />
                            <asp:HiddenField ID="id_perclie" runat="server" />
                            <asp:HiddenField ID="cuota_neta" runat="server" />
                            <asp:HiddenField ID="cuota_total" runat="server" />
                            <asp:HiddenField ID="comision_cuota" runat="server" />
                            <asp:HiddenField ID="anio_recibo" runat="server" />
                            <asp:HiddenField ID="neta_pago" runat="server" />
                            <asp:HiddenField ID="comision_pago" runat="server" />
                            <asp:HiddenField ID="id_liq" runat="server" />

                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-3">
                            <span id="Label2">N° Póliza :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-3 col-xl-3">
                            <dx:BootstrapComboBox ID="num_poliza" runat="server" ValueType="System.String">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" Control="fs-10" />
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Dato requerido" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>

                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-2 col-xl-2 col-xxl-2">
                            <span id="Label5">N° Liquidación :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-3 col-xl-3 col-xxl-3">
                            <dx:BootstrapComboBox ID="no_liquida" runat="server" ValueType="System.String">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" Control="fs-10" />
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Dato requerido" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>

                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                            <span id="ctl00_cpmaster_Label15">Grupo Asegurado:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-8 col-lg-7 col-xl-7">
                            <asp:Label ID="desc_grupo" runat="server" CssClass="form-control form-control-sm border border-light"></asp:Label>
                            <asp:HiddenField ID="id_gru" runat="server" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-3">
                            <span id="ctl00_cpmaster_lblncuotas">N° de Cuota :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-9 col-xl-3">
                            <dx:BootstrapComboBox ID="cuota" runat="server" ValueType="System.String">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" Control="fs-10" />
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Dato requerido" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>

                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-2 col-xxl-2">
                            <span id="ctl00_cpmaster_Label6">Tipo de Pago :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-9 col-xl-3 col-xxl-3">
                            <dx:BootstrapComboBox ID="id_tpago" runat="server" ValueType="System.String">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" Control="fs-10" />
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Dato requerido" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                            <span id="ctl00_cpmaster_Label7">Recibo/Compensación :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-8 col-lg-7 col-xl-7">
                            <div class="d-flex">
                                <dx:BootstrapTextBox runat="server" ID="recibo" NullText="" Text="">
                                    <CssClasses Input="form-control-sm fs-10" Control="me-3" />
                                    <ValidationSettings>
                                        <RequiredField IsRequired="true" ErrorText="" />
                                    </ValidationSettings>
                                </dx:BootstrapTextBox>
                                <dx:BootstrapButton runat="server" ID="btnrec" Text="..." OnClick="btnrec_Click">
                                    <SettingsBootstrap RenderOption="None" Sizing="Small" />
                                    <CssClasses Control="msg_button_class me-3" Text="fs-9" />
                                </dx:BootstrapButton>

                                <dx:BootstrapTextBox runat="server" ID="monto_resto" NullText="" Text="">
                                    <CssClasses Input="form-control-sm fs-10" />
                                    <ValidationSettings>
                                        <RequiredField IsRequired="true" ErrorText="" />
                                    </ValidationSettings>
                                </dx:BootstrapTextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-3 col-xxl-3">
                            <span id="ctl00_cpmaster_Label8">Prima Total :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-3 col-xl-3">
                            <dx:BootstrapTextBox runat="server" ID="monto_exclusion" NullText="" Text="">
                                <CssClasses Input="form-control-sm fs-10" />
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="" />
                                </ValidationSettings>
                            </dx:BootstrapTextBox>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-2 col-xl-2 col-xxl-2">
                            <span id="ctl00_cpmaster_Label9">Cuota Pagada :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-3 col-xl-3 col-xxl-3">
                            <dx:BootstrapTextBox runat="server" ID="monto_devolucion" NullText="" Text="">
                                <CssClasses Input="form-control-sm fs-10" />
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="" />
                                </ValidationSettings>
                            </dx:BootstrapTextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-3 col-xxl-3">
                            <span id="ctl00_cpmaster_Label10">Monto a Pagar :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-3 col-xl-3">
                            <dx:BootstrapTextBox runat="server" ID="monto_pago" NullText="" Text="">
                                <CssClasses Input="form-control-sm fs-10" />
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="" />
                                </ValidationSettings>
                            </dx:BootstrapTextBox>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-2 col-xxl-2">
                            <span id="ctl00_cpmaster_Label14">Liquidación :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-3 col-xl-3 col-xxl-3">
                            <dx:BootstrapTextBox runat="server" ID="idliq" NullText="" Text="">
                                <CssClasses Input="form-control-sm fs-10" />
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="" />
                                </ValidationSettings>
                            </dx:BootstrapTextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                            <span id="Label13">Pago Por :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-8 col-lg-8 col-xl-8">
                            <dx:BootstrapMemo ID="pago_por" runat="server">
                                <CssClasses Input="form-control-sm" />
                            </dx:BootstrapMemo>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-12">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <dx:BootstrapButton runat="server" ID="Button1" Text="Nuevo" OnClick="Button1_Click">
                                <SettingsBootstrap RenderOption="None" Sizing="Small" />
                                <CssClasses Control="msg_button_class" Text="fs-9" />
                            </dx:BootstrapButton>
                            <dx:BootstrapButton runat="server" ID="b1" Text="Actualizar" OnClick="b1_Click">
                                <SettingsBootstrap RenderOption="None" Sizing="Small" />
                                <CssClasses Control="msg_button_class" Text="fs-9" />
                            </dx:BootstrapButton>
                            <dx:BootstrapButton runat="server" ID="btnguardar" Text="Guardar" OnClick="btnguardar_Click">
                                <SettingsBootstrap RenderOption="None" Sizing="Small" />
                                <CssClasses Control="msg_button_class" Text="fs-9" />
                            </dx:BootstrapButton>
                        </div>
                    </div>

                </div>
            </div>

        </div>
    </div>
</asp:Content>
