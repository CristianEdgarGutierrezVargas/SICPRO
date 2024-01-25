<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wpr_polizacomision.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ModuloComisiones.wpr_polizacomision" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">

    <script type="text/javascript">    
        function UpdateDetailGrid(s, e) {
            var index = e.visibleIndex;

            CallBPersona.PerformCallback(index);
        }
        function OnEndCallbackPersona(s, e) {

            pCPersona.Hide();

        }

        function UpdateDetailGridCompania(s, e) {
            var index = e.visibleIndex;

            CallBCompania.PerformCallback(index);
        }
        function OnEndCallbackCompania(s, e) {

            pCCompania.Hide();

        }
        function UpdateDetailGridProducto(s, e) {
            var index = e.visibleIndex;

            CallBProducto.PerformCallback(index);
        }
        function OnEndCallbackProducto(s, e) {

            pCProducto.Hide();

        }

        function UpdateDetailGridDireccion(s, e) {
            var index = e.visibleIndex;

            CallBDireccion.PerformCallback(index);
        }
        function OnEndCallbackDireccion(s, e) {

            pCDireccion.Hide();

        }
    </script>
    <div class="container">
        <div class="card p-3 ">
            <h1 class="fs-8 text-info fw-bold">
                <asp:Label runat="server" ID="titulo" Text=""></asp:Label>
            </h1>
            <asp:HiddenField runat="server" ID="id_clamov" Value="" />
            <asp:HiddenField runat="server" ID="id_poliza" Value="" />
            <asp:HiddenField runat="server" ID="id_mov" Value="" />
            <div class="row">
                <div class="col-12 col-sm-12 col-md-3 col-lg-3 col-xl-2">
                    <div class="entry">
                        <img src="../../../UI/img/poliza.gif" alt="" class="img-fluid">
                    </div>
                </div>
                <div class="col-12 col-sm-12 col-md-9 col-lg-9 col-xl-10">
                    <div class="row">
                        <div class="col-md-12">
                            <span id="ctl00_cpmaster_fechas" style="font-weight: bold;">Fechas</span>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-6 col-sm-6 col-md-3">
                            <span id="lblfecemis">Fecha de Emisión:</span>
                        </div>
                        <div class="col-6 col-sm-6 col-md-3">
                            <asp:Label ID="fc_emision" runat="server" Text="" />

                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-0 col-6 col-sm-6 col-md-3">
                            <span id="lblfc_recepcion">Fecha de Recepción:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-0 col-6 col-sm-6 col-md-3">
                            <asp:Label ID="fc_recepcion" runat="server" Text="" />
                        </div>
                    </div>
                    <%--<br />--%>
                    <div class="row mt-1">
                        <div class="col-6 col-sm-6 col-md-3">
                            <span id="lblfc_inivig">Inicio Vigencia:</span>
                        </div>
                        <div class="col-6 col-sm-6 col-md-3">
                            <asp:Label ID="fc_inivig" runat="server" Text="" />
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-0 col-6 col-sm-6 col-md-3">
                            <span id="ctl00_cpmaster_lblfc_finvig">Fin Vigencia:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-0 col-6 col-sm-6 col-md-3">
                            <asp:Label ID="fc_finvig" runat="server" Text="" />
                        </div>
                    </div>
                    <%--<br />--%>
                    <div class="row mt-1">
                        <div class="col-6 col-sm-6 col-md-3">
                            <span id="lblnumero">N° de Poliza:</span>
                        </div>
                        <div class="col-6 col-sm-6 col-md-3">
                            <asp:Label ID="num_poliza" runat="server" Text="" />
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-0 col-6 col-sm-6 col-md-3">
                            <span id="lblnumliquida">Nº Liquidación:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-0 col-6 col-sm-6 col-md-3">
                            <asp:Label ID="no_liquidacion" runat="server" Text="" />
                        </div>
                    </div>
                    <%--<br />--%>
                    <div class="row mt-1">
                        <div class="col-6 col-sm-6 col-md-3 col-lg-3 col-xl-3 col-xxl-3">
                            <span id="ctl00_cpmaster_Label1">Asegurado :</span>
                        </div>
                        <div class="col-6 col-sm-6 col-md-9 col-lg-9 col-xl-9 col-xxl-9">

                            <asp:Label runat="server" ID="nomraz" Text="" />
                            <asp:HiddenField runat="server" ID="id_per" Value="" />

                        </div>

                    </div>

                    <div class="row mt-1">
                        <div class="col-6 col-sm-6 col-md-3 col-lg-3 col-xl-3 col-xxl-3">
                            <span id="lbldireccion">Dirección :</span>
                        </div>
                        <div class="col-6 col-sm-6 col-md-9 col-lg-9 col-xl-9 col-xxl-9">

                            <asp:Label runat="server" ID="desc_direccion" Text="" />
                            <asp:HiddenField runat="server" ID="id_direccion" Value="" />

                        </div>
                    </div>
                    <%--<br />--%>
                    <div class="row mt-1">
                        <div class="col-6 col-sm-6 col-md-3 col-lg-3 col-xl-3 col-xxl-3">
                            <span id="ctl00_cpmaster_Label3">Grupo :</span>
                        </div>
                        <div class="col-6 col-sm-6 col-md-9 col-lg-9 col-xl-9 col-xxl-9">
                            <asp:Label ID="cmbGrupo" runat="server" Text=""/>
                        </div>
                    </div>
                    <%--<br />--%>
                    <div class="row mt-1">
                        <div class="col-6 col-sm-6 col-md-3 col-lg-3 col-xl-3 col-xxl-3">
                            <span id="ctl00_cpmaster_Label2">Cia Aseguradora :</span>
                        </div>
                        <div class="col-6 col-sm-6 col-md-9 col-lg-9 col-xl-9 col-xxl-9">
                            <asp:Label ID="id_spvs" runat="server" Text=""/>
                        </div>
                    </div>
                    <%--<br />--%>
                    <div class="row mt-1">
                        <div class="col-6 col-sm-6 col-md-3 col-lg-3 col-xl-3 col-xxl-3">
                            <span id="lblnombre">Producto :</span>
                        </div>
                        <div class="col-6 col-sm-6 col-md-9 col-lg-9 col-xl-9 col-xxl-9">
                            <asp:Label ID="id_producto" runat="server" Text=""/>
                        </div>
                    </div>
                    <%--<br />--%>
                    <%--    <div class="row mt-1">
                        <div class="col-6 col-sm-6 col-md-3 col-lg-3 col-xl-3 col-xxl-3">
                            <span id="ctl00_cpmaster_Label5">Tipo de Cartera :</span>
                        </div>
                        <div class="col-6 col-sm-6 col-md-9 col-lg-9 col-xl-9 col-xxl-9">
                            <dx:BootstrapComboBox ID="cmbTipoCartera" runat="server" ValueType="System.String" Width="100%">
                                <CssClasses Button="btn-sm" Input="form-control-sm fs-10" />
                                <ValidationSettings SetFocusOnError="True" ValidationGroup="form_wgr_poliza" ErrorDisplayMode="ImageWithText" CausesValidation="true">
                                    <RequiredField ErrorText="Dato requerido" IsRequired="true" />
                                </ValidationSettings>
                            </dx:BootstrapComboBox>
                        </div>
                    </div>--%>
                    <%--<br />--%>
                    <div class="row mt-1">
                        <div class="col-6 col-sm-6 col-md-3 col-lg-3 col-xl-3 col-xxl-3">
                            <span id="ctl00_cpmaster_lblejecutivo">Ejecutivo:</span>
                        </div>
                        <div class="col-6 col-sm-6 col-md-9 col-lg-9 col-xl-9 col-xxl-9">
                            <asp:Label ID="id_perejec" runat="server"  Text=""/>
                        </div>
                    </div>
                    <%--<br />--%>
                    <div class="row mt-1">
                        <div class="col-6 col-sm-6 col-md-3 col-lg-3 col-xl-3 col-xxl-3">
                            <span id="ctl00_cpmaster_lblagente">Agente Cartera:</span>
                        </div>
                        <div class="col-6 col-sm-6 col-md-9 col-lg-9 col-xl-9 col-xxl-9">
                            <asp:Label ID="id_percart" runat="server" Text="" />
                        </div>
                    </div>
                    <%--<br />--%>
                    <div class="row mt-1">
                        <div class="col-6 col-sm-6 col-md-3 col-lg-3 col-xl-3 col-xxl-3">
                            <span id="ctl00_cpmaster_Label4">Tipo Poliza:</span>
                        </div>
                        <div class="col-6 col-sm-6 col-md-9 col-lg-9 col-xl-9 col-xxl-9">
                            <asp:Label ID="clase_poliza" runat="server" Text="" />
                        </div>
                    </div>

                    <div class="row mt-1">
                        <div class="col-6 col-sm-6 col-md-3 col-lg-3 col-xl-3 col-xxl-3">
                            <span id="lblprima_bruta">Prima Total:</span>
                        </div>
                        <div class="col-6 col-sm-6 col-md-4 col-lg-4 col-xl-3 col-xxl-3">

                            <%--<input name="ctl00$cpmaster$prima_bruta" type="text" value="0,00" maxlength="15" id="ctl00_cpmaster_prima_bruta" onkeypress="return(currencyFormat(this,event));" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:75px;">--%>
                            <asp:Label ID="prima_bruta" runat="server"  Text="" />
                        </div>
                        <div class=" mt-1 mt-sm-1 mt-md-0 mt-lg-0 col-6 col-sm-6 col-md-2 col-lg-2 col-xl-1 col-xxl-1  ps-xl-0 pe-xl-0 ps-xxl-0 pe-xxl-0 ">
                            <span id="ctl00_cpmaster_lblnum_cuota">Nº Cuotas:</span>
                        </div>
                        <%--<input name="ctl00$cpmaster$num_cuota" type="text" maxlength="2" id="ctl00_cpmaster_num_cuota" onkeydown="return dFilter (event.keyCode, this, '##');" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color:#336699;font-family:Arial,Helvetica,sans-serif;font-size:11px;font-weight:bold;height:18px;width:25px;">--%>
                        <div class="mt-1 mt-sm-1 mt-md-0 mt-lg-0 col-6 col-sm-6 col-md-3 col-lg-3 col-xl-1 col-xxl-1  ps-xl-0 pe-xl-0 ps-xxl-0 pe-xxl-0">
                            <asp:Label ID="num_cuota" runat="server"  Text="" />

                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 mt-lg-1 mt-xl-0 col-6 col-sm-6 col-md-3 col-lg-3 col-xl-1 col-xxl-1  pe-lg-0  pe-xl-0  pe-xxl-0 ">
                            <span id="ctl00_cpmaster_lblid_div">Divisa:</span>
                        </div>
                        <div class="mt-1 mt-sm-1 mt-md-1 mt-lg-1 mt-xl-0 col-6 col-sm-6 col-md-9 col-lg-9 col-xl-3 col-xxl-3  ps-xl-0 ps-xxl-0">
                            <asp:Label ID="id_div" runat="server"  Text="" />

                        </div>
                    </div>


                    <div class="row mt-1">
                        <div class="col-6 col-sm-6 col-md-3 col-lg-3 col-xl-3 col-xxl-3">
                            <span id="lbltipo_cuota">Forma de Pago</span>
                        </div>
                        <div class="col-6 col-sm-6 col-md-9 col-lg-9 col-xl-9 col-xxl-9">
                            <asp:Label ID="tipo_cuota" runat="server"  Text=""/>
                        </div>
                    </div>
                    <%--<br />--%>
                    <div class="row mt-1">
                        <div class="col-6 col-sm-6 col-md-3 col-lg-3 col-xl-3 col-xxl-3">
                            <span id="lblmat_aseg">Mat. Asegurada:</span>
                        </div>
                        <div class="col-6 col-sm-6 col-md-9 col-lg-9 col-xl-9 col-xxl-9">
                            <asp:Label ID="mat_aseg" runat="server" Text="" />
                        </div>
                    </div>
                    <%--<br />--%>

                    <div class="row mt-1">
                        <div class="col-md-2">
                        </div>
                        <div class="col-md-8">
                            <div class="panel-group">
                                <div class="panel panel-default">
                                    <div class="panel-body">Cuotas de la Poliza</div>
                                </div>
                                <div class="panel panel-default">
                                    <div class="panel-body">

                                        <asp:GridView ID="grdCuotasPoliza" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
                                            <Columns>
                                                <asp:BoundField DataField="cuota" HeaderText="Cuota">
                                                    <ControlStyle Width="20px" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Fecha Pago">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("fecha_pago") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <dx:BootstrapDateEdit ID="dtFechaPago" ClientInstanceName="dtFechaPago" runat="server" Width="100%"
                                                            Date='<%# Bind("fecha_pago") %>' DateOnError="Null">
                                                            <ValidationSettings SetFocusOnError="True" ErrorDisplayMode="ImageWithText" EnableCustomValidation="true">
                                                                <%--ErrorDisplayMode="ImageWithTooltip"--%>
                                                                <RequiredField ErrorText="Campo requerido" IsRequired="true" />
                                                            </ValidationSettings>
                                                        </dx:BootstrapDateEdit>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="50px" />
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Cuota Total">
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("cuota_total") %>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                    <ItemTemplate>
                                                        <dx:BootstrapSpinEdit ID="txtCuotaTotal" Width="125px" runat="server" Number="0" MinValue="0" MaxValue="10000000000"
                                                            Increment="0.1" LargeIncrement="1" NumberType="Float" Text='<%# Bind("cuota_total") %>'>
                                                            <SpinButtons ShowLargeIncrementButtons="true" />
                                                        </dx:BootstrapSpinEdit>
                                                    </ItemTemplate>
                                                    <ControlStyle Width="50px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="White" ForeColor="#000066" />
                                            <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                            <RowStyle ForeColor="#000066" />
                                            <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                            <SortedAscendingHeaderStyle BackColor="#007DBB" />
                                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                            <SortedDescendingHeaderStyle BackColor="#00547E" />
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>



                        </div>
                    </div>

                    <div class="row mt-1">
                        <div class="col-md-4">
                        </div>
                        <div class="col-md-7">
                            <dx:ASPxButton ID="btnNuevo" runat="server" Text="Nuevo" CssClass="msg_button_class" OnClick="btnNuevo_Click"></dx:ASPxButton>
                        </div>
                    </div>

                </div>
            </div>
        </div>

        <p class="links">
            <asp:Label ID="lblmensaje" runat="server" Text="Introduzca Valores" CssClass="error"></asp:Label>
        </p>
    </div>


   







</asp:Content>
