using Common;
using Logica.Consumo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWeb.Sitio.Vista.RegistroProduccion
{
    public partial class wgr_persona1 : System.Web.UI.Page
    {
        ConsumoRegistroProd _objConsumoRegistroProd = new ConsumoRegistroProd();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }
            CargaInicial();
        }

        #region Metodos

        private void CargaInicial()
        {
            var lstSucursales = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_suc);

            cmb_id_suc.DataSource = lstSucursales;
            cmb_id_suc.DataValueField = "id_par";
            cmb_id_suc.DataValueField = "desc_param";
            cmb_id_suc.DataBind();


            var lstTipoPersona = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_tper);

            cmb_tper.DataSource = lstTipoPersona;
            cmb_tper.DataValueField = "id_par";
            cmb_tper.DataValueField = "desc_param";
            cmb_tper.DataBind();

            var lstSalutacionPersonal = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_sal);

            cmb_id_sal.DataSource = lstSalutacionPersonal;
            cmb_id_sal.DataValueField = "id_par";
            cmb_id_sal.DataValueField = "desc_param";
            cmb_id_sal.DataBind();

            var lstTipoRol = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_rol);

            cmb_id_rol.DataSource = lstTipoRol;
            cmb_id_rol.DataValueField = "id_par";
            cmb_id_rol.DataValueField = "desc_param";
            cmb_id_rol.DataBind();

            var lstTipoDocumento = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_tdoc);

            cmb_tipodoc.DataSource = lstTipoDocumento;
            cmb_tipodoc.DataValueField = "id_par";
            cmb_tipodoc.DataValueField = "desc_param";
            cmb_tipodoc.DataBind();

            var lstEmisionDocumento = _objConsumoRegistroProd.ObtenerLista(CParametros.LexColumna_id_emis);

            cmb_id_emis.DataSource = lstEmisionDocumento;
            cmb_id_emis.DataValueField = "id_par";
            cmb_id_emis.DataValueField = "desc_param";
            cmb_id_emis.DataBind();
        }

        #endregion
    }
}