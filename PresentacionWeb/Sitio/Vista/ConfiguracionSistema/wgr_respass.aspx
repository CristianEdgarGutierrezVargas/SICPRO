<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_respass.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wgr_respass" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <!-- Inicio Contenido -->
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Reseteo de Password</h1>
            </div>
        </div>
        <div class="row align-items-center">
            <div class="col-2">
                <img src="../../../UI/img/img07.jpg" alt="" width="122" height="122">
            </div>
            <div class="col-10">
                <div class="row p-4">
                    <div class="col-2">
                        <label>Usuario :</label>
                    </div>
                    <div class="col-10">
                        <asp:DropDownList ID="id_per" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-5"></div>
                    <div class="col-2">
                        <asp:Button ID="btnguardar" runat="server" Text="Guardar" CssClass="msg_button_class" OnClick="btnguardar_Click" />
                    </div>
                    <div class="col-5"></div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <asp:Label ID="lblmensaje" runat="server" CssClass="error"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <dx:ASPxPopupControl ID="popUpConfirmacion" runat="server" Modal="true" HeaderText="Confirmacion" ShowFooter="true" PopupElementID="body" ClientInstanceName="popupBusquedaPersona"
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
                            <dx:ASPxLabel ID="lblmensajepopup" runat="server" Text="Cambio de Clave realizado con éxito"></dx:ASPxLabel>
                        </p>
                    </div>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <button type="button" style="background-image: url(../../../UI/img/msg_title_1.jpg); background-size: contain; color: white; border: solid; padding: 2px" onclick="popupBusquedaPersona.Hide();location.href = '../Default.aspx';">ACEPTAR</button>
        </FooterContentTemplate>
    </dx:ASPxPopupControl>
    <!-- Fin Contenido -->
</asp:Content>




