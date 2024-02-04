using DevExpress.Web.Bootstrap;
using EntidadesClases.ModelSicPro;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        ConsumoCommon _objConsumoCommon = new ConsumoCommon();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            CargaMenu();
        }

        public void Page_Error(object sender, EventArgs e)
        {
            string mensajeError = string.Empty;
            Exception objErr = Server.GetLastError();
            if (objErr.InnerException == null)
                mensajeError = objErr.Message;
            else
                mensajeError = objErr.InnerException.Message;
            Response.Redirect("~/Sitio/Vista/Exceptions/Error.aspx?error=" + mensajeError.Replace("\r\n", ""));
        }

        private void CargaMenu()
        {
            var IdRolSession = Session["roles"];
            if (IdRolSession == null)
            {
                return;
            }
            var idRol = Convert.ToInt64(Session["roles"].ToString());
            var lstGroupComponents = _objConsumoCommon.ObtenerTablaComp(0, idRol);

            foreach (var itemGroupComponent in lstGroupComponents)
            {
                var objCurrentGroup = new BootstrapAccordionGroup();
                objCurrentGroup.Text = itemGroupComponent.desc_comp;
                objCurrentGroup.Visible = true;
                objCurrentGroup.AllowExpanding = true;
                objCurrentGroup.Expanded = false;
                objCurrentGroup.HeaderBadge.IconCssClass = string.IsNullOrEmpty(itemGroupComponent.icono)? "" : itemGroupComponent.icono;
                dxMenu.Groups.Add(objCurrentGroup);

                var lstItemComponentGroup = _objConsumoCommon.ObtenerTablaComp(itemGroupComponent.id_com, idRol);

                foreach (var itemComponent in lstItemComponentGroup)
                {
                    var objCurrentItem = new BootstrapAccordionItem();
                    objCurrentItem.Text = itemComponent.desc_comp;
                    objCurrentItem.NavigateUrl = itemComponent.vinculo;
                    //objCurrentItem.Target= itemComponent.vinculo;
                    //objCurrentItem.IconCssClass = "fa fa-user";
                    objCurrentItem.IconCssClass = string.IsNullOrEmpty(itemComponent.icono) ? "" : itemComponent.icono;

                    objCurrentGroup.Items.Add(objCurrentItem);
                }
                
            }
        }
    }
}