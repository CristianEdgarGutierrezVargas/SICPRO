<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_factura.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ModuloCobranzas.wpr_factura" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container p-2">
        <div class="card p-3">
            <div class="row">
                <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-2">
                    <img src="../../../UI/img/img07.jpg" alt="" class="img-fluid">
                </div>
                <div class="col-12 col-sm-12 col-md-9 col-lg-9 col-xl-10">

                    <div class="row">
                        <div class="col-12">
                            <h1 class="title">Registro de Facturas</h1>
                        </div>
                    </div>
                    <div class="row">
                        <div class="mt-1 mt-sm-1 mt-md-1 col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                            <span id="Label17">Cia Aseguradora :</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 col-8 col-sm-8 col-md-8 col-lg-7 col-xl-7">
                            <dx:BootstrapComboBox ID="id_spvs" runat="server" ValueType="System.String" NullText="Seleccione una compañia..." AutoPostBack="true" OnSelectedIndexChanged="id_spvs_SelectedIndexChanged">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" />
                                <ValidationSettings ValidationGroup="Buscar">
                                    <RequiredField ErrorText="Debe Seleccionar una Compañia" IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>

                        </div>
                    </div>

                    <div class="row mt-1">
                        <div class="col-4 col-sm-4 col-md-4 col-lg-3 col-xl-3">
                            <span id="Label10">Factura:</span>
                        </div>
                        <div class="col-8 col-sm-8 col-md-4 col-lg-6 col-xl-6">
                            <dx:BootstrapComboBox ID="num_poliza1" runat="server" ValueType="System.String" NullText="Seleccione una opcion..." AutoPostBack="true" OnSelectedIndexChanged="num_poliza1_SelectedIndexChanged">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" ListBox="fs-10" />
                                <ValidationSettings ValidationGroup="Buscar">
                                    <RequiredField ErrorText="Seleccione un opcion" IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>
                        </div>
                    </div>

                    <div class="row mt-1">
                        <div class="mt-1 mt-sm-1 mt-md-0 col-11 col-sm-11 col-md-11 col-lg-11 col-xl-11">

                            <asp:Panel runat="server" ID="pnlGrid" Visible="false" CssClass="mt-2">
                                <dx:BootstrapGridView ID="grid_factura" ClientInstanceName="grid_factura" runat="server" KeyFieldName="id_pago" >
                                    <Settings ShowColumnHeaders="true" ShowTitlePanel="true" />
                                    <SettingsText Title="Cantidad de cuotas de la póliza" />
                                    <SettingsBehavior AllowFocusedRow="True" AllowClientEventsOnLoad="False" AllowSelectByRowClick="true" />
                                    <SettingsBootstrap Striped="true" />
                                    <CssClasses PanelHeading="msg_button_class p-1 fs-10 " HeaderRow="thTabla" />
                                    <SettingsPager NumericButtonCount="3">
                                        <PageSizeItemSettings Visible="false" Items="10, 20, 50" />
                                    </SettingsPager>
                                    <SettingsDetail ShowDetailRow="true" ShowDetailButtons="false" />

                                    <Columns>
                                        <dx:BootstrapGridViewDataColumn Caption="Id Pago" FieldName="id_pago" Width="20px">
                                        </dx:BootstrapGridViewDataColumn>
                                        <dx:BootstrapGridViewDataColumn Caption="Nº Cuota" FieldName="cuota" Width="30px">
                                        </dx:BootstrapGridViewDataColumn>
                                        <dx:BootstrapGridViewDataColumn Caption="Poliza" FieldName="num_poliza" Width="30px">
                                        </dx:BootstrapGridViewDataColumn>
                                        <dx:BootstrapGridViewDateColumn Name="Fecha" Caption="Fecha Factura" FieldName="fecha_factura" Width="20px">
                                            <DataItemTemplate>
                                                <dx:BootstrapDateEdit ID="fecha_factura" runat="server"  CalendarProperties-CssClasses-Button="btn-sm">
                                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                                </dx:BootstrapDateEdit>
                                            </DataItemTemplate>
                                        </dx:BootstrapGridViewDateColumn>
                                        <dx:BootstrapGridViewDataColumn Name="fac" Caption="Nro Factura" FieldName="factura" Width="40px">
                                            <DataItemTemplate>
                                                <dx:BootstrapTextBox ID="n_factura" runat="server" >
                                                    <CssClasses Input="form-control-sm fs-10" />
                                                </dx:BootstrapTextBox>
                                            </DataItemTemplate>
                                        </dx:BootstrapGridViewDataColumn>
                                        <dx:BootstrapGridViewDataColumn Caption="" Width="20px">
                                            <DataItemTemplate>
                                                <dx:BootstrapButton ID="img2" runat="server" Text="" OnClick="img2_Click" >
                                                    <CssClasses Icon="bi bi-floppy-fill text-primary" />
                                                    <SettingsBootstrap RenderOption="None" />
                                                </dx:BootstrapButton>
                                            </DataItemTemplate>
                                        </dx:BootstrapGridViewDataColumn>
                                    </Columns>
                                </dx:BootstrapGridView>
                            </asp:Panel>
                        </div>
                    </div>








                    <div class="row mt-2">
                        <div class="col-12">
                            <dx:BootstrapButton runat="server" ID="Nuevo" Text="Nuevo"  OnClick="Nuevo_Click" >
                                <SettingsBootstrap RenderOption="None" Sizing="Small" />
                                <CssClasses Control="msg_button_class" Text="fs-9" />
                            </dx:BootstrapButton>
                            <dx:BootstrapButton runat="server" ID="Salir" Text="Salir" OnClick="Salir_Click" >
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
