<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_cierreregistro.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wgr_cierreregistro" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <!-- Inicio Contenido -->
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Cierre de Registro</h1>
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
                            <label>Mes :</label>
                        </div>
                        <div class="col-3">
                            <asp:DropDownList ID="mes" runat="server" Style="color: #0F5B96; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <asp:ListItem Value="-1" Text="SEL. UNA OPCIÓN"></asp:ListItem>
                                <asp:ListItem Value="01" Text="ENERO"></asp:ListItem>
                                <asp:ListItem Value="02" Text="FEBRERO"></asp:ListItem>
                                <asp:ListItem Value="03" Text="MARZO"></asp:ListItem>
                                <asp:ListItem Value="04" Text="ABRIL"></asp:ListItem>
                                <asp:ListItem Value="05" Text="MAYO"></asp:ListItem>
                                <asp:ListItem Value="06" Text="JUNIO"></asp:ListItem>
                                <asp:ListItem Value="07" Text="JULIO"></asp:ListItem>
                                <asp:ListItem Value="08" Text="AGOSTO"></asp:ListItem>
                                <asp:ListItem Value="09" Text="SEPTIEMBRE"></asp:ListItem>
                                <asp:ListItem Value="10" Text="OCTUBRE"></asp:ListItem>
                                <asp:ListItem Value="11" Text="NOVIEMBRE"></asp:ListItem>
                                <asp:ListItem Value="12" Text="DICIEMBRE"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-3">
                            <label>Año :</label>
                        </div>
                        <div class="col-3">
                            <asp:DropDownList ID="anio" runat="server" Style="color: #0F5B96; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            <label>Ini. Registro :</label>
                        </div>
                        <div class="col-3">
                            <dx:BootstrapDateEdit ID="ini_reg" runat="server">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                            </dx:BootstrapDateEdit>
                        </div>
                        <div class="col-3">
                            <label>Fin. Registro :</label>
                        </div>
                        <div class="col-3">
                            <dx:BootstrapDateEdit ID="fin_reg" runat="server">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                            </dx:BootstrapDateEdit>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            <label>T.C. Cierre :</label>
                        </div>
                        <div class="col-9">
                             <dx:ASPxSpinEdit ID="porcentaje" runat="server" Number="0" DecimalPlaces="2" DisplayFormatString="##.##" NumberType="Float">
                                <SpinButtons ShowIncrementButtons="false" />
                            </dx:ASPxSpinEdit>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4">
                        </div>
                        <div class="col-4">
                            <dx:ASPxButton ID="btnguardar" runat="server" Text="Guardar" CssClass="msg_button_class" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;"></dx:ASPxButton>
                        </div>
                        <div class="col-4">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <div class="col-11">
                            <dx:ASPxGridView ID="gridcierre" runat="server" Settings-ShowTitlePanel="true" SettingsText-Title="Lista de Direcciones"
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
                                Styles-Cell-Paddings-Padding="0">
                                <Columns>
                                    <dx:GridViewDataColumn>
                                        <DataItemTemplate>
                                            <%--<asp:ImageButton runat="server" ImageUrl="~/UI/img/front.png" CommandName="UPDATE" CommandArgument='<%# Eval("id_per") %>'  />--%>
                                            <asp:ImageButton runat="server" ImageUrl="~/UI/img/front.png" CommandName="UPDATE" />
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Mes" FieldName="mes"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Ano" FieldName="anio"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Inicio Registro" FieldName="ini_reg"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Fin Registro" FieldName="fin_reg"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="T.C." FieldName="tcambio"></dx:GridViewDataColumn>

                                </Columns>
                                <SettingsPager PageSize="10" CurrentPageNumberFormat="{0}">
                                    <FirstPageButton Visible="true"></FirstPageButton>
                                    <LastPageButton Visible="true"></LastPageButton>
                                    <Summary Visible="false" />
                                </SettingsPager>
                            </dx:ASPxGridView>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-12">
                            <p class="links">
                                <a class="error">
                                    <span id="cpmaster_lblmensaje" class="error"></span></a>
                            </p>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Fin Contenido -->
    <dx:ASPxPopupControl ID="popupBusquedaPersona" runat="server" Modal="true" HeaderText="Busqueda de Persona por Nombre o Razón Social" ShowFooter="true" PopupElementID="body" ClientInstanceName="popupBusquedaPersona"
        CloseAction="OuterMouseClick" PopupAction="None" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" Width="500px">
        <HeaderStyle BackgroundImage-ImageUrl="../../../UI/img/msg_title_1.jpg" ForeColor="White" />
        <FooterStyle HorizontalAlign="Right" />
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <div class="row">
                    <div class="col-3">
                        <img src="../../../UI/img/search_user.png" width="48" height="48">
                        <dx:ASPxTextBox ID="nomraz1" ClientInstanceName="nomraz1" runat="server" AutoCompleteType="None" Size="12"></dx:ASPxTextBox>
                        <dx:ASPxButton ID="btnserper_modal" runat="server" Text="->" CssClass="msg_button_class" AutoPostBack="false">
                            <ClientSideEvents Click="function(s,e){
                                        pnlCallBackBuscaPersona.PerformCallback(nomraz1.GetValue());
                                        }
                                        " />
                        </dx:ASPxButton>
                    </div>
                    <div class="col-9">
                    </div>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <button type="button" style="background-image: url(../../../UI/img/msg_title_1.jpg); background-size: contain; color: white; border: solid; padding: 2px" onclick="popupBusquedaPersona.Hide()">ACEPTAR</button>
        </FooterContentTemplate>
    </dx:ASPxPopupControl>

    <dx:ASPxPopupControl ID="popUpValidacion" runat="server" Modal="true" HeaderText="" ShowFooter="true" PopupElementID="body" ClientInstanceName="popUpValidacion"
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
                        <%--<br>Debe Registrar una Fecha para apertura de Registro<br />--%>
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
