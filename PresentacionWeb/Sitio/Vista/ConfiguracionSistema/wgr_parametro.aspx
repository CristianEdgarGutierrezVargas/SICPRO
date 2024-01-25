<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_parametro.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wgr_parametro" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <!-- Inicio Contenido -->
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Registro de Parámetros</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <img src="../../../UI/img/img07.jpg" alt="" width="122" height="122">
            </div>
            <div class="col-10">
                <div class="row p-1">
                    <div class="col-2">
                        <label>Columna :</label>
                    </div>
                    <div class="col-4">
                        <asp:TextBox ID="columna" runat="server" CssClass="w-50"></asp:TextBox>
                    </div>
                </div>
                <div class="row p-1">
                    <div class="col-2">
                        <label>Descripción :</label>
                    </div>
                    <div class="col-5">
                        <asp:TextBox ID="desc_param" runat="server" CssClass="w-75"></asp:TextBox>
                        <asp:HiddenField ID="id_para" runat="server" />
                    </div>
                </div>
                <div class="row p-1">
                    <div class="col-2">
                        <label>Abreviación :</label>
                    </div>
                    <div class="col-4">
                        <asp:TextBox ID="abrev_param" runat="server" CssClass="w-50"></asp:TextBox>
                    </div>
                </div>
                <div class="row p-1">
                    <div class="col-2">
                        <label>Valor :</label>
                    </div>
                    <div class="col-4">
                        <asp:TextBox ID="valor_param" runat="server" CssClass="w-50"></asp:TextBox>
                    </div>
                </div>

                <div class="row p-2">
                    <div class="col-3">
                    </div>
                    <div class="col-4">
                        <dx:ASPxButton ID="btnnuevo" runat="server" Text="Nuevo" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnnuevo_Click"></dx:ASPxButton>
                        <dx:ASPxButton ID="btnguardar" runat="server" Text="Guardar" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnguardar_Click"></dx:ASPxButton>
                        <dx:ASPxButton ID="btnmodificar" runat="server" Text="Guardar" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnmodificar_Click"></dx:ASPxButton>
                        <dx:ASPxButton ID="btneliminar" runat="server" Text="Eliminar" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btneliminar_Click"></dx:ASPxButton>
                    </div>
                    <div class="col-5">
                    </div>
                </div>
                <div class="row p-0">
                    <div class="col-2">
                        <label>Seleccionar Columna :</label>
                    </div>
                    <div class="col-4">
                        <asp:DropDownList ID="icolumna" runat="server" CssClass="w-50" OnSelectedIndexChanged="icolumna_SelectedIndexChanged" AutoPostBack="true">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-12">
                        <dx:ASPxLabel ID="lblmensaje" runat="server" Text="" CssClass="error"></dx:ASPxLabel>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-2"></div>
            <div class="col-10">
                <dx:ASPxGridView ID="grdparametro" runat="server" Settings-ShowTitlePanel="true" SettingsText-Title="Lista de Parámetros" OnDataBinding="grdparametro_DataBinding" Visible="false"
                    Style="width: 450px; border-collapse: collapse;"
                    Font-Size="11px"
                    Font-Names="Arial, Helvetica, sans-serif"
                    Styles-Header-BackgroundImage-ImageUrl="~/UI/img/blue/captionbckg.gif"
                    Styles-Header-ForeColor="#15428b"
                    Styles-Header-Paddings-Padding="1"
                    Styles-Header-HorizontalAlign="Center"
                    Styles-TitlePanel-BackgroundImage-ImageUrl="~/UI/img/blue/captionbckg.gif"
                    Styles-TitlePanel-ForeColor="#15428b"
                    Styles-TitlePanel-Font-Bold="true"
                    Styles-TitlePanel-HorizontalAlign="Left"
                    Styles-TitlePanel-Paddings-Padding="1"
                    Styles-Cell-Paddings-Padding="0"
                    Styles-Cell-HorizontalAlign="Center">
                    <Columns>
                        <dx:GridViewDataColumn>
                            <DataItemTemplate>
                                <asp:ImageButton runat="server" ImageUrl="~/UI/img/front.png" CommandName="UPDATE" CommandArgument='<%# Eval("id_par") %>' OnClick="Unnamed_Click"/>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="ID." FieldName="id_par" Visible="true"></dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Descripción" FieldName="desc_param" Visible="true"></dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Abrev." FieldName="abrev_param" Visible="true"></dx:GridViewDataColumn>
                    </Columns>
                    <SettingsPager PageSize="5" CurrentPageNumberFormat="{0}">
                        <FirstPageButton Visible="true"></FirstPageButton>
                        <LastPageButton Visible="true"></LastPageButton>
                        <Summary Visible="false" />
                    </SettingsPager>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>
    <!-- Fin Contenido -->
    <dx:ASPxPopupControl ID="popUpValidacion" runat="server" Modal="true" HeaderText="Validacion de datos" ShowFooter="true" PopupElementID="body" ClientInstanceName="popUpValidacion"
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
