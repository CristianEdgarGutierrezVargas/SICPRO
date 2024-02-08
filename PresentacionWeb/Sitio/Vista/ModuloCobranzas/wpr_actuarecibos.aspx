<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_actuarecibos.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ModuloCobranzas.wpr_actuarecibos" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <script>
        function OnEndCallbackPersona(s, e) {

            pCPersona.Hide();

        }
        function UpdateDetailGrid(s, e) {
            var index = e.visibleIndex;

            CallBPersona.PerformCallback(index);
        }
    </script>
    <div class="container p-2">
        <div class="card p-3">
            <div class="row">
                <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-2">
                    <img src="../../../UI/img/img07.jgp" alt="" class="img-fluid">
                </div>
                <div class="col-12 col-sm-12 col-md-9 col-lg-9 col-xl-10">

                    <div class="row">
                        <div class="col-12">
                            <h1 class="title">Actualización de Recibos</h1>
                        </div>
                    </div>
                    <%--  <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                            <span id="Label17">Nº Liquidación:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-8 col-lg-7 col-xl-7">
                            <asp:Label runat="server" ID="id_liq"></asp:Label>

                        </div>
                    </div>--%>

                    <div class="row mt-1">
                        <div class="col-4 col-sm-4 col-md-4 col-lg-2 col-xl-2">
                            <span id="Label10">Sucursal:</span>
                        </div>
                        <div class="col-8 col-sm-8 col-md-4 col-lg-4 col-xl-4">
                            <dx:BootstrapComboBox ID="id_suc" runat="server" ValueType="System.String" NullText="Seleccione una opcion..." AutoPostBack="true" OnSelectedIndexChanged="id_suc_SelectedIndexChanged">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" />
                                <ValidationSettings ValidationGroup="Guarda">
                                    <RequiredField ErrorText="Seleccione una opcion" IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>
                        </div>
                    </div>

                    <div class="row mt-1">
                        <div class="mt-1 mt-sm-1 mt-md-0 col-4 col-sm-4 col-md-4 col-lg-2 col-xl-2">
                            <span id="Label16">Cobrador:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-0 col-8 col-sm-8 col-md-3 col-lg-3 col-xl-4">
                            <dx:BootstrapComboBox ID="id_perucb" runat="server" ValueType="System.String" NullText="Seleccione una opcion..." DropDownStyle="DropDownList" AutoPostBack="true" OnSelectedIndexChanged="id_perucb_SelectedIndexChanged">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" />
                                <ValidationSettings ValidationGroup="Guarda">
                                </ValidationSettings>
                            </dx:BootstrapComboBox>

                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-2 col-xl-2 col-xxl-2">
                            <span id="Label5">Año :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-4 col-xl-4 col-xxl-4">
                            <dx:BootstrapComboBox ID="año" runat="server" ValueType="System.String" DropDownStyle="DropDownList" AutoPostBack="true" OnSelectedIndexChanged="año_SelectedIndexChanged" NullText="Seleccione una opción">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" Control="fs-10" />
                                <ValidationSettings ValidationGroup="Guarda">
                                    <RequiredField IsRequired="true" ErrorText="Dato requerido" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>

                        </div>
                    </div>
                    <div class="row mt-1">
                        <div class="col-4 col-sm-4 col-md-4 col-lg-2 col-xl-2">
                            <span id="Label100">Nº Recibo:</span>
                        </div>
                        <div class="col-8 col-sm-8 col-md-4 col-lg-4 col-xl-4">
                            <dx:BootstrapComboBox ID="id_recibo" runat="server" ValueType="System.String" NullText="Seleccione una opcion..." >
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" />
                                <ValidationSettings ValidationGroup="Guarda">
                                    <RequiredField ErrorText="Seleccione una opcion" IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-0 col-4 col-sm-4 col-md-4 col-lg-2 col-xl-2">
                            <span id="Label180">Monto Poliza :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-9 col-xl-4">
                            <dx:BootstrapSpinEdit ID="monto_cobro" runat="server" NullText="0.00" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                <SpinButtons ShowLargeIncrementButtons="true" />
                                <CssClasses Button="btn-sm" Control="fs-10" Input="form-control-sm fs-10" />
                                <ValidationSettings ValidationGroup="Guarda">
                                    <RequiredField IsRequired="true" ErrorText="Debe Registrar un Monto" />
                                </ValidationSettings>
                            </dx:BootstrapSpinEdit>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-2 col-xl-2 col-xxl-2">
                            <span id="Label233">Divisa :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-3 col-xl-4 col-xxl-4">
                            <dx:BootstrapComboBox ID="id_div" runat="server" ValueType="System.String" NullText="Seleccione una opcion">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" Control="fs-10" />
                                <ValidationSettings ValidationGroup="Guarda">
                                    <RequiredField IsRequired="true" ErrorText="Dato requerido" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>
                        </div>

                    </div>
                    <div class="row mt-1">
                        <div class="mt-1 mt-sm-1 mt-md-0 col-4 col-sm-4 col-md-4 col-lg-2 col-xl-2">
                            <span id="Label1">Efectivo Bs:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-9 col-xl-4">
                            <dx:BootstrapSpinEdit ID="cont_bs" runat="server" NullText="0.00" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                <SpinButtons ShowLargeIncrementButtons="true" />
                                <CssClasses Button="btn-sm" Control="fs-10" Input="form-control-sm fs-10" />
                                <ValidationSettings ValidationGroup="Guarda">
                                    <RequiredField IsRequired="true" ErrorText="Debe Registrar un Monto" />
                                </ValidationSettings>
                            </dx:BootstrapSpinEdit>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-2 col-xl-2 col-xxl-2">
                            <span id="ctl00_cpmaster_Label23">Efectivo $us:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-3 col-xl-4 col-xxl-4">
                            <dx:BootstrapSpinEdit ID="cont_sus" runat="server" NullText="0.00" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                <SpinButtons ShowLargeIncrementButtons="true" />
                                <CssClasses Button="btn-sm" Control="fs-10" Input="form-control-sm fs-10" />
                                <ValidationSettings ValidationGroup="Guarda">
                                    <RequiredField IsRequired="true" ErrorText="Debe Registrar un Monto" />
                                </ValidationSettings>
                            </dx:BootstrapSpinEdit>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-0 col-4 col-sm-4 col-md-4 col-lg-2 col-xl-2">
                            <span id="Label01">Cheque Bs:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-9 col-xl-4">
                            <dx:BootstrapSpinEdit ID="cheq_bs" runat="server" NullText="0.00" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                <SpinButtons ShowLargeIncrementButtons="true" />
                                <CssClasses Button="btn-sm" Control="fs-10" Input="form-control-sm fs-10" />
                                <ValidationSettings ValidationGroup="Guarda">
                                    <RequiredField IsRequired="true" ErrorText="Debe Registrar un Monto" />
                                </ValidationSettings>
                            </dx:BootstrapSpinEdit>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-2 col-xl-2 col-xxl-2">
                            <span id="Label023">Cheque $us:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-9 col-lg-3 col-xl-4 col-xxl-4">
                            <dx:BootstrapSpinEdit ID="cheq_sus" runat="server" NullText="0.00" MinValue="0" MaxValue="10000000000" Increment="0.1" LargeIncrement="1" NumberType="Float">
                                <SpinButtons ShowLargeIncrementButtons="true" />
                                <CssClasses Button="btn-sm" Control="fs-10" Input="form-control-sm fs-10" />
                                <ValidationSettings ValidationGroup="Guarda">
                                    <RequiredField IsRequired="true" ErrorText="Debe Registrar un Monto" />
                                </ValidationSettings>
                            </dx:BootstrapSpinEdit>
                        </div>
                    </div>
                    <div class="row mt-1">
                        <div class="col-2">
                            <asp:Label runat="server" ID="lblasegurado" Text="Cliente o Grupo:" CssClass="fs-10"></asp:Label>
                        </div>
                        <div class="col-8 col-sm-8 col-md-8 col-lg-8 col-xl-8 col-xxl-8">
                            <div class="d-flex">
                                <div class="flex-grow-1">
                                    <dx:BootstrapCallbackPanel ID="CallBPersona" ClientInstanceName="CallBPersona" runat="server" OnCallback="CallBPersona_Callback">
                                        <ClientSideEvents EndCallback="OnEndCallbackPersona"></ClientSideEvents>
                                        <ContentCollection>
                                            <dx:ContentControl>
                                                <dx:BootstrapTextBox runat="server" ID="nomraz" NullText="">
                                                    <CssClasses Input="form-control-sm fs-10" />
                                                </dx:BootstrapTextBox>
                                                <asp:HiddenField runat="server" ID="id_per" Value="" />
                                            </dx:ContentControl>
                                        </ContentCollection>
                                    </dx:BootstrapCallbackPanel>
                                </div>
                                <dx:BootstrapButton ID="btnserper" runat="server" AutoPostBack="false" Text="..." OnClick="btnserper_Click">
                                    <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                    <SettingsBootstrap RenderOption="None" />
                                </dx:BootstrapButton>
                            </div>

                        </div>
                    </div>
                    <div class="row mt-1">
                        <div class=" col-4 col-sm-4 col-md-4 col-lg-2 col-xl-2">
                            <span id="Label18">Fecha Cobro:</span>
                        </div>
                        <div class=" col-8 col-sm-8 col-md-8 col-lg-4 col-xl-4">
                            <dx:BootstrapDateEdit PickerDisplayMode="Auto" Enabled="false"  ID="fecha_cobro" runat="server" CalendarProperties-CssClasses-Button="btn-sm" >
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" Calendar="fs-10" />
                                <TimeSectionProperties Visible="true" />
                                <CalendarProperties HighlightToday="false" ShowTodayButton="false" ShowClearButton="false" />
                            </dx:BootstrapDateEdit>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-3 col-lg-3 col-xl-2 col-xxl-3">
                            <span id="Label23">Recibo aplicado a:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-4 col-lg-4 col-xl-4 col-xxl-3">
                            <dx:BootstrapComboBox ID="id_apli" runat="server" ValueType="System.String" NullText="Seleccione una opcion">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" Control="fs-10" />
                                <ValidationSettings ValidationGroup="Guarda">
                                    <RequiredField IsRequired="true" ErrorText="Dato requerido" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>
                        </div>
                    </div>

                    <div class="row mt-1">
                        <div class="col-md-2">
                            <span id="lblmat_aseg">Recibo por:</span>
                        </div>
                        <div class="col-md-8">
                            <dx:BootstrapMemo ID="recibo_por" runat="server" Rows="3" Width="100%"></dx:BootstrapMemo>
                        </div>
                    </div>

                    <div class="row mt-2">
                        <div class="col-12">
                            <dx:BootstrapButton runat="server" ID="btnguardar" Text="Guardar" ValidationGroup="Guarda" OnClick="btnguardar_Click">

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

                        <dx:BootstrapGridView ID="grdPersonas" EnableCallBacks="true" runat="server" KeyFieldName="id_per" ClientInstanceName="grdPersonas" OnDataBinding="grdPersonas_DataBinding">
                            <Settings ShowColumnHeaders="false" ShowTitlePanel="true" />
                            <SettingsText Title="Lista de Personas" />
                            <SettingsBehavior AllowFocusedRow="True" AllowClientEventsOnLoad="False" AllowSelectByRowClick="true" />
                            <ClientSideEvents RowClick="UpdateDetailGrid" />
                            <SettingsBootstrap Striped="true" />
                            <CssClasses PanelHeading="msg_button_class p-1 fs-10 " />
                            <SettingsPager NumericButtonCount="3">
                                <PageSizeItemSettings Visible="false" Items="10, 20, 50" />
                            </SettingsPager>
                            <Columns>
                                <dx:BootstrapGridViewDataColumn FieldName="nomraz" Width="200px" CssClasses-DataCell="fs-11"></dx:BootstrapGridViewDataColumn>

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
