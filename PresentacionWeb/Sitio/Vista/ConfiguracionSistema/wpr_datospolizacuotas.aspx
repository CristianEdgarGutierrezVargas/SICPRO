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
                <div class="row">
                    Fechas
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
                        <asp:HiddenField ID="estado" runat="server" Value="PRODUCCION" />
                        <asp:HiddenField ID="id_poliza" runat="server" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-2"></div>
                    <div class="col-8">
                        <dx:ASPxGridView ID="gridcuotas" runat="server" EnableCallBacks="false"
                            Settings-ShowTitlePanel="true" SettingsText-Title="Cantidad de Cuotas de la Póliza"
                            Style="width: 100%; border-collapse: collapse;"
                            Font-Size="11px"
                            Font-Names="Arial, Helvetica, sans-serif"
                            Styles-Header-Font-Bold="true"
                            Styles-Header-BackgroundImage-ImageUrl="~/UI/img/blue/captionbckg.gif"
                            Styles-Header-ForeColor="#15428b"
                            Styles-Header-Paddings-Padding="1"
                            Styles-Header-HorizontalAlign="Left"
                            Styles-TitlePanel-BackgroundImage-ImageUrl="~/UI/img/blue/captionbckg.gif"
                            Styles-TitlePanel-ForeColor="#15428b"
                            Styles-TitlePanel-Font-Bold="false"
                            Styles-TitlePanel-HorizontalAlign="Left"
                            Styles-TitlePanel-Paddings-Padding="1"
                            Styles-TitlePanel-Font-Size="Small"
                            Styles-Cell-Paddings-Padding="0"
                            Styles-Cell-ForeColor="#15428b"
                            Styles-Cell-HorizontalAlign="Center"
                            OnDataBinding="gridcuotas_DataBinding">
                            <Columns>
                                <dx:GridViewDataColumn Caption="Nro Poliza" FieldName="num_poliza" Visible="true" VisibleIndex="0"></dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Nro Cuota" FieldName="cuota" Visible="true" VisibleIndex="1"></dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Fecha Pago" FieldName="fecha_pago" Visible="true" Width="25%" VisibleIndex="2">
                                    <DataItemTemplate>
                                        <dx:ASPxDateEdit ID="fecha" runat="server" Value='<%#Eval("fecha_pago") %>' DisplayFormatString="dd/MM/yyyy" EditFormatString="dd/MM/yyyy" Width="100px">
                                            <DropDownButton>
                                                <Image IconID="scheduling_calendar_16x16" Url="../../../UI/img/Calendar_scheduleHS.png"></Image>
                                            </DropDownButton>
                                        </dx:ASPxDateEdit>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Caption="Cuota Total" FieldName="cuota_total" Visible="true" Width="25%" VisibleIndex="3">
                                    <DataItemTemplate>
                                        <dx:ASPxTextBox ID="monto" runat="server" Width="50%" Value='<%#Eval("cuota_total") %>'></dx:ASPxTextBox>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                                <dx:GridViewDataColumn Visible="true" VisibleIndex="4">
                                    <DataItemTemplate>
                                        <dx:ASPxButton BackgroundImage-ImageUrl="../../../UI/img/lc_save.png" runat="server" ID="img1" OnClick="img1_Click"></dx:ASPxButton>
                                    </DataItemTemplate>
                                </dx:GridViewDataColumn>
                            </Columns>
                            <TotalSummary>
                                <dx:ASPxSummaryItem FieldName="cuota_total" SummaryType="Sum" />
                            </TotalSummary>
                            <Settings ShowFooter="True" ShowGroupFooter="VisibleIfExpanded"></Settings>
                        </dx:ASPxGridView>
                    </div>
                </div>
                <div class="row">
                    <div class="col-4"></div>
                    <div class="col-6">
                        <dx:ASPxButton ID="btnnuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnnuevo_Click"></dx:ASPxButton>
                        <dx:ASPxButton ID="btncuotas" runat="server" Text="Cuotas" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btncuotas_Click"></dx:ASPxButton>
                    </div>
                </div>
                <div class="row">
                    <div class="col-3">
                        <p style="color: #990000; font-weight: bold">
                            <dx:ASPxLabel ID="lblmensajePantalla" runat="server" Text=""></dx:ASPxLabel>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <dx:ASPxPopupControl ID="popUpValidacion" runat="server" Modal="true" HeaderText="Validación de Valores" ShowFooter="true" PopupElementID="body" ClientInstanceName="popUpValidacion"
        CloseAction="OuterMouseClick" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="500px">
        <HeaderStyle BackgroundImage-ImageUrl="../../../UI/img/msg_button_2.jpg" ForeColor="White" />
        <FooterStyle HorizontalAlign="Right" />
        <ContentCollection>
            <dx:PopupControlContentControl>
                <div class="row">
                    <div class="col-3">
                        <img src="../../../UI/img/msg_icon_2.png">
                    </div>
                    <div class="col-9">
                        <br>
                        <p style="color: #990000; font-weight: bold">
                            <dx:ASPxLabel ID="lblerror" runat="server" Text=""></dx:ASPxLabel>
                        </p>
                    </div>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <button type="button" style="background-image: url(../../../UI/img/msg_button_2.jpg); background-size: contain; color: white; border: solid; padding: 2px" onclick="popUpValidacion.Hide()">ACEPTAR</button>
        </FooterContentTemplate>
    </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="popUpConfirmacion" runat="server" Modal="true" HeaderText="Confirmacion" ShowFooter="true" PopupElementID="body" ClientInstanceName="popUpConfirmacion"
        CloseAction="OuterMouseClick" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="500px">
        <HeaderStyle BackgroundImage-ImageUrl="../../../UI/img/msg_title_1" ForeColor="White" />
        <FooterStyle HorizontalAlign="Right" />
        <ContentCollection>
            <dx:PopupControlContentControl>
                <div class="row">
                    <div class="col-3">
                        <img src="../../../UI/img/msg_icon_1.png">
                    </div>
                    <div class="col-9">
                        <br>
                        <p style="color: #0A416B; font-weight: bold">
                            <dx:ASPxLabel ID="lblMensaje" runat="server" Text=""></dx:ASPxLabel>
                        </p>
                    </div>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <button type="button" style="background-image: url(../../../UI/img/msg_title_1); background-size: contain; color: white; border: solid; padding: 2px" onclick="popUpConfirmacion.Hide()">ACEPTAR</button>
        </FooterContentTemplate>
    </dx:ASPxPopupControl>
</asp:Content>
