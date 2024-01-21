<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_amortizacomis.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ModuloComisiones.wpr_amortizacomis" %>

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

                    <div class="row mt">
                        <div class="col-4 col-sm-4 col-md-3 col-lg-3 col-xl-2">
                            <span id="Label10">Cheque :</span>
                        </div>
                        <div class="col-8 col-sm-8 col-md-4 col-lg-4 col-xl-4">
                            <dx:BootstrapTextBox runat="server" ID="cheque" NullText="" Text="">
                                <CssClasses Input="form-control-sm fs-10" />
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Debe Registrar un Cheque" />
                                </ValidationSettings>
                            </dx:BootstrapTextBox>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-0 col-4 col-sm-4 col-md-2 col-lg-2 col-xl-2">
                            <span id="Label16">Fecha :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-0 col-8 col-sm-8 col-md-3 col-lg-3 col-xl-4">
                            <dx:BootstrapDateEdit ID="fecha" runat="server" CalendarProperties-CssClasses-Button="btn-sm">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" Calendar="fs-10" />
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Debe Seleccionar una Fecha" />
                                </ValidationSettings>
                            </dx:BootstrapDateEdit>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-2">
                            <span id="Label17">Cia Aseguradora :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-9 col-xl-10">
                            <dx:BootstrapComboBox ID="id_spvs" runat="server" ValueType="System.String" NullText="Seleccione una compañia...">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" />
                                <ValidationSettings>
                                    <RequiredField ErrorText="Debe Seleccionar una Compañia" IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>


                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-2">
                            <span id="Label18">Monto :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-9 col-xl-4">
                            <dx:BootstrapSpinEdit ID="monto_pc" runat="server" NullText="0.00" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                <SpinButtons ShowLargeIncrementButtons="true" />
                                <CssClasses Button="btn-sm" Control="fs-10" Input="form-control-sm fs-10" />
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Debe Registrar un Monto" />
                                </ValidationSettings>
                            </dx:BootstrapSpinEdit>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-2 col-xxl-3">
                            <span id="Label19">Comisión :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-9 col-xl-4 col-xxl-3">
                            <dx:BootstrapSpinEdit ID="comision_pc" runat="server" NullText="0.00" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
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
                            <span id="ctl00_cpmaster_Label23">Divisa :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-4 col-lg-4 col-xl-4 col-xxl-3">
                            <dx:BootstrapComboBox ID="id_div" runat="server" ValueType="System.String">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" Control="fs-10" />
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Dato requerido" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-2 col-lg-2 col-xl-2 col-xxl-3">
                            <span id="Label20">Factura :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-3 col-lg-3 col-xl-4 col-xxl-3">
                            <dx:BootstrapTextBox runat="server" ID="factura_pc" NullText="" Text="">
                                <CssClasses Input="form-control-sm fs-10" />
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Debe Registrar una Factura" />
                                </ValidationSettings>
                            </dx:BootstrapTextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-2 col-xxl-3">
                            <span id="Label22">Año :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-4 col-lg-4 col-xl-4 col-xxl-3">
                            <dx:BootstrapComboBox ID="pc_anio" runat="server" ValueType="System.String">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" Control="fs-10" />
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Debe Seleccionar un Año" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>
                            <%-- <select name="ctl00$cpmaster$pc_anio" id="ctl00_cpmaster_pc_anio" class="general" style="color: #0F5B96; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; width: 100px;">
                                <option value="SEL. UNA OPCIÓN">SEL. UNA OPCIÓN</option>
                                <option selected="selected" value="2023">2023</option>
                                <option value="2024">2024</option>
                                <option value="2025">2025</option>

                            </select>--%>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 pe-0 col-4 col-sm-4 col-md-1 col-lg-1 col-xl-2 col-xxl-3">
                            <span id="ctl00_cpmaster_Label21">Mes :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-4 col-lg-4 col-xl-4 col-xxl-3">
                            <dx:BootstrapComboBox ID="pc_mes" runat="server" ValueType="System.String" NullText="Seleccione una opción">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-11" ListBox="fs-10" Control="fs-10" />
                                <ValidationSettings>
                                    <RequiredField IsRequired="true" ErrorText="Debe Seleccionar un Mes" />
                                </ValidationSettings>
                                <Items>
                                    <dx:BootstrapListEditItem Text="ENERO" Value="1"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="FEBRERO" Value="2"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="MARZO" Value="3"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="ABRIL" Value="4"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="MAYO" Value="5"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="JUNIO" Value="6"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="JULIO" Value="7"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="AGOSTO" Value="8"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="SEPTIEMBRE" Value="9"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="OCTUBRE" Value="10"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="NOVIEMBRE" Value="11"></dx:BootstrapListEditItem>
                                    <dx:BootstrapListEditItem Text="DICIEMBRE" Value="12"></dx:BootstrapListEditItem>
                                </Items>
                            </dx:BootstrapComboBox>
                            <%--   <select name="ctl00$cpmaster$pc_mes" id="ctl00_cpmaster_pc_mes" class="general" style="color: #0F5B96; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <option value="-1">SEL. UNA OPCIÓN</option>
                                <option selected="selected" value="1">ENERO</option>
                                <option value="2">FEBRERO</option>
                                <option value="3">MARZO</option>
                                <option value="4">ABRIL</option>
                                <option value="5">MAYO</option>
                                <option value="6">JUNIO</option>
                                <option value="7">JULIO</option>
                                <option value="8">AGOSTO</option>
                                <option value="9">SEPTIEMBRE</option>
                                <option value="10">OCTUBRE</option>
                                <option value="11">NOVIEMBRE</option>
                                <option value="12">DICIEMBRE</option>
 </select>--%>
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
