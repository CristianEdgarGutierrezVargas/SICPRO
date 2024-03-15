<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_productom.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wpr_productom" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Modificación de Productos</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <img src="../../../UI/img/img07.jpg" alt="" width="122" height="122">
            </div>
            <span class="border border-3 rounded w-75 pt-2 mb-2">
                <div class="col-10">
                    <div class="row p-0">
                        <div class="col-2">
                            Compañia:
                        </div>
                        <div class="col-8">
                            <asp:DropDownList ID="id_spvs" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" AutoPostBack="true" OnSelectedIndexChanged="id_spvs_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row p-0">
                        <div class="col-2">
                            Producto:
                        </div>
                        <div class="col-8">
                            <asp:DropDownList ID="id_producto" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" AutoPostBack="true" OnSelectedIndexChanged="id_producto_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:HiddenField ID="operar" runat="server" />
                        </div>
                    </div>
                    <div class="row p-0">
                        <div class="col-2">
                            Riesgo:
                        </div>
                        <div class="col-8">
                            <asp:DropDownList ID="id_riesgo" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row p-2 align-items-center">
                        <div class="col-2">
                            Fórmula:
                        </div>
                        <div class="col-1">
                             <label class="fw-bold" style="text-align: right;">PT</label>
                        </div>
                        <div class="col-2">
                            <asp:DropDownList ID="opera" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; width: 60px;">
                                <asp:ListItem Value="!--" Text="!--"></asp:ListItem>
                                <asp:ListItem Value="false" Text="*"></asp:ListItem>
                                <asp:ListItem Value="true" Text="/"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-2">
                            <asp:TextBox ID="evaluar" runat="server" CssClass="form-control fs-10">0,00</asp:TextBox>
                        </div>
                        <div class="col-4"></div>
                    </div>
                    <div class="row p-1 align-items-center">
                        <div class="col-2">
                            Comisión:
                        </div>
                        <div class="col-2">
                            <asp:TextBox ID="comis_riesgo" runat="server" CssClass="form-control fs-10">0,00</asp:TextBox>
                        </div>
                        <div class="col-2">
                            Por. a Crédito :
                        </div>
                        <div class="col-2">
                            <asp:TextBox ID="por_cred" runat="server" CssClass="form-control fs-10">0,00</asp:TextBox>
                        </div>
                        <div class="col-2">
                            Plus Neta :
                        </div>
                        <div class="col-2">
                            <asp:TextBox ID="plus_neta" runat="server" CssClass="form-control fs-10">0,00</asp:TextBox>
                        </div>
                    </div>
                    <div class="row p-0 align-items-center">
                        <div class="col-3">
                            Form. Contado :
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="form_riesgo1" runat="server" CssClass="form-control fs-10">0,00</asp:TextBox>
                            <asp:HiddenField ID="Hform_riesgo1" runat="server" />
                        </div>
                        <div class="col-2">
                            <dx:ASPxButton ID="ib1" runat="server" Image-Url="~/UI/img/lc_checkbox.png" alt="" width="24px" height="24px" OnClick="ib1_Click"></dx:ASPxButton>
                        </div>
                        <div class="col-3">
                        </div>
                    </div>
                    <div class="row p-0 align-items-center">
                        <div class="col-3">
                            Form. Contado :
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="form_riesgo2" runat="server" CssClass="form-control fs-10">0,00</asp:TextBox>
                            <asp:HiddenField ID="Hform_riesgo2" runat="server" />
                        </div>
                        <div class="col-2">
                            <dx:ASPxButton ID="ib2" runat="server" Image-Url="~/UI/img/lc_checkbox.png" alt="" width="24px" height="24px" OnClick="ib2_Click"></dx:ASPxButton>
                        </div>
                        <div class="col-3">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                        </div>
                        <div class="col-2">
                            <dx:ASPxButton ID="btnnuevo" runat="server" Text="Nuevo" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnnuevo_Click"></dx:ASPxButton>
                        </div>
                        <div class="col-2">
                            <dx:ASPxButton ID="btnguardar" runat="server" Text="Guardar" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnguardar_Click"></dx:ASPxButton>
                        </div>
                        <div class="col-2">
                            <dx:ASPxButton ID="btnsalir" runat="server" Text="Salir" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnsalir_Click"></dx:ASPxButton>
                        </div>
                        <div class="col-2">
                        </div>

                    </div>
                    <div class="row p-2">
                        <div class="col-12">
                            <p style="color: #990000; font-weight: bold">
                            <dx:ASPxLabel ID="lblmensajeGuardar" runat="server" Text=""></dx:ASPxLabel>
                        </p>
                        </div>
                    </div>
                </div>
            </span>
        </div>
    </div>
    <dx:ASPxPopupControl ID="popUpValidacion" runat="server" Modal="true" HeaderText="Error de Datos" ShowFooter="true" PopupElementID="body" ClientInstanceName="popUpValidacion"
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
                        Los siguientes valores deben ser verificados antes de proseguir<br />
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
                            <dx:ASPxLabel ID="lblMensajePop" runat="server" Text=""></dx:ASPxLabel>
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
