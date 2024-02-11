<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_amortizaanexos.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ModuloCobranzas.wpr_amortizaanexos" %>


<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <script>
        function UpdateDetailGrid(s, e) {
            var index = e.visibleIndex;

            CallBPersona.PerformCallback(index);
        }
        function OnEndCallbackPersona(s, e) {

            pCPersona.Hide();

        }
    </script>
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
                            <div class="d-flex ">

                                <dx:BootstrapTextBox runat="server" ID="nomraz" NullText="" Text="" Width="220px">
                                    <CssClasses Input="form-control-sm fs-10" />

                                </dx:BootstrapTextBox>
                                <asp:HiddenField runat="server" ID="id_per" Value="" />

                                <dx:BootstrapButton runat="server" ID="btnserper" Text="..." OnClick="btnserper_Click">
                                    <SettingsBootstrap RenderOption="None" Sizing="Small" />
                                    <CssClasses Control="msg_button_class ms-2" Text="fs-9" />
                                </dx:BootstrapButton>
                            </div>
                            <asp:HiddenField ID="a" runat="server" />
                            <asp:HiddenField ID="b" runat="server" />

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
                            <dx:BootstrapComboBox ID="num_poliza" runat="server" ValueType="System.String" AutoPostBack="true" OnSelectedIndexChanged="num_poliza_SelectedIndexChanged">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" Control="fs-10" />
                                <ValidationSettings ValidationGroup="guardar">
                                    <RequiredField IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>

                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-2 col-xl-2 col-xxl-2">
                            <span id="Label5">N° Liquidación :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-3 col-xl-3 col-xxl-3">
                            <dx:BootstrapComboBox ID="no_liquida" runat="server" ValueType="System.String" AutoPostBack="true" OnSelectedIndexChanged="no_liquida_SelectedIndexChanged">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" Control="fs-10" />
                                <ValidationSettings ValidationGroup="guardar">
                                    <RequiredField IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>

                        </div>
                    </div>

                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-3">
                            <span id="ctl00_cpmaster_lblncuotas">Cuota devolución:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-9 col-xl-3">
                            <dx:BootstrapComboBox ID="cuota_devolucion" runat="server" ValueType="System.String">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" Control="fs-10" />
                                <ValidationSettings ValidationGroup="guardar">
                                    <RequiredField IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>

                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-2 col-xxl-2">
                            <span id="ctl00_cpmaster_Label6">Monto Dev:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-9 col-xl-3 col-xxl-3">
                            <dx:BootstrapSpinEdit ID="monto_devolucion" runat="server">
                                <CssClasses Input="form-control-sm fs-10" Control="fs-10" />
                                <ValidationSettings ValidationGroup="guardar">
                                    <RequiredField IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapSpinEdit>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                            <span id="ctl00_cpmaster_Label7">Saldo devolucion:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-8 col-lg-3 col-xl-3">
                            <dx:BootstrapSpinEdit ID="saldo_devolucion" runat="server">
                                <CssClasses Input="form-control-sm fs-10" Control="fs-10" />
                                <ValidationSettings ValidationGroup="guardar">
                                    <RequiredField IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapSpinEdit>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                            <span id="ctl00_cpmaster_abel7">Monto Cheque</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-8 col-lg-3 col-xl-3">
                            <dx:BootstrapSpinEdit ID="mcheque" runat="server">
                                <CssClasses Input="form-control-sm fs-10" Control="fs-10" />
                                <ValidationSettings ValidationGroup="guardar">
                                    <RequiredField IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapSpinEdit>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                            <span id="Lael13">Cheque :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-8 col-lg-8 col-xl-8">
                            <dx:BootstrapTextBox ID="cheque" runat="server">
                                <CssClasses Input="form-control-sm" />
                            </dx:BootstrapTextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                            <span id="Lab13">Pago Por :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-8 col-lg-8 col-xl-8">
                            <dx:BootstrapMemo ID="pago_por" runat="server">
                                <CssClasses Input="form-control-sm" />
                            </dx:BootstrapMemo>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                            <span id="Label13">Banco :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-8 col-lg-8 col-xl-8">
                            <dx:BootstrapTextBox ID="banco" runat="server">
                                <CssClasses Input="form-control-sm" />
                            </dx:BootstrapTextBox>
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
                            <dx:BootstrapButton runat="server" ID="btnguardar" Text="Guardar" OnClick="btnguardar_Click" ValidationGroup="guardar">
                                <SettingsBootstrap RenderOption="None" Sizing="Small" />
                                <CssClasses Control="msg_button_class" Text="fs-9" />
                            </dx:BootstrapButton>
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </div>

    <dx:BootstrapPopupControl ID="pCPersona" runat="server" ClientInstanceName="pCPersona" ShowHeader="false" ShowFooter="true" Modal="true" CloseAction="None" SettingsBootstrap-Sizing="Small">
        <SettingsAdaptivity Mode="Always" MaxWidth="500px" />
        <CssClasses Content="pt-1" />
        <ContentCollection>
            <dx:ContentControl>
                <div class="row msg_button_class rounded-top-1">
                    <div class="col-12 fs-10 p-1 ">
                        <span>Busqueda de Persona por Nombre o Razón Social</span>
                    </div>
                </div>
                <div class="row">
                    <div class="col-4">
                        <div class="row">
                            <div class="col-12 text-center mt-2">
                                <img src="../../../UI/img/search_user.png" />
                            </div>
                            <div class="col-12 text-center mt-2">
                                <dx:BootstrapTextBox runat="server" ID="nomraz1" ClientInstanceName="nomraz1" NullText="" Width="150px">
                                    <CssClasses Input="form-control-sm fs-10" />
                                </dx:BootstrapTextBox>
                            </div>
                            <div class="col-12 text-center mt-2">
                                <dx:BootstrapButton ID="btnserper1" runat="server" AutoPostBack="false" Text="-->" OnClick="btnserper1_Click">
                                    <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                    <SettingsBootstrap RenderOption="None" />
                                </dx:BootstrapButton>
                            </div>
                        </div>
                    </div>
                    <div class="col-8 mt-2">

                        <dx:BootstrapGridView ID="grdPersonas" EnableCallBacks="true" runat="server" KeyFieldName="id_per;nomraz" ClientInstanceName="grdPersonas" OnDataBinding="grdPersonas_DataBinding">
                            <Settings ShowColumnHeaders="false" ShowTitlePanel="true" />
                            <SettingsText Title="Lista de Personas" />
                            <SettingsBehavior AllowFocusedRow="True" AllowClientEventsOnLoad="False" AllowSelectByRowClick="true" />

                            <SettingsBootstrap Striped="true" />
                            <CssClasses PanelHeading="msg_button_class p-1 fs-10 " />
                            <SettingsPager NumericButtonCount="3">
                                <PageSizeItemSettings Visible="false" Items="10, 20, 50" />
                            </SettingsPager>
                            <Columns>
                                <dx:BootstrapGridViewDataColumn FieldName="nomraz" Width="200px" CssClasses-DataCell="fs-11"></dx:BootstrapGridViewDataColumn>
                                <dx:BootstrapGridViewDataColumn Width="50px" CssClasses-DataCell="fs-11">
                                    <DataItemTemplate>
                                        <dx:BootstrapButton ID="btnSelect" runat="server" OnClick="btnSelect_Click">
                                            <CssClasses Icon="bi bi-check2-circle text-primary" />
                                            <SettingsBootstrap RenderOption="None" />
                                        </dx:BootstrapButton>
                                    </DataItemTemplate>
                                </dx:BootstrapGridViewDataColumn>

                            </Columns>

                        </dx:BootstrapGridView>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                    </div>
                </div>
            </dx:ContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <dx:BootstrapButton runat="server" ID="btnAceptar" OnClick="btnAceptar_Click" Text="Aceptar">
                <SettingsBootstrap RenderOption="None" Sizing="Small" />
                <CssClasses Control="msg_button_class" Text="fs-9" />
            </dx:BootstrapButton>
        </FooterContentTemplate>
    </dx:BootstrapPopupControl>
</asp:Content>
