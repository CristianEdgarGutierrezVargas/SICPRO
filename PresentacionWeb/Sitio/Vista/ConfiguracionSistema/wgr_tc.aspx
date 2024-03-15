<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_tc.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wgr_tc" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Tasa de Cambio</h1>
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
                            <label>Fecha :</label>
                        </div>
                        <div class="col-4">
                            <dx:BootstrapDateEdit ID="fecha" runat="server">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                            </dx:BootstrapDateEdit>
                        </div>
                        <div class="col-2">
                            <label>Tasa de Cambio :</label>
                        </div>
                        <div class="col-4">
                            <div class="form-floating mb-3">
                                <dx:ASPxSpinEdit ID="tcambio"  runat="server" Number="0" DecimalPlaces="2" DisplayFormatString="##.##" NumberType="Float" >
                                    <SpinButtons ShowIncrementButtons="false" />
                                </dx:ASPxSpinEdit>
                            </div>
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            <label>Divisa :</label>
                        </div>
                        <div class="col-7">
                            <asp:DropDownList ID="id_div" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <asp:ListItem Value="-1" Text="SEL. UNA OPCIÓN"></asp:ListItem>
                                <asp:ListItem Value="38" Text="UNIDAD FOMENTO A LA VIVIENDA"></asp:ListItem>
                                <asp:ListItem Value="40" Text="EUROS"></asp:ListItem>
                                <asp:ListItem Value="39" Text="DOLARES AMERICANOS"></asp:ListItem>
                                <asp:ListItem Value="37" Text="BOLVIAMOS"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-2">
                        </div>
                        <div class="col-4">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-4">
                        </div>
                        <div class="col-4">
                            <dx:ASPxButton ID="btnguardar" runat="server" Text="Guardar" CssClass="btn btn-primary" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" OnClick="btnguardar_Click"></dx:ASPxButton>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>

                </div>
            </span>
        </div>
        <div class="row">
            <div class="col-3"></div>
            <div class="col-9">
                <dx:ASPxGridView ID="gridtcambio" runat="server" Settings-ShowTitlePanel="true" SettingsText-Title="Lista de Tasa de Cambio"
                    class="table table-hover"
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
                        <dx:GridViewDataColumn Caption="Fecha" FieldName="fecha"></dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Tasa" FieldName="tasa"></dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Divisa" FieldName="divisa"></dx:GridViewDataColumn>

                    </Columns>
                    <SettingsPager PageSize="10" CurrentPageNumberFormat="{0}">
                        <FirstPageButton Visible="true"></FirstPageButton>
                        <LastPageButton Visible="true"></LastPageButton>
                        <Summary Visible="false" />
                    </SettingsPager>
                </dx:ASPxGridView>
            </div>
        </div>
    </div>

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
