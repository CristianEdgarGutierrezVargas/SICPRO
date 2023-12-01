<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_passnuevo.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wgr_passnuevo" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <!-- Inicio Contenido -->
    <div class="container rounded-3 p-4" style="background-color: rgb(243, 243, 243);">
        <div class="row">
            <div class="col-12">
                <h1 class="title fw-bold">Registro de Nuevos Usuarios</h1>
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
                            <label>Loggin :</label>
                        </div>
                        <div class="col-9">
                            <asp:TextBox ID="TextBox1" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px;"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            <label>Rol de Sistema :</label>
                        </div>
                        <div class="col-9">
                            <asp:DropDownList ID="id_rol" runat="server" Style="color: #0F5B96; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-3">
                            <label>Usuario :</label>
                        </div>
                        <div class="col-9">
                            <asp:TextBox ID="nomraz" runat="server" Style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 200px;"></asp:TextBox>
                            <button type="button" name="btnserper" data-bs-toggle="modal" data-bs-target="#modal_btnserper" id="btnserper" class="msg_button_class" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">...</button>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-4">
                        </div>
                        <div class="col-4">
                            <input type="submit" name="ctl00$cpmaster$btnguardar" value="Guardar" id="cpmaster_btnguardar" class="msg_button_class" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                        </div>
                        <div class="col-4">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-1"></div>
                        <div class="col-11">
                            <dx:ASPxGridView ID="grdusuarios" runat="server" Settings-ShowTitlePanel="true" SettingsText-Title="Lista de Usuarios" OnDataBinding="grdusuarios_DataBinding" 
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
                                >
                                <Columns>
                                    <dx:GridViewDataColumn>
                                        <DataItemTemplate>
                                            <asp:ImageButton runat="server" ImageUrl="~/UI/img/front.png" />
                                        </DataItemTemplate>
                                    </dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="ID." FieldName="id_per"></dx:GridViewDataColumn>
                                    <dx:GridViewDataColumn Caption="Nombre" FieldName="nomraz"></dx:GridViewDataColumn>
                                </Columns>
                                <SettingsPager PageSize="5" CurrentPageNumberFormat="{0}">
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

    <!-- Modal class="modal fade"-->
    <div class="modal fade" id="modal_btnserper" tabindex="-1" aria-labelledby="Busca Persona" aria-hidden="true">
        <div class="modal-dialog modal-lg">
            <div class="modal-content border border-5 border-secondary rounded-0">
                <div class="modal-header" style="background-image: url(../../../UI/img/msg_title_1.jpg); background-size: contain">
                    <h6 class="modal-title" id="exampleModalLabel">Busqueda de Persona por Nombre o Razón Social</h6>
                    <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
                </div>
                <div class="modal-body" style="color: #0F5B96">
                    <div class="container">
                        <div class="row">
                            <div id="cpmaster_msgboxpanel">
                                <div style="position: fixed; height: 100%; width: 100%; top: 0px; left: 0px; background-color: rgb(0, 0, 0); opacity: 0.55; z-index: 50; visibility: hidden;" id="pagedimmer">&nbsp;</div>
                                <div style="position: fixed; background-color: rgb(136, 136, 136); border: 1px solid rgb(153, 153, 153); z-index: 50; left: 30%; right: 20%; top: 15%; width: 550px; visibility: hidden;" id="msgbox">
                                    <div style="margin: 5px; width: 300px">
                                        <table width="540" align="center" style="background-color: #FFFFFF; border: 1px solid #999999;">
                                            <tbody>
                                                <tr>
                                                    <td colspan="2" style="font-family: tahoma; font-size: 11px; font-weight: bold; padding-left: 5px; background-image: url(images/msg_title_1.jpg); color: #FFFFFF; height: 22px;">Busqueda de Persona por Nombre o Razón Social</td>
                                                </tr>
                                                <tr>
                                                    <td width="135" valign="top" style="text-align: center;">
                                                        <p>
                                                            <img src="./Registro de Nuevos Usuarios_files/search_user.png" width="48" height="48">
                                                        </p>
                                                        <p>
                                                            <label>
                                                                <input name="nomraz1" type="text" id="nomraz1" size="12" onkeyup="javascript:document.getElementById(&#39;ctl00_cpmaster_nomraz&#39;).value = this.value" autocomplete="off" onfocus="this.value = document.getElementById(&#39;ctl00_cpmaster_nomraz&#39;).value">
                                                                <input type="submit" name="ctl00$cpmaster$btnserper" value="-&gt;" id="ctl00_cpmaster_btnserper" class="msg_button_class" onclick="if (document.getElementById(&#39;nomraz1&#39;).value==&#39;&#39;) document.getElementById(&#39;ctl00_cpmaster_nomraz&#39;).value = &#39;&#39; ">
                                                            </label>
                                                        </p>
                                                    </td>
                                                    <td width="393" style="font-family: tahoma; font-size: 11px; padding-left: 5px;">
                                                        <div class="gridcontainer" style="width: 350px">
                                                            <table class="grid" width="350" align="center" cellpadding="0" cellspacing="0">
                                                                <caption>Lista de Personas</caption>
                                                                <tbody>
                                                                    <tr onmouseout="this.className = this.orignalclassName;" onmouseover="this.orignalclassName = this.className;this.className = &#39;altoverow&#39;;" onclick="mClk1(&#39;-5369550-&#39;,&#39;-ALFARO VALVERVE JOSE- E.A.&#39;);">
                                                                        <td><font color="#336699" style="font-weight: bold; size: 12px">-ALFARO VALVERVE JOSE- E.A.</font></td>
                                                                    </tr>
                                                                    <tr onmouseout="this.className = this.orignalclassName;" onmouseover="this.orignalclassName = this.className;this.className = &#39;altoverow&#39;;" onclick="mClk1(&#39;2556820&#39;,&#39; AZURDUY QUEREJAZU PABLO ERNESTO&#39;);">
                                                                        <td><font color="#336699" style="font-weight: bold; size: 12px">AZURDUY QUEREJAZU PABLO ERNESTO</font></td>
                                                                    </tr>
                                                                    <tr onmouseout="this.className = this.orignalclassName;" onmouseover="this.orignalclassName = this.className;this.className = &#39;altoverow&#39;;" onclick="mClk1(&#39;2549044&#39;,&#39; CONDORI SARZO  CLEMENTE&#39;);" class="">
                                                                        <td><font color="#336699" style="font-weight: bold; size: 12px">CONDORI SARZO  CLEMENTE</font></td>
                                                                    </tr>
                                                                    <tr onmouseout="this.className = this.orignalclassName;" onmouseover="this.orignalclassName = this.className;this.className = &#39;altoverow&#39;;" onclick="mClk1(&#39;6944800&#39;,&#39; DE LA TORRE GUZMAN RYAN&#39;);" class="">
                                                                        <td><font color="#336699" style="font-weight: bold; size: 12px">DE LA TORRE GUZMAN RYAN</font></td>
                                                                    </tr>
                                                                    <tr onmouseout="this.className = this.orignalclassName;" onmouseover="this.orignalclassName = this.className;this.className = &#39;altoverow&#39;;" onclick="mClk1(&#39;4591860019&#39;,&#39; E.G. TRI-CHACO&#39;);" class="">
                                                                        <td><font color="#336699" style="font-weight: bold; size: 12px">E.G. TRI-CHACO</font></td>
                                                                    </tr>
                                                                    <tr onmouseout="this.className = this.orignalclassName;" onmouseover="this.orignalclassName = this.className;this.className = &#39;altoverow&#39;;" onclick="mClk1(&#39;3142650014&#39;,&#39; ELIAS ARRAYA PABLO ENRIQUEZ&#39;);" class="">
                                                                        <td><font color="#336699" style="font-weight: bold; size: 12px">ELIAS ARRAYA PABLO ENRIQUEZ</font></td>
                                                                    </tr>
                                                                    <tr onmouseout="this.className = this.orignalclassName;" onmouseover="this.orignalclassName = this.className;this.className = &#39;altoverow&#39;;" onclick="mClk1(&#39;4546936&#39;,&#39; ERENE MONTERO MERCY&#39;);" class="">
                                                                        <td><font color="#336699" style="font-weight: bold; size: 12px">ERENE MONTERO MERCY</font></td>
                                                                    </tr>
                                                                    <tr onmouseout="this.className = this.orignalclassName;" onmouseover="this.orignalclassName = this.className;this.className = &#39;altoverow&#39;;" onclick="mClk1(&#39;1015627025&#39;,&#39; ITURRALDE SRL&#39;);" class="">
                                                                        <td><font color="#336699" style="font-weight: bold; size: 12px">ITURRALDE SRL</font></td>
                                                                    </tr>
                                                                    <tr onmouseout="this.className = this.orignalclassName;" onmouseover="this.orignalclassName = this.className;this.className = &#39;altoverow&#39;;" onclick="mClk1(&#39;4090322&#39;,&#39; MENDIOLA WILLMA&#39;);" class="">
                                                                        <td><font color="#336699" style="font-weight: bold; size: 12px">MENDIOLA WILLMA</font></td>
                                                                    </tr>
                                                                    <tr onmouseout="this.className = this.orignalclassName;" onmouseover="this.orignalclassName = this.className;this.className = &#39;altoverow&#39;;" onclick="mClk1(&#39;2379089&#39;,&#39; MONTES DE OCA ANTEZANA DIETER FREDDY&#39;);" class="">
                                                                        <td><font color="#336699" style="font-weight: bold; size: 12px">MONTES DE OCA ANTEZANA DIETER FREDDY</font></td>
                                                                    </tr>
                                                                </tbody>
                                                            </table>
                                                        </div>
                                                        <div class="gridcontainer" style="width: 350px">
                                                            <div style="width: 350px" class="pagerstyle">
                                                                <center>
                                                                    <a href="http://localhost:4700/wgr_passnuevo.aspx#">
                                                                        <input type="submit" class="pagfirst" value="" title="Primera Página Desactivado" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;"></a>&nbsp;&nbsp;<a href="http://localhost:4700/wgr_passnuevo.aspx#"><input type="submit" class="pagprev" value="" title="Anterior Página Desactivado" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;"></a>&nbsp;&nbsp;<a href="http://localhost:4700/wgr_passnuevo.aspx#" onclick="document.forms.aspnetForm.ctl00_cpmaster_a.value = 10; document.forms.aspnetForm.ctl00_cpmaster_b.value = 20;f(); "><input type="submit" value="" class="pagnext" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" title="Siguiente Página"></a>&nbsp;&nbsp;<a href="http://localhost:4700/wgr_passnuevo.aspx#" onclick="document.forms.aspnetForm.ctl00_cpmaster_a.value = 6760; document.forms.aspnetForm.ctl00_cpmaster_b.value = 6763;f(); "><input type="submit" value="" class="paglast" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;" title="Última Página"></a></center>
                                                            </div>
                                                        </div>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" style="border-top: 1px solid #CCCCCC; padding-top: 5px; text-align: right;">
                                                        <input type="button" value="ACEPTAR" class="msg_button_class" onclick="document.getElementById(&#39;pagedimmer&#39;).style.visibility = &#39;hidden&#39;; document.getElementById(&#39;msgbox&#39;).style.visibility = &#39;hidden&#39;;">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-md-12">

                                <%--  <dx:ASPxGridView ID="grdPersonas" KeyFieldName="id_per" runat="server" Width="100%"
                                    OnSearchPanelEditorCreate="Grid_SearchPanelEditorCreate"
                                    OnDataBinding="grdPersonas_DataBinding" OnRowCommand="gv_RowCommand" OnPageIndexChanged="grdPersonas_PageIndexChanged">
                                    <Columns>
                                        <dx:GridViewDataTextColumn FieldName="id_per" Caption="Opciones" VisibleIndex="0">
                                            <DataItemTemplate>
                                                <dx:ASPxButton ID="btn" runat="server" Text="Seleccionar"></dx:ASPxButton>
                                            </DataItemTemplate>
                                        </dx:GridViewDataTextColumn>
                                        <dx:GridViewDataTextColumn FieldName="nomraz" Caption="Nombre o Razon Social" />
                                    </Columns>
                                    <SettingsSearchPanel Visible="true" ColumnNames="nomraz" ShowApplyButton="True" ShowClearButton="True" />
                                    <SettingsPager Mode="ShowPager" PageSize="10" />
                                </dx:ASPxGridView>--%>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" style="background-image: url(../../../UI/img/msg_title_1.jpg); background-size: contain">ACEPTAR</button>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
