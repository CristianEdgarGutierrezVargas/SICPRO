<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wre_cierrecaso.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ModuloReclamos.wre_cierrecaso" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Cierre de Casos</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <img src="../../../UI/img/poliza.gif" alt="" width="122" height="122">
            </div>
            <div class="col-10">
                <div class="container">
                    <div class="row">
                        <div class="col-3">
                            Nº de Caso / Año:
                        </div>
                        <div class="col-2">
                            <dx:ASPxTextBox ID="id_caso" runat="server" CssClass="w-100"></dx:ASPxTextBox>
                        </div>
                        <div class="col-1 w-auto">/</div>
                        <div class="col-4">
                            <asp:DropDownList ID="anio_caso" runat="server" CssClass="w-75"></asp:DropDownList>
                        </div>
                        <div class="col-2">
                            <asp:ImageButton runat="server" ImageUrl="~/UI/img/view.png" CommandName="UPDATE" BorderStyle="Groove" CssClass="rounded-3" BorderColor="#999999" ID="btnser" OnClick="btnser_Click" />
                        </div>
                        <asp:HiddenField ID="id_sucur" runat="server" />
                        <asp:HiddenField ID="id_per" ClientIDMode="Static" runat="server" />
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Cliente:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="nomraz" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Poliza:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="num_poliza" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Producto :
                        </div>
                        <div class="col-7">
                            <asp:Label ID="desc_prod" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Compañía :
                        </div>
                        <div class="col-7">
                            <asp:Label ID="nomraz2" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Objeto Asegurado:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="mat_aseg" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Identificador Unico:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="uni_obj" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Fecha de Denuncia:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="fc_denuncia" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Circunstancias:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="circunstancia" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Monto Aproximado:
                        </div>
                        <div class="col-3">
                            <asp:Label ID="monto_aprox1" runat="server" Text="0.00"></asp:Label>
                            <asp:Label ID="divisa" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-1">
                            
                        </div>
                        <div class="col-3">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Ultimo Estado:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="desc_param" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Fecha de Registro:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="fc_iniestado" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Observaciones:
                        </div>
                        <div class="col-7">
                            <asp:Label ID="obs_histcaso1" runat="server" Text="-"></asp:Label>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Nuevo Estado:
                        </div>
                        <div class="col-7">
                            <asp:DropDownList ID="id_estca" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Observaciones:
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="obs_histcaso" runat="server" CssClass="w-100" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Nº de Recibo:
                        </div>
                        <div class="col-3">
                            <dx:ASPxTextBox ID="recibo" runat="server" CssClass="w-100"></dx:ASPxTextBox>
                        </div>
                        <div class="col-2">
                            <asp:HiddenField ID="anio_recibo" runat="server" />
                            <dx:ASPxButton ID="btnrec" runat="server" Text="..." CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnrec_Click">
                               <%-- <ClientSideEvents Click="function(s, e) {
                                        pnlCallBackBuscaRecibo.PerformCallback(document.getElementById('id_per').value);
                                        popupBusquedaRecibo.Show();
                                    }" />--%>
                            </dx:ASPxButton>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Co Aseguro / Franquicia:
                        </div>
                        <div class="col-4">
                            <%--<asp:TextBox ID="coafran" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 25px; width: 180px;">0.00</asp:TextBox>--%>
                            <dx:ASPxSpinEdit ID="coafran" runat="server" Number="0" DecimalPlaces="2" DisplayFormatString="##.##" NumberType="Float">
                                        <SpinButtons ShowIncrementButtons="false" />
                            </dx:ASPxSpinEdit>
                        </div>
                        <div class="col-2">
                            <asp:Label ID="divisa2" runat="server" Text="-"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Monto Pagado:
                        </div>
                        <div class="col-4">
                            <%--<asp:TextBox ID="pago_caso" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 25px; width: 180px;">0.00</asp:TextBox>--%>
                            <dx:ASPxSpinEdit ID="pago_caso" runat="server" Number="0" DecimalPlaces="2" DisplayFormatString="##.##" NumberType="Float">
                                        <SpinButtons ShowIncrementButtons="false" />
                            </dx:ASPxSpinEdit>
                        </div>
                        <div class="col-2">
                            <asp:Label ID="divisa1" runat="server" Text="-"></asp:Label>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            Monto Indemnizado:
                        </div>
                        <div class="col-4">
                            <%--<asp:TextBox ID="indem" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 25px; width: 180px;">0.00</asp:TextBox>--%>
                            <dx:ASPxSpinEdit ID="indem" runat="server" Number="0" DecimalPlaces="2" DisplayFormatString="##.##" NumberType="Float">
                                        <SpinButtons ShowIncrementButtons="false" />
                            </dx:ASPxSpinEdit>
                        </div>
                        <div class="col-2">
                            <asp:Label ID="divisa3" runat="server" Text="-"></asp:Label>
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-1">
                        </div>
                         <div class="col-2">
                            <dx:ASPxButton ID="btnguardar" runat="server" Text="Guardar" CssClass="btn btn-primary btn-sm"  OnClick="btnguardar_Click" Visible="false"></dx:ASPxButton>
                        </div>
                        <div class="col-2">
                            <dx:ASPxButton ID="btncalcular" runat="server" Text="Calcular" CssClass="btn btn-primary btn-sm"  OnClick="btncalcular_Click"></dx:ASPxButton>
                        </div>
                       
                        <div class="col-2">
                            <dx:ASPxButton ID="btnnuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary btn-sm" OnClick="btnnuevo_Click"></dx:ASPxButton>
                        </div>
                        <div class="col-2">
                            <dx:ASPxButton ID="btnsalir" runat="server" Text="Salir" CssClass="btn btn-primary btn-sm"  OnClick="btnsalir_Click"></dx:ASPxButton>
                        </div>
                        

                    </div>
                </div>
            </div>
        </div>
        <p class="links">
            <asp:Label ID="lblmensaje" runat="server" Text="Introduzca Valores" CssClass="error"></asp:Label>
        </p>
    </div>
    <dx:ASPxPopupControl ID="popUpValidacion" runat="server" Modal="true" HeaderText="Reclamo No encontrado" ShowFooter="true" PopupElementID="body" ClientInstanceName="popUpValidacion"
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

    <dx:ASPxPopupControl ID="popupBusquedaRecibo" runat="server" Modal="true" HeaderText="Busqueda de Montos de Recibos o Compensación" ShowFooter="true" PopupElementID="body" ClientInstanceName="popupBusquedaRecibo"
        CloseAction="OuterMouseClick" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="500px">
        <HeaderStyle BackgroundImage-ImageUrl="../../../UI/img/msg_title_1.jpg" ForeColor="White" />
        <FooterStyle HorizontalAlign="Right" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div class="row">
                    <div class="col-3">
                        <img src="../../../UI/img/search_user.png" width="48" height="48">
                    </div>
                    <div class="col-9">
                        <dx:ASPxCallbackPanel ID="pnlCallBackBuscaRecibo" ClientInstanceName="pnlCallBackBuscaRecibo" runat="server" Width="200px" SettingsLoadingPanel-Delay="2000" EnableCallbackAnimation="true">
                            <PanelCollection>
                                <dx:PanelContent runat="server">
                                    <dx:ASPxGridView ID="grdListaRecibo" runat="server"  OnSelectionChanged="grdListaRecibo_SelectionChanged" EnableCallBacks="false" KeyFieldName="id_recibo"
                                    Style="width: 340px; border-collapse: collapse;"
                                    Font-Size="11px"
                                    Font-Names="Arial, Helvetica, sans-serif"
                                    Styles-Header-BackgroundImage-ImageUrl="~/UI/img/blue/captionbckg.gif"
                                    Styles-Header-ForeColor="#15428b"
                                    Styles-Header-Paddings-Padding="1"
                                    Styles-Header-HorizontalAlign="Left"
                                    Styles-Header-Font-Bold="true"
                                    Styles-Cell-Paddings-Padding="0"
                                    Styles-Cell-ForeColor="#15428b">
                                    <Columns>
                                        <dx:GridViewDataColumn Caption="N° de Recibo" FieldName="id_recibo" Visible="true"></dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="Monto Resto" FieldName="monto_resto" Visible="true"></dx:GridViewDataColumn>
                                        <dx:GridViewDataColumn Caption="Año Recibo" FieldName="anio_recibo" Visible="true"></dx:GridViewDataColumn>
                                    </Columns>
                                    <SettingsPager PageSize="25" NumericButtonCount="1" CurrentPageNumberFormat="{0}">
                                        <FirstPageButton Visible="true"></FirstPageButton>
                                        <LastPageButton Visible="true"></LastPageButton>
                                        <Summary Visible="false" />
                                    </SettingsPager>
                                    <SettingsBehavior ProcessSelectionChangedOnServer="true" AllowSelectByRowClick="true"></SettingsBehavior>
                                </dx:ASPxGridView>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxCallbackPanel>
                    </div>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <button type="button" style="background-image: url(../../../UI/img/msg_title_1.jpg); background-size: contain; color: white; border: solid; padding: 2px" onclick="popupBusquedaRecibo.Hide()">ACEPTAR</button>
        </FooterContentTemplate>
    </dx:ASPxPopupControl>
    <dx:ASPxPopupControl ID="popUpConfirmacion" runat="server" Modal="true" HeaderText="Datos Almacenados" ShowFooter="true" PopupElementID="body" ClientInstanceName="popUpConfirmacion"
        CloseAction="None" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="500px" ShowCloseButton="false">
        <HeaderStyle BackgroundImage-ImageUrl="../../../UI/img/msg_title_1.jpg" ForeColor="White" />
        <FooterStyle HorizontalAlign="Right" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div class="row">
                    <div class="col-3">
                        <img src="../../../UI/img/msg_icon_1.png">
                    </div>
                    <div class="col-9">
                        <br>
                        <p style="color: #0A416B; font-weight: bold">
                            <dx:ASPxLabel ID="lblmensajepopup" runat="server" Text="Se han registrado correctamente"></dx:ASPxLabel>
                        </p>
                    </div>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <button type="button" style="background-image: url(../../../UI/img/msg_title_1.jpg); background-size: contain; color: white; border: solid; padding: 2px" onclick="popUpConfirmacion.Hide();location.href = '../Default.aspx';">ACEPTAR</button>
        </FooterContentTemplate>
    </dx:ASPxPopupControl>
</asp:Content>
