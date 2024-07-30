<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="re_viewer.aspx.cs" Inherits="PresentacionWeb.Sitio.Vista.Reportes.re_viewer" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src='<%=ResolveUrl("~/crystalreportviewers13/js/crviewer/crv.js")%>' type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <cr:crystalreportviewer runat="server" autodatabind="true" ID="CrystalReportViewer1" GroupTreeStyle-ShowLines="False" Height="50px" ToolPanelView="None" Width="350px"></cr:crystalreportviewer>
        </div>
    </form>
</body>
</html>
