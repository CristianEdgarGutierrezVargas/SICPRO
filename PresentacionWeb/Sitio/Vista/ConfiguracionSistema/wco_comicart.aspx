<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wco_comicart.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wco_comicart" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <!-- Inicio Contenido -->
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Registro de Comisiones por Cartera</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <img src="../../../UI/img/img07.jpg" alt="" width="122" height="122">
            </div>
            <div class="col-10">
                <div class="container">
                    <div class="row">
                        <div class="col-3">
                            <label>Cartera :</label>
                        </div>
                        <div class="col-9">
                            <asp:DropDownList ID="id_percart" runat="server" OnSelectedIndexChanged="id_percart_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            <label>Comision :</label>
                        </div>
                        <div class="col-9">
                            <dx:ASPxSpinEdit ID="porcentaje" runat="server" Number="0" DecimalPlaces="2" DisplayFormatString="##.##" NumberType="Float">
                                <SpinButtons ShowIncrementButtons="false" />
                            </dx:ASPxSpinEdit>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            <label>Facturacion :</label>
                        </div>
                        <div class="col-9">
                            <dx:ASPxCheckBox ID="factura" runat="server"></dx:ASPxCheckBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4">
                        </div>
                        <div class="col-4">
                            <dx:ASPxButton ID="btn_guardar" runat="server" Text="Guardar" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnguardar_Click"></dx:ASPxButton>
                            <dx:ASPxButton ID="btn_modificar" runat="server" Text="Modificar" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btn_modificar_Click"></dx:ASPxButton>
                            <dx:ASPxButton ID="btn_borrar" runat="server" Text="Nuevo" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btn_borrar_Click"></dx:ASPxButton>
                        </div>
                        <div class="col-4">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <p class="links">
                                <a class="error">
                                    <dx:ASPxLabel ID="lblmensajeCarga" runat="server" Text=""></dx:ASPxLabel>
                                    <%--<span id="cpmaster_lblmensaje" class="error"></span>--%>
                                </a>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Fin Contenido -->
    <dx:ASPxPopupControl ID="popUpConfirmacion" runat="server" Modal="true" HeaderText="" ShowFooter="true" PopupElementID="body" ClientInstanceName="popUpConfirmacion"
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
