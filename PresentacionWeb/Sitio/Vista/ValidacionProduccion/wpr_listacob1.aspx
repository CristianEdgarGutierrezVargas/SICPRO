<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_listacob1.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ValidacionProduccion.wpr_listacob1" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <div id="content" class="container">



        <script type="text/javascript" src="scripts/validaciones.js"></script>

        <script type="text/javascript" language="javascript" src="scripts/fieldScripts.js"></script>

        <script type="text/javascript">    
            function toggleDisplay(v) {
                var rowIndex = v
                var obj = document.getElementById(rowIndex);
                obj.style.display = obj.style.display != "none" ? "none" : "";
            }
            function mOvr(src, clrOver) {
                if (!src.contains(event.fromElement)) {
                    src.style.cursor = 'hand';
                    src.bgColor = clrOver;
                }
            }
            function mOut(src, clrIn) {
                if (!src.contains(event.toElement)) {
                    src.style.cursor = 'default';
                    src.bgColor = clrIn;
                }
            }
            function mClk1(a1, a2) {
                document.getElementById("ctl00_cpmaster_id_per").value = a1;
                document.getElementById("ctl00_cpmaster_nomraz").value = a2;
                document.getElementById("pagedimmer").style.visibility = "hidden";
                document.getElementById("msgbox").style.visibility = "hidden";
            }
            function mClk2(a1, a2) {
                document.getElementById("ctl00_cpmaster_id_producto").value = a1;
                document.getElementById("ctl00_cpmaster_desc_producto").value = a2;
                document.getElementById("pagedimmer").style.visibility = "hidden";
                document.getElementById("msgbox").style.visibility = "hidden";
            }
            function mClk(a1, a2) {
                document.getElementById("ctl00_cpmaster_id_spvs").value = a1;
                document.getElementById("ctl00_cpmaster_nomco").value = a2;
                document.getElementById("pagedimmer").style.visibility = "hidden";
                document.getElementById("msgbox").style.visibility = "hidden";
            }
            function AbrirPoliza(v, b, c) {
                if (document.aspnetForm.ctl00_cpmaster_id_clamov.value == '42') {
                    window.open('wpr_polizacobranza.aspx?var=' + v + '&val=' + b + '&ver=' + c, '_self', 'height=300, width=450, top=100, left= 100, status=no, toolbar=no, menubar=no,location=no, scrollbars = yes, resizable = yes');
                }
                else if (document.aspnetForm.ctl00_cpmaster_id_clamov.value == '43') {
                    window.open('wpr_polizacobranza.aspx?var=' + v + '&val=' + b + '&ver=' + c, '_self', 'height=300, width=450, top=100, left= 100, status=no, toolbar=no, menubar=no,location=no, scrollbars = yes, resizable = yes');
                }
                else if (document.aspnetForm.ctl00_cpmaster_id_clamov.value == '44') {
                    window.open('wpr_polizacobranzain.aspx?var=' + v + '&val=' + b + '&ver=' + c, '_self', 'height=300, width=450, top=100, left= 100, status=no, toolbar=no, menubar=no,location=no, scrollbars = yes, resizable = yes');
                }
            }
            function fpr() {
                __doPostBack("ctl00$cpmaster$btnserprod", "");
            }
            function fp() {
                __doPostBack("ctl00$cpmaster$btnbuscar", "");
            }
            function f() {
                __doPostBack("ctl00$cpmaster$btnserper", "");
            }
        </script>

        <script type="text/javascript">
            //<![CDATA[
            Sys.WebForms.PageRequestManager._initialize('ctl00$cpmaster$smcontrol', document.getElementById('aspnetForm'));
            Sys.WebForms.PageRequestManager.getInstance()._updateControls(['tctl00$cpmaster$panel'], [], [], 90);
            //]]>
        </script>

        <asp:Panel runat="server" ID="panel" CssClass="rounded">


            <div class="card p-3 bg-light rounded">
                <h6 class="text-info fw-bold fs-8">Listado de Polizas</h6>
                <div class="row">
                    <div class="col-5">
                        <div class="row">
                            <div class="col-4">
                                <asp:Label runat="server" ID="lblnumero" Text="N° de Poliza :" CssClass="fs-10"></asp:Label>
                            </div>
                            <div class="col-8">
                                <dx:BootstrapTextBox runat="server" ID="num_poliza" NullText="%">
                                    <CssClasses Input="form-control-sm fs-10" />
                                </dx:BootstrapTextBox>
                            </div>
                        </div>
                        <div class="row mt-1">
                            <div class="col-4">
                                <asp:Label runat="server" ID="lblasegurado" Text="Asegurado :" CssClass="fs-10"></asp:Label>
                            </div>
                            <div class="col-8">
                                <div class="d-flex flex-row">
                                    <dx:BootstrapTextBox runat="server" ID="nomraz" NullText="" Width="150px">
                                        <CssClasses Input="form-control-sm fs-10" />
                                    </dx:BootstrapTextBox>
                                    <dx:BootstrapButton ID="btnserper" runat="server" AutoPostBack="false" Text="...">
                                        <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                        <SettingsBootstrap RenderOption="None" />
                                    </dx:BootstrapButton>
                                </div>
                                <asp:HiddenField runat="server" ID="id_per" Value="" />
                                <asp:HiddenField runat="server" ID="a" Value="" />
                                <asp:HiddenField runat="server" ID="b" Value="" />
                                <asp:HiddenField runat="server" ID="ap" Value="" />
                                <asp:HiddenField runat="server" ID="bp" Value="" />
                            </div>
                        </div>
                        <div class="row mt-1">
                            <div class="col-4 pe-0">
                                <asp:Label runat="server" ID="lblcompania" Text="Cia Aseguradora:" CssClass="fs-10"></asp:Label>
                            </div>
                            <div class="col-8">
                                <div class="d-flex flex-row">
                                    <dx:BootstrapTextBox runat="server" ID="nomco" NullText="" Width="150px">
                                        <CssClasses Input="form-control-sm fs-10" />
                                    </dx:BootstrapTextBox>

                                    <dx:BootstrapButton ID="btnsercom" runat="server" AutoPostBack="false" Text="...">
                                        <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                        <SettingsBootstrap RenderOption="None" />
                                    </dx:BootstrapButton>
                                </div>
                                <asp:HiddenField runat="server" ID="id_spvs" Value="" />
                            </div>
                        </div>
                        <div class="row mt-1">
                            <div class="col-4">
                                <asp:Label runat="server" ID="lblproducto" Text="Producto :" CssClass="fs-10"></asp:Label>
                            </div>
                            <div class="col-8">
                                <div class="d-flex flex-row">
                                    <dx:BootstrapTextBox runat="server" ID="desc_producto" NullText="" Width="150px">
                                        <CssClasses Input="form-control-sm fs-10" />
                                    </dx:BootstrapTextBox>

                                    <dx:BootstrapButton ID="btnserprod" runat="server" AutoPostBack="false" Text="..." OnClick="btnserprod_Click">
                                        <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                        <SettingsBootstrap RenderOption="None" />
                                    </dx:BootstrapButton>
                                </div>
                                <asp:HiddenField runat="server" ID="id_producto" Value="" />
                            </div>
                        </div>
                        <div class="row mt-1 msg_button_class">
                            <div class="col-12 ">
                                <div class="d-flex flex-row-reverse ">
                                    <dx:BootstrapCheckBox ID="vigencia" runat="server"></dx:BootstrapCheckBox>
                                    <asp:Label runat="server" ID="chkLabel" Text="Por Vigencia" CssClass="fs-10 mt-1 me-1"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="row mt-1">
                            <div class="col-4">
                                <asp:Label runat="server" ID="lblfc_inivig" Text="Del" CssClass="fs-10"></asp:Label>

                            </div>
                            <div class="col-8">
                                <dx:BootstrapDateEdit ID="fc_inivig" runat="server">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                </dx:BootstrapDateEdit>
                            </div>
                        </div>
                        <div class="row mt-1">
                            <div class="col-4">
                                <asp:Label runat="server" ID="lblfc_finvig" Text="Al" CssClass="fs-10"></asp:Label>
                            </div>
                            <div class="col-8">
                                <dx:BootstrapDateEdit ID="fc_finvig" runat="server">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                </dx:BootstrapDateEdit>
                                <asp:HiddenField runat="server" ID="id_clamov" Value="" />
                            </div>
                        </div>
                        <div class="row mt-1 msg_button_class">
                            <div class="col-12 ">
                                <div class="d-flex flex-row-reverse ">
                                    <dx:BootstrapCheckBox ID="porvencer" runat="server"></dx:BootstrapCheckBox>
                                    <asp:Label runat="server" ID="Label1" Text="Por Vencer" CssClass="fs-10 mt-1 me-1"></asp:Label>
                                </div>
                            </div>

                        </div>
                        <div class="row mt-1">
                            <div class="col-4 pe-0">
                                <asp:Label runat="server" ID="lblcuotavencidas" Text="Polizas Vencidas:" CssClass="fs-10"></asp:Label>
                            </div>
                            <div class="col-8">
                                <dx:BootstrapDateEdit ID="fc_polizavencida" runat="server">
                                    <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                </dx:BootstrapDateEdit>
                            </div>
                        </div>
                        <div class="row mt-1">
                            <div class="col-12 text-center">
                                <dx:BootstrapButton ID="btnnuevo" runat="server" AutoPostBack="false" Text="Nuevo">
                                    <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                    <SettingsBootstrap RenderOption="None" />
                                </dx:BootstrapButton>
                                <dx:BootstrapButton ID="btnbuscar" runat="server" AutoPostBack="false" Text="Buscar">
                                    <CssClasses Control="ms-1 msg_button_class btn-sm fs-10" />
                                    <SettingsBootstrap RenderOption="None" />
                                </dx:BootstrapButton>
                            </div>
                        </div>
                    </div>
                    <div class="col-7">
                        <asp:Panel runat="server" ID="gridcontainer" Visible="false">
                            <dx:BootstrapGridView ID="gridpoliza" runat="server">
                                <Columns>
                                    <dx:BootstrapGridViewDateColumn Caption="Poliza" FieldName="">
                                    </dx:BootstrapGridViewDateColumn>
                                </Columns>
                            </dx:BootstrapGridView>
                        </asp:Panel>

                    </div>
                </div>


                <p class="links">
                    <asp:Label runat="server" ID="lblmensaje" Text="" CssClass="fs-10"></asp:Label>


                </p>
            </div>

        </asp:Panel>


    </div>
</asp:Content>
