<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.Exceptions.Error" %>
<%@ Register Assembly="DevExpress.Web.Bootstrap.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.Bootstrap" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v23.1, Version=23.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../../Content/bootstrap.css" rel="stylesheet" />
    <script src="../../../Scripts/bootstrap.js"></script>
    <script src="../../../Scripts/jquery-3.7.1.js"></script>
</head>
<body>
    <form id="form1" runat="server">
       <div class="container">
         <div class="row">
           <div id="block_error">
            <div>
                <img src="../../../UI/img/logo_Previcor.png"  width="200"/>
             <%--<h2>Error 404. Oops you've have encountered an error</h2>--%>
                <h2>Ocurrio un error, si el problema persiste contacte al administrador del sistema.</h2>
            <p>
                <asp:Label ID="lblMensajeError" runat="server" EnableTheming="True"></asp:Label>
           <%-- It apperrs that Either something went wrong or the page doesn't exist anymore..<br />
            This website is temporarily unable to service your request as it has exceeded it’s resource limit. Please check back shortly.--%>
            </p>
            <p>
            <asp:HyperLink ID="hplInicio" runat="server" Font-Size="Small" NavigateUrl="~/Default.aspx">Inicio</asp:HyperLink>
                            
            </p>
            <div id="show" runat="server">
              <a href="#" id="linkName" style="font-size:x-small">VER DETALLES</a>
            </div>

            </div>
           </div>
         </div>

         <div class="row"><!-- https://stackoverflow.com/questions/10009431/what-is-the-easiest-way-to-put-an-index-to-a-repeater-control-in-net -->       
            <div class="col-1">
          
            </div>
            <div class="col-10">
               <div class="menu" style="display: none;">   
                <dx:BootstrapGridView ID="DetalleError" runat="server" AutoGenerateColumns="False" OnDataBinding="DetalleError_DataBinding">
                    <SettingsPager Visible="False">
                    </SettingsPager>
                    <Columns>
                        <dx:BootstrapGridViewTextColumn VisibleIndex="0" Caption="#" >
                            <DataItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text="<%# Container.ItemIndex + 1 %>"></asp:Label>
                            </DataItemTemplate>
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="ErrorMessage" VisibleIndex="1">
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="InnerException" VisibleIndex="2">
                        </dx:BootstrapGridViewTextColumn>
                        <dx:BootstrapGridViewTextColumn FieldName="StackTrace" VisibleIndex="3">
                        </dx:BootstrapGridViewTextColumn>                        
                    </Columns>
                 </dx:BootstrapGridView>
                  <dx:BootstrapButton runat="server" Text="Descargar" ID="btnDescargar" OnClick="btnDescargar_Click">
                    <CssClasses Icon="fa fa-file-excel-o" />
                </dx:BootstrapButton>
              </div> 
           </div>
            <div class="col-1">
          
            </div>
        </div>           

            <script>
                $(document).ready(function () {
                    $('#show').click(function () {
                        if ($('#linkName').text() == "VER DETALLES") $('#linkName').text("OCULTAR DETALLES");
                        else $('#linkName').text("VER DETALLES");
                        $('.menu').toggle("slide");
                    });
                });
            </script>

        
       </div>
    </form>
</body>
</html>
