<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wre_caso.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ModuloReclamos.wre_caso" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Registro de Denuncias Casos de Reclamos</h1>
            </div>
        </div>
        <div class="row">
            <div class="col-2">
                <img src="../../../UI/img/caso.png" alt="" width="122" height="122">
            </div>
            <span class="border border-3 rounded w-75 pt-2">
                <div class="col-10">
                    <div class="row p-2">
                        <div class="col-2">
                            Sucursal:
                        </div>
                        <div class="col-7">
                            <asp:DropDownList ID="id_suc" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <asp:ListItem Value="-1" Text="SEL. UNA OPCIÓN"></asp:ListItem>
                                <asp:ListItem Value="98" Text="COCHABAMBA"></asp:ListItem>
                                <asp:ListItem Value="54" Text="SANTA CRUZ"></asp:ListItem>
                                <asp:ListItem Value="95" Text="SUCRE"></asp:ListItem>
                                <asp:ListItem Value="53" Text="CENTRAL LA PAZ"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Año de Atención:
                        </div>
                        <div class="col-7">

                            <asp:DropDownList ID="anio_caso" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <asp:ListItem Value="-1" Text="SEL. UNA OPCIÓN"></asp:ListItem>
                                <asp:ListItem Value="2023" Text="2023"></asp:ListItem>
                                <asp:ListItem Value="2024" Text="2024"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Número de Reclamo:
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="id_caso" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 25px; width: 300px;">Por asignarse...</asp:TextBox>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Cliente:
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="nomraz" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 25px; width: 300px;"></asp:TextBox>
                        </div>
                        <div class="col-2">
                            <asp:HiddenField ID="id_per" runat="server" />
                            <dx:ASPxButton ID="btnserper" runat="server" Text="..." CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <ClientSideEvents Click="function(s, e) {
                                                            popupBusquedaPersona.Show();
                                                        }" />
                            </dx:ASPxButton>
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Nº de póliza:
                        </div>
                        <div class="col-7">

                            <asp:DropDownList ID="id_poliza" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <asp:ListItem Value="-1" Text="SEL. UNA OPCIÓN"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div class="col-2">
                            <asp:ImageButton runat="server" ImageUrl="~/UI/img/refresh.png" CommandName="UPDATE" BorderStyle="Groove" CssClass="rounded-3" BorderColor="#999999" />
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Producto:
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="desc_prod" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 25px; width: 300px;"></asp:TextBox>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Compañía:
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="nomraz2" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 25px; width: 300px;"></asp:TextBox>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Ejecutivo Previcor:
                        </div>
                        <div class="col-7">

                            <asp:DropDownList ID="id_perurc" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <asp:ListItem Value="-1" Text="SEL. UNA OPCIÓN"></asp:ListItem>
                                <asp:ListItem Value="4336060" Text="CHAVEZ MORALES OSCAR IVAN"></asp:ListItem>

                            </asp:DropDownList>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Inspector Compañía:
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="per_cia" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 25px; width: 300px;"></asp:TextBox>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Atención:
                        </div>
                        <div class="col-7">

                            <asp:DropDownList ID="id_rolate" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <asp:ListItem Value="-1" Text="SEL. UNA OPCIÓN"></asp:ListItem>
                                <asp:ListItem Value="89" Text="AJUSTADOR"></asp:ListItem>
                                <asp:ListItem Value="90" Text="IMPORTADOR"></asp:ListItem>
                                <asp:ListItem Value="91" Text="AUDITORIA"></asp:ListItem>
                                <asp:ListItem Value="62" Text="CLINICA, LABORATORIO O MEDICO TRATANTE"></asp:ListItem>
                                <asp:ListItem Value="61" Text="TALLLER MECANICO"></asp:ListItem>

                            </asp:DropDownList>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Siniestro Atendido por:
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="per_aten" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 25px; width: 300px;"></asp:TextBox>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Siniestro atendido en:
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="direccion" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 25px; width: 300px;"></asp:TextBox>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Tipo de Identificador Único:
                        </div>
                        <div class="col-7">

                            <asp:DropDownList ID="id_uniobj" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <asp:ListItem Value="-1" Text="SEL. UNA OPCIÓN"></asp:ListItem>
                                <asp:ListItem Value="64" Text="CARNET DE ASEGURADO"></asp:ListItem>
                                <asp:ListItem Value="72" Text="OTRO"></asp:ListItem>
                                <asp:ListItem Value="63" Text="PLACA DE VEHÍCULO"></asp:ListItem>

                            </asp:DropDownList>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Identificador Único :
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="uniobj" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 25px; width: 300px;"></asp:TextBox>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Descripción del Asegurado (obj/pers):
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="mat_aseg" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 50px; width: 300px;" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Fecha del Incidente:
                        </div>
                        <div class="col-7">
                            <dx:BootstrapDateEdit ID="fc_incidente" runat="server">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                            </dx:BootstrapDateEdit>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Fecha de Denuncia:
                        </div>
                        <div class="col-7">
                            <dx:BootstrapDateEdit ID="fc_denuncia" runat="server">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                            </dx:BootstrapDateEdit>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Circunstancias del Caso:
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="circunstancia" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 50px; width: 300px;" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Lugar del Incidente:
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="lugar_siniestro" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 50px; width: 300px;" TextMode="MultiLine"></asp:TextBox>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Denunciado por:
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="denunciante" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 25px; width: 300px;"></asp:TextBox>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Relación del Denunciante:
                        </div>
                        <div class="col-7">
                            <asp:TextBox ID="reladenun" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 25px; width: 300px;"></asp:TextBox>
                        </div>
                        <div class="col-2">
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                            Monto aproximado de reclamo:
                        </div>
                        <div class="col-4">
                            <asp:TextBox ID="aprox_caso" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 25px; width: 180px;">0.00</asp:TextBox>
                        </div>
                        <div class="col-2">
                            <asp:DropDownList ID="id_div" runat="server" class="form-select" Style="color: #0F5B96; text-align: left; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                <asp:ListItem Value="-1" Text="SEL. UNA OPCIÓN"></asp:ListItem>
                                <asp:ListItem Value="37" Text="BS"></asp:ListItem>
                                <asp:ListItem Value="39" Text="SUS"></asp:ListItem>
                                <asp:ListItem Value="38" Text="UFV"></asp:ListItem>
                                <asp:ListItem Value="40" Text="EU"></asp:ListItem>

                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row p-2">
                        <div class="col-2">
                        </div>
                        <div class="col-2">
                            
                        </div>
                        <div class="col-2">
                            <dx:ASPxButton ID="btnguardar" runat="server" Text="Guardar" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;"></dx:ASPxButton>
                        </div>
                        <div class="col-2">
                            <dx:ASPxButton ID="btnsalir" runat="server" Text="Salir" CssClass="btn btn-primary btn-sm" Style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;"></dx:ASPxButton>
                        </div>
                        <div class="col-2">
                        </div>

                    </div>
                </div>
            </span>
        </div>

        <p class="links">
            <asp:Label ID="cpmaster_lblmensaje" runat="server" Text="Introduzca Valores" CssClass="error"></asp:Label>
        </p>
    </div>

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
                        <dx:ASPxCallbackPanel ID="pnlCallBackBuscaPersona" ClientInstanceName="pnlCallBackBuscaPersona" runat="server" Width="200px" SettingsLoadingPanel-Delay="2000" EnableCallbackAnimation="true">
                            <PanelCollection>
                                <dx:PanelContent runat="server">
                                    <%--<dx:ASPxGridView ID="grdListaPersona" runat="server" OnDataBinding="grdListaPersona_DataBinding" OnSelectionChanged="grdListaPersona_SelectionChanged" EnableCallBacks="false" KeyFieldName="id_per"
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
                                            <dx:GridViewDataColumn Caption="ID." FieldName="id_per" Visible="false"></dx:GridViewDataColumn>
                                            <dx:GridViewDataColumn Caption="Lista de Personas" FieldName="nomraz" Visible="true"></dx:GridViewDataColumn>
                                        </Columns>
                                        <SettingsPager PageSize="10" NumericButtonCount="1" CurrentPageNumberFormat="{0}">
                                            <FirstPageButton Visible="true"></FirstPageButton>
                                            <LastPageButton Visible="true"></LastPageButton>
                                            <Summary Visible="false" />
                                        </SettingsPager>
                                        <SettingsBehavior ProcessSelectionChangedOnServer="true" AllowSelectByRowClick="true"></SettingsBehavior>
                                    </dx:ASPxGridView>--%>
                                </dx:PanelContent>
                            </PanelCollection>
                        </dx:ASPxCallbackPanel>
                    </div>
                </div>
            </dx:PopupControlContentControl>
        </ContentCollection>
        <FooterContentTemplate>
            <button type="button" style="background-image: url(../../../UI/img/msg_title_1.jpg); background-size: contain; color: white; border: solid; padding: 2px" onclick="popupBusquedaPersona.Hide()">ACEPTAR</button>
        </FooterContentTemplate>
    </dx:ASPxPopupControl>
</asp:Content>
