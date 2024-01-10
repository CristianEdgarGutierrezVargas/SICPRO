using DevExpress.Export;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.Exceptions
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            /*if (Context.Request.UrlReferrer != null)
            {
                this.hplAtras.NavigateUrl = Context.Request.UrlReferrer.ToString();
            }
            else
            {
                this.hplAtras.Visible = false;
            }*/
            string strMensajeError = Request.Params.Get("error");
            if (strMensajeError != null && !strMensajeError.Equals(String.Empty))
            {
                if (strMensajeError == "ACCESO")
                {
                    lblMensajeError.Text = "No tiene permisos suficientes.";
                }
                else
                {
                    lblMensajeError.Text = strMensajeError;
                    //Notificacion.Informacion("ADMIN SERVICIOS CANALES", strMensajeError);
                }
            }

            if (System.Web.HttpContext.Current.Session["ERROR_LIST"] != null)
            {
                show.Visible = true;
                DetalleError.DataSource = System.Web.HttpContext.Current.Session["ERROR_LIST"];
                DetalleError.DataBind();
            }
            else
            {
                show.Visible = false;
            }

        }

        protected void DetalleError_DataBinding(object sender, EventArgs e)
        {
            DetalleError.DataSource = System.Web.HttpContext.Current.Session["ERROR_LIST"];
        }

        protected void btnDescargar_Click(object sender, EventArgs e)
        {
            DetalleError.ExportXlsToResponse(new XlsExportOptionsEx { ExportType = ExportType.WYSIWYG, SheetName = "Detalle" });
        }
    }
}