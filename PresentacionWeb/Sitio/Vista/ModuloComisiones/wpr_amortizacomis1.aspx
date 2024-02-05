<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_amortizacomis1.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ModuloComisiones.wpr_amortizacomis1" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">


    <div class="container p-2">
        <div class="card p-3">
            <div class="row">
                <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-2">
                    <img src="../../../UI/img/docscia.png" alt="" class="img-fluid">
                </div>
                <div class="col-12 col-sm-12 col-md-9 col-lg-9 col-xl-10">

                    <div class="row">
                        <div class="col-12">
                            <h1 class="title">Registro Cheque de Compañía</h1>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-2">
                            <span id="Label17">Cia Aseguradora :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-9 col-xl-10">
                            <dx:BootstrapComboBox ID="id_spvs" runat="server" ValueType="System.String" NullText="Seleccione una compañia..." AutoPostBack="true" OnSelectedIndexChanged="id_spvs_SelectedIndexChanged">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" />
                                <ValidationSettings>
                                    <RequiredField ErrorText="Debe Seleccionar una Compañia" IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>
                        </div>
                    </div>
                    <div class="row msg_button_class mt-3">
                        <div class="col-12 pt-1">
                            <span>Propiedades del Cheque</span>
                        </div>
                    </div>
                    <div class="row mt">
                        <div class="col-4 col-sm-4 col-md-3 col-lg-3 col-xl-2">
                            <span id="Label10">Cheque :</span>
                        </div>
                        <div class="col-8 col-sm-8 col-md-4 col-lg-4 col-xl-4">
                            <dx:BootstrapComboBox ID="cheque" runat="server" ValueType="System.String" NullText="Seleccione una opcion..." AutoPostBack="true" OnSelectedIndexChanged="id_spvs_SelectedIndexChanged">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" />
                                <ValidationSettings>
                                    <RequiredField ErrorText="Debe Seleccionar una opcion" IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>
                        </div>

                    </div>

                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-2 col-xxl-3">
                            <span id="Label2">Mes :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-4 col-lg-4 col-xl-4 col-xxl-3">
                            <asp:Label ID="pago_mes" runat="server" Text=""></asp:Label>

                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 pe-0 col-4 col-sm-4 col-md-1 col-lg-1 col-xl-2 col-xxl-3">
                            <span id="Label21">Año :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-4 col-lg-4 col-xl-4 col-xxl-3">
                            <asp:Label ID="pc_anio" runat="server" Text=""></asp:Label>

                        </div>
                    </div>

                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-2 col-xxl-3">
                            <span id="LabelFecha">Fecha emisión :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-4 col-lg-4 col-xl-4 col-xxl-3">
                            <asp:Label ID="fecha" runat="server" Text=""></asp:Label>

                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 pe-0 col-4 col-sm-4 col-md-1 col-lg-1 col-xl-2 col-xxl-3">
                            <span id="LabelSaldo">Saldo :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-4 col-lg-4 col-xl-4 col-xxl-3">
                            <asp:Label ID="comisaldo_pc" runat="server" Text=""></asp:Label>

                        </div>
                    </div>

                    <div class="row msg_button_class mt-3">
                        <div class="col-12 pt-1">
                            <span>Datos de Liquidación</span>
                        </div>
                    </div>

                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-2">
                            <span id="liq">Liquidación :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-9 col-xl-10">
                            <dx:BootstrapComboBox ID="RadComboBox1" runat="server" ValueType="System.String" NullText="Seleccione una liquidación...">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" />
                                <ValidationSettings>
                                    <RequiredField ErrorText="Debe Seleccionar una Liquidación" IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>
                        </div>
                        <div class="row">

                            <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-2 col-xxl-3">
                                <span id="Labelcuo">Cuota:</span>
                            </div>
                            <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-9 col-xl-4 col-xxl-3">
                                <dx:BootstrapSpinEdit ID="cuota" runat="server" ReadOnly="true" NullText="0.00" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                    <SpinButtons ShowLargeIncrementButtons="true" />
                                    <CssClasses Button="btn-sm" Control="fs-10" Input="form-control-sm fs-10" />
                                    <ValidationSettings>
                                        <RequiredField IsRequired="true" ErrorText="Debe Registrar una ComisiónDato requerido" />
                                    </ValidationSettings>
                                </dx:BootstrapSpinEdit>
                            </div>
                        </div>
                        <div class="row">

                            <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-2 col-xxl-3">
                                <span id="Label19">Comisión Pago:</span>
                            </div>
                            <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-9 col-xl-4 col-xxl-3">
                                <dx:BootstrapSpinEdit ID="comision_pc" runat="server" ReadOnly="true" NullText="0.00" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                    <SpinButtons ShowLargeIncrementButtons="true" />
                                    <CssClasses Button="btn-sm" Control="fs-10" Input="form-control-sm fs-10" />
                                    <ValidationSettings>
                                        <RequiredField IsRequired="true" ErrorText="Debe Registrar una ComisiónDato requerido" />
                                    </ValidationSettings>
                                </dx:BootstrapSpinEdit>
                            </div>
                            <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-2">
                                <span id="Label18">Pago compañia :</span>
                            </div>
                            <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-9 col-xl-4">
                                <dx:BootstrapSpinEdit ID="monto_comis" runat="server" ReadOnly="true" NullText="0.00" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                    <SpinButtons ShowLargeIncrementButtons="true" />
                                    <CssClasses Button="btn-sm" Control="fs-10" Input="form-control-sm fs-10" />
                                    <ValidationSettings>
                                        <RequiredField IsRequired="true" ErrorText="Debe Registrar un Monto" />
                                    </ValidationSettings>
                                </dx:BootstrapSpinEdit>
                            </div>
                        </div>


                        <div class="row">
                            <div class="col-12">
                                <dx:BootstrapButton runat="server" ID="btncuotas" Text="Aceptar" OnClick="btncuotas_Click">
                                    <SettingsBootstrap RenderOption="None" Sizing="Small" />
                                    <CssClasses Control="msg_button_class" Text="fs-9" />
                                </dx:BootstrapButton>
                                <%--      <input type="submit" name="ctl00$cpmaster$btncuotas" value="Guardar Cheque" id="ctl00_cpmaster_btncuotas" class="msg_button_class" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                --%>
                            </div>
                        </div>



                    </div>
                </div>


            </div>
            <p class="links">
                <span id="ctl00_cpmaster_lblmensaje" class="error">Introduzca Valores</span>
            </p>
        </div>
        <dx:BootstrapPopupControl HeaderText="Mensaje" runat="server" ID="pnlMensaje"
            PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="300px" CloseAction="CloseButton"
            Modal="true" CssClasses-Header="fs-9 text-white bg-primary">
            <ContentCollection>
                <dx:ContentControl>
                    <div class="row">
                        <div class="offset-3 col-9">
                            <asp:Image ImageUrl="../../../UI/img/ok.png" Width="70px" runat="server" ID="imagenOk" />
                            <asp:Image ImageUrl="../../../UI/img/msg_icon_2.png" Width="70px" runat="server" ID="imagenFail" />

                        </div>
                        <div class="col-12">
                            <asp:Label runat="server" ID="lblMensaje" Text=""></asp:Label>
                        </div>
                    </div>
                </dx:ContentControl>
            </ContentCollection>
        </dx:BootstrapPopupControl>
</asp:Content>
