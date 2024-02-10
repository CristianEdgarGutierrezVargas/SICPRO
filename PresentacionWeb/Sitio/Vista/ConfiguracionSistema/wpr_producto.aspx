<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_producto.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wpr_producto" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dxA" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Registro de Productos</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <img src="../../../UI/img/img07.jpg" alt="" width="122" height="122">
            </div>
            <span class="border border-3 rounded w-75 pt-2 mb-2">
                <div class="col-10">
                    <div class="row p-2">
                        <div class="col-2">
                            Descripción:
                        </div>
                        <div class="col-6">
                            <asp:TextBox ID="desc_producto" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 280px;"></asp:TextBox>
                        </div>
                        <div class="col-2">
                            <asp:HiddenField ID="id_producto" runat="server" />
                            <dxA:ASPxButton ID="btnserprod" runat="server" Text="..." CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <ClientSideEvents Click="function(s, e) {
                                            popupBusquedaProducto.Show();
                                        }" />
                            </dxA:ASPxButton>
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Abrev:
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="abrev_prod" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px;"></asp:TextBox>
                        </div>
                        <div class="col-2">
                            <dxA:ASPxButton ID="btnguardar" runat="server" Text="Guardar" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnguardar_Click"></dxA:ASPxButton>
                        </div>
                        <div class="col-2">
                            <dxA:ASPxButton ID="btnbuscar" runat="server" Text="Buscar" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <ClientSideEvents Click="function(s, e) {
                                            popupBusquedaProducto.Show();
                                        }" />
                            </dxA:ASPxButton>
                        </div>
                    </div>
                    <div class="row p-2">
                        <p class="links">
                            <asp:Label ID="lblmensajeA" runat="server" Text="" class="error"></asp:Label>
                        </p>
                    </div>

                    <asp:Panel ID="pnlControles" runat="server" Visible="false">
                        <div class="row p-2">
                            <div class="col-2">
                                Riesgo :
                            </div>
                            <div class="col-4">
                                <asp:DropDownList ID="id_riesgo" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row p-2">
                            <div class="col-2">
                                Compañia :
                            </div>
                            <div class="col-4">
                                <asp:DropDownList ID="id_spvs" runat="server"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row p-2">
                            <div class="col-2">
                                Formula :
                            </div>
                            <div class="col-4">
                                <asp:DropDownList ID="operador" runat="server">
                                    <asp:ListItem Text="!--" Value="!--"></asp:ListItem>
                                    <asp:ListItem Text="*" Value="*"></asp:ListItem>
                                    <asp:ListItem Text="/" Value="/"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-4">
                                <asp:TextBox ID="evaluar" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 280px;"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row p-2">
                            <div class="col-2">
                                Comisión :
                            </div>
                            <div class="col-2">
                                <asp:TextBox ID="comis_riesgo" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 280px;"></asp:TextBox>
                            </div>
                            <div class="col-2">
                                Por. a Crédito :
                            </div>
                            <div class="col-2">
                                <asp:TextBox ID="por_cred" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 280px;"></asp:TextBox>
                            </div>
                            <div class="col-2">
                                Plus Neta :
                            </div>
                            <div class="col-2">
                                <asp:TextBox ID="plus_neta" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 280px;"></asp:TextBox>
                            </div>
                        </div>
                    </asp:Panel>

                </div>
            </span>
        </div>
    </div>

    <dxA:ASPxPopupControl ID="popupBusquedaProducto" runat="server" Modal="true" HeaderText="Busqueda de Productos por Compañia" ShowFooter="true" PopupElementID="body" ClientInstanceName="popupBusquedaProducto"
        CloseAction="OuterMouseClick" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="500px">
        <HeaderStyle BackgroundImage-ImageUrl="../../../UI/img/msg_title_1.jpg" ForeColor="White" Font-Bold="true" />
        <FooterStyle HorizontalAlign="Right" />
        <ContentCollection>
            <dxA:PopupControlContentControl runat="server">
                <div class="row">
                    <div class="col-3">
                        <img src="../../../UI/img/search_user.png" width="48" height="48">
                        <dxA:ASPxTextBox ID="nomraz1" ClientInstanceName="nomraz1" runat="server" AutoCompleteType="None" Size="12"></dxA:ASPxTextBox>
                        <dxA:ASPxButton ID="btnserprod_modal" runat="server" Text="Buscar" CssClass="msg_button_class" AutoPostBack="false">
                            <ClientSideEvents Click="function(s,e){
                                    pnlCallBackBuscaProducto.PerformCallback(nomraz1.GetValue());
                                    }
                                    " />
                        </dxA:ASPxButton>
                    </div>
                    <div class="col-9">
                        <dxA:ASPxCallbackPanel ID="pnlCallBackBuscaProducto" ClientInstanceName="pnlCallBackBuscaProducto" runat="server" Width="200px" SettingsLoadingPanel-Delay="2000" EnableCallbackAnimation="true" OnCallback="pnlCallBackBuscaProducto_Callback">
                            <PanelCollection>
                                <dxA:PanelContent runat="server">
                                    <dxA:ASPxGridView ID="grdListaProducto" runat="server" OnDataBinding="grdListaProducto_DataBinding" OnSelectionChanged="grdListaProducto_SelectionChanged" EnableCallBacks="false" KeyFieldName="id_producto"
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
                                            <dxA:GridViewDataColumn Caption="ID." FieldName="id_producto" Visible="false"></dxA:GridViewDataColumn>
                                            <dxA:GridViewDataColumn Caption="Lista de Productos" FieldName="desc_prod" Visible="true"></dxA:GridViewDataColumn>
                                        </Columns>
                                        <SettingsPager PageSize="10" NumericButtonCount="1" CurrentPageNumberFormat="{0}">
                                            <FirstPageButton Visible="true"></FirstPageButton>
                                            <LastPageButton Visible="true"></LastPageButton>
                                            <Summary Visible="false" />
                                        </SettingsPager>
                                        <SettingsBehavior ProcessSelectionChangedOnServer="true" AllowSelectByRowClick="true"></SettingsBehavior>
                                    </dxA:ASPxGridView>
                                </dxA:PanelContent>
                            </PanelCollection>
                        </dxA:ASPxCallbackPanel>
                    </div>
                </div>
            </dxA:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <button type="button" style="background-image: url(../../../UI/img/msg_title_1.jpg); background-size: contain; color: white; border: solid; padding: 2px" onclick="popupBusquedaProducto.Hide()">ACEPTAR</button>
        </FooterContentTemplate>
    </dxA:ASPxPopupControl>

    <dxA:ASPxPopupControl ID="popUpValidacion" runat="server" Modal="true" HeaderText="Validacion de datos" ShowFooter="true" PopupElementID="body" ClientInstanceName="popUpValidacion"
        CloseAction="OuterMouseClick" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="500px">
        <HeaderStyle BackgroundImage-ImageUrl="../../../UI/img/msg_button_2.jpg" ForeColor="White" />
        <FooterStyle HorizontalAlign="Right" />
        <ContentCollection>
            <dxA:PopupControlContentControl>
                <div class="row">
                    <div class="col-3">
                        <img src="../../../UI/img/msg_icon_2.png">
                    </div>
                    <div class="col-9">
                        <br>
                        Los siguientes valores deben ser verificados antes de proseguir<br />
                        <p style="color: #990000; font-weight: bold">
                            <dxA:ASPxLabel ID="lblerror" runat="server" Text=""></dxA:ASPxLabel>
                        </p>
                    </div>
                </div>
            </dxA:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <button type="button" style="background-image: url(../../../UI/img/msg_button_2.jpg); background-size: contain; color: white; border: solid; padding: 2px" onclick="popUpValidacion.Hide()">ACEPTAR</button>
        </FooterContentTemplate>
    </dxA:ASPxPopupControl>

    <dxA:ASPxPopupControl ID="popUpConfirmacion" runat="server" Modal="true" HeaderText="Confirmacion" ShowFooter="true" PopupElementID="body" ClientInstanceName="popUpConfirmacion"
        CloseAction="OuterMouseClick" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="500px">
        <HeaderStyle BackgroundImage-ImageUrl="../../../UI/img/msg_title_1" ForeColor="White" />
        <FooterStyle HorizontalAlign="Right" />
        <ContentCollection>
            <dxA:PopupControlContentControl>
                <div class="row">
                    <div class="col-3">
                        <img src="../../../UI/img/msg_icon_1.png">
                    </div>
                    <div class="col-9">
                        <br>
                        <p style="color: #0A416B; font-weight: bold">
                            <dxA:ASPxLabel ID="lblMensaje" runat="server" Text=""></dxA:ASPxLabel>
                        </p>
                    </div>
                </div>
            </dxA:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <button type="button" style="background-image: url(../../../UI/img/msg_title_1); background-size: contain; color: white; border: solid; padding: 2px" onclick="popUpConfirmacion.Hide()">ACEPTAR</button>
        </FooterContentTemplate>
    </dxA:ASPxPopupControl>


</asp:Content>
