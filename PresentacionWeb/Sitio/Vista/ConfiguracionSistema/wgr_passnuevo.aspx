<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="wgr_passnuevo.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.ConfiguracionSistema.wgr_passnuevo" %>

<%@ Register Assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolderPrincipal" runat="server">
    <!-- Inicio Contenido -->
    <div id="content">
        <div class="post">
            <div>
                <div class="post">
                    <div id="cpmaster_panel">
                        <div id="cpmaster_msgboxpanel">
                            <script src="./Registro de Nuevos Usuarios_files/AC_RunActiveContent.js.descarga" type="text/javascript"></script>
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
                        <h1 class="title">Registro de Nuevos Usuarios</h1>
                        <div class="entry">
                            <img src="../../../UI/img/img07.jpg" alt="" width="122" height="122" class="left">
                            <div>
                                <table width="500" cellpadding="0" cellspacing="0">
                                    <tbody>
                                        <tr>
                                            <td style="height: 18px; width: 110px;">
                                                <span id="cpmaster_Label2">Loggin :</span>
                                            </td>
                                            <td style="height: 18px; width: 200px;">
                                                <input name="ctl00$cpmaster$login" type="text" id="cpmaster_login" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px;">
                                            </td>
                                            <td style="width: 98px; height: 18px">&nbsp;
                                            </td>
                                            <td style="width: 4px; height: 18px">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 18px; width: 110px;">
                                                <span id="cpmaster_Label4">Rol de Sistema :</span>
                                            </td>
                                            <td style="height: 18px; width: 200px;">
                                                <asp:DropDownList ID="id_rol" runat="server"></asp:DropDownList>
                                                <%--<select name="ctl00$cpmaster$id_rol" id="cpmaster_id_rol" style="color: #0F5B96; background-color: White; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                                </select>--%>
                                            </td>
                                            <td style="width: 98px; height: 18px">&nbsp;
                                            </td>
                                            <td style="width: 4px; height: 18px">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 18px; width: 110px;">
                                                <span id="cpmaster_lblusuario">Usuario :</span>
                                            </td>
                                            <td colspan="2" style="height: 18px;">
                                                <input type="hidden" name="ctl00$cpmaster$id_per" id="cpmaster_id_per">
                                                <input name="ctl00$cpmaster$nomraz" type="text" id="cpmaster_nomraz" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 200px;">
                                                <input type="submit" name="ctl00$cpmaster$btnserper" value="..." id="cpmaster_btnserper" class="msg_button_class" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                                <input type="hidden" name="ctl00$cpmaster$a" id="cpmaster_a" value="0">
                                                <input type="hidden" name="ctl00$cpmaster$b" id="cpmaster_b" value="10">
                                            </td>
                                            <td style="width: 4px; height: 18px">&nbsp;
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" style="height: 22px">
                                                <input type="submit" name="ctl00$cpmaster$btnguardar" value="Guardar" id="cpmaster_btnguardar" class="msg_button_class" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4" style="height: 22px">
                                                <div class="gridcontainer" style="width: 450px">
                                                    <div>
                                                        <dx:ASPxGridView ID="grdusuarios" runat="server" Settings-ShowTitlePanel="true" CssClasses-PanelHeading="TitlePanelStyle" SettingsText-Title="Lista de Usuarios"  OnDataBinding="grdusuarios_DataBinding">
                                                            
                                                            <Columns>
                                                                <dx:GridViewDataColumn>
                                                                    <DataItemTemplate>
                                                                        <asp:ImageButton runat="server" ImageUrl="~/UI/img/front.png" />
                                                                    </DataItemTemplate>
                                                                </dx:GridViewDataColumn>
                                                                <dx:GridViewDataColumn Caption="ID." FieldName="id_per"></dx:GridViewDataColumn>
                                                                <dx:GridViewDataColumn Caption="Nombre" FieldName="nomraz"></dx:GridViewDataColumn>
                                                            </Columns>
                                                            <SettingsPager PageSize="5"  CurrentPageNumberFormat="{0}">
                                                                <FirstPageButton Visible="true" ></FirstPageButton>
                                                                <LastPageButton Visible="true"></LastPageButton>
                                                                <Summary Visible="false" />
                                                            </SettingsPager>
                                                        </dx:ASPxGridView>

                                                        <%--<table class="grid" cellspacing="0" cellpadding="0" rules="all" border="1" id="cpmaster_grdusuarios" style="width: 450px; border-collapse: collapse;">
                                                            <caption>
                                                                Lista de Usuarioss
		
                                                            </caption>
                                                            <tbody>
                                                                <tr>
                                                                    <th align="center" scope="col">&nbsp;</th>
                                                                    <th align="center" scope="col">ID.</th>
                                                                    <th align="center" scope="col">Nombre</th>
                                                                </tr>
                                                                <tr onmouseout="this.className = this.orignalclassName;" onmouseover="this.orignalclassName = this.className;this.className = &#39;altoverow&#39;;" class="">
                                                                    <td style="width: 25px;">
                                                                        <input type="image" name="ctl00$cpmaster$grdusuarios$ctl02$img1" id="cpmaster_grdusuarios_img1_0" title="Seleccionar Registro" src="./Registro de Nuevos Usuarios3_files/front.png" style="background-color: Transparent; height: 20px; width: 20px;">
                                                                    </td>
                                                                    <td align="center" style="width: 80px;">
                                                                        <span id="cpmaster_grdusuarios_id_per_0">2522812CB</span>
                                                                    </td>
                                                                    <td align="left" style="width: 300px;">
                                                                        <span id="cpmaster_grdusuarios_nomraz_0">*XIMENA ROSARIO ROMERO VILLAZON - SERVICIOS DE CONSULTORIA*</span>
                                                                    </td>
                                                                </tr>
                                                                <tr onmouseout="this.className = this.orignalclassName;" onmouseover="this.orignalclassName = this.className;this.className = &#39;altoverow&#39;;">
                                                                    <td style="width: 25px;">
                                                                        <input type="image" name="ctl00$cpmaster$grdusuarios$ctl03$img1" id="cpmaster_grdusuarios_img1_1" title="Seleccionar Registro" src="./Registro de Nuevos Usuarios3_files/front.png" style="background-color: Transparent; height: 20px; width: 20px;">
                                                                    </td>
                                                                    <td align="center" style="width: 80px;">
                                                                        <span id="cpmaster_grdusuarios_id_per_1">3387333</span>
                                                                    </td>
                                                                    <td align="left" style="width: 300px;">
                                                                        <span id="cpmaster_grdusuarios_nomraz_1">ALDO MAUIRICIO ARANA MARQUINA</span>
                                                                    </td>
                                                                </tr>
                                                                <tr onmouseout="this.className = this.orignalclassName;" onmouseover="this.orignalclassName = this.className;this.className = &#39;altoverow&#39;;" class="altoverow">
                                                                    <td style="width: 25px;">
                                                                        <input type="image" name="ctl00$cpmaster$grdusuarios$ctl04$img1" id="cpmaster_grdusuarios_img1_2" title="Seleccionar Registro" src="./Registro de Nuevos Usuarios3_files/front.png" style="background-color: Transparent; height: 20px; width: 20px;">
                                                                    </td>
                                                                    <td align="center" style="width: 80px;">
                                                                        <span id="cpmaster_grdusuarios_id_per_2">C5369550</span>
                                                                    </td>
                                                                    <td align="left" style="width: 300px;">
                                                                        <span id="cpmaster_grdusuarios_nomraz_2">ALFARO VALVERDE JOSE</span>
                                                                    </td>
                                                                </tr>
                                                                <tr onmouseout="this.className = this.orignalclassName;" onmouseover="this.orignalclassName = this.className;this.className = &#39;altoverow&#39;;" class="">
                                                                    <td style="width: 25px;">
                                                                        <input type="image" name="ctl00$cpmaster$grdusuarios$ctl05$img1" id="cpmaster_grdusuarios_img1_3" title="Seleccionar Registro" src="./Registro de Nuevos Usuarios3_files/front.png" style="background-color: Transparent; height: 20px; width: 20px;">
                                                                    </td>
                                                                    <td align="center" style="width: 80px;">
                                                                        <span id="cpmaster_grdusuarios_id_per_3">4770030</span>
                                                                    </td>
                                                                    <td align="left" style="width: 300px;">
                                                                        <span id="cpmaster_grdusuarios_nomraz_3">ALVARO REYES</span>
                                                                    </td>
                                                                </tr>
                                                                <tr onmouseout="this.className = this.orignalclassName;" onmouseover="this.orignalclassName = this.className;this.className = &#39;altoverow&#39;;" class="">
                                                                    <td style="width: 25px;">
                                                                        <input type="image" name="ctl00$cpmaster$grdusuarios$ctl06$img1" id="cpmaster_grdusuarios_img1_4" title="Seleccionar Registro" src="./Registro de Nuevos Usuarios3_files/front.png" style="background-color: Transparent; height: 20px; width: 20px;">
                                                                    </td>
                                                                    <td align="center" style="width: 80px;">
                                                                        <span id="cpmaster_grdusuarios_id_per_4">1545453-1</span>
                                                                    </td>
                                                                    <td align="left" style="width: 300px;">
                                                                        <span id="cpmaster_grdusuarios_nomraz_4">ARABE PAZ DALCY TERESA</span>
                                                                    </td>
                                                                </tr>
                                                                <tr class="pagerstyle">
                                                                    <td colspan="3">Pagina&nbsp;&nbsp;
                                               
                                                                        <input name="ctl00$cpmaster$grdusuarios$ctl08$IraPag" type="text" value="1" onchange="javascript:setTimeout(&#39;__doPostBack(\&#39;ctl00$cpmaster$grdusuarios$ctl08$IraPag\&#39;,\&#39;\&#39;)&#39;, 0)" onkeypress="if (WebForm_TextBoxKeyHandler(event) == false) return false;" id="cpmaster_grdusuarios_IraPag" onfocus="DoFocus(this);" onblur="DoBlur(this);" style="color: #336699; font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold; height: 18px; width: 50px;">
                                                                        &nbsp;&nbsp;de&nbsp;&nbsp;
                                               
                                                                        <span id="cpmaster_grdusuarios_lbltotalpaginas">13</span>&nbsp;&nbsp;
                                               
                                                                        <input type="submit" name="ctl00$cpmaster$grdusuarios$ctl08$btnfirst" value="" id="cpmaster_grdusuarios_btnfirst" title="Primera Página" class="pagfirst" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                                                        <input type="submit" name="ctl00$cpmaster$grdusuarios$ctl08$btnprevious" value="" id="cpmaster_grdusuarios_btnprevious" title="Página Anterior" class="pagprev" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                                                        <input type="submit" name="ctl00$cpmaster$grdusuarios$ctl08$btnnext" value="" id="cpmaster_grdusuarios_btnnext" title="Página Siguiente" class="pagnext" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                                                        <input type="submit" name="ctl00$cpmaster$grdusuarios$ctl08$btnlast" value="" id="cpmaster_grdusuarios_btnlast" title="Ultima Página" class="paglast" style="font-family: Arial,Helvetica,sans-serif; font-size: 11px; font-weight: bold;">
                                                                    </td>
                                                                </tr>
                                                            </tbody>
                                                        </table>--%>
                                                    </div>
                                                </div>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" colspan="4" style="height: 22px">&nbsp;
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                        <p class="links">
                            <a class="error">
                                <span id="cpmaster_lblmensaje" class="error"></span></a>
                        </p>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- Fin Contenido -->
</asp:Content>
